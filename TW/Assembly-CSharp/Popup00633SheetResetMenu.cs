// Decompiled with JetBrains decompiler
// Type: Popup00633SheetResetMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup00633SheetResetMenu : BackButtonMenuBase
{
  private Func<IEnumerator> YesAction;
  private System.Action NoAction;

  [DebuggerHidden]
  public IEnumerator Init(Func<IEnumerator> yesAction, System.Action noAction)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00633SheetResetMenu.\u003CInit\u003Ec__IteratorA00()
    {
      yesAction = yesAction,
      noAction = noAction,
      \u003C\u0024\u003EyesAction = yesAction,
      \u003C\u0024\u003EnoAction = noAction,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator IbtnYesReset()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup00633SheetResetMenu.\u003CIbtnYesReset\u003Ec__IteratorA01 resetCIteratorA01 = new Popup00633SheetResetMenu.\u003CIbtnYesReset\u003Ec__IteratorA01();
    return (IEnumerator) resetCIteratorA01;
  }

  public void IbtnYes()
  {
    if (this.YesAction == null)
      return;
    this.StartCoroutine(this.YesAction());
  }

  public void IbtnNo()
  {
    if (this.NoAction == null)
      return;
    this.NoAction();
  }

  public override void onBackButton() => this.IbtnNo();
}
