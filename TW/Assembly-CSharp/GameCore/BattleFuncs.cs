// Decompiled with JetBrains decompiler
// Type: GameCore.BattleFuncs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  public static class BattleFuncs
  {
    private const int CriticalDamageRate = 3;
    private const int EDGE_MAX_COST = 10000;
    private const int costMax = 1000000000;
    public static GameGlobalVariable<BL> environment = GameGlobalVariable<BL>.Null();
    public static BL.Unit[] ZeroArrayUnit = new BL.Unit[0];
    public static BL.ForceID[] ForceIDArrayNone = new BL.ForceID[1]
    {
      BL.ForceID.none
    };
    public static BL.ForceID[] ForceIDArrayPlayer = new BL.ForceID[1];
    public static BL.ForceID[] ForceIDArrayEnemy = new BL.ForceID[1]
    {
      BL.ForceID.enemy
    };
    public static BL.ForceID[] ForceIDArrayNeutral = new BL.ForceID[1]
    {
      BL.ForceID.neutral
    };
    public static BL.ForceID[] ForceIDArrayPlayerTarget = new BL.ForceID[1]
    {
      BL.ForceID.enemy
    };
    public static BL.ForceID[] ForceIDArrayEnemyTarget = new BL.ForceID[1];
    public static BL.ForceID[] ForceIDArrayNeutralTarget = new BL.ForceID[2]
    {
      BL.ForceID.player,
      BL.ForceID.enemy
    };
    private static BattleskillEffectLogicEnum[] DeckEveryGeSkillAddEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_every_ge_fix_strength,
      BattleskillEffectLogicEnum.deck_every_ge_fix_vitality,
      BattleskillEffectLogicEnum.deck_every_ge_fix_intelligence,
      BattleskillEffectLogicEnum.deck_every_ge_fix_mind,
      BattleskillEffectLogicEnum.deck_every_ge_fix_agility,
      BattleskillEffectLogicEnum.deck_every_ge_fix_dexterity,
      BattleskillEffectLogicEnum.deck_every_ge_fix_luck,
      BattleskillEffectLogicEnum.deck_every_ge_fix_move,
      BattleskillEffectLogicEnum.deck_every_ge_fix_physical_attack,
      BattleskillEffectLogicEnum.deck_every_ge_fix_magic_attack,
      BattleskillEffectLogicEnum.deck_every_ge_fix_physical_defense,
      BattleskillEffectLogicEnum.deck_every_ge_fix_magic_defense,
      BattleskillEffectLogicEnum.deck_every_ge_fix_hit,
      BattleskillEffectLogicEnum.deck_every_ge_fix_evasion,
      BattleskillEffectLogicEnum.deck_every_ge_fix_critical,
      BattleskillEffectLogicEnum.deck_every_ge_fix_critical_evasion,
      BattleskillEffectLogicEnum.deck_every_ge_fix_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckEveryGeSkillMulEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_every_ge_ratio_strength,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_vitality,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_intelligence,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_mind,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_agility,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_dexterity,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_luck,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_move,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_physical_attack,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_magic_attack,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_physical_defense,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_magic_defense,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_hit,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_evasion,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_critical,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_critical_evasion,
      BattleskillEffectLogicEnum.deck_every_ge_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckEveryLeSkillAddEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_every_le_fix_strength,
      BattleskillEffectLogicEnum.deck_every_le_fix_vitality,
      BattleskillEffectLogicEnum.deck_every_le_fix_intelligence,
      BattleskillEffectLogicEnum.deck_every_le_fix_mind,
      BattleskillEffectLogicEnum.deck_every_le_fix_agility,
      BattleskillEffectLogicEnum.deck_every_le_fix_dexterity,
      BattleskillEffectLogicEnum.deck_every_le_fix_luck,
      BattleskillEffectLogicEnum.deck_every_le_fix_move,
      BattleskillEffectLogicEnum.deck_every_le_fix_physical_attack,
      BattleskillEffectLogicEnum.deck_every_le_fix_magic_attack,
      BattleskillEffectLogicEnum.deck_every_le_fix_physical_defense,
      BattleskillEffectLogicEnum.deck_every_le_fix_magic_defense,
      BattleskillEffectLogicEnum.deck_every_le_fix_hit,
      BattleskillEffectLogicEnum.deck_every_le_fix_evasion,
      BattleskillEffectLogicEnum.deck_every_le_fix_critical,
      BattleskillEffectLogicEnum.deck_every_le_fix_critical_evasion,
      BattleskillEffectLogicEnum.deck_every_le_fix_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckEveryLeSkillMulEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_every_le_ratio_strength,
      BattleskillEffectLogicEnum.deck_every_le_ratio_vitality,
      BattleskillEffectLogicEnum.deck_every_le_ratio_intelligence,
      BattleskillEffectLogicEnum.deck_every_le_ratio_mind,
      BattleskillEffectLogicEnum.deck_every_le_ratio_agility,
      BattleskillEffectLogicEnum.deck_every_le_ratio_dexterity,
      BattleskillEffectLogicEnum.deck_every_le_ratio_luck,
      BattleskillEffectLogicEnum.deck_every_le_ratio_move,
      BattleskillEffectLogicEnum.deck_every_le_ratio_physical_attack,
      BattleskillEffectLogicEnum.deck_every_le_ratio_magic_attack,
      BattleskillEffectLogicEnum.deck_every_le_ratio_physical_defense,
      BattleskillEffectLogicEnum.deck_every_le_ratio_magic_defense,
      BattleskillEffectLogicEnum.deck_every_le_ratio_hit,
      BattleskillEffectLogicEnum.deck_every_le_ratio_evasion,
      BattleskillEffectLogicEnum.deck_every_le_ratio_critical,
      BattleskillEffectLogicEnum.deck_every_le_ratio_critical_evasion,
      BattleskillEffectLogicEnum.deck_every_le_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckAnotherGeSkillAddEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_another_ge_fix_strength,
      BattleskillEffectLogicEnum.deck_another_ge_fix_vitality,
      BattleskillEffectLogicEnum.deck_another_ge_fix_intelligence,
      BattleskillEffectLogicEnum.deck_another_ge_fix_mind,
      BattleskillEffectLogicEnum.deck_another_ge_fix_agility,
      BattleskillEffectLogicEnum.deck_another_ge_fix_dexterity,
      BattleskillEffectLogicEnum.deck_another_ge_fix_luck,
      BattleskillEffectLogicEnum.deck_another_ge_fix_move,
      BattleskillEffectLogicEnum.deck_another_ge_fix_physical_attack,
      BattleskillEffectLogicEnum.deck_another_ge_fix_magic_attack,
      BattleskillEffectLogicEnum.deck_another_ge_fix_physical_defense,
      BattleskillEffectLogicEnum.deck_another_ge_fix_magic_defense,
      BattleskillEffectLogicEnum.deck_another_ge_fix_hit,
      BattleskillEffectLogicEnum.deck_another_ge_fix_evasion,
      BattleskillEffectLogicEnum.deck_another_ge_fix_critical,
      BattleskillEffectLogicEnum.deck_another_ge_fix_critical_evasion,
      BattleskillEffectLogicEnum.deck_another_ge_fix_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckAnotherGeSkillMulEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_another_ge_ratio_strength,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_vitality,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_intelligence,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_mind,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_agility,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_dexterity,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_luck,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_move,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_physical_attack,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_magic_attack,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_physical_defense,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_magic_defense,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_hit,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_evasion,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_critical,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_critical_evasion,
      BattleskillEffectLogicEnum.deck_another_ge_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckAnotherLeSkillAddEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_another_le_fix_strength,
      BattleskillEffectLogicEnum.deck_another_le_fix_vitality,
      BattleskillEffectLogicEnum.deck_another_le_fix_intelligence,
      BattleskillEffectLogicEnum.deck_another_le_fix_mind,
      BattleskillEffectLogicEnum.deck_another_le_fix_agility,
      BattleskillEffectLogicEnum.deck_another_le_fix_dexterity,
      BattleskillEffectLogicEnum.deck_another_le_fix_luck,
      BattleskillEffectLogicEnum.deck_another_le_fix_move,
      BattleskillEffectLogicEnum.deck_another_le_fix_physical_attack,
      BattleskillEffectLogicEnum.deck_another_le_fix_magic_attack,
      BattleskillEffectLogicEnum.deck_another_le_fix_physical_defense,
      BattleskillEffectLogicEnum.deck_another_le_fix_magic_defense,
      BattleskillEffectLogicEnum.deck_another_le_fix_hit,
      BattleskillEffectLogicEnum.deck_another_le_fix_evasion,
      BattleskillEffectLogicEnum.deck_another_le_fix_critical,
      BattleskillEffectLogicEnum.deck_another_le_fix_critical_evasion,
      BattleskillEffectLogicEnum.deck_another_le_fix_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckAnotherLeSkillMulEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_another_le_ratio_strength,
      BattleskillEffectLogicEnum.deck_another_le_ratio_vitality,
      BattleskillEffectLogicEnum.deck_another_le_ratio_intelligence,
      BattleskillEffectLogicEnum.deck_another_le_ratio_mind,
      BattleskillEffectLogicEnum.deck_another_le_ratio_agility,
      BattleskillEffectLogicEnum.deck_another_le_ratio_dexterity,
      BattleskillEffectLogicEnum.deck_another_le_ratio_luck,
      BattleskillEffectLogicEnum.deck_another_le_ratio_move,
      BattleskillEffectLogicEnum.deck_another_le_ratio_physical_attack,
      BattleskillEffectLogicEnum.deck_another_le_ratio_magic_attack,
      BattleskillEffectLogicEnum.deck_another_le_ratio_physical_defense,
      BattleskillEffectLogicEnum.deck_another_le_ratio_magic_defense,
      BattleskillEffectLogicEnum.deck_another_le_ratio_hit,
      BattleskillEffectLogicEnum.deck_another_le_ratio_evasion,
      BattleskillEffectLogicEnum.deck_another_le_ratio_critical,
      BattleskillEffectLogicEnum.deck_another_le_ratio_critical_evasion,
      BattleskillEffectLogicEnum.deck_another_le_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckSameGeSkillAddEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_same_ge_fix_strength,
      BattleskillEffectLogicEnum.deck_same_ge_fix_vitality,
      BattleskillEffectLogicEnum.deck_same_ge_fix_intelligence,
      BattleskillEffectLogicEnum.deck_same_ge_fix_mind,
      BattleskillEffectLogicEnum.deck_same_ge_fix_agility,
      BattleskillEffectLogicEnum.deck_same_ge_fix_dexterity,
      BattleskillEffectLogicEnum.deck_same_ge_fix_luck,
      BattleskillEffectLogicEnum.deck_same_ge_fix_move,
      BattleskillEffectLogicEnum.deck_same_ge_fix_physical_attack,
      BattleskillEffectLogicEnum.deck_same_ge_fix_magic_attack,
      BattleskillEffectLogicEnum.deck_same_ge_fix_physical_defense,
      BattleskillEffectLogicEnum.deck_same_ge_fix_magic_defense,
      BattleskillEffectLogicEnum.deck_same_ge_fix_hit,
      BattleskillEffectLogicEnum.deck_same_ge_fix_evasion,
      BattleskillEffectLogicEnum.deck_same_ge_fix_critical,
      BattleskillEffectLogicEnum.deck_same_ge_fix_critical_evasion,
      BattleskillEffectLogicEnum.deck_same_ge_fix_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckSameGeSkillMulEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_same_ge_ratio_strength,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_vitality,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_intelligence,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_mind,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_agility,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_dexterity,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_luck,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_move,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_physical_attack,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_magic_attack,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_physical_defense,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_magic_defense,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_hit,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_evasion,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_critical,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_critical_evasion,
      BattleskillEffectLogicEnum.deck_same_ge_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckSameLeSkillAddEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_same_le_fix_strength,
      BattleskillEffectLogicEnum.deck_same_le_fix_vitality,
      BattleskillEffectLogicEnum.deck_same_le_fix_intelligence,
      BattleskillEffectLogicEnum.deck_same_le_fix_mind,
      BattleskillEffectLogicEnum.deck_same_le_fix_agility,
      BattleskillEffectLogicEnum.deck_same_le_fix_dexterity,
      BattleskillEffectLogicEnum.deck_same_le_fix_luck,
      BattleskillEffectLogicEnum.deck_same_le_fix_move,
      BattleskillEffectLogicEnum.deck_same_le_fix_physical_attack,
      BattleskillEffectLogicEnum.deck_same_le_fix_magic_attack,
      BattleskillEffectLogicEnum.deck_same_le_fix_physical_defense,
      BattleskillEffectLogicEnum.deck_same_le_fix_magic_defense,
      BattleskillEffectLogicEnum.deck_same_le_fix_hit,
      BattleskillEffectLogicEnum.deck_same_le_fix_evasion,
      BattleskillEffectLogicEnum.deck_same_le_fix_critical,
      BattleskillEffectLogicEnum.deck_same_le_fix_critical_evasion,
      BattleskillEffectLogicEnum.deck_same_le_fix_attack_speed
    };
    private static BattleskillEffectLogicEnum[] DeckSameLeSkillMulEnum = new BattleskillEffectLogicEnum[17]
    {
      BattleskillEffectLogicEnum.deck_same_le_ratio_strength,
      BattleskillEffectLogicEnum.deck_same_le_ratio_vitality,
      BattleskillEffectLogicEnum.deck_same_le_ratio_intelligence,
      BattleskillEffectLogicEnum.deck_same_le_ratio_mind,
      BattleskillEffectLogicEnum.deck_same_le_ratio_agility,
      BattleskillEffectLogicEnum.deck_same_le_ratio_dexterity,
      BattleskillEffectLogicEnum.deck_same_le_ratio_luck,
      BattleskillEffectLogicEnum.deck_same_le_ratio_move,
      BattleskillEffectLogicEnum.deck_same_le_ratio_physical_attack,
      BattleskillEffectLogicEnum.deck_same_le_ratio_magic_attack,
      BattleskillEffectLogicEnum.deck_same_le_ratio_physical_defense,
      BattleskillEffectLogicEnum.deck_same_le_ratio_magic_defense,
      BattleskillEffectLogicEnum.deck_same_le_ratio_hit,
      BattleskillEffectLogicEnum.deck_same_le_ratio_evasion,
      BattleskillEffectLogicEnum.deck_same_le_ratio_critical,
      BattleskillEffectLogicEnum.deck_same_le_ratio_critical_evasion,
      BattleskillEffectLogicEnum.deck_same_le_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] charismaEffectsEnum = new BattleskillEffectLogicEnum[35]
    {
      BattleskillEffectLogicEnum.charisma_fix_strength,
      BattleskillEffectLogicEnum.charisma_fix_intelligence,
      BattleskillEffectLogicEnum.charisma_fix_mind,
      BattleskillEffectLogicEnum.charisma_fix_agility,
      BattleskillEffectLogicEnum.charisma_fix_dexterity,
      BattleskillEffectLogicEnum.charisma_fix_luck,
      BattleskillEffectLogicEnum.charisma_fix_move,
      BattleskillEffectLogicEnum.charisma_fix_physical_attack,
      BattleskillEffectLogicEnum.charisma_fix_magic_attack,
      BattleskillEffectLogicEnum.charisma_fix_physical_defense,
      BattleskillEffectLogicEnum.charisma_fix_magic_defense,
      BattleskillEffectLogicEnum.charisma_fix_hit,
      BattleskillEffectLogicEnum.charisma_fix_evasion,
      BattleskillEffectLogicEnum.charisma_fix_critical,
      BattleskillEffectLogicEnum.charisma_fix_critical_evasion,
      BattleskillEffectLogicEnum.charisma_fix_attack_speed,
      BattleskillEffectLogicEnum.charisma_ratio_strength,
      BattleskillEffectLogicEnum.charisma_ratio_vitality,
      BattleskillEffectLogicEnum.charisma_ratio_intelligence,
      BattleskillEffectLogicEnum.charisma_ratio_mind,
      BattleskillEffectLogicEnum.charisma_ratio_agility,
      BattleskillEffectLogicEnum.charisma_ratio_dexterity,
      BattleskillEffectLogicEnum.charisma_ratio_luck,
      BattleskillEffectLogicEnum.charisma_ratio_move,
      BattleskillEffectLogicEnum.charisma_ratio_physical_attack,
      BattleskillEffectLogicEnum.charisma_ratio_magic_attack,
      BattleskillEffectLogicEnum.charisma_ratio_physical_defense,
      BattleskillEffectLogicEnum.charisma_ratio_magic_defense,
      BattleskillEffectLogicEnum.charisma_ratio_hit,
      BattleskillEffectLogicEnum.charisma_ratio_evasion,
      BattleskillEffectLogicEnum.charisma_ratio_critical,
      BattleskillEffectLogicEnum.charisma_ratio_critical_evasion,
      BattleskillEffectLogicEnum.charisma_ratio_attack_speed,
      BattleskillEffectLogicEnum.charisma_clamp_hit,
      BattleskillEffectLogicEnum.charisma_damage_rate
    };
    private static BattleskillEffectLogicEnum[] moveDistanceSkillEffectsEnum = new BattleskillEffectLogicEnum[34]
    {
      BattleskillEffectLogicEnum.move_distance_fix_strength,
      BattleskillEffectLogicEnum.move_distance_fix_vitality,
      BattleskillEffectLogicEnum.move_distance_fix_intelligence,
      BattleskillEffectLogicEnum.move_distance_fix_mind,
      BattleskillEffectLogicEnum.move_distance_fix_agility,
      BattleskillEffectLogicEnum.move_distance_fix_dexterity,
      BattleskillEffectLogicEnum.move_distance_fix_luck,
      BattleskillEffectLogicEnum.move_distance_fix_move,
      BattleskillEffectLogicEnum.move_distance_fix_physical_attack,
      BattleskillEffectLogicEnum.move_distance_fix_magic_attack,
      BattleskillEffectLogicEnum.move_distance_fix_physical_defense,
      BattleskillEffectLogicEnum.move_distance_fix_magic_defense,
      BattleskillEffectLogicEnum.move_distance_fix_hit,
      BattleskillEffectLogicEnum.move_distance_fix_evasion,
      BattleskillEffectLogicEnum.move_distance_fix_critical,
      BattleskillEffectLogicEnum.move_distance_fix_critical_evasion,
      BattleskillEffectLogicEnum.move_distance_fix_attack_speed,
      BattleskillEffectLogicEnum.move_distance_ratio_strength,
      BattleskillEffectLogicEnum.move_distance_ratio_vitality,
      BattleskillEffectLogicEnum.move_distance_ratio_intelligence,
      BattleskillEffectLogicEnum.move_distance_ratio_mind,
      BattleskillEffectLogicEnum.move_distance_ratio_agility,
      BattleskillEffectLogicEnum.move_distance_ratio_dexterity,
      BattleskillEffectLogicEnum.move_distance_ratio_luck,
      BattleskillEffectLogicEnum.move_distance_ratio_move,
      BattleskillEffectLogicEnum.move_distance_ratio_physical_attack,
      BattleskillEffectLogicEnum.move_distance_ratio_magic_attack,
      BattleskillEffectLogicEnum.move_distance_ratio_physical_defense,
      BattleskillEffectLogicEnum.move_distance_ratio_magic_defense,
      BattleskillEffectLogicEnum.move_distance_ratio_hit,
      BattleskillEffectLogicEnum.move_distance_ratio_evasion,
      BattleskillEffectLogicEnum.move_distance_ratio_critical,
      BattleskillEffectLogicEnum.move_distance_ratio_critical_evasion,
      BattleskillEffectLogicEnum.move_distance_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] rangeSkillEffectsEnum = new BattleskillEffectLogicEnum[34]
    {
      BattleskillEffectLogicEnum.cavalry_rush_fix_strength,
      BattleskillEffectLogicEnum.cavalry_rush_fix_vitality,
      BattleskillEffectLogicEnum.cavalry_rush_fix_intelligence,
      BattleskillEffectLogicEnum.cavalry_rush_fix_mind,
      BattleskillEffectLogicEnum.cavalry_rush_fix_agility,
      BattleskillEffectLogicEnum.cavalry_rush_fix_dexterity,
      BattleskillEffectLogicEnum.cavalry_rush_fix_luck,
      BattleskillEffectLogicEnum.cavalry_rush_fix_move,
      BattleskillEffectLogicEnum.cavalry_rush_fix_physical_attack,
      BattleskillEffectLogicEnum.cavalry_rush_fix_magic_attack,
      BattleskillEffectLogicEnum.cavalry_rush_fix_physical_defense,
      BattleskillEffectLogicEnum.cavalry_rush_fix_magic_defense,
      BattleskillEffectLogicEnum.cavalry_rush_fix_hit,
      BattleskillEffectLogicEnum.cavalry_rush_fix_evasion,
      BattleskillEffectLogicEnum.cavalry_rush_fix_critical,
      BattleskillEffectLogicEnum.cavalry_rush_fix_critical_evasion,
      BattleskillEffectLogicEnum.cavalry_rush_fix_attack_speed,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_strength,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_vitality,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_intelligence,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_mind,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_agility,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_dexterity,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_luck,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_move,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_physical_attack,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_magic_attack,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_physical_defense,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_magic_defense,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_hit,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_evasion,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_critical,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_critical_evasion,
      BattleskillEffectLogicEnum.cavalry_rush_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] deadCountSkillEffectsEnumPlayerForce = new BattleskillEffectLogicEnum[68]
    {
      BattleskillEffectLogicEnum.dead_count_player_fix_strength,
      BattleskillEffectLogicEnum.dead_count_player_fix_vitality,
      BattleskillEffectLogicEnum.dead_count_player_fix_intelligence,
      BattleskillEffectLogicEnum.dead_count_player_fix_mind,
      BattleskillEffectLogicEnum.dead_count_player_fix_agility,
      BattleskillEffectLogicEnum.dead_count_player_fix_dexterity,
      BattleskillEffectLogicEnum.dead_count_player_fix_luck,
      BattleskillEffectLogicEnum.dead_count_player_fix_move,
      BattleskillEffectLogicEnum.dead_count_player_fix_physical_attack,
      BattleskillEffectLogicEnum.dead_count_player_fix_magic_attack,
      BattleskillEffectLogicEnum.dead_count_player_fix_physical_defense,
      BattleskillEffectLogicEnum.dead_count_player_fix_magic_defense,
      BattleskillEffectLogicEnum.dead_count_player_fix_hit,
      BattleskillEffectLogicEnum.dead_count_player_fix_evasion,
      BattleskillEffectLogicEnum.dead_count_player_fix_critical,
      BattleskillEffectLogicEnum.dead_count_player_fix_critical_evasion,
      BattleskillEffectLogicEnum.dead_count_player_fix_attack_speed,
      BattleskillEffectLogicEnum.dead_count_player_ratio_strength,
      BattleskillEffectLogicEnum.dead_count_player_ratio_vitality,
      BattleskillEffectLogicEnum.dead_count_player_ratio_intelligence,
      BattleskillEffectLogicEnum.dead_count_player_ratio_mind,
      BattleskillEffectLogicEnum.dead_count_player_ratio_agility,
      BattleskillEffectLogicEnum.dead_count_player_ratio_dexterity,
      BattleskillEffectLogicEnum.dead_count_player_ratio_luck,
      BattleskillEffectLogicEnum.dead_count_player_ratio_move,
      BattleskillEffectLogicEnum.dead_count_player_ratio_physical_attack,
      BattleskillEffectLogicEnum.dead_count_player_ratio_magic_attack,
      BattleskillEffectLogicEnum.dead_count_player_ratio_physical_defense,
      BattleskillEffectLogicEnum.dead_count_player_ratio_magic_defense,
      BattleskillEffectLogicEnum.dead_count_player_ratio_hit,
      BattleskillEffectLogicEnum.dead_count_player_ratio_evasion,
      BattleskillEffectLogicEnum.dead_count_player_ratio_critical,
      BattleskillEffectLogicEnum.dead_count_player_ratio_critical_evasion,
      BattleskillEffectLogicEnum.dead_count_player_ratio_attack_speed,
      BattleskillEffectLogicEnum.dead_count_complex_fix_strength,
      BattleskillEffectLogicEnum.dead_count_complex_fix_vitality,
      BattleskillEffectLogicEnum.dead_count_complex_fix_intelligence,
      BattleskillEffectLogicEnum.dead_count_complex_fix_mind,
      BattleskillEffectLogicEnum.dead_count_complex_fix_agility,
      BattleskillEffectLogicEnum.dead_count_complex_fix_dexterity,
      BattleskillEffectLogicEnum.dead_count_complex_fix_luck,
      BattleskillEffectLogicEnum.dead_count_complex_fix_move,
      BattleskillEffectLogicEnum.dead_count_complex_fix_physical_attack,
      BattleskillEffectLogicEnum.dead_count_complex_fix_magic_attack,
      BattleskillEffectLogicEnum.dead_count_complex_fix_physical_defense,
      BattleskillEffectLogicEnum.dead_count_complex_fix_magic_defense,
      BattleskillEffectLogicEnum.dead_count_complex_fix_hit,
      BattleskillEffectLogicEnum.dead_count_complex_fix_evasion,
      BattleskillEffectLogicEnum.dead_count_complex_fix_critical,
      BattleskillEffectLogicEnum.dead_count_complex_fix_critical_evasion,
      BattleskillEffectLogicEnum.dead_count_complex_fix_attack_speed,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_strength,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_vitality,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_intelligence,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_mind,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_agility,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_dexterity,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_luck,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_move,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_physical_attack,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_magic_attack,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_physical_defense,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_magic_defense,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_hit,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_evasion,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_critical,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_critical_evasion,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] deadCountSkillEffectsEnumEnemyForce = new BattleskillEffectLogicEnum[68]
    {
      BattleskillEffectLogicEnum.dead_count_enemy_fix_strength,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_vitality,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_intelligence,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_mind,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_agility,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_dexterity,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_luck,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_move,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_physical_attack,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_magic_attack,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_physical_defense,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_magic_defense,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_hit,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_evasion,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_critical,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_critical_evasion,
      BattleskillEffectLogicEnum.dead_count_enemy_fix_attack_speed,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_strength,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_vitality,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_intelligence,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_mind,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_agility,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_dexterity,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_luck,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_move,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_physical_attack,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_magic_attack,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_physical_defense,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_magic_defense,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_hit,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_evasion,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_critical,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_critical_evasion,
      BattleskillEffectLogicEnum.dead_count_enemy_ratio_attack_speed,
      BattleskillEffectLogicEnum.dead_count_complex_fix_strength,
      BattleskillEffectLogicEnum.dead_count_complex_fix_vitality,
      BattleskillEffectLogicEnum.dead_count_complex_fix_intelligence,
      BattleskillEffectLogicEnum.dead_count_complex_fix_mind,
      BattleskillEffectLogicEnum.dead_count_complex_fix_agility,
      BattleskillEffectLogicEnum.dead_count_complex_fix_dexterity,
      BattleskillEffectLogicEnum.dead_count_complex_fix_luck,
      BattleskillEffectLogicEnum.dead_count_complex_fix_move,
      BattleskillEffectLogicEnum.dead_count_complex_fix_physical_attack,
      BattleskillEffectLogicEnum.dead_count_complex_fix_magic_attack,
      BattleskillEffectLogicEnum.dead_count_complex_fix_physical_defense,
      BattleskillEffectLogicEnum.dead_count_complex_fix_magic_defense,
      BattleskillEffectLogicEnum.dead_count_complex_fix_hit,
      BattleskillEffectLogicEnum.dead_count_complex_fix_evasion,
      BattleskillEffectLogicEnum.dead_count_complex_fix_critical,
      BattleskillEffectLogicEnum.dead_count_complex_fix_critical_evasion,
      BattleskillEffectLogicEnum.dead_count_complex_fix_attack_speed,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_strength,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_vitality,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_intelligence,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_mind,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_agility,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_dexterity,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_luck,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_move,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_physical_attack,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_magic_attack,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_physical_defense,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_magic_defense,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_hit,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_evasion,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_critical,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_critical_evasion,
      BattleskillEffectLogicEnum.dead_count_complex_ratio_attack_speed
    };
    private static BattleskillEffectLogicEnum[] onemanChargeEffectsEnum = new BattleskillEffectLogicEnum[34]
    {
      BattleskillEffectLogicEnum.oneman_charge_fix_strength,
      BattleskillEffectLogicEnum.oneman_charge_fix_vitality,
      BattleskillEffectLogicEnum.oneman_charge_fix_intelligence,
      BattleskillEffectLogicEnum.oneman_charge_fix_mind,
      BattleskillEffectLogicEnum.oneman_charge_fix_agility,
      BattleskillEffectLogicEnum.oneman_charge_fix_dexterity,
      BattleskillEffectLogicEnum.oneman_charge_fix_luck,
      BattleskillEffectLogicEnum.oneman_charge_fix_move,
      BattleskillEffectLogicEnum.oneman_charge_fix_physical_attack,
      BattleskillEffectLogicEnum.oneman_charge_fix_magic_attack,
      BattleskillEffectLogicEnum.oneman_charge_fix_physical_defense,
      BattleskillEffectLogicEnum.oneman_charge_fix_magic_defense,
      BattleskillEffectLogicEnum.oneman_charge_fix_hit,
      BattleskillEffectLogicEnum.oneman_charge_fix_evasion,
      BattleskillEffectLogicEnum.oneman_charge_fix_critical,
      BattleskillEffectLogicEnum.oneman_charge_fix_critical_evasion,
      BattleskillEffectLogicEnum.oneman_charge_ratio_strength,
      BattleskillEffectLogicEnum.oneman_charge_ratio_vitality,
      BattleskillEffectLogicEnum.oneman_charge_ratio_intelligence,
      BattleskillEffectLogicEnum.oneman_charge_ratio_mind,
      BattleskillEffectLogicEnum.oneman_charge_ratio_agility,
      BattleskillEffectLogicEnum.oneman_charge_ratio_dexterity,
      BattleskillEffectLogicEnum.oneman_charge_ratio_luck,
      BattleskillEffectLogicEnum.oneman_charge_ratio_move,
      BattleskillEffectLogicEnum.oneman_charge_ratio_physical_attack,
      BattleskillEffectLogicEnum.oneman_charge_ratio_magic_attack,
      BattleskillEffectLogicEnum.oneman_charge_ratio_physical_defense,
      BattleskillEffectLogicEnum.oneman_charge_ratio_magic_defense,
      BattleskillEffectLogicEnum.oneman_charge_ratio_hit,
      BattleskillEffectLogicEnum.oneman_charge_ratio_evasion,
      BattleskillEffectLogicEnum.oneman_charge_ratio_critical,
      BattleskillEffectLogicEnum.oneman_charge_ratio_critical_evasion,
      BattleskillEffectLogicEnum.oneman_charge_fix_attack_speed,
      BattleskillEffectLogicEnum.oneman_charge_ratio_attack_speed
    };

    public static bool useNeighbors(BL.Unit u, BL env_ = null)
    {
      if (env_ == null)
        env_ = BattleFuncs.env;
      return env_.battleInfo.pvp || env_.battleInfo.gvg || env_.battleInfo.isEarthMode || env_.playerUnits.value.Contains(u);
    }

    public static AttackStatus getCounterAttack(
      BL.UnitPosition attack,
      BL.UnitPosition defense,
      bool isAttack,
      bool isHeal,
      int move_distance = 0,
      int move_range = -1,
      bool isAI = false)
    {
      BL.Unit[] attackNeighbors = !BattleFuncs.useNeighbors(attack.unit) ? BattleFuncs.ZeroArrayUnit : BattleFuncs.getFourForceUnits(attack.row, attack.column, BattleFuncs.getForceIDArray(attack.unit, BattleFuncs.env), isAI).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>();
      BL.Unit[] defenseNeighbors = !BattleFuncs.useNeighbors(defense.unit) ? BattleFuncs.ZeroArrayUnit : BattleFuncs.getFourForceUnits(defense.row, defense.column, BattleFuncs.getForceIDArray(defense.unit, BattleFuncs.env), isAI).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>();
      return BattleFuncs.getCounterAttack(!(attack is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) attack.unit : attack as BL.ISkillEffectListUnit, BattleFuncs.env.getFieldPanel(attack), attackNeighbors, !(defense is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) defense.unit : defense as BL.ISkillEffectListUnit, BattleFuncs.env.getFieldPanel(defense), defenseNeighbors, isAttack, isHeal, move_distance, move_range, isAI);
    }

    public static AttackStatus getCounterAttack(
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.Unit[] attackNeighbors,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      BL.Unit[] defenseNeighbors,
      bool isAttack,
      bool isHeal,
      int move_distance,
      int move_range,
      bool isAI = false)
    {
      AttackStatus[] attackStatusArray = BattleFuncs.getAttackStatusArray(defense, defensePanel, defenseNeighbors, attack, attackPanel, attackNeighbors, defense.hp, isAttack, isHeal, move_distance, move_range, isAI);
      if (((IEnumerable<AttackStatus>) attackStatusArray).Count<AttackStatus>() == 0)
        return (AttackStatus) null;
      AttackStatus attackStatus = ((IEnumerable<AttackStatus>) attackStatusArray).First<AttackStatus>();
      return attackStatus.magicBullet == null ? attackStatus : ((IEnumerable<AttackStatus>) attackStatusArray).Where<AttackStatus>((Func<AttackStatus, bool>) (y => y.magicBullet.isAttack)).OrderBy<AttackStatus, int>((Func<AttackStatus, int>) (y => y.magicBullet.cost)).First<AttackStatus>();
    }

    public static bool isCounterAttack(
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.Unit[] attackNeighbors,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      BL.Unit[] defenseNeighbors,
      int defenseHp,
      bool isAI)
    {
      return BattleFuncs.getAttackStatusArray(defense, defensePanel, defenseNeighbors, attack, attackPanel, attackNeighbors, defenseHp, false, false, isAI: isAI, makeEmptyArray: true).Length > 0;
    }

    public static AttackStatus[] getAttackStatusArray(
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.Unit[] attackNeighbors,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      BL.Unit[] defenseNeighbors,
      int attackHp,
      bool isAttack,
      bool isHeal,
      int move_distance = 0,
      int move_range = -1,
      bool isAI = false,
      bool makeEmptyArray = false)
    {
      if (attack.IsDontAction)
        return new AttackStatus[0];
      AttackStatus[] ret;
      if (BattleFuncs.env.getAttackStatusCache(attack, attackPanel, attackNeighbors, defense, defensePanel, defenseNeighbors, attackHp, isAttack, isHeal, move_distance, move_range, out ret))
        return ret;
      int distance = BL.fieldDistance(attackPanel, defensePanel);
      BL.Unit originalUnit = attack.originalUnit;
      Tuple<int, int> addRange = attackPanel.getEffectsAddRange(originalUnit.unit.kind.ID, originalUnit.unit.job.move_type);
      BL.Unit.GearRange gearRange = originalUnit.gearRange();
      AttackStatus[] data;
      if (((IEnumerable<BL.MagicBullet>) originalUnit.magicBullets).Any<BL.MagicBullet>())
      {
        IEnumerable<BL.MagicBullet> source = ((IEnumerable<BL.MagicBullet>) originalUnit.magicBullets).Where<BL.MagicBullet>((Func<BL.MagicBullet, bool>) (x => x != null && x.isHeal == isHeal && attackHp > x.cost * BattleFuncs.attackCount(attack, defense) && NC.IsReach(x.minRange + addRange.Item1, x.maxRange + addRange.Item2, distance)));
        if (makeEmptyArray)
          return new AttackStatus[source.Count<BL.MagicBullet>()];
        data = !isAttack || !isHeal ? source.Select<BL.MagicBullet, AttackStatus>((Func<BL.MagicBullet, AttackStatus>) (x => BattleFuncs.getAttackStatus(x, attack, attackPanel, attackNeighbors, defense, defensePanel, defenseNeighbors, isAttack, isHeal, move_distance, move_range, isAI))).OrderByDescending<AttackStatus, int>((Func<AttackStatus, int>) (x => x.attack)).ToArray<AttackStatus>() : source.Select<BL.MagicBullet, AttackStatus>((Func<BL.MagicBullet, AttackStatus>) (x => BattleFuncs.getAttackStatus(x, attack, attackPanel, attackNeighbors, defense, defensePanel, defenseNeighbors, isAttack, isHeal, move_distance, move_range, isAI))).OrderBy<AttackStatus, int>((Func<AttackStatus, int>) (x => x.magicBullet.cost)).ToArray<AttackStatus>();
      }
      else
      {
        if (!NC.IsReach(gearRange.Min + addRange.Item1, gearRange.Max + addRange.Item2, distance))
          return new AttackStatus[0];
        if (makeEmptyArray)
          return new AttackStatus[1];
        data = new AttackStatus[1]
        {
          BattleFuncs.getAttackStatus((BL.MagicBullet) null, attack, attackPanel, attackNeighbors, defense, defensePanel, defenseNeighbors, isAttack, isHeal, move_distance, move_range, isAI)
        };
      }
      return BattleFuncs.env.setAttackStatusCache(attack, attackPanel, attackNeighbors, defense, defensePanel, defenseNeighbors, attackHp, isAttack, isHeal, move_distance, move_range, data);
    }

    private static AttackStatus getAttackStatus(
      BL.MagicBullet magicBullet,
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.Unit[] attackNeighbors,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      BL.Unit[] defenseNeighbors,
      bool isAttack,
      bool isHeal,
      int move_distance,
      int move_range,
      bool isAI)
    {
      BL.ForceID forceId1 = BattleFuncs.env.getForceID(attack.originalUnit);
      BL.ForceID forceId2 = BattleFuncs.env.getForceID(defense.originalUnit);
      BL.ForceID[] targetForce1 = BattleFuncs.env.getTargetForce(attack.originalUnit);
      BL.ForceID[] targetForce2 = BattleFuncs.env.getTargetForce(defense.originalUnit);
      IEnumerable<BL.Unit> beAttackDeckUnits = (IEnumerable<BL.Unit>) BattleFuncs.env.forceUnits(forceId1).value;
      IEnumerable<BL.Unit> beAttackTargetDeckUnits = ((IEnumerable<BL.ForceID>) targetForce1).SelectMany<BL.ForceID, BL.Unit>((Func<BL.ForceID, IEnumerable<BL.Unit>>) (x => (IEnumerable<BL.Unit>) BattleFuncs.env.forceUnits(x).value));
      IEnumerable<BL.Unit> beDefenseDeckUnits;
      IEnumerable<BL.Unit> beDefenseTargetDeckUnits;
      if (forceId1 == forceId2)
      {
        beDefenseDeckUnits = beAttackDeckUnits;
        beDefenseTargetDeckUnits = beAttackTargetDeckUnits;
      }
      else
      {
        beDefenseDeckUnits = (IEnumerable<BL.Unit>) BattleFuncs.env.forceUnits(forceId2).value;
        beDefenseTargetDeckUnits = ((IEnumerable<BL.ForceID>) targetForce2).SelectMany<BL.ForceID, BL.Unit>((Func<BL.ForceID, IEnumerable<BL.Unit>>) (x => (IEnumerable<BL.Unit>) BattleFuncs.env.forceUnits(x).value));
      }
      Judgement.BeforeDuelParameter single = Judgement.BeforeDuelParameter.CreateSingle(attack, magicBullet, attackPanel.landform, attackNeighbors, defense, (BL.MagicBullet) null, defensePanel.landform, defenseNeighbors, isAttack, BL.fieldDistance(attackPanel, defensePanel), move_distance, move_range, attack.hp, defense.hp, targetForce1, targetForce2, attackPanel, defensePanel, beAttackDeckUnits, beDefenseDeckUnits, beAttackTargetDeckUnits, beDefenseTargetDeckUnits, isHeal, isAI);
      GearGear gear = attack.originalUnit.weapon.gear;
      bool flag = (gear.attack_type != GearAttackType.none ? (int) gear.attack_type : (int) attack.originalUnit.unit.initial_gear.attack_type) == 6;
      AttackStatus attackStatus = new AttackStatus()
      {
        duelParameter = single,
        isMagic = flag,
        magicBullet = magicBullet,
        attackRate = 1f
      };
      attackStatus.calcElementAttackRate(attack, defense);
      return attackStatus;
    }

    public static void makeAttackStatusArgs(
      BL.UnitPosition attack,
      BL.UnitPosition defense,
      bool isAttack,
      bool isHeal,
      out BL.Unit[] attackNeighbors,
      out BL.Unit[] defenseNeighbors,
      out int move_distance,
      out int move_range,
      bool isAI = false)
    {
      attackNeighbors = !BattleFuncs.useNeighbors(attack.unit) ? BattleFuncs.ZeroArrayUnit : BattleFuncs.getFourForceUnits(attack.row, attack.column, BattleFuncs.getForceIDArray(attack.unit, BattleFuncs.env), isAI).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>();
      defenseNeighbors = !BattleFuncs.useNeighbors(defense.unit) ? BattleFuncs.ZeroArrayUnit : BattleFuncs.getFourForceUnits(defense.row, defense.column, BattleFuncs.getForceIDArray(defense.unit, BattleFuncs.env), isAI).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>();
      if (isHeal)
      {
        move_distance = 0;
        move_range = -1;
      }
      else if (isAttack)
      {
        move_distance = !BattleFuncs.hasEnabledMoveDistanceEffects((BL.ISkillEffectListUnit) attack.unit) ? 0 : BL.fieldDistance(BattleFuncs.env.getFieldPanel(attack, true), BattleFuncs.env.getFieldPanel(defense)) - 1;
        if (BattleFuncs.hasEnabledRangeEffects((BL.ISkillEffectListUnit) attack.unit))
          move_range = BL.fieldDistance(BattleFuncs.env.getFieldPanel(attack, true), BattleFuncs.env.getFieldPanel(attack));
        else
          move_range = -1;
      }
      else
      {
        move_distance = !BattleFuncs.hasEnabledMoveDistanceEffects((BL.ISkillEffectListUnit) defense.unit) ? 0 : BL.fieldDistance(BattleFuncs.env.getFieldPanel(defense, true), BattleFuncs.env.getFieldPanel(attack)) - 1;
        if (BattleFuncs.hasEnabledRangeEffects((BL.ISkillEffectListUnit) defense.unit))
          move_range = BL.fieldDistance(BattleFuncs.env.getFieldPanel(defense, true), BattleFuncs.env.getFieldPanel(defense));
        else
          move_range = -1;
      }
    }

    public static AttackStatus[] getAttackStatusArray(
      BL.UnitPosition attack,
      BL.UnitPosition defense,
      bool isAttack,
      bool isHeal,
      bool isAI = false)
    {
      BL.Unit[] attackNeighbors;
      BL.Unit[] defenseNeighbors;
      int move_distance;
      int move_range;
      BattleFuncs.makeAttackStatusArgs(attack, defense, isAttack, isHeal, out attackNeighbors, out defenseNeighbors, out move_distance, out move_range, isAI);
      BL.ISkillEffectListUnit attack1 = !(attack is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) attack.unit : attack as BL.ISkillEffectListUnit;
      BL.ISkillEffectListUnit defense1 = !(defense is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) defense.unit : defense as BL.ISkillEffectListUnit;
      return BattleFuncs.getAttackStatusArray(attack1, BattleFuncs.env.getFieldPanel(attack), attackNeighbors, defense1, BattleFuncs.env.getFieldPanel(defense), defenseNeighbors, attack1.hp, isAttack, isHeal, move_distance, move_range, isAI);
    }

    public static DuelResult calcDuel(
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      int move_distance,
      int move_range,
      bool isAI = false)
    {
      return attackStatus.isHeal ? BattleFuncs.calcDuelHeal(attackStatus, attack, attackPanel, defense, defensePanel, isAI) : BattleFuncs.calcDuelAttack(attackStatus, attack, attackPanel, defense, defensePanel, move_distance, move_range, isAI);
    }

    public static DuelResult calcDuelHeal(
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      bool isAI = false)
    {
      DuelResult duelResult = new DuelResult()
      {
        moveUnit = attack.originalUnit,
        isColosseum = false,
        isPlayerAttack = attack.originalUnit.isPlayerControl,
        attack = attack.originalUnit,
        defense = defense.originalUnit,
        attackAttackStatus = attackStatus,
        defenseAttackStatus = (AttackStatus) null,
        turns = new BL.DuelTurn[0],
        attackDamage = attackStatus.magicBullet.cost,
        defenseDamage = -attackStatus.heal_attack,
        attackFromDamage = 0,
        defenseFromDamage = 0
      };
      duelResult.isDieAttack = duelResult.attackDamage >= attack.hp;
      duelResult.isDieDefense = duelResult.defenseDamage >= defense.hp;
      return duelResult;
    }

    public static DuelResult calcDuelAttack(
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit attack,
      BL.Panel attackPanel,
      BL.ISkillEffectListUnit defense,
      BL.Panel defensePanel,
      int move_distance,
      int move_range,
      bool isAI = false)
    {
      DuelResult duelResult = new DuelResult();
      duelResult.isColosseum = false;
      duelResult.moveUnit = attack.originalUnit;
      AttackStatus defenseAS = BattleFuncs.getCounterAttack(attack, attackPanel, BattleFuncs.getFourForceUnits(attackPanel.row, attackPanel.column, BattleFuncs.getForceIDArray(attack.originalUnit, BattleFuncs.env), isAI).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>(), defense, defensePanel, BattleFuncs.getFourForceUnits(defensePanel.row, defensePanel.column, BattleFuncs.getForceIDArray(defense.originalUnit, BattleFuncs.env), isAI).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>(), false, false, move_distance, move_range, isAI);
      Tuple<BattleskillSkill, int> tuple = (Tuple<BattleskillSkill, int>) null;
      if (!defense.IsDontAction && defenseAS != null && !BattleFuncs.isSkillsAndEffectsInvalid(defense, attack))
      {
        tuple = BattleFuncs.getUnitAndGearSkills(defense.originalUnit).Where<Tuple<BattleskillSkill, int>>((Func<Tuple<BattleskillSkill, int>, bool>) (x => !defense.IsDontUseSkill(x.Item1.ID) && ((IEnumerable<BattleskillEffect>) x.Item1.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (effect => effect.effect_logic.Enum == BattleskillEffectLogicEnum.ambush && effect.isEnableGameMode(BattleskillInvokeGameModeEnum.quest) && (!effect.HasKey("gear_kind_id") || effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == defense.originalUnit.unit.kind.ID) && (!effect.HasKey("target_gear_kind_id") || effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == attack.originalUnit.unit.kind.ID) && (!effect.HasKey("element") || effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == defense.originalUnit.playerUnit.GetElement()) && (!effect.HasKey("target_element") || effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == attack.originalUnit.playerUnit.GetElement()) && (!effect.HasKey("job_id") || effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == defense.originalUnit.job.ID) && (!effect.HasKey("target_job_id") || effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == attack.originalUnit.job.ID) && (!effect.HasKey("family_id") || effect.GetInt("family_id") == 0 || defense.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id"))) && (!effect.HasKey("target_family_id") || effect.GetInt("target_family_id") == 0 || attack.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && (double) defense.hp <= ((double) effect.GetFloat("percentage") * 100.0 + (double) (x.Item2 * 2)) / 100.0 * (double) defense.originalUnit.parameter.Hp)))).FirstOrDefault<Tuple<BattleskillSkill, int>>();
        if (tuple != null)
        {
          BL.ISkillEffectListUnit skillEffectListUnit = attack;
          attack = defense;
          defense = skillEffectListUnit;
          AttackStatus attackStatus1 = attackStatus;
          attackStatus = defenseAS;
          defenseAS = attackStatus1;
          BL.Panel panel = attackPanel;
          attackPanel = defensePanel;
          defensePanel = panel;
        }
      }
      duelResult.beforeAttakerAilmentEffectIDs = attack.skillEffects.Where(BattleskillSkillType.ailment).Select<BattleskillSkill, int>((Func<BattleskillSkill, int>) (x => x.ailment_effect.ID)).ToArray<int>();
      duelResult.beforeDefenderAilmentEffectIDs = defense.skillEffects.Where(BattleskillSkillType.ailment).Select<BattleskillSkill, int>((Func<BattleskillSkill, int>) (x => x.ailment_effect.ID)).ToArray<int>();
      duelResult.isPlayerAttack = attack.originalUnit.isPlayerControl;
      duelResult.attack = attack.originalUnit;
      duelResult.defense = defense.originalUnit;
      duelResult.attackAttackStatus = attackStatus;
      duelResult.defenseAttackStatus = defenseAS;
      duelResult.distance = BL.fieldDistance(attackPanel, defensePanel);
      BL.SkillEffectList skillEffects1 = attack.skillEffects;
      BL.SkillEffectList skillEffects2 = defense.skillEffects;
      attack.setSkillEffects(CopyUtil.DeepCopy<BL.SkillEffectList>(skillEffects1));
      defense.setSkillEffects(CopyUtil.DeepCopy<BL.SkillEffectList>(skillEffects2));
      duelResult.turns = BattleFuncs.calcTurns(attack, attackStatus, defense, defenseAS, duelResult.distance, isAI, tuple != null);
      attack.setSkillEffects(skillEffects1);
      defense.setSkillEffects(skillEffects2);
      if (tuple != null)
      {
        BL.Skill[] invokeDuelSkills = duelResult.turns[0].invokeDuelSkills;
        BL.Skill[] skillArray = new BL.Skill[invokeDuelSkills.Length + 1];
        skillArray[0] = new BL.Skill()
        {
          id = tuple.Item1.ID
        };
        for (int index = 0; index < invokeDuelSkills.Length; ++index)
          skillArray[index + 1] = invokeDuelSkills[index];
        duelResult.turns[0].invokeDuelSkills = skillArray;
      }
      foreach (BL.DuelTurn turn in duelResult.turns)
      {
        if (turn.isAtackker)
        {
          duelResult.defenseDamage += turn.damage;
          duelResult.defenseDamage -= turn.defenderDrainDamage;
          duelResult.attackDamage += turn.counterDamage;
          duelResult.attackDamage -= turn.drainDamage;
        }
        else
        {
          duelResult.attackDamage += turn.damage;
          duelResult.attackDamage -= turn.defenderDrainDamage;
          duelResult.defenseDamage += turn.counterDamage;
          duelResult.defenseDamage -= turn.drainDamage;
        }
      }
      duelResult.attackFromDamage = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Sum<BL.DuelTurn>((Func<BL.DuelTurn, int>) (x => !x.isAtackker ? x.damage : 0));
      duelResult.defenseFromDamage = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Sum<BL.DuelTurn>((Func<BL.DuelTurn, int>) (x => x.isAtackker ? x.damage : 0));
      duelResult.isDieAttack = duelResult.attackDamage >= attack.hp;
      duelResult.isDieDefense = duelResult.defenseDamage >= defense.hp;
      duelResult.distance = BL.fieldDistance(attackPanel, defensePanel);
      BL.Unit[] array1 = BattleFuncs.getFourForceUnits(attackPanel.row, attackPanel.column, BattleFuncs.getForceIDArray(attack.originalUnit, BattleFuncs.env), isAI).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>();
      BattleFuncs.BeforeDuelDuelSupport beforeDuelDuelSupport1 = BattleFuncs.GetBeforeDuelDuelSupport(attack, defense, array1);
      duelResult.attackDuelSupport = beforeDuelDuelSupport1.duelSupport;
      duelResult.attackDuelSupportHitIncr = beforeDuelDuelSupport1.hitIncr;
      duelResult.attackDuelSupportEvasionIncr = beforeDuelDuelSupport1.evasionIncr;
      duelResult.attackDuelSupportCriticalIncr = beforeDuelDuelSupport1.criticalIncr;
      duelResult.attackDuelSupportCriticalEvasionIncr = beforeDuelDuelSupport1.criticalEvasionIncr;
      BL.Unit[] array2 = BattleFuncs.getFourForceUnits(defensePanel.row, defensePanel.column, BattleFuncs.getForceIDArray(defense.originalUnit, BattleFuncs.env), isAI).Select<BL.UnitPosition, BL.Unit>((Func<BL.UnitPosition, BL.Unit>) (x => x.unit)).ToArray<BL.Unit>();
      BattleFuncs.BeforeDuelDuelSupport beforeDuelDuelSupport2 = BattleFuncs.GetBeforeDuelDuelSupport(defense, attack, array2);
      duelResult.defenseDuelSupport = beforeDuelDuelSupport2.duelSupport;
      duelResult.defenseDuelSupportHitIncr = beforeDuelDuelSupport2.hitIncr;
      duelResult.defenseDuelSupportEvasionIncr = beforeDuelDuelSupport2.evasionIncr;
      duelResult.defenseDuelSupportCriticalIncr = beforeDuelDuelSupport2.criticalIncr;
      duelResult.defenseDuelSupportCriticalEvasionIncr = beforeDuelDuelSupport2.criticalEvasionIncr;
      GearKindCorrelations kindCorrelations1 = MasterData.UniqueGearKindCorrelationsBy(attack.originalUnit.unit.kind, defense.originalUnit.unit.kind);
      BL.DuelHistory duelHistory1 = new BL.DuelHistory()
      {
        inflictTotalDamage = duelResult.defenseFromDamage,
        sufferTotalDamage = duelResult.attackFromDamage,
        criticalCount = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Where<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => x.isAtackker && x.isCritical)).Count<BL.DuelTurn>(),
        inflictMaxDamage = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Max<BL.DuelTurn>((Func<BL.DuelTurn, int>) (x => x.isAtackker ? x.damage : 0)),
        weekElementAttackCount = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Count<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => x.isAtackker && (double) x.attackStatus.elementAttackRate > 1.0)),
        weekKindAttackCount = kindCorrelations1 == null || !kindCorrelations1.is_advantage ? 0 : ((IEnumerable<BL.DuelTurn>) duelResult.turns).Count<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => x.isAtackker)),
        targetUnitID = defense.originalUnit.playerUnit.id
      };
      GearKindCorrelations kindCorrelations2 = MasterData.UniqueGearKindCorrelationsBy(defense.originalUnit.unit.kind, attack.originalUnit.unit.kind);
      BL.DuelHistory duelHistory2 = new BL.DuelHistory()
      {
        inflictTotalDamage = duelResult.attackFromDamage,
        sufferTotalDamage = duelResult.defenseFromDamage,
        criticalCount = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Where<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => !x.isAtackker && x.isCritical)).Count<BL.DuelTurn>(),
        inflictMaxDamage = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Max<BL.DuelTurn>((Func<BL.DuelTurn, int>) (x => !x.isAtackker ? x.damage : 0)),
        weekElementAttackCount = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Count<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => !x.isAtackker && (double) x.attackStatus.elementAttackRate > 1.0)),
        weekKindAttackCount = kindCorrelations2 == null || !kindCorrelations2.is_advantage ? 0 : ((IEnumerable<BL.DuelTurn>) duelResult.turns).Count<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => !x.isAtackker)),
        targetUnitID = attack.originalUnit.playerUnit.id
      };
      List<BL.DuelHistory> duelHistoryList = new List<BL.DuelHistory>();
      if (attack.originalUnit.duelHistory != null)
        duelHistoryList.AddRange((IEnumerable<BL.DuelHistory>) attack.originalUnit.duelHistory);
      duelHistoryList.Add(duelHistory1);
      attack.originalUnit.duelHistory = duelHistoryList.ToArray();
      duelHistoryList.Clear();
      if (defense.originalUnit.duelHistory != null)
        duelHistoryList.AddRange((IEnumerable<BL.DuelHistory>) defense.originalUnit.duelHistory);
      duelHistoryList.Add(duelHistory2);
      defense.originalUnit.duelHistory = duelHistoryList.ToArray();
      return duelResult;
    }

    public static DuelResult calcDuel(
      AttackStatus attackStatus,
      BL.UnitPosition attack,
      BL.UnitPosition defense,
      bool isAI = false)
    {
      return BattleFuncs.calcDuel(attackStatus, !(attack is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) attack.unit : attack as BL.ISkillEffectListUnit, BattleFuncs.env.getFieldPanel(attack), !(defense is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) defense.unit : defense as BL.ISkillEffectListUnit, BattleFuncs.env.getFieldPanel(defense), BL.fieldDistance(BattleFuncs.env.getFieldPanel(attack, true), BattleFuncs.env.getFieldPanel(defense)) - 1, BL.fieldDistance(BattleFuncs.env.getFieldPanel(attack, true), BattleFuncs.env.getFieldPanel(attack)), isAI);
    }

    private static BL.DuelTurn[] calcTurns(
      BL.ISkillEffectListUnit attack,
      AttackStatus attackAS,
      BL.ISkillEffectListUnit defense,
      AttackStatus defenseAS,
      int distance,
      bool isAI,
      bool invokedAmbush)
    {
      List<BL.DuelTurn> turns = new List<BL.DuelTurn>();
      TurnHp hp = new TurnHp();
      hp.attackerHp = attack.hp;
      hp.defenderHp = defense.hp;
      hp.attackerIsDontAction = attack.IsDontAction;
      hp.defenderIsDontAction = defense.IsDontAction;
      hp.attackerIsDontEvasion = attack.IsDontEvasion;
      hp.defenderIsDontEvasion = defense.IsDontEvasion;
      hp.attackerIsDontUseSkill = attack.IsDontAction;
      hp.defenderIsDontUseSkill = defense.IsDontAction;
      hp.attackerCantOneMore = false;
      hp.defenderCantOneMore = false;
      if (BattleFuncs.isSkillsAndEffectsInvalid(attack, defense))
        hp.attackerIsDontUseSkill = true;
      if (BattleFuncs.isSkillsAndEffectsInvalid(defense, attack))
        hp.defenderIsDontUseSkill = true;
      BattleFuncs.calcMultiAttack(turns, hp, true, attack, attackAS, defense, defenseAS, distance, isAI, invokedAmbush, false);
      BattleFuncs.calcMultiAttack(turns, hp, false, defense, defenseAS, attack, attackAS, distance, isAI, invokedAmbush, false);
      if (!hp.attackerCantOneMore && BattleFuncs.canOneMore(attackAS.duelParameter.attackerUnitParameter, attackAS.duelParameter.defenderUnitParameter, attack, defense))
        BattleFuncs.calcMultiAttack(turns, hp, true, attack, attackAS, defense, defenseAS, distance, isAI, invokedAmbush, true);
      if (defenseAS != null && !hp.defenderCantOneMore && BattleFuncs.canOneMore(defenseAS.duelParameter.attackerUnitParameter, defenseAS.duelParameter.defenderUnitParameter, defense, attack))
        BattleFuncs.calcMultiAttack(turns, hp, false, defense, defenseAS, attack, attackAS, distance, isAI, invokedAmbush, true);
      return turns.ToArray();
    }

    private static void calcMultiAttack(
      List<BL.DuelTurn> turns,
      TurnHp hp,
      bool isAttacker,
      BL.ISkillEffectListUnit attack,
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit defense,
      AttackStatus defenseStatus,
      int distance,
      bool isAI,
      bool invokedAmbush,
      bool isOneMoreAttack)
    {
      if (attackStatus == null || (!isAttacker ? (hp.defenderIsDontAction ? 1 : 0) : (hp.attackerIsDontAction ? 1 : 0)) != 0)
        return;
      for (int index = BattleFuncs.attackCount(attack, defense); index > 0; --index)
        BattleFuncs.calcSingleAttack(turns, hp, isAttacker, attack, attackStatus, defense, defenseStatus, distance, BattleFuncs.env.random, isAI, false, invokedAmbush, false, defense.hp, isOneMoreAttack);
    }

    private static BattleFuncs.AttackDamageData calcAttackDamage(
      XorShift random,
      bool isAttacker,
      TurnHp hp,
      BL.ISkillEffectListUnit attack,
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit defense,
      AttackStatus defenseStatus,
      int distance,
      bool isAI,
      bool isColosseum,
      BattleDuelSkill baseDuelSkill,
      bool invokedAmbush,
      bool invokedPrayer,
      float? invokeRate,
      float? criticalRate,
      int defenderDuelBeginHp,
      bool isOneMoreAttack,
      bool isBiattack,
      int biAttackNo = 0)
    {
      BattleFuncs.AttackDamageData ret = new BattleFuncs.AttackDamageData();
      int? nullable1 = new int?();
      float? nullable2 = new float?();
      float? nullable3 = new float?();
      float damageRate1 = baseDuelSkill.damageRate;
      if (baseDuelSkill.biAttackDamageRate != null)
        damageRate1 *= baseDuelSkill.biAttackDamageRate[biAttackNo];
      float attackRate1 = baseDuelSkill.attackRate;
      float damageValue = baseDuelSkill.damageValue;
      int? fixDamage1 = baseDuelSkill.FixDamage;
      float drainRate = baseDuelSkill.drainRate;
      float downPhysicalRate = baseDuelSkill.defenseDownPhysicalRate;
      float defenseDownMagicRate = baseDuelSkill.defenseDownMagicRate;
      float? fixHit = baseDuelSkill.FixHit;
      bool isChageAttackType = baseDuelSkill.isChageAttackType;
      float? percentageDamageRate = baseDuelSkill.PercentageDamageRate;
      float drainRateRatio = baseDuelSkill.drainRateRatio;
      float physicalRateRatio = baseDuelSkill.defenseDownPhysicalRateRatio;
      float downMagicRateRatio = baseDuelSkill.defenseDownMagicRateRatio;
      if (isBiattack)
      {
        foreach (BL.SkillEffect skillEffect in defense.skillEffects.Where(BattleskillEffectLogicEnum.resist_suisei, (Func<BL.SkillEffect, bool>) (x =>
        {
          BattleskillEffect effect = x.effect;
          return !BattleFuncs.isSealedSkillEffect(defense, x) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == defense.originalUnit.unit.kind.ID) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == attack.originalUnit.unit.kind.ID) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == defense.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == attack.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == attack.originalUnit.job.ID) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, defense, attack) && !BattleFuncs.isSkillsAndEffectsInvalid(defense, attack);
        })))
        {
          float num1 = 1f;
          for (int index = biAttackNo < 5 ? biAttackNo + 1 : 5; index >= 1; --index)
          {
            float num2 = skillEffect.effect.GetFloat("percentage_damage_s" + (object) index);
            if ((double) num2 != 0.0)
            {
              num1 = num2;
              break;
            }
          }
          damageRate1 *= num1;
        }
      }
      ret.attackerConsumeSkillEffects = new List<BL.SkillEffect>();
      ret.defenderConsumeSkillEffects = new List<BL.SkillEffect>();
      ret.duelSkillProc = BattleDuelSkill.invokeDuelSkills(attack, attackStatus, defense, defenseStatus, distance, !isAttacker ? hp.defenderHp : hp.attackerHp, !isAttacker ? hp.attackerHp : hp.defenderHp, !isAttacker ? hp.defenderIsDontUseSkill : hp.attackerIsDontUseSkill, !isAttacker ? hp.attackerIsDontUseSkill : hp.defenderIsDontUseSkill, random, isAI, isColosseum, isBiattack, isAttacker, invokedAmbush, invokedPrayer, baseDuelSkill, invokeRate, defenderDuelBeginHp, isOneMoreAttack);
      float? nullable4 = new float?();
      if (ret.duelSkillProc.PercentageDamageRate.HasValue)
        nullable4 = ret.duelSkillProc.PercentageDamageRate;
      else if (percentageDamageRate.HasValue)
        nullable4 = percentageDamageRate;
      BL.MagicBullet magicBullet = attackStatus.magicBullet;
      if (magicBullet != null && !nullable4.HasValue)
      {
        BattleskillEffect percentageDamage = magicBullet.percentageDamage;
        if (percentageDamage != null)
          nullable4 = new float?(percentageDamage.GetFloat("percentage"));
      }
      ret.hp = hp;
      if (ret.duelSkillProc.FixHit.HasValue || fixHit.HasValue)
      {
        int? hitMin = attackStatus.duelParameter.HitMin;
        float? nullable5 = !hitMin.HasValue ? new float?() : new float?((float) hitMin.Value / 100f);
        int? hitMax = attackStatus.duelParameter.HitMax;
        float? nullable6 = !hitMax.HasValue ? new float?() : new float?((float) hitMax.Value / 100f);
        float? nullable7 = !ret.duelSkillProc.FixHit.HasValue ? fixHit : ret.duelSkillProc.FixHit;
        if (nullable6.HasValue && (!nullable7.HasValue || !nullable6.HasValue ? 0 : ((double) nullable7.Value > (double) nullable6.Value ? 1 : 0)) != 0)
          nullable7 = nullable6;
        if (nullable5.HasValue && (!nullable7.HasValue || !nullable5.HasValue ? 0 : ((double) nullable7.Value < (double) nullable5.Value ? 1 : 0)) != 0)
          nullable7 = nullable5;
        ret.isHit = nullable7.HasValue && (double) nullable7.Value >= (double) random.NextFloat();
      }
      else
        ret.isHit = attackStatus.calcHit(random.NextFloat());
      if (defense.IsDontEvasion || (!isAttacker ? (hp.attackerIsDontEvasion ? 1 : 0) : (hp.defenderIsDontEvasion ? 1 : 0)) != 0)
        ret.isHit = true;
      float? nullable8 = criticalRate;
      if (attackStatus.criticalDisplay() > 0 && (!nullable8.HasValue || (!nullable8.HasValue ? 0 : ((double) attackStatus.critical > (double) nullable8.Value ? 1 : 0)) != 0))
        nullable8 = new float?(attackStatus.critical);
      ret.isCritical = ret.isHit && nullable8.HasValue && nullable8.HasValue && (double) nullable8.Value >= (double) random.NextFloat();
      ret.damage = 0;
      ret.dispDamage = 0;
      ret.dispDrainDamage = 0;
      ret.drainDamage = 0;
      ret.counterDamage = 0;
      ret.defenderDispDrainDamage = 0;
      ret.defenderDrainDamage = 0;
      ret.duelSkillProc.invokeDefenderSkill(ret.isCritical);
      if (ret.duelSkillProc.isSuppressCritical || baseDuelSkill.isSuppressCritical)
        ret.isCritical = false;
      if (ret.duelSkillProc.attackerCantOneMore || baseDuelSkill.attackerCantOneMore)
      {
        if (isAttacker)
          hp.attackerCantOneMore = true;
        else
          hp.defenderCantOneMore = true;
      }
      if (biAttackNo == 0)
      {
        int hp1 = attack.originalUnit.parameter.Hp;
        ret.counterDamage += Mathf.CeilToInt((float) hp1 * baseDuelSkill.counterDamageHpPercentage) + Mathf.CeilToInt((float) hp1 * ret.duelSkillProc.counterDamageHpPercentage);
        ret.counterDamage += ret.duelSkillProc.counterDamageValue + baseDuelSkill.counterDamageValue;
      }
      System.Action action = (System.Action) (() =>
      {
        if (isAttacker)
        {
          ret.counterDamage = NC.Clamp(0, hp.attackerHp, ret.counterDamage);
          hp.attackerHp -= ret.counterDamage;
        }
        else
        {
          ret.counterDamage = NC.Clamp(0, hp.defenderHp, ret.counterDamage);
          hp.defenderHp -= ret.counterDamage;
        }
      });
      if (ret.isHit)
      {
        int physicalDefense = attackStatus.duelParameter.defenderUnitParameter.PhysicalDefense;
        int magicDefense = attackStatus.duelParameter.defenderUnitParameter.MagicDefense;
        float num3 = ret.duelSkillProc.defenseDownPhysicalRate * downPhysicalRate;
        float num4 = ret.duelSkillProc.defenseDownMagicRate * defenseDownMagicRate;
        float num5 = 1f - (1f - num3) * (ret.duelSkillProc.defenseDownPhysicalRateRatio * physicalRateRatio);
        float num6 = 1f - (1f - num4) * (ret.duelSkillProc.defenseDownMagicRateRatio * downMagicRateRatio);
        attackStatus.duelParameter.defenderUnitParameter.PhysicalDefense = (int) Mathf.Ceil((float) physicalDefense * num5);
        attackStatus.duelParameter.defenderUnitParameter.MagicDefense = (int) Mathf.Ceil((float) magicDefense * num6);
        float num7 = ret.duelSkillProc.damageRate * damageRate1;
        foreach (BL.SkillEffect skillEffect in attack.skillEffects.Where(BattleskillEffectLogicEnum.damage_rate_one_more_attack, (Func<BL.SkillEffect, bool>) (x =>
        {
          BattleskillEffect effect = x.effect;
          int num9 = effect.GetInt("attack_phase");
          return !BattleFuncs.isSealedSkillEffect(attack, x) && (num9 == 0 || num9 == 1 && !isOneMoreAttack || num9 == 2 && isOneMoreAttack) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == defense.originalUnit.playerUnit.GetElement()) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == attack.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == defense.originalUnit.unit.kind.ID) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == attack.originalUnit.unit.kind.ID) && (effect.GetInt("target_family_id") == 0 || defense.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && (effect.GetInt("family_id") == 0 || attack.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id"))) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, attack, defense) && !BattleFuncs.isSkillsAndEffectsInvalid(attack, defense);
        })))
        {
          if (BattleFuncs.isInvoke(attack, defense, attackStatus.duelParameter.attackerUnitParameter, attackStatus.duelParameter.defenderUnitParameter, skillEffect.baseSkillLevel, skillEffect.effect.GetFloat("percentage_invocation"), random))
          {
            float num8 = skillEffect.effect.GetFloat("damage_percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
            if ((double) num8 < 0.0)
              num8 = 0.0f;
            num7 *= num8;
          }
        }
        if (ret.duelSkillProc.isInvokeCounterAttack)
          num7 *= ret.duelSkillProc.counterDamageRate;
        int? fixDamage2 = attackStatus.duelParameter.FixDamage;
        if (ret.duelSkillProc.FixDamage.HasValue)
          attackStatus.duelParameter.FixDamage = ret.duelSkillProc.FixDamage;
        else if (fixDamage1.HasValue)
          attackStatus.duelParameter.FixDamage = fixDamage1;
        if (nullable4.HasValue)
        {
          int preHp = !isAttacker ? hp.attackerHp : hp.defenderHp;
          attackStatus.duelParameter.FixDamage = new int?(BattleFuncs.calcPercentageDamage(preHp, nullable4.Value));
        }
        int physicalAttack = attackStatus.duelParameter.attackerUnitParameter.PhysicalAttack;
        attackStatus.duelParameter.attackerUnitParameter.PhysicalAttack += (int) ((double) ret.duelSkillProc.damageValue + (double) damageValue);
        int magicAttack = attackStatus.duelParameter.attackerUnitParameter.MagicAttack;
        attackStatus.duelParameter.attackerUnitParameter.MagicAttack += (int) ((double) ret.duelSkillProc.damageValue + (double) damageValue);
        bool isMagic = attackStatus.isMagic;
        attackStatus.isMagic = ret.duelSkillProc.isChageAttackType || isChageAttackType ? !isMagic : isMagic;
        float attackRate2 = attackStatus.attackRate;
        attackStatus.attackRate = ret.duelSkillProc.attackRate * attackRate1;
        float damageRate2 = attackStatus.duelParameter.DamageRate;
        attackStatus.duelParameter.DamageRate *= num7;
        float num10 = 1f;
        float num11 = Mathf.Max(1f, attackStatus.originalAttack * num10) * (!ret.isCritical ? 1f : 3f);
        attackStatus.duelParameter.attackerUnitParameter.PhysicalAttack = physicalAttack;
        attackStatus.duelParameter.attackerUnitParameter.MagicAttack = magicAttack;
        attackStatus.duelParameter.FixDamage = fixDamage2;
        attackStatus.duelParameter.defenderUnitParameter.PhysicalDefense = physicalDefense;
        attackStatus.duelParameter.defenderUnitParameter.MagicDefense = magicDefense;
        attackStatus.isMagic = isMagic;
        attackStatus.attackRate = attackRate2;
        attackStatus.duelParameter.DamageRate = damageRate2;
        if ((double) num11 < 1.0)
          num11 = 1f;
        IEnumerable<BL.SkillEffect> source1 = defense.skillEffects.Where(BattleskillEffectLogicEnum.absolute_defense, (Func<BL.SkillEffect, bool>) (x =>
        {
          BattleskillEffect effect = x.effect;
          return (!x.useRemain.HasValue || x.useRemain.Value >= 1) && !BattleFuncs.isSealedSkillEffect(defense, x) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == attack.originalUnit.unit.kind.ID) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == defense.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == attack.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == attack.originalUnit.job.ID) && (effect.GetInt("target_family_id") == 0 || attack.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && (effect.GetInt("character_id") == 0 || effect.GetInt("character_id") == defense.originalUnit.unit.character.ID) && (effect.GetInt("target_unit_id") == 0 || effect.GetInt("target_unit_id") == attack.originalUnit.unit.ID) && (effect.GetInt("unit_id") == 0 || effect.GetInt("unit_id") == defense.originalUnit.unit.ID) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, defense, attack) && !BattleFuncs.isSkillsAndEffectsInvalid(defense, attack);
        }));
        if (source1.Any<BL.SkillEffect>())
        {
          foreach (BL.SkillEffect skillEffect1 in source1)
          {
            if (BattleFuncs.isInvoke(defense, attack, attackStatus.duelParameter.defenderUnitParameter, attackStatus.duelParameter.attackerUnitParameter, skillEffect1.baseSkillLevel, skillEffect1.effect.GetFloat("percentage_invocation"), random))
            {
              ret.defenderConsumeSkillEffects.Add(skillEffect1);
              if (skillEffect1.useRemain.HasValue && skillEffect1.useRemain.Value >= 1)
              {
                BL.SkillEffect skillEffect2 = skillEffect1;
                int? useRemain = skillEffect1.useRemain;
                int? nullable9 = !useRemain.HasValue ? new int?() : new int?(useRemain.Value - 1);
                skillEffect2.useRemain = nullable9;
              }
              num11 = 0.0f;
              break;
            }
          }
        }
        ret.duelSkillProc.InvokeDamageSkill((int) num11);
        if (!invokedPrayer)
          invokedPrayer = ((IEnumerable<BL.Skill>) ret.duelSkillProc.defenderSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (y => y.effect_logic.Enum == BattleskillEffectLogicEnum.prayer))));
        if (!invokedPrayer)
        {
          int num12 = !isAttacker ? hp.attackerHp : hp.defenderHp;
          if ((double) num11 >= (double) num12 && defenderDuelBeginHp >= 2)
          {
            IEnumerable<BL.SkillEffect> source2 = defense.skillEffects.Where(BattleskillEffectLogicEnum.passive_prayer, (Func<BL.SkillEffect, bool>) (x =>
            {
              BattleskillEffect effect = x.effect;
              return (!x.useRemain.HasValue || x.useRemain.Value >= 1) && !BattleFuncs.isSealedSkillEffect(defense, x) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == defense.originalUnit.unit.kind.ID) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == attack.originalUnit.unit.kind.ID) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == defense.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == attack.originalUnit.playerUnit.GetElement()) && (effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == defense.originalUnit.job.ID) && (effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == attack.originalUnit.job.ID) && (effect.GetInt("family_id") == 0 || defense.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id"))) && (effect.GetInt("target_family_id") == 0 || attack.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && (!effect.HasKey("invoke_gamemode") || effect.GetInt("invoke_gamemode") == 0 || effect.GetInt("invoke_gamemode") == 1 && !isColosseum || effect.GetInt("invoke_gamemode") == 2 && isColosseum) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, defense, attack) && !BattleFuncs.isSkillsAndEffectsInvalid(defense, attack);
            }));
            if (source2.Any<BL.SkillEffect>())
            {
              foreach (BL.SkillEffect skillEffect in source2)
              {
                if (BattleFuncs.isInvoke(defense, attack, attackStatus.duelParameter.defenderUnitParameter, attackStatus.duelParameter.attackerUnitParameter, skillEffect.baseSkillLevel, skillEffect.effect.GetFloat("percentage_invocation"), random, effect: skillEffect.effect))
                {
                  ret.defenderConsumeSkillEffects.Add(skillEffect);
                  invokedPrayer = true;
                  break;
                }
              }
            }
          }
        }
        if (invokedPrayer)
        {
          int num13 = !isAttacker ? hp.attackerHp : hp.defenderHp;
          if ((double) num11 >= (double) num13)
            num11 = (float) (num13 - 1);
        }
        ret.damage = NC.Clamp(0, !isAttacker ? hp.attackerHp : hp.defenderHp, (int) num11);
        ret.dispDamage = NC.Clamp(0, 999, (int) num11);
        if (ret.duelSkillProc.isInvokeCounterAttack)
        {
          float num14 = num11 * ret.duelSkillProc.counterAttackRate;
          ret.counterDamage += (int) num14;
        }
        action();
        if ((!isAttacker ? (!hp.attackerIsDontAction ? 1 : 0) : (!hp.defenderIsDontAction ? 1 : 0)) != 0)
        {
          IEnumerable<BL.SkillEffect> source3 = defense.skillEffects.Where(BattleskillEffectLogicEnum.damage_drain, (Func<BL.SkillEffect, bool>) (x =>
          {
            BattleskillEffect effect = x.effect;
            return !BattleFuncs.isSealedSkillEffect(defense, x) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == defense.originalUnit.unit.kind.ID) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == attack.originalUnit.unit.kind.ID) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == defense.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == attack.originalUnit.playerUnit.GetElement()) && (effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == defense.originalUnit.job.ID) && (effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == attack.originalUnit.job.ID) && (effect.GetInt("family_id") == 0 || defense.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id"))) && (effect.GetInt("target_family_id") == 0 || attack.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, defense, attack) && !BattleFuncs.isSkillsAndEffectsInvalid(defense, attack);
          }));
          if (source3.Any<BL.SkillEffect>())
          {
            int num15 = 0;
            foreach (BL.SkillEffect skillEffect in source3)
            {
              float num16 = skillEffect.effect.GetFloat("percentage_drain") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
              num15 += (int) ((double) ret.damage * (double) num16);
            }
            ret.defenderDispDrainDamage = num15;
            int num17 = (!isAttacker ? hp.attackerHp : hp.defenderHp) - ret.damage;
            ret.defenderDrainDamage = Mathf.Min(defense.originalUnit.parameter.Hp, num17 + ret.defenderDispDrainDamage) - num17;
          }
        }
        ret.dispDrainDamage = 0;
        ret.drainDamage = 0;
        int hp2 = attack.originalUnit.parameter.Hp;
        float num18 = ret.duelSkillProc.attackerSkills.Length >= 1 || baseDuelSkill.attackerSkills.Length >= 1 ? ret.duelSkillProc.drainRateRatio * drainRateRatio : 1f;
        if ((double) ret.duelSkillProc.drainRate > 0.0)
        {
          ret.dispDrainDamage = Mathf.CeilToInt((float) ret.damage * ret.duelSkillProc.drainRate * num18);
          ret.drainDamage = NC.Clamp(0, hp2, ret.dispDrainDamage);
        }
        else if ((double) drainRate > 0.0)
        {
          ret.dispDrainDamage = Mathf.CeilToInt((float) ret.damage * drainRate * num18);
          ret.drainDamage = NC.Clamp(0, hp2, ret.dispDrainDamage);
        }
        else if (attackStatus.isDrain)
        {
          ret.dispDrainDamage = Mathf.CeilToInt((float) ret.damage * attackStatus.drainRate * num18);
          ret.drainDamage = NC.Clamp(0, hp2, ret.dispDrainDamage);
        }
        if (isAttacker)
        {
          ret.hp.defenderHp -= ret.damage;
          ret.hp.defenderHp += ret.defenderDrainDamage;
          int num19 = Mathf.Min(hp2, hp.attackerHp + ret.drainDamage);
          if (ret.dispDrainDamage > 0)
            ret.drainDamage = Mathf.Max(0, num19 - hp.attackerHp);
          ret.hp.attackerHp = num19;
        }
        else
        {
          ret.hp.attackerHp -= ret.damage;
          ret.hp.attackerHp += ret.defenderDrainDamage;
          int num20 = Mathf.Min(hp2, hp.defenderHp + ret.drainDamage);
          if (ret.dispDrainDamage > 0)
            ret.drainDamage = Mathf.Max(0, num20 - hp.defenderHp);
          hp.defenderHp = num20;
        }
      }
      else
      {
        ret.duelSkillProc.InvokeDamageSkill(0);
        action();
      }
      foreach (BL.SkillEffect skillEffect in attack.skillEffects.Where(BattleskillEffectLogicEnum.passive_invest_passive, (Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect = x.effect;
        int num = effect.GetInt("attack_phase");
        return !BattleFuncs.isSealedSkillEffect(attack, x) && (num == 0 || num == 1 && !isOneMoreAttack || num == 2 && isOneMoreAttack) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == defense.originalUnit.playerUnit.GetElement()) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == attack.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == defense.originalUnit.unit.kind.ID) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == attack.originalUnit.unit.kind.ID) && (effect.GetInt("target_family_id") == 0 || defense.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, attack, defense) && !BattleFuncs.isSkillsAndEffectsInvalid(attack, defense);
      })))
      {
        int num = skillEffect.effect.GetInt("skill_id");
        bool flag;
        if (num < 0)
        {
          flag = true;
          num = -num;
        }
        else
          flag = false;
        if (num != 0 && MasterData.BattleskillSkill.ContainsKey(num))
        {
          float lottery = skillEffect.effect.GetFloat("percentage_invest") + skillEffect.effect.GetFloat("percentage_invest_levelup") * (float) skillEffect.baseSkillLevel;
          BattleskillSkill battleskillSkill = MasterData.BattleskillSkill[num];
          foreach (BL.ISkillEffectListUnit skillEffectListUnit in BattleFuncs.getInvestUnit(attack, defense, num, skillEffect.effect.GetInt("range_type"), isAI, isColosseum))
          {
            if (battleskillSkill.skill_type == BattleskillSkillType.ailment)
            {
              if (BattleFuncs.isAilmentInvest(lottery, num, skillEffectListUnit, random))
                ret.duelSkillProc.addInvestSkills(skillEffectListUnit, BattleFuncs.ailmentInvest(num, skillEffectListUnit), true, false, 0);
            }
            else if ((double) lottery >= (double) random.NextFloat())
              ret.duelSkillProc.addInvestSkills(skillEffectListUnit, new BL.Skill[1]
              {
                new BL.Skill() { id = num, level = 1 }
              }, false, (flag ? 1 : 0) != 0, 0);
          }
        }
      }
      return ret;
    }

    public static void calcSingleAttack(
      List<BL.DuelTurn> turns,
      TurnHp hp,
      bool isAttacker,
      BL.ISkillEffectListUnit attack,
      AttackStatus attackStatus,
      BL.ISkillEffectListUnit defense,
      AttackStatus defenseStatus,
      int distance,
      XorShift random,
      bool isAI,
      bool isColosseum,
      bool invokedAmbush,
      bool invokedPrayer,
      int defenseHp,
      bool isOneMoreAttack)
    {
      if (hp.isDieAttackerOrDefender())
        return;
      BL.MagicBullet magicBullet = attackStatus.magicBullet;
      if (magicBullet != null && (!isAttacker ? hp.defenderHp : hp.attackerHp) <= magicBullet.cost)
        return;
      if (!invokedPrayer)
      {
        invokedPrayer = BattleFuncs.isInvokedDefenderSkillLogic((IEnumerable<BL.DuelTurn>) turns, BattleskillEffectLogicEnum.prayer, new bool?(isAttacker));
        if (!invokedPrayer)
          invokedPrayer = BattleFuncs.isInvokedDefenderConsumeSkillLogic((IEnumerable<BL.DuelTurn>) turns, BattleskillEffectLogicEnum.passive_prayer, new bool?(isAttacker));
      }
      IEnumerable<BattleskillSkill> battleskillSkills = defense.skillEffects.Where(BattleskillSkillType.ailment);
      IEnumerable<BattleskillSkill> second = attack.skillEffects.Where(BattleskillSkillType.ailment);
      BL.DuelTurn duelTurn1 = new BL.DuelTurn();
      duelTurn1.isAtackker = isAttacker;
      duelTurn1.attackStatus = attackStatus;
      duelTurn1.attackerStatus = (AttackStatus) null;
      duelTurn1.defenderStatus = (AttackStatus) null;
      duelTurn1.counterDamage = magicBullet == null ? 0 : magicBullet.cost;
      duelTurn1.skillIds = ((IEnumerable<BL.Skill>) attack.originalUnit.skills).Select<BL.Skill, int>((Func<BL.Skill, int>) (x => x.id)).ToArray<int>();
      if (isAttacker)
        hp.attackerHp -= duelTurn1.counterDamage;
      else
        hp.defenderHp -= duelTurn1.counterDamage;
      float? criticalRate = new float?();
      float? invokeRate = new float?();
      List<BL.Skill> first = new List<BL.Skill>();
      if ((!isAttacker ? (hp.defenderIsDontUseSkill ? 1 : 0) : (hp.attackerIsDontUseSkill ? 1 : 0)) == 0)
      {
        IEnumerable<Tuple<BattleskillSkill, int>> source = BattleFuncs.getUnitAndGearSkills(attack.originalUnit).Where<Tuple<BattleskillSkill, int>>((Func<Tuple<BattleskillSkill, int>, bool>) (skill => ((IEnumerable<BattleskillEffect>) skill.Item1.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (effect => effect.effect_logic.Enum == BattleskillEffectLogicEnum.fierce_rival && !attack.IsDontUseSkill(skill.Item1.ID)))));
        if (source.Any<Tuple<BattleskillSkill, int>>() && !BattleFuncs.isSkillsAndEffectsInvalid(attack, defense))
        {
          BL.DuelTurn duelTurn2 = turns.LastOrDefault<BL.DuelTurn>();
          foreach (Tuple<BattleskillSkill, int> tuple in source)
          {
            bool flag = false;
            foreach (BattleskillEffect battleskillEffect in ((IEnumerable<BattleskillEffect>) tuple.Item1.Effects).Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.fierce_rival)))
            {
              int num1 = battleskillEffect.GetInt("invoke_skill");
              int num2 = battleskillEffect.GetInt("invoke_critical");
              int num3 = battleskillEffect.GetInt("invoke_turn");
              flag = (!battleskillEffect.HasKey("gear_kind_id") || battleskillEffect.GetInt("gear_kind_id") == 0 || battleskillEffect.GetInt("gear_kind_id") == attack.originalUnit.unit.kind.ID) && (!battleskillEffect.HasKey("target_gear_kind_id") || battleskillEffect.GetInt("target_gear_kind_id") == 0 || battleskillEffect.GetInt("target_gear_kind_id") == defense.originalUnit.unit.kind.ID) && (!battleskillEffect.HasKey("element") || battleskillEffect.GetInt("element") == 0 || (CommonElement) battleskillEffect.GetInt("element") == attack.originalUnit.playerUnit.GetElement()) && (!battleskillEffect.HasKey("target_element") || battleskillEffect.GetInt("target_element") == 0 || (CommonElement) battleskillEffect.GetInt("target_element") == defense.originalUnit.playerUnit.GetElement()) && (num3 == 0 || num3 == 1 && duelTurn2 != null && isAttacker != duelTurn2.isAtackker || num3 == 2 && duelTurn2 != null && isAttacker == duelTurn2.isAtackker) && (num1 == 0 || num1 == 1 && duelTurn2 != null && ((IEnumerable<BL.Skill>) duelTurn2.invokeDuelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (x =>
              {
                BattleskillGenre? genre1 = x.genre1;
                return genre1.GetValueOrDefault() == BattleskillGenre.attack && genre1.HasValue;
              })) || num1 == 2 && duelTurn2 != null && !((IEnumerable<BL.Skill>) duelTurn2.invokeDuelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (x =>
              {
                BattleskillGenre? genre1 = x.genre1;
                return genre1.GetValueOrDefault() == BattleskillGenre.attack && genre1.HasValue;
              }))) && (num2 == 0 || num2 == 1 && duelTurn2 != null && duelTurn2.isCritical || num2 == 2 && duelTurn2 != null && !duelTurn2.isCritical) && BattleFuncs.isInvoke(attack, defense, attackStatus.duelParameter.attackerUnitParameter, attackStatus.duelParameter.defenderUnitParameter, tuple.Item2, battleskillEffect.GetFloat("percentage_invocation"), random);
              if (flag)
              {
                float num4;
                if ((double) (num4 = battleskillEffect.GetFloat("counter_critical_rate")) != 0.0 && !BattleFuncs.isCriticalGuardEnable(defense, attack))
                  criticalRate = new float?(num4);
                float num5;
                if ((double) (num5 = battleskillEffect.GetFloat("counter_skill_rate")) != 0.0)
                  invokeRate = new float?(num5);
                first.Add(new BL.Skill()
                {
                  id = tuple.Item1.ID
                });
                break;
              }
            }
            if (flag)
              break;
          }
        }
      }
      List<BL.ISkillEffectListUnit> turnInvestUnit = new List<BL.ISkillEffectListUnit>();
      List<int> turninvestSkillIds = new List<int>();
      BL.Skill[] skillArray = (BL.Skill[]) null;
      BattleDuelSkill battleDuelSkill1 = BattleDuelSkill.invokeBiAttackSkills(attack, attackStatus, defense, defenseStatus, distance, !isAttacker ? hp.defenderHp : hp.attackerHp, !isAttacker ? hp.attackerHp : hp.defenderHp, !isAttacker ? hp.defenderIsDontUseSkill : hp.attackerIsDontUseSkill, !isAttacker ? hp.attackerIsDontUseSkill : hp.defenderIsDontUseSkill, random, isAI, isColosseum, isAttacker, invokedAmbush, invokeRate, isOneMoreAttack);
      if (battleDuelSkill1.attackCount > 1)
      {
        List<BL.SuiseiResult> source1 = new List<BL.SuiseiResult>();
        List<BL.Skill> source2 = new List<BL.Skill>();
        List<BL.Skill> source3 = new List<BL.Skill>();
        List<BL.Skill> skillList1 = new List<BL.Skill>();
        List<BL.Skill> skillList2 = new List<BL.Skill>();
        List<BL.Skill> givePassiveSkills = new List<BL.Skill>();
        List<BL.SkillEffect> skillEffectList1 = new List<BL.SkillEffect>();
        List<BL.SkillEffect> skillEffectList2 = new List<BL.SkillEffect>();
        for (int index = 0; index < battleDuelSkill1.attackCount; ++index)
        {
          BattleFuncs.AttackDamageData attackDamageData = BattleFuncs.calcAttackDamage(random, isAttacker, hp, attack, attackStatus, defense, defenseStatus, distance, isAI, isColosseum, battleDuelSkill1, invokedAmbush, invokedPrayer, invokeRate, criticalRate, defenseHp, isOneMoreAttack, true, index);
          if (!invokedPrayer)
          {
            invokedPrayer = ((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.defenderSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (y => y.effect_logic.Enum == BattleskillEffectLogicEnum.prayer))));
            if (!invokedPrayer)
              invokedPrayer = attackDamageData.defenderConsumeSkillEffects.Any<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.effect_logic.Enum == BattleskillEffectLogicEnum.passive_prayer));
          }
          skillEffectList1.AddRange((IEnumerable<BL.SkillEffect>) attackDamageData.attackerConsumeSkillEffects);
          skillEffectList2.AddRange((IEnumerable<BL.SkillEffect>) attackDamageData.defenderConsumeSkillEffects);
          duelTurn1.counterDamage += attackDamageData.counterDamage;
          BL.SuiseiResult suiseiResult = new BL.SuiseiResult();
          suiseiResult.damage = attackDamageData.damage;
          suiseiResult.dispDamage = attackDamageData.dispDamage;
          suiseiResult.invokeDuelSkills = ((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.attackerSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.attackerElementSkills).ToArray<BL.Skill>();
          suiseiResult.invokeDefenderDuelSkills = ((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.defenderSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.defenderElementSkills).ToArray<BL.Skill>();
          suiseiResult.attackerConsumeSkillEffects = attackDamageData.attackerConsumeSkillEffects;
          suiseiResult.defenderConsumeSkillEffects = attackDamageData.defenderConsumeSkillEffects;
          suiseiResult.drainDamage = attackDamageData.drainDamage;
          suiseiResult.dispDrainDamage = attackDamageData.dispDrainDamage;
          suiseiResult.isCritical = attackDamageData.isCritical;
          suiseiResult.isHit = attackDamageData.isHit;
          suiseiResult.defenderDrainDamage = attackDamageData.defenderDrainDamage;
          suiseiResult.defenderDispDrainDamage = attackDamageData.defenderDispDrainDamage;
          source1.Add(suiseiResult);
          source2.AddRange((IEnumerable<BL.Skill>) suiseiResult.invokeDefenderDuelSkills);
          source3.AddRange((IEnumerable<BL.Skill>) suiseiResult.invokeDuelSkills);
          BattleFuncs.assortOneAttackInvest(attack, defense, battleDuelSkill1, attackDamageData.duelSkillProc, turnInvestUnit, turninvestSkillIds, givePassiveSkills, skillList2, skillList1, suiseiResult.isHit, index);
        }
        duelTurn1.suiseiResults = source1;
        duelTurn1.isHit = source1.Any<BL.SuiseiResult>((Func<BL.SuiseiResult, bool>) (x => x.isHit));
        duelTurn1.isCritical = source1.Any<BL.SuiseiResult>((Func<BL.SuiseiResult, bool>) (x => x.isCritical));
        duelTurn1.invokeDuelSkills = first.Concat<BL.Skill>((IEnumerable<BL.Skill>) battleDuelSkill1.attackerSkills).Concat<BL.Skill>(source3.GroupBy<BL.Skill, int>((Func<BL.Skill, int>) (x => x.id)).Select<IGrouping<int, BL.Skill>, BL.Skill>((Func<IGrouping<int, BL.Skill>, BL.Skill>) (x => x.FirstOrDefault<BL.Skill>()))).ToArray<BL.Skill>();
        duelTurn1.invokeDefenderDuelSkills = ((IEnumerable<BL.Skill>) battleDuelSkill1.defenderSkills).Concat<BL.Skill>(source2.GroupBy<BL.Skill, int>((Func<BL.Skill, int>) (x => x.id)).Select<IGrouping<int, BL.Skill>, BL.Skill>((Func<IGrouping<int, BL.Skill>, BL.Skill>) (x => x.FirstOrDefault<BL.Skill>()))).ToArray<BL.Skill>();
        duelTurn1.damage = source1.Sum<BL.SuiseiResult>((Func<BL.SuiseiResult, int>) (x => x.damage));
        duelTurn1.dispDamage = source1.Sum<BL.SuiseiResult>((Func<BL.SuiseiResult, int>) (x => x.dispDamage));
        duelTurn1.drainDamage = source1.Sum<BL.SuiseiResult>((Func<BL.SuiseiResult, int>) (x => x.drainDamage));
        duelTurn1.dispDrainDamage = source1.Sum<BL.SuiseiResult>((Func<BL.SuiseiResult, int>) (x => x.dispDrainDamage));
        duelTurn1.defenderDrainDamage = source1.Sum<BL.SuiseiResult>((Func<BL.SuiseiResult, int>) (x => x.defenderDrainDamage));
        duelTurn1.defenderDispDrainDamage = source1.Sum<BL.SuiseiResult>((Func<BL.SuiseiResult, int>) (x => x.defenderDispDrainDamage));
        duelTurn1.attackerRestHp = hp.attackerHp;
        duelTurn1.defenderRestHp = hp.defenderHp;
        duelTurn1.attackerConsumeSkillEffects = skillEffectList1;
        duelTurn1.defenderConsumeSkillEffects = skillEffectList2;
        if (skillList1.Count > 0)
          duelTurn1.invokeAilmentSkills = skillList1.GroupBy<BL.Skill, int>((Func<BL.Skill, int>) (x => x.id)).Select<IGrouping<int, BL.Skill>, BL.Skill>((Func<IGrouping<int, BL.Skill>, BL.Skill>) (x => x.FirstOrDefault<BL.Skill>())).ToArray<BL.Skill>();
        if (skillList2.Count > 0)
          skillArray = skillList2.GroupBy<BL.Skill, int>((Func<BL.Skill, int>) (x => x.id)).Select<IGrouping<int, BL.Skill>, BL.Skill>((Func<IGrouping<int, BL.Skill>, BL.Skill>) (x => x.FirstOrDefault<BL.Skill>())).ToArray<BL.Skill>();
        if (givePassiveSkills.Count > 0)
          duelTurn1.invokeGiveSkills = givePassiveSkills.ToArray();
      }
      else
      {
        BattleFuncs.AttackDamageData attackDamageData = BattleFuncs.calcAttackDamage(random, isAttacker, hp, attack, attackStatus, defense, defenseStatus, distance, isAI, isColosseum, battleDuelSkill1, invokedAmbush, invokedPrayer, invokeRate, criticalRate, defenseHp, isOneMoreAttack, false);
        duelTurn1.counterDamage += attackDamageData.counterDamage;
        duelTurn1.isHit = attackDamageData.isHit;
        duelTurn1.isCritical = attackDamageData.isCritical;
        duelTurn1.invokeDuelSkills = first.Concat<BL.Skill>((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.attackerSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.attackerElementSkills).ToArray<BL.Skill>();
        duelTurn1.invokeDefenderDuelSkills = ((IEnumerable<BL.Skill>) battleDuelSkill1.defenderSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.defenderSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) attackDamageData.duelSkillProc.defenderElementSkills).ToArray<BL.Skill>();
        duelTurn1.damage = attackDamageData.damage;
        duelTurn1.dispDamage = attackDamageData.dispDamage;
        duelTurn1.drainDamage = attackDamageData.drainDamage;
        duelTurn1.dispDrainDamage = attackDamageData.dispDrainDamage;
        duelTurn1.defenderDrainDamage = attackDamageData.defenderDrainDamage;
        duelTurn1.defenderDispDrainDamage = attackDamageData.defenderDispDrainDamage;
        duelTurn1.attackerRestHp = attackDamageData.hp.attackerHp;
        duelTurn1.defenderRestHp = attackDamageData.hp.defenderHp;
        duelTurn1.attackerConsumeSkillEffects = attackDamageData.attackerConsumeSkillEffects;
        duelTurn1.defenderConsumeSkillEffects = attackDamageData.defenderConsumeSkillEffects;
        List<BL.Skill> givePassiveSkills = new List<BL.Skill>();
        List<BL.Skill> giveAttackerAilmentSkills = new List<BL.Skill>();
        List<BL.Skill> giveDefenderAilmentSkills = new List<BL.Skill>();
        BattleFuncs.assortOneAttackInvest(attack, defense, battleDuelSkill1, attackDamageData.duelSkillProc, turnInvestUnit, turninvestSkillIds, givePassiveSkills, giveAttackerAilmentSkills, giveDefenderAilmentSkills, duelTurn1.isHit, 0);
        if (giveDefenderAilmentSkills.Count > 0)
          duelTurn1.invokeAilmentSkills = giveDefenderAilmentSkills.ToArray();
        if (giveAttackerAilmentSkills.Count > 0)
          skillArray = giveAttackerAilmentSkills.ToArray();
        if (givePassiveSkills.Count > 0)
          duelTurn1.invokeGiveSkills = givePassiveSkills.ToArray();
      }
      if (!isColosseum)
      {
        BattleDuelSkill battleDuelSkill2 = BattleDuelSkill.invokeAilmentSkills(attack, attackStatus, defense, duelTurn1.isHit, !isAttacker ? hp.defenderIsDontUseSkill : hp.attackerIsDontUseSkill, random, isAI, isColosseum);
        List<BL.Skill> source4 = new List<BL.Skill>();
        if (duelTurn1.isHit)
        {
          BL.Skill[] investSkills = battleDuelSkill2.getInvestSkills(defense, true, false, 0);
          if (investSkills != null)
            source4.AddRange((IEnumerable<BL.Skill>) investSkills);
        }
        BL.Skill[] investSkills1 = battleDuelSkill2.getInvestSkills(defense, true, true, 0);
        if (investSkills1 != null)
          source4.AddRange((IEnumerable<BL.Skill>) investSkills1);
        if (source4.Any<BL.Skill>())
          duelTurn1.invokeAilmentSkills = duelTurn1.invokeAilmentSkills == null ? source4.ToArray() : ((IEnumerable<BL.Skill>) duelTurn1.invokeAilmentSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) source4.ToArray()).ToArray<BL.Skill>();
        List<BL.Skill> source5 = new List<BL.Skill>();
        if (duelTurn1.isHit)
        {
          BL.Skill[] investSkills2 = battleDuelSkill2.getInvestSkills(attack, true, false, 0);
          if (investSkills2 != null)
            source5.AddRange((IEnumerable<BL.Skill>) investSkills2);
        }
        BL.Skill[] investSkills3 = battleDuelSkill2.getInvestSkills(attack, true, true, 0);
        if (investSkills3 != null)
          source5.AddRange((IEnumerable<BL.Skill>) investSkills3);
        if (source5.Any<BL.Skill>())
          skillArray = skillArray == null ? source5.ToArray() : ((IEnumerable<BL.Skill>) skillArray).Concat<BL.Skill>((IEnumerable<BL.Skill>) source5.ToArray()).ToArray<BL.Skill>();
        if (duelTurn1.isHit)
        {
          Tuple<BL.ISkillEffectListUnit[], int[]> allInvestList = battleDuelSkill2.getAllInvestList(true, false, 0);
          if (allInvestList != null)
          {
            turnInvestUnit.AddRange((IEnumerable<BL.ISkillEffectListUnit>) allInvestList.Item1);
            turninvestSkillIds.AddRange((IEnumerable<int>) allInvestList.Item2);
          }
        }
        Tuple<BL.ISkillEffectListUnit[], int[]> allInvestList1 = battleDuelSkill2.getAllInvestList(true, true, 0);
        if (allInvestList1 != null)
        {
          turnInvestUnit.AddRange((IEnumerable<BL.ISkillEffectListUnit>) allInvestList1.Item1);
          turninvestSkillIds.AddRange((IEnumerable<int>) allInvestList1.Item2);
        }
        duelTurn1.invokeDuelSkills = ((IEnumerable<BL.Skill>) duelTurn1.invokeDuelSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) battleDuelSkill2.attackerSkills).ToArray<BL.Skill>();
        if (duelTurn1.invokeAilmentSkills != null)
        {
          if (duelTurn1.dispDamage >= 1)
            battleskillSkills = battleskillSkills.Where<BattleskillSkill>((Func<BattleskillSkill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (y => y.effect_logic.Enum != BattleskillEffectLogicEnum.sleep))));
          IEnumerable<BattleskillSkill> source6 = ((IEnumerable<BL.Skill>) duelTurn1.invokeAilmentSkills).Select<BL.Skill, BattleskillSkill>((Func<BL.Skill, BattleskillSkill>) (x => x.skill)).Except<BattleskillSkill>(battleskillSkills);
          duelTurn1.ailmentEffects = source6.Select<BattleskillSkill, BattleskillAilmentEffect>((Func<BattleskillSkill, BattleskillAilmentEffect>) (x => x.ailment_effect)).ToArray<BattleskillAilmentEffect>();
          if (isAttacker)
          {
            hp.defenderIsDontAction |= BL.Skill.HasDontActionEffect(duelTurn1.invokeAilmentSkills);
            hp.defenderIsDontEvasion |= BL.Skill.HasDontEvasionEffect(duelTurn1.invokeAilmentSkills);
            hp.defenderIsDontUseSkill |= BL.Skill.HasDontActionEffect(duelTurn1.invokeAilmentSkills);
          }
          else
          {
            hp.attackerIsDontAction |= BL.Skill.HasDontActionEffect(duelTurn1.invokeAilmentSkills);
            hp.attackerIsDontEvasion |= BL.Skill.HasDontEvasionEffect(duelTurn1.invokeAilmentSkills);
            hp.attackerIsDontUseSkill |= BL.Skill.HasDontActionEffect(duelTurn1.invokeAilmentSkills);
          }
        }
        if (skillArray != null)
        {
          IEnumerable<BattleskillSkill> source7 = ((IEnumerable<BL.Skill>) skillArray).Select<BL.Skill, BattleskillSkill>((Func<BL.Skill, BattleskillSkill>) (x => x.skill)).Except<BattleskillSkill>(second);
          duelTurn1.attackerAilmentEffects = source7.Select<BattleskillSkill, BattleskillAilmentEffect>((Func<BattleskillSkill, BattleskillAilmentEffect>) (x => x.ailment_effect)).ToArray<BattleskillAilmentEffect>();
          if (!isAttacker)
          {
            hp.defenderIsDontAction |= BL.Skill.HasDontActionEffect(skillArray);
            hp.defenderIsDontEvasion |= BL.Skill.HasDontEvasionEffect(skillArray);
            hp.defenderIsDontUseSkill |= BL.Skill.HasDontActionEffect(skillArray);
          }
          else
          {
            hp.attackerIsDontAction |= BL.Skill.HasDontActionEffect(skillArray);
            hp.attackerIsDontEvasion |= BL.Skill.HasDontEvasionEffect(skillArray);
            hp.attackerIsDontUseSkill |= BL.Skill.HasDontActionEffect(skillArray);
          }
        }
      }
      duelTurn1.investUnit = turnInvestUnit.ToArray();
      duelTurn1.investSkillIds = turninvestSkillIds.ToArray();
      // ISSUE: object of a compiler-generated type is created
      foreach (\u003C\u003E__AnonType0<BL.ISkillEffectListUnit, int> anonType0 in ((IEnumerable<BL.ISkillEffectListUnit>) duelTurn1.investUnit).Select<BL.ISkillEffectListUnit, \u003C\u003E__AnonType0<BL.ISkillEffectListUnit, int>>((Func<BL.ISkillEffectListUnit, int, \u003C\u003E__AnonType0<BL.ISkillEffectListUnit, int>>) ((unit, index) => new \u003C\u003E__AnonType0<BL.ISkillEffectListUnit, int>(unit, index))))
      {
        BattleskillEffectLogicEnum[] source = new BattleskillEffectLogicEnum[1]
        {
          BattleskillEffectLogicEnum.white_night
        };
        if (anonType0.unit == attack || anonType0.unit == defense)
        {
          BL.Skill skill = new BL.Skill()
          {
            id = duelTurn1.investSkillIds[anonType0.index]
          };
          if (skill.skill.target_type == BattleskillTargetType.complex_single || skill.skill.target_type == BattleskillTargetType.complex_range)
          {
            foreach (BattleskillEffect effect in skill.skill.Effects)
            {
              if (((IEnumerable<BattleskillEffectLogicEnum>) source).Contains<BattleskillEffectLogicEnum>(effect.effect_logic.Enum))
              {
                if (!effect.is_targer_enemy)
                {
                  if (anonType0.unit == attack)
                    anonType0.unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
                }
                else if (anonType0.unit == defense)
                  anonType0.unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
              }
            }
          }
          else
          {
            foreach (BattleskillEffect effect in skill.skill.Effects)
            {
              if (((IEnumerable<BattleskillEffectLogicEnum>) source).Contains<BattleskillEffectLogicEnum>(effect.effect_logic.Enum))
                anonType0.unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
            }
          }
        }
      }
      turns.Add(duelTurn1);
    }

    public static int attackCount(BL.ISkillEffectListUnit attack, BL.ISkillEffectListUnit defense)
    {
      if (BattleFuncs.isSkillsAndEffectsInvalid(attack, defense))
        return 1;
      int num = attack.skillEffects.Where(BattleskillEffectLogicEnum.multiple_attack, (Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect = x.effect;
        if (effect.HasKey("gear_kind_id") && effect.GetInt("gear_kind_id") != 0 && effect.GetInt("gear_kind_id") != attack.originalUnit.unit.kind.ID || effect.HasKey("target_gear_kind_id") && effect.GetInt("target_gear_kind_id") != 0 && effect.GetInt("target_gear_kind_id") != defense.originalUnit.unit.kind.ID || effect.HasKey("element") && effect.GetInt("element") != 0 && (CommonElement) effect.GetInt("element") != attack.originalUnit.playerUnit.GetElement() || effect.HasKey("target_element") && effect.GetInt("target_element") != 0 && (CommonElement) effect.GetInt("target_element") != defense.originalUnit.playerUnit.GetElement() || effect.HasKey("job_id") && effect.GetInt("job_id") != 0 && effect.GetInt("job_id") != attack.originalUnit.job.ID || effect.HasKey("target_job_id") && effect.GetInt("target_job_id") != 0 && effect.GetInt("target_job_id") != defense.originalUnit.job.ID || effect.HasKey("family_id") && effect.GetInt("family_id") != 0 && !attack.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id")))
          return false;
        return !effect.HasKey("target_family_id") || effect.GetInt("target_family_id") == 0 || defense.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"));
      })).Sum<BL.SkillEffect>((Func<BL.SkillEffect, int>) (x => x.effect.GetInt("value")));
      return num > 0 ? num : 1;
    }

    public static bool canOneMore(
      Judgement.BeforeDuelUnitParameter attack,
      Judgement.BeforeDuelUnitParameter defense,
      BL.ISkillEffectListUnit myself,
      BL.ISkillEffectListUnit enemy)
    {
      Func<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, bool> func = (Func<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, bool>) ((effectUnit, targetUnit, effect_target, unit, target) => effectUnit.skillEffects.Where(BattleskillEffectLogicEnum.defensive_formation, (Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect = x.effect;
        return (double) effect.GetFloat(nameof (effect_target)) == (double) effect_target && !BattleFuncs.isSealedSkillEffect(effectUnit, x) && (effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == effectUnit.originalUnit.unit.kind.ID) && (effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == targetUnit.originalUnit.unit.kind.ID) && (effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == effectUnit.originalUnit.playerUnit.GetElement()) && (effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == targetUnit.originalUnit.playerUnit.GetElement()) && (effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == effectUnit.originalUnit.job.ID) && (effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == targetUnit.originalUnit.job.ID) && (effect.GetInt("family_id") == 0 || effectUnit.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id"))) && (effect.GetInt("target_family_id") == 0 || targetUnit.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && (effectUnit != target || !BattleFuncs.isSkillsAndEffectsInvalid(target, unit)) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target);
      })).Any<BL.SkillEffect>());
      return attack.AttackSpeed - defense.AttackSpeed >= 5 && !func(myself, enemy, 0, myself, enemy) && !func(enemy, myself, 1, myself, enemy);
    }

    public static int calcPercentageDamage(int preHp, float percentageDamageRate)
    {
      int num = Mathf.CeilToInt((float) preHp * percentageDamageRate);
      if (preHp <= 1)
        num = preHp;
      else if (preHp - num < 1)
        num = preHp - 1;
      return num;
    }

    public static bool isInvokedDefenderSkillLogic(
      IEnumerable<BL.DuelTurn> turns,
      BattleskillEffectLogicEnum skillLogic,
      bool? isAttacker = null)
    {
      return turns.Any<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => (!isAttacker.HasValue || (x.isAtackker != isAttacker.GetValueOrDefault() ? 0 : (isAttacker.HasValue ? 1 : 0)) != 0) && ((IEnumerable<BL.Skill>) x.invokeDefenderDuelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (y => ((IEnumerable<BattleskillEffect>) y.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (z => z.effect_logic.Enum == skillLogic))))));
    }

    public static bool isInvokedDefenderConsumeSkillLogic(
      IEnumerable<BL.DuelTurn> turns,
      BattleskillEffectLogicEnum skillLogic,
      bool? isAttacker = null)
    {
      return turns.Any<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => (!isAttacker.HasValue || (x.isAtackker != isAttacker.GetValueOrDefault() ? 0 : (isAttacker.HasValue ? 1 : 0)) != 0) && x.defenderConsumeSkillEffects.Any<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (y => y.effect.effect_logic.Enum == skillLogic))));
    }

    public static Tuple<float?, float?> getClampHitEffect(
      BL.ISkillEffectListUnit beAttackUnit,
      BL.ISkillEffectListUnit beDefenseUnit)
    {
      float? min = new float?();
      float? max = new float?();
      Action<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int> action = (Action<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int>) ((effectUnit, targetUnit, effect_target) =>
      {
        if (BattleFuncs.isSkillsAndEffectsInvalid(effectUnit, targetUnit))
          return;
        foreach (BL.SkillEffect skillEffect in effectUnit.enabledSkillEffect(BattleskillEffectLogicEnum.clamp_hit).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x =>
        {
          BattleskillEffect effect = x.effect;
          if ((effect.HasKey(nameof (effect_target)) || effect_target != 0) && (!effect.HasKey(nameof (effect_target)) || (double) effect.GetFloat(nameof (effect_target)) != (double) effect_target) || effect.HasKey("gear_kind_id") && effect.GetInt("gear_kind_id") != 0 && effect.GetInt("gear_kind_id") != effectUnit.originalUnit.unit.kind.ID || effect.HasKey("target_gear_kind_id") && effect.GetInt("target_gear_kind_id") != 0 && effect.GetInt("target_gear_kind_id") != targetUnit.originalUnit.unit.kind.ID || effect.HasKey("element") && effect.GetInt("element") != 0 && (CommonElement) effect.GetInt("element") != effectUnit.originalUnit.playerUnit.GetElement() || effect.HasKey("target_element") && effect.GetInt("target_element") != 0 && (CommonElement) effect.GetInt("target_element") != targetUnit.originalUnit.playerUnit.GetElement() || effect.HasKey("job_id") && effect.GetInt("job_id") != 0 && effect.GetInt("job_id") != effectUnit.originalUnit.job.ID)
            return false;
          return !effect.HasKey("target_job_id") || effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == targetUnit.originalUnit.job.ID;
        })))
        {
          float num1 = (float) ((Decimal) skillEffect.effect.GetFloat("min_percentage") + (Decimal) skillEffect.baseSkillLevel * (Decimal) skillEffect.effect.GetFloat("min_skill_ratio"));
          if (!min.HasValue || (!min.HasValue ? 0 : ((double) num1 > (double) min.Value ? 1 : 0)) != 0)
            min = new float?(num1);
          float num2 = (float) ((Decimal) skillEffect.effect.GetFloat("max_percentage") + (Decimal) skillEffect.baseSkillLevel * (Decimal) skillEffect.effect.GetFloat("max_skill_ratio"));
          if (!max.HasValue || (!max.HasValue ? 0 : ((double) num2 < (double) max.Value ? 1 : 0)) != 0)
            max = new float?(num2);
        }
      });
      action(beAttackUnit, beDefenseUnit, 0);
      action(beDefenseUnit, beAttackUnit, 1);
      return new Tuple<float?, float?>(min, max);
    }

    private static void assortOneAttackInvest(
      BL.ISkillEffectListUnit attack,
      BL.ISkillEffectListUnit defense,
      BattleDuelSkill biAttackSkills,
      BattleDuelSkill duelSkillProc,
      List<BL.ISkillEffectListUnit> turnInvestUnit,
      List<int> turninvestSkillIds,
      List<BL.Skill> givePassiveSkills,
      List<BL.Skill> giveAttackerAilmentSkills,
      List<BL.Skill> giveDefenderAilmentSkills,
      bool isHit,
      int attackNo)
    {
      Action<bool> action = (Action<bool>) (isUnconditional =>
      {
        BL.Skill[] investSkills1 = biAttackSkills.getInvestSkills(attack, true, isUnconditional, attackNo);
        if (investSkills1 != null)
          giveAttackerAilmentSkills.AddRange((IEnumerable<BL.Skill>) investSkills1);
        BL.Skill[] investSkills2 = duelSkillProc.getInvestSkills(attack, true, isUnconditional, 0);
        if (investSkills2 != null)
          giveAttackerAilmentSkills.AddRange((IEnumerable<BL.Skill>) investSkills2);
        BL.Skill[] investSkills3 = biAttackSkills.getInvestSkills(defense, true, isUnconditional, attackNo);
        if (investSkills3 != null)
          giveDefenderAilmentSkills.AddRange((IEnumerable<BL.Skill>) investSkills3);
        BL.Skill[] investSkills4 = duelSkillProc.getInvestSkills(defense, true, isUnconditional, 0);
        if (investSkills4 != null)
          giveDefenderAilmentSkills.AddRange((IEnumerable<BL.Skill>) investSkills4);
        BL.Skill[] investSkills5 = biAttackSkills.getInvestSkills(attack, false, isUnconditional, attackNo);
        if (investSkills5 != null)
          givePassiveSkills.AddRange((IEnumerable<BL.Skill>) investSkills5);
        BL.Skill[] investSkills6 = duelSkillProc.getInvestSkills(attack, false, isUnconditional, 0);
        if (investSkills6 != null)
          givePassiveSkills.AddRange((IEnumerable<BL.Skill>) investSkills6);
        BL.Skill[] investSkills7 = biAttackSkills.getInvestSkills(defense, false, isUnconditional, attackNo);
        if (investSkills7 != null)
          givePassiveSkills.AddRange((IEnumerable<BL.Skill>) investSkills7);
        BL.Skill[] investSkills8 = duelSkillProc.getInvestSkills(defense, false, isUnconditional, 0);
        if (investSkills8 != null)
          givePassiveSkills.AddRange((IEnumerable<BL.Skill>) investSkills8);
        Tuple<BL.ISkillEffectListUnit[], int[]> allInvestList1 = biAttackSkills.getAllInvestList(true, isUnconditional, attackNo);
        if (allInvestList1 != null)
        {
          turnInvestUnit.AddRange((IEnumerable<BL.ISkillEffectListUnit>) allInvestList1.Item1);
          turninvestSkillIds.AddRange((IEnumerable<int>) allInvestList1.Item2);
        }
        Tuple<BL.ISkillEffectListUnit[], int[]> allInvestList2 = duelSkillProc.getAllInvestList(true, isUnconditional, 0);
        if (allInvestList2 != null)
        {
          turnInvestUnit.AddRange((IEnumerable<BL.ISkillEffectListUnit>) allInvestList2.Item1);
          turninvestSkillIds.AddRange((IEnumerable<int>) allInvestList2.Item2);
        }
        Tuple<BL.ISkillEffectListUnit[], int[]> allInvestList3 = biAttackSkills.getAllInvestList(false, isUnconditional, attackNo);
        if (allInvestList3 != null)
        {
          turnInvestUnit.AddRange((IEnumerable<BL.ISkillEffectListUnit>) allInvestList3.Item1);
          turninvestSkillIds.AddRange((IEnumerable<int>) allInvestList3.Item2);
        }
        Tuple<BL.ISkillEffectListUnit[], int[]> allInvestList4 = duelSkillProc.getAllInvestList(false, isUnconditional, 0);
        if (allInvestList4 == null)
          return;
        turnInvestUnit.AddRange((IEnumerable<BL.ISkillEffectListUnit>) allInvestList4.Item1);
        turninvestSkillIds.AddRange((IEnumerable<int>) allInvestList4.Item2);
      });
      if (isHit)
        action(false);
      action(true);
    }

    private static BL env => BattleFuncs.environment.Get();

    public static BL.ForceID getForceID(BL.Unit unit) => BattleFuncs.env.getForceID(unit);

    public static BL.ForceID[] getForceIDArray(BL.ForceID id)
    {
      switch (id)
      {
        case BL.ForceID.player:
          return BattleFuncs.ForceIDArrayPlayer;
        case BL.ForceID.neutral:
          return BattleFuncs.ForceIDArrayNeutral;
        case BL.ForceID.enemy:
          return BattleFuncs.ForceIDArrayEnemy;
        default:
          return BattleFuncs.ForceIDArrayNone;
      }
    }

    public static BL.ForceID[] getForceIDArray(BL.Unit unit, BL _env)
    {
      return BattleFuncs.getForceIDArray(_env.getForceID(unit));
    }

    public static void setAttributePanels(
      IEnumerable<BL.Panel> panels,
      BL.PanelAttribute attribute,
      bool unset)
    {
      if (panels == null)
        return;
      foreach (BL.Panel panel in panels)
      {
        if (unset)
          panel.unsetAttribute(attribute);
        else
          panel.setAttribute(attribute);
      }
    }

    private static BL.Panel panelAdd(
      BL.Panel panel,
      int movement,
      HashSet<BL.Panel> pwl,
      HashSet<BL.Panel> limit)
    {
      if (limit != null && !limit.Contains(panel))
        return panel;
      panel.workMovement = movement;
      if (!pwl.Contains(panel))
        pwl.Add(panel);
      return panel;
    }

    private static bool checkMoveOK(
      int row,
      int column,
      int movement,
      BL.Unit unit,
      HashSet<BL.Panel> pwl,
      HashSet<BL.Panel> limit,
      bool isAI,
      bool isRebirth,
      bool enabledIgnoreMveCost)
    {
      BL.Panel fieldPanel = BattleFuncs.env.getFieldPanel(row, column);
      if (fieldPanel == null || limit != null && !limit.Contains(fieldPanel))
        return false;
      if (pwl.Contains(fieldPanel))
        return movement > fieldPanel.workMovement;
      return (!isAI ? (BattleFuncs.env.isMoveOK(fieldPanel, unit, isRebirth, enabledIgnoreMveCost, movement) ? 1 : 0) : (BattleFuncs.env.isMoveOKAI(fieldPanel, unit, isRebirth, enabledIgnoreMveCost, movement) ? 1 : 0)) != 0;
    }

    private static void createMovePanelsFour(
      int row,
      int column,
      int movement,
      BL.Unit unit,
      HashSet<BL.Panel> pwl,
      HashSet<BL.Panel> limit,
      Queue<Tuple<int, int, int>> queue,
      bool isAI,
      bool isRebirth,
      bool enabledIgnoreMoveCost)
    {
      if (movement < 1)
        return;
      if (BattleFuncs.checkMoveOK(row - 1, column, movement, unit, pwl, limit, isAI, isRebirth, enabledIgnoreMoveCost))
        BattleFuncs.createMovePanelsSub(row - 1, column, movement, unit, pwl, limit, queue, enabledIgnoreMoveCost, isAI);
      if (BattleFuncs.checkMoveOK(row + 1, column, movement, unit, pwl, limit, isAI, isRebirth, enabledIgnoreMoveCost))
        BattleFuncs.createMovePanelsSub(row + 1, column, movement, unit, pwl, limit, queue, enabledIgnoreMoveCost, isAI);
      if (BattleFuncs.checkMoveOK(row, column - 1, movement, unit, pwl, limit, isAI, isRebirth, enabledIgnoreMoveCost))
        BattleFuncs.createMovePanelsSub(row, column - 1, movement, unit, pwl, limit, queue, enabledIgnoreMoveCost, isAI);
      if (!BattleFuncs.checkMoveOK(row, column + 1, movement, unit, pwl, limit, isAI, isRebirth, enabledIgnoreMoveCost))
        return;
      BattleFuncs.createMovePanelsSub(row, column + 1, movement, unit, pwl, limit, queue, enabledIgnoreMoveCost, isAI);
    }

    private static void createMovePanelsSub(
      int row,
      int column,
      int movement,
      BL.Unit unit,
      HashSet<BL.Panel> pwl,
      HashSet<BL.Panel> limit,
      Queue<Tuple<int, int, int>> queue,
      bool enabledIgnoreMoveCost,
      bool isAI)
    {
      BL.Panel fieldPanel = BattleFuncs.env.getFieldPanel(row, column);
      BattleFuncs.panelAdd(fieldPanel, movement, pwl, limit);
      if (fieldPanel.zocCheckp(unit, isAI, BattleFuncs.env))
        return;
      queue.Enqueue(Tuple.Create<int, int, int>(row, column, movement - BattleFuncs.getMoveCost(fieldPanel, unit, enabledIgnoreMoveCost)));
    }

    public static HashSet<BL.Panel> createMovePanels(
      int row,
      int column,
      int movement,
      BL.Unit unit,
      HashSet<BL.Panel> limit = null,
      bool isAI = false,
      bool isRebirth = false)
    {
      if (!isRebirth && unit.HasEnabledSkillEffect(BattleskillEffectLogicEnum.slip_thru))
        isRebirth = true;
      HashSet<BL.Panel> pwl = new HashSet<BL.Panel>();
      Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
      bool enabledIgnoreMoveCost = unit.HasEnabledSkillEffect(BattleskillEffectLogicEnum.ignore_move_cost);
      using (BL.Unit unit1 = unit.enableCache())
      {
        BattleFuncs.panelAdd(BattleFuncs.env.getFieldPanel(row, column), movement, pwl, limit);
        BattleFuncs.createMovePanelsFour(row, column, movement, unit1, pwl, limit, queue, isAI, isRebirth, enabledIgnoreMoveCost);
        while (queue.Count != 0)
        {
          Tuple<int, int, int> tuple = queue.Dequeue();
          BattleFuncs.createMovePanelsFour(tuple.Item1, tuple.Item2, tuple.Item3, unit1, pwl, limit, queue, isAI, isRebirth, enabledIgnoreMoveCost);
        }
      }
      return pwl;
    }

    public static HashSet<BL.Panel> createMovePanels(BL.UnitPosition up)
    {
      return BattleFuncs.createMovePanels(up.originalRow, up.originalColumn, up.moveCost, up.unit);
    }

    public static BL.Panel getPanel(BL.UnitPosition up)
    {
      return BattleFuncs.env.getFieldPanel(up.originalRow, up.originalColumn);
    }

    public static BL.Panel getPanel(int row, int column)
    {
      return BattleFuncs.env.getFieldPanel(row, column);
    }

    private static void addEdge(
      int row,
      int column,
      IEnumerable<BL.Panel> panels,
      List<BattleFuncs.AsterEdge> edges,
      BL.Unit unit,
      int cost)
    {
      int to = 0;
      foreach (BL.Panel panel in panels)
      {
        if (row == panel.row && column == panel.column)
          edges.Add(new BattleFuncs.AsterEdge(to, cost));
        ++to;
      }
    }

    private static BattleFuncs.AsterEdge[] createEdges(
      BL.Panel panel,
      IEnumerable<BL.Panel> panels,
      BL.Unit unit,
      int moveCache,
      bool enabledIgnoreMoveCost)
    {
      List<BattleFuncs.AsterEdge> edges = new List<BattleFuncs.AsterEdge>();
      int moveCost = BattleFuncs.getMoveCost(panel, unit, enabledIgnoreMoveCost);
      int cost = moveCost <= moveCache ? moveCost : 10000;
      BattleFuncs.addEdge(panel.row - 1, panel.column, panels, edges, unit, cost);
      BattleFuncs.addEdge(panel.row + 1, panel.column, panels, edges, unit, cost);
      BattleFuncs.addEdge(panel.row, panel.column - 1, panels, edges, unit, cost);
      BattleFuncs.addEdge(panel.row, panel.column + 1, panels, edges, unit, cost);
      return edges.ToArray();
    }

    public static BattleFuncs.AsterNode[] createNodes(
      IEnumerable<BL.Panel> panels,
      BL.Unit unit,
      BL.Panel start,
      BL.Panel goal,
      out int startIdx,
      out int goalIdx,
      bool enabledIgnoreMoveCost)
    {
      List<BattleFuncs.AsterNode> asterNodeList = new List<BattleFuncs.AsterNode>();
      int no = 0;
      startIdx = goalIdx = -1;
      int moveCost = BattleFuncs.env.getUnitPosition(unit).moveCost;
      foreach (BL.Panel panel in panels)
      {
        asterNodeList.Add(new BattleFuncs.AsterNode(no, panel, BattleFuncs.createEdges(panel, panels, unit, moveCost, enabledIgnoreMoveCost)));
        if (panel == start)
          startIdx = no;
        if (panel == goal)
          goalIdx = no;
        ++no;
      }
      return asterNodeList.ToArray();
    }

    private static void aster(BattleFuncs.AsterNode[] nodes, int goal, int start)
    {
      BattleFuncs.AsterNode node1 = nodes[goal];
      BattleFuncs.AsterNode node2 = nodes[start];
      HashSet<BattleFuncs.AsterNode> asterNodeSet1 = new HashSet<BattleFuncs.AsterNode>();
      HashSet<BattleFuncs.AsterNode> asterNodeSet2 = new HashSet<BattleFuncs.AsterNode>();
      asterNodeSet1.Add(node2);
      node2.cost = BattleFuncs.heuristic(node1, node2);
      while (asterNodeSet1.Count != 0)
      {
        BattleFuncs.AsterNode n = (BattleFuncs.AsterNode) null;
        int num1 = 1000000000;
        foreach (BattleFuncs.AsterNode asterNode in asterNodeSet1)
        {
          if (asterNode.cost < num1)
          {
            n = asterNode;
            num1 = n.cost;
          }
        }
        if (n == node1)
          break;
        asterNodeSet2.Add(n);
        asterNodeSet1.Remove(n);
        for (int index = 0; index < n.edges.Length; ++index)
        {
          BattleFuncs.AsterNode node3 = nodes[n.edges[index].to];
          int num2 = n.cost - BattleFuncs.heuristic(node1, n) + BattleFuncs.heuristic(node1, node3) + n.edges[index].cost;
          if (asterNodeSet1.Contains(node3))
          {
            if (num2 < node3.cost)
            {
              node3.cost = num2;
              node3.from = n.no;
            }
          }
          else if (asterNodeSet2.Contains(node3))
          {
            if (num2 < node3.cost)
            {
              node3.cost = num2;
              node3.from = n.no;
              asterNodeSet1.Add(node3);
              asterNodeSet2.Remove(node3);
            }
          }
          else
          {
            node3.cost = num2;
            node3.from = n.no;
            asterNodeSet1.Add(node3);
          }
        }
      }
    }

    private static int heuristic(BattleFuncs.AsterNode goal, BattleFuncs.AsterNode n)
    {
      int row1 = goal.panel.row;
      int column1 = goal.panel.column;
      int row2 = n.panel.row;
      int column2 = n.panel.column;
      return (row1 <= row2 ? row2 - row1 : row1 - row2) + (column1 <= column2 ? column2 - column1 : column1 - column2);
    }

    public static void getNodesStartAndGoal(
      BattleFuncs.AsterNode[] nodes,
      BL.Panel start,
      BL.Panel goal,
      out int startIdx,
      out int goalIdx)
    {
      startIdx = goalIdx = -1;
      for (int index = 0; index < nodes.Length; ++index)
      {
        if (nodes[index].panel == goal)
          goalIdx = index;
        if (nodes[index].panel == start)
          startIdx = index;
        if (startIdx != -1 && goalIdx != -1)
          break;
      }
    }

    public static List<BL.Panel> createRouteWithCost(
      BL.Unit unit,
      BattleFuncs.AsterNode[] nodes,
      int startIdx,
      int goalIdx,
      out int cost,
      bool enabledIgnoreMoveCost)
    {
      cost = 0;
      if (startIdx == -1 || goalIdx == -1)
        return new List<BL.Panel>();
      BattleFuncs.aster(nodes, goalIdx, startIdx);
      List<BL.Panel> routeWithCost = new List<BL.Panel>();
      BattleFuncs.AsterNode node;
      for (int index = goalIdx; index != startIdx; index = node.from)
      {
        node = nodes[index];
        cost += BattleFuncs.getMoveCost(node.panel, unit, enabledIgnoreMoveCost);
        routeWithCost.Add(node.panel);
      }
      routeWithCost.Add(nodes[startIdx].panel);
      return routeWithCost;
    }

    public static List<BL.UnitPosition> getTargets(
      int r,
      int c,
      int[] range,
      BL.ForceID[] forceIds,
      bool isAI = false,
      bool originalTarget = false,
      bool isDead = false)
    {
      List<BL.UnitPosition> targets = new List<BL.UnitPosition>();
      foreach (BL.Panel rangePanel in BattleFuncs.getRangePanels(r, c, range))
      {
        if (isDead && !isAI)
        {
          BL.UnitPosition[] fieldUnits = BattleFuncs.env.getFieldUnits(rangePanel, originalTarget, true);
          if (fieldUnits != null)
          {
            foreach (BL.UnitPosition unitPosition in fieldUnits)
            {
              if (((IEnumerable<BL.ForceID>) forceIds).Contains<BL.ForceID>(BattleFuncs.env.getForceID(unitPosition.unit)))
                targets.Add(unitPosition);
            }
          }
        }
        else
        {
          BL.UnitPosition unitPosition = !isAI ? BattleFuncs.env.getFieldUnit(rangePanel, originalTarget) : BattleFuncs.env.getFieldUnitAI(rangePanel);
          if (unitPosition != null && ((IEnumerable<BL.ForceID>) forceIds).Contains<BL.ForceID>(BattleFuncs.env.getForceID(unitPosition.unit)))
            targets.Add(unitPosition);
        }
      }
      return targets;
    }

    public static Tuple<int, int> getUnitCell(BL.Unit unit, bool isAI = false, bool isOriginal = false)
    {
      int num1;
      int num2;
      if (isAI)
      {
        BL.AIUnit aiUnit = BattleFuncs.env.getAIUnit(unit);
        if (isOriginal)
        {
          num1 = aiUnit.unitPosition.originalRow;
          num2 = aiUnit.unitPosition.originalColumn;
        }
        else
        {
          num1 = aiUnit.row;
          num2 = aiUnit.column;
        }
      }
      else
      {
        BL.UnitPosition unitPosition = BattleFuncs.env.getUnitPosition(unit);
        if (isOriginal)
        {
          num1 = unitPosition.originalRow;
          num2 = unitPosition.originalColumn;
        }
        else
        {
          num1 = unitPosition.row;
          num2 = unitPosition.column;
        }
      }
      return new Tuple<int, int>(num1, num2);
    }

    public static List<BL.UnitPosition> getTargets(
      BL.Unit unit,
      int[] range,
      BL.ForceID[] forceIds,
      bool isAI = false,
      bool isMineOriginal = false,
      bool isTargetsOriginal = false)
    {
      Tuple<int, int> unitCell = BattleFuncs.getUnitCell(unit, isAI, isMineOriginal);
      return BattleFuncs.getTargets(unitCell.Item1, unitCell.Item2, range, forceIds, isAI);
    }

    public static List<BL.UnitPosition> getAttackTargets(
      BL.UnitPosition up,
      bool isOriginal = false,
      bool isAI = false)
    {
      return up == null || up.unit == null ? new List<BL.UnitPosition>() : BattleFuncs.getTargets(!isOriginal ? up.row : up.originalRow, !isOriginal ? up.column : up.originalColumn, up.unit.attackRange, BattleFuncs.env.getTargetForce(up.unit), isAI);
    }

    public static List<BL.UnitPosition> getHealTargets(
      BL.UnitPosition up,
      bool isOriginal = false,
      bool isAI = false)
    {
      return up == null || up.unit == null ? new List<BL.UnitPosition>() : BattleFuncs.getTargets(!isOriginal ? up.row : up.originalRow, !isOriginal ? up.column : up.originalColumn, up.unit.healRange, BattleFuncs.getForceIDArray(up.unit, BattleFuncs.env), isAI).Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => !isAI || x.unit.hp < x.unit.parameter.Hp)).ToList<BL.UnitPosition>();
    }

    public static HashSet<BL.Panel> getTargetPanels(
      int row,
      int column,
      int[] range,
      BL.ForceID[] forceIds,
      bool isAI = false,
      BL.UnitPosition myUP = null)
    {
      bool originalTarget = myUP != null;
      List<BL.UnitPosition> targets = BattleFuncs.getTargets(row, column, range, forceIds, isAI, originalTarget);
      HashSet<BL.Panel> targetPanels = new HashSet<BL.Panel>();
      foreach (BL.UnitPosition unitPosition in targets)
      {
        if (originalTarget)
        {
          if (unitPosition != myUP)
            targetPanels.Add(BattleFuncs.env.getFieldPanel(unitPosition.originalRow, unitPosition.originalColumn));
        }
        else
          targetPanels.Add(BattleFuncs.env.getFieldPanel(unitPosition.row, unitPosition.column));
      }
      return targetPanels;
    }

    public static HashSet<BL.Panel> getAttackTargetPanels(
      BL.UnitPosition up,
      bool isOriginal = false,
      bool isAI = false)
    {
      if (up.unit == null)
        return new HashSet<BL.Panel>();
      if (up.unit.IsDontAction)
        return new HashSet<BL.Panel>();
      int row = !isOriginal ? up.row : up.originalRow;
      int column = !isOriginal ? up.column : up.originalColumn;
      Tuple<int, int> effectsAddRange = BattleFuncs.env.getFieldPanel(row, column).getEffectsAddRange(up.unit.unit.kind.ID, up.unit.unit.job.move_type);
      int[] range = new int[2]
      {
        up.unit.attackRange[0] + effectsAddRange.Item1,
        up.unit.attackRange[1] + effectsAddRange.Item2
      };
      return BattleFuncs.getTargetPanels(row, column, range, BattleFuncs.env.getTargetForce(up.unit), isAI);
    }

    public static HashSet<BL.Panel> getHealTargetPanels(
      BL.UnitPosition up,
      bool isOriginal = false,
      bool isAI = false)
    {
      if (up.unit == null)
        return new HashSet<BL.Panel>();
      return up.unit.IsDontAction ? new HashSet<BL.Panel>() : BattleFuncs.getTargetPanels(!isOriginal ? up.row : up.originalRow, !isOriginal ? up.column : up.originalColumn, up.unit.healRange, BattleFuncs.getForceIDArray(up.unit, BattleFuncs.env), isAI, up);
    }

    public static List<BL.Panel> getRangePanels(int row, int column, int[] range)
    {
      if (range.Length == 0)
        return new List<BL.Panel>();
      List<BL.Panel> rangePanels = new List<BL.Panel>(range.Length * (range[0] * 4 + range[1] * 4) / 2);
      for (int r2 = -range[1]; r2 <= range[1]; ++r2)
      {
        for (int c2 = -range[1]; c2 <= range[1]; ++c2)
        {
          int num = BL.fieldDistance(0, 0, r2, c2);
          if (num >= range[0] && num <= range[1])
          {
            BL.Panel fieldPanel = BattleFuncs.env.getFieldPanel(row + r2, column + c2);
            if (fieldPanel != null)
              rangePanels.Add(fieldPanel);
          }
        }
      }
      return rangePanels;
    }

    public static HashSet<BL.Panel> allMoveActionRangePanels_(
      BL.UnitPosition up,
      HashSet<BL.Panel> completePanels = null,
      bool isAI = false,
      bool isHeal = false,
      HashSet<BL.Panel> positionPanels = null)
    {
      HashSet<BL.Panel> panelSet = new HashSet<BL.Panel>();
      positionPanels?.Clear();
      if (completePanels == null)
        completePanels = up.completePanels;
      int[] attackRange = up.unit.attackRange;
      int[] healRange = up.unit.healRange;
      BL.ForceID forceId = BattleFuncs.env.getForceID(up.unit);
      BL.ForceID[] targetForce = BattleFuncs.env.getTargetForce(up.unit);
      int[] range = new int[2];
      foreach (BL.Panel completePanel in completePanels)
      {
        if (isHeal)
        {
          range = healRange;
        }
        else
        {
          Tuple<int, int> effectsAddRange = completePanel.getEffectsAddRange(up.unit.unit.kind.ID, up.unit.unit.job.move_type);
          range[0] = attackRange[0] + effectsAddRange.Item1;
          range[1] = attackRange[1] + effectsAddRange.Item2;
        }
        List<BL.Panel> rangePanels = BattleFuncs.getRangePanels(completePanel.row, completePanel.column, range);
        foreach (BL.Panel panel in rangePanels)
          panelSet.Add(panel);
        if (positionPanels != null)
        {
          foreach (BL.Panel panel in rangePanels)
          {
            BL.UnitPosition unitPosition = !isAI ? BattleFuncs.env.getFieldUnit(panel.row, panel.column) : BattleFuncs.env.getFieldUnitAI(panel.row, panel.column);
            if (unitPosition != null)
            {
              if (isHeal)
              {
                if (up.id != unitPosition.id && forceId == BattleFuncs.env.getForceID(unitPosition.unit))
                {
                  positionPanels.Add(completePanel);
                  break;
                }
              }
              else if (((IEnumerable<BL.ForceID>) targetForce).Contains<BL.ForceID>(BattleFuncs.env.getForceID(unitPosition.unit)))
              {
                positionPanels.Add(completePanel);
                break;
              }
            }
          }
        }
      }
      return panelSet;
    }

    public static HashSet<BL.Panel> createDangerPanels<T>(IEnumerable<T> units) where T : BL.UnitPosition
    {
      HashSet<BL.Panel> dangerPanels = new HashSet<BL.Panel>();
      foreach (T unit in units)
      {
        foreach (BL.Panel actionRangePanel in unit.allMoveActionRangePanels)
          dangerPanels.Add(actionRangePanel);
      }
      return dangerPanels;
    }

    public static HashSet<BL.Panel> createDangerPanels(BL.ForceID byForce)
    {
      return BattleFuncs.createDangerPanels<BL.UnitPosition>((IEnumerable<BL.UnitPosition>) BattleFuncs.env.getActionUnits(byForce).value);
    }

    public static HashSet<BL.Panel> createDangerPanels(BL.ForceID[] byForces)
    {
      HashSet<BL.Panel> dangerPanels = new HashSet<BL.Panel>();
      foreach (BL.ForceID byForce in byForces)
      {
        foreach (BL.Panel dangerPanel in BattleFuncs.createDangerPanels(byForce))
          dangerPanels.Add(dangerPanel);
      }
      return dangerPanels;
    }

    public static HashSet<BL.Panel> moveCompletePanels_(
      HashSet<BL.Panel> panels,
      BL.Unit unit,
      bool isAI = false,
      bool isOriginal = true)
    {
      HashSet<BL.Panel> panelSet = new HashSet<BL.Panel>();
      foreach (BL.Panel panel in panels)
      {
        BL.UnitPosition unitPosition = !isAI ? BattleFuncs.env.getFieldUnit(panel, isOriginal) : BattleFuncs.env.getFieldUnitAI(panel);
        if (unitPosition == null || unitPosition.unit == unit)
          panelSet.Add(panel);
      }
      return panelSet;
    }

    public static HashSet<BL.Panel> targetAttackPanels(
      HashSet<BL.Panel> panels,
      BL.Unit unit,
      BL.ForceID[] targetForce,
      bool isAI = false)
    {
      HashSet<BL.Panel> panelSet = new HashSet<BL.Panel>();
      foreach (BL.Panel panel in panels)
      {
        if (BattleFuncs.getTargets(panel.row, panel.column, unit.attackRange, targetForce, isAI).Count > 0)
          panelSet.Add(panel);
      }
      return panelSet;
    }

    public static List<BL.UnitPosition> getFourForceUnits(
      int row,
      int column,
      BL.ForceID[] targetForce,
      bool isAI = false)
    {
      List<BL.UnitPosition> fourForceUnits = new List<BL.UnitPosition>();
      BL.UnitPosition unitPosition1 = BattleFuncs.env.fieldForceUnit(row + 1, column, targetForce, isAI);
      if (unitPosition1 != null)
        fourForceUnits.Add(unitPosition1);
      BL.UnitPosition unitPosition2 = BattleFuncs.env.fieldForceUnit(row - 1, column, targetForce, isAI);
      if (unitPosition2 != null)
        fourForceUnits.Add(unitPosition2);
      BL.UnitPosition unitPosition3 = BattleFuncs.env.fieldForceUnit(row, column - 1, targetForce, isAI);
      if (unitPosition3 != null)
        fourForceUnits.Add(unitPosition3);
      BL.UnitPosition unitPosition4 = BattleFuncs.env.fieldForceUnit(row, column + 1, targetForce, isAI);
      if (unitPosition4 != null)
        fourForceUnits.Add(unitPosition4);
      return fourForceUnits;
    }

    public static List<BL.UnitPosition> getNeighbors(BL.UnitPosition up, bool isAI = false)
    {
      return BattleFuncs.getFourForceUnits(up.row, up.column, BattleFuncs.getForceIDArray(up.unit, BattleFuncs.env), isAI);
    }

    public static int getMoveCost(
      BL.Panel panel,
      UnitMoveType moveType,
      bool enabledIgnoreMoveCost)
    {
      int moveCost = panel.landform.GetIncr(moveType).move_cost;
      return enabledIgnoreMoveCost && moveCost <= 10 ? 1 : moveCost;
    }

    public static int getMoveCost(BL.Panel panel, BL.Unit unit, bool enabledIgnoreMoveCost)
    {
      return BattleFuncs.getMoveCost(panel, unit.unit.job.move_type, enabledIgnoreMoveCost);
    }

    public static bool isAilmentInvest(
      float lottery,
      int skillID,
      BL.ISkillEffectListUnit target,
      XorShift random)
    {
      if (MasterData.BattleskillSkill.ContainsKey(skillID))
      {
        BattleskillSkill skill = MasterData.BattleskillSkill[skillID];
        lottery = Mathf.Min(1f, lottery);
        float num = target.skillEffects.Where(BattleskillEffectLogicEnum.change_invest_skilleffect).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => ((IEnumerable<BattleskillEffect>) skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (effect => effect.effect_logic.Enum == (BattleskillEffectLogicEnum) x.effect.GetInt("effect_logic"))))).Select<BL.SkillEffect, float>((Func<BL.SkillEffect, float>) (x => x.effect.GetFloat("percentage_change") + x.effect.GetFloat("percentage_change_levelup") * (float) x.baseSkillLevel)).Sum();
        lottery *= Mathf.Max(0.0f, 1f - num);
        if ((double) lottery >= (double) random.NextFloat())
          return true;
      }
      return false;
    }

    public static BL.Skill[] ailmentInvest(int skill_id, BL.ISkillEffectListUnit target)
    {
      if (!MasterData.BattleskillSkill.ContainsKey(skill_id))
        return (BL.Skill[]) null;
      BattleskillSkill battleskillSkill = MasterData.BattleskillSkill[skill_id];
      if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).All<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.seal)))
      {
        IEnumerable<int> target_skills = ((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Select<BattleskillEffect, int>((Func<BattleskillEffect, int>) (x => x.GetInt(nameof (skill_id))));
        if (!target_skills.Contains<int>(0) && !((IEnumerable<PlayerUnitSkills>) target.originalUnit.playerUnit.skills).Any<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => target_skills.Contains<int>(x.skill_id))))
          return (BL.Skill[]) null;
      }
      return new BL.Skill[1]
      {
        new BL.Skill() { id = skill_id }
      };
    }

    public static BL.ISkillEffectListUnit unitPositionToISkillEffectListUnit(BL.UnitPosition up)
    {
      return up is BL.ISkillEffectListUnit ? up as BL.ISkillEffectListUnit : (BL.ISkillEffectListUnit) up.unit;
    }

    public static BL.UnitPosition iSkillEffectListUnitToUnitPosition(BL.ISkillEffectListUnit unit)
    {
      return unit is BL.UnitPosition ? unit as BL.UnitPosition : BattleFuncs.env.getUnitPosition(unit.originalUnit);
    }

    public static bool isSkillsAndEffectsInvalid(
      BL.ISkillEffectListUnit myself,
      BL.ISkillEffectListUnit enemy)
    {
      Func<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int, bool> func = (Func<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int, bool>) ((unit, target, effect_target) => unit.skillEffects.Where(BattleskillEffectLogicEnum.invalid_skills_and_effects, (Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect = x.effect;
        if ((double) effect.GetFloat(nameof (effect_target)) != (double) effect_target || BattleFuncs.isSealedSkillEffect(unit, x) || effect.GetInt("gear_kind_id") != 0 && effect.GetInt("gear_kind_id") != unit.originalUnit.unit.kind.ID || effect.GetInt("target_gear_kind_id") != 0 && effect.GetInt("target_gear_kind_id") != target.originalUnit.unit.kind.ID || effect.GetInt("element") != 0 && (CommonElement) effect.GetInt("element") != unit.originalUnit.playerUnit.GetElement() || effect.GetInt("target_element") != 0 && (CommonElement) effect.GetInt("target_element") != target.originalUnit.playerUnit.GetElement() || effect.GetInt("job_id") != 0 && effect.GetInt("job_id") != unit.originalUnit.job.ID || effect.GetInt("target_job_id") != 0 && effect.GetInt("target_job_id") != target.originalUnit.job.ID || effect.GetInt("family_id") != 0 && !unit.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id")))
          return false;
        return effect.GetInt("target_family_id") == 0 || target.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"));
      })).Any<BL.SkillEffect>());
      return func(myself, enemy, 0) || func(enemy, myself, 1);
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledLandBlessingBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit effectUnit,
      BL.ISkillEffectListUnit targetUnit,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      BattleLandform landform,
      BattleLandformEffectPhase phase,
      int effectTarget)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect =>
      {
        if (BattleFuncs.isSealedSkillEffect(effectUnit, effect) || target != null && effectTarget != effect.effect.GetInt("effect_target") || phase != (BattleLandformEffectPhase) 0 && effect.effect.GetInt(nameof (phase)) != 0 && (BattleLandformEffectPhase) effect.effect.GetInt(nameof (phase)) != phase || effect.effect.GetInt("landform_id") != 0 && effect.effect.GetInt("landform_id") != landform.ID || effect.effect.GetInt("gear_kind_id") != 0 && effect.effect.GetInt("gear_kind_id") != effectUnit.originalUnit.unit.kind.ID || target != null && effect.effect.GetInt("target_gear_kind_id") != 0 && effect.effect.GetInt("target_gear_kind_id") != targetUnit.originalUnit.unit.kind.ID || effect.effect.GetInt("element") != 0 && (CommonElement) effect.effect.GetInt("element") != effectUnit.originalUnit.playerUnit.GetElement() || target != null && effect.effect.GetInt("target_element") != 0 && (CommonElement) effect.effect.GetInt("target_element") != targetUnit.originalUnit.playerUnit.GetElement() || effect.effect.GetInt("job_id") != 0 && effect.effect.GetInt("job_id") != effectUnit.originalUnit.job.ID || target != null && effect.effect.GetInt("target_job_id") != 0 && effect.effect.GetInt("target_job_id") != targetUnit.originalUnit.job.ID || target != null && effectUnit == target && BattleFuncs.isSkillsAndEffectsInvalid(target, unit) || target != null && BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target))
          return false;
        return target == null || !BattleFuncs.isSkillsAndEffectsInvalid(unit, target);
      }));
    }

    public static int GetLandBlessingSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BL.ISkillEffectListUnit beTarget,
      BattleskillEffectLogicEnum fix_logic,
      BattleLandform landform,
      BattleLandformEffectPhase phase)
    {
      int blessingSkillAdd = 0;
      foreach (BL.SkillEffect skillEffect in BattleFuncs.GetEnabledLandBlessingBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, beTarget, beUnit, beTarget, landform, phase, 0))
        blessingSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
      if (beTarget != null)
      {
        foreach (BL.SkillEffect skillEffect in BattleFuncs.GetEnabledLandBlessingBuffDebuff(beTarget.skillEffects, fix_logic, beTarget, beUnit, beUnit, beTarget, landform, phase, 1))
          blessingSkillAdd += skillEffect.effect.GetInt("value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
      }
      return blessingSkillAdd;
    }

    public static float GetLandBlessingSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BL.ISkillEffectListUnit beTarget,
      BattleskillEffectLogicEnum ratio_logic,
      BattleLandform landform,
      BattleLandformEffectPhase phase)
    {
      float blessingSkillMul = 1f;
      foreach (BL.SkillEffect skillEffect in BattleFuncs.GetEnabledLandBlessingBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, beTarget, beUnit, beTarget, landform, phase, 0))
        blessingSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
      if (beTarget != null)
      {
        foreach (BL.SkillEffect skillEffect in BattleFuncs.GetEnabledLandBlessingBuffDebuff(beTarget.skillEffects, ratio_logic, beTarget, beUnit, beUnit, beTarget, landform, phase, 1))
          blessingSkillMul *= skillEffect.effect.GetFloat("percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
      }
      return blessingSkillMul;
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDuelSupportBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit effectUnit,
      BL.ISkillEffectListUnit targetUnit,
      int effectTarget,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect =>
      {
        BattleskillEffect effect1 = effect.effect;
        return !BattleFuncs.isSealedSkillEffect(effectUnit, effect) && effectTarget == effect.effect.GetInt("effect_target") && (!effect1.HasKey("gear_kind_id") || effect1.GetInt("gear_kind_id") == 0 || effect1.GetInt("gear_kind_id") == effectUnit.originalUnit.unit.kind.ID) && (!effect1.HasKey("target_gear_kind_id") || effect1.GetInt("target_gear_kind_id") == 0 || effect1.GetInt("target_gear_kind_id") == targetUnit.originalUnit.unit.kind.ID) && (!effect1.HasKey("element") || effect1.GetInt("element") == 0 || (CommonElement) effect1.GetInt("element") == effectUnit.originalUnit.playerUnit.GetElement()) && (!effect1.HasKey("target_element") || effect1.GetInt("target_element") == 0 || (CommonElement) effect1.GetInt("target_element") == targetUnit.originalUnit.playerUnit.GetElement()) && (effectUnit != target || !BattleFuncs.isSkillsAndEffectsInvalid(target, unit)) && !BattleFuncs.isEffectEnemyRangeAndInvalid(effect, unit, target) && !BattleFuncs.isSkillsAndEffectsInvalid(unit, target);
      }));
    }

    [DebuggerHidden]
    private static IEnumerable<BL.SkillEffect> GetDuelSupportSkillEffects(
      BL.ISkillEffectListUnit beUnit,
      BL.ISkillEffectListUnit beTarget,
      BattleskillEffectLogicEnum logic,
      BL.Unit[] neighborUnits)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      BattleFuncs.\u003CGetDuelSupportSkillEffects\u003Ec__Iterator25 supportSkillEffects = new BattleFuncs.\u003CGetDuelSupportSkillEffects\u003Ec__Iterator25()
      {
        beUnit = beUnit,
        beTarget = beTarget,
        logic = logic,
        neighborUnits = neighborUnits,
        \u003C\u0024\u003EbeUnit = beUnit,
        \u003C\u0024\u003EbeTarget = beTarget,
        \u003C\u0024\u003Elogic = logic,
        \u003C\u0024\u003EneighborUnits = neighborUnits
      };
      // ISSUE: reference to a compiler-generated field
      supportSkillEffects.\u0024PC = -2;
      return (IEnumerable<BL.SkillEffect>) supportSkillEffects;
    }

    public static int GetDuelSupportSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BL.ISkillEffectListUnit beTarget,
      BattleskillEffectLogicEnum fix_logic,
      BL.Unit[] neighborUnits)
    {
      int duelSupportSkillAdd = 0;
      foreach (BL.SkillEffect supportSkillEffect in BattleFuncs.GetDuelSupportSkillEffects(beUnit, beTarget, fix_logic, neighborUnits))
        duelSupportSkillAdd += supportSkillEffect.effect.GetInt("value") + supportSkillEffect.baseSkillLevel * supportSkillEffect.effect.GetInt("skill_ratio");
      return duelSupportSkillAdd;
    }

    public static float GetDuelSupportSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BL.ISkillEffectListUnit beTarget,
      BattleskillEffectLogicEnum ratio_logic,
      BL.Unit[] neighborUnits)
    {
      float duelSupportSkillMul = 1f;
      foreach (BL.SkillEffect supportSkillEffect in BattleFuncs.GetDuelSupportSkillEffects(beUnit, beTarget, ratio_logic, neighborUnits))
        duelSupportSkillMul *= supportSkillEffect.effect.GetFloat("percentage") + (float) supportSkillEffect.baseSkillLevel * supportSkillEffect.effect.GetFloat("skill_ratio");
      return duelSupportSkillMul;
    }

    public static BattleFuncs.BeforeDuelDuelSupport GetBeforeDuelDuelSupport(
      BL.ISkillEffectListUnit beUnit,
      BL.ISkillEffectListUnit beTarget,
      BL.Unit[] neighborUnits)
    {
      BattleFuncs.BeforeDuelDuelSupport beforeDuelDuelSupport = new BattleFuncs.BeforeDuelDuelSupport();
      beforeDuelDuelSupport.duelSupport = beUnit.originalUnit.playerUnit.GetIntimateDuelSupport(((IEnumerable<BL.Unit>) neighborUnits).Select<BL.Unit, PlayerUnit>((Func<BL.Unit, PlayerUnit>) (x => x.playerUnit)).ToArray<PlayerUnit>());
      int num1 = BattleFuncs.GetDuelSupportSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support_fix_hit, neighborUnits) + BattleFuncs.GetDuelSupportSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support2_fix_hit, neighborUnits);
      int num2 = BattleFuncs.GetDuelSupportSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support_fix_evasion, neighborUnits) + BattleFuncs.GetDuelSupportSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support2_fix_evasion, neighborUnits);
      int num3 = BattleFuncs.GetDuelSupportSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support_fix_critical, neighborUnits) + BattleFuncs.GetDuelSupportSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support2_fix_critical, neighborUnits);
      int num4 = BattleFuncs.GetDuelSupportSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support_fix_critical_evasion, neighborUnits) + BattleFuncs.GetDuelSupportSkillAdd(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support2_fix_critical_evasion, neighborUnits);
      float num5 = BattleFuncs.GetDuelSupportSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support_ratio_hit, neighborUnits) * BattleFuncs.GetDuelSupportSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support2_ratio_hit, neighborUnits);
      float num6 = BattleFuncs.GetDuelSupportSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support_ratio_evasion, neighborUnits) * BattleFuncs.GetDuelSupportSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support2_ratio_evasion, neighborUnits);
      float num7 = BattleFuncs.GetDuelSupportSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support_ratio_critical, neighborUnits) * BattleFuncs.GetDuelSupportSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support2_ratio_critical, neighborUnits);
      float num8 = BattleFuncs.GetDuelSupportSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support_ratio_critical_evasion, neighborUnits) * BattleFuncs.GetDuelSupportSkillMul(beUnit, beTarget, BattleskillEffectLogicEnum.duel_support2_ratio_critical_evasion, neighborUnits);
      beforeDuelDuelSupport.hit = Mathf.CeilToInt((float) beforeDuelDuelSupport.duelSupport.hit * num5) + num1;
      beforeDuelDuelSupport.evasion = Mathf.CeilToInt((float) beforeDuelDuelSupport.duelSupport.evasion * num6) + num2;
      beforeDuelDuelSupport.critical = Mathf.CeilToInt((float) beforeDuelDuelSupport.duelSupport.critical * num7) + num3;
      beforeDuelDuelSupport.criticalEvasion = Mathf.CeilToInt((float) beforeDuelDuelSupport.duelSupport.critical_evasion * num8) + num4;
      beforeDuelDuelSupport.hitIncr = beforeDuelDuelSupport.hit - beforeDuelDuelSupport.duelSupport.hit;
      beforeDuelDuelSupport.evasionIncr = beforeDuelDuelSupport.evasion - beforeDuelDuelSupport.duelSupport.evasion;
      beforeDuelDuelSupport.criticalIncr = beforeDuelDuelSupport.critical - beforeDuelDuelSupport.duelSupport.critical;
      beforeDuelDuelSupport.criticalEvasionIncr = beforeDuelDuelSupport.criticalEvasion - beforeDuelDuelSupport.duelSupport.critical_evasion;
      return beforeDuelDuelSupport;
    }

    public static BL.PhaseState getPhaseState()
    {
      return BattleFuncs.env != null ? BattleFuncs.env.phaseState : (BL.PhaseState) null;
    }

    public static bool isInvoke(
      BL.ISkillEffectListUnit invoke,
      BL.ISkillEffectListUnit target,
      Judgement.BeforeDuelUnitParameter invokeParameter,
      Judgement.BeforeDuelUnitParameter targetParameter,
      int skill_level,
      float percentage_invocation,
      XorShift random,
      float? invokeRate = null,
      BattleskillEffect effect = null)
    {
      int num1 = invokeParameter.Dexterity;
      if (effect != null)
      {
        switch (effect.effect_logic.Enum)
        {
          case BattleskillEffectLogicEnum.prayer:
          case BattleskillEffectLogicEnum.passive_prayer:
            num1 = invokeParameter.Luck;
            break;
        }
      }
      float num2 = (float) num1 * percentage_invocation + (float) skill_level - (float) targetParameter.Luck;
      if (invokeRate.HasValue)
      {
        float? nullable = !invokeRate.HasValue ? new float?() : new float?(invokeRate.Value * 100f);
        if ((!nullable.HasValue ? 0 : ((double) num2 < (double) nullable.Value ? 1 : 0)) != 0)
          num2 = invokeRate.Value * 100f;
      }
      float num3 = num2 + BattleFuncs.getWhiteNightRate(invoke, target) * 100f;
      float? nullable1 = new float?();
      float? nullable2 = new float?();
      foreach (BL.SkillEffect skillEffect in invoke.enabledSkillEffect(BattleskillEffectLogicEnum.clamp_invoke_duel_skill).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect1 = x.effect;
        if (effect1.HasKey("gear_kind_id") && effect1.GetInt("gear_kind_id") != 0 && effect1.GetInt("gear_kind_id") != invoke.originalUnit.unit.kind.ID || effect1.HasKey("target_gear_kind_id") && effect1.GetInt("target_gear_kind_id") != 0 && effect1.GetInt("target_gear_kind_id") != target.originalUnit.unit.kind.ID || effect1.HasKey("element") && effect1.GetInt("element") != 0 && (CommonElement) effect1.GetInt("element") != invoke.originalUnit.playerUnit.GetElement() || effect1.HasKey("target_element") && effect1.GetInt("target_element") != 0 && (CommonElement) effect1.GetInt("target_element") != target.originalUnit.playerUnit.GetElement() || effect1.HasKey("job_id") && effect1.GetInt("job_id") != 0 && effect1.GetInt("job_id") != invoke.originalUnit.job.ID)
          return false;
        return !effect1.HasKey("target_job_id") || effect1.GetInt("target_job_id") == 0 || effect1.GetInt("target_job_id") == target.originalUnit.job.ID;
      })))
      {
        float num4 = (float) (((Decimal) skillEffect.effect.GetFloat("min_percentage") + (Decimal) skillEffect.baseSkillLevel * (Decimal) skillEffect.effect.GetFloat("min_skill_ratio")) * 100M);
        if (!nullable1.HasValue || (!nullable1.HasValue ? 0 : ((double) num4 > (double) nullable1.Value ? 1 : 0)) != 0)
          nullable1 = new float?(num4);
        float num5 = (float) (((Decimal) skillEffect.effect.GetFloat("max_percentage") + (Decimal) skillEffect.baseSkillLevel * (Decimal) skillEffect.effect.GetFloat("max_skill_ratio")) * 100M);
        if (!nullable2.HasValue || (!nullable2.HasValue ? 0 : ((double) num5 < (double) nullable2.Value ? 1 : 0)) != 0)
          nullable2 = new float?(num5);
      }
      if (nullable2.HasValue && (!nullable2.HasValue ? 0 : ((double) num3 > (double) nullable2.Value ? 1 : 0)) != 0)
        num3 = nullable2.Value;
      if (nullable1.HasValue && (!nullable1.HasValue ? 0 : ((double) num3 < (double) nullable1.Value ? 1 : 0)) != 0)
        num3 = nullable1.Value;
      return (double) num3 >= (double) random.NextFloat() * 100.0;
    }

    private static float getWhiteNightRate(
      BL.ISkillEffectListUnit myself,
      BL.ISkillEffectListUnit enemy)
    {
      float rate = 0.0f;
      Action<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int> action = (Action<BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, int>) ((effectUnit, targetUnit, effect_target) =>
      {
        foreach (BL.SkillEffect skillEffect in effectUnit.skillEffects.Where(BattleskillEffectLogicEnum.white_night, (Func<BL.SkillEffect, bool>) (x =>
        {
          BattleskillEffect effect = x.effect;
          return (double) effect.GetFloat(nameof (effect_target)) == (double) effect_target && !BattleFuncs.isSealedSkillEffect(effectUnit, x) && (!effect.HasKey("gear_kind_id") || effect.GetInt("gear_kind_id") == 0 || effect.GetInt("gear_kind_id") == effectUnit.originalUnit.unit.kind.ID) && (!effect.HasKey("target_gear_kind_id") || effect.GetInt("target_gear_kind_id") == 0 || effect.GetInt("target_gear_kind_id") == targetUnit.originalUnit.unit.kind.ID) && (!effect.HasKey("element") || effect.GetInt("element") == 0 || (CommonElement) effect.GetInt("element") == effectUnit.originalUnit.playerUnit.GetElement()) && (!effect.HasKey("target_element") || effect.GetInt("target_element") == 0 || (CommonElement) effect.GetInt("target_element") == targetUnit.originalUnit.playerUnit.GetElement()) && (!effect.HasKey("job_id") || effect.GetInt("job_id") == 0 || effect.GetInt("job_id") == effectUnit.originalUnit.job.ID) && (!effect.HasKey("target_job_id") || effect.GetInt("target_job_id") == 0 || effect.GetInt("target_job_id") == targetUnit.originalUnit.job.ID) && (!effect.HasKey("family_id") || effect.GetInt("family_id") == 0 || effectUnit.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id"))) && (!effect.HasKey("target_family_id") || effect.GetInt("target_family_id") == 0 || targetUnit.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"))) && (effectUnit != enemy || !BattleFuncs.isSkillsAndEffectsInvalid(enemy, myself)) && !BattleFuncs.isEffectEnemyRangeAndInvalid(x, myself, enemy) && !BattleFuncs.isSkillsAndEffectsInvalid(myself, enemy);
        })))
          rate += skillEffect.effect.GetFloat("percentage") * (float) skillEffect.baseSkillLevel;
      });
      action(myself, enemy, 0);
      action(enemy, myself, 1);
      return rate;
    }

    public static IEnumerable<Tuple<BattleskillSkill, int>> getUnitAndGearSkills(BL.Unit unit)
    {
      IEnumerable<Tuple<BattleskillSkill, int>> first = (IEnumerable<Tuple<BattleskillSkill, int>>) ((IEnumerable<PlayerUnitSkills>) unit.playerUnit.skills).Select<PlayerUnitSkills, Tuple<BattleskillSkill, int>>((Func<PlayerUnitSkills, Tuple<BattleskillSkill, int>>) (x => new Tuple<BattleskillSkill, int>(x.skill, x.level))).OrderByDescending<Tuple<BattleskillSkill, int>, int>((Func<Tuple<BattleskillSkill, int>, int>) (x => x.Item1.weight)).ThenBy<Tuple<BattleskillSkill, int>, int>((Func<Tuple<BattleskillSkill, int>, int>) (x => x.Item1.ID));
      if (unit.playerUnit.equippedGear != (PlayerItem) null)
        first = first.Concat<Tuple<BattleskillSkill, int>>((IEnumerable<Tuple<BattleskillSkill, int>>) ((IEnumerable<GearGearSkill>) unit.playerUnit.equippedGear.skills).Select<GearGearSkill, Tuple<BattleskillSkill, int>>((Func<GearGearSkill, Tuple<BattleskillSkill, int>>) (x => new Tuple<BattleskillSkill, int>(x.skill, x.skill_level))).OrderByDescending<Tuple<BattleskillSkill, int>, int>((Func<Tuple<BattleskillSkill, int>, int>) (x => x.Item1.weight)).ThenBy<Tuple<BattleskillSkill, int>, int>((Func<Tuple<BattleskillSkill, int>, int>) (x => x.Item1.ID)));
      return first;
    }

    public static bool isCriticalGuardEnable(
      BL.ISkillEffectListUnit myself,
      BL.ISkillEffectListUnit enemy)
    {
      return myself.enabledSkillEffect(BattleskillEffectLogicEnum.critical_guard).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x =>
      {
        BattleskillEffect effect = x.effect;
        if (effect.HasKey("gear_kind_id") && effect.GetInt("gear_kind_id") != 0 && effect.GetInt("gear_kind_id") != myself.originalUnit.unit.kind.ID || effect.HasKey("target_gear_kind_id") && effect.GetInt("target_gear_kind_id") != 0 && effect.GetInt("target_gear_kind_id") != enemy.originalUnit.unit.kind.ID || effect.HasKey("element") && effect.GetInt("element") != 0 && (CommonElement) effect.GetInt("element") != myself.originalUnit.playerUnit.GetElement() || effect.HasKey("target_element") && effect.GetInt("target_element") != 0 && (CommonElement) effect.GetInt("target_element") != enemy.originalUnit.playerUnit.GetElement() || effect.HasKey("job_id") && effect.GetInt("job_id") != 0 && effect.GetInt("job_id") != myself.originalUnit.job.ID || effect.HasKey("target_job_id") && effect.GetInt("target_job_id") != 0 && effect.GetInt("target_job_id") != enemy.originalUnit.job.ID || effect.HasKey("family_id") && effect.GetInt("family_id") != 0 && !myself.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("family_id")))
          return false;
        return !effect.HasKey("target_family_id") || effect.GetInt("target_family_id") == 0 || enemy.originalUnit.unit.HasFamily((UnitFamily) effect.GetInt("target_family_id"));
      })).Any<BL.SkillEffect>() && !BattleFuncs.isSkillsAndEffectsInvalid(myself, enemy);
    }

    public static bool isEffectEnemyRangeAndInvalid(
      BL.SkillEffect effect,
      BL.ISkillEffectListUnit myself,
      BL.ISkillEffectListUnit enemy)
    {
      return effect.unit != null && effect.unit.index == enemy.originalUnit.index && effect.unit.isPlayerControl == enemy.originalUnit.isPlayerControl && (effect.effect.skill.skill_type == BattleskillSkillType.leader || effect.effect.skill.skill_type == BattleskillSkillType.passive && effect.effect.skill.range_effect_passive_skill) && BattleFuncs.isSkillsAndEffectsInvalid(enemy, myself);
    }

    public static void consumeSkillEffects(
      BL.DuelTurn[] turns,
      BL.ISkillEffectListUnit atk,
      BL.ISkillEffectListUnit def)
    {
      Action<BL.SkillEffectList, BL.SkillEffect> action = (Action<BL.SkillEffectList, BL.SkillEffect>) ((skillEffects, consumeEffect) =>
      {
        BL.SkillEffect skillEffect = skillEffects.All().Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x =>
        {
          if (x.effectId == consumeEffect.effectId && x.baseSkillLevel == consumeEffect.baseSkillLevel)
          {
            int? turnRemain3 = x.turnRemain;
            int valueOrDefault3 = turnRemain3.GetValueOrDefault();
            int? turnRemain4 = consumeEffect.turnRemain;
            int valueOrDefault4 = turnRemain4.GetValueOrDefault();
            if ((valueOrDefault3 != valueOrDefault4 ? 0 : (turnRemain3.HasValue == turnRemain4.HasValue ? 1 : 0)) != 0)
            {
              if (x.unit == null && consumeEffect.unit == null)
                return true;
              return x.unit != null && consumeEffect.unit != null && x.unit.index == consumeEffect.unit.index && x.unit.isPlayerControl == consumeEffect.unit.isPlayerControl;
            }
          }
          return false;
        })).FirstOrDefault<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x =>
        {
          int? useRemain = x.useRemain;
          return useRemain.HasValue && useRemain.Value >= 1;
        }));
        if (skillEffect == null)
          return;
        int? useRemain1 = skillEffect.useRemain;
        if (!useRemain1.HasValue)
          return;
        skillEffect.useRemain = new int?(useRemain1.Value - 1);
      });
      foreach (BL.DuelTurn turn in turns)
      {
        List<BL.SkillEffect> consumeSkillEffects1;
        List<BL.SkillEffect> consumeSkillEffects2;
        if (turn.isAtackker)
        {
          consumeSkillEffects1 = turn.attackerConsumeSkillEffects;
          consumeSkillEffects2 = turn.defenderConsumeSkillEffects;
        }
        else
        {
          consumeSkillEffects1 = turn.defenderConsumeSkillEffects;
          consumeSkillEffects2 = turn.attackerConsumeSkillEffects;
        }
        foreach (BL.SkillEffect skillEffect in consumeSkillEffects1)
          action(atk.skillEffects, skillEffect);
        foreach (BL.SkillEffect skillEffect in consumeSkillEffects2)
          action(def.skillEffects, skillEffect);
      }
    }

    public static BL.ClassValue<List<BL.AIUnit>> getAIDeads() => BattleFuncs.env.aiDeads;

    public static IEnumerable<BL.ISkillEffectListUnit> getInvestUnit(
      BL.ISkillEffectListUnit myself,
      BL.ISkillEffectListUnit enemy,
      int skillId,
      int rangeType,
      bool isAI,
      bool isColosseum)
    {
      BattleskillSkill battleskillSkill = MasterData.BattleskillSkill[skillId];
      if (isColosseum)
      {
        List<BL.ISkillEffectListUnit> skillEffectListUnitList = new List<BL.ISkillEffectListUnit>();
        switch (rangeType)
        {
          case 0:
            switch (battleskillSkill.target_type)
            {
              case BattleskillTargetType.myself:
              case BattleskillTargetType.player_single:
                skillEffectListUnitList.Add(myself);
                break;
              case BattleskillTargetType.player_range:
                if (battleskillSkill.min_range <= 0)
                {
                  skillEffectListUnitList.Add(myself);
                  break;
                }
                break;
              case BattleskillTargetType.enemy_single:
                skillEffectListUnitList.Add(enemy);
                break;
              case BattleskillTargetType.enemy_range:
                if (battleskillSkill.min_range <= 1 && battleskillSkill.max_range >= 1)
                {
                  skillEffectListUnitList.Add(enemy);
                  break;
                }
                break;
              case BattleskillTargetType.complex_single:
                if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => !x.is_targer_enemy)))
                  skillEffectListUnitList.Add(myself);
                if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.is_targer_enemy)))
                {
                  skillEffectListUnitList.Add(enemy);
                  break;
                }
                break;
              case BattleskillTargetType.complex_range:
                if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => !x.is_targer_enemy)) && battleskillSkill.min_range <= 0)
                  skillEffectListUnitList.Add(myself);
                if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.is_targer_enemy)) && battleskillSkill.min_range <= 1 && battleskillSkill.max_range >= 1)
                {
                  skillEffectListUnitList.Add(enemy);
                  break;
                }
                break;
            }
            break;
          case 1:
            switch (battleskillSkill.target_type)
            {
              case BattleskillTargetType.myself:
              case BattleskillTargetType.player_range:
              case BattleskillTargetType.player_single:
                if (battleskillSkill.min_range <= 0)
                {
                  skillEffectListUnitList.Add(myself);
                  break;
                }
                break;
              case BattleskillTargetType.enemy_single:
              case BattleskillTargetType.enemy_range:
                if (battleskillSkill.min_range <= 1 && battleskillSkill.max_range >= 1)
                {
                  skillEffectListUnitList.Add(enemy);
                  break;
                }
                break;
              case BattleskillTargetType.complex_single:
              case BattleskillTargetType.complex_range:
                if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => !x.is_targer_enemy)) && battleskillSkill.min_range <= 0)
                  skillEffectListUnitList.Add(myself);
                if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.is_targer_enemy)) && battleskillSkill.min_range <= 1 && battleskillSkill.max_range >= 1)
                {
                  skillEffectListUnitList.Add(enemy);
                  break;
                }
                break;
            }
            break;
          case 2:
            switch (battleskillSkill.target_type)
            {
              case BattleskillTargetType.myself:
              case BattleskillTargetType.player_range:
              case BattleskillTargetType.player_single:
                if (battleskillSkill.min_range <= 1 && battleskillSkill.max_range >= 1)
                {
                  skillEffectListUnitList.Add(myself);
                  break;
                }
                break;
              case BattleskillTargetType.enemy_single:
              case BattleskillTargetType.enemy_range:
                if (battleskillSkill.min_range <= 0)
                {
                  skillEffectListUnitList.Add(enemy);
                  break;
                }
                break;
              case BattleskillTargetType.complex_single:
              case BattleskillTargetType.complex_range:
                if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => !x.is_targer_enemy)) && battleskillSkill.min_range <= 1 && battleskillSkill.max_range >= 1)
                  skillEffectListUnitList.Add(myself);
                if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.is_targer_enemy)) && battleskillSkill.min_range <= 0)
                {
                  skillEffectListUnitList.Add(enemy);
                  break;
                }
                break;
            }
            break;
        }
        return (IEnumerable<BL.ISkillEffectListUnit>) skillEffectListUnitList.ToArray();
      }
      List<BL.UnitPosition> source = new List<BL.UnitPosition>();
      switch (rangeType)
      {
        case 0:
          switch (battleskillSkill.target_type)
          {
            case BattleskillTargetType.myself:
            case BattleskillTargetType.player_single:
              source = BattleFuncs.getTargets(myself.originalUnit, new int[2], new BL.ForceID[1]
              {
                BattleFuncs.getForceID(myself.originalUnit)
              }, (isAI ? 1 : 0) != 0);
              break;
            case BattleskillTargetType.player_range:
              source = BattleFuncs.getTargets(myself.originalUnit, new int[2]
              {
                battleskillSkill.min_range,
                battleskillSkill.max_range
              }, new BL.ForceID[1]
              {
                BattleFuncs.getForceID(myself.originalUnit)
              }, (isAI ? 1 : 0) != 0);
              break;
            case BattleskillTargetType.enemy_single:
              source = BattleFuncs.getTargets(enemy.originalUnit, new int[2], new BL.ForceID[1]
              {
                BattleFuncs.getForceID(enemy.originalUnit)
              }, (isAI ? 1 : 0) != 0);
              break;
            case BattleskillTargetType.enemy_range:
              source = BattleFuncs.getTargets(myself.originalUnit, new int[2]
              {
                battleskillSkill.min_range,
                battleskillSkill.max_range
              }, new BL.ForceID[1]
              {
                BattleFuncs.getForceID(enemy.originalUnit)
              }, (isAI ? 1 : 0) != 0);
              break;
            case BattleskillTargetType.complex_single:
              if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => !x.is_targer_enemy)))
                source.AddRange((IEnumerable<BL.UnitPosition>) BattleFuncs.getTargets(myself.originalUnit, new int[2], new BL.ForceID[1]
                {
                  BattleFuncs.getForceID(myself.originalUnit)
                }, (isAI ? 1 : 0) != 0));
              if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.is_targer_enemy)))
              {
                source.AddRange((IEnumerable<BL.UnitPosition>) BattleFuncs.getTargets(enemy.originalUnit, new int[2], new BL.ForceID[1]
                {
                  BattleFuncs.getForceID(enemy.originalUnit)
                }, (isAI ? 1 : 0) != 0));
                break;
              }
              break;
            case BattleskillTargetType.complex_range:
              if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => !x.is_targer_enemy)))
                source.AddRange((IEnumerable<BL.UnitPosition>) BattleFuncs.getTargets(myself.originalUnit, new int[2]
                {
                  battleskillSkill.min_range,
                  battleskillSkill.max_range
                }, new BL.ForceID[1]
                {
                  BattleFuncs.getForceID(myself.originalUnit)
                }, (isAI ? 1 : 0) != 0));
              if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.is_targer_enemy)))
              {
                source.AddRange((IEnumerable<BL.UnitPosition>) BattleFuncs.getTargets(myself.originalUnit, new int[2]
                {
                  battleskillSkill.min_range,
                  battleskillSkill.max_range
                }, new BL.ForceID[1]
                {
                  BattleFuncs.getForceID(enemy.originalUnit)
                }, (isAI ? 1 : 0) != 0));
                break;
              }
              break;
          }
          break;
        case 1:
        case 2:
          BL.ISkillEffectListUnit skillEffectListUnit = rangeType != 1 ? enemy : myself;
          int[] range = new int[2]
          {
            battleskillSkill.min_range,
            battleskillSkill.max_range
          };
          switch (battleskillSkill.target_type)
          {
            case BattleskillTargetType.myself:
            case BattleskillTargetType.player_single:
              List<BL.UnitPosition> targets1 = BattleFuncs.getTargets(skillEffectListUnit.originalUnit, range, new BL.ForceID[1]
              {
                BattleFuncs.getForceID(myself.originalUnit)
              }, (isAI ? 1 : 0) != 0);
              source.AddRange(targets1.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x) == myself)));
              break;
            case BattleskillTargetType.player_range:
              source = BattleFuncs.getTargets(skillEffectListUnit.originalUnit, range, new BL.ForceID[1]
              {
                BattleFuncs.getForceID(myself.originalUnit)
              }, (isAI ? 1 : 0) != 0);
              break;
            case BattleskillTargetType.enemy_single:
              List<BL.UnitPosition> targets2 = BattleFuncs.getTargets(skillEffectListUnit.originalUnit, range, new BL.ForceID[1]
              {
                BattleFuncs.getForceID(enemy.originalUnit)
              }, (isAI ? 1 : 0) != 0);
              source.AddRange(targets2.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x) == enemy)));
              break;
            case BattleskillTargetType.enemy_range:
              source = BattleFuncs.getTargets(skillEffectListUnit.originalUnit, range, new BL.ForceID[1]
              {
                BattleFuncs.getForceID(enemy.originalUnit)
              }, (isAI ? 1 : 0) != 0);
              break;
            case BattleskillTargetType.complex_single:
              if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => !x.is_targer_enemy)))
              {
                List<BL.UnitPosition> targets3 = BattleFuncs.getTargets(skillEffectListUnit.originalUnit, range, new BL.ForceID[1]
                {
                  BattleFuncs.getForceID(myself.originalUnit)
                }, (isAI ? 1 : 0) != 0);
                source.AddRange(targets3.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x) == myself)));
              }
              if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.is_targer_enemy)))
              {
                List<BL.UnitPosition> targets4 = BattleFuncs.getTargets(skillEffectListUnit.originalUnit, range, new BL.ForceID[1]
                {
                  BattleFuncs.getForceID(enemy.originalUnit)
                }, (isAI ? 1 : 0) != 0);
                source.AddRange(targets4.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x) == enemy)));
                break;
              }
              break;
            case BattleskillTargetType.complex_range:
              if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => !x.is_targer_enemy)))
                source.AddRange((IEnumerable<BL.UnitPosition>) BattleFuncs.getTargets(skillEffectListUnit.originalUnit, range, new BL.ForceID[1]
                {
                  BattleFuncs.getForceID(myself.originalUnit)
                }, (isAI ? 1 : 0) != 0));
              if (((IEnumerable<BattleskillEffect>) battleskillSkill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.is_targer_enemy)))
              {
                source.AddRange((IEnumerable<BL.UnitPosition>) BattleFuncs.getTargets(skillEffectListUnit.originalUnit, range, new BL.ForceID[1]
                {
                  BattleFuncs.getForceID(enemy.originalUnit)
                }, (isAI ? 1 : 0) != 0));
                break;
              }
              break;
          }
          break;
      }
      return source.Select<BL.UnitPosition, BL.ISkillEffectListUnit>((Func<BL.UnitPosition, BL.ISkillEffectListUnit>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x)));
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDeckEveryBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.Unit> deckUnits,
      Func<int, int, bool> condFunc)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => effect.effectId)).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect =>
      {
        int num1 = effect.effect.GetInt("type");
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        for (int index = 1; index <= 7; ++index)
        {
          int num2 = effect.effect.GetInt("kind_count" + (object) index);
          if (num2 != 0)
          {
            int key = num2 / 10;
            int num3 = num2 % 10;
            dictionary[key] = num3;
          }
        }
        foreach (int key in dictionary.Keys)
        {
          int kind = key;
          int num4 = 0;
          switch (num1)
          {
            case 0:
              num4 = deckUnits.Count<BL.Unit>((Func<BL.Unit, bool>) (x => x.originalUnit.unit.kind.ID == kind));
              break;
            case 1:
              num4 = deckUnits.Count<BL.Unit>((Func<BL.Unit, bool>) (x => x.originalUnit.playerUnit.GetElement() == (CommonElement) kind));
              break;
            case 2:
              num4 = deckUnits.Count<BL.Unit>((Func<BL.Unit, bool>) (x => x.originalUnit.job.ID == kind));
              break;
            case 3:
              num4 = deckUnits.Count<BL.Unit>((Func<BL.Unit, bool>) (x => x.originalUnit.unit.HasFamily((UnitFamily) kind)));
              break;
            case 4:
              num4 = deckUnits.Count<BL.Unit>((Func<BL.Unit, bool>) (x => x.unit.character.ID == kind));
              break;
            case 5:
              num4 = deckUnits.Count<BL.Unit>((Func<BL.Unit, bool>) (x => x.unit.same_character_id == kind));
              break;
            case 6:
              num4 = deckUnits.Count<BL.Unit>((Func<BL.Unit, bool>) (x => x.unit.ID == kind));
              break;
          }
          if (!condFunc(num4, dictionary[kind]))
            return false;
        }
        return true;
      })).ToList<BL.SkillEffect>()));
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDeckEveryGeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.Unit> deckUnits)
    {
      return BattleFuncs.GetEnabledDeckEveryBuffDebuff(self, e, unit, deckUnits, (Func<int, int, bool>) ((deckCount, condCount) => deckCount >= condCount));
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDeckEveryLeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.Unit> deckUnits)
    {
      return BattleFuncs.GetEnabledDeckEveryBuffDebuff(self, e, unit, deckUnits, (Func<int, int, bool>) ((deckCount, condCount) => deckCount <= condCount));
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDeckSameAnotherBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.Unit> deckUnits,
      Func<IEnumerable<int>, int, bool> condFunc)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => effect.effectId)).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect =>
      {
        int num1 = effect.effect.GetInt("type");
        int num2 = effect.effect.GetInt("kind_count");
        IEnumerable<int> source = (IEnumerable<int>) null;
        switch (num1)
        {
          case 0:
            source = deckUnits.GroupBy<BL.Unit, int>((Func<BL.Unit, int>) (x => x.originalUnit.unit.kind.ID)).Select<IGrouping<int, BL.Unit>, int>((Func<IGrouping<int, BL.Unit>, int>) (x => x.Count<BL.Unit>()));
            break;
          case 1:
            source = deckUnits.GroupBy<BL.Unit, int>((Func<BL.Unit, int>) (x => (int) x.originalUnit.playerUnit.GetElement())).Select<IGrouping<int, BL.Unit>, int>((Func<IGrouping<int, BL.Unit>, int>) (x => x.Count<BL.Unit>()));
            break;
          case 2:
            source = deckUnits.GroupBy<BL.Unit, int>((Func<BL.Unit, int>) (x => x.originalUnit.job.ID)).Select<IGrouping<int, BL.Unit>, int>((Func<IGrouping<int, BL.Unit>, int>) (x => x.Count<BL.Unit>()));
            break;
          case 3:
            source = deckUnits.SelectMany<BL.Unit, UnitFamily>((Func<BL.Unit, IEnumerable<UnitFamily>>) (x => (IEnumerable<UnitFamily>) x.originalUnit.unit.Families)).GroupBy<UnitFamily, UnitFamily>((Func<UnitFamily, UnitFamily>) (x => x)).Select<IGrouping<UnitFamily, UnitFamily>, int>((Func<IGrouping<UnitFamily, UnitFamily>, int>) (x => x.Count<UnitFamily>()));
            break;
          case 4:
            source = deckUnits.GroupBy<BL.Unit, int>((Func<BL.Unit, int>) (x => x.unit.character.ID)).Select<IGrouping<int, BL.Unit>, int>((Func<IGrouping<int, BL.Unit>, int>) (x => x.Count<BL.Unit>()));
            break;
          case 5:
            source = deckUnits.GroupBy<BL.Unit, int>((Func<BL.Unit, int>) (x => x.unit.same_character_id)).Select<IGrouping<int, BL.Unit>, int>((Func<IGrouping<int, BL.Unit>, int>) (x => x.Count<BL.Unit>()));
            break;
          case 6:
            source = deckUnits.GroupBy<BL.Unit, int>((Func<BL.Unit, int>) (x => x.unit.ID)).Select<IGrouping<int, BL.Unit>, int>((Func<IGrouping<int, BL.Unit>, int>) (x => x.Count<BL.Unit>()));
            break;
        }
        return source != null && source.Count<int>() != 0 && condFunc(source, num2);
      })).ToList<BL.SkillEffect>()));
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDeckAnotherGeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.Unit> deckUnits)
    {
      return BattleFuncs.GetEnabledDeckSameAnotherBuffDebuff(self, e, unit, deckUnits, (Func<IEnumerable<int>, int, bool>) ((count, kindCount) => count.Count<int>() >= kindCount));
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDeckAnotherLeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.Unit> deckUnits)
    {
      return BattleFuncs.GetEnabledDeckSameAnotherBuffDebuff(self, e, unit, deckUnits, (Func<IEnumerable<int>, int, bool>) ((count, kindCount) => count.Count<int>() <= kindCount));
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDeckSameGeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.Unit> deckUnits)
    {
      return BattleFuncs.GetEnabledDeckSameAnotherBuffDebuff(self, e, unit, deckUnits, (Func<IEnumerable<int>, int, bool>) ((count, kindCount) => count.OrderByDescending<int, int>((Func<int, int>) (x => x)).First<int>() >= kindCount));
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledDeckSameLeBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.Unit> deckUnits)
    {
      return BattleFuncs.GetEnabledDeckSameAnotherBuffDebuff(self, e, unit, deckUnits, (Func<IEnumerable<int>, int, bool>) ((count, kindCount) => count.OrderByDescending<int, int>((Func<int, int>) (x => x)).First<int>() <= kindCount));
    }

    private static void GetDeckEveryGeSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum fix_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckEveryGeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddFixEffectParam(fix_logic, effect, effect.effect.GetInt("value") + effect.baseSkillLevel * effect.effect.GetInt("skill_ratio"));
    }

    private static void GetDeckEveryGeSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum ratio_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckEveryGeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddRatioEffectParam(ratio_logic, effect, effect.effect.GetFloat("percentage") + (float) effect.baseSkillLevel * effect.effect.GetFloat("skill_ratio"));
    }

    private static void GetDeckEveryLeSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum fix_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckEveryLeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddFixEffectParam(fix_logic, effect, effect.effect.GetInt("value") + effect.baseSkillLevel * effect.effect.GetInt("skill_ratio"));
    }

    private static void GetDeckEveryLeSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum ratio_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckEveryLeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddRatioEffectParam(ratio_logic, effect, effect.effect.GetFloat("percentage") + (float) effect.baseSkillLevel * effect.effect.GetFloat("skill_ratio"));
    }

    private static void GetDeckAnotherGeSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum fix_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckAnotherGeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddFixEffectParam(fix_logic, effect, effect.effect.GetInt("value") + effect.baseSkillLevel * effect.effect.GetInt("skill_ratio"));
    }

    private static void GetDeckAnotherGeSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum ratio_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckAnotherGeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddRatioEffectParam(ratio_logic, effect, effect.effect.GetFloat("percentage") + (float) effect.baseSkillLevel * effect.effect.GetFloat("skill_ratio"));
    }

    private static void GetDeckAnotherLeSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum fix_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckAnotherLeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddFixEffectParam(fix_logic, effect, effect.effect.GetInt("value") + effect.baseSkillLevel * effect.effect.GetInt("skill_ratio"));
    }

    private static void GetDeckAnotherLeSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum ratio_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckAnotherLeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddRatioEffectParam(ratio_logic, effect, effect.effect.GetFloat("percentage") + (float) effect.baseSkillLevel * effect.effect.GetFloat("skill_ratio"));
    }

    private static void GetDeckSameGeSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum fix_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckSameGeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddFixEffectParam(fix_logic, effect, effect.effect.GetInt("value") + effect.baseSkillLevel * effect.effect.GetInt("skill_ratio"));
    }

    private static void GetDeckSameGeSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum ratio_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckSameGeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddRatioEffectParam(ratio_logic, effect, effect.effect.GetFloat("percentage") + (float) effect.baseSkillLevel * effect.effect.GetFloat("skill_ratio"));
    }

    private static void GetDeckSameLeSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum fix_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckSameLeBuffDebuff(beUnit.skillEffects, fix_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddFixEffectParam(fix_logic, effect, effect.effect.GetInt("value") + effect.baseSkillLevel * effect.effect.GetInt("skill_ratio"));
    }

    private static void GetDeckSameLeSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BattleskillEffectLogicEnum ratio_logic,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BL.SkillEffect effect in BattleFuncs.GetEnabledDeckSameLeBuffDebuff(beUnit.skillEffects, ratio_logic, beUnit, deckUnits))
        beUnit.skillEffects.AddRatioEffectParam(ratio_logic, effect, effect.effect.GetFloat("percentage") + (float) effect.baseSkillLevel * effect.effect.GetFloat("skill_ratio"));
    }

    public static void createBattleSkillEffectParams(
      BL.ISkillEffectListUnit beUnit,
      IEnumerable<BL.Unit> deckUnits)
    {
      foreach (BattleskillEffectLogicEnum fix_logic in BattleFuncs.DeckEveryGeSkillAddEnum)
        BattleFuncs.GetDeckEveryGeSkillAdd(beUnit, fix_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum ratio_logic in BattleFuncs.DeckEveryGeSkillMulEnum)
        BattleFuncs.GetDeckEveryGeSkillMul(beUnit, ratio_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum fix_logic in BattleFuncs.DeckEveryLeSkillAddEnum)
        BattleFuncs.GetDeckEveryLeSkillAdd(beUnit, fix_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum ratio_logic in BattleFuncs.DeckEveryLeSkillMulEnum)
        BattleFuncs.GetDeckEveryLeSkillMul(beUnit, ratio_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum fix_logic in BattleFuncs.DeckAnotherGeSkillAddEnum)
        BattleFuncs.GetDeckAnotherGeSkillAdd(beUnit, fix_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum ratio_logic in BattleFuncs.DeckAnotherGeSkillMulEnum)
        BattleFuncs.GetDeckAnotherGeSkillMul(beUnit, ratio_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum fix_logic in BattleFuncs.DeckAnotherLeSkillAddEnum)
        BattleFuncs.GetDeckAnotherLeSkillAdd(beUnit, fix_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum ratio_logic in BattleFuncs.DeckAnotherLeSkillMulEnum)
        BattleFuncs.GetDeckAnotherLeSkillMul(beUnit, ratio_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum fix_logic in BattleFuncs.DeckSameGeSkillAddEnum)
        BattleFuncs.GetDeckSameGeSkillAdd(beUnit, fix_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum ratio_logic in BattleFuncs.DeckSameGeSkillMulEnum)
        BattleFuncs.GetDeckSameGeSkillMul(beUnit, ratio_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum fix_logic in BattleFuncs.DeckSameLeSkillAddEnum)
        BattleFuncs.GetDeckSameLeSkillAdd(beUnit, fix_logic, deckUnits);
      foreach (BattleskillEffectLogicEnum ratio_logic in BattleFuncs.DeckSameLeSkillMulEnum)
        BattleFuncs.GetDeckSameLeSkillMul(beUnit, ratio_logic, deckUnits);
    }

    public static bool isSealedSkillEffect(BL.ISkillEffectListUnit unit, BL.SkillEffect effect)
    {
      if (effect.unit == null || effect.effect.skill.skill_type != BattleskillSkillType.leader && (effect.effect.skill.skill_type != BattleskillSkillType.passive || !effect.effect.skill.range_effect_passive_skill))
        return unit.IsDontUseSkillEffect(effect);
      if (unit is BL.AIUnit)
      {
        foreach (BL.AIUnit aiUnit in BattleFuncs.env.aiUnitPositions.value)
        {
          if (aiUnit.originalUnit.index == effect.unit.index && aiUnit.originalUnit.isPlayerControl == effect.unit.isPlayerControl)
            return aiUnit.IsDontUseSkillEffect(effect);
        }
        foreach (BL.AIUnit aiUnit in BattleFuncs.env.aiDeads.value)
        {
          if (aiUnit.originalUnit.index == effect.unit.index && aiUnit.originalUnit.isPlayerControl == effect.unit.isPlayerControl)
            return aiUnit.IsDontUseSkillEffect(effect);
        }
      }
      return effect.unit.IsDontUseSkillEffect(effect);
    }

    [DebuggerHidden]
    public static IEnumerable<BL.ISkillEffectListUnit> getForceUnits(
      BL.ForceID forceId,
      bool isAI,
      bool isEnableOnly)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      BattleFuncs.\u003CgetForceUnits\u003Ec__Iterator26 forceUnits = new BattleFuncs.\u003CgetForceUnits\u003Ec__Iterator26()
      {
        isAI = isAI,
        forceId = forceId,
        isEnableOnly = isEnableOnly,
        \u003C\u0024\u003EisAI = isAI,
        \u003C\u0024\u003EforceId = forceId,
        \u003C\u0024\u003EisEnableOnly = isEnableOnly
      };
      // ISSUE: reference to a compiler-generated field
      forceUnits.\u0024PC = -2;
      return (IEnumerable<BL.ISkillEffectListUnit>) forceUnits;
    }

    public static HashSet<BL.ISkillEffectListUnit> getCharismaTargetUnits(
      BL.ISkillEffectListUnit unit,
      IEnumerable<BL.SkillEffect> effects)
    {
      HashSet<BL.ISkillEffectListUnit> charismaTargetUnits = new HashSet<BL.ISkillEffectListUnit>();
      if (!effects.Any<BL.SkillEffect>())
        return charismaTargetUnits;
      BL.ForceID[][] forceIdArray = new BL.ForceID[2][];
      if (BattleFuncs.env.getForceID(unit.originalUnit) == BL.ForceID.player)
      {
        forceIdArray[0] = BattleFuncs.ForceIDArrayPlayer;
        forceIdArray[1] = BattleFuncs.ForceIDArrayPlayerTarget;
      }
      else
      {
        forceIdArray[0] = BattleFuncs.ForceIDArrayEnemy;
        forceIdArray[1] = BattleFuncs.ForceIDArrayEnemyTarget;
      }
      for (int effectTarget = 0; effectTarget <= 1; ++effectTarget)
      {
        if (effects.Any<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => x.effect.GetInt("effect_target") == effectTarget)))
        {
          foreach (BL.ISkillEffectListUnit skillEffectListUnit in ((IEnumerable<BL.ForceID>) forceIdArray[effectTarget]).SelectMany<BL.ForceID, BL.ISkillEffectListUnit>((Func<BL.ForceID, IEnumerable<BL.ISkillEffectListUnit>>) (x => BattleFuncs.getForceUnits(x, unit is BL.AIUnit, true))))
            charismaTargetUnits.Add(skillEffectListUnit);
        }
      }
      return charismaTargetUnits;
    }

    private static IEnumerable<BL.SkillEffect> GetEnabledFieldDamageFluctuateBuffDebuff(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit target,
      int range)
    {
      return self.WhereAndGroupBy(e, (Func<List<BL.SkillEffect>, BL.SkillEffect>) (x => x.OrderBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => Mathf.Abs(range - effect.effect.GetInt(nameof (range))))).ThenBy<BL.SkillEffect, int>((Func<BL.SkillEffect, int>) (effect => effect.effectId)).FirstOrDefault<BL.SkillEffect>()), (Func<List<BL.SkillEffect>, List<BL.SkillEffect>>) (skills => skills.Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (effect =>
      {
        if (BattleFuncs.isSealedSkillEffect(unit, effect) || effect.effect.GetInt("unit_id") != 0 && effect.effect.GetInt("unit_id") != unit.originalUnit.unit.ID || effect.effect.GetInt("target_gear_kind_id") != 0 && effect.effect.GetInt("target_gear_kind_id") != target.originalUnit.unit.kind.ID || effect.effect.GetInt("target_element") != 0 && (CommonElement) effect.effect.GetInt("target_element") != target.originalUnit.playerUnit.GetElement() || effect.effect.GetInt("target_job_id") != 0 && effect.effect.GetInt("target_job_id") != target.originalUnit.job.ID || effect.effect.GetInt("target_family_id") != 0 && !target.originalUnit.unit.HasFamily((UnitFamily) effect.effect.GetInt("target_family_id")) || effect.effect.GetInt("target_character_id") != 0 && effect.effect.GetInt("target_character_id") != target.originalUnit.unit.character.ID)
          return false;
        return effect.effect.GetInt("target_unit_id") == 0 || effect.effect.GetInt("target_unit_id") == target.originalUnit.unit.ID;
      })).ToList<BL.SkillEffect>()));
    }

    private static int GetFieldDamageFluctuateSkillAdd(
      BL.ISkillEffectListUnit beUnit,
      BL.ISkillEffectListUnit beTarget,
      int range)
    {
      int fluctuateSkillAdd = 0;
      foreach (BL.SkillEffect skillEffect in BattleFuncs.GetEnabledFieldDamageFluctuateBuffDebuff(beUnit.skillEffects, BattleskillEffectLogicEnum.after_duel_damage_fluctuate_fix, beUnit, beTarget, range))
        fluctuateSkillAdd += skillEffect.effect.GetInt("damage_value") + skillEffect.baseSkillLevel * skillEffect.effect.GetInt("skill_ratio");
      return fluctuateSkillAdd;
    }

    private static float GetFieldDamageFluctuateSkillMul(
      BL.ISkillEffectListUnit beUnit,
      BL.ISkillEffectListUnit beTarget,
      int range)
    {
      float fluctuateSkillMul = 1f;
      foreach (BL.SkillEffect skillEffect in BattleFuncs.GetEnabledFieldDamageFluctuateBuffDebuff(beUnit.skillEffects, BattleskillEffectLogicEnum.after_duel_damage_fluctuate_ratio, beUnit, beTarget, range))
        fluctuateSkillMul *= skillEffect.effect.GetFloat("damage_percentage") + (float) skillEffect.baseSkillLevel * skillEffect.effect.GetFloat("skill_ratio");
      return fluctuateSkillMul;
    }

    public static int applyFieldDamageFluctuate(
      BL.ISkillEffectListUnit atk,
      BL.ISkillEffectListUnit def,
      BL.ISkillEffectListUnit invokeUnit,
      BL.ISkillEffectListUnit damageUnit,
      BattleskillEffect effect,
      int damage)
    {
      if (damage < 0)
        return damage;
      BL.ISkillEffectListUnit beTarget = BattleFuncs.env.getForceID(atk.originalUnit) != BattleFuncs.env.getForceID(damageUnit.originalUnit) ? atk : def;
      BL.ISkillEffectListUnit unit = effect.GetInt("is_range_from_enemy") != 0 ? (atk != invokeUnit ? atk : def) : invokeUnit;
      int range = BL.fieldDistance(BattleFuncs.iSkillEffectListUnitToUnitPosition(damageUnit), BattleFuncs.iSkillEffectListUnitToUnitPosition(unit));
      int fluctuateSkillAdd = BattleFuncs.GetFieldDamageFluctuateSkillAdd(damageUnit, beTarget, range);
      float fluctuateSkillMul = BattleFuncs.GetFieldDamageFluctuateSkillMul(damageUnit, beTarget, range);
      damage = (int) ((double) damage * (double) fluctuateSkillMul) + fluctuateSkillAdd;
      if (damage < 0)
        damage = 0;
      return damage;
    }

    public static void createAsterNodeCache(BL blenv)
    {
      List<BL.Panel> panelList = new List<BL.Panel>();
      for (int row = 0; row < blenv.getFieldHeight(); ++row)
      {
        for (int column = 0; column < blenv.getFieldWidth(); ++column)
        {
          if (blenv.getFieldPanel(row, column) != null)
            panelList.Add(blenv.getFieldPanel(row, column));
          else
            Debug.LogError((object) (" === ouch! フィールドデータがおかしい(" + (object) row + ", " + (object) column + ")"));
        }
      }
      for (int index = 0; index < 2; ++index)
      {
        Dictionary<UnitMoveType, BattleFuncs.AsterNode[]> dictionary = new Dictionary<UnitMoveType, BattleFuncs.AsterNode[]>();
        foreach (BL.UnitPosition unitPosition in blenv.unitPositions.value)
        {
          if (unitPosition.asterNodeCache == null)
            unitPosition.asterNodeCache = new BattleFuncs.AsterNode[2][];
          if (dictionary.ContainsKey(unitPosition.unit.unit.job.move_type))
          {
            unitPosition.asterNodeCache[index] = dictionary[unitPosition.unit.unit.job.move_type];
          }
          else
          {
            unitPosition.asterNodeCache[index] = BattleFuncs.createNodes((IEnumerable<BL.Panel>) panelList, unitPosition.unit, (BL.Panel) null, (BL.Panel) null, out int _, out int _, index == 1);
            dictionary[unitPosition.unit.unit.job.move_type] = unitPosition.asterNodeCache[index];
          }
        }
      }
    }

    public static HashSet<BL.ISkillEffectListUnit> applyDuelSkillEffects(
      DuelResult duelResult,
      BL.ISkillEffectListUnit atk,
      BL.ISkillEffectListUnit def,
      BL env,
      Action<BL.ISkillEffectListUnit, int> addHpFunction = null,
      Action<BL.ISkillEffectListUnit, int> subHpFunction = null,
      Action<BattleskillSkill, BL.Unit, Dictionary<BL.Unit, Tuple<int, int>>> snakeFunction = null,
      Dictionary<Tuple<BL.Unit, BattleskillSkill>, List<BL.Unit>> lifeAbsorbSkillTarget = null,
      Dictionary<Tuple<BL.Unit, BattleskillSkill>, List<BL.Unit>> curseReflectionSkillTarget = null)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      BattleFuncs.\u003CapplyDuelSkillEffects\u003Ec__AnonStoreyC7F effectsCAnonStoreyC7F1 = new BattleFuncs.\u003CapplyDuelSkillEffects\u003Ec__AnonStoreyC7F();
      // ISSUE: reference to a compiler-generated field
      effectsCAnonStoreyC7F1.snakeFunction = snakeFunction;
      // ISSUE: reference to a compiler-generated field
      effectsCAnonStoreyC7F1.duelResult = duelResult;
      // ISSUE: reference to a compiler-generated field
      effectsCAnonStoreyC7F1.atk = atk;
      // ISSUE: reference to a compiler-generated field
      effectsCAnonStoreyC7F1.def = def;
      // ISSUE: reference to a compiler-generated field
      if (effectsCAnonStoreyC7F1.duelResult.disableDuelSkillEffects)
        return new HashSet<BL.ISkillEffectListUnit>();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      BattleFuncs.apllyDuelRemoveSleepEffect(effectsCAnonStoreyC7F1.duelResult, effectsCAnonStoreyC7F1.atk, effectsCAnonStoreyC7F1.def);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      BattleFuncs.consumeSkillEffects(effectsCAnonStoreyC7F1.duelResult.turns, effectsCAnonStoreyC7F1.atk, effectsCAnonStoreyC7F1.def);
      // ISSUE: reference to a compiler-generated field
      bool isAI = effectsCAnonStoreyC7F1.atk is BL.AIUnit;
      Dictionary<BL.ISkillEffectListUnit, int> dictionary1 = new Dictionary<BL.ISkillEffectListUnit, int>();
      IEnumerable<BL.ISkillEffectListUnit> skillEffectListUnits = ((IEnumerable<BL.ForceID>) new BL.ForceID[3]
      {
        BL.ForceID.player,
        BL.ForceID.enemy,
        BL.ForceID.neutral
      }).SelectMany<BL.ForceID, BL.ISkillEffectListUnit>((Func<BL.ForceID, IEnumerable<BL.ISkillEffectListUnit>>) (x => BattleFuncs.getForceUnits(x, isAI, true)));
      foreach (BL.ISkillEffectListUnit skillEffectListUnit in skillEffectListUnits)
      {
        BL.ISkillEffectListUnit unit = skillEffectListUnit;
        dictionary1[unit] = unit.skillEffects.All().Count<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => !BattleFuncs.isSealedSkillEffect(unit, x)));
      }
      // ISSUE: reference to a compiler-generated field
      foreach (BL.DuelTurn turn in effectsCAnonStoreyC7F1.duelResult.turns)
      {
        for (int index = 0; index < turn.investUnit.Length; ++index)
        {
          BL.ISkillEffectListUnit unit = turn.investUnit[index];
          BL.Skill skill = new BL.Skill()
          {
            id = turn.investSkillIds[index]
          };
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          BL.ISkillEffectListUnit skillEffectListUnit = !turn.isAtackker ? effectsCAnonStoreyC7F1.atk : effectsCAnonStoreyC7F1.def;
          List<BL.SkillEffect> list1 = BattleFuncs.getEnabledCharismaEffects(unit).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => !BattleFuncs.isSealedSkillEffect(unit, x))).ToList<BL.SkillEffect>();
          if (!isAI)
          {
            unit = (BL.ISkillEffectListUnit) unit.originalUnit;
            unit.originalUnit.commit();
          }
          if (skill.skill.target_type == BattleskillTargetType.complex_single || skill.skill.target_type == BattleskillTargetType.complex_range)
          {
            bool flag = env.getForceID(unit.originalUnit) == env.getForceID(skillEffectListUnit.originalUnit);
            foreach (BattleskillEffect effect in skill.skill.Effects)
            {
              if (effect.effect_logic.Enum != BattleskillEffectLogicEnum.snake_venom)
              {
                if (!effect.is_targer_enemy)
                {
                  if (!flag)
                    unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
                }
                else if (flag)
                  unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
              }
            }
          }
          else
          {
            foreach (BattleskillEffect effect in skill.skill.Effects)
            {
              if (effect.effect_logic.Enum != BattleskillEffectLogicEnum.snake_venom)
                unit.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
            }
          }
          List<BL.SkillEffect> list2 = BattleFuncs.getEnabledCharismaEffects(unit).Where<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => !BattleFuncs.isSealedSkillEffect(unit, x))).ToList<BL.SkillEffect>();
          IEnumerable<BL.SkillEffect> effects = list1.Union<BL.SkillEffect>((IEnumerable<BL.SkillEffect>) list2).Except<BL.SkillEffect>(list1.Intersect<BL.SkillEffect>((IEnumerable<BL.SkillEffect>) list2));
          foreach (BL.ISkillEffectListUnit charismaTargetUnit in BattleFuncs.getCharismaTargetUnits(unit, effects))
            charismaTargetUnit.skillEffects.commit();
        }
      }
      foreach (BL.ISkillEffectListUnit skillEffectListUnit in skillEffectListUnits)
      {
        BL.ISkillEffectListUnit unit = skillEffectListUnit;
        if (unit.skillEffects.All().Count<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => !BattleFuncs.isSealedSkillEffect(unit, x))) != dictionary1[unit])
          unit.skillEffects.commit();
      }
      // ISSUE: reference to a compiler-generated field
      effectsCAnonStoreyC7F1.deads = new HashSet<BL.ISkillEffectListUnit>();
      // ISSUE: reference to a compiler-generated field
      if (!effectsCAnonStoreyC7F1.duelResult.isHeal)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        BattleFuncs.applyDuelDamageSkillEffects(effectsCAnonStoreyC7F1.duelResult, effectsCAnonStoreyC7F1.atk, effectsCAnonStoreyC7F1.def, env, effectsCAnonStoreyC7F1.deads, addHpFunction, subHpFunction, effectsCAnonStoreyC7F1.snakeFunction, lifeAbsorbSkillTarget, curseReflectionSkillTarget);
        HashSet<BL.ISkillEffectListUnit> isInvokedSnakeVenom = new HashSet<BL.ISkillEffectListUnit>();
        Dictionary<BL.ISkillEffectListUnit, BattleskillEffect> snakeVenomUnitEffect = new Dictionary<BL.ISkillEffectListUnit, BattleskillEffect>();
        BL.Skill snakeVenomSkill = (BL.Skill) null;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        BattleFuncs.mapDuelSkillEffects(effectsCAnonStoreyC7F1.duelResult, effectsCAnonStoreyC7F1.atk, effectsCAnonStoreyC7F1.def, env, (Action<Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill>>) null, (Action<Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill, bool, bool>>) (data =>
        {
          foreach (BattleskillEffect effect in data.Item5.skill.Effects)
          {
            if (effect.effect_logic.Enum == BattleskillEffectLogicEnum.snake_venom && (!data.Item6 || effect.is_targer_enemy == data.Item7))
            {
              snakeVenomUnitEffect[data.Item4] = effect;
              snakeVenomSkill = data.Item5;
            }
          }
        }), (Action<Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, IEnumerable<BL.UnitPosition>, BL.Skill, bool, bool>>) (data =>
        {
          foreach (BL.UnitPosition unitPosition in data.Item4)
          {
            BL.ISkillEffectListUnit key = !(unitPosition is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) unitPosition.unit : unitPosition as BL.ISkillEffectListUnit;
            foreach (BattleskillEffect effect in data.Item5.skill.Effects)
            {
              if (effect.effect_logic.Enum == BattleskillEffectLogicEnum.snake_venom && (!data.Item6 || effect.is_targer_enemy == data.Item7))
              {
                if (key != data.Item3)
                  snakeVenomUnitEffect[key] = effect;
                snakeVenomSkill = data.Item5;
              }
            }
          }
        }), (Action<BL.DuelTurn, BL.ISkillEffectListUnit>) ((turn, myself) =>
        {
          // ISSUE: variable of a compiler-generated type
          BattleFuncs.\u003CapplyDuelSkillEffects\u003Ec__AnonStoreyC7F effectsCAnonStoreyC7F = effectsCAnonStoreyC7F1;
          // ISSUE: variable of a compiler-generated type
          BattleFuncs.\u003CapplyDuelSkillEffects\u003Ec__AnonStoreyC7E effectsCAnonStoreyC7E = this;
          BL.DuelTurn turn1 = turn;
          if (!isInvokedSnakeVenom.Contains(myself) && snakeVenomSkill != null && snakeVenomUnitEffect.Count >= 1)
          {
            Dictionary<BL.Unit, Tuple<int, int>> dictionary2 = snakeFunction == null ? (Dictionary<BL.Unit, Tuple<int, int>>) null : new Dictionary<BL.Unit, Tuple<int, int>>();
            isInvokedSnakeVenom.Add(myself);
            // ISSUE: reference to a compiler-generated field
            int num = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Sum<BL.DuelTurn>((Func<BL.DuelTurn, int>) (x => x.isAtackker == turn1.isAtackker && ((IEnumerable<BL.Skill>) x.invokeDuelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (skill => skill == effectsCAnonStoreyC7E.snakeVenomSkill)) ? x.dispDamage : 0));
            foreach (BL.ISkillEffectListUnit key in snakeVenomUnitEffect.Keys)
            {
              int hp = key.hp;
              BattleskillEffect effect = snakeVenomUnitEffect[key];
              if (hp >= 1)
              {
                int minHp = effect.GetInt("min_hp");
                int damage1 = effect.GetInt("venom_value") + Mathf.CeilToInt((float) key.originalUnit.parameter.Hp * effect.GetFloat("venom_hp_percentage")) + Mathf.CeilToInt((float) num * effect.GetFloat("venom_damage_percentage"));
                int damage2 = BattleFuncs.applyFieldDamageFluctuate(atk, def, myself, key, effect, damage1);
                BattleFuncs.applyHpDamage(atk, def, myself, key, damage2, minHp, deads, (Action<BL.ISkillEffectListUnit, int>) null);
                if (dictionary2 != null)
                  dictionary2[key as BL.Unit] = new Tuple<int, int>(hp, key.hp);
              }
            }
            if (dictionary2 != null)
              snakeFunction(snakeVenomSkill.skill, myself as BL.Unit, dictionary2);
          }
          snakeVenomUnitEffect.Clear();
          snakeVenomSkill = (BL.Skill) null;
        }), true);
      }
      // ISSUE: reference to a compiler-generated field
      return effectsCAnonStoreyC7F1.deads;
    }

    private static void apllyDuelRemoveSleepEffect(
      DuelResult duelResult,
      BL.ISkillEffectListUnit atk,
      BL.ISkillEffectListUnit def)
    {
      if (atk != null && ((IEnumerable<BL.DuelTurn>) duelResult.turns).Any<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => !x.isAtackker && x.dispDamage >= 1)))
        atk.skillEffects.RemoveEffect(1000418, BattleFuncs.env, atk);
      if (def == null || !((IEnumerable<BL.DuelTurn>) duelResult.turns).Any<BL.DuelTurn>((Func<BL.DuelTurn, bool>) (x => x.isAtackker && x.dispDamage >= 1)))
        return;
      def.skillEffects.RemoveEffect(1000418, BattleFuncs.env, atk);
    }

    private static void mapDuelSkillEffects(
      DuelResult duelResult,
      BL.ISkillEffectListUnit atk,
      BL.ISkillEffectListUnit def,
      BL env,
      Action<Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill>> mapAlimentFunction,
      Action<Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill, bool, bool>> mapGiveOneFunction,
      Action<Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, IEnumerable<BL.UnitPosition>, BL.Skill, bool, bool>> mapGiveMultiFunction,
      Action<BL.DuelTurn, BL.ISkillEffectListUnit> turnFunction,
      bool isCheckSingleRange)
    {
      bool isAI = atk is BL.AIUnit;
      foreach (BL.DuelTurn turn in duelResult.turns)
      {
        BL.ISkillEffectListUnit myself;
        BL.ISkillEffectListUnit enemy;
        if (turn.isAtackker)
        {
          myself = atk;
          enemy = def;
        }
        else
        {
          myself = def;
          enemy = atk;
        }
        if (mapAlimentFunction != null && turn.invokeAilmentSkills != null)
        {
          BL.ISkillEffectListUnit skillEffectListUnit = !turn.isAtackker ? atk : def;
          foreach (BL.Skill invokeAilmentSkill in turn.invokeAilmentSkills)
            mapAlimentFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill>(turn, myself, enemy, skillEffectListUnit, invokeAilmentSkill));
        }
        if (mapGiveOneFunction != null && mapGiveMultiFunction != null && turn.invokeGiveSkills != null)
        {
          BL.ForceID[] forceIds1 = new BL.ForceID[1]
          {
            env.getForceID(myself.originalUnit)
          };
          BL.ForceID[] forceIds2 = new BL.ForceID[1]
          {
            env.getForceID(enemy.originalUnit)
          };
          int[] range = new int[2];
          foreach (BL.Skill invokeGiveSkill in turn.invokeGiveSkills)
          {
            range[0] = invokeGiveSkill.skill.min_range;
            range[1] = invokeGiveSkill.skill.max_range;
            BL.Unit originalUnit = myself.originalUnit;
            if (((IEnumerable<BattleskillEffect>) invokeGiveSkill.skill.Effects).Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.snake_venom)).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.GetInt("is_range_from_enemy") != 0)))
              originalUnit = enemy.originalUnit;
            switch (invokeGiveSkill.skill.target_type)
            {
              case BattleskillTargetType.myself:
              case BattleskillTargetType.player_single:
                if (!isCheckSingleRange || range[0] == 0 && range[1] == 0 || BattleFuncs.getTargets(originalUnit, range, forceIds1, isAI).Any<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (up => (!(up is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) up.unit : up as BL.ISkillEffectListUnit) == myself)))
                {
                  mapGiveOneFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill, bool, bool>(turn, myself, enemy, myself, invokeGiveSkill, false, false));
                  break;
                }
                break;
              case BattleskillTargetType.player_range:
                List<BL.UnitPosition> targets1 = BattleFuncs.getTargets(originalUnit, range, forceIds1, isAI);
                mapGiveMultiFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, IEnumerable<BL.UnitPosition>, BL.Skill, bool, bool>(turn, myself, enemy, (IEnumerable<BL.UnitPosition>) targets1, invokeGiveSkill, false, false));
                break;
              case BattleskillTargetType.enemy_single:
                if (!isCheckSingleRange || range[0] == 0 && range[1] == 0 || BattleFuncs.getTargets(originalUnit, range, forceIds2, isAI).Any<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (up => (!(up is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) up.unit : up as BL.ISkillEffectListUnit) == enemy)))
                {
                  mapGiveOneFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill, bool, bool>(turn, myself, enemy, enemy, invokeGiveSkill, false, false));
                  break;
                }
                break;
              case BattleskillTargetType.enemy_range:
                List<BL.UnitPosition> targets2 = BattleFuncs.getTargets(originalUnit, range, forceIds2, isAI);
                mapGiveMultiFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, IEnumerable<BL.UnitPosition>, BL.Skill, bool, bool>(turn, myself, enemy, (IEnumerable<BL.UnitPosition>) targets2, invokeGiveSkill, false, true));
                break;
              case BattleskillTargetType.complex_single:
                bool flag1 = true;
                bool flag2 = true;
                if (isCheckSingleRange && (range[0] != 0 || range[1] != 0))
                {
                  flag1 = BattleFuncs.getTargets(originalUnit, range, forceIds2, isAI).Any<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (up => (!(up is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) up.unit : up as BL.ISkillEffectListUnit) == enemy));
                  flag2 = BattleFuncs.getTargets(originalUnit, range, forceIds1, isAI).Any<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (up => (!(up is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) up.unit : up as BL.ISkillEffectListUnit) == myself));
                }
                if (flag1)
                  mapGiveOneFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill, bool, bool>(turn, myself, enemy, enemy, invokeGiveSkill, true, true));
                if (flag2)
                {
                  mapGiveOneFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, BL.Skill, bool, bool>(turn, myself, enemy, myself, invokeGiveSkill, true, false));
                  break;
                }
                break;
              case BattleskillTargetType.complex_range:
                List<BL.UnitPosition> targets3 = BattleFuncs.getTargets(originalUnit, range, forceIds1, isAI);
                List<BL.UnitPosition> targets4 = BattleFuncs.getTargets(originalUnit, range, forceIds2, isAI);
                mapGiveMultiFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, IEnumerable<BL.UnitPosition>, BL.Skill, bool, bool>(turn, myself, enemy, (IEnumerable<BL.UnitPosition>) targets4, invokeGiveSkill, true, true));
                mapGiveMultiFunction(new Tuple<BL.DuelTurn, BL.ISkillEffectListUnit, BL.ISkillEffectListUnit, IEnumerable<BL.UnitPosition>, BL.Skill, bool, bool>(turn, myself, enemy, (IEnumerable<BL.UnitPosition>) targets3, invokeGiveSkill, true, false));
                break;
            }
          }
        }
        if (turnFunction != null)
          turnFunction(turn, myself);
      }
    }

    private static void applyDuelDamageSkillEffects(
      DuelResult duelResult,
      BL.ISkillEffectListUnit atk,
      BL.ISkillEffectListUnit def,
      BL env,
      HashSet<BL.ISkillEffectListUnit> deads,
      Action<BL.ISkillEffectListUnit, int> addHpFunction,
      Action<BL.ISkillEffectListUnit, int> subHpFunction,
      Action<BattleskillSkill, BL.Unit, Dictionary<BL.Unit, Tuple<int, int>>> snakeFunction,
      Dictionary<Tuple<BL.Unit, BattleskillSkill>, List<BL.Unit>> lifeAbsorbSkillTarget,
      Dictionary<Tuple<BL.Unit, BattleskillSkill>, List<BL.Unit>> curseReflectionSkillTarget)
    {
      bool isAI = atk is BL.AIUnit;
      bool isInvokedAmbush = duelResult.moveUnit != atk.originalUnit;
      BL.ISkillEffectListUnit myself = isInvokedAmbush ? def : atk;
      BL.ISkillEffectListUnit enemy = isInvokedAmbush ? atk : def;
      int is_attack = 1;
      BL.ForceID[] forceIds1 = new BL.ForceID[1]
      {
        env.getForceID(myself.originalUnit)
      };
      BL.ForceID[] forceIds2 = new BL.ForceID[1]
      {
        env.getForceID(enemy.originalUnit)
      };
      int[] iWork = new int[1];
      Dictionary<BL.ISkillEffectListUnit, int> lifeAbsorbTargetHeal = new Dictionary<BL.ISkillEffectListUnit, int>();
      BL.ISkillEffectListUnit[] curseReflectionInvokeUnit = new BL.ISkillEffectListUnit[2];
      Dictionary<BL.ISkillEffectListUnit, int>[] curseReflectionTargetDamage = new Dictionary<BL.ISkillEffectListUnit, int>[2];
      BL.ISkillEffectListUnit[] snakeVenomInvokeUnit = new BL.ISkillEffectListUnit[2];
      BL.SkillEffect[] snakeVenomEffect = new BL.SkillEffect[2];
      Dictionary<BL.ISkillEffectListUnit, int>[] snakeVenomUnitDamage = new Dictionary<BL.ISkillEffectListUnit, int>[2];
      int[] snakeVenomInvokeTurn = new int[2];
      Dictionary<BattleskillEffectLogicEnum, Tuple<Func<BL.SkillEffect, bool>, Action<BL.SkillEffect, BL.ISkillEffectListUnit>>> dictionary1 = new Dictionary<BattleskillEffectLogicEnum, Tuple<Func<BL.SkillEffect, bool>, Action<BL.SkillEffect, BL.ISkillEffectListUnit>>>()
      {
        {
          BattleskillEffectLogicEnum.life_absorb,
          new Tuple<Func<BL.SkillEffect, bool>, Action<BL.SkillEffect, BL.ISkillEffectListUnit>>((Func<BL.SkillEffect, bool>) (effect =>
          {
            if (effect.effect.HasKey("element"))
            {
              int num = effect.effect.GetInt("element");
              if (num != 0 && (CommonElement) num != myself.originalUnit.playerUnit.GetElement())
                return false;
            }
            if (effect.effect.HasKey("target_element"))
            {
              int num = effect.effect.GetInt("target_element");
              if (num != 0 && (CommonElement) num != enemy.originalUnit.playerUnit.GetElement())
                return false;
            }
            if (effect.effect.GetInt("condition") == 1)
              return enemy.hp <= 0;
            return effect.effect.GetInt("condition") != 2 && enemy.hp <= 0 || myself.hp <= 0;
          }), (Action<BL.SkillEffect, BL.ISkillEffectListUnit>) ((effect, unit) =>
          {
            if (!lifeAbsorbTargetHeal.ContainsKey(unit))
              lifeAbsorbTargetHeal[unit] = 0;
            Dictionary<BL.ISkillEffectListUnit, int> dictionary2;
            BL.ISkillEffectListUnit key1;
            (dictionary2 = lifeAbsorbTargetHeal)[key1 = unit] = dictionary2[key1] + effect.baseSkillLevel;
            Dictionary<BL.ISkillEffectListUnit, int> dictionary3;
            BL.ISkillEffectListUnit key2;
            (dictionary3 = lifeAbsorbTargetHeal)[key2 = unit] = dictionary3[key2] + effect.effect.GetInt("value");
            Dictionary<BL.ISkillEffectListUnit, int> dictionary4;
            BL.ISkillEffectListUnit key3;
            (dictionary4 = lifeAbsorbTargetHeal)[key3 = unit] = dictionary4[key3] + Mathf.CeilToInt((float) unit.originalUnit.parameter.Hp * effect.effect.GetFloat("percentage"));
            if (lifeAbsorbSkillTarget == null)
              return;
            Tuple<BL.Unit, BattleskillSkill> key4 = new Tuple<BL.Unit, BattleskillSkill>(myself as BL.Unit, effect.baseSkill);
            if (!lifeAbsorbSkillTarget.ContainsKey(key4))
              lifeAbsorbSkillTarget[key4] = new List<BL.Unit>();
            if (lifeAbsorbSkillTarget[key4].Contains(unit as BL.Unit))
              return;
            lifeAbsorbSkillTarget[key4].Add(unit as BL.Unit);
          }))
        },
        {
          BattleskillEffectLogicEnum.curse_reflection,
          new Tuple<Func<BL.SkillEffect, bool>, Action<BL.SkillEffect, BL.ISkillEffectListUnit>>((Func<BL.SkillEffect, bool>) (effect =>
          {
            int num1 = effect.effect.GetInt("target_gear_kind_id");
            if (num1 != 0 && num1 != enemy.originalUnit.unit.kind.ID)
              return false;
            if (effect.effect.HasKey("target_element"))
            {
              int num2 = effect.effect.GetInt("target_element");
              if (num2 != 0 && (CommonElement) num2 != enemy.originalUnit.playerUnit.GetElement())
                return false;
            }
            int num3 = effect.effect.GetInt("condition");
            bool flag = true;
            switch (num3)
            {
              case 1:
                flag = myself.hp >= 1;
                break;
              case 2:
                flag = myself.hp <= 0;
                break;
            }
            if (flag && curseReflectionInvokeUnit[is_attack - 1] == null)
            {
              curseReflectionInvokeUnit[is_attack - 1] = myself;
              curseReflectionTargetDamage[is_attack - 1] = new Dictionary<BL.ISkillEffectListUnit, int>();
              bool isa = is_attack == 1;
              if (isInvokedAmbush)
                isa = !isa;
              iWork[0] = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Sum<BL.DuelTurn>((Func<BL.DuelTurn, int>) (x => x.isAtackker != isa ? x.dispDamage : 0));
            }
            return flag;
          }), (Action<BL.SkillEffect, BL.ISkillEffectListUnit>) ((effect, unit) =>
          {
            int damage = effect.effect.GetInt("value") + Mathf.CeilToInt((float) iWork[0] * effect.effect.GetFloat("percentage"));
            if (damage == 0)
              return;
            int num = BattleFuncs.applyFieldDamageFluctuate(atk, def, myself, unit, effect.effect, damage);
            int index = is_attack - 1;
            if (!curseReflectionTargetDamage[index].ContainsKey(unit))
              curseReflectionTargetDamage[index][unit] = 0;
            Dictionary<BL.ISkillEffectListUnit, int> dictionary5;
            BL.ISkillEffectListUnit key5;
            (dictionary5 = curseReflectionTargetDamage[index])[key5 = unit] = dictionary5[key5] + num;
            if (curseReflectionSkillTarget == null)
              return;
            Tuple<BL.Unit, BattleskillSkill> key6 = new Tuple<BL.Unit, BattleskillSkill>(myself as BL.Unit, effect.baseSkill);
            if (!curseReflectionSkillTarget.ContainsKey(key6))
              curseReflectionSkillTarget[key6] = new List<BL.Unit>();
            if (curseReflectionSkillTarget[key6].Contains(unit as BL.Unit))
              return;
            curseReflectionSkillTarget[key6].Add(unit as BL.Unit);
          }))
        },
        {
          BattleskillEffectLogicEnum.snake_venom_damage,
          new Tuple<Func<BL.SkillEffect, bool>, Action<BL.SkillEffect, BL.ISkillEffectListUnit>>((Func<BL.SkillEffect, bool>) (effect =>
          {
            if (effect.effect.HasKey("target_element"))
            {
              int num = effect.effect.GetInt("target_element");
              if (num != 0 && (CommonElement) num != enemy.originalUnit.playerUnit.GetElement())
                return false;
            }
            int index1 = is_attack - 1;
            if (snakeVenomInvokeUnit[index1] != null)
              return false;
            snakeVenomInvokeUnit[index1] = myself;
            snakeVenomEffect[index1] = effect;
            snakeVenomUnitDamage[index1] = new Dictionary<BL.ISkillEffectListUnit, int>();
            bool flag = is_attack == 1;
            if (isInvokedAmbush)
              flag = !flag;
            snakeVenomInvokeTurn[index1] = 0;
            iWork[0] = 0;
            for (int index2 = ((IEnumerable<BL.DuelTurn>) duelResult.turns).Count<BL.DuelTurn>() - 1; index2 >= 0; --index2)
            {
              BL.DuelTurn turn = duelResult.turns[index2];
              if (turn.isAtackker == flag && turn.invokeGiveSkills != null && ((IEnumerable<BL.Skill>) turn.invokeGiveSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (skill => ((IEnumerable<BattleskillEffect>) skill.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (e => e.skill.ID == effect.baseSkillId)))))
              {
                snakeVenomInvokeTurn[index1] = index2;
                iWork[0] += turn.dispDamage;
              }
            }
            return true;
          }), (Action<BL.SkillEffect, BL.ISkillEffectListUnit>) ((effect, unit) =>
          {
            if (unit == enemy && effect.effect.GetInt("effect_target") != 3 && (effect.effect.GetInt("min_range") != 0 || effect.effect.GetInt("max_range") != 0))
              return;
            int damage = effect.effect.GetInt("venom_value") + Mathf.CeilToInt((float) unit.originalUnit.parameter.Hp * effect.effect.GetFloat("venom_hp_percentage")) + Mathf.CeilToInt((float) iWork[0] * effect.effect.GetFloat("venom_damage_percentage"));
            int num = BattleFuncs.applyFieldDamageFluctuate(atk, def, myself, unit, effect.effect, damage);
            snakeVenomUnitDamage[is_attack - 1][unit] = num;
          }))
        }
      };
      foreach (BattleskillEffectLogicEnum key in dictionary1.Keys)
      {
        for (is_attack = 1; is_attack <= 2; ++is_attack)
        {
          foreach (BL.SkillEffect effect in myself.skillEffects.Where(key))
          {
            if ((effect.effect.GetInt("is_attack_nc") == 0 || effect.effect.GetInt("is_attack_nc") == is_attack) && !BattleFuncs.isSkillsAndEffectsInvalid(myself, enemy) && !BattleFuncs.isSealedSkillEffect(myself, effect) && dictionary1[key].Item1(effect))
            {
              int[] range = new int[2]
              {
                effect.effect.GetInt("min_range"),
                effect.effect.GetInt("max_range")
              };
              BL.Unit unit = effect.effect.GetInt("is_range_from_enemy") != 0 ? enemy.originalUnit : myself.originalUnit;
              int num = effect.effect.GetInt("effect_target");
              List<BL.UnitPosition> source;
              switch (num)
              {
                case 0:
                case 2:
                  source = BattleFuncs.getTargets(unit, range, forceIds1, isAI);
                  if (num == 2)
                  {
                    source = source.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x) == myself)).ToList<BL.UnitPosition>();
                    break;
                  }
                  break;
                default:
                  source = BattleFuncs.getTargets(unit, range, forceIds2, isAI);
                  if (num == 3)
                  {
                    source = source.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => BattleFuncs.unitPositionToISkillEffectListUnit(x) == enemy)).ToList<BL.UnitPosition>();
                    break;
                  }
                  break;
              }
              foreach (BL.UnitPosition unitPosition in source)
              {
                BL.ISkillEffectListUnit skillEffectListUnit = !(unitPosition is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) unitPosition.unit : unitPosition as BL.ISkillEffectListUnit;
                if (skillEffectListUnit != null)
                  dictionary1[key].Item2(effect, skillEffectListUnit);
              }
            }
          }
          BL.ISkillEffectListUnit skillEffectListUnit1 = myself;
          myself = enemy;
          enemy = skillEffectListUnit1;
          BL.ForceID[] forceIdArray = forceIds1;
          forceIds1 = forceIds2;
          forceIds2 = forceIdArray;
        }
      }
      if (lifeAbsorbTargetHeal.Count >= 1)
      {
        foreach (BL.ISkillEffectListUnit key7 in lifeAbsorbTargetHeal.Keys)
        {
          int hp = key7.hp;
          if (hp >= 1)
          {
            key7.hp += lifeAbsorbTargetHeal[key7];
            if (addHpFunction != null)
              addHpFunction(key7, hp);
          }
          else if (lifeAbsorbSkillTarget != null)
          {
            foreach (Tuple<BL.Unit, BattleskillSkill> key8 in lifeAbsorbSkillTarget.Keys)
              lifeAbsorbSkillTarget[key8].Remove(key7 as BL.Unit);
          }
        }
      }
      if (curseReflectionInvokeUnit[0] != null || curseReflectionInvokeUnit[1] != null)
      {
        if (curseReflectionSkillTarget != null)
        {
          foreach (Tuple<BL.Unit, BattleskillSkill> key in curseReflectionSkillTarget.Keys)
          {
            List<BL.Unit> unitList = new List<BL.Unit>();
            foreach (BL.Unit unit in curseReflectionSkillTarget[key])
            {
              if (unit.hp <= 0)
                unitList.Add(unit);
            }
            foreach (BL.Unit unit in unitList)
              curseReflectionSkillTarget[key].Remove(unit);
          }
        }
        for (int index = 0; index < 2; ++index)
        {
          if (curseReflectionTargetDamage[index] != null && curseReflectionTargetDamage[index].Count >= 1)
          {
            BL.ISkillEffectListUnit invokeUnit = curseReflectionInvokeUnit[index];
            foreach (BL.ISkillEffectListUnit key in curseReflectionTargetDamage[index].Keys)
            {
              if (key.hp >= 1)
                BattleFuncs.applyHpDamage(atk, def, invokeUnit, key, curseReflectionTargetDamage[index][key], 0, deads, subHpFunction);
            }
          }
        }
      }
      int index3 = 0;
      if (snakeVenomInvokeUnit[0] != null && snakeVenomInvokeUnit[1] != null)
        index3 = snakeVenomInvokeTurn[0] <= snakeVenomInvokeTurn[1] ? 0 : 1;
      for (int index4 = 0; index4 < 2; ++index4)
      {
        BL.ISkillEffectListUnit skillEffectListUnit = snakeVenomInvokeUnit[index3];
        if (skillEffectListUnit != null)
        {
          Dictionary<BL.Unit, Tuple<int, int>> dictionary6 = snakeFunction == null ? (Dictionary<BL.Unit, Tuple<int, int>>) null : new Dictionary<BL.Unit, Tuple<int, int>>();
          skillEffectListUnit.skillEffects.RemoveEffect(1000413, env, skillEffectListUnit);
          foreach (KeyValuePair<BL.ISkillEffectListUnit, int> keyValuePair in snakeVenomUnitDamage[index3])
          {
            BL.ISkillEffectListUnit key = keyValuePair.Key;
            int minHp = snakeVenomEffect[index3].effect.GetInt("min_hp");
            if (key.hp >= minHp)
            {
              int hp = key.hp;
              BattleFuncs.applyHpDamage(atk, def, skillEffectListUnit, key, keyValuePair.Value, minHp, deads, (Action<BL.ISkillEffectListUnit, int>) null);
              if (dictionary6 != null && hp >= 1)
                dictionary6[key as BL.Unit] = new Tuple<int, int>(hp, key.hp);
            }
          }
          if (dictionary6 != null)
            snakeFunction(snakeVenomEffect[index3].baseSkill, skillEffectListUnit as BL.Unit, dictionary6);
        }
        index3 ^= 1;
      }
    }

    private static void applyHpDamage(
      BL.ISkillEffectListUnit atk,
      BL.ISkillEffectListUnit def,
      BL.ISkillEffectListUnit invokeUnit,
      BL.ISkillEffectListUnit target,
      int damage,
      int minHp,
      HashSet<BL.ISkillEffectListUnit> deads,
      Action<BL.ISkillEffectListUnit, int> hpFunction)
    {
      BL.Unit unit1 = invokeUnit as BL.Unit;
      int hp = target.hp;
      target.hp -= damage;
      if (target.hp < minHp)
        target.hp = minHp;
      if (damage >= 1 && target != atk && target != def)
        target.skillEffects.RemoveEffect(1000418, BattleFuncs.env, target);
      if (hpFunction != null)
        hpFunction(target, hp);
      if (target.hp <= 0 && target != atk && target != def)
      {
        if (unit1 != null)
        {
          BL.Unit unit2 = target as BL.Unit;
          ++unit1.killCount;
          unit2.killedBy = unit1;
          if (BattleFuncs.env.getForceID(unit2) == BL.ForceID.player)
            BattleFuncs.env.updateIntimateByDefense(unit2);
        }
        invokeUnit.skillEffects.AddKillCount(1);
        deads.Add(target);
      }
      if (unit1 == null || hp <= target.hp)
        return;
      unit1.attackDamage += hp - target.hp;
    }

    private static void addSkillEffectsUnits(
      IEnumerable<BL.UnitPosition> ups,
      BL.Skill skill,
      int ignoreType,
      bool isEnemyTrigger,
      bool isEnemy,
      params BattleskillEffectLogicEnum[] logics)
    {
      foreach (BL.UnitPosition up in ups)
      {
        BL.ISkillEffectListUnit u = !(up is BL.ISkillEffectListUnit) ? (BL.ISkillEffectListUnit) up.unit : up as BL.ISkillEffectListUnit;
        if (u != null)
          BattleFuncs.addSkillEffects(u, skill, ignoreType, isEnemyTrigger, isEnemy, logics);
      }
    }

    private static void addSkillEffects1(
      BL.ISkillEffectListUnit u,
      BL.Skill skill,
      bool isEnemyTrigger,
      bool isEnemy,
      BattleskillEffectLogicEnum[] logics)
    {
      foreach (BattleskillEffect effect in skill.skill.Effects)
      {
        if (!((IEnumerable<BattleskillEffectLogicEnum>) logics).Contains<BattleskillEffectLogicEnum>(effect.effect_logic.Enum) && (!isEnemyTrigger || effect.is_targer_enemy == isEnemy))
          u.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
      }
    }

    private static void addSkillEffects2(
      BL.ISkillEffectListUnit u,
      BL.Skill skill,
      bool isEnemyTrigger,
      bool isEnemy,
      BattleskillEffectLogicEnum[] logics)
    {
      foreach (BattleskillEffect effect in skill.skill.Effects)
      {
        if (((IEnumerable<BattleskillEffectLogicEnum>) logics).Contains<BattleskillEffectLogicEnum>(effect.effect_logic.Enum) && (!isEnemyTrigger || effect.is_targer_enemy == isEnemy))
          u.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
      }
    }

    private static void addSkillEffects(
      BL.ISkillEffectListUnit u,
      BL.Skill skill,
      int ignoreType,
      bool isEnemyTrigger,
      bool isEnemy,
      params BattleskillEffectLogicEnum[] logics)
    {
      switch (ignoreType)
      {
        case 0:
          foreach (BattleskillEffect effect in skill.skill.Effects)
          {
            if (!isEnemyTrigger || effect.is_targer_enemy == isEnemy)
              u.skillEffects.Add(BL.SkillEffect.FromMasterData(effect, skill.skill, 1));
          }
          break;
        case 1:
          BattleFuncs.addSkillEffects1(u, skill, isEnemyTrigger, isEnemy, logics);
          break;
        case 2:
          BattleFuncs.addSkillEffects2(u, skill, isEnemyTrigger, isEnemy, logics);
          break;
      }
    }

    public static bool applyServantsJoy(BL.ISkillEffectListUnit unit, int healHpTotal)
    {
      bool flag = false;
      int num1 = 0;
      foreach (BL.SkillEffect skillEffect in unit.enabledSkillEffect(BattleskillEffectLogicEnum.ratio_servants_joy))
      {
        float num2 = skillEffect.effect.GetFloat("percentage") + skillEffect.effect.GetFloat("skill_ratio") * (float) skillEffect.baseSkillLevel;
        int num3 = (int) ((Decimal) healHpTotal * (Decimal) num2);
        if ((double) num2 > 0.0)
        {
          if (num3 <= 0)
            num3 = 1;
        }
        else if ((double) num2 < 0.0 && num3 >= 0)
          num3 = -1;
        num1 += num3;
        flag = true;
      }
      foreach (BL.SkillEffect skillEffect in unit.enabledSkillEffect(BattleskillEffectLogicEnum.fix_servants_joy))
      {
        int num4 = skillEffect.effect.GetInt("value") + skillEffect.effect.GetInt("skill_ratio") * skillEffect.baseSkillLevel;
        num1 += num4;
        flag = true;
      }
      if (flag)
        unit.hp += num1;
      return flag;
    }

    public static bool hasEnabledMoveDistanceEffects(BL.ISkillEffectListUnit unit)
    {
      foreach (BattleskillEffectLogicEnum logic in BattleFuncs.moveDistanceSkillEffectsEnum)
      {
        if (unit.HasEnabledSkillEffect(logic))
          return true;
      }
      return false;
    }

    public static bool hasEnabledRangeEffects(BL.ISkillEffectListUnit unit)
    {
      foreach (BattleskillEffectLogicEnum logic in BattleFuncs.rangeSkillEffectsEnum)
      {
        if (unit.HasEnabledSkillEffect(logic))
          return true;
      }
      return false;
    }

    public static IEnumerable<BL.SkillEffect> getEnabledCharismaEffects(BL.ISkillEffectListUnit unit)
    {
      IEnumerable<BL.SkillEffect> first = (IEnumerable<BL.SkillEffect>) new BL.SkillEffect[0];
      foreach (BattleskillEffectLogicEnum e in BattleFuncs.charismaEffectsEnum)
        first = first.Concat<BL.SkillEffect>(BattleFuncs.getEnabledEffects(unit.skillEffects, e, unit));
      return first;
    }

    public static bool hasEnabledDeadCountEffects(
      BL.ISkillEffectListUnit unit,
      BL.ISkillEffectListUnit deadUnit)
    {
      BL.ForceID forceId = BattleFuncs.env.getForceID(deadUnit.originalUnit);
      if (BattleFuncs.env.getForceID(unit.originalUnit) == forceId)
      {
        foreach (BattleskillEffectLogicEnum e in BattleFuncs.deadCountSkillEffectsEnumPlayerForce)
        {
          if (BattleFuncs.getEnabledEffects(unit.skillEffects, e, unit).Any<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => !x.effect.HasKey("unit_id") || x.effect.GetInt("unit_id") == 0 || x.effect.GetInt("unit_id") == deadUnit.originalUnit.unit.ID)))
            return true;
        }
      }
      else if (((IEnumerable<BL.ForceID>) BattleFuncs.env.getTargetForce(unit.originalUnit)).Contains<BL.ForceID>(forceId))
      {
        foreach (BattleskillEffectLogicEnum e in BattleFuncs.deadCountSkillEffectsEnumEnemyForce)
        {
          if (BattleFuncs.getEnabledEffects(unit.skillEffects, e, unit).Any<BL.SkillEffect>((Func<BL.SkillEffect, bool>) (x => !x.effect.HasKey("unit_id") || x.effect.GetInt("unit_id") == 0 || x.effect.GetInt("unit_id") == deadUnit.originalUnit.unit.ID)))
            return true;
        }
      }
      return false;
    }

    public static IEnumerable<BL.SkillEffect> getEnabledEffects(
      BL.SkillEffectList self,
      BattleskillEffectLogicEnum e,
      BL.ISkillEffectListUnit effectUnit)
    {
      return self.Where(e, (Func<BL.SkillEffect, bool>) (effect =>
      {
        if (effect.effect.HasKey("element") && effect.effect.GetInt("element") != 0 && (CommonElement) effect.effect.GetInt("element") != effectUnit.originalUnit.playerUnit.GetElement())
          return false;
        return !effect.effect.HasKey("gear_kind_id") || effect.effect.GetInt("gear_kind_id") == 0 || effect.effect.GetInt("gear_kind_id") == effectUnit.originalUnit.unit.kind.ID;
      }));
    }

    public static IEnumerable<BL.SkillEffect> getEnabledOnemanChargeEffects(
      BL.ISkillEffectListUnit unit)
    {
      IEnumerable<BL.SkillEffect> first = (IEnumerable<BL.SkillEffect>) new BL.SkillEffect[0];
      foreach (BattleskillEffectLogicEnum e in BattleFuncs.onemanChargeEffectsEnum)
        first = first.Concat<BL.SkillEffect>(unit.skillEffects.Where(e));
      return first;
    }

    public static IEnumerable<BL.Panel> getSkillZocPanels(
      BL.ISkillEffectListUnit unit,
      int row,
      int column)
    {
      HashSet<BL.Panel> zoc = new HashSet<BL.Panel>();
      IEnumerable<BL.SkillEffect> source = unit.enabledSkillEffect(BattleskillEffectLogicEnum.zoc);
      if (source.Count<BL.SkillEffect>() > 0)
      {
        foreach (BL.SkillEffect skillEffect in source)
        {
          int num1 = skillEffect.effect.GetInt("min_range");
          int num2 = skillEffect.effect.GetInt("max_range");
          bool includingSlanting = skillEffect.effect.GetInt("excluding_slanting") == 0;
          int[] range = new int[2]{ num1, num2 };
          BattleFuncs.getRangePanels(row, column, range).ForEach((Action<BL.Panel>) (x =>
          {
            if (!includingSlanting && (includingSlanting || x.row != row && x.column != column))
              return;
            zoc.Add(x);
          }));
        }
      }
      return (IEnumerable<BL.Panel>) zoc;
    }

    public struct AttackDamageData
    {
      public bool isHit;
      public bool isCritical;
      public int damage;
      public int dispDamage;
      public int drainDamage;
      public int dispDrainDamage;
      public int defenderDispDrainDamage;
      public int defenderDrainDamage;
      public BattleDuelSkill duelSkillProc;
      public TurnHp hp;
      public int counterDamage;
      public List<BL.SkillEffect> attackerConsumeSkillEffects;
      public List<BL.SkillEffect> defenderConsumeSkillEffects;
    }

    public class AsterEdge
    {
      public int to;
      public int cost;

      public AsterEdge(int to, int cost)
      {
        this.to = to;
        this.cost = cost;
      }
    }

    public class AsterNode
    {
      public BL.Panel panel;
      public BattleFuncs.AsterEdge[] edges;
      public int cost;
      public int no;
      public int from;

      public AsterNode(int no, BL.Panel panel, BattleFuncs.AsterEdge[] edges)
      {
        this.panel = panel;
        this.no = no;
        this.edges = edges;
        this.cost = 1000000000;
        this.from = -1;
      }
    }

    public class BeforeDuelDuelSupport
    {
      public IntimateDuelSupport duelSupport;
      public int hit;
      public int evasion;
      public int critical;
      public int criticalEvasion;
      public int hitIncr;
      public int evasionIncr;
      public int criticalIncr;
      public int criticalEvasionIncr;
    }
  }
}
