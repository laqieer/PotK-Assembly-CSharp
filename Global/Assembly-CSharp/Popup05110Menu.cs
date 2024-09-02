// Decompiled with JetBrains decompiler
// Type: Popup05110Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    Popup05110Menu.\u003CShowDetaResetPopup\u003Ec__Iterator80B popupCIterator80B = new Popup05110Menu.\u003CShowDetaResetPopup\u003Ec__Iterator80B();
    return (IEnumerator) popupCIterator80B;
  }
}
