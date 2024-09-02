// Decompiled with JetBrains decompiler
// Type: Popup00173Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Popup00173Menu.\u003CInit\u003Ec__Iterator9ED()
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
    return (IEnumerator) new Popup00173Menu.\u003CShowPopup\u003Ec__Iterator9EE()
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
