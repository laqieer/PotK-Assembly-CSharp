// Decompiled with JetBrains decompiler
// Type: ColosseumUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class ColosseumUtility
{
  [DebuggerHidden]
  public static IEnumerator CreateGearIcon(
    GameObject prefab,
    GearGear gear,
    Transform parent,
    bool isBottom = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumUtility.\u003CCreateGearIcon\u003Ec__Iterator89F()
    {
      prefab = prefab,
      parent = parent,
      gear = gear,
      isBottom = isBottom,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003EisBottom = isBottom
    };
  }

  [DebuggerHidden]
  public static IEnumerator CreateSupplyIcon(
    GameObject prefab,
    SupplySupply supply,
    Transform parent,
    bool isBottom = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumUtility.\u003CCreateSupplyIcon\u003Ec__Iterator8A0()
    {
      prefab = prefab,
      parent = parent,
      supply = supply,
      isBottom = isBottom,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u0024\u003EisBottom = isBottom
    };
  }

  [DebuggerHidden]
  public static IEnumerator CreateUnitIcon(
    GameObject prefab,
    UnitUnit unit,
    Transform parent,
    bool isBottom = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumUtility.\u003CCreateUnitIcon\u003Ec__Iterator8A1()
    {
      prefab = prefab,
      parent = parent,
      unit = unit,
      isBottom = isBottom,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EisBottom = isBottom
    };
  }

  [DebuggerHidden]
  public static IEnumerator CreateUniqueIcon(
    GameObject gearPrefab,
    Transform parent,
    int rewardTypeID,
    int rewardID,
    int rewardQuantity,
    bool isBottom = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumUtility.\u003CCreateUniqueIcon\u003Ec__Iterator8A2()
    {
      parent = parent,
      rewardTypeID = rewardTypeID,
      rewardID = rewardID,
      rewardQuantity = rewardQuantity,
      isBottom = isBottom,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003ErewardTypeID = rewardTypeID,
      \u003C\u0024\u003ErewardID = rewardID,
      \u003C\u0024\u003ErewardQuantity = rewardQuantity,
      \u003C\u0024\u003EisBottom = isBottom
    };
  }

  [DebuggerHidden]
  public static IEnumerator CreateUniqueIcon(
    GameObject gearPrefab,
    Transform parent,
    MasterDataTable.CommonRewardType rewardTypeID,
    int rewardID,
    int rewardQuantity,
    bool isBottom = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumUtility.\u003CCreateUniqueIcon\u003Ec__Iterator8A3()
    {
      parent = parent,
      rewardTypeID = rewardTypeID,
      rewardID = rewardID,
      rewardQuantity = rewardQuantity,
      isBottom = isBottom,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003ErewardTypeID = rewardTypeID,
      \u003C\u0024\u003ErewardID = rewardID,
      \u003C\u0024\u003ErewardQuantity = rewardQuantity,
      \u003C\u0024\u003EisBottom = isBottom
    };
  }

  public static int GetNextRankPoint(int point, int maxPoint)
  {
    return ColosseumUtility.GetRankInfo(point, maxPoint).to_point - point;
  }

  public static float GetNextRankRate(int point, int maxPoint)
  {
    int toPoint1 = ColosseumUtility.GetPrevRankInfo(point, maxPoint).to_point;
    int toPoint2 = ColosseumUtility.GetRankInfo(point, maxPoint).to_point;
    int num = toPoint1 != toPoint2 ? toPoint1 + 1 : 0;
    return (float) (point - num) / (float) (toPoint2 - num);
  }

  public static string GetRankName(int point)
  {
    return ColosseumUtility.GetRankInfo(point, int.MaxValue).name;
  }

  public static int GetRankID(int point) => ColosseumUtility.GetRankInfo(point, int.MaxValue).ID;

  public static ColosseumRank GetPrevRankInfo(int point, int maxPoint)
  {
    ColosseumRank[] array = ((IEnumerable<ColosseumRank>) MasterData.ColosseumRankList).Where<ColosseumRank>((Func<ColosseumRank, bool>) (v => v.to_point <= maxPoint)).OrderBy<ColosseumRank, int>((Func<ColosseumRank, int>) (v => v.to_point)).ToArray<ColosseumRank>();
    if (array.Length == 0)
      return (ColosseumRank) null;
    ColosseumRank prevRankInfo = array[0];
    foreach (ColosseumRank colosseumRank in array)
    {
      if (point <= colosseumRank.to_point)
        return prevRankInfo;
      prevRankInfo = colosseumRank;
    }
    return prevRankInfo;
  }

  public static ColosseumRankReward[] GetRankRewardFromPoint(int point)
  {
    ColosseumRank info = ColosseumUtility.GetRankInfo(point, int.MaxValue);
    return ((IEnumerable<ColosseumRankReward>) MasterData.ColosseumRankRewardList).Where<ColosseumRankReward>((Func<ColosseumRankReward, bool>) (v => v.rank_id == info.ID)).ToArray<ColosseumRankReward>();
  }

  public static ColosseumRankReward[] GetRankRewardFromID(int id)
  {
    return ((IEnumerable<ColosseumRankReward>) MasterData.ColosseumRankRewardList).Where<ColosseumRankReward>((Func<ColosseumRankReward, bool>) (v => v.rank_id == id)).ToArray<ColosseumRankReward>();
  }

  private static ColosseumRank GetRankInfo(int point, int maxPoint)
  {
    IOrderedEnumerable<ColosseumRank> source = ((IEnumerable<ColosseumRank>) MasterData.ColosseumRankList).Where<ColosseumRank>((Func<ColosseumRank, bool>) (v => v.to_point <= maxPoint)).OrderBy<ColosseumRank, int>((Func<ColosseumRank, int>) (v => v.to_point));
    foreach (ColosseumRank rankInfo in (IEnumerable<ColosseumRank>) source)
    {
      if (point <= rankInfo.to_point)
        return rankInfo;
    }
    return source.Last<ColosseumRank>();
  }

  public static string GetRewardTitle(RankUpInfoRank_up_rewards reward)
  {
    return ColosseumUtility.GetRewardTitle((MasterDataTable.CommonRewardType) reward.reward_type_id, reward.reward_id, reward.reward_quantity);
  }

  public static string GetRewardTitle(ColosseumRankReward reward)
  {
    return ColosseumUtility.GetRewardTitle(reward.reward_type, reward.reward_id, reward.reward_value);
  }

  private static string GetRewardTitle(MasterDataTable.CommonRewardType rewardType, int rewardID, int num)
  {
    switch (rewardType)
    {
      case MasterDataTable.CommonRewardType.unit:
        return Consts.Lookup("MYPAGE_0017_UNIT", (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.UnitUnit[rewardID].name
          },
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.supply:
        return Consts.Lookup("MYPAGE_0017_SUPPLY", (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.SupplySupply[rewardID].name
          },
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.gear:
        return Consts.Lookup("MYPAGE_0017_GEAR", (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.GearGear[rewardID].name
          },
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.money:
        return Consts.Lookup("MYPAGE_0017_ZENY", (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.player_exp:
        return Consts.Lookup("MYPAGE_0017_EXP", (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.coin:
        return Consts.Lookup("MYPAGE_0017_STONE", (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.medal:
        return Consts.Lookup("MYPAGE_0017_MEDAL", (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.friend_point:
        return Consts.Lookup("MYPAGE_0017_POINT", (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.battle_medal:
        return Consts.Lookup("MYPAGE_0017_BATTLE_MEDAL", (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.quest_key:
        return Consts.Lookup("MYPAGE_0017_KEY", (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) num
          }
        });
      case MasterDataTable.CommonRewardType.gacha_ticket:
        return Consts.Lookup("MYPAGE_0017_GACHATICKET", (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) num
          }
        });
      default:
        return string.Empty;
    }
  }

  [DebuggerHidden]
  public static IEnumerator LoadIconPrefab(MasterDataTable.CommonRewardType type)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumUtility.\u003CLoadIconPrefab\u003Ec__Iterator8A4()
    {
      type = type,
      \u003C\u0024\u003Etype = type
    };
  }

  public static IEnumerator SetupIconData(
    RankUpInfoRank_up_rewards reward,
    GameObject iconPrefab,
    UILabel rewardName,
    Transform parent)
  {
    return ColosseumUtility.SetupIconData((MasterDataTable.CommonRewardType) reward.reward_type_id, reward.reward_id, reward.reward_quantity, iconPrefab, rewardName, parent);
  }

  public static IEnumerator SetupIconData(
    ColosseumRankReward reward,
    GameObject iconPrefab,
    UILabel rewardName,
    Transform parent)
  {
    return ColosseumUtility.SetupIconData(reward.reward_type, reward.reward_id, reward.reward_value, iconPrefab, rewardName, parent);
  }

  [DebuggerHidden]
  private static IEnumerator SetupIconData(
    MasterDataTable.CommonRewardType type,
    int rewardID,
    int num,
    GameObject iconPrefab,
    UILabel rewardName,
    Transform parent)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumUtility.\u003CSetupIconData\u003Ec__Iterator8A5()
    {
      type = type,
      rewardID = rewardID,
      rewardName = rewardName,
      iconPrefab = iconPrefab,
      parent = parent,
      num = num,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003ErewardID = rewardID,
      \u003C\u0024\u003ErewardName = rewardName,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Enum = num
    };
  }

  public class Info
  {
    public bool rankingUpdated;
    public bool is_battle;
    public bool is_tutorial;
    public int next_battle_type;
    public ColosseumRecord colosseum_record;
    public Bonus[] bonus;
    public Gladiator[] gladiators;
    public Campaign[] campaigns;

    public Info()
    {
    }

    public Info(bool update, WebAPI.Response.ColosseumBoot boot)
    {
      this.rankingUpdated = update;
      this.SetBootInfo(boot);
    }

    public Info(bool update, WebAPI.Response.ColosseumTutorialBoot boot)
    {
      this.rankingUpdated = update;
      this.SetBootInfo(boot);
    }

    public Info(bool update, WebAPI.Response.ColosseumFinish finish)
    {
      this.rankingUpdated = update;
      this.SetBootInfo(finish);
    }

    public Info(bool update, WebAPI.Response.ColosseumTutorialFinish finish)
    {
      this.rankingUpdated = update;
      this.SetBootInfo(finish);
    }

    public void SetBootInfo(WebAPI.Response.ColosseumBoot boot)
    {
      this.is_battle = boot.is_battle;
      this.is_tutorial = boot.is_tutorial;
      this.next_battle_type = boot.next_battle_type;
      this.colosseum_record = boot.colosseum_record;
      this.bonus = boot.bonus;
      this.gladiators = boot.gladiators;
      this.campaigns = boot.campaigns;
    }

    public void SetBootInfo(WebAPI.Response.ColosseumTutorialBoot boot)
    {
      this.is_battle = boot.is_battle;
      this.is_tutorial = boot.is_tutorial;
      this.next_battle_type = boot.next_battle_type;
      this.colosseum_record = boot.colosseum_record;
      this.bonus = boot.bonus;
      this.gladiators = boot.gladiators;
      this.campaigns = boot.campaigns;
    }

    public void SetBootInfo(WebAPI.Response.ColosseumFinish finish)
    {
      this.is_battle = finish.is_battle;
      this.is_tutorial = finish.is_tutorial;
      this.next_battle_type = finish.next_battle_type;
      this.colosseum_record = finish.colosseum_record;
      this.bonus = finish.bonus;
      this.gladiators = finish.gladiators;
      this.campaigns = finish.campaigns;
    }

    public void SetBootInfo(WebAPI.Response.ColosseumTutorialFinish finish)
    {
      this.is_battle = finish.is_battle;
      this.is_tutorial = finish.is_tutorial;
      this.next_battle_type = finish.next_battle_type;
      this.colosseum_record = finish.colosseum_record;
      this.bonus = finish.bonus;
      this.gladiators = finish.gladiators;
    }
  }
}
