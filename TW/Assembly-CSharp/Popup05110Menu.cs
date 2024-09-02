// Decompiled with JetBrains decompiler
// Type: Popup05110Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup05110Menu : BackButtonMenuBase
{
  public override void onBackButton() => this.IbtnClose();

  public void IbtnClose()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnReset()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.StartCoroutine(this.ShowDetaResetPopup());
  }

  [DebuggerHidden]
  private IEnumerator ShowDetaResetPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup05110Menu.\u003CShowDetaResetPopup\u003Ec__IteratorA4F popupCIteratorA4F = new Popup05110Menu.\u003CShowDetaResetPopup\u003Ec__IteratorA4F();
    return (IEnumerator) popupCIteratorA4F;
  }
}
