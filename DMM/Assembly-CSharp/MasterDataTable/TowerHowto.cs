﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TowerHowto
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TowerHowto
  {
    public int ID;
    public int kind;
    public string body;
    public string image_url;
    public int? image_width;
    public int? image_height;
    public int? extra_type;
    public int? extra_id;
    public int? extra_position;

    public static TowerHowto Parse(MasterDataReader reader) => new TowerHowto()
    {
      ID = reader.ReadInt(),
      kind = reader.ReadInt(),
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
