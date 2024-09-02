// Decompiled with JetBrains decompiler
// Type: Popup00179Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup00179Menu : BackButtonMenuBase
{
  private Mypage0017Menu menu0017;
  private PlayerPresent deletePresent;

  [DebuggerHidden]
  public IEnumerator Init(PlayerPresent present, Mypage0017Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00179Menu.\u003CInit\u003Ec__Iterator9EF()
    {
      menu = menu,
      present = present,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Epresent = present,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator DeletePresent()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00179Menu.\u003CDeletePresent\u003Ec__Iterator9F0()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnYes() => this.StartCoroutine(this.DeletePresent());

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
