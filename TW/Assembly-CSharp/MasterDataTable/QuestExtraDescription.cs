﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraDescription
  {
    public int ID;
    public int descriptionID;
    public string body;
    public string image_url;
    public int? image_width;
    public int? image_height;
    public int? extra_type;
    public int? extra_id;
    public int? extra_position;

    public static QuestExtraDescription Parse(MasterDataReader reader)
    {
      return new QuestExtraDescription()
      {
        ID = reader.ReadInt(),
        descriptionID = reader.ReadInt(),
        body = reader.ReadStringOrNull(true),
        image_url = reader.ReadStringOrNull(true),
        image_width = reader.ReadIntOrNull(),
        image_height = reader.ReadIntOrNull(),
        extra_type = reader.ReadIntOrNull(),
        extra_id = reader.ReadIntOrNull(),
        extra_position = reader.ReadIntOrNull()
      };
    }
  }
}
