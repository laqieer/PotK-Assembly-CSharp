﻿// Decompiled with JetBrains decompiler
// Type: DailyMission0271ConfirmationCompRewardPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271ConfirmationCompRewardPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private CreateIconObject RewardThumb;
  [SerializeField]
  private UILabel rewardName;

  [DebuggerHidden]
  public IEnumerator Init(BingoRewardGroup completeReward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271ConfirmationCompRewardPopup.\u003CInit\u003Ec__Iterator6B7()
    {
      completeReward = completeReward,
      \u003C\u0024\u003EcompleteReward = completeReward,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnOK() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnOK();
}
