// Decompiled with JetBrains decompiler
// Type: SM_PlayerFriendExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_PlayerFriendExtension
{
  public static PlayerFriend[] Friends(this IEnumerable<PlayerFriend> self)
  {
    return self.Where<PlayerFriend>((Func<PlayerFriend, bool>) (x => !x.application)).ToArray<PlayerFriend>();
  }

  public static PlayerFriend[] SentFriendApplications(this IEnumerable<PlayerFriend> self)
  {
    return self.Where<PlayerFriend>((Func<PlayerFriend, bool>) (x => x.application && x.sent_player_id == Player.Current.id)).ToArray<PlayerFriend>();
  }

  public static PlayerFriend[] ReceivedFriendApplications(this IEnumerable<PlayerFriend> self)
  {
    return self.Where<PlayerFriend>((Func<PlayerFriend, bool>) (x => x.application && x.sent_player_id != Player.Current.id)).ToArray<PlayerFriend>();
  }
}
