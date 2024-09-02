// Decompiled with JetBrains decompiler
// Type: GameCore.RecoveryUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  public static class RecoveryUtility
  {
    public static void resetPosition(BL.UnitPosition up, int row, int column, BL env)
    {
      up.row = row;
      up.column = column;
      up.resetOriginalPosition(env);
    }

    public static void Apply(RecoveryType rt, BL env)
    {
      List<BL.UnitPosition> unitPositionList1 = new List<BL.UnitPosition>();
      List<BL.UnitPosition> unitPositionList2 = new List<BL.UnitPosition>();
      env.completedActionUnits.value = new List<BL.UnitPosition>();
      env.resetActionList(BL.ForceID.player);
      env.resetActionList(BL.ForceID.neutral);
      env.resetActionList(BL.ForceID.enemy);
      foreach (RecoveryUnit unit in rt.units)
      {
        BL.UnitPosition up = BL.UnitPosition.FromNetwork(new int?(unit.unitPositionId), env);
        up.unit.hp = unit.hp;
        up.unit.setIsDead(unit.hp <= 0, env);
        up.unit.deadTurn = new List<int>((IEnumerable<int>) unit.deadTurn);
        up.unit.pvpRespawnCount = unit.respawnCount;
        RecoveryUtility.resetPosition(up, unit.row, unit.column, env);
        if (unit.completed)
        {
          if (!up.isCompleted)
            up.completeActionUnit(env, true);
        }
        else if (up.unit.isPlayerControl)
          unitPositionList1.Add(up);
        else
          unitPositionList2.Add(up);
        foreach (RecoverySkill skill1 in unit.skillList)
        {
          BL.Skill skill2 = (BL.Skill) null;
          if (up.unit.hasOugi && up.unit.ougi.id == skill1.id)
          {
            skill2 = up.unit.ougi;
          }
          else
          {
            foreach (BL.Skill skill3 in up.unit.skills)
            {
              if (skill3.id == skill1.id)
                skill2 = skill3;
            }
          }
          if (skill2 != null)
          {
            skill2.level = skill1.level;
            skill2.remain = skill1.remain;
            skill2.useTurn = skill1.useTurn;
          }
        }
        up.unit.skillEffects = new BL.SkillEffectList();
        foreach (RecoverySkillEffect skillEffect in unit.skillEffectList)
          up.unit.skillEffects.Add(BL.SkillEffect.FromRecovery(skillEffect));
        foreach (RecoverySkillEffectParam skillFixEffectParam in unit.skillFixEffectParams)
        {
          BL.SkillEffect effect = BL.SkillEffect.FromRecovery(skillFixEffectParam.skillEffect);
          up.unit.skillEffects.AddFixEffectParam(effect.effect.effect_logic.Enum, effect, (int) skillFixEffectParam.value);
        }
        foreach (RecoverySkillEffectParam ratioEffectParam in unit.skillRatioEffectParams)
        {
          BL.SkillEffect effect = BL.SkillEffect.FromRecovery(ratioEffectParam.skillEffect);
          up.unit.skillEffects.AddRatioEffectParam(effect.effect.effect_logic.Enum, effect, ratioEffectParam.value);
        }
        foreach (RecoverySkillEffect removedBaseSkillEffect in unit.removedBaseSkillEffects)
          up.unit.skillEffects.AddRemovedBaseSkillEffect(BL.SkillEffect.FromRecovery(removedBaseSkillEffect));
        foreach (RecoverySkillEffectParam removedFixEffectParam in unit.removedFixEffectParams)
        {
          BL.SkillEffect skillEffect = BL.SkillEffect.FromRecovery(removedFixEffectParam.skillEffect);
          up.unit.skillEffects.AddRemovedFixEffectParam(new Tuple<BattleskillEffectLogicEnum, BL.SkillEffect, int>(skillEffect.effect.effect_logic.Enum, skillEffect, (int) removedFixEffectParam.value));
        }
        foreach (RecoverySkillEffectParam ratioEffectParam in unit.removedRatioEffectParams)
        {
          BL.SkillEffect skillEffect = BL.SkillEffect.FromRecovery(ratioEffectParam.skillEffect);
          up.unit.skillEffects.AddRemovedRatioEffectParam(new Tuple<BattleskillEffectLogicEnum, BL.SkillEffect, float>(skillEffect.effect.effect_logic.Enum, skillEffect, ratioEffectParam.value));
        }
      }
      env.playerActionUnits.value = unitPositionList1;
      env.enemyActionUnits.value = unitPositionList2;
    }
  }
}
