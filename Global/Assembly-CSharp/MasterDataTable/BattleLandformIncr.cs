// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleLandformIncr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleLandformIncr
  {
    public int ID;
    public int landform_BattleLandform;
    public int move_type_UnitMoveType;
    public int physical_defense_incr;
    public int magic_defense_incr;
    public int hit_incr;
    public int critical_incr;
    public int evasion_incr;
    public float hp_healing_ratio;
    public int move_cost;
    public int? effect_group_id;

    public BattleLandformEffectGroup effect_group
    {
      get
      {
        BattleLandformEffectGroup effectGroup = (BattleLandformEffectGroup) null;
        if (this.effect_group_id.HasValue)
          effectGroup = MasterData.BattleLandformEffectGroup[this.effect_group_id.Value];
        return effectGroup;
      }
    }

    public BattleLandformEffect[] effects
    {
      get
      {
        BattleLandformEffect[] effects = new BattleLandformEffect[0];
        if (this.effect_group_id.HasValue)
          effects = ((IEnumerable<BattleLandformEffect>) MasterData.BattleLandformEffectList).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.group_id == this.effect_group_id.Value)).ToArray<BattleLandformEffect>();
        return effects;
      }
    }

    public BattleLandformEffect[] GetLandformEffects(BattleLandformEffectPhase phase)
    {
      return ((IEnumerable<BattleLandformEffect>) this.effects).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.landform_effect_phase == phase)).ToArray<BattleLandformEffect>();
    }

    private IEnumerable<BattleLandformEffect> GetEnabledBuffDebuff(
      BattleskillEffectLogicEnum e,
      BL.Unit unit,
      BL.Unit target,
      int attackType)
    {
      return ((IEnumerable<BattleLandformEffect>) this.GetLandformEffects(BattleLandformEffectPhase.duel)).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x =>
      {
        if (x.effect_logic.Enum != e || x.GetInt("job_id") != 0 && x.GetInt("job_id") != unit.job.ID || x.GetInt("gear_kind_id") != 0 && x.GetInt("gear_kind_id") != unit.unit.kind.ID || x.GetInt("target_family_id") != 0 && !target.unit.HasFamily((UnitFamily) x.GetInt("target_family_id")) || x.GetInt("target_gear_kind_id") != 0 && x.GetInt("target_gear_kind_id") != target.unit.kind.ID || x.GetInt("is_attack") != 0 && x.GetInt("is_attack") != attackType || x.GetInt("element") != 0 && (CommonElement) x.GetInt("element") != unit.playerUnit.GetElement())
          return false;
        return x.GetInt("target_element") == 0 || (CommonElement) x.GetInt("target_element") == target.playerUnit.GetElement();
      }));
    }

    private int GetSkillAdd(
      BL.Unit beUnit,
      BL.Unit beTarget,
      int attackType,
      BattleskillEffectLogicEnum fix_logic)
    {
      int skillAdd = 0;
      foreach (BattleLandformEffect battleLandformEffect in this.GetEnabledBuffDebuff(fix_logic, beUnit, beTarget, attackType))
        skillAdd += battleLandformEffect.GetInt("value");
      return skillAdd;
    }

    private float GetSkillMul(
      BL.Unit beUnit,
      BL.Unit beTarget,
      int attackType,
      BattleskillEffectLogicEnum ratio_logic)
    {
      float skillMul = 1f;
      foreach (BattleLandformEffect battleLandformEffect in this.GetEnabledBuffDebuff(ratio_logic, beUnit, beTarget, attackType))
        skillMul *= battleLandformEffect.GetFloat("percentage");
      return skillMul;
    }

    public BattleLandformIncr.LandformDuelSkillIncr GetDuelSkillIncr(
      BL.Unit unit,
      BL.Unit target,
      int attackType)
    {
      BattleLandformIncr.LandformDuelSkillIncr duelSkillIncr;
      duelSkillIncr.skillAddHp = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_hp);
      duelSkillIncr.skillAddStrength = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_strength);
      duelSkillIncr.skillAddIntelligence = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_intelligence);
      duelSkillIncr.skillAddVitality = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_vitality);
      duelSkillIncr.skillAddMind = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_mind);
      duelSkillIncr.skillAddAgility = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_agility);
      duelSkillIncr.skillAddDexterity = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_dexterity);
      duelSkillIncr.skillAddLuck = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_luck);
      duelSkillIncr.skillAddMove = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_move);
      duelSkillIncr.skillAddPhysicalAttack = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_physical_attack);
      duelSkillIncr.skillAddPhysicalDefense = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_physical_defense);
      duelSkillIncr.skillAddMagicAttack = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_magic_attack);
      duelSkillIncr.skillAddMagicDefense = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_magic_defense);
      duelSkillIncr.skillAddHit = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_hit);
      duelSkillIncr.skillAddCritical = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_critical);
      duelSkillIncr.skillAddEvasion = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_evasion);
      duelSkillIncr.skillAddCriticalEvasion = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_critical_evasion);
      duelSkillIncr.skillMulHp = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_hp);
      duelSkillIncr.skillMulStrength = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_strength);
      duelSkillIncr.skillMulIntelligence = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_intelligence);
      duelSkillIncr.skillMulVitality = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_vitality);
      duelSkillIncr.skillMulMind = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_mind);
      duelSkillIncr.skillMulAgility = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_agility);
      duelSkillIncr.skillMulDexterity = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_dexterity);
      duelSkillIncr.skillMulLuck = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_luck);
      duelSkillIncr.skillMulMove = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_move);
      duelSkillIncr.skillMulPhysicalAttack = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_physical_attack);
      duelSkillIncr.skillMulPhysicalDefense = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_physical_defense);
      duelSkillIncr.skillMulMagicAttack = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_magic_attack);
      duelSkillIncr.skillMulMagicDefense = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_magic_defense);
      duelSkillIncr.skillMulHit = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_hit);
      duelSkillIncr.skillMulCritical = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_critical);
      duelSkillIncr.skillMulEvasion = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_evasion);
      duelSkillIncr.skillMulCriticalEvasion = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_critical_evasion);
      return duelSkillIncr;
    }

    public static BattleLandformIncr Parse(MasterDataReader reader)
    {
      return new BattleLandformIncr()
      {
        ID = reader.ReadInt(),
        landform_BattleLandform = reader.ReadInt(),
        move_type_UnitMoveType = reader.ReadInt(),
        physical_defense_incr = reader.ReadInt(),
        magic_defense_incr = reader.ReadInt(),
        hit_incr = reader.ReadInt(),
        critical_incr = reader.ReadInt(),
        evasion_incr = reader.ReadInt(),
        hp_healing_ratio = reader.ReadFloat(),
        move_cost = reader.ReadInt(),
        effect_group_id = reader.ReadIntOrNull()
      };
    }

    public BattleLandform landform
    {
      get
      {
        BattleLandform landform;
        if (!MasterData.BattleLandform.TryGetValue(this.landform_BattleLandform, out landform))
          Debug.LogError((object) ("Key not Found: MasterData.BattleLandform[" + (object) this.landform_BattleLandform + "]"));
        return landform;
      }
    }

    public UnitMoveType move_type => (UnitMoveType) this.move_type_UnitMoveType;

    public struct LandformDuelSkillIncr
    {
      public int skillAddHp;
      public int skillAddStrength;
      public int skillAddIntelligence;
      public int skillAddVitality;
      public int skillAddMind;
      public int skillAddAgility;
      public int skillAddDexterity;
      public int skillAddLuck;
      public int skillAddMove;
      public int skillAddPhysicalAttack;
      public int skillAddPhysicalDefense;
      public int skillAddMagicAttack;
      public int skillAddMagicDefense;
      public int skillAddHit;
      public int skillAddCritical;
      public int skillAddEvasion;
      public int skillAddCriticalEvasion;
      public float skillMulHp;
      public float skillMulStrength;
      public float skillMulIntelligence;
      public float skillMulVitality;
      public float skillMulMind;
      public float skillMulAgility;
      public float skillMulDexterity;
      public float skillMulLuck;
      public float skillMulMove;
      public float skillMulPhysicalAttack;
      public float skillMulPhysicalDefense;
      public float skillMulMagicAttack;
      public float skillMulMagicDefense;
      public float skillMulHit;
      public float skillMulCritical;
      public float skillMulEvasion;
      public float skillMulCriticalEvasion;
    }
  }
}
