// Decompiled with JetBrains decompiler
// Type: GVGManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using Net;
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
  private string spawnPlayerPrefabPath = "BattleEffects/field/ef657_fe_Multi_Unit_Sporn";
  private string spawnEnemyPrefabPath = "BattleEffects/field/ef658_fe_Multi_Enemy_Sporn";
  private GameObject finishPrefab;
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
  private BL.StructValue<bool> _isPlayerWipedOut;
  private BL.StructValue<bool> _isEnemyWipedOut;
  private HashSet<BL.Panel> _formationPanel;
  private HashSet<BL.Panel> _formationPanelEnemy;
  private int _starNum;
  private string _victory_condition = string.Empty;
  private string _victory_sub_condition = string.Empty;
  private BL.Phase saveState = BL.Phase.none;
  private Dictionary<BattleMonoBehaviour, bool> nextStateFlags = new Dictionary<BattleMonoBehaviour, bool>();
  private List<BattleMonoBehaviour> nextStateFlagsKeys = new List<BattleMonoBehaviour>();
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

  public BL.StructValue<bool> isPlayerWipedOut => this._isPlayerWipedOut;

  public BL.StructValue<bool> isEnemyWipedOut => this._isEnemyWipedOut;

  public string playerGuildName => this.setting.myGuildName;

  public string playerName => SMManager.Observe<Player>().Value.name;

  public int playerEmblem => SMManager.Observe<Player>().Value.current_emblem_id;

  public string enemyGuildName => this.setting.enemyGuildname;

  public string enemyName => this.setting.enemyPlayerName;

  public int enemyEmblem => this.setting.enemyEmblemID;

  public int enemyContribution => this.setting.enemyContribution;

  public int enemyLevel => this.setting.enemyLevel;

  public int enemyGuildPosition => this.setting.enemyGuildPosition;

  public int enemyKeepStar => this.setting.enemyKeepStar;

  public int enemyTownLevel => this.setting.enemyTownLevel;

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

  public int playerAnnihilationCount => this.bm.environment.core.playerAnnihilationCount;

  public int enemyAnnihilationCount => this.bm.environment.core.enemyAnnihilationCount;

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

  public int starNum => this._starNum;

  public string victory_condition
  {
    get
    {
      return Consts.Format(Consts.GetInstance().GUILD_BATTLE_VICTORY_CONDITION, (IDictionary) new Hashtable()
      {
        {
          (object) "cnt",
          (object) this.bm.battleInfo.gvgSetting.turns.ToLocalizeNumberText()
        }
      });
    }
  }

  public string victory_sub_condition
  {
    get
    {
      return Consts.Format(Consts.GetInstance().GUILD_BATTLE_SUB_CONDITION1, (IDictionary) new Hashtable()
      {
        {
          (object) "cnt",
          (object) this.bm.battleInfo.gvgSetting.turns.ToLocalizeNumberText()
        }
      });
    }
  }

  protected override void Initialize()
  {
    this.bm = Singleton<NGBattleManager>.GetInstance();
    this._remainTurn = new BL.StructValue<int>(0);
    this._timeLimit = new BL.StructValue<int>(0);
    this._playerPoint = new BL.StructValue<int>(0);
    this._enemyPoint = new BL.StructValue<int>(0);
    this._isPlayerWipedOut = new BL.StructValue<bool>(false);
    this._isEnemyWipedOut = new BL.StructValue<bool>(false);
  }

  public int playerOrder => this.bm.order;

  public void deadReserveToPoint(bool isEnemy)
  {
    if (this.bm.environment.core.phaseState.state == BL.Phase.finalize)
      return;
    if (isEnemy)
    {
      if (this.playerPoint.value != this.playerPoint_reserve)
        this.playerPoint.value = this.bm.environment.core.playerPointView = this.playerPoint_reserve;
    }
    else if (this.enemyPoint.value != this.enemyPoint_reserve)
      this.enemyPoint.value = this.bm.environment.core.enemyPointView = this.enemyPoint_reserve;
    this.clearNextStateFlags();
    this.btm.setEnableWait(0.2f);
    BL core1 = this.bm.environment.core;
    if (this.checkAnnihilationp((IEnumerable<BL.Unit>) core1.playerUnits.value))
    {
      this.btm.setScheduleAction((System.Action) (() =>
      {
        this.isEnemyWipedOut.value = true;
        BL.StructValue<int> enemyPoint = this.enemyPoint;
        BL core2 = this.bm.environment.core;
        int num1 = this.enemyPoint_reserve + this.setting.annihilation_point;
        this.enemyPoint_reserve = num1;
        int num2;
        int num3 = num2 = num1;
        core2.enemyPointView = num2;
        int num4 = num3;
        enemyPoint.value = num4;
        ++this.bm.environment.core.playerAnnihilationCount;
      }));
      this.btm.setEnableWait(0.2f);
    }
    if (!this.checkAnnihilationp((IEnumerable<BL.Unit>) core1.enemyUnits.value))
      return;
    this.btm.setScheduleAction((System.Action) (() =>
    {
      this.isPlayerWipedOut.value = true;
      BL.StructValue<int> playerPoint = this.playerPoint;
      BL core3 = this.bm.environment.core;
      int num5 = this.playerPoint_reserve + this.setting.annihilation_point;
      this.playerPoint_reserve = num5;
      int num6;
      int num7 = num6 = num5;
      core3.playerPointView = num6;
      int num8 = num7;
      playerPoint.value = num8;
      ++this.bm.environment.core.enemyAnnihilationCount;
    }));
    this.btm.setEnableWait(0.2f);
  }

  [DebuggerHidden]
  public IEnumerator cleanupGVG()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003CcleanupGVG\u003Ec__IteratorA8A()
    {
      \u003C\u003Ef__this = this
    };
  }

  public Future<None> startGVG(GameCore.BattleInfo battleInfo, bool isRestart)
  {
    return new Future<None>((Func<Promise<None>, IEnumerator>) (promise => this._startGVG(promise, battleInfo, isRestart)));
  }

  [DebuggerHidden]
  private IEnumerator _startGVG(Promise<None> promise, GameCore.BattleInfo battleInfo, bool isRestart)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003C_startGVG\u003Ec__IteratorA8B()
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
    return (IEnumerator) new GVGManager.\u003C_battleReady\u003Ec__IteratorA8C()
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
    return (IEnumerator) new GVGManager.\u003CcreateEnvironment\u003Ec__IteratorA8D()
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
    return (IEnumerator) new GVGManager.\u003CinitPrefabs\u003Ec__IteratorA8E()
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
    }, (BL.Unit) null, spawns, (GameObject) null, (GameObject) null, prefab, (System.Action) null, (System.Action) (() =>
    {
      foreach (BL.Unit spawn in spawns)
      {
        spawn.rebirth(env.core);
        spawn.rebirthBE(env);
      }
    }), (List<BL.Unit>) null);
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
    GVGManager.\u003CdestroyGVGManager\u003Ec__IteratorA8F managerCIteratorA8F = new GVGManager.\u003CdestroyGVGManager\u003Ec__IteratorA8F();
    return (IEnumerator) managerCIteratorA8F;
  }

  private HashSet<BL.Panel> createFormationPanels(int order)
  {
    BL ec = this.bm.environment.core;
    HashSet<BL.Panel> formationPanels = new HashSet<BL.Panel>();
    foreach (GvgStageFormation gvgStageFormation in ((IEnumerable<GvgStageFormation>) MasterData.GvgStageFormationList).Where<GvgStageFormation>((Func<GvgStageFormation, bool>) (x => x.stage.ID == ec.stage.id)).Where<GvgStageFormation>((Func<GvgStageFormation, bool>) (x => x.player_order == order)))
      formationPanels.Add(ec.getFieldPanel(gvgStageFormation.formation_y - 1, gvgStageFormation.formation_x - 1));
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
    if (this._stopwatch == null || !this._stopwatch.IsRunning || this._isWaitAction)
      return;
    this.setTimeLimit(this.currentLimit, this._stopwatch.ElapsedMilliseconds);
  }

  private bool timeLimitp()
  {
    return this._stopwatch != null && this._stopwatch.IsRunning && this._timeLimit.value == 0;
  }

  private bool moveingUnitp(BE env)
  {
    foreach (BL.UnitPosition up in env.core.unitPositions.value)
    {
      if (up.isMoving(env))
        return true;
    }
    return false;
  }

  [DebuggerHidden]
  private IEnumerator doGvgMain()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003CdoGvgMain\u003Ec__IteratorA90()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void execNextState(BattleMonoBehaviour bmb)
  {
    if (!this.nextStateFlags.ContainsKey(bmb))
      this.nextStateFlagsKeys.Add(bmb);
    this.nextStateFlags[bmb] = true;
  }

  private bool checkNextStateFlags()
  {
    foreach (KeyValuePair<BattleMonoBehaviour, bool> nextStateFlag in this.nextStateFlags)
    {
      if (!nextStateFlag.Value)
        return false;
    }
    return true;
  }

  private void clearNextStateFlags()
  {
    foreach (BattleMonoBehaviour nextStateFlagsKey in this.nextStateFlagsKeys)
      this.nextStateFlags[nextStateFlagsKey] = false;
  }

  private bool checkAnnihilationp(IEnumerable<BL.Unit> units)
  {
    foreach (BL.Unit unit in units)
    {
      if (unit.isEnable && !unit.isDead)
        return false;
    }
    return true;
  }

  private void turnInitialize()
  {
    BL core1 = this.bm.environment.core;
    this.remainTurn.value = this.endTurn - core1.phaseState.turnCount;
    if (this.isGameFinish())
    {
      this.finishBattle();
    }
    else
    {
      bool flag1 = this.checkAnnihilationp((IEnumerable<BL.Unit>) core1.playerUnits.value);
      bool flag2 = this.checkAnnihilationp((IEnumerable<BL.Unit>) core1.enemyUnits.value);
      foreach (BL.UnitPosition unitPosition in core1.unitPositions.value)
      {
        if (unitPosition.unit.isDead)
        {
          if (flag1 && core1.playerUnits.value.Contains(unitPosition.unit))
            unitPosition.unit.pvpRespawnCount = 0;
          else if (flag2 && core1.enemyUnits.value.Contains(unitPosition.unit))
            unitPosition.unit.pvpRespawnCount = 0;
          else
            --unitPosition.unit.pvpRespawnCount;
        }
      }
      List<BL.Unit> spawns1 = new List<BL.Unit>();
      List<BL.Unit> spawns2 = new List<BL.Unit>();
      foreach (BL.UnitPosition up in core1.unitPositions.value)
      {
        if (up.unit.isDead && up.unit.pvpRespawnCount == 0)
        {
          HashSet<BL.Panel> self = !up.unit.isPlayerControl ? this.formationPanelEnemy : this.formationPanel;
          BL core2 = this.bm.environment.core;
          foreach (BL.Panel panel in self.Shuffle<BL.Panel>())
          {
            if (core1.isMoveOKPanel(panel, up.unit, false, up.moveCost) && core1.getFieldUnit(panel) == null)
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
  }

  private bool setNextPhase(List<BL.UnitPosition> units, BL.Phase state, BL.Phase cantChangeState)
  {
    if (this.bm.environment.core.currentUnitPosition.cantChangeCurrent)
    {
      this.btm.setPhaseState(cantChangeState);
      if (cantChangeState == BL.Phase.pvp_player_start)
      {
        this.resetTimeLimit(this.setting.timeLimit);
        this._isWaitAction = false;
      }
      else
        this._isWaitAction = true;
      return true;
    }
    if (units.Count > 0)
    {
      this.btm.setPhaseState(state);
      switch (state)
      {
        case BL.Phase.pvp_player_start:
          this.resetTimeLimit(this.setting.timeLimit);
          this._isWaitAction = false;
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
    this.bm.environment.core.phaseState.setStateWith(BL.Phase.none, this.bm.environment.core, (System.Action) (() => { }));
    this.nextStateWaitAction = (System.Action) (() =>
    {
      BL core = this.bm.environment.core;
      if (this.isGameFinish())
        this.finishBattle();
      else if (state == BL.Phase.enemy)
      {
        if (this.setNextPhase(core.playerActionUnits.value, BL.Phase.pvp_player_start, BL.Phase.pvp_enemy_start) || this.setNextPhase(core.enemyActionUnits.value, BL.Phase.pvp_enemy_start, BL.Phase.pvp_player_start))
          return;
        this.turnInitialize();
      }
      else
      {
        if (this.setNextPhase(core.enemyActionUnits.value, BL.Phase.pvp_enemy_start, BL.Phase.pvp_player_start) || this.setNextPhase(core.playerActionUnits.value, BL.Phase.pvp_player_start, BL.Phase.pvp_enemy_start))
          return;
        this.turnInitialize();
      }
    });
    this.clearNextStateFlags();
  }

  public void locateUnitsCompleted()
  {
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
    this.btm.setPhaseState(BL.Phase.pvp_player_start);
    this.resetTimeLimit(this.setting.timeLimit);
  }

  public void actionUnitCompleted()
  {
    BL core = this.bm.environment.core;
    this.aiController.clearAIActionOrder();
    this._isWaitAction = false;
    this.nextState(core.phaseState.state);
  }

  public void wipedOutCompleted()
  {
  }

  public void moveUnit(BL.UnitPosition up)
  {
    BL ec = this.bm.environment.core;
    up.completeActionUnit(ec);
    this.btm.setScheduleAction((System.Action) (() => this.nextState(ec.phaseState.state)));
  }

  public void moveUnitWithAttack(
    BL.UnitPosition attack,
    BL.UnitPosition defense,
    bool isHeal,
    int attackStatusIndex)
  {
    this._isWaitAction = true;
    BE environment = this.bm.environment;
    BL ec = environment.core;
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    AttackStatus attackStatus = BattleFuncs.getAttackStatusArray(attack, defense, true, isHeal)[attackStatusIndex];
    if (isHeal)
    {
      if (instance.sceneName != this.bm.topScene)
        this.btm.backSceneWithReturnWait();
      environment.useMagicBullet(attackStatus.magicBullet, attackStatus.heal_attack, attack.unit, new List<BL.Unit>()
      {
        defense.unit
      }, this.btm);
    }
    else
      this.bm.startDuel(BattleFuncs.calcDuel(attackStatus, attack, defense));
    this.btm.setScheduleAction((System.Action) (() =>
    {
      this._isWaitAction = false;
      this.nextState(ec.phaseState.state);
    }));
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
    BL ec = this.bm.environment.core;
    this.bm.environment.useSkill(unit, skill, targets, this.btm);
    this.btm.setScheduleAction((System.Action) (() => this.nextState(ec.phaseState.state)));
  }

  public void readyComplited()
  {
    this.btm.setPhaseState(BL.Phase.pvp_disposition);
    this.resetTimeLimit(this.setting.timeLimit);
  }

  private void resetPosition(BL.UnitPosition up, int row, int column, bool resetDirection)
  {
    BE environment = this.bm.environment;
    RecoveryUtility.resetPosition(up, row, column, environment.core);
    if (!resetDirection)
      return;
    up.direction = this.playerOrder != 0 ? (!up.unit.isPlayerControl ? 0.0f : 180f) : (!up.unit.isPlayerControl ? 180f : 0.0f);
    environment.unitResource[up.unit].unitParts.moveStayUpdate();
  }

  private void finishBattle()
  {
    this.bm.battleEffects.startEffect((Transform) null, 3f, popupPrefab: this.finishPrefab, cloneAction: (Action<GameObject>) (o => o.GetComponent<PopupPvpMatchResult>().setResult(this.getFinishBattle(), this.playerOrder)));
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
    if (killUnit != null)
      killUnit.pvpPoint += num;
    deadUnit.pvpRespawnCount = this.calcRespawnCount(deadUnit);
  }

  public void applyGVGDeadUnit(BL.Unit attack, BL.Unit defense)
  {
    if (attack.hp <= 0)
      this.apllyUnitData(attack, defense);
    if (defense == null || defense.hp > 0)
      return;
    this.apllyUnitData(defense, attack);
  }

  private bool deadUnitAndFinish(BL.Unit u)
  {
    if (u.hp > 0)
      return false;
    BL core = this.bm.environment.core;
    int num = this.calcPoint(u);
    return core.getForceID(u) == BL.ForceID.enemy ? this.playerPoint_reserve + num >= this.endPoint : this.enemyPoint_reserve + num >= this.endPoint;
  }

  public bool checkDuelDeadUnitAndFinish(BL.Unit attack, BL.Unit defense)
  {
    return this.deadUnitAndFinish(attack) || this.deadUnitAndFinish(defense);
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
    return (int) ((double) this.setting.respawn_base_factor + ((double) (unit.unit.rarity.index + 1) * (double) this.setting.respawn_rarity_factor + (double) unit.unit.cost * (double) this.setting.respawn_cost_factor));
  }

  private bool isGameFinish()
  {
    BL core = this.bm.environment.core;
    bool flag = this.playerPoint_reserve >= this.endPoint || this.enemyPoint_reserve >= this.endPoint || this.remainTurn.value == 0;
    if (flag)
      core.isWin = this.playerPoint_reserve > this.enemyPoint_reserve;
    return flag;
  }

  private AppPeer.FinishBattle getFinishBattle()
  {
    AppPeer.FinishBattle finishBattle = new AppPeer.FinishBattle();
    this.getVictoryEffectEnum(finishBattle);
    return finishBattle;
  }

  private void getVictoryEffectEnum(AppPeer.FinishBattle finishBattle)
  {
    int num = this.getStarNum();
    if (finishBattle != null)
    {
      finishBattle.victoryEffects = new PvpVictoryEffectEnum[1];
      switch (num)
      {
        case 0:
          finishBattle.victoryEffects[0] = this.playerPoint.value == this.enemyPoint.value || this.playerPoint.value >= this.endPoint && this.enemyPoint.value >= this.endPoint ? PvpVictoryEffectEnum.draw_effect : PvpVictoryEffectEnum.lose_effect;
          break;
        case 1:
          finishBattle.victoryEffects[0] = PvpVictoryEffectEnum.win_effect;
          break;
        case 2:
          finishBattle.victoryEffects[0] = PvpVictoryEffectEnum.great_effect;
          break;
        case 3:
          finishBattle.victoryEffects[0] = PvpVictoryEffectEnum.excellent_effect;
          break;
        default:
          finishBattle.victoryEffects[0] = PvpVictoryEffectEnum.lose_effect;
          break;
      }
    }
    if (this.setting.enemyKeepStar < num)
      num = this.setting.enemyKeepStar;
    this._starNum = num;
  }

  private int getStarNum()
  {
    if (!this.bm.environment.core.isWin)
      return 0;
    bool flag = this.bm.environment.core.playerUnits.value.Sum<BL.Unit>((Func<BL.Unit, int>) (x => x.deadCount)) <= 0;
    int num1 = Mathf.CeilToInt((float) (this.endPoint - this.enemyPoint.value) * 100f / (float) this.endPoint);
    int num2 = Mathf.CeilToInt((float) (this.endPoint - this.playerPoint.value) * 100f / (float) this.endPoint);
    int num3 = this.endTurn - this.bm.environment.core.phaseState.turnCount;
    foreach (GvgStarCondition gvgStarCondition in ((IEnumerable<GvgStarCondition>) MasterData.GvgStarConditionList).OrderBy<GvgStarCondition, int>((Func<GvgStarCondition, int>) (x => x.ID)).ToList<GvgStarCondition>())
    {
      if ((gvgStarCondition.breakaway_condition != GvgBreakawayCondition.no_breakaway || flag) && (gvgStarCondition.breakaway_condition != GvgBreakawayCondition.breakaway || !flag) && (!gvgStarCondition.player_gauge_condition || num1 >= gvgStarCondition.player_gauge_value) && (!gvgStarCondition.enemy_gauge_condition || num2 <= gvgStarCondition.enemy_gauge_value) && (!gvgStarCondition.remain_turn_condition || num3 >= gvgStarCondition.remain_turn_value))
        return gvgStarCondition.star_num;
    }
    return 1;
  }

  [DebuggerHidden]
  private IEnumerator closeGvg()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003CcloseGvg\u003Ec__IteratorA91()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator forceClose(System.Action action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GVGManager.\u003CforceClose\u003Ec__IteratorA92()
    {
      action = action,
      \u003C\u0024\u003Eaction = action
    };
  }
}
