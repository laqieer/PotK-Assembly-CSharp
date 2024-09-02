// Decompiled with JetBrains decompiler
// Type: Popup00173Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup00173Menu : NGMenuBase
{
  public UILabel TxtPopupTitle;
  public UILabel TxtDescription1;
  public UILabel TxtDescription2;
  public UIButton IBtnOk;
  private bool Present;
  private PlayerPresent[] receiveList;

  [DebuggerHidden]
  public IEnumerator Init(PlayerPresent[] presents, int noReceiveCount = 0, bool isPresent = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00173Menu.\u003CInit\u003Ec__Iterator7AE()
    {
      isPresent = isPresent,
      presents = presents,
      noReceiveCount = noReceiveCount,
      \u003C\u0024\u003EisPresent = isPresent,
      \u003C\u0024\u003Epresents = presents,
      \u003C\u0024\u003EnoReceiveCount = noReceiveCount,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00173Menu.\u003CShowPopup\u003Ec__Iterator7AF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnOk()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (!this.Present)
      return;
    this.StartCoroutine(this.ShowPopup());
  }
}
