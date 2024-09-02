// Decompiled with JetBrains decompiler
// Type: GameCore.BattleDuelSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  public class BattleDuelSkill
  {
    private bool isHit;
    private bool isCritical;
    private BL.ISkillEffectListUnit attacker;
    private AttackStatus attackStatus;
    private BL.ISkillEffectListUnit defender;
    private AttackStatus defenseStatus;
    private int distance;
    private int currentAttakerHp;
    private int currentDefenderHp;
    private int defenderDuelBeginHp;
    private XorShift random;
    private bool isColossume;
    private bool isAI;
    private bool isBiattack;
    private bool isPrecede;
    private bool attakerIsDontUseSkill;
    private bool defenderIsDontUseSkill;
    private bool isAttacker;
    private bool isInvokedAmbush;
    private bool isInvokedPrayer;
    private int finalAttack;
    private BattleDuelSkill biAttackDuelSkill;
    private BL.Skill invokeAttackerSkill;
    private List<BattleskillEffect> invokeAttackerSkillEffects;
    private float? invokeRate;
    private bool isOneMoreAttack;
    private BattleDuelSkill.InvokeGenericWork invokeDefenseGenericWork;
    private static BL.Skill[] noneSkills = new BL.Skill[0];

    private BattleDuelSkill()
    {
      this.damageRate = 1f;
      this.biAttackDamageRate = (float[]) null;
      this.attackRate = 1f;
      this.damageValue = 0.0f;
      this.FixDamage = new int?();
      this.drainRate = 0.0f;
      this.defenseDownPhysicalRate = 1f;
      this.defenseDownMagicRate = 1f;
      this.attackCount = 1;
      this.FixHit = new float?();
      this.attacker = (BL.ISkillEffectListUnit) null;
      this.attackStatus = (AttackStatus) null;
      this.defender = (BL.ISkillEffectListUnit) null;
      this.defenseStatus = (AttackStatus) null;
      this.distance = 0;
      this.currentAttakerHp = 0;
      this.currentDefenderHp = 0;
      this.isInvokeCounterAttack = false;
      this.counterDamageRate = 0.0f;
      this.counterAttackRate = 0.0f;
      this.counterDamageHpPercentage = 0.0f;
      this.counterDamageValue = 0;
      this.PercentageDamageRate = new float?();
      this.invokeAttackerSkill = (BL.Skill) null;
      this.invokeAttackerSkillEffects = (List<BattleskillEffect>) null;
      this.biAttackDuelSkill = (BattleDuelSkill) null;
      this.drainRateRatio = 1f;
      this.defenseDownPhysicalRateRatio = 1f;
      this.defenseDownMagicRateRatio = 1f;
      this.isSuppressCritical = false;
      this.attackerCantOneMore = false;
      this.isSuppressDuelSkill = false;
      this.invokeRate = new float?();
    }

    public float damageRate { get; private set; }

    public float[] biAttackDamageRate { get; private set; }

    public float attackRate { get; private set; }

    public float damageValue { get; private set; }

    public int? FixDamage { get; private set; }

    public float drainRate { get; private set; }

    public float defenseDownPhysicalRate { get; private set; }

    public float defenseDownMagicRate { get; private set; }

    public int attackCount { get; private set; }

    public float? FixHit { get; private set; }

    public bool isChageAttackType { get; private set; }

    public bool isInvokeCounterAttack { get; private set; }

    public float counterDamageRate { get; private set; }

    public float counterAttackRate { get; private set; }

    public float counterDamageHpPercentage { get; private set; }

    public int counterDamageValue { get; private set; }

    public float? PercentageDamageRate { get; private set; }

    public float drainRateRatio { get; private set; }

    public float defenseDownPhysicalRateRatio { get; private set; }

    public float defenseDownMagicRateRatio { get; private set; }

    public bool isSuppressCritical { get; private set; }

    public bool attackerCantOneMore { get; private set; }

    public bool isSuppressDuelSkill { get; private set; }

    public BL.Skill[] attackerSkills { get; private set; }

    public BL.Skill[] defenderSkills { get; private set; }

    public BL.Skill[] attackerElementSkills { get; private set; }

    public BL.Skill[] defenderElementSkills { get; private set; }

    public List<List<BattleDuelSkill.InvestSkills>> investSkills { get; private set; }

    public static BattleDuelSkill invokeBiAttackSkills(
      BL.ISkillEffectListUnit attacker,
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit defender,
      AttackStatus defenseStatus,
      int distance,
      int currentAttakerHp,
      int currentDefenderHp,
      bool attakerIsDontUseSkill,
      bool defenderIsDontUseSkill,
      XorShift random,
      bool isAI,
      bool isColossume,
      bool isAttacker,
      bool isInvokedAmbush,
      float? invokeRate,
      bool isOneMoreAttack)
    {
      BattleDuelSkill battleDuelSkill = new BattleDuelSkill()
      {
        random = random,
        attacker = attacker,
        attackStatus = attackStatus,
        defender = defender,
        defenseStatus = defenseStatus,
        investSkills = (List<List<BattleDuelSkill.InvestSkills>>) null,
        attakerIsDontUseSkill = attakerIsDontUseSkill,
        defenderIsDontUseSkill = defenderIsDontUseSkill,
        isAI = isAI,
        isColossume = isColossume,
        isChageAttackType = false,
        distance = distance,
        currentAttakerHp = currentAttakerHp,
        currentDefenderHp = currentDefenderHp,
        isAttacker = isAttacker,
        isInvokedAmbush = isInvokedAmbush,
        isOneMoreAttack = isOneMoreAttack,
        isPrecede = true,
        isBiattack = false,
        invokeRate = new float?()
      };
      battleDuelSkill.defenderSkills = battleDuelSkill.InvokePrecedeDefender();
      float damageRate = battleDuelSkill.damageRate;
      battleDuelSkill.damageRate = 1f;
      battleDuelSkill.isBiattack = true;
      battleDuelSkill.invokeRate = invokeRate;
      battleDuelSkill.invokeAttackerSkillEffects = new List<BattleskillEffect>();
      battleDuelSkill.attackerSkills = battleDuelSkill.InvokeBiAttack();
      battleDuelSkill.damageRate *= damageRate;
      battleDuelSkill.applyPrecedeDefenseBiattack();
      return battleDuelSkill;
    }

    public static float getElementAttackRate(
      BL.ISkillEffectListUnit attacker,
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit defender)
    {
      BattleDuelSkill battleDuelSkill = new BattleDuelSkill();
      battleDuelSkill.attacker = attacker;
      battleDuelSkill.attackStatus = attackStatus;
      battleDuelSkill.defender = defender;
      battleDuelSkill.InvokeElementSkill();
      return battleDuelSkill.damageRate;
    }

    public static BattleDuelSkill invokeDuelSkills(
      BL.ISkillEffectListUnit attacker,
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit defender,
      AttackStatus defenseStatus,
      int distance,
      int currentAttakerHp,
      int currentDefenderHp,
      bool attakerIsDontUseSkill,
      bool defenderIsDontUseSkill,
      XorShift random,
      bool isAI,
      bool isColossume,
      bool isBiattack,
      bool isAttacker,
      bool isInvokedAmbush,
      bool isInvokedPrayer,
      BattleDuelSkill biAttackDuelSkill,
      float? invokeRate,
      int defenderDuelBeginHp,
      bool isOneMoreAttack)
    {
      BattleDuelSkill battleDuelSkill = new BattleDuelSkill()
      {
        random = random,
        attacker = attacker,
        attackStatus = attackStatus,
        defender = defender,
        defenseStatus = defenseStatus,
        distance = distance,
        currentAttakerHp = currentAttakerHp,
        currentDefenderHp = currentDefenderHp,
        defenderDuelBeginHp = defenderDuelBeginHp,
        isAI = isAI,
        isColossume = isColossume,
        investSkills = (List<List<BattleDuelSkill.InvestSkills>>) null,
        attakerIsDontUseSkill = attakerIsDontUseSkill,
        defenderIsDontUseSkill = defenderIsDontUseSkill,
        isChageAttackType = false,
        isBiattack = isBiattack,
        isAttacker = isAttacker,
        isInvokedAmbush = isInvokedAmbush,
        isInvokedPrayer = isInvokedPrayer,
        invokeAttackerSkillEffects = new List<BattleskillEffect>(),
        biAttackDuelSkill = biAttackDuelSkill,
        invokeRate = invokeRate,
        isOneMoreAttack = isOneMoreAttack
      };
      battleDuelSkill.attackerSkills = battleDuelSkill.InvokeAttacker();
      battleDuelSkill.InvokeElementSkill();
      return battleDuelSkill;
    }

    public void invokeDefenderSkill(bool isCritical)
    {
      this.isCritical = isCritical;
      this.invokeRate = new float?();
      this.defenderSkills = this.InvokeDefender();
    }

    public static BattleDuelSkill invokeAilmentSkills(
      BL.ISkillEffectListUnit attacker,
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit defender,
      bool isHit,
      bool attakerIsDontUseSkill,
      XorShift random,
      bool isAI,
      bool isColossume)
    {
      BattleDuelSkill battleDuelSkill = new BattleDuelSkill()
      {
        random = random,
        attacker = attacker,
        attackStatus = attackStatus,
        defender = defender,
        isHit = isHit,
        investSkills = (List<List<BattleDuelSkill.InvestSkills>>) null,
        isAI = isAI,
        isColossume = isColossume,
        attakerIsDontUseSkill = attakerIsDontUseSkill
      };
      battleDuelSkill.attackerSkills = battleDuelSkill.InvokeAilmentSkills(isAI);
      return battleDuelSkill;
    }

    private BL.Skill[] InvokeDefender()
    {
      if (this.biAttackDuelSkill.defenderSkills != BattleDuelSkill.noneSkills)
        return BattleDuelSkill.noneSkills;
      BL.Skill[] duelSkills = this.defender.originalUnit.duelSkills;
      Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool>> dictionary = new Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool>>()
      {
        {
          BattleskillEffectLogicEnum.shield,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcShield)
        },
        {
          BattleskillEffectLogicEnum.out_of_range_defense,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcOutOfRangeDefence)
        },
        {
          BattleskillEffectLogicEnum.counter,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcCounter)
        }
      };
      if (this.defender.IsDontAction || this.defenderIsDontUseSkill)
        return BattleDuelSkill.noneSkills;
      BL.Skill[] skillArray = this.InvokeDefenderGeneric();
      if (skillArray != BattleDuelSkill.noneSkills)
        return skillArray;
      foreach (BL.Skill skill in duelSkills)
      {
        foreach (BattleskillEffect effect in skill.skill.Effects)
        {
          if (!this.defender.IsDontUseSkill(skill.id))
          {
            BattleskillEffectLogicEnum key = effect.effect_logic.Enum;
            if (dictionary.ContainsKey(key) && dictionary[key](skill, effect))
              return new BL.Skill[1]{ skill };
          }
        }
      }
      return BattleDuelSkill.noneSkills;
    }

    private BL.Skill[] InvokePrecedeDefender()
    {
      BL.Skill[] duelSkills = this.defender.originalUnit.duelSkills;
      if (this.defender.IsDontAction || this.defenderIsDontUseSkill)
        return BattleDuelSkill.noneSkills;
      BL.Skill[] skillArray = this.InvokeDefenderGeneric();
      return skillArray != BattleDuelSkill.noneSkills ? skillArray : BattleDuelSkill.noneSkills;
    }

    private void applyPrecedeDefenseBiattack()
    {
      if (this.invokeDefenseGenericWork == null || !this.invokeDefenseGenericWork.HasKey("skill_id1"))
        return;
      for (int attackNo = 0; attackNo < this.attackCount; ++attackNo)
        this.funcGenericSkillInvest(this.invokeDefenseGenericWork, this.defender, this.attacker, attackNo);
    }

    private BL.Skill[] InvokeAttacker()
    {
      if (this.isBiattack || this.biAttackDuelSkill.isSuppressDuelSkill || this.attackStatus.magicBullet != null && this.attackStatus.magicBullet.percentageDamage != null)
        return BattleDuelSkill.noneSkills;
      BL.Skill[] duelSkills = this.attacker.originalUnit.duelSkills;
      Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool>> dictionary = new Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool>>()
      {
        {
          BattleskillEffectLogicEnum.ryusei,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcRyusei)
        },
        {
          BattleskillEffectLogicEnum.gekko,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcGekko)
        },
        {
          BattleskillEffectLogicEnum.taiyo,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcTaiyo)
        },
        {
          BattleskillEffectLogicEnum.magic_suisei,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcMagicSuisei)
        },
        {
          BattleskillEffectLogicEnum.magic_physical_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcIntelligenceToPhysicalAttackUp)
        },
        {
          BattleskillEffectLogicEnum.agility_physical_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcAgilityToPhysicalAttackUp)
        },
        {
          BattleskillEffectLogicEnum.dexterity_physical_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcDexterityToPhysicalAttackUp)
        },
        {
          BattleskillEffectLogicEnum.luck_physical_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcLuckToPhysicalAttackUp)
        },
        {
          BattleskillEffectLogicEnum.strength_magic_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcStrengthToMagicAttackUp)
        },
        {
          BattleskillEffectLogicEnum.agility_magic_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcAgilityToMagicAttackUp)
        },
        {
          BattleskillEffectLogicEnum.dexterity_magic_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcDexterityToMagicAttackUp)
        },
        {
          BattleskillEffectLogicEnum.luck_magic_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcLuckToMagicAttackUp)
        },
        {
          BattleskillEffectLogicEnum.instant_death,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcInstantDeath)
        },
        {
          BattleskillEffectLogicEnum.revenge,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcRevenge)
        },
        {
          BattleskillEffectLogicEnum.mdmg_combi,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcMdmgCombi)
        },
        {
          BattleskillEffectLogicEnum.change_attack_type,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcChangeAttackType)
        },
        {
          BattleskillEffectLogicEnum.invest_passive,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcInvokePassive)
        },
        {
          BattleskillEffectLogicEnum.anohana_trio,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcAnohanaTrio)
        },
        {
          BattleskillEffectLogicEnum.snake_venom,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcSnakeVenom)
        },
        {
          BattleskillEffectLogicEnum.percentage_damage,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcPercentageDamage)
        },
        {
          BattleskillEffectLogicEnum.combi_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcCombiAttack)
        }
      };
      if (this.attacker.IsDontAction || this.attakerIsDontUseSkill)
        return BattleDuelSkill.noneSkills;
      BL.Skill[] skillArray1 = this.InvokeAttackerGeneric();
      if (skillArray1 != BattleDuelSkill.noneSkills)
        return skillArray1;
      foreach (BL.Skill skill in duelSkills)
      {
        foreach (BattleskillEffect effect in skill.skill.Effects)
        {
          if (!this.attacker.IsDontUseSkill(skill.id))
          {
            BattleskillEffectLogicEnum key = effect.effect_logic.Enum;
            if (dictionary.ContainsKey(key) && dictionary[key](skill, effect))
            {
              BL.Skill[] skillArray2 = new BL.Skill[1]
              {
                skill
              };
              this.invokeAttackerSkill = skill;
              this.invokeAttackerSkillEffects.Add(effect);
              return skillArray2;
            }
          }
        }
      }
      return BattleDuelSkill.noneSkills;
    }

    private BL.Skill[] InvokeBiAttack()
    {
      if (this.isSuppressDuelSkill || this.attackStatus.magicBullet != null && this.attackStatus.magicBullet.percentageDamage != null)
        return BattleDuelSkill.noneSkills;
      BL.Skill[] duelSkills = this.attacker.originalUnit.duelSkills;
      Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool>> dictionary = new Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool>>()
      {
        {
          BattleskillEffectLogicEnum.suisei,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcBiAttack)
        },
        {
          BattleskillEffectLogicEnum.combi_attack,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcCombiAttack)
        }
      };
      if (this.attacker.IsDontAction || this.attakerIsDontUseSkill)
        return BattleDuelSkill.noneSkills;
      BL.Skill[] skillArray1 = this.InvokeAttackerGeneric();
      if (skillArray1 != BattleDuelSkill.noneSkills)
        return skillArray1;
      foreach (BL.Skill skill in duelSkills)
      {
        foreach (BattleskillEffect effect in skill.skill.Effects)
        {
          if (!this.attacker.IsDontUseSkill(skill.id))
          {
            BattleskillEffectLogicEnum key = effect.effect_logic.Enum;
            if (dictionary.ContainsKey(key) && dictionary[key](skill, effect))
            {
              BL.Skill[] skillArray2 = new BL.Skill[1]
              {
                skill
              };
              this.invokeAttackerSkill = skill;
              this.invokeAttackerSkillEffects.Add(effect);
              return skillArray2;
            }
          }
        }
      }
      return BattleDuelSkill.noneSkills;
    }

    private BL.Skill[] InvokeAilmentSkills(bool isAI)
    {
      if (!BattleFuncs.isSkillsAndEffectsInvalid(this.attacker, this.defender))
      {
        IEnumerable<BattleskillEffect> investSkillEffect = this.attackStatus.magicBullet == null ? (IEnumerable<BattleskillEffect>) null : this.attackStatus.magicBullet.investSkillEffect;
        if (investSkillEffect != null && investSkillEffect.Count<BattleskillEffect>() >= 1)
        {
          foreach (BattleskillEffect battleskillEffect in investSkillEffect)
          {
            int num = battleskillEffect.GetInt("skill_id");
            bool isUnconditional;
            if (num < 0)
            {
              isUnconditional = true;
              num = -num;
            }
            else
              isUnconditional = false;
            if (num != 0 && MasterData.BattleskillSkill.ContainsKey(num) && MasterData.BattleskillSkill[num].skill_type == BattleskillSkillType.ailment)
            {
              foreach (BL.ISkillEffectListUnit skillEffectListUnit in this.getInvestUnit(this.attacker, this.defender, num, !battleskillEffect.HasKey("range_type") ? 0 : battleskillEffect.GetInt("range_type")))
              {
                if (BattleFuncs.isAilmentInvest(battleskillEffect.GetFloat("percentage_invest"), num, skillEffectListUnit, this.random))
                  this.addInvestSkills(skillEffectListUnit, BattleFuncs.ailmentInvest(num, skillEffectListUnit), true, isUnconditional, 0);
              }
            }
          }
        }
      }
      Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool, bool>> dictionary = new Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool, bool>>()
      {
        {
          BattleskillEffectLogicEnum.invest_skilleffect,
          new Func<BL.Skill, BattleskillEffect, bool, bool>(this.funcInvestSkillEffect)
        }
      };
      if (this.attacker.IsDontAction || this.attakerIsDontUseSkill)
        return BattleDuelSkill.noneSkills;
      foreach (BL.Skill duelSkill in this.attacker.originalUnit.duelSkills)
      {
        foreach (BattleskillEffect effect in duelSkill.skill.Effects)
        {
          if (!this.attacker.IsDontUseSkill(duelSkill.id))
          {
            BattleskillEffectLogicEnum key = effect.effect_logic.Enum;
            if (dictionary.ContainsKey(key) && dictionary[key](duelSkill, effect, isAI))
              return new BL.Skill[1]{ duelSkill };
          }
        }
      }
      return BattleDuelSkill.noneSkills;
    }

    private void InvokeElementSkill()
    {
      List<CommonElement> element = new List<CommonElement>();
      this.attackerElementSkills = BattleDuelSkill.noneSkills;
      this.defenderElementSkills = BattleDuelSkill.noneSkills;
      if (this.attackStatus.isMagic && this.attackStatus.magicBullet != null && this.attackStatus.magicBullet.skill != null && this.attackStatus.magicBullet.skill.Effects != null && ((IEnumerable<BattleskillEffect>) this.attackStatus.magicBullet.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element)))
        element.Add(this.attackStatus.magicBullet.skill.element);
      this.attackerElementSkills = ((IEnumerable<BL.Skill>) this.attacker.originalUnit.duelSkills).Where<BL.Skill>((Func<BL.Skill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element)))).ToArray<BL.Skill>();
      element.AddRange(((IEnumerable<BL.Skill>) this.attackerElementSkills).Select<BL.Skill, CommonElement>((Func<BL.Skill, CommonElement>) (x => x.skill.element)));
      this.defenderElementSkills = ((IEnumerable<BL.Skill>) this.defender.originalUnit.duelSkills).Where<BL.Skill>((Func<BL.Skill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.effect_element && ef.HasKey("target_element") && element.Any<CommonElement>((Func<CommonElement, bool>) (e => (CommonElement) ef.GetInt("target_element") == e)))))).ToArray<BL.Skill>();
      if (this.defenderElementSkills.Length <= 0)
        return;
      foreach (CommonElement commonElement in element)
      {
        CommonElement e = commonElement;
        foreach (BattleskillEffect battleskillEffect in ((IEnumerable<BL.Skill>) this.defenderElementSkills).SelectMany<BL.Skill, BattleskillEffect>((Func<BL.Skill, IEnumerable<BattleskillEffect>>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.effect_element && ef.HasKey("target_element") && (CommonElement) ef.GetInt("target_element") == e)).Select<BattleskillEffect, BattleskillEffect>((Func<BattleskillEffect, BattleskillEffect>) (ef => ef)))))
          this.damageRate *= battleskillEffect.GetFloat("damage_ratio");
      }
    }

    public void InvokeDamageSkill(int finalAttack)
    {
      this.finalAttack = finalAttack;
      this.isHit = finalAttack >= 1;
      this.invokeRate = new float?();
      BL.Skill[] second1 = this.InvokeAttackerDamageSkill();
      if (second1 != BattleDuelSkill.noneSkills)
        this.attackerSkills = ((IEnumerable<BL.Skill>) this.attackerSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) second1).ToArray<BL.Skill>();
      BL.Skill[] second2 = this.InvokeDefenderDamageSkill();
      if (second2 == BattleDuelSkill.noneSkills)
        return;
      this.defenderSkills = ((IEnumerable<BL.Skill>) this.defenderSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) second2).ToArray<BL.Skill>();
    }

    public BL.Skill[] InvokeAttackerDamageSkill() => BattleDuelSkill.noneSkills;

    public BL.Skill[] InvokeDefenderDamageSkill()
    {
      BL.Skill[] duelSkills = this.defender.originalUnit.duelSkills;
      Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool>> dictionary = new Dictionary<BattleskillEffectLogicEnum, Func<BL.Skill, BattleskillEffect, bool>>()
      {
        {
          BattleskillEffectLogicEnum.prayer,
          new Func<BL.Skill, BattleskillEffect, bool>(this.funcPrayer)
        }
      };
      if (this.defender.IsDontAction || this.defenderIsDontUseSkill)
        return BattleDuelSkill.noneSkills;
      foreach (BL.Skill skill in duelSkills)
      {
        foreach (BattleskillEffect effect in skill.skill.Effects)
        {
          if (!this.defender.IsDontUseSkill(skill.id))
          {
            BattleskillEffectLogicEnum key = effect.effect_logic.Enum;
            if (dictionary.ContainsKey(key) && dictionary[key](skill, effect))
              return new BL.Skill[1]{ skill };
          }
        }
      }
      return BattleDuelSkill.noneSkills;
    }

    private bool funcBiAttack(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.attackCount = effect.GetInt("attack_count");
      this.damageRate *= effect.GetFloat("percentage_damage");
      return true;
    }

    private bool funcRyusei(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageRate *= effect.GetFloat("percentage");
      return true;
    }

    private bool funcMagicSuisei(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageRate *= effect.GetFloat("percentage_damage") * effect.GetFloat("attack_count");
      return true;
    }

    private bool funcGekko(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageRate *= effect.GetFloat("percentage");
      this.defenseDownPhysicalRate *= effect.GetFloat("percentage_decrease");
      return true;
    }

    private bool funcTaiyo(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      float num1 = effect.GetFloat("hit_value");
      if ((double) num1 > 0.0)
        this.FixHit = new float?(num1);
      this.damageRate *= effect.GetFloat("percentage_damage");
      float num2 = effect.GetFloat("percentage_drain");
      if ((double) this.drainRate < (double) num2)
        this.drainRate = num2;
      return true;
    }

    private bool funcParameterToPhysicalAttackUp(
      BL.Skill skill,
      BattleskillEffect effect,
      int base_parameter)
    {
      if (this.attackStatus.isMagic || !this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageValue = (float) base_parameter * effect.GetFloat("percentage_damage");
      return true;
    }

    private bool funcIntelligenceToPhysicalAttackUp(BL.Skill skill, BattleskillEffect effect)
    {
      return this.funcParameterToPhysicalAttackUp(skill, effect, this.attackStatus.duelParameter.attackerUnitParameter.Intelligence);
    }

    private bool funcAgilityToPhysicalAttackUp(BL.Skill skill, BattleskillEffect effect)
    {
      return this.funcParameterToPhysicalAttackUp(skill, effect, this.attackStatus.duelParameter.attackerUnitParameter.Agility);
    }

    private bool funcDexterityToPhysicalAttackUp(BL.Skill skill, BattleskillEffect effect)
    {
      return this.funcParameterToPhysicalAttackUp(skill, effect, this.attackStatus.duelParameter.attackerUnitParameter.Dexterity);
    }

    private bool funcLuckToPhysicalAttackUp(BL.Skill skill, BattleskillEffect effect)
    {
      return this.funcParameterToPhysicalAttackUp(skill, effect, this.attackStatus.duelParameter.attackerUnitParameter.Luck);
    }

    private bool funcParameterToMagicAttackUp(
      BL.Skill skill,
      BattleskillEffect effect,
      int base_parameter)
    {
      if (!this.attackStatus.isMagic || !this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageValue = (float) base_parameter * effect.GetFloat("percentage_damage");
      return true;
    }

    private bool funcStrengthToMagicAttackUp(BL.Skill skill, BattleskillEffect effect)
    {
      return this.funcParameterToMagicAttackUp(skill, effect, this.attackStatus.duelParameter.attackerUnitParameter.Strength);
    }

    private bool funcAgilityToMagicAttackUp(BL.Skill skill, BattleskillEffect effect)
    {
      return this.funcParameterToMagicAttackUp(skill, effect, this.attackStatus.duelParameter.attackerUnitParameter.Agility);
    }

    private bool funcDexterityToMagicAttackUp(BL.Skill skill, BattleskillEffect effect)
    {
      return this.funcParameterToMagicAttackUp(skill, effect, this.attackStatus.duelParameter.attackerUnitParameter.Dexterity);
    }

    private bool funcLuckToMagicAttackUp(BL.Skill skill, BattleskillEffect effect)
    {
      return this.funcParameterToMagicAttackUp(skill, effect, this.attackStatus.duelParameter.attackerUnitParameter.Luck);
    }

    private bool funcInstantDeath(BL.Skill skill, BattleskillEffect effect)
    {
      if (effect.GetInt("equip_gear_king_id") != this.attacker.originalUnit.playerUnit.equippedGearOrInitial.kind_GearKind || !this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.FixDamage = new int?(this.currentDefenderHp);
      return true;
    }

    private bool funcRevenge(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      int num1 = this.attacker.originalUnit.parameter.Hp - this.currentAttakerHp;
      float num2 = 0.0f;
      if (effect.HasKey("base_value_damage"))
        num2 = effect.GetFloat("base_value_damage");
      this.damageValue = num2 + (float) num1 * effect.GetFloat("percentage_damage");
      return true;
    }

    private bool funcMdmgCombi(BL.Skill skill, BattleskillEffect effect)
    {
      if (this.isColossume)
        return false;
      List<BL.ISkillEffectListUnit> list1 = BattleFuncs.getTargets(this.attacker.originalUnit, new int[2]
      {
        effect.GetInt("min_range"),
        effect.GetInt("max_range")
      }, new BL.ForceID[1]
      {
        BattleFuncs.getForceID(this.attacker.originalUnit)
      }, (this.isAI ? 1 : 0) != 0).Select<BL.UnitPosition, BL.ISkillEffectListUnit>((Func<BL.UnitPosition, BL.ISkillEffectListUnit>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x))).ToList<BL.ISkillEffectListUnit>();
      Judgement.BeforeDuelParameter beforeDuelParameter = (Judgement.BeforeDuelParameter) null;
      bool flag = false;
      float percentage_invocation = effect.GetFloat("percentage_invocation");
      float num1 = effect.GetFloat("percentage_damage");
      if (list1.Count > 0)
      {
        int target_skill_id = effect.GetInt("target_skill_id");
        List<BL.ISkillEffectListUnit> list2 = list1.Where<BL.ISkillEffectListUnit>((Func<BL.ISkillEffectListUnit, bool>) (x => ((IEnumerable<BL.Skill>) x.originalUnit.duelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (duelSkill => duelSkill.id == target_skill_id)) && this.attacker.originalUnit.unit.character.ID != x.originalUnit.unit.character.ID)).ToList<BL.ISkillEffectListUnit>();
        if (list2.Count > 0)
        {
          Tuple<int, int> pos = BattleFuncs.getUnitCell(this.attacker.originalUnit, this.isAI);
          BL.ISkillEffectListUnit beAttackUnit = list2.OrderBy<BL.ISkillEffectListUnit, int>((Func<BL.ISkillEffectListUnit, int>) (x =>
          {
            int num2 = 0;
            Tuple<int, int> unitCell = BattleFuncs.getUnitCell(x.originalUnit, this.isAI);
            int num3 = BL.fieldDistance(pos.Item1, pos.Item2, unitCell.Item1, unitCell.Item2);
            int num4 = unitCell.Item1 - pos.Item1;
            int num5 = unitCell.Item2 - pos.Item2;
            int num6 = 0;
            for (int index = 0; index < num3; ++index)
              num6 += 4 * index;
            if (num4 < 0)
              num2 = num6 + num3 * 3 - num5;
            else if (num4 > 0)
              num2 = num6 + num3 * 1 + num5;
            else if (num5 > 0)
              num2 = num6 + num3 * 2;
            else if (num5 < 0)
              num2 = num6;
            return num2;
          })).FirstOrDefault<BL.ISkillEffectListUnit>();
          if (beAttackUnit != null)
          {
            Tuple<int, int> unitCell1 = BattleFuncs.getUnitCell(this.defender.originalUnit, this.isAI);
            BL.MagicBullet beAttackMagicBullet = ((IEnumerable<BL.MagicBullet>) beAttackUnit.originalUnit.magicBullets).Where<BL.MagicBullet>((Func<BL.MagicBullet, bool>) (x => x.isAttack)).OrderBy<BL.MagicBullet, int>((Func<BL.MagicBullet, int>) (x => x.cost)).FirstOrDefault<BL.MagicBullet>();
            flag = beAttackMagicBullet != null;
            beforeDuelParameter = Judgement.BeforeDuelParameter.CreateDuelSkill(beAttackUnit, beAttackMagicBullet, BattleFuncs.getPanel(pos.Item1, pos.Item2).landform, this.defender, BattleFuncs.getPanel(unitCell1.Item1, unitCell1.Item2).landform, this.distance, this.currentDefenderHp);
            Tuple<int, int> unitCell2 = BattleFuncs.getUnitCell(beAttackUnit.originalUnit, this.isAI);
            int num7 = BL.fieldDistance(pos.Item1, pos.Item2, unitCell2.Item1, unitCell2.Item2);
            int num8 = Mathf.Max(0, effect.GetInt("max_range") - (num7 - 1));
            percentage_invocation += (float) num8 * effect.GetFloat("range_add_precentage_invocation");
            num1 += (float) num8 * effect.GetFloat("range_add_precentage_damage");
          }
        }
      }
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, percentage_invocation))
        return false;
      if (beforeDuelParameter != null)
        this.damageValue = !flag ? (float) beforeDuelParameter.DisplayPhysicalAttack : (float) beforeDuelParameter.DisplayMagicAttack;
      else
        num1 *= 1.5f;
      this.damageRate *= num1;
      int num9 = effect.GetInt("skill_id");
      if (BattleFuncs.isAilmentInvest(1f, num9, this.defender, this.random))
        this.addInvestSkills(this.defender, BattleFuncs.ailmentInvest(num9, this.defender), true, false, 0);
      return true;
    }

    private bool funcChangeAttackType(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.isChageAttackType = true;
      this.damageRate *= effect.GetFloat("percentage_damage");
      this.attackRate *= effect.GetFloat("percentage_attack");
      return true;
    }

    private bool funcInvokePassive(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageRate *= effect.GetFloat("percentage_damage");
      int num = effect.GetInt("skill_id");
      foreach (BL.ISkillEffectListUnit skillEffectListUnit in this.getInvestUnit(this.attacker, this.defender, num, !effect.HasKey("range_type") ? 0 : effect.GetInt("range_type")))
      {
        float lottery = 1f;
        if (effect.HasKey("percentage_invest"))
          lottery = effect.GetFloat("percentage_invest") + (!effect.HasKey("percentage_invest_levelup") ? 0.0f : effect.GetFloat("percentage_invest_levelup")) * (float) skill.level;
        if (MasterData.BattleskillSkill[num].skill_type == BattleskillSkillType.ailment)
        {
          if (BattleFuncs.isAilmentInvest(lottery, num, skillEffectListUnit, this.random))
            this.addInvestSkills(skillEffectListUnit, BattleFuncs.ailmentInvest(num, skillEffectListUnit), true, false, 0);
        }
        else if ((double) lottery >= (double) this.random.NextFloat())
          this.addInvestSkills(skillEffectListUnit, new BL.Skill[1]
          {
            new BL.Skill() { id = num }
          }, false, false, 0);
      }
      return true;
    }

    private bool funcAnohanaTrio(BL.Skill skill, BattleskillEffect effect)
    {
      if (this.isColossume)
        return false;
      List<BL.ISkillEffectListUnit> list1 = BattleFuncs.getTargets(this.attacker.originalUnit, new int[2]
      {
        1,
        effect.GetInt("max_range")
      }, new BL.ForceID[1]
      {
        BattleFuncs.getForceID(this.attacker.originalUnit)
      }, (this.isAI ? 1 : 0) != 0).Select<BL.UnitPosition, BL.ISkillEffectListUnit>((Func<BL.UnitPosition, BL.ISkillEffectListUnit>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x))).ToList<BL.ISkillEffectListUnit>();
      Judgement.BeforeDuelParameter beforeDuelParameter1 = (Judgement.BeforeDuelParameter) null;
      Judgement.BeforeDuelParameter beforeDuelParameter2 = (Judgement.BeforeDuelParameter) null;
      bool flag1 = false;
      bool flag2 = false;
      float percentage_invocation = effect.GetFloat("percentage_invocation");
      float num1 = effect.GetFloat("percentage_damage");
      if (list1.Count > 1)
      {
        BL.ISkillEffectListUnit beAttackUnit1 = (BL.ISkillEffectListUnit) null;
        BL.ISkillEffectListUnit beAttackUnit2 = (BL.ISkillEffectListUnit) null;
        int target_skill_id = effect.GetInt("target_skill_id1");
        List<BL.ISkillEffectListUnit> list2 = list1.Where<BL.ISkillEffectListUnit>((Func<BL.ISkillEffectListUnit, bool>) (x => ((IEnumerable<BL.Skill>) x.originalUnit.duelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (duelSkill => duelSkill.id == target_skill_id)) && this.attacker.originalUnit.unit.character.ID != x.originalUnit.unit.character.ID)).ToList<BL.ISkillEffectListUnit>();
        Tuple<int, int> attacker_pos = BattleFuncs.getUnitCell(this.attacker.originalUnit, this.isAI);
        if (list2.Count > 0)
          beAttackUnit1 = list2.OrderBy<BL.ISkillEffectListUnit, int>((Func<BL.ISkillEffectListUnit, int>) (x =>
          {
            int num2 = 0;
            Tuple<int, int> unitCell = BattleFuncs.getUnitCell(x.originalUnit, this.isAI);
            int num3 = BL.fieldDistance(attacker_pos.Item1, attacker_pos.Item2, unitCell.Item1, unitCell.Item2);
            int num4 = unitCell.Item1 - attacker_pos.Item1;
            int num5 = unitCell.Item2 - attacker_pos.Item2;
            int num6 = 0;
            for (int index = 0; index < num3; ++index)
              num6 += 4 * index;
            if (num4 < 0)
              num2 = num6 + num3 * 3 - num5;
            else if (num4 > 0)
              num2 = num6 + num3 * 1 + num5;
            else if (num5 > 0)
              num2 = num6 + num3 * 2;
            else if (num5 < 0)
              num2 = num6;
            return num2;
          })).FirstOrDefault<BL.ISkillEffectListUnit>();
        target_skill_id = effect.GetInt("target_skill_id2");
        List<BL.ISkillEffectListUnit> list3 = list1.Where<BL.ISkillEffectListUnit>((Func<BL.ISkillEffectListUnit, bool>) (x => ((IEnumerable<BL.Skill>) x.originalUnit.duelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (duelSkill => duelSkill.id == target_skill_id)) && this.attacker.originalUnit.unit.character.ID != x.originalUnit.unit.character.ID)).ToList<BL.ISkillEffectListUnit>();
        if (list3.Count > 0)
          beAttackUnit2 = list3.OrderBy<BL.ISkillEffectListUnit, int>((Func<BL.ISkillEffectListUnit, int>) (x =>
          {
            int num7 = 0;
            Tuple<int, int> unitCell = BattleFuncs.getUnitCell(x.originalUnit, this.isAI);
            int num8 = BL.fieldDistance(attacker_pos.Item1, attacker_pos.Item2, unitCell.Item1, unitCell.Item2);
            int num9 = unitCell.Item1 - attacker_pos.Item1;
            int num10 = unitCell.Item2 - attacker_pos.Item2;
            int num11 = 0;
            for (int index = 0; index < num8; ++index)
              num11 += 4 * index;
            if (num9 < 0)
              num7 = num11 + num8 * 3 - num10;
            else if (num9 > 0)
              num7 = num11 + num8 * 1 + num10;
            else if (num10 > 0)
              num7 = num11 + num8 * 2;
            else if (num10 < 0)
              num7 = num11;
            return num7;
          })).FirstOrDefault<BL.ISkillEffectListUnit>();
        if (beAttackUnit1 != null && beAttackUnit2 != null)
        {
          Tuple<int, int> unitCell1 = BattleFuncs.getUnitCell(beAttackUnit1.originalUnit, this.isAI);
          Tuple<int, int> unitCell2 = BattleFuncs.getUnitCell(beAttackUnit2.originalUnit, this.isAI);
          Tuple<int, int> unitCell3 = BattleFuncs.getUnitCell(this.defender.originalUnit, this.isAI);
          BL.MagicBullet beAttackMagicBullet1 = ((IEnumerable<BL.MagicBullet>) beAttackUnit1.originalUnit.magicBullets).Where<BL.MagicBullet>((Func<BL.MagicBullet, bool>) (x => x.isAttack)).OrderBy<BL.MagicBullet, int>((Func<BL.MagicBullet, int>) (x => x.cost)).FirstOrDefault<BL.MagicBullet>();
          flag1 = beAttackMagicBullet1 != null;
          beforeDuelParameter1 = Judgement.BeforeDuelParameter.CreateDuelSkill(beAttackUnit1, beAttackMagicBullet1, BattleFuncs.getPanel(attacker_pos.Item1, attacker_pos.Item2).landform, this.defender, BattleFuncs.getPanel(unitCell3.Item1, unitCell3.Item2).landform, this.distance, this.currentDefenderHp);
          BL.MagicBullet beAttackMagicBullet2 = ((IEnumerable<BL.MagicBullet>) beAttackUnit2.originalUnit.magicBullets).Where<BL.MagicBullet>((Func<BL.MagicBullet, bool>) (x => x.isAttack)).OrderBy<BL.MagicBullet, int>((Func<BL.MagicBullet, int>) (x => x.cost)).FirstOrDefault<BL.MagicBullet>();
          flag2 = beAttackMagicBullet2 != null;
          beforeDuelParameter2 = Judgement.BeforeDuelParameter.CreateDuelSkill(beAttackUnit2, beAttackMagicBullet2, BattleFuncs.getPanel(attacker_pos.Item1, attacker_pos.Item2).landform, this.defender, BattleFuncs.getPanel(unitCell3.Item1, unitCell3.Item2).landform, this.distance, this.currentDefenderHp);
          int num12 = BL.fieldDistance(unitCell1.Item1, unitCell1.Item2, attacker_pos.Item1, attacker_pos.Item2);
          int num13 = BL.fieldDistance(unitCell2.Item1, unitCell2.Item2, attacker_pos.Item1, attacker_pos.Item2);
          int num14 = num12 <= num13 ? num13 : num12;
          int num15 = Mathf.Max(0, effect.GetInt("max_range") - (num14 - 1));
          percentage_invocation += (float) num15 * effect.GetFloat("range_add_precentage_invocation");
          num1 += (float) num15 * effect.GetFloat("range_add_precentage_damage");
        }
      }
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, percentage_invocation))
        return false;
      if (beforeDuelParameter1 != null && beforeDuelParameter2 != null)
      {
        this.damageValue = !flag1 ? (float) beforeDuelParameter1.DisplayPhysicalAttack : (float) beforeDuelParameter1.DisplayMagicAttack;
        if (flag2)
          this.damageValue += (float) beforeDuelParameter2.DisplayMagicAttack;
        else
          this.damageValue += (float) beforeDuelParameter2.DisplayPhysicalAttack;
      }
      else
        num1 *= 2f;
      this.damageRate *= num1;
      int skillId = effect.GetInt("skill_id");
      BL.Skill[] skills = new BL.Skill[1]
      {
        new BL.Skill() { id = skillId }
      };
      foreach (BL.ISkillEffectListUnit unit in this.getInvestUnit(this.attacker, this.defender, skillId, 0))
        this.addInvestSkills(unit, skills, false, false, 0);
      return true;
    }

    private bool funcSnakeVenom(BL.Skill skill, BattleskillEffect effect)
    {
      bool flag = !this.isInvokedAmbush ? this.isAttacker : !this.isAttacker;
      if (effect.GetInt("is_attack") == 1 && !flag || effect.GetInt("is_attack") == 2 && flag || !this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageValue += (float) effect.GetInt("attack_value");
      this.damageRate *= effect.GetFloat("attack_percentage");
      BL.Skill[] skills = new BL.Skill[1]{ skill };
      if (effect.GetInt("is_hit_only") != 0)
        this.addInvestSkills(this.defender, skills, false, false, 0);
      else
        this.addInvestSkills(this.defender, skills, false, true, 0);
      return true;
    }

    private bool funcPercentageDamage(BL.Skill skill, BattleskillEffect effect)
    {
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      float num = effect.GetFloat("hit_value");
      if ((double) num > 0.0)
        this.FixHit = new float?(num);
      this.PercentageDamageRate = new float?(effect.GetFloat("percentage"));
      return true;
    }

    private bool funcCombiAttack(BL.Skill skill, BattleskillEffect effect)
    {
      if (this.isColossume)
        return false;
      int num1 = effect.GetInt("attack_count");
      if (num1 <= 1 && this.isBiattack || num1 >= 2 && !this.isBiattack)
        return false;
      List<BL.ISkillEffectListUnit> list1 = BattleFuncs.getTargets(this.attacker.originalUnit, new int[2]
      {
        1,
        effect.GetInt("max_range")
      }, new BL.ForceID[1]
      {
        BattleFuncs.getForceID(this.attacker.originalUnit)
      }, (this.isAI ? 1 : 0) != 0).Select<BL.UnitPosition, BL.ISkillEffectListUnit>((Func<BL.UnitPosition, BL.ISkillEffectListUnit>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x))).ToList<BL.ISkillEffectListUnit>();
      Judgement.BeforeDuelParameter beforeDuelParameter = (Judgement.BeforeDuelParameter) null;
      bool flag = false;
      float percentage_invocation = effect.GetFloat("percentage_invocation");
      float num2 = effect.GetFloat("percentage_damage");
      if (list1.Count > 0)
      {
        int target_skill_id = effect.GetInt("target_skill_id");
        List<BL.ISkillEffectListUnit> list2 = list1.Where<BL.ISkillEffectListUnit>((Func<BL.ISkillEffectListUnit, bool>) (x => ((IEnumerable<BL.Skill>) x.originalUnit.duelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (duelSkill => duelSkill.id == target_skill_id)) && this.attacker.originalUnit.unit.character.ID != x.originalUnit.unit.character.ID)).ToList<BL.ISkillEffectListUnit>();
        if (list2.Count > 0)
        {
          Tuple<int, int> pos = BattleFuncs.getUnitCell(this.attacker.originalUnit, this.isAI);
          BL.ISkillEffectListUnit beAttackUnit = list2.OrderBy<BL.ISkillEffectListUnit, int>((Func<BL.ISkillEffectListUnit, int>) (x =>
          {
            int num3 = 0;
            Tuple<int, int> unitCell = BattleFuncs.getUnitCell(x.originalUnit, this.isAI);
            int num4 = BL.fieldDistance(pos.Item1, pos.Item2, unitCell.Item1, unitCell.Item2);
            int num5 = unitCell.Item1 - pos.Item1;
            int num6 = unitCell.Item2 - pos.Item2;
            int num7 = 0;
            for (int index = 0; index < num4; ++index)
              num7 += 4 * index;
            if (num5 < 0)
              num3 = num7 + num4 * 3 - num6;
            else if (num5 > 0)
              num3 = num7 + num4 * 1 + num6;
            else if (num6 > 0)
              num3 = num7 + num4 * 2;
            else if (num6 < 0)
              num3 = num7;
            return num3;
          })).FirstOrDefault<BL.ISkillEffectListUnit>();
          if (beAttackUnit != null)
          {
            Tuple<int, int> unitCell1 = BattleFuncs.getUnitCell(this.defender.originalUnit, this.isAI);
            BL.MagicBullet beAttackMagicBullet = ((IEnumerable<BL.MagicBullet>) beAttackUnit.originalUnit.magicBullets).Where<BL.MagicBullet>((Func<BL.MagicBullet, bool>) (x => x.isAttack)).OrderBy<BL.MagicBullet, int>((Func<BL.MagicBullet, int>) (x => x.cost)).FirstOrDefault<BL.MagicBullet>();
            flag = beAttackMagicBullet != null;
            beforeDuelParameter = Judgement.BeforeDuelParameter.CreateDuelSkill(beAttackUnit, beAttackMagicBullet, BattleFuncs.getPanel(pos.Item1, pos.Item2).landform, this.defender, BattleFuncs.getPanel(unitCell1.Item1, unitCell1.Item2).landform, this.distance, this.currentDefenderHp);
            Tuple<int, int> unitCell2 = BattleFuncs.getUnitCell(beAttackUnit.originalUnit, this.isAI);
            int num8 = BL.fieldDistance(pos.Item1, pos.Item2, unitCell2.Item1, unitCell2.Item2);
            int num9 = Mathf.Max(0, effect.GetInt("max_range") - (num8 - 1));
            percentage_invocation += (float) num9 * effect.GetFloat("range_add_precentage_invocation");
            num2 += (float) num9 * effect.GetFloat("range_add_precentage_damage");
          }
        }
      }
      if (!this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, skill.level, percentage_invocation))
        return false;
      if (beforeDuelParameter != null)
        this.damageValue = !flag ? (float) beforeDuelParameter.DisplayPhysicalAttack : (float) beforeDuelParameter.DisplayMagicAttack;
      else
        num2 *= 1.5f;
      this.damageRate *= num2;
      this.attackCount = num1;
      float num10 = effect.GetFloat("percentage_drain");
      if ((double) this.drainRate < (double) num10)
        this.drainRate = num10;
      float num11 = effect.GetFloat("hit_value");
      if ((double) num11 > 0.0)
        this.FixHit = new float?(num11);
      int num12 = effect.GetInt("skill_id");
      if (num12 != 0 && MasterData.BattleskillSkill.ContainsKey(num12))
      {
        if (MasterData.BattleskillSkill[num12].skill_type == BattleskillSkillType.ailment)
        {
          if (BattleFuncs.isAilmentInvest(1f, num12, this.defender, this.random))
            this.addInvestSkills(this.defender, BattleFuncs.ailmentInvest(num12, this.defender), true, false, 0);
        }
        else
        {
          BL.Skill[] skills = new BL.Skill[1]
          {
            new BL.Skill() { id = num12 }
          };
          foreach (BL.ISkillEffectListUnit unit in this.getInvestUnit(this.attacker, this.defender, num12, 0))
            this.addInvestSkills(unit, skills, false, false, 0);
        }
      }
      return true;
    }

    private bool funcShield(BL.Skill skill, BattleskillEffect effect)
    {
      if (effect.GetInt("gear_kind_id") != this.attacker.originalUnit.playerUnit.equippedGearOrInitial.kind_GearKind || !this.isInvoke(this.defender, this.attacker, this.attackStatus.duelParameter.defenderUnitParameter, this.attackStatus.duelParameter.attackerUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageRate *= effect.GetFloat("percentage");
      return true;
    }

    private bool funcOutOfRangeDefence(BL.Skill skill, BattleskillEffect effect)
    {
      if (this.distance == 0)
        return false;
      BL.Unit.GearRange gearRange = this.defender.originalUnit.gearRange();
      if (NC.IsReach(gearRange.Min, gearRange.Max, this.distance) || !this.isInvoke(this.defender, this.attacker, this.attackStatus.duelParameter.defenderUnitParameter, this.attackStatus.duelParameter.attackerUnitParameter, skill.level, effect.GetFloat("percentage_invocation")))
        return false;
      this.damageRate *= effect.GetFloat("percentage_decrease");
      return true;
    }

    private bool funcCounter(BL.Skill skill, BattleskillEffect effect)
    {
      if (effect.GetInt("gear_kind_id") != this.attacker.originalUnit.playerUnit.equippedGearOrInitial.kind_GearKind || !NC.IsReach(effect.GetInt("min_range"), effect.GetInt("max_range"), this.distance))
        return false;
      this.isInvokeCounterAttack = true;
      this.counterDamageRate = effect.GetFloat("damage_ratio");
      this.counterAttackRate = effect.GetFloat("counter_attack_ratio");
      return true;
    }

    private bool funcPrayer(BL.Skill skill, BattleskillEffect effect)
    {
      if (this.defenderSkills.Length >= 1 || this.isInvokedPrayer || this.defenderDuelBeginHp <= 1 || this.finalAttack < this.currentDefenderHp)
        return false;
      if (effect.HasKey("invoke_gamemode"))
      {
        int num = effect.GetInt("invoke_gamemode");
        if (num == 1 && this.isColossume || num == 2 && !this.isColossume)
          return false;
      }
      if (this.distance != 0 && effect.HasKey("out_of_range"))
      {
        int num = effect.GetInt("out_of_range");
        if (num != 0)
        {
          BL.Unit.GearRange gearRange = this.defender.originalUnit.gearRange();
          bool flag = NC.IsReach(gearRange.Min, gearRange.Max, this.distance);
          if (num == 1 && flag || num == 2 && !flag)
            return false;
        }
      }
      return this.isInvoke(this.defender, this.attacker, this.attackStatus.duelParameter.defenderUnitParameter, this.attackStatus.duelParameter.attackerUnitParameter, skill.level, effect.GetFloat("percentage_invocation"), effect);
    }

    private bool funcInvestSkillEffect(BL.Skill skill, BattleskillEffect effect, bool isAI)
    {
      if (this.isHit)
      {
        float lottery = effect.GetFloat("percentage_invest") + effect.GetFloat("percentage_invest_levelup") * (float) skill.level;
        int num = effect.GetInt("skill_id");
        if (BattleFuncs.isAilmentInvest(lottery, num, this.defender, this.random))
          this.addInvestSkills(this.defender, BattleFuncs.ailmentInvest(num, this.defender), true, false, 0);
      }
      return true;
    }

    private bool isInvoke(
      BL.ISkillEffectListUnit invoke,
      BL.ISkillEffectListUnit target,
      Judgement.BeforeDuelUnitParameter invokeParameter,
      Judgement.BeforeDuelUnitParameter targetParameter,
      int skill_level,
      float percentage_invocation,
      BattleskillEffect effect = null)
    {
      return BattleFuncs.isInvoke(invoke, target, invokeParameter, targetParameter, skill_level, percentage_invocation, this.random, this.invokeRate, effect);
    }

    private bool CheckInvokeGeneric(BattleDuelSkill.InvokeGenericWork work)
    {
      if (work.HasKey("invoke_gamemode"))
      {
        int num = work.GetInt("invoke_gamemode");
        if (num == 1 && this.isColossume || num == 2 && !this.isColossume)
          return false;
      }
      if (work.HasKey("attacker_gear_kind_id"))
      {
        int num = work.GetInt("attacker_gear_kind_id");
        if (num != 0 && num != this.attacker.originalUnit.playerUnit.equippedGearOrInitial.kind_GearKind)
          return false;
      }
      if (work.HasKey("defender_gear_kind_id"))
      {
        int num = work.GetInt("defender_gear_kind_id");
        if (num != 0 && num != this.defender.originalUnit.playerUnit.equippedGearOrInitial.kind_GearKind)
          return false;
      }
      if (work.HasKey("attacker_base_gear_kind_id"))
      {
        int num = work.GetInt("attacker_base_gear_kind_id");
        if (num != 0 && num != this.attacker.originalUnit.unit.kind.ID)
          return false;
      }
      if (work.HasKey("defender_base_gear_kind_id"))
      {
        int num = work.GetInt("defender_base_gear_kind_id");
        if (num != 0 && num != this.defender.originalUnit.unit.kind.ID)
          return false;
      }
      if (work.HasKey("attacker_element"))
      {
        int num = work.GetInt("attacker_element");
        if (num != 0 && (CommonElement) num != this.attacker.originalUnit.playerUnit.GetElement())
          return false;
      }
      if (work.HasKey("defender_element"))
      {
        int num = work.GetInt("defender_element");
        if (num != 0 && (CommonElement) num != this.defender.originalUnit.playerUnit.GetElement())
          return false;
      }
      if (work.HasKey("attacker_job_id"))
      {
        int num = work.GetInt("attacker_job_id");
        if (num != 0 && num != this.attacker.originalUnit.job.ID)
          return false;
      }
      if (work.HasKey("defender_job_id"))
      {
        int num = work.GetInt("defender_job_id");
        if (num != 0 && num != this.defender.originalUnit.job.ID)
          return false;
      }
      if (work.HasKey("attacker_family_id"))
      {
        int family = work.GetInt("attacker_family_id");
        if (family != 0 && !this.attacker.originalUnit.unit.HasFamily((UnitFamily) family))
          return false;
      }
      if (work.HasKey("defender_family_id"))
      {
        int family = work.GetInt("defender_family_id");
        if (family != 0 && !this.defender.originalUnit.unit.HasFamily((UnitFamily) family))
          return false;
      }
      if (this.distance != 0)
      {
        if (work.HasKey("min_range"))
        {
          int num = work.GetInt("min_range");
          if (num != 0 && this.distance < num)
            return false;
        }
        if (work.HasKey("max_range"))
        {
          int num = work.GetInt("max_range");
          if (num != 0 && this.distance > num)
            return false;
        }
      }
      if (work.HasKey("attack_phase"))
      {
        int num = work.GetInt("attack_phase");
        if (num == 1 && this.isOneMoreAttack || num == 2 && !this.isOneMoreAttack)
          return false;
      }
      BL.ISkillEffectListUnit[] skillEffectListUnitArray = new BL.ISkillEffectListUnit[2]
      {
        this.attacker,
        this.defender
      };
      string[] strArray1 = new string[2]
      {
        "attacker",
        "defender"
      };
      int[] numArray = new int[2]
      {
        this.currentAttakerHp,
        this.currentDefenderHp
      };
      string[] strArray2 = new string[4]
      {
        "gt",
        "lt",
        "ge",
        "le"
      };
      Func<int, int, bool>[] funcArray = new Func<int, int, bool>[4]
      {
        (Func<int, int, bool>) ((hp, border) => hp > border),
        (Func<int, int, bool>) ((hp, border) => hp < border),
        (Func<int, int, bool>) ((hp, border) => hp >= border),
        (Func<int, int, bool>) ((hp, border) => hp <= border)
      };
      for (int index1 = 0; index1 < 2; ++index1)
      {
        string str = strArray1[index1] + "_hp";
        for (int index2 = 0; index2 < 4; ++index2)
        {
          string key1 = str + "_percentage_" + strArray2[index2];
          if (work.HasKey(key1))
          {
            float num = work.GetFloat(key1);
            if ((double) num != 0.0 && !funcArray[index2](numArray[index1], Mathf.CeilToInt((float) skillEffectListUnitArray[index1].originalUnit.parameter.Hp * num)))
              return false;
          }
          string key2 = str + "_value_" + strArray2[index2];
          if (work.HasKey(key2))
          {
            int num = work.GetInt(key2);
            if (num != 0 && !funcArray[index2](numArray[index1], num))
              return false;
          }
        }
      }
      return true;
    }

    private List<List<BattleskillEffect>> CreateEffectPack(BL.Skill skill, string borderKey)
    {
      List<List<BattleskillEffect>> effectPack = new List<List<BattleskillEffect>>();
      List<BattleskillEffect> battleskillEffectList = (List<BattleskillEffect>) null;
      for (int index = 0; index < skill.skill.Effects.Length; ++index)
      {
        BattleskillEffect effect = skill.skill.Effects[index];
        if (effect.HasKey(borderKey))
        {
          battleskillEffectList = new List<BattleskillEffect>();
          effectPack.Add(battleskillEffectList);
        }
        battleskillEffectList?.Add(effect);
      }
      return effectPack;
    }

    private void funcGenericSkillInvest(
      BattleDuelSkill.InvokeGenericWork work,
      BL.ISkillEffectListUnit myself,
      BL.ISkillEffectListUnit enemy,
      int attackNo)
    {
      bool flag1 = true;
      int rangeType = !work.HasKey("skill_range_type") ? 0 : work.GetInt("skill_range_type");
      for (int index = 1; work.HasKey("skill_id" + (object) index); ++index)
      {
        int num1 = work.GetInt("skill_id" + (object) index);
        bool isUnconditional;
        if (num1 < 0)
        {
          isUnconditional = true;
          num1 = -num1;
        }
        else
          isUnconditional = false;
        if (num1 != 0 && MasterData.BattleskillSkill.ContainsKey(num1))
        {
          float lottery = 1f;
          bool flag2 = work.HasKey("skill_percentage_invest" + (object) index);
          if (flag2)
          {
            float num2 = work.GetFloat("skill_percentage_invest" + (object) index);
            if ((double) num2 != 0.0)
              lottery = num2 + (!work.HasKey("skill_percentage_invest_levelup" + (object) index) ? 0.0f : work.GetFloat("skill_percentage_invest_levelup" + (object) index)) * (float) work.skill.level;
            else
              flag2 = false;
          }
          if (MasterData.BattleskillSkill[num1].skill_type == BattleskillSkillType.ailment)
          {
            foreach (BL.ISkillEffectListUnit skillEffectListUnit in this.getInvestUnit(myself, enemy, num1, rangeType))
            {
              if (BattleFuncs.isAilmentInvest(lottery, num1, skillEffectListUnit, this.random))
                this.addInvestSkills(skillEffectListUnit, BattleFuncs.ailmentInvest(num1, skillEffectListUnit), true, isUnconditional, attackNo);
            }
          }
          else
          {
            bool flag3 = flag1;
            flag1 = false;
            foreach (BL.ISkillEffectListUnit unit in this.getInvestUnit(myself, enemy, num1, rangeType))
            {
              bool flag4 = !flag2 ? flag3 : (double) lottery >= (double) this.random.NextFloat();
              flag1 |= flag4;
              if (flag4)
                this.addInvestSkills(unit, new BL.Skill[1]
                {
                  new BL.Skill() { id = num1, level = 1 }
                }, false, (isUnconditional ? 1 : 0) != 0, attackNo);
            }
          }
        }
      }
    }

    private BL.Skill[] InvokeAttackerGeneric()
    {
      Dictionary<string, Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>> dictionary = new Dictionary<string, Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>>()
      {
        {
          "change_attack_type",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericChangeAttackType)
        },
        {
          "percentage_damage",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericPercentageDamage)
        },
        {
          "percentage_damage_s1",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericBiAttackPercentageDamage)
        },
        {
          "percentage_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericPercentageAttack)
        },
        {
          "base_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericBaseAttack)
        },
        {
          "percentage_drain",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericPercentageDrain)
        },
        {
          "hit_value",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericHitValue)
        },
        {
          "skill_id1",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericSkillId)
        },
        {
          "percentage_decrease",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericPercentageDecrease)
        },
        {
          "percentage_magic_decrease",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericPercentageMagicDecrease)
        },
        {
          "intelligence_physical_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericIntelligencePhysicalAttack)
        },
        {
          "agility_physical_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericAgilityPhysicalAttack)
        },
        {
          "dexterity_physical_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericDexterityPhysicalAttack)
        },
        {
          "luck_physical_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericLuckPhysicalAttack)
        },
        {
          "strength_magic_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericStrengthMagicAttack)
        },
        {
          "agility_magic_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericAgilityMagicAttack)
        },
        {
          "dexterity_magic_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericDexterityMagicAttack)
        },
        {
          "luck_magic_attack",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericLuckMagicAttack)
        },
        {
          "instant_death",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericInstantDeath)
        },
        {
          "revenge",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericRevenge)
        },
        {
          "rate_damage",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericRateDamage)
        },
        {
          "combi_target_skill_id1",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericCombiTargetSkillId)
        },
        {
          "counter_damage_hp_percentage",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericCounterDamageHpPercentage)
        },
        {
          "counter_damage_value",
          new Func<BattleDuelSkill.InvokeAttackerGenericWork, string, bool>(this.funcGenericCounterDamageValue)
        }
      };
      foreach (BL.Skill duelSkill1 in this.attacker.originalUnit.duelSkills)
      {
        if (!this.attacker.IsDontUseSkill(duelSkill1.id) && ((IEnumerable<BattleskillEffect>) duelSkill1.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.HasKey("gda_percentage_invocation"))))
        {
          foreach (List<BattleskillEffect> collection in this.CreateEffectPack(duelSkill1, "gda_percentage_invocation"))
          {
            BattleDuelSkill.InvokeAttackerGenericWork attackerGenericWork = new BattleDuelSkill.InvokeAttackerGenericWork();
            attackerGenericWork.skill = duelSkill1;
            attackerGenericWork.effects = collection;
            BattleDuelSkill.InvokeAttackerGenericWork work = attackerGenericWork;
            int num1 = 1;
            if (work.HasKey("attack_count"))
              num1 = work.GetInt("attack_count");
            if ((num1 > 1 || !this.isBiattack) && (num1 < 2 || this.isBiattack) && this.CheckInvokeGeneric((BattleDuelSkill.InvokeGenericWork) work))
            {
              if (work.HasKey("is_attack"))
              {
                bool flag = !this.isInvokedAmbush ? this.isAttacker : !this.isAttacker;
                int num2 = work.GetInt("is_attack");
                if (num2 == 1 && !flag || num2 == 2 && flag)
                  continue;
              }
              float percentage_invocation = work.GetFloat("gda_percentage_invocation");
              if (!this.isColossume)
              {
                int length = 0;
                while (true)
                {
                  string key = "combi_target_skill_id" + (object) (length + 1);
                  if (work.HasKey(key) && work.GetInt(key) != 0)
                    ++length;
                  else
                    break;
                }
                if (length >= 1)
                {
                  int num3 = 1;
                  if (work.HasKey("combi_min_range"))
                    num3 = work.GetInt("combi_min_range");
                  int[] range = new int[2]
                  {
                    num3,
                    work.GetInt("combi_max_range")
                  };
                  List<BL.ISkillEffectListUnit> list1 = BattleFuncs.getTargets(this.attacker.originalUnit, range, new BL.ForceID[1]
                  {
                    BattleFuncs.getForceID(this.attacker.originalUnit)
                  }, (this.isAI ? 1 : 0) != 0).Select<BL.UnitPosition, BL.ISkillEffectListUnit>((Func<BL.UnitPosition, BL.ISkillEffectListUnit>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x))).ToList<BL.ISkillEffectListUnit>();
                  work.duelParam = new Judgement.BeforeDuelParameter[length];
                  work.isMagic = new bool[length];
                  work.rangeAddDamage = 0.0f;
                  if (list1.Count >= length)
                  {
                    Tuple<int, int> pos = BattleFuncs.getUnitCell(this.attacker.originalUnit, this.isAI);
                    BL.ISkillEffectListUnit[] skillEffectListUnitArray = new BL.ISkillEffectListUnit[length];
                    for (int index1 = 0; index1 < length; ++index1)
                    {
                      int target_skill_id = work.GetInt("combi_target_skill_id" + (object) (index1 + 1));
                      List<BL.ISkillEffectListUnit> list2 = list1.Where<BL.ISkillEffectListUnit>((Func<BL.ISkillEffectListUnit, bool>) (x => ((IEnumerable<BL.Skill>) x.originalUnit.duelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (duelSkill => duelSkill.id == target_skill_id)) && this.attacker.originalUnit.unit.character.ID != x.originalUnit.unit.character.ID)).ToList<BL.ISkillEffectListUnit>();
                      if (list2.Count > 0)
                      {
                        BL.ISkillEffectListUnit skillEffectListUnit = list2.OrderBy<BL.ISkillEffectListUnit, int>((Func<BL.ISkillEffectListUnit, int>) (x =>
                        {
                          int num4 = 0;
                          Tuple<int, int> unitCell = BattleFuncs.getUnitCell(x.originalUnit, this.isAI);
                          int num5 = BL.fieldDistance(pos.Item1, pos.Item2, unitCell.Item1, unitCell.Item2);
                          int num6 = unitCell.Item1 - pos.Item1;
                          int num7 = unitCell.Item2 - pos.Item2;
                          int num8 = 0;
                          for (int index2 = 0; index2 < num5; ++index2)
                            num8 += 4 * index2;
                          if (num6 < 0)
                            num4 = num8 + num5 * 3 - num7;
                          else if (num6 > 0)
                            num4 = num8 + num5 * 1 + num7;
                          else if (num7 > 0)
                            num4 = num8 + num5 * 2;
                          else if (num7 < 0)
                            num4 = num8;
                          return num4;
                        })).FirstOrDefault<BL.ISkillEffectListUnit>();
                        if (skillEffectListUnit != null)
                          skillEffectListUnitArray[index1] = skillEffectListUnit;
                        else
                          break;
                      }
                      if (skillEffectListUnitArray[index1] == null)
                        break;
                    }
                    if (skillEffectListUnitArray[length - 1] != null)
                    {
                      Tuple<int, int> unitCell1 = BattleFuncs.getUnitCell(this.defender.originalUnit, this.isAI);
                      int num9 = int.MinValue;
                      for (int index = 0; index < length; ++index)
                      {
                        BL.MagicBullet beAttackMagicBullet = ((IEnumerable<BL.MagicBullet>) skillEffectListUnitArray[index].originalUnit.magicBullets).Where<BL.MagicBullet>((Func<BL.MagicBullet, bool>) (x => x.isAttack)).OrderBy<BL.MagicBullet, int>((Func<BL.MagicBullet, int>) (x => x.cost)).FirstOrDefault<BL.MagicBullet>();
                        work.isMagic[index] = beAttackMagicBullet != null;
                        work.duelParam[index] = Judgement.BeforeDuelParameter.CreateDuelSkill(skillEffectListUnitArray[index], beAttackMagicBullet, BattleFuncs.getPanel(pos.Item1, pos.Item2).landform, this.defender, BattleFuncs.getPanel(unitCell1.Item1, unitCell1.Item2).landform, this.distance, this.currentDefenderHp);
                        Tuple<int, int> unitCell2 = BattleFuncs.getUnitCell(skillEffectListUnitArray[index].originalUnit, this.isAI);
                        int num10 = BL.fieldDistance(pos.Item1, pos.Item2, unitCell2.Item1, unitCell2.Item2);
                        if (num10 > num9)
                          num9 = num10;
                      }
                      int num11 = Mathf.Max(0, range[1] - (num9 - 1));
                      if (work.HasKey("combi_range_add_percentage_invocation"))
                        percentage_invocation += (float) num11 * work.GetFloat("combi_range_add_percentage_invocation");
                      if (work.HasKey("combi_range_add_percentage_damage"))
                        work.rangeAddDamage = (float) num11 * work.GetFloat("combi_range_add_percentage_damage");
                    }
                  }
                }
              }
              if (this.isInvoke(this.attacker, this.defender, this.attackStatus.duelParameter.attackerUnitParameter, this.attackStatus.duelParameter.defenderUnitParameter, duelSkill1.level, percentage_invocation))
              {
                bool flag = false;
                work.attackCount = num1;
                foreach (string key in dictionary.Keys)
                {
                  if (work.HasKey(key) && dictionary[key](work, key))
                    flag = true;
                }
                if (flag)
                {
                  this.attackCount = num1;
                  this.invokeAttackerSkill = duelSkill1;
                  this.invokeAttackerSkillEffects.AddRange((IEnumerable<BattleskillEffect>) collection);
                  return new BL.Skill[1]{ duelSkill1 };
                }
              }
            }
          }
        }
      }
      return BattleDuelSkill.noneSkills;
    }

    private bool funcGenericPercentageDamage(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.damageRate *= work.GetFloat("percentage_damage");
      return true;
    }

    private bool funcGenericBiAttackPercentageDamage(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.biAttackDamageRate = new float[work.attackCount];
      float num1 = 1f;
      for (int index = 1; index <= work.attackCount; ++index)
      {
        if (work.HasKey("percentage_damage_s" + (object) index))
        {
          float num2 = work.GetFloat("percentage_damage_s" + (object) index);
          if ((double) num2 != 0.0)
            num1 = num2;
        }
        this.biAttackDamageRate[index - 1] = num1;
      }
      return true;
    }

    private bool funcGenericPercentageAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.attackRate *= work.GetFloat("percentage_attack");
      return true;
    }

    private bool funcGenericBaseAttack(BattleDuelSkill.InvokeAttackerGenericWork work, string param)
    {
      this.damageValue += work.GetFloat("base_attack");
      return true;
    }

    private bool funcGenericPercentageDrain(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      float num = work.GetFloat("percentage_drain");
      if ((double) this.drainRate < (double) num)
        this.drainRate = num;
      return true;
    }

    private bool funcGenericHitValue(BattleDuelSkill.InvokeAttackerGenericWork work, string param)
    {
      float num = work.GetFloat("hit_value");
      if ((double) num > 0.0)
        this.FixHit = new float?(num);
      return true;
    }

    private bool funcGenericSkillId(BattleDuelSkill.InvokeAttackerGenericWork work, string param)
    {
      int num = work.attackCount >= 1 ? work.attackCount : 1;
      for (int attackNo = 0; attackNo < num; ++attackNo)
        this.funcGenericSkillInvest((BattleDuelSkill.InvokeGenericWork) work, this.attacker, this.defender, attackNo);
      return true;
    }

    private bool funcGenericPercentageDecrease(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.defenseDownPhysicalRate *= work.GetFloat("percentage_decrease");
      return true;
    }

    private bool funcGenericPercentageMagicDecrease(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.defenseDownMagicRate *= work.GetFloat("percentage_magic_decrease");
      return true;
    }

    private bool funcGenericParameterToPhysicalAttackUp(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      int base_parameter,
      string param)
    {
      if ((this.isChageAttackType || this.attackStatus.isMagic) && (!this.isChageAttackType || !this.attackStatus.isMagic))
        return false;
      this.damageValue += (float) base_parameter * work.GetFloat(param);
      return true;
    }

    private bool funcGenericIntelligencePhysicalAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      return this.funcGenericParameterToPhysicalAttackUp(work, this.attackStatus.duelParameter.attackerUnitParameter.Intelligence, param);
    }

    private bool funcGenericAgilityPhysicalAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      return this.funcGenericParameterToPhysicalAttackUp(work, this.attackStatus.duelParameter.attackerUnitParameter.Agility, param);
    }

    private bool funcGenericDexterityPhysicalAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      return this.funcGenericParameterToPhysicalAttackUp(work, this.attackStatus.duelParameter.attackerUnitParameter.Dexterity, param);
    }

    private bool funcGenericLuckPhysicalAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      return this.funcGenericParameterToPhysicalAttackUp(work, this.attackStatus.duelParameter.attackerUnitParameter.Luck, param);
    }

    private bool funcGenericParameterToMagicAttackUp(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      int base_parameter,
      string param)
    {
      if ((this.isChageAttackType || !this.attackStatus.isMagic) && (!this.isChageAttackType || this.attackStatus.isMagic))
        return false;
      this.damageValue += (float) base_parameter * work.GetFloat(param);
      return true;
    }

    private bool funcGenericStrengthMagicAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      return this.funcGenericParameterToMagicAttackUp(work, this.attackStatus.duelParameter.attackerUnitParameter.Strength, param);
    }

    private bool funcGenericAgilityMagicAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      return this.funcGenericParameterToMagicAttackUp(work, this.attackStatus.duelParameter.attackerUnitParameter.Agility, param);
    }

    private bool funcGenericDexterityMagicAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      return this.funcGenericParameterToMagicAttackUp(work, this.attackStatus.duelParameter.attackerUnitParameter.Dexterity, param);
    }

    private bool funcGenericLuckMagicAttack(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      return this.funcGenericParameterToMagicAttackUp(work, this.attackStatus.duelParameter.attackerUnitParameter.Luck, param);
    }

    private bool funcGenericInstantDeath(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.FixDamage = new int?(this.currentDefenderHp);
      return true;
    }

    private bool funcGenericRevenge(BattleDuelSkill.InvokeAttackerGenericWork work, string param)
    {
      this.damageValue += (float) (this.attacker.originalUnit.parameter.Hp - this.currentAttakerHp) * work.GetFloat("revenge");
      return true;
    }

    private bool funcGenericChangeAttackType(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.isChageAttackType = true;
      return true;
    }

    private bool funcGenericRateDamage(BattleDuelSkill.InvokeAttackerGenericWork work, string param)
    {
      this.PercentageDamageRate = new float?(work.GetFloat("rate_damage"));
      return true;
    }

    private bool funcGenericCombiTargetSkillId(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      if (work.duelParam == null)
        return false;
      this.damageRate += work.rangeAddDamage;
      int length = work.duelParam.Length;
      if (work.duelParam[length - 1] != null)
      {
        for (int index = 0; index < length; ++index)
        {
          if (work.isMagic[index])
            this.damageValue += (float) work.duelParam[index].DisplayMagicAttack;
          else
            this.damageValue += (float) work.duelParam[index].DisplayPhysicalAttack;
        }
      }
      else if (work.HasKey("combi_none_percentage_damage"))
        this.damageRate *= work.GetFloat("combi_none_percentage_damage");
      return true;
    }

    private bool funcGenericCounterDamageHpPercentage(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.counterDamageHpPercentage = work.GetFloat("counter_damage_hp_percentage");
      return true;
    }

    private bool funcGenericCounterDamageValue(
      BattleDuelSkill.InvokeAttackerGenericWork work,
      string param)
    {
      this.counterDamageValue = work.GetInt("counter_damage_value");
      return true;
    }

    private BL.Skill[] InvokeDefenderGeneric()
    {
      Dictionary<string, Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>> dictionary = new Dictionary<string, Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>>()
      {
        {
          "percentage_damage",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericPercentageDamage)
        },
        {
          "percentage_attack",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericPercentageAttack)
        },
        {
          "base_attack",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericBaseAttack)
        },
        {
          "percentage_drain_ratio",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericPercentageDrainRatio)
        },
        {
          "percentage_decrease_ratio",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericPercentageDecreaseRatio)
        },
        {
          "percentage_magic_decrease_ratio",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericPercentageMagicDecreaseRatio)
        },
        {
          "skill_id1",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericSkillId)
        },
        {
          "suppress_critical_percentage",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericSuppressCriticalPercentage)
        },
        {
          "suppress_one_more_attack_percentage",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericSuppressOneMoreAttackPercentage)
        },
        {
          "suppress_duel_skill_percentage",
          new Func<BattleDuelSkill.InvokeDefenderGenericWork, string, bool>(this.funcDefenderGenericSuppressDuelSkillPercentage)
        }
      };
      foreach (BL.Skill duelSkill in this.defender.originalUnit.duelSkills)
      {
        if (!this.defender.IsDontUseSkill(duelSkill.id) && ((IEnumerable<BattleskillEffect>) duelSkill.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.HasKey("gdd_percentage_invocation"))))
        {
          foreach (List<BattleskillEffect> battleskillEffectList in this.CreateEffectPack(duelSkill, "gdd_percentage_invocation"))
          {
            BattleDuelSkill.InvokeDefenderGenericWork defenderGenericWork = new BattleDuelSkill.InvokeDefenderGenericWork();
            defenderGenericWork.skill = duelSkill;
            defenderGenericWork.effects = battleskillEffectList;
            BattleDuelSkill.InvokeDefenderGenericWork work = defenderGenericWork;
            bool flag1 = work.HasKey("suppress_duel_skill_percentage");
            if ((flag1 || !this.isPrecede) && (!flag1 || this.isPrecede) && this.CheckInvokeGeneric((BattleDuelSkill.InvokeGenericWork) work))
            {
              if (work.HasKey("is_attack"))
              {
                bool flag2 = !this.isInvokedAmbush ? !this.isAttacker : this.isAttacker;
                int num = work.GetInt("is_attack");
                if (num == 1 && !flag2 || num == 2 && flag2)
                  continue;
              }
              if (work.HasKey("skill_id"))
              {
                int num = work.GetInt("skill_id");
                if (num != 0)
                {
                  BL.Skill skill = !this.isBiattack ? this.invokeAttackerSkill : this.biAttackDuelSkill.invokeAttackerSkill;
                  if (skill == null || skill.id != num)
                    continue;
                }
              }
              if (work.HasKey("logic_id"))
              {
                int logic_id = work.GetInt("logic_id");
                if (logic_id != 0)
                {
                  List<BattleskillEffect> source = !this.isBiattack ? this.invokeAttackerSkillEffects : this.biAttackDuelSkill.invokeAttackerSkillEffects;
                  if (source == null || !source.Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.ID == logic_id)))
                    continue;
                }
              }
              if (work.HasKey("invoke_suisei"))
              {
                int num = work.GetInt("invoke_suisei");
                if (num == 1 && !this.isBiattack || num == 2 && this.isBiattack)
                  continue;
              }
              if (work.HasKey("invoke_drain"))
              {
                int num = work.GetInt("invoke_drain");
                if (num != 0)
                {
                  bool flag3 = this.isDefenderGenericDrainTarget();
                  if (num == 1 && !flag3 || num == 2 && flag3)
                    continue;
                }
              }
              if (work.HasKey("invoke_decrease"))
              {
                int num = work.GetInt("invoke_decrease");
                if (num != 0)
                {
                  bool flag4 = (double) this.defenseDownPhysicalRate != 1.0 || this.isBiattack && (double) this.biAttackDuelSkill.defenseDownPhysicalRate != 1.0;
                  if (num == 1 && !flag4 || num == 2 && flag4)
                    continue;
                }
              }
              if (work.HasKey("invoke_magic_decrease"))
              {
                int num = work.GetInt("invoke_magic_decrease");
                if (num != 0)
                {
                  bool flag5 = (double) this.defenseDownMagicRate != 1.0 || this.isBiattack && (double) this.biAttackDuelSkill.defenseDownMagicRate != 1.0;
                  if (num == 1 && !flag5 || num == 2 && flag5)
                    continue;
                }
              }
              if (this.distance != 0 && work.HasKey("out_of_range"))
              {
                int num = work.GetInt("out_of_range");
                if (num != 0)
                {
                  BL.Unit.GearRange gearRange = this.defender.originalUnit.gearRange();
                  bool flag6 = NC.IsReach(gearRange.Min, gearRange.Max, this.distance);
                  if (num == 1 && flag6 || num == 2 && !flag6)
                    continue;
                }
              }
              if (work.HasKey("invoke_skill"))
              {
                int num = work.GetInt("invoke_skill");
                if (num != 0)
                {
                  bool flag7 = (!this.isBiattack ? this.invokeAttackerSkill : this.biAttackDuelSkill.invokeAttackerSkill) != null;
                  if (num == 1 && !flag7 || num == 2 && flag7)
                    continue;
                }
              }
              if (work.HasKey("invoke_critical"))
              {
                int num = work.GetInt("invoke_critical");
                if (num != 0 && (num == 1 && !this.isCritical || num == 2 && this.isCritical))
                  continue;
              }
              float percentage_invocation = work.GetFloat("gdd_percentage_invocation");
              if (this.isInvoke(this.defender, this.attacker, this.attackStatus.duelParameter.defenderUnitParameter, this.attackStatus.duelParameter.attackerUnitParameter, duelSkill.level, percentage_invocation))
              {
                bool flag8 = false;
                foreach (string key in dictionary.Keys)
                {
                  if (work.HasKey(key) && dictionary[key](work, key))
                    flag8 = true;
                }
                if (flag8)
                {
                  this.invokeDefenseGenericWork = (BattleDuelSkill.InvokeGenericWork) work;
                  return new BL.Skill[1]{ duelSkill };
                }
              }
            }
          }
        }
      }
      return BattleDuelSkill.noneSkills;
    }

    private bool isDefenderGenericDrainTarget()
    {
      if ((double) this.drainRate > 0.0 || this.isBiattack && (double) this.biAttackDuelSkill.drainRate > 0.0)
        return true;
      return this.attackStatus.isDrain && (!this.isBiattack ? this.invokeAttackerSkill : this.biAttackDuelSkill.invokeAttackerSkill) != null;
    }

    private bool funcDefenderGenericPercentageDamage(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      this.damageRate *= work.GetFloat("percentage_damage");
      return true;
    }

    private bool funcDefenderGenericPercentageAttack(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      this.attackRate *= work.GetFloat("percentage_attack");
      return true;
    }

    private bool funcDefenderGenericBaseAttack(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      this.damageValue += work.GetFloat("base_attack");
      return true;
    }

    private bool funcDefenderGenericPercentageDrainRatio(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      if (!this.isPrecede && !this.isDefenderGenericDrainTarget())
        return true;
      this.drainRateRatio = work.GetFloat("percentage_drain_ratio");
      return true;
    }

    private bool funcDefenderGenericPercentageDecreaseRatio(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      this.defenseDownPhysicalRateRatio = work.GetFloat("percentage_decrease_ratio");
      return true;
    }

    private bool funcDefenderGenericPercentageMagicDecreaseRatio(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      this.defenseDownMagicRateRatio = work.GetFloat("percentage_magic_decrease_ratio");
      return true;
    }

    private bool funcDefenderGenericSkillId(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      if (this.isPrecede)
        return true;
      this.funcGenericSkillInvest((BattleDuelSkill.InvokeGenericWork) work, this.defender, this.attacker, 0);
      return true;
    }

    private bool funcDefenderGenericSuppressCriticalPercentage(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      this.isSuppressCritical = (double) work.GetFloat("suppress_critical_percentage") + (!work.HasKey("suppress_critical_percentage_levelup") ? 0.0 : (double) work.GetFloat("suppress_critical_percentage_levelup")) * (double) work.skill.level >= (double) this.random.NextFloat();
      return true;
    }

    private bool funcDefenderGenericSuppressOneMoreAttackPercentage(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      this.attackerCantOneMore = (double) work.GetFloat("suppress_one_more_attack_percentage") + (!work.HasKey("suppress_one_more_attack_percentage_levelup") ? 0.0 : (double) work.GetFloat("suppress_one_more_attack_percentage_levelup")) * (double) work.skill.level >= (double) this.random.NextFloat();
      return true;
    }

    private bool funcDefenderGenericSuppressDuelSkillPercentage(
      BattleDuelSkill.InvokeDefenderGenericWork work,
      string param)
    {
      this.isSuppressDuelSkill = (double) work.GetFloat("suppress_duel_skill_percentage") + (!work.HasKey("suppress_duel_skill_percentage_levelup") ? 0.0 : (double) work.GetFloat("suppress_duel_skill_percentage_levelup")) * (double) work.skill.level >= (double) this.random.NextFloat();
      return true;
    }

    public void addInvestSkills(
      BL.ISkillEffectListUnit unit,
      BL.Skill[] skills,
      bool isAilment,
      bool isUnconditional,
      int attackNo)
    {
      if (skills == null)
        return;
      if (this.investSkills == null)
        this.investSkills = new List<List<BattleDuelSkill.InvestSkills>>();
      while (this.investSkills.Count <= attackNo)
        this.investSkills.Add(new List<BattleDuelSkill.InvestSkills>());
      this.investSkills[attackNo].Add(new BattleDuelSkill.InvestSkills(unit, skills, isAilment, isUnconditional));
    }

    public BL.Skill[] getInvestSkills(
      BL.ISkillEffectListUnit unit,
      bool isAilment,
      bool isUnconditional,
      int attackNo)
    {
      if (this.investSkills == null)
        return (BL.Skill[]) null;
      if (this.investSkills.Count <= attackNo)
        return (BL.Skill[]) null;
      IEnumerable<BattleDuelSkill.InvestSkills> source = this.investSkills[attackNo].Where<BattleDuelSkill.InvestSkills>((Func<BattleDuelSkill.InvestSkills, bool>) (x => x.unit == unit && x.isAilment == isAilment && x.isUnconditional == isUnconditional));
      if (!source.Any<BattleDuelSkill.InvestSkills>())
        return (BL.Skill[]) null;
      List<BL.Skill> skillList = new List<BL.Skill>();
      foreach (BattleDuelSkill.InvestSkills investSkills in source)
        skillList.AddRange((IEnumerable<BL.Skill>) investSkills.skills);
      return skillList.ToArray();
    }

    public Tuple<BL.ISkillEffectListUnit[], int[]> getAllInvestList(
      bool isAilment,
      bool isUnconditional,
      int attackNo)
    {
      if (this.investSkills == null)
        return (Tuple<BL.ISkillEffectListUnit[], int[]>) null;
      if (this.investSkills.Count <= attackNo)
        return (Tuple<BL.ISkillEffectListUnit[], int[]>) null;
      IEnumerable<BattleDuelSkill.InvestSkills> source = this.investSkills[attackNo].Where<BattleDuelSkill.InvestSkills>((Func<BattleDuelSkill.InvestSkills, bool>) (x => x.isAilment == isAilment && x.isUnconditional == isUnconditional));
      if (!source.Any<BattleDuelSkill.InvestSkills>())
        return (Tuple<BL.ISkillEffectListUnit[], int[]>) null;
      List<BL.ISkillEffectListUnit> skillEffectListUnitList = new List<BL.ISkillEffectListUnit>();
      List<int> intList = new List<int>();
      foreach (BattleDuelSkill.InvestSkills investSkills in source)
      {
        foreach (BL.Skill skill in investSkills.skills)
        {
          skillEffectListUnitList.Add(investSkills.unit);
          intList.Add(skill.id);
        }
      }
      return new Tuple<BL.ISkillEffectListUnit[], int[]>(skillEffectListUnitList.ToArray(), intList.ToArray());
    }

    private IEnumerable<BL.ISkillEffectListUnit> getInvestUnit(
      BL.ISkillEffectListUnit myself,
      BL.ISkillEffectListUnit enemy,
      int skillId,
      int rangeType)
    {
      return BattleFuncs.getInvestUnit(myself, enemy, skillId, rangeType, this.isAI, this.isColossume);
    }

    private class InvokeGenericWork
    {
      public BL.Skill skill;
      public List<BattleskillEffect> effects;

      public bool HasKey(string key)
      {
        return this.effects.Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.HasKey(key)));
      }

      public int GetInt(string key)
      {
        return this.effects.Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.HasKey(key))).First<BattleskillEffect>().GetInt(key);
      }

      public float GetFloat(string key)
      {
        return this.effects.Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.HasKey(key))).First<BattleskillEffect>().GetFloat(key);
      }
    }

    private class InvokeAttackerGenericWork : BattleDuelSkill.InvokeGenericWork
    {
      public Judgement.BeforeDuelParameter[] duelParam;
      public bool[] isMagic;
      public float rangeAddDamage;
      public int attackCount;
    }

    private class InvokeDefenderGenericWork : BattleDuelSkill.InvokeGenericWork
    {
    }

    public class InvestSkills
    {
      public InvestSkills(
        BL.ISkillEffectListUnit unit,
        BL.Skill[] skills,
        bool isAilment,
        bool isUnconditional)
      {
        this.unit = unit;
        this.skills = skills;
        this.isAilment = isAilment;
        this.isUnconditional = isUnconditional;
      }

      public BL.ISkillEffectListUnit unit { get; private set; }

      public BL.Skill[] skills { get; private set; }

      public bool isAilment { get; private set; }

      public bool isUnconditional { get; private set; }
    }
  }
}
