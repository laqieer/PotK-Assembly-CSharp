// Decompiled with JetBrains decompiler
// Type: NGDuelManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGDuelManager : MonoBehaviour
{
  private const int PLAYER_UNIT = 0;
  private const int ENEMY_UNIT = 1;
  private const string mStoryScene = "story009_3";
  [SerializeField]
  public Transform mMyFirstPosFar;
  [SerializeField]
  public Transform mEnemyFirstPosFar;
  [SerializeField]
  public Transform mMyFirstPosNear;
  [SerializeField]
  public Transform mEnemyFirstPosNear;
  [SerializeField]
  public UISprite mMyArrowUp;
  [SerializeField]
  public UISprite mMyArrowDown;
  [SerializeField]
  public UISprite mEArrowUp;
  [SerializeField]
  public UISprite mEArrowDown;
  [SerializeField]
  private Battle0181CharacterStatus mPlayerUI;
  [SerializeField]
  private Battle0181CharacterStatus mEnemyUI;
  [SerializeField]
  public Battle0181Menu mParentScene;
  [SerializeField]
  public float mDuelSupportDisplayTime;
  [SerializeField]
  public float mBossIntroDisplayTime;
  [SerializeField]
  public GameObject mRoot3d;
  [SerializeField]
  private DuelCameraManager mCameraManager;
  [SerializeField]
  public float DuelCameraDispTime;
  [SerializeField]
  public float DrawDispTime;
  [SerializeField]
  public float WinDispTime;
  [SerializeField]
  public float LoseDispTime;
  [SerializeField]
  public float RemoteCameraChangeDelay;
  [SerializeField]
  public bool useDistance;
  [SerializeField]
  private Light directionalLight;
  [SerializeField]
  private GameObject mPreloadGO;
  private NGDuelManager.DuelStatus currSts = NGDuelManager.DuelStatus.ST_NONE;
  private GameObject mMapObject;
  private Transform PlayerInitPosition;
  private Transform EnemyInitPosition;
  private List<GameObject> destroyList = new List<GameObject>();
  private List<BL.Story> mDuelStorys;
  private NGDuelUnit mPlayerDUnit;
  private NGDuelUnit mEnemyDUnit;
  private int mDuelTurn;
  private bool _isWait;
  private bool mInitialized;
  private float wait_time;
  private Color duelAmbientLight = Color.white;
  private int endVoiceChannel = -1;
  private BattleMap mMapData;
  private Dictionary<string, ClipEventEffectData> preloadClipEventEffectData = new Dictionary<string, ClipEventEffectData>();
  private Dictionary<string, GameObject> preloadGameObject = new Dictionary<string, GameObject>();
  public Dictionary<int, Texture> duelCutin = new Dictionary<int, Texture>();

  [HideInInspector]
  public DuelResult mDuelResult { get; private set; }

  public GameObject mDamagePrefab => Singleton<NGDuelDataManager>.GetInstance().mDamagePrefab;

  public GameObject mCriticalEffect => Singleton<NGDuelDataManager>.GetInstance().mCriticalEffect;

  public GameObject mMissEffect => Singleton<NGDuelDataManager>.GetInstance().mMissEffect;

  public GameObject mShadow => Singleton<NGDuelDataManager>.GetInstance().mShadow;

  public GameObject mDuelSupport => Singleton<NGDuelDataManager>.GetInstance().mDuelSupport;

  public GameObject mCriticalFlash => Singleton<NGDuelDataManager>.GetInstance().mCriticalFlash;

  public GameObject mWeakEffect => Singleton<NGDuelDataManager>.GetInstance().mWeakEffect;

  public GameObject mResistEffect => Singleton<NGDuelDataManager>.GetInstance().mResistEffect;

  public bool isWait
  {
    get => this._isWait;
    set
    {
      if (this._isWait == value)
        return;
      this._isWait = value;
      if (this._isWait)
        return;
      if (Object.op_Inequality((Object) this.mPlayerDUnit, (Object) null))
        this.mPlayerDUnit.TimeReset();
      if (!Object.op_Inequality((Object) this.mEnemyDUnit, (Object) null))
        return;
      this.mEnemyDUnit.TimeReset();
    }
  }

  public int duel_distance => this.mDuelResult.distance;

  public GameObject currentCamera
  {
    get
    {
      return Object.op_Inequality((Object) this.mCameraManager, (Object) null) ? this.mCameraManager.currentCamera : (GameObject) null;
    }
  }

  public NGDuelUnit playerUnit => this.mPlayerDUnit;

  public NGDuelUnit enemyUnit => this.mEnemyDUnit;

  public NGDuelUnit getNGDuelUnit(int unit_type)
  {
    if (unit_type == 0)
      return this.mPlayerDUnit;
    return unit_type == 1 ? this.mEnemyDUnit : (NGDuelUnit) null;
  }

  public bool isDuelEnd => this.currSts == NGDuelManager.DuelStatus.ST_END;

  public static void actScreen(bool darken = true)
  {
    Singleton<CommonRoot>.GetInstance().isActiveBlackBGPanel = darken;
  }

  [DebuggerHidden]
  public IEnumerator Initialize(DuelResult duelResult, DuelEnvironment duelEnv)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelManager.\u003CInitialize\u003Ec__Iterator6A0()
    {
      duelResult = duelResult,
      duelEnv = duelEnv,
      \u003C\u0024\u003EduelResult = duelResult,
      \u003C\u0024\u003EduelEnv = duelEnv,
      \u003C\u003Ef__this = this
    };
  }

  private void MakeGCR(GearKind attackerGearKind, GearKind defenderGearKind)
  {
    GearKindCorrelations kindCorrelations = MasterData.UniqueGearKindCorrelationsBy(attackerGearKind, defenderGearKind);
    if (kindCorrelations == null)
    {
      ((Behaviour) this.mMyArrowUp).enabled = false;
      ((Behaviour) this.mMyArrowDown).enabled = false;
      ((Behaviour) this.mEArrowUp).enabled = false;
      ((Behaviour) this.mEArrowDown).enabled = false;
    }
    else if (kindCorrelations.is_advantage)
    {
      ((Behaviour) this.mMyArrowUp).enabled = true;
      ((Behaviour) this.mMyArrowDown).enabled = false;
      ((Behaviour) this.mEArrowUp).enabled = false;
      ((Behaviour) this.mEArrowDown).enabled = true;
    }
    else
    {
      ((Behaviour) this.mMyArrowUp).enabled = false;
      ((Behaviour) this.mMyArrowDown).enabled = true;
      ((Behaviour) this.mEArrowUp).enabled = true;
      ((Behaviour) this.mEArrowDown).enabled = false;
    }
  }

  private bool checkPostInitialized()
  {
    if (Object.op_Inequality((Object) null, (Object) this.mRoot3d))
    {
      IEnumerable<Transform> children = this.mRoot3d.transform.GetChildren();
      if (children == null)
      {
        Debug.LogError((object) "NGDuelUnit checkPostInitialized DuelRoot3Dに子がありません");
        return false;
      }
      int num = 0;
      foreach (Component component in children)
      {
        if (((Object) component.gameObject).name.Equals("prefab(Clone)"))
          ++num;
      }
      if (num == 3)
        return true;
      Debug.LogError((object) ("NGDuelUnit checkPostInitialized cloneは" + (object) num + "個です"));
      return false;
    }
    Debug.LogError((object) "NGDuelUnit checkPostInitialized DuelRoot3DがNULLです");
    return false;
  }

  private bool checkPreInitialized()
  {
    if (Object.op_Inequality((Object) null, (Object) this.mRoot3d))
    {
      IEnumerable<Transform> children = this.mRoot3d.transform.GetChildren();
      if (children == null)
      {
        Debug.LogError((object) "NGDuelUnit checkPreInitialized DuelRoot3Dに子がありません");
        return false;
      }
      int num = 0;
      foreach (Component component in children)
      {
        if (((Object) component.gameObject).name.Equals("prefab(Clone)"))
          ++num;
      }
      if (num == 0)
        return true;
      Debug.LogError((object) ("NGDuelUnit checkPreInitialized cloneは" + (object) num + "個です"));
      return false;
    }
    Debug.LogError((object) "NGDuelUnit checkPreInitialized DuelRoot3DがNULLです");
    return false;
  }

  [DebuggerHidden]
  private IEnumerator makePlayerUnit(DuelResult result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelManager.\u003CmakePlayerUnit\u003Ec__Iterator6A1()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator makeEnemyUnit(DuelResult result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelManager.\u003CmakeEnemyUnit\u003Ec__Iterator6A2()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  private unitInfomation makeUnitInfo(
    DuelResult result,
    NGDuelUnit enemyUnit,
    Battle0181CharacterStatus cs,
    Transform initpos,
    bool isPlayer = true)
  {
    unitInfomation unitInfomation = new unitInfomation();
    BL.Unit unit = !isPlayer ? result.enemyUnit() : result.playerUnit();
    int[] numArray = !isPlayer ? result.enemyUnitBeforeAilmentEffectIDs() : result.playerUnitBeforeAilmentEffectIDs();
    if (unit == null)
    {
      Debug.LogError((object) "[NGDuelManager] at makeUnitInfo beUnit is NULL.");
      return (unitInfomation) null;
    }
    unitInfomation.bu = unit;
    if (Object.op_Equality((Object) null, (Object) cs))
    {
      Debug.LogError((object) "[NGDuelManager] at makeUnitInfo 0181CharaStatus is NULL.");
      return (unitInfomation) null;
    }
    unitInfomation.p = cs;
    if (Object.op_Equality((Object) null, (Object) enemyUnit))
    {
      Debug.LogError((object) "[NGDuelManager] at makeUnitInfo enemyUnit is NULL.");
      return (unitInfomation) null;
    }
    unitInfomation.enemy = enemyUnit;
    if (Object.op_Equality((Object) null, (Object) initpos))
      Debug.LogError((object) "[NGDuelManager] at makeUnitInfo InitPosition is NULL.");
    unitInfomation.trs = initpos;
    unitInfomation.isplayer = unit.isPlayerControl;
    unitInfomation.beforeAilmentEffectIDs = numArray;
    unitInfomation.range = result.distance == 0 ? 1 : result.distance;
    AttackStatus attackStatus = !isPlayer ? result.enemyAttackStatus() : result.playerAttackStatus();
    if (attackStatus != null && attackStatus.magicBullet != null)
      unitInfomation.mb = attackStatus.magicBullet;
    if (result.isPlayerAttack && isPlayer)
    {
      unitInfomation.support = result.attackDuelSupport;
      unitInfomation.supportHitIncr = result.attackDuelSupportHitIncr;
      unitInfomation.supportEvasionIncr = result.attackDuelSupportEvasionIncr;
      unitInfomation.supportCriticalIncr = result.attackDuelSupportCriticalIncr;
      unitInfomation.supportCriticalEvasionIncr = result.attackDuelSupportCriticalEvasionIncr;
    }
    else if (result.isPlayerAttack && !isPlayer)
    {
      unitInfomation.support = result.defenseDuelSupport;
      unitInfomation.supportHitIncr = result.defenseDuelSupportHitIncr;
      unitInfomation.supportEvasionIncr = result.defenseDuelSupportEvasionIncr;
      unitInfomation.supportCriticalIncr = result.defenseDuelSupportCriticalIncr;
      unitInfomation.supportCriticalEvasionIncr = result.defenseDuelSupportCriticalEvasionIncr;
    }
    else if (!result.isPlayerAttack && isPlayer)
    {
      unitInfomation.support = result.defenseDuelSupport;
      unitInfomation.supportHitIncr = result.defenseDuelSupportHitIncr;
      unitInfomation.supportEvasionIncr = result.defenseDuelSupportEvasionIncr;
      unitInfomation.supportCriticalIncr = result.defenseDuelSupportCriticalIncr;
      unitInfomation.supportCriticalEvasionIncr = result.defenseDuelSupportCriticalEvasionIncr;
    }
    else
    {
      unitInfomation.support = result.attackDuelSupport;
      unitInfomation.supportHitIncr = result.attackDuelSupportHitIncr;
      unitInfomation.supportEvasionIncr = result.attackDuelSupportEvasionIncr;
      unitInfomation.supportCriticalIncr = result.attackDuelSupportCriticalIncr;
      unitInfomation.supportCriticalEvasionIncr = result.attackDuelSupportCriticalEvasionIncr;
    }
    if (Object.op_Inequality((Object) null, (Object) this.mRoot3d))
      unitInfomation.root3d = this.mRoot3d;
    unitInfomation.mng = this;
    return unitInfomation;
  }

  private void Update()
  {
    if (!this.mInitialized || this.isWait)
      return;
    if (this.currSts == NGDuelManager.DuelStatus.ST_INIT && this.mInitialized)
      this.currSts = !this.mDuelResult.isFirstBoss ? (!this.mDuelResult.isBossBattle ? NGDuelManager.DuelStatus.ST_PREP_DUEL_START : NGDuelManager.DuelStatus.ST_PREP_DUEL_START_BOSS) : NGDuelManager.DuelStatus.ST_PREP_DUEL_INTRO_BOSS;
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_DUEL_START)
    {
      if (this.mDuelResult.isPlayerAttack)
      {
        if (this.mDuelResult.distance == 1 && this.useDistance)
          this.StartCoroutine(this.mCameraManager.changeCamera("startCam_02"));
        else
          this.StartCoroutine(this.mCameraManager.changeCamera("startCam_01"));
      }
      else if (this.mDuelResult.distance == 1 && this.useDistance)
        this.StartCoroutine(this.mCameraManager.changeCamera("2PstartCam_02"));
      else
        this.StartCoroutine(this.mCameraManager.changeCamera("2PstartCam_01"));
      this.currSts = !this.mDuelResult.isColosseum ? NGDuelManager.DuelStatus.ST_EXEC_DUEL_START : NGDuelManager.DuelStatus.ST_EXEC_COLOSSEUM_DUEL_START;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_DUEL_START)
    {
      if (this.mDuelStorys == null)
      {
        this.StartCoroutine(this.waitCurrentStatusEnd(NGDuelManager.DuelStatus.ST_PREP_BUFF, this.DuelCameraDispTime));
        this.currSts = NGDuelManager.DuelStatus.ST_NONE;
      }
      else if (this.mDuelStorys.Count<BL.Story>((Func<BL.Story, bool>) (x => x.type == BL.StoryType.duel_start)) > 0)
      {
        this.StartCoroutine(this.waitCurrentStatusEnd(NGDuelManager.DuelStatus.ST_PREP_DUEL_TALK, this.DuelCameraDispTime));
        this.currSts = NGDuelManager.DuelStatus.ST_NONE;
      }
      else
      {
        this.StartCoroutine(this.waitCurrentStatusEnd(NGDuelManager.DuelStatus.ST_PREP_BUFF, this.DuelCameraDispTime));
        this.currSts = NGDuelManager.DuelStatus.ST_NONE;
      }
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_COLOSSEUM_DUEL_START)
    {
      this.StartCoroutine(this.startDuelStartAnimation(NGDuelManager.DuelStatus.ST_PREP_BUFF, this.DuelCameraDispTime));
      this.currSts = NGDuelManager.DuelStatus.ST_NONE;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_DUEL_INTRO_BOSS)
    {
      this.StartCoroutine(this.mCameraManager.changeCamera("BossIntro_cam01"));
      this.mEnemyDUnit.playWinPose();
      this.wait_time = this.mBossIntroDisplayTime;
      this.currSts = NGDuelManager.DuelStatus.ST_EXEC_DUEL_INTRO_BOSS;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_DUEL_INTRO_BOSS)
    {
      this.wait_time -= Time.deltaTime;
      if (0.0 > (double) this.wait_time)
        this.currSts = NGDuelManager.DuelStatus.ST_PREP_DUEL_START_BOSS;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_DUEL_START_BOSS)
    {
      this.StartCoroutine(this.mCameraManager.changeCamera("BossBattleStartCam_01"));
      this.currSts = NGDuelManager.DuelStatus.ST_EXEC_DUEL_START_BOSS;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_DUEL_START_BOSS)
    {
      this.StartCoroutine(this.waitBossFirstCameraEnd());
      this.currSts = NGDuelManager.DuelStatus.ST_NONE;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_DUEL_TALK)
    {
      foreach (BL.Story mDuelStory in this.mDuelStorys)
      {
        if (mDuelStory.type == BL.StoryType.duel_start)
          Singleton<NGSceneManager>.GetInstance().changeScene("story009_3", true, (object) mDuelStory.scriptId);
      }
      this.isWait = true;
      this.StartCoroutine(this.waitCurrentStatusEnd(NGDuelManager.DuelStatus.ST_EXEC_DUEL_TALK, 0.1f));
      this.currSts = NGDuelManager.DuelStatus.ST_NONE;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_DUEL_TALK && Singleton<NGSceneManager>.GetInstance().isSceneInitialized)
      this.currSts = NGDuelManager.DuelStatus.ST_PREP_BUFF;
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_BUFF)
    {
      this.mPlayerDUnit.showDuelSupport();
      this.wait_time = this.mDuelSupportDisplayTime;
      this.currSts = NGDuelManager.DuelStatus.ST_EXEC_BUFF;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_BUFF)
    {
      this.wait_time -= Time.deltaTime;
      if (0.0 > (double) this.wait_time)
      {
        this.currSts = NGDuelManager.DuelStatus.ST_PREP_COMMAND;
        this.mPlayerDUnit.hideDuelSupport();
      }
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_COMMAND)
    {
      this.buildTurns();
      this.currSts = NGDuelManager.DuelStatus.ST_EXEC_COMMAND;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_COMMAND)
    {
      if (Object.op_Equality((Object) this.mPlayerDUnit, (Object) null) || Object.op_Equality((Object) this.mEnemyDUnit, (Object) null))
        return;
      float distance = Math.Abs(((Component) this.mPlayerDUnit).transform.position.x - ((Component) this.mEnemyDUnit).transform.position.x);
      this.mPlayerDUnit.mDistanceFromEnemy = distance;
      this.mEnemyDUnit.mDistanceFromEnemy = distance;
      this.mCameraManager.updateLookatPosition(distance, this.mPlayerDUnit, this.mEnemyDUnit, this.mDuelResult.turns[this.mDuelTurn - 1].isAtackker);
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_RESULT)
      this.currSts = !this.mDuelResult.isPlayerAttack || !this.mDuelResult.isDieAttack ? (this.mDuelResult.isPlayerAttack || !this.mDuelResult.isDieAttack ? (!this.mDuelResult.isPlayerAttack || !this.mDuelResult.isDieDefense ? (this.mDuelResult.isPlayerAttack || !this.mDuelResult.isDieDefense ? NGDuelManager.DuelStatus.ST_PREP_RES_DRAW : NGDuelManager.DuelStatus.ST_PREP_RES_LOSE) : NGDuelManager.DuelStatus.ST_PREP_RES_WIN) : NGDuelManager.DuelStatus.ST_PREP_RES_WIN) : NGDuelManager.DuelStatus.ST_PREP_RES_LOSE;
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_RES_LOSE)
    {
      this.mPlayerDUnit.adjustPosition(this.PlayerInitPosition);
      if (!this.mDuelResult.isBossBattle)
      {
        if (this.mDuelResult.distance > 1)
          this.StartCoroutine(this.mCameraManager.changeCamera("LoseCam_01"));
        else
          this.StartCoroutine(this.mCameraManager.changeCamera("LoseCam_r1"));
      }
      else
        this.StartCoroutine(this.mCameraManager.changeCamera("BossBattleAttackLoseCam_01"));
      this.currSts = this.mDuelStorys != null ? (this.mDuelStorys.Count<BL.Story>((Func<BL.Story, bool>) (x => x.type == BL.StoryType.duel_unit_dead)) <= 0 ? NGDuelManager.DuelStatus.ST_EXEC_RES_LOSE : NGDuelManager.DuelStatus.ST_PREP_LOSE_TALK) : NGDuelManager.DuelStatus.ST_EXEC_RES_LOSE;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_RES_LOSE)
      this.StartCoroutine(this.waitCurrentStatusEnd(NGDuelManager.DuelStatus.ST_PREP_END, this.LoseDispTime));
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_LOSE_TALK)
    {
      foreach (BL.Story mDuelStory in this.mDuelStorys)
      {
        if (mDuelStory.type == BL.StoryType.duel_unit_dead)
          Singleton<NGSceneManager>.GetInstance().changeScene("story009_3", true, (object) mDuelStory.scriptId);
      }
      this.StartCoroutine(this.waitCurrentStatusEnd(NGDuelManager.DuelStatus.ST_EXEC_DUEL_TALK, 0.1f));
      this.currSts = NGDuelManager.DuelStatus.ST_NONE;
      this.isWait = true;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_LOSE_TALK && Singleton<NGSceneManager>.GetInstance().isSceneInitialized)
      this.currSts = NGDuelManager.DuelStatus.ST_EXEC_RES_LOSE;
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_RES_WIN)
    {
      this.mPlayerDUnit.SetWinMode();
      if (!this.mDuelResult.isBossBattle)
      {
        if (this.duel_distance == 1)
          this.StartCoroutine(this.mCameraManager.changeCamera("WinCam_r1", this.mPlayerDUnit.selectTarget().transform));
        else
          this.StartCoroutine(this.mCameraManager.changeCamera("WinCam_01", this.mPlayerDUnit.selectTarget().transform));
      }
      else
        this.StartCoroutine(this.mCameraManager.changeCamera("BossBattleAttackWinCam_01"));
      NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
      if (Object.op_Inequality((Object) null, (Object) instance))
        this.endVoiceChannel = instance.playVoiceByID(this.mPlayerDUnit.mMyUnitData.unit.unitVoicePattern.file_name, 60, channel: 2);
      this.StartCoroutine(this.mPlayerDUnit.loadWinAnimator());
      this.currSts = NGDuelManager.DuelStatus.ST_EXEC_RES_WIN;
      if (this.endVoiceChannel == -1)
      {
        this.StartCoroutine(this.waitCurrentStatusEnd(NGDuelManager.DuelStatus.ST_PREP_END, this.WinDispTime));
        this.currSts = NGDuelManager.DuelStatus.ST_NONE;
      }
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_RES_WIN && !Singleton<NGSoundManager>.GetInstance().IsVoicePlaying(this.endVoiceChannel))
      this.currSts = NGDuelManager.DuelStatus.ST_PREP_END;
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_RES_DRAW)
      this.currSts = NGDuelManager.DuelStatus.ST_EXEC_RES_DRAW;
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_RES_DRAW)
    {
      this.StartCoroutine(this.waitCurrentStatusEnd(NGDuelManager.DuelStatus.ST_PREP_END, this.DrawDispTime));
      this.currSts = NGDuelManager.DuelStatus.ST_NONE;
    }
    if (this.currSts == NGDuelManager.DuelStatus.ST_PREP_END)
      this.currSts = NGDuelManager.DuelStatus.ST_EXEC_END;
    if (this.currSts == NGDuelManager.DuelStatus.ST_EXEC_END)
      this.currSts = NGDuelManager.DuelStatus.ST_END;
    if (this.currSts != NGDuelManager.DuelStatus.ST_END)
      return;
    this.FinishDuel();
    this.currSts = NGDuelManager.DuelStatus.ST_NONE;
  }

  private void FinishDuel()
  {
    this.mParentScene.backToBattle();
    this.mCameraManager.Reset();
    Object.Destroy((Object) this.mPlayerDUnit.selectTarget());
    Object.Destroy((Object) this.mEnemyDUnit.selectTarget());
    this.mPlayerDUnit = (NGDuelUnit) null;
    this.mEnemyDUnit = (NGDuelUnit) null;
    foreach (Object destroy in this.destroyList)
      Object.Destroy(destroy);
    this.destroyList.Clear();
    this.preloadGameObject.Clear();
    this.mInitialized = false;
    ((Component) this).gameObject.SetActive(false);
    this.mCameraManager.Initialize();
    Singleton<NGDuelDataManager>.GetInstance().SetActiveMap(false);
    Singleton<NGSoundManager>.GetInstance().StopSe();
  }

  public void PlayerMoveToInitPos() => this.mPlayerDUnit.adjustPosition(this.PlayerInitPosition);

  [DebuggerHidden]
  private IEnumerator waitCurrentStatusEnd(NGDuelManager.DuelStatus status, float duration = 1.6f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelManager.\u003CwaitCurrentStatusEnd\u003Ec__Iterator6A3()
    {
      duration = duration,
      status = status,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u0024\u003Estatus = status,
      \u003C\u003Ef__this = this
    };
  }

  public void addDestoryList(GameObject obj) => this.destroyList.Add(obj);

  [DebuggerHidden]
  private IEnumerator startDuelStartAnimation(NGDuelManager.DuelStatus status, float duration = 1.6f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelManager.\u003CstartDuelStartAnimation\u003Ec__Iterator6A4()
    {
      duration = duration,
      status = status,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u0024\u003Estatus = status,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator waitBossFirstCameraEnd(float duration = 2f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelManager.\u003CwaitBossFirstCameraEnd\u003Ec__Iterator6A5()
    {
      duration = duration,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createMap(BL.Stage stage)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelManager.\u003CcreateMap\u003Ec__Iterator6A6()
    {
      stage = stage,
      \u003C\u0024\u003Estage = stage,
      \u003C\u003Ef__this = this
    };
  }

  public void ResetLight()
  {
    Singleton<NGDuelDataManager>.GetInstance().ResetLight(this.directionalLight);
  }

  private void adjustPosition()
  {
    this.mPlayerDUnit.adjustPosition(this.PlayerInitPosition);
    this.mEnemyDUnit.adjustPosition(this.EnemyInitPosition);
  }

  public void ResetDuelAmbient()
  {
    if (!this.mInitialized)
      return;
    RenderSettings.ambientLight = this.duelAmbientLight;
  }

  private void buildTurns()
  {
    if (this.mDuelResult.turns == null)
      this.currSts = NGDuelManager.DuelStatus.ST_END;
    else if (((IEnumerable<BL.DuelTurn>) this.mDuelResult.turns).Count<BL.DuelTurn>() == 0)
      this.currSts = NGDuelManager.DuelStatus.ST_END;
    else if (this.mDuelTurn >= ((IEnumerable<BL.DuelTurn>) this.mDuelResult.turns).Count<BL.DuelTurn>())
    {
      this.currSts = NGDuelManager.DuelStatus.ST_END;
    }
    else
    {
      BL.DuelTurn turn1 = this.mDuelResult.turns[this.mDuelTurn];
      int unit_type = !this.mDuelResult.isPlayerAttack ? (!turn1.isAtackker ? 0 : 1) : (!turn1.isAtackker ? 1 : 0);
      bool is_renzoku = false;
      if (((IEnumerable<BL.DuelTurn>) this.mDuelResult.turns).Count<BL.DuelTurn>() > this.mDuelTurn + 1)
      {
        BL.DuelTurn turn2 = this.mDuelResult.turns[this.mDuelTurn + 1];
        if ((!this.mDuelResult.isPlayerAttack ? (!turn2.isAtackker ? 0 : 1) : (!turn2.isAtackker ? 1 : 0)) == unit_type)
          is_renzoku = true;
      }
      if (this.mDuelResult.isColosseum && turn1.attackerStatus != null && turn1.defenderStatus != null)
      {
        if (this.mDuelResult.isPlayerAttack)
          this.mParentScene.ChangeStatus(turn1.attackerStatus, turn1.defenderStatus);
        else
          this.mParentScene.ChangeStatus(turn1.defenderStatus, turn1.attackerStatus);
      }
      this.StartCoroutine(this.getNGDuelUnit(unit_type).startAttack(turn1, new System.Action(this.turnEnd), this.mDuelTurn, is_renzoku));
      ++this.mDuelTurn;
    }
  }

  public void turnEnd()
  {
    if (((IEnumerable<BL.DuelTurn>) this.mDuelResult.turns).Count<BL.DuelTurn>() > this.mDuelTurn)
      this.currSts = NGDuelManager.DuelStatus.ST_PREP_COMMAND;
    else
      this.currSts = NGDuelManager.DuelStatus.ST_PREP_RESULT;
  }

  public void skipDuel() => this.currSts = NGDuelManager.DuelStatus.ST_END;

  public void ActAttackBeginCamera()
  {
    this.mCameraManager.ActAttackBeginCamera(this.mDuelResult, this.mPlayerDUnit);
  }

  public void ActCameraToCenter() => this.mCameraManager.ActCameraToCenter();

  public void ActKoyuCamera(RuntimeAnimatorController rac)
  {
    this.mCameraManager.ActKoyuCamera(rac);
  }

  public void EnableKoyuCamera() => this.mCameraManager.EnableKoyuCamera();

  public void EndKoyuCamera() => this.mCameraManager.EndKoyuCamera();

  public void ActCameraToMe(NGDuelUnit myunit) => this.mCameraManager.ActCameraToMe(myunit);

  public void ShakeCamera() => this.mCameraManager.ShakeCamera();

  public void WarpCameraToPrincess()
  {
    this.mCameraManager.WarpCamera1stAttackPos(true, ((Component) this.mEnemyDUnit).gameObject.transform);
  }

  public void WarpCameraToEnemy()
  {
    this.mCameraManager.WarpCamera1stAttackPos(false, ((Component) this.mPlayerDUnit).gameObject.transform);
  }

  public void WarpCameraToPrincessAsRemote(Transform bullet, float delay = 2f)
  {
    this.StartCoroutine(this.mCameraManager.WarpCamera1stAttackPosRemoteEnemy(((Component) this.mEnemyDUnit).gameObject.transform, delay, bullet));
  }

  public void WarpCameraToEnemyAsRemote(Transform bullet = null, float delay = 2f)
  {
    this.StartCoroutine(this.mCameraManager.WarpCamera1stAttackPosRemoteEnemy(((Component) this.mPlayerDUnit).gameObject.transform, delay, bullet));
  }

  public void CameraChaseBullet(Transform bullet) => this.mCameraManager.LookCameraBullet(bullet);

  public void SetCameraSmoothTime(float f) => this.mCameraManager.smoothTime = f;

  public float GetCameraSmoothTime() => this.mCameraManager.smoothTime;

  public void ChangeCameraToRemotoSuiseiHalf()
  {
    this.StartCoroutine(this.mCameraManager.changeCamera("attack_long_lastattck_cam"));
  }

  public ClipEventEffectData getPreloadClipEventEffectData(string name)
  {
    return !string.IsNullOrEmpty(name) && this.preloadClipEventEffectData.ContainsKey(name) ? this.preloadClipEventEffectData[name] : (ClipEventEffectData) null;
  }

  public void setPreloadClipEventEffectData(ClipEventEffectData effectData)
  {
    if (string.IsNullOrEmpty(((Object) effectData).name) || this.preloadClipEventEffectData.ContainsKey(((Object) effectData).name))
      return;
    this.preloadClipEventEffectData.Add(((Object) effectData).name, effectData);
  }

  public GameObject getPreloadGameObject(string name, Transform parent = null)
  {
    if (string.IsNullOrEmpty(name) || !this.preloadGameObject.ContainsKey(name))
      return (GameObject) null;
    GameObject preloadGameObject = this.preloadGameObject[name].Clone(parent);
    this.destroyList.Add(preloadGameObject);
    return preloadGameObject;
  }

  public void setPreloadGameObject(GameObject prefab)
  {
    if (string.IsNullOrEmpty(((Object) prefab).name) || this.preloadGameObject.ContainsKey(((Object) prefab).name))
      return;
    this.preloadGameObject.Add(((Object) prefab).name, prefab);
  }

  [DebuggerHidden]
  private IEnumerator preloadDuelUnitObject()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGDuelManager.\u003CpreloadDuelUnitObject\u003Ec__Iterator6A7 objectCIterator6A7 = new NGDuelManager.\u003CpreloadDuelUnitObject\u003Ec__Iterator6A7();
    return (IEnumerator) objectCIterator6A7;
  }

  [DebuggerHidden]
  private IEnumerator preloadEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelManager.\u003CpreloadEffect\u003Ec__Iterator6A8()
    {
      \u003C\u003Ef__this = this
    };
  }

  private HashSet<string> analyzePreloadEffectName()
  {
    HashSet<string> stringSet = new HashSet<string>();
    foreach (BL.DuelTurn turn in this.mDuelResult.turns)
    {
      if (turn.isHit)
      {
        if (this.mDuelResult.isPlayerAttack && turn.isAtackker || !this.mDuelResult.isPlayerAttack && !turn.isAtackker)
        {
          foreach (string str in this.weaponHitEffectName(this.mPlayerDUnit))
            stringSet.Add(str);
        }
        else if (this.mDuelResult.isPlayerAttack && !turn.isAtackker || !this.mDuelResult.isPlayerAttack && turn.isAtackker)
        {
          foreach (string str in this.weaponHitEffectName(this.mEnemyDUnit))
            stringSet.Add(str);
        }
        foreach (BL.Skill skill in ((IEnumerable<BL.Skill>) turn.invokeDuelSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) turn.invokeDefenderDuelSkills))
        {
          if (skill.skill.duel_effect != null)
          {
            foreach (string preloadEffectFileName in skill.skill.duel_effect.preloadEffectFileNameList)
              stringSet.Add(preloadEffectFileName);
          }
        }
        if (turn.ailmentEffects != null)
        {
          foreach (BattleskillAilmentEffect ailmentEffect in turn.ailmentEffects)
          {
            if (!string.IsNullOrEmpty(ailmentEffect.duel_effect_name))
              stringSet.Add(ailmentEffect.duel_effect_name);
          }
        }
      }
    }
    if (this.mPlayerDUnit.beforeAilmentEffectIDs != null)
    {
      foreach (string str in ((IEnumerable<int>) this.mPlayerDUnit.beforeAilmentEffectIDs).Where<int>((Func<int, bool>) (x => MasterData.BattleskillAilmentEffect.ContainsKey(x))).Select<int, string>((Func<int, string>) (x => MasterData.BattleskillAilmentEffect[x].duel_effect_name)))
      {
        if (!string.IsNullOrEmpty(str))
          stringSet.Add(str);
      }
    }
    if (this.mEnemyDUnit.beforeAilmentEffectIDs != null)
    {
      foreach (string str in ((IEnumerable<int>) this.mEnemyDUnit.beforeAilmentEffectIDs).Where<int>((Func<int, bool>) (x => MasterData.BattleskillAilmentEffect.ContainsKey(x))).Select<int, string>((Func<int, string>) (x => MasterData.BattleskillAilmentEffect[x].duel_effect_name)))
      {
        if (!string.IsNullOrEmpty(str))
          stringSet.Add(str);
      }
    }
    return stringSet;
  }

  private List<UnitUnit> analyzePreloadCutinUnit()
  {
    List<UnitUnit> unitUnitList = new List<UnitUnit>();
    foreach (BL.DuelTurn turn in this.mDuelResult.turns)
    {
      foreach (BL.Skill skill in ((IEnumerable<BL.Skill>) turn.invokeDuelSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) turn.invokeDefenderDuelSkills))
      {
        if (skill.skill.duel_effect != null)
        {
          foreach (UnitUnit preloadCutinUnit in skill.skill.duel_effect.preloadCutinUnitList)
            unitUnitList.Add(preloadCutinUnit);
        }
      }
    }
    return unitUnitList;
  }

  private HashSet<string> analyzePreloadClipEventEffectData()
  {
    HashSet<string> stringSet = new HashSet<string>();
    foreach (BL.DuelTurn turn in this.mDuelResult.turns)
    {
      if (turn.isHit)
      {
        foreach (BL.Skill skill in ((IEnumerable<BL.Skill>) turn.invokeDuelSkills).Concat<BL.Skill>((IEnumerable<BL.Skill>) turn.invokeDefenderDuelSkills))
        {
          if (skill.skill.duel_effect != null)
          {
            foreach (string effectDataFileName in skill.skill.duel_effect.preloadClipEventEffectDataFileNameList)
              stringSet.Add(effectDataFileName);
          }
        }
      }
    }
    return stringSet;
  }

  private List<string> weaponHitEffectName(NGDuelUnit unit)
  {
    List<string> stringList = new List<string>();
    DuelElementTrailEffect elementTrailEffect = unit.elementTrailEffect;
    if (elementTrailEffect != null && !string.IsNullOrEmpty(elementTrailEffect.trail_effect_name))
      stringList.Add(elementTrailEffect.trail_effect_name);
    string hit_effect_name = string.Empty;
    switch (unit.mMyUnitData.weapon.gear.kind_GearKind)
    {
      case 1:
        hit_effect_name = this.mDuelResult.distance != 1 ? unit.GetMissileHitEffect() : "ef512_sword_locus_hit";
        break;
      case 2:
        hit_effect_name = this.mDuelResult.distance != 1 ? unit.GetMissileHitEffect() : "ef513_hatchet_locus_hit";
        break;
      case 3:
        hit_effect_name = this.mDuelResult.distance != 1 ? unit.GetMissileHitEffect() : "ef514_spear_locus_hit";
        break;
      case 4:
        hit_effect_name = unit.GetMissileHitEffect();
        break;
    }
    if (!string.IsNullOrEmpty(hit_effect_name))
    {
      DuelElementHitEffect elementHitEffect = unit.GetElementHitEffect(hit_effect_name);
      if (elementHitEffect != null && !string.IsNullOrEmpty(elementHitEffect.change_effect_name))
        stringList.Add(elementHitEffect.change_effect_name);
      else
        stringList.Add(hit_effect_name);
    }
    return stringList;
  }

  public void removePreload()
  {
  }

  public void SetActiveMap(bool active)
  {
    Singleton<NGDuelDataManager>.GetInstance().SetActiveMap(active);
  }

  private enum DuelStatus
  {
    ST_INIT,
    ST_PREP_DUEL_START,
    ST_EXEC_DUEL_START,
    ST_EXEC_COLOSSEUM_DUEL_START,
    ST_PREP_DUEL_INTRO_BOSS,
    ST_EXEC_DUEL_INTRO_BOSS,
    ST_PREP_DUEL_START_BOSS,
    ST_EXEC_DUEL_START_BOSS,
    ST_PREP_DUEL_TALK,
    ST_EXEC_DUEL_TALK,
    ST_PREP_BUFF,
    ST_EXEC_BUFF,
    ST_PREP_COMMAND,
    ST_EXEC_COMMAND,
    ST_PREP_RESULT,
    ST_PREP_RES_LOSE,
    ST_EXEC_RES_LOSE,
    ST_PREP_LOSE_TALK,
    ST_EXEC_LOSE_TALK,
    ST_PREP_RES_WIN,
    ST_EXEC_RES_WIN,
    ST_PREP_RES_DRAW,
    ST_EXEC_RES_DRAW,
    ST_PREP_END,
    ST_EXEC_END,
    ST_END,
    ST_NONE,
  }
}
