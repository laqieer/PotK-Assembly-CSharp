// Decompiled with JetBrains decompiler
// Type: DailyMission0271SelectCompRewardList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271SelectCompRewardList : MonoBehaviour
{
  [SerializeField]
  private UILabel rewardName;
  [SerializeField]
  private CreateIconObject iconRoot;
  [SerializeField]
  private GameObject btnDetail;
  private int reward_group_id;
  private BingoRewardGroup completeReward;
  private DailyMission0271MissionRoot missionRoot;
  private GameObject compleateMissionRewardDetailPrefab;

  [DebuggerHidden]
  public IEnumerator Init(
    BingoRewardGroup completeReward,
    DailyMission0271MissionRoot missionRoot,
    GameObject compleateMissionRewardDetailPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271SelectCompRewardList.\u003CInit\u003Ec__Iterator6CD()
    {
      completeReward = completeReward,
      compleateMissionRewardDetailPrefab = compleateMissionRewardDetailPrefab,
      missionRoot = missionRoot,
      \u003C\u0024\u003EcompleteReward = completeReward,
      \u003C\u0024\u003EcompleateMissionRewardDetailPrefab = compleateMissionRewardDetailPrefab,
      \u003C\u0024\u003EmissionRoot = missionRoot,
      \u003C\u003Ef__this = this
    };
  }

  public void onCompReward()
  {
    if (this.missionRoot.menu.IsPushAndSet())
      return;
    this.StartCoroutine(this.CompRewardPopup());
  }

  [DebuggerHidden]
  public IEnumerator CompRewardPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271SelectCompRewardList.\u003CCompRewardPopup\u003Ec__Iterator6CE()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onDetailReward()
  {
    if (this.missionRoot.menu.IsPushAndSet())
      return;
    this.StartCoroutine(this.setDetailPopup());
  }

  [DebuggerHidden]
  private IEnumerator setDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271SelectCompRewardList.\u003CsetDetailPopup\u003Ec__Iterator6CF()
    {
      \u003C\u003Ef__this = this
    };
  }
}
