// Decompiled with JetBrains decompiler
// Type: GameCore.BattleLogicInitializer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
namespace GameCore
{
  public class BattleLogicInitializer
  {
    private BL.DropData createFieldEvent(Reward reward)
    {
      return new BL.DropData() { reward = reward };
    }

    private Future<BL.Skill> createSkill(PlayerUnitSkills playerSkill)
    {
      BL.Skill skill = new BL.Skill()
      {
        id = playerSkill.skill.ID,
        level = playerSkill.level
      };
      skill.useTurn = playerSkill.skill.charge_turn - (skill.level - 1);
      skill.remain = playerSkill.skill.use_count != 0 ? new int?(playerSkill.skill.use_count + (skill.level - 1)) : new int?();
      if (skill.remain.HasValue && playerSkill.skill.max_use_count != 0)
      {
        int? remain = skill.remain;
        if ((!remain.HasValue ? 0 : (remain.Value > playerSkill.skill.max_use_count ? 1 : 0)) != 0)
          skill.remain = new int?(playerSkill.skill.max_use_count);
      }
      return Future.Single<BL.Skill>(skill);
    }

    private Future<BL.Skill> createSkill(GearGearSkill gearSkill)
    {
      BL.Skill skill = new BL.Skill()
      {
        id = gearSkill.skill.ID,
        level = gearSkill.skill_level
      };
      skill.useTurn = gearSkill.skill.charge_turn - (skill.level - 1);
      skill.remain = gearSkill.skill.use_count != 0 ? new int?(gearSkill.skill.use_count + (skill.level - 1)) : new int?();
      if (skill.remain.HasValue && gearSkill.skill.max_use_count != 0)
      {
        int? remain = skill.remain;
        if ((!remain.HasValue ? 0 : (remain.Value > gearSkill.skill.max_use_count ? 1 : 0)) != 0)
          skill.remain = new int?(gearSkill.skill.max_use_count);
      }
      return Future.Single<BL.Skill>(skill);
    }

    private Future<BL.MagicBullet> createMagicBullet(PlayerUnitSkills playerSkill)
    {
      return Future.Single<BL.MagicBullet>(new BL.MagicBullet()
      {
        skillId = playerSkill.skill.ID
      });
    }

    private Future<BL.MagicBullet> createMagicBullet(GearGearSkill gearSkill)
    {
      return Future.Single<BL.MagicBullet>(new BL.MagicBullet()
      {
        skillId = gearSkill.skill.ID
      });
    }

    private Future<BL.Unit> createUnitByPlayerUnit(PlayerUnit pu, int index, bool friend)
    {
      PlayerUnitSkills[] array1 = ((IEnumerable<PlayerUnitSkills>) pu.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.command)).ToArray<PlayerUnitSkills>();
      PlayerUnitSkills[] array2 = ((IEnumerable<PlayerUnitSkills>) pu.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.release)).ToArray<PlayerUnitSkills>();
      PlayerUnitSkills[] array3 = ((IEnumerable<PlayerUnitSkills>) pu.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.magic)).ToArray<PlayerUnitSkills>();
      PlayerUnitSkills[] array4 = ((IEnumerable<PlayerUnitSkills>) pu.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.duel)).ToArray<PlayerUnitSkills>();
      GearGearSkill[] source1 = !(pu.equippedGear != (PlayerItem) null) ? new GearGearSkill[0] : ((IEnumerable<GearGearSkill>) pu.equippedGear.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (v => v.skill.skill_type == BattleskillSkillType.command)).ToArray<GearGearSkill>();
      GearGearSkill[] source2 = !(pu.equippedGear != (PlayerItem) null) ? new GearGearSkill[0] : ((IEnumerable<GearGearSkill>) pu.equippedGear.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (v => v.skill.skill_type == BattleskillSkillType.duel)).ToArray<GearGearSkill>();
      GearGearSkill[] source3 = !(pu.equippedGear != (PlayerItem) null) ? new GearGearSkill[0] : ((IEnumerable<GearGearSkill>) pu.equippedGear.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (v => v.skill.skill_type == BattleskillSkillType.magic)).ToArray<GearGearSkill>();
      return Future.WhenAllThen<BL.Skill, List<BL.Skill>, List<BL.MagicBullet>, List<BL.Skill>, List<BL.Skill>, List<BL.Skill>, List<BL.MagicBullet>, BL.Unit>(array2.Length != 0 ? this.createSkill(((IEnumerable<PlayerUnitSkills>) array2).Single<PlayerUnitSkills>()) : Future.Single<BL.Skill>((BL.Skill) null), ((IEnumerable<PlayerUnitSkills>) array1).Select<PlayerUnitSkills, Future<BL.Skill>>((Func<PlayerUnitSkills, Future<BL.Skill>>) (v => this.createSkill(v))).Sequence<BL.Skill>(), ((IEnumerable<PlayerUnitSkills>) array3).Select<PlayerUnitSkills, Future<BL.MagicBullet>>((Func<PlayerUnitSkills, Future<BL.MagicBullet>>) (v => this.createMagicBullet(v))).Sequence<BL.MagicBullet>(), ((IEnumerable<PlayerUnitSkills>) array4).Select<PlayerUnitSkills, Future<BL.Skill>>((Func<PlayerUnitSkills, Future<BL.Skill>>) (v => this.createSkill(v))).Sequence<BL.Skill>(), ((IEnumerable<GearGearSkill>) source1).Select<GearGearSkill, Future<BL.Skill>>((Func<GearGearSkill, Future<BL.Skill>>) (v => this.createSkill(v))).Sequence<BL.Skill>(), ((IEnumerable<GearGearSkill>) source2).Select<GearGearSkill, Future<BL.Skill>>((Func<GearGearSkill, Future<BL.Skill>>) (v => this.createSkill(v))).Sequence<BL.Skill>(), ((IEnumerable<GearGearSkill>) source3).Select<GearGearSkill, Future<BL.MagicBullet>>((Func<GearGearSkill, Future<BL.MagicBullet>>) (v => this.createMagicBullet(v))).Sequence<BL.MagicBullet>(), (Func<BL.Skill, List<BL.Skill>, List<BL.MagicBullet>, List<BL.Skill>, List<BL.Skill>, List<BL.Skill>, List<BL.MagicBullet>, BL.Unit>) ((ougi, skills, magicBullets, duel, gearCommand, gearDuel, gearMB) => new BL.Unit()
      {
        specificId = pu.id,
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
        AIMoveGroup = pu.ai_move_group,
        AIMoveGroupOrder = pu.ai_move_group_order,
        AIMoveTargetX = pu.ai_move_target_x,
        AIMoveTargetY = pu.ai_move_target_y,
        index = index,
        friend = friend,
        ougi = ougi,
        skills = skills.Concat<BL.Skill>((IEnumerable<BL.Skill>) gearCommand).ToArray<BL.Skill>(),
        duelSkills = duel.Concat<BL.Skill>((IEnumerable<BL.Skill>) gearDuel).OrderByDescending<BL.Skill, int>((Func<BL.Skill, int>) (x => x.skill.weight)).ThenBy<BL.Skill, int>((Func<BL.Skill, int>) (x => x.id)).ToArray<BL.Skill>(),
        magicBullets = magicBullets.Concat<BL.MagicBullet>((IEnumerable<BL.MagicBullet>) gearMB).ToArray<BL.MagicBullet>(),
        skillfull_shield = XorShift.Range(1, 5),
        skillfull_weapon = XorShift.Range(1, 5),
        isSpawned = pu.spawn_turn <= 0
      }));
    }

    private float CalcIndicatorLevel(IEnumerable<PlayerUnit> playerUnits)
    {
      return playerUnits.Count<PlayerUnit>() <= 0 ? 0.0f : playerUnits.Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)).Select<PlayerUnit, float>((Func<PlayerUnit, float>) (x => (float) x.level * x.unit.rarity.indicator_level_rate)).OrderByDescending<float, float>((Func<float, float>) (x => x)).Max();
    }

    private void initializeStage(BattleInfo info, BL env)
    {
      BattleStage stage = info.stage;
      env.initializeFeild(info.stageId);
      if (env.condition == null)
        env.condition = new BL.Condition();
      env.condition.id = stage.victory_condition.ID;
      Dictionary<int, Tuple<int, Reward>> dropDic = new Dictionary<int, Tuple<int, Reward>>();
      if (info.PanelItems != null)
        dropDic = ((IEnumerable<Tuple<int, Reward>>) info.PanelItems).ToDictionary<Tuple<int, Reward>, int>((Func<Tuple<int, Reward>, int>) (v =>
        {
          BattleStagePanelEvent battleStagePanelEvent = MasterData.BattleStagePanelEvent[v.Item1];
          return battleStagePanelEvent.initial_coordinate_x - 1 << 16 | battleStagePanelEvent.initial_coordinate_y - 1;
        }));
      BattleVictoryAreaCondition[] winArea = env.condition.winAreaConditoin;
      BattleVictoryAreaCondition[] loseArea = env.condition.loseAreaConditoin;
      BattleReinforcement[] battleReinforcements = (BattleReinforcement[]) null;
      if (info.Enemies != null)
        battleReinforcements = ((IEnumerable<BattleStageEnemy>) info.Enemies).Where<BattleStageEnemy>((Func<BattleStageEnemy, bool>) (x => x.reinforcement != null)).Select<BattleStageEnemy, BattleReinforcement>((Func<BattleStageEnemy, BattleReinforcement>) (x => x.reinforcement)).ToArray<BattleReinforcement>();
      stage.ApplyLandforms((Action<int, int, BattleMapLandform>) ((x, y, landform) =>
      {
        int key = x << 16 | y;
        Tuple<int, Reward> tuple = dropDic == null || !dropDic.ContainsKey(key) ? (Tuple<int, Reward>) null : dropDic[key];
        BL.DropData fieldEvent = tuple != null ? this.createFieldEvent(tuple.Item2) : (BL.DropData) null;
        env.setFeildPanel(landform.ID, y, x, landform.landform.ID, tuple != null ? tuple.Item1 : 0, fieldEvent, winArea, loseArea, battleReinforcements);
      }));
    }

    [DebuggerHidden]
    private IEnumerator createEnemyUnits(
      BattleInfo info,
      List<BL.Unit> enemies,
      List<BL.Unit> userEnemies,
      BL env)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleLogicInitializer.\u003CcreateEnemyUnits\u003Ec__Iterator1D()
      {
        info = info,
        env = env,
        enemies = enemies,
        userEnemies = userEnemies,
        \u003C\u0024\u003Einfo = info,
        \u003C\u0024\u003Eenv = env,
        \u003C\u0024\u003Eenemies = enemies,
        \u003C\u0024\u003EuserEnemies = userEnemies,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator initializeWave(int wave, BattleInfo info, BL env)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleLogicInitializer.\u003CinitializeWave\u003Ec__Iterator1E()
      {
        info = info,
        wave = wave,
        env = env,
        \u003C\u0024\u003Einfo = info,
        \u003C\u0024\u003Ewave = wave,
        \u003C\u0024\u003Eenv = env,
        \u003C\u003Ef__this = this
      };
    }

    private void createFieldEffects(BattleStage stage, BL env)
    {
      List<BL.FieldEffect> v = new List<BL.FieldEffect>();
      Dictionary<BattleFieldEffectTiming, BL.FieldEffectType> dictionary = new Dictionary<BattleFieldEffectTiming, BL.FieldEffectType>()
      {
        {
          BattleFieldEffectTiming.before_battle,
          BL.FieldEffectType.battle_start
        },
        {
          BattleFieldEffectTiming.first_turn_start,
          BL.FieldEffectType.first_turn_start
        },
        {
          BattleFieldEffectTiming.turn_start,
          BL.FieldEffectType.turn_start
        },
        {
          BattleFieldEffectTiming.player_start,
          BL.FieldEffectType.player_start
        },
        {
          BattleFieldEffectTiming.neutral_start,
          BL.FieldEffectType.neutral_start
        },
        {
          BattleFieldEffectTiming.enemy_start,
          BL.FieldEffectType.enemy_start
        },
        {
          BattleFieldEffectTiming.stageclear,
          BL.FieldEffectType.stageclear
        },
        {
          BattleFieldEffectTiming.pvp_change_player,
          BL.FieldEffectType.pvp_change_player
        },
        {
          BattleFieldEffectTiming.pvp_change_enemy,
          BL.FieldEffectType.pvp_change_enemy
        }
      };
      foreach (BattleFieldEffectStage fieldEffectStage in stage.FieldEffectStages)
        v.Add(new BL.FieldEffect(fieldEffectStage.field_effect.ID, dictionary[fieldEffectStage.timing]));
      if (env.fieldEffectList == null)
        env.fieldEffectList = new BL.ClassValue<List<BL.FieldEffect>>(v);
      else
        env.fieldEffectList.value = v;
    }

    private BL.UnitPosition checkUnitPosition(BL.Unit u, BL env)
    {
      BL.UnitPosition unitPosition = (BL.UnitPosition) null;
      if (env.unitPositions != null && env.unitPositions.value != null)
        unitPosition = env.getUnitPosition(u);
      return unitPosition ?? new BL.UnitPosition();
    }

    private Tuple<List<BL.UnitPosition>, int> getGuestPosition(
      BattleInfo info,
      BL env,
      List<BL.Unit> guests,
      int positionId)
    {
      List<BL.UnitPosition> unitPositionList = new List<BL.UnitPosition>();
      if (info.quest_type == CommonQuestType.Earth || info.quest_type == CommonQuestType.EarthExtra)
        unitPositionList.AddRange(guests.Select<BL.Unit, BattleEarthStageGuest, BL.UnitPosition>((IEnumerable<BattleEarthStageGuest>) info.EarthGuests, (Func<BL.Unit, BattleEarthStageGuest, BL.UnitPosition>) ((a, b) =>
        {
          BL.UnitPosition guestPosition = this.checkUnitPosition(a, env);
          BL.UnitPosition unitPosition = guestPosition;
          int num1;
          positionId = (num1 = positionId) + 1;
          int num2 = num1;
          unitPosition.id = num2;
          guestPosition.unit = a;
          guestPosition.row = b.initial_coordinate_y - 1;
          guestPosition.column = b.initial_coordinate_x - 1;
          guestPosition.direction = b.initial_direction;
          guestPosition.resetOriginalPosition(env);
          return guestPosition;
        })).Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (a => a != null)));
      else
        unitPositionList.AddRange(guests.Select<BL.Unit, BattleStageGuest, BL.UnitPosition>((IEnumerable<BattleStageGuest>) info.Guests, (Func<BL.Unit, BattleStageGuest, BL.UnitPosition>) ((a, b) =>
        {
          BL.UnitPosition guestPosition = this.checkUnitPosition(a, env);
          BL.UnitPosition unitPosition = guestPosition;
          int num3;
          positionId = (num3 = positionId) + 1;
          int num4 = num3;
          unitPosition.id = num4;
          guestPosition.unit = a;
          guestPosition.row = b.initial_coordinate_y(info.stageId) - 1;
          guestPosition.column = b.initial_coordinate_x(info.stageId) - 1;
          guestPosition.direction = b.initial_direction(info.stageId);
          guestPosition.resetOriginalPosition(env);
          return guestPosition;
        })).Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (a => a != null)));
      return new Tuple<List<BL.UnitPosition>, int>(unitPositionList, positionId);
    }

    [DebuggerHidden]
    private IEnumerator createUnitPositions(
      BattleInfo info,
      BL env,
      List<BL.Unit> players,
      List<BL.Unit> guests,
      List<BL.Unit> friend,
      List<BL.Unit> enemies,
      List<BL.Unit> userEnemies)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleLogicInitializer.\u003CcreateUnitPositions\u003Ec__Iterator1F()
      {
        info = info,
        players = players,
        env = env,
        guests = guests,
        friend = friend,
        enemies = enemies,
        userEnemies = userEnemies,
        \u003C\u0024\u003Einfo = info,
        \u003C\u0024\u003Eplayers = players,
        \u003C\u0024\u003Eenv = env,
        \u003C\u0024\u003Eguests = guests,
        \u003C\u0024\u003Efriend = friend,
        \u003C\u0024\u003Eenemies = enemies,
        \u003C\u0024\u003EuserEnemies = userEnemies,
        \u003C\u003Ef__this = this
      };
    }

    private void setRangeSkills(
      List<BL.Unit> units,
      List<BL.Unit> targets,
      bool ownOnly,
      bool targetOnly,
      BL.Unit unit,
      BattleskillSkill skill,
      int level)
    {
      if (!targetOnly && skill.target_type == BattleskillTargetType.myself)
      {
        foreach (BattleskillEffect effect in skill.Effects)
          unit.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level, true));
      }
      else if (!targetOnly && (skill.target_type == BattleskillTargetType.player_single || skill.target_type == BattleskillTargetType.player_range))
      {
        foreach (BL.Unit unit1 in units)
        {
          foreach (BattleskillEffect effect in skill.Effects)
            unit1.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level, true));
        }
      }
      else if (!ownOnly && (skill.target_type == BattleskillTargetType.enemy_single || skill.target_type == BattleskillTargetType.enemy_range))
      {
        foreach (BL.Unit target in targets)
        {
          foreach (BattleskillEffect effect in skill.Effects)
            target.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level, true));
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
            if (!ownOnly)
            {
              foreach (BL.Unit target in targets)
                target.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level, true));
            }
          }
          else if (!targetOnly)
          {
            foreach (BL.Unit unit2 in units)
              unit2.skillEffects.Add(BL.SkillEffect.FromMasterData(unit, effect, skill, level, true));
          }
        }
      }
    }

    private void setLeaderSkills(
      List<BL.Unit> units,
      List<BL.Unit> targets,
      bool ownOnly = false,
      bool targetOnly = false)
    {
      foreach (BL.Unit unit in units)
      {
        if (unit.is_leader || unit.friend || unit.playerUnit.is_enemy_leader || unit.playerUnit.is_gesut && unit.is_helper)
        {
          foreach (PlayerUnitLeader_skills leaderSkill in unit.playerUnit.leader_skills)
            this.setRangeSkills(units, targets, ownOnly, targetOnly, unit, leaderSkill.skill, leaderSkill.level);
        }
      }
    }

    private void setPassiveSkills(
      List<BL.Unit> units,
      List<BL.Unit> targets,
      bool ownOnly = false,
      bool targetOnly = false)
    {
      foreach (BL.Unit unit in units)
      {
        foreach (PlayerUnitSkills playerUnitSkills in ((IEnumerable<PlayerUnitSkills>) unit.playerUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (v => v.skill.skill_type == BattleskillSkillType.passive)).ToArray<PlayerUnitSkills>())
        {
          if (!playerUnitSkills.skill.range_effect_passive_skill)
          {
            if (!targetOnly)
            {
              foreach (BattleskillEffect effect in playerUnitSkills.skill.Effects)
                unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, playerUnitSkills.skill, playerUnitSkills.level, true));
            }
          }
          else
            this.setRangeSkills(units, targets, ownOnly, targetOnly, unit, playerUnitSkills.skill, playerUnitSkills.level);
        }
      }
    }

    private void setGearSkills(
      List<BL.Unit> units,
      List<BL.Unit> targets,
      bool ownOnly = false,
      bool targetOnly = false)
    {
      foreach (BL.Unit unit in units)
      {
        PlayerItem equippedGear = unit.playerUnit.equippedGear;
        if (equippedGear != (PlayerItem) null)
        {
          foreach (GearGearSkill gearGearSkill in ((IEnumerable<GearGearSkill>) equippedGear.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (v => v.skill.skill_type == BattleskillSkillType.passive)).ToArray<GearGearSkill>())
          {
            if (!gearGearSkill.skill.range_effect_passive_skill)
            {
              if (!targetOnly)
              {
                foreach (BattleskillEffect effect in gearGearSkill.skill.Effects)
                  unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, gearGearSkill.skill, gearGearSkill.skill_level, true));
              }
            }
            else
              this.setRangeSkills(units, targets, ownOnly, targetOnly, unit, gearGearSkill.skill, gearGearSkill.skill_level);
          }
        }
      }
    }

    private void setBonusSkills(List<BL.Unit> units, BattleInfo info)
    {
      foreach (BL.Unit unit in units)
      {
        foreach (Bonus pvpBonus in info.pvp_bonus_list)
        {
          if (Bonus.IsEnableBonus(unit, pvpBonus, info.pvp_start_date))
          {
            foreach (BattleskillEffect effect in pvpBonus.skill.Effects)
              unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, pvpBonus.skill, 1, true));
          }
        }
      }
    }

    private void setGvgBonusSkills(List<BL.Unit> units, GuildBaseBonusEffect[] bonus_list)
    {
      foreach (BL.Unit unit in units)
      {
        foreach (GuildBaseBonusEffect bonus in bonus_list)
        {
          foreach (BattleskillEffect effect in bonus.skill.Effects)
            unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, bonus.skill, 1, true));
        }
      }
    }

    private bool enableGvgFriendSkill(PlayerUnit unit, PlayerUnit[] helpers)
    {
      return helpers != null && ((IEnumerable<PlayerUnit>) helpers).FirstIndexOrNull<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.Equals(unit))).HasValue;
    }

    [DebuggerHidden]
    private IEnumerator initializeData(BattleInfo battleInfo, BL env)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleLogicInitializer.\u003CinitializeData\u003Ec__Iterator20()
      {
        env = env,
        battleInfo = battleInfo,
        \u003C\u0024\u003Eenv = env,
        \u003C\u0024\u003EbattleInfo = battleInfo,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator doStart(BattleInfo battleInfo, BL env)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleLogicInitializer.\u003CdoStart\u003Ec__Iterator21()
      {
        battleInfo = battleInfo,
        env = env,
        \u003C\u0024\u003EbattleInfo = battleInfo,
        \u003C\u0024\u003Eenv = env,
        \u003C\u003Ef__this = this
      };
    }
  }
}
