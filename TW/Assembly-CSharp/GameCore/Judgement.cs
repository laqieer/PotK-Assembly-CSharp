// Decompiled with JetBrains decompiler
// Type: GameCore.Judgement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  public class Judgement
  {
    private const float MulBaseValue = 10000f;

    public static IEnumerable<BL.SkillEffect> GetEnabledBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.Unit unit,
      BattleskillInvokeGameModeEnum gameMode,
      bool isHp)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect = x.effect;
        return (effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == unit.job.ID) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == unit.unit.kind.ID) && effect.GetInt("target_family_id") == 0 && effect.GetInt("target_gear_kind_id") == 0 && effect.GetInt("is_attack") == 0 && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == unit.playerUnit.GetElement()) && effect.GetInt("target_element") == 0 && (isHp || !BattleFuncs.isSealedSkillEffect((BL.ISkillEffectListUnit) unit, x)) && effect.isEnableGameMode(gameMode);
      }));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      int attackType,
      BattleskillInvokeGameModeEnum gameMode,
      bool isHp)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect = x.effect;
        if (effect.GetInt("job_id") != 0 && effect.GetInt("job_id") != unit.originalUnit.job.ID || effect.GetInt("gear_kind_id") != 0 && effect.GetInt("gear_kind_id") != unit.originalUnit.unit.kind.ID || effect.GetInt("target_family_id") != 0 && !target.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id")) || effect.GetInt("target_gear_kind_id") != 0 && effect.GetInt("target_gear_kind_id") != target.originalUnit.unit.kind.ID || effect.GetInt("is_attack") != 0 && effect.GetInt("is_attack") != attackType || effect.GetInt("element") != 0 && (CommonElement) effect.GetInt("element") != unit.originalUnit.playerUnit.GetElement() || effect.GetInt("target_element") != 0 && (CommonElement) effect.GetInt("target_element") != target.originalUnit.playerUnit.GetElement() || !isHp && BattleFuncs.isSealedSkillEffect(unit, x) || !effect.isEnableGameMode(gameMode) || !isHp && BattleFuncs.isEffectEnemyRangeAndInvalid(x, unit, target))
          return false;
        return isHp || effect.skill.ID >= 900100000 && effect.skill.ID <= 900199999 || !BattleFuncs.isSkillsAndEffectsInvalid(unit, target);
      }));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.Unit unit,
      BL.Unit target,
      int attackType,
      BattleskillInvokeGameModeEnum gameMode,
      BattleskillSkillType skill_type,
      BattleskillTargetType target_type)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect = x.effect;
        return effect.skill.skill_type == skill_type && effect.skill.target_type == target_type && (effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == unit.job.ID) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == unit.unit.kind.ID) && (effect.GetInt("target_family_id") == 0 || target.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == target.unit.kind.ID) && (effect.GetInt("is_attack") == 0 || effect.GetInt("is_attack") == attackType) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == unit.playerUnit.GetElement()) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == target.playerUnit.GetElement()) && !BattleFuncs.isSealedSkillEffect((BL.ISkillEffectListUnit) unit, x) && effect.isEnableGameMode(gameMode);
      }));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledRangeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      int distance,
      bool isEnemy = false)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => Mathf.Abs(distance - effect.effect.GetInt("range")))).ThenByDescending<BL.SkillEffect, float>((Func<BL.SkillEffect, float>) (effect =>
      {
        if (effect.effect.HasKey("value"))
          return effect.effect.GetFloat("value");
        return effect.effect.HasKey("percentage") ? effect.effect.GetFloat("percentage") : 0.0f;
      })).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target))).ToList<BL.SkillEffect>()));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledHpLeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      float hpRatio)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, float>((Func<BL.SkillEffect, float>) (effect => effect.effect.GetFloat("border"))).ThenByDescending<BL.SkillEffect, float>((Func<BL.SkillEffect, float>) (effect =>
      {
        if (effect.effect.HasKey("value"))
          return effect.effect.GetFloat("value");
        return effect.effect.HasKey("percentage") ? effect.effect.GetFloat("percentage") : 0.0f;
      })).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && (double) hpRatio <= (double) effect.effect.GetFloat("border") && (effect.effect.GetInt("gear_kind_id") == 0 || effect.effect.GetInt("gear_kind_id") == unit.originalUnit.unit.kind.ID) && (effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == target.originalUnit.unit.kind.ID) && (effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == unit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == target.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("job_id") == 0 || effect.effect.GetInt("job_id") == unit.originalUnit.job.ID) && (effect.effect.GetInt("target_job_id") == 0 || effect.effect.GetInt("target_job_id") == target.originalUnit.job.ID) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target))).ToList<BL.SkillEffect>()));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledHpGeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      float hpRatio)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderByDescending<BL.SkillEffect, float>((Func<BL.SkillEffect, float>) (effect => effect.effect.GetFloat("border"))).ThenByDescending<BL.SkillEffect, float>((Func<BL.SkillEffect, float>) (effect =>
      {
        if (effect.effect.HasKey("value"))
          return effect.effect.GetFloat("value");
        return effect.effect.HasKey("percentage") ? effect.effect.GetFloat("percentage") : 0.0f;
      })).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && (double) hpRatio >= (double) effect.effect.GetFloat("border") && (effect.effect.GetInt("gear_kind_id") == 0 || effect.effect.GetInt("gear_kind_id") == unit.originalUnit.unit.kind.ID) && (effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == target.originalUnit.unit.kind.ID) && (effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == unit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == target.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("job_id") == 0 || effect.effect.GetInt("job_id") == unit.originalUnit.job.ID) && (effect.effect.GetInt("target_job_id") == 0 || effect.effect.GetInt("target_job_id") == target.originalUnit.job.ID) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target))).ToList<BL.SkillEffect>()));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledTargetCountBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      BL.ForceID[] targetForceId,
      BL.Panel panel,
      bool isAI)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect =>
      {
        if (!BattleFuncs.isSealedSkillEffect(unit, effect))
        {
          if (BattleFuncs.getTargets(panel.row, panel.column, new int[2]
          {
            effect.effect.GetInt("min_range"),
            effect.effect.GetInt("max_range")
          }, targetForceId, (isAI ? 1 : 0) != 0).Count<BL.UnitPosition>() >= 1 && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target))
            return !BattleFuncs.isSkillsAndEffectsInvalid(unit, target);
        }
        return false;
      }));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledCharismaBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit effectUnit,
      int distance,
      int effectTarget,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(effectUnit, effect) && distance >= effect.effect.GetInt("min_range") && distance <= effect.effect.GetInt("max_range") && (!effect.effect.HasKey("element") || effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == effectUnit.originalUnit.playerUnit.GetElement()) && (!effect.effect.HasKey("target_element") || effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == unit.originalUnit.playerUnit.GetElement()) && (!effect.effect.HasKey("target_gear_kind_id") || effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == unit.originalUnit.unit.kind.ID) && (!effect.effect.HasKey("target_family_id") || effect.effect.GetInt("target_family_id") == 0 || unit.originalUnit.unit.HasFamily((UnitFamily) effect.effect.GetInt("target_family_id"))) && effectTarget == effect.effect.GetInt("effect_target") && (effectUnit != target || !BattleFuncs.isSkillsAndEffectsInvalid(target, unit)) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target)));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledRaidMissionBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit effectUnit,
      int effectTarget,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(effectUnit, effect) && effectTarget == effect.effect.GetInt("effect_target") && (effectUnit != target || !BattleFuncs.isSkillsAndEffectsInvalid(target, unit)) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target)));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledExtremeOfForceBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => Mathf.Abs(effect.killCount - effect.effect.GetInt("kill_count")))).ThenByDescending<BL.SkillEffect, float>((Func<BL.SkillEffect, float>) (effect =>
      {
        if (effect.effect.HasKey("value"))
          return effect.effect.GetFloat("value");
        return effect.effect.HasKey("percentage") ? effect.effect.GetFloat("percentage") : 0.0f;
      })).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target))).ToList<BL.SkillEffect>()));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledOnemanChargeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      Dictionary<BL.ISkillEffectListUnit, int>[] unitDistance)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => effect.effectId)).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect =>
      {
        if (BattleFuncs.isSealedSkillEffect(unit, effect))
          return false;
        int num1 = effect.effect.GetInt("search_target");
        int num2 = effect.effect.GetInt("max_unit_count");
        int num3 = effect.effect.GetInt("min_range");
        int num4 = effect.effect.GetInt("max_range");
        int num5 = 0;
        for (int index = 0; index < 2; ++index)
        {
          if (index == num1 || num1 == 2)
          {
            foreach (BL.ISkillEffectListUnit key in unitDistance[index].Keys)
            {
              if (key != unit)
              {
                int num6 = unitDistance[index][key];
                if (num6 >= num3 && num6 <= num4 && ++num5 > num2)
                  return false;
              }
            }
          }
        }
        return num5 >= effect.effect.GetInt("min_unit_count") && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target);
      })).ToList<BL.SkillEffect>()));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledInOutSideBattleBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && (effect.effect.GetInt("gear_kind_id") == 0 || effect.effect.GetInt("gear_kind_id") == unit.originalUnit.unit.kind.ID) && (effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == target.originalUnit.unit.kind.ID) && (effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == unit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == target.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("job_id") == 0 || effect.effect.GetInt("job_id") == unit.originalUnit.job.ID) && (effect.effect.GetInt("target_job_id") == 0 || effect.effect.GetInt("target_job_id") == target.originalUnit.job.ID) && (effect.effect.GetInt("family_id") == 0 || unit.originalUnit.unit.HasFamily((UnitFamily) effect.effect.GetInt("family_id"))) && (effect.effect.GetInt("target_family_id") == 0 || target.originalUnit.unit.HasFamily((UnitFamily) effect.effect.GetInt("target_family_id"))) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target)));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledEvenIllusionBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect =>
      {
        int absoluteTurnCount = BattleFuncs.getPhaseState().absoluteTurnCount;
        int num1 = effect.effect.GetInt("start_turn");
        int num2 = effect.effect.GetInt("turn_cycle");
        if (num2 == 0)
          num2 = 1;
        return !BattleFuncs.isSealedSkillEffect(unit, effect) && absoluteTurnCount >= num1 && (absoluteTurnCount - num1) % num2 == 0 && (effect.effect.GetInt("gear_kind_id") == 0 || effect.effect.GetInt("gear_kind_id") == unit.originalUnit.unit.kind.ID) && (effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == target.originalUnit.unit.kind.ID) && (effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == unit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == target.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("job_id") == 0 || effect.effect.GetInt("job_id") == unit.originalUnit.job.ID) && (effect.effect.GetInt("target_job_id") == 0 || effect.effect.GetInt("target_job_id") == target.originalUnit.job.ID) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target);
      }));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledSpecificUnitBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && (effect.effect.GetInt("unit_id") == 0 || effect.effect.GetInt("unit_id") == unit.originalUnit.unit.ID) && (effect.effect.GetInt("target_unit_id") == 0 || effect.effect.GetInt("target_unit_id") == target.originalUnit.unit.ID) && (effect.effect.GetInt("character_id") == 0 || effect.effect.GetInt("character_id") == unit.originalUnit.unit.character.ID) && (effect.effect.GetInt("target_character_id") == 0 || effect.effect.GetInt("target_character_id") == target.originalUnit.unit.character.ID) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target)));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledUnitRarityBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => effect.effectId)).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && (effect.effect.GetInt("min_rarity") == 0 || effect.effect.GetInt("min_rarity") <= unit.originalUnit.unit.rarity.index + 1) && (effect.effect.GetInt("target_min_rarity") == 0 || effect.effect.GetInt("target_min_rarity") <= target.originalUnit.unit.rarity.index + 1) && (effect.effect.GetInt("max_rarity") == 0 || effect.effect.GetInt("max_rarity") >= unit.originalUnit.unit.rarity.index + 1) && (effect.effect.GetInt("target_max_rarity") == 0 || effect.effect.GetInt("target_max_rarity") >= target.originalUnit.unit.rarity.index + 1) && (effect.effect.GetInt("gear_kind_id") == 0 || effect.effect.GetInt("gear_kind_id") == unit.originalUnit.unit.kind.ID) && (effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == target.originalUnit.unit.kind.ID) && (effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == unit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == target.originalUnit.playerUnit.GetElement()) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target))).ToList<BL.SkillEffect>()));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledEquipGearBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect =>
      {
        if (BattleFuncs.isSealedSkillEffect(unit, effect) || effect.effect.GetInt("equip_gear_king_id") != 0 && effect.effect.GetInt("equip_gear_king_id") != unit.originalUnit.playerUnit.equippedGearOrInitial.kind_GearKind || effect.effect.GetInt("equip_gear_model_king_id") != 0 && effect.effect.GetInt("equip_gear_model_king_id") != unit.originalUnit.playerUnit.equippedGearOrInitial.model_kind_GearModelKind)
          return false;
        return effect.unit == null || effect.effect.skill.skill_type != BattleskillSkillType.leader;
      }));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledEquipGearBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && (effect.effect.GetInt("equip_gear_king_id") == 0 || effect.effect.GetInt("equip_gear_king_id") == unit.originalUnit.playerUnit.equippedGearOrInitial.kind_GearKind) && (effect.effect.GetInt("equip_gear_model_king_id") == 0 || effect.effect.GetInt("equip_gear_model_king_id") == unit.originalUnit.playerUnit.equippedGearOrInitial.model_kind_GearModelKind) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target)));
    }

    public static IEnumerable<BL.SkillEffect> GetEnabledDeadCountBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      int turnCount,
      IEnumerable<BL.Unit> unitDeckUnits,
      IEnumerable<BL.Unit> targetDeckUnits,
      BattleskillInvokeGameModeEnum gameMode,
      bool isAI)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect =>
      {
        int num1 = effect.effect.GetInt("turn_range");
        int unitId = !effect.effect.HasKey("unit_id") ? 0 : effect.effect.GetInt("unit_id");
        int borderTurn = turnCount - (num1 - 1);
        int num2 = 0;
        if (unitDeckUnits != null)
        {
          IEnumerable<BL.Unit> source = unitDeckUnits.Where<BL.Unit>((Func<BL.Unit, bool>) (y => unitId == 0 || unitId == y.unit.ID));
          if (num1 == 0)
            num2 += source.Sum<BL.Unit>((Func<BL.Unit, int>) (u => u.deadCount));
          else
            num2 += source.Sum<BL.Unit>((Func<BL.Unit, int>) (u => u.deadTurn.Count<int>((Func<int, bool>) (t => t >= borderTurn))));
          if (isAI)
            num2 += source.Count<BL.Unit>((Func<BL.Unit, bool>) (u => BattleFuncs.getAIDeads().value.Any<BL.AIUnit>((Func<BL.AIUnit, bool>) (y => y.unit == u))));
        }
        if (targetDeckUnits != null)
        {
          IEnumerable<BL.Unit> source = targetDeckUnits.Where<BL.Unit>((Func<BL.Unit, bool>) (y => unitId == 0 || unitId == y.unit.ID));
          if (num1 == 0)
            num2 += source.Sum<BL.Unit>((Func<BL.Unit, int>) (u => u.deadCount));
          else
            num2 += source.Sum<BL.Unit>((Func<BL.Unit, int>) (u => u.deadTurn.Count<int>((Func<int, bool>) (t => t >= borderTurn))));
          if (isAI)
            num2 += source.Count<BL.Unit>((Func<BL.Unit, bool>) (u => BattleFuncs.getAIDeads().value.Any<BL.AIUnit>((Func<BL.AIUnit, bool>) (y => y.unit == u))));
        }
        return Mathf.Abs(num2 - effect.effect.GetInt("dead_count"));
      })).ThenBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => effect.effectId)).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(unit, effect) && (effect.effect.GetInt("gear_kind_id") == 0 || effect.effect.GetInt("gear_kind_id") == unit.originalUnit.unit.kind.ID) && (effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == target.originalUnit.unit.kind.ID) && (effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == unit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == target.originalUnit.playerUnit.GetElement()) && (!effect.effect.HasKey("target_job_id") || effect.effect.GetInt("target_job_id") == 0 || effect.effect.GetInt("target_job_id") == target.originalUnit.job.ID) && effect.effect.isEnableGameMode(gameMode) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target))).ToList<BL.SkillEffect>()));
    }

    public static int GetFixEffectParamValue(
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      BattleskillEffectLogicEnum logic)
    {
      int effectParamValue = 0;
      IEnumerable<Tuple<BL.SkillEffect, int>> fixEffectParams = unit.skillEffects.GetFixEffectParams(logic);
      if (fixEffectParams.Any<Tuple<BL.SkillEffect, int>>() && BattleFuncs.isSkillsAndEffectsInvalid(unit, target))
        return effectParamValue;
      foreach (Tuple<BL.SkillEffect, int> tuple in fixEffectParams)
      {
        if (!BattleFuncs.isSealedSkillEffect(unit, tuple.Item1) && !BattleFuncs.isEffectEnemyRangeAndInvalid(tuple.Item1, unit, target))
          effectParamValue += tuple.Item2;
      }
      return effectParamValue;
    }

    public static float GetRatioEffectParamValue(
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      BattleskillEffectLogicEnum logic)
    {
      float effectParamValue = 1f;
      IEnumerable<Tuple<BL.SkillEffect, float>> ratioEffectParams = unit.skillEffects.GetRatioEffectParams(logic);
      if (ratioEffectParams.Any<Tuple<BL.SkillEffect, float>>() && BattleFuncs.isSkillsAndEffectsInvalid(unit, target))
        return effectParamValue;
      foreach (Tuple<BL.SkillEffect, float> tuple in ratioEffectParams)
      {
        if (!BattleFuncs.isSealedSkillEffect(unit, tuple.Item1) && !BattleFuncs.isEffectEnemyRangeAndInvalid(tuple.Item1, unit, target))
          effectParamValue *= tuple.Item2;
      }
      return effectParamValue;
    }

    [Serializable]
    public class GearParameter
    {
      public int Power;
      public int PhysicalDefense;
      public int MagicDefense;
      public int Hit;
      public int Critical;
      public int Evasion;
      public int Hp;
      public int Strength;
      public int Vitality;
      public int Intelligence;
      public int Mind;
      public int Agility;
      public int Dexterity;
      public int Luck;

      public static Judgement.GearParameter FromPlayerGear(ItemInfo item)
      {
        return Judgement.GearParameter.FromPlayerGear(((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).FirstOrDefault<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == item.itemID)));
      }

      public static Judgement.GearParameter FromPlayerGear(PlayerItem pi)
      {
        return new Judgement.GearParameter()
        {
          Power = pi.power,
          PhysicalDefense = pi.physical_defense,
          MagicDefense = pi.magic_defense,
          Hit = pi.hit,
          Critical = pi.critical,
          Evasion = pi.evasion,
          Hp = pi.hp_incremental,
          Strength = pi.strength_incremental,
          Vitality = pi.vitality_incremental,
          Intelligence = pi.intelligence_incremental,
          Mind = pi.mind_incremental,
          Agility = pi.agility_incremental,
          Dexterity = pi.dexterity_incremental,
          Luck = pi.lucky_incremental
        };
      }

      public static Judgement.GearParameter FromGearGear(GearGear gear)
      {
        return new Judgement.GearParameter()
        {
          Power = gear.power,
          PhysicalDefense = gear.physical_defense,
          MagicDefense = gear.magic_defense,
          Hit = gear.hit,
          Critical = gear.critical,
          Evasion = gear.evasion,
          Hp = gear.hp_incremental,
          Strength = gear.strength_incremental,
          Vitality = gear.vitality_incremental,
          Intelligence = gear.intelligence_incremental,
          Mind = gear.mind_incremental,
          Agility = gear.agility_incremental,
          Dexterity = gear.dexterity_incremental,
          Luck = gear.lucky_incremental
        };
      }
    }

    [Serializable]
    public class NonBattleParameter
    {
      public int Hp;
      public int Strength;
      public int Intelligence;
      public int Vitality;
      public int Mind;
      public int Agility;
      public int Dexterity;
      public int Luck;
      public int Move;
      public int PhysicalAttack;
      public int PhysicalDefense;
      public int MagicAttack;
      public int MagicDefense;
      public int Hit;
      public int Critical;
      public int Evasion;
      public int Combat;

      public static Judgement.NonBattleParameter FromPlayerUnitWithPlayerGear(
        PlayerUnit playerUnit,
        PlayerItem playerGear)
      {
        Judgement.GearParameter gearParameter = Judgement.GearParameter.FromPlayerGear(playerGear);
        return Judgement.NonBattleParameter.FromPlayerUnitWithGearParameter(playerUnit, gearParameter, playerGear.gear.attack_type, playerUnit.GetProficiencyIncr(playerGear.gear.kind));
      }

      public static Judgement.NonBattleParameter FromPlayerUnitWithGearParameter(
        PlayerUnit playerUnit,
        Judgement.GearParameter gearParameter,
        GearAttackType atkType,
        UnitProficiencyIncr proficiency)
      {
        Judgement.NonBattleParameter nonBattleParameter = new Judgement.NonBattleParameter();
        nonBattleParameter.Hp = playerUnit.total_hp + gearParameter.Hp;
        nonBattleParameter.Strength = playerUnit.total_strength + gearParameter.Strength;
        nonBattleParameter.Intelligence = playerUnit.total_intelligence + gearParameter.Intelligence;
        nonBattleParameter.Vitality = playerUnit.total_vitality + gearParameter.Vitality;
        nonBattleParameter.Mind = playerUnit.total_mind + gearParameter.Mind;
        nonBattleParameter.Agility = playerUnit.total_agility + gearParameter.Agility;
        nonBattleParameter.Dexterity = playerUnit.total_dexterity + gearParameter.Dexterity;
        nonBattleParameter.Luck = playerUnit.total_lucky + gearParameter.Luck;
        nonBattleParameter.Move = playerUnit.move;
        int num1 = 0;
        int num2 = 0;
        if (atkType == GearAttackType.magic)
          num2 = gearParameter.Power;
        else
          num1 = gearParameter.Power;
        nonBattleParameter.PhysicalAttack = nonBattleParameter.Strength + num1 + proficiency.physical_attack;
        nonBattleParameter.PhysicalDefense = nonBattleParameter.Vitality + gearParameter.PhysicalDefense;
        nonBattleParameter.MagicAttack = nonBattleParameter.Intelligence + playerUnit.MinMagicBulletPower + num2 + proficiency.magic_attack;
        nonBattleParameter.MagicDefense = nonBattleParameter.Mind + gearParameter.MagicDefense;
        nonBattleParameter.Hit = (nonBattleParameter.Dexterity * 3 + nonBattleParameter.Luck) / 2 + gearParameter.Hit + proficiency.hit;
        nonBattleParameter.Critical = nonBattleParameter.Dexterity / 2 + gearParameter.Critical;
        nonBattleParameter.Evasion = (nonBattleParameter.Agility * 3 + nonBattleParameter.Luck) / 2 + gearParameter.Evasion + proficiency.evasion;
        nonBattleParameter.Combat = nonBattleParameter.PhysicalAttack + nonBattleParameter.PhysicalDefense + nonBattleParameter.MagicAttack + nonBattleParameter.MagicDefense + (nonBattleParameter.Hit + nonBattleParameter.Critical + nonBattleParameter.Evasion) / 2 + nonBattleParameter.Hp;
        return nonBattleParameter;
      }

      public static Judgement.NonBattleParameter FromPlayerUnitWithGearParameter(
        PlayerUnit playerUnit,
        Judgement.GearParameter gearParameter)
      {
        return Judgement.NonBattleParameter.FromPlayerUnitWithGearParameter(playerUnit, gearParameter, playerUnit.equippedGearOrInitial.attack_type, playerUnit.ProficiencyIncr);
      }

      public static Judgement.NonBattleParameter FromPlayerUnit(PlayerUnit playerUnit)
      {
        Judgement.GearParameter gearParameter = !(playerUnit.equippedGear == (PlayerItem) null) ? Judgement.GearParameter.FromPlayerGear(playerUnit.equippedGear) : Judgement.GearParameter.FromGearGear(playerUnit.equippedGearOrInitial);
        return Judgement.NonBattleParameter.FromPlayerUnitWithGearParameter(playerUnit, gearParameter);
      }

      public static Judgement.NonBattleParameter FromPlayerFriendWithGearParameter(
        PlayerFriend playerFriend,
        Judgement.GearParameter gearParameter)
      {
        PlayerUnit leaderUnit = playerFriend.leader_unit;
        UnitProficiencyIncr proficiencyIncr = leaderUnit.ProficiencyIncr;
        Judgement.NonBattleParameter nonBattleParameter = new Judgement.NonBattleParameter();
        nonBattleParameter.Hp = leaderUnit.total_hp + gearParameter.Hp;
        nonBattleParameter.Strength = leaderUnit.total_strength + gearParameter.Strength;
        nonBattleParameter.Intelligence = leaderUnit.total_intelligence + gearParameter.Intelligence;
        nonBattleParameter.Vitality = leaderUnit.total_vitality + gearParameter.Vitality;
        nonBattleParameter.Mind = leaderUnit.total_mind + gearParameter.Mind;
        nonBattleParameter.Agility = leaderUnit.total_agility + gearParameter.Agility;
        nonBattleParameter.Dexterity = leaderUnit.total_dexterity + gearParameter.Dexterity;
        nonBattleParameter.Luck = leaderUnit.total_lucky + gearParameter.Luck;
        nonBattleParameter.Move = leaderUnit.move;
        int num1 = 0;
        int num2 = 0;
        GearGear initialGear;
        if (playerFriend.gear_ids.Length > 0)
          initialGear = MasterData.GearGear[playerFriend.gear_ids[0].Value];
        else
          initialGear = leaderUnit.unit.initial_gear;
        if (initialGear.attack_type == GearAttackType.magic)
          num2 = gearParameter.Power;
        else
          num1 = gearParameter.Power;
        nonBattleParameter.PhysicalAttack = nonBattleParameter.Strength + num1 + proficiencyIncr.physical_attack;
        nonBattleParameter.PhysicalDefense = nonBattleParameter.Vitality + gearParameter.PhysicalDefense;
        nonBattleParameter.MagicAttack = nonBattleParameter.Intelligence + leaderUnit.MinMagicBulletPower + num2 + proficiencyIncr.magic_attack;
        nonBattleParameter.MagicDefense = nonBattleParameter.Mind + gearParameter.MagicDefense;
        nonBattleParameter.Hit = (nonBattleParameter.Dexterity * 3 + nonBattleParameter.Luck) / 2 + gearParameter.Hit + proficiencyIncr.hit;
        nonBattleParameter.Critical = nonBattleParameter.Dexterity / 2 + gearParameter.Critical;
        nonBattleParameter.Evasion = (nonBattleParameter.Agility * 3 + nonBattleParameter.Luck) / 2 + gearParameter.Evasion + proficiencyIncr.evasion;
        nonBattleParameter.Combat = nonBattleParameter.PhysicalAttack + nonBattleParameter.PhysicalDefense + nonBattleParameter.MagicAttack + nonBattleParameter.MagicDefense + (nonBattleParameter.Hit + nonBattleParameter.Critical + nonBattleParameter.Evasion) / 2 + nonBattleParameter.Hp;
        return nonBattleParameter;
      }

      public static Judgement.NonBattleParameter FromPlayerFriend(PlayerFriend playerFriend)
      {
        GearGear initialGear;
        if (playerFriend.gear_ids.Length > 0)
          initialGear = MasterData.GearGear[playerFriend.gear_ids[0].Value];
        else
          initialGear = playerFriend.leader_unit.unit.initial_gear;
        Judgement.GearParameter gearParameter = Judgement.GearParameter.FromGearGear(initialGear);
        return Judgement.NonBattleParameter.FromPlayerFriendWithGearParameter(playerFriend, gearParameter);
      }
    }

    [Serializable]
    public class BattleParameter
    {
      public int Hp;
      public int Strength;
      public int Intelligence;
      public int Vitality;
      public int Mind;
      public int Agility;
      public int Dexterity;
      public int Luck;
      public int Move;
      public int HpIncr;
      public int StrengthIncr;
      public int IntelligenceIncr;
      public int VitalityIncr;
      public int MindIncr;
      public int AgilityIncr;
      public int DexterityIncr;
      public int LuckIncr;
      public int MoveIncr;
      public int PhysicalAttack;
      public int PhysicalDefense;
      public int MagicAttack;
      public int MagicDefense;
      public int Hit;
      public int Critical;
      public int Evasion;
      public int Combat;
      public int PhysicalAttackIncr;
      public int PhysicalDefenseIncr;
      public int MagicAttackIncr;
      public int MagicDefenseIncr;
      public int HitIncr;
      public int CriticalIncr;
      public int EvasionIncr;
      public int CombatIncr;

      private static int GetSkillAdd(
        BL.Unit beUnit,
        BattleskillEffectLogicEnum fix_logic,
        BattleskillInvokeGameModeEnum gameMode,
        bool isHp = false)
      {
        int skillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, gameMode, isHp))
          skillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return skillAdd;
      }

      private static float GetSkillMul(
        BL.Unit beUnit,
        BattleskillEffectLogicEnum ratio_logic,
        BattleskillInvokeGameModeEnum gameMode,
        bool isHp = false)
      {
        float skillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, gameMode, isHp))
          skillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return skillMul;
      }

      private static int GetEquipGearSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BattleskillEffectLogicEnum fix_logic)
      {
        int equipGearSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledEquipGearBuffDebuff(beUnit.skillEffects, fix_logic, beUnit))
          equipGearSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return equipGearSkillAdd;
      }

      private static float GetEquipGearSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BattleskillEffectLogicEnum ratio_logic)
      {
        float equipGearSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledEquipGearBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit))
          equipGearSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return equipGearSkillMul;
      }

      public static Judgement.BattleParameter FromBeUnit(BL.Unit beUnit)
      {
        int skillAdd = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_hp, BattleskillInvokeGameModeEnum.quest, true);
        int num1 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_strength, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_strength_fix);
        int num2 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_intelligence, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_intelligence_fix);
        int num3 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_vitality, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_vitality_fix);
        int num4 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_mind, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_mind_fix);
        int num5 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_agility, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_agility_fix);
        int num6 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_dexterity, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_dexterity_fix);
        int num7 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_luck, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_luck_fix);
        int num8 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_move, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_move_fix);
        int num9 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_physical_attack, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_physical_attack_fix);
        int num10 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_physical_defense, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_physical_defense_fix);
        int num11 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_magic_attack, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_magic_attack_fix);
        int num12 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_magic_defense, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_magic_defense_fix);
        int num13 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_hit, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_hit_fix);
        int num14 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_critical, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_critical_fix);
        int num15 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_evasion, BattleskillInvokeGameModeEnum.quest) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_evasion_fix);
        float num16 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_hp, BattleskillInvokeGameModeEnum.quest, true);
        float num17 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_strength, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_strength_ratio);
        float num18 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_intelligence, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_intelligence_ratio);
        float num19 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_vitality, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_vitality_ratio);
        float num20 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_mind, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_mind_ratio);
        float num21 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_agility, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_agility_ratio);
        float num22 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_dexterity, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_dexterity_ratio);
        float num23 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_luck, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_luck_ratio);
        float num24 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_move, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_move_ratio);
        float num25 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_physical_attack, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_physical_attack_ratio);
        float num26 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_physical_defense, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_physical_defense_ratio);
        float num27 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_magic_attack, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_magic_attack_ratio);
        float num28 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_magic_defense, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_magic_defense_ratio);
        float num29 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_hit, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_hit_ratio);
        float num30 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_critical, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_critical_ratio);
        float num31 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_evasion, BattleskillInvokeGameModeEnum.quest) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_evasion_ratio);
        PlayerUnit playerUnit = beUnit.playerUnit;
        Judgement.GearParameter gearParameter = !(playerUnit.equippedGear == (PlayerItem) null) ? Judgement.GearParameter.FromPlayerGear(playerUnit.equippedGear) : Judgement.GearParameter.FromGearGear(playerUnit.equippedGearOrInitial);
        UnitProficiencyIncr proficiencyIncr = playerUnit.ProficiencyIncr;
        Judgement.BattleParameter battleParameter = new Judgement.BattleParameter();
        battleParameter.Hp = (int) ((double) playerUnit.total_hp * (double) num16 / 10000.0 + (double) gearParameter.Hp + (double) skillAdd);
        battleParameter.Strength = (int) ((double) playerUnit.total_strength * (double) num17 / 10000.0 + (double) gearParameter.Strength + (double) num1);
        battleParameter.Intelligence = (int) ((double) playerUnit.total_intelligence * (double) num18 / 10000.0 + (double) gearParameter.Intelligence + (double) num2);
        battleParameter.Vitality = (int) ((double) playerUnit.total_vitality * (double) num19 / 10000.0 + (double) gearParameter.Vitality + (double) num3);
        battleParameter.Mind = (int) ((double) playerUnit.total_mind * (double) num20 / 10000.0 + (double) gearParameter.Mind + (double) num4);
        battleParameter.Agility = (int) ((double) playerUnit.total_agility * (double) num21 / 10000.0 + (double) gearParameter.Agility + (double) num5);
        battleParameter.Dexterity = (int) ((double) playerUnit.total_dexterity * (double) num22 / 10000.0 + (double) gearParameter.Dexterity + (double) num6);
        battleParameter.Luck = (int) ((double) playerUnit.total_lucky * (double) num23 / 10000.0 + (double) gearParameter.Luck + (double) num7);
        battleParameter.Move = (int) ((double) playerUnit.move * (double) num24 / 10000.0 + (double) num8);
        Judgement.NonBattleParameter nonBattleParameter = Judgement.NonBattleParameter.FromPlayerUnit(playerUnit);
        battleParameter.HpIncr = battleParameter.Hp - nonBattleParameter.Hp;
        battleParameter.StrengthIncr = battleParameter.Strength - nonBattleParameter.Strength;
        battleParameter.IntelligenceIncr = battleParameter.Intelligence - nonBattleParameter.Intelligence;
        battleParameter.VitalityIncr = battleParameter.Vitality - nonBattleParameter.Vitality;
        battleParameter.MindIncr = battleParameter.Mind - nonBattleParameter.Mind;
        battleParameter.AgilityIncr = battleParameter.Agility - nonBattleParameter.Agility;
        battleParameter.DexterityIncr = battleParameter.Dexterity - nonBattleParameter.Dexterity;
        battleParameter.LuckIncr = battleParameter.Luck - nonBattleParameter.Luck;
        battleParameter.MoveIncr = battleParameter.Move - nonBattleParameter.Move;
        bool flag = ((IEnumerable<BL.MagicBullet>) beUnit.magicBullets).Any<BL.MagicBullet>();
        int power1 = !flag ? gearParameter.Power : 0;
        int power2 = !flag ? 0 : gearParameter.Power;
        battleParameter.PhysicalAttack = (int) ((double) (battleParameter.Strength + power1 + proficiencyIncr.physical_attack) * (double) num25 / 10000.0 + (double) num9);
        battleParameter.PhysicalDefense = (int) ((double) (battleParameter.Vitality + gearParameter.PhysicalDefense) * (double) num26 / 10000.0 + (double) num10);
        battleParameter.MagicAttack = (int) ((double) (battleParameter.Intelligence + playerUnit.MinMagicBulletPower + power2 + proficiencyIncr.magic_attack) * (double) num27 / 10000.0 + (double) num11);
        battleParameter.MagicDefense = (int) ((double) (battleParameter.Mind + gearParameter.MagicDefense) * (double) num28 / 10000.0 + (double) num12);
        battleParameter.Hit = (int) ((double) ((battleParameter.Dexterity * 3 + battleParameter.Luck) / 2 + gearParameter.Hit + proficiencyIncr.hit) * (double) num29 / 10000.0 + (double) num13);
        battleParameter.Critical = (int) ((double) (battleParameter.Dexterity / 2 + gearParameter.Critical) * (double) num30 / 10000.0 + (double) num14);
        battleParameter.Evasion = (int) ((double) ((battleParameter.Agility * 3 + battleParameter.Luck) / 2 + gearParameter.Evasion + proficiencyIncr.evasion) * (double) num31 / 10000.0 + (double) num15);
        battleParameter.Combat = battleParameter.PhysicalAttack + battleParameter.PhysicalDefense + battleParameter.MagicAttack + battleParameter.MagicDefense + (battleParameter.Hit + battleParameter.Critical + battleParameter.Evasion) / 2 + battleParameter.Hp;
        battleParameter.PhysicalAttackIncr = battleParameter.PhysicalAttack - nonBattleParameter.PhysicalAttack;
        battleParameter.PhysicalDefenseIncr = battleParameter.PhysicalDefense - nonBattleParameter.PhysicalDefense;
        battleParameter.MagicAttackIncr = battleParameter.MagicAttack - nonBattleParameter.MagicAttack;
        battleParameter.MagicDefenseIncr = battleParameter.MagicDefense - nonBattleParameter.MagicDefense;
        battleParameter.HitIncr = battleParameter.Hit - nonBattleParameter.Hit;
        battleParameter.CriticalIncr = battleParameter.Critical - nonBattleParameter.Critical;
        battleParameter.EvasionIncr = battleParameter.Evasion - nonBattleParameter.Evasion;
        battleParameter.CombatIncr = battleParameter.Combat - nonBattleParameter.Combat;
        return battleParameter;
      }

      public static Judgement.BattleParameter FromBeColosseumUnit(
        BL.Unit beUnit,
        PlayerItem equipped_gear)
      {
        int skillAdd = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_hp, BattleskillInvokeGameModeEnum.colosseum, true);
        int num1 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_strength, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_strength_fix);
        int num2 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_intelligence, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_intelligence_fix);
        int num3 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_vitality, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_vitality_fix);
        int num4 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_mind, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_mind_fix);
        int num5 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_agility, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_agility_fix);
        int num6 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_dexterity, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_dexterity_fix);
        int num7 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_luck, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_luck_fix);
        int num8 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_move, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_move_fix);
        int num9 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_physical_attack, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_physical_attack_fix);
        int num10 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_physical_defense, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_physical_defense_fix);
        int num11 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_magic_attack, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_magic_attack_fix);
        int num12 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_magic_defense, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_magic_defense_fix);
        int num13 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_hit, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_hit_fix);
        int num14 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_critical, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_critical_fix);
        int num15 = Judgement.BattleParameter.GetSkillAdd(beUnit, BattleskillEffectLogicEnum.fix_evasion, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BattleParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_evasion_fix);
        float num16 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_hp, BattleskillInvokeGameModeEnum.colosseum, true);
        float num17 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_strength, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_strength_ratio);
        float num18 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_intelligence, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_intelligence_ratio);
        float num19 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_vitality, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_vitality_ratio);
        float num20 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_mind, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_mind_ratio);
        float num21 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_agility, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_agility_ratio);
        float num22 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_dexterity, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_dexterity_ratio);
        float num23 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_luck, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_luck_ratio);
        float num24 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_move, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_move_ratio);
        float num25 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_physical_attack, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_physical_attack_ratio);
        float num26 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_physical_defense, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_physical_defense_ratio);
        float num27 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_magic_attack, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_magic_attack_ratio);
        float num28 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_magic_defense, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_magic_defense_ratio);
        float num29 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_hit, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_hit_ratio);
        float num30 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_critical, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_critical_ratio);
        float num31 = 10000f * Judgement.BattleParameter.GetSkillMul(beUnit, BattleskillEffectLogicEnum.ratio_evasion, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BattleParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, BattleskillEffectLogicEnum.equip_evasion_ratio);
        PlayerUnit playerUnit = beUnit.playerUnit;
        Judgement.GearParameter gearParameter = !(equipped_gear == (PlayerItem) null) ? Judgement.GearParameter.FromPlayerGear(equipped_gear) : Judgement.GearParameter.FromGearGear(playerUnit.unit.initial_gear);
        UnitProficiencyIncr proficiencyIncr = playerUnit.ProficiencyIncr;
        Judgement.BattleParameter battleParameter = new Judgement.BattleParameter();
        battleParameter.Hp = (int) ((double) playerUnit.total_hp * (double) num16 / 10000.0 + (double) gearParameter.Hp + (double) skillAdd);
        battleParameter.Strength = (int) ((double) playerUnit.total_strength * (double) num17 / 10000.0 + (double) gearParameter.Strength + (double) num1);
        battleParameter.Intelligence = (int) ((double) playerUnit.total_intelligence * (double) num18 / 10000.0 + (double) gearParameter.Intelligence + (double) num2);
        battleParameter.Vitality = (int) ((double) playerUnit.total_vitality * (double) num19 / 10000.0 + (double) gearParameter.Vitality + (double) num3);
        battleParameter.Mind = (int) ((double) playerUnit.total_mind * (double) num20 / 10000.0 + (double) gearParameter.Mind + (double) num4);
        battleParameter.Agility = (int) ((double) playerUnit.total_agility * (double) num21 / 10000.0 + (double) gearParameter.Agility + (double) num5);
        battleParameter.Dexterity = (int) ((double) playerUnit.total_dexterity * (double) num22 / 10000.0 + (double) gearParameter.Dexterity + (double) num6);
        battleParameter.Luck = (int) ((double) playerUnit.total_lucky * (double) num23 / 10000.0 + (double) gearParameter.Luck + (double) num7);
        battleParameter.Move = (int) ((double) playerUnit.move * (double) num24 / 10000.0 + (double) num8);
        Judgement.NonBattleParameter nonBattleParameter = Judgement.NonBattleParameter.FromPlayerUnit(playerUnit);
        battleParameter.HpIncr = battleParameter.Hp - nonBattleParameter.Hp;
        battleParameter.StrengthIncr = battleParameter.Strength - nonBattleParameter.Strength;
        battleParameter.IntelligenceIncr = battleParameter.Intelligence - nonBattleParameter.Intelligence;
        battleParameter.VitalityIncr = battleParameter.Vitality - nonBattleParameter.Vitality;
        battleParameter.MindIncr = battleParameter.Mind - nonBattleParameter.Mind;
        battleParameter.AgilityIncr = battleParameter.Agility - nonBattleParameter.Agility;
        battleParameter.DexterityIncr = battleParameter.Dexterity - nonBattleParameter.Dexterity;
        battleParameter.LuckIncr = battleParameter.Luck - nonBattleParameter.Luck;
        battleParameter.MoveIncr = battleParameter.Move - nonBattleParameter.Move;
        bool flag = ((IEnumerable<BL.MagicBullet>) beUnit.magicBullets).Any<BL.MagicBullet>();
        int power1 = !flag ? gearParameter.Power : 0;
        int power2 = !flag ? 0 : gearParameter.Power;
        battleParameter.PhysicalAttack = (int) ((double) (battleParameter.Strength + power1 + proficiencyIncr.physical_attack) * (double) num25 / 10000.0 + (double) num9);
        battleParameter.PhysicalDefense = (int) ((double) (battleParameter.Vitality + gearParameter.PhysicalDefense) * (double) num26 / 10000.0 + (double) num10);
        battleParameter.MagicAttack = (int) ((double) (battleParameter.Intelligence + playerUnit.MinMagicBulletPower + power2 + proficiencyIncr.magic_attack) * (double) num27 / 10000.0 + (double) num11);
        battleParameter.MagicDefense = (int) ((double) (battleParameter.Mind + gearParameter.MagicDefense) * (double) num28 / 10000.0 + (double) num12);
        battleParameter.Hit = (int) ((double) ((battleParameter.Dexterity * 3 + battleParameter.Luck) / 2 + gearParameter.Hit + proficiencyIncr.hit) * (double) num29 / 10000.0 + (double) num13);
        battleParameter.Critical = (int) ((double) (battleParameter.Dexterity / 2 + gearParameter.Critical) * (double) num30 / 10000.0 + (double) num14);
        battleParameter.Evasion = (int) ((double) ((battleParameter.Agility * 3 + battleParameter.Luck) / 2 + gearParameter.Evasion + proficiencyIncr.evasion) * (double) num31 / 10000.0 + (double) num15);
        battleParameter.Combat = battleParameter.PhysicalAttack + battleParameter.PhysicalDefense + battleParameter.MagicAttack + battleParameter.MagicDefense + (battleParameter.Hit + battleParameter.Critical + battleParameter.Evasion) / 2 + battleParameter.Hp;
        battleParameter.PhysicalAttackIncr = battleParameter.PhysicalAttack - nonBattleParameter.PhysicalAttack;
        battleParameter.PhysicalDefenseIncr = battleParameter.PhysicalDefense - nonBattleParameter.PhysicalDefense;
        battleParameter.MagicAttackIncr = battleParameter.MagicAttack - nonBattleParameter.MagicAttack;
        battleParameter.MagicDefenseIncr = battleParameter.MagicDefense - nonBattleParameter.MagicDefense;
        battleParameter.HitIncr = battleParameter.Hit - nonBattleParameter.Hit;
        battleParameter.CriticalIncr = battleParameter.Critical - nonBattleParameter.Critical;
        battleParameter.EvasionIncr = battleParameter.Evasion - nonBattleParameter.Evasion;
        battleParameter.CombatIncr = battleParameter.Combat - nonBattleParameter.Combat;
        return battleParameter;
      }
    }

    [Serializable]
    public class BeforeDuelUnitParameter
    {
      public int Hp;
      public int Strength;
      public int Intelligence;
      public int Vitality;
      public int Mind;
      public int Agility;
      public int Dexterity;
      public int Luck;
      public int Move;
      public int PhysicalAttack;
      public int PhysicalDefense;
      public int MagicAttack;
      public int MagicDefense;
      public int Hit;
      public int Critical;
      public int Evasion;
      public int CriticalEvasion;
      public int AttackSpeed;
      public bool IsDontEvasion;

      private static int GetSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        int attackType,
        BattleskillEffectLogicEnum fix_logic,
        BattleskillInvokeGameModeEnum gameMode,
        bool isHp = false)
      {
        int skillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, attackType, gameMode, isHp))
          skillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return skillAdd;
      }

      private static float GetSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        int attackType,
        BattleskillEffectLogicEnum ratio_logic,
        BattleskillInvokeGameModeEnum gameMode,
        bool isHp = false)
      {
        float skillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, attackType, gameMode, isHp))
          skillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return skillMul;
      }

      private static int GetRangeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        int distanse)
      {
        int rangeSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledRangeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, distanse))
          rangeSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return rangeSkillAdd;
      }

      private static float GetRangeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        int distance)
      {
        float rangeSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledRangeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, distance))
          rangeSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return rangeSkillMul;
      }

      private static int GetMoveDistanceSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        int move_distance)
      {
        if (move_distance <= 0)
          return 0;
        int distanceSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledRangeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, move_distance))
          distanceSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return distanceSkillAdd;
      }

      private static float GetMoveDistanceSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        int move_distance)
      {
        if (move_distance <= 0)
          return 1f;
        float distanceSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledRangeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, move_distance))
          distanceSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return distanceSkillMul;
      }

      private static int GetHpLeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        float hpRatio)
      {
        int hpLeSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledHpLeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, hpRatio))
          hpLeSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return hpLeSkillAdd;
      }

      private static float GetHpLeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        float hpRatio)
      {
        float hpLeSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledHpLeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, hpRatio))
          hpLeSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return hpLeSkillMul;
      }

      private static int GetHpGeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        float hpRatio)
      {
        int hpGeSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledHpGeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, hpRatio))
          hpGeSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return hpGeSkillAdd;
      }

      private static float GetHpGeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        float hpRatio)
      {
        float hpGeSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledHpGeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, hpRatio))
          hpGeSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return hpGeSkillMul;
      }

      private static int GetTargetCountSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        BL.ForceID[] targetForceId,
        BL.Panel panel,
        bool isAI)
      {
        int targetCountSkillAdd = 0;
        if (targetForceId == null || panel == null)
          return targetCountSkillAdd;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledTargetCountBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, targetForceId, panel, isAI))
        {
          int num1 = BattleFuncs.getTargets(panel.row, panel.column, new int[2]
          {
            skillEffect.effect.GetInt("min_range"),
            skillEffect.effect.GetInt("max_range")
          }, targetForceId, (isAI ? 1 : 0) != 0).Count<BL.UnitPosition>();
          int num2 = skillEffect.effect.GetInt("max_target_count");
          if (num2 >= 1 && num1 > num2)
            num1 = num2;
          targetCountSkillAdd += num1 * (int) ((double) skillEffect.effect.GetFloat("skill_lv_add") + (double) skillEffect.effect.GetFloat("skill_lv_mul") * (double) (skillEffect.baseSkillLevel - 1));
        }
        return targetCountSkillAdd;
      }

      private static float GetTargetCountSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        BL.ForceID[] targetForceId,
        BL.Panel panel,
        bool isAI)
      {
        float targetCountSkillMul = 1f;
        if (targetForceId == null || panel == null)
          return targetCountSkillMul;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledTargetCountBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, targetForceId, panel, isAI))
        {
          int num1 = BattleFuncs.getTargets(panel.row, panel.column, new int[2]
          {
            skillEffect.effect.GetInt("min_range"),
            skillEffect.effect.GetInt("max_range")
          }, targetForceId, (isAI ? 1 : 0) != 0).Count<BL.UnitPosition>();
          int num2 = skillEffect.effect.GetInt("max_target_count");
          if (num2 >= 1 && num1 > num2)
            num1 = num2;
          targetCountSkillMul *= (float) (1.0 + (double) num1 * ((double) skillEffect.effect.GetFloat("skill_lv_add") + (double) skillEffect.effect.GetFloat("skill_lv_mul") * (double) (skillEffect.baseSkillLevel - 1)));
        }
        return targetCountSkillMul;
      }

      private static int GetCharismaSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        Dictionary<BL.ISkillEffectListUnit, int>[] unitDistance)
      {
        int charismaSkillAdd = 0;
        if (unitDistance == null)
          return charismaSkillAdd;
        for (int effectTarget = 0; effectTarget <= 1; ++effectTarget)
        {
          foreach (BL.ISkillEffectListUnit key in unitDistance[effectTarget].Keys)
          {
            foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledCharismaBuffDebuff(key.skillEffects, ratio_logic, key, unitDistance[effectTarget][key], effectTarget, beUnit, beTarget))
              charismaSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
          }
        }
        return charismaSkillAdd;
      }

      private static float GetCharismaSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        Dictionary<BL.ISkillEffectListUnit, int>[] unitDistance)
      {
        float charismaSkillMul = 1f;
        if (unitDistance == null)
          return charismaSkillMul;
        for (int effectTarget = 0; effectTarget <= 1; ++effectTarget)
        {
          foreach (BL.ISkillEffectListUnit key in unitDistance[effectTarget].Keys)
          {
            foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledCharismaBuffDebuff(key.skillEffects, ratio_logic, key, unitDistance[effectTarget][key], effectTarget, beUnit, beTarget))
              charismaSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
          }
        }
        return charismaSkillMul;
      }

      private static int GetCavalryRushSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        int move_range)
      {
        if (move_range < 0)
          return 0;
        int cavalryRushSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledRangeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, move_range))
          cavalryRushSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return cavalryRushSkillAdd;
      }

      private static float GetCavalryRushSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        int move_range)
      {
        if (move_range < 0)
          return 1f;
        float cavalryRushSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledRangeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, move_range))
          cavalryRushSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return cavalryRushSkillMul;
      }

      private static int GetRaidMissionSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        BL.ISkillEffectListUnit raidMissionUnit)
      {
        int raidMissionSkillAdd = 0;
        if (raidMissionUnit == null)
          return raidMissionSkillAdd;
        int effectTarget = beUnit != raidMissionUnit ? 1 : 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledRaidMissionBuffDebuff(raidMissionUnit.skillEffects, fix_logic, raidMissionUnit, effectTarget, beUnit, beTarget))
          raidMissionSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return raidMissionSkillAdd;
      }

      private static float GetRaidMissionSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        BL.ISkillEffectListUnit raidMissionUnit)
      {
        float raidMissionSkillMul = 1f;
        if (raidMissionUnit == null)
          return raidMissionSkillMul;
        int effectTarget = beUnit != raidMissionUnit ? 1 : 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledRaidMissionBuffDebuff(raidMissionUnit.skillEffects, ratio_logic, raidMissionUnit, effectTarget, beUnit, beTarget))
          raidMissionSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return raidMissionSkillMul;
      }

      private static int GetExtremeOfForceSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic)
      {
        int extremeOfForceSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledExtremeOfForceBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget))
          extremeOfForceSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return extremeOfForceSkillAdd;
      }

      private static float GetExtremeOfForceSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic)
      {
        float extremeOfForceSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledExtremeOfForceBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget))
          extremeOfForceSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return extremeOfForceSkillMul;
      }

      private static int GetOnemanChargeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        Dictionary<BL.ISkillEffectListUnit, int>[] unitDistance)
      {
        int onemanChargeSkillAdd = 0;
        if (unitDistance == null)
          return onemanChargeSkillAdd;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledOnemanChargeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, unitDistance))
          onemanChargeSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return onemanChargeSkillAdd;
      }

      private static float GetOnemanChargeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        Dictionary<BL.ISkillEffectListUnit, int>[] unitDistance)
      {
        float onemanChargeSkillMul = 1f;
        if (unitDistance == null)
          return onemanChargeSkillMul;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledOnemanChargeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, unitDistance))
          onemanChargeSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return onemanChargeSkillMul;
      }

      private static int GetInOutSideBattleSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        BattleLandform landform,
        BattleInOutSide side)
      {
        int sideBattleSkillAdd = 0;
        if (landform.in_out != side)
          return sideBattleSkillAdd;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledInOutSideBattleBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget))
          sideBattleSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return sideBattleSkillAdd;
      }

      private static float GetInOutSideBattleSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        BattleLandform landform,
        BattleInOutSide side)
      {
        float sideBattleSkillMul = 1f;
        if (landform.in_out != side)
          return sideBattleSkillMul;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledInOutSideBattleBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget))
          sideBattleSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return sideBattleSkillMul;
      }

      private static int GetOutSideBattleSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        BattleLandform landform)
      {
        return Judgement.BeforeDuelUnitParameter.GetInOutSideBattleSkillAdd(beUnit, beTarget, fix_logic, landform, BattleInOutSide.outside);
      }

      private static float GetOutSideBattleSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        BattleLandform landform)
      {
        return Judgement.BeforeDuelUnitParameter.GetInOutSideBattleSkillMul(beUnit, beTarget, ratio_logic, landform, BattleInOutSide.outside);
      }

      private static int GetInSideBattleSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        BattleLandform landform)
      {
        return Judgement.BeforeDuelUnitParameter.GetInOutSideBattleSkillAdd(beUnit, beTarget, fix_logic, landform, BattleInOutSide.inside);
      }

      private static float GetInSideBattleSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        BattleLandform landform)
      {
        return Judgement.BeforeDuelUnitParameter.GetInOutSideBattleSkillMul(beUnit, beTarget, ratio_logic, landform, BattleInOutSide.inside);
      }

      private static int GetEvenIllusionSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic)
      {
        int illusionSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledEvenIllusionBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget))
          illusionSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return illusionSkillAdd;
      }

      private static float GetEvenIllusionSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic)
      {
        float illusionSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledEvenIllusionBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget))
          illusionSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return illusionSkillMul;
      }

      private static int GetDeckEveryGeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        int num = 0;
        return deckUnits == null ? num : num + Judgement.GetFixEffectParamValue(beUnit, beTarget, fix_logic);
      }

      private static float GetDeckEveryGeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        float num = 1f;
        return deckUnits == null ? num : num * Judgement.GetRatioEffectParamValue(beUnit, beTarget, ratio_logic);
      }

      private static int GetDeckEveryLeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        int num = 0;
        return deckUnits == null ? num : num + Judgement.GetFixEffectParamValue(beUnit, beTarget, fix_logic);
      }

      private static float GetDeckEveryLeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        float num = 1f;
        return deckUnits == null ? num : num * Judgement.GetRatioEffectParamValue(beUnit, beTarget, ratio_logic);
      }

      private static int GetDeckAnotherGeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        int num = 0;
        return deckUnits == null ? num : num + Judgement.GetFixEffectParamValue(beUnit, beTarget, fix_logic);
      }

      private static float GetDeckAnotherGeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        float num = 1f;
        return deckUnits == null ? num : num * Judgement.GetRatioEffectParamValue(beUnit, beTarget, ratio_logic);
      }

      private static int GetDeckAnotherLeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        int num = 0;
        return deckUnits == null ? num : num + Judgement.GetFixEffectParamValue(beUnit, beTarget, fix_logic);
      }

      private static float GetDeckAnotherLeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        float num = 1f;
        return deckUnits == null ? num : num * Judgement.GetRatioEffectParamValue(beUnit, beTarget, ratio_logic);
      }

      private static int GetDeckSameGeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        int num = 0;
        return deckUnits == null ? num : num + Judgement.GetFixEffectParamValue(beUnit, beTarget, fix_logic);
      }

      private static float GetDeckSameGeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        float num = 1f;
        return deckUnits == null ? num : num * Judgement.GetRatioEffectParamValue(beUnit, beTarget, ratio_logic);
      }

      private static int GetDeckSameLeSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        int num = 0;
        return deckUnits == null ? num : num + Judgement.GetFixEffectParamValue(beUnit, beTarget, fix_logic);
      }

      private static float GetDeckSameLeSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        IEnumerable<BL.Unit> deckUnits)
      {
        float num = 1f;
        return deckUnits == null ? num : num * Judgement.GetRatioEffectParamValue(beUnit, beTarget, ratio_logic);
      }

      private static int GetSpecificUnitSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        bool isHeal)
      {
        int specificUnitSkillAdd = 0;
        if (isHeal)
          return specificUnitSkillAdd;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledSpecificUnitBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget))
          specificUnitSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return specificUnitSkillAdd;
      }

      private static float GetSpecificUnitSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        bool isHeal)
      {
        float specificUnitSkillMul = 1f;
        if (isHeal)
          return specificUnitSkillMul;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledSpecificUnitBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget))
          specificUnitSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return specificUnitSkillMul;
      }

      private static int GetUnitRaritySkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic)
      {
        int unitRaritySkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledUnitRarityBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget))
          unitRaritySkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return unitRaritySkillAdd;
      }

      private static float GetUnitRaritySkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic)
      {
        float unitRaritySkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledUnitRarityBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget))
          unitRaritySkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return unitRaritySkillMul;
      }

      private static int GetEquipGearSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic)
      {
        int equipGearSkillAdd = 0;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledEquipGearBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget))
          equipGearSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return equipGearSkillAdd;
      }

      private static float GetEquipGearSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic)
      {
        float equipGearSkillMul = 1f;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledEquipGearBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget))
          equipGearSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return equipGearSkillMul;
      }

      private static int GetDeadCountPlayerSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        int turnCount,
        IEnumerable<BL.Unit> unitDeckUnits,
        BattleskillInvokeGameModeEnum gameMode,
        bool isAI)
      {
        int countPlayerSkillAdd = 0;
        if (unitDeckUnits == null)
          return countPlayerSkillAdd;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledDeadCountBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, turnCount, unitDeckUnits, (IEnumerable<BL.Unit>) null, gameMode, isAI))
          countPlayerSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return countPlayerSkillAdd;
      }

      private static float GetDeadCountPlayerSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        int turnCount,
        IEnumerable<BL.Unit> unitDeckUnits,
        BattleskillInvokeGameModeEnum gameMode,
        bool isAI)
      {
        float countPlayerSkillMul = 1f;
        if (unitDeckUnits == null)
          return countPlayerSkillMul;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledDeadCountBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, turnCount, unitDeckUnits, (IEnumerable<BL.Unit>) null, gameMode, isAI))
          countPlayerSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return countPlayerSkillMul;
      }

      private static int GetDeadCountEnemySkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        int turnCount,
        IEnumerable<BL.Unit> targetDeckUnits,
        BattleskillInvokeGameModeEnum gameMode,
        bool isAI)
      {
        int countEnemySkillAdd = 0;
        if (targetDeckUnits == null)
          return countEnemySkillAdd;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledDeadCountBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, turnCount, (IEnumerable<BL.Unit>) null, targetDeckUnits, gameMode, isAI))
          countEnemySkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return countEnemySkillAdd;
      }

      private static float GetDeadCountEnemySkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        int turnCount,
        IEnumerable<BL.Unit> targetDeckUnits,
        BattleskillInvokeGameModeEnum gameMode,
        bool isAI)
      {
        float countEnemySkillMul = 1f;
        if (targetDeckUnits == null)
          return countEnemySkillMul;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledDeadCountBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, turnCount, (IEnumerable<BL.Unit>) null, targetDeckUnits, gameMode, isAI))
          countEnemySkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return countEnemySkillMul;
      }

      private static int GetDeadCountComplexSkillAdd(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum fix_logic,
        int turnCount,
        IEnumerable<BL.Unit> unitDeckUnits,
        IEnumerable<BL.Unit> targetDeckUnits,
        BattleskillInvokeGameModeEnum gameMode,
        bool isAI)
      {
        int countComplexSkillAdd = 0;
        if (unitDeckUnits == null || targetDeckUnits == null)
          return countComplexSkillAdd;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledDeadCountBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, turnCount, unitDeckUnits, targetDeckUnits, gameMode, isAI))
          countComplexSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        return countComplexSkillAdd;
      }

      private static float GetDeadCountComplexSkillMul(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleskillEffectLogicEnum ratio_logic,
        int turnCount,
        IEnumerable<BL.Unit> unitDeckUnits,
        IEnumerable<BL.Unit> targetDeckUnits,
        BattleskillInvokeGameModeEnum gameMode,
        bool isAI)
      {
        float countComplexSkillMul = 1f;
        if (unitDeckUnits == null || targetDeckUnits == null)
          return countComplexSkillMul;
        foreach (BL.SkillEffect skillEffect in Judgement.GetEnabledDeadCountBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, turnCount, unitDeckUnits, targetDeckUnits, gameMode, isAI))
          countComplexSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
        return countComplexSkillMul;
      }

      public static Judgement.BeforeDuelUnitParameter FromBeUnit(
        BL.ISkillEffectListUnit beUnit,
        BL.ISkillEffectListUnit beTarget,
        BattleLandform landform,
        BL.Unit[] neighborUnits,
        BL.MagicBullet beMagicBullet,
        int attackType,
        int distance,
        Judgement.BeforeDuelUnitParameter.FromBeUnitData data = null)
      {
        int move_distance;
        int move_range;
        int num1;
        BL.ForceID[] targetForceId;
        BL.Panel panel;
        BL.ISkillEffectListUnit raidMissionUnit;
        Dictionary<BL.ISkillEffectListUnit, int>[] unitDistance;
        IEnumerable<BL.Unit> units;
        IEnumerable<BL.Unit> targetDeckUnits;
        bool isHeal;
        bool isAI;
        if (data != null)
        {
          move_distance = data.move_distance;
          move_range = data.move_range;
          num1 = data.attackHp;
          targetForceId = data.targetForceId;
          panel = data.panel;
          raidMissionUnit = data.raidMissionUnit;
          unitDistance = data.charismaUnitDistance;
          units = data.deckUnits;
          targetDeckUnits = data.targetDeckUnits;
          isHeal = data.isHeal;
          isAI = data.isAI;
        }
        else
        {
          move_distance = 0;
          move_range = -1;
          num1 = 0;
          targetForceId = (BL.ForceID[]) null;
          panel = (BL.Panel) null;
          raidMissionUnit = (BL.ISkillEffectListUnit) null;
          unitDistance = (Dictionary<BL.ISkillEffectListUnit, int>[]) null;
          units = (IEnumerable<BL.Unit>) null;
          targetDeckUnits = (IEnumerable<BL.Unit>) null;
          isHeal = false;
          isAI = false;
        }
        if (num1 <= 0)
          num1 = beUnit.hp;
        float hpRatio = (float) ((double) num1 / (double) beUnit.originalUnit.parameter.Hp * 100.0);
        int absoluteTurnCount = BattleFuncs.getPhaseState() == null ? 0 : BattleFuncs.getPhaseState().absoluteTurnCount;
        int skillAdd = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_hp, BattleskillInvokeGameModeEnum.quest, true);
        int num2 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_strength, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_strength, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_strength, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_strength, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_strength, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_strength, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_strength, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_strength, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_strength, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_strength) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_strength, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_strength, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_strength, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_strength) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_strength, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_strength, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_strength, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_strength, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_strength, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_strength, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_strength, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_strength) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_strength_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_strength, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_strength, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_strength, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num3 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_intelligence, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_intelligence, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_intelligence, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_intelligence, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_intelligence, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_intelligence, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_intelligence, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_intelligence, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_intelligence, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_intelligence) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_intelligence, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_intelligence, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_intelligence, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_intelligence) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_intelligence, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_intelligence, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_intelligence, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_intelligence, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_intelligence, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_intelligence, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_intelligence, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_intelligence) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_intelligence_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_intelligence, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_intelligence, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_intelligence, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num4 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_vitality, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_vitality, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_vitality, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_vitality, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_vitality, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_vitality, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_vitality, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_vitality, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_vitality, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_vitality) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_vitality, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_vitality, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_vitality, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_vitality) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_vitality, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_vitality, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_vitality, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_vitality, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_vitality, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_vitality, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_vitality, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_vitality) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_vitality_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_vitality, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_vitality, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_vitality, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num5 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_mind, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_mind, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_mind, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_mind, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_mind, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_mind, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_mind, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_mind, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_mind, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_mind) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_mind, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_mind, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_mind, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_mind) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_mind, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_mind, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_mind, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_mind, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_mind, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_mind, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_mind, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_mind) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_mind_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_mind, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_mind, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_mind, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num6 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_agility, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_agility, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_agility, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_agility, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_agility, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_agility, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_agility, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_agility, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_agility, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_agility) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_agility, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_agility, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_agility, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_agility) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_agility, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_agility, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_agility, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_agility, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_agility, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_agility, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_agility, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_agility) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_agility_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_agility, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_agility, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_agility, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num7 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_dexterity, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_dexterity, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_dexterity, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_dexterity, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_dexterity, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_dexterity, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_dexterity, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_dexterity, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_dexterity, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_dexterity) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_dexterity, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_dexterity, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_dexterity, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_dexterity) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_dexterity, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_dexterity, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_dexterity, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_dexterity, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_dexterity, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_dexterity, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_dexterity, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_dexterity) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_dexterity_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_dexterity, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_dexterity, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_dexterity, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num8 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_luck, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_luck, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_luck, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_luck, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_luck, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_luck, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_luck, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_luck, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_luck, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_luck) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_luck, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_luck, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_luck, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_luck) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_luck, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_luck, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_luck, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_luck, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_luck, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_luck, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_luck, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_luck) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_luck_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_luck, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_luck, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_luck, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num9 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_move, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_move, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_move, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_move, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_move, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_move, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_move, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_move, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_move, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_move) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_move, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_move, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_move, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_move) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_move, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_move, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_move, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_move, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_move, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_move, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_move, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_move) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_move_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_move, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_move, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_move, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num10 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_physical_attack, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_physical_attack, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_physical_attack, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_physical_attack, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_physical_attack, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_physical_attack, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_physical_attack, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_physical_attack, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_physical_attack, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_physical_attack) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_physical_attack, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_physical_attack, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_physical_attack, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_physical_attack) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_physical_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_physical_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_physical_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_physical_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_physical_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_physical_attack, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_physical_attack, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_physical_attack) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_physical_attack_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_physical_attack, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_physical_attack, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_physical_attack, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num11 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_physical_defense, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_physical_defense, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_physical_defense, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_physical_defense, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_physical_defense, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_physical_defense, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_physical_defense, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_physical_defense, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_physical_defense, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_physical_defense) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_physical_defense, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_physical_defense, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_physical_defense, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_physical_defense) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_physical_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_physical_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_physical_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_physical_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_physical_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_physical_defense, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_physical_defense, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_physical_defense) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_physical_defense_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_physical_defense, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_physical_defense, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_physical_defense, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num12 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_magic_attack, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_magic_attack, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_magic_attack, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_magic_attack, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_magic_attack, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_magic_attack, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_magic_attack, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_magic_attack, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_magic_attack, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_magic_attack) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_magic_attack, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_magic_attack, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_magic_attack, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_magic_attack) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_magic_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_magic_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_magic_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_magic_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_magic_attack, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_magic_attack, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_magic_attack, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_magic_attack) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_magic_attack_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_magic_attack, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_magic_attack, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_magic_attack, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num13 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_magic_defense, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_magic_defense, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_magic_defense, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_magic_defense, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_magic_defense, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_magic_defense, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_magic_defense, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_magic_defense, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_magic_defense, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_magic_defense) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_magic_defense, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_magic_defense, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_magic_defense, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_magic_defense) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_magic_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_magic_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_magic_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_magic_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_magic_defense, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_magic_defense, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_magic_defense, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_magic_defense) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_magic_defense_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_magic_defense, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_magic_defense, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_magic_defense, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num14 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_hit, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_hit, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_hit, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_hit, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_hit, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_hit, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_hit, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_hit, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_hit, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_hit) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_hit, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_hit, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_hit, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_hit) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_hit, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_hit, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_hit, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_hit, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_hit, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_hit, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_hit, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_hit) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_hit_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_hit, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_hit, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_hit, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num15 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_critical, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_critical, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_critical, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_critical, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_critical, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_critical, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_critical, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_critical, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_critical, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_critical) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_critical, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_critical, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_critical, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_critical) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_critical, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_critical, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_critical, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_critical, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_critical, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_critical, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_critical, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_critical) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_critical_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_critical, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_critical, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_critical, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num16 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_evasion, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_evasion, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_evasion, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_evasion, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_evasion, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_evasion, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_evasion, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_evasion, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_evasion, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_evasion) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_evasion, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_evasion, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_evasion, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_evasion) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_evasion, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_evasion, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_evasion) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_evasion_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_evasion, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_evasion, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_evasion, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num17 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_critical_evasion, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_critical_evasion, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_critical_evasion, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_critical_evasion, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_critical_evasion, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_critical_evasion, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_critical_evasion, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_critical_evasion, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_critical_evasion, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_critical_evasion) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_critical_evasion, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_critical_evasion, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_critical_evasion, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_critical_evasion) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_critical_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_critical_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_critical_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_critical_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_critical_evasion, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_critical_evasion, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_critical_evasion, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_critical_evasion) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_critical_evasion_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_critical_evasion, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_critical_evasion, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_critical_evasion, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        int num18 = Judgement.BeforeDuelUnitParameter.GetSkillAdd(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.fix_attack_speed, BattleskillInvokeGameModeEnum.quest) + Judgement.BeforeDuelUnitParameter.GetRangeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.range_fix_attack_speed, distance) + Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_fix_attack_speed, move_distance) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_fix_attack_speed, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_fix_attack_speed, hpRatio) + Judgement.BeforeDuelUnitParameter.GetTargetCountSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_fix_attack_speed, targetForceId, panel, isAI) + Judgement.BeforeDuelUnitParameter.GetCharismaSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_fix_attack_speed, unitDistance) + Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_fix_attack_speed, move_range) + Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_fix_attack_speed, raidMissionUnit) + Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_fix_attack_speed) + Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_fix_attack_speed, unitDistance) + Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_fix_attack_speed, landform) + Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_fix_attack_speed, landform) + Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_fix_attack_speed) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_attack_speed, units) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_attack_speed, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_attack_speed, units) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_attack_speed, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_attack_speed, units) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_attack_speed, units) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_fix_attack_speed, isHeal) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_attack_speed) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.equip_attack_speed_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_attack_speed, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_attack_speed, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_attack_speed, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num19 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_hp, BattleskillInvokeGameModeEnum.quest, true);
        float num20 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_strength, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_strength, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_strength, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_strength, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_strength, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_strength, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_strength, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_strength, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_strength, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_strength) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_strength, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_strength, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_strength, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_strength) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_strength, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_strength, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_strength, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_strength, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_strength, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_strength, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_strength, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_strength) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_strength_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_strength, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_strength, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_strength, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num21 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_intelligence, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_intelligence, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_intelligence, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_intelligence, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_intelligence, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_intelligence, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_intelligence, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_intelligence, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_intelligence, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_intelligence) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_intelligence, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_intelligence, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_intelligence, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_intelligence) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_intelligence, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_intelligence, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_intelligence, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_intelligence, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_intelligence, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_intelligence, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_intelligence, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_intelligence) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_intelligence_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_intelligence, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_intelligence, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_intelligence, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num22 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_vitality, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_vitality, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_vitality, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_vitality, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_vitality, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_vitality, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_vitality, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_vitality, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_vitality, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_vitality) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_vitality, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_vitality, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_vitality, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_vitality) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_vitality, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_vitality, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_vitality, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_vitality, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_vitality, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_vitality, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_vitality, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_vitality) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_vitality_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_vitality, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_vitality, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_vitality, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num23 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_mind, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_mind, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_mind, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_mind, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_mind, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_mind, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_mind, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_mind, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_mind, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_mind) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_mind, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_mind, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_mind, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_mind) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_mind, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_mind, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_mind, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_mind, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_mind, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_mind, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_mind, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_mind) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_mind_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_mind, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_mind, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_mind, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num24 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_agility, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_agility, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_agility, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_agility, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_agility, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_agility, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_agility, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_agility, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_agility, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_agility) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_agility, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_agility, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_agility, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_agility) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_agility, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_agility, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_agility, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_agility, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_agility, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_agility, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_agility, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_agility) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_agility_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_agility, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_agility, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_agility, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num25 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_dexterity, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_dexterity, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_dexterity, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_dexterity, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_dexterity, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_dexterity, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_dexterity, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_dexterity, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_dexterity, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_dexterity) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_dexterity, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_dexterity, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_dexterity, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_dexterity) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_dexterity, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_dexterity, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_dexterity, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_dexterity, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_dexterity, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_dexterity, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_dexterity, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_dexterity) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_dexterity_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_dexterity, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_dexterity, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_dexterity, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num26 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_luck, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_luck, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_luck, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_luck, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_luck, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_luck, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_luck, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_luck, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_luck, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_luck) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_luck, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_luck, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_luck, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_luck) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_luck, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_luck, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_luck, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_luck, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_luck, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_luck, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_luck, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_luck) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_luck_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_luck, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_luck, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_luck, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num27 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_move, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_move, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_move, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_move, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_move, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_move, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_move, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_move, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_move, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_move) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_move, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_move, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_move, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_move) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_move, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_move, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_move, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_move, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_move, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_move, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_move, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_move) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_move_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_move, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_move, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_move, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num28 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_physical_attack, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_physical_attack, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_physical_attack, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_physical_attack, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_physical_attack, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_physical_attack, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_physical_attack, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_physical_attack, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_physical_attack, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_physical_attack) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_physical_attack, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_physical_attack, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_physical_attack, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_physical_attack) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_physical_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_physical_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_physical_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_physical_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_physical_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_physical_attack, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_physical_attack, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_physical_attack) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_physical_attack_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_physical_attack, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_physical_attack, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_physical_attack, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num29 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_physical_defense, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_physical_defense, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_physical_defense, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_physical_defense, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_physical_defense, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_physical_defense, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_physical_defense, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_physical_defense, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_physical_defense, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_physical_defense) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_physical_defense, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_physical_defense, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_physical_defense, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_physical_defense) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_physical_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_physical_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_physical_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_physical_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_physical_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_physical_defense, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_physical_defense, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_physical_defense) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_physical_defense_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_physical_defense, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_physical_defense, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_physical_defense, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num30 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_magic_attack, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_magic_attack, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_magic_attack, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_magic_attack, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_magic_attack, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_magic_attack, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_magic_attack, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_magic_attack, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_magic_attack, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_magic_attack) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_magic_attack, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_magic_attack, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_magic_attack, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_magic_attack) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_magic_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_magic_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_magic_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_magic_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_magic_attack, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_magic_attack, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_magic_attack, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_magic_attack) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_magic_attack_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_magic_attack, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_magic_attack, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_magic_attack, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num31 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_magic_defense, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_magic_defense, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_magic_defense, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_magic_defense, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_magic_defense, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_magic_defense, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_magic_defense, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_magic_defense, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_magic_defense, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_magic_defense) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_magic_defense, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_magic_defense, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_magic_defense, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_magic_defense) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_magic_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_magic_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_magic_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_magic_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_magic_defense, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_magic_defense, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_magic_defense, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_magic_defense) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_magic_defense_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_magic_defense, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_magic_defense, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_magic_defense, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num32 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_hit, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_hit, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_hit, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_hit, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_hit, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_hit, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_hit, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_hit, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_hit, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_hit) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_hit, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_hit, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_hit, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_hit) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_hit, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_hit, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_hit, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_hit, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_hit, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_hit, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_hit, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_hit) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_hit_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_hit, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_hit, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_hit, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num33 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_critical, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_critical, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_critical, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_critical, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_critical, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_critical, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_critical, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_critical, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_critical, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_critical) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_critical, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_critical, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_critical, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_critical) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_critical, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_critical, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_critical, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_critical, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_critical, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_critical, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_critical, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_critical) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_critical_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_critical, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_critical, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_critical, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num34 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_evasion, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_evasion, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_evasion, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_evasion, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_evasion, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_evasion, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_evasion, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_evasion, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_evasion, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_evasion) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_evasion, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_evasion, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_evasion, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_evasion) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_evasion, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_evasion, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_evasion) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_evasion_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_evasion, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_evasion, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_evasion, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num35 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_critical_evasion, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_critical_evasion, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_critical_evasion, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_critical_evasion, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_critical_evasion, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_critical_evasion, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_critical_evasion, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_critical_evasion, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_critical_evasion, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_critical_evasion) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_critical_evasion, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_critical_evasion, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_critical_evasion, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_critical_evasion) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_critical_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_critical_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_critical_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_critical_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_critical_evasion, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_critical_evasion, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_critical_evasion, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_critical_evasion) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_critical_evasion_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_critical_evasion, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_critical_evasion, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_critical_evasion, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        float num36 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul(beUnit, beTarget, attackType, BattleskillEffectLogicEnum.ratio_attack_speed, BattleskillInvokeGameModeEnum.quest) * Judgement.BeforeDuelUnitParameter.GetRangeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.range_ratio_attack_speed, distance) * Judgement.BeforeDuelUnitParameter.GetMoveDistanceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.move_distance_ratio_attack_speed, move_distance) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_le_ratio_attack_speed, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_attack_speed, hpRatio) * Judgement.BeforeDuelUnitParameter.GetTargetCountSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.target_count_ratio_attack_speed, targetForceId, panel, isAI) * Judgement.BeforeDuelUnitParameter.GetCharismaSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.charisma_ratio_attack_speed, unitDistance) * Judgement.BeforeDuelUnitParameter.GetCavalryRushSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.cavalry_rush_ratio_attack_speed, move_range) * Judgement.BeforeDuelUnitParameter.GetRaidMissionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.raid_mission_ratio_attack_speed, raidMissionUnit) * Judgement.BeforeDuelUnitParameter.GetExtremeOfForceSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.extreme_of_force_ratio_attack_speed) * Judgement.BeforeDuelUnitParameter.GetOnemanChargeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.oneman_charge_ratio_attack_speed, unitDistance) * Judgement.BeforeDuelUnitParameter.GetOutSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.outside_battle_ratio_attack_speed, landform) * Judgement.BeforeDuelUnitParameter.GetInSideBattleSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.inside_battle_ratio_attack_speed, landform) * Judgement.BeforeDuelUnitParameter.GetEvenIllusionSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.even_illusion_ratio_attack_speed) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_attack_speed, units) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_attack_speed, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_attack_speed, units) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_attack_speed, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_attack_speed, units) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_attack_speed, units) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_attack_speed, isHeal) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_attack_speed) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.equip_attack_speed_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_attack_speed, absoluteTurnCount, units, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_attack_speed, absoluteTurnCount, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_attack_speed, absoluteTurnCount, units, targetDeckUnits, BattleskillInvokeGameModeEnum.quest, isAI);
        PlayerUnit playerUnit = beUnit.originalUnit.playerUnit;
        Judgement.GearParameter gearParameter = !(playerUnit.equippedGear == (PlayerItem) null) ? Judgement.GearParameter.FromPlayerGear(playerUnit.equippedGear) : Judgement.GearParameter.FromGearGear(playerUnit.equippedGearOrInitial);
        UnitProficiencyIncr proficiencyIncr = playerUnit.ProficiencyIncr;
        Judgement.BeforeDuelUnitParameter duelUnitParameter = new Judgement.BeforeDuelUnitParameter();
        float elementOrKindRatio = playerUnit.GetElementOrKindRatio(beTarget.originalUnit.playerUnit);
        Tuple<int, int> gearKindIncr = playerUnit.GetGearKindIncr(beTarget.originalUnit.playerUnit);
        BattleFuncs.BeforeDuelDuelSupport beforeDuelDuelSupport = BattleFuncs.GetBeforeDuelDuelSupport(beUnit, beTarget, neighborUnits);
        int power = beMagicBullet != null ? beMagicBullet.power : 0;
        BattleLandformIncr incr = landform.GetIncr(playerUnit.unit);
        BattleLandformIncr.LandformDuelSkillIncr duelSkillIncr = incr.GetDuelSkillIncr(beUnit.originalUnit, beTarget.originalUnit, attackType);
        int blessingSkillAdd1 = BattleFuncs.GetLandBlessingSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_fix_physical_defense, landform, (BattleLandformEffectPhase) 0);
        int blessingSkillAdd2 = BattleFuncs.GetLandBlessingSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_fix_magic_defense, landform, (BattleLandformEffectPhase) 0);
        int blessingSkillAdd3 = BattleFuncs.GetLandBlessingSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_fix_hit, landform, (BattleLandformEffectPhase) 0);
        int blessingSkillAdd4 = BattleFuncs.GetLandBlessingSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_fix_critical, landform, (BattleLandformEffectPhase) 0);
        int blessingSkillAdd5 = BattleFuncs.GetLandBlessingSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_fix_evasion, landform, (BattleLandformEffectPhase) 0);
        float blessingSkillMul1 = BattleFuncs.GetLandBlessingSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_ratio_physical_defense, landform, (BattleLandformEffectPhase) 0);
        float blessingSkillMul2 = BattleFuncs.GetLandBlessingSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_ratio_magic_defense, landform, (BattleLandformEffectPhase) 0);
        float blessingSkillMul3 = BattleFuncs.GetLandBlessingSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_ratio_hit, landform, (BattleLandformEffectPhase) 0);
        float blessingSkillMul4 = BattleFuncs.GetLandBlessingSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_ratio_critical, landform, (BattleLandformEffectPhase) 0);
        float blessingSkillMul5 = BattleFuncs.GetLandBlessingSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.land_blessing_ratio_evasion, landform, (BattleLandformEffectPhase) 0);
        float num37 = num19 * duelSkillIncr.skillMulHp;
        float num38 = num20 * duelSkillIncr.skillMulStrength;
        float num39 = num21 * duelSkillIncr.skillMulIntelligence;
        float num40 = num22 * duelSkillIncr.skillMulVitality;
        float num41 = num23 * duelSkillIncr.skillMulMind;
        float num42 = num24 * duelSkillIncr.skillMulAgility;
        float num43 = num25 * duelSkillIncr.skillMulDexterity;
        float num44 = num26 * duelSkillIncr.skillMulLuck;
        float num45 = num27 * duelSkillIncr.skillMulMove;
        duelUnitParameter.Hp = (int) ((double) playerUnit.total_hp * (double) num37 / 10000.0 + (double) gearParameter.Hp + (double) skillAdd + (double) duelSkillIncr.skillAddHp);
        duelUnitParameter.Strength = (int) ((double) playerUnit.total_strength * (double) num38 / 10000.0 + (double) gearParameter.Strength + (double) num2 + (double) duelSkillIncr.skillAddStrength);
        duelUnitParameter.Intelligence = (int) ((double) playerUnit.total_intelligence * (double) num39 / 10000.0 + (double) gearParameter.Intelligence + (double) num3 + (double) duelSkillIncr.skillAddIntelligence);
        duelUnitParameter.Vitality = (int) ((double) playerUnit.total_vitality * (double) num40 / 10000.0 + (double) gearParameter.Vitality + (double) num4 + (double) duelSkillIncr.skillAddVitality);
        duelUnitParameter.Mind = (int) ((double) playerUnit.total_mind * (double) num41 / 10000.0 + (double) gearParameter.Mind + (double) num5 + (double) duelSkillIncr.skillAddMind);
        duelUnitParameter.Agility = (int) ((double) playerUnit.total_agility * (double) num42 / 10000.0 + (double) gearParameter.Agility + (double) num6 + (double) duelSkillIncr.skillAddAgility);
        duelUnitParameter.Dexterity = (int) ((double) playerUnit.total_dexterity * (double) num43 / 10000.0 + (double) gearParameter.Dexterity + (double) num7 + (double) duelSkillIncr.skillAddDexterity);
        duelUnitParameter.Luck = (int) ((double) playerUnit.total_lucky * (double) num44 / 10000.0 + (double) gearParameter.Luck + (double) num8 + (double) duelSkillIncr.skillAddLuck);
        duelUnitParameter.Move = (int) ((double) playerUnit.move * (double) num45 / 10000.0 + (double) num9 + (double) duelSkillIncr.skillAddMove);
        float num46 = num28 * duelSkillIncr.skillMulPhysicalAttack;
        float num47 = num29 * duelSkillIncr.skillMulPhysicalDefense;
        float num48 = num30 * duelSkillIncr.skillMulMagicAttack;
        float num49 = num31 * duelSkillIncr.skillMulMagicDefense;
        float num50 = num32 * duelSkillIncr.skillMulHit;
        float num51 = num33 * duelSkillIncr.skillMulCritical;
        float num52 = num34 * duelSkillIncr.skillMulEvasion;
        float num53 = num35 * duelSkillIncr.skillMulCriticalEvasion;
        duelUnitParameter.PhysicalAttack = (int) (((double) duelUnitParameter.Strength + (double) gearParameter.Power * (double) elementOrKindRatio + (double) proficiencyIncr.physical_attack) * (double) num46 / 10000.0 + (double) num10 + (double) duelSkillIncr.skillAddPhysicalAttack + (double) gearKindIncr.Item1);
        duelUnitParameter.PhysicalDefense = (int) ((double) (duelUnitParameter.Vitality + gearParameter.PhysicalDefense) * (double) num47 / 10000.0 + (double) num11 + (double) duelSkillIncr.skillAddPhysicalDefense + (double) Mathf.Ceil((float) incr.physical_defense_incr * blessingSkillMul1) + (double) blessingSkillAdd1);
        duelUnitParameter.MagicAttack = (int) (((double) (duelUnitParameter.Intelligence + power) + (double) gearParameter.Power * (double) elementOrKindRatio + (double) proficiencyIncr.magic_attack) * (double) num48 / 10000.0 + (double) num12 + (double) duelSkillIncr.skillAddMagicAttack + (double) gearKindIncr.Item1);
        duelUnitParameter.MagicDefense = (int) ((double) (duelUnitParameter.Mind + gearParameter.MagicDefense) * (double) num49 / 10000.0 + (double) num13 + (double) duelSkillIncr.skillAddMagicDefense + (double) Mathf.Ceil((float) incr.magic_defense_incr * blessingSkillMul2) + (double) blessingSkillAdd2);
        duelUnitParameter.Hit = (int) ((double) ((duelUnitParameter.Dexterity * 3 + duelUnitParameter.Luck) / 2 + gearParameter.Hit + proficiencyIncr.hit) * (double) num50 / 10000.0 + (double) num14 + (double) duelSkillIncr.skillAddHit + (double) gearKindIncr.Item2 + (double) beforeDuelDuelSupport.hit + (double) Mathf.Ceil((float) incr.hit_incr * blessingSkillMul3) + (double) blessingSkillAdd3);
        duelUnitParameter.Critical = (int) ((double) (duelUnitParameter.Dexterity / 2 + gearParameter.Critical) * (double) num51 / 10000.0 + (double) num15 + (double) duelSkillIncr.skillAddCritical + (double) beforeDuelDuelSupport.critical + (double) Mathf.Ceil((float) incr.critical_incr * blessingSkillMul4) + (double) blessingSkillAdd4);
        duelUnitParameter.Evasion = (int) ((double) ((duelUnitParameter.Agility * 3 + duelUnitParameter.Luck) / 2 + gearParameter.Evasion + proficiencyIncr.evasion) * (double) num52 / 10000.0 + (double) num16 + (double) duelSkillIncr.skillAddEvasion + (double) beforeDuelDuelSupport.evasion + (double) Mathf.Ceil((float) incr.evasion_incr * blessingSkillMul5) + (double) blessingSkillAdd5);
        duelUnitParameter.CriticalEvasion = (int) ((double) duelUnitParameter.Luck * (double) num53 / 10000.0 + (double) num17 + (double) duelSkillIncr.skillAddCriticalEvasion + (double) beforeDuelDuelSupport.criticalEvasion);
        duelUnitParameter.AttackSpeed = (int) ((double) (duelUnitParameter.Agility - playerUnit.equippedGearOrInitial.weight - (beMagicBullet != null ? beMagicBullet.weight : 0)) * (double) num36 / 10000.0 + (double) num18);
        if (BattleFuncs.isCriticalGuardEnable(beTarget, beUnit))
          duelUnitParameter.Critical = 0;
        duelUnitParameter.IsDontEvasion = beUnit.IsDontEvasion;
        return duelUnitParameter;
      }

      public static Judgement.BeforeDuelUnitParameter FromBeColosseumUnit(
        BL.Unit beUnit,
        BL.Unit beTarget,
        BL.Unit[] neighborUnits,
        BL.MagicBullet beMagicBullet,
        PlayerItem equipped_gear,
        int attackType,
        BL.Unit[] deckUnits,
        BL.Unit[] targetDeckUnits,
        int attackHp,
        int battleCount)
      {
        float hpRatio = (float) ((double) attackHp / (double) beUnit.parameter.Hp * 100.0);
        int skillAdd = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_hp, BattleskillInvokeGameModeEnum.colosseum, true);
        int num1 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_strength, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_strength, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_strength, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_strength, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_strength, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_strength, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_strength, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_strength, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_strength, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_strength, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_strength) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_strength_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_strength, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_strength, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_strength, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num2 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_intelligence, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_intelligence, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_intelligence, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_intelligence, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_intelligence, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_intelligence, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_intelligence, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_intelligence, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_intelligence, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_intelligence, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_intelligence) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_intelligence_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_intelligence, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_intelligence, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_intelligence, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num3 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_vitality, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_vitality, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_vitality, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_vitality, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_vitality, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_vitality, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_vitality, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_vitality, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_vitality, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_vitality, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_vitality) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_vitality_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_vitality, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_vitality, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_vitality, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num4 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_mind, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_mind, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_mind, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_mind, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_mind, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_mind, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_mind, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_mind, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_mind, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_mind, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_mind) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_mind_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_mind, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_mind, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_mind, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num5 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_agility, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_agility, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_agility, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_agility, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_agility, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_agility, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_agility, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_agility, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_agility, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_agility, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_agility) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_agility_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_agility, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_agility, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_agility, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num6 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_dexterity, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_dexterity, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_dexterity, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_dexterity, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_dexterity, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_dexterity, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_dexterity, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_dexterity, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_dexterity, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_dexterity, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_dexterity) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_dexterity_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_dexterity, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_dexterity, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_dexterity, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num7 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_luck, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_luck, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_luck, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_luck, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_luck, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_luck, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_luck, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_luck, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_luck, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_luck, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_luck) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_luck_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_luck, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_luck, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_luck, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num8 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_move, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_move, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_move, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_move, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_move, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_move, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_move, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_move, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_move, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_move, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_move) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_move_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_move, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_move, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_move, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num9 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_physical_attack, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_physical_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_physical_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_physical_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_physical_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_physical_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_physical_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_physical_attack, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_physical_attack, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_physical_attack, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_physical_attack) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_physical_attack_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_physical_attack, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_physical_attack, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_physical_attack, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num10 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_physical_defense, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_physical_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_physical_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_physical_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_physical_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_physical_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_physical_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_physical_defense, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_physical_defense, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_physical_defense, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_physical_defense) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_physical_defense_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_physical_defense, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_physical_defense, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_physical_defense, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num11 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_magic_attack, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_magic_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_magic_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_magic_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_magic_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_magic_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_magic_attack, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_magic_attack, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_magic_attack, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_magic_attack, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_magic_attack) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_magic_attack_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_magic_attack, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_magic_attack, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_magic_attack, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num12 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_magic_defense, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_magic_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_magic_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_magic_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_magic_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_magic_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_magic_defense, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_magic_defense, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_magic_defense, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_magic_defense, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_magic_defense) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_magic_defense_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_magic_defense, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_magic_defense, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_magic_defense, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num13 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_hit, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_hit, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_hit, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_hit, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_hit, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_hit, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_hit, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_hit, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_hit, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_hit, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_hit) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_hit_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_hit, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_hit, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_hit, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num14 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_critical, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_critical, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_critical, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_critical, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_critical, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_critical, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_critical, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_critical, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_critical, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_critical, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_critical) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_critical_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_critical, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_critical, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_critical, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num15 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_evasion, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_evasion, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_evasion, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_evasion, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_evasion) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_evasion_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_evasion, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_evasion, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_evasion, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num16 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_critical_evasion, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_critical_evasion, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_critical_evasion, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_critical_evasion, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_critical_evasion) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_critical_evasion_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_critical_evasion, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_critical_evasion, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_critical_evasion, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        int num17 = Judgement.BeforeDuelUnitParameter.GetSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.fix_attack_speed, BattleskillInvokeGameModeEnum.colosseum) + Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_fix_attack_speed, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_fix_attack_speed, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_fix_attack_speed, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_fix_attack_speed, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_fix_attack_speed, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_fix_attack_speed, (IEnumerable<BL.Unit>) deckUnits) + Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_fix_attack_speed, false) + Judgement.BeforeDuelUnitParameter.GetHpLeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_fix_attack_speed, hpRatio) + Judgement.BeforeDuelUnitParameter.GetHpGeSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_fix_attack_speed, hpRatio) + Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_fix_attack_speed) + Judgement.BeforeDuelUnitParameter.GetEquipGearSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_attack_speed_fix) + Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_fix_attack_speed, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_fix_attack_speed, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) + Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillAdd((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_fix_attack_speed, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num18 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_hp, BattleskillInvokeGameModeEnum.colosseum, true);
        float num19 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_strength, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_strength, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_strength, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_strength, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_strength, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_strength, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_strength, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_strength, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_strength, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_strength, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_strength) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_strength_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_strength, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_strength, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_strength, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num20 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_intelligence, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_intelligence, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_intelligence, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_intelligence, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_intelligence, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_intelligence, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_intelligence, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_intelligence, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_intelligence, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_intelligence, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_intelligence) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_intelligence_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_intelligence, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_intelligence, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_intelligence, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num21 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_vitality, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_vitality, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_vitality, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_vitality, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_vitality, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_vitality, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_vitality, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_vitality, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_vitality, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_vitality, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_vitality) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_vitality_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_vitality, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_vitality, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_vitality, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num22 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_mind, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_mind, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_mind, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_mind, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_mind, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_mind, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_mind, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_mind, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_mind, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_mind, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_mind) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_mind_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_mind, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_mind, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_mind, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num23 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_agility, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_agility, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_agility, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_agility, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_agility, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_agility, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_agility, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_agility, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_agility, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_agility, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_agility) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_agility_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_agility, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_agility, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_agility, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num24 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_dexterity, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_dexterity, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_dexterity, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_dexterity, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_dexterity, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_dexterity, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_dexterity, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_dexterity, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_dexterity, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_dexterity, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_dexterity) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_dexterity_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_dexterity, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_dexterity, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_dexterity, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num25 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_luck, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_luck, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_luck, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_luck, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_luck, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_luck, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_luck, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_luck, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_luck, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_luck, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_luck) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_luck_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_luck, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_luck, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_luck, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num26 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_move, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_move, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_move, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_move, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_move, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_move, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_move, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_move, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_move, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_move, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_move) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_move_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_move, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_move, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_move, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num27 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_physical_attack, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_physical_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_physical_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_physical_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_physical_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_physical_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_physical_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_physical_attack, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_physical_attack, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_physical_attack, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_physical_attack) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_physical_attack_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_physical_attack, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_physical_attack, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_physical_attack, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num28 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_physical_defense, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_physical_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_physical_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_physical_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_physical_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_physical_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_physical_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_physical_defense, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_physical_defense, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_physical_defense, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_physical_defense) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_physical_defense_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_physical_defense, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_physical_defense, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_physical_defense, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num29 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_magic_attack, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_magic_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_magic_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_magic_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_magic_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_magic_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_magic_attack, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_magic_attack, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_magic_attack, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_magic_attack, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_magic_attack) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_magic_attack_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_magic_attack, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_magic_attack, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_magic_attack, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num30 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_magic_defense, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_magic_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_magic_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_magic_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_magic_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_magic_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_magic_defense, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_magic_defense, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_magic_defense, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_magic_defense, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_magic_defense) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_magic_defense_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_magic_defense, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_magic_defense, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_magic_defense, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num31 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_hit, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_hit, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_hit, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_hit, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_hit, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_hit, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_hit, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_hit, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_hit, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_hit, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_hit) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_hit_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_hit, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_hit, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_hit, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num32 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_critical, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_critical, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_critical, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_critical, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_critical, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_critical, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_critical, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_critical, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_critical, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_critical, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_critical) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_critical_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_critical, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_critical, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_critical, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num33 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_evasion, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_evasion, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_evasion, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_evasion, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_evasion) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_evasion_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_evasion, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_evasion, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_evasion, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num34 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_critical_evasion, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_critical_evasion, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_critical_evasion, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_critical_evasion, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_critical_evasion, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_critical_evasion) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_critical_evasion_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_critical_evasion, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_critical_evasion, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_critical_evasion, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        float num35 = 10000f * Judgement.BeforeDuelUnitParameter.GetSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, attackType, BattleskillEffectLogicEnum.ratio_attack_speed, BattleskillInvokeGameModeEnum.colosseum) * Judgement.BeforeDuelUnitParameter.GetDeckEveryGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_ge_ratio_attack_speed, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckEveryLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_every_le_ratio_attack_speed, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_ge_ratio_attack_speed, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckAnotherLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_another_le_ratio_attack_speed, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_ge_ratio_attack_speed, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetDeckSameLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.deck_same_le_ratio_attack_speed, (IEnumerable<BL.Unit>) deckUnits) * Judgement.BeforeDuelUnitParameter.GetSpecificUnitSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.specific_unit_ratio_attack_speed, false) * Judgement.BeforeDuelUnitParameter.GetHpLeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_le_ratio_attack_speed, hpRatio) * Judgement.BeforeDuelUnitParameter.GetHpGeSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.hp_ge_ratio_attack_speed, hpRatio) * Judgement.BeforeDuelUnitParameter.GetUnitRaritySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.unit_rarity_ratio_attack_speed) * Judgement.BeforeDuelUnitParameter.GetEquipGearSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.equip_attack_speed_ratio) * Judgement.BeforeDuelUnitParameter.GetDeadCountPlayerSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_player_ratio_attack_speed, battleCount, (IEnumerable<BL.Unit>) deckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountEnemySkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_enemy_ratio_attack_speed, battleCount, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false) * Judgement.BeforeDuelUnitParameter.GetDeadCountComplexSkillMul((BL.ISkillEffectListUnit) beUnit, (BL.ISkillEffectListUnit) beTarget, BattleskillEffectLogicEnum.dead_count_complex_ratio_attack_speed, battleCount, (IEnumerable<BL.Unit>) deckUnits, (IEnumerable<BL.Unit>) targetDeckUnits, BattleskillInvokeGameModeEnum.colosseum, false);
        PlayerUnit playerUnit = beUnit.playerUnit;
        Judgement.GearParameter gearParameter = !(equipped_gear == (PlayerItem) null) ? Judgement.GearParameter.FromPlayerGear(equipped_gear) : Judgement.GearParameter.FromGearGear(playerUnit.unit.initial_gear);
        UnitProficiencyIncr proficiencyIncr = playerUnit.ProficiencyIncr;
        Judgement.BeforeDuelUnitParameter duelUnitParameter = new Judgement.BeforeDuelUnitParameter();
        float elementOrKindRatio = playerUnit.GetElementOrKindRatio(beTarget.playerUnit);
        Tuple<int, int> gearKindIncr = playerUnit.GetGearKindIncr(beTarget.playerUnit);
        IntimateDuelSupport intimateDuelSupport = playerUnit.GetIntimateDuelSupport(((IEnumerable<BL.Unit>) neighborUnits).Select<BL.Unit, PlayerUnit>((Func<BL.Unit, PlayerUnit>) (x => x.playerUnit)).ToArray<PlayerUnit>());
        int power = beMagicBullet != null ? beMagicBullet.power : 0;
        duelUnitParameter.Hp = (int) ((double) playerUnit.total_hp * (double) num18 / 10000.0 + (double) gearParameter.Hp + (double) skillAdd);
        duelUnitParameter.Strength = (int) ((double) playerUnit.total_strength * (double) num19 / 10000.0 + (double) gearParameter.Strength + (double) num1);
        duelUnitParameter.Intelligence = (int) ((double) playerUnit.total_intelligence * (double) num20 / 10000.0 + (double) gearParameter.Intelligence + (double) num2);
        duelUnitParameter.Vitality = (int) ((double) playerUnit.total_vitality * (double) num21 / 10000.0 + (double) gearParameter.Vitality + (double) num3);
        duelUnitParameter.Mind = (int) ((double) playerUnit.total_mind * (double) num22 / 10000.0 + (double) gearParameter.Mind + (double) num4);
        duelUnitParameter.Agility = (int) ((double) playerUnit.total_agility * (double) num23 / 10000.0 + (double) gearParameter.Agility + (double) num5);
        duelUnitParameter.Dexterity = (int) ((double) playerUnit.total_dexterity * (double) num24 / 10000.0 + (double) gearParameter.Dexterity + (double) num6);
        duelUnitParameter.Luck = (int) ((double) playerUnit.total_lucky * (double) num25 / 10000.0 + (double) gearParameter.Luck + (double) num7);
        duelUnitParameter.Move = (int) ((double) playerUnit.move * (double) num26 / 10000.0 + (double) num8);
        duelUnitParameter.PhysicalAttack = (int) (((double) duelUnitParameter.Strength + (double) gearParameter.Power * (double) elementOrKindRatio + (double) proficiencyIncr.physical_attack) * (double) num27 / 10000.0 + (double) num9 + (double) gearKindIncr.Item1);
        duelUnitParameter.PhysicalDefense = (int) ((double) (duelUnitParameter.Vitality + gearParameter.PhysicalDefense) * (double) num28 / 10000.0 + (double) num10);
        duelUnitParameter.MagicAttack = (int) (((double) (duelUnitParameter.Intelligence + power) + (double) gearParameter.Power * (double) elementOrKindRatio + (double) proficiencyIncr.magic_attack) * (double) num29 / 10000.0 + (double) num11 + (double) gearKindIncr.Item1);
        duelUnitParameter.MagicDefense = (int) ((double) (duelUnitParameter.Mind + gearParameter.MagicDefense) * (double) num30 / 10000.0 + (double) num12);
        duelUnitParameter.Hit = (int) ((double) ((duelUnitParameter.Dexterity * 3 + duelUnitParameter.Luck) / 2 + gearParameter.Hit + proficiencyIncr.hit) * (double) num31 / 10000.0 + (double) num13 + (double) gearKindIncr.Item2 + (double) intimateDuelSupport.hit);
        duelUnitParameter.Critical = (int) ((double) (duelUnitParameter.Dexterity / 2 + gearParameter.Critical) * (double) num32 / 10000.0 + (double) num14 + (double) intimateDuelSupport.critical);
        duelUnitParameter.Evasion = (int) ((double) ((duelUnitParameter.Agility * 3 + duelUnitParameter.Luck) / 2 + gearParameter.Evasion + proficiencyIncr.evasion) * (double) num33 / 10000.0 + (double) num15 + (double) intimateDuelSupport.evasion);
        duelUnitParameter.CriticalEvasion = (int) ((double) duelUnitParameter.Luck * (double) num34 / 10000.0 + (double) num16 + (double) intimateDuelSupport.critical_evasion);
        duelUnitParameter.AttackSpeed = (int) ((double) (duelUnitParameter.Agility - playerUnit.equippedGearOrInitial.weight - (beMagicBullet != null ? beMagicBullet.weight : 0)) * (double) num35 / 10000.0 + (double) num17);
        if (BattleFuncs.isCriticalGuardEnable((BL.ISkillEffectListUnit) beTarget, (BL.ISkillEffectListUnit) beUnit))
          duelUnitParameter.Critical = 0;
        duelUnitParameter.IsDontEvasion = beUnit.IsDontEvasion;
        return duelUnitParameter;
      }

      public class FromBeUnitData
      {
        public int move_distance;
        public int move_range;
        public int attackHp;
        public BL.ForceID[] targetForceId;
        public BL.Panel panel;
        public BL.ISkillEffectListUnit raidMissionUnit;
        public Dictionary<BL.ISkillEffectListUnit, int>[] charismaUnitDistance;
        public IEnumerable<BL.Unit> deckUnits;
        public IEnumerable<BL.Unit> targetDeckUnits;
        public bool isHeal;
        public bool isAI;
      }
    }

    [Serializable]
    public class BeforeDuelParameter
    {
      public int AttackCount;
      public int? FixDamage;
      public int? HitMin;
      public int? HitMax;
      public int? FixHit;
      public float DamageRate;
      public int BaseDamage;

      public int DisplayPhysicalAttack => (int) this.CalcPhysicalAttack(1f);

      public int DisplayMagicAttack => (int) this.CalcMagicAttack(1f);

      public float CalcPhysicalAttack(float rate)
      {
        return this.CalcAttack(this.attackerUnitParameter.PhysicalAttack, this.defenderUnitParameter.PhysicalDefense, rate);
      }

      public float CalcMagicAttack(float rate)
      {
        return this.CalcAttack(this.attackerUnitParameter.MagicAttack, this.defenderUnitParameter.MagicDefense, rate);
      }

      private float CalcAttack(int attack, int defense, float rate)
      {
        return Mathf.Max(1f, (float) NC.Clamp(1, int.MaxValue, !this.FixDamage.HasValue ? (int) ((double) attack * (double) rate - (double) defense) : (int) ((double) this.FixDamage.Value * (double) rate)) * this.DamageRate) + (float) this.BaseDamage;
      }

      public int DisplayHit
      {
        get
        {
          if (this.defenderUnitParameter.IsDontEvasion)
            return 100;
          int displayHit = !this.FixHit.HasValue ? this.attackerUnitParameter.Hit - this.defenderUnitParameter.Evasion : this.FixHit.Value;
          if (this.HitMax.HasValue && displayHit > this.HitMax.Value)
            displayHit = this.HitMax.Value;
          if (this.HitMin.HasValue && displayHit < this.HitMin.Value)
            displayHit = this.HitMin.Value;
          return displayHit;
        }
      }

      public int DisplayCritical
      {
        get => this.attackerUnitParameter.Critical - this.defenderUnitParameter.CriticalEvasion;
      }

      public Judgement.BeforeDuelUnitParameter attackerUnitParameter { get; protected set; }

      public Judgement.BeforeDuelUnitParameter defenderUnitParameter { get; protected set; }

      public static Judgement.BeforeDuelParameter CreateSingle(
        BL.ISkillEffectListUnit beAttackUnit,
        BL.MagicBullet beAttackMagicBullet,
        BattleLandform attackPanel,
        BL.Unit[] beAttackNeighborUnits,
        BL.ISkillEffectListUnit beDefenseUnit,
        BL.MagicBullet beDefenseMagicBullet,
        BattleLandform defensePanel,
        BL.Unit[] beDefenseNeighborUnits,
        bool isAttack,
        int distance = 0,
        int move_distance = 0,
        int move_range = -1,
        int attackHp = 0,
        int defenseHp = 0,
        BL.ForceID[] attackTargetForceId = null,
        BL.ForceID[] defenceTargetForceId = null,
        BL.Panel blAttackPanel = null,
        BL.Panel blDefencePanel = null,
        IEnumerable<BL.Unit> beAttackDeckUnits = null,
        IEnumerable<BL.Unit> beDefenseDeckUnits = null,
        IEnumerable<BL.Unit> beAttackTargetDeckUnits = null,
        IEnumerable<BL.Unit> beDefenseTargetDeckUnits = null,
        bool isHeal = false,
        bool isAI = false)
      {
        BL.ISkillEffectListUnit skillEffectListUnit = !isAttack || isHeal || blDefencePanel == null || blAttackPanel == null || BattleFuncs.isCounterAttack(beAttackUnit, blAttackPanel, beAttackNeighborUnits, beDefenseUnit, blDefencePanel, beDefenseNeighborUnits, defenseHp, isAI) ? (BL.ISkillEffectListUnit) null : beAttackUnit;
        BL.ISkillEffectListUnit beMoveUnit = !isAttack ? beDefenseUnit : beAttackUnit;
        Dictionary<BL.ISkillEffectListUnit, int>[] charismaUnitDistance = Judgement.BeforeDuelParameter.MakeCharismaUnitDistance(beAttackUnit, attackTargetForceId, blAttackPanel, beMoveUnit, !isAttack ? distance : 0, isAI);
        Dictionary<BL.ISkillEffectListUnit, int>[] dictionaryArray = Judgement.BeforeDuelParameter.MakeCharismaUnitDistance(beDefenseUnit, defenceTargetForceId, blDefencePanel, beMoveUnit, isAttack ? distance : 0, isAI);
        Judgement.BeforeDuelUnitParameter.FromBeUnitData data = new Judgement.BeforeDuelUnitParameter.FromBeUnitData()
        {
          move_distance = !isAttack ? 0 : move_distance,
          move_range = !isAttack ? -1 : move_range,
          attackHp = attackHp,
          targetForceId = attackTargetForceId,
          panel = blAttackPanel,
          raidMissionUnit = skillEffectListUnit,
          charismaUnitDistance = charismaUnitDistance,
          deckUnits = beAttackDeckUnits,
          targetDeckUnits = beAttackTargetDeckUnits,
          isHeal = isHeal,
          isAI = isAI
        };
        Judgement.BeforeDuelUnitParameter attack = Judgement.BeforeDuelUnitParameter.FromBeUnit(beAttackUnit, beDefenseUnit, attackPanel, beAttackNeighborUnits, beAttackMagicBullet, !isAttack ? 2 : 1, distance, data);
        data.move_distance = isAttack ? 0 : move_distance;
        data.move_range = isAttack ? -1 : move_range;
        data.attackHp = defenseHp;
        data.targetForceId = defenceTargetForceId;
        data.panel = blDefencePanel;
        data.charismaUnitDistance = dictionaryArray;
        data.deckUnits = beDefenseDeckUnits;
        data.targetDeckUnits = beDefenseTargetDeckUnits;
        Judgement.BeforeDuelUnitParameter defense = Judgement.BeforeDuelUnitParameter.FromBeUnit(beDefenseUnit, beAttackUnit, defensePanel, beDefenseNeighborUnits, beDefenseMagicBullet, !isAttack ? 1 : 2, distance, data);
        Judgement.BeforeDuelParameter single = new Judgement.BeforeDuelParameter()
        {
          attackerUnitParameter = attack,
          defenderUnitParameter = defense
        };
        single.AttackCount = BattleFuncs.attackCount(beAttackUnit, beDefenseUnit);
        if (BattleFuncs.canOneMore(attack, defense, beAttackUnit, beDefenseUnit))
          single.AttackCount *= 2;
        single.FixDamage = Judgement.BeforeDuelParameter.MakeFixDamage(beAttackUnit, beAttackMagicBullet, defenseHp > 0 ? defenseHp : beDefenseUnit.hp);
        Tuple<int?, int?, int?> tuple = Judgement.BeforeDuelParameter.MakeFixHit(beAttackUnit, beDefenseUnit, beAttackMagicBullet, charismaUnitDistance);
        single.HitMin = tuple.Item1;
        single.HitMax = tuple.Item2;
        single.FixHit = tuple.Item3;
        single.DamageRate = Judgement.BeforeDuelParameter.MakeDamageRate(beAttackUnit, beDefenseUnit, charismaUnitDistance);
        single.BaseDamage = Judgement.BeforeDuelParameter.MakeBaseDamage(beAttackUnit, beDefenseUnit);
        return single;
      }

      public static Judgement.BeforeDuelParameter CreateDuelSkill(
        BL.ISkillEffectListUnit beAttackUnit,
        BL.MagicBullet beAttackMagicBullet,
        BattleLandform attackPanel,
        BL.ISkillEffectListUnit beDefenseUnit,
        BattleLandform defensePanel,
        int distance = 0,
        int defenseHp = 0)
      {
        Judgement.BeforeDuelUnitParameter duelUnitParameter1 = Judgement.BeforeDuelUnitParameter.FromBeUnit(beAttackUnit, beDefenseUnit, attackPanel, new BL.Unit[0], beAttackMagicBullet, 0, distance);
        Judgement.BeforeDuelUnitParameter duelUnitParameter2 = Judgement.BeforeDuelUnitParameter.FromBeUnit(beDefenseUnit, beAttackUnit, defensePanel, new BL.Unit[0], (BL.MagicBullet) null, 0, distance);
        Judgement.BeforeDuelParameter duelSkill = new Judgement.BeforeDuelParameter()
        {
          attackerUnitParameter = duelUnitParameter1,
          defenderUnitParameter = duelUnitParameter2
        };
        duelSkill.FixDamage = Judgement.BeforeDuelParameter.MakeFixDamage(beAttackUnit, beAttackMagicBullet, defenseHp);
        Tuple<int?, int?, int?> tuple = Judgement.BeforeDuelParameter.MakeFixHit(beAttackUnit, beDefenseUnit, beAttackMagicBullet);
        duelSkill.HitMin = tuple.Item1;
        duelSkill.HitMax = tuple.Item2;
        duelSkill.FixHit = tuple.Item3;
        duelSkill.DamageRate = Judgement.BeforeDuelParameter.MakeDamageRate(beAttackUnit, beDefenseUnit);
        duelSkill.BaseDamage = Judgement.BeforeDuelParameter.MakeBaseDamage(beAttackUnit, beDefenseUnit);
        return duelSkill;
      }

      public static Judgement.BeforeDuelParameter CreateColosseumSingle(
        BL.Unit beAttackUnit,
        BL.MagicBullet beAttackMagicBullet,
        BL.Unit[] beAttackNeighborUnits,
        BL.Unit[] beAttackDeckUnits,
        PlayerItem beAttackEquippedGear,
        BL.Unit beDefenseUnit,
        BL.MagicBullet beDefenseMagicBullet,
        BL.Unit[] beDefenseNeighborUnits,
        BL.Unit[] beDefenseDeckUnits,
        PlayerItem beDefenseEquippedGear,
        bool isAttack,
        bool isSample,
        int attackHp,
        int defenseHp,
        int battleCount)
      {
        Judgement.BeforeDuelUnitParameter attack = Judgement.BeforeDuelUnitParameter.FromBeColosseumUnit(beAttackUnit, beDefenseUnit, beAttackNeighborUnits, beAttackMagicBullet, beAttackEquippedGear, !isSample ? (!isAttack ? 2 : 1) : 0, beAttackDeckUnits, beDefenseDeckUnits, attackHp, battleCount);
        Judgement.BeforeDuelUnitParameter defense = Judgement.BeforeDuelUnitParameter.FromBeColosseumUnit(beDefenseUnit, beAttackUnit, beDefenseNeighborUnits, beDefenseMagicBullet, beDefenseEquippedGear, !isSample ? (!isAttack ? 1 : 2) : 0, beDefenseDeckUnits, beAttackDeckUnits, defenseHp, battleCount);
        Judgement.BeforeDuelParameter colosseumSingle = new Judgement.BeforeDuelParameter()
        {
          attackerUnitParameter = attack,
          defenderUnitParameter = defense
        };
        colosseumSingle.AttackCount = BattleFuncs.attackCount((BL.ISkillEffectListUnit) beAttackUnit, (BL.ISkillEffectListUnit) beDefenseUnit);
        if (BattleFuncs.canOneMore(attack, defense, (BL.ISkillEffectListUnit) beAttackUnit, (BL.ISkillEffectListUnit) beDefenseUnit))
          colosseumSingle.AttackCount *= 2;
        colosseumSingle.FixDamage = Judgement.BeforeDuelParameter.MakeFixDamage((BL.ISkillEffectListUnit) beAttackUnit, beAttackMagicBullet, defenseHp);
        Tuple<int?, int?, int?> tuple = Judgement.BeforeDuelParameter.MakeFixHit((BL.ISkillEffectListUnit) beAttackUnit, (BL.ISkillEffectListUnit) beDefenseUnit, beAttackMagicBullet);
        colosseumSingle.HitMin = tuple.Item1;
        colosseumSingle.HitMax = tuple.Item2;
        colosseumSingle.FixHit = tuple.Item3;
        colosseumSingle.DamageRate = Judgement.BeforeDuelParameter.MakeDamageRate((BL.ISkillEffectListUnit) beAttackUnit, (BL.ISkillEffectListUnit) beDefenseUnit);
        colosseumSingle.BaseDamage = Judgement.BeforeDuelParameter.MakeBaseDamage((BL.ISkillEffectListUnit) beAttackUnit, (BL.ISkillEffectListUnit) beDefenseUnit);
        return colosseumSingle;
      }

      public static Tuple<Judgement.BeforeDuelParameter, Judgement.BeforeDuelParameter> CreatePair(
        BL.Unit beAttackUnit,
        BL.MagicBullet beAttackMagicBullet,
        BattleLandform attackPanel,
        BL.Unit[] beAttackNeighborUnits,
        BL.Unit beDefenseUnit,
        BL.MagicBullet beDefenseMagicBullet,
        BattleLandform defensePanel,
        BL.Unit[] beDefenseNeighborUnits)
      {
        return Tuple.Create<Judgement.BeforeDuelParameter, Judgement.BeforeDuelParameter>(Judgement.BeforeDuelParameter.CreateSingle((BL.ISkillEffectListUnit) beAttackUnit, beAttackMagicBullet, attackPanel, beAttackNeighborUnits, (BL.ISkillEffectListUnit) beDefenseUnit, beDefenseMagicBullet, defensePanel, beDefenseNeighborUnits, true), Judgement.BeforeDuelParameter.CreateSingle((BL.ISkillEffectListUnit) beDefenseUnit, beDefenseMagicBullet, defensePanel, beDefenseNeighborUnits, (BL.ISkillEffectListUnit) beAttackUnit, beAttackMagicBullet, attackPanel, beAttackNeighborUnits, false));
      }

      private static int? MakeFixDamage(
        BL.ISkillEffectListUnit beAttackUnit,
        BL.MagicBullet beAttackMagicBullet,
        int defenderHp)
      {
        if (beAttackMagicBullet != null)
        {
          BattleskillEffect percentageDamage = beAttackMagicBullet.percentageDamage;
          if (percentageDamage != null)
            return new int?(BattleFuncs.calcPercentageDamage(defenderHp, percentageDamage.GetFloat("percentage")));
        }
        return beAttackUnit.originalUnit.weapon.gear.fix_damage;
      }

      private static Tuple<int?, int?, int?> MakeFixHit(
        BL.ISkillEffectListUnit beAttackUnit,
        BL.ISkillEffectListUnit beDefenseUnit,
        BL.MagicBullet beAttackMagicBullet,
        Dictionary<BL.ISkillEffectListUnit, int>[] charismaUnitDistance = null)
      {
        float? nullable1 = new float?();
        if (beAttackMagicBullet != null)
        {
          BattleskillEffect percentageDamage = beAttackMagicBullet.percentageDamage;
          if (percentageDamage != null)
          {
            float num = percentageDamage.GetFloat("hit_value");
            if ((double) num > 0.0)
              nullable1 = new float?(num);
          }
        }
        Tuple<float?, float?> clampHitEffect = BattleFuncs.getClampHitEffect(beAttackUnit, beDefenseUnit);
        float? nullable2 = clampHitEffect.Item1;
        float? nullable3 = clampHitEffect.Item2;
        if (charismaUnitDistance != null)
        {
          for (int target = 0; target <= 1; ++target)
          {
            foreach (BL.ISkillEffectListUnit key in charismaUnitDistance[target].Keys)
            {
              BL.ISkillEffectListUnit effectUnit = key;
              int distance = charismaUnitDistance[target][effectUnit];
              foreach (BL.SkillEffect skillEffect in effectUnit.skillEffects.Where(BattleskillEffectLogicEnum.charisma_clamp_hit, (Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(effectUnit, effect) && distance >= effect.effect.GetInt("min_range") && distance <= effect.effect.GetInt("max_range") && (effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == effectUnit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == beAttackUnit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == beAttackUnit.originalUnit.unit.kind.ID) && target == effect.effect.GetInt("effect_target") && (effectUnit != beDefenseUnit || !BattleFuncs.isSkillsAndEffectsInvalid(beDefenseUnit, beAttackUnit)) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, beAttackUnit, beDefenseUnit) && !BattleFuncs.isSkillsAndEffectsInvalid(beAttackUnit, beDefenseUnit))))
              {
                float num1 = (float) ((Decimal) skillEffect.effect.GetFloat("min_percentage") + (Decimal) skillEffect.baseSkillLevel * (Decimal) skillEffect.effect.GetFloat("min_skill_ratio"));
                if (!nullable2.HasValue || (!nullable2.HasValue ? 0 : ((double) num1 > (double) nullable2.Value ? 1 : 0)) != 0)
                  nullable2 = new float?(num1);
                float num2 = (float) ((Decimal) skillEffect.effect.GetFloat("max_percentage") + (Decimal) skillEffect.baseSkillLevel * (Decimal) skillEffect.effect.GetFloat("max_skill_ratio"));
                if (!nullable3.HasValue || (!nullable3.HasValue ? 0 : ((double) num2 < (double) nullable3.Value ? 1 : 0)) != 0)
                  nullable3 = new float?(num2);
              }
            }
          }
        }
        int? nullable4;
        if (nullable2.HasValue)
        {
          float? nullable5 = !nullable2.HasValue ? new float?() : new float?(nullable2.Value * 100f);
          nullable4 = !nullable5.HasValue ? new int?() : new int?((int) nullable5.Value);
        }
        else
          nullable4 = new int?();
        int? nullable6 = nullable4;
        int? nullable7;
        if (nullable3.HasValue)
        {
          float? nullable8 = !nullable3.HasValue ? new float?() : new float?(nullable3.Value * 100f);
          nullable7 = !nullable8.HasValue ? new int?() : new int?((int) nullable8.Value);
        }
        else
          nullable7 = new int?();
        int? nullable9 = nullable7;
        int? nullable10;
        if (nullable1.HasValue)
        {
          float? nullable11 = !nullable1.HasValue ? new float?() : new float?(nullable1.Value * 100f);
          nullable10 = !nullable11.HasValue ? new int?() : new int?((int) nullable11.Value);
        }
        else
          nullable10 = new int?();
        int? nullable12 = nullable10;
        return new Tuple<int?, int?, int?>(nullable6, nullable9, nullable12);
      }

      private static int MakeBaseDamage(
        BL.ISkillEffectListUnit beAttackUnit,
        BL.ISkillEffectListUnit beDefenseUnit)
      {
        int baseDamage = 0;
        ((Action<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int>) ((effectUnit, targetUnit, effect_target) =>
        {
          foreach (BL.SkillEffect skillEffect in effectUnit.skillEffects.Where(BattleskillEffectLogicEnum.base_damage, (Func<BL.SkillEffect, bool>) (x =>
          {
            BattleskillEffect effect = x.effect;
            return !BattleFuncs.isSealedSkillEffect(effectUnit, x) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == effectUnit.originalUnit.unit.kind.ID) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == targetUnit.originalUnit.unit.kind.ID) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == effectUnit.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == targetUnit.originalUnit.playerUnit.GetElement()) && (effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == effectUnit.originalUnit.job.ID) && (effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == targetUnit.originalUnit.job.ID) && (effect.GetInt("family_id") == 0 || effectUnit.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id"))) && (effect.GetInt("target_family_id") == 0 || targetUnit.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, beAttackUnit, beDefenseUnit) && !BattleFuncs.isSkillsAndEffectsInvalid(beAttackUnit, beDefenseUnit);
          })))
            baseDamage += skillEffect.effect.GetInt("damage_value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
        }))(beAttackUnit, beDefenseUnit, 0);
        return baseDamage;
      }

      private static float MakeDamageRate(
        BL.ISkillEffectListUnit beAttackUnit,
        BL.ISkillEffectListUnit beDefenseUnit,
        Dictionary<BL.ISkillEffectListUnit, int>[] charismaUnitDistance = null)
      {
        float damageRate = 1f;
        Action<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int> action = (Action<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int>) ((effectUnit, targetUnit, effect_target) =>
        {
          foreach (BL.SkillEffect skillEffect in effectUnit.skillEffects.Where(BattleskillEffectLogicEnum.damage_rate, (Func<BL.SkillEffect, bool>) (x =>
          {
            BattleskillEffect effect = x.effect;
            return effect.GetInt(nameof (effect_target)) == effect_target && !BattleFuncs.isSealedSkillEffect(effectUnit, x) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == effectUnit.originalUnit.unit.kind.ID) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == targetUnit.originalUnit.unit.kind.ID) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == effectUnit.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == targetUnit.originalUnit.playerUnit.GetElement()) && (effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == effectUnit.originalUnit.job.ID) && (effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == targetUnit.originalUnit.job.ID) && (effectUnit != beDefenseUnit || !BattleFuncs.isSkillsAndEffectsInvalid(beDefenseUnit, beAttackUnit)) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, beAttackUnit, beDefenseUnit) && !BattleFuncs.isSkillsAndEffectsInvalid(beAttackUnit, beDefenseUnit);
          })))
          {
            float num = skillEffect.effect.GetFloat("damage_percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
            if ((double) num < 0.0)
              num = 0.0f;
            damageRate *= num;
          }
        });
        action(beAttackUnit, beDefenseUnit, 0);
        action(beDefenseUnit, beAttackUnit, 1);
        if (charismaUnitDistance != null)
        {
          for (int target = 0; target <= 1; ++target)
          {
            foreach (BL.ISkillEffectListUnit key in charismaUnitDistance[target].Keys)
            {
              BL.ISkillEffectListUnit effectUnit = key;
              int distance = charismaUnitDistance[target][effectUnit];
              foreach (BL.SkillEffect skillEffect in effectUnit.skillEffects.Where(BattleskillEffectLogicEnum.charisma_damage_rate, (Func<BL.SkillEffect, bool>) (effect => !BattleFuncs.isSealedSkillEffect(effectUnit, effect) && distance >= effect.effect.GetInt("min_range") && distance <= effect.effect.GetInt("max_range") && (effect.effect.GetInt("element") == 0 || (CommonElement) effect.effect.GetInt("element") == effectUnit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("target_element") == 0 || (CommonElement) effect.effect.GetInt("target_element") == beAttackUnit.originalUnit.playerUnit.GetElement()) && (effect.effect.GetInt("gear_kind_id") == 0 || effect.effect.GetInt("gear_kind_id") == effectUnit.originalUnit.unit.kind.ID) && (effect.effect.GetInt("target_gear_kind_id") == 0 || effect.effect.GetInt("target_gear_kind_id") == beAttackUnit.originalUnit.unit.kind.ID) && (effect.effect.GetInt("target_job_id") == 0 || effect.effect.GetInt("target_job_id") == beAttackUnit.originalUnit.job.ID) && target == effect.effect.GetInt("effect_target") && (effectUnit != beDefenseUnit || !BattleFuncs.isSkillsAndEffectsInvalid(beDefenseUnit, beAttackUnit)) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, beAttackUnit, beDefenseUnit) && !BattleFuncs.isSkillsAndEffectsInvalid(beAttackUnit, beDefenseUnit))))
              {
                float num = skillEffect.effect.GetFloat("damage_percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
                if ((double) num < 0.0)
                  num = 0.0f;
                damageRate *= num;
              }
            }
          }
        }
        return damageRate;
      }

      private static Dictionary<BL.ISkillEffectListUnit, int>[] MakeCharismaUnitDistance(
        BL.ISkillEffectListUnit beUnit,
        BL.ForceID[] targetForceId,
        BL.Panel panel,
        BL.ISkillEffectListUnit beMoveUnit,
        int distanceToMoveUnit,
        bool isAI)
      {
        if (panel == null || targetForceId == null || beMoveUnit == null)
          return (Dictionary<BL.ISkillEffectListUnit, int>[]) null;
        Dictionary<BL.ISkillEffectListUnit, int>[] dictionaryArray = new Dictionary<BL.ISkillEffectListUnit, int>[2];
        BL.ForceID[][] forceIdArray = new BL.ForceID[2][]
        {
          new BL.ForceID[1]
          {
            BattleFuncs.getForceID(beUnit.originalUnit)
          },
          targetForceId
        };
        for (int index = 0; index <= 1; ++index)
        {
          dictionaryArray[index] = new Dictionary<BL.ISkillEffectListUnit, int>();
          foreach (BL.UnitPosition target in BattleFuncs.getTargets(panel.row, panel.column, new int[2]
          {
            0,
            5
          }, forceIdArray[index], (isAI ? 1 : 0) != 0))
          {
            BL.ISkillEffectListUnit iskillEffectListUnit = BattleFuncs.unitPositionToISkillEffectListUnit(target);
            if (iskillEffectListUnit != beMoveUnit)
              dictionaryArray[index][iskillEffectListUnit] = BL.fieldDistance(panel, BattleFuncs.getPanel(target.row, target.column));
          }
        }
        dictionaryArray[beMoveUnit != beUnit ? 1 : 0][beMoveUnit] = distanceToMoveUnit;
        return dictionaryArray;
      }
    }
  }
}
