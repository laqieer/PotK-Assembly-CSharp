// Decompiled with JetBrains decompiler
// Type: Popup05111Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup05111Menu : BackButtonMenuBase
{
  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.DataReset());
  }

  [DebuggerHidden]
  private IEnumerator DataReset()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup05111Menu.\u003CDataReset\u003Ec__Iterator97B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowDetaResetCompletePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup05111Menu.\u003CShowDetaResetCompletePopup\u003Ec__Iterator97C popupCIterator97C = new Popup05111Menu.\u003CShowDetaResetCompletePopup\u003Ec__Iterator97C();
    return (IEnumerator) popupCIterator97C;
  }
}
