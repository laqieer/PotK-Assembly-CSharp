// Decompiled with JetBrains decompiler
// Type: Friend0087Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
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
    return (IEnumerator) new Friend0087Menu.\u003CopenPopup00872\u003Ec__Iterator53B()
    {
      friendName = friendName,
      \u003C\u0024\u003EfriendName = friendName
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup0088(string reason)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0087Menu.\u003CopenPopup0088\u003Ec__Iterator53C()
    {
      reason = reason,
      \u003C\u0024\u003Ereason = reason
    };
  }

  [DebuggerHidden]
  private IEnumerator FriendAcceptAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0087Menu.\u003CFriendAcceptAsync\u003Ec__Iterator53D()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void UpdateReceivedFriend()
  {
    SMManager.Get<Player>();
    ((IEnumerable<PlayerFriend>) SMManager.Get<PlayerFriend[]>()).Friends();
    PlayerFriend[] playerFriendArray = ((IEnumerable<PlayerFriend>) SMManager.Get<PlayerFriend[]>()).ReceivedFriendApplications();
    if (playerFriendArray != null)
      Singleton<NGGameDataManager>.GetInstance().ReceivedFriendRequestCount = playerFriendArray.Length;
    else
      Singleton<NGGameDataManager>.GetInstance().ReceivedFriendRequestCount = 0;
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
