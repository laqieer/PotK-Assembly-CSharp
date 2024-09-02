// Decompiled with JetBrains decompiler
// Type: Colosseum02351RewardItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum02351RewardItem : MonoBehaviour
{
  private GameObject iconPrefab;
  [SerializeField]
  private GameObject zoomButton;
  [SerializeField]
  private Transform iconBase;
  [SerializeField]
  private UILabel itemName;

  public ColosseumRankReward reward { get; private set; }

  [DebuggerHidden]
  public IEnumerator SetReward(ColosseumRankReward reward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02351RewardItem.\u003CSetReward\u003Ec__Iterator531()
    {
      reward = reward,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u003Ef__this = this
    };
  }

  private bool Zoomable(ColosseumRankReward reward)
  {
    return reward.reward_type == MasterDataTable.CommonRewardType.gear || reward.reward_type == MasterDataTable.CommonRewardType.unit;
  }
}
