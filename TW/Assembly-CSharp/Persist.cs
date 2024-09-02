// Decompiled with JetBrains decompiler
// Type: Persist
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Bode;
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
  public static Persist<Persist.UnitSortAndFilterInfo> unit004912SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit004912SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit004431SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit004431SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00486SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00486SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit00487SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit00487SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit005411SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit005411SortAndFilter.dat");
  public static Persist<Persist.UnitSortAndFilterInfo> unit005468SortAndFilter = new Persist<Persist.UnitSortAndFilterInfo>("unit005468SortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0052SortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0052SortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu005SupplyListSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu005SupplyListSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu005MaterialListSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu005MaterialListSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0052CompositeSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0052CompositeSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0052RepairSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0052RepairSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0052SellSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0052RepairSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0052DrillingBaseSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0052DrillingBaseSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0052DrillingMaterialSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0052DrillingMaterialSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0052BuildupBaseSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0052BuildupBaseSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0052BuildupMaterialSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0052BuildupMaterialSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> unit0044SortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("unit0044SortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0552SortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0552SortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu055SellSortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu055SellSortAndFilter.dat");
  public static Persist<Persist.ItemSortAndFilterInfo> bugu0544SortAndFilter = new Persist<Persist.ItemSortAndFilterInfo>("bugu0544SortAndFilter.dat");
  public static Persist<Persist.GuildMemberSortInfo> guildMemberListSort = new Persist<Persist.GuildMemberSortInfo>("guildMemberListSort.dat");
  public static Persist<Persist.EmblemSortCategory> emblemSortCategory = new Persist<Persist.EmblemSortCategory>("emblemSortCategory.dat");
  public static Persist<Persist.InfoUnRead> infoUnRead = new Persist<Persist.InfoUnRead>("infoUnRead.dat");
  public static Persist<Persist.LastInfoTime> lastInfoTime = new Persist<Persist.LastInfoTime>("lastInfoTime.dat");
  public static Persist<Persist.LastAccessTime> lastAccessTime = new Persist<Persist.LastAccessTime>("lastAccessTime.dat");
  public static Persist<Persist.UserPolicy> userPolicy = new Persist<Persist.UserPolicy>("userPolicy.dat");
  public static Persist<Persist.Volume> volume = new Persist<Persist.Volume>("volume.dat");
  public static Persist<Persist.Notification> notification = new Persist<Persist.Notification>("notification.dat");
  public static Persist<Persist.PushNotification> pushnotification = new Persist<Persist.PushNotification>("pushnotification.dat");
  public static Persist<Persist.BattleInfo> battleinfo = new Persist<Persist.BattleInfo>("battleinfo.dat");
  public static Persist<BE> battleEnvironment = new Persist<BE>("be.dat");
  public static Persist<Persist.Tutorial> tutorial = new Persist<Persist.Tutorial>("tutorial.dat");
  public static Persist<Persist.QuestLastSortie> lastsortie = new Persist<Persist.QuestLastSortie>("lastsortie.dat");
  public static Persist<Persist.EventQuestExplanation> explanation = new Persist<Persist.EventQuestExplanation>("explanation.dat");
  public static Persist<Persist.Duel> duel = new Persist<Persist.Duel>("duel.dat");
  public static Persist<Persist.Battle> battle = new Persist<Persist.Battle>("battle.dat");
  public static Persist<Persist.BattleIcon> battleIcon = new Persist<Persist.BattleIcon>("battleIcon.dat");
  public static Persist<Persist.BattleNoDuel> battleNoDuel = new Persist<Persist.BattleNoDuel>("battleNoDuel.dat");
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
  public static Persist<Persist.MissionHistory> missionHistory = new Persist<Persist.MissionHistory>("missionHistory.dat");
  public static Persist<Persist.EventStoryPlay> eventStoryPlay = new Persist<Persist.EventStoryPlay>("eventStoryPlay.dat");
  public static Persist<Persist.GuildSettingInfo> guildSetting = new Persist<Persist.GuildSettingInfo>("guildSettingInfo.dat");
  public static Persist<Persist.GuildBankSettingInfo> guildBankSetting = new Persist<Persist.GuildBankSettingInfo>("guildBankSettingInfo.dat");
  public static Persist<BE> gvgBattleEnvironment = new Persist<BE>("gvgbe.dat");
  public static Persist<Persist.GuildTopLevel> guildTopLevel = new Persist<Persist.GuildTopLevel>("guildTopLevel.dat");
  public static Persist<Persist.GuildBattleUser> guildBattleUser = new Persist<Persist.GuildBattleUser>("guildBattleUser.dat");
  public static Persist<Persist.UserInfo> userInfo = new Persist<Persist.UserInfo>("userInfo.dat");

  [Serializable]
  public class Auth
  {
    public string UUID;
    public string SecretKey;
    public string DeviceID;

    public Auth() => this.setDefault();

    public void ResetAllAuthInfo()
    {
      this.UUID = (string) null;
      this.SecretKey = (string) null;
      this.DeviceID = (string) null;
      this.setDefault();
    }

    public bool IsNeedAuthRegister() => this.DeviceID == string.Empty;

    private void setDefault()
    {
      if (string.IsNullOrEmpty(this.UUID))
      {
        this.UUID = SystemInfo.deviceUniqueIdentifier;
        Debug.Log((object) ("config default set UUID = " + this.UUID));
      }
      if (string.IsNullOrEmpty(this.SecretKey))
      {
        this.SecretKey = Guid.NewGuid().ToString();
        Debug.Log((object) ("config default set SecretKey = " + this.SecretKey));
      }
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
    public int GuildMember;
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
    public UnitGroupHead groupType = UnitGroupHead.group_all;
    public int groupID = 1;
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
      this.groupType = UnitGroupHead.group_all;
      this.groupID = 1;
    }
  }

  [Serializable]
  public class ItemSortAndFilterInfo
  {
    public SortAndFilter.SORT_TYPE_ORDER_BUY order;
    public ItemSortAndFilter.SORT_TYPES sortType = ItemSortAndFilter.SORT_TYPES.BranchOfWeapon;
    public ItemSortAndFilter.ModeTypes modeType;
    public List<bool> filter = new List<bool>();
    private bool isInit;

    public ItemSortAndFilterInfo() => this.setDefault();

    private void setDefault()
    {
      if (this.isInit)
        return;
      this.isInit = true;
      for (int index = 0; index < 27; ++index)
        this.filter.Add(true);
      this.sortType = ItemSortAndFilter.SORT_TYPES.BranchOfWeapon;
    }
  }

  [Serializable]
  public class GuildMemberSortInfo
  {
    public GuildMemberSort.SORT_TYPES sortType = GuildMemberSort.SORT_TYPES.Contribution;
    public SortAndFilter.SORT_TYPE_ORDER_BUY order;
    private bool isInit;

    public GuildMemberSortInfo() => this.setDefault();

    private void setDefault()
    {
      if (this.isInit)
        return;
      this.isInit = true;
      switch (Persist.sortOrder.Data.GuildMember)
      {
        case 0:
          this.sortType = GuildMemberSort.SORT_TYPES.Contribution;
          break;
        case 1:
          this.sortType = GuildMemberSort.SORT_TYPES.JoinAt;
          break;
        case 2:
          this.sortType = GuildMemberSort.SORT_TYPES.LastLoginAt;
          break;
        case 3:
          this.sortType = GuildMemberSort.SORT_TYPES.Level;
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
  public class LastAccessTime
  {
    public DateTime gachaRootLastAccessTime;
    public DateTime shopRootLastAccessTime;
    public DateTime zeniShopLastAccessTime;
    public DateTime rareMedalSlotLastAccessTime;
    public DateTime battleMedalShopLastAccessTime;
    public DateTime limitedShopLastAccessTime;
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
  public class BattleInfo
  {
    public bool bIsSkipDuel;
    public bool bOpenSkipDuelTips;

    public BattleInfo() => this.setDefault();

    private void setDefault()
    {
      this.bIsSkipDuel = false;
      this.bOpenSkipDuelTips = false;
    }

    public void SetSkipDuel(bool bSkip) => this.bIsSkipDuel = bSkip;

    public void SetOpenSkipDuelTips(bool bSkipTips) => this.bOpenSkipDuelTips = bSkipTips;
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
    public string PlayID;

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
      this.PlayID = SDK.instance.GetPlayID();
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
      this.PlayID = string.Empty;
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

    private void setDefault() => this.speed = 0;
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
  public class MissionHistory
  {
    public Persist.MissionHistory.IDList daily;
    public Persist.MissionHistory.IDList mission;

    public MissionHistory() => this.setDefault();

    public void setDefault()
    {
      this.daily = new Persist.MissionHistory.IDList();
      this.mission = new Persist.MissionHistory.IDList();
    }

    [Serializable]
    public class IDList
    {
      public DateTime? date;
      public List<int> ids = new List<int>();
    }
  }

  [Serializable]
  public class EventStoryPlay
  {
    public DateTime reservedTime;
    public List<int> reserveIDList;

    public EventStoryPlay() => this.setDefault();

    private void setDefault()
    {
      this.reservedTime = new DateTime();
      this.reserveIDList = new List<int>();
    }

    public void SetReserveList(IEnumerable<StoryPlaybackEventPlay> list, DateTime serverTime)
    {
      bool flag = false;
      foreach (StoryPlaybackEventPlay playbackEventPlay in list)
      {
        if (!this.reserveIDList.Contains(playbackEventPlay.ID))
        {
          this.reserveIDList.Add(playbackEventPlay.ID);
          flag = true;
        }
      }
      List<int> intList = new List<int>();
      foreach (int reserveId in this.reserveIDList)
      {
        if (MasterData.StoryPlaybackEventPlay.ContainsKey(reserveId))
        {
          if (MasterData.StoryPlaybackEventPlay[reserveId].end_at < serverTime)
            intList.Add(reserveId);
        }
        else
          intList.Add(reserveId);
      }
      foreach (int num in intList)
      {
        this.reserveIDList.Remove(num);
        flag = true;
      }
      if (!flag)
        return;
      if (this.reserveIDList.Count > 0)
        this.reservedTime = this.reserveIDList.Select<int, StoryPlaybackEventPlay>((Func<int, StoryPlaybackEventPlay>) (x => MasterData.StoryPlaybackEventPlay[x])).Max<StoryPlaybackEventPlay, DateTime>((Func<StoryPlaybackEventPlay, DateTime>) (x => x.start_at));
      Persist.eventStoryPlay.Flush();
    }

    public bool isExistEventScript(string sceneName, int arg1)
    {
      return this.reserveIDList.Select<int, StoryPlaybackEventPlay>((Func<int, StoryPlaybackEventPlay>) (x => MasterData.StoryPlaybackEventPlay[x])).Any<StoryPlaybackEventPlay>((Func<StoryPlaybackEventPlay, bool>) (x =>
      {
        if (!string.IsNullOrEmpty(x.scene_name) && !sceneName.Contains(x.scene_name))
          return false;
        return !x.arg1.HasValue || x.arg1.Value == arg1;
      }));
    }

    public bool PlayEventScript(string sceneName, DateTime serverTime, int arg1)
    {
      StoryPlaybackEventPlay playbackEventPlay = this.reserveIDList.Select<int, StoryPlaybackEventPlay>((Func<int, StoryPlaybackEventPlay>) (x => MasterData.StoryPlaybackEventPlay[x])).OrderBy<StoryPlaybackEventPlay, DateTime>((Func<StoryPlaybackEventPlay, DateTime>) (x => x.start_at)).FirstOrDefault<StoryPlaybackEventPlay>((Func<StoryPlaybackEventPlay, bool>) (x =>
      {
        if (!string.IsNullOrEmpty(x.scene_name) && !sceneName.Contains(x.scene_name))
          return false;
        return !x.arg1.HasValue || x.arg1.Value == arg1;
      }));
      if (playbackEventPlay != null)
      {
        this.reserveIDList.Remove(playbackEventPlay.ID);
        Persist.eventStoryPlay.Flush();
        Story0093Scene.changeScene009_3(false, playbackEventPlay.script_id);
      }
      return playbackEventPlay != null;
    }
  }

  [Serializable]
  public class GuildSettingInfo
  {
    private Dictionary<GuildUtil.GuildBadgeInfoType, bool> badgeState;
    public int titleSortCategory;
    public int memberNum = -1;
    public DateTime timeTitleAppear;

    public GuildSettingInfo() => this.setDefault();

    private void setDefault()
    {
      if (this.badgeState == null)
        this.badgeState = new Dictionary<GuildUtil.GuildBadgeInfoType, bool>();
      this.badgeState.Clear();
      for (int key = 0; key < Enum.GetValues(typeof (GuildUtil.GuildBadgeInfoType)).Length; ++key)
        this.setBadgeState((GuildUtil.GuildBadgeInfoType) key, false);
      this.timeTitleAppear = new DateTime(2000, 1, 1);
      this.memberNum = -1;
    }

    public void setBadgeState(GuildUtil.GuildBadgeInfoType key, bool state)
    {
      if (this.badgeState == null)
        this.badgeState = new Dictionary<GuildUtil.GuildBadgeInfoType, bool>();
      if (!this.badgeState.ContainsKey(key))
        this.badgeState.Add(key, state);
      else
        this.badgeState[key] = state;
    }

    public bool getBadgeState(GuildUtil.GuildBadgeInfoType key)
    {
      return this.badgeState != null && this.badgeState.ContainsKey(key) && this.badgeState[key];
    }

    public void reset() => this.setDefault();
  }

  [Serializable]
  public class GuildBankSettingInfo
  {
    public bool guildBankFirstTime = true;

    public void setDefault() => this.guildBankFirstTime = true;

    public void reset() => this.setDefault();
  }

  [Serializable]
  public class GuildTopLevel
  {
    public string guildID = string.Empty;
    public int level = 1;

    public void setDefault()
    {
      this.guildID = string.Empty;
      this.level = 1;
    }

    public void reset() => this.setDefault();
  }

  [Serializable]
  public class GuildBattleUser
  {
    public string guildID;
    public int roleNo;
    public int gvgID;
    public int countTopIN;

    public GuildBattleUser() => this.setDefault();

    public void setDefault()
    {
      this.guildID = string.Empty;
      this.roleNo = 0;
      this.gvgID = 0;
      this.countTopIN = 0;
    }

    public void reset(string id, int role, int gvgId)
    {
      this.guildID = id;
      this.roleNo = role;
      this.gvgID = gvgId;
      this.countTopIN = 0;
    }
  }

  [Serializable]
  public class UserInfo
  {
    public string userId = string.Empty;

    public UserInfo() => this.setDefault();

    private void setDefault() => this.userId = string.Empty;
  }
}
