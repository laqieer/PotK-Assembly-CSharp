// Decompiled with JetBrains decompiler
// Type: Friend0087Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Friend0087Menu : BackButtonMenuBase
{
  private List<string> target_friend_ids = new List<string>();
  private System.Action callBack;

  public void IsBack(bool is_back)
  {
  }

  public void Init0087PopUp(string id, System.Action callback = null)
  {
    this.target_friend_ids.Add(id);
    this.callBack = callback;
  }

  [DebuggerHidden]
  private IEnumerator openPopup00872(string friendName)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0087Menu.\u003CopenPopup00872\u003Ec__Iterator4EA()
    {
      friendName = friendName,
      \u003C\u0024\u003EfriendName = friendName
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup0088(string reason)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0087Menu.\u003CopenPopup0088\u003Ec__Iterator4EB()
    {
      reason = reason,
      \u003C\u0024\u003Ereason = reason
    };
  }

  [DebuggerHidden]
  private IEnumerator FriendAcceptAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0087Menu.\u003CFriendAcceptAsync\u003Ec__Iterator4EC()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.FriendAcceptAsync());
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
