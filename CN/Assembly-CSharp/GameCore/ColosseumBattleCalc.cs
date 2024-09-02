// Decompiled with JetBrains decompiler
// Type: GameCore.ColosseumBattleCalc
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  public static class ColosseumBattleCalc
  {
    private const int BattingFirstPlayer = 0;
    private const int BattingFirstOpponent = 1;
    private const int ColosseumMaxDuelTurn = 4;
    private const int CriticalDamageRate = 3;
    private const float COMMANDSKILL_PROBABILITY_BASE = 30f;
    private const float COMMANDSKILL_PROBABILITY_ADJUST = 40f;
    private const float COMMANDSKILL_PROBABILITY_MIN = 5f;
    private const float COMMANDSKILL_PROBABILITY_MAX = 100f;
    private const float RELEASESKILL_PROBABILITY_BASE = 25f;
    private const float RELEASESKILL_PROBABILITY_ADJUST = 0.09f;
    private const float RELEASESKILL_PROBABILITY_MIN = 3f;
    private const float RELEASESKILL_PROBABILITY_MAX = 100f;
    private static GameGlobalVariable<XorShift> random = GameGlobalVariable<XorShift>.Null();
    private static GameGlobalVariable<ColosseumEnvironment> _env = GameGlobalVariable<ColosseumEnvironment>.Null();

    public static AttackStatus selectAttackStatus(
      BL.Unit attack,
      BL.Unit[] attackNeighbors,
      BL.Unit[] attackDeckUnits,
      PlayerItem attackEquippedGear,
      BL.Unit defense,
      BL.Unit[] defenseNeighbors,
      BL.Unit[] defenseDeckUnits,
      PlayerItem defenseEquippedGear,
      bool isAttack,
      int attackHp,
      bool isSample,
      int defenseHp)
    {
      AttackStatus[] attackStatusArray = ColosseumBattleCalc.getAttackStatusArray(attack, attackNeighbors, attackDeckUnits, attackEquippedGear, defense, defenseNeighbors, defenseDeckUnits, defenseEquippedGear, isAttack, attackHp, isSample, defenseHp);
      if (((IEnumerable<AttackStatus>) attackStatusArray).Count<AttackStatus>() == 0)
        return (AttackStatus) null;
      AttackStatus attackStatus = ((IEnumerable<AttackStatus>) attackStatusArray).First<AttackStatus>();
      return attackStatus.magicBullet == null ? attackStatus : ((IEnumerable<AttackStatus>) attackStatusArray).Where<AttackStatus>((Func<AttackStatus, bool>) (y => y.magicBullet.isAttack && y.magicBullet.cost < attackHp)).OrderBy<AttackStatus, int>((Func<AttackStatus, int>) (y => y.magicBullet.cost)).Last<AttackStatus>();
    }

    public static AttackStatus[] getAttackStatusArray(
      BL.Unit attack,
      BL.Unit[] attackNeighbors,
      BL.Unit[] attackDeckUnits,
      PlayerItem attackEquippedGear,
      BL.Unit defense,
      BL.Unit[] defenseNeighbors,
      BL.Unit[] defenseDeckUnits,
      PlayerItem defenseEquippedGear,
      bool isAttack,
      int attackHp,
      bool isSample,
      int defenseHp)
    {
      if (((IEnumerable<BL.MagicBullet>) attack.magicBullets).Any<BL.MagicBullet>())
        return ((IEnumerable<BL.MagicBullet>) attack.magicBullets).Where<BL.MagicBullet>((Func<BL.MagicBullet, bool>) (x => x != null && attackHp > x.cost * BattleFuncs.attackCount((BL.ISkillEffectListUnit) attack, (BL.ISkillEffectListUnit) defense))).Select<BL.MagicBullet, AttackStatus>((Func<BL.MagicBullet, AttackStatus>) (x => ColosseumBattleCalc.getAttackStatus(x, attack, attackNeighbors, attackDeckUnits, attackEquippedGear, defense, defenseNeighbors, defenseDeckUnits, defenseEquippedGear, isAttack, attackHp, isSample, defenseHp))).OrderByDescending<AttackStatus, int>((Func<AttackStatus, int>) (x => x.attack)).ToArray<AttackStatus>();
      return new AttackStatus[1]
      {
        ColosseumBattleCalc.getAttackStatus((BL.MagicBullet) null, attack, attackNeighbors, attackDeckUnits, attackEquippedGear, defense, defenseNeighbors, defenseDeckUnits, defenseEquippedGear, isAttack, attackHp, isSample, defenseHp)
      };
    }

    private static AttackStatus getAttackStatus(
      BL.MagicBullet magicBullet,
      BL.Unit attack,
      BL.Unit[] attackNeighbors,
      BL.Unit[] attackDeckUnits,
      PlayerItem attackEquippedGear,
      BL.Unit defense,
      BL.Unit[] defenseNeighbors,
      BL.Unit[] defenseDeckUnits,
      PlayerItem defenseEquippedGear,
      bool isAttack,
      int attackHp,
      bool isSample,
      int defenseHp)
    {
      Judgement.BeforeDuelParameter colosseumSingle = Judgement.BeforeDuelParameter.CreateColosseumSingle(attack, magicBullet, attackNeighbors, attackDeckUnits, attackEquippedGear, defense, (BL.MagicBullet) null, defenseNeighbors, defenseDeckUnits, defenseEquippedGear, isAttack, isSample, attackHp, defenseHp);
      GearGear gear = attack.weapon.gear;
      bool flag = (gear.attack_type != GearAttackType.none ? (int) gear.attack_type : (int) attack.unit.initial_gear.attack_type) == 6;
      AttackStatus attackStatus = new AttackStatus()
      {
        duelParameter = colosseumSingle,
        isMagic = flag,
        magicBullet = magicBullet,
        attackRate = 1f
      };
      attackStatus.calcElementAttackRate((BL.ISkillEffectListUnit) attack, (BL.ISkillEffectListUnit) defense);
      return attackStatus;
    }

    public static DuelColosseumResult calcColosseumDuel(
      BL.Unit playerUnit,
      int playerUnitHp,
      PlayerItem playerEquippedGear,
      BL.Unit opponentUnit,
      int opponentUnitHp,
      PlayerItem opponentEquippedGear,
      Bonus[] bonusList)
    {
      return ColosseumBattleCalc.calcColosseumDuelAttack(playerUnit, playerUnitHp, playerEquippedGear, opponentUnit, opponentUnitHp, opponentEquippedGear, bonusList);
    }

    public static DuelColosseumResult calcColosseumDuelAttack(
      BL.Unit playerUnit,
      int playerUnitHp,
      PlayerItem playerEquippedGear,
      BL.Unit opponentUnit,
      int opponentUnitHp,
      PlayerItem opponentEquippedGear,
      Bonus[] bonusList)
    {
      DuelColosseumResult duelColosseumResult = new DuelColosseumResult();
      BL.Unit[] array1 = ColosseumBattleCalc._env.Get().playerUnitDict.Values.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x != null)).ToArray<BL.Unit>();
      BL.Unit[] array2 = ColosseumBattleCalc._env.Get().opponentUnitDict.Values.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x != null)).ToArray<BL.Unit>();
      AttackStatus status1 = ColosseumBattleCalc.selectAttackStatus(playerUnit, new BL.Unit[0], array1, playerEquippedGear, opponentUnit, new BL.Unit[0], array2, opponentEquippedGear, true, playerUnitHp, true, opponentUnitHp);
      AttackStatus status2 = ColosseumBattleCalc.selectAttackStatus(opponentUnit, new BL.Unit[0], array2, opponentEquippedGear, playerUnit, new BL.Unit[0], array1, playerEquippedGear, true, opponentUnitHp, true, playerUnitHp);
      duelColosseumResult.playerBeforeBonusParam = new ColosseumBeforBonusParam(status1);
      duelColosseumResult.opponentBeforeBonusParam = new ColosseumBeforBonusParam(status2);
      duelColosseumResult.playerActiveBonus = ColosseumBattleCalc.SetEnableColosseumBonusEffect(playerUnit, bonusList);
      duelColosseumResult.opponentActiveBonus = ColosseumBattleCalc.SetEnableColosseumBonusEffect(opponentUnit, bonusList);
      playerUnit.setParameter(Judgement.BattleParameter.FromBeColosseumUnit(playerUnit, playerEquippedGear));
      playerUnit.hp = playerUnit.parameter.Hp;
      playerUnitHp = playerUnit.hp;
      opponentUnit.setParameter(Judgement.BattleParameter.FromBeColosseumUnit(opponentUnit, opponentEquippedGear));
      opponentUnit.hp = opponentUnit.parameter.Hp;
      opponentUnitHp = opponentUnit.hp;
      int attackOrder = ColosseumBattleCalc.getAttackOrder(playerUnit, playerEquippedGear, playerUnitHp, opponentUnit, opponentEquippedGear, opponentUnitHp);
      duelColosseumResult.isPlayerFirstAttacker = attackOrder == 0;
      duelColosseumResult.player = playerUnit;
      duelColosseumResult.playerEq = playerEquippedGear;
      duelColosseumResult.opponent = opponentUnit;
      duelColosseumResult.opponentEq = opponentEquippedGear;
      duelColosseumResult.playerAttackStatus = ColosseumBattleCalc.selectAttackStatus(playerUnit, new BL.Unit[0], array1, playerEquippedGear, opponentUnit, new BL.Unit[0], array2, opponentEquippedGear, true, playerUnitHp, true, opponentUnitHp);
      duelColosseumResult.opponentAttackStatus = ColosseumBattleCalc.selectAttackStatus(opponentUnit, new BL.Unit[0], array2, opponentEquippedGear, playerUnit, new BL.Unit[0], array1, playerEquippedGear, true, opponentUnitHp, true, playerUnitHp);
      BL.Unit unit1;
      int num1;
      PlayerItem playerItem1;
      BL.Unit[] unitArray1;
      BL.Unit unit2;
      int num2;
      PlayerItem playerItem2;
      BL.Unit[] unitArray2;
      if (attackOrder == 0)
      {
        unit1 = playerUnit;
        num1 = playerUnitHp;
        playerItem1 = playerEquippedGear;
        unitArray1 = array1;
        unit2 = opponentUnit;
        num2 = opponentUnitHp;
        playerItem2 = opponentEquippedGear;
        unitArray2 = array2;
      }
      else
      {
        unit2 = playerUnit;
        num2 = playerUnitHp;
        playerItem2 = playerEquippedGear;
        unitArray2 = array1;
        unit1 = opponentUnit;
        num1 = opponentUnitHp;
        playerItem1 = opponentEquippedGear;
        unitArray1 = array2;
      }
      List<BL.DuelTurn> duelTurnList = new List<BL.DuelTurn>();
      ColosseumBattleCalc.CalcCommandAndReleaseSkill(playerUnit, opponentUnit, attackOrder != 0 ? 2 : 1);
      ColosseumBattleCalc.CalcCommandAndReleaseSkill(opponentUnit, playerUnit, attackOrder != 1 ? 2 : 1);
      duelColosseumResult.colosseumNewPAS = ColosseumBattleCalc.selectAttackStatus(playerUnit, new BL.Unit[0], array1, playerEquippedGear, opponentUnit, new BL.Unit[0], array2, opponentEquippedGear, attackOrder == 0, playerUnitHp, false, opponentUnitHp);
      duelColosseumResult.colosseumNewOAS = ColosseumBattleCalc.selectAttackStatus(opponentUnit, new BL.Unit[0], array2, opponentEquippedGear, playerUnit, new BL.Unit[0], array1, playerEquippedGear, attackOrder != 0, opponentUnitHp, false, playerUnitHp);
      bool invokedAttackerPrayer = false;
      bool invokedDefenderPrayer = false;
      for (int index = 0; index < 4; ++index)
      {
        bool flag = false;
        AttackStatus attackAS = ColosseumBattleCalc.selectAttackStatus(unit1, new BL.Unit[0], unitArray1, playerItem1, unit2, new BL.Unit[0], unitArray2, playerItem2, !flag, num1, false, num2);
        AttackStatus defenseAS = ColosseumBattleCalc.selectAttackStatus(unit2, new BL.Unit[0], unitArray2, playerItem2, unit1, new BL.Unit[0], unitArray1, playerItem1, flag, num2, false, num1);
        BL.DuelTurn[] duelTurnArray = ColosseumBattleCalc.calcTurns(unit1, num1, attackAS, unit2, num2, defenseAS, flag, invokedAttackerPrayer, invokedDefenderPrayer);
        if (duelTurnArray.Length > 0)
        {
          if (!flag)
          {
            duelTurnArray[0].attackerStatus = attackAS;
            duelTurnArray[0].defenderStatus = defenseAS;
          }
          else
          {
            duelTurnArray[0].defenderStatus = attackAS;
            duelTurnArray[0].attackerStatus = defenseAS;
          }
        }
        int num3 = 0;
        int num4 = 0;
        foreach (BL.DuelTurn duelTurn in duelTurnArray)
        {
          if (duelTurn.isAtackker)
          {
            num4 += duelTurn.damage - duelTurn.defenderDrainDamage;
            num3 += duelTurn.counterDamage - duelTurn.drainDamage;
          }
          else
          {
            num3 += duelTurn.damage - duelTurn.defenderDrainDamage;
            num4 += duelTurn.counterDamage - duelTurn.drainDamage;
          }
        }
        duelColosseumResult.firstAttackerDamage += num3;
        duelColosseumResult.secondAttackerDamage += num4;
        num1 = Mathf.Min(unit1.parameter.Hp, num1 - num3);
        num2 = Mathf.Min(unit2.parameter.Hp, num2 - num4);
        duelColosseumResult.isDieFirstAttacker = num1 <= 0;
        duelColosseumResult.isDieSecondAttacker = num2 <= 0;
        duelTurnList.AddRange((IEnumerable<BL.DuelTurn>) duelTurnArray);
        if (!duelColosseumResult.isDieFirstAttacker && !duelColosseumResult.isDieSecondAttacker)
          BattleFuncs.consumeSkillEffects(duelTurnArray, (BL.ISkillEffectListUnit) unit1, (BL.ISkillEffectListUnit) unit2);
        else
          break;
      }
      duelColosseumResult.turns = duelTurnList.ToArray();
      duelColosseumResult.firstAttackerFromDamage = ((IEnumerable<BL.DuelTurn>) duelColosseumResult.turns).Sum<BL.DuelTurn>((Func<BL.DuelTurn, int>) (x => !x.isAtackker ? x.dispDamage : 0));
      duelColosseumResult.secondAttackerFromDamage = ((IEnumerable<BL.DuelTurn>) duelColosseumResult.turns).Sum<BL.DuelTurn>((Func<BL.DuelTurn, int>) (x => x.isAtackker ? x.dispDamage : 0));
      return duelColosseumResult;
    }

    private static BL.DuelTurn[] calcTurns(
      BL.Unit attack,
      int attackHp,
      AttackStatus attackAS,
      BL.Unit defense,
      int defenseHp,
      AttackStatus defenseAS,
      bool isAttakerSwap,
      bool invokedAttackerPrayer,
      bool invokedDefenderPrayer)
    {
      List<BL.DuelTurn> turns = new List<BL.DuelTurn>();
      TurnHp hp = new TurnHp();
      hp.attackerHp = attackHp;
      hp.defenderHp = defenseHp;
      if (BattleFuncs.isSkillsAndEffectsInvalid((BL.ISkillEffectListUnit) attack, (BL.ISkillEffectListUnit) defense))
        hp.attackerIsDontUseSkill = true;
      if (BattleFuncs.isSkillsAndEffectsInvalid((BL.ISkillEffectListUnit) defense, (BL.ISkillEffectListUnit) attack))
        hp.defenderIsDontUseSkill = true;
      if (!isAttakerSwap)
      {
        ColosseumBattleCalc.calcMultiAttack(turns, hp, true, attack, attackAS, defense, defenseAS, invokedDefenderPrayer);
        ColosseumBattleCalc.calcMultiAttack(turns, hp, false, defense, defenseAS, attack, attackAS, invokedAttackerPrayer);
        if (attackAS != null && BattleFuncs.canOneMore(attackAS.duelParameter.attackerUnitParameter, attackAS.duelParameter.defenderUnitParameter, (BL.ISkillEffectListUnit) attack, (BL.ISkillEffectListUnit) defense))
          ColosseumBattleCalc.calcMultiAttack(turns, hp, true, attack, attackAS, defense, defenseAS, invokedDefenderPrayer);
        if (defenseAS != null && BattleFuncs.canOneMore(defenseAS.duelParameter.attackerUnitParameter, defenseAS.duelParameter.defenderUnitParameter, (BL.ISkillEffectListUnit) defense, (BL.ISkillEffectListUnit) attack))
          ColosseumBattleCalc.calcMultiAttack(turns, hp, false, defense, defenseAS, attack, attackAS, invokedAttackerPrayer);
      }
      else
      {
        ColosseumBattleCalc.calcMultiAttack(turns, hp, false, defense, defenseAS, attack, attackAS, invokedAttackerPrayer);
        ColosseumBattleCalc.calcMultiAttack(turns, hp, true, attack, attackAS, defense, defenseAS, invokedDefenderPrayer);
        if (defenseAS != null && BattleFuncs.canOneMore(defenseAS.duelParameter.attackerUnitParameter, defenseAS.duelParameter.defenderUnitParameter, (BL.ISkillEffectListUnit) defense, (BL.ISkillEffectListUnit) attack))
          ColosseumBattleCalc.calcMultiAttack(turns, hp, false, defense, defenseAS, attack, attackAS, invokedAttackerPrayer);
        if (attackAS != null && BattleFuncs.canOneMore(attackAS.duelParameter.attackerUnitParameter, attackAS.duelParameter.defenderUnitParameter, (BL.ISkillEffectListUnit) attack, (BL.ISkillEffectListUnit) defense))
          ColosseumBattleCalc.calcMultiAttack(turns, hp, true, attack, attackAS, defense, defenseAS, invokedDefenderPrayer);
      }
      return turns.ToArray();
    }

    private static void calcMultiAttack(
      List<BL.DuelTurn> turns,
      TurnHp hp,
      bool isAttacker,
      BL.Unit attack,
      AttackStatus attackStatus,
      BL.Unit defense,
      AttackStatus defenseStatus,
      bool invokedPrayer)
    {
      if (attackStatus == null)
        return;
      for (int index = BattleFuncs.attackCount((BL.ISkillEffectListUnit) attack, (BL.ISkillEffectListUnit) defense); index > 0; --index)
        BattleFuncs.calcSingleAttack(turns, hp, isAttacker, (BL.ISkillEffectListUnit) attack, attackStatus, (BL.ISkillEffectListUnit) defense, defenseStatus, 0, ColosseumBattleCalc.random.Get(), false, true, false, invokedPrayer);
    }

    private static int getPreemptValue(
      Judgement.BeforeDuelUnitParameter unit,
      GearGear equippedGear)
    {
      return (unit.Agility - equippedGear.weight * 3 + unit.Move * 2 + unit.Luck * 2) * equippedGear.kind.colosseum_preempt_coefficient * 100;
    }

    private static bool getInvokeAmbush(BL.Unit unit, BL.Unit enemyUnit, int hp)
    {
      return !BattleFuncs.isSkillsAndEffectsInvalid((BL.ISkillEffectListUnit) unit, (BL.ISkillEffectListUnit) enemyUnit) && BattleFuncs.getUnitAndGearSkills(unit).Where<Tuple<BattleskillSkill, int>>((Func<Tuple<BattleskillSkill, int>, bool>) (x => ((IEnumerable<BattleskillEffect>) x.Item1.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (effect => effect.effect_logic.Enum == BattleskillEffectLogicEnum.ambush && effect.isEnableGameMode(BattleskillInvokeGameModeEnum.colosseum) && (!effect.HasKey("gear_kind_id") || effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == unit.unit.kind.ID) && (!effect.HasKey("target_gear_kind_id") || effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == enemyUnit.unit.kind.ID) && (!effect.HasKey("element") || effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == unit.playerUnit.GetElement()) && (!effect.HasKey("target_element") || effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == enemyUnit.playerUnit.GetElement()) && (!effect.HasKey("job_id") || effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == unit.job.ID) && (!effect.HasKey("target_job_id") || effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == enemyUnit.job.ID) && (!effect.HasKey("family_id") || effect.GetInt("family_id") == 0 || unit.unit.HasFamily((UnitFamily) effect.GetInt("family_id"))) && (!effect.HasKey("target_family_id") || effect.GetInt("target_family_id") == 0 || enemyUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && (double) hp <= ((double) effect.GetFloat("percentage") * 100.0 + (double) (x.Item2 * 2)) / 100.0 * (double) unit.parameter.Hp)))).FirstOrDefault<Tuple<BattleskillSkill, int>>() != null;
    }

    private static int getAttackOrder(
      BL.Unit playerUnit,
      PlayerItem playerEquippedGear,
      int playerHp,
      BL.Unit opponentUnit,
      PlayerItem opponentEquippedGear,
      int oppentHp)
    {
      bool invokeAmbush1 = ColosseumBattleCalc.getInvokeAmbush(playerUnit, opponentUnit, playerHp);
      bool invokeAmbush2 = ColosseumBattleCalc.getInvokeAmbush(opponentUnit, playerUnit, oppentHp);
      if (invokeAmbush1 && !invokeAmbush2)
        return 0;
      if (!invokeAmbush1 && invokeAmbush2)
        return 1;
      Judgement.BeforeDuelParameter colosseumSingle = Judgement.BeforeDuelParameter.CreateColosseumSingle(playerUnit, (BL.MagicBullet) null, new BL.Unit[0], ColosseumBattleCalc._env.Get().playerUnitDict.Values.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x != null)).ToArray<BL.Unit>(), playerEquippedGear, opponentUnit, (BL.MagicBullet) null, new BL.Unit[0], ColosseumBattleCalc._env.Get().opponentUnitDict.Values.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x != null)).ToArray<BL.Unit>(), opponentEquippedGear, false, true, playerHp, oppentHp);
      return ColosseumBattleCalc.getPreemptValue(colosseumSingle.attackerUnitParameter, !(playerEquippedGear == (PlayerItem) null) ? playerEquippedGear.gear : playerUnit.unit.initial_gear) < ColosseumBattleCalc.getPreemptValue(colosseumSingle.defenderUnitParameter, !(opponentEquippedGear == (PlayerItem) null) ? opponentEquippedGear.gear : opponentUnit.unit.initial_gear) ? 1 : 0;
    }

    private static void CalcCommandAndReleaseSkill(BL.Unit unit, BL.Unit target, int attackOrder)
    {
      if (BattleFuncs.isSkillsAndEffectsInvalid((BL.ISkillEffectListUnit) unit, (BL.ISkillEffectListUnit) target))
      {
        unit.skills = new BL.Skill[0];
        unit.ougi = (BL.Skill) null;
      }
      else
      {
        List<BL.Skill> skillList = new List<BL.Skill>();
        foreach (BL.Skill skill in unit.skills)
        {
          if (skill.remain.HasValue)
          {
            float num = Mathf.Clamp(Mathf.Floor((float) (30.0 - (double) Mathf.Pow((float) skill.remain.Value, -1f) * 40.0)), 5f, 100f);
            if (ColosseumBattleCalc.random.Get().RangeInt(0, 100) < (int) num)
            {
              if (skill.targetType == BattleskillTargetType.complex_range || skill.targetType == BattleskillTargetType.complex_single)
              {
                foreach (BattleskillEffect effect in skill.skill.Effects)
                {
                  if (effect.is_targer_enemy)
                    target.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, skill.level));
                  else
                    unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, skill.level));
                }
              }
              else if (skill.targetType == BattleskillTargetType.myself || skill.targetType == BattleskillTargetType.player_range || skill.targetType == BattleskillTargetType.player_single)
              {
                foreach (BattleskillEffect effect in skill.skill.Effects)
                  unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, skill.level));
              }
              else if (skill.targetType == BattleskillTargetType.enemy_range || skill.targetType == BattleskillTargetType.enemy_single)
              {
                foreach (BattleskillEffect effect in skill.skill.Effects)
                  target.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, skill.level));
              }
              skillList.Add(skill);
            }
          }
        }
        IEnumerable<PlayerUnitSkills> playerUnitSkillses = ((IEnumerable<PlayerUnitSkills>) unit.playerUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.passive && ((IEnumerable<BattleskillEffect>) v.skill.Effects).Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (effect => effect.HasKey("is_attack") && effect.GetInt("is_attack") == attackOrder)).Any<BattleskillEffect>()));
        IEnumerable<GearGearSkill> gearGearSkills = ((IEnumerable<GearGearSkill>) unit.playerUnit.equippedGearOrInitial.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (v => v.skill.skill_type == BattleskillSkillType.passive && ((IEnumerable<BattleskillEffect>) v.skill.Effects).Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (effect => effect.HasKey("is_attack") && effect.GetInt("is_attack") == attackOrder)).Any<BattleskillEffect>()));
        foreach (PlayerUnitSkills playerUnitSkills in playerUnitSkillses)
          skillList.Add(new BL.Skill()
          {
            id = playerUnitSkills.skill_id,
            level = playerUnitSkills.level,
            useTurn = 0,
            remain = new int?(0)
          });
        foreach (GearGearSkill gearGearSkill in gearGearSkills)
          skillList.Add(new BL.Skill()
          {
            id = gearGearSkill.skill.ID,
            level = gearGearSkill.skill_level,
            useTurn = 0,
            remain = new int?(0)
          });
        unit.skills = skillList.ToArray();
        if (!unit.hasOugi)
          return;
        if (unit.ougi.useTurn > 0)
        {
          float num = Mathf.Clamp(Mathf.Floor((float) (25.0 - (double) Mathf.Pow((float) unit.ougi.useTurn, 2f) * 0.090000003576278687)), 3f, 100f);
          if (ColosseumBattleCalc.random.Get().RangeInt(0, 100) < (int) num)
          {
            if (unit.ougi.targetType == BattleskillTargetType.complex_range || unit.ougi.targetType == BattleskillTargetType.complex_single)
            {
              foreach (BattleskillEffect effect in unit.ougi.skill.Effects)
              {
                if (effect.is_targer_enemy)
                  target.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, unit.ougi.skill, unit.ougi.level));
                else
                  unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, unit.ougi.skill, unit.ougi.level));
              }
            }
            else if (unit.ougi.targetType == BattleskillTargetType.myself || unit.ougi.targetType == BattleskillTargetType.player_range || unit.ougi.targetType == BattleskillTargetType.player_single)
            {
              foreach (BattleskillEffect effect in unit.ougi.skill.Effects)
                unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, unit.ougi.skill, unit.ougi.level));
            }
            else
            {
              if (unit.ougi.targetType != BattleskillTargetType.enemy_range && unit.ougi.targetType != BattleskillTargetType.enemy_single)
                return;
              foreach (BattleskillEffect effect in unit.ougi.skill.Effects)
                target.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, unit.ougi.skill, unit.ougi.level));
            }
          }
          else
            unit.ougi = (BL.Skill) null;
        }
        else
          unit.ougi = (BL.Skill) null;
      }
    }

    private static Bonus[] SetEnableColosseumBonusEffect(BL.Unit unit, Bonus[] enableBonusList)
    {
      List<Bonus> bonusList = new List<Bonus>();
      if (enableBonusList == null)
        return bonusList.ToArray();
      foreach (Bonus enableBonus in enableBonusList)
      {
        if (Bonus.IsEnableBonus(unit, enableBonus, ColosseumBattleCalc._env.Get().today))
        {
          foreach (BattleskillEffect effect in enableBonus.skill.Effects)
            unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, enableBonus.skill, 1));
          bonusList.Add(enableBonus);
        }
      }
      return bonusList.ToArray();
    }

    public static ColosseumResult calcColosseum(ColosseumEnvironment env)
    {
      ColosseumBattleCalc.random.Reset(new XorShift(env.colosseumTransactionID));
      ColosseumBattleCalc._env.Reset(env);
      ColosseumResult colosseumResult = new ColosseumResult(env.colosseumTransactionID, env.opponentUnitDict[5].playerUnit.player_id);
      for (int key = 1; key <= 5; ++key)
      {
        DuelColosseumResult result = (DuelColosseumResult) null;
        if (env.playerUnitDict[key] != null && env.opponentUnitDict[key] != null)
          result = ColosseumBattleCalc.calcColosseumDuel(env.playerUnitDict[key], env.playerUnitDict[key].hp, env.playerGearDict[key], env.opponentUnitDict[key], env.opponentUnitDict[key].hp, env.opponentGearDict[key], env.bonusList);
        else if (env.playerUnitDict[key] == null && env.opponentUnitDict[key] == null)
          result = new DuelColosseumResult();
        else if (env.playerUnitDict[key] != null)
        {
          result = new DuelColosseumResult();
          result.player = env.playerUnitDict[key];
          result.playerActiveBonus = ColosseumBattleCalc.SetEnableColosseumBonusEffect(env.playerUnitDict[key], env.bonusList);
          result.isDieOpponent = true;
          result.isPlayerFirstAttacker = true;
        }
        else if (env.opponentUnitDict[key] != null)
        {
          result = new DuelColosseumResult();
          result.opponent = env.opponentUnitDict[key];
          result.opponentActiveBonus = ColosseumBattleCalc.SetEnableColosseumBonusEffect(env.opponentUnitDict[key], env.bonusList);
          result.isDiePlayer = true;
          result.isPlayerFirstAttacker = false;
        }
        colosseumResult.SetData(key - 1, result);
      }
      return colosseumResult;
    }
  }
}
