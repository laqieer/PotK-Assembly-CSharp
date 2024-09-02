// Decompiled with JetBrains decompiler
// Type: BattleStateController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Earth;
using GameCore;
using gu3.Device;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleStateController : BattleMonoBehaviour
{
  private string effect_condition_for_victory = "Condition_forVictory";
  private string effect_player_phase = "PlayerPhase";
  private string effect_neutral_phase = "NeutralPhase";
  private string effect_enemy_phase = "EnemyPhase";
  private string effect_stage_clear = "StageClear";
  private string effect_wave_clear = "WaveClear";
  private string effect_gameover = "GameOver";
  private string pvpMatchStartPrefab_path = "Prefabs/battle/dir_PvpMatchStart";
  private string gvgMatchStartPrefab_path = "Prefabs/battle/dir_PvpMatchStart_for_guild";
  private BL.BattleModified<BL.PhaseState> phaseStateModified;
  private BL.BattleModified<BL.ClassValue<List<BL.UnitPosition>>> playerListModified;
  private BL.BattleModified<BL.ClassValue<List<BL.UnitPosition>>> neutralListModified;
  private BL.BattleModified<BL.ClassValue<List<BL.UnitPosition>>> enemyListModified;
  private BL.BattleModified<BL.ClassValue<List<BL.UnitPosition>>> completedListModified;
  private BL.BattleModified<BL.ClassValue<List<BL.UnitPosition>>> spawnUnitListModified;
  private BL.BattleModified<BL.StructValue<bool>> isAutoBattleModified;
  private BL.UnitPosition currentUnitPosition;
  private int currentUnitActionCount;
  private BattleAIController aiController;
  private BattleTimeManager btm;
  private GameObject popupAllDeadPlayerPrefab;
  private GameObject spawnEffectPrefab;
  private GameObject healPrefab;
  private Dictionary<string, GameObject> panelEffectPrefabs;
  private GameObject pvpMatchStartPrefab;
  private Battle01SelectNode uiNode;
  private PVPManager _pvpManager;

  public void setUiNode(Battle01SelectNode node) => this.uiNode = node;

  private PVPManager pvpManager
  {
    get
    {
      if (Object.op_Equality((Object) this._pvpManager, (Object) null))
        this._pvpManager = Singleton<PVPManager>.GetInstanceOrNull();
      return this._pvpManager;
    }
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleStateController.\u003CStart_Original\u003Ec__IteratorA79()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleStateController.\u003CStart_Battle\u003Ec__IteratorA7A()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool startStroyWithNextState(BL.Story story, BL.Phase state)
  {
    if (story != null && story.scriptId >= 0)
    {
      Singleton<NGBattleManager>.GetInstance().startStory(story);
      this.btm.setPhaseState(state);
      return true;
    }
    this.btm.setPhaseState(state);
    return false;
  }

  private bool startStroyWithNextState(BL.StoryType stype, BL.Phase state)
  {
    return this.startStroyWithNextState(this.env.core.getStory(stype), state);
  }

  private void setStartTarget(BL.UnitPosition up, bool nonCurrent)
  {
    if (nonCurrent)
      this.btm.setTargetPanel(this.env.core.getFieldPanel(up), 0.1f);
    else
      this.btm.setCurrentUnit(up, 0.1f);
  }

  private void executeSkillEffects(List<BL.UnitPosition> upl)
  {
    bool isWait = false;
    this.btm.setScheduleAction((System.Action) (() =>
    {
      foreach (BL.UnitPosition up in upl)
      {
        foreach (BL.ExecuteSkillEffectResult executeSkillEffect in this.env.core.executeSkillEffects(up))
        {
          if (executeSkillEffect.targets.Count > 0)
          {
            this.doExecuteSkillEffects(up, executeSkillEffect);
            isWait = true;
          }
        }
      }
    }));
    if (isWait)
      this.btm.setEnableWait(0.1f);
    else
      this.btm.setScheduleAction((System.Action) (() => this.battleManager.isBattleEnable = true));
  }

  private void executeTurnInitSkillEffects(List<BL.UnitPosition> upl, int turn)
  {
    bool isWait = false;
    this.btm.setScheduleAction((System.Action) (() =>
    {
      foreach (BL.UnitPosition up in upl)
      {
        foreach (BL.ExecuteSkillEffectResult turnInitSkillEffect in this.env.core.executeTurnInitSkillEffects(up, turn))
        {
          if (turnInitSkillEffect.targets.Count > 0)
          {
            this.doExecuteSkillEffects(up, turnInitSkillEffect);
            isWait = true;
          }
        }
      }
    }));
    if (isWait)
      this.btm.setEnableWait(0.1f);
    else
      this.btm.setScheduleAction((System.Action) (() => this.battleManager.isBattleEnable = true));
  }

  private void doExecuteSkillEffects(BL.UnitPosition up, BL.ExecuteSkillEffectResult es)
  {
    List<BL.Unit> targets = new List<BL.Unit>();
    foreach (BL.UnitPosition target in es.targets)
      targets.Add(target.unit);
    bool isRebirth = ((IEnumerable<BattleskillEffect>) es.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.self_rebirth));
    BattleskillFieldEffect passiveEffect = es.skill.passive_effect;
    GameObject effectPrefab = (GameObject) null;
    GameObject targetEffectPrefab = this.healPrefab;
    GameObject invokedEffectPrefab = (GameObject) null;
    if (passiveEffect != null)
    {
      BE.SkillResource skillResource = this.env.skillResource[es.skill.passive_effect.ID];
      effectPrefab = skillResource.effectPrefab;
      invokedEffectPrefab = skillResource.invokedEffectPrefab;
      targetEffectPrefab = skillResource.targetEffectPrefab;
    }
    this.battleManager.battleEffects.skillFieldEffectStartCore(passiveEffect, up.unit, targets, effectPrefab, invokedEffectPrefab, targetEffectPrefab, (System.Action) (() =>
    {
      for (int index = 0; index < es.targets.Count; ++index)
      {
        if (isRebirth)
          es.targets[index].unit.rebirthBE(this.env);
        else
          this.dispHpNumberAnime(es.targets[index].unit, es.target_prev_hps[index], es.target_hps[index]);
      }
    }), (System.Action) null, (List<BL.Unit>) null);
  }

  private void completedSkillEffects(BL.UnitPosition up)
  {
    foreach (BL.ExecuteSkillEffectResult executeSkillEffect in this.env.core.completedExecuteSkillEffects(up))
    {
      if (executeSkillEffect.targets.Count > 0)
        this.doExecuteCompletedSkillEffects(up, executeSkillEffect);
    }
  }

  private void doExecuteCompletedSkillEffects(BL.UnitPosition up, BL.ExecuteSkillEffectResult es)
  {
    if (this.battleManager.isGvg)
      Singleton<GVGManager>.GetInstanceOrNull().applyGVGDeadUnit(up.unit, (BL.Unit) null);
    List<BL.Unit> targets = new List<BL.Unit>();
    foreach (BL.UnitPosition target in es.targets)
      targets.Add(target.unit);
    if (es.skill.skill_type == BattleskillSkillType.ailment)
    {
      this.btm.setTargetUnit(up, 0.0f, isWaitCameraMove: true);
      this.btm.setTargetUnit(up, 1.3f, func: (System.Action) (() =>
      {
        for (int index = 0; index < es.targets.Count; ++index)
          this.dispHpNumberAnime(es.targets[index].unit, es.target_prev_hps[index], es.target_hps[index]);
      }));
    }
    else
    {
      BattleskillFieldEffect passiveEffect = es.skill.passive_effect;
      GameObject effectPrefab = (GameObject) null;
      GameObject targetEffectPrefab = this.healPrefab;
      GameObject invokedEffectPrefab = (GameObject) null;
      if (passiveEffect != null)
      {
        BE.SkillResource skillResource = this.env.skillResource[es.skill.passive_effect.ID];
        effectPrefab = skillResource.effectPrefab;
        targetEffectPrefab = skillResource.targetEffectPrefab;
        invokedEffectPrefab = skillResource.invokedEffectPrefab;
      }
      this.battleManager.battleEffects.skillFieldEffectStartCore(passiveEffect, (BL.Unit) null, targets, effectPrefab, invokedEffectPrefab, targetEffectPrefab, (System.Action) null, (System.Action) (() =>
      {
        for (int index = 0; index < es.targets.Count; ++index)
          this.dispHpNumberAnime(es.targets[index].unit, es.target_prev_hps[index], es.target_hps[index]);
      }), (List<BL.Unit>) null);
    }
  }

  private void setStateWithEffect(
    string effect,
    float time,
    BL.Phase state,
    System.Action endAction,
    bool isBattleEnableControl)
  {
    this.btm.setSchedule((Schedule) new BattleStateController.EffectAIWait(this));
    this.battleManager.battleEffects.startEffect(effect, time, (System.Action) (() =>
    {
      if (endAction != null)
        endAction();
      this.btm.setPhaseState(state);
    }), isBattleEnableControl);
  }

  private bool deadCheck()
  {
    if (this.env.core.condition.type == BL.ConditionType.bossdown && this.env.core.getBossUnit().isDead)
    {
      this.btm.setPhaseState(!this.battleManager.isWave ? BL.Phase.stageclear : BL.Phase.stageclear_pre, true);
      return true;
    }
    if (this.env.core.getGamevoerType() != BL.GameoverType.alldown)
    {
      if (this.env.core.getGamevoerType() == BL.GameoverType.guestdown)
      {
        if (this.env.core.playerUnits.value.Count<BL.Unit>((Func<BL.Unit, bool>) (x => x.playerUnit.is_gesut && !x.isDead)) == 0)
        {
          this.btm.setPhaseState(BL.Phase.all_dead_player);
          return true;
        }
      }
      else if (this.env.core.getGamevoerType() == BL.GameoverType.playerdown && this.env.core.playerUnits.value.Count<BL.Unit>((Func<BL.Unit, bool>) (x => !x.playerUnit.is_gesut && !x.isDead)) == 0)
      {
        this.btm.setPhaseState(BL.Phase.all_dead_player);
        return true;
      }
    }
    if (this.env.core.getLoseUnitList().Count > 0 && this.env.core.getLoseUnitList().Any<BL.Unit>((Func<BL.Unit, bool>) (x => x.isDead)))
    {
      this.btm.setPhaseState(BL.Phase.gameover, true);
      return true;
    }
    if (this.env.core.battleInfo.isEarthMode)
    {
      if (!this.env.core.battleInfo.isExtraEarthQuest)
      {
        BL.Unit unit = this.env.core.playerUnits.value.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x.is_leader)).FirstOrDefault<BL.Unit>();
        if (unit != null && unit.isDead)
        {
          this.btm.setPhaseState(BL.Phase.gameover, true);
          return true;
        }
      }
      else
      {
        BL.Unit unit = this.env.core.playerUnits.value.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x.unit.same_character_id == 11002)).FirstOrDefault<BL.Unit>();
        if (unit != null && unit.isDead)
        {
          this.btm.setPhaseState(BL.Phase.gameover, true);
          return true;
        }
      }
    }
    if (this.env.core.allDeadUnitsp(BL.ForceID.player))
    {
      this.btm.setPhaseState(BL.Phase.all_dead_player);
      return true;
    }
    if (!this.env.core.allDeadUnitsp(BL.ForceID.enemy))
      return false;
    this.btm.setPhaseState(BL.Phase.all_dead_enemy);
    return true;
  }

  private void updateNormal()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    switch (this.phaseStateModified.value.state)
    {
      case BL.Phase.player:
        if (this.deadCheck())
          break;
        if (this.isAutoBattleModified.isChangedOnce())
        {
          if (this.isAutoBattleModified.value.value)
          {
            if (this.env.core.unitCurrent.unit != null)
              this.env.core.currentUnitPosition.cancelMove(this.env);
            if (this.aiController.startAI(this.env.core.playerActionUnits.value))
              break;
            this.isAutoBattleModified.notifyChanged();
            break;
          }
          this.aiController.stopAIAction();
          break;
        }
        if (!this.env.core.isAutoBattle.value || !this.aiController.isCompleted)
          break;
        this.aiController.startAIAction();
        break;
      case BL.Phase.neutral:
        if (this.deadCheck())
          break;
        if (this.aiController.isCompleted)
        {
          this.aiController.startAIAction();
          break;
        }
        this.aiController.startAI(this.env.core.neutralActionUnits.value);
        break;
      case BL.Phase.enemy:
        if (this.deadCheck())
          break;
        if (this.aiController.isCompleted)
        {
          this.aiController.startAIAction();
          break;
        }
        this.aiController.startAI(this.env.core.enemyActionUnits.value);
        break;
    }
  }

  private void updateOVO()
  {
    if (!this.battleManager.gameEngine.isWaitAction && this.battleManager.isBattleEnable)
      return;
    switch (this.phaseStateModified.value.state)
    {
      case BL.Phase.enemy:
      case BL.Phase.pvp_move_unit_waiting:
        if (this.aiController.isCompleted)
        {
          this.aiController.startAIAction(0.0f, (System.Action) (() => this.battleManager.gameEngine.actionUnitCompleted()));
          break;
        }
        if (!this.battleManager.isGvg)
          break;
        this.aiController.startAI(this.env.core.enemyActionUnits.value, 1);
        break;
    }
  }

  protected override void Update_Battle()
  {
    if (this.battleManager.isOvo)
      this.updateOVO();
    else
      this.updateNormal();
  }

  private void spawnUnit(BL.Panel panel, BL.UnitPosition up)
  {
    up.unit.isSpawned = true;
    this.btm.setTargetPanel(panel, 0.3f, (System.Action) (() => this.battleManager.battleEffects.fieldEffectsStart(this.spawnEffectPrefab, up.unit)), (System.Action) (() => up.unit.spawn(this.env)));
    this.btm.setScheduleAction((System.Action) null, 0.6f);
  }

  private void dispHpNumberAnime(BL.Unit unit, int prev_hp, int new_hp)
  {
    this.env.unitResource[unit].unitParts.dispHpNumber(prev_hp, new_hp);
  }

  private bool execPanelLandformIncr(BL.Panel panel, BL.UnitPosition up)
  {
    BattleLandformIncr incr = panel.landform.GetIncr(up.unit.unit);
    if (!up.unit.isEnable || up.unit.isDead || up.unit.hp == up.unit.parameter.Hp || (double) incr.hp_healing_ratio <= 0.0)
      return false;
    this.btm.setTargetUnit(up, 0.0f, this.healPrefab, endAction: (System.Action) (() => up.unit.hp += Mathf.CeilToInt((float) up.unit.parameter.Hp * incr.hp_healing_ratio)), isWaitCameraMove: true);
    this.btm.setScheduleAction((System.Action) null, 0.5f);
    return true;
  }

  private bool execPanelLandformEffect(
    BL.Panel panel,
    BL.UnitPosition up,
    BattleLandformEffectPhase phase)
  {
    this.btm.setScheduleAction((System.Action) (() =>
    {
      BattleLandformIncr incr = panel.landform.GetIncr(up.unit.unit);
      BattleLandformEffect[] landformEffects = incr.GetLandformEffects(phase);
      int blessingSkillAdd = BattleFuncs.GetLandBlessingSkillAdd((BL.ISkillEffectListUnit) up.unit, (BL.ISkillEffectListUnit) null, BattleskillEffectLogicEnum.land_blessing_fix_hp_healing, panel.landform, phase);
      if (landformEffects.Length <= 0 && blessingSkillAdd == 0 || !up.unit.isEnable || up.unit.isDead)
        return;
      float num1 = ((IEnumerable<BattleLandformEffect>) landformEffects).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_heal)).Sum<BattleLandformEffect>((Func<BattleLandformEffect, float>) (x => x.GetFloat("value"))) + (float) blessingSkillAdd;
      float num2 = ((IEnumerable<BattleLandformEffect>) landformEffects).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.ratio_heal)).Sum<BattleLandformEffect>((Func<BattleLandformEffect, float>) (x => x.GetFloat("percentage"))) * BattleFuncs.GetLandBlessingSkillMul((BL.ISkillEffectListUnit) up.unit, (BL.ISkillEffectListUnit) null, BattleskillEffectLogicEnum.land_blessing_ratio_hp_healing, panel.landform, phase);
      float num3 = ((IEnumerable<BattleLandformEffect>) landformEffects).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_damage)).Sum<BattleLandformEffect>((Func<BattleLandformEffect, float>) (x => x.GetFloat("value")));
      float num4 = ((IEnumerable<BattleLandformEffect>) landformEffects).Where<BattleLandformEffect>((Func<BattleLandformEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.ratio_damage)).Sum<BattleLandformEffect>((Func<BattleLandformEffect, float>) (x => x.GetFloat("percentage")));
      int changeHp = Mathf.Clamp(up.unit.hp + Mathf.CeilToInt((float) up.unit.parameter.Hp * num2 + num1) - Mathf.CeilToInt((float) up.unit.parameter.Hp * num4 + num3), 0, up.unit.parameter.Hp);
      if (changeHp == up.unit.hp)
        return;
      int prevHp = up.unit.hp;
      this.btm.setTargetUnit(up, 0.0f, isWaitCameraMove: true);
      this.btm.setTargetUnit(up, 0.0f, incr.effect_group == null || !this.panelEffectPrefabs.ContainsKey(incr.effect_group.play_prefab_file_name) ? (GameObject) null : this.panelEffectPrefabs[incr.effect_group.play_prefab_file_name], (System.Action) (() =>
      {
        up.unit.hp = changeHp;
        this.dispHpNumberAnime(up.unit, prevHp, changeHp);
      }));
      this.btm.setEnableWait(1.3f);
      this.btm.setScheduleAction((System.Action) (() =>
      {
        if (this.battleManager.isGvg)
          Singleton<GVGManager>.GetInstanceOrNull().applyGVGDeadUnit(up.unit, (BL.Unit) null);
        this.uiNode.hpCheckWithDeadEffects(up.unit);
      }), isInsertMode: true);
    }), isInsertMode: true);
    return false;
  }

  private void startBattleStartEffect()
  {
    BL.Story story = this.env.core.getFirstTurnStart();
    bool isBattleEnableControl = story != null && story.scriptId >= 0;
    ConditionForVictory conditionForVictory = this.battleManager.battleEffects.getConditionForVictory(this.effect_condition_for_victory);
    if (Object.op_Inequality((Object) conditionForVictory, (Object) null))
    {
      int wave = 0;
      int maxWave = 0;
      if (this.battleManager.isWave)
      {
        wave = this.env.core.currentWave;
        maxWave = this.battleManager.waveLength;
      }
      conditionForVictory.Initialize(this.env.core.condition.condition, wave, maxWave);
    }
    this.battleManager.battleEffects.startEffect(this.effect_condition_for_victory, 2.8f, (System.Action) (() => this.startStroyWithNextState(story, BL.Phase.turn_initialize)), isBattleEnableControl);
  }

  private void startBattlePvpStartEffect()
  {
    this.battleManager.battleEffects.startEffect((Transform) null, 5f, (System.Action) (() => this.battleManager.gameEngine.startMain()), true, this.pvpMatchStartPrefab, cloneE: (BattleEffects.CloneEnumlator) new BattleStateController.PvpMatchEffect(this));
  }

  private void startBattleFieldEffect(BL.FieldEffectType type)
  {
    foreach (BL.FieldEffect fieldEffect in this.env.core.getFieldEffects(type))
      this.battleManager.battleEffects.startEffect(fieldEffect);
  }

  private void battleStartOvo()
  {
    this.btm.setScheduleAction((System.Action) (() =>
    {
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      this.battleManager.gameEngine.readyComplited();
    }));
  }

  private void battleStartNormal()
  {
    this.btm.setScheduleAction((System.Action) (() =>
    {
      BL.Story story = this.env.core.getStory(BL.StoryType.battle_start);
      if (story == null || story.scriptId == 0)
      {
        Singleton<CommonRoot>.GetInstance().isLoading = false;
        Singleton<NGSceneManager>.GetInstance().StopTimer("BattleInit/");
      }
      this.startBattleFieldEffect(BL.FieldEffectType.battle_start);
      this.startStroyWithNextState(BL.StoryType.battle_start, BL.Phase.battle_start_init);
    }));
  }

  protected override void LateUpdate_Battle()
  {
    if (!this.battleManager.isOvo && !this.battleManager.isBattleEnable)
      return;
    if (!this.battleManager.isOvo)
    {
      this.checkScriptUnitInArea();
      if (this.completedListModified.isChanged && this.completedListModified.value.value.Count > 0)
      {
        List<int> scripts = new List<int>();
        foreach (BL.UnitPosition unitPosition in this.completedListModified.value.value)
        {
          List<int> scripts1 = unitPosition.getScripts();
          if (scripts1 != null && scripts1.Count > 0)
          {
            scripts.AddRange((IEnumerable<int>) scripts1);
            unitPosition.resetScript();
          }
        }
        if (scripts.Count > 0)
        {
          this.btm.setScheduleAction((System.Action) (() =>
          {
            scripts.ForEach((Action<int>) (i => this.battleManager.startStory(new BL.Story(i, BL.StoryType.unit_in_area, (object[]) null))));
            this.btm.setPhaseState(this.env.core.phaseState.state);
          }));
          return;
        }
      }
    }
    if (this.completedListModified.isChangedOnce() && this.completedListModified.value.value.Count > 0)
    {
      foreach (BL.UnitPosition up in this.completedListModified.value.value)
      {
        if (!up.unit.isDead && up.unit.hp > 0)
        {
          BL.Phase changePhaseToPanel = this.env.core.getChangePhaseToPanel(up);
          if (changePhaseToPanel == BL.Phase.none)
          {
            this.completedSkillEffects(up);
            int[] ids = this.env.core.getReinforcementIDsToPanel(up);
            if (ids != null)
            {
              foreach (BL.UnitPosition unitPosition in this.env.core.unitPositions.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => x.unit.playerUnit.reinforcement != null && !x.unit.isDead && !x.unit.isEnable && ((IEnumerable<int>) ids).Contains<int>(x.unit.playerUnit.reinforcement.ID))))
              {
                if (!this.env.core.spawnUnits.value.Contains(unitPosition))
                {
                  this.env.core.spawnUnits.value.Add(unitPosition);
                  this.env.core.spawnUnits.commit();
                }
              }
            }
          }
          else
          {
            this.btm.setPhaseState(changePhaseToPanel, true);
            return;
          }
        }
      }
      this.completedListModified.value.value.Clear();
      this.completedListModified.commit();
    }
    if (this.spawnUnitListModified.isChangedOnce() && this.spawnUnitListModified.value.value.Count > 0)
      this.btm.setScheduleAction((System.Action) (() =>
      {
        foreach (BL.UnitPosition up in this.spawnUnitListModified.value.value)
          this.spawnUnit(this.env.core.getFieldPanel(up), up);
        this.env.core.spawnUnits.value.Clear();
        this.env.core.spawnUnits.commit();
      }));
    if (!this.battleManager.isOvo)
    {
      if (this.playerListModified.isChangedOnce())
      {
        this.btm.setScheduleAction((System.Action) (() =>
        {
          if (this.env.core.phaseState.state != BL.Phase.player)
            return;
          if (this.playerListModified.value.value.Count == 0)
          {
            this.btm.setPhaseState(BL.Phase.player_end);
          }
          else
          {
            if (!this.env.core.currentPhaseUnitp(this.env.core.unitCurrent.unit))
              return;
            this.btm.setCurrentUnit((BL.Unit) null);
          }
        }));
        return;
      }
      if (this.neutralListModified.isChangedOnce())
      {
        this.btm.setScheduleAction((System.Action) (() =>
        {
          if (this.env.core.phaseState.state != BL.Phase.neutral || this.neutralListModified.value.value.Count != 0)
            return;
          this.btm.setPhaseState(BL.Phase.neutral_end);
        }));
        return;
      }
      if (this.enemyListModified.isChangedOnce())
      {
        this.btm.setScheduleAction((System.Action) (() =>
        {
          if (this.env.core.phaseState.state != BL.Phase.enemy || this.enemyListModified.value.value.Count != 0)
            return;
          this.btm.setPhaseState(BL.Phase.enemy_end);
        }));
        return;
      }
    }
    if (!this.phaseStateModified.isChangedOnce())
      return;
    BL.Phase state = this.phaseStateModified.value.state;
    switch (state)
    {
      case BL.Phase.player_start:
        this.battleManager.saveEnvironment();
        this.aiController.stopAIAction();
        Singleton<NGSoundManager>.GetInstance().PlayBgmFile(this.env.core.stage.stage.field_player_bgm_file, this.env.core.stage.stage.field_player_bgm);
        this.startBattleFieldEffect(BL.FieldEffectType.player_start);
        this.setStartTarget(this.env.core.playerActionUnits.value[0], true);
        this.btm.setScheduleAction((System.Action) (() =>
        {
          this.setStateWithEffect(this.effect_player_phase, 1.5f, BL.Phase.player_start_post, (System.Action) null, true);
          this.isAutoBattleModified.notifyChanged();
        }));
        foreach (BL.UnitPosition up in this.env.core.playerActionUnits.value)
          this.execPanelLandformEffect(this.env.core.getFieldPanel(up), up, BattleLandformEffectPhase.phase_start);
        this.executeSkillEffects(this.env.core.playerActionUnits.value);
        break;
      case BL.Phase.neutral_start:
        if (this.neutralListModified.value.value.Count == 0)
        {
          this.neutralListModified.notifyChanged();
          break;
        }
        this.aiController.stopAIAction();
        this.env.core.resetActionList(BL.ForceID.neutral);
        this.startBattleFieldEffect(BL.FieldEffectType.neutral_start);
        this.setStartTarget(this.env.core.neutralActionUnits.value[0], false);
        this.btm.setScheduleAction((System.Action) (() =>
        {
          this.battleManager.saveEnvironment();
          this.setStateWithEffect(this.effect_neutral_phase, 1.5f, BL.Phase.neutral_start_post, (System.Action) null, true);
        }));
        foreach (BL.UnitPosition up in this.env.core.neutralActionUnits.value)
          this.execPanelLandformEffect(this.env.core.getFieldPanel(up), up, BattleLandformEffectPhase.phase_start);
        this.executeSkillEffects(this.env.core.neutralActionUnits.value);
        break;
      case BL.Phase.enemy_start:
        this.aiController.stopAIAction();
        this.env.core.resetActionList(BL.ForceID.enemy);
        Singleton<NGSoundManager>.GetInstance().PlayBgmFile(this.env.core.stage.stage.field_enemy_bgm_file, this.env.core.stage.stage.field_enemy_bgm);
        this.startBattleFieldEffect(BL.FieldEffectType.enemy_start);
        this.setStartTarget(this.env.core.enemyActionUnits.value[0], false);
        this.btm.setScheduleAction((System.Action) (() =>
        {
          this.battleManager.saveEnvironment();
          this.setStateWithEffect(this.effect_enemy_phase, 1.5f, BL.Phase.enemy_start_post, (System.Action) null, true);
        }));
        foreach (BL.UnitPosition up in this.env.core.enemyActionUnits.value)
          this.execPanelLandformEffect(this.env.core.getFieldPanel(up), up, BattleLandformEffectPhase.phase_start);
        this.executeSkillEffects(this.env.core.enemyActionUnits.value);
        break;
      case BL.Phase.player_end:
        if (this.env.core.condition.isTurn && this.env.core.phaseState.turnCount + 1 > this.env.core.condition.turn)
        {
          this.btm.setPhaseState(BL.Phase.gameover);
          break;
        }
        if (this.deadCheck())
          break;
        if (this.env.core.neutralUnits.value.Any<BL.Unit>((Func<BL.Unit, bool>) (x => !x.isDead && x.isEnable)))
        {
          this.btm.setPhaseState(BL.Phase.neutral_start);
          break;
        }
        if (!this.env.core.enemyUnits.value.Any<BL.Unit>((Func<BL.Unit, bool>) (x => !x.isDead && x.isEnable)))
          break;
        this.btm.setPhaseState(BL.Phase.enemy_start);
        break;
      case BL.Phase.neutral_end:
        if (this.deadCheck())
          break;
        this.btm.setPhaseState(BL.Phase.enemy_start);
        break;
      case BL.Phase.enemy_end:
        if (this.deadCheck())
          break;
        this.btm.setPhaseState(BL.Phase.turn_initialize);
        break;
      case BL.Phase.turn_initialize:
        Debug.LogWarning((object) " ========== BL.Phase.turn_initialize !");
        this.aiController.stopAIAction();
        this.btm.setCurrentUnit((BL.Unit) null);
        if (this.env.core.condition.isElapsedTurn && this.env.core.phaseState.turnCount > this.env.core.condition.elapsedTurn)
        {
          this.btm.setPhaseState(!this.battleManager.isWave ? BL.Phase.stageclear : BL.Phase.stageclear_pre, true);
          break;
        }
        this.btm.setScheduleAction((System.Action) (() =>
        {
          Debug.LogWarning((object) " ========== turn_initialize ! ACTION");
          this.env.core.nextRandom();
          this.startBattleFieldEffect(BL.FieldEffectType.turn_start);
          foreach (BL.UnitPosition up in this.env.core.unitPositions.value)
          {
            BL.Panel fieldPanel = this.env.core.getFieldPanel(up);
            if (up.unit.spawnTurn == this.env.core.phaseState.turnCount)
              this.spawnUnit(fieldPanel, up);
          }
          this.btm.setScheduleAction((System.Action) (() =>
          {
            this.env.core.resetActionList(BL.ForceID.player);
            this.env.core.resetActionList(BL.ForceID.neutral);
            this.env.core.resetActionList(BL.ForceID.enemy);
            this.env.core.createDangerAria();
          }));
        }), isInsertMode: true);
        foreach (BL.UnitPosition up in this.env.core.unitPositions.value)
          this.execPanelLandformEffect(this.env.core.getFieldPanel(up), up, BattleLandformEffectPhase.turn_start);
        this.executeTurnInitSkillEffects(this.env.core.unitPositions.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => x.unit.isSpawned)).ToList<BL.UnitPosition>(), this.env.core.phaseState.absoluteTurnCount);
        if (Singleton<NGBattleManager>.GetInstance().isOvo)
          this.executeSkillEffects(this.env.core.unitPositions.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => !x.unit.isDead && x.unit.isEnable)).ToList<BL.UnitPosition>());
        this.btm.setScheduleAction((System.Action) (() =>
        {
          if (this.battleManager.isOvo)
          {
            Debug.LogWarning((object) " === send turnInitializeCompleted !");
            this.battleManager.gameEngine.turnInitializeCompleted();
          }
          else
            this.btm.setPhaseState(BL.Phase.player_start);
        }));
        break;
      case BL.Phase.win_finalize:
        this.btm.setScheduleAction((System.Action) (() => this.startStroyWithNextState(BL.StoryType.battle_win, BL.Phase.finalize)), isInsertMode: true);
        break;
      case BL.Phase.finalize:
        this.btm.setScheduleAction((System.Action) (() =>
        {
          this.battleManager.isSuspend = false;
          if (this.battleManager.isPvp)
            ((Component) this).gameObject.AddComponent<BattlePvpFinalize>();
          else if (this.battleManager.isGvg)
            ((Component) this).gameObject.AddComponent<BattleGvgFinalize>();
          else if (this.battleManager.isWave)
            ((Component) this).gameObject.AddComponent<BattleWaveFinalize>();
          else
            ((Component) this).gameObject.AddComponent<BattleFinalize>();
          DeviceManager.SetAutoSleep(true);
        }));
        break;
      case BL.Phase.suspend:
        if (!this.battleManager.isEarth)
          break;
        this.btm.setScheduleAction((System.Action) (() =>
        {
          this.battleManager.isSuspend = true;
          DeviceManager.SetAutoSleep(true);
          Singleton<EarthDataManager>.GetInstance().SuspendEarthMode();
        }));
        break;
      case BL.Phase.player_start_post:
        List<BL.Story> sl1 = !this.env.core.battleInfo.isWave ? this.env.core.getStoryOffense(this.env.core.phaseState.turnCount) : this.env.core.getStoryWaveOffense(this.env.core.phaseState.turnCount, this.env.core.nowWaveNo);
        if (sl1 != null && sl1.Count > 0)
        {
          sl1[0].isRead = true;
          this.btm.setScheduleAction((System.Action) (() => this.startStroyWithNextState(sl1[0], BL.Phase.player)));
          break;
        }
        this.btm.setPhaseState(BL.Phase.player);
        break;
      case BL.Phase.neutral_start_post:
        this.btm.setPhaseState(BL.Phase.neutral);
        break;
      case BL.Phase.enemy_start_post:
        List<BL.Story> sl2 = !this.env.core.battleInfo.isWave ? this.env.core.getStoryDefense(this.env.core.phaseState.turnCount) : this.env.core.getStoryWaveDefense(this.env.core.phaseState.turnCount, this.env.core.nowWaveNo);
        if (sl2 != null && sl2.Count > 0)
        {
          sl2[0].isRead = true;
          this.btm.setScheduleAction((System.Action) (() => this.startStroyWithNextState(sl2[0], BL.Phase.enemy)));
          break;
        }
        this.btm.setPhaseState(BL.Phase.enemy);
        break;
      case BL.Phase.all_dead_player:
        this.aiController.stopAIAction();
        this.btm.setScheduleAction((System.Action) (() =>
        {
          if (this.env.core.battleInfo.isContinueEnable)
          {
            this.battleManager.popupOpen(this.popupAllDeadPlayerPrefab);
            this.btm.setPhaseState(BL.Phase.none);
          }
          else
            this.btm.setPhaseState(BL.Phase.gameover);
        }));
        break;
      case BL.Phase.all_dead_neutral:
        this.aiController.stopAIAction();
        break;
      case BL.Phase.all_dead_enemy:
        this.aiController.stopAIAction();
        this.btm.setPhaseState(!this.battleManager.isWave ? BL.Phase.stageclear : BL.Phase.stageclear_pre, true);
        break;
      case BL.Phase.stageclear_pre:
        this.aiController.stopAIAction();
        List<BL.Story> sl3 = !this.battleManager.isWave ? (List<BL.Story>) null : this.env.core.getStoryWaveClear(this.env.core.nowWaveNo);
        if (sl3 != null && sl3.Count > 0)
        {
          sl3[0].isRead = true;
          this.btm.setScheduleAction((System.Action) (() => this.startStroyWithNextState(sl3[0], BL.Phase.stageclear)));
          break;
        }
        this.btm.setPhaseState(BL.Phase.stageclear);
        break;
      case BL.Phase.stageclear:
        this.aiController.stopAIAction();
        if (this.battleManager.isWave && this.env.core.nowWaveNo < this.battleManager.waveLength)
        {
          this.startBattleFieldEffect(BL.FieldEffectType.waveclear);
          this.setStateWithEffect(this.effect_wave_clear, 2.5f, BL.Phase.wave_start, (System.Action) null, false);
          break;
        }
        this.btm.setScheduleAction((System.Action) (() =>
        {
          this.startBattleFieldEffect(BL.FieldEffectType.stageclear);
          this.setStateWithEffect(this.effect_stage_clear, 5f, BL.Phase.win_finalize, (System.Action) (() => this.env.core.isWin = true), false);
        }));
        break;
      case BL.Phase.gameover:
        bool needNabi = !this.battleManager.isOvo && !this.env.core.battleInfo.isEarthMode && this.env.core.battleInfo.isFirstAllDead && this.env.core.allDeadUnitsp(BL.ForceID.player);
        this.aiController.stopAIAction();
        this.btm.setScheduleAction((System.Action) (() => this.setStateWithEffect(this.effect_gameover, 5f, BL.Phase.finalize, (System.Action) (() => this.env.core.isWin = false), needNabi)));
        break;
      default:
        switch (state - 41)
        {
          case BL.Phase.player_start:
            Singleton<NGSoundManager>.GetInstance().PlayBgmFile(this.env.core.stage.stage.field_player_bgm_file, this.env.core.stage.stage.field_player_bgm);
            this.startBattleFieldEffect(BL.FieldEffectType.pvp_change_player);
            BL.UnitPosition unitPosition1 = this.env.core.playerActionUnits.value.FirstOrDefault<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => x.cantChangeCurrent));
            BL.UnitPosition up1 = unitPosition1 == null ? this.env.core.playerActionUnits.value[0] : unitPosition1;
            this.btm.setCurrentUnit((BL.Unit) null);
            this.setStartTarget(up1, true);
            this.btm.setPhaseState(BL.Phase.player);
            return;
          case BL.Phase.neutral_start:
            Singleton<NGSoundManager>.GetInstance().PlayBgmFile(this.env.core.stage.stage.field_enemy_bgm_file, this.env.core.stage.stage.field_enemy_bgm);
            this.startBattleFieldEffect(BL.FieldEffectType.pvp_change_enemy);
            this.setStartTarget(this.env.core.enemyActionUnits.value[0], false);
            this.btm.setPhaseState(BL.Phase.enemy);
            return;
          case BL.Phase.enemy_start:
            Debug.LogWarning((object) " ============== pvp_result");
            if (Object.op_Inequality((Object) this.pvpManager, (Object) null))
              this.pvpManager.isResult = true;
            if (Object.op_Inequality((Object) Singleton<GVGManager>.GetInstanceOrNull(), (Object) null))
              Singleton<GVGManager>.GetInstance().isResult = true;
            this.btm.setPhaseState(BL.Phase.finalize);
            return;
          case BL.Phase.neutral:
            this.btm.setScheduleAction((System.Action) (() => this.startBattlePvpStartEffect()));
            return;
          case BL.Phase.neutral_start | BL.Phase.enemy_end:
            Debug.LogWarning((object) " ===== BL.Phase.pvp_exception!");
            NGSceneManager sm = Singleton<NGSceneManager>.GetInstance();
            if (sm.sceneName != this.battleManager.topScene)
              this.btm.setScheduleAction((System.Action) (() => sm.backScene()));
            ModalWindow.ShowYesNo(Consts.GetInstance().VERSUS_02694POPUP_TITLE, this.pvpManager.getErrorMessage(this.pvpManager.exception), (System.Action) (() => this.pvpManager.errorRecovery()), (System.Action) (() => this.btm.setPhaseState(BL.Phase.finalize)));
            this.btm.setPhaseState(BL.Phase.none);
            return;
          default:
            if (state != BL.Phase.battle_start)
            {
              if (state != BL.Phase.battle_start_init)
              {
                if (state != BL.Phase.wave_start)
                  return;
                this.btm.setSchedule((Schedule) new BattleStateController.WaveStart(this, this.env, this.env.core.nowWaveNo));
                this.btm.setPhaseState(BL.Phase.battle_start_init);
                return;
              }
              this.battleManager.saveEnvironment();
              this.startBattleFieldEffect(BL.FieldEffectType.first_turn_start);
              this.btm.setScheduleAction((System.Action) (() => this.startBattleStartEffect()));
              return;
            }
            Debug.LogWarning((object) " === BL.Phase.battle_start");
            this.battleManager.saveEnvironment();
            this.btm.setTargetPanel(this.env.core.getFieldPanel(this.env.core.getUnitPosition(this.env.core.playerUnits.value[0])), 0.0f, isWaitCameraMove: true);
            if (this.battleManager.isOvo)
            {
              this.battleStartOvo();
              return;
            }
            this.battleStartNormal();
            return;
        }
    }
  }

  private void updateCurrentUnitPosition()
  {
    if (this.currentUnitPosition == this.env.core.currentUnitPosition)
      return;
    this.currentUnitPosition = this.env.core.currentUnitPosition;
    this.currentUnitActionCount = this.currentUnitPosition == null ? -1 : this.currentUnitPosition.unit.skillEffects.GetCompleteCount();
  }

  private bool isCurrentUnitActionCountedOnce
  {
    get
    {
      bool actionCountedOnce = false;
      if (this.currentUnitPosition != null)
      {
        actionCountedOnce = this.currentUnitActionCount != this.currentUnitPosition.completedCount;
        this.currentUnitActionCount = this.currentUnitPosition.completedCount;
      }
      return actionCountedOnce;
    }
  }

  private void checkScriptUnitInArea()
  {
    if (this.env.core.unitCurrent.unit == null)
      return;
    this.updateCurrentUnitPosition();
    switch (this.phaseStateModified.value.state)
    {
      case BL.Phase.player:
        if (!this.isCurrentUnitActionCountedOnce)
          break;
        BL.UnitPosition currentUnitPosition1 = this.env.core.currentUnitPosition;
        using (List<BL.Story>.Enumerator enumerator = this.env.core.getStoryOffenseInArea(currentUnitPosition1.originalRow, currentUnitPosition1.originalColumn).GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            BL.Story current = enumerator.Current;
            current.isRead = true;
            currentUnitPosition1.setScript(current.scriptId);
          }
          break;
        }
      case BL.Phase.neutral:
        if (!this.isCurrentUnitActionCountedOnce)
          break;
        break;
      case BL.Phase.enemy:
        if (!this.isCurrentUnitActionCountedOnce)
          break;
        BL.UnitPosition currentUnitPosition2 = this.env.core.currentUnitPosition;
        using (List<BL.Story>.Enumerator enumerator = this.env.core.getStoryDefenseInArea(currentUnitPosition2.originalRow, currentUnitPosition2.originalColumn).GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            BL.Story current = enumerator.Current;
            current.isRead = true;
            currentUnitPosition2.setScript(current.scriptId);
          }
          break;
        }
    }
  }

  private class EffectAIWait : ScheduleEnumerator
  {
    private BattleStateController parent;

    public EffectAIWait(BattleStateController parent) => this.parent = parent;

    [DebuggerHidden]
    public override IEnumerator doBody()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleStateController.EffectAIWait.\u003CdoBody\u003Ec__IteratorA7B()
      {
        \u003C\u003Ef__this = this
      };
    }
  }

  private class PvpMatchEffect : BattleEffects.CloneEnumlator
  {
    private BattleStateController parent;

    public PvpMatchEffect(BattleStateController parent) => this.parent = parent;

    [DebuggerHidden]
    public override IEnumerator doBody(GameObject o)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleStateController.PvpMatchEffect.\u003CdoBody\u003Ec__IteratorA7F()
      {
        o = o,
        \u003C\u0024\u003Eo = o,
        \u003C\u003Ef__this = this
      };
    }
  }

  private class WaveStart : ScheduleEnumerator
  {
    private BattleStateController parent;
    private BE env;
    private int wave;

    public WaveStart(BattleStateController parent, BE env, int wave)
    {
      this.parent = parent;
      this.env = env;
      this.wave = wave;
    }

    [DebuggerHidden]
    public override IEnumerator doBody()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BattleStateController.WaveStart.\u003CdoBody\u003Ec__IteratorA80()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
