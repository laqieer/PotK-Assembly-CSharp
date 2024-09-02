// Decompiled with JetBrains decompiler
// Type: MasterData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;

#nullable disable
public static class MasterData
{
  public static void LoadBattleMapLandform(MasterDataTable.BattleMap map)
  {
    MasterDataCache.LoadPartial<int, MasterDataTable.BattleMapLandform>("BattleMapLandform", "BattleMapLandform_part_" + map.ID.ToString(), new Func<MasterDataReader, MasterDataTable.BattleMapLandform>(MasterDataTable.BattleMapLandform.Parse), (Func<MasterDataTable.BattleMapLandform, int>) (x => x.ID));
  }

  public static void LoadBattleStageEnemy(MasterDataTable.BattleStage stage)
  {
    MasterDataCache.LoadPartial<int, MasterDataTable.BattleStageEnemy>("BattleStageEnemy", "BattleStageEnemy_part_" + stage.ID.ToString(), new Func<MasterDataReader, MasterDataTable.BattleStageEnemy>(MasterDataTable.BattleStageEnemy.Parse), (Func<MasterDataTable.BattleStageEnemy, int>) (x => x.ID));
  }

  public static void LoadBattleStageUserUnit(MasterDataTable.BattleStage stage)
  {
    MasterDataCache.LoadPartial<int, MasterDataTable.BattleStageUserUnit>("BattleStageUserUnit", "BattleStageUserUnit_part_" + stage.ID.ToString(), new Func<MasterDataReader, MasterDataTable.BattleStageUserUnit>(MasterDataTable.BattleStageUserUnit.Parse), (Func<MasterDataTable.BattleStageUserUnit, int>) (x => x.ID));
  }

  public static MasterDataTable.BattleskillEffect[] WhereBattleskillEffectBy(MasterDataTable.BattleskillSkill skill)
  {
    return MasterDataCache.Where<int, MasterDataTable.BattleskillEffect, Tuple<int>>("BattleskillEffect", "By", Tuple.Create<int>(skill.ID), (Func<MasterDataTable.BattleskillEffect, Tuple<int>>) (x => Tuple.Create<int>(x.skill.ID)), new Func<MasterDataReader, MasterDataTable.BattleskillEffect>(MasterDataTable.BattleskillEffect.Parse), (Func<MasterDataTable.BattleskillEffect, int>) (x => x.ID));
  }

  public static MasterDataTable.GearKindCorrelations UniqueGearKindCorrelationsBy(
    MasterDataTable.GearKind attacker,
    MasterDataTable.GearKind defender)
  {
    return MasterDataCache.Unique<int, MasterDataTable.GearKindCorrelations, Tuple<int, int>>("GearKindCorrelations", "By", Tuple.Create<int, int>(attacker.ID, defender.ID), (Func<MasterDataTable.GearKindCorrelations, Tuple<int, int>>) (x => Tuple.Create<int, int>(x.attacker.ID, x.defender.ID)), new Func<MasterDataReader, MasterDataTable.GearKindCorrelations>(MasterDataTable.GearKindCorrelations.Parse), (Func<MasterDataTable.GearKindCorrelations, int>) (x => x.ID));
  }

  public static MasterDataTable.GearKindIncr UniqueGearKindIncrBy(
    MasterDataTable.GearKind attack_kind,
    MasterDataTable.GearKind defense_kind,
    MasterDataTable.UnitProficiency proficiency)
  {
    return MasterDataCache.Unique<int, MasterDataTable.GearKindIncr, Tuple<int, int, int>>("GearKindIncr", "By", Tuple.Create<int, int, int>(attack_kind.ID, defense_kind.ID, proficiency.ID), (Func<MasterDataTable.GearKindIncr, Tuple<int, int, int>>) (x => Tuple.Create<int, int, int>(x.attack_kind.ID, x.defense_kind.ID, x.proficiency.ID)), new Func<MasterDataReader, MasterDataTable.GearKindIncr>(MasterDataTable.GearKindIncr.Parse), (Func<MasterDataTable.GearKindIncr, int>) (x => x.ID));
  }

  public static AssocList<int, MasterDataTable.AIScore> AIScore
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.AIScore>(nameof (AIScore), new Func<MasterDataReader, MasterDataTable.AIScore>(MasterDataTable.AIScore.Parse), (Func<MasterDataTable.AIScore, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.AIScoreCorrection> AIScoreCorrection
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.AIScoreCorrection>(nameof (AIScoreCorrection), new Func<MasterDataReader, MasterDataTable.AIScoreCorrection>(MasterDataTable.AIScoreCorrection.Parse), (Func<MasterDataTable.AIScoreCorrection, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.AIScorePattern> AIScorePattern
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.AIScorePattern>(nameof (AIScorePattern), new Func<MasterDataReader, MasterDataTable.AIScorePattern>(MasterDataTable.AIScorePattern.Parse), (Func<MasterDataTable.AIScorePattern, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ActivityReward> ActivityReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ActivityReward>(nameof (ActivityReward), new Func<MasterDataReader, MasterDataTable.ActivityReward>(MasterDataTable.ActivityReward.Parse), (Func<MasterDataTable.ActivityReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ActivityRewardConditions> ActivityRewardConditions
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ActivityRewardConditions>(nameof (ActivityRewardConditions), new Func<MasterDataReader, MasterDataTable.ActivityRewardConditions>(MasterDataTable.ActivityRewardConditions.Parse), (Func<MasterDataTable.ActivityRewardConditions, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ActivityRewardPhaseConditions> ActivityRewardPhaseConditions
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ActivityRewardPhaseConditions>(nameof (ActivityRewardPhaseConditions), new Func<MasterDataReader, MasterDataTable.ActivityRewardPhaseConditions>(MasterDataTable.ActivityRewardPhaseConditions.Parse), (Func<MasterDataTable.ActivityRewardPhaseConditions, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ActivityTotalTable> ActivityTotalTable
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ActivityTotalTable>(nameof (ActivityTotalTable), new Func<MasterDataReader, MasterDataTable.ActivityTotalTable>(MasterDataTable.ActivityTotalTable.Parse), (Func<MasterDataTable.ActivityTotalTable, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ActivityTypeTable> ActivityTypeTable
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ActivityTypeTable>(nameof (ActivityTypeTable), new Func<MasterDataReader, MasterDataTable.ActivityTypeTable>(MasterDataTable.ActivityTypeTable.Parse), (Func<MasterDataTable.ActivityTypeTable, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.Bag> Bag
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.Bag>(nameof (Bag), new Func<MasterDataReader, MasterDataTable.Bag>(MasterDataTable.Bag.Parse), (Func<MasterDataTable.Bag, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleAIScript> BattleAIScript
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleAIScript>(nameof (BattleAIScript), new Func<MasterDataReader, MasterDataTable.BattleAIScript>(MasterDataTable.BattleAIScript.Parse), (Func<MasterDataTable.BattleAIScript, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleEarthItemDropTable> BattleEarthItemDropTable
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleEarthItemDropTable>(nameof (BattleEarthItemDropTable), new Func<MasterDataReader, MasterDataTable.BattleEarthItemDropTable>(MasterDataTable.BattleEarthItemDropTable.Parse), (Func<MasterDataTable.BattleEarthItemDropTable, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleEarthStageGuest> BattleEarthStageGuest
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleEarthStageGuest>(nameof (BattleEarthStageGuest), new Func<MasterDataReader, MasterDataTable.BattleEarthStageGuest>(MasterDataTable.BattleEarthStageGuest.Parse), (Func<MasterDataTable.BattleEarthStageGuest, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleEarthStageGuestSkill> BattleEarthStageGuestSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleEarthStageGuestSkill>(nameof (BattleEarthStageGuestSkill), new Func<MasterDataReader, MasterDataTable.BattleEarthStageGuestSkill>(MasterDataTable.BattleEarthStageGuestSkill.Parse), (Func<MasterDataTable.BattleEarthStageGuestSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleEnemyAcquireSkill> BattleEnemyAcquireSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleEnemyAcquireSkill>(nameof (BattleEnemyAcquireSkill), new Func<MasterDataReader, MasterDataTable.BattleEnemyAcquireSkill>(MasterDataTable.BattleEnemyAcquireSkill.Parse), (Func<MasterDataTable.BattleEnemyAcquireSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleEnemyParameterDeviationTable> BattleEnemyParameterDeviationTable
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleEnemyParameterDeviationTable>(nameof (BattleEnemyParameterDeviationTable), new Func<MasterDataReader, MasterDataTable.BattleEnemyParameterDeviationTable>(MasterDataTable.BattleEnemyParameterDeviationTable.Parse), (Func<MasterDataTable.BattleEnemyParameterDeviationTable, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleEnemyParameterTable> BattleEnemyParameterTable
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleEnemyParameterTable>(nameof (BattleEnemyParameterTable), new Func<MasterDataReader, MasterDataTable.BattleEnemyParameterTable>(MasterDataTable.BattleEnemyParameterTable.Parse), (Func<MasterDataTable.BattleEnemyParameterTable, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleFieldEffect> BattleFieldEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleFieldEffect>(nameof (BattleFieldEffect), new Func<MasterDataReader, MasterDataTable.BattleFieldEffect>(MasterDataTable.BattleFieldEffect.Parse), (Func<MasterDataTable.BattleFieldEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleFieldEffectStage> BattleFieldEffectStage
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleFieldEffectStage>(nameof (BattleFieldEffectStage), new Func<MasterDataReader, MasterDataTable.BattleFieldEffectStage>(MasterDataTable.BattleFieldEffectStage.Parse), (Func<MasterDataTable.BattleFieldEffectStage, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleLandform> BattleLandform
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleLandform>(nameof (BattleLandform), new Func<MasterDataReader, MasterDataTable.BattleLandform>(MasterDataTable.BattleLandform.Parse), (Func<MasterDataTable.BattleLandform, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleLandformEffect> BattleLandformEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleLandformEffect>(nameof (BattleLandformEffect), new Func<MasterDataReader, MasterDataTable.BattleLandformEffect>(MasterDataTable.BattleLandformEffect.Parse), (Func<MasterDataTable.BattleLandformEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleLandformEffectGroup> BattleLandformEffectGroup
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleLandformEffectGroup>(nameof (BattleLandformEffectGroup), new Func<MasterDataReader, MasterDataTable.BattleLandformEffectGroup>(MasterDataTable.BattleLandformEffectGroup.Parse), (Func<MasterDataTable.BattleLandformEffectGroup, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleLandformFootstepType> BattleLandformFootstepType
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleLandformFootstepType>(nameof (BattleLandformFootstepType), new Func<MasterDataReader, MasterDataTable.BattleLandformFootstepType>(MasterDataTable.BattleLandformFootstepType.Parse), (Func<MasterDataTable.BattleLandformFootstepType, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleLandformIncr> BattleLandformIncr
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleLandformIncr>(nameof (BattleLandformIncr), new Func<MasterDataReader, MasterDataTable.BattleLandformIncr>(MasterDataTable.BattleLandformIncr.Parse), (Func<MasterDataTable.BattleLandformIncr, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleMap> BattleMap
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleMap>(nameof (BattleMap), new Func<MasterDataReader, MasterDataTable.BattleMap>(MasterDataTable.BattleMap.Parse), (Func<MasterDataTable.BattleMap, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleMapLandform> BattleMapLandform
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleMapLandform>(nameof (BattleMapLandform), new Func<MasterDataReader, MasterDataTable.BattleMapLandform>(MasterDataTable.BattleMapLandform.Parse), (Func<MasterDataTable.BattleMapLandform, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleReinforcement> BattleReinforcement
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleReinforcement>(nameof (BattleReinforcement), new Func<MasterDataReader, MasterDataTable.BattleReinforcement>(MasterDataTable.BattleReinforcement.Parse), (Func<MasterDataTable.BattleReinforcement, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleReinforcementLogic> BattleReinforcementLogic
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleReinforcementLogic>(nameof (BattleReinforcementLogic), new Func<MasterDataReader, MasterDataTable.BattleReinforcementLogic>(MasterDataTable.BattleReinforcementLogic.Parse), (Func<MasterDataTable.BattleReinforcementLogic, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleSpecialSkill> BattleSpecialSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleSpecialSkill>(nameof (BattleSpecialSkill), new Func<MasterDataReader, MasterDataTable.BattleSpecialSkill>(MasterDataTable.BattleSpecialSkill.Parse), (Func<MasterDataTable.BattleSpecialSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStage> BattleStage
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStage>(nameof (BattleStage), new Func<MasterDataReader, MasterDataTable.BattleStage>(MasterDataTable.BattleStage.Parse), (Func<MasterDataTable.BattleStage, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStageClear> BattleStageClear
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStageClear>(nameof (BattleStageClear), new Func<MasterDataReader, MasterDataTable.BattleStageClear>(MasterDataTable.BattleStageClear.Parse), (Func<MasterDataTable.BattleStageClear, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStageEnemy> BattleStageEnemy
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStageEnemy>(nameof (BattleStageEnemy), new Func<MasterDataReader, MasterDataTable.BattleStageEnemy>(MasterDataTable.BattleStageEnemy.Parse), (Func<MasterDataTable.BattleStageEnemy, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStageEnemyReward> BattleStageEnemyReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStageEnemyReward>(nameof (BattleStageEnemyReward), new Func<MasterDataReader, MasterDataTable.BattleStageEnemyReward>(MasterDataTable.BattleStageEnemyReward.Parse), (Func<MasterDataTable.BattleStageEnemyReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStageEnemySkill> BattleStageEnemySkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStageEnemySkill>(nameof (BattleStageEnemySkill), new Func<MasterDataReader, MasterDataTable.BattleStageEnemySkill>(MasterDataTable.BattleStageEnemySkill.Parse), (Func<MasterDataTable.BattleStageEnemySkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStageGuest> BattleStageGuest
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStageGuest>(nameof (BattleStageGuest), new Func<MasterDataReader, MasterDataTable.BattleStageGuest>(MasterDataTable.BattleStageGuest.Parse), (Func<MasterDataTable.BattleStageGuest, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStageGuestSkill> BattleStageGuestSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStageGuestSkill>(nameof (BattleStageGuestSkill), new Func<MasterDataReader, MasterDataTable.BattleStageGuestSkill>(MasterDataTable.BattleStageGuestSkill.Parse), (Func<MasterDataTable.BattleStageGuestSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStagePanelEvent> BattleStagePanelEvent
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStagePanelEvent>(nameof (BattleStagePanelEvent), new Func<MasterDataReader, MasterDataTable.BattleStagePanelEvent>(MasterDataTable.BattleStagePanelEvent.Parse), (Func<MasterDataTable.BattleStagePanelEvent, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStagePlayer> BattleStagePlayer
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStagePlayer>(nameof (BattleStagePlayer), new Func<MasterDataReader, MasterDataTable.BattleStagePlayer>(MasterDataTable.BattleStagePlayer.Parse), (Func<MasterDataTable.BattleStagePlayer, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleStageUserUnit> BattleStageUserUnit
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleStageUserUnit>(nameof (BattleStageUserUnit), new Func<MasterDataReader, MasterDataTable.BattleStageUserUnit>(MasterDataTable.BattleStageUserUnit.Parse), (Func<MasterDataTable.BattleStageUserUnit, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleUnitLandformFootstep> BattleUnitLandformFootstep
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleUnitLandformFootstep>(nameof (BattleUnitLandformFootstep), new Func<MasterDataReader, MasterDataTable.BattleUnitLandformFootstep>(MasterDataTable.BattleUnitLandformFootstep.Parse), (Func<MasterDataTable.BattleUnitLandformFootstep, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleVictoryAreaCondition> BattleVictoryAreaCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleVictoryAreaCondition>(nameof (BattleVictoryAreaCondition), new Func<MasterDataReader, MasterDataTable.BattleVictoryAreaCondition>(MasterDataTable.BattleVictoryAreaCondition.Parse), (Func<MasterDataTable.BattleVictoryAreaCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleVictoryCondition> BattleVictoryCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleVictoryCondition>(nameof (BattleVictoryCondition), new Func<MasterDataReader, MasterDataTable.BattleVictoryCondition>(MasterDataTable.BattleVictoryCondition.Parse), (Func<MasterDataTable.BattleVictoryCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillAilmentEffect> BattleskillAilmentEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillAilmentEffect>(nameof (BattleskillAilmentEffect), new Func<MasterDataReader, MasterDataTable.BattleskillAilmentEffect>(MasterDataTable.BattleskillAilmentEffect.Parse), (Func<MasterDataTable.BattleskillAilmentEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillDuelClipEventEffectDataPreload> BattleskillDuelClipEventEffectDataPreload
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillDuelClipEventEffectDataPreload>(nameof (BattleskillDuelClipEventEffectDataPreload), new Func<MasterDataReader, MasterDataTable.BattleskillDuelClipEventEffectDataPreload>(MasterDataTable.BattleskillDuelClipEventEffectDataPreload.Parse), (Func<MasterDataTable.BattleskillDuelClipEventEffectDataPreload, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillDuelCutinPreload> BattleskillDuelCutinPreload
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillDuelCutinPreload>(nameof (BattleskillDuelCutinPreload), new Func<MasterDataReader, MasterDataTable.BattleskillDuelCutinPreload>(MasterDataTable.BattleskillDuelCutinPreload.Parse), (Func<MasterDataTable.BattleskillDuelCutinPreload, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillDuelEffect> BattleskillDuelEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillDuelEffect>(nameof (BattleskillDuelEffect), new Func<MasterDataReader, MasterDataTable.BattleskillDuelEffect>(MasterDataTable.BattleskillDuelEffect.Parse), (Func<MasterDataTable.BattleskillDuelEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillDuelEffectPreload> BattleskillDuelEffectPreload
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillDuelEffectPreload>(nameof (BattleskillDuelEffectPreload), new Func<MasterDataReader, MasterDataTable.BattleskillDuelEffectPreload>(MasterDataTable.BattleskillDuelEffectPreload.Parse), (Func<MasterDataTable.BattleskillDuelEffectPreload, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillEffect> BattleskillEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillEffect>(nameof (BattleskillEffect), new Func<MasterDataReader, MasterDataTable.BattleskillEffect>(MasterDataTable.BattleskillEffect.Parse), (Func<MasterDataTable.BattleskillEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillEffectLogic> BattleskillEffectLogic
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillEffectLogic>(nameof (BattleskillEffectLogic), new Func<MasterDataReader, MasterDataTable.BattleskillEffectLogic>(MasterDataTable.BattleskillEffectLogic.Parse), (Func<MasterDataTable.BattleskillEffectLogic, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillFieldEffect> BattleskillFieldEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillFieldEffect>(nameof (BattleskillFieldEffect), new Func<MasterDataReader, MasterDataTable.BattleskillFieldEffect>(MasterDataTable.BattleskillFieldEffect.Parse), (Func<MasterDataTable.BattleskillFieldEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillLifeCycle> BattleskillLifeCycle
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillLifeCycle>(nameof (BattleskillLifeCycle), new Func<MasterDataReader, MasterDataTable.BattleskillLifeCycle>(MasterDataTable.BattleskillLifeCycle.Parse), (Func<MasterDataTable.BattleskillLifeCycle, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillSkill> BattleskillSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillSkill>(nameof (BattleskillSkill), new Func<MasterDataReader, MasterDataTable.BattleskillSkill>(MasterDataTable.BattleskillSkill.Parse), (Func<MasterDataTable.BattleskillSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillTiming> BattleskillTiming
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillTiming>(nameof (BattleskillTiming), new Func<MasterDataReader, MasterDataTable.BattleskillTiming>(MasterDataTable.BattleskillTiming.Parse), (Func<MasterDataTable.BattleskillTiming, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BattleskillTimingLogic> BattleskillTimingLogic
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BattleskillTimingLogic>(nameof (BattleskillTimingLogic), new Func<MasterDataReader, MasterDataTable.BattleskillTimingLogic>(MasterDataTable.BattleskillTimingLogic.Parse), (Func<MasterDataTable.BattleskillTimingLogic, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BeginnerNaviCategory> BeginnerNaviCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BeginnerNaviCategory>(nameof (BeginnerNaviCategory), new Func<MasterDataReader, MasterDataTable.BeginnerNaviCategory>(MasterDataTable.BeginnerNaviCategory.Parse), (Func<MasterDataTable.BeginnerNaviCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BeginnerNaviDetail> BeginnerNaviDetail
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BeginnerNaviDetail>(nameof (BeginnerNaviDetail), new Func<MasterDataReader, MasterDataTable.BeginnerNaviDetail>(MasterDataTable.BeginnerNaviDetail.Parse), (Func<MasterDataTable.BeginnerNaviDetail, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BeginnerNaviMovePage> BeginnerNaviMovePage
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BeginnerNaviMovePage>(nameof (BeginnerNaviMovePage), new Func<MasterDataReader, MasterDataTable.BeginnerNaviMovePage>(MasterDataTable.BeginnerNaviMovePage.Parse), (Func<MasterDataTable.BeginnerNaviMovePage, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BeginnerNaviTitle> BeginnerNaviTitle
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BeginnerNaviTitle>(nameof (BeginnerNaviTitle), new Func<MasterDataReader, MasterDataTable.BeginnerNaviTitle>(MasterDataTable.BeginnerNaviTitle.Parse), (Func<MasterDataTable.BeginnerNaviTitle, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BingoBingo> BingoBingo
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BingoBingo>(nameof (BingoBingo), new Func<MasterDataReader, MasterDataTable.BingoBingo>(MasterDataTable.BingoBingo.Parse), (Func<MasterDataTable.BingoBingo, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BingoMission> BingoMission
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BingoMission>(nameof (BingoMission), new Func<MasterDataReader, MasterDataTable.BingoMission>(MasterDataTable.BingoMission.Parse), (Func<MasterDataTable.BingoMission, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BingoRewardGroup> BingoRewardGroup
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BingoRewardGroup>(nameof (BingoRewardGroup), new Func<MasterDataReader, MasterDataTable.BingoRewardGroup>(MasterDataTable.BingoRewardGroup.Parse), (Func<MasterDataTable.BingoRewardGroup, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BoostBonusGearCombine> BoostBonusGearCombine
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BoostBonusGearCombine>(nameof (BoostBonusGearCombine), new Func<MasterDataReader, MasterDataTable.BoostBonusGearCombine>(MasterDataTable.BoostBonusGearCombine.Parse), (Func<MasterDataTable.BoostBonusGearCombine, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BoostBonusGearDrilling> BoostBonusGearDrilling
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BoostBonusGearDrilling>(nameof (BoostBonusGearDrilling), new Func<MasterDataReader, MasterDataTable.BoostBonusGearDrilling>(MasterDataTable.BoostBonusGearDrilling.Parse), (Func<MasterDataTable.BoostBonusGearDrilling, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BoostBonusUnitBuildup> BoostBonusUnitBuildup
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BoostBonusUnitBuildup>(nameof (BoostBonusUnitBuildup), new Func<MasterDataReader, MasterDataTable.BoostBonusUnitBuildup>(MasterDataTable.BoostBonusUnitBuildup.Parse), (Func<MasterDataTable.BoostBonusUnitBuildup, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BoostBonusUnitCompose> BoostBonusUnitCompose
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BoostBonusUnitCompose>(nameof (BoostBonusUnitCompose), new Func<MasterDataReader, MasterDataTable.BoostBonusUnitCompose>(MasterDataTable.BoostBonusUnitCompose.Parse), (Func<MasterDataTable.BoostBonusUnitCompose, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BoostBonusUnitTransmigrate> BoostBonusUnitTransmigrate
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BoostBonusUnitTransmigrate>(nameof (BoostBonusUnitTransmigrate), new Func<MasterDataReader, MasterDataTable.BoostBonusUnitTransmigrate>(MasterDataTable.BoostBonusUnitTransmigrate.Parse), (Func<MasterDataTable.BoostBonusUnitTransmigrate, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BoostCampaignTypeName> BoostCampaignTypeName
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BoostCampaignTypeName>(nameof (BoostCampaignTypeName), new Func<MasterDataReader, MasterDataTable.BoostCampaignTypeName>(MasterDataTable.BoostCampaignTypeName.Parse), (Func<MasterDataTable.BoostCampaignTypeName, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BoostPeriod> BoostPeriod
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BoostPeriod>(nameof (BoostPeriod), new Func<MasterDataReader, MasterDataTable.BoostPeriod>(MasterDataTable.BoostPeriod.Parse), (Func<MasterDataTable.BoostPeriod, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.BreakThroughBuildupSkill> BreakThroughBuildupSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.BreakThroughBuildupSkill>(nameof (BreakThroughBuildupSkill), new Func<MasterDataReader, MasterDataTable.BreakThroughBuildupSkill>(MasterDataTable.BreakThroughBuildupSkill.Parse), (Func<MasterDataTable.BreakThroughBuildupSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.CoinChargeLimit> CoinChargeLimit
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.CoinChargeLimit>(nameof (CoinChargeLimit), new Func<MasterDataReader, MasterDataTable.CoinChargeLimit>(MasterDataTable.CoinChargeLimit.Parse), (Func<MasterDataTable.CoinChargeLimit, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.CoinProduct> CoinProduct
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.CoinProduct>(nameof (CoinProduct), new Func<MasterDataReader, MasterDataTable.CoinProduct>(MasterDataTable.CoinProduct.Parse), (Func<MasterDataTable.CoinProduct, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ColosseumBonus> ColosseumBonus
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ColosseumBonus>(nameof (ColosseumBonus), new Func<MasterDataReader, MasterDataTable.ColosseumBonus>(MasterDataTable.ColosseumBonus.Parse), (Func<MasterDataTable.ColosseumBonus, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ColosseumBonusBloodType> ColosseumBonusBloodType
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ColosseumBonusBloodType>(nameof (ColosseumBonusBloodType), new Func<MasterDataReader, MasterDataTable.ColosseumBonusBloodType>(MasterDataTable.ColosseumBonusBloodType.Parse), (Func<MasterDataTable.ColosseumBonusBloodType, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ColosseumBonusZodiacType> ColosseumBonusZodiacType
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ColosseumBonusZodiacType>(nameof (ColosseumBonusZodiacType), new Func<MasterDataReader, MasterDataTable.ColosseumBonusZodiacType>(MasterDataTable.ColosseumBonusZodiacType.Parse), (Func<MasterDataTable.ColosseumBonusZodiacType, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ColosseumRank> ColosseumRank
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ColosseumRank>(nameof (ColosseumRank), new Func<MasterDataReader, MasterDataTable.ColosseumRank>(MasterDataTable.ColosseumRank.Parse), (Func<MasterDataTable.ColosseumRank, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ColosseumRankReward> ColosseumRankReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ColosseumRankReward>(nameof (ColosseumRankReward), new Func<MasterDataReader, MasterDataTable.ColosseumRankReward>(MasterDataTable.ColosseumRankReward.Parse), (Func<MasterDataTable.ColosseumRankReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ColosseumTotalVictoryReward> ColosseumTotalVictoryReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ColosseumTotalVictoryReward>(nameof (ColosseumTotalVictoryReward), new Func<MasterDataReader, MasterDataTable.ColosseumTotalVictoryReward>(MasterDataTable.ColosseumTotalVictoryReward.Parse), (Func<MasterDataTable.ColosseumTotalVictoryReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.CommonElementName> CommonElementName
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.CommonElementName>(nameof (CommonElementName), new Func<MasterDataReader, MasterDataTable.CommonElementName>(MasterDataTable.CommonElementName.Parse), (Func<MasterDataTable.CommonElementName, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.CommonQuestBattleEffect> CommonQuestBattleEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.CommonQuestBattleEffect>(nameof (CommonQuestBattleEffect), new Func<MasterDataReader, MasterDataTable.CommonQuestBattleEffect>(MasterDataTable.CommonQuestBattleEffect.Parse), (Func<MasterDataTable.CommonQuestBattleEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.CommonStrengthComposePrice> CommonStrengthComposePrice
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.CommonStrengthComposePrice>(nameof (CommonStrengthComposePrice), new Func<MasterDataReader, MasterDataTable.CommonStrengthComposePrice>(MasterDataTable.CommonStrengthComposePrice.Parse), (Func<MasterDataTable.CommonStrengthComposePrice, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ConstsConsts> ConstsConsts
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ConstsConsts>(nameof (ConstsConsts), new Func<MasterDataReader, MasterDataTable.ConstsConsts>(MasterDataTable.ConstsConsts.Parse), (Func<MasterDataTable.ConstsConsts, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.DailyMission> DailyMission
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.DailyMission>(nameof (DailyMission), new Func<MasterDataReader, MasterDataTable.DailyMission>(MasterDataTable.DailyMission.Parse), (Func<MasterDataTable.DailyMission, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.DailyMissionTopPage> DailyMissionTopPage
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.DailyMissionTopPage>(nameof (DailyMissionTopPage), new Func<MasterDataReader, MasterDataTable.DailyMissionTopPage>(MasterDataTable.DailyMissionTopPage.Parse), (Func<MasterDataTable.DailyMissionTopPage, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.DuelDuelConfig> DuelDuelConfig
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.DuelDuelConfig>(nameof (DuelDuelConfig), new Func<MasterDataReader, MasterDataTable.DuelDuelConfig>(MasterDataTable.DuelDuelConfig.Parse), (Func<MasterDataTable.DuelDuelConfig, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.DuelEffectPreload> DuelEffectPreload
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.DuelEffectPreload>(nameof (DuelEffectPreload), new Func<MasterDataReader, MasterDataTable.DuelEffectPreload>(MasterDataTable.DuelEffectPreload.Parse), (Func<MasterDataTable.DuelEffectPreload, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.DuelElementBulletEffect> DuelElementBulletEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.DuelElementBulletEffect>(nameof (DuelElementBulletEffect), new Func<MasterDataReader, MasterDataTable.DuelElementBulletEffect>(MasterDataTable.DuelElementBulletEffect.Parse), (Func<MasterDataTable.DuelElementBulletEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.DuelElementHitEffect> DuelElementHitEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.DuelElementHitEffect>(nameof (DuelElementHitEffect), new Func<MasterDataReader, MasterDataTable.DuelElementHitEffect>(MasterDataTable.DuelElementHitEffect.Parse), (Func<MasterDataTable.DuelElementHitEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.DuelElementTrailEffect> DuelElementTrailEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.DuelElementTrailEffect>(nameof (DuelElementTrailEffect), new Func<MasterDataReader, MasterDataTable.DuelElementTrailEffect>(MasterDataTable.DuelElementTrailEffect.Parse), (Func<MasterDataTable.DuelElementTrailEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthBattleStagePanelEvent> EarthBattleStagePanelEvent
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthBattleStagePanelEvent>(nameof (EarthBattleStagePanelEvent), new Func<MasterDataReader, MasterDataTable.EarthBattleStagePanelEvent>(MasterDataTable.EarthBattleStagePanelEvent.Parse), (Func<MasterDataTable.EarthBattleStagePanelEvent, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthDesertCharacter> EarthDesertCharacter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthDesertCharacter>(nameof (EarthDesertCharacter), new Func<MasterDataReader, MasterDataTable.EarthDesertCharacter>(MasterDataTable.EarthDesertCharacter.Parse), (Func<MasterDataTable.EarthDesertCharacter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthExtraQuest> EarthExtraQuest
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthExtraQuest>(nameof (EarthExtraQuest), new Func<MasterDataReader, MasterDataTable.EarthExtraQuest>(MasterDataTable.EarthExtraQuest.Parse), (Func<MasterDataTable.EarthExtraQuest, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthForcedSortieCharacter> EarthForcedSortieCharacter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthForcedSortieCharacter>(nameof (EarthForcedSortieCharacter), new Func<MasterDataReader, MasterDataTable.EarthForcedSortieCharacter>(MasterDataTable.EarthForcedSortieCharacter.Parse), (Func<MasterDataTable.EarthForcedSortieCharacter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthImpossibleOFSortieCharacter> EarthImpossibleOFSortieCharacter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthImpossibleOFSortieCharacter>(nameof (EarthImpossibleOFSortieCharacter), new Func<MasterDataReader, MasterDataTable.EarthImpossibleOFSortieCharacter>(MasterDataTable.EarthImpossibleOFSortieCharacter.Parse), (Func<MasterDataTable.EarthImpossibleOFSortieCharacter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthJoinCharacter> EarthJoinCharacter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthJoinCharacter>(nameof (EarthJoinCharacter), new Func<MasterDataReader, MasterDataTable.EarthJoinCharacter>(MasterDataTable.EarthJoinCharacter.Parse), (Func<MasterDataTable.EarthJoinCharacter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthQuestChapter> EarthQuestChapter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthQuestChapter>(nameof (EarthQuestChapter), new Func<MasterDataReader, MasterDataTable.EarthQuestChapter>(MasterDataTable.EarthQuestChapter.Parse), (Func<MasterDataTable.EarthQuestChapter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthQuestClearReward> EarthQuestClearReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthQuestClearReward>(nameof (EarthQuestClearReward), new Func<MasterDataReader, MasterDataTable.EarthQuestClearReward>(MasterDataTable.EarthQuestClearReward.Parse), (Func<MasterDataTable.EarthQuestClearReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthQuestEpisode> EarthQuestEpisode
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthQuestEpisode>(nameof (EarthQuestEpisode), new Func<MasterDataReader, MasterDataTable.EarthQuestEpisode>(MasterDataTable.EarthQuestEpisode.Parse), (Func<MasterDataTable.EarthQuestEpisode, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthQuestExtraStoryPlayback> EarthQuestExtraStoryPlayback
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthQuestExtraStoryPlayback>(nameof (EarthQuestExtraStoryPlayback), new Func<MasterDataReader, MasterDataTable.EarthQuestExtraStoryPlayback>(MasterDataTable.EarthQuestExtraStoryPlayback.Parse), (Func<MasterDataTable.EarthQuestExtraStoryPlayback, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthQuestKey> EarthQuestKey
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthQuestKey>(nameof (EarthQuestKey), new Func<MasterDataReader, MasterDataTable.EarthQuestKey>(MasterDataTable.EarthQuestKey.Parse), (Func<MasterDataTable.EarthQuestKey, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthQuestPologue> EarthQuestPologue
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthQuestPologue>(nameof (EarthQuestPologue), new Func<MasterDataReader, MasterDataTable.EarthQuestPologue>(MasterDataTable.EarthQuestPologue.Parse), (Func<MasterDataTable.EarthQuestPologue, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthQuestStoryPlayback> EarthQuestStoryPlayback
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthQuestStoryPlayback>(nameof (EarthQuestStoryPlayback), new Func<MasterDataReader, MasterDataTable.EarthQuestStoryPlayback>(MasterDataTable.EarthQuestStoryPlayback.Parse), (Func<MasterDataTable.EarthQuestStoryPlayback, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthShopArticle> EarthShopArticle
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthShopArticle>(nameof (EarthShopArticle), new Func<MasterDataReader, MasterDataTable.EarthShopArticle>(MasterDataTable.EarthShopArticle.Parse), (Func<MasterDataTable.EarthShopArticle, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EarthShopContent> EarthShopContent
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EarthShopContent>(nameof (EarthShopContent), new Func<MasterDataReader, MasterDataTable.EarthShopContent>(MasterDataTable.EarthShopContent.Parse), (Func<MasterDataTable.EarthShopContent, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EmblemEmblem> EmblemEmblem
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EmblemEmblem>(nameof (EmblemEmblem), new Func<MasterDataReader, MasterDataTable.EmblemEmblem>(MasterDataTable.EmblemEmblem.Parse), (Func<MasterDataTable.EmblemEmblem, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.EmblemRarity> EmblemRarity
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.EmblemRarity>(nameof (EmblemRarity), new Func<MasterDataReader, MasterDataTable.EmblemRarity>(MasterDataTable.EmblemRarity.Parse), (Func<MasterDataTable.EmblemRarity, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GachaTicket> GachaTicket
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GachaTicket>(nameof (GachaTicket), new Func<MasterDataReader, MasterDataTable.GachaTicket>(MasterDataTable.GachaTicket.Parse), (Func<MasterDataTable.GachaTicket, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearBuildup> GearBuildup
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearBuildup>(nameof (GearBuildup), new Func<MasterDataReader, MasterDataTable.GearBuildup>(MasterDataTable.GearBuildup.Parse), (Func<MasterDataTable.GearBuildup, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearBuildupLogic> GearBuildupLogic
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearBuildupLogic>(nameof (GearBuildupLogic), new Func<MasterDataReader, MasterDataTable.GearBuildupLogic>(MasterDataTable.GearBuildupLogic.Parse), (Func<MasterDataTable.GearBuildupLogic, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearCombineRecipe> GearCombineRecipe
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearCombineRecipe>(nameof (GearCombineRecipe), new Func<MasterDataReader, MasterDataTable.GearCombineRecipe>(MasterDataTable.GearCombineRecipe.Parse), (Func<MasterDataTable.GearCombineRecipe, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearDisappearanceType> GearDisappearanceType
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearDisappearanceType>(nameof (GearDisappearanceType), new Func<MasterDataReader, MasterDataTable.GearDisappearanceType>(MasterDataTable.GearDisappearanceType.Parse), (Func<MasterDataTable.GearDisappearanceType, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearDrilling> GearDrilling
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearDrilling>(nameof (GearDrilling), new Func<MasterDataReader, MasterDataTable.GearDrilling>(MasterDataTable.GearDrilling.Parse), (Func<MasterDataTable.GearDrilling, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearElementRatio> GearElementRatio
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearElementRatio>(nameof (GearElementRatio), new Func<MasterDataReader, MasterDataTable.GearElementRatio>(MasterDataTable.GearElementRatio.Parse), (Func<MasterDataTable.GearElementRatio, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearGear> GearGear
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearGear>(nameof (GearGear), new Func<MasterDataReader, MasterDataTable.GearGear>(MasterDataTable.GearGear.Parse), (Func<MasterDataTable.GearGear, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearGearComposeParameter> GearGearComposeParameter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearGearComposeParameter>(nameof (GearGearComposeParameter), new Func<MasterDataReader, MasterDataTable.GearGearComposeParameter>(MasterDataTable.GearGearComposeParameter.Parse), (Func<MasterDataTable.GearGearComposeParameter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearGearDescription> GearGearDescription
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearGearDescription>(nameof (GearGearDescription), new Func<MasterDataReader, MasterDataTable.GearGearDescription>(MasterDataTable.GearGearDescription.Parse), (Func<MasterDataTable.GearGearDescription, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearGearElement> GearGearElement
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearGearElement>(nameof (GearGearElement), new Func<MasterDataReader, MasterDataTable.GearGearElement>(MasterDataTable.GearGearElement.Parse), (Func<MasterDataTable.GearGearElement, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearGearSkill> GearGearSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearGearSkill>(nameof (GearGearSkill), new Func<MasterDataReader, MasterDataTable.GearGearSkill>(MasterDataTable.GearGearSkill.Parse), (Func<MasterDataTable.GearGearSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearKind> GearKind
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearKind>(nameof (GearKind), new Func<MasterDataReader, MasterDataTable.GearKind>(MasterDataTable.GearKind.Parse), (Func<MasterDataTable.GearKind, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearKindCorrelations> GearKindCorrelations
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearKindCorrelations>(nameof (GearKindCorrelations), new Func<MasterDataReader, MasterDataTable.GearKindCorrelations>(MasterDataTable.GearKindCorrelations.Parse), (Func<MasterDataTable.GearKindCorrelations, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearKindIncr> GearKindIncr
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearKindIncr>(nameof (GearKindIncr), new Func<MasterDataReader, MasterDataTable.GearKindIncr>(MasterDataTable.GearKindIncr.Parse), (Func<MasterDataTable.GearKindIncr, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearKindRatio> GearKindRatio
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearKindRatio>(nameof (GearKindRatio), new Func<MasterDataReader, MasterDataTable.GearKindRatio>(MasterDataTable.GearKindRatio.Parse), (Func<MasterDataTable.GearKindRatio, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearMaterialQuestInfo> GearMaterialQuestInfo
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearMaterialQuestInfo>(nameof (GearMaterialQuestInfo), new Func<MasterDataReader, MasterDataTable.GearMaterialQuestInfo>(MasterDataTable.GearMaterialQuestInfo.Parse), (Func<MasterDataTable.GearMaterialQuestInfo, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearModelKind> GearModelKind
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearModelKind>(nameof (GearModelKind), new Func<MasterDataReader, MasterDataTable.GearModelKind>(MasterDataTable.GearModelKind.Parse), (Func<MasterDataTable.GearModelKind, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearRank> GearRank
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearRank>(nameof (GearRank), new Func<MasterDataReader, MasterDataTable.GearRank>(MasterDataTable.GearRank.Parse), (Func<MasterDataTable.GearRank, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearRankExp> GearRankExp
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearRankExp>(nameof (GearRankExp), new Func<MasterDataReader, MasterDataTable.GearRankExp>(MasterDataTable.GearRankExp.Parse), (Func<MasterDataTable.GearRankExp, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearRankIncr> GearRankIncr
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearRankIncr>(nameof (GearRankIncr), new Func<MasterDataReader, MasterDataTable.GearRankIncr>(MasterDataTable.GearRankIncr.Parse), (Func<MasterDataTable.GearRankIncr, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearRarity> GearRarity
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearRarity>(nameof (GearRarity), new Func<MasterDataReader, MasterDataTable.GearRarity>(MasterDataTable.GearRarity.Parse), (Func<MasterDataTable.GearRarity, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearSpecialDrillingCost> GearSpecialDrillingCost
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearSpecialDrillingCost>(nameof (GearSpecialDrillingCost), new Func<MasterDataReader, MasterDataTable.GearSpecialDrillingCost>(MasterDataTable.GearSpecialDrillingCost.Parse), (Func<MasterDataTable.GearSpecialDrillingCost, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GearSpecificationOfEquipmentUnit> GearSpecificationOfEquipmentUnit
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GearSpecificationOfEquipmentUnit>(nameof (GearSpecificationOfEquipmentUnit), new Func<MasterDataReader, MasterDataTable.GearSpecificationOfEquipmentUnit>(MasterDataTable.GearSpecificationOfEquipmentUnit.Parse), (Func<MasterDataTable.GearSpecificationOfEquipmentUnit, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildApprovalPolicy> GuildApprovalPolicy
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildApprovalPolicy>(nameof (GuildApprovalPolicy), new Func<MasterDataReader, MasterDataTable.GuildApprovalPolicy>(MasterDataTable.GuildApprovalPolicy.Parse), (Func<MasterDataTable.GuildApprovalPolicy, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildAtmosphere> GuildAtmosphere
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildAtmosphere>(nameof (GuildAtmosphere), new Func<MasterDataReader, MasterDataTable.GuildAtmosphere>(MasterDataTable.GuildAtmosphere.Parse), (Func<MasterDataTable.GuildAtmosphere, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildAutoApproval> GuildAutoApproval
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildAutoApproval>(nameof (GuildAutoApproval), new Func<MasterDataReader, MasterDataTable.GuildAutoApproval>(MasterDataTable.GuildAutoApproval.Parse), (Func<MasterDataTable.GuildAutoApproval, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildAvailability> GuildAvailability
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildAvailability>(nameof (GuildAvailability), new Func<MasterDataReader, MasterDataTable.GuildAvailability>(MasterDataTable.GuildAvailability.Parse), (Func<MasterDataTable.GuildAvailability, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildBankHowto> GuildBankHowto
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildBankHowto>(nameof (GuildBankHowto), new Func<MasterDataReader, MasterDataTable.GuildBankHowto>(MasterDataTable.GuildBankHowto.Parse), (Func<MasterDataTable.GuildBankHowto, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildBase> GuildBase
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildBase>(nameof (GuildBase), new Func<MasterDataReader, MasterDataTable.GuildBase>(MasterDataTable.GuildBase.Parse), (Func<MasterDataTable.GuildBase, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildBaseAnimation> GuildBaseAnimation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildBaseAnimation>(nameof (GuildBaseAnimation), new Func<MasterDataReader, MasterDataTable.GuildBaseAnimation>(MasterDataTable.GuildBaseAnimation.Parse), (Func<MasterDataTable.GuildBaseAnimation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildBaseBonus> GuildBaseBonus
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildBaseBonus>(nameof (GuildBaseBonus), new Func<MasterDataReader, MasterDataTable.GuildBaseBonus>(MasterDataTable.GuildBaseBonus.Parse), (Func<MasterDataTable.GuildBaseBonus, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildBasePos> GuildBasePos
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildBasePos>(nameof (GuildBasePos), new Func<MasterDataReader, MasterDataTable.GuildBasePos>(MasterDataTable.GuildBasePos.Parse), (Func<MasterDataTable.GuildBasePos, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildEmblemRarity> GuildEmblemRarity
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildEmblemRarity>(nameof (GuildEmblemRarity), new Func<MasterDataReader, MasterDataTable.GuildEmblemRarity>(MasterDataTable.GuildEmblemRarity.Parse), (Func<MasterDataTable.GuildEmblemRarity, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildEmblemUnit> GuildEmblemUnit
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildEmblemUnit>(nameof (GuildEmblemUnit), new Func<MasterDataReader, MasterDataTable.GuildEmblemUnit>(MasterDataTable.GuildEmblemUnit.Parse), (Func<MasterDataTable.GuildEmblemUnit, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildImagePattern> GuildImagePattern
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildImagePattern>(nameof (GuildImagePattern), new Func<MasterDataReader, MasterDataTable.GuildImagePattern>(MasterDataTable.GuildImagePattern.Parse), (Func<MasterDataTable.GuildImagePattern, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildRoleName> GuildRoleName
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildRoleName>(nameof (GuildRoleName), new Func<MasterDataReader, MasterDataTable.GuildRoleName>(MasterDataTable.GuildRoleName.Parse), (Func<MasterDataTable.GuildRoleName, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildSetting> GuildSetting
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildSetting>(nameof (GuildSetting), new Func<MasterDataReader, MasterDataTable.GuildSetting>(MasterDataTable.GuildSetting.Parse), (Func<MasterDataTable.GuildSetting, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildStamp> GuildStamp
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildStamp>(nameof (GuildStamp), new Func<MasterDataReader, MasterDataTable.GuildStamp>(MasterDataTable.GuildStamp.Parse), (Func<MasterDataTable.GuildStamp, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GuildStampGroup> GuildStampGroup
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GuildStampGroup>(nameof (GuildStampGroup), new Func<MasterDataReader, MasterDataTable.GuildStampGroup>(MasterDataTable.GuildStampGroup.Parse), (Func<MasterDataTable.GuildStampGroup, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GvgSettings> GvgSettings
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GvgSettings>(nameof (GvgSettings), new Func<MasterDataReader, MasterDataTable.GvgSettings>(MasterDataTable.GvgSettings.Parse), (Func<MasterDataTable.GvgSettings, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GvgStageFormation> GvgStageFormation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GvgStageFormation>(nameof (GvgStageFormation), new Func<MasterDataReader, MasterDataTable.GvgStageFormation>(MasterDataTable.GvgStageFormation.Parse), (Func<MasterDataTable.GvgStageFormation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.GvgStarCondition> GvgStarCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.GvgStarCondition>(nameof (GvgStarCondition), new Func<MasterDataReader, MasterDataTable.GvgStarCondition>(MasterDataTable.GvgStarCondition.Parse), (Func<MasterDataTable.GvgStarCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.HelpCategory> HelpCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.HelpCategory>(nameof (HelpCategory), new Func<MasterDataReader, MasterDataTable.HelpCategory>(MasterDataTable.HelpCategory.Parse), (Func<MasterDataTable.HelpCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.HelpHelp> HelpHelp
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.HelpHelp>(nameof (HelpHelp), new Func<MasterDataReader, MasterDataTable.HelpHelp>(MasterDataTable.HelpHelp.Parse), (Func<MasterDataTable.HelpHelp, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.InformationCategory> InformationCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.InformationCategory>(nameof (InformationCategory), new Func<MasterDataReader, MasterDataTable.InformationCategory>(MasterDataTable.InformationCategory.Parse), (Func<MasterDataTable.InformationCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.InformationInformation> InformationInformation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.InformationInformation>(nameof (InformationInformation), new Func<MasterDataReader, MasterDataTable.InformationInformation>(MasterDataTable.InformationInformation.Parse), (Func<MasterDataTable.InformationInformation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.InformationSubCategory> InformationSubCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.InformationSubCategory>(nameof (InformationSubCategory), new Func<MasterDataReader, MasterDataTable.InformationSubCategory>(MasterDataTable.InformationSubCategory.Parse), (Func<MasterDataTable.InformationSubCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.InitimateBreakthrough> InitimateBreakthrough
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.InitimateBreakthrough>(nameof (InitimateBreakthrough), new Func<MasterDataReader, MasterDataTable.InitimateBreakthrough>(MasterDataTable.InitimateBreakthrough.Parse), (Func<MasterDataTable.InitimateBreakthrough, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.InitimateLevel> InitimateLevel
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.InitimateLevel>(nameof (InitimateLevel), new Func<MasterDataReader, MasterDataTable.InitimateLevel>(MasterDataTable.InitimateLevel.Parse), (Func<MasterDataTable.InitimateLevel, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.IntimateDuelSupport> IntimateDuelSupport
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.IntimateDuelSupport>(nameof (IntimateDuelSupport), new Func<MasterDataReader, MasterDataTable.IntimateDuelSupport>(MasterDataTable.IntimateDuelSupport.Parse), (Func<MasterDataTable.IntimateDuelSupport, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.InvitationInvitation> InvitationInvitation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.InvitationInvitation>(nameof (InvitationInvitation), new Func<MasterDataReader, MasterDataTable.InvitationInvitation>(MasterDataTable.InvitationInvitation.Parse), (Func<MasterDataTable.InvitationInvitation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.LoginbonusLoginbonus> LoginbonusLoginbonus
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.LoginbonusLoginbonus>(nameof (LoginbonusLoginbonus), new Func<MasterDataReader, MasterDataTable.LoginbonusLoginbonus>(MasterDataTable.LoginbonusLoginbonus.Parse), (Func<MasterDataTable.LoginbonusLoginbonus, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.LoginbonusReward> LoginbonusReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.LoginbonusReward>(nameof (LoginbonusReward), new Func<MasterDataReader, MasterDataTable.LoginbonusReward>(MasterDataTable.LoginbonusReward.Parse), (Func<MasterDataTable.LoginbonusReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PlayerLevelUpStatus> PlayerLevelUpStatus
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PlayerLevelUpStatus>(nameof (PlayerLevelUpStatus), new Func<MasterDataReader, MasterDataTable.PlayerLevelUpStatus>(MasterDataTable.PlayerLevelUpStatus.Parse), (Func<MasterDataTable.PlayerLevelUpStatus, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PunitiveExpeditionEventGuildReward> PunitiveExpeditionEventGuildReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PunitiveExpeditionEventGuildReward>(nameof (PunitiveExpeditionEventGuildReward), new Func<MasterDataReader, MasterDataTable.PunitiveExpeditionEventGuildReward>(MasterDataTable.PunitiveExpeditionEventGuildReward.Parse), (Func<MasterDataTable.PunitiveExpeditionEventGuildReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PunitiveExpeditionEventReward> PunitiveExpeditionEventReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PunitiveExpeditionEventReward>(nameof (PunitiveExpeditionEventReward), new Func<MasterDataReader, MasterDataTable.PunitiveExpeditionEventReward>(MasterDataTable.PunitiveExpeditionEventReward.Parse), (Func<MasterDataTable.PunitiveExpeditionEventReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PvpBonus> PvpBonus
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PvpBonus>(nameof (PvpBonus), new Func<MasterDataReader, MasterDataTable.PvpBonus>(MasterDataTable.PvpBonus.Parse), (Func<MasterDataTable.PvpBonus, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PvpClassKind> PvpClassKind
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PvpClassKind>(nameof (PvpClassKind), new Func<MasterDataReader, MasterDataTable.PvpClassKind>(MasterDataTable.PvpClassKind.Parse), (Func<MasterDataTable.PvpClassKind, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PvpClassReward> PvpClassReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PvpClassReward>(nameof (PvpClassReward), new Func<MasterDataReader, MasterDataTable.PvpClassReward>(MasterDataTable.PvpClassReward.Parse), (Func<MasterDataTable.PvpClassReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PvpMatchingType> PvpMatchingType
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PvpMatchingType>(nameof (PvpMatchingType), new Func<MasterDataReader, MasterDataTable.PvpMatchingType>(MasterDataTable.PvpMatchingType.Parse), (Func<MasterDataTable.PvpMatchingType, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PvpRankingCondition> PvpRankingCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PvpRankingCondition>(nameof (PvpRankingCondition), new Func<MasterDataReader, MasterDataTable.PvpRankingCondition>(MasterDataTable.PvpRankingCondition.Parse), (Func<MasterDataTable.PvpRankingCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PvpRankingReward> PvpRankingReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PvpRankingReward>(nameof (PvpRankingReward), new Func<MasterDataReader, MasterDataTable.PvpRankingReward>(MasterDataTable.PvpRankingReward.Parse), (Func<MasterDataTable.PvpRankingReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PvpStageFormation> PvpStageFormation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PvpStageFormation>(nameof (PvpStageFormation), new Func<MasterDataReader, MasterDataTable.PvpStageFormation>(MasterDataTable.PvpStageFormation.Parse), (Func<MasterDataTable.PvpStageFormation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.PvpVictoryEffect> PvpVictoryEffect
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.PvpVictoryEffect>(nameof (PvpVictoryEffect), new Func<MasterDataReader, MasterDataTable.PvpVictoryEffect>(MasterDataTable.PvpVictoryEffect.Parse), (Func<MasterDataTable.PvpVictoryEffect, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCharacterDisplayCondition> QuestCharacterDisplayCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCharacterDisplayCondition>(nameof (QuestCharacterDisplayCondition), new Func<MasterDataReader, MasterDataTable.QuestCharacterDisplayCondition>(MasterDataTable.QuestCharacterDisplayCondition.Parse), (Func<MasterDataTable.QuestCharacterDisplayCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCharacterLimitation> QuestCharacterLimitation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCharacterLimitation>(nameof (QuestCharacterLimitation), new Func<MasterDataReader, MasterDataTable.QuestCharacterLimitation>(MasterDataTable.QuestCharacterLimitation.Parse), (Func<MasterDataTable.QuestCharacterLimitation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCharacterLimitationLabel> QuestCharacterLimitationLabel
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCharacterLimitationLabel>(nameof (QuestCharacterLimitationLabel), new Func<MasterDataReader, MasterDataTable.QuestCharacterLimitationLabel>(MasterDataTable.QuestCharacterLimitationLabel.Parse), (Func<MasterDataTable.QuestCharacterLimitationLabel, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCharacterM> QuestCharacterM
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCharacterM>(nameof (QuestCharacterM), new Func<MasterDataReader, MasterDataTable.QuestCharacterM>(MasterDataTable.QuestCharacterM.Parse), (Func<MasterDataTable.QuestCharacterM, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCharacterMReleaseCondition> QuestCharacterMReleaseCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCharacterMReleaseCondition>(nameof (QuestCharacterMReleaseCondition), new Func<MasterDataReader, MasterDataTable.QuestCharacterMReleaseCondition>(MasterDataTable.QuestCharacterMReleaseCondition.Parse), (Func<MasterDataTable.QuestCharacterMReleaseCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCharacterReleaseCondition> QuestCharacterReleaseCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCharacterReleaseCondition>(nameof (QuestCharacterReleaseCondition), new Func<MasterDataReader, MasterDataTable.QuestCharacterReleaseCondition>(MasterDataTable.QuestCharacterReleaseCondition.Parse), (Func<MasterDataTable.QuestCharacterReleaseCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCharacterS> QuestCharacterS
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCharacterS>(nameof (QuestCharacterS), new Func<MasterDataReader, MasterDataTable.QuestCharacterS>(MasterDataTable.QuestCharacterS.Parse), (Func<MasterDataTable.QuestCharacterS, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCommonBackground> QuestCommonBackground
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCommonBackground>(nameof (QuestCommonBackground), new Func<MasterDataReader, MasterDataTable.QuestCommonBackground>(MasterDataTable.QuestCommonBackground.Parse), (Func<MasterDataTable.QuestCommonBackground, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCommonDrop> QuestCommonDrop
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCommonDrop>(nameof (QuestCommonDrop), new Func<MasterDataReader, MasterDataTable.QuestCommonDrop>(MasterDataTable.QuestCommonDrop.Parse), (Func<MasterDataTable.QuestCommonDrop, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestCommonSpecialColor> QuestCommonSpecialColor
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestCommonSpecialColor>(nameof (QuestCommonSpecialColor), new Func<MasterDataReader, MasterDataTable.QuestCommonSpecialColor>(MasterDataTable.QuestCommonSpecialColor.Parse), (Func<MasterDataTable.QuestCommonSpecialColor, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraCategory> QuestExtraCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraCategory>(nameof (QuestExtraCategory), new Func<MasterDataReader, MasterDataTable.QuestExtraCategory>(MasterDataTable.QuestExtraCategory.Parse), (Func<MasterDataTable.QuestExtraCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraDescription> QuestExtraDescription
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraDescription>(nameof (QuestExtraDescription), new Func<MasterDataReader, MasterDataTable.QuestExtraDescription>(MasterDataTable.QuestExtraDescription.Parse), (Func<MasterDataTable.QuestExtraDescription, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraL> QuestExtraL
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraL>(nameof (QuestExtraL), new Func<MasterDataReader, MasterDataTable.QuestExtraL>(MasterDataTable.QuestExtraL.Parse), (Func<MasterDataTable.QuestExtraL, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraLimitation> QuestExtraLimitation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraLimitation>(nameof (QuestExtraLimitation), new Func<MasterDataReader, MasterDataTable.QuestExtraLimitation>(MasterDataTable.QuestExtraLimitation.Parse), (Func<MasterDataTable.QuestExtraLimitation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraLimitationLabel> QuestExtraLimitationLabel
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraLimitationLabel>(nameof (QuestExtraLimitationLabel), new Func<MasterDataReader, MasterDataTable.QuestExtraLimitationLabel>(MasterDataTable.QuestExtraLimitationLabel.Parse), (Func<MasterDataTable.QuestExtraLimitationLabel, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraM> QuestExtraM
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraM>(nameof (QuestExtraM), new Func<MasterDataReader, MasterDataTable.QuestExtraM>(MasterDataTable.QuestExtraM.Parse), (Func<MasterDataTable.QuestExtraM, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraMission> QuestExtraMission
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraMission>(nameof (QuestExtraMission), new Func<MasterDataReader, MasterDataTable.QuestExtraMission>(MasterDataTable.QuestExtraMission.Parse), (Func<MasterDataTable.QuestExtraMission, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraS> QuestExtraS
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraS>(nameof (QuestExtraS), new Func<MasterDataReader, MasterDataTable.QuestExtraS>(MasterDataTable.QuestExtraS.Parse), (Func<MasterDataTable.QuestExtraS, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraScoreAchivementReward> QuestExtraScoreAchivementReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraScoreAchivementReward>(nameof (QuestExtraScoreAchivementReward), new Func<MasterDataReader, MasterDataTable.QuestExtraScoreAchivementReward>(MasterDataTable.QuestExtraScoreAchivementReward.Parse), (Func<MasterDataTable.QuestExtraScoreAchivementReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraScoreRankingReward> QuestExtraScoreRankingReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraScoreRankingReward>(nameof (QuestExtraScoreRankingReward), new Func<MasterDataReader, MasterDataTable.QuestExtraScoreRankingReward>(MasterDataTable.QuestExtraScoreRankingReward.Parse), (Func<MasterDataTable.QuestExtraScoreRankingReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraTotalScoreReward> QuestExtraTotalScoreReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraTotalScoreReward>(nameof (QuestExtraTotalScoreReward), new Func<MasterDataReader, MasterDataTable.QuestExtraTotalScoreReward>(MasterDataTable.QuestExtraTotalScoreReward.Parse), (Func<MasterDataTable.QuestExtraTotalScoreReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestExtraXL> QuestExtraXL
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestExtraXL>(nameof (QuestExtraXL), new Func<MasterDataReader, MasterDataTable.QuestExtraXL>(MasterDataTable.QuestExtraXL.Parse), (Func<MasterDataTable.QuestExtraXL, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestHarmonyDisplayCondition> QuestHarmonyDisplayCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestHarmonyDisplayCondition>(nameof (QuestHarmonyDisplayCondition), new Func<MasterDataReader, MasterDataTable.QuestHarmonyDisplayCondition>(MasterDataTable.QuestHarmonyDisplayCondition.Parse), (Func<MasterDataTable.QuestHarmonyDisplayCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestHarmonyLimitation> QuestHarmonyLimitation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestHarmonyLimitation>(nameof (QuestHarmonyLimitation), new Func<MasterDataReader, MasterDataTable.QuestHarmonyLimitation>(MasterDataTable.QuestHarmonyLimitation.Parse), (Func<MasterDataTable.QuestHarmonyLimitation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestHarmonyLimitationLabel> QuestHarmonyLimitationLabel
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestHarmonyLimitationLabel>(nameof (QuestHarmonyLimitationLabel), new Func<MasterDataReader, MasterDataTable.QuestHarmonyLimitationLabel>(MasterDataTable.QuestHarmonyLimitationLabel.Parse), (Func<MasterDataTable.QuestHarmonyLimitationLabel, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestHarmonyM> QuestHarmonyM
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestHarmonyM>(nameof (QuestHarmonyM), new Func<MasterDataReader, MasterDataTable.QuestHarmonyM>(MasterDataTable.QuestHarmonyM.Parse), (Func<MasterDataTable.QuestHarmonyM, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestHarmonyReleaseCondition> QuestHarmonyReleaseCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestHarmonyReleaseCondition>(nameof (QuestHarmonyReleaseCondition), new Func<MasterDataReader, MasterDataTable.QuestHarmonyReleaseCondition>(MasterDataTable.QuestHarmonyReleaseCondition.Parse), (Func<MasterDataTable.QuestHarmonyReleaseCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestHarmonyS> QuestHarmonyS
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestHarmonyS>(nameof (QuestHarmonyS), new Func<MasterDataReader, MasterDataTable.QuestHarmonyS>(MasterDataTable.QuestHarmonyS.Parse), (Func<MasterDataTable.QuestHarmonyS, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestMoviePath> QuestMoviePath
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestMoviePath>(nameof (QuestMoviePath), new Func<MasterDataReader, MasterDataTable.QuestMoviePath>(MasterDataTable.QuestMoviePath.Parse), (Func<MasterDataTable.QuestMoviePath, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestMovieQuest> QuestMovieQuest
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestMovieQuest>(nameof (QuestMovieQuest), new Func<MasterDataReader, MasterDataTable.QuestMovieQuest>(MasterDataTable.QuestMovieQuest.Parse), (Func<MasterDataTable.QuestMovieQuest, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryClearMessage> QuestStoryClearMessage
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryClearMessage>(nameof (QuestStoryClearMessage), new Func<MasterDataReader, MasterDataTable.QuestStoryClearMessage>(MasterDataTable.QuestStoryClearMessage.Parse), (Func<MasterDataTable.QuestStoryClearMessage, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryL> QuestStoryL
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryL>(nameof (QuestStoryL), new Func<MasterDataReader, MasterDataTable.QuestStoryL>(MasterDataTable.QuestStoryL.Parse), (Func<MasterDataTable.QuestStoryL, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryLimitation> QuestStoryLimitation
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryLimitation>(nameof (QuestStoryLimitation), new Func<MasterDataReader, MasterDataTable.QuestStoryLimitation>(MasterDataTable.QuestStoryLimitation.Parse), (Func<MasterDataTable.QuestStoryLimitation, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryLimitationLabel> QuestStoryLimitationLabel
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryLimitationLabel>(nameof (QuestStoryLimitationLabel), new Func<MasterDataReader, MasterDataTable.QuestStoryLimitationLabel>(MasterDataTable.QuestStoryLimitationLabel.Parse), (Func<MasterDataTable.QuestStoryLimitationLabel, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryM> QuestStoryM
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryM>(nameof (QuestStoryM), new Func<MasterDataReader, MasterDataTable.QuestStoryM>(MasterDataTable.QuestStoryM.Parse), (Func<MasterDataTable.QuestStoryM, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryMission> QuestStoryMission
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryMission>(nameof (QuestStoryMission), new Func<MasterDataReader, MasterDataTable.QuestStoryMission>(MasterDataTable.QuestStoryMission.Parse), (Func<MasterDataTable.QuestStoryMission, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryMissionReward> QuestStoryMissionReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryMissionReward>(nameof (QuestStoryMissionReward), new Func<MasterDataReader, MasterDataTable.QuestStoryMissionReward>(MasterDataTable.QuestStoryMissionReward.Parse), (Func<MasterDataTable.QuestStoryMissionReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryS> QuestStoryS
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryS>(nameof (QuestStoryS), new Func<MasterDataReader, MasterDataTable.QuestStoryS>(MasterDataTable.QuestStoryS.Parse), (Func<MasterDataTable.QuestStoryS, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestStoryXL> QuestStoryXL
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestStoryXL>(nameof (QuestStoryXL), new Func<MasterDataReader, MasterDataTable.QuestStoryXL>(MasterDataTable.QuestStoryXL.Parse), (Func<MasterDataTable.QuestStoryXL, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestWave> QuestWave
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestWave>(nameof (QuestWave), new Func<MasterDataReader, MasterDataTable.QuestWave>(MasterDataTable.QuestWave.Parse), (Func<MasterDataTable.QuestWave, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestkeyCondition> QuestkeyCondition
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestkeyCondition>(nameof (QuestkeyCondition), new Func<MasterDataReader, MasterDataTable.QuestkeyCondition>(MasterDataTable.QuestkeyCondition.Parse), (Func<MasterDataTable.QuestkeyCondition, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.QuestkeyQuestkey> QuestkeyQuestkey
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.QuestkeyQuestkey>(nameof (QuestkeyQuestkey), new Func<MasterDataReader, MasterDataTable.QuestkeyQuestkey>(MasterDataTable.QuestkeyQuestkey.Parse), (Func<MasterDataTable.QuestkeyQuestkey, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ReviewReward> ReviewReward
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ReviewReward>(nameof (ReviewReward), new Func<MasterDataReader, MasterDataTable.ReviewReward>(MasterDataTable.ReviewReward.Parse), (Func<MasterDataTable.ReviewReward, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ScriptScript> ScriptScript
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ScriptScript>(nameof (ScriptScript), new Func<MasterDataReader, MasterDataTable.ScriptScript>(MasterDataTable.ScriptScript.Parse), (Func<MasterDataTable.ScriptScript, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.SeasonTicketSeasonTicket> SeasonTicketSeasonTicket
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.SeasonTicketSeasonTicket>(nameof (SeasonTicketSeasonTicket), new Func<MasterDataReader, MasterDataTable.SeasonTicketSeasonTicket>(MasterDataTable.SeasonTicketSeasonTicket.Parse), (Func<MasterDataTable.SeasonTicketSeasonTicket, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ShopArticle> ShopArticle
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ShopArticle>(nameof (ShopArticle), new Func<MasterDataReader, MasterDataTable.ShopArticle>(MasterDataTable.ShopArticle.Parse), (Func<MasterDataTable.ShopArticle, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ShopContent> ShopContent
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ShopContent>(nameof (ShopContent), new Func<MasterDataReader, MasterDataTable.ShopContent>(MasterDataTable.ShopContent.Parse), (Func<MasterDataTable.ShopContent, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ShopShop> ShopShop
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ShopShop>(nameof (ShopShop), new Func<MasterDataReader, MasterDataTable.ShopShop>(MasterDataTable.ShopShop.Parse), (Func<MasterDataTable.ShopShop, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.ShopTopUnit> ShopTopUnit
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.ShopTopUnit>(nameof (ShopTopUnit), new Func<MasterDataReader, MasterDataTable.ShopTopUnit>(MasterDataTable.ShopTopUnit.Parse), (Func<MasterDataTable.ShopTopUnit, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.SlotS001MedalDeck> SlotS001MedalDeck
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.SlotS001MedalDeck>(nameof (SlotS001MedalDeck), new Func<MasterDataReader, MasterDataTable.SlotS001MedalDeck>(MasterDataTable.SlotS001MedalDeck.Parse), (Func<MasterDataTable.SlotS001MedalDeck, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.SlotS001MedalDeckEntity> SlotS001MedalDeckEntity
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.SlotS001MedalDeckEntity>(nameof (SlotS001MedalDeckEntity), new Func<MasterDataReader, MasterDataTable.SlotS001MedalDeckEntity>(MasterDataTable.SlotS001MedalDeckEntity.Parse), (Func<MasterDataTable.SlotS001MedalDeckEntity, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.SlotS001MedalRarity> SlotS001MedalRarity
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.SlotS001MedalRarity>(nameof (SlotS001MedalRarity), new Func<MasterDataReader, MasterDataTable.SlotS001MedalRarity>(MasterDataTable.SlotS001MedalRarity.Parse), (Func<MasterDataTable.SlotS001MedalRarity, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.SlotS001MedalReel> SlotS001MedalReel
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.SlotS001MedalReel>(nameof (SlotS001MedalReel), new Func<MasterDataReader, MasterDataTable.SlotS001MedalReel>(MasterDataTable.SlotS001MedalReel.Parse), (Func<MasterDataTable.SlotS001MedalReel, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.SlotS001MedalReelDetail> SlotS001MedalReelDetail
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.SlotS001MedalReelDetail>(nameof (SlotS001MedalReelDetail), new Func<MasterDataReader, MasterDataTable.SlotS001MedalReelDetail>(MasterDataTable.SlotS001MedalReelDetail.Parse), (Func<MasterDataTable.SlotS001MedalReelDetail, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.SlotS001MedalReelIcon> SlotS001MedalReelIcon
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.SlotS001MedalReelIcon>(nameof (SlotS001MedalReelIcon), new Func<MasterDataReader, MasterDataTable.SlotS001MedalReelIcon>(MasterDataTable.SlotS001MedalReelIcon.Parse), (Func<MasterDataTable.SlotS001MedalReelIcon, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackCharacter> StoryPlaybackCharacter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackCharacter>(nameof (StoryPlaybackCharacter), new Func<MasterDataReader, MasterDataTable.StoryPlaybackCharacter>(MasterDataTable.StoryPlaybackCharacter.Parse), (Func<MasterDataTable.StoryPlaybackCharacter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackCharacterDetail> StoryPlaybackCharacterDetail
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackCharacterDetail>(nameof (StoryPlaybackCharacterDetail), new Func<MasterDataReader, MasterDataTable.StoryPlaybackCharacterDetail>(MasterDataTable.StoryPlaybackCharacterDetail.Parse), (Func<MasterDataTable.StoryPlaybackCharacterDetail, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackEventPlay> StoryPlaybackEventPlay
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackEventPlay>(nameof (StoryPlaybackEventPlay), new Func<MasterDataReader, MasterDataTable.StoryPlaybackEventPlay>(MasterDataTable.StoryPlaybackEventPlay.Parse), (Func<MasterDataTable.StoryPlaybackEventPlay, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackExtra> StoryPlaybackExtra
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackExtra>(nameof (StoryPlaybackExtra), new Func<MasterDataReader, MasterDataTable.StoryPlaybackExtra>(MasterDataTable.StoryPlaybackExtra.Parse), (Func<MasterDataTable.StoryPlaybackExtra, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackExtraDetail> StoryPlaybackExtraDetail
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackExtraDetail>(nameof (StoryPlaybackExtraDetail), new Func<MasterDataReader, MasterDataTable.StoryPlaybackExtraDetail>(MasterDataTable.StoryPlaybackExtraDetail.Parse), (Func<MasterDataTable.StoryPlaybackExtraDetail, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackHarmony> StoryPlaybackHarmony
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackHarmony>(nameof (StoryPlaybackHarmony), new Func<MasterDataReader, MasterDataTable.StoryPlaybackHarmony>(MasterDataTable.StoryPlaybackHarmony.Parse), (Func<MasterDataTable.StoryPlaybackHarmony, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackHarmonyDetail> StoryPlaybackHarmonyDetail
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackHarmonyDetail>(nameof (StoryPlaybackHarmonyDetail), new Func<MasterDataReader, MasterDataTable.StoryPlaybackHarmonyDetail>(MasterDataTable.StoryPlaybackHarmonyDetail.Parse), (Func<MasterDataTable.StoryPlaybackHarmonyDetail, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackStory> StoryPlaybackStory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackStory>(nameof (StoryPlaybackStory), new Func<MasterDataReader, MasterDataTable.StoryPlaybackStory>(MasterDataTable.StoryPlaybackStory.Parse), (Func<MasterDataTable.StoryPlaybackStory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.StoryPlaybackStoryDetail> StoryPlaybackStoryDetail
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.StoryPlaybackStoryDetail>(nameof (StoryPlaybackStoryDetail), new Func<MasterDataReader, MasterDataTable.StoryPlaybackStoryDetail>(MasterDataTable.StoryPlaybackStoryDetail.Parse), (Func<MasterDataTable.StoryPlaybackStoryDetail, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.SupplySupply> SupplySupply
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.SupplySupply>(nameof (SupplySupply), new Func<MasterDataReader, MasterDataTable.SupplySupply>(MasterDataTable.SupplySupply.Parse), (Func<MasterDataTable.SupplySupply, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.TipsTips> TipsTips
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.TipsTips>(nameof (TipsTips), new Func<MasterDataReader, MasterDataTable.TipsTips>(MasterDataTable.TipsTips.Parse), (Func<MasterDataTable.TipsTips, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitBreakThrough> UnitBreakThrough
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitBreakThrough>(nameof (UnitBreakThrough), new Func<MasterDataReader, MasterDataTable.UnitBreakThrough>(MasterDataTable.UnitBreakThrough.Parse), (Func<MasterDataTable.UnitBreakThrough, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitCameraPattern> UnitCameraPattern
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitCameraPattern>(nameof (UnitCameraPattern), new Func<MasterDataReader, MasterDataTable.UnitCameraPattern>(MasterDataTable.UnitCameraPattern.Parse), (Func<MasterDataTable.UnitCameraPattern, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitCharacter> UnitCharacter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitCharacter>(nameof (UnitCharacter), new Func<MasterDataReader, MasterDataTable.UnitCharacter>(MasterDataTable.UnitCharacter.Parse), (Func<MasterDataTable.UnitCharacter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitEvolutionPattern> UnitEvolutionPattern
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitEvolutionPattern>(nameof (UnitEvolutionPattern), new Func<MasterDataReader, MasterDataTable.UnitEvolutionPattern>(MasterDataTable.UnitEvolutionPattern.Parse), (Func<MasterDataTable.UnitEvolutionPattern, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitEvolutionUnit> UnitEvolutionUnit
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitEvolutionUnit>(nameof (UnitEvolutionUnit), new Func<MasterDataReader, MasterDataTable.UnitEvolutionUnit>(MasterDataTable.UnitEvolutionUnit.Parse), (Func<MasterDataTable.UnitEvolutionUnit, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitFamilyValue> UnitFamilyValue
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitFamilyValue>(nameof (UnitFamilyValue), new Func<MasterDataReader, MasterDataTable.UnitFamilyValue>(MasterDataTable.UnitFamilyValue.Parse), (Func<MasterDataTable.UnitFamilyValue, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitFootstepType> UnitFootstepType
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitFootstepType>(nameof (UnitFootstepType), new Func<MasterDataReader, MasterDataTable.UnitFootstepType>(MasterDataTable.UnitFootstepType.Parse), (Func<MasterDataTable.UnitFootstepType, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitGenderText> UnitGenderText
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitGenderText>(nameof (UnitGenderText), new Func<MasterDataReader, MasterDataTable.UnitGenderText>(MasterDataTable.UnitGenderText.Parse), (Func<MasterDataTable.UnitGenderText, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitGroup> UnitGroup
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitGroup>(nameof (UnitGroup), new Func<MasterDataReader, MasterDataTable.UnitGroup>(MasterDataTable.UnitGroup.Parse), (Func<MasterDataTable.UnitGroup, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitGroupClothingCategory> UnitGroupClothingCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitGroupClothingCategory>(nameof (UnitGroupClothingCategory), new Func<MasterDataReader, MasterDataTable.UnitGroupClothingCategory>(MasterDataTable.UnitGroupClothingCategory.Parse), (Func<MasterDataTable.UnitGroupClothingCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitGroupGenerationCategory> UnitGroupGenerationCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitGroupGenerationCategory>(nameof (UnitGroupGenerationCategory), new Func<MasterDataReader, MasterDataTable.UnitGroupGenerationCategory>(MasterDataTable.UnitGroupGenerationCategory.Parse), (Func<MasterDataTable.UnitGroupGenerationCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitGroupLargeCategory> UnitGroupLargeCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitGroupLargeCategory>(nameof (UnitGroupLargeCategory), new Func<MasterDataReader, MasterDataTable.UnitGroupLargeCategory>(MasterDataTable.UnitGroupLargeCategory.Parse), (Func<MasterDataTable.UnitGroupLargeCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitGroupSmallCategory> UnitGroupSmallCategory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitGroupSmallCategory>(nameof (UnitGroupSmallCategory), new Func<MasterDataReader, MasterDataTable.UnitGroupSmallCategory>(MasterDataTable.UnitGroupSmallCategory.Parse), (Func<MasterDataTable.UnitGroupSmallCategory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitHomeVoicePattern> UnitHomeVoicePattern
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitHomeVoicePattern>(nameof (UnitHomeVoicePattern), new Func<MasterDataReader, MasterDataTable.UnitHomeVoicePattern>(MasterDataTable.UnitHomeVoicePattern.Parse), (Func<MasterDataTable.UnitHomeVoicePattern, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitIllustPattern> UnitIllustPattern
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitIllustPattern>(nameof (UnitIllustPattern), new Func<MasterDataReader, MasterDataTable.UnitIllustPattern>(MasterDataTable.UnitIllustPattern.Parse), (Func<MasterDataTable.UnitIllustPattern, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitJob> UnitJob
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitJob>(nameof (UnitJob), new Func<MasterDataReader, MasterDataTable.UnitJob>(MasterDataTable.UnitJob.Parse), (Func<MasterDataTable.UnitJob, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitLeaderSkill> UnitLeaderSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitLeaderSkill>(nameof (UnitLeaderSkill), new Func<MasterDataReader, MasterDataTable.UnitLeaderSkill>(MasterDataTable.UnitLeaderSkill.Parse), (Func<MasterDataTable.UnitLeaderSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitLevel> UnitLevel
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitLevel>(nameof (UnitLevel), new Func<MasterDataReader, MasterDataTable.UnitLevel>(MasterDataTable.UnitLevel.Parse), (Func<MasterDataTable.UnitLevel, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitMaterialQuestInfo> UnitMaterialQuestInfo
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitMaterialQuestInfo>(nameof (UnitMaterialQuestInfo), new Func<MasterDataReader, MasterDataTable.UnitMaterialQuestInfo>(MasterDataTable.UnitMaterialQuestInfo.Parse), (Func<MasterDataTable.UnitMaterialQuestInfo, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitPickupSkill> UnitPickupSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitPickupSkill>(nameof (UnitPickupSkill), new Func<MasterDataReader, MasterDataTable.UnitPickupSkill>(MasterDataTable.UnitPickupSkill.Parse), (Func<MasterDataTable.UnitPickupSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitProficiency> UnitProficiency
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitProficiency>(nameof (UnitProficiency), new Func<MasterDataReader, MasterDataTable.UnitProficiency>(MasterDataTable.UnitProficiency.Parse), (Func<MasterDataTable.UnitProficiency, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitProficiencyIncr> UnitProficiencyIncr
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitProficiencyIncr>(nameof (UnitProficiencyIncr), new Func<MasterDataReader, MasterDataTable.UnitProficiencyIncr>(MasterDataTable.UnitProficiencyIncr.Parse), (Func<MasterDataTable.UnitProficiencyIncr, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitProficiencyLevel> UnitProficiencyLevel
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitProficiencyLevel>(nameof (UnitProficiencyLevel), new Func<MasterDataReader, MasterDataTable.UnitProficiencyLevel>(MasterDataTable.UnitProficiencyLevel.Parse), (Func<MasterDataTable.UnitProficiencyLevel, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitRarity> UnitRarity
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitRarity>(nameof (UnitRarity), new Func<MasterDataReader, MasterDataTable.UnitRarity>(MasterDataTable.UnitRarity.Parse), (Func<MasterDataTable.UnitRarity, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitSkill> UnitSkill
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitSkill>(nameof (UnitSkill), new Func<MasterDataReader, MasterDataTable.UnitSkill>(MasterDataTable.UnitSkill.Parse), (Func<MasterDataTable.UnitSkill, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitSkillCharacterQuest> UnitSkillCharacterQuest
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitSkillCharacterQuest>(nameof (UnitSkillCharacterQuest), new Func<MasterDataReader, MasterDataTable.UnitSkillCharacterQuest>(MasterDataTable.UnitSkillCharacterQuest.Parse), (Func<MasterDataTable.UnitSkillCharacterQuest, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitSkillEvolution> UnitSkillEvolution
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitSkillEvolution>(nameof (UnitSkillEvolution), new Func<MasterDataReader, MasterDataTable.UnitSkillEvolution>(MasterDataTable.UnitSkillEvolution.Parse), (Func<MasterDataTable.UnitSkillEvolution, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitSkillHarmonyQuest> UnitSkillHarmonyQuest
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitSkillHarmonyQuest>(nameof (UnitSkillHarmonyQuest), new Func<MasterDataReader, MasterDataTable.UnitSkillHarmonyQuest>(MasterDataTable.UnitSkillHarmonyQuest.Parse), (Func<MasterDataTable.UnitSkillHarmonyQuest, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitSkillIntimate> UnitSkillIntimate
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitSkillIntimate>(nameof (UnitSkillIntimate), new Func<MasterDataReader, MasterDataTable.UnitSkillIntimate>(MasterDataTable.UnitSkillIntimate.Parse), (Func<MasterDataTable.UnitSkillIntimate, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitSkillLevelUpProbability> UnitSkillLevelUpProbability
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitSkillLevelUpProbability>(nameof (UnitSkillLevelUpProbability), new Func<MasterDataReader, MasterDataTable.UnitSkillLevelUpProbability>(MasterDataTable.UnitSkillLevelUpProbability.Parse), (Func<MasterDataTable.UnitSkillLevelUpProbability, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitSkillupSetting> UnitSkillupSetting
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitSkillupSetting>(nameof (UnitSkillupSetting), new Func<MasterDataReader, MasterDataTable.UnitSkillupSetting>(MasterDataTable.UnitSkillupSetting.Parse), (Func<MasterDataTable.UnitSkillupSetting, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitSkillupSkillGroupSetting> UnitSkillupSkillGroupSetting
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitSkillupSkillGroupSetting>(nameof (UnitSkillupSkillGroupSetting), new Func<MasterDataReader, MasterDataTable.UnitSkillupSkillGroupSetting>(MasterDataTable.UnitSkillupSkillGroupSetting.Parse), (Func<MasterDataTable.UnitSkillupSkillGroupSetting, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitTicket> UnitTicket
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitTicket>(nameof (UnitTicket), new Func<MasterDataReader, MasterDataTable.UnitTicket>(MasterDataTable.UnitTicket.Parse), (Func<MasterDataTable.UnitTicket, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitTicketUnitSample> UnitTicketUnitSample
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitTicketUnitSample>(nameof (UnitTicketUnitSample), new Func<MasterDataReader, MasterDataTable.UnitTicketUnitSample>(MasterDataTable.UnitTicketUnitSample.Parse), (Func<MasterDataTable.UnitTicketUnitSample, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitTransmigrationMaterial> UnitTransmigrationMaterial
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitTransmigrationMaterial>(nameof (UnitTransmigrationMaterial), new Func<MasterDataReader, MasterDataTable.UnitTransmigrationMaterial>(MasterDataTable.UnitTransmigrationMaterial.Parse), (Func<MasterDataTable.UnitTransmigrationMaterial, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitTransmigrationPattern> UnitTransmigrationPattern
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitTransmigrationPattern>(nameof (UnitTransmigrationPattern), new Func<MasterDataReader, MasterDataTable.UnitTransmigrationPattern>(MasterDataTable.UnitTransmigrationPattern.Parse), (Func<MasterDataTable.UnitTransmigrationPattern, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitType> UnitType
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitType>(nameof (UnitType), new Func<MasterDataReader, MasterDataTable.UnitType>(MasterDataTable.UnitType.Parse), (Func<MasterDataTable.UnitType, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitTypeParameter> UnitTypeParameter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitTypeParameter>(nameof (UnitTypeParameter), new Func<MasterDataReader, MasterDataTable.UnitTypeParameter>(MasterDataTable.UnitTypeParameter.Parse), (Func<MasterDataTable.UnitTypeParameter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnit> UnitUnit
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnit>(nameof (UnitUnit), new Func<MasterDataReader, MasterDataTable.UnitUnit>(MasterDataTable.UnitUnit.Parse), (Func<MasterDataTable.UnitUnit, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitBuildupAmount> UnitUnitBuildupAmount
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitBuildupAmount>(nameof (UnitUnitBuildupAmount), new Func<MasterDataReader, MasterDataTable.UnitUnitBuildupAmount>(MasterDataTable.UnitUnitBuildupAmount.Parse), (Func<MasterDataTable.UnitUnitBuildupAmount, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitBuildupLimitRelease> UnitUnitBuildupLimitRelease
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitBuildupLimitRelease>(nameof (UnitUnitBuildupLimitRelease), new Func<MasterDataReader, MasterDataTable.UnitUnitBuildupLimitRelease>(MasterDataTable.UnitUnitBuildupLimitRelease.Parse), (Func<MasterDataTable.UnitUnitBuildupLimitRelease, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitDescription> UnitUnitDescription
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitDescription>(nameof (UnitUnitDescription), new Func<MasterDataReader, MasterDataTable.UnitUnitDescription>(MasterDataTable.UnitUnitDescription.Parse), (Func<MasterDataTable.UnitUnitDescription, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitFamily> UnitUnitFamily
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitFamily>(nameof (UnitUnitFamily), new Func<MasterDataReader, MasterDataTable.UnitUnitFamily>(MasterDataTable.UnitUnitFamily.Parse), (Func<MasterDataTable.UnitUnitFamily, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitGearModelKind> UnitUnitGearModelKind
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitGearModelKind>(nameof (UnitUnitGearModelKind), new Func<MasterDataReader, MasterDataTable.UnitUnitGearModelKind>(MasterDataTable.UnitUnitGearModelKind.Parse), (Func<MasterDataTable.UnitUnitGearModelKind, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitGrowth> UnitUnitGrowth
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitGrowth>(nameof (UnitUnitGrowth), new Func<MasterDataReader, MasterDataTable.UnitUnitGrowth>(MasterDataTable.UnitUnitGrowth.Parse), (Func<MasterDataTable.UnitUnitGrowth, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitParameter> UnitUnitParameter
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitParameter>(nameof (UnitUnitParameter), new Func<MasterDataReader, MasterDataTable.UnitUnitParameter>(MasterDataTable.UnitUnitParameter.Parse), (Func<MasterDataTable.UnitUnitParameter, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitStory> UnitUnitStory
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitStory>(nameof (UnitUnitStory), new Func<MasterDataReader, MasterDataTable.UnitUnitStory>(MasterDataTable.UnitUnitStory.Parse), (Func<MasterDataTable.UnitUnitStory, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitUnitSupplement> UnitUnitSupplement
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitUnitSupplement>(nameof (UnitUnitSupplement), new Func<MasterDataReader, MasterDataTable.UnitUnitSupplement>(MasterDataTable.UnitUnitSupplement.Parse), (Func<MasterDataTable.UnitUnitSupplement, int>) (x => x.ID));
    }
  }

  public static AssocList<int, MasterDataTable.UnitVoicePattern> UnitVoicePattern
  {
    get
    {
      return MasterDataCache.Get<int, MasterDataTable.UnitVoicePattern>(nameof (UnitVoicePattern), new Func<MasterDataReader, MasterDataTable.UnitVoicePattern>(MasterDataTable.UnitVoicePattern.Parse), (Func<MasterDataTable.UnitVoicePattern, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.AIScore[] AIScoreList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.AIScore>("AIScore", new Func<MasterDataReader, MasterDataTable.AIScore>(MasterDataTable.AIScore.Parse), (Func<MasterDataTable.AIScore, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.AIScoreCorrection[] AIScoreCorrectionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.AIScoreCorrection>("AIScoreCorrection", new Func<MasterDataReader, MasterDataTable.AIScoreCorrection>(MasterDataTable.AIScoreCorrection.Parse), (Func<MasterDataTable.AIScoreCorrection, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.AIScorePattern[] AIScorePatternList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.AIScorePattern>("AIScorePattern", new Func<MasterDataReader, MasterDataTable.AIScorePattern>(MasterDataTable.AIScorePattern.Parse), (Func<MasterDataTable.AIScorePattern, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ActivityReward[] ActivityRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ActivityReward>("ActivityReward", new Func<MasterDataReader, MasterDataTable.ActivityReward>(MasterDataTable.ActivityReward.Parse), (Func<MasterDataTable.ActivityReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ActivityRewardConditions[] ActivityRewardConditionsList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ActivityRewardConditions>("ActivityRewardConditions", new Func<MasterDataReader, MasterDataTable.ActivityRewardConditions>(MasterDataTable.ActivityRewardConditions.Parse), (Func<MasterDataTable.ActivityRewardConditions, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ActivityRewardPhaseConditions[] ActivityRewardPhaseConditionsList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ActivityRewardPhaseConditions>("ActivityRewardPhaseConditions", new Func<MasterDataReader, MasterDataTable.ActivityRewardPhaseConditions>(MasterDataTable.ActivityRewardPhaseConditions.Parse), (Func<MasterDataTable.ActivityRewardPhaseConditions, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ActivityTotalTable[] ActivityTotalTableList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ActivityTotalTable>("ActivityTotalTable", new Func<MasterDataReader, MasterDataTable.ActivityTotalTable>(MasterDataTable.ActivityTotalTable.Parse), (Func<MasterDataTable.ActivityTotalTable, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ActivityTypeTable[] ActivityTypeTableList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ActivityTypeTable>("ActivityTypeTable", new Func<MasterDataReader, MasterDataTable.ActivityTypeTable>(MasterDataTable.ActivityTypeTable.Parse), (Func<MasterDataTable.ActivityTypeTable, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.Bag[] BagList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.Bag>("Bag", new Func<MasterDataReader, MasterDataTable.Bag>(MasterDataTable.Bag.Parse), (Func<MasterDataTable.Bag, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleAIScript[] BattleAIScriptList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleAIScript>("BattleAIScript", new Func<MasterDataReader, MasterDataTable.BattleAIScript>(MasterDataTable.BattleAIScript.Parse), (Func<MasterDataTable.BattleAIScript, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleEarthItemDropTable[] BattleEarthItemDropTableList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleEarthItemDropTable>("BattleEarthItemDropTable", new Func<MasterDataReader, MasterDataTable.BattleEarthItemDropTable>(MasterDataTable.BattleEarthItemDropTable.Parse), (Func<MasterDataTable.BattleEarthItemDropTable, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleEarthStageGuest[] BattleEarthStageGuestList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleEarthStageGuest>("BattleEarthStageGuest", new Func<MasterDataReader, MasterDataTable.BattleEarthStageGuest>(MasterDataTable.BattleEarthStageGuest.Parse), (Func<MasterDataTable.BattleEarthStageGuest, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleEarthStageGuestSkill[] BattleEarthStageGuestSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleEarthStageGuestSkill>("BattleEarthStageGuestSkill", new Func<MasterDataReader, MasterDataTable.BattleEarthStageGuestSkill>(MasterDataTable.BattleEarthStageGuestSkill.Parse), (Func<MasterDataTable.BattleEarthStageGuestSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleEnemyAcquireSkill[] BattleEnemyAcquireSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleEnemyAcquireSkill>("BattleEnemyAcquireSkill", new Func<MasterDataReader, MasterDataTable.BattleEnemyAcquireSkill>(MasterDataTable.BattleEnemyAcquireSkill.Parse), (Func<MasterDataTable.BattleEnemyAcquireSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleEnemyParameterDeviationTable[] BattleEnemyParameterDeviationTableList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleEnemyParameterDeviationTable>("BattleEnemyParameterDeviationTable", new Func<MasterDataReader, MasterDataTable.BattleEnemyParameterDeviationTable>(MasterDataTable.BattleEnemyParameterDeviationTable.Parse), (Func<MasterDataTable.BattleEnemyParameterDeviationTable, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleEnemyParameterTable[] BattleEnemyParameterTableList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleEnemyParameterTable>("BattleEnemyParameterTable", new Func<MasterDataReader, MasterDataTable.BattleEnemyParameterTable>(MasterDataTable.BattleEnemyParameterTable.Parse), (Func<MasterDataTable.BattleEnemyParameterTable, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleFieldEffect[] BattleFieldEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleFieldEffect>("BattleFieldEffect", new Func<MasterDataReader, MasterDataTable.BattleFieldEffect>(MasterDataTable.BattleFieldEffect.Parse), (Func<MasterDataTable.BattleFieldEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleFieldEffectStage[] BattleFieldEffectStageList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleFieldEffectStage>("BattleFieldEffectStage", new Func<MasterDataReader, MasterDataTable.BattleFieldEffectStage>(MasterDataTable.BattleFieldEffectStage.Parse), (Func<MasterDataTable.BattleFieldEffectStage, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleLandform[] BattleLandformList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleLandform>("BattleLandform", new Func<MasterDataReader, MasterDataTable.BattleLandform>(MasterDataTable.BattleLandform.Parse), (Func<MasterDataTable.BattleLandform, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleLandformEffect[] BattleLandformEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleLandformEffect>("BattleLandformEffect", new Func<MasterDataReader, MasterDataTable.BattleLandformEffect>(MasterDataTable.BattleLandformEffect.Parse), (Func<MasterDataTable.BattleLandformEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleLandformEffectGroup[] BattleLandformEffectGroupList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleLandformEffectGroup>("BattleLandformEffectGroup", new Func<MasterDataReader, MasterDataTable.BattleLandformEffectGroup>(MasterDataTable.BattleLandformEffectGroup.Parse), (Func<MasterDataTable.BattleLandformEffectGroup, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleLandformFootstepType[] BattleLandformFootstepTypeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleLandformFootstepType>("BattleLandformFootstepType", new Func<MasterDataReader, MasterDataTable.BattleLandformFootstepType>(MasterDataTable.BattleLandformFootstepType.Parse), (Func<MasterDataTable.BattleLandformFootstepType, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleLandformIncr[] BattleLandformIncrList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleLandformIncr>("BattleLandformIncr", new Func<MasterDataReader, MasterDataTable.BattleLandformIncr>(MasterDataTable.BattleLandformIncr.Parse), (Func<MasterDataTable.BattleLandformIncr, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleMap[] BattleMapList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleMap>("BattleMap", new Func<MasterDataReader, MasterDataTable.BattleMap>(MasterDataTable.BattleMap.Parse), (Func<MasterDataTable.BattleMap, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleMapLandform[] BattleMapLandformList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleMapLandform>("BattleMapLandform", new Func<MasterDataReader, MasterDataTable.BattleMapLandform>(MasterDataTable.BattleMapLandform.Parse), (Func<MasterDataTable.BattleMapLandform, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleReinforcement[] BattleReinforcementList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleReinforcement>("BattleReinforcement", new Func<MasterDataReader, MasterDataTable.BattleReinforcement>(MasterDataTable.BattleReinforcement.Parse), (Func<MasterDataTable.BattleReinforcement, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleReinforcementLogic[] BattleReinforcementLogicList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleReinforcementLogic>("BattleReinforcementLogic", new Func<MasterDataReader, MasterDataTable.BattleReinforcementLogic>(MasterDataTable.BattleReinforcementLogic.Parse), (Func<MasterDataTable.BattleReinforcementLogic, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleSpecialSkill[] BattleSpecialSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleSpecialSkill>("BattleSpecialSkill", new Func<MasterDataReader, MasterDataTable.BattleSpecialSkill>(MasterDataTable.BattleSpecialSkill.Parse), (Func<MasterDataTable.BattleSpecialSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStage[] BattleStageList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStage>("BattleStage", new Func<MasterDataReader, MasterDataTable.BattleStage>(MasterDataTable.BattleStage.Parse), (Func<MasterDataTable.BattleStage, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStageClear[] BattleStageClearList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStageClear>("BattleStageClear", new Func<MasterDataReader, MasterDataTable.BattleStageClear>(MasterDataTable.BattleStageClear.Parse), (Func<MasterDataTable.BattleStageClear, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStageEnemy[] BattleStageEnemyList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStageEnemy>("BattleStageEnemy", new Func<MasterDataReader, MasterDataTable.BattleStageEnemy>(MasterDataTable.BattleStageEnemy.Parse), (Func<MasterDataTable.BattleStageEnemy, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStageEnemyReward[] BattleStageEnemyRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStageEnemyReward>("BattleStageEnemyReward", new Func<MasterDataReader, MasterDataTable.BattleStageEnemyReward>(MasterDataTable.BattleStageEnemyReward.Parse), (Func<MasterDataTable.BattleStageEnemyReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStageEnemySkill[] BattleStageEnemySkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStageEnemySkill>("BattleStageEnemySkill", new Func<MasterDataReader, MasterDataTable.BattleStageEnemySkill>(MasterDataTable.BattleStageEnemySkill.Parse), (Func<MasterDataTable.BattleStageEnemySkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStageGuest[] BattleStageGuestList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStageGuest>("BattleStageGuest", new Func<MasterDataReader, MasterDataTable.BattleStageGuest>(MasterDataTable.BattleStageGuest.Parse), (Func<MasterDataTable.BattleStageGuest, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStageGuestSkill[] BattleStageGuestSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStageGuestSkill>("BattleStageGuestSkill", new Func<MasterDataReader, MasterDataTable.BattleStageGuestSkill>(MasterDataTable.BattleStageGuestSkill.Parse), (Func<MasterDataTable.BattleStageGuestSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStagePanelEvent[] BattleStagePanelEventList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStagePanelEvent>("BattleStagePanelEvent", new Func<MasterDataReader, MasterDataTable.BattleStagePanelEvent>(MasterDataTable.BattleStagePanelEvent.Parse), (Func<MasterDataTable.BattleStagePanelEvent, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStagePlayer[] BattleStagePlayerList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStagePlayer>("BattleStagePlayer", new Func<MasterDataReader, MasterDataTable.BattleStagePlayer>(MasterDataTable.BattleStagePlayer.Parse), (Func<MasterDataTable.BattleStagePlayer, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleStageUserUnit[] BattleStageUserUnitList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleStageUserUnit>("BattleStageUserUnit", new Func<MasterDataReader, MasterDataTable.BattleStageUserUnit>(MasterDataTable.BattleStageUserUnit.Parse), (Func<MasterDataTable.BattleStageUserUnit, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleUnitLandformFootstep[] BattleUnitLandformFootstepList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleUnitLandformFootstep>("BattleUnitLandformFootstep", new Func<MasterDataReader, MasterDataTable.BattleUnitLandformFootstep>(MasterDataTable.BattleUnitLandformFootstep.Parse), (Func<MasterDataTable.BattleUnitLandformFootstep, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleVictoryAreaCondition[] BattleVictoryAreaConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleVictoryAreaCondition>("BattleVictoryAreaCondition", new Func<MasterDataReader, MasterDataTable.BattleVictoryAreaCondition>(MasterDataTable.BattleVictoryAreaCondition.Parse), (Func<MasterDataTable.BattleVictoryAreaCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleVictoryCondition[] BattleVictoryConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleVictoryCondition>("BattleVictoryCondition", new Func<MasterDataReader, MasterDataTable.BattleVictoryCondition>(MasterDataTable.BattleVictoryCondition.Parse), (Func<MasterDataTable.BattleVictoryCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillAilmentEffect[] BattleskillAilmentEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillAilmentEffect>("BattleskillAilmentEffect", new Func<MasterDataReader, MasterDataTable.BattleskillAilmentEffect>(MasterDataTable.BattleskillAilmentEffect.Parse), (Func<MasterDataTable.BattleskillAilmentEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillDuelClipEventEffectDataPreload[] BattleskillDuelClipEventEffectDataPreloadList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillDuelClipEventEffectDataPreload>("BattleskillDuelClipEventEffectDataPreload", new Func<MasterDataReader, MasterDataTable.BattleskillDuelClipEventEffectDataPreload>(MasterDataTable.BattleskillDuelClipEventEffectDataPreload.Parse), (Func<MasterDataTable.BattleskillDuelClipEventEffectDataPreload, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillDuelCutinPreload[] BattleskillDuelCutinPreloadList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillDuelCutinPreload>("BattleskillDuelCutinPreload", new Func<MasterDataReader, MasterDataTable.BattleskillDuelCutinPreload>(MasterDataTable.BattleskillDuelCutinPreload.Parse), (Func<MasterDataTable.BattleskillDuelCutinPreload, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillDuelEffect[] BattleskillDuelEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillDuelEffect>("BattleskillDuelEffect", new Func<MasterDataReader, MasterDataTable.BattleskillDuelEffect>(MasterDataTable.BattleskillDuelEffect.Parse), (Func<MasterDataTable.BattleskillDuelEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillDuelEffectPreload[] BattleskillDuelEffectPreloadList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillDuelEffectPreload>("BattleskillDuelEffectPreload", new Func<MasterDataReader, MasterDataTable.BattleskillDuelEffectPreload>(MasterDataTable.BattleskillDuelEffectPreload.Parse), (Func<MasterDataTable.BattleskillDuelEffectPreload, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillEffect[] BattleskillEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillEffect>("BattleskillEffect", new Func<MasterDataReader, MasterDataTable.BattleskillEffect>(MasterDataTable.BattleskillEffect.Parse), (Func<MasterDataTable.BattleskillEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillEffectLogic[] BattleskillEffectLogicList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillEffectLogic>("BattleskillEffectLogic", new Func<MasterDataReader, MasterDataTable.BattleskillEffectLogic>(MasterDataTable.BattleskillEffectLogic.Parse), (Func<MasterDataTable.BattleskillEffectLogic, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillFieldEffect[] BattleskillFieldEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillFieldEffect>("BattleskillFieldEffect", new Func<MasterDataReader, MasterDataTable.BattleskillFieldEffect>(MasterDataTable.BattleskillFieldEffect.Parse), (Func<MasterDataTable.BattleskillFieldEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillLifeCycle[] BattleskillLifeCycleList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillLifeCycle>("BattleskillLifeCycle", new Func<MasterDataReader, MasterDataTable.BattleskillLifeCycle>(MasterDataTable.BattleskillLifeCycle.Parse), (Func<MasterDataTable.BattleskillLifeCycle, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillSkill[] BattleskillSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillSkill>("BattleskillSkill", new Func<MasterDataReader, MasterDataTable.BattleskillSkill>(MasterDataTable.BattleskillSkill.Parse), (Func<MasterDataTable.BattleskillSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillTiming[] BattleskillTimingList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillTiming>("BattleskillTiming", new Func<MasterDataReader, MasterDataTable.BattleskillTiming>(MasterDataTable.BattleskillTiming.Parse), (Func<MasterDataTable.BattleskillTiming, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BattleskillTimingLogic[] BattleskillTimingLogicList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BattleskillTimingLogic>("BattleskillTimingLogic", new Func<MasterDataReader, MasterDataTable.BattleskillTimingLogic>(MasterDataTable.BattleskillTimingLogic.Parse), (Func<MasterDataTable.BattleskillTimingLogic, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BeginnerNaviCategory[] BeginnerNaviCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BeginnerNaviCategory>("BeginnerNaviCategory", new Func<MasterDataReader, MasterDataTable.BeginnerNaviCategory>(MasterDataTable.BeginnerNaviCategory.Parse), (Func<MasterDataTable.BeginnerNaviCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BeginnerNaviDetail[] BeginnerNaviDetailList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BeginnerNaviDetail>("BeginnerNaviDetail", new Func<MasterDataReader, MasterDataTable.BeginnerNaviDetail>(MasterDataTable.BeginnerNaviDetail.Parse), (Func<MasterDataTable.BeginnerNaviDetail, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BeginnerNaviMovePage[] BeginnerNaviMovePageList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BeginnerNaviMovePage>("BeginnerNaviMovePage", new Func<MasterDataReader, MasterDataTable.BeginnerNaviMovePage>(MasterDataTable.BeginnerNaviMovePage.Parse), (Func<MasterDataTable.BeginnerNaviMovePage, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BeginnerNaviTitle[] BeginnerNaviTitleList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BeginnerNaviTitle>("BeginnerNaviTitle", new Func<MasterDataReader, MasterDataTable.BeginnerNaviTitle>(MasterDataTable.BeginnerNaviTitle.Parse), (Func<MasterDataTable.BeginnerNaviTitle, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BingoBingo[] BingoBingoList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BingoBingo>("BingoBingo", new Func<MasterDataReader, MasterDataTable.BingoBingo>(MasterDataTable.BingoBingo.Parse), (Func<MasterDataTable.BingoBingo, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BingoMission[] BingoMissionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BingoMission>("BingoMission", new Func<MasterDataReader, MasterDataTable.BingoMission>(MasterDataTable.BingoMission.Parse), (Func<MasterDataTable.BingoMission, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BingoRewardGroup[] BingoRewardGroupList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BingoRewardGroup>("BingoRewardGroup", new Func<MasterDataReader, MasterDataTable.BingoRewardGroup>(MasterDataTable.BingoRewardGroup.Parse), (Func<MasterDataTable.BingoRewardGroup, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BoostBonusGearCombine[] BoostBonusGearCombineList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BoostBonusGearCombine>("BoostBonusGearCombine", new Func<MasterDataReader, MasterDataTable.BoostBonusGearCombine>(MasterDataTable.BoostBonusGearCombine.Parse), (Func<MasterDataTable.BoostBonusGearCombine, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BoostBonusGearDrilling[] BoostBonusGearDrillingList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BoostBonusGearDrilling>("BoostBonusGearDrilling", new Func<MasterDataReader, MasterDataTable.BoostBonusGearDrilling>(MasterDataTable.BoostBonusGearDrilling.Parse), (Func<MasterDataTable.BoostBonusGearDrilling, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BoostBonusUnitBuildup[] BoostBonusUnitBuildupList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BoostBonusUnitBuildup>("BoostBonusUnitBuildup", new Func<MasterDataReader, MasterDataTable.BoostBonusUnitBuildup>(MasterDataTable.BoostBonusUnitBuildup.Parse), (Func<MasterDataTable.BoostBonusUnitBuildup, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BoostBonusUnitCompose[] BoostBonusUnitComposeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BoostBonusUnitCompose>("BoostBonusUnitCompose", new Func<MasterDataReader, MasterDataTable.BoostBonusUnitCompose>(MasterDataTable.BoostBonusUnitCompose.Parse), (Func<MasterDataTable.BoostBonusUnitCompose, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BoostBonusUnitTransmigrate[] BoostBonusUnitTransmigrateList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BoostBonusUnitTransmigrate>("BoostBonusUnitTransmigrate", new Func<MasterDataReader, MasterDataTable.BoostBonusUnitTransmigrate>(MasterDataTable.BoostBonusUnitTransmigrate.Parse), (Func<MasterDataTable.BoostBonusUnitTransmigrate, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BoostCampaignTypeName[] BoostCampaignTypeNameList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BoostCampaignTypeName>("BoostCampaignTypeName", new Func<MasterDataReader, MasterDataTable.BoostCampaignTypeName>(MasterDataTable.BoostCampaignTypeName.Parse), (Func<MasterDataTable.BoostCampaignTypeName, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BoostPeriod[] BoostPeriodList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BoostPeriod>("BoostPeriod", new Func<MasterDataReader, MasterDataTable.BoostPeriod>(MasterDataTable.BoostPeriod.Parse), (Func<MasterDataTable.BoostPeriod, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.BreakThroughBuildupSkill[] BreakThroughBuildupSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.BreakThroughBuildupSkill>("BreakThroughBuildupSkill", new Func<MasterDataReader, MasterDataTable.BreakThroughBuildupSkill>(MasterDataTable.BreakThroughBuildupSkill.Parse), (Func<MasterDataTable.BreakThroughBuildupSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.CoinChargeLimit[] CoinChargeLimitList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.CoinChargeLimit>("CoinChargeLimit", new Func<MasterDataReader, MasterDataTable.CoinChargeLimit>(MasterDataTable.CoinChargeLimit.Parse), (Func<MasterDataTable.CoinChargeLimit, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.CoinProduct[] CoinProductList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.CoinProduct>("CoinProduct", new Func<MasterDataReader, MasterDataTable.CoinProduct>(MasterDataTable.CoinProduct.Parse), (Func<MasterDataTable.CoinProduct, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ColosseumBonus[] ColosseumBonusList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ColosseumBonus>("ColosseumBonus", new Func<MasterDataReader, MasterDataTable.ColosseumBonus>(MasterDataTable.ColosseumBonus.Parse), (Func<MasterDataTable.ColosseumBonus, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ColosseumBonusBloodType[] ColosseumBonusBloodTypeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ColosseumBonusBloodType>("ColosseumBonusBloodType", new Func<MasterDataReader, MasterDataTable.ColosseumBonusBloodType>(MasterDataTable.ColosseumBonusBloodType.Parse), (Func<MasterDataTable.ColosseumBonusBloodType, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ColosseumBonusZodiacType[] ColosseumBonusZodiacTypeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ColosseumBonusZodiacType>("ColosseumBonusZodiacType", new Func<MasterDataReader, MasterDataTable.ColosseumBonusZodiacType>(MasterDataTable.ColosseumBonusZodiacType.Parse), (Func<MasterDataTable.ColosseumBonusZodiacType, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ColosseumRank[] ColosseumRankList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ColosseumRank>("ColosseumRank", new Func<MasterDataReader, MasterDataTable.ColosseumRank>(MasterDataTable.ColosseumRank.Parse), (Func<MasterDataTable.ColosseumRank, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ColosseumRankReward[] ColosseumRankRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ColosseumRankReward>("ColosseumRankReward", new Func<MasterDataReader, MasterDataTable.ColosseumRankReward>(MasterDataTable.ColosseumRankReward.Parse), (Func<MasterDataTable.ColosseumRankReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ColosseumTotalVictoryReward[] ColosseumTotalVictoryRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ColosseumTotalVictoryReward>("ColosseumTotalVictoryReward", new Func<MasterDataReader, MasterDataTable.ColosseumTotalVictoryReward>(MasterDataTable.ColosseumTotalVictoryReward.Parse), (Func<MasterDataTable.ColosseumTotalVictoryReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.CommonElementName[] CommonElementNameList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.CommonElementName>("CommonElementName", new Func<MasterDataReader, MasterDataTable.CommonElementName>(MasterDataTable.CommonElementName.Parse), (Func<MasterDataTable.CommonElementName, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.CommonQuestBattleEffect[] CommonQuestBattleEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.CommonQuestBattleEffect>("CommonQuestBattleEffect", new Func<MasterDataReader, MasterDataTable.CommonQuestBattleEffect>(MasterDataTable.CommonQuestBattleEffect.Parse), (Func<MasterDataTable.CommonQuestBattleEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.CommonStrengthComposePrice[] CommonStrengthComposePriceList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.CommonStrengthComposePrice>("CommonStrengthComposePrice", new Func<MasterDataReader, MasterDataTable.CommonStrengthComposePrice>(MasterDataTable.CommonStrengthComposePrice.Parse), (Func<MasterDataTable.CommonStrengthComposePrice, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ConstsConsts[] ConstsConstsList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ConstsConsts>("ConstsConsts", new Func<MasterDataReader, MasterDataTable.ConstsConsts>(MasterDataTable.ConstsConsts.Parse), (Func<MasterDataTable.ConstsConsts, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.DailyMission[] DailyMissionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.DailyMission>("DailyMission", new Func<MasterDataReader, MasterDataTable.DailyMission>(MasterDataTable.DailyMission.Parse), (Func<MasterDataTable.DailyMission, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.DailyMissionTopPage[] DailyMissionTopPageList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.DailyMissionTopPage>("DailyMissionTopPage", new Func<MasterDataReader, MasterDataTable.DailyMissionTopPage>(MasterDataTable.DailyMissionTopPage.Parse), (Func<MasterDataTable.DailyMissionTopPage, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.DuelDuelConfig[] DuelDuelConfigList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.DuelDuelConfig>("DuelDuelConfig", new Func<MasterDataReader, MasterDataTable.DuelDuelConfig>(MasterDataTable.DuelDuelConfig.Parse), (Func<MasterDataTable.DuelDuelConfig, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.DuelEffectPreload[] DuelEffectPreloadList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.DuelEffectPreload>("DuelEffectPreload", new Func<MasterDataReader, MasterDataTable.DuelEffectPreload>(MasterDataTable.DuelEffectPreload.Parse), (Func<MasterDataTable.DuelEffectPreload, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.DuelElementBulletEffect[] DuelElementBulletEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.DuelElementBulletEffect>("DuelElementBulletEffect", new Func<MasterDataReader, MasterDataTable.DuelElementBulletEffect>(MasterDataTable.DuelElementBulletEffect.Parse), (Func<MasterDataTable.DuelElementBulletEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.DuelElementHitEffect[] DuelElementHitEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.DuelElementHitEffect>("DuelElementHitEffect", new Func<MasterDataReader, MasterDataTable.DuelElementHitEffect>(MasterDataTable.DuelElementHitEffect.Parse), (Func<MasterDataTable.DuelElementHitEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.DuelElementTrailEffect[] DuelElementTrailEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.DuelElementTrailEffect>("DuelElementTrailEffect", new Func<MasterDataReader, MasterDataTable.DuelElementTrailEffect>(MasterDataTable.DuelElementTrailEffect.Parse), (Func<MasterDataTable.DuelElementTrailEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthBattleStagePanelEvent[] EarthBattleStagePanelEventList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthBattleStagePanelEvent>("EarthBattleStagePanelEvent", new Func<MasterDataReader, MasterDataTable.EarthBattleStagePanelEvent>(MasterDataTable.EarthBattleStagePanelEvent.Parse), (Func<MasterDataTable.EarthBattleStagePanelEvent, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthDesertCharacter[] EarthDesertCharacterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthDesertCharacter>("EarthDesertCharacter", new Func<MasterDataReader, MasterDataTable.EarthDesertCharacter>(MasterDataTable.EarthDesertCharacter.Parse), (Func<MasterDataTable.EarthDesertCharacter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthExtraQuest[] EarthExtraQuestList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthExtraQuest>("EarthExtraQuest", new Func<MasterDataReader, MasterDataTable.EarthExtraQuest>(MasterDataTable.EarthExtraQuest.Parse), (Func<MasterDataTable.EarthExtraQuest, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthForcedSortieCharacter[] EarthForcedSortieCharacterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthForcedSortieCharacter>("EarthForcedSortieCharacter", new Func<MasterDataReader, MasterDataTable.EarthForcedSortieCharacter>(MasterDataTable.EarthForcedSortieCharacter.Parse), (Func<MasterDataTable.EarthForcedSortieCharacter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthImpossibleOFSortieCharacter[] EarthImpossibleOFSortieCharacterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthImpossibleOFSortieCharacter>("EarthImpossibleOFSortieCharacter", new Func<MasterDataReader, MasterDataTable.EarthImpossibleOFSortieCharacter>(MasterDataTable.EarthImpossibleOFSortieCharacter.Parse), (Func<MasterDataTable.EarthImpossibleOFSortieCharacter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthJoinCharacter[] EarthJoinCharacterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthJoinCharacter>("EarthJoinCharacter", new Func<MasterDataReader, MasterDataTable.EarthJoinCharacter>(MasterDataTable.EarthJoinCharacter.Parse), (Func<MasterDataTable.EarthJoinCharacter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthQuestChapter[] EarthQuestChapterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthQuestChapter>("EarthQuestChapter", new Func<MasterDataReader, MasterDataTable.EarthQuestChapter>(MasterDataTable.EarthQuestChapter.Parse), (Func<MasterDataTable.EarthQuestChapter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthQuestClearReward[] EarthQuestClearRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthQuestClearReward>("EarthQuestClearReward", new Func<MasterDataReader, MasterDataTable.EarthQuestClearReward>(MasterDataTable.EarthQuestClearReward.Parse), (Func<MasterDataTable.EarthQuestClearReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthQuestEpisode[] EarthQuestEpisodeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthQuestEpisode>("EarthQuestEpisode", new Func<MasterDataReader, MasterDataTable.EarthQuestEpisode>(MasterDataTable.EarthQuestEpisode.Parse), (Func<MasterDataTable.EarthQuestEpisode, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthQuestExtraStoryPlayback[] EarthQuestExtraStoryPlaybackList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthQuestExtraStoryPlayback>("EarthQuestExtraStoryPlayback", new Func<MasterDataReader, MasterDataTable.EarthQuestExtraStoryPlayback>(MasterDataTable.EarthQuestExtraStoryPlayback.Parse), (Func<MasterDataTable.EarthQuestExtraStoryPlayback, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthQuestKey[] EarthQuestKeyList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthQuestKey>("EarthQuestKey", new Func<MasterDataReader, MasterDataTable.EarthQuestKey>(MasterDataTable.EarthQuestKey.Parse), (Func<MasterDataTable.EarthQuestKey, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthQuestPologue[] EarthQuestPologueList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthQuestPologue>("EarthQuestPologue", new Func<MasterDataReader, MasterDataTable.EarthQuestPologue>(MasterDataTable.EarthQuestPologue.Parse), (Func<MasterDataTable.EarthQuestPologue, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthQuestStoryPlayback[] EarthQuestStoryPlaybackList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthQuestStoryPlayback>("EarthQuestStoryPlayback", new Func<MasterDataReader, MasterDataTable.EarthQuestStoryPlayback>(MasterDataTable.EarthQuestStoryPlayback.Parse), (Func<MasterDataTable.EarthQuestStoryPlayback, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthShopArticle[] EarthShopArticleList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthShopArticle>("EarthShopArticle", new Func<MasterDataReader, MasterDataTable.EarthShopArticle>(MasterDataTable.EarthShopArticle.Parse), (Func<MasterDataTable.EarthShopArticle, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EarthShopContent[] EarthShopContentList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EarthShopContent>("EarthShopContent", new Func<MasterDataReader, MasterDataTable.EarthShopContent>(MasterDataTable.EarthShopContent.Parse), (Func<MasterDataTable.EarthShopContent, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EmblemEmblem[] EmblemEmblemList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EmblemEmblem>("EmblemEmblem", new Func<MasterDataReader, MasterDataTable.EmblemEmblem>(MasterDataTable.EmblemEmblem.Parse), (Func<MasterDataTable.EmblemEmblem, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.EmblemRarity[] EmblemRarityList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.EmblemRarity>("EmblemRarity", new Func<MasterDataReader, MasterDataTable.EmblemRarity>(MasterDataTable.EmblemRarity.Parse), (Func<MasterDataTable.EmblemRarity, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GachaTicket[] GachaTicketList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GachaTicket>("GachaTicket", new Func<MasterDataReader, MasterDataTable.GachaTicket>(MasterDataTable.GachaTicket.Parse), (Func<MasterDataTable.GachaTicket, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearBuildup[] GearBuildupList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearBuildup>("GearBuildup", new Func<MasterDataReader, MasterDataTable.GearBuildup>(MasterDataTable.GearBuildup.Parse), (Func<MasterDataTable.GearBuildup, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearBuildupLogic[] GearBuildupLogicList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearBuildupLogic>("GearBuildupLogic", new Func<MasterDataReader, MasterDataTable.GearBuildupLogic>(MasterDataTable.GearBuildupLogic.Parse), (Func<MasterDataTable.GearBuildupLogic, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearCombineRecipe[] GearCombineRecipeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearCombineRecipe>("GearCombineRecipe", new Func<MasterDataReader, MasterDataTable.GearCombineRecipe>(MasterDataTable.GearCombineRecipe.Parse), (Func<MasterDataTable.GearCombineRecipe, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearDisappearanceType[] GearDisappearanceTypeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearDisappearanceType>("GearDisappearanceType", new Func<MasterDataReader, MasterDataTable.GearDisappearanceType>(MasterDataTable.GearDisappearanceType.Parse), (Func<MasterDataTable.GearDisappearanceType, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearDrilling[] GearDrillingList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearDrilling>("GearDrilling", new Func<MasterDataReader, MasterDataTable.GearDrilling>(MasterDataTable.GearDrilling.Parse), (Func<MasterDataTable.GearDrilling, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearElementRatio[] GearElementRatioList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearElementRatio>("GearElementRatio", new Func<MasterDataReader, MasterDataTable.GearElementRatio>(MasterDataTable.GearElementRatio.Parse), (Func<MasterDataTable.GearElementRatio, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearGear[] GearGearList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearGear>("GearGear", new Func<MasterDataReader, MasterDataTable.GearGear>(MasterDataTable.GearGear.Parse), (Func<MasterDataTable.GearGear, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearGearComposeParameter[] GearGearComposeParameterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearGearComposeParameter>("GearGearComposeParameter", new Func<MasterDataReader, MasterDataTable.GearGearComposeParameter>(MasterDataTable.GearGearComposeParameter.Parse), (Func<MasterDataTable.GearGearComposeParameter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearGearDescription[] GearGearDescriptionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearGearDescription>("GearGearDescription", new Func<MasterDataReader, MasterDataTable.GearGearDescription>(MasterDataTable.GearGearDescription.Parse), (Func<MasterDataTable.GearGearDescription, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearGearElement[] GearGearElementList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearGearElement>("GearGearElement", new Func<MasterDataReader, MasterDataTable.GearGearElement>(MasterDataTable.GearGearElement.Parse), (Func<MasterDataTable.GearGearElement, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearGearSkill[] GearGearSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearGearSkill>("GearGearSkill", new Func<MasterDataReader, MasterDataTable.GearGearSkill>(MasterDataTable.GearGearSkill.Parse), (Func<MasterDataTable.GearGearSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearKind[] GearKindList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearKind>("GearKind", new Func<MasterDataReader, MasterDataTable.GearKind>(MasterDataTable.GearKind.Parse), (Func<MasterDataTable.GearKind, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearKindCorrelations[] GearKindCorrelationsList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearKindCorrelations>("GearKindCorrelations", new Func<MasterDataReader, MasterDataTable.GearKindCorrelations>(MasterDataTable.GearKindCorrelations.Parse), (Func<MasterDataTable.GearKindCorrelations, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearKindIncr[] GearKindIncrList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearKindIncr>("GearKindIncr", new Func<MasterDataReader, MasterDataTable.GearKindIncr>(MasterDataTable.GearKindIncr.Parse), (Func<MasterDataTable.GearKindIncr, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearKindRatio[] GearKindRatioList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearKindRatio>("GearKindRatio", new Func<MasterDataReader, MasterDataTable.GearKindRatio>(MasterDataTable.GearKindRatio.Parse), (Func<MasterDataTable.GearKindRatio, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearMaterialQuestInfo[] GearMaterialQuestInfoList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearMaterialQuestInfo>("GearMaterialQuestInfo", new Func<MasterDataReader, MasterDataTable.GearMaterialQuestInfo>(MasterDataTable.GearMaterialQuestInfo.Parse), (Func<MasterDataTable.GearMaterialQuestInfo, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearModelKind[] GearModelKindList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearModelKind>("GearModelKind", new Func<MasterDataReader, MasterDataTable.GearModelKind>(MasterDataTable.GearModelKind.Parse), (Func<MasterDataTable.GearModelKind, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearRank[] GearRankList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearRank>("GearRank", new Func<MasterDataReader, MasterDataTable.GearRank>(MasterDataTable.GearRank.Parse), (Func<MasterDataTable.GearRank, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearRankExp[] GearRankExpList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearRankExp>("GearRankExp", new Func<MasterDataReader, MasterDataTable.GearRankExp>(MasterDataTable.GearRankExp.Parse), (Func<MasterDataTable.GearRankExp, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearRankIncr[] GearRankIncrList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearRankIncr>("GearRankIncr", new Func<MasterDataReader, MasterDataTable.GearRankIncr>(MasterDataTable.GearRankIncr.Parse), (Func<MasterDataTable.GearRankIncr, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearRarity[] GearRarityList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearRarity>("GearRarity", new Func<MasterDataReader, MasterDataTable.GearRarity>(MasterDataTable.GearRarity.Parse), (Func<MasterDataTable.GearRarity, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearSpecialDrillingCost[] GearSpecialDrillingCostList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearSpecialDrillingCost>("GearSpecialDrillingCost", new Func<MasterDataReader, MasterDataTable.GearSpecialDrillingCost>(MasterDataTable.GearSpecialDrillingCost.Parse), (Func<MasterDataTable.GearSpecialDrillingCost, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GearSpecificationOfEquipmentUnit[] GearSpecificationOfEquipmentUnitList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GearSpecificationOfEquipmentUnit>("GearSpecificationOfEquipmentUnit", new Func<MasterDataReader, MasterDataTable.GearSpecificationOfEquipmentUnit>(MasterDataTable.GearSpecificationOfEquipmentUnit.Parse), (Func<MasterDataTable.GearSpecificationOfEquipmentUnit, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildApprovalPolicy[] GuildApprovalPolicyList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildApprovalPolicy>("GuildApprovalPolicy", new Func<MasterDataReader, MasterDataTable.GuildApprovalPolicy>(MasterDataTable.GuildApprovalPolicy.Parse), (Func<MasterDataTable.GuildApprovalPolicy, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildAtmosphere[] GuildAtmosphereList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildAtmosphere>("GuildAtmosphere", new Func<MasterDataReader, MasterDataTable.GuildAtmosphere>(MasterDataTable.GuildAtmosphere.Parse), (Func<MasterDataTable.GuildAtmosphere, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildAutoApproval[] GuildAutoApprovalList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildAutoApproval>("GuildAutoApproval", new Func<MasterDataReader, MasterDataTable.GuildAutoApproval>(MasterDataTable.GuildAutoApproval.Parse), (Func<MasterDataTable.GuildAutoApproval, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildAvailability[] GuildAvailabilityList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildAvailability>("GuildAvailability", new Func<MasterDataReader, MasterDataTable.GuildAvailability>(MasterDataTable.GuildAvailability.Parse), (Func<MasterDataTable.GuildAvailability, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildBankHowto[] GuildBankHowtoList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildBankHowto>("GuildBankHowto", new Func<MasterDataReader, MasterDataTable.GuildBankHowto>(MasterDataTable.GuildBankHowto.Parse), (Func<MasterDataTable.GuildBankHowto, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildBase[] GuildBaseList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildBase>("GuildBase", new Func<MasterDataReader, MasterDataTable.GuildBase>(MasterDataTable.GuildBase.Parse), (Func<MasterDataTable.GuildBase, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildBaseAnimation[] GuildBaseAnimationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildBaseAnimation>("GuildBaseAnimation", new Func<MasterDataReader, MasterDataTable.GuildBaseAnimation>(MasterDataTable.GuildBaseAnimation.Parse), (Func<MasterDataTable.GuildBaseAnimation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildBaseBonus[] GuildBaseBonusList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildBaseBonus>("GuildBaseBonus", new Func<MasterDataReader, MasterDataTable.GuildBaseBonus>(MasterDataTable.GuildBaseBonus.Parse), (Func<MasterDataTable.GuildBaseBonus, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildBasePos[] GuildBasePosList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildBasePos>("GuildBasePos", new Func<MasterDataReader, MasterDataTable.GuildBasePos>(MasterDataTable.GuildBasePos.Parse), (Func<MasterDataTable.GuildBasePos, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildEmblemRarity[] GuildEmblemRarityList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildEmblemRarity>("GuildEmblemRarity", new Func<MasterDataReader, MasterDataTable.GuildEmblemRarity>(MasterDataTable.GuildEmblemRarity.Parse), (Func<MasterDataTable.GuildEmblemRarity, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildEmblemUnit[] GuildEmblemUnitList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildEmblemUnit>("GuildEmblemUnit", new Func<MasterDataReader, MasterDataTable.GuildEmblemUnit>(MasterDataTable.GuildEmblemUnit.Parse), (Func<MasterDataTable.GuildEmblemUnit, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildImagePattern[] GuildImagePatternList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildImagePattern>("GuildImagePattern", new Func<MasterDataReader, MasterDataTable.GuildImagePattern>(MasterDataTable.GuildImagePattern.Parse), (Func<MasterDataTable.GuildImagePattern, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildRoleName[] GuildRoleNameList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildRoleName>("GuildRoleName", new Func<MasterDataReader, MasterDataTable.GuildRoleName>(MasterDataTable.GuildRoleName.Parse), (Func<MasterDataTable.GuildRoleName, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildSetting[] GuildSettingList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildSetting>("GuildSetting", new Func<MasterDataReader, MasterDataTable.GuildSetting>(MasterDataTable.GuildSetting.Parse), (Func<MasterDataTable.GuildSetting, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildStamp[] GuildStampList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildStamp>("GuildStamp", new Func<MasterDataReader, MasterDataTable.GuildStamp>(MasterDataTable.GuildStamp.Parse), (Func<MasterDataTable.GuildStamp, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GuildStampGroup[] GuildStampGroupList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GuildStampGroup>("GuildStampGroup", new Func<MasterDataReader, MasterDataTable.GuildStampGroup>(MasterDataTable.GuildStampGroup.Parse), (Func<MasterDataTable.GuildStampGroup, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GvgSettings[] GvgSettingsList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GvgSettings>("GvgSettings", new Func<MasterDataReader, MasterDataTable.GvgSettings>(MasterDataTable.GvgSettings.Parse), (Func<MasterDataTable.GvgSettings, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GvgStageFormation[] GvgStageFormationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GvgStageFormation>("GvgStageFormation", new Func<MasterDataReader, MasterDataTable.GvgStageFormation>(MasterDataTable.GvgStageFormation.Parse), (Func<MasterDataTable.GvgStageFormation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.GvgStarCondition[] GvgStarConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.GvgStarCondition>("GvgStarCondition", new Func<MasterDataReader, MasterDataTable.GvgStarCondition>(MasterDataTable.GvgStarCondition.Parse), (Func<MasterDataTable.GvgStarCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.HelpCategory[] HelpCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.HelpCategory>("HelpCategory", new Func<MasterDataReader, MasterDataTable.HelpCategory>(MasterDataTable.HelpCategory.Parse), (Func<MasterDataTable.HelpCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.HelpHelp[] HelpHelpList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.HelpHelp>("HelpHelp", new Func<MasterDataReader, MasterDataTable.HelpHelp>(MasterDataTable.HelpHelp.Parse), (Func<MasterDataTable.HelpHelp, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.InformationCategory[] InformationCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.InformationCategory>("InformationCategory", new Func<MasterDataReader, MasterDataTable.InformationCategory>(MasterDataTable.InformationCategory.Parse), (Func<MasterDataTable.InformationCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.InformationInformation[] InformationInformationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.InformationInformation>("InformationInformation", new Func<MasterDataReader, MasterDataTable.InformationInformation>(MasterDataTable.InformationInformation.Parse), (Func<MasterDataTable.InformationInformation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.InformationSubCategory[] InformationSubCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.InformationSubCategory>("InformationSubCategory", new Func<MasterDataReader, MasterDataTable.InformationSubCategory>(MasterDataTable.InformationSubCategory.Parse), (Func<MasterDataTable.InformationSubCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.InitimateBreakthrough[] InitimateBreakthroughList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.InitimateBreakthrough>("InitimateBreakthrough", new Func<MasterDataReader, MasterDataTable.InitimateBreakthrough>(MasterDataTable.InitimateBreakthrough.Parse), (Func<MasterDataTable.InitimateBreakthrough, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.InitimateLevel[] InitimateLevelList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.InitimateLevel>("InitimateLevel", new Func<MasterDataReader, MasterDataTable.InitimateLevel>(MasterDataTable.InitimateLevel.Parse), (Func<MasterDataTable.InitimateLevel, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.IntimateDuelSupport[] IntimateDuelSupportList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.IntimateDuelSupport>("IntimateDuelSupport", new Func<MasterDataReader, MasterDataTable.IntimateDuelSupport>(MasterDataTable.IntimateDuelSupport.Parse), (Func<MasterDataTable.IntimateDuelSupport, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.InvitationInvitation[] InvitationInvitationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.InvitationInvitation>("InvitationInvitation", new Func<MasterDataReader, MasterDataTable.InvitationInvitation>(MasterDataTable.InvitationInvitation.Parse), (Func<MasterDataTable.InvitationInvitation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.LoginbonusLoginbonus[] LoginbonusLoginbonusList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.LoginbonusLoginbonus>("LoginbonusLoginbonus", new Func<MasterDataReader, MasterDataTable.LoginbonusLoginbonus>(MasterDataTable.LoginbonusLoginbonus.Parse), (Func<MasterDataTable.LoginbonusLoginbonus, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.LoginbonusReward[] LoginbonusRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.LoginbonusReward>("LoginbonusReward", new Func<MasterDataReader, MasterDataTable.LoginbonusReward>(MasterDataTable.LoginbonusReward.Parse), (Func<MasterDataTable.LoginbonusReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PlayerLevelUpStatus[] PlayerLevelUpStatusList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PlayerLevelUpStatus>("PlayerLevelUpStatus", new Func<MasterDataReader, MasterDataTable.PlayerLevelUpStatus>(MasterDataTable.PlayerLevelUpStatus.Parse), (Func<MasterDataTable.PlayerLevelUpStatus, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PunitiveExpeditionEventGuildReward[] PunitiveExpeditionEventGuildRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PunitiveExpeditionEventGuildReward>("PunitiveExpeditionEventGuildReward", new Func<MasterDataReader, MasterDataTable.PunitiveExpeditionEventGuildReward>(MasterDataTable.PunitiveExpeditionEventGuildReward.Parse), (Func<MasterDataTable.PunitiveExpeditionEventGuildReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PunitiveExpeditionEventReward[] PunitiveExpeditionEventRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PunitiveExpeditionEventReward>("PunitiveExpeditionEventReward", new Func<MasterDataReader, MasterDataTable.PunitiveExpeditionEventReward>(MasterDataTable.PunitiveExpeditionEventReward.Parse), (Func<MasterDataTable.PunitiveExpeditionEventReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PvpBonus[] PvpBonusList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PvpBonus>("PvpBonus", new Func<MasterDataReader, MasterDataTable.PvpBonus>(MasterDataTable.PvpBonus.Parse), (Func<MasterDataTable.PvpBonus, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PvpClassKind[] PvpClassKindList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PvpClassKind>("PvpClassKind", new Func<MasterDataReader, MasterDataTable.PvpClassKind>(MasterDataTable.PvpClassKind.Parse), (Func<MasterDataTable.PvpClassKind, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PvpClassReward[] PvpClassRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PvpClassReward>("PvpClassReward", new Func<MasterDataReader, MasterDataTable.PvpClassReward>(MasterDataTable.PvpClassReward.Parse), (Func<MasterDataTable.PvpClassReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PvpMatchingType[] PvpMatchingTypeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PvpMatchingType>("PvpMatchingType", new Func<MasterDataReader, MasterDataTable.PvpMatchingType>(MasterDataTable.PvpMatchingType.Parse), (Func<MasterDataTable.PvpMatchingType, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PvpRankingCondition[] PvpRankingConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PvpRankingCondition>("PvpRankingCondition", new Func<MasterDataReader, MasterDataTable.PvpRankingCondition>(MasterDataTable.PvpRankingCondition.Parse), (Func<MasterDataTable.PvpRankingCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PvpRankingReward[] PvpRankingRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PvpRankingReward>("PvpRankingReward", new Func<MasterDataReader, MasterDataTable.PvpRankingReward>(MasterDataTable.PvpRankingReward.Parse), (Func<MasterDataTable.PvpRankingReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PvpStageFormation[] PvpStageFormationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PvpStageFormation>("PvpStageFormation", new Func<MasterDataReader, MasterDataTable.PvpStageFormation>(MasterDataTable.PvpStageFormation.Parse), (Func<MasterDataTable.PvpStageFormation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.PvpVictoryEffect[] PvpVictoryEffectList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.PvpVictoryEffect>("PvpVictoryEffect", new Func<MasterDataReader, MasterDataTable.PvpVictoryEffect>(MasterDataTable.PvpVictoryEffect.Parse), (Func<MasterDataTable.PvpVictoryEffect, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCharacterDisplayCondition[] QuestCharacterDisplayConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCharacterDisplayCondition>("QuestCharacterDisplayCondition", new Func<MasterDataReader, MasterDataTable.QuestCharacterDisplayCondition>(MasterDataTable.QuestCharacterDisplayCondition.Parse), (Func<MasterDataTable.QuestCharacterDisplayCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCharacterLimitation[] QuestCharacterLimitationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCharacterLimitation>("QuestCharacterLimitation", new Func<MasterDataReader, MasterDataTable.QuestCharacterLimitation>(MasterDataTable.QuestCharacterLimitation.Parse), (Func<MasterDataTable.QuestCharacterLimitation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCharacterLimitationLabel[] QuestCharacterLimitationLabelList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCharacterLimitationLabel>("QuestCharacterLimitationLabel", new Func<MasterDataReader, MasterDataTable.QuestCharacterLimitationLabel>(MasterDataTable.QuestCharacterLimitationLabel.Parse), (Func<MasterDataTable.QuestCharacterLimitationLabel, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCharacterM[] QuestCharacterMList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCharacterM>("QuestCharacterM", new Func<MasterDataReader, MasterDataTable.QuestCharacterM>(MasterDataTable.QuestCharacterM.Parse), (Func<MasterDataTable.QuestCharacterM, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCharacterMReleaseCondition[] QuestCharacterMReleaseConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCharacterMReleaseCondition>("QuestCharacterMReleaseCondition", new Func<MasterDataReader, MasterDataTable.QuestCharacterMReleaseCondition>(MasterDataTable.QuestCharacterMReleaseCondition.Parse), (Func<MasterDataTable.QuestCharacterMReleaseCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCharacterReleaseCondition[] QuestCharacterReleaseConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCharacterReleaseCondition>("QuestCharacterReleaseCondition", new Func<MasterDataReader, MasterDataTable.QuestCharacterReleaseCondition>(MasterDataTable.QuestCharacterReleaseCondition.Parse), (Func<MasterDataTable.QuestCharacterReleaseCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCharacterS[] QuestCharacterSList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCharacterS>("QuestCharacterS", new Func<MasterDataReader, MasterDataTable.QuestCharacterS>(MasterDataTable.QuestCharacterS.Parse), (Func<MasterDataTable.QuestCharacterS, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCommonBackground[] QuestCommonBackgroundList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCommonBackground>("QuestCommonBackground", new Func<MasterDataReader, MasterDataTable.QuestCommonBackground>(MasterDataTable.QuestCommonBackground.Parse), (Func<MasterDataTable.QuestCommonBackground, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCommonDrop[] QuestCommonDropList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCommonDrop>("QuestCommonDrop", new Func<MasterDataReader, MasterDataTable.QuestCommonDrop>(MasterDataTable.QuestCommonDrop.Parse), (Func<MasterDataTable.QuestCommonDrop, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestCommonSpecialColor[] QuestCommonSpecialColorList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestCommonSpecialColor>("QuestCommonSpecialColor", new Func<MasterDataReader, MasterDataTable.QuestCommonSpecialColor>(MasterDataTable.QuestCommonSpecialColor.Parse), (Func<MasterDataTable.QuestCommonSpecialColor, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraCategory[] QuestExtraCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraCategory>("QuestExtraCategory", new Func<MasterDataReader, MasterDataTable.QuestExtraCategory>(MasterDataTable.QuestExtraCategory.Parse), (Func<MasterDataTable.QuestExtraCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraDescription[] QuestExtraDescriptionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraDescription>("QuestExtraDescription", new Func<MasterDataReader, MasterDataTable.QuestExtraDescription>(MasterDataTable.QuestExtraDescription.Parse), (Func<MasterDataTable.QuestExtraDescription, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraL[] QuestExtraLList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraL>("QuestExtraL", new Func<MasterDataReader, MasterDataTable.QuestExtraL>(MasterDataTable.QuestExtraL.Parse), (Func<MasterDataTable.QuestExtraL, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraLimitation[] QuestExtraLimitationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraLimitation>("QuestExtraLimitation", new Func<MasterDataReader, MasterDataTable.QuestExtraLimitation>(MasterDataTable.QuestExtraLimitation.Parse), (Func<MasterDataTable.QuestExtraLimitation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraLimitationLabel[] QuestExtraLimitationLabelList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraLimitationLabel>("QuestExtraLimitationLabel", new Func<MasterDataReader, MasterDataTable.QuestExtraLimitationLabel>(MasterDataTable.QuestExtraLimitationLabel.Parse), (Func<MasterDataTable.QuestExtraLimitationLabel, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraM[] QuestExtraMList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraM>("QuestExtraM", new Func<MasterDataReader, MasterDataTable.QuestExtraM>(MasterDataTable.QuestExtraM.Parse), (Func<MasterDataTable.QuestExtraM, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraMission[] QuestExtraMissionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraMission>("QuestExtraMission", new Func<MasterDataReader, MasterDataTable.QuestExtraMission>(MasterDataTable.QuestExtraMission.Parse), (Func<MasterDataTable.QuestExtraMission, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraS[] QuestExtraSList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraS>("QuestExtraS", new Func<MasterDataReader, MasterDataTable.QuestExtraS>(MasterDataTable.QuestExtraS.Parse), (Func<MasterDataTable.QuestExtraS, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraScoreAchivementReward[] QuestExtraScoreAchivementRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraScoreAchivementReward>("QuestExtraScoreAchivementReward", new Func<MasterDataReader, MasterDataTable.QuestExtraScoreAchivementReward>(MasterDataTable.QuestExtraScoreAchivementReward.Parse), (Func<MasterDataTable.QuestExtraScoreAchivementReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraScoreRankingReward[] QuestExtraScoreRankingRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraScoreRankingReward>("QuestExtraScoreRankingReward", new Func<MasterDataReader, MasterDataTable.QuestExtraScoreRankingReward>(MasterDataTable.QuestExtraScoreRankingReward.Parse), (Func<MasterDataTable.QuestExtraScoreRankingReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraTotalScoreReward[] QuestExtraTotalScoreRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraTotalScoreReward>("QuestExtraTotalScoreReward", new Func<MasterDataReader, MasterDataTable.QuestExtraTotalScoreReward>(MasterDataTable.QuestExtraTotalScoreReward.Parse), (Func<MasterDataTable.QuestExtraTotalScoreReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestExtraXL[] QuestExtraXLList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestExtraXL>("QuestExtraXL", new Func<MasterDataReader, MasterDataTable.QuestExtraXL>(MasterDataTable.QuestExtraXL.Parse), (Func<MasterDataTable.QuestExtraXL, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestHarmonyDisplayCondition[] QuestHarmonyDisplayConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestHarmonyDisplayCondition>("QuestHarmonyDisplayCondition", new Func<MasterDataReader, MasterDataTable.QuestHarmonyDisplayCondition>(MasterDataTable.QuestHarmonyDisplayCondition.Parse), (Func<MasterDataTable.QuestHarmonyDisplayCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestHarmonyLimitation[] QuestHarmonyLimitationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestHarmonyLimitation>("QuestHarmonyLimitation", new Func<MasterDataReader, MasterDataTable.QuestHarmonyLimitation>(MasterDataTable.QuestHarmonyLimitation.Parse), (Func<MasterDataTable.QuestHarmonyLimitation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestHarmonyLimitationLabel[] QuestHarmonyLimitationLabelList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestHarmonyLimitationLabel>("QuestHarmonyLimitationLabel", new Func<MasterDataReader, MasterDataTable.QuestHarmonyLimitationLabel>(MasterDataTable.QuestHarmonyLimitationLabel.Parse), (Func<MasterDataTable.QuestHarmonyLimitationLabel, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestHarmonyM[] QuestHarmonyMList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestHarmonyM>("QuestHarmonyM", new Func<MasterDataReader, MasterDataTable.QuestHarmonyM>(MasterDataTable.QuestHarmonyM.Parse), (Func<MasterDataTable.QuestHarmonyM, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestHarmonyReleaseCondition[] QuestHarmonyReleaseConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestHarmonyReleaseCondition>("QuestHarmonyReleaseCondition", new Func<MasterDataReader, MasterDataTable.QuestHarmonyReleaseCondition>(MasterDataTable.QuestHarmonyReleaseCondition.Parse), (Func<MasterDataTable.QuestHarmonyReleaseCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestHarmonyS[] QuestHarmonySList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestHarmonyS>("QuestHarmonyS", new Func<MasterDataReader, MasterDataTable.QuestHarmonyS>(MasterDataTable.QuestHarmonyS.Parse), (Func<MasterDataTable.QuestHarmonyS, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestMoviePath[] QuestMoviePathList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestMoviePath>("QuestMoviePath", new Func<MasterDataReader, MasterDataTable.QuestMoviePath>(MasterDataTable.QuestMoviePath.Parse), (Func<MasterDataTable.QuestMoviePath, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestMovieQuest[] QuestMovieQuestList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestMovieQuest>("QuestMovieQuest", new Func<MasterDataReader, MasterDataTable.QuestMovieQuest>(MasterDataTable.QuestMovieQuest.Parse), (Func<MasterDataTable.QuestMovieQuest, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryClearMessage[] QuestStoryClearMessageList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryClearMessage>("QuestStoryClearMessage", new Func<MasterDataReader, MasterDataTable.QuestStoryClearMessage>(MasterDataTable.QuestStoryClearMessage.Parse), (Func<MasterDataTable.QuestStoryClearMessage, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryL[] QuestStoryLList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryL>("QuestStoryL", new Func<MasterDataReader, MasterDataTable.QuestStoryL>(MasterDataTable.QuestStoryL.Parse), (Func<MasterDataTable.QuestStoryL, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryLimitation[] QuestStoryLimitationList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryLimitation>("QuestStoryLimitation", new Func<MasterDataReader, MasterDataTable.QuestStoryLimitation>(MasterDataTable.QuestStoryLimitation.Parse), (Func<MasterDataTable.QuestStoryLimitation, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryLimitationLabel[] QuestStoryLimitationLabelList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryLimitationLabel>("QuestStoryLimitationLabel", new Func<MasterDataReader, MasterDataTable.QuestStoryLimitationLabel>(MasterDataTable.QuestStoryLimitationLabel.Parse), (Func<MasterDataTable.QuestStoryLimitationLabel, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryM[] QuestStoryMList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryM>("QuestStoryM", new Func<MasterDataReader, MasterDataTable.QuestStoryM>(MasterDataTable.QuestStoryM.Parse), (Func<MasterDataTable.QuestStoryM, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryMission[] QuestStoryMissionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryMission>("QuestStoryMission", new Func<MasterDataReader, MasterDataTable.QuestStoryMission>(MasterDataTable.QuestStoryMission.Parse), (Func<MasterDataTable.QuestStoryMission, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryMissionReward[] QuestStoryMissionRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryMissionReward>("QuestStoryMissionReward", new Func<MasterDataReader, MasterDataTable.QuestStoryMissionReward>(MasterDataTable.QuestStoryMissionReward.Parse), (Func<MasterDataTable.QuestStoryMissionReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryS[] QuestStorySList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryS>("QuestStoryS", new Func<MasterDataReader, MasterDataTable.QuestStoryS>(MasterDataTable.QuestStoryS.Parse), (Func<MasterDataTable.QuestStoryS, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestStoryXL[] QuestStoryXLList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestStoryXL>("QuestStoryXL", new Func<MasterDataReader, MasterDataTable.QuestStoryXL>(MasterDataTable.QuestStoryXL.Parse), (Func<MasterDataTable.QuestStoryXL, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestWave[] QuestWaveList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestWave>("QuestWave", new Func<MasterDataReader, MasterDataTable.QuestWave>(MasterDataTable.QuestWave.Parse), (Func<MasterDataTable.QuestWave, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestkeyCondition[] QuestkeyConditionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestkeyCondition>("QuestkeyCondition", new Func<MasterDataReader, MasterDataTable.QuestkeyCondition>(MasterDataTable.QuestkeyCondition.Parse), (Func<MasterDataTable.QuestkeyCondition, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.QuestkeyQuestkey[] QuestkeyQuestkeyList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.QuestkeyQuestkey>("QuestkeyQuestkey", new Func<MasterDataReader, MasterDataTable.QuestkeyQuestkey>(MasterDataTable.QuestkeyQuestkey.Parse), (Func<MasterDataTable.QuestkeyQuestkey, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ReviewReward[] ReviewRewardList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ReviewReward>("ReviewReward", new Func<MasterDataReader, MasterDataTable.ReviewReward>(MasterDataTable.ReviewReward.Parse), (Func<MasterDataTable.ReviewReward, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ScriptScript[] ScriptScriptList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ScriptScript>("ScriptScript", new Func<MasterDataReader, MasterDataTable.ScriptScript>(MasterDataTable.ScriptScript.Parse), (Func<MasterDataTable.ScriptScript, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.SeasonTicketSeasonTicket[] SeasonTicketSeasonTicketList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.SeasonTicketSeasonTicket>("SeasonTicketSeasonTicket", new Func<MasterDataReader, MasterDataTable.SeasonTicketSeasonTicket>(MasterDataTable.SeasonTicketSeasonTicket.Parse), (Func<MasterDataTable.SeasonTicketSeasonTicket, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ShopArticle[] ShopArticleList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ShopArticle>("ShopArticle", new Func<MasterDataReader, MasterDataTable.ShopArticle>(MasterDataTable.ShopArticle.Parse), (Func<MasterDataTable.ShopArticle, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ShopContent[] ShopContentList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ShopContent>("ShopContent", new Func<MasterDataReader, MasterDataTable.ShopContent>(MasterDataTable.ShopContent.Parse), (Func<MasterDataTable.ShopContent, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ShopShop[] ShopShopList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ShopShop>("ShopShop", new Func<MasterDataReader, MasterDataTable.ShopShop>(MasterDataTable.ShopShop.Parse), (Func<MasterDataTable.ShopShop, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.ShopTopUnit[] ShopTopUnitList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.ShopTopUnit>("ShopTopUnit", new Func<MasterDataReader, MasterDataTable.ShopTopUnit>(MasterDataTable.ShopTopUnit.Parse), (Func<MasterDataTable.ShopTopUnit, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.SlotS001MedalDeck[] SlotS001MedalDeckList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.SlotS001MedalDeck>("SlotS001MedalDeck", new Func<MasterDataReader, MasterDataTable.SlotS001MedalDeck>(MasterDataTable.SlotS001MedalDeck.Parse), (Func<MasterDataTable.SlotS001MedalDeck, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.SlotS001MedalDeckEntity[] SlotS001MedalDeckEntityList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.SlotS001MedalDeckEntity>("SlotS001MedalDeckEntity", new Func<MasterDataReader, MasterDataTable.SlotS001MedalDeckEntity>(MasterDataTable.SlotS001MedalDeckEntity.Parse), (Func<MasterDataTable.SlotS001MedalDeckEntity, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.SlotS001MedalRarity[] SlotS001MedalRarityList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.SlotS001MedalRarity>("SlotS001MedalRarity", new Func<MasterDataReader, MasterDataTable.SlotS001MedalRarity>(MasterDataTable.SlotS001MedalRarity.Parse), (Func<MasterDataTable.SlotS001MedalRarity, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.SlotS001MedalReel[] SlotS001MedalReelList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.SlotS001MedalReel>("SlotS001MedalReel", new Func<MasterDataReader, MasterDataTable.SlotS001MedalReel>(MasterDataTable.SlotS001MedalReel.Parse), (Func<MasterDataTable.SlotS001MedalReel, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.SlotS001MedalReelDetail[] SlotS001MedalReelDetailList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.SlotS001MedalReelDetail>("SlotS001MedalReelDetail", new Func<MasterDataReader, MasterDataTable.SlotS001MedalReelDetail>(MasterDataTable.SlotS001MedalReelDetail.Parse), (Func<MasterDataTable.SlotS001MedalReelDetail, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.SlotS001MedalReelIcon[] SlotS001MedalReelIconList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.SlotS001MedalReelIcon>("SlotS001MedalReelIcon", new Func<MasterDataReader, MasterDataTable.SlotS001MedalReelIcon>(MasterDataTable.SlotS001MedalReelIcon.Parse), (Func<MasterDataTable.SlotS001MedalReelIcon, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackCharacter[] StoryPlaybackCharacterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackCharacter>("StoryPlaybackCharacter", new Func<MasterDataReader, MasterDataTable.StoryPlaybackCharacter>(MasterDataTable.StoryPlaybackCharacter.Parse), (Func<MasterDataTable.StoryPlaybackCharacter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackCharacterDetail[] StoryPlaybackCharacterDetailList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackCharacterDetail>("StoryPlaybackCharacterDetail", new Func<MasterDataReader, MasterDataTable.StoryPlaybackCharacterDetail>(MasterDataTable.StoryPlaybackCharacterDetail.Parse), (Func<MasterDataTable.StoryPlaybackCharacterDetail, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackEventPlay[] StoryPlaybackEventPlayList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackEventPlay>("StoryPlaybackEventPlay", new Func<MasterDataReader, MasterDataTable.StoryPlaybackEventPlay>(MasterDataTable.StoryPlaybackEventPlay.Parse), (Func<MasterDataTable.StoryPlaybackEventPlay, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackExtra[] StoryPlaybackExtraList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackExtra>("StoryPlaybackExtra", new Func<MasterDataReader, MasterDataTable.StoryPlaybackExtra>(MasterDataTable.StoryPlaybackExtra.Parse), (Func<MasterDataTable.StoryPlaybackExtra, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackExtraDetail[] StoryPlaybackExtraDetailList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackExtraDetail>("StoryPlaybackExtraDetail", new Func<MasterDataReader, MasterDataTable.StoryPlaybackExtraDetail>(MasterDataTable.StoryPlaybackExtraDetail.Parse), (Func<MasterDataTable.StoryPlaybackExtraDetail, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackHarmony[] StoryPlaybackHarmonyList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackHarmony>("StoryPlaybackHarmony", new Func<MasterDataReader, MasterDataTable.StoryPlaybackHarmony>(MasterDataTable.StoryPlaybackHarmony.Parse), (Func<MasterDataTable.StoryPlaybackHarmony, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackHarmonyDetail[] StoryPlaybackHarmonyDetailList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackHarmonyDetail>("StoryPlaybackHarmonyDetail", new Func<MasterDataReader, MasterDataTable.StoryPlaybackHarmonyDetail>(MasterDataTable.StoryPlaybackHarmonyDetail.Parse), (Func<MasterDataTable.StoryPlaybackHarmonyDetail, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackStory[] StoryPlaybackStoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackStory>("StoryPlaybackStory", new Func<MasterDataReader, MasterDataTable.StoryPlaybackStory>(MasterDataTable.StoryPlaybackStory.Parse), (Func<MasterDataTable.StoryPlaybackStory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.StoryPlaybackStoryDetail[] StoryPlaybackStoryDetailList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.StoryPlaybackStoryDetail>("StoryPlaybackStoryDetail", new Func<MasterDataReader, MasterDataTable.StoryPlaybackStoryDetail>(MasterDataTable.StoryPlaybackStoryDetail.Parse), (Func<MasterDataTable.StoryPlaybackStoryDetail, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.SupplySupply[] SupplySupplyList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.SupplySupply>("SupplySupply", new Func<MasterDataReader, MasterDataTable.SupplySupply>(MasterDataTable.SupplySupply.Parse), (Func<MasterDataTable.SupplySupply, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.TipsTips[] TipsTipsList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.TipsTips>("TipsTips", new Func<MasterDataReader, MasterDataTable.TipsTips>(MasterDataTable.TipsTips.Parse), (Func<MasterDataTable.TipsTips, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitBreakThrough[] UnitBreakThroughList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitBreakThrough>("UnitBreakThrough", new Func<MasterDataReader, MasterDataTable.UnitBreakThrough>(MasterDataTable.UnitBreakThrough.Parse), (Func<MasterDataTable.UnitBreakThrough, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitCameraPattern[] UnitCameraPatternList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitCameraPattern>("UnitCameraPattern", new Func<MasterDataReader, MasterDataTable.UnitCameraPattern>(MasterDataTable.UnitCameraPattern.Parse), (Func<MasterDataTable.UnitCameraPattern, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitCharacter[] UnitCharacterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitCharacter>("UnitCharacter", new Func<MasterDataReader, MasterDataTable.UnitCharacter>(MasterDataTable.UnitCharacter.Parse), (Func<MasterDataTable.UnitCharacter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitEvolutionPattern[] UnitEvolutionPatternList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitEvolutionPattern>("UnitEvolutionPattern", new Func<MasterDataReader, MasterDataTable.UnitEvolutionPattern>(MasterDataTable.UnitEvolutionPattern.Parse), (Func<MasterDataTable.UnitEvolutionPattern, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitEvolutionUnit[] UnitEvolutionUnitList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitEvolutionUnit>("UnitEvolutionUnit", new Func<MasterDataReader, MasterDataTable.UnitEvolutionUnit>(MasterDataTable.UnitEvolutionUnit.Parse), (Func<MasterDataTable.UnitEvolutionUnit, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitFamilyValue[] UnitFamilyValueList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitFamilyValue>("UnitFamilyValue", new Func<MasterDataReader, MasterDataTable.UnitFamilyValue>(MasterDataTable.UnitFamilyValue.Parse), (Func<MasterDataTable.UnitFamilyValue, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitFootstepType[] UnitFootstepTypeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitFootstepType>("UnitFootstepType", new Func<MasterDataReader, MasterDataTable.UnitFootstepType>(MasterDataTable.UnitFootstepType.Parse), (Func<MasterDataTable.UnitFootstepType, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitGenderText[] UnitGenderTextList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitGenderText>("UnitGenderText", new Func<MasterDataReader, MasterDataTable.UnitGenderText>(MasterDataTable.UnitGenderText.Parse), (Func<MasterDataTable.UnitGenderText, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitGroup[] UnitGroupList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitGroup>("UnitGroup", new Func<MasterDataReader, MasterDataTable.UnitGroup>(MasterDataTable.UnitGroup.Parse), (Func<MasterDataTable.UnitGroup, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitGroupClothingCategory[] UnitGroupClothingCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitGroupClothingCategory>("UnitGroupClothingCategory", new Func<MasterDataReader, MasterDataTable.UnitGroupClothingCategory>(MasterDataTable.UnitGroupClothingCategory.Parse), (Func<MasterDataTable.UnitGroupClothingCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitGroupGenerationCategory[] UnitGroupGenerationCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitGroupGenerationCategory>("UnitGroupGenerationCategory", new Func<MasterDataReader, MasterDataTable.UnitGroupGenerationCategory>(MasterDataTable.UnitGroupGenerationCategory.Parse), (Func<MasterDataTable.UnitGroupGenerationCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitGroupLargeCategory[] UnitGroupLargeCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitGroupLargeCategory>("UnitGroupLargeCategory", new Func<MasterDataReader, MasterDataTable.UnitGroupLargeCategory>(MasterDataTable.UnitGroupLargeCategory.Parse), (Func<MasterDataTable.UnitGroupLargeCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitGroupSmallCategory[] UnitGroupSmallCategoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitGroupSmallCategory>("UnitGroupSmallCategory", new Func<MasterDataReader, MasterDataTable.UnitGroupSmallCategory>(MasterDataTable.UnitGroupSmallCategory.Parse), (Func<MasterDataTable.UnitGroupSmallCategory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitHomeVoicePattern[] UnitHomeVoicePatternList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitHomeVoicePattern>("UnitHomeVoicePattern", new Func<MasterDataReader, MasterDataTable.UnitHomeVoicePattern>(MasterDataTable.UnitHomeVoicePattern.Parse), (Func<MasterDataTable.UnitHomeVoicePattern, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitIllustPattern[] UnitIllustPatternList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitIllustPattern>("UnitIllustPattern", new Func<MasterDataReader, MasterDataTable.UnitIllustPattern>(MasterDataTable.UnitIllustPattern.Parse), (Func<MasterDataTable.UnitIllustPattern, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitJob[] UnitJobList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitJob>("UnitJob", new Func<MasterDataReader, MasterDataTable.UnitJob>(MasterDataTable.UnitJob.Parse), (Func<MasterDataTable.UnitJob, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitLeaderSkill[] UnitLeaderSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitLeaderSkill>("UnitLeaderSkill", new Func<MasterDataReader, MasterDataTable.UnitLeaderSkill>(MasterDataTable.UnitLeaderSkill.Parse), (Func<MasterDataTable.UnitLeaderSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitLevel[] UnitLevelList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitLevel>("UnitLevel", new Func<MasterDataReader, MasterDataTable.UnitLevel>(MasterDataTable.UnitLevel.Parse), (Func<MasterDataTable.UnitLevel, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitMaterialQuestInfo[] UnitMaterialQuestInfoList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitMaterialQuestInfo>("UnitMaterialQuestInfo", new Func<MasterDataReader, MasterDataTable.UnitMaterialQuestInfo>(MasterDataTable.UnitMaterialQuestInfo.Parse), (Func<MasterDataTable.UnitMaterialQuestInfo, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitPickupSkill[] UnitPickupSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitPickupSkill>("UnitPickupSkill", new Func<MasterDataReader, MasterDataTable.UnitPickupSkill>(MasterDataTable.UnitPickupSkill.Parse), (Func<MasterDataTable.UnitPickupSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitProficiency[] UnitProficiencyList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitProficiency>("UnitProficiency", new Func<MasterDataReader, MasterDataTable.UnitProficiency>(MasterDataTable.UnitProficiency.Parse), (Func<MasterDataTable.UnitProficiency, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitProficiencyIncr[] UnitProficiencyIncrList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitProficiencyIncr>("UnitProficiencyIncr", new Func<MasterDataReader, MasterDataTable.UnitProficiencyIncr>(MasterDataTable.UnitProficiencyIncr.Parse), (Func<MasterDataTable.UnitProficiencyIncr, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitProficiencyLevel[] UnitProficiencyLevelList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitProficiencyLevel>("UnitProficiencyLevel", new Func<MasterDataReader, MasterDataTable.UnitProficiencyLevel>(MasterDataTable.UnitProficiencyLevel.Parse), (Func<MasterDataTable.UnitProficiencyLevel, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitRarity[] UnitRarityList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitRarity>("UnitRarity", new Func<MasterDataReader, MasterDataTable.UnitRarity>(MasterDataTable.UnitRarity.Parse), (Func<MasterDataTable.UnitRarity, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitSkill[] UnitSkillList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitSkill>("UnitSkill", new Func<MasterDataReader, MasterDataTable.UnitSkill>(MasterDataTable.UnitSkill.Parse), (Func<MasterDataTable.UnitSkill, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitSkillCharacterQuest[] UnitSkillCharacterQuestList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitSkillCharacterQuest>("UnitSkillCharacterQuest", new Func<MasterDataReader, MasterDataTable.UnitSkillCharacterQuest>(MasterDataTable.UnitSkillCharacterQuest.Parse), (Func<MasterDataTable.UnitSkillCharacterQuest, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitSkillEvolution[] UnitSkillEvolutionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitSkillEvolution>("UnitSkillEvolution", new Func<MasterDataReader, MasterDataTable.UnitSkillEvolution>(MasterDataTable.UnitSkillEvolution.Parse), (Func<MasterDataTable.UnitSkillEvolution, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitSkillHarmonyQuest[] UnitSkillHarmonyQuestList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitSkillHarmonyQuest>("UnitSkillHarmonyQuest", new Func<MasterDataReader, MasterDataTable.UnitSkillHarmonyQuest>(MasterDataTable.UnitSkillHarmonyQuest.Parse), (Func<MasterDataTable.UnitSkillHarmonyQuest, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitSkillIntimate[] UnitSkillIntimateList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitSkillIntimate>("UnitSkillIntimate", new Func<MasterDataReader, MasterDataTable.UnitSkillIntimate>(MasterDataTable.UnitSkillIntimate.Parse), (Func<MasterDataTable.UnitSkillIntimate, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitSkillLevelUpProbability[] UnitSkillLevelUpProbabilityList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitSkillLevelUpProbability>("UnitSkillLevelUpProbability", new Func<MasterDataReader, MasterDataTable.UnitSkillLevelUpProbability>(MasterDataTable.UnitSkillLevelUpProbability.Parse), (Func<MasterDataTable.UnitSkillLevelUpProbability, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitSkillupSetting[] UnitSkillupSettingList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitSkillupSetting>("UnitSkillupSetting", new Func<MasterDataReader, MasterDataTable.UnitSkillupSetting>(MasterDataTable.UnitSkillupSetting.Parse), (Func<MasterDataTable.UnitSkillupSetting, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitSkillupSkillGroupSetting[] UnitSkillupSkillGroupSettingList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitSkillupSkillGroupSetting>("UnitSkillupSkillGroupSetting", new Func<MasterDataReader, MasterDataTable.UnitSkillupSkillGroupSetting>(MasterDataTable.UnitSkillupSkillGroupSetting.Parse), (Func<MasterDataTable.UnitSkillupSkillGroupSetting, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitTicket[] UnitTicketList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitTicket>("UnitTicket", new Func<MasterDataReader, MasterDataTable.UnitTicket>(MasterDataTable.UnitTicket.Parse), (Func<MasterDataTable.UnitTicket, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitTicketUnitSample[] UnitTicketUnitSampleList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitTicketUnitSample>("UnitTicketUnitSample", new Func<MasterDataReader, MasterDataTable.UnitTicketUnitSample>(MasterDataTable.UnitTicketUnitSample.Parse), (Func<MasterDataTable.UnitTicketUnitSample, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitTransmigrationMaterial[] UnitTransmigrationMaterialList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitTransmigrationMaterial>("UnitTransmigrationMaterial", new Func<MasterDataReader, MasterDataTable.UnitTransmigrationMaterial>(MasterDataTable.UnitTransmigrationMaterial.Parse), (Func<MasterDataTable.UnitTransmigrationMaterial, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitTransmigrationPattern[] UnitTransmigrationPatternList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitTransmigrationPattern>("UnitTransmigrationPattern", new Func<MasterDataReader, MasterDataTable.UnitTransmigrationPattern>(MasterDataTable.UnitTransmigrationPattern.Parse), (Func<MasterDataTable.UnitTransmigrationPattern, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitType[] UnitTypeList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitType>("UnitType", new Func<MasterDataReader, MasterDataTable.UnitType>(MasterDataTable.UnitType.Parse), (Func<MasterDataTable.UnitType, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitTypeParameter[] UnitTypeParameterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitTypeParameter>("UnitTypeParameter", new Func<MasterDataReader, MasterDataTable.UnitTypeParameter>(MasterDataTable.UnitTypeParameter.Parse), (Func<MasterDataTable.UnitTypeParameter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnit[] UnitUnitList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnit>("UnitUnit", new Func<MasterDataReader, MasterDataTable.UnitUnit>(MasterDataTable.UnitUnit.Parse), (Func<MasterDataTable.UnitUnit, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitBuildupAmount[] UnitUnitBuildupAmountList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitBuildupAmount>("UnitUnitBuildupAmount", new Func<MasterDataReader, MasterDataTable.UnitUnitBuildupAmount>(MasterDataTable.UnitUnitBuildupAmount.Parse), (Func<MasterDataTable.UnitUnitBuildupAmount, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitBuildupLimitRelease[] UnitUnitBuildupLimitReleaseList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitBuildupLimitRelease>("UnitUnitBuildupLimitRelease", new Func<MasterDataReader, MasterDataTable.UnitUnitBuildupLimitRelease>(MasterDataTable.UnitUnitBuildupLimitRelease.Parse), (Func<MasterDataTable.UnitUnitBuildupLimitRelease, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitDescription[] UnitUnitDescriptionList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitDescription>("UnitUnitDescription", new Func<MasterDataReader, MasterDataTable.UnitUnitDescription>(MasterDataTable.UnitUnitDescription.Parse), (Func<MasterDataTable.UnitUnitDescription, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitFamily[] UnitUnitFamilyList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitFamily>("UnitUnitFamily", new Func<MasterDataReader, MasterDataTable.UnitUnitFamily>(MasterDataTable.UnitUnitFamily.Parse), (Func<MasterDataTable.UnitUnitFamily, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitGearModelKind[] UnitUnitGearModelKindList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitGearModelKind>("UnitUnitGearModelKind", new Func<MasterDataReader, MasterDataTable.UnitUnitGearModelKind>(MasterDataTable.UnitUnitGearModelKind.Parse), (Func<MasterDataTable.UnitUnitGearModelKind, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitGrowth[] UnitUnitGrowthList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitGrowth>("UnitUnitGrowth", new Func<MasterDataReader, MasterDataTable.UnitUnitGrowth>(MasterDataTable.UnitUnitGrowth.Parse), (Func<MasterDataTable.UnitUnitGrowth, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitParameter[] UnitUnitParameterList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitParameter>("UnitUnitParameter", new Func<MasterDataReader, MasterDataTable.UnitUnitParameter>(MasterDataTable.UnitUnitParameter.Parse), (Func<MasterDataTable.UnitUnitParameter, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitStory[] UnitUnitStoryList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitStory>("UnitUnitStory", new Func<MasterDataReader, MasterDataTable.UnitUnitStory>(MasterDataTable.UnitUnitStory.Parse), (Func<MasterDataTable.UnitUnitStory, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitUnitSupplement[] UnitUnitSupplementList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitUnitSupplement>("UnitUnitSupplement", new Func<MasterDataReader, MasterDataTable.UnitUnitSupplement>(MasterDataTable.UnitUnitSupplement.Parse), (Func<MasterDataTable.UnitUnitSupplement, int>) (x => x.ID));
    }
  }

  public static MasterDataTable.UnitVoicePattern[] UnitVoicePatternList
  {
    get
    {
      return MasterDataCache.GetList<int, MasterDataTable.UnitVoicePattern>("UnitVoicePattern", new Func<MasterDataReader, MasterDataTable.UnitVoicePattern>(MasterDataTable.UnitVoicePattern.Parse), (Func<MasterDataTable.UnitVoicePattern, int>) (x => x.ID));
    }
  }

  public static void ParseJson(Dictionary<string, object> json)
  {
  }

  public static void LoadScriptScript(int ID)
  {
    MasterDataCache.LoadPartial<int, MasterDataTable.ScriptScript>("ScriptScript", "ScriptScript_part_" + ID.ToString(), new Func<MasterDataReader, MasterDataTable.ScriptScript>(MasterDataTable.ScriptScript.Parse), (Func<MasterDataTable.ScriptScript, int>) (x => x.ID));
  }

  public static MasterDataTable.UnitProficiencyIncr UniqueUnitProficiencyIncrBy(
    MasterDataTable.GearKind kind,
    MasterDataTable.UnitProficiency proficiency)
  {
    return MasterDataCache.Unique<int, MasterDataTable.UnitProficiencyIncr, Tuple<int, int>>("UnitProficiencyIncr", "By", Tuple.Create<int, int>(kind.ID, proficiency.ID), (Func<MasterDataTable.UnitProficiencyIncr, Tuple<int, int>>) (x => Tuple.Create<int, int>(x.kind.ID, x.proficiency.ID)), new Func<MasterDataReader, MasterDataTable.UnitProficiencyIncr>(MasterDataTable.UnitProficiencyIncr.Parse), (Func<MasterDataTable.UnitProficiencyIncr, int>) (x => x.ID));
  }

  public static MasterDataTable.UnitUnitFamily[] WhereUnitUnitFamilyBy(MasterDataTable.UnitUnit unit)
  {
    return MasterDataCache.Where<int, MasterDataTable.UnitUnitFamily, Tuple<int>>("UnitUnitFamily", "By", Tuple.Create<int>(unit.ID), (Func<MasterDataTable.UnitUnitFamily, Tuple<int>>) (x => Tuple.Create<int>(x.unit.ID)), new Func<MasterDataReader, MasterDataTable.UnitUnitFamily>(MasterDataTable.UnitUnitFamily.Parse), (Func<MasterDataTable.UnitUnitFamily, int>) (x => x.ID));
  }

  public static MasterDataTable.UnitUnitGearModelKind UniqueUnitUnitGearModelKindBy(
    MasterDataTable.UnitUnit unit,
    MasterDataTable.GearModelKind gear_model_kind)
  {
    return MasterDataCache.Unique<int, MasterDataTable.UnitUnitGearModelKind, Tuple<int, int>>("UnitUnitGearModelKind", "By", Tuple.Create<int, int>(unit.ID, gear_model_kind.ID), (Func<MasterDataTable.UnitUnitGearModelKind, Tuple<int, int>>) (x => Tuple.Create<int, int>(x.unit.ID, x.gear_model_kind.ID)), new Func<MasterDataReader, MasterDataTable.UnitUnitGearModelKind>(MasterDataTable.UnitUnitGearModelKind.Parse), (Func<MasterDataTable.UnitUnitGearModelKind, int>) (x => x.ID));
  }
}
