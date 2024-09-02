// Decompiled with JetBrains decompiler
// Type: DailyMission0271MissionRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class DailyMission0271MissionRoot : MonoBehaviour
{
  [SerializeField]
  private GameObject selectCompleteReward;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private GameObject panelRoot;
  [SerializeField]
  private UI2DSprite compRewardImage;
  [SerializeField]
  private DailyMission0271PanelRoot[] panelRoots;
  [SerializeField]
  private UIButton CompleateRewardBtn;
  private PlayerBingo playerBingo;
  private GameObject panelPrefab;
  private GameObject compleateMissonSelectPrefab;
  private GameObject compleateMissionRewardDetailPrefab;
  private DailyMission0271Menu _menu;

  public DailyMission0271Menu menu
  {
    get
    {
      if (Object.op_Equality((Object) this._menu, (Object) null))
        this._menu = ((Component) ((Component) this).gameObject.transform.root).GetComponent<DailyMission0271Menu>();
      return this._menu;
    }
  }

  [DebuggerHidden]
  public IEnumerator InitPrefabs()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271MissionRoot.\u003CInitPrefabs\u003Ec__Iterator6BE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetMissionData(PlayerBingo playerBingoData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271MissionRoot.\u003CSetMissionData\u003Ec__Iterator6BF()
    {
      playerBingoData = playerBingoData,
      \u003C\u0024\u003EplayerBingoData = playerBingoData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetSelectCompReward()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271MissionRoot.\u003CSetSelectCompReward\u003Ec__Iterator6C0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetPanel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271MissionRoot.\u003CSetPanel\u003Ec__Iterator6C1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createBingoMission(PlayerBingoPanel[] panels)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271MissionRoot.\u003CcreateBingoMission\u003Ec__Iterator6C2()
    {
      panels = panels,
      \u003C\u0024\u003Epanels = panels,
      \u003C\u003Ef__this = this
    };
  }

  public void SetCompReward(int reward_group_id)
  {
    this.StartCoroutine(this.SelectCompReward(reward_group_id));
  }

  [DebuggerHidden]
  public IEnumerator SelectCompReward(int reward_group_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271MissionRoot.\u003CSelectCompReward\u003Ec__Iterator6C3()
    {
      reward_group_id = reward_group_id,
      \u003C\u0024\u003Ereward_group_id = reward_group_id,
      \u003C\u003Ef__this = this
    };
  }

  public void CompRewardEffect()
  {
    this.StartCoroutine(this.playCompRewardEffect(((IEnumerable<MasterDataTable.BingoRewardGroup>) MasterData.BingoRewardGroupList).Where<MasterDataTable.BingoRewardGroup>((Func<MasterDataTable.BingoRewardGroup, bool>) (x => x.reward_group_id == this.playerBingo.selected_group_reward_id)).ToArray<MasterDataTable.BingoRewardGroup>()));
  }

  [DebuggerHidden]
  private IEnumerator playCompRewardEffect(MasterDataTable.BingoRewardGroup[] Rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271MissionRoot.\u003CplayCompRewardEffect\u003Ec__Iterator6C4()
    {
      Rewards = Rewards,
      \u003C\u0024\u003ERewards = Rewards,
      \u003C\u003Ef__this = this
    };
  }
}
