﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SkillMetamorphosis
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class SkillMetamorphosis
  {
    public int ID;
    public int unit_UnitUnit;
    public int group_id;
    public int skill_BattleskillSkill;
    public int metamorphosis_id;

    public static SkillMetamorphosis Parse(MasterDataReader reader) => new SkillMetamorphosis()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadInt(),
      group_id = reader.ReadInt(),
      skill_BattleskillSkill = reader.ReadInt(),
      metamorphosis_id = reader.ReadInt()
    };

    public UnitUnit unit
    {
      get
      {
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit + "]"));
        return unitUnit;
      }
    }

    public BattleskillSkill skill
    {
      get
      {
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill + "]"));
        return battleskillSkill;
      }
    }
  }
}
