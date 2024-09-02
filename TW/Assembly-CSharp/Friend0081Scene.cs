// Decompiled with JetBrains decompiler
// Type: Friend0081Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend0081Scene : NGSceneBase
{
  [SerializeField]
  private UILabel TxtNumber;
  [SerializeField]
  private GameObject BadgeIcon;
  [SerializeField]
  private Friend0081Menu menu;
  private bool isInit = true;
  private int friendCnt;
  private GameObject badgeGo;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0081Scene.\u003ConInitSceneAsync\u003Ec__Iterator50B()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void UpdateInfomation()
  {
    Player player = SMManager.Get<Player>();
    PlayerFriend[] playerFriendArray1 = ((IEnumerable<PlayerFriend>) SMManager.Get<PlayerFriend[]>()).Friends();
    PlayerFriend[] playerFriendArray2 = ((IEnumerable<PlayerFriend>) SMManager.Get<PlayerFriend[]>()).ReceivedFriendApplications();
    this.menu.DirNoFriend.SetActive(playerFriendArray1.Length == 0);
    this.TxtNumber.SetTextLocalize(playerFriendArray1.Length.ToString("D3") + "/" + player.max_friends.ToString("D3"));
    ButtonBadge component = this.badgeGo.GetComponent<ButtonBadge>();
    if (playerFriendArray2 != null)
    {
      Singleton<NGGameDataManager>.GetInstance().ReceivedFriendRequestCount = playerFriendArray2.Length;
      component.set(playerFriendArray2.Length);
    }
    else
    {
      Singleton<NGGameDataManager>.GetInstance().ReceivedFriendRequestCount = 0;
      component.set(0);
    }
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0081Scene.\u003ConStartSceneAsync\u003Ec__Iterator50C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => Persist.sortOrder.Flush();

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("friend008_1", stack);
  }
}
