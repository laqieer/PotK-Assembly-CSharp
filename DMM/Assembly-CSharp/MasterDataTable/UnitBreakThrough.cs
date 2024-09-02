// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitBreakThrough
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitBreakThrough
  {
    public int ID;
    public int material_unit_UnitUnit;
    public int? rarity_UnitRarity;
    public int? kind_GearKind;
    public int? target_unit_UnitUnit;
    public int? skill_id_BattleskillSkill;

    public static UnitBreakThrough Parse(MasterDataReader reader) => new UnitBreakThrough()
    {
      ID = reader.ReadInt(),
      material_unit_UnitUnit = reader.ReadInt(),
      rarity_UnitRarity = reader.ReadIntOrNull(),
      kind_GearKind = reader.ReadIntOrNull(),
      target_unit_UnitUnit = reader.ReadIntOrNull(),
      skill_id_BattleskillSkill = reader.ReadIntOrNull()
    };

    public UnitUnit material_unit
    {
      get
      {
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.material_unit_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.material_unit_UnitUnit + "]"));
        return unitUnit;
      }
    }

    public UnitRarity rarity
    {
      get
      {
        if (!this.rarity_UnitRarity.HasValue)
          return (UnitRarity) null;
        UnitRarity unitRarity;
        if (!MasterData.UnitRarity.TryGetValue(this.rarity_UnitRarity.Value, out unitRarity))
          Debug.LogError((object) ("Key not Found: MasterData.UnitRarity[" + (object) this.rarity_UnitRarity.Value + "]"));
        return unitRarity;
      }
    }

    public GearKind kind
    {
      get
      {
        if (!this.kind_GearKind.HasValue)
          return (GearKind) null;
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.kind_GearKind.Value, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.kind_GearKind.Value + "]"));
        return gearKind;
      }
    }

    public UnitUnit target_unit
    {
      get
      {
        if (!this.target_unit_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.target_unit_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.target_unit_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public BattleskillSkill skill_id
    {
      get
      {
        if (!this.skill_id_BattleskillSkill.HasValue)
          return (BattleskillSkill) null;
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_id_BattleskillSkill.Value, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_id_BattleskillSkill.Value + "]"));
        return battleskillSkill;
      }
    }
  }
}
