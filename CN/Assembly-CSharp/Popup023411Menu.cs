// Decompiled with JetBrains decompiler
// Type: Popup023411Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Popup023411Menu.\u003CShowBPAlertPopup\u003Ec__Iterator946 popupCIterator946 = new Popup023411Menu.\u003CShowBPAlertPopup\u003Ec__Iterator946();
    return (IEnumerator) popupCIterator946;
  }
}
