// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerUnit : KeyCompare
  {
    private PlayerUnit.UnitType unitType;
    public bool is_enemy_leader;
    public PlayerItem primary_equipped_gear;
    public int ai_move_target_x = -1;
    public int ai_move_target_y = -1;
    public int ai_move_group;
    public int ai_move_group_order;
    public string ai_attack = string.Empty;
    public string ai_move = string.Empty;
    public string ai_heal = string.Empty;
    public string ai_use = string.Empty;
    public string ai_script_file = string.Empty;
    public int spawn_turn;
    public int? group_id;
    public BattleReinforcement reinforcement;
    private PlayerCharacterIntimate[] my_intimates;
    public PlayerUnitDexterity dexterity;
    public PlayerUnitIntelligence intelligence;
    public int move;
    public PlayerUnitMind mind;
    public string player_id;
    public int id;
    public int _unit;
    public int?[] equip_gear_ids;
    public PlayerUnitStrength strength;
    public int breakthrough_count;
    public int _unit_type;
    public PlayerUnitHp hp;
    public PlayerUnitAgility agility;
    public PlayerUnitLeader_skills[] leader_skills;
    public int max_level;
    public int buildup_limit;
    public PlayerUnitLucky lucky;
    public PlayerUnitVitality vitality;
    public PlayerUnitGearProficiency[] gear_proficiencies;
    public int exp_next;
    public int level;
    public PlayerUnitSkills[] skills;
    public DateTime created_at;
    public int total_exp;
    public bool favorite;
    public int exp;
    public int buildup_count;

    public PlayerUnit()
    {
    }

    public PlayerUnit(Dictionary<string, object> json)
    {
      this._hasKey = true;
      this.dexterity = json[nameof (dexterity)] != null ? new PlayerUnitDexterity((Dictionary<string, object>) json[nameof (dexterity)]) : (PlayerUnitDexterity) null;
      this.intelligence = json[nameof (intelligence)] != null ? new PlayerUnitIntelligence((Dictionary<string, object>) json[nameof (intelligence)]) : (PlayerUnitIntelligence) null;
      this.move = (int) (long) json[nameof (move)];
      this.mind = json[nameof (mind)] != null ? new PlayerUnitMind((Dictionary<string, object>) json[nameof (mind)]) : (PlayerUnitMind) null;
      this.player_id = (string) json[nameof (player_id)];
      this._key = (object) (this.id = (int) (long) json[nameof (id)]);
      this._unit = (int) (long) json[nameof (unit)];
      this.equip_gear_ids = ((IEnumerable<object>) json[nameof (equip_gear_ids)]).Select<object, int?>((Func<object, int?>) (s =>
      {
        long? nullable = (long?) s;
        return nullable.HasValue ? new int?((int) nullable.Value) : new int?();
      })).ToArray<int?>();
      this.strength = json[nameof (strength)] != null ? new PlayerUnitStrength((Dictionary<string, object>) json[nameof (strength)]) : (PlayerUnitStrength) null;
      this.breakthrough_count = (int) (long) json[nameof (breakthrough_count)];
      this._unit_type = (int) (long) json[nameof (unit_type)];
      this.hp = json[nameof (hp)] != null ? new PlayerUnitHp((Dictionary<string, object>) json[nameof (hp)]) : (PlayerUnitHp) null;
      this.agility = json[nameof (agility)] != null ? new PlayerUnitAgility((Dictionary<string, object>) json[nameof (agility)]) : (PlayerUnitAgility) null;
      List<PlayerUnitLeader_skills> unitLeaderSkillsList = new List<PlayerUnitLeader_skills>();
      foreach (object json1 in (List<object>) json[nameof (leader_skills)])
        unitLeaderSkillsList.Add(json1 != null ? new PlayerUnitLeader_skills((Dictionary<string, object>) json1) : (PlayerUnitLeader_skills) null);
      this.leader_skills = unitLeaderSkillsList.ToArray();
      this.max_level = (int) (long) json[nameof (max_level)];
      this.buildup_limit = (int) (long) json[nameof (buildup_limit)];
      this.lucky = json[nameof (lucky)] != null ? new PlayerUnitLucky((Dictionary<string, object>) json[nameof (lucky)]) : (PlayerUnitLucky) null;
      this.vitality = json[nameof (vitality)] != null ? new PlayerUnitVitality((Dictionary<string, object>) json[nameof (vitality)]) : (PlayerUnitVitality) null;
      List<PlayerUnitGearProficiency> unitGearProficiencyList = new List<PlayerUnitGearProficiency>();
      foreach (object json2 in (List<object>) json[nameof (gear_proficiencies)])
        unitGearProficiencyList.Add(json2 != null ? new PlayerUnitGearProficiency((Dictionary<string, object>) json2) : (PlayerUnitGearProficiency) null);
      this.gear_proficiencies = unitGearProficiencyList.ToArray();
      this.exp_next = (int) (long) json[nameof (exp_next)];
      this.level = (int) (long) json[nameof (level)];
      List<PlayerUnitSkills> playerUnitSkillsList = new List<PlayerUnitSkills>();
      foreach (object json3 in (List<object>) json[nameof (skills)])
        playerUnitSkillsList.Add(json3 != null ? new PlayerUnitSkills((Dictionary<string, object>) json3) : (PlayerUnitSkills) null);
      this.skills = playerUnitSkillsList.ToArray();
      this.created_at = DateTime.Parse((string) json[nameof (created_at)]);
      this.total_exp = (int) (long) json[nameof (total_exp)];
      this.favorite = (bool) json[nameof (favorite)];
      this.exp = (int) (long) json[nameof (exp)];
      this.buildup_count = (int) (long) json[nameof (buildup_count)];
    }

    public override bool Equals(object rhs) => this.Equals(rhs as PlayerUnit);

    public override int GetHashCode() => 0;

    public bool Equals(PlayerUnit rhs)
    {
      if (object.ReferenceEquals((object) rhs, (object) null))
        return false;
      if (object.ReferenceEquals((object) this, (object) rhs))
        return true;
      return (object) this.GetType() == (object) rhs.GetType() && this.unitType == rhs.unitType && this.id == rhs.id && this.player_id == rhs.player_id;
    }

    public bool is_enemy
    {
      get => this.unitType == PlayerUnit.UnitType.Enemy;
      set
      {
        if (value)
          this.unitType = PlayerUnit.UnitType.Enemy;
        else
          this.unitType = PlayerUnit.UnitType.Player;
      }
    }

    public bool is_gesut => this.unitType == PlayerUnit.UnitType.Gesut;

    public PlayerUnit Clone() => (PlayerUnit) this.MemberwiseClone();

    public static PlayerUnit create_by_unitunit(UnitUnit unit)
    {
      return new PlayerUnit() { _unit = unit.ID };
    }

    public static PlayerUnit CreateByPlayerMaterialUnit(PlayerMaterialUnit unit, int count = 0)
    {
      return new PlayerUnit()
      {
        _unit = unit._unit,
        level = 1,
        max_level = 1,
        id = unit.id,
        player_id = count.ToString(),
        _unit_type = MasterData.UnitTypeList[0].ID
      };
    }

    public static PlayerUnit CreateForKey(int id)
    {
      PlayerUnit forKey = new PlayerUnit();
      forKey._hasKey = true;
      forKey._key = (object) (forKey.id = id);
      return forKey;
    }

    public static int CalcEnemyParameter(
      float level,
      int initial,
      float growthRate,
      float deviation_min,
      float deviation_max,
      XorShift random)
    {
      return Mathf.CeilToInt((float) (((double) initial + (double) level * (double) growthRate) * (random == null ? 1.0 : (double) random.RangeFloat(deviation_min, deviation_max))));
    }

    public static PlayerUnit FromEnemy(
      BattleStageEnemy enemy,
      float indicator_level = 0.0f,
      XorShift random = null)
    {
      PlayerUnit playerUnit = new PlayerUnit();
      playerUnit.id = enemy.ID;
      playerUnit.unitType = PlayerUnit.UnitType.Enemy;
      float level = Mathf.Round(Mathf.Max((float) enemy.level, indicator_level + (float) enemy.level_correction));
      int enemy_level = (int) level;
      playerUnit.dexterity = new PlayerUnitDexterity();
      playerUnit.agility = new PlayerUnitAgility();
      playerUnit.mind = new PlayerUnitMind();
      playerUnit.strength = new PlayerUnitStrength();
      playerUnit.vitality = new PlayerUnitVitality();
      playerUnit.hp = new PlayerUnitHp();
      playerUnit.intelligence = new PlayerUnitIntelligence();
      playerUnit.lucky = new PlayerUnitLucky();
      if (enemy.parameter_table == null || enemy.parameter_deviation_table == null || (double) indicator_level == 0.0)
      {
        playerUnit.dexterity.initial = enemy.dexterity;
        playerUnit.agility.initial = enemy.agility;
        playerUnit.mind.initial = enemy.mind;
        playerUnit.strength.initial = enemy.strength;
        playerUnit.vitality.initial = enemy.vitality;
        playerUnit.hp.initial = enemy.hp;
        playerUnit.intelligence.initial = enemy.intelligence;
        playerUnit.lucky.initial = enemy.lucky;
        playerUnit.level = enemy.level;
        playerUnit.max_level = enemy.level;
      }
      else
      {
        playerUnit.dexterity.initial = PlayerUnit.CalcEnemyParameter(level, enemy.parameter_table.initial_dexterity, enemy.parameter_table.growth_rate_dexterity, enemy.parameter_deviation_table.deviation_min_dexterity, enemy.parameter_deviation_table.deviation_max_dexterity, random);
        playerUnit.agility.initial = PlayerUnit.CalcEnemyParameter(level, enemy.parameter_table.initial_agility, enemy.parameter_table.growth_rate_agility, enemy.parameter_deviation_table.deviation_min_agility, enemy.parameter_deviation_table.deviation_max_agility, random);
        playerUnit.mind.initial = PlayerUnit.CalcEnemyParameter(level, enemy.parameter_table.initial_mind, enemy.parameter_table.growth_rate_mind, enemy.parameter_deviation_table.deviation_min_mind, enemy.parameter_deviation_table.deviation_max_mind, random);
        playerUnit.strength.initial = PlayerUnit.CalcEnemyParameter(level, enemy.parameter_table.initial_strength, enemy.parameter_table.growth_rate_strength, enemy.parameter_deviation_table.deviation_min_strength, enemy.parameter_deviation_table.deviation_max_strength, random);
        playerUnit.vitality.initial = PlayerUnit.CalcEnemyParameter(level, enemy.parameter_table.initial_vitality, enemy.parameter_table.growth_rate_vitality, enemy.parameter_deviation_table.deviation_min_vitality, enemy.parameter_deviation_table.deviation_max_vitality, random);
        playerUnit.hp.initial = PlayerUnit.CalcEnemyParameter(level, enemy.parameter_table.initial_hp, enemy.parameter_table.growth_rate_hp, enemy.parameter_deviation_table.deviation_min_hp, enemy.parameter_deviation_table.deviation_max_hp, random);
        playerUnit.intelligence.initial = PlayerUnit.CalcEnemyParameter(level, enemy.parameter_table.initial_intelligence, enemy.parameter_table.growth_rate_intelligence, enemy.parameter_deviation_table.deviation_min_intelligence, enemy.parameter_deviation_table.deviation_max_intelligence, random);
        playerUnit.lucky.initial = PlayerUnit.CalcEnemyParameter(level, enemy.parameter_table.initial_lucky, enemy.parameter_table.growth_rate_lucky, enemy.parameter_deviation_table.deviation_min_lucky, enemy.parameter_deviation_table.deviation_max_lucky, random);
        playerUnit.level = enemy_level;
        playerUnit.max_level = enemy_level;
      }
      playerUnit.breakthrough_count = 0;
      playerUnit.move = enemy.unit.job.movement;
      playerUnit.favorite = false;
      playerUnit.total_exp = 0;
      playerUnit._unit_type = MasterData.UnitTypeList[0].ID;
      playerUnit._unit = enemy.unit_UnitUnit;
      playerUnit.equip_gear_ids = (int?[]) null;
      if (enemy.acquire_skill_group_id == 0 || (double) indicator_level == 0.0)
      {
        playerUnit.skills = ((IEnumerable<BattleStageEnemySkill>) enemy.EnemySkills).Where<BattleStageEnemySkill>((Func<BattleStageEnemySkill, bool>) (x => x.skill.skill_type != BattleskillSkillType.leader)).Select<BattleStageEnemySkill, PlayerUnitSkills>((Func<BattleStageEnemySkill, PlayerUnitSkills>) (x => new PlayerUnitSkills()
        {
          skill_id = x.skill.ID,
          level = x.skill_level
        })).ToArray<PlayerUnitSkills>();
        playerUnit.leader_skills = ((IEnumerable<BattleStageEnemySkill>) enemy.EnemySkills).Where<BattleStageEnemySkill>((Func<BattleStageEnemySkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.leader)).Select<BattleStageEnemySkill, PlayerUnitLeader_skills>((Func<BattleStageEnemySkill, PlayerUnitLeader_skills>) (x => new PlayerUnitLeader_skills()
        {
          skill_id = x.skill.ID,
          level = x.skill_level
        })).ToArray<PlayerUnitLeader_skills>();
      }
      else
      {
        IEnumerable<BattleEnemyAcquireSkill> source = ((IEnumerable<BattleEnemyAcquireSkill>) MasterData.BattleEnemyAcquireSkillList).Where<BattleEnemyAcquireSkill>((Func<BattleEnemyAcquireSkill, bool>) (x => x.group_id == enemy.acquire_skill_group_id && x.level <= enemy_level));
        playerUnit.skills = source.Where<BattleEnemyAcquireSkill>((Func<BattleEnemyAcquireSkill, bool>) (x => x.skill.skill_type != BattleskillSkillType.leader)).Select<BattleEnemyAcquireSkill, PlayerUnitSkills>((Func<BattleEnemyAcquireSkill, PlayerUnitSkills>) (x =>
        {
          int num = Mathf.Min(x.skill.upper_level, (enemy_level - x.level) / x.skill_level_up_rate + 1);
          return new PlayerUnitSkills()
          {
            skill_id = x.skill.ID,
            level = num
          };
        })).ToArray<PlayerUnitSkills>();
        playerUnit.leader_skills = source.Where<BattleEnemyAcquireSkill>((Func<BattleEnemyAcquireSkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.leader)).Select<BattleEnemyAcquireSkill, PlayerUnitLeader_skills>((Func<BattleEnemyAcquireSkill, PlayerUnitLeader_skills>) (x =>
        {
          int num = Mathf.Min(x.skill.upper_level, (enemy_level - x.level) / x.skill_level_up_rate + 1);
          return new PlayerUnitLeader_skills()
          {
            skill_id = x.skill.ID,
            level = num
          };
        })).ToArray<PlayerUnitLeader_skills>();
      }
      playerUnit.is_enemy_leader = playerUnit.leader_skills.Length > 0;
      playerUnit.primary_equipped_gear = new PlayerItem();
      playerUnit.primary_equipped_gear.id = XorShift.Range(int.MinValue, -1);
      playerUnit.primary_equipped_gear.broken = false;
      playerUnit.primary_equipped_gear._entity_type = 3;
      playerUnit.primary_equipped_gear.entity_id = enemy.gear_GearGear;
      playerUnit.primary_equipped_gear.gear_level = enemy.gear_rank;
      playerUnit.primary_equipped_gear.favorite = false;
      playerUnit.primary_equipped_gear.for_battle = false;
      playerUnit.primary_equipped_gear.quantity = 1;
      playerUnit.primary_equipped_gear.gear_buildup_param = new PlayerGearBuildupParam();
      playerUnit.ai_attack = enemy.ai_attack;
      playerUnit.ai_move = enemy.ai_move;
      playerUnit.ai_heal = enemy.ai_heal;
      playerUnit.ai_script_file = enemy.ai_script_id == null ? string.Empty : enemy.ai_script_id.file_name;
      playerUnit.ai_move_target_x = enemy.ai_target_move_x - 1;
      playerUnit.ai_move_target_y = enemy.ai_target_move_y - 1;
      playerUnit.ai_move_group = enemy.ai_move_group;
      playerUnit.ai_move_group_order = enemy.ID;
      playerUnit.ai_use = enemy.ai_use;
      playerUnit.group_id = enemy.group_id;
      playerUnit.spawn_turn = enemy.reinforcement != null ? (enemy.reinforcement.reinforcement_logic.Enum != BattleReinforcementLogicEnum.turn ? int.MaxValue : enemy.reinforcement.arg1_value) : 0;
      playerUnit.reinforcement = enemy.reinforcement;
      playerUnit.gear_proficiencies = new PlayerUnitGearProficiency[1]
      {
        new PlayerUnitGearProficiency()
        {
          level = enemy.proficiency.ID,
          gear_kind_id = playerUnit.unit.kind.ID
        }
      };
      return playerUnit;
    }

    public static PlayerUnit FromGuest(BattleStageGuest guest)
    {
      PlayerUnit playerUnit = new PlayerUnit()
      {
        id = guest.ID,
        unitType = PlayerUnit.UnitType.Gesut,
        dexterity = new PlayerUnitDexterity(),
        agility = new PlayerUnitAgility(),
        mind = new PlayerUnitMind(),
        strength = new PlayerUnitStrength(),
        vitality = new PlayerUnitVitality(),
        hp = new PlayerUnitHp(),
        intelligence = new PlayerUnitIntelligence(),
        lucky = new PlayerUnitLucky()
      };
      playerUnit.dexterity.initial = guest.dexterity;
      playerUnit.agility.initial = guest.agility;
      playerUnit.mind.initial = guest.mind;
      playerUnit.strength.initial = guest.strength;
      playerUnit.vitality.initial = guest.vitality;
      playerUnit.hp.initial = guest.hp;
      playerUnit.intelligence.initial = guest.intelligence;
      playerUnit.lucky.initial = guest.lucky;
      playerUnit.level = guest.level;
      playerUnit.max_level = guest.level;
      playerUnit.breakthrough_count = 0;
      playerUnit.move = guest.unit.job.movement;
      playerUnit.favorite = false;
      playerUnit.total_exp = 0;
      playerUnit._unit_type = MasterData.UnitTypeList[0].ID;
      playerUnit._unit = guest.unit_UnitUnit;
      playerUnit.equip_gear_ids = (int?[]) null;
      playerUnit.skills = ((IEnumerable<BattleStageGuestSkill>) guest.GuestSkills).Where<BattleStageGuestSkill>((Func<BattleStageGuestSkill, bool>) (x => x.skill.skill_type != BattleskillSkillType.leader)).Select<BattleStageGuestSkill, PlayerUnitSkills>((Func<BattleStageGuestSkill, PlayerUnitSkills>) (x => new PlayerUnitSkills()
      {
        skill_id = x.skill.ID,
        level = x.skill_level
      })).ToArray<PlayerUnitSkills>();
      playerUnit.leader_skills = ((IEnumerable<BattleStageGuestSkill>) guest.GuestSkills).Where<BattleStageGuestSkill>((Func<BattleStageGuestSkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.leader)).Select<BattleStageGuestSkill, PlayerUnitLeader_skills>((Func<BattleStageGuestSkill, PlayerUnitLeader_skills>) (x => new PlayerUnitLeader_skills()
      {
        skill_id = x.skill.ID,
        level = x.skill_level
      })).ToArray<PlayerUnitLeader_skills>();
      playerUnit.primary_equipped_gear = new PlayerItem();
      playerUnit.primary_equipped_gear.id = XorShift.Range(int.MinValue, -1);
      playerUnit.primary_equipped_gear.broken = false;
      playerUnit.primary_equipped_gear._entity_type = 3;
      playerUnit.primary_equipped_gear.entity_id = guest.gear_GearGear;
      playerUnit.primary_equipped_gear.gear_level = guest.gear_rank;
      playerUnit.primary_equipped_gear.favorite = false;
      playerUnit.primary_equipped_gear.for_battle = false;
      playerUnit.primary_equipped_gear.quantity = 1;
      playerUnit.primary_equipped_gear.gear_buildup_param = new PlayerGearBuildupParam();
      playerUnit.spawn_turn = 0;
      playerUnit.gear_proficiencies = new PlayerUnitGearProficiency[1]
      {
        new PlayerUnitGearProficiency()
        {
          level = guest.proficiency.ID,
          gear_kind_id = playerUnit.unit.kind.ID
        }
      };
      return playerUnit;
    }

    public static PlayerUnit FromGuest(BattleEarthStageGuest guest)
    {
      PlayerUnit playerUnit = new PlayerUnit()
      {
        id = guest.ID,
        unitType = PlayerUnit.UnitType.Gesut,
        dexterity = new PlayerUnitDexterity(),
        agility = new PlayerUnitAgility(),
        mind = new PlayerUnitMind(),
        strength = new PlayerUnitStrength(),
        vitality = new PlayerUnitVitality(),
        hp = new PlayerUnitHp(),
        intelligence = new PlayerUnitIntelligence(),
        lucky = new PlayerUnitLucky()
      };
      playerUnit.dexterity.initial = guest.dexterity;
      playerUnit.agility.initial = guest.agility;
      playerUnit.mind.initial = guest.mind;
      playerUnit.strength.initial = guest.strength;
      playerUnit.vitality.initial = guest.vitality;
      playerUnit.hp.initial = guest.hp;
      playerUnit.intelligence.initial = guest.intelligence;
      playerUnit.lucky.initial = guest.lucky;
      playerUnit.level = guest.level;
      playerUnit.max_level = guest.level;
      playerUnit.breakthrough_count = 0;
      playerUnit.move = guest.unit.job.movement;
      playerUnit.favorite = false;
      playerUnit.total_exp = 0;
      playerUnit._unit_type = MasterData.UnitTypeList[0].ID;
      playerUnit._unit = guest.unit_UnitUnit;
      playerUnit.equip_gear_ids = (int?[]) null;
      playerUnit.skills = ((IEnumerable<BattleEarthStageGuestSkill>) guest.GuestSkills).Where<BattleEarthStageGuestSkill>((Func<BattleEarthStageGuestSkill, bool>) (x => x.skill.skill_type != BattleskillSkillType.leader)).Select<BattleEarthStageGuestSkill, PlayerUnitSkills>((Func<BattleEarthStageGuestSkill, PlayerUnitSkills>) (x => new PlayerUnitSkills()
      {
        skill_id = x.skill.ID,
        level = x.skill_level
      })).ToArray<PlayerUnitSkills>();
      playerUnit.leader_skills = ((IEnumerable<BattleEarthStageGuestSkill>) guest.GuestSkills).Where<BattleEarthStageGuestSkill>((Func<BattleEarthStageGuestSkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.leader)).Select<BattleEarthStageGuestSkill, PlayerUnitLeader_skills>((Func<BattleEarthStageGuestSkill, PlayerUnitLeader_skills>) (x => new PlayerUnitLeader_skills()
      {
        skill_id = x.skill.ID,
        level = x.skill_level
      })).ToArray<PlayerUnitLeader_skills>();
      playerUnit.primary_equipped_gear = new PlayerItem();
      playerUnit.primary_equipped_gear.id = XorShift.Range(int.MinValue, -1);
      playerUnit.primary_equipped_gear.broken = false;
      playerUnit.primary_equipped_gear._entity_type = 3;
      playerUnit.primary_equipped_gear.entity_id = guest.gear_GearGear;
      playerUnit.primary_equipped_gear.gear_level = guest.gear_rank;
      playerUnit.primary_equipped_gear.favorite = false;
      playerUnit.primary_equipped_gear.for_battle = false;
      playerUnit.primary_equipped_gear.quantity = 1;
      playerUnit.primary_equipped_gear.gear_buildup_param = new PlayerGearBuildupParam();
      playerUnit.spawn_turn = 0;
      playerUnit.gear_proficiencies = new PlayerUnitGearProficiency[1]
      {
        new PlayerUnitGearProficiency()
        {
          level = guest.proficiency.ID,
          gear_kind_id = playerUnit.unit.kind.ID
        }
      };
      return playerUnit;
    }

    public bool checkGroup(int id) => this.group_id.HasValue && this.group_id.Value == id;

    public void SetUserEnemyUnit(BattleStageUserUnit data, PlayerItem gear, bool is_leader)
    {
      this.unitType = PlayerUnit.UnitType.Enemy;
      if (gear != (PlayerItem) null)
        this.primary_equipped_gear = gear;
      this.is_enemy_leader = is_leader;
      this.ai_attack = data.ai_attack;
      this.ai_heal = data.ai_heal;
      this.ai_move = data.ai_move;
      this.ai_move_group = data.ai_move_group;
      this.ai_move_group_order = data.ID;
    }

    public Judgement.NonBattleParameter nonbattleParameter
    {
      get => Judgement.NonBattleParameter.FromPlayerUnit(this);
    }

    public int combat => Judgement.NonBattleParameter.FromPlayerUnit(this).Combat;

    public int total_hp
    {
      get
      {
        return this.unit.IsNormalUnit ? this.hp.initial + this.hp.level + this.hp.compose + this.hp.inheritance + this.hp.buildup + this.hp.transmigrate : 1;
      }
    }

    public int total_strength
    {
      get
      {
        return this.unit.IsNormalUnit ? this.strength.initial + this.strength.level + this.strength.compose + this.strength.inheritance + this.strength.buildup + this.strength.transmigrate : 1;
      }
    }

    public int total_intelligence
    {
      get
      {
        return this.unit.IsNormalUnit ? this.intelligence.initial + this.intelligence.level + this.intelligence.compose + this.intelligence.inheritance + this.intelligence.buildup + this.intelligence.transmigrate : 1;
      }
    }

    public int total_vitality
    {
      get
      {
        return this.unit.IsNormalUnit ? this.vitality.initial + this.vitality.level + this.vitality.compose + this.vitality.inheritance + this.vitality.buildup + this.vitality.transmigrate : 1;
      }
    }

    public int total_dexterity
    {
      get
      {
        return this.unit.IsNormalUnit ? this.dexterity.initial + this.dexterity.level + this.dexterity.compose + this.dexterity.inheritance + this.dexterity.buildup + this.dexterity.transmigrate : 1;
      }
    }

    public int total_agility
    {
      get
      {
        return this.unit.IsNormalUnit ? this.agility.initial + this.agility.level + this.agility.compose + this.agility.inheritance + this.agility.buildup + this.agility.transmigrate : 1;
      }
    }

    public int total_mind
    {
      get
      {
        return this.unit.IsNormalUnit ? this.mind.initial + this.mind.level + this.mind.compose + this.mind.inheritance + this.mind.buildup + this.mind.transmigrate : 1;
      }
    }

    public int total_lucky
    {
      get
      {
        return this.unit.IsNormalUnit ? this.lucky.initial + this.lucky.level + this.lucky.compose + this.lucky.inheritance + this.lucky.buildup + this.lucky.transmigrate : 1;
      }
    }

    public PlayerItem equippedGear
    {
      get
      {
        if (this.primary_equipped_gear != (PlayerItem) null)
          return this.primary_equipped_gear.id == 0 ? (PlayerItem) null : this.primary_equipped_gear;
        if (this.equip_gear_ids == null || this.equip_gear_ids.Length == 0)
          return (PlayerItem) null;
        int? id = this.equip_gear_ids[0];
        if (!id.HasValue)
          return (PlayerItem) null;
        PlayerItem playerItem = ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.entity_type == MasterDataTable.CommonRewardType.gear && x.id == id.Value)).FirstOrDefault<PlayerItem>();
        return playerItem == (PlayerItem) null ? (PlayerItem) null : playerItem;
      }
    }

    public PlayerItem FindEquippedGear(PlayerItem[] items)
    {
      if (this.equip_gear_ids.Length == 0)
        return (PlayerItem) null;
      int? id = this.equip_gear_ids[0];
      if (!id.HasValue)
        return (PlayerItem) null;
      PlayerItem playerItem = ((IEnumerable<PlayerItem>) items).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == id.Value && x.entity_type == MasterDataTable.CommonRewardType.gear)).FirstOrDefault<PlayerItem>();
      return playerItem == (PlayerItem) null ? (PlayerItem) null : playerItem;
    }

    public UnitTypeParameter UnitTypeParameter
    {
      get
      {
        return ((IEnumerable<UnitTypeParameter>) MasterData.UnitTypeParameterList).Single<UnitTypeParameter>((Func<UnitTypeParameter, bool>) (x => x.unit_type.ID == this.unit_type.ID && x.rarity.ID == this.unit.rarity.ID));
      }
    }

    public int amountIncrementInCompose
    {
      get
      {
        return this.unit.IsNormalUnit ? this.hp.compose + this.vitality.compose + this.strength.compose + this.lucky.compose + this.intelligence.compose + this.mind.compose + this.agility.compose + this.dexterity.compose : 0;
      }
    }

    public bool isMaxParamInCompose
    {
      get
      {
        if (!this.unit.IsNormalUnit)
          return false;
        UnitTypeParameter unitTypeParameter = this.UnitTypeParameter;
        return this.hp.compose >= unitTypeParameter.hp_compose_max && this.vitality.compose >= unitTypeParameter.vitality_compose_max && this.strength.compose >= unitTypeParameter.strength_compose_max && this.lucky.compose >= unitTypeParameter.lucky_compose_max && this.intelligence.compose >= unitTypeParameter.intelligence_compose_max && this.mind.compose >= unitTypeParameter.mind_compose_max && this.agility.compose >= unitTypeParameter.agility_compose_max && this.dexterity.compose >= unitTypeParameter.dexterity_compose_max;
      }
    }

    public bool isMaxParamInComposeEx
    {
      get
      {
        if (!this.unit.IsNormalUnit)
          return false;
        bool maxParamInCompose = this.isMaxParamInCompose;
        bool flag1 = ((IEnumerable<PlayerUnitSkills>) this.skills).Count<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.level < x.skill.upper_level)) == 0;
        bool flag2 = this.breakthrough_count >= this.unit.breakthrough_limit;
        return maxParamInCompose && flag1 && flag2;
      }
    }

    public bool isMaxParamInReinforce => this.buildup_count >= this.buildup_limit;

    public bool isMaxLevelupParam
    {
      get
      {
        return this.hp.is_max && this.strength.is_max && this.intelligence.is_max && this.vitality.is_max && this.mind.is_max && this.agility.is_max && this.lucky.is_max;
      }
    }

    public string equippedGearName
    {
      get
      {
        PlayerItem equippedGear = this.equippedGear;
        return equippedGear == (PlayerItem) null ? this.unit.initial_gear.name : equippedGear.name;
      }
    }

    public GearGear equippedGearOrInitial
    {
      get
      {
        PlayerItem equippedGear = this.equippedGear;
        return equippedGear == (PlayerItem) null ? this.unit.initial_gear : equippedGear.gear;
      }
    }

    public GearGear equippedWeaponGearOrInitial
    {
      get
      {
        PlayerItem equippedGear = this.equippedGear;
        return equippedGear == (PlayerItem) null || equippedGear.gear.kind.isNonWeapon ? this.unit.initial_gear : equippedGear.gear;
      }
    }

    public bool isLeftHandWeapon
    {
      get
      {
        return MasterData.UniqueUnitUnitGearModelKindBy(this.unit, this.equippedWeaponGearOrInitial.model_kind).is_left_hand_weapon == 1;
      }
    }

    public bool isDualWieldWeapon
    {
      get
      {
        return MasterData.UniqueUnitUnitGearModelKindBy(this.unit, this.equippedWeaponGearOrInitial.model_kind).is_left_hand_weapon == 2;
      }
    }

    public int buildupLimitBreakCnt
    {
      get
      {
        int buildupLimitBreakCnt = 0;
        foreach (PlayerUnitSkills skill in this.skills)
        {
          PlayerUnitSkills s = skill;
          if (((IEnumerable<BreakThroughBuildupSkill>) MasterData.BreakThroughBuildupSkillList).Any<BreakThroughBuildupSkill>((Func<BreakThroughBuildupSkill, bool>) (x => x.skill_id == s.skill_id)))
            buildupLimitBreakCnt += s.level;
        }
        return buildupLimitBreakCnt;
      }
    }

    public PlayerUnitLeader_skills leader_skill
    {
      get
      {
        return this.leader_skills.Length != 0 ? this.leader_skills[0] : (PlayerUnitLeader_skills) null;
      }
    }

    public UnitProficiency proficiency => this.GetProficiency(this.equippedGearOrInitial.kind);

    public UnitProficiency shildProficiency()
    {
      int key = 1;
      if (this.gear_proficiencies != null)
      {
        PlayerUnitGearProficiency unitGearProficiency = ((IEnumerable<PlayerUnitGearProficiency>) this.gear_proficiencies).SingleOrDefault<PlayerUnitGearProficiency>((Func<PlayerUnitGearProficiency, bool>) (x => x.gear_kind_id == 7));
        key = unitGearProficiency != null ? unitGearProficiency.level : 1;
      }
      return MasterData.UnitProficiency[key];
    }

    public UnitProficiencyIncr ProficiencyIncr
    {
      get => this.GetProficiencyIncr(this.equippedGearOrInitial.kind);
    }

    public UnitProficiency GetProficiency(GearKind kind)
    {
      int key = 1;
      if (this.gear_proficiencies != null)
      {
        PlayerUnitGearProficiency unitGearProficiency = ((IEnumerable<PlayerUnitGearProficiency>) this.gear_proficiencies).SingleOrDefault<PlayerUnitGearProficiency>((Func<PlayerUnitGearProficiency, bool>) (x => x.gear_kind_id == kind.ID));
        key = unitGearProficiency != null ? unitGearProficiency.level : 1;
      }
      return MasterData.UnitProficiency[key];
    }

    public UnitProficiencyIncr GetProficiencyIncr(GearKind kind)
    {
      return UnitProficiencyIncr.FromKindProficiency(kind, this.GetProficiency(kind));
    }

    public int MinMagicBulletPower
    {
      get
      {
        if (this.skills == null)
          return 0;
        PlayerUnitSkills[] array = ((IEnumerable<PlayerUnitSkills>) this.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill.skill_type == BattleskillSkillType.magic)).ToArray<PlayerUnitSkills>();
        return array.Length != 0 ? ((IEnumerable<PlayerUnitSkills>) array).Min<PlayerUnitSkills>((Func<PlayerUnitSkills, int>) (x => x.skill.power)) : 0;
      }
    }

    public float GetElementOrKindRatio(PlayerUnit target)
    {
      Dictionary<Tuple<CommonElement, UnitFamily>, GearElementRatio> dictionary1 = ((IEnumerable<GearElementRatio>) MasterData.GearElementRatioList).ToDictionary<GearElementRatio, Tuple<CommonElement, UnitFamily>>((Func<GearElementRatio, Tuple<CommonElement, UnitFamily>>) (x => Tuple.Create<CommonElement, UnitFamily>(x.element, x.family)));
      foreach (GearGearElement element in this.equippedGearOrInitial.elements)
      {
        foreach (UnitFamily family in target.unit.Families)
        {
          Tuple<CommonElement, UnitFamily> key = Tuple.Create<CommonElement, UnitFamily>(element.element, family);
          if (dictionary1.ContainsKey(key))
            return dictionary1[key].ratio;
        }
      }
      Dictionary<Tuple<int, UnitFamily>, GearKindRatio> dictionary2 = ((IEnumerable<GearKindRatio>) MasterData.GearKindRatioList).ToDictionary<GearKindRatio, Tuple<int, UnitFamily>>((Func<GearKindRatio, Tuple<int, UnitFamily>>) (x => Tuple.Create<int, UnitFamily>(x.kind.ID, x.family)));
      GearKind kind = this.unit.kind;
      foreach (UnitFamily family in target.unit.Families)
      {
        Tuple<int, UnitFamily> key = Tuple.Create<int, UnitFamily>(kind.ID, family);
        if (dictionary2.ContainsKey(key))
          return dictionary2[key].ratio;
      }
      return 1f;
    }

    public Tuple<int, int> GetGearKindIncr(PlayerUnit target)
    {
      GearKindCorrelations kindCorrelations = MasterData.UniqueGearKindCorrelationsBy(this.unit.kind, target.unit.kind);
      if (kindCorrelations != null)
      {
        GearKindIncr gearKindIncr = MasterData.UniqueGearKindIncrBy(this.unit.kind, target.unit.kind, (!kindCorrelations.is_advantage ? target : this).proficiency);
        if (gearKindIncr != null)
          return Tuple.Create<int, int>(gearKindIncr.attack, gearKindIncr.hit);
      }
      return Tuple.Create<int, int>(0, 0);
    }

    public void SetIntimateList(
      PlayerCharacterIntimate[] playerCharactoreIntimates)
    {
      if (playerCharactoreIntimates == null)
        return;
      int characterID = this.unit.character.ID;
      this.my_intimates = ((IEnumerable<PlayerCharacterIntimate>) playerCharactoreIntimates).Where<PlayerCharacterIntimate>((Func<PlayerCharacterIntimate, bool>) (x => x.character.ID == characterID || x.target_character.ID == characterID)).ToArray<PlayerCharacterIntimate>();
    }

    public int GetIntimateValue(PlayerUnit target)
    {
      if (this.my_intimates == null)
        return 0;
      int characterID = target.unit.character.ID;
      PlayerCharacterIntimate characterIntimate = ((IEnumerable<PlayerCharacterIntimate>) this.my_intimates).FirstOrDefault<PlayerCharacterIntimate>((Func<PlayerCharacterIntimate, bool>) (x => x.target_character.ID == characterID || x.character.ID == characterID));
      return characterIntimate == null ? 1 : characterIntimate.level;
    }

    public IntimateDuelSupport GetIntimateDuelSupport(PlayerUnit[] neighborUnits)
    {
      int intimateValue = ((IEnumerable<PlayerUnit>) neighborUnits).Select<PlayerUnit, int>((Func<PlayerUnit, int>) (x => this.GetIntimateValue(x))).Sum();
      return ((IEnumerable<IntimateDuelSupport>) MasterData.IntimateDuelSupportList).Single<IntimateDuelSupport>((Func<IntimateDuelSupport, bool>) (x => x.intimate_value == intimateValue));
    }

    public bool CheckForBattle()
    {
      foreach (PlayerDeck playerDeck in SMManager.Get<PlayerDeck[]>())
      {
        if (playerDeck != null)
        {
          foreach (PlayerUnit playerUnit in playerDeck.player_units)
          {
            if (!(playerUnit == (PlayerUnit) null) && playerUnit.id == this.id)
              return true;
          }
        }
      }
      return false;
    }

    public PlayerUnitSkills[] GetAcquireSkills()
    {
      return this.skills == null ? new PlayerUnitSkills[0] : ((IEnumerable<PlayerUnitSkills>) this.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill.skill_type != BattleskillSkillType.magic && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<PlayerUnitSkills>();
    }

    public Dictionary<int, int> GetAcquireSkillsDictionary()
    {
      Dictionary<int, int> skillsDictionary = new Dictionary<int, int>();
      foreach (PlayerUnitSkills acquireSkill in this.GetAcquireSkills())
        skillsDictionary.Add(acquireSkill.skill_id, acquireSkill.level);
      return skillsDictionary;
    }

    public UnitSkill[] GetSkills()
    {
      return ((IEnumerable<UnitSkill>) this.unit.RememberUnitSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.skill_type != BattleskillSkillType.magic && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<UnitSkill>();
    }

    public BattleskillSkill[] GetBattleSkills()
    {
      List<BattleskillSkill> list = ((IEnumerable<UnitSkill>) this.GetSkills()).Select<UnitSkill, BattleskillSkill>((Func<UnitSkill, BattleskillSkill>) (x => x.skill)).ToList<BattleskillSkill>();
      list.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<UnitSkillCharacterQuest>) this.GetCharacterSkills()).Select<UnitSkillCharacterQuest, BattleskillSkill>((Func<UnitSkillCharacterQuest, BattleskillSkill>) (x => x.skill)).ToArray<BattleskillSkill>());
      list.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<UnitSkillCharacterQuest>) this.GetCharacterSkills()).Where<UnitSkillCharacterQuest>((Func<UnitSkillCharacterQuest, bool>) (x => x.skill_after_evolution > 0)).Select<UnitSkillCharacterQuest, BattleskillSkill>((Func<UnitSkillCharacterQuest, BattleskillSkill>) (x => x.skillOfEvolution)).ToArray<BattleskillSkill>());
      list.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<UnitSkillHarmonyQuest>) this.GetHarmonySkills()).Select<UnitSkillHarmonyQuest, BattleskillSkill>((Func<UnitSkillHarmonyQuest, BattleskillSkill>) (x => x.skill)).ToArray<BattleskillSkill>());
      return list.ToArray();
    }

    public UnitSkillCharacterQuest[] GetCharacterSkills()
    {
      return ((IEnumerable<UnitSkillCharacterQuest>) MasterData.UnitSkillCharacterQuestList).Where<UnitSkillCharacterQuest>((Func<UnitSkillCharacterQuest, bool>) (x => x.unit.ID == this.unit.ID && x.skill.skill_type != BattleskillSkillType.magic && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<UnitSkillCharacterQuest>();
    }

    public UnitSkillHarmonyQuest[] GetHarmonySkills()
    {
      return ((IEnumerable<UnitSkillHarmonyQuest>) MasterData.UnitSkillHarmonyQuestList).Where<UnitSkillHarmonyQuest>((Func<UnitSkillHarmonyQuest, bool>) (x => x.character.ID == this.unit.character.ID && x.skill.skill_type != BattleskillSkillType.magic && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<UnitSkillHarmonyQuest>();
    }

    public UnitSkillIntimate[] GetIntimateSkills()
    {
      return ((IEnumerable<UnitSkillIntimate>) MasterData.UnitSkillIntimateList).Where<UnitSkillIntimate>((Func<UnitSkillIntimate, bool>) (x => x.unit.ID == this.unit.ID && x.skill.skill_type != BattleskillSkillType.magic && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<UnitSkillIntimate>();
    }

    public BattleskillSkill evolutionSkill(BattleskillSkill skill)
    {
      int[] array = ((IEnumerable<PlayerUnitSkills>) this.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill.skill_type != BattleskillSkillType.magic && x.skill.skill_type != BattleskillSkillType.leader)).Select<PlayerUnitSkills, int>((Func<PlayerUnitSkills, int>) (x => x.skill.ID)).ToArray<int>();
      Dictionary<int, UnitSkillEvolution> dictionary = ((IEnumerable<UnitSkillEvolution>) MasterData.UnitSkillEvolutionList).Where<UnitSkillEvolution>((Func<UnitSkillEvolution, bool>) (x => x.unit.ID == this.unit.ID)).ToDictionary<UnitSkillEvolution, int>((Func<UnitSkillEvolution, int>) (x => x.before_skill.ID));
      return dictionary.ContainsKey(skill.ID) && ((IEnumerable<int>) array).Contains<int>(dictionary[skill.ID].after_skill.ID) ? dictionary[skill.ID].after_skill : skill;
    }

    public CommonElement GetElement()
    {
      CommonElement element = CommonElement.none;
      if (this.skills != null)
      {
        IEnumerable<PlayerUnitSkills> source = ((IEnumerable<PlayerUnitSkills>) this.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element))));
        if (source.Count<PlayerUnitSkills>() > 0)
          element = source.First<PlayerUnitSkills>().skill.element;
      }
      else
        element = this.unit.GetElement();
      return element;
    }

    public string GetElementName()
    {
      CommonElementName commonElementName = ((IEnumerable<CommonElementName>) MasterData.CommonElementNameList).First<CommonElementName>((Func<CommonElementName, bool>) (x => (CommonElement) x.ID == this.GetElement()));
      return commonElementName != null ? commonElementName.name : string.Empty;
    }

    public UnitUnit unit
    {
      get
      {
        if (MasterData.UnitUnit.ContainsKey(this._unit))
          return MasterData.UnitUnit[this._unit];
        Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this._unit + "]"));
        return (UnitUnit) null;
      }
    }

    public MasterDataTable.UnitType unit_type
    {
      get
      {
        if (MasterData.UnitType.ContainsKey(this._unit_type))
          return MasterData.UnitType[this._unit_type];
        Debug.LogError((object) ("Key not Found: MasterData.UnitType[" + (object) this._unit_type + "]"));
        return (MasterDataTable.UnitType) null;
      }
    }

    public string SpecialEffectType(
      IEnumerable<QuestScoreBonusTimetable> activeTables,
      IEnumerable<UnitBonus> activeUnitBonus)
    {
      string str = (string) null;
      foreach (QuestScoreBonusTimetable activeTable in activeTables)
      {
        QuestScoreBonusRule[] rules = activeTable.rules;
        if (rules != null)
        {
          foreach (QuestScoreBonusRule questScoreBonusRule in rules)
          {
            QuestScoreBonusRule rule = questScoreBonusRule;
            switch (rule.bonus_type)
            {
              case 1:
                int? targetUnitId = rule.target_unit_id;
                if ((targetUnitId.GetValueOrDefault() != this.unit.ID ? 0 : (targetUnitId.HasValue ? 1 : 0)) != 0)
                {
                  str = activeTable.color_code;
                  break;
                }
                break;
              case 2:
                if (((IEnumerable<PlayerUnitSkills>) this.GetAcquireSkills()).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x =>
                {
                  int skillId = x.skill_id;
                  int? targetSkillId = rule.target_skill_id;
                  int valueOrDefault = targetSkillId.GetValueOrDefault();
                  return skillId == valueOrDefault && targetSkillId.HasValue;
                })) != null)
                {
                  str = activeTable.color_code;
                  break;
                }
                break;
              case 3:
                int? targetJobId = rule.target_job_id;
                if ((targetJobId.GetValueOrDefault() != this.unit.job_UnitJob ? 0 : (targetJobId.HasValue ? 1 : 0)) != 0)
                {
                  str = activeTable.color_code;
                  break;
                }
                break;
            }
          }
        }
      }
      if (string.IsNullOrEmpty(str))
      {
        foreach (UnitBonus activeUnitBonu in activeUnitBonus)
        {
          if (activeUnitBonu != null && activeUnitBonu.target_unit_id_list != null && ((IEnumerable<int>) activeUnitBonu.target_unit_id_list).Contains<int>(this.unit.ID))
          {
            str = activeUnitBonu.color_code;
            break;
          }
        }
      }
      return str;
    }

    public string SpecialEffectFactor(
      IEnumerable<QuestScoreBonusTimetable> activeTables,
      IEnumerable<UnitBonus> activeUnitBonus)
    {
      string str = (string) null;
      foreach (QuestScoreBonusTimetable activeTable in activeTables)
      {
        QuestScoreBonusRule[] rules = activeTable.rules;
        if (rules != null)
        {
          foreach (QuestScoreBonusRule questScoreBonusRule in rules)
          {
            QuestScoreBonusRule rule = questScoreBonusRule;
            switch (rule.bonus_type)
            {
              case 1:
                int? targetUnitId = rule.target_unit_id;
                if ((targetUnitId.GetValueOrDefault() != this.unit.ID ? 0 : (targetUnitId.HasValue ? 1 : 0)) != 0)
                {
                  str = activeTable.GetBreakthroughRate(this.breakthrough_count);
                  break;
                }
                break;
              case 2:
                if (((IEnumerable<PlayerUnitSkills>) this.GetAcquireSkills()).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x =>
                {
                  int skillId = x.skill_id;
                  int? targetSkillId = rule.target_skill_id;
                  int valueOrDefault = targetSkillId.GetValueOrDefault();
                  return skillId == valueOrDefault && targetSkillId.HasValue;
                })) != null)
                {
                  str = activeTable.GetBreakthroughRate(this.breakthrough_count);
                  break;
                }
                break;
              case 3:
                int? targetJobId = rule.target_job_id;
                if ((targetJobId.GetValueOrDefault() != this.unit.job_UnitJob ? 0 : (targetJobId.HasValue ? 1 : 0)) != 0)
                {
                  str = activeTable.GetBreakthroughRate(this.breakthrough_count);
                  break;
                }
                break;
            }
          }
        }
      }
      if (string.IsNullOrEmpty(str))
      {
        foreach (UnitBonus activeUnitBonu in activeUnitBonus)
        {
          if (activeUnitBonu != null && activeUnitBonu.target_unit_id_list != null && ((IEnumerable<int>) activeUnitBonu.target_unit_id_list).Contains<int>(this.unit.ID))
          {
            str = activeUnitBonu.GetBreakthroughRate(this.breakthrough_count);
            break;
          }
        }
      }
      return str;
    }

    public string SpecialEffectEventName(
      IEnumerable<QuestScoreBonusTimetable> activeTables,
      IEnumerable<UnitBonus> activeUnitBonus)
    {
      string str = (string) null;
      foreach (QuestScoreBonusTimetable activeTable in activeTables)
      {
        QuestScoreBonusRule[] rules = activeTable.rules;
        if (rules != null)
        {
          foreach (QuestScoreBonusRule questScoreBonusRule in rules)
          {
            QuestScoreBonusRule rule = questScoreBonusRule;
            switch (rule.bonus_type)
            {
              case 1:
                int? targetUnitId = rule.target_unit_id;
                if ((targetUnitId.GetValueOrDefault() != this.unit.ID ? 0 : (targetUnitId.HasValue ? 1 : 0)) != 0)
                {
                  str = MasterData.QuestExtraS[activeTable.quest_s_id].quest_l.name;
                  break;
                }
                break;
              case 2:
                if (((IEnumerable<PlayerUnitSkills>) this.GetAcquireSkills()).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x =>
                {
                  int skillId = x.skill_id;
                  int? targetSkillId = rule.target_skill_id;
                  int valueOrDefault = targetSkillId.GetValueOrDefault();
                  return skillId == valueOrDefault && targetSkillId.HasValue;
                })) != null)
                {
                  str = MasterData.QuestExtraS[activeTable.quest_s_id].quest_l.name;
                  break;
                }
                break;
              case 3:
                int? targetJobId = rule.target_job_id;
                if ((targetJobId.GetValueOrDefault() != this.unit.job_UnitJob ? 0 : (targetJobId.HasValue ? 1 : 0)) != 0)
                {
                  str = MasterData.QuestExtraS[activeTable.quest_s_id].quest_l.name;
                  break;
                }
                break;
            }
          }
        }
      }
      if (string.IsNullOrEmpty(str))
      {
        foreach (UnitBonus activeUnitBonu in activeUnitBonus)
        {
          if (activeUnitBonu != null && activeUnitBonu.target_unit_id_list != null && ((IEnumerable<int>) activeUnitBonu.target_unit_id_list).Contains<int>(this.unit.ID))
          {
            str = activeUnitBonu.eventPeriod.event_name;
            break;
          }
        }
      }
      return str;
    }

    public Future<GameObject> LoadEquippedNonShieldGearModel()
    {
      return this.unit.non_disp_weapon ? Future.Single<GameObject>((GameObject) null) : MasterData.GearGear[this.equippedWeaponGearOrInitial.ID].LoadModel();
    }

    public Future<GameObject> LoadEquippedGearModel()
    {
      return this.unit.non_disp_weapon ? Future.Single<GameObject>((GameObject) null) : MasterData.GearGear[this.equippedGearOrInitial.ID].LoadModel();
    }

    public string duelAnimatorControllerName
    {
      get
      {
        return MasterData.UniqueUnitUnitGearModelKindBy(this.unit, this.equippedWeaponGearOrInitial.model_kind).duel_animator_controller_name;
      }
    }

    public Future<RuntimeAnimatorController> LoadDuelAnimator()
    {
      return Singleton<ResourceManager>.GetInstance().Load<RuntimeAnimatorController>(string.Format("Animators/duel/{0}", (object) this.duelAnimatorControllerName));
    }

    private string winAnimatorControllerName
    {
      get
      {
        return MasterData.UniqueUnitUnitGearModelKindBy(this.unit, this.equippedWeaponGearOrInitial.model_kind).winning_animator_controller_name;
      }
    }

    public Future<RuntimeAnimatorController> LoadWinAnimator()
    {
      return Singleton<ResourceManager>.GetInstance().Load<RuntimeAnimatorController>(string.Format("Animators/duel_win/{0}", (object) this.winAnimatorControllerName));
    }

    public static bool operator ==(PlayerUnit lhs, PlayerUnit rhs)
    {
      return object.ReferenceEquals((object) lhs, (object) null) ? object.ReferenceEquals((object) rhs, (object) null) : lhs.Equals(rhs);
    }

    public static bool operator !=(PlayerUnit lhs, PlayerUnit rhs) => !(lhs == rhs);

    private enum UnitType
    {
      Player,
      Enemy,
      Gesut,
    }
  }
}
