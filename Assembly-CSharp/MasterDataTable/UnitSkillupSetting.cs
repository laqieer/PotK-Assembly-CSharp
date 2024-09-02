// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillupSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillupSetting
  {
    public int ID;
    public int material_unit_id;
    public float levelup_ratio;
    public int? skill_group;

    public static UnitSkillupSetting Parse(MasterDataReader reader) => new UnitSkillupSetting()
    {
      ID = reader.ReadInt(),
      material_unit_id = reader.ReadInt(),
      levelup_ratio = reader.ReadFloat(),
      skill_group = reader.ReadIntOrNull()
    };
  }
}
