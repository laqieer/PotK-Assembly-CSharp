﻿// Decompiled with JetBrains decompiler
// Type: FriendBarInfoExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class FriendBarInfoExtension
{
  public static IEnumerable<FriendBarInfo> SortBy(this IEnumerable<FriendBarInfo> self)
  {
    List<FriendBarInfo> friendBarInfoList = new List<FriendBarInfo>();
    switch (Persist.sortOrder.Data.Friend)
    {
      case 0:
        friendBarInfoList = self.OrderByDescending<FriendBarInfo, bool>((Func<FriendBarInfo, bool>) (fr => fr.friend.is_favorite)).ThenByDescending<FriendBarInfo, DateTime?>((Func<FriendBarInfo, DateTime?>) (fr => fr.friend.applied_at)).ToList<FriendBarInfo>();
        break;
      case 1:
        friendBarInfoList = self.OrderByDescending<FriendBarInfo, DateTime?>((Func<FriendBarInfo, DateTime?>) (fr => fr.friend.applied_at)).ThenByDescending<FriendBarInfo, int>((Func<FriendBarInfo, int>) (fr => fr.friend.level)).ToList<FriendBarInfo>();
        break;
      case 2:
        friendBarInfoList = self.OrderByDescending<FriendBarInfo, int>((Func<FriendBarInfo, int>) (fr => fr.friend.level)).ThenByDescending<FriendBarInfo, int>((Func<FriendBarInfo, int>) (fr => fr.friend.leader_unit.level)).ToList<FriendBarInfo>();
        break;
    }
    return (IEnumerable<FriendBarInfo>) friendBarInfoList;
  }
}
