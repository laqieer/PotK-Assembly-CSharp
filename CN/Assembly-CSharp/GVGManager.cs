// Decompiled with JetBrains decompiler
// Type: GVGManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class GVGManager : Singleton<GVGManager>, IGameEngine
{
  private string finishPrefabPath = "Prefabs/battle/dir_PvpResults";
  private string loadingPrefabPath = "Prefabs/battle/Loading_BattlePrefab";
  private string spawnPlayerPrefabPath = "BattleEffects/field/ef657_fe_Multi_Unit_Sporn";
  private string spawnEnemyPrefabPath = "BattleEffects/field/ef658_fe_Multi_Enemy_Sporn";
  private GameObject finishPrefab;
  private GameObject loadingPrefab;
  private GameObject spawnPlayerPrefab;
  private GameObject spawnEnemyPrefab;
  private NGBattleManager bm;
  private BattleTimeManager _btm;
  private BattleAIController _aiController;
  private BattleInputObserver _inputObserver;
  private bool _isRunning;
  private bool _isWaitAction;
  private bool _isDisposition;
  public bool isResult;
  private Stopwatch _stopwatch;
  private BL.StructValue<int> _remainTurn;
  private BL.StructValue<int> _timeLimit;
  private BL.StructValue<int> _playerPoint;
  private BL.StructValue<int> _enemyPoint;
  private HashSet<BL.Panel> _formationPanel;
  private HashSet<BL.Panel> _formationPanelEnemy;
  private BL.Phase saveState = BL.Phase.none;
  private System.Action nextStateWaitAction;
  private int currentLimit;

  private BattleTimeManager btm
  {
    get
    {
      if (Object.op_Equality((Object) this._btm, (Object) null))
        this._btm = this.bm.getManager<BattleTimeManager>();
      return this._btm;
    }
  }

  private BattleAIController aiController
  {
    get
    {
      if (Object.op_Equality((Object) this._aiController, (Object) null))
        this._aiController = this.bm.getController<BattleAIController>();
      return this._aiController;
    }
  }

  private BattleInputObserver inputObserver
  {
    get
    {
      if (Object.op_Equality((Object) this._inputObserver, (Object) null))
        this._inputObserver = this.bm.getController<BattleInputObserver>();
      return this._inputObserver;
    }
  }

  public bool isRunning => this._isRunning;

  public bool isWaitAction => this._isWaitAction;

  public bool isDisposition => this._isDisposition;

  public BL.StructValue<int> remainTurn => this._remainTurn;

  public BL.StructValue<int> timeLimit => this._timeLimit;

  public BL.StructValue<int> playerPoint => this._playerPoint;

  public BL.StructValue<int> enemyPoint => this._enemyPoint;

  public string playerName => SMManager.Observe<Player>().Value.name;

  public string enemyName => string.Empty;

  public int playerEmblem => SMManager.Observe<Player>().Value.current_emblem_id;

  public int enemyEmblem => 0;

  private int playerPoint_reserve
  {
    get => this.bm.environment.core.playerPoint;
    set => this.bm.environment.core.playerPoint = value;
  }

  private int enemyPoint_reserve
  {
    get => this.bm.environment.core.enemyPoint;
    set => this.bm.environment.core.enemyPoint = value;
  }

  public PvpMatchingTypeEnum matchingType
  {
    get => Persist.pvpSuspend.Data.matchingType;
    set => Persist.pvpSuspend.Data.matchingType = value;
  }

  public HashSet<BL.Panel> formationPanel
  {
    get
    {
      if (this._formationPanel == null)
        this._formationPanel = this.createFormationPanels(this.playerOrder);
      return this._formationPanel;
    }
  }

  private HashSet<BL.Panel> formationPanelEnemy
  {
    get
    {
      if (this._formationPanelEnemy == null)
        this._formationPanelEnemy = this.createFormationPanels(this.playerOrder != 0 ? 0 : 1);
      return this._formationPanelEnemy;
    }
  }

  protected override void Initialize()
  {
    this.bm = Singleton<NGBattleManager>.GetInstance();
    this._remainTurn = new BL.StructValue<int>(0);
    this._timeLimit = new BL.StructValue<int>(0);
    this._playerPoint = new BL.StructValue<int>(0);
    this._enemyPoint = new BL.StructValue<int>(0);
  }

  public int playerOrder => this.bm.order;

  public void deadReserveToPoint(bool isEnemy)
  {
    if (this.bm.environment.core.phaseState.state == BL.Phase.finalize)
      return;
    if (isEnemy)
      this.playerPoint.value = this.playerPoint_reserve;
    else
      this.enemyPoint.value = this.enemyPoint_reserve;
  }

  [DebuggerHidden]
  public IEnumerator cleanupGVG()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003CcleanupGVG\u003Ec__Iterator9B4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public Future<None> startGVG(GameCore.BattleInfo battleInfo, bool isRestart)
  {
    Debug.LogWarning((object) " === startGVG");
    Debug.LogWarning((object) ("     isRestart:" + (object) isRestart));
    return new Future<None>((Func<Promise<None>, IEnumerator>) (promise => this._startGVG(promise, battleInfo, isRestart)));
  }

  [DebuggerHidden]
  private IEnumerator _startGVG(Promise<None> promise, GameCore.BattleInfo battleInfo, bool isRestart)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003C_startGVG\u003Ec__Iterator9B5()
    {
      isRestart = isRestart,
      promise = promise,
      battleInfo = battleInfo,
      \u003C\u0024\u003EisRestart = isRestart,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u0024\u003EbattleInfo = battleInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _battleReady(Promise<None> promise, GameCore.BattleInfo battleInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003C_battleReady\u003Ec__Iterator9B6()
    {
      battleInfo = battleInfo,
      promise = promise,
      \u003C\u0024\u003EbattleInfo = battleInfo,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createEnvironment(GameCore.BattleInfo battleInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003CcreateEnvironment\u003Ec__Iterator9B7()
    {
      battleInfo = battleInfo,
      \u003C\u0024\u003EbattleInfo = battleInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator initPrefabs()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003CinitPrefabs\u003Ec__Iterator9B8()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void spawnsEffects(List<BL.Unit> spawns, GameObject prefab)
  {
    BE env = this.bm.environment;
    this.bm.battleEffects.skillFieldEffectStartCore(new BattleskillFieldEffect()
    {
      user_move_camera = false,
      user_wait_seconds = 0.0f,
      targets_multiple_effect = false,
      target_move_camera = true,
      target_wait_seconds = 0.5f
    }, (BL.Unit) null, spawns, (GameObject) null, prefab, targetAction: (System.Action) (() =>
    {
      foreach (BL.Unit spawn in spawns)
      {
        spawn.rebirth(env.core);
        spawn.rebirthBE(env);
      }
    }));
  }

  public static GVGManager createGVGManager()
  {
    GVGManager gvgManager = Singleton<GVGManager>.GetInstanceOrNull();
    if (Object.op_Equality((Object) gvgManager, (Object) null))
      gvgManager = new GameObject("GVG Manager").AddComponent<GVGManager>();
    return gvgManager;
  }

  [DebuggerHidden]
  public static IEnumerator destroyGVGManager()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    GVGManager.\u003CdestroyGVGManager\u003Ec__Iterator9B9 managerCIterator9B9 = new GVGManager.\u003CdestroyGVGManager\u003Ec__Iterator9B9();
    return (IEnumerator) managerCIterator9B9;
  }

  private HashSet<BL.Panel> createFormationPanels(int order)
  {
    BL ec = this.bm.environment.core;
    HashSet<BL.Panel> formationPanels = new HashSet<BL.Panel>();
    foreach (PvpStageFormation pvpStageFormation in ((IEnumerable<PvpStageFormation>) MasterData.PvpStageFormationList).Where<PvpStageFormation>((Func<PvpStageFormation, bool>) (x => x.stage.ID == ec.stage.id)).Where<PvpStageFormation>((Func<PvpStageFormation, bool>) (x => x.player_order == order)))
      formationPanels.Add(ec.getFieldPanel(pvpStageFormation.formation_y - 1, pvpStageFormation.formation_x - 1));
    Debug.LogWarning((object) (" === createFormationPanels Count:" + (object) formationPanels.Count));
    return formationPanels;
  }

  private void startGVGMain()
  {
    this._stopwatch = new Stopwatch();
    this.StartCoroutine("doGvgMain");
  }

  public void startMain() => this.turnInitialize();

  private void timeCount()
  {
    if (this._stopwatch == null || !this._stopwatch.IsRunning)
      return;
    this.setTimeLimit(this.currentLimit, this._stopwatch.ElapsedMilliseconds);
  }

  private bool timeLimitp()
  {
    return this._stopwatch != null && this._stopwatch.IsRunning && this._timeLimit.value == 0;
  }

  [DebuggerHidden]
  private IEnumerator doGvgMain()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003CdoGvgMain\u003Ec__Iterator9BA()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void turnInitialize()
  {
    Debug.LogWarning((object) " === turnInitialize");
    BL core = this.bm.environment.core;
    this.remainTurn.value = this.endTurn - core.phaseState.turnCount;
    bool flag1 = true;
    bool flag2 = true;
    foreach (BL.Unit unit in core.playerUnits.value)
    {
      if (unit.isEnable && !unit.isDead)
      {
        flag1 = false;
        break;
      }
    }
    foreach (BL.Unit unit in core.enemyUnits.value)
    {
      if (unit.isEnable && !unit.isDead)
      {
        flag2 = false;
        break;
      }
    }
    foreach (BL.UnitPosition unitPosition in core.unitPositions.value)
    {
      if (unitPosition.unit.isDead)
      {
        if (flag1 && core.playerUnits.value.Contains(unitPosition.unit))
          unitPosition.unit.pvpRespawnCount = 0;
        else if (flag2 && core.enemyUnits.value.Contains(unitPosition.unit))
          unitPosition.unit.pvpRespawnCount = 0;
        else
          --unitPosition.unit.pvpRespawnCount;
      }
    }
    List<BL.Unit> spawns1 = new List<BL.Unit>();
    List<BL.Unit> spawns2 = new List<BL.Unit>();
    foreach (BL.UnitPosition up in core.unitPositions.value)
    {
      if (up.unit.isDead && up.unit.pvpRespawnCount == 0)
      {
        Debug.LogWarning((object) (" ==== リスポーン:" + up.unit.unit.name));
        foreach (BL.Panel panel in (!up.unit.isPlayerControl ? (IEnumerable<BL.Panel>) this.formationPanelEnemy : (IEnumerable<BL.Panel>) this.formationPanel).Shuffle<BL.Panel>())
        {
          if (core.isMoveOKPanel(panel, up.unit, false, up.moveCost) && core.getFieldUnit(panel) == null)
          {
            this.resetPosition(up, panel.row, panel.column, true);
            break;
          }
        }
        if (up.unit.isPlayerControl)
          spawns1.Add(up.unit);
        else
          spawns2.Add(up.unit);
      }
    }
    if (spawns1.Count > 0)
      this.spawnsEffects(spawns1, this.spawnPlayerPrefab);
    if (spawns2.Count > 0)
      this.spawnsEffects(spawns2, this.spawnEnemyPrefab);
    this.btm.setPhaseState(BL.Phase.turn_initialize);
  }

  private bool setNextPhase(List<BL.UnitPosition> units, BL.Phase state)
  {
    if (units.Count > 0)
    {
      this.btm.setPhaseState(state);
      switch (state)
      {
        case BL.Phase.pvp_player_start:
          this.resetTimeLimit(this.setting.timeLimit);
          break;
        case BL.Phase.pvp_enemy_start:
          this._isWaitAction = true;
          break;
      }
      return true;
    }
    this._isWaitAction = false;
    return false;
  }

  private void nextState(BL.Phase state)
  {
    Debug.LogWarning((object) " === nextState");
    this.btm.setScheduleAction((System.Action) (() => this.nextStateWaitAction = (System.Action) (() =>
    {
      BL core = this.bm.environment.core;
      Debug.LogWarning((object) (" === playerActionUnits:" + (object) core.playerActionUnits.value.Count));
      Debug.LogWarning((object) (" === enemyActionUnits:" + (object) core.enemyActionUnits.value.Count));
      if (this.isGameFinish())
        this.finishBattle();
      else if (state == BL.Phase.enemy)
      {
        if (!this.setNextPhase(core.playerActionUnits.value, BL.Phase.pvp_player_start) && !this.setNextPhase(core.enemyActionUnits.value, BL.Phase.pvp_enemy_start))
          this.turnInitialize();
      }
      else if (!this.setNextPhase(core.enemyActionUnits.value, BL.Phase.pvp_enemy_start) && !this.setNextPhase(core.playerActionUnits.value, BL.Phase.pvp_player_start))
        this.turnInitialize();
      Debug.LogWarning((object) " === nextState btm Done!");
    })));
  }

  public void locateUnitsCompleted()
  {
    Debug.LogWarning((object) " === locateUnitsCompleted");
    this._stopwatch.Reset();
    BL core = this.bm.environment.core;
    foreach (BL.Unit unit in core.playerUnits.value)
      core.getUnitPosition(unit).completeActionUnit(core);
    this._isDisposition = true;
    this.btm.setPhaseState(BL.Phase.pvp_start_init);
  }

  private void resetTimeLimit(int limit)
  {
    this.currentLimit = limit;
    this.btm.setScheduleAction((System.Action) (() =>
    {
      this._stopwatch.Reset();
      this._stopwatch.Start();
      this.setTimeLimit(limit, this._stopwatch.ElapsedMilliseconds);
    }));
  }

  public void turnInitializeCompleted()
  {
    Debug.LogWarning((object) " === turnInitializeCompleted");
    this.btm.setPhaseState(BL.Phase.pvp_player_start);
    this.resetTimeLimit(this.setting.timeLimit);
  }

  public void actionUnitCompleted()
  {
    Debug.LogWarning((object) " === actionUnitCompleted");
    BL core = this.bm.environment.core;
    this.aiController.clearAIActionOrder();
    this.nextState(core.phaseState.state);
  }

  public void moveUnit(BL.UnitPosition up)
  {
    Debug.LogWarning((object) " === moveUnit");
    BL core = this.bm.environment.core;
    up.completeActionUnit(core);
    this.nextState(core.phaseState.state);
  }

  public void moveUnitWithAttack(
    BL.UnitPosition attack,
    BL.UnitPosition defense,
    bool isHeal,
    int attackStatusIndex)
  {
    Debug.LogWarning((object) " === moveUnitWithAttack");
    BE environment = this.bm.environment;
    BattleFuncs.getAttackStatusArray(attack, defense, true, isHeal);
    BL core = environment.core;
    AttackStatus attackStatus = BattleFuncs.getAttackStatusArray(attack, defense, true, isHeal)[attackStatusIndex];
    if (isHeal)
      environment.useMagicBullet(attackStatus.magicBullet, attackStatus.heal_attack, attack.unit, new List<BL.Unit>()
      {
        defense.unit
      }, this.btm);
    else
      this.bm.startDuel(BattleFuncs.calcDuel(attackStatus, attack, defense));
    this.nextState(core.phaseState.state);
  }

  public void moveUnitWithAttack(
    BL.Unit attack,
    BL.Unit defense,
    bool isHeal,
    int attackStatusIndex)
  {
    BL core = this.bm.environment.core;
    this.moveUnitWithAttack(core.getUnitPosition(attack), core.getUnitPosition(defense), isHeal, attackStatusIndex);
  }

  public void moveUnitWithSkill(BL.Unit unit, BL.Skill skill, List<BL.Unit> targets)
  {
    Debug.LogWarning((object) " === moveUnitWithSkill");
    BL core = this.bm.environment.core;
    this.bm.environment.useSkill(unit, skill, targets, this.btm);
    this.nextState(core.phaseState.state);
  }

  public void readyComplited()
  {
    Debug.LogWarning((object) " === readyComplited");
    this.btm.setPhaseState(BL.Phase.pvp_disposition);
    this.resetTimeLimit(this.setting.timeLimit);
  }

  private void resetPosition(BL.UnitPosition up, int row, int column, bool resetDirection)
  {
    RecoveryUtility.resetPosition(up, row, column);
    if (!resetDirection)
      return;
    up.direction = this.playerOrder != 0 ? (!up.unit.isPlayerControl ? 0.0f : 180f) : (!up.unit.isPlayerControl ? 180f : 0.0f);
    this.bm.environment.unitResource[up.unit].unitParts.moveStayUpdate();
  }

  private void finishBattle()
  {
    Debug.LogWarning((object) " ===    FinishBattle");
    this.bm.battleEffects.startEffect((Transform) null, 3f, popupPrefab: this.finishPrefab);
    this.btm.setPhaseState(BL.Phase.pvp_result);
  }

  private void apllyUnitData(BL.Unit deadUnit, BL.Unit killUnit)
  {
    BL core = this.bm.environment.core;
    int num = this.calcPoint(deadUnit);
    if (core.getForceID(deadUnit) == BL.ForceID.enemy)
      this.playerPoint_reserve += num;
    else
      this.enemyPoint_reserve += num;
    killUnit.pvpPoint += num;
    deadUnit.pvpRespawnCount = this.calcRespawnCount(deadUnit);
  }

  public void applyGVGDeadUnit(BL.Unit attack, BL.Unit defense)
  {
    if (attack.hp <= 0)
    {
      this.apllyUnitData(attack, defense);
    }
    else
    {
      if (defense.hp > 0)
        return;
      this.apllyUnitData(defense, attack);
    }
  }

  private void setTimeLimit(int limit, long swms)
  {
    long num1 = 100;
    int num2 = (int) (((long) (limit * 1000) + num1 - swms) / 1000L);
    if (num2 < 0)
      num2 = 0;
    if (this.timeLimit.value == num2)
      return;
    this.timeLimit.value = num2;
  }

  public int endTurn => (int) ((double) this.setting.turns * (double) this.setting.turns_factor);

  public int endPoint => this.setting.point;

  private GVGSetting setting => this.bm.battleInfo.gvgSetting;

  private int calcPoint(BL.Unit unit)
  {
    return (int) ((double) this.setting.point_base_factor + ((double) (unit.unit.rarity.index + 1) * (double) this.setting.point_rarity_factor + (double) unit.unit.cost * (double) this.setting.point_cost_factor) * (!unit.is_leader ? (double) this.setting.point_no_leader_factor : (double) this.setting.point_leader_factor));
  }

  private int calcRespawnCount(BL.Unit unit)
  {
    Debug.LogWarning((object) (" === calcRespawnCount unit:" + (object) unit + " count:" + (object) (int) ((double) this.setting.respawn_base_factor + ((double) (unit.unit.rarity.index + 1) * (double) this.setting.respawn_rarity_factor + (double) unit.unit.cost * (double) this.setting.respawn_cost_factor))));
    return (int) ((double) this.setting.respawn_base_factor + ((double) (unit.unit.rarity.index + 1) * (double) this.setting.respawn_rarity_factor + (double) unit.unit.cost * (double) this.setting.respawn_cost_factor));
  }

  private bool isGameFinish()
  {
    BL core = this.bm.environment.core;
    return this.playerPoint.value >= this.endPoint || this.enemyPoint.value >= this.endPoint || core.phaseState.turnCount > this.endTurn;
  }
}
