﻿// Decompiled with JetBrains decompiler
// Type: DailyMission0272Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using MissionData;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class DailyMission0272Menu : BackButtonMenuBase
{
  [SerializeField]
  public GameObject[] dirMissionListObject;
  [SerializeField]
  public UIGrid[] grid;
  [SerializeField]
  public UIScrollView[] scrollview;
  [SerializeField]
  private GameObject[] dirMissionCleared;
  [SerializeField]
  private GameObject[] dirBadge;
  [SerializeField]
  private SpreadColorButton[] tabBtn;
  [SerializeField]
  [Tooltip("ギルドミッション表示時、ギルド未所属時に表示")]
  private GameObject objGuildNotAffiliation;
  [SerializeField]
  [Tooltip("objGuildNotAffiliationを表示する際に調整する")]
  private UIWidget widgetGuildMain;
  private DailyMission0272Scene parentScene;
  private int? originalGuildMainAnchorAbsolute;
  private HelpCategory helpCategory;
  private Dictionary<DailyMission0272Menu.ScrollType, MissionType> scrollMissionType = new Dictionary<DailyMission0272Menu.ScrollType, MissionType>()
  {
    {
      DailyMission0272Menu.ScrollType.Daily,
      MissionType.daily
    },
    {
      DailyMission0272Menu.ScrollType.Game,
      MissionType.game
    },
    {
      DailyMission0272Menu.ScrollType.Period,
      MissionType.period
    },
    {
      DailyMission0272Menu.ScrollType.Guild,
      MissionType.guild
    }
  };
  private DailyMission0272Menu.ScrollType scrollType;
  private bool[] isScrollInit = new bool[Enum.GetValues(typeof (DailyMission0272Menu.ScrollType)).Length];
  private GameObject scrollPrefab;
  private Dictionary<int, IMissionAchievement[]> missionDic;

  public bool isGuildNotAffiliation { get; private set; }

  private IEnumerator createPanel(int type, GameObject prefab, IMissionAchievement pdm)
  {
    prefab.Clone(this.grid[type].transform);
    yield break;
  }

  private IEnumerator CreateScrolllObject(
    int type,
    Dictionary<int, IMissionAchievement[]> dic,
    GameObject prefab,
    bool isTabBtnDisplay = false)
  {
    ((IEnumerable<GameObject>) this.dirMissionListObject).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    if (isTabBtnDisplay)
      this.dirBadge[type].SetActive(((IEnumerable<IMissionAchievement>) dic[type]).Any<IMissionAchievement>((Func<IMissionAchievement, bool>) (x => x.isCleared && !x.isReceived)));
    UIGrid g = this.grid[type];
    g.transform.Clear();
    IMissionAchievement[] missionAchievementArray = dic[type];
    for (int index = 0; index < missionAchievementArray.Length; ++index)
    {
      IMissionAchievement pdm = missionAchievementArray[index];
      IEnumerator e = this.createPanel(type, prefab, pdm);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    missionAchievementArray = (IMissionAchievement[]) null;
    g.onReposition = (UIGrid.OnReposition) (() =>
    {
      this.scrollview[type].ResetPosition();
      g.onReposition = (UIGrid.OnReposition) null;
    });
    g.Reposition();
    this.dirMissionCleared[type].SetActive(((IEnumerable<IMissionAchievement>) dic[type]).Count<IMissionAchievement>() == 0);
  }

  private void DisplayList(DailyMission0272Menu.ScrollType type)
  {
    int num = (int) type;
    for (int index = 0; index < this.tabBtn.Length; ++index)
      this.tabBtn[index].isEnabled = index != num;
    ((IEnumerable<GameObject>) this.dirMissionListObject).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    this.dirMissionListObject[(int) type].gameObject.SetActive(true);
    if (!this.isScrollInit[(int) type])
    {
      this.isScrollInit[(int) type] = true;
      this.scrollview[(int) type].ResetPosition();
    }
    if (!((UnityEngine.Object) this.objGuildNotAffiliation != (UnityEngine.Object) null))
      return;
    this.objGuildNotAffiliation.SetActive(type == DailyMission0272Menu.ScrollType.Guild && this.isGuildNotAffiliation);
  }

  public IEnumerator InitMissionList(
    IMissionAchievement[] playerDailyMissions,
    int[] types,
    bool isTabBtnDisplay,
    bool updateDataVersion)
  {
    ((IEnumerable<bool>) this.isScrollInit).ForEach<bool>((System.Action<bool>) (x => x = false));
    HashSet<MissionType> missionTargets = new HashSet<MissionType>(((IEnumerable<int>) types).Select<int, MissionType>((Func<int, MissionType>) (i => this.scrollMissionType[(DailyMission0272Menu.ScrollType) i])));
    Dictionary<MissionType, IMissionAchievement[]> dictionary = ((IEnumerable<IMissionAchievement>) playerDailyMissions).Where<IMissionAchievement>((Func<IMissionAchievement, bool>) (x => x.mission != null && missionTargets.Contains(x.mission.missionType) && x.isShow)).GroupBy<IMissionAchievement, MissionType>((Func<IMissionAchievement, MissionType>) (x => x.mission.missionType)).ToDictionary<IGrouping<MissionType, IMissionAchievement>, MissionType, IMissionAchievement[]>((Func<IGrouping<MissionType, IMissionAchievement>, MissionType>) (k => k.Key), (Func<IGrouping<MissionType, IMissionAchievement>, IMissionAchievement[]>) (v => this.sortMission(v.Key, (IEnumerable<IMissionAchievement>) v).ToArray<IMissionAchievement>()));
    if (this.missionDic == null)
      this.missionDic = new Dictionary<int, IMissionAchievement[]>();
    foreach (int type in types)
    {
      IMissionAchievement[] missionAchievementArray;
      if (!dictionary.TryGetValue(this.scrollMissionType[(DailyMission0272Menu.ScrollType) type], out missionAchievementArray))
        missionAchievementArray = new IMissionAchievement[0];
      this.missionDic[type] = missionAchievementArray;
      this.dirBadge[type].SetActive(((IEnumerable<IMissionAchievement>) missionAchievementArray).Any<IMissionAchievement>((Func<IMissionAchievement, bool>) (x => x.isCleared && !x.isReceived)));
    }
    ((IEnumerable<GameObject>) this.dirMissionListObject).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(true)));
    int[] numArray = types;
    for (int index = 0; index < numArray.Length; ++index)
    {
      IEnumerator e = this.CreateScrolllObject(numArray[index], this.missionDic, this.scrollPrefab, isTabBtnDisplay);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    numArray = (int[]) null;
    if (updateDataVersion && (UnityEngine.Object) this.parentScene != (UnityEngine.Object) null)
      this.parentScene.updateDataVersion();
    this.DisplayList(this.scrollType);
  }

  private IEnumerable<IMissionAchievement> sortMission(
    MissionType missionType,
    IEnumerable<IMissionAchievement> sortDat)
  {
    return missionType != MissionType.guild ? sortDat : (IEnumerable<IMissionAchievement>) sortDat.OrderBy<IMissionAchievement, int>((Func<IMissionAchievement, int>) (x =>
    {
      if (x.isReceived)
        return 3;
      if (x.isCleared)
        return 0;
      return x.isOwnCleared ? 1 : 2;
    }));
  }

  public IEnumerator Init(bool resetCurrentTab = true)
  {
    DailyMission0272Menu dailyMission0272Menu1 = this;
    if (dailyMission0272Menu1.helpCategory == null)
      dailyMission0272Menu1.helpCategory = Array.Find<HelpCategory>(MasterData.HelpCategoryList, (Predicate<HelpCategory>) (x => x.name == "ミッション"));
    if ((UnityEngine.Object) dailyMission0272Menu1.parentScene == (UnityEngine.Object) null)
      dailyMission0272Menu1.parentScene = dailyMission0272Menu1.GetComponent<DailyMission0272Scene>();
    foreach (Component component1 in dailyMission0272Menu1.grid)
    {
      foreach (Component component2 in component1.transform)
        UnityEngine.Object.Destroy((UnityEngine.Object) component2.gameObject);
    }
    IEnumerator e1 = ServerTime.WaitSync();
    while (e1.MoveNext())
      yield return e1.Current;
    e1 = (IEnumerator) null;
    Future<WebAPI.Response.DailymissionIndex> future = WebAPI.DailymissionIndex((System.Action<WebAPI.Response.UserError>) (e =>
    {
      WebAPI.DefaultUserErrorCallback(e);
      MypageScene.ChangeSceneOnError();
    }));
    e1 = future.Wait();
    while (e1.MoveNext())
      yield return e1.Current;
    e1 = (IEnumerator) null;
    if (future.Result != null)
    {
      Future<WebAPI.Response.GuildmissionIndex> future2 = WebAPI.GuildmissionIndex((System.Action<WebAPI.Response.UserError>) (e =>
      {
        WebAPI.DefaultUserErrorCallback(e);
        MypageScene.ChangeSceneOnError();
      }));
      e1 = future2.Wait();
      while (e1.MoveNext())
        yield return e1.Current;
      e1 = (IEnumerator) null;
      if (future2.Result != null)
      {
        DailyMission0272Menu dailyMission0272Menu2 = dailyMission0272Menu1;
        PlayerAffiliation current = PlayerAffiliation.Current;
        int num = (current != null ? (current.isGuildMember() ? 1 : 0) : 0) == 0 ? 1 : 0;
        dailyMission0272Menu2.isGuildNotAffiliation = num != 0;
        if ((UnityEngine.Object) dailyMission0272Menu1.widgetGuildMain != (UnityEngine.Object) null)
        {
          if (!dailyMission0272Menu1.originalGuildMainAnchorAbsolute.HasValue)
            dailyMission0272Menu1.originalGuildMainAnchorAbsolute = new int?(dailyMission0272Menu1.widgetGuildMain.topAnchor.absolute);
          dailyMission0272Menu1.widgetGuildMain.topAnchor.absolute = dailyMission0272Menu1.isGuildNotAffiliation ? -314 : dailyMission0272Menu1.originalGuildMainAnchorAbsolute.Value;
        }
        if ((UnityEngine.Object) dailyMission0272Menu1.scrollPrefab == (UnityEngine.Object) null)
        {
          Future<GameObject> scrollPrefabF = Res.Prefabs.dailymission027_2.dir_Daily_Mission.Load<GameObject>();
          e1 = scrollPrefabF.Wait();
          while (e1.MoveNext())
            yield return e1.Current;
          e1 = (IEnumerator) null;
          dailyMission0272Menu1.scrollPrefab = scrollPrefabF.Result;
          scrollPrefabF = (Future<GameObject>) null;
        }
        List<IMissionAchievement> list = ((IEnumerable<PlayerDailyMissionAchievement>) future.Result.player_daily_missions).Select<PlayerDailyMissionAchievement, IMissionAchievement>((Func<PlayerDailyMissionAchievement, IMissionAchievement>) (dm => Util.Create(dm))).ToList<IMissionAchievement>();
        GuildMissionInfo[] playerGuildMissions = future2.Result.player_guild_missions;
        if ((playerGuildMissions != null ? playerGuildMissions.Length : 0) > 0)
          list.AddRange(((IEnumerable<GuildMissionInfo>) future2.Result.player_guild_missions).Select<GuildMissionInfo, IMissionAchievement>((Func<GuildMissionInfo, IMissionAchievement>) (gm => Util.Create(gm))));
        if (resetCurrentTab)
          dailyMission0272Menu1.scrollType = DailyMission0272Menu.ScrollType.Daily;
        int[] types = new int[4]{ 0, 1, 2, 3 };
        e1 = dailyMission0272Menu1.InitMissionList(list.ToArray(), types, true, true);
        while (e1.MoveNext())
          yield return e1.Current;
        e1 = (IEnumerator) null;
      }
    }
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public void IbtnDaily()
  {
    if (this.scrollType == DailyMission0272Menu.ScrollType.Daily)
      return;
    this.scrollType = DailyMission0272Menu.ScrollType.Daily;
    this.DisplayList(this.scrollType);
  }

  public void IbtnGame()
  {
    if (this.scrollType == DailyMission0272Menu.ScrollType.Game)
      return;
    this.scrollType = DailyMission0272Menu.ScrollType.Game;
    this.DisplayList(this.scrollType);
  }

  public void IbtnPeriod()
  {
    if (this.scrollType == DailyMission0272Menu.ScrollType.Period)
      return;
    this.scrollType = DailyMission0272Menu.ScrollType.Period;
    this.DisplayList(this.scrollType);
  }

  public void IbtnGuild()
  {
    if (this.scrollType == DailyMission0272Menu.ScrollType.Guild)
      return;
    this.scrollType = DailyMission0272Menu.ScrollType.Guild;
    this.DisplayList(this.scrollType);
  }

  public void onClickedHelp()
  {
    if (this.helpCategory == null || this.IsPushAndSet())
      return;
    Help0152Scene.ChangeScene(true, this.helpCategory);
  }

  private enum ScrollType
  {
    Daily,
    Game,
    Period,
    Guild,
  }
}
