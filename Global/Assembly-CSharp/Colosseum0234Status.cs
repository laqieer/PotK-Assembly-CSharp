// Decompiled with JetBrains decompiler
// Type: Colosseum0234Status
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Colosseum0234Status : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtBattlept;
  [SerializeField]
  private UILabel TxtBattlept_thum;
  [SerializeField]
  private UILabel TxtWin;
  [SerializeField]
  private UILabel TxtLose;
  [SerializeField]
  private UILabel TxtPlayerRanking;
  [SerializeField]
  private UILabel TxtRankname4;
  [SerializeField]
  private UILabel TxtNumRankpoint;
  [SerializeField]
  private GameObject rankGauge;
  [SerializeField]
  private GameObject totalPowBase;
  [SerializeField]
  private UILabel TxtFighting;
  [SerializeField]
  private GameObject totalPowBase_thum;
  [SerializeField]
  private UILabel TxtFighting_thum;
  [SerializeField]
  private GameObject dirRnakBattle;
  [SerializeField]
  private GameObject slcRankBattleDown;
  [SerializeField]
  private GameObject slcRankBattleUp;
  [SerializeField]
  private GameObject dirRnakBattle_thum;
  [SerializeField]
  private GameObject slcRankBattleDown_thum;
  [SerializeField]
  private GameObject slcRankBattleUp_thum;
  [SerializeField]
  private GameObject dirRankBattleMax;
  [SerializeField]
  private GameObject slc_RankUpReward;
  [SerializeField]
  private GameObject rewardUnit;
  [SerializeField]
  private GameObject rewardItem;
  [SerializeField]
  private GameObject rewardUnique;
  private GameObject unitPrefab;
  private GameObject gearPrefab;
  private GameObject uniquePrefab;
  private ColosseumUtility.Info colosseumInfo;
  private Colosseum0234Menu menu;

  private bool DispReward(ColosseumUtility.Info colosseumInfo)
  {
    return colosseumInfo.colosseum_record.current_rank + 1 > colosseumInfo.colosseum_record.max_rank && colosseumInfo.colosseum_record.max_rank != colosseumInfo.colosseum_record.enabled_max_rank;
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    ColosseumUtility.Info colosseumInfo,
    Colosseum0234Menu menu,
    RankingPlayer myRanking)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Status.\u003CInitialize\u003Ec__Iterator4F1()
    {
      colosseumInfo = colosseumInfo,
      menu = menu,
      myRanking = myRanking,
      \u003C\u0024\u003EcolosseumInfo = colosseumInfo,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EmyRanking = myRanking,
      \u003C\u003Ef__this = this
    };
  }

  private PlayerDeck GetDeck()
  {
    PlayerDeck[] playerDeckArray = SMManager.Get<PlayerDeck[]>();
    return ((IEnumerable<PlayerUnit>) playerDeckArray[Persist.colosseumDeckOrganized.Data.number].player_units).FirstOrDefault<PlayerUnit>() != (PlayerUnit) null ? playerDeckArray[Persist.colosseumDeckOrganized.Data.number] : playerDeckArray[0];
  }

  private void SetRankInfo(
    ColosseumUtility.Info colosseumInfo,
    RankingPlayer myRanking,
    bool dispReward)
  {
    this.dirRnakBattle.SetActive(true);
    PlayerDeck deck = this.GetDeck();
    ColosseumRecord colosseumRecord = colosseumInfo.colosseum_record;
    int rankPt = colosseumInfo.colosseum_record.rank_pt;
    int enabledMaxRankPoint = colosseumInfo.colosseum_record.enabled_max_rank_point;
    this.SetBattlePoint(ColosseumUtility.GetNextRankPoint(rankPt, enabledMaxRankPoint), dispReward);
    this.SetCombatPow(deck.total_combat, dispReward);
    this.TxtWin.SetTextLocalize(colosseumRecord.attack_win);
    this.TxtLose.SetTextLocalize(colosseumRecord.attack_lose);
    this.SetRanking(myRanking);
    this.TxtRankname4.SetTextLocalize(ColosseumUtility.GetRankName(rankPt));
    this.TxtNumRankpoint.SetTextLocalize(rankPt);
    this.rankGauge.transform.localScale = new Vector3(ColosseumUtility.GetNextRankRate(rankPt, enabledMaxRankPoint), 1f, 1f);
  }

  private void SetBattlePoint(int point, bool dispReward)
  {
    if (dispReward)
    {
      ((Component) this.TxtBattlept).gameObject.SetActive(false);
      ((Component) this.TxtBattlept_thum).gameObject.SetActive(true);
      this.TxtBattlept_thum.SetTextLocalize(point);
    }
    else
    {
      ((Component) this.TxtBattlept_thum).gameObject.SetActive(false);
      ((Component) this.TxtBattlept).gameObject.SetActive(true);
      this.TxtBattlept.SetTextLocalize(point);
    }
  }

  private void SetCombatPow(int combat, bool dispReward)
  {
    this.totalPowBase.SetActive(!dispReward);
    this.totalPowBase_thum.SetActive(dispReward);
    if (dispReward)
    {
      ((Component) this.TxtFighting).gameObject.SetActive(false);
      ((Component) this.TxtFighting_thum).gameObject.SetActive(true);
      this.TxtFighting_thum.SetTextLocalize(combat);
    }
    else
    {
      ((Component) this.TxtFighting).gameObject.SetActive(true);
      ((Component) this.TxtFighting_thum).gameObject.SetActive(false);
      this.TxtFighting.SetTextLocalize(combat);
    }
  }

  private void DispBattleType(ColosseumUtility.Info colosseumInfo, bool dispReward)
  {
    if (colosseumInfo.next_battle_type == 0)
    {
      if (colosseumInfo.colosseum_record.current_rank == colosseumInfo.colosseum_record.enabled_max_rank)
        this.ChangeRankBattle(Colosseum0234Status.RankBattle.MAX, dispReward);
      else
        this.ChangeRankBattle(Colosseum0234Status.RankBattle.NOMAL, dispReward);
    }
    else if (colosseumInfo.next_battle_type == 1)
    {
      if (colosseumInfo.colosseum_record.current_rank == colosseumInfo.colosseum_record.enabled_max_rank)
        this.ChangeRankBattle(Colosseum0234Status.RankBattle.MAX, dispReward);
      else
        this.ChangeRankBattle(Colosseum0234Status.RankBattle.UP, dispReward);
    }
    else
    {
      if (colosseumInfo.next_battle_type != 2)
        return;
      this.ChangeRankBattle(Colosseum0234Status.RankBattle.DOWN, dispReward);
    }
  }

  private void ChangeRankBattle(Colosseum0234Status.RankBattle type, bool dispReward)
  {
    this.dirRnakBattle.SetActive(false);
    this.dirRnakBattle_thum.SetActive(false);
    this.slcRankBattleUp.SetActive(false);
    this.slcRankBattleUp_thum.SetActive(false);
    this.slcRankBattleDown.SetActive(false);
    this.slcRankBattleDown_thum.SetActive(false);
    this.dirRankBattleMax.SetActive(false);
    switch (type)
    {
      case Colosseum0234Status.RankBattle.NOMAL:
        this.dirRnakBattle.SetActive(!dispReward);
        this.dirRnakBattle_thum.SetActive(dispReward);
        break;
      case Colosseum0234Status.RankBattle.UP:
        this.slcRankBattleUp.SetActive(!dispReward);
        this.slcRankBattleUp_thum.SetActive(dispReward);
        break;
      case Colosseum0234Status.RankBattle.DOWN:
        this.slcRankBattleDown.SetActive(!dispReward);
        this.slcRankBattleDown_thum.SetActive(dispReward);
        break;
      case Colosseum0234Status.RankBattle.MAX:
        this.dirRankBattleMax.SetActive(true);
        break;
      default:
        Debug.LogWarning((object) "ChangeRankBattle Error");
        this.dirRnakBattle.SetActive(false);
        this.dirRnakBattle_thum.SetActive(false);
        break;
    }
  }

  public virtual void IbtnRank()
  {
    if (this.colosseumInfo == null || Object.op_Equality((Object) this.menu, (Object) null))
    {
      Debug.LogWarning((object) "colosseumInfoかColosseum0234Menuが未設定");
    }
    else
    {
      Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
      Colosseum0235Scene.ChangeScene(new Colosseum0235Scene.Param(this.colosseumInfo.colosseum_record.max_rank, this.colosseumInfo.colosseum_record.current_rank, this.colosseumInfo.colosseum_record.enabled_max_rank, this.menu.Opponents, this.colosseumInfo));
    }
  }

  [DebuggerHidden]
  private IEnumerator LoadRewardObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Status.\u003CLoadRewardObject\u003Ec__Iterator4F2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetRewardItem(ColosseumRankReward nextReward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Status.\u003CSetRewardItem\u003Ec__Iterator4F3()
    {
      nextReward = nextReward,
      \u003C\u0024\u003EnextReward = nextReward,
      \u003C\u003Ef__this = this
    };
  }

  private void SetRanking(RankingPlayer myRanking)
  {
    if (myRanking == null)
      Debug.LogError((object) "ERROR Colosseum0234Status myRanking NULL");
    else if (myRanking.ranking <= 0)
      this.TxtPlayerRanking.SetTextLocalize(Consts.Lookup("COLOSSEUM_00234_RANKING_NONE"));
    else
      this.TxtPlayerRanking.SetTextLocalize(myRanking.ranking);
  }

  private enum RankBattle
  {
    NOMAL,
    UP,
    DOWN,
    MAX,
  }
}
