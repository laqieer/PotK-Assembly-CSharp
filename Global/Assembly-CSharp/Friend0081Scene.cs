// Decompiled with JetBrains decompiler
// Type: Friend0081Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Friend0081Scene.\u003ConInitSceneAsync\u003Ec__Iterator420()
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
      component.set(playerFriendArray2.Length);
    else
      component.set(0);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0081Scene.\u003ConStartSceneAsync\u003Ec__Iterator421()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => Persist.sortOrder.Flush();
}
