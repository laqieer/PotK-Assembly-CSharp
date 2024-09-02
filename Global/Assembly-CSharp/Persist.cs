// Decompiled with JetBrains decompiler
// Type: Persist
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public static class Persist
{
  public static Persist<Persist.Auth> auth = new Persist<Persist.Auth>("auth.dat");
  public static Persist<Persist.SortOrder> sortOrder = new Persist<Persist.SortOrder>("order.dat");
  public static Persist<Persist.GuideUnitSortAndFilter> guidUnitSortAndFilter = new Persist<Persist.GuideUnitSortAndFilter>("guidUnitSortAndFilter.dat");
  public static Persist<Persist.GuideEnemySortAndFilter> guidEnemySortAndFilter = new Persist<Persist.GuideEnemySortAndFilter>("guidEnemySortAndFilter.dat");
  public static Persist<Persist.GuideGearSortAndFilter> guidGearSortAndFilter = new Persist<Persist.GuideGearSortAndFilter>("guidGearSortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00410SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00410SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00411SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00411SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00412SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00412SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00468SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00468SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit0048SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit0048SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00481SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00481SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00491SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00491SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit004431SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit004431SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00486SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00486SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00487SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00487SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit005411SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit005411SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit005468SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit005468SortAndFilter.dat");
  public static Persist<Persist.EmblemSortCategory> emblemSortCategory = new Persist<Persist.EmblemSortCategory>("emblemSortCategory.dat");
  public static Persist<Persist.InfoUnRead> infoUnRead = new Persist<Persist.InfoUnRead>("infoUnRead.dat");
  public static Persist<Persist.LastInfoTime> lastInfoTime = new Persist<Persist.LastInfoTime>("lastInfoTime.dat");
  public static Persist<Persist.UserPolicy> userPolicy = new Persist<Persist.UserPolicy>("userPolicy.dat");
  public static Persist<Persist.Volume> volume = new Persist<Persist.Volume>("volume.dat");
  public static Persist<Persist.Notification> notification = new Persist<Persist.Notification>("notification.dat");
  public static Persist<Persist.PushNotification> pushnotification = new Persist<Persist.PushNotification>("pushnotification.dat");
  public static Persist<BE> battleEnvironment = new Persist<BE>("be.dat");
  public static Persist<Persist.Tutorial> tutorial = new Persist<Persist.Tutorial>("tutorial.dat");
  public static Persist<Persist.QuestLastSortie> lastsortie = new Persist<Persist.QuestLastSortie>("lastsortie.dat");
  public static Persist<Persist.EventQuestExplanation> explanation = new Persist<Persist.EventQuestExplanation>("explanation.dat");
  public static Persist<Persist.Duel> duel = new Persist<Persist.Duel>("duel.dat");
  public static Persist<Persist.Battle> battle = new Persist<Persist.Battle>("battle.dat");
  public static Persist<Persist.BattleIcon> battleIcon = new Persist<Persist.BattleIcon>("battleIcon.dat");
  public static Persist<Persist.BattleNoDuel> battleNoDuel = new Persist<Persist.BattleNoDuel>("battleNoDuel.dat");
  public static Persist<Persist.BattleTimeSetting> battleTimeSetting = new Persist<Persist.BattleTimeSetting>("battletimesetting.dat");
  public static Persist<Persist.OpeningMovie> opmovie = new Persist<Persist.OpeningMovie>("opmovie.dat");
  public static Persist<Persist.DeckOrganized> deckOrganized = new Persist<Persist.DeckOrganized>("deckOrganized.dat");
  public static Persist<Persist.ColosseumDeckOrganized> colosseumDeckOrganized = new Persist<Persist.ColosseumDeckOrganized>("colosseimDeckOrganized.dat");
  public static Persist<Persist.ColosseumTransactionID> colosseumEnv = new Persist<Persist.ColosseumTransactionID>("colosseum.dat");
  public static Persist<Persist.ColosseumOpen> colosseumOpen = new Persist<Persist.ColosseumOpen>("colosseumOpen.dat");
  public static Persist<Persist.ColosseumTutorial> colosseumTutorial = new Persist<Persist.ColosseumTutorial>("colosseumTutorial.dat");
  public static Persist<Persist.VersusDeckOrganized> versusDeckOrganized = new Persist<Persist.VersusDeckOrganized>("versusDeckOrganized.dat");
  public static Persist<Persist.PvPInfo> pvpInfo = new Persist<Persist.PvPInfo>("pvpInfo.dat");
  public static Persist<Persist.PvPSuspend> pvpSuspend = new Persist<Persist.PvPSuspend>("pvpSuspend.dat");
  public static Persist<Persist.CacheInfo> cacheInfo = new Persist<Persist.CacheInfo>("cacheInfo.dat");
  public static Persist<Persist.PvpUnitPositions> pvpUnitPositions_order1 = new Persist<Persist.PvpUnitPositions>("pvpUnitPositions_order1.dat");
  public static Persist<Persist.PvpUnitPositions> pvpUnitPositions_order2 = new Persist<Persist.PvpUnitPositions>("pvpUnitPositions_order2.dat");
  public static Persist<EarthDataManager.EarthData> earthData = new Persist<EarthDataManager.EarthData>("earth.dat");
  public static Persist<BE> earthBattleEnvironment = new Persist<BE>("earthbe.dat");
  public static Persist<Persist.FirstPGSSignIn> firstPGSSignIn = new Persist<Persist.FirstPGSSignIn>("firstPGSSignIn.dat");

  [Serializable]
  public class Auth
  {
    public string UUID;
    public string SecretKey;
    public string DeviceID;
    public bool FBLoginStatus;

    public Auth() => this.setDefault();

    public void ResetAllAuthInfo()
    {
      this.UUID = (string) null;
      this.SecretKey = (string) null;
      this.DeviceID = (string) null;
      this.FBLoginStatus = false;
      this.setDefault();
    }

    public bool IsNeedAuthRegister() => this.DeviceID == string.Empty;

    private void setDefault()
    {
      if (string.IsNullOrEmpty(this.UUID))
        this.UUID = SystemInfo.deviceUniqueIdentifier;
      if (string.IsNullOrEmpty(this.SecretKey))
        this.SecretKey = Guid.NewGuid().ToString();
      if (!string.IsNullOrEmpty(this.DeviceID))
        return;
      this.DeviceID = string.Empty;
    }
  }

  [Serializable]
  public class SortOrder
  {
    public int Weapon = 2;
    public int Unit = 4;
    public int Friend;
  }

  [Serializable]
  public class GuideUnitSortAndFilter
  {
    public List<GearKindEnum> gearKindEnumList = new List<GearKindEnum>();
    public List<int> unitFamilyOrNullList = new List<int>();
    public List<GuideSortAndFilter.GUIDE_CATEGORY_TYPE> unitCategoryList = new List<GuideSortAndFilter.GUIDE_CATEGORY_TYPE>();
    public GuideSortAndFilter.GUIDE_SORT_TYPE sortType = GuideSortAndFilter.GUIDE_SORT_TYPE.NUMBER;
    public GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE orderBuySort = GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE.BACK;
  }

  [Serializable]
  public class GuideEnemySortAndFilter
  {
    public List<GearKindEnum> gearKindEnumList = new List<GearKindEnum>();
    public List<int> unitFamilyOrNullList = new List<int>();
    public GuideSortAndFilter.GUIDE_SORT_TYPE sortType = GuideSortAndFilter.GUIDE_SORT_TYPE.NUMBER;
    public GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE orderBuySort = GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE.BACK;
  }

  [Serializable]
  public class GuideGearSortAndFilter
  {
    public List<GearKindEnum> gearKindEnumList = new List<GearKindEnum>();
    public List<GuideSortAndFilter.GUIDE_GEAR_CATEGORY_TYPE> unitCategoryList = new List<GuideSortAndFilter.GUIDE_GEAR_CATEGORY_TYPE>();
    public GuideSortAndFilter.GUIDE_SORT_TYPE sortType = GuideSortAndFilter.GUIDE_SORT_TYPE.NUMBER;
    public GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE orderBuySort = GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE.BACK;
  }

  [Serializable]
  public class UnitSortAndFilterInfo
  {
    public SortAndFilter.SORT_TYPE_ORDER_BUY order;
    public UnitSortAndFilter.SORT_TYPES sortType = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy;
    public UnitSortAndFilter.ModeTypes modeType;
    public List<bool> filter = new List<bool>();
    private bool isInit;

    public UnitSortAndFilterInfo() => this.setDefault();

    private void setDefault()
    {
      if (this.isInit)
        return;
      this.isInit = true;
      for (int index = 0; index < 38; ++index)
        this.filter.Add(true);
      switch (Persist.sortOrder.Data.Unit)
      {
        case 0:
          this.sortType = UnitSortAndFilter.SORT_TYPES.Level;
          break;
        case 1:
          this.sortType = UnitSortAndFilter.SORT_TYPES.Rarity;
          break;
        case 3:
          this.sortType = UnitSortAndFilter.SORT_TYPES.FightingPower;
          break;
        case 5:
          this.sortType = UnitSortAndFilter.SORT_TYPES.Cost;
          break;
        default:
          this.sortType = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy;
          break;
      }
    }
  }

  [Serializable]
  public class EmblemSortCategory
  {
    public int category;
  }

  [Serializable]
  public class InfoUnRead
  {
    private Dictionary<int, bool> unRead;

    public bool GetUnRead(int id)
    {
      if (this.unRead == null)
        this.unRead = new Dictionary<int, bool>();
      return this.unRead.ContainsKey(id);
    }

    public void SetUnRead(int id)
    {
      if (this.unRead == null)
        this.unRead = new Dictionary<int, bool>();
      if (this.unRead.ContainsKey(id))
        return;
      this.unRead.Add(id, true);
    }
  }

  [Serializable]
  public class LastInfoTime
  {
    private DateTime lastInfoTime;

    public DateTime GetLastInfoTime() => this.lastInfoTime;

    public void SetLastInfoTime(DateTime infoTime) => this.lastInfoTime = infoTime;
  }

  [Serializable]
  public class UserPolicy
  {
    private bool isUserPolicy;

    public bool GetUserPolicy() => this.isUserPolicy;

    public void SetUserPolicy(bool flag = true) => this.isUserPolicy = flag;
  }

  [Serializable]
  public class Volume
  {
    private bool isInit;
    public float Bgm;
    public float Se;
    public float Voice;

    public Volume() => this.setDefault();

    private void setDefault()
    {
      this.isInit = false;
      if (this.isInit)
        return;
      this.Bgm = 0.9f;
      this.Se = 0.75f;
      this.Voice = 0.85f;
      this.isInit = true;
    }
  }

  [Serializable]
  public class Notification
  {
    private bool isInit;
    public bool Ap;
    public bool Bp = true;

    public Notification() => this.setDefault();

    private void setDefault()
    {
      this.isInit = false;
      if (this.isInit)
        return;
      this.Ap = true;
      this.Bp = true;
      this.isInit = true;
    }
  }

  [Serializable]
  public class PushNotification
  {
    private bool isInit;
    public bool enablePush;

    public PushNotification() => this.setDefault();

    private void setDefault()
    {
      this.isInit = false;
      if (this.isInit)
        return;
      this.enablePush = true;
      this.isInit = true;
    }
  }

  [Serializable]
  public class Tutorial
  {
    public int CurrentPage;
    public int MiniGameScore;
    public int GachaUnitId;
    public string PlayerName;
    public Dictionary<string, bool> Hints;
    public bool signupCalled;
    public DateTime ChangeNextPageAt;
    public int LastPageIndex;

    public Tutorial() => this.setDefault();

    public int DuringSeconds()
    {
      return (int) (DateTime.Now - Persist.tutorial.Data.ChangeNextPageAt).TotalSeconds;
    }

    public bool HasMiniGameScore() => this.MiniGameScore >= 0;

    public bool IsFinishTutorial() => this.CurrentPage == this.LastPageIndex;

    public bool IsNotStartTutorial() => this.CurrentPage == 0;

    public void SetPageIndex(int page)
    {
      this.CurrentPage = page;
      this.ChangeNextPageAt = DateTime.Now;
    }

    public void SetTutorialFinish()
    {
      this.CurrentPage = this.LastPageIndex;
      this.ChangeNextPageAt = DateTime.Now;
    }

    private void setDefault()
    {
      this.CurrentPage = 0;
      this.GachaUnitId = 0;
      this.MiniGameScore = -1;
      this.PlayerName = string.Empty;
      this.Hints = new Dictionary<string, bool>();
      this.signupCalled = false;
      this.LastPageIndex = int.MaxValue;
      this.ChangeNextPageAt = DateTime.Now;
    }
  }

  [Serializable]
  public class QuestLastSortie
  {
    public int s_id;
    public int m_id;
    public int l_id;

    public QuestLastSortie() => this.setDefault();

    public void SaveLastSortie(int s_id, int m_id, int l_id)
    {
      this.s_id = s_id;
      this.m_id = m_id;
      this.l_id = l_id;
    }

    private void setDefault()
    {
      this.s_id = 0;
      this.m_id = 0;
      this.l_id = 0;
    }
  }

  [Serializable]
  public class EventQuestExplanation
  {
    public Dictionary<int, bool> Explanation;

    public EventQuestExplanation() => this.setDefault();

    public bool IsOpen(int sceneID)
    {
      bool flag = false;
      if (this.Explanation.ContainsKey(sceneID))
        flag = this.Explanation[sceneID];
      return flag;
    }

    private void setDefault() => this.Explanation = new Dictionary<int, bool>();
  }

  [Serializable]
  public class Duel
  {
    public int speed;

    public Duel() => this.setDefault();

    private void setDefault() => this.speed = 1;
  }

  [Serializable]
  public class Battle
  {
    public int sight;

    public Battle() => this.setDefault();

    private void setDefault() => this.sight = 1;
  }

  [Serializable]
  public class BattleIcon
  {
    public bool canDisp;

    public BattleIcon() => this.setDefault();

    private void setDefault() => this.canDisp = false;
  }

  [Serializable]
  public class BattleNoDuel
  {
    public bool noDuelScene;

    public BattleNoDuel() => this.setDefault();

    private void setDefault() => this.noDuelScene = false;
  }

  [Serializable]
  public class BattleTimeSetting
  {
    public int speed;

    public BattleTimeSetting() => this.setDefault();

    private void setDefault() => this.speed = 1;
  }

  [Serializable]
  public class OpeningMovie
  {
    public bool isPlayMovie;

    public OpeningMovie() => this.setDefault();

    private void setDefault() => this.isPlayMovie = false;
  }

  [Serializable]
  public class DeckOrganized
  {
    public int number;

    public DeckOrganized() => this.setDefault();

    private void setDefault() => this.number = 0;
  }

  [Serializable]
  public class ColosseumDeckOrganized
  {
    public int number = -1;

    public ColosseumDeckOrganized() => this.setDefault();

    private void setDefault() => this.number = -1;
  }

  [Serializable]
  public class ColosseumTransactionID
  {
    public string id;

    public ColosseumTransactionID() => this.setDefault();

    private void setDefault() => this.id = string.Empty;
  }

  [Serializable]
  public class ColosseumOpen
  {
    public bool isOpen;

    public ColosseumOpen() => this.setDefault();

    private void setDefault() => this.isOpen = false;
  }

  [Serializable]
  public class ColosseumTutorial
  {
    public int CurrentPage;

    public ColosseumTutorial() => this.setDefault();

    private void setDefault() => this.CurrentPage = 0;
  }

  [Serializable]
  public class VersusDeckOrganized
  {
    public int number;

    public VersusDeckOrganized() => this.setDefault();

    private void setDefault() => this.number = 0;
  }

  [Serializable]
  public class PvPInfo
  {
    public int currentPage;
    public PvpMatchingTypeEnum lastMatchingType;

    public PvPInfo() => this.setDefault();

    public void setDefault()
    {
      this.currentPage = 0;
      this.lastMatchingType = PvpMatchingTypeEnum.normal;
    }
  }

  [Serializable]
  public class PvPSuspend
  {
    public string host = string.Empty;
    public int port;
    public string token = string.Empty;
    public MpStage stage;
    public Player player;
    public Player enemy;
    public PvpMatchingTypeEnum matchingType;
    public int order;

    public PvPSuspend() => this.setDefault();

    private void setDefault()
    {
      this.order = 0;
      this.host = string.Empty;
      this.port = 0;
      this.token = string.Empty;
      this.stage = (MpStage) null;
      this.player = this.enemy = (Player) null;
      this.matchingType = PvpMatchingTypeEnum.normal;
    }
  }

  [Serializable]
  public class CacheInfo
  {
    public bool hasDeleted;

    public CacheInfo() => this.setDefault();

    private void setDefault() => this.hasDeleted = false;
  }

  [Serializable]
  public class PvpUnitPositions
  {
    public int stageId;
    public Tuple<int, int>[] positions;
    public int order;

    public PvpUnitPositions() => this.setDefault();

    private void setDefault()
    {
      this.stageId = -1;
      this.positions = new Tuple<int, int>[0];
    }

    public bool check(int stageId, int nbPositions, int order)
    {
      return this.stageId == stageId && this.positions.Length == nbPositions && this.order == order;
    }

    public bool check(MpStage stage, int nbPositions, int order)
    {
      return this.check(stage.stage_id, nbPositions, order);
    }

    public static void save(int stageId, List<BL.UnitPosition> upl, int order)
    {
      Persist.PvpUnitPositions pvpUnitPositions = order != 1 ? Persist.pvpUnitPositions_order2.Data : Persist.pvpUnitPositions_order1.Data;
      pvpUnitPositions.stageId = stageId;
      pvpUnitPositions.positions = upl.Select<BL.UnitPosition, Tuple<int, int>>((Func<BL.UnitPosition, Tuple<int, int>>) (up => new Tuple<int, int>(up.row, up.column))).ToArray<Tuple<int, int>>();
      if (order == 1)
        Persist.pvpUnitPositions_order1.Flush();
      else
        Persist.pvpUnitPositions_order2.Flush();
    }

    public static Persist.PvpUnitPositions getData(MpStage stage, int nbPositions, int order)
    {
      if (Persist.pvpUnitPositions_order1.Data.check(stage, nbPositions, order))
        return Persist.pvpUnitPositions_order1.Data;
      return Persist.pvpUnitPositions_order2.Data.check(stage, nbPositions, order) ? Persist.pvpUnitPositions_order2.Data : (Persist.PvpUnitPositions) null;
    }
  }

  [Serializable]
  public class FirstPGSSignIn
  {
    private bool signIn;

    public bool Flag() => this.signIn;

    public void SetFlag(bool flag = true) => this.signIn = flag;
  }
}
