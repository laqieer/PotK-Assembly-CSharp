﻿// Decompiled with JetBrains decompiler
// Type: Shop00720RewardList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00720RewardList : BackButtonMenuBase
{
  [SerializeField]
  private NGxScrollMasonry Scroll;

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  public IEnumerator Init(Shop00720Prefabs prefabs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720RewardList.\u003CInit\u003Ec__Iterator3D4()
    {
      prefabs = prefabs,
      \u003C\u0024\u003Eprefabs = prefabs,
      \u003C\u003Ef__this = this
    };
  }

  private void OnEnable() => this.Scroll.ResolvePosition();

  [DebuggerHidden]
  private IEnumerator SetRewardPatternData(
    Shop00720RewardPatternData rewardPatternData,
    int[] reelIds,
    int id,
    SlotS001MedalDeck targetDeck,
    SlotS001MedalDeckEntity[] DeckEntityList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720RewardList.\u003CSetRewardPatternData\u003Ec__Iterator3D5()
    {
      rewardPatternData = rewardPatternData,
      reelIds = reelIds,
      targetDeck = targetDeck,
      DeckEntityList = DeckEntityList,
      id = id,
      \u003C\u0024\u003ErewardPatternData = rewardPatternData,
      \u003C\u0024\u003EreelIds = reelIds,
      \u003C\u0024\u003EtargetDeck = targetDeck,
      \u003C\u0024\u003EDeckEntityList = DeckEntityList,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  private void SetRewardData(
    SlotS001MedalDeckEntity reward,
    Shop00720RewardPatternData rewardPatternData)
  {
    Shop00720RewardData shop00720RewardData = new Shop00720RewardData()
    {
      RewardId = reward.reward_id,
      RewardType = reward.reward_type_id,
      Quantity = !reward.reward_quantity.HasValue ? 0 : reward.reward_quantity.Value
    };
    shop00720RewardData.Description = CommonRewardType.GetRewardName(shop00720RewardData.RewardType, shop00720RewardData.RewardId, shop00720RewardData.Quantity);
    rewardPatternData.RewardList.Add(shop00720RewardData);
  }
}
