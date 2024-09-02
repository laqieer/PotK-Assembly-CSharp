// Decompiled with JetBrains decompiler
// Type: Quest00230NextRewardObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00230NextRewardObject : MonoBehaviour
{
  private const int TWEEN_GROUPID_START = 0;
  private const int TWEEN_GROUPID_END = 1;
  [SerializeField]
  private CreateIconObject[] nextRewardThums;
  [SerializeField]
  private UILabel txtNextRewardPointLabel;
  private TweenAlpha[] tweenAlphas;
  private System.Action displayEndAction;
  private System.Action hiddenEndAction;
  private bool isEnable;

  public bool Enable => this.isEnable;

  [DebuggerHidden]
  public IEnumerator Init(
    WebAPI.Response.EventTop eventTopInfo,
    List<IGrouping<Tuple<EventPointType, int, int>, PunitiveExpeditionEventReward>> rewardList,
    EventPointType rewardType,
    System.Action displayAction,
    System.Action hiddenAction)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00230NextRewardObject.\u003CInit\u003Ec__Iterator260()
    {
      displayAction = displayAction,
      hiddenAction = hiddenAction,
      rewardType = rewardType,
      rewardList = rewardList,
      eventTopInfo = eventTopInfo,
      \u003C\u0024\u003EdisplayAction = displayAction,
      \u003C\u0024\u003EhiddenAction = hiddenAction,
      \u003C\u0024\u003ErewardType = rewardType,
      \u003C\u0024\u003ErewardList = rewardList,
      \u003C\u0024\u003EeventTopInfo = eventTopInfo,
      \u003C\u003Ef__this = this
    };
  }

  private void StartTweenAlpha(int groupID)
  {
    TweenAlpha tweenAlpha = ((IEnumerable<TweenAlpha>) this.tweenAlphas).FirstOrDefault<TweenAlpha>((Func<TweenAlpha, bool>) (x => x.tweenGroup == groupID));
    if (!Object.op_Inequality((Object) tweenAlpha, (Object) null))
      return;
    tweenAlpha.ResetToBeginning();
    tweenAlpha.PlayForward();
  }

  public void DisplayEnd()
  {
    if (this.displayEndAction == null)
      return;
    this.displayEndAction();
  }

  public void HiddenEnd()
  {
    ((Component) this).gameObject.SetActive(false);
    if (this.hiddenEndAction == null)
      return;
    this.hiddenEndAction();
  }

  public void Display()
  {
    if (!this.isEnable)
      return;
    ((Component) this).gameObject.SetActive(true);
    this.StartTweenAlpha(0);
  }

  public void Hidden()
  {
    if (!this.isEnable)
      return;
    this.StartTweenAlpha(1);
  }
}
