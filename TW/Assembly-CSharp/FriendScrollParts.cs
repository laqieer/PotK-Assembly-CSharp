// Decompiled with JetBrains decompiler
// Type: FriendScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class FriendScrollParts : FriendScrollBar
{
  [SerializeField]
  private UILabel ApplicationAt;
  public Friend0085Menu menu85;
  [SerializeField]
  private UIButton yesButton;
  [SerializeField]
  private UIButton noButton;

  public void Set(Friend0085Menu menu)
  {
    this.SetApplication(this.ApplicationAt);
    if (!Object.op_Inequality((Object) menu, (Object) null) || !Object.op_Equality((Object) this.menu85, (Object) null))
      return;
    this.menu85 = menu;
    EventDelegate.Set(this.yesButton.onClick, new EventDelegate.Callback(this.onAccept));
    EventDelegate.Set(this.noButton.onClick, new EventDelegate.Callback(this.onDeny));
  }

  [DebuggerHidden]
  private IEnumerator openPopup0087()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendScrollParts.\u003CopenPopup0087\u003Ec__Iterator52E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onAccept()
  {
    if (Object.op_Inequality((Object) this.menu, (Object) null))
    {
      if (this.menu.IsPushAndSet())
        return;
      this.StartCoroutine(this.openPopup0087());
    }
    else
      this.StartCoroutine(this.openPopup0087());
  }

  public void onDeny()
  {
    if (Object.op_Inequality((Object) this.menu, (Object) null))
    {
      if (this.menu.IsPushAndSet())
        return;
      this.StartCoroutine(this.openPopup0089());
    }
    else
      this.StartCoroutine(this.openPopup0089());
  }

  [DebuggerHidden]
  private IEnumerator openPopup0089()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendScrollParts.\u003CopenPopup0089\u003Ec__Iterator52F()
    {
      \u003C\u003Ef__this = this
    };
  }
}
