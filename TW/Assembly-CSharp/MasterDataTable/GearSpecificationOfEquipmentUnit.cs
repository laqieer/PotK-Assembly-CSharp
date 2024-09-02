// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearSpecificationOfEquipmentUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearSpecificationOfEquipmentUnit
  {
    public int ID;
    public int group_id;
    public int unit_id;

    public static GearSpecificationOfEquipmentUnit Parse(MasterDataReader reader)
    {
      return new GearSpecificationOfEquipmentUnit()
      {
        ID = reader.ReadInt(),
        group_id = reader.ReadInt(),
        unit_id = reader.ReadInt()
      };
    }
  }
}
