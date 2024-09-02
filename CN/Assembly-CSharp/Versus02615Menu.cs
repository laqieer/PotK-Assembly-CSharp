// Decompiled with JetBrains decompiler
// Type: Versus02615Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02615Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScrollMasonry Scroll;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtTerm;
  [SerializeField]
  private UILabel txtRewardReceivalbe;

  [DebuggerHidden]
  public IEnumerator Init(int term, string disp_term, DateTime? recievable)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02615Menu.\u003CInit\u003Ec__Iterator648()
    {
      disp_term = disp_term,
      recievable = recievable,
      term = term,
      \u003C\u0024\u003Edisp_term = disp_term,
      \u003C\u0024\u003Erecievable = recievable,
      \u003C\u0024\u003Eterm = term,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetScroll(PvpRankingReward[] rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02615Menu.\u003CSetScroll\u003Ec__Iterator649()
    {
      rewards = rewards,
      \u003C\u0024\u003Erewards = rewards,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
