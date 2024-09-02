// Decompiled with JetBrains decompiler
// Type: DailyMission0272Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
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
  private UISprite[] tabBtnSprite;
  private DailyMission0272Menu.ScrollType scrollType;
  private bool[] isScrollInit = new bool[3];
  private GameObject scrollPrefab;
  private Dictionary<int, PlayerDailyMissionAchievement[]> missionDic;

  [DebuggerHidden]
  private IEnumerator createPanel(
    DailyMission0272Menu.ScrollType type,
    GameObject prefab,
    PlayerDailyMissionAchievement pdm)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CcreatePanel\u003Ec__Iterator6D3()
    {
      prefab = prefab,
      type = type,
      pdm = pdm,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Epdm = pdm,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateScrolllObject(
    DailyMission0272Menu.ScrollType type,
    Dictionary<int, PlayerDailyMissionAchievement[]> dic,
    GameObject prefab,
    bool isTabBtnDisplay = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CCreateScrolllObject\u003Ec__Iterator6D4()
    {
      isTabBtnDisplay = isTabBtnDisplay,
      type = type,
      dic = dic,
      prefab = prefab,
      \u003C\u0024\u003EisTabBtnDisplay = isTabBtnDisplay,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Edic = dic,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  private void DisplayList(DailyMission0272Menu.ScrollType type)
  {
    ((IEnumerable<SpreadColorButton>) this.tabBtn).ForEach<SpreadColorButton>((Action<SpreadColorButton>) (x => x.defaultColor = x.pressed = x.hover = Color.gray));
    ((IEnumerable<SpreadColorButton>) this.tabBtn).ForEach<SpreadColorButton>((Action<SpreadColorButton>) (x => x.SetTweenColor(false, 0.0f, Color.gray)));
    this.tabBtn[(int) type].defaultColor = this.tabBtn[(int) type].pressed = this.tabBtn[(int) type].pressed = Color.white;
    this.tabBtn[(int) type].SetTweenColor(false, 0.0f, Color.white);
    ((IEnumerable<UISprite>) this.tabBtnSprite).ForEach<UISprite>((Action<UISprite>) (x => x.color = Color.gray));
    this.tabBtnSprite[(int) type].color = Color.white;
    ((IEnumerable<GameObject>) this.dirMissionListObject).ForEach<GameObject>((Action<GameObject>) (x => x.gameObject.SetActive(false)));
    this.dirMissionListObject[(int) type].gameObject.SetActive(true);
    if (this.isScrollInit[(int) type])
      return;
    this.isScrollInit[(int) type] = true;
    this.scrollview[(int) type].ResetPosition();
  }

  [DebuggerHidden]
  public IEnumerator InitMissionList(
    PlayerDailyMissionAchievement[] playerDailyMissions,
    bool isTabBtnDisplay = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CInitMissionList\u003Ec__Iterator6D5()
    {
      playerDailyMissions = playerDailyMissions,
      isTabBtnDisplay = isTabBtnDisplay,
      \u003C\u0024\u003EplayerDailyMissions = playerDailyMissions,
      \u003C\u0024\u003EisTabBtnDisplay = isTabBtnDisplay,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CInit\u003Ec__Iterator6D6()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
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

  private enum ScrollType
  {
    Daily,
    Game,
    Period,
    Max,
  }
}
