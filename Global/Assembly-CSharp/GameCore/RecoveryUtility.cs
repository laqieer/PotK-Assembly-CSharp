// Decompiled with JetBrains decompiler
// Type: GameCore.RecoveryUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  public static class RecoveryUtility
  {
    public static void resetPosition(BL.UnitPosition up, int row, int column)
    {
      up.row = row;
      up.column = column;
      up.resetOriginalPosition();
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
        up.unit.pvpRespawnCount = unit.respawnCount;
        RecoveryUtility.resetPosition(up, unit.row, unit.column);
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
      }
      env.playerActionUnits.value = unitPositionList1;
      env.enemyActionUnits.value = unitPositionList2;
    }
  }
}
