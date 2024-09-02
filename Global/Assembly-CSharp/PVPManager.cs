// Decompiled with JetBrains decompiler
// Type: PVPManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using GameCore.FastMiniJSON;
using MasterDataTable;
using Net;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UniLinq;
using UnityEngine;

#nullable disable
public class PVPManager : Singleton<PVPManager>, IGameEngine
{
  [SerializeField]
  private int timeoutMilliseconds = 60000;
  [SerializeField]
  private float loadingMinTime = 0.5f;
  private string winLosePrefabPath = "Prefabs/battle/dir_PvpResults";
  private string loadingPrefabPath = "Prefabs/battle/Loading_BattlePrefab";
  private string spawnPlayerPrefabPath = "BattleEffects/field/ef657_fe_Multi_Unit_Sporn";
  private string spawnEnemyPrefabPath = "BattleEffects/field/ef658_fe_Multi_Enemy_Sporn";
  private GameObject winLosePrefab;
  private GameObject loadingPrefab;
  private GameObject spawnPlayerPrefab;
  private GameObject spawnEnemyPrefab;
  public Exception exception;
  private NGBattleManager bm;
  private AppPeer peer;
  private BattleTimeManager _btm;
  private BattleAIController _aiController;
  private BattleInputObserver _inputObserver;
  private bool _isRunning;
  private bool _isWaitAction;
  private bool _isDisposition;
  private bool sendLocateComplited;
  public bool isResult;
  private Stopwatch _stopwatch;
  private BL.StructValue<int> _remainTurn;
  private BL.StructValue<int> _timeLimit;
  private BL.StructValue<int> _playerPoint;
  private BL.StructValue<int> _enemyPoint;
  private int playerPoint_reserve;
  private int enemyPoint_reserve;
  public WebAPI.Response.PvpFriend enemyInfo;
  private HashSet<BL.Panel> _formationPanel;
  private DateTime loadingStartTime;
  private bool isLoading;
  public bool isSending;

  private void OnValidate()
  {
  }

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

  public int endPoint => this.stage.point;

  public BL.StructValue<int> remainTurn => this._remainTurn;

  public BL.StructValue<int> timeLimit => this._timeLimit;

  public BL.StructValue<int> playerPoint => this._playerPoint;

  public BL.StructValue<int> enemyPoint => this._enemyPoint;

  private string host
  {
    get => Persist.pvpSuspend.Data.host;
    set => Persist.pvpSuspend.Data.host = value;
  }

  private int port
  {
    get => Persist.pvpSuspend.Data.port;
    set => Persist.pvpSuspend.Data.port = value;
  }

  private string battleToken
  {
    get => Persist.pvpSuspend.Data.token;
    set => Persist.pvpSuspend.Data.token = value;
  }

  public MpStage stage
  {
    get => Persist.pvpSuspend.Data.stage;
    set => Persist.pvpSuspend.Data.stage = value;
  }

  public Player player
  {
    get => Persist.pvpSuspend.Data.player;
    set => Persist.pvpSuspend.Data.player = value;
  }

  public Player enemy
  {
    get => Persist.pvpSuspend.Data.enemy;
    set => Persist.pvpSuspend.Data.enemy = value;
  }

  public PvpMatchingTypeEnum matchingType
  {
    get => Persist.pvpSuspend.Data.matchingType;
    set => Persist.pvpSuspend.Data.matchingType = value;
  }

  public string playerName => this.player.name;

  public string enemyName => this.enemy.name;

  public int playerEmblem => this.player.current_emblem_id;

  public int enemyEmblem => this.enemy.current_emblem_id;

  public HashSet<BL.Panel> formationPanel
  {
    get
    {
      if (this._formationPanel == null)
        this._formationPanel = this.createFormationPanels(this.playerOrder);
      return this._formationPanel;
    }
  }

  protected override void Initialize()
  {
    this.bm = Singleton<NGBattleManager>.GetInstance();
    this._remainTurn = new BL.StructValue<int>(0);
    this._timeLimit = new BL.StructValue<int>(0);
    this._playerPoint = new BL.StructValue<int>(0);
    this._enemyPoint = new BL.StructValue<int>(0);
    this.playerPoint_reserve = this.playerPoint.value;
    this.enemyPoint_reserve = this.enemyPoint.value;
  }

  public int playerOrder => this.bm.order;

  public void deadReserveToPoint(bool isEnemy)
  {
    if (this.bm.environment.core.phaseState.state == BL.Phase.finalize)
      return;
    if (isEnemy)
    {
      if (this.playerPoint.value == this.playerPoint_reserve)
        return;
      this.playerPoint.value = this.playerPoint_reserve;
    }
    else
    {
      if (this.enemyPoint.value == this.enemyPoint_reserve)
        return;
      this.enemyPoint.value = this.enemyPoint_reserve;
    }
  }

  public PVPMatching getMatchingBehaviour()
  {
    PVPMatching matchingBehaviour = ((Component) this).gameObject.GetComponent<PVPMatching>();
    if (Object.op_Equality((Object) matchingBehaviour, (Object) null))
      matchingBehaviour = ((Component) this).gameObject.AddComponent<PVPMatching>();
    return matchingBehaviour;
  }

  public void startMain()
  {
    if (this._stopwatch == null)
      this._stopwatch = new Stopwatch();
    if (!this.isDisposition)
    {
      this.StartCoroutine("doPvpDisposition");
    }
    else
    {
      if (this.isRunning)
        return;
      if (Object.op_Inequality((Object) Singleton<DebugText>.GetInstanceOrNull(), (Object) null))
        ((Behaviour) Singleton<DebugText>.GetInstance()).enabled = false;
      this._isRunning = true;
      this.StartCoroutine("doPvpMain");
    }
  }

  public void stopPVPMain()
  {
    if (!this.isDisposition)
      this.StopCoroutine("doPvpDisposition");
    else if (this.isRunning)
    {
      if (Object.op_Inequality((Object) Singleton<DebugText>.GetInstanceOrNull(), (Object) null))
        ((Behaviour) Singleton<DebugText>.GetInstance()).enabled = true;
      this.StopCoroutine("doPvpMain");
      this._isRunning = false;
    }
    this._stopwatch = (Stopwatch) null;
    if (!this.isLoading)
      return;
    this._viewLoading(false);
  }

  [DebuggerHidden]
  public IEnumerator cleanupPVP()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003CcleanupPVP\u003Ec__Iterator861()
    {
      \u003C\u003Ef__this = this
    };
  }

  public Future<None> startPVP(string host, int port, string battleToken, bool isRestart)
  {
    return new Future<None>((Func<Promise<None>, IEnumerator>) (promise => this._startPVP(promise, host, port, battleToken, isRestart)));
  }

  [DebuggerHidden]
  private IEnumerator _startPVP(
    Promise<None> promise,
    string host,
    int port,
    string battleToken,
    bool isRestart)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_startPVP\u003Ec__Iterator862()
    {
      host = host,
      port = port,
      battleToken = battleToken,
      isRestart = isRestart,
      promise = promise,
      \u003C\u0024\u003Ehost = host,
      \u003C\u0024\u003Eport = port,
      \u003C\u0024\u003EbattleToken = battleToken,
      \u003C\u0024\u003EisRestart = isRestart,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }

  public Future<AppPeer> connectServer(string host, int port, string battleToken)
  {
    return new Future<AppPeer>((Func<Promise<AppPeer>, IEnumerator>) (promise => this._connectServer(promise, host, port, battleToken)));
  }

  [DebuggerHidden]
  private IEnumerator _connectServer(
    Promise<AppPeer> promise,
    string host,
    int port,
    string battleToken)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_connectServer\u003Ec__Iterator863()
    {
      host = host,
      port = port,
      promise = promise,
      battleToken = battleToken,
      \u003C\u0024\u003Ehost = host,
      \u003C\u0024\u003Eport = port,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u0024\u003EbattleToken = battleToken
    };
  }

  [DebuggerHidden]
  private IEnumerator _battleReady(Promise<None> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_battleReady\u003Ec__Iterator864()
    {
      promise = promise,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createEnvironment(PVPManager.CreateEnvInfo info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003CcreateEnvironment\u003Ec__Iterator865()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  private void resetPlayerControllUnits(int order)
  {
    if (order != 1)
      return;
    BE environment = this.bm.environment;
    BL.ClassValue<List<BL.Unit>> playerUnits = environment.core.playerUnits;
    environment.core.playerUnits = environment.core.enemyUnits;
    environment.core.enemyUnits = playerUnits;
    foreach (BL.Unit unit in environment.core.playerUnits.value)
      unit.isPlayerControl = true;
    foreach (BL.Unit unit in environment.core.enemyUnits.value)
      unit.isPlayerControl = false;
  }

  [DebuggerHidden]
  private IEnumerator initPrefabs()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003CinitPrefabs\u003Ec__Iterator866()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doPvpDisposition()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003CdoPvpDisposition\u003Ec__Iterator867()
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

  [DebuggerHidden]
  private IEnumerator doPvpMain()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003CdoPvpMain\u003Ec__Iterator868()
    {
      \u003C\u003Ef__this = this
    };
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

  private void _viewLoading(bool isView)
  {
    if (isView)
      this.isSending = false;
    if (this.isLoading == isView || Singleton<CommonRoot>.GetInstance().isLoading)
      return;
    this.bm.isBattleEnable = true;
    if (isView)
    {
      this.loadingStartTime = DateTime.Now;
      this.bm.popupCloseAll();
      this.bm.popupOpen(this.loadingPrefab, isViewBack: false, isNonSe: true);
    }
    else
      this.bm.popupDismiss(true);
    this.isLoading = isView;
  }

  [DebuggerHidden]
  private IEnumerator hideLoading()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003ChideLoading\u003Ec__Iterator869()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _ReadyCompleted()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_ReadyCompleted\u003Ec__Iterator86A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _LocateUnitsCompleted(Tuple<int, int, int>[] unitPositions)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_LocateUnitsCompleted\u003Ec__Iterator86B()
    {
      unitPositions = unitPositions,
      \u003C\u0024\u003EunitPositions = unitPositions,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _ActionUnitCompleted()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_ActionUnitCompleted\u003Ec__Iterator86C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _TurnInitializeCompleted()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_TurnInitializeCompleted\u003Ec__Iterator86D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _MoveUnitTimeout(int? currentUnitPositionId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_MoveUnitTimeout\u003Ec__Iterator86E()
    {
      currentUnitPositionId = currentUnitPositionId,
      \u003C\u0024\u003EcurrentUnitPositionId = currentUnitPositionId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _MoveUnit(int unitPositionId, int row, int column)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_MoveUnit\u003Ec__Iterator86F()
    {
      unitPositionId = unitPositionId,
      row = row,
      column = column,
      \u003C\u0024\u003EunitPositionId = unitPositionId,
      \u003C\u0024\u003Erow = row,
      \u003C\u0024\u003Ecolumn = column,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _MoveUnitWithAttack(
    int unitPositionId,
    int row,
    int column,
    int targetUnitPositionId,
    bool isHeal,
    int attackStatusIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_MoveUnitWithAttack\u003Ec__Iterator870()
    {
      unitPositionId = unitPositionId,
      row = row,
      column = column,
      targetUnitPositionId = targetUnitPositionId,
      isHeal = isHeal,
      attackStatusIndex = attackStatusIndex,
      \u003C\u0024\u003EunitPositionId = unitPositionId,
      \u003C\u0024\u003Erow = row,
      \u003C\u0024\u003Ecolumn = column,
      \u003C\u0024\u003EtargetUnitPositionId = targetUnitPositionId,
      \u003C\u0024\u003EisHeal = isHeal,
      \u003C\u0024\u003EattackStatusIndex = attackStatusIndex,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _MoveUnitWithSkill(
    int unitPositionId,
    int row,
    int column,
    int[] targetPositionIds,
    int skillId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_MoveUnitWithSkill\u003Ec__Iterator871()
    {
      unitPositionId = unitPositionId,
      row = row,
      column = column,
      targetPositionIds = targetPositionIds,
      skillId = skillId,
      \u003C\u0024\u003EunitPositionId = unitPositionId,
      \u003C\u0024\u003Erow = row,
      \u003C\u0024\u003Ecolumn = column,
      \u003C\u0024\u003EtargetPositionIds = targetPositionIds,
      \u003C\u0024\u003EskillId = skillId,
      \u003C\u003Ef__this = this
    };
  }

  public static PVPManager createPVPManager()
  {
    PVPManager pvpManager = Singleton<PVPManager>.GetInstanceOrNull();
    if (Object.op_Equality((Object) pvpManager, (Object) null))
      pvpManager = new GameObject("PVP Manager").AddComponent<PVPManager>();
    return pvpManager;
  }

  [DebuggerHidden]
  public static IEnumerator destroyPVPManager()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PVPManager.\u003CdestroyPVPManager\u003Ec__Iterator872 managerCIterator872 = new PVPManager.\u003CdestroyPVPManager\u003Ec__Iterator872();
    return (IEnumerator) managerCIterator872;
  }

  private HashSet<BL.Panel> createFormationPanels(int order)
  {
    BE environment = this.bm.environment;
    HashSet<BL.Panel> formationPanels = new HashSet<BL.Panel>();
    foreach (PvpStageFormation pvpStageFormation in ((IEnumerable<PvpStageFormation>) MasterData.PvpStageFormationList).Where<PvpStageFormation>((Func<PvpStageFormation, bool>) (x => x.stage.ID == this.stage.stage_id)).Where<PvpStageFormation>((Func<PvpStageFormation, bool>) (x => x.player_order == order)))
      formationPanels.Add(environment.core.getFieldPanel(pvpStageFormation.formation_y - 1, pvpStageFormation.formation_x - 1));
    return formationPanels;
  }

  public void locateUnitsCompleted()
  {
    if (this.exception != null)
      return;
    BE environment = this.bm.environment;
    List<Tuple<int, int, int>> tupleList = new List<Tuple<int, int, int>>();
    foreach (BL.Unit unit in environment.core.playerUnits.value)
    {
      BL.UnitPosition unitPosition = environment.core.getUnitPosition(unit);
      tupleList.Add(new Tuple<int, int, int>(unitPosition.id, unitPosition.row, unitPosition.column));
    }
    this.StartCoroutine(this._LocateUnitsCompleted(tupleList.ToArray()));
  }

  public void turnInitializeCompleted()
  {
    if (this.exception != null)
      return;
    this.btm.setPhaseState(BL.Phase.pvp_move_unit_waiting);
    this.StartCoroutine(this._TurnInitializeCompleted());
  }

  public void actionUnitCompleted()
  {
    if (this.exception != null)
      return;
    this.aiController.clearAIActionOrder();
    this.StartCoroutine(this._ActionUnitCompleted());
  }

  public void moveUnitTimeout(BL.UnitPosition up)
  {
    if (this.exception != null)
      return;
    this.btm.setPhaseState(BL.Phase.pvp_move_unit_waiting);
    this.StartCoroutine(this._MoveUnitTimeout(up == null ? new int?() : new int?(up.id)));
  }

  public void moveUnit(BL.UnitPosition up)
  {
    if (this.exception != null)
      return;
    this.btm.setPhaseState(BL.Phase.pvp_move_unit_waiting);
    this.StartCoroutine(this._MoveUnit(up.id, up.row, up.column));
  }

  public void moveUnitWithAttack(
    BL.UnitPosition attack,
    BL.UnitPosition defense,
    bool isHeal,
    int attackStatusIndex)
  {
    if (this.exception != null)
      return;
    this.btm.setPhaseState(BL.Phase.pvp_move_unit_waiting);
    this.StartCoroutine(this._MoveUnitWithAttack(attack.id, attack.row, attack.column, defense.id, isHeal, attackStatusIndex));
  }

  public void moveUnitWithAttack(
    BL.Unit attack,
    BL.Unit defense,
    bool isHeal,
    int attackStatusIndex)
  {
    if (this.exception != null)
      return;
    BE environment = this.bm.environment;
    this.moveUnitWithAttack(environment.core.getUnitPosition(attack), environment.core.getUnitPosition(defense), isHeal, attackStatusIndex);
  }

  public void moveUnitWithSkill(BL.UnitPosition up, BL.Skill skill, List<BL.Unit> targets)
  {
    if (this.exception != null)
      return;
    BE environment = this.bm.environment;
    this.btm.setPhaseState(BL.Phase.pvp_move_unit_waiting);
    List<int> intList = new List<int>();
    foreach (BL.Unit target in targets)
      intList.Add(environment.core.getUnitPosition(target).id);
    this.StartCoroutine(this._MoveUnitWithSkill(up.id, up.row, up.column, intList.ToArray(), skill.id));
  }

  public void moveUnitWithSkill(BL.Unit unit, BL.Skill skill, List<BL.Unit> targets)
  {
    if (this.exception != null)
      return;
    this.moveUnitWithSkill(this.bm.environment.core.getUnitPosition(unit), skill, targets);
  }

  public void readyComplited()
  {
    if (this.exception != null)
      return;
    this.StartCoroutine(this._ReadyCompleted());
  }

  public void errorRecovery()
  {
    this.exception = (Exception) null;
    this.btm.setPhaseState(BL.Phase.none);
    this.StartCoroutine(this.doErrorRecovery());
  }

  [DebuggerHidden]
  private IEnumerator _RecoveryRequest(string bt)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003C_RecoveryRequest\u003Ec__Iterator873()
    {
      bt = bt,
      \u003C\u0024\u003Ebt = bt,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doErrorRecovery(bool enableCheck = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003CdoErrorRecovery\u003Ec__Iterator874()
    {
      enableCheck = enableCheck,
      \u003C\u0024\u003EenableCheck = enableCheck,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doRecoveryStartPVPMain()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003CdoRecoveryStartPVPMain\u003Ec__Iterator875()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void applyRecovery(RecoveryType rt)
  {
    BE environment = this.bm.environment;
    this.remainTurn.value = rt.remainTurn;
    this.playerPoint.value = rt.points[this.playerOrder];
    this.enemyPoint.value = rt.points[this.playerOrder != 0 ? 0 : 1];
    RecoveryUtility.Apply(rt, environment.core);
    foreach (BL.UnitPosition unitPosition in environment.core.unitPositions.value)
    {
      BattleUnitParts unitParts = environment.unitResource[unitPosition.unit].unitParts;
      unitParts.moveStayUpdate();
      unitParts.setActive(!unitPosition.unit.isDead);
    }
    if (!Singleton<CommonRoot>.GetInstance().isLoading)
      return;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  private void resetPosition(BL.UnitPosition up, int row, int column, bool resetDirection)
  {
    RecoveryUtility.resetPosition(up, row, column);
    if (!resetDirection)
      return;
    up.direction = this.playerOrder != 0 ? (!up.unit.isPlayerControl ? 0.0f : 180f) : (!up.unit.isPlayerControl ? 180f : 0.0f);
    this.bm.environment.unitResource[up.unit].unitParts.moveStayUpdate();
  }

  private void resetPosition(int unitPositionId, int row, int column, bool resetDirection)
  {
    BE environment = this.bm.environment;
    this.resetPosition(BL.UnitPosition.FromNetwork(new int?(unitPositionId), environment.core), row, column, resetDirection);
  }

  public string getErrorMessage(Exception e) => Consts.Lookup("VERSUS_02694POPUP_DESCRIPTION");

  private void finishBattle(AppPeer.FinishBattle freq)
  {
    this.bm.battleEffects.startEffect((Transform) null, 3f, popupPrefab: this.winLosePrefab, cloneAction: (Action<GameObject>) (o => o.GetComponent<PopupPvpMatchResult>().setResult(freq, this.playerOrder)));
    this.btm.setPhaseState(BL.Phase.pvp_result);
    this.stopPVPMain();
  }

  [DebuggerHidden]
  private IEnumerator noRoomFinish(AppPeer.NoRoom nreq)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPManager.\u003CnoRoomFinish\u003Ec__Iterator876()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnApplicationPause(bool pause)
  {
    if (!pause || this.peer == null)
      return;
    this.peer.Close();
  }

  private void errorCallback(WebAPI.Response.UserError error)
  {
    Singleton<NGSceneManager>.GetInstance().StartCoroutine(PopupCommon.Show(error.Code, error.Reason, (System.Action) (() =>
    {
      NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
      instance.clearStack();
      instance.destroyCurrentScene();
      instance.changeScene(Singleton<CommonRoot>.GetInstance().startScene);
    })));
  }

  private class CreateEnvInfo
  {
    public int order;
    public PlayerUnit[] player1_units;
    public PlayerUnit[] player2_units;
    public Player player1;
    public Player player2;
    public string battle_uuid;
    public MpStage stage;
    public PlayerItem[] player1_items;
    public PlayerItem[] player2_items;
    public Bonus[] bonus;
    public DateTime battle_start_at;

    public void EncodeReady(AppPeer.Ready r)
    {
      WebAPI.Response.InternalPvpStart internalPvpStart = new WebAPI.Response.InternalPvpStart((Dictionary<string, object>) Json.Deserialize(Encoding.UTF8.GetString(r.buffer)));
      this.order = r.order;
      this.player1_units = ((IEnumerable<PlayerUnit>) internalPvpStart.player1_units).Take<PlayerUnit>(5).ToArray<PlayerUnit>();
      this.player2_units = ((IEnumerable<PlayerUnit>) internalPvpStart.player2_units).Take<PlayerUnit>(5).ToArray<PlayerUnit>();
      this.player1 = internalPvpStart.player1;
      this.player2 = internalPvpStart.player2;
      this.battle_uuid = internalPvpStart.battle_uuid;
      this.stage = internalPvpStart.stage;
      this.player1_items = internalPvpStart.player1_items;
      this.player2_items = internalPvpStart.player2_items;
      this.bonus = internalPvpStart.bonus;
      this.battle_start_at = internalPvpStart.battle_start_at;
    }

    public void EncodeResume(WebAPI.Response.PvpResume r)
    {
      this.order = r.order;
      this.player1_units = ((IEnumerable<PlayerUnit>) r.player1_units).Take<PlayerUnit>(5).ToArray<PlayerUnit>();
      this.player2_units = ((IEnumerable<PlayerUnit>) r.player2_units).Take<PlayerUnit>(5).ToArray<PlayerUnit>();
      this.player1 = r.player1;
      this.player2 = r.player2;
      this.battle_uuid = r.battle_uuid;
      this.stage = r.stage;
      this.player1_items = r.player1_items;
      this.player2_items = r.player2_items;
      this.bonus = r.bonus;
      this.battle_start_at = r.battle_start_at;
    }
  }
}
