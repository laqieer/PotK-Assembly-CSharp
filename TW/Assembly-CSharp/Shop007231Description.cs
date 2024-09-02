// Decompiled with JetBrains decompiler
// Type: Shop007231Description
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop007231Description : BackButtonMenuBase
{
  [SerializeField]
  private UIScrollView scroll_;
  [SerializeField]
  private UILabel txtDescription_;
  [SerializeField]
  private UILabel txtNames_;
  private SM.UnitTicket ticket_;

  public void initialize(SM.UnitTicket ticket) => this.ticket_ = ticket;

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop007231Description.\u003CStart\u003Ec__Iterator4CB()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.OnIbtnBack();

  public void OnIbtnBack() => Singleton<PopupManager>.GetInstance().onDismiss();
}
