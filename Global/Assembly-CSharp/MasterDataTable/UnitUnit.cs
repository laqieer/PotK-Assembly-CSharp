// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitUnit
  {
    public int ID;
    private string _name;
    public int parameter_data_UnitUnitParameter;
    public int etc_data_UnitUnitDescription;
    public DateTime? published_at;
    public int same_character_id;
    public int character_UnitCharacter;
    public int resource_reference_unit_id_UnitUnit;
    public int rarity_UnitRarity;
    public int cost;
    public int job_UnitJob;
    public int is_consume_only;
    public int is_evolution_only;
    public int skillup_type;
    public int is_breakthrough_only;
    public int is_buildup_only;
    public int kind_GearKind;
    public int history_group_number;
    public int _base_sell_price;
    public int initial_gear_GearGear;
    public string vehicle_model_name;
    public string equip_model_name;
    public string equip_model_b_name;
    public string field_normal_face_material_name;
    public string field_gray_body_material_name;
    public string field_gray_face_material_name;
    public string field_gray_vehicle_material_name;
    public string field_gray_equip_material_name;
    public string field_gray_equip_b_material_name;
    public int cutin_effect_type_CutinEffect;
    public float duel_model_scale;
    public float field_model_scale;
    public float duel_shadow_scale_x;
    public float duel_shadow_scale_z;
    public int footstep_type_UnitFootstepType;
    public int camera_pattern_UnitCameraPattern;
    public int illust_pattern_UnitIllustPattern;
    public int? cutin_pattern_id;
    public int voice_pattern_id;
    public bool non_disp_weapon;
    public bool rainbow_on;
    private static readonly string duelAnimatorRootPath = "Animators/duel/{0}";
    private static readonly string winAnimatorRootPath = "Animators/duel_win/{0}";

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitUnit_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static UnitUnit Parse(MasterDataReader reader)
    {
      return new UnitUnit()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        parameter_data_UnitUnitParameter = reader.ReadInt(),
        etc_data_UnitUnitDescription = reader.ReadInt(),
        published_at = reader.ReadDateTimeOrNull(),
        same_character_id = reader.ReadInt(),
        character_UnitCharacter = reader.ReadInt(),
        resource_reference_unit_id_UnitUnit = reader.ReadInt(),
        rarity_UnitRarity = reader.ReadInt(),
        cost = reader.ReadInt(),
        job_UnitJob = reader.ReadInt(),
        is_consume_only = reader.ReadInt(),
        is_evolution_only = reader.ReadInt(),
        skillup_type = reader.ReadInt(),
        is_breakthrough_only = reader.ReadInt(),
        is_buildup_only = reader.ReadInt(),
        kind_GearKind = reader.ReadInt(),
        history_group_number = reader.ReadInt(),
        _base_sell_price = reader.ReadInt(),
        initial_gear_GearGear = reader.ReadInt(),
        vehicle_model_name = reader.ReadStringOrNull(true),
        equip_model_name = reader.ReadStringOrNull(true),
        equip_model_b_name = reader.ReadStringOrNull(true),
        field_normal_face_material_name = reader.ReadString(true),
        field_gray_body_material_name = reader.ReadString(true),
        field_gray_face_material_name = reader.ReadString(true),
        field_gray_vehicle_material_name = reader.ReadString(true),
        field_gray_equip_material_name = reader.ReadString(true),
        field_gray_equip_b_material_name = reader.ReadString(true),
        cutin_effect_type_CutinEffect = reader.ReadInt(),
        duel_model_scale = reader.ReadFloat(),
        field_model_scale = reader.ReadFloat(),
        duel_shadow_scale_x = reader.ReadFloat(),
        duel_shadow_scale_z = reader.ReadFloat(),
        footstep_type_UnitFootstepType = reader.ReadInt(),
        camera_pattern_UnitCameraPattern = reader.ReadInt(),
        illust_pattern_UnitIllustPattern = reader.ReadInt(),
        cutin_pattern_id = reader.ReadIntOrNull(),
        voice_pattern_id = reader.ReadInt(),
        non_disp_weapon = reader.ReadBool(),
        rainbow_on = reader.ReadBool()
      };
    }

    public UnitUnitParameter parameter_data
    {
      get
      {
        UnitUnitParameter parameterData;
        if (!MasterData.UnitUnitParameter.TryGetValue(this.parameter_data_UnitUnitParameter, out parameterData))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnitParameter[" + (object) this.parameter_data_UnitUnitParameter + "]"));
        return parameterData;
      }
    }

    public UnitUnitDescription etc_data
    {
      get
      {
        UnitUnitDescription etcData;
        if (!MasterData.UnitUnitDescription.TryGetValue(this.etc_data_UnitUnitDescription, out etcData))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnitDescription[" + (object) this.etc_data_UnitUnitDescription + "]"));
        return etcData;
      }
    }

    public UnitCharacter character
    {
      get
      {
        UnitCharacter character;
        if (!MasterData.UnitCharacter.TryGetValue(this.character_UnitCharacter, out character))
          Debug.LogError((object) ("Key not Found: MasterData.UnitCharacter[" + (object) this.character_UnitCharacter + "]"));
        return character;
      }
    }

    public UnitUnit resource_reference_unit_id
    {
      get
      {
        UnitUnit resourceReferenceUnitId;
        if (!MasterData.UnitUnit.TryGetValue(this.resource_reference_unit_id_UnitUnit, out resourceReferenceUnitId))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.resource_reference_unit_id_UnitUnit + "]"));
        return resourceReferenceUnitId;
      }
    }

    public UnitRarity rarity
    {
      get
      {
        UnitRarity rarity;
        if (!MasterData.UnitRarity.TryGetValue(this.rarity_UnitRarity, out rarity))
          Debug.LogError((object) ("Key not Found: MasterData.UnitRarity[" + (object) this.rarity_UnitRarity + "]"));
        return rarity;
      }
    }

    public UnitJob job
    {
      get
      {
        UnitJob job;
        if (!MasterData.UnitJob.TryGetValue(this.job_UnitJob, out job))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job_UnitJob + "]"));
        return job;
      }
    }

    public GearKind kind
    {
      get
      {
        GearKind kind;
        if (!MasterData.GearKind.TryGetValue(this.kind_GearKind, out kind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.kind_GearKind + "]"));
        return kind;
      }
    }

    public GearGear initial_gear
    {
      get
      {
        GearGear initialGear;
        if (!MasterData.GearGear.TryGetValue(this.initial_gear_GearGear, out initialGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.initial_gear_GearGear + "]"));
        return initialGear;
      }
    }

    public CutinEffect cutin_effect_type => (CutinEffect) this.cutin_effect_type_CutinEffect;

    public UnitFootstepType footstep_type
    {
      get
      {
        UnitFootstepType footstepType;
        if (!MasterData.UnitFootstepType.TryGetValue(this.footstep_type_UnitFootstepType, out footstepType))
          Debug.LogError((object) ("Key not Found: MasterData.UnitFootstepType[" + (object) this.footstep_type_UnitFootstepType + "]"));
        return footstepType;
      }
    }

    public UnitCameraPattern camera_pattern
    {
      get
      {
        UnitCameraPattern cameraPattern;
        if (!MasterData.UnitCameraPattern.TryGetValue(this.camera_pattern_UnitCameraPattern, out cameraPattern))
          Debug.LogError((object) ("Key not Found: MasterData.UnitCameraPattern[" + (object) this.camera_pattern_UnitCameraPattern + "]"));
        return cameraPattern;
      }
    }

    public UnitIllustPattern illust_pattern
    {
      get
      {
        UnitIllustPattern illustPattern;
        if (!MasterData.UnitIllustPattern.TryGetValue(this.illust_pattern_UnitIllustPattern, out illustPattern))
          Debug.LogError((object) ("Key not Found: MasterData.UnitIllustPattern[" + (object) this.illust_pattern_UnitIllustPattern + "]"));
        return illustPattern;
      }
    }

    public bool IsNormalUnit
    {
      get
      {
        return (this.is_consume_only != 0 || this.is_evolution_only != 0 || this.skillup_type != 0 || this.is_breakthrough_only != 0 ? 1 : (this.is_buildup_only != 0 ? 1 : 0)) == 0;
      }
    }

    public bool IsMaterialUnit
    {
      get
      {
        return this.is_consume_only != 0 || this.is_evolution_only != 0 || this.skillup_type != 0 || this.is_breakthrough_only != 0 || this.is_buildup_only != 0;
      }
    }

    public bool IsTougouUnit
    {
      get
      {
        return this.is_consume_only != 0 || this.skillup_type != 0 || this.is_breakthrough_only != 0 || this.is_buildup_only != 0;
      }
    }

    public bool IsSinkaUnit => this.is_evolution_only == 1;

    public bool IsTenseiUnit => this.is_evolution_only == 2;

    public bool IsBreakThrough => this.is_breakthrough_only == 1;

    public bool IsBuildup => this.is_buildup_only == 1;

    public bool CheckBreakThroughMaterial(PlayerUnit baseUnit)
    {
      List<UnitBreakThrough> list = ((IEnumerable<UnitBreakThrough>) MasterData.UnitBreakThroughList).Where<UnitBreakThrough>((Func<UnitBreakThrough, bool>) (x => x.material_unit == this)).ToList<UnitBreakThrough>();
      return list.Count != 0 && (this.CheckBreakThroughInTargetUnit(list, baseUnit) || this.CheckBreakThroughRarityAndGear(list, baseUnit) || this.CheckBreakThroughAllFree(list));
    }

    public bool CheckBreakThroughInTargetUnit(List<UnitBreakThrough> list, PlayerUnit baseUnit)
    {
      return list.Any<UnitBreakThrough>((Func<UnitBreakThrough, bool>) (x => x.target_unit != null && x.target_unit == baseUnit.unit));
    }

    public bool CheckBreakThroughRarityAndGear(List<UnitBreakThrough> list, PlayerUnit baseUnit)
    {
      return list.Where<UnitBreakThrough>((Func<UnitBreakThrough, bool>) (x =>
      {
        if (x.rarity == null)
          return true;
        return x.rarity != null && x.rarity.ID == baseUnit.unit.rarity.ID;
      })).Any<UnitBreakThrough>((Func<UnitBreakThrough, bool>) (x =>
      {
        if (x.rarity != null && x.kind == null)
          return true;
        return x.kind != null && x.kind.Enum == baseUnit.unit.kind.Enum;
      }));
    }

    public bool CheckBreakThroughAllFree(List<UnitBreakThrough> list)
    {
      return list.Any<UnitBreakThrough>((Func<UnitBreakThrough, bool>) (x => x.target_unit == null && x.rarity == null && x.kind == null));
    }

    public bool IsMaterialUnitSkillUp => this.skillup_type != 0;

    public UnitTransmigrationPattern TransmigratePattern
    {
      get
      {
        return ((IEnumerable<UnitTransmigrationPattern>) MasterData.UnitTransmigrationPatternList).Where<UnitTransmigrationPattern>((Func<UnitTransmigrationPattern, bool>) (p => p.rarity_name.index == this.rarity.index)).First<UnitTransmigrationPattern>();
      }
    }

    public UnitUnit[] TransmigrateUnits
    {
      get
      {
        UnitTransmigrationPattern pattern = this.TransmigratePattern;
        return ((IEnumerable<UnitTransmigrationMaterial>) MasterData.UnitTransmigrationMaterialList).Where<UnitTransmigrationMaterial>((Func<UnitTransmigrationMaterial, bool>) (u => u.pattern_UnitTransmigrationPattern == pattern.ID)).Select<UnitTransmigrationMaterial, UnitUnit>((Func<UnitTransmigrationMaterial, UnitUnit>) (u => u.material)).ToArray<UnitUnit>();
      }
    }

    public UnitEvolutionPattern[] EvolutionPattern
    {
      get
      {
        return ((IEnumerable<UnitEvolutionPattern>) MasterData.UnitEvolutionPatternList).Where<UnitEvolutionPattern>((Func<UnitEvolutionPattern, bool>) (p => p.unit.ID == this.ID)).ToArray<UnitEvolutionPattern>();
      }
    }

    public Dictionary<int, UnitUnit[]> EvolutionUnits
    {
      get
      {
        Dictionary<int, UnitUnit[]> evolutionUnits = new Dictionary<int, UnitUnit[]>();
        foreach (UnitEvolutionPattern evolutionPattern in this.EvolutionPattern)
        {
          UnitEvolutionPattern pattern = evolutionPattern;
          UnitUnit[] array = ((IEnumerable<UnitEvolutionUnit>) MasterData.UnitEvolutionUnitList).Where<UnitEvolutionUnit>((Func<UnitEvolutionUnit, bool>) (u => u.evolution_pattern.ID == pattern.ID)).Select<UnitEvolutionUnit, UnitUnit>((Func<UnitEvolutionUnit, UnitUnit>) (u => u.unit)).ToArray<UnitUnit>();
          evolutionUnits.Add(pattern.ID, array);
        }
        return evolutionUnits;
      }
    }

    public UnitFamily[] Families
    {
      get
      {
        return ((IEnumerable<UnitUnitFamily>) MasterData.WhereUnitUnitFamilyBy(this)).Select<UnitUnitFamily, UnitFamily>((Func<UnitUnitFamily, UnitFamily>) (x => x.element)).ToArray<UnitFamily>();
      }
    }

    public bool HasFamily(UnitFamily family)
    {
      return ((IEnumerable<UnitFamily>) this.Families).Any<UnitFamily>((Func<UnitFamily, bool>) (x => x == family));
    }

    public BattleskillSkill RememberLeaderSkill
    {
      get
      {
        return ((IEnumerable<UnitLeaderSkill>) MasterData.UnitLeaderSkillList).Where<UnitLeaderSkill>((Func<UnitLeaderSkill, bool>) (x => x.unit.ID == this.ID)).Select<UnitLeaderSkill, BattleskillSkill>((Func<UnitLeaderSkill, BattleskillSkill>) (x => x.skill)).FirstOrDefault<BattleskillSkill>();
      }
    }

    public BattleskillSkill[] RememberSkills
    {
      get
      {
        return ((IEnumerable<UnitSkill>) MasterData.UnitSkillList).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.unit.ID == this.ID)).Select<UnitSkill, BattleskillSkill>((Func<UnitSkill, BattleskillSkill>) (x => x.skill)).ToArray<BattleskillSkill>();
      }
    }

    public UnitSkill[] RememberUnitSkills
    {
      get
      {
        return ((IEnumerable<UnitSkill>) MasterData.UnitSkillList).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.unit.ID == this.ID)).Select<UnitSkill, UnitSkill>((Func<UnitSkill, UnitSkill>) (x => x)).ToArray<UnitSkill>();
      }
    }

    public CommonElement GetElement()
    {
      CommonElement element = CommonElement.none;
      IEnumerable<BattleskillSkill> source = ((IEnumerable<UnitSkill>) this.RememberUnitSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.level <= 1)).Where<UnitSkill>((Func<UnitSkill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element)))).Select<UnitSkill, BattleskillSkill>((Func<UnitSkill, BattleskillSkill>) (x => x.skill));
      if (source.Count<BattleskillSkill>() > 0)
        element = source.First<BattleskillSkill>().element;
      return element;
    }

    public UnitBattleSkillOrigin[] MakeLeaderSkillOrigins()
    {
      UnitLeaderSkill origin = ((IEnumerable<UnitLeaderSkill>) MasterData.UnitLeaderSkillList).FirstOrDefault<UnitLeaderSkill>((Func<UnitLeaderSkill, bool>) (x => x.unit.ID == this.ID));
      List<UnitBattleSkillOrigin> source = new List<UnitBattleSkillOrigin>()
      {
        new UnitBattleSkillOrigin((object) origin, origin.skill)
      };
      UnitSkillCharacterQuest[] array = ((IEnumerable<UnitSkillCharacterQuest>) MasterData.UnitSkillCharacterQuestList).Where<UnitSkillCharacterQuest>((Func<UnitSkillCharacterQuest, bool>) (x => x.unit.ID == this.ID && x.skill.skill_type == BattleskillSkillType.leader)).ToArray<UnitSkillCharacterQuest>();
      foreach (UnitSkillCharacterQuest skillCharacterQuest in array)
      {
        UnitSkillCharacterQuest s = skillCharacterQuest;
        BattleskillSkill es = (BattleskillSkill) null;
        bool flag = MasterData.BattleskillSkill.TryGetValue(s.skill_after_evolution, out es);
        if (source.FirstOrDefault<UnitBattleSkillOrigin>((Func<UnitBattleSkillOrigin, bool>) (l => l.skill_ != null && l.skill_.ID == s.skill_BattleskillSkill)) != null && flag && !source.Any<UnitBattleSkillOrigin>((Func<UnitBattleSkillOrigin, bool>) (l => l.skill_.ID == es.ID)))
          source.Add(new UnitBattleSkillOrigin((object) s, es));
      }
      return source.ToArray();
    }

    public UnitBattleSkillOrigin[][] MakeSkillOrigins(bool includeMagic = true)
    {
      List<List<UnitBattleSkillOrigin>> list = ((IEnumerable<UnitSkill>) MasterData.UnitSkillList).Where<UnitSkill>((Func<UnitSkill, bool>) (x =>
      {
        if (x.unit.ID != this.ID)
          return false;
        return includeMagic || x.skill.skill_type != BattleskillSkillType.magic;
      })).Select<UnitSkill, List<UnitBattleSkillOrigin>>((Func<UnitSkill, List<UnitBattleSkillOrigin>>) (s => new List<UnitBattleSkillOrigin>()
      {
        new UnitBattleSkillOrigin((object) s, s.skill)
      })).ToList<List<UnitBattleSkillOrigin>>();
      UnitSkillCharacterQuest[] array1 = ((IEnumerable<UnitSkillCharacterQuest>) MasterData.UnitSkillCharacterQuestList).Where<UnitSkillCharacterQuest>((Func<UnitSkillCharacterQuest, bool>) (x => x.unit.ID == this.ID && (includeMagic || x.skill.skill_type != BattleskillSkillType.magic) && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<UnitSkillCharacterQuest>();
      foreach (UnitSkillCharacterQuest skillCharacterQuest in array1)
      {
        UnitSkillCharacterQuest s = skillCharacterQuest;
        BattleskillSkill skill1 = (BattleskillSkill) null;
        bool flag = MasterData.BattleskillSkill.TryGetValue(s.skill_after_evolution, out skill1);
        List<UnitBattleSkillOrigin> battleSkillOriginList = list.FirstOrDefault<List<UnitBattleSkillOrigin>>((Func<List<UnitBattleSkillOrigin>, bool>) (tl => tl.Any<UnitBattleSkillOrigin>((Func<UnitBattleSkillOrigin, bool>) (l => l.skill_ != null && l.skill_.ID == s.skill_BattleskillSkill))));
        if (battleSkillOriginList == null)
        {
          BattleskillSkill skill2 = (BattleskillSkill) null;
          if (MasterData.BattleskillSkill.TryGetValue(s.skill_BattleskillSkill, out skill2))
          {
            battleSkillOriginList = new List<UnitBattleSkillOrigin>()
            {
              new UnitBattleSkillOrigin((object) s, skill2)
            };
            list.Add(battleSkillOriginList);
          }
          else
            continue;
        }
        if (flag)
          battleSkillOriginList.Add(new UnitBattleSkillOrigin((object) s, skill1));
      }
      int cId = this.character.ID;
      UnitSkillHarmonyQuest[] array2 = ((IEnumerable<UnitSkillHarmonyQuest>) MasterData.UnitSkillHarmonyQuestList).Where<UnitSkillHarmonyQuest>((Func<UnitSkillHarmonyQuest, bool>) (x => x.character.ID == cId && (includeMagic || x.skill.skill_type != BattleskillSkillType.magic) && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<UnitSkillHarmonyQuest>();
      if (array2.Length > 0)
        list.AddRange((IEnumerable<List<UnitBattleSkillOrigin>>) ((IEnumerable<UnitSkillHarmonyQuest>) array2).Select<UnitSkillHarmonyQuest, List<UnitBattleSkillOrigin>>((Func<UnitSkillHarmonyQuest, List<UnitBattleSkillOrigin>>) (hs => new List<UnitBattleSkillOrigin>()
        {
          new UnitBattleSkillOrigin((object) hs, MasterData.BattleskillSkill[hs.skill_BattleskillSkill])
        })).ToList<List<UnitBattleSkillOrigin>>());
      Dictionary<int, UnitSkillEvolution> dictionary = ((IEnumerable<UnitSkillEvolution>) MasterData.UnitSkillEvolutionList).Where<UnitSkillEvolution>((Func<UnitSkillEvolution, bool>) (x => x.unit_UnitUnit == this.ID)).ToDictionary<UnitSkillEvolution, int>((Func<UnitSkillEvolution, int>) (d => d.before_skill_BattleskillSkill));
      foreach (KeyValuePair<int, UnitSkillEvolution> keyValuePair in dictionary)
      {
        KeyValuePair<int, UnitSkillEvolution> item = keyValuePair;
        foreach (List<UnitBattleSkillOrigin> battleSkillOriginList in list)
        {
          int index = battleSkillOriginList.FindIndex((Predicate<UnitBattleSkillOrigin>) (s => s.skill_.ID == item.Key));
          if (index >= 0)
          {
            if (battleSkillOriginList.Count - 1 == index)
            {
              battleSkillOriginList.Add(new UnitBattleSkillOrigin((object) item.Value, item.Value.after_skill));
              break;
            }
            if (battleSkillOriginList[index + 1].skill_.ID != item.Value.after_skill.ID)
            {
              Debug.LogError((object) string.Format("{0}({1})のスキル({2})の進化先が複数存在します", (object) this.name, (object) this.ID, (object) item.Key));
              break;
            }
            break;
          }
        }
      }
      return list.Select<List<UnitBattleSkillOrigin>, UnitBattleSkillOrigin[]>((Func<List<UnitBattleSkillOrigin>, UnitBattleSkillOrigin[]>) (lst => lst.ToArray())).ToArray<UnitBattleSkillOrigin[]>();
    }

    public string cv_name => this.etc_data.cv_name;

    public string description => this.etc_data.description;

    public string illustrator_name => this.etc_data.illustrator_name;

    public int breakthrough_limit => this.parameter_data.breakthrough_limit;

    public int _level_per_breakthrough => this.parameter_data._level_per_breakthrough;

    public int hp_max => this.parameter_data.hp_max;

    public int strength_max => this.parameter_data.strength_max;

    public int vitality_max => this.parameter_data.vitality_max;

    public int intelligence_max => this.parameter_data.intelligence_max;

    public int mind_max => this.parameter_data.mind_max;

    public int agility_max => this.parameter_data.agility_max;

    public int dexterity_max => this.parameter_data.dexterity_max;

    public int lucky_max => this.parameter_data.lucky_max;

    public int hp_initial => this.parameter_data.hp_initial;

    public int strength_initial => this.parameter_data.strength_initial;

    public int vitality_initial => this.parameter_data.vitality_initial;

    public int intelligence_initial => this.parameter_data.intelligence_initial;

    public int mind_initial => this.parameter_data.mind_initial;

    public int agility_initial => this.parameter_data.agility_initial;

    public int dexterity_initial => this.parameter_data.dexterity_initial;

    public int lucky_initial => this.parameter_data.lucky_initial;

    public int hp_compose => this.parameter_data.hp_compose;

    public int strength_compose => this.parameter_data.strength_compose;

    public int vitality_compose => this.parameter_data.vitality_compose;

    public int intelligence_compose => this.parameter_data.intelligence_compose;

    public int mind_compose => this.parameter_data.mind_compose;

    public int agility_compose => this.parameter_data.agility_compose;

    public int dexterity_compose => this.parameter_data.dexterity_compose;

    public int lucky_compose => this.parameter_data.lucky_compose;

    public int hp_buildup => this.parameter_data.hp_buildup;

    public int strength_buildup => this.parameter_data.strength_buildup;

    public int vitality_buildup => this.parameter_data.vitality_buildup;

    public int intelligence_buildup => this.parameter_data.intelligence_buildup;

    public int mind_buildup => this.parameter_data.mind_buildup;

    public int agility_buildup => this.parameter_data.agility_buildup;

    public int dexterity_buildup => this.parameter_data.dexterity_buildup;

    public int lucky_buildup => this.parameter_data.lucky_buildup;

    public int buildup_limit => this.parameter_data.buildup_limit;

    public UnitProficiency default_weapon_proficiency
    {
      get => this.parameter_data.default_weapon_proficiency;
    }

    public UnitProficiency default_shield_proficiency
    {
      get => this.parameter_data.default_shield_proficiency;
    }

    public bool isLeftHandInitialWeapon
    {
      get
      {
        return MasterData.UniqueUnitUnitGearModelKindBy(this, this.initial_gear.model_kind).is_left_hand_weapon == 1;
      }
    }

    public bool isDualWieldInitialWeapon
    {
      get
      {
        return MasterData.UniqueUnitUnitGearModelKindBy(this, this.initial_gear.model_kind).is_left_hand_weapon == 2;
      }
    }

    public BattleskillSkill PickupSkill
    {
      get
      {
        return ((IEnumerable<UnitPickupSkill>) MasterData.UnitPickupSkillList).FirstOrDefault<UnitPickupSkill>((Func<UnitPickupSkill, bool>) (x => x.unit.ID == this.ID))?.skill;
      }
    }

    public bool isComposeParameter
    {
      get
      {
        bool composeParameter = true;
        if (this.hp_compose == 0 && this.strength_compose == 0 && this.vitality_compose == 0 && this.intelligence_compose == 0 && this.mind_compose == 0 && this.agility_compose == 0 && this.dexterity_compose == 0)
          composeParameter = false;
        return composeParameter;
      }
    }

    public BattleUnitLandformFootstep GetFootstep(BattleLandform landform)
    {
      return ((IEnumerable<BattleUnitLandformFootstep>) MasterData.BattleUnitLandformFootstepList).Single<BattleUnitLandformFootstep>((Func<BattleUnitLandformFootstep, bool>) (x => x.unit_footstep_type.ID == this.footstep_type.ID && x.landform_footstep_type.ID == landform.footstep_type.ID));
    }

    public Future<Sprite> LoadCutin()
    {
      return this.cutin_pattern_id.HasValue ? ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Characters/{0}/battle_cutin_{1}", (object) this.character.ID, (object) this.cutin_pattern_id.Value)) : ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Characters/{0}/battle_cutin", (object) this.character.ID));
    }

    public Future<Sprite> LoadSpriteMedium()
    {
      return ResourceManager.Load<Sprite>(string.Format("Units/{0}/2D/c_400x400", (object) this.resource_reference_unit_id.ID));
    }

    public Future<Sprite> LoadSpriteLarge()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Units/{0}/2D/unit_large", (object) this.resource_reference_unit_id.ID));
    }

    private static string GetSpriteFacePath(int id, string name)
    {
      return string.Format("AssetBundle/Resources/Units/{0}/2D/Face/{1}", (object) id, (object) name);
    }

    public bool HasSpriteFace(string name)
    {
      return Singleton<ResourceManager>.GetInstance().Contains(UnitUnit.GetSpriteFacePath(this.resource_reference_unit_id.ID, name));
    }

    public Future<Sprite> LoadSpriteFace(string name)
    {
      return ResourceManager.Load<Sprite>(UnitUnit.GetSpriteFacePath(this.resource_reference_unit_id.ID, name));
    }

    private static string GetSpriteEyePath(int id, string name)
    {
      return string.Format("AssetBundle/Resources/Units/{0}/2D/Eye/{1}", (object) id, (object) name);
    }

    public bool HasSpriteEye(string name)
    {
      return Singleton<ResourceManager>.GetInstance().Contains(UnitUnit.GetSpriteEyePath(this.resource_reference_unit_id.ID, name));
    }

    public Future<Sprite> LoadSpriteEye(string name)
    {
      return ResourceManager.Load<Sprite>(UnitUnit.GetSpriteEyePath(this.resource_reference_unit_id.ID, name));
    }

    public Future<Sprite> LoadSpritePickup()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Units/{0}/2D/unit_pickup", (object) this.resource_reference_unit_id.ID));
    }

    public Future<Sprite> LoadSpriteThumbnail()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Units/{0}/2D/c_thum", (object) this.resource_reference_unit_id.ID));
    }

    public Future<Sprite> LoadSpriteBasic()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Units/{0}/2D/unit_large", (object) this.resource_reference_unit_id.ID));
    }

    public Future<GameObject> LoadModelDuel()
    {
      return ResourceManager.Load<GameObject>(string.Format("Units/{0}/3D/duel/prefab", (object) this.resource_reference_unit_id.ID));
    }

    public Future<GameObject> LoadModelField()
    {
      return ResourceManager.Load<GameObject>(string.Format("Units/{0}/3D/field/prefab", (object) this.resource_reference_unit_id.ID));
    }

    public Future<GameObject> LoadModelDuelVehicle()
    {
      return string.IsNullOrEmpty(this.vehicle_model_name) ? Future.Single<GameObject>((GameObject) null) : ResourceManager.Load<GameObject>(string.Format("UnitVehicle/{0}/3D/duel/prefab", (object) this.vehicle_model_name));
    }

    public Future<RuntimeAnimatorController> LoadAnimatorControllerDuelVehicle(
      GearModelKind modelKind)
    {
      return string.IsNullOrEmpty(this.vehicle_model_name) ? Future.Single<RuntimeAnimatorController>((RuntimeAnimatorController) null) : ResourceManager.LoadOrNull<RuntimeAnimatorController>(string.Format("UnitVehicle/{0}/3D/duel/controller/{1}", (object) this.vehicle_model_name, (object) modelKind.ID));
    }

    public Future<GameObject> LoadModelFieldVehicle()
    {
      return string.IsNullOrEmpty(this.vehicle_model_name) ? Future.Single<GameObject>((GameObject) null) : ResourceManager.Load<GameObject>(string.Format("UnitVehicle/{0}/3D/field/prefab", (object) this.vehicle_model_name));
    }

    public Future<GameObject> LoadModelDuelEquip()
    {
      return string.IsNullOrEmpty(this.equip_model_name) ? Future.Single<GameObject>((GameObject) null) : ResourceManager.Load<GameObject>(string.Format("UnitEquips/{0}/3D/duel/prefab", (object) this.equip_model_name));
    }

    public Future<GameObject> LoadModelFieldEquip()
    {
      return string.IsNullOrEmpty(this.equip_model_name) ? Future.Single<GameObject>((GameObject) null) : ResourceManager.Load<GameObject>(string.Format("UnitEquips/{0}/3D/field/prefab", (object) this.equip_model_name));
    }

    public Future<GameObject> LoadModelDuelEquipB()
    {
      return string.IsNullOrEmpty(this.equip_model_b_name) ? Future.Single<GameObject>((GameObject) null) : ResourceManager.Load<GameObject>(string.Format("UnitEquips_b/{0}/3D/duel/prefab", (object) this.equip_model_b_name));
    }

    public Future<GameObject> LoadModelFieldEquipB()
    {
      return string.IsNullOrEmpty(this.equip_model_b_name) ? Future.Single<GameObject>((GameObject) null) : ResourceManager.Load<GameObject>(string.Format("UnitEquips_b/{0}/3D/field/prefab", (object) this.equip_model_b_name));
    }

    public Future<Sprite> LoadFullSprite()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Units/{0}/2D/unit_full", (object) this.resource_reference_unit_id.ID));
    }

    public Future<Material> LoadFieldNormalFaceMaterial()
    {
      return string.IsNullOrEmpty(this.field_normal_face_material_name) ? Future.Single<Material>((Material) null) : ResourceManager.Load<Material>(string.Format("Units/Shared/{0}", (object) this.field_normal_face_material_name));
    }

    public Future<Material> LoadFieldGrayBodyMaterial()
    {
      return string.IsNullOrEmpty(this.field_gray_body_material_name) ? Future.Single<Material>((Material) null) : ResourceManager.Load<Material>(string.Format("Units/{0}/3D/field/{1}", (object) this.resource_reference_unit_id.ID, (object) this.field_gray_body_material_name));
    }

    public Future<Material> LoadFieldGrayFaceMaterial()
    {
      return string.IsNullOrEmpty(this.field_gray_face_material_name) ? Future.Single<Material>((Material) null) : ResourceManager.Load<Material>(string.Format("Units/Shared/{0}", (object) this.field_gray_face_material_name));
    }

    public Future<Material> LoadFieldGrayVehicleMaterial()
    {
      if (string.IsNullOrEmpty(this.vehicle_model_name))
        return Future.Single<Material>((Material) null);
      return string.IsNullOrEmpty(this.field_gray_vehicle_material_name) ? Future.Single<Material>((Material) null) : ResourceManager.Load<Material>(string.Format("UnitVehicle/{0}/3D/field/{1}", (object) this.vehicle_model_name, (object) this.field_gray_vehicle_material_name));
    }

    public Future<Material> LoadFieldGrayEquipMaterial()
    {
      if (string.IsNullOrEmpty(this.equip_model_name))
        return Future.Single<Material>((Material) null);
      return string.IsNullOrEmpty(this.field_gray_equip_material_name) ? Future.Single<Material>((Material) null) : ResourceManager.Load<Material>(string.Format("UnitEquips/{0}/3D/field/{1}", (object) this.equip_model_name, (object) this.field_gray_equip_material_name));
    }

    public Future<Material> LoadFieldGrayEquipBMaterial()
    {
      if (string.IsNullOrEmpty(this.equip_model_b_name))
        return Future.Single<Material>((Material) null);
      return string.IsNullOrEmpty(this.field_gray_equip_b_material_name) ? Future.Single<Material>((Material) null) : ResourceManager.Load<Material>(string.Format("UnitEquips_b/{0}/3D/field/{1}", (object) this.equip_model_b_name, (object) this.field_gray_equip_b_material_name));
    }

    [DebuggerHidden]
    public IEnumerator SetLargeSprite(GameObject go, int depth = 1000)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnitUnit.\u003CSetLargeSprite\u003Ec__Iterator38()
      {
        go = go,
        depth = depth,
        \u003C\u0024\u003Ego = go,
        \u003C\u0024\u003Edepth = depth,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator SetLargeSpriteSnap(GameObject go, int depth = 1000)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnitUnit.\u003CSetLargeSpriteSnap\u003Ec__Iterator39()
      {
        go = go,
        depth = depth,
        \u003C\u0024\u003Ego = go,
        \u003C\u0024\u003Edepth = depth,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator SetLargeSpriteWithMask(
      GameObject go,
      Future<Texture2D> maskFuture,
      int depth = 1000,
      int x = 0,
      int y = 0)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnitUnit.\u003CSetLargeSpriteWithMask\u003Ec__Iterator3A()
      {
        go = go,
        maskFuture = maskFuture,
        depth = depth,
        x = x,
        y = y,
        \u003C\u0024\u003Ego = go,
        \u003C\u0024\u003EmaskFuture = maskFuture,
        \u003C\u0024\u003Edepth = depth,
        \u003C\u0024\u003Ex = x,
        \u003C\u0024\u003Ey = y,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator SetMediumSpriteSnap(GameObject go, int depth = 1000)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnitUnit.\u003CSetMediumSpriteSnap\u003Ec__Iterator3B()
      {
        go = go,
        depth = depth,
        \u003C\u0024\u003Ego = go,
        \u003C\u0024\u003Edepth = depth,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator SetMediumSpriteWithMask(
      GameObject go,
      Future<Texture2D> maskFuture,
      int depth = 1000,
      int x = 0,
      int y = 0)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnitUnit.\u003CSetMediumSpriteWithMask\u003Ec__Iterator3C()
      {
        go = go,
        maskFuture = maskFuture,
        depth = depth,
        x = x,
        y = y,
        \u003C\u0024\u003Ego = go,
        \u003C\u0024\u003EmaskFuture = maskFuture,
        \u003C\u0024\u003Edepth = depth,
        \u003C\u0024\u003Ex = x,
        \u003C\u0024\u003Ey = y,
        \u003C\u003Ef__this = this
      };
    }

    private Future<GameObject> fullGameObject(float scale, int x, int y)
    {
      return ResourceManager.Load<GameObject>("Prefabs/UnitIcon/full").Then<GameObject>((Func<GameObject, GameObject>) (full =>
      {
        NGxMaskSpriteWithScale component = full.GetComponent<NGxMaskSpriteWithScale>();
        component.xOffsetPixel = x;
        component.yOffsetPixel = y;
        component.scale = scale;
        return full;
      }));
    }

    private Future<GameObject> fullGameObject()
    {
      return ResourceManager.Load<GameObject>("Prefabs/UnitIcon/full").Then<GameObject>((Func<GameObject, GameObject>) (full =>
      {
        UnitUnitStory unitUnitStory = (UnitUnitStory) null;
        float num1 = 1f;
        int num2 = 0;
        int num3 = 0;
        if (MasterData.UnitUnitStory.TryGetValue(this.resource_reference_unit_id_UnitUnit, out unitUnitStory))
        {
          num1 = unitUnitStory.story_texture_scale;
          num2 = unitUnitStory.story_texture_x;
          num3 = unitUnitStory.story_texture_y;
        }
        NGxMaskSpriteWithScale component = full.GetComponent<NGxMaskSpriteWithScale>();
        component.xOffsetPixel = num2;
        component.yOffsetPixel = num3;
        component.scale = num1;
        return full;
      }));
    }

    private Future<GameObject> fullWithFaceGameObject()
    {
      return ResourceManager.Load<GameObject>("Prefabs/UnitIcon/fullWithFace");
    }

    public void SetStoryData(GameObject go, string name = "normal")
    {
      UnitUnitStory unitUnitStory = (UnitUnitStory) null;
      float num1 = 1f;
      int num2 = 0;
      int num3 = 0;
      if (MasterData.UnitUnitStory.TryGetValue(this.resource_reference_unit_id_UnitUnit, out unitUnitStory))
      {
        num1 = unitUnitStory.story_texture_scale;
        num2 = unitUnitStory.story_texture_x;
        num3 = unitUnitStory.story_texture_y;
      }
      ((Object) go).name = "StoryUnitPrefab";
      NGxMaskSpriteWithScale component1 = go.GetComponent<NGxMaskSpriteWithScale>();
      component1.xOffsetPixel = num2;
      component1.yOffsetPixel = num3;
      component1.scale = num1;
      NGxFaceSprite component2 = go.GetComponent<NGxFaceSprite>();
      component2.UnitID = this.ID;
      component2.faceName = name;
      NGxEyeSprite component3 = go.GetComponent<NGxEyeSprite>();
      if (!Object.op_Inequality((Object) component3, (Object) null))
        return;
      ((Behaviour) component3).enabled = false;
      ((Component) component3.EyeUI2DSprite).gameObject.SetActive(false);
      component3.UnitID = this.ID;
      component3.EyeName = name;
    }

    public Future<GameObject> LoadStory() => this.fullWithFaceGameObject();

    public Future<GameObject> LoadQuest() => this.fullGameObject(0.7f, 74, -14);

    [DebuggerHidden]
    public IEnumerator LoadQuestWithMask(Transform parent, int depth, Future<Texture2D> maskFuture)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnitUnit.\u003CLoadQuestWithMask\u003Ec__Iterator3D()
      {
        parent = parent,
        maskFuture = maskFuture,
        depth = depth,
        \u003C\u0024\u003Eparent = parent,
        \u003C\u0024\u003EmaskFuture = maskFuture,
        \u003C\u0024\u003Edepth = depth,
        \u003C\u003Ef__this = this
      };
    }

    public Future<GameObject> LoadShopContent() => this.fullGameObject(0.5f, 66, 51);

    public Future<GameObject> LoadShopContentUnitOther() => this.fullGameObject(0.7f, 13, 23);

    [DebuggerHidden]
    public IEnumerator LoadShopContentWithMask(
      Transform parent,
      int depth,
      Future<Texture2D> maskFuture)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnitUnit.\u003CLoadShopContentWithMask\u003Ec__Iterator3E()
      {
        parent = parent,
        maskFuture = maskFuture,
        depth = depth,
        \u003C\u0024\u003Eparent = parent,
        \u003C\u0024\u003EmaskFuture = maskFuture,
        \u003C\u0024\u003Edepth = depth,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator LoadShopContentUnitOtherWithMask(
      Transform parent,
      int depth,
      Future<Texture2D> maskFuture)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnitUnit.\u003CLoadShopContentUnitOtherWithMask\u003Ec__Iterator3F()
      {
        parent = parent,
        maskFuture = maskFuture,
        depth = depth,
        \u003C\u0024\u003Eparent = parent,
        \u003C\u0024\u003EmaskFuture = maskFuture,
        \u003C\u0024\u003Edepth = depth,
        \u003C\u003Ef__this = this
      };
    }

    public Future<GameObject> LoadCompose() => this.fullGameObject(0.6f, 0, -130);

    public Future<GameObject> LoadLove() => this.fullGameObject(0.6f, -35, -91);

    public Future<GameObject> LoadMypage() => this.fullGameObject(1f, 0, 0);

    public Future<GameObject> LoadShop() => this.fullGameObject(0.8f, -72, 70);

    public Future<GameObject> LoadGacha() => this.fullGameObject(0.84f, 0, 0);

    public Future<GameObject> LoadColosseum() => this.fullGameObject();

    public Future<GameObject> LoadInitialEquippedGearModel()
    {
      return MasterData.GearGear[this.initial_gear.ID].LoadModel();
    }

    public string duelAnimatorControllerName
    {
      get
      {
        return MasterData.UniqueUnitUnitGearModelKindBy(this, this.initial_gear.model_kind)?.duel_animator_controller_name;
      }
    }

    public string DuelAnimatorPath
    {
      get
      {
        return string.IsNullOrEmpty(this.duelAnimatorControllerName) ? (string) null : string.Intern(string.Format(UnitUnit.duelAnimatorRootPath, (object) this.duelAnimatorControllerName));
      }
    }

    public Future<RuntimeAnimatorController> LoadInitialDuelAnimator()
    {
      return ResourceManager.Load<RuntimeAnimatorController>(string.Format(UnitUnit.duelAnimatorRootPath, (object) this.duelAnimatorControllerName));
    }

    private string winAnimatorControllerName
    {
      get
      {
        return MasterData.UniqueUnitUnitGearModelKindBy(this, this.initial_gear.model_kind)?.winning_animator_controller_name;
      }
    }

    public string WinAnimatorPath
    {
      get
      {
        return string.IsNullOrEmpty(this.winAnimatorControllerName) ? (string) null : string.Intern(string.Format(UnitUnit.winAnimatorRootPath, (object) this.winAnimatorControllerName));
      }
    }

    public Future<RuntimeAnimatorController> LoadInitialWinAnimator()
    {
      return ResourceManager.Load<RuntimeAnimatorController>(string.Format(UnitUnit.winAnimatorRootPath, (object) this.winAnimatorControllerName));
    }

    public UnitVoicePattern unitVoicePattern
    {
      get
      {
        return ((IEnumerable<UnitVoicePattern>) MasterData.UnitVoicePatternList).Where<UnitVoicePattern>((Func<UnitVoicePattern, bool>) (x => x.character_id == this.character.ID && x.voice_pattern == this.voice_pattern_id)).FirstOrDefault<UnitVoicePattern>();
      }
    }

    public bool IsEvolution
    {
      get
      {
        return ((IEnumerable<UnitEvolutionPattern>) ((IEnumerable<UnitEvolutionPattern>) MasterData.UnitEvolutionPatternList).Where<UnitEvolutionPattern>((Func<UnitEvolutionPattern, bool>) (p =>
        {
          if (p.unit.ID != this.ID)
            return false;
          DateTime? publishedAt = p.target_unit.published_at;
          return publishedAt.HasValue && publishedAt.Value < ServerTime.NowAppTime();
        })).ToArray<UnitEvolutionPattern>()).Count<UnitEvolutionPattern>() != 0;
      }
    }
  }
}
