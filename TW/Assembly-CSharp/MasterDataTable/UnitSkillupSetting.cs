﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillupSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
