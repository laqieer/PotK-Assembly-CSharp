﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.StoryPlaybackEventPlay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class StoryPlaybackEventPlay
  {
    public int ID;
    public string scene_name;
    public int? arg1;
    public int script_id;
    public DateTime start_at;
    public DateTime end_at;

    public static StoryPlaybackEventPlay Parse(MasterDataReader reader)
    {
      return new StoryPlaybackEventPlay()
      {
        ID = reader.ReadInt(),
        scene_name = reader.ReadStringOrNull(true),
        arg1 = reader.ReadIntOrNull(),
        script_id = reader.ReadInt(),
        start_at = reader.ReadDateTime(),
        end_at = reader.ReadDateTime()
      };
    }

    public static IEnumerable<StoryPlaybackEventPlay> GetPlayList(
      DateTime serverTime,
      DateTime playedTime)
    {
      return ((IEnumerable<StoryPlaybackEventPlay>) MasterData.StoryPlaybackEventPlayList).Where<StoryPlaybackEventPlay>((Func<StoryPlaybackEventPlay, bool>) (x => playedTime < x.start_at && x.start_at <= serverTime && x.end_at >= serverTime));
    }
  }
}
