// Decompiled with JetBrains decompiler
// Type: Popup023411Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup023411Menu : BackButtonMenuBase
{
  public virtual void IbtnBack() => Singleton<PopupManager>.GetInstance().onDismiss();

  public virtual void IbtnRecover() => this.StartCoroutine(this.ShowBPAlertPopup());

  public void IbtnNo() => this.IbtnBack();

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator ShowBPAlertPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup023411Menu.\u003CShowBPAlertPopup\u003Ec__IteratorA1B popupCIteratorA1B = new Popup023411Menu.\u003CShowBPAlertPopup\u003Ec__IteratorA1B();
    return (IEnumerator) popupCIteratorA1B;
  }
}
