﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DailyMissionTopPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class DailyMissionTopPage
  {
    public int ID;
    public string title;
    public string message;
    public string attention;
    public DateTime? start_at;
    public DateTime? end_at;

    public static DailyMissionTopPage Parse(MasterDataReader reader) => new DailyMissionTopPage()
    {
      ID = reader.ReadInt(),
      title = reader.ReadString(true),
      message = reader.ReadString(true),
      attention = reader.ReadString(true),
      start_at = reader.ReadDateTimeOrNull(),
      end_at = reader.ReadDateTimeOrNull()
    };
  }
}
