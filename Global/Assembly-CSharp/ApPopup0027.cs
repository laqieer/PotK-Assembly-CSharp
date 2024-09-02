// Decompiled with JetBrains decompiler
// Type: ApPopup0027
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class ApPopup0027 : BackButtonMenuBase
{
  public void ibtnYes() => this.StartCoroutine(this.popup00712());

  [DebuggerHidden]
  private IEnumerator popup00712()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ApPopup0027.\u003Cpopup00712\u003Ec__Iterator1CA popup00712CIterator1Ca = new ApPopup0027.\u003Cpopup00712\u003Ec__Iterator1CA();
    return (IEnumerator) popup00712CIterator1Ca;
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
