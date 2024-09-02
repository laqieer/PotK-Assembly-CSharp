// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearCombineRecipe
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearCombineRecipe
  {
    public int ID;
    public int material1_gear_id;
    public int? material2_gear_id;
    public int? material3_gear_id;
    public int? material4_gear_id;
    public int? material5_gear_id;
    public int? material1_gear_rank;
    public int? material2_gear_rank;
    public int? material3_gear_rank;
    public int? material4_gear_rank;
    public int? material5_gear_rank;
    public int combined_gear_id;
    public string extension;
    public DateTime? start_at;
    public DateTime? end_at;
    public int priority;

    public static GearCombineRecipe Parse(MasterDataReader reader)
    {
      return new GearCombineRecipe()
      {
        ID = reader.ReadInt(),
        material1_gear_id = reader.ReadInt(),
        material2_gear_id = reader.ReadIntOrNull(),
        material3_gear_id = reader.ReadIntOrNull(),
        material4_gear_id = reader.ReadIntOrNull(),
        material5_gear_id = reader.ReadIntOrNull(),
        material1_gear_rank = reader.ReadIntOrNull(),
        material2_gear_rank = reader.ReadIntOrNull(),
        material3_gear_rank = reader.ReadIntOrNull(),
        material4_gear_rank = reader.ReadIntOrNull(),
        material5_gear_rank = reader.ReadIntOrNull(),
        combined_gear_id = reader.ReadInt(),
        extension = reader.ReadString(true),
        start_at = reader.ReadDateTimeOrNull(),
        end_at = reader.ReadDateTimeOrNull(),
        priority = reader.ReadInt()
      };
    }
  }
}
