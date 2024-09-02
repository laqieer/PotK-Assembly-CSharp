// Decompiled with JetBrains decompiler
// Type: FriendScrollBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class FriendScrollBar : MonoBehaviour
{
  [SerializeField]
  protected UILabel friendName;
  [SerializeField]
  protected UILabel lastPlay;
  [SerializeField]
  protected UILabel level;
  [SerializeField]
  protected GameObject LinkCharacter;
  [SerializeField]
  protected UI2DSprite Emblem;
  private PlayerFriend friend;
  protected UnitIcon unitIcon;
  protected GameObject unitIconPrefab;
  protected DateTime nowTime;
  protected Friend0081Menu menu;
  protected int index;

  public UnitIcon UnicIcon => this.unitIcon;

  public PlayerFriend Friend => this.friend;

  public void Set(PlayerFriend friend, DateTime now)
  {
    this.nowTime = now;
    this.friendName.SetTextLocalize(friend.target_player_name);
    this.level.SetTextLocalize(friend.level.ToString());
    TimeSpan self = this.nowTime - friend.target_player_last_signed_in_at;
    this.lastPlay.SetTextLocalize(Consts.Format(Consts.GetInstance().LAST_PLAY, (IDictionary) new Hashtable()
    {
      {
        (object) "time",
        (object) self.DisplayStringForFriends()
      }
    }));
    this.friend = friend;
  }

  [DebuggerHidden]
  public virtual IEnumerator SetUnitIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FriendScrollBar.\u003CSetUnitIcon\u003Ec__Iterator50D()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void SetApplication(UILabel label)
  {
    TimeSpan self = this.nowTime - new DateTime(this.friend.applied_at.Value.Year, this.friend.applied_at.Value.Month, this.friend.applied_at.Value.Day);
    label.SetTextLocalize(Consts.Format(Consts.GetInstance().FRIEND_0085SCROLLPARTS_DESCRIPTION01, (IDictionary) new Hashtable()
    {
      {
        (object) "dsfapplied",
        (object) self.DisplayStringForFriendsApplied().ToConverter()
      }
    }));
  }

  protected void onDetails()
  {
    if (Object.op_Inequality((Object) this.menu, (Object) null))
      this.menu.LastIndex = this.index;
    if (this.friend.application)
      Singleton<NGSceneManager>.GetInstance().changeScene("friend008_6", true, (object) this.friend, (object) Friend0086Scene.Mode.Accept);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("friend008_6", true, (object) this.friend, (object) Friend0086Scene.Mode.Friend);
  }
}
