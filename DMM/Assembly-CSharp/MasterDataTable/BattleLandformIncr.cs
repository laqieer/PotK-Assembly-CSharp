// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleLandformIncr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;

namespace MasterDataTable
{
  [Serializable]
  public class BattleLandformIncr
  {
    private BattleLandformEffect[] _effects;
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
    public float? physical_defense_ratio_incr;
    public float? magic_defense_ratio_incr;
    public float? hit_ratio_incr;
    public float? evasion_ratio_incr;

    public BattleLandformEffectGroup effect_group
    {
      get
      {
        BattleLandformEffectGroup landformEffectGroup = (BattleLandformEffectGroup) null;
        if (this.effect_group_id.HasValue)
          landformEffectGroup = MasterData.BattleLandformEffectGroup[this.effect_group_id.Value];
        return landformEffectGroup;
      }
    }

    public BattleLandformEffect[] effects
    {
      get
      {
        if (this._effects == null)
          this._effects = !this.effect_group_id.HasValue ? new BattleLandformEffect[0] : ((IEnumerable<BattleLandformEffect>) MasterData.BattleLandformEffectList).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.group_id == this.effect_group_id.Value)).ToArray<BattleLandformEffect>();
        return this._effects;
      }
    }

    public IEnumerable<BattleLandformEffect> GetLandformEffects(
      BattleLandformEffectPhase phase)
    {
      return ((IEnumerable<BattleLandformEffect>) this.effects).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.landform_effect_phase == phase));
    }

    private IEnumerable<BattleLandformEffect> GetEnabledBuffDebuff(
      BattleskillEffectLogicEnum e,
      BL.Unit unit)
    {
      return this.GetLandformEffects(BattleLandformEffectPhase.duel).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x =>
      {
        if (x.effect_logic.Enum != e || x.GetInt(BattleskillEffectLogicArgumentEnum.job_id) != 0 && x.GetInt(BattleskillEffectLogicArgumentEnum.job_id) != unit.job.ID || (x.GetInt(BattleskillEffectLogicArgumentEnum.gear_kind_id) != 0 && x.GetInt(BattleskillEffectLogicArgumentEnum.gear_kind_id) != unit.unit.kind.ID || (x.GetInt(BattleskillEffectLogicArgumentEnum.target_family_id) != 0 || x.GetInt(BattleskillEffectLogicArgumentEnum.target_gear_kind_id) != 0)) || (x.GetInt(BattleskillEffectLogicArgumentEnum.is_attack) != 0 || x.GetInt(BattleskillEffectLogicArgumentEnum.element) != 0 && (CommonElement) x.GetInt(BattleskillEffectLogicArgumentEnum.element) != unit.playerUnit.GetElement() || x.GetInt(BattleskillEffectLogicArgumentEnum.target_element) != 0))
          return false;
        return !x.HasKey(BattleskillEffectLogicArgumentEnum.family_id) || x.GetInt(BattleskillEffectLogicArgumentEnum.family_id) == 0 || unit.playerUnit.HasFamily((UnitFamily) x.GetInt(BattleskillEffectLogicArgumentEnum.family_id));
      }));
    }

    private IEnumerable<BattleLandformEffect> GetEnabledBuffDebuff(
      BattleskillEffectLogicEnum e,
      BL.Unit unit,
      BL.Unit target,
      int attackType)
    {
      return this.GetLandformEffects(BattleLandformEffectPhase.duel).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x =>
      {
        if (x.effect_logic.Enum != e || x.GetInt(BattleskillEffectLogicArgumentEnum.job_id) != 0 && x.GetInt(BattleskillEffectLogicArgumentEnum.job_id) != unit.job.ID || (x.GetInt(BattleskillEffectLogicArgumentEnum.gear_kind_id) != 0 && x.GetInt(BattleskillEffectLogicArgumentEnum.gear_kind_id) != unit.unit.kind.ID || x.GetInt(BattleskillEffectLogicArgumentEnum.target_family_id) != 0 && !target.playerUnit.HasFamily((UnitFamily) x.GetInt(BattleskillEffectLogicArgumentEnum.target_family_id))) || (x.GetInt(BattleskillEffectLogicArgumentEnum.target_gear_kind_id) != 0 && x.GetInt(BattleskillEffectLogicArgumentEnum.target_gear_kind_id) != target.unit.kind.ID || x.GetInt(BattleskillEffectLogicArgumentEnum.is_attack) != 0 && x.GetInt(BattleskillEffectLogicArgumentEnum.is_attack) != attackType || (x.GetInt(BattleskillEffectLogicArgumentEnum.element) != 0 && (CommonElement) x.GetInt(BattleskillEffectLogicArgumentEnum.element) != unit.playerUnit.GetElement() || x.GetInt(BattleskillEffectLogicArgumentEnum.target_element) != 0 && (CommonElement) x.GetInt(BattleskillEffectLogicArgumentEnum.target_element) != target.playerUnit.GetElement())))
          return false;
        return !x.HasKey(BattleskillEffectLogicArgumentEnum.family_id) || x.GetInt(BattleskillEffectLogicArgumentEnum.family_id) == 0 || unit.playerUnit.HasFamily((UnitFamily) x.GetInt(BattleskillEffectLogicArgumentEnum.family_id));
      }));
    }

    private int GetSkillAdd(BL.Unit beUnit, BattleskillEffectLogicEnum fix_logic)
    {
      int num = 0;
      foreach (BattleLandformEffect battleLandformEffect in this.GetEnabledBuffDebuff(fix_logic, beUnit))
        num += battleLandformEffect.GetInt(BattleskillEffectLogicArgumentEnum.value);
      return num;
    }

    private float GetSkillMul(BL.Unit beUnit, BattleskillEffectLogicEnum ratio_logic)
    {
      float num = 1f;
      foreach (BattleLandformEffect battleLandformEffect in this.GetEnabledBuffDebuff(ratio_logic, beUnit))
        num *= battleLandformEffect.GetFloat(BattleskillEffectLogicArgumentEnum.percentage);
      return num;
    }

    public BattleLandformIncr.LandformDuelSkillIncr GetDuelSkillIncr(BL.Unit unit)
    {
      BattleLandformIncr.LandformDuelSkillIncr landformDuelSkillIncr;
      landformDuelSkillIncr.skillAddHp = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_hp);
      landformDuelSkillIncr.skillAddStrength = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_strength);
      landformDuelSkillIncr.skillAddIntelligence = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_intelligence);
      landformDuelSkillIncr.skillAddVitality = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_vitality);
      landformDuelSkillIncr.skillAddMind = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_mind);
      landformDuelSkillIncr.skillAddAgility = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_agility);
      landformDuelSkillIncr.skillAddDexterity = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_dexterity);
      landformDuelSkillIncr.skillAddLuck = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_luck);
      landformDuelSkillIncr.skillAddMove = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_move);
      landformDuelSkillIncr.skillAddPhysicalAttack = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_physical_attack);
      landformDuelSkillIncr.skillAddPhysicalDefense = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_physical_defense);
      landformDuelSkillIncr.skillAddMagicAttack = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_magic_attack);
      landformDuelSkillIncr.skillAddMagicDefense = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_magic_defense);
      landformDuelSkillIncr.skillAddHit = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_hit);
      landformDuelSkillIncr.skillAddCritical = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_critical);
      landformDuelSkillIncr.skillAddEvasion = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_evasion);
      landformDuelSkillIncr.skillAddCriticalEvasion = this.GetSkillAdd(unit, BattleskillEffectLogicEnum.fix_critical_evasion);
      landformDuelSkillIncr.skillMulHp = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_hp);
      landformDuelSkillIncr.skillMulStrength = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_strength);
      landformDuelSkillIncr.skillMulIntelligence = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_intelligence);
      landformDuelSkillIncr.skillMulVitality = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_vitality);
      landformDuelSkillIncr.skillMulMind = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_mind);
      landformDuelSkillIncr.skillMulAgility = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_agility);
      landformDuelSkillIncr.skillMulDexterity = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_dexterity);
      landformDuelSkillIncr.skillMulLuck = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_luck);
      landformDuelSkillIncr.skillMulMove = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_move);
      landformDuelSkillIncr.skillMulPhysicalAttack = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_physical_attack);
      landformDuelSkillIncr.skillMulPhysicalDefense = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_physical_defense);
      landformDuelSkillIncr.skillMulMagicAttack = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_magic_attack);
      landformDuelSkillIncr.skillMulMagicDefense = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_magic_defense);
      landformDuelSkillIncr.skillMulHit = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_hit);
      landformDuelSkillIncr.skillMulCritical = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_critical);
      landformDuelSkillIncr.skillMulEvasion = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_evasion);
      landformDuelSkillIncr.skillMulCriticalEvasion = this.GetSkillMul(unit, BattleskillEffectLogicEnum.ratio_critical_evasion);
      return landformDuelSkillIncr;
    }

    private int GetSkillAdd(
      BL.Unit beUnit,
      BL.Unit beTarget,
      int attackType,
      BattleskillEffectLogicEnum fix_logic)
    {
      int num = 0;
      foreach (BattleLandformEffect battleLandformEffect in this.GetEnabledBuffDebuff(fix_logic, beUnit, beTarget, attackType))
        num += battleLandformEffect.GetInt(BattleskillEffectLogicArgumentEnum.value);
      return num;
    }

    private float GetSkillMul(
      BL.Unit beUnit,
      BL.Unit beTarget,
      int attackType,
      BattleskillEffectLogicEnum ratio_logic)
    {
      float num = 1f;
      foreach (BattleLandformEffect battleLandformEffect in this.GetEnabledBuffDebuff(ratio_logic, beUnit, beTarget, attackType))
        num *= battleLandformEffect.GetFloat(BattleskillEffectLogicArgumentEnum.percentage);
      return num;
    }

    public BattleLandformIncr.LandformDuelSkillIncr GetDuelSkillIncr(
      BL.Unit unit,
      BL.Unit target,
      int attackType)
    {
      BattleLandformIncr.LandformDuelSkillIncr landformDuelSkillIncr;
      landformDuelSkillIncr.skillAddHp = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_hp);
      landformDuelSkillIncr.skillAddStrength = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_strength);
      landformDuelSkillIncr.skillAddIntelligence = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_intelligence);
      landformDuelSkillIncr.skillAddVitality = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_vitality);
      landformDuelSkillIncr.skillAddMind = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_mind);
      landformDuelSkillIncr.skillAddAgility = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_agility);
      landformDuelSkillIncr.skillAddDexterity = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_dexterity);
      landformDuelSkillIncr.skillAddLuck = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_luck);
      landformDuelSkillIncr.skillAddMove = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_move);
      landformDuelSkillIncr.skillAddPhysicalAttack = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_physical_attack);
      landformDuelSkillIncr.skillAddPhysicalDefense = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_physical_defense);
      landformDuelSkillIncr.skillAddMagicAttack = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_magic_attack);
      landformDuelSkillIncr.skillAddMagicDefense = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_magic_defense);
      landformDuelSkillIncr.skillAddHit = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_hit);
      landformDuelSkillIncr.skillAddCritical = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_critical);
      landformDuelSkillIncr.skillAddEvasion = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_evasion);
      landformDuelSkillIncr.skillAddCriticalEvasion = this.GetSkillAdd(unit, target, attackType, BattleskillEffectLogicEnum.fix_critical_evasion);
      landformDuelSkillIncr.skillMulHp = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_hp);
      landformDuelSkillIncr.skillMulStrength = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_strength);
      landformDuelSkillIncr.skillMulIntelligence = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_intelligence);
      landformDuelSkillIncr.skillMulVitality = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_vitality);
      landformDuelSkillIncr.skillMulMind = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_mind);
      landformDuelSkillIncr.skillMulAgility = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_agility);
      landformDuelSkillIncr.skillMulDexterity = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_dexterity);
      landformDuelSkillIncr.skillMulLuck = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_luck);
      landformDuelSkillIncr.skillMulMove = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_move);
      landformDuelSkillIncr.skillMulPhysicalAttack = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_physical_attack);
      landformDuelSkillIncr.skillMulPhysicalDefense = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_physical_defense);
      landformDuelSkillIncr.skillMulMagicAttack = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_magic_attack);
      landformDuelSkillIncr.skillMulMagicDefense = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_magic_defense);
      landformDuelSkillIncr.skillMulHit = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_hit);
      landformDuelSkillIncr.skillMulCritical = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_critical);
      landformDuelSkillIncr.skillMulEvasion = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_evasion);
      landformDuelSkillIncr.skillMulCriticalEvasion = this.GetSkillMul(unit, target, attackType, BattleskillEffectLogicEnum.ratio_critical_evasion);
      return landformDuelSkillIncr;
    }

    public static BattleLandformIncr Parse(MasterDataReader reader) => new BattleLandformIncr()
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
      effect_group_id = reader.ReadIntOrNull(),
      physical_defense_ratio_incr = reader.ReadFloatOrNull(),
      magic_defense_ratio_incr = reader.ReadFloatOrNull(),
      hit_ratio_incr = reader.ReadFloatOrNull(),
      evasion_ratio_incr = reader.ReadFloatOrNull()
    };

    public BattleLandform landform
    {
      get
      {
        BattleLandform battleLandform;
        if (!MasterData.BattleLandform.TryGetValue(this.landform_BattleLandform, out battleLandform))
          Debug.LogError((object) ("Key not Found: MasterData.BattleLandform[" + (object) this.landform_BattleLandform + "]"));
        return battleLandform;
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
