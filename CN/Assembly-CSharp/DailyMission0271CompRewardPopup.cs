﻿// Decompiled with JetBrains decompiler
// Type: DailyMission0271CompRewardPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271CompRewardPopup : BackButtonMenuBase
{
  [SerializeField]
  private UIButton YesButton;
  [SerializeField]
  private UIButton NgButton;
  [SerializeField]
  private GameObject RewardThumbImage;
  private System.Action yes;
  private System.Action no;

  [DebuggerHidden]
  public IEnumerator Init(Hashtable reward, System.Action yes = null, System.Action no = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271CompRewardPopup.\u003CInit\u003Ec__Iterator66C()
    {
      reward = reward,
      yes = yes,
      no = no,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u0024\u003Eyes = yes,
      \u003C\u0024\u003Eno = no,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    this.no();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.yes();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  [DebuggerHidden]
  private IEnumerator loadThumb(int rewardID, int rewardTypeID, int rewardQuantity)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271CompRewardPopup.\u003CloadThumb\u003Ec__Iterator66D()
    {
      rewardTypeID = rewardTypeID,
      rewardID = rewardID,
      rewardQuantity = rewardQuantity,
      \u003C\u0024\u003ErewardTypeID = rewardTypeID,
      \u003C\u0024\u003ErewardID = rewardID,
      \u003C\u0024\u003ErewardQuantity = rewardQuantity,
      \u003C\u003Ef__this = this
    };
  }

  public static void defaultCallback() => Debug.Log((object) "popup close");
}
