// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTrustLevelMaterialPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitTrustLevelMaterialPattern
  {
    public int ID;
    public int material_unit_UnitUnit;
    public int? rarity_UnitRarity;
    public int? kind_GearKind;
    public int? element_UnitFamily;
    public int? skill_BattleskillSkill;
    public int? target_character_UnitCharacter;
    public int? target_unit_UnitUnit;
    public int group_large_category_id_UnitGroupLargeCategory;
    public int group_small_category_id_UnitGroupSmallCategory;
    public int group_clothing_category_id_UnitGroupClothingCategory;
    public int group_generation_category_id_UnitGroupGenerationCategory;
    public float increase_value;

    public static UnitTrustLevelMaterialPattern Parse(
      MasterDataReader reader)
    {
      return new UnitTrustLevelMaterialPattern()
      {
        ID = reader.ReadInt(),
        material_unit_UnitUnit = reader.ReadInt(),
        rarity_UnitRarity = reader.ReadIntOrNull(),
        kind_GearKind = reader.ReadIntOrNull(),
        element_UnitFamily = reader.ReadIntOrNull(),
        skill_BattleskillSkill = reader.ReadIntOrNull(),
        target_character_UnitCharacter = reader.ReadIntOrNull(),
        target_unit_UnitUnit = reader.ReadIntOrNull(),
        group_large_category_id_UnitGroupLargeCategory = reader.ReadInt(),
        group_small_category_id_UnitGroupSmallCategory = reader.ReadInt(),
        group_clothing_category_id_UnitGroupClothingCategory = reader.ReadInt(),
        group_generation_category_id_UnitGroupGenerationCategory = reader.ReadInt(),
        increase_value = reader.ReadFloat()
      };
    }

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

    public UnitFamily? element
    {
      get
      {
        int? elementUnitFamily = this.element_UnitFamily;
        return !elementUnitFamily.HasValue ? new UnitFamily?() : new UnitFamily?((UnitFamily) elementUnitFamily.GetValueOrDefault());
      }
    }

    public BattleskillSkill skill
    {
      get
      {
        if (!this.skill_BattleskillSkill.HasValue)
          return (BattleskillSkill) null;
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill.Value, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill.Value + "]"));
        return battleskillSkill;
      }
    }

    public UnitCharacter target_character
    {
      get
      {
        if (!this.target_character_UnitCharacter.HasValue)
          return (UnitCharacter) null;
        UnitCharacter unitCharacter;
        if (!MasterData.UnitCharacter.TryGetValue(this.target_character_UnitCharacter.Value, out unitCharacter))
          Debug.LogError((object) ("Key not Found: MasterData.UnitCharacter[" + (object) this.target_character_UnitCharacter.Value + "]"));
        return unitCharacter;
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

    public UnitGroupLargeCategory group_large_category_id
    {
      get
      {
        UnitGroupLargeCategory groupLargeCategory;
        if (!MasterData.UnitGroupLargeCategory.TryGetValue(this.group_large_category_id_UnitGroupLargeCategory, out groupLargeCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupLargeCategory[" + (object) this.group_large_category_id_UnitGroupLargeCategory + "]"));
        return groupLargeCategory;
      }
    }

    public UnitGroupSmallCategory group_small_category_id
    {
      get
      {
        UnitGroupSmallCategory groupSmallCategory;
        if (!MasterData.UnitGroupSmallCategory.TryGetValue(this.group_small_category_id_UnitGroupSmallCategory, out groupSmallCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupSmallCategory[" + (object) this.group_small_category_id_UnitGroupSmallCategory + "]"));
        return groupSmallCategory;
      }
    }

    public UnitGroupClothingCategory group_clothing_category_id
    {
      get
      {
        UnitGroupClothingCategory clothingCategory;
        if (!MasterData.UnitGroupClothingCategory.TryGetValue(this.group_clothing_category_id_UnitGroupClothingCategory, out clothingCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupClothingCategory[" + (object) this.group_clothing_category_id_UnitGroupClothingCategory + "]"));
        return clothingCategory;
      }
    }

    public UnitGroupGenerationCategory group_generation_category_id
    {
      get
      {
        UnitGroupGenerationCategory generationCategory;
        if (!MasterData.UnitGroupGenerationCategory.TryGetValue(this.group_generation_category_id_UnitGroupGenerationCategory, out generationCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupGenerationCategory[" + (object) this.group_generation_category_id_UnitGroupGenerationCategory + "]"));
        return generationCategory;
      }
    }
  }
}
