// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillupSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillupSetting
  {
    public int ID;
    public int material_unit_id;
    public float levelup_ratio;
    public int? skill_group;

    public static UnitSkillupSetting Parse(MasterDataReader reader)
    {
      return new UnitSkillupSetting()
      {
        ID = reader.ReadInt(),
        material_unit_id = reader.ReadInt(),
        levelup_ratio = reader.ReadFloat(),
        skill_group = reader.ReadIntOrNull()
      };
    }
  }
}
