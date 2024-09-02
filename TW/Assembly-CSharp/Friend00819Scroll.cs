// Decompiled with JetBrains decompiler
// Type: Friend00819Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class Friend00819Scroll : FriendScrollBar
{
  [SerializeField]
  private UILabel ApplicationAt;
  [SerializeField]
  private UIButton CheckBox;
  [SerializeField]
  private GameObject CheckMark;
  private FriendBarInfo info;
  private Friend00819Menu menu819;

  public void Set(bool is_checked, DateTime now, FriendBarInfo info, Friend00819Menu menu)
  {
    this.info = info;
    this.menu819 = menu;
    DateTime dateTime = new DateTime(this.Friend.applied_at.Value.Year, this.Friend.applied_at.Value.Month, this.Friend.applied_at.Value.Day);
    TimeSpan self = now - dateTime;
    this.ApplicationAt.SetText(Consts.Format(Consts.GetInstance().FRIEND_0085SCROLLPARTS_DESCRIPTION01, (IDictionary) new Hashtable()
    {
      {
        (object) "dsfapplied",
        (object) self.DisplayStringForFriendsApplied().ToConverter()
      }
    }));
    TimeSpan timeSpan = now - this.Friend.target_player_last_signed_in_at;
    EventDelegate.Set(this.CheckBox.onClick, new EventDelegate.Callback(this.Select));
    this.CheckMark.SetActive(info.select);
  }

  public void Select()
  {
    this.info.select = !this.info.select;
    this.CheckMark.SetActive(this.info.select);
    this.menu819.CheckSelect();
  }

  public void CheckMarkUpdate() => this.CheckMark.SetActive(this.info.select);
}
