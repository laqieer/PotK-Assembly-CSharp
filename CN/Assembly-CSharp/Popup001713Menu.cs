// Decompiled with JetBrains decompiler
// Type: Popup001713Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Popup001713Menu : BackButtonMenuBase
{
  public UILabel TxtDescription;
  private bool IsPresent;
  private Mypage0017Menu menu0017;
  private List<PlayerPresent> receiveList = new List<PlayerPresent>();

  [DebuggerHidden]
  public IEnumerator Init(Mypage0017Menu menu, PlayerPresent[] presents)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup001713Menu.\u003CInit\u003Ec__Iterator916()
    {
      menu = menu,
      presents = presents,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Epresents = presents,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ReceiveAll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup001713Menu.\u003CReceiveAll\u003Ec__Iterator917()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnYes()
  {
    this.StartCoroutine(this.ReceiveAll());
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
