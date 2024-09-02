// Decompiled with JetBrains decompiler
// Type: DailyMission0271CompRewardPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271CompRewardPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UIButton YesButton;
  [SerializeField]
  private UIButton NgButton;
  [SerializeField]
  private CreateIconObject RewardThumb;
  [SerializeField]
  private UILabel rewardName;
  private System.Action yesCallback;
  private System.Action noCallback;

  [DebuggerHidden]
  public IEnumerator Init(BingoRewardGroup completeReward, System.Action yes = null, System.Action no = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271CompRewardPopup.\u003CInit\u003Ec__Iterator6B6()
    {
      completeReward = completeReward,
      yes = yes,
      no = no,
      \u003C\u0024\u003EcompleteReward = completeReward,
      \u003C\u0024\u003Eyes = yes,
      \u003C\u0024\u003Eno = no,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.noCallback != null)
      this.noCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnYes()
  {
    if (this.yesCallback != null)
      this.yesCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
