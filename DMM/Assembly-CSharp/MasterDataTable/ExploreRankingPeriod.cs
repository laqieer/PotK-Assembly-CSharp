﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ExploreRankingPeriod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class ExploreRankingPeriod
  {
    public int ID;
    public DateTime? start_at;
    public DateTime? end_at;
    public DateTime? aggregate_end_at;
    public int reward_group_id;

    public static ExploreRankingPeriod Parse(MasterDataReader reader) => new ExploreRankingPeriod()
    {
      ID = reader.ReadInt(),
      start_at = reader.ReadDateTimeOrNull(),
      end_at = reader.ReadDateTimeOrNull(),
      aggregate_end_at = reader.ReadDateTimeOrNull(),
      reward_group_id = reader.ReadInt()
    };
  }
}
