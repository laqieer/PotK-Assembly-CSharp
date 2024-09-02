// Decompiled with JetBrains decompiler
// Type: Popup023411Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    Popup023411Menu.\u003CShowBPAlertPopup\u003Ec__Iterator7D6 popupCIterator7D6 = new Popup023411Menu.\u003CShowBPAlertPopup\u003Ec__Iterator7D6();
    return (IEnumerator) popupCIterator7D6;
  }
}
