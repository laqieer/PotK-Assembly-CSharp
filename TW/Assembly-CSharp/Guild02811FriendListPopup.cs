// Decompiled with JetBrains decompiler
// Type: Guild02811FriendListPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Guild02811FriendListPopup : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll scroll;
  [SerializeField]
  private GameObject nonFriend;

  public void Initialize(
    Guild02811Menu menu,
    GameObject parts,
    WebAPI.Response.GuildFriendAffiliations friends,
    DateTime now)
  {
    this.scroll.Clear();
    this.scroll.Reset();
    if (friends == null || friends.friend_affiliations.Length <= 0)
    {
      this.nonFriend.SetActive(true);
    }
    else
    {
      this.nonFriend.SetActive(false);
      PlayerFriend[] self = SMManager.Get<PlayerFriend[]>();
      foreach (FriendAffiliation friendAffiliation in friends.friend_affiliations)
      {
        FriendAffiliation friend = friendAffiliation;
        if (friend.guild != null)
        {
          GameObject gameObject = Object.Instantiate<GameObject>(parts);
          Guild02811FriendScrollBar component = gameObject.GetComponent<Guild02811FriendScrollBar>();
          if (Object.op_Inequality((Object) component, (Object) null))
          {
            int? nullable = ((IEnumerable<PlayerFriend>) self).FirstIndexOrNull<PlayerFriend>((Func<PlayerFriend, bool>) (z => z.target_player_id == friend.player_id));
            if (nullable.HasValue)
            {
              component.Set(self[nullable.Value], now);
              this.StartCoroutine(component.SetUnitIcon());
              component.Menu = menu;
              component.Guild = friend.guild;
            }
            else
              continue;
          }
          this.scroll.Add(gameObject);
        }
      }
    }
    this.scroll.ResolvePosition();
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();
}
