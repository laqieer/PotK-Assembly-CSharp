// Decompiled with JetBrains decompiler
// Type: StoryPlaybackExtraExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class StoryPlaybackExtraExtension
{
  public static StoryPlaybackExtra[] DisplayList(
    this StoryPlaybackExtra[] self,
    DateTime serverTime)
  {
    return ((IEnumerable<StoryPlaybackExtra>) self).Where<StoryPlaybackExtra>((Func<StoryPlaybackExtra, bool>) (x =>
    {
      if (!x.display_expire_at.HasValue)
        return true;
      if (!x.display_expire_at.HasValue)
        return false;
      DateTime? displayExpireAt = x.display_expire_at;
      return displayExpireAt.HasValue && displayExpireAt.Value > serverTime;
    })).ToArray<StoryPlaybackExtra>();
  }
}
