// Decompiled with JetBrains decompiler
// Type: Popup05020Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup05020Menu : BackButtonMenuBase
{
  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo() => this.StartCoroutine(this.ShowResetPopup());

  public void IbtnYes()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<EarthDataManager>.GetInstance().BattleInit();
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  [DebuggerHidden]
  private IEnumerator ShowResetPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup05020Menu.\u003CShowResetPopup\u003Ec__Iterator80A popupCIterator80A = new Popup05020Menu.\u003CShowResetPopup\u003Ec__Iterator80A();
    return (IEnumerator) popupCIterator80A;
  }
}
