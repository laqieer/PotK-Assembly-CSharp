// Decompiled with JetBrains decompiler
// Type: GameCore.ColosseumEnvironmentInitializer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace GameCore
{
  public class ColosseumEnvironmentInitializer
  {
    private static BL.Skill createSkill(PlayerUnitSkills playerSkill)
    {
      BL.Skill skill = new BL.Skill()
      {
        id = playerSkill.skill.ID,
        level = playerSkill.level
      };
      skill.useTurn = playerSkill.skill.charge_turn - (skill.level - 1);
      skill.remain = playerSkill.skill.use_count != 0 ? new int?(playerSkill.skill.use_count + (skill.level - 1)) : new int?();
      return skill;
    }

    private static BL.Skill createSkill(GearGearSkill gearSkill)
    {
      BL.Skill skill = new BL.Skill()
      {
        id = gearSkill.skill.ID,
        level = gearSkill.skill_level
      };
      skill.useTurn = gearSkill.skill.charge_turn - (skill.level - 1);
      skill.remain = gearSkill.skill.use_count != 0 ? new int?(gearSkill.skill.use_count + (skill.level - 1)) : new int?();
      return skill;
    }

    private static BL.MagicBullet createMagicBullet(PlayerUnitSkills playerSkill)
    {
      return new BL.MagicBullet()
      {
        skillId = playerSkill.skill.ID
      };
    }

    private static BL.MagicBullet createMagicBullet(GearGearSkill gearSkill)
    {
      return new BL.MagicBullet()
      {
        skillId = gearSkill.skill.ID
      };
    }

    private static BL.Unit createUnitByPlayerUnit(PlayerUnit pu, int index, bool friend)
    {
      PlayerUnitSkills[] array1 = ((IEnumerable<PlayerUnitSkills>) pu.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.command)).ToArray<PlayerUnitSkills>();
      PlayerUnitSkills[] array2 = ((IEnumerable<PlayerUnitSkills>) pu.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.release)).ToArray<PlayerUnitSkills>();
      PlayerUnitSkills[] array3 = ((IEnumerable<PlayerUnitSkills>) pu.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.magic)).ToArray<PlayerUnitSkills>();
      PlayerUnitSkills[] array4 = ((IEnumerable<PlayerUnitSkills>) pu.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.duel)).ToArray<PlayerUnitSkills>();
      GearGearSkill[] source1 = !(pu.equippedGear != (PlayerItem) null) ? new GearGearSkill[0] : ((IEnumerable<GearGearSkill>) pu.equippedGear.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (v => v.skill.skill_type == BattleskillSkillType.command)).ToArray<GearGearSkill>();
      GearGearSkill[] source2 = !(pu.equippedGear != (PlayerItem) null) ? new GearGearSkill[0] : ((IEnumerable<GearGearSkill>) pu.equippedGear.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (v => v.skill.skill_type == BattleskillSkillType.duel)).ToArray<GearGearSkill>();
      GearGearSkill[] source3 = !(pu.equippedGear != (PlayerItem) null) ? new GearGearSkill[0] : ((IEnumerable<GearGearSkill>) pu.equippedGear.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (v => v.skill.skill_type == BattleskillSkillType.magic)).ToArray<GearGearSkill>();
      BL.Skill skill = array2.Length != 0 ? ColosseumEnvironmentInitializer.createSkill(((IEnumerable<PlayerUnitSkills>) array2).Single<PlayerUnitSkills>()) : (BL.Skill) null;
      List<BL.Skill> list = ((IEnumerable<PlayerUnitSkills>) array1).Select<PlayerUnitSkills, BL.Skill>((Func<PlayerUnitSkills, BL.Skill>) (v => ColosseumEnvironmentInitializer.createSkill(v))).ToList<BL.Skill>();
      IEnumerable<BL.MagicBullet> first1 = ((IEnumerable<PlayerUnitSkills>) array3).Select<PlayerUnitSkills, BL.MagicBullet>((Func<PlayerUnitSkills, BL.MagicBullet>) (v => ColosseumEnvironmentInitializer.createMagicBullet(v)));
      IEnumerable<BL.Skill> first2 = ((IEnumerable<PlayerUnitSkills>) array4).Select<PlayerUnitSkills, BL.Skill>((Func<PlayerUnitSkills, BL.Skill>) (v => ColosseumEnvironmentInitializer.createSkill(v)));
      IEnumerable<BL.Skill> second1 = ((IEnumerable<GearGearSkill>) source1).Select<GearGearSkill, BL.Skill>((Func<GearGearSkill, BL.Skill>) (v => ColosseumEnvironmentInitializer.createSkill(v)));
      IEnumerable<BL.Skill> second2 = ((IEnumerable<GearGearSkill>) source2).Select<GearGearSkill, BL.Skill>((Func<GearGearSkill, BL.Skill>) (v => ColosseumEnvironmentInitializer.createSkill(v)));
      IEnumerable<BL.MagicBullet> second3 = ((IEnumerable<GearGearSkill>) source3).Select<GearGearSkill, BL.MagicBullet>((Func<GearGearSkill, BL.MagicBullet>) (v => ColosseumEnvironmentInitializer.createMagicBullet(v)));
      return new BL.Unit()
      {
        unitId = pu.unit.ID,
        playerUnit = pu,
        lv = pu.level,
        spawnTurn = pu.spawn_turn,
        weapon = new BL.Weapon()
        {
          gearId = pu.equippedWeaponGearOrInitial.ID
        },
        gearLeftHand = pu.isLeftHandWeapon,
        gearDualWield = pu.isDualWieldWeapon,
        index = index,
        friend = friend,
        ougi = skill,
        skills = list.Concat<BL.Skill>(second1).ToArray<BL.Skill>(),
        magicBullets = first1.Concat<BL.MagicBullet>(second3).ToArray<BL.MagicBullet>(),
        duelSkills = first2.Concat<BL.Skill>(second2).ToArray<BL.Skill>(),
        skillfull_shield = XorShift.Range(1, 5),
        skillfull_weapon = XorShift.Range(1, 5)
      };
    }

    public static ColosseumEnvironment initializeData(
      ColosseumInitialData colosseumInitialData,
      ColosseumEnvironment env_)
    {
      ColosseumEnvironment colosseumEnvironment = new ColosseumEnvironment();
      if (!colosseumInitialData.transaction_id.Equals(Persist.colosseumEnv.Data.id))
      {
        Persist.colosseumEnv.Data.id = colosseumInitialData.transaction_id;
        Persist.colosseumEnv.Flush();
      }
      colosseumEnvironment.today = string.Format("{0:D2}{1:D2}", (object) colosseumInitialData.now.Month, (object) colosseumInitialData.now.Day);
      colosseumEnvironment.bonusList = colosseumInitialData.bonusList;
      colosseumEnvironment.colosseumTransactionID = colosseumInitialData.transaction_id;
      Dictionary<int, BL.Unit> dictionary1 = new Dictionary<int, BL.Unit>();
      Dictionary<int, PlayerItem> dictionary2 = new Dictionary<int, PlayerItem>();
      for (int index = 0; index < 5; ++index)
      {
        int key = 5 - index;
        PlayerUnit pu = (PlayerUnit) null;
        if (index < colosseumInitialData.player_unit_list.Length)
          pu = colosseumInitialData.player_unit_list[index];
        if (pu == (PlayerUnit) null)
        {
          dictionary1.Add(key, (BL.Unit) null);
          dictionary2.Add(key, (PlayerItem) null);
        }
        else
        {
          if (pu.equip_gear_ids != null && pu.equip_gear_ids.Length > 0)
          {
            int? id = pu.equip_gear_ids[0];
            dictionary2.Add(key, ((IEnumerable<PlayerItem>) colosseumInitialData.player_gear_list).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == id.Value && x.entity_type == MasterDataTable.CommonRewardType.gear)).FirstOrDefault<PlayerItem>());
            if (dictionary2[key] != (PlayerItem) null)
              pu.primary_equipped_gear = dictionary2[key];
          }
          else
            dictionary2.Add(key, (PlayerItem) null);
          BL.Unit unitByPlayerUnit = ColosseumEnvironmentInitializer.createUnitByPlayerUnit(pu, index, false);
          unitByPlayerUnit.isPlayerControl = true;
          dictionary1.Add(key, unitByPlayerUnit);
        }
      }
      Dictionary<int, BL.Unit> dictionary3 = new Dictionary<int, BL.Unit>();
      Dictionary<int, PlayerItem> dictionary4 = new Dictionary<int, PlayerItem>();
      for (int index = 0; index < 5; ++index)
      {
        int key = 5 - index;
        PlayerUnit pu = (PlayerUnit) null;
        if (index < colosseumInitialData.opponent_unit_list.Length)
          pu = colosseumInitialData.opponent_unit_list[index];
        if (pu == (PlayerUnit) null)
        {
          dictionary3.Add(key, (BL.Unit) null);
          dictionary4.Add(key, (PlayerItem) null);
        }
        else
        {
          if (pu.equip_gear_ids != null && pu.equip_gear_ids.Length > 0)
          {
            int? id = pu.equip_gear_ids[0];
            dictionary4.Add(key, ((IEnumerable<PlayerItem>) colosseumInitialData.opponent_gear_list).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == id.Value && x.entity_type == MasterDataTable.CommonRewardType.gear)).FirstOrDefault<PlayerItem>());
            if (dictionary4[key] != (PlayerItem) null)
              pu.primary_equipped_gear = dictionary4[key];
          }
          else
            dictionary4.Add(key, (PlayerItem) null);
          BL.Unit unitByPlayerUnit = ColosseumEnvironmentInitializer.createUnitByPlayerUnit(pu, index, false);
          unitByPlayerUnit.isPlayerControl = false;
          dictionary3.Add(key, unitByPlayerUnit);
        }
      }
      colosseumEnvironment.playerUnitDict = dictionary1;
      colosseumEnvironment.playerGearDict = dictionary2;
      colosseumEnvironment.opponentUnitDict = dictionary3;
      colosseumEnvironment.opponentGearDict = dictionary4;
      BL.Unit[] array1 = colosseumEnvironment.playerUnitDict.Values.ToArray<BL.Unit>();
      BL.Unit[] array2 = colosseumEnvironment.opponentUnitDict.Values.ToArray<BL.Unit>();
      foreach (BL.Unit unit in colosseumEnvironment.playerUnitDict.Values)
      {
        if (unit != null && unit.is_leader)
        {
          foreach (PlayerUnitLeader_skills leaderSkill in unit.playerUnit.leader_skills)
            ColosseumEnvironmentInitializer.setRangeSkills(array1, array2, unit, leaderSkill.skill, leaderSkill.level);
        }
      }
      foreach (BL.Unit unit in colosseumEnvironment.opponentUnitDict.Values)
      {
        if (unit != null && unit.is_leader)
        {
          foreach (PlayerUnitLeader_skills leaderSkill in unit.playerUnit.leader_skills)
            ColosseumEnvironmentInitializer.setRangeSkills(array2, array1, unit, leaderSkill.skill, leaderSkill.level);
        }
      }
      foreach (BL.Unit unit in colosseumEnvironment.playerUnitDict.Values)
      {
        if (unit != null)
        {
          foreach (PlayerUnitSkills playerUnitSkills in ((IEnumerable<PlayerUnitSkills>) unit.playerUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.passive)).ToArray<PlayerUnitSkills>())
          {
            if (!playerUnitSkills.skill.range_effect_passive_skill)
            {
              foreach (BattleskillEffect effect in playerUnitSkills.skill.Effects)
                unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, playerUnitSkills.skill, playerUnitSkills.level));
            }
            else
              ColosseumEnvironmentInitializer.setRangeSkills(array1, array2, unit, playerUnitSkills.skill, playerUnitSkills.level);
          }
        }
      }
      foreach (BL.Unit unit in colosseumEnvironment.opponentUnitDict.Values)
      {
        if (unit != null)
        {
          foreach (PlayerUnitSkills playerUnitSkills in ((IEnumerable<PlayerUnitSkills>) unit.playerUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.passive)).ToArray<PlayerUnitSkills>())
          {
            if (!playerUnitSkills.skill.range_effect_passive_skill)
            {
              foreach (BattleskillEffect effect in playerUnitSkills.skill.Effects)
                unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, playerUnitSkills.skill, playerUnitSkills.level));
            }
            else
              ColosseumEnvironmentInitializer.setRangeSkills(array2, array1, unit, playerUnitSkills.skill, playerUnitSkills.level);
          }
        }
      }
      foreach (KeyValuePair<int, BL.Unit> keyValuePair in colosseumEnvironment.playerUnitDict)
      {
        BL.Unit unit = keyValuePair.Value;
        if (unit != null)
        {
          PlayerItem playerItem = colosseumEnvironment.playerGearDict[keyValuePair.Key];
          if (playerItem != (PlayerItem) null)
          {
            foreach (GearGearSkill skill in playerItem.skills)
            {
              if (skill.skill.skill_type != BattleskillSkillType.passive || !skill.skill.range_effect_passive_skill)
              {
                foreach (BattleskillEffect effect in skill.skill.Effects)
                  unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, skill.skill_level));
              }
              else
                ColosseumEnvironmentInitializer.setRangeSkills(array1, array2, unit, skill.skill, skill.skill_level);
            }
          }
        }
      }
      foreach (KeyValuePair<int, BL.Unit> keyValuePair in colosseumEnvironment.opponentUnitDict)
      {
        BL.Unit unit = keyValuePair.Value;
        if (unit != null)
        {
          PlayerItem playerItem = colosseumEnvironment.opponentGearDict[keyValuePair.Key];
          if (playerItem != (PlayerItem) null)
          {
            foreach (GearGearSkill skill in playerItem.skills)
            {
              if (skill.skill.skill_type != BattleskillSkillType.passive || !skill.skill.range_effect_passive_skill)
              {
                foreach (BattleskillEffect effect in skill.skill.Effects)
                  unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, skill.skill_level));
              }
              else
                ColosseumEnvironmentInitializer.setRangeSkills(array2, array1, unit, skill.skill, skill.skill_level);
            }
          }
        }
      }
      foreach (BL.Unit unit in colosseumEnvironment.playerUnitDict.Values)
      {
        if (unit != null)
          unit.hp = unit.parameter.Hp;
      }
      foreach (BL.Unit unit in colosseumEnvironment.opponentUnitDict.Values)
      {
        if (unit != null)
          unit.hp = unit.parameter.Hp;
      }
      return colosseumEnvironment;
    }

    public static void setRangeSkills(
      BL.Unit[] units,
      BL.Unit[] targets,
      BL.Unit unit,
      BattleskillSkill skill,
      int level)
    {
      if (skill.target_type == BattleskillTargetType.myself || skill.target_type == BattleskillTargetType.player_single || skill.target_type == BattleskillTargetType.player_range)
      {
        foreach (BL.Unit unit1 in units)
        {
          if (unit1 != null)
          {
            foreach (BattleskillEffect effect in skill.Effects)
              unit1.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level));
          }
        }
      }
      else if (skill.target_type == BattleskillTargetType.enemy_single || skill.target_type == BattleskillTargetType.enemy_range)
      {
        foreach (BL.Unit target in targets)
        {
          if (target != null)
          {
            foreach (BattleskillEffect effect in skill.Effects)
              target.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level));
          }
        }
      }
      else
      {
        if (skill.target_type != BattleskillTargetType.complex_single && skill.target_type != BattleskillTargetType.complex_range)
          return;
        foreach (BattleskillEffect effect in skill.Effects)
        {
          if (effect.is_targer_enemy)
          {
            foreach (BL.Unit target in targets)
              target?.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level));
          }
          else
          {
            foreach (BL.Unit unit2 in units)
              unit2?.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level));
          }
        }
      }
    }
  }
}
