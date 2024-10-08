﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitGroupClothingCategory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitGroupClothingCategory
  {
    public int ID;
    public string name;
    public string short_label_name;
    public string description;
    public DateTime? start_at;

    public static UnitGroupClothingCategory Parse(MasterDataReader reader) => new UnitGroupClothingCategory()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      short_label_name = reader.ReadString(true),
      description = reader.ReadString(true),
      start_at = reader.ReadDateTimeOrNull()
    };

    public string GetSpriteName() => string.Format("dresses_{0}", (object) this.ID);
  }
}
