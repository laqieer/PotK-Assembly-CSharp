// Decompiled with JetBrains decompiler
// Type: NGDuelUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGDuelUnit : MonoBehaviour
{
  private const int debugIdentifyer = 1;
  private const float turnTimeout = 60f;
  private const string SWORD_BULLET_DEFAULT = "ef329_sword_bullet";
  private const string AXE_BULLET_DEFAULT = "ef325_axe_bullet";
  private const string SPEAR_BULLET_DEFAULT = "ef326_spear_bullet";
  private const string ARROW_BULLET_DEFAULT = "ef324_bow_bullet";
  protected NGDuelUnit.Status currentStatus = NGDuelUnit.Status.ST_NONE;
  private NGDuelManager mDuelManager;
  protected Battle0181CharacterStatus mPlayerUI;
  public BL.Unit mMyUnitData;
  protected BL.MagicBullet mMagicBullet;
  protected BL.DuelTurn mThisTurn;
  protected NGDuelUnit mMyUnit;
  protected NGDuelUnit mEnemyUnit;
  protected bool isRemovedSleepEffect;
  private IntimateDuelSupport mSupport;
  private int mSupportHitIncr;
  private int mSupportEvasionIncr;
  private int mSupportCriticalIncr;
  private int mSupportCriticalEvasionIncr;
  private bool mInitialized;
  protected bool mIsPlayer;
  protected bool mIsMonster;
  protected bool mIsDamageWait;
  protected bool mIsDodging;
  protected bool mFirstAttackDone;
  public float mMyReach = 1f;
  public float mDistanceFromEnemy;
  protected float mDirToEnemy = -1f;
  private float mTurnSpentTime;
  public string currentClipStatus = string.Empty;
  protected Transform mInitPos;
  protected GameObject mRoot3D;
  protected GameObject mMyModel;
  protected GameObject mGoVehicle;
  protected GameObject mShieldObject;
  protected GameObject mWeaponObject;
  protected GameObject mMadan;
  protected GameObject mEquip;
  protected GameObject mHelm;
  protected MissileWeapon mMissileWeapon;
  protected GameObject mMissileWeaponPrefab;
  protected GameObject mMissileWeaponReadyEffectPrefab;
  protected GameObject mMissileWeaponElementEffectPrefab;
  public GameObject mMadanPrefab;
  protected GameObject mEffectShadow;
  protected GameObject mEffectDuelSupport;
  protected List<GameObject> mRemoveObjects = new List<GameObject>();
  protected Animator mCharacterAnimator;
  protected Animator mVehicleAnimator;
  protected DuelCutin mDuelCI;
  protected SkinnedMeshRenderer mBodyMesh;
  public DuelTime mDuelTime;
  private bool mIsSuisei;
  protected int mSuiseiCount;
  public bool mIsLastAttack;
  private float mOrigSmoothTime;
  private NGSoundManager mSM;
  private bool mAttackVoicePlaying;
  protected GameObject mBullet;
  public bool mToNextTurn;
  private bool mNowPlayKoyu;
  private GameObject mDrainBullet;
  private Linear mLinearX;
  private Linear mLinearY;
  private bool mRemoteSuiseiCameraFlag;
  private BL.Skill mInvokeDuelSkill;
  private List<BL.Skill> mDispDuelSkills;
  private List<BL.Skill> mDefenseDuelSkills;
  public DuelMoveTypeEnum mMoveType;
  private DuelDuelConfig mConfig;
  private DuelElementTrailEffect _elementTrailEffect;
  private string critical_attack1;
  private string nomal_attack1_last;
  private string nomal_attack_last;
  private string critical_attackS_last;
  private string critical_attack_last;
  private string skill_ss5_attack4_last;
  private string skill_attack1_last;
  private string skill_attack_last;
  private string skill_attack_throw_last;
  private string skill_ss5_attack_throw4_last;
  private string skill_ss5_attack_throw5_last;
  private string critical_attack_throw_last;
  private string nomal_attack_throw_last;
  private string skill_attack;

  public int[] beforeAilmentEffectIDs { get; private set; }

  public Transform mBipTransform { get; private set; }

  public List<string> controllerPreloadEffectList
  {
    get => this.mConfig == null ? new List<string>() : this.mConfig.preloadEffectFileNameList;
  }

  public CommonElement GetElement()
  {
    CommonElement element = CommonElement.none;
    BL.Skill[] array = ((IEnumerable<BL.Skill>) this.mMyUnitData.duelSkills).Where<BL.Skill>((Func<BL.Skill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element)))).ToArray<BL.Skill>();
    if (array.Length > 0)
      element = array[0].skill.element;
    return element;
  }

  public DuelElementTrailEffect elementTrailEffect
  {
    get
    {
      if (this._elementTrailEffect == null)
        this._elementTrailEffect = ((IEnumerable<DuelElementTrailEffect>) MasterData.DuelElementTrailEffectList).FirstOrDefault<DuelElementTrailEffect>((Func<DuelElementTrailEffect, bool>) (x => x.kind.Enum == this.mMyUnitData.unit.kind.Enum && x.element == this.GetElement()));
      return this._elementTrailEffect;
    }
  }

  public DuelElementBulletEffect GetElementBulletEffect(string bullet_name)
  {
    return ((IEnumerable<DuelElementBulletEffect>) MasterData.DuelElementBulletEffectList).FirstOrDefault<DuelElementBulletEffect>((Func<DuelElementBulletEffect, bool>) (x => x.bullet_prefab_name == bullet_name && x.element == this.GetElement()));
  }

  public DuelElementHitEffect GetElementHitEffect(string hit_effect_name)
  {
    return ((IEnumerable<DuelElementHitEffect>) MasterData.DuelElementHitEffectList).FirstOrDefault<DuelElementHitEffect>((Func<DuelElementHitEffect, bool>) (x => x.original_effect_name == hit_effect_name && x.element == this.GetElement()));
  }

  public int jobId => this.mMyUnitData.job.ID;

  public NGDuelUnit Enemy => this.mEnemyUnit;

  public BL.DuelTurn thisTurn => this.mThisTurn;

  public NGDuelUnit.Status currSts => this.currentStatus;

  public bool useDistance => this.mDuelManager.useDistance;

  public void TimeReset() => this.mTurnSpentTime = 0.0f;

  public NGDuelManager manager => this.mDuelManager;

  public bool isPlayVoice => Object.op_Inequality((Object) this.mSM, (Object) null);

  [DebuggerHidden]
  public virtual IEnumerator Initialize(unitInfomation ui)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CInitialize\u003Ec__Iterator7EF()
    {
      ui = ui,
      \u003C\u0024\u003Eui = ui,
      \u003C\u003Ef__this = this
    };
  }

  public void SetAilmentEffect()
  {
    Debug.Log((object) ("SetAilmentEffect:" + (object) this.beforeAilmentEffectIDs));
    if (this.beforeAilmentEffectIDs == null)
      return;
    foreach (string name in ((IEnumerable<int>) this.beforeAilmentEffectIDs).Where<int>((Func<int, bool>) (x => MasterData.BattleskillAilmentEffect.ContainsKey(x))).Select<int, string>((Func<int, string>) (x => MasterData.BattleskillAilmentEffect[x].duel_effect_name)))
      this.mDuelManager.getPreloadGameObject(name, this.mBipTransform);
  }

  private void OnDestroy()
  {
    foreach (Object mRemoveObject in this.mRemoveObjects)
      Object.Destroy(mRemoveObject);
  }

  private void Update()
  {
    if (!this.mInitialized || this.mDuelManager.isWait || this.currentStatus == NGDuelUnit.Status.ST_DEATH)
      return;
    this.mTurnSpentTime += Time.deltaTime;
    AnimatorClipInfo[] animatorClipInfo1 = this.mCharacterAnimator.GetCurrentAnimatorClipInfo(0);
    foreach (AnimatorClipInfo animatorClipInfo2 in animatorClipInfo1)
    {
      if (Object.op_Inequality((Object) null, (Object) this.mEffectShadow))
      {
        Vector3 position = this.mBipTransform.position;
        position.y = 0.05f;
        this.mEffectShadow.transform.position = position;
        this.mEffectShadow.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0.0f, 0.0f));
      }
    }
    AnimatorStateInfo animatorStateInfo = this.mCharacterAnimator.GetCurrentAnimatorStateInfo(0);
    if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.critical_attack1))
      this.DuelUnitLog("[DUEL state] critical_attack1");
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.nomal_attack1_last))
    {
      if (!this.mIsLastAttack && ((Object) ((AnimatorClipInfo) ref animatorClipInfo1[0]).clip).name.Equals("attack2"))
        this.mIsLastAttack = true;
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.nomal_attack_last))
    {
      if (!this.mIsLastAttack)
        this.mIsLastAttack = true;
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.critical_attackS_last))
    {
      if (!this.mIsLastAttack)
      {
        this.mIsLastAttack = true;
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.critical_attack_last))
    {
      if (!this.mIsLastAttack && ((Object) ((AnimatorClipInfo) ref animatorClipInfo1[0]).clip).name.EndsWith("attackS"))
      {
        this.mIsLastAttack = true;
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.skill_ss5_attack4_last))
    {
      if (!this.mIsLastAttack && ((Object) ((AnimatorClipInfo) ref animatorClipInfo1[0]).clip).name.EndsWith("attackS"))
      {
        if ((double) this.mMyReach < 9.0)
        {
          this.mIsLastAttack = true;
        }
        else
        {
          if (this.mMyUnitData.playerUnit.equippedWeaponGearOrInitial.kind.Enum == GearKindEnum.bow)
            this.mDuelManager.ActAttackBeginCamera();
          this.StartCoroutine(this.delayLastAttackOn(0.5f));
        }
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
      else if (!this.mIsLastAttack && ((Object) ((AnimatorClipInfo) ref animatorClipInfo1[0]).clip).name.EndsWith("attack1"))
      {
        if ((double) this.mMyReach < 9.0)
        {
          this.mIsLastAttack = true;
        }
        else
        {
          if (this.mMyUnitData.playerUnit.equippedWeaponGearOrInitial.kind.Enum == GearKindEnum.bow)
            this.StartCoroutine(this.bowSuiseiLastCameraWork());
          this.mIsLastAttack = true;
        }
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.skill_attack1_last))
    {
      if (!this.mIsLastAttack && ((Object) ((AnimatorClipInfo) ref animatorClipInfo1[0]).clip).name.Equals("attack2"))
        this.mIsLastAttack = true;
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.skill_attack_last))
    {
      if (!this.mIsLastAttack)
      {
        this.mIsLastAttack = true;
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.skill_attack_throw_last))
    {
      if (!this.mIsLastAttack)
      {
        this.mIsLastAttack = true;
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.skill_ss5_attack_throw4_last))
    {
      if (!this.mIsLastAttack)
      {
        this.mIsLastAttack = true;
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.skill_ss5_attack_throw5_last))
    {
      if (!this.mIsLastAttack)
      {
        this.mIsLastAttack = true;
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.critical_attack_throw_last))
    {
      if (!this.mIsLastAttack)
      {
        this.mIsLastAttack = true;
        if (this.isPlayVoice)
          this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      }
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.nomal_attack_throw_last))
    {
      if (!this.mIsLastAttack)
        this.mIsLastAttack = true;
    }
    else if (((AnimatorStateInfo) ref animatorStateInfo).IsName(this.skill_attack) && this.isPlayVoice && !this.mAttackVoicePlaying)
    {
      this.mSM.playVoiceByID(this.mMyUnitData.unit.unitVoicePattern.file_name, 28);
      this.mAttackVoicePlaying = true;
    }
    if (this.currentStatus == NGDuelUnit.Status.ST_READY_DODGE)
    {
      float x = ((Component) this.mMyUnit).gameObject.transform.position.x;
      float dodgeDistance = this.mDuelTime.dodgeDistance;
      float e = this.backward(x, dodgeDistance);
      float dodgeTime = this.mDuelTime.dodgeTime;
      this.mLinearX = new Linear(x, e, dodgeTime);
      this.currentStatus = NGDuelUnit.Status.ST_DODGE;
    }
    if (this.currentStatus == NGDuelUnit.Status.ST_DODGE)
    {
      this.mLinearX.Update(Time.deltaTime);
      if (!this.mLinearX.isEnd)
      {
        Vector3 position = this.selectTarget().transform.position;
        position.x = this.mLinearX.value;
        this.selectTarget().transform.position = position;
      }
      else
      {
        Vector3 position = this.selectTarget().transform.position;
        position.x = this.mLinearX.value;
        this.selectTarget().transform.position = position;
        this.mIsDodging = false;
        this.mToNextTurn = true;
        this.currentStatus = NGDuelUnit.Status.ST_WAIT;
      }
    }
    if (this.mThisTurn == null)
      return;
    if (this.currentStatus == NGDuelUnit.Status.ST_READY_BS)
    {
      float x = ((Component) this.mMyUnit).gameObject.transform.position.x;
      float e = this.backward(((Component) this.Enemy).gameObject.transform.position.x, Mathf.Abs(this.mInitPos.position.x) * 2f);
      float bsDuration = this.mDuelTime.bsDuration;
      this.mLinearX = new Linear(x, e, bsDuration);
      this.mLinearY = new Linear(((Component) this.mMyUnit).gameObject.transform.position.y, ((Component) this.mInitPos).transform.position.y, bsDuration);
      this.mOrigSmoothTime = this.mDuelManager.GetCameraSmoothTime();
      this.mDuelManager.SetCameraSmoothTime(0.075f);
      this.currentStatus = NGDuelUnit.Status.ST_BACKSTEP;
    }
    if (this.currentStatus == NGDuelUnit.Status.ST_BACKSTEP)
    {
      if ((double) ((AnimatorStateInfo) ref animatorStateInfo).normalizedTime < (double) this.mDuelTime.bsDelay)
        return;
      this.mLinearX.Update(Time.deltaTime);
      this.mLinearY.Update(Time.deltaTime);
      if (!this.mLinearX.isEnd)
      {
        Vector3 position = this.selectTarget().transform.position;
        position.x = this.mLinearX.value;
        if (!this.mIsPlayer)
          position.y = this.mLinearY.value;
        this.selectTarget().transform.position = position;
      }
      else
      {
        Vector3 position = this.selectTarget().transform.position;
        position.x = this.mLinearX.value;
        position.y = ((Component) this.mInitPos).transform.position.y;
        this.selectTarget().transform.position = position;
      }
      if (this.mLinearX.isEnd)
      {
        Vector3 position = this.selectTarget().transform.position;
        position.x = this.mLinearX.value;
        position.y = ((Component) this.mInitPos).transform.position.y;
        this.selectTarget().transform.position = position;
        if (this.mInvokeDuelSkill != null)
        {
          if (this.mThisTurn.dispDrainDamage <= 0)
            this.mToNextTurn = true;
          else if (!this.mThisTurn.isHit)
            this.mToNextTurn = true;
        }
        else
          this.mToNextTurn = true;
        this.mDuelManager.SetCameraSmoothTime(this.mOrigSmoothTime);
        this.currentStatus = NGDuelUnit.Status.ST_NONE;
      }
    }
    if (this.currentStatus != NGDuelUnit.Status.ST_WIN)
      ;
    if (this.mToNextTurn && this.Enemy.mToNextTurn && !this.mNowPlayKoyu && !this.Enemy.mNowPlayKoyu && this.mThisTurn != null)
    {
      if (this.mThisTurn.isDieDefender())
      {
        if ((double) ((AnimatorStateInfo) ref animatorStateInfo).normalizedTime >= 1.0)
        {
          this.mTurnSpentTime = 0.0f;
          this.mToNextTurn = false;
          this.Enemy.mToNextTurn = false;
          this.StartCoroutine("execEndTurn");
        }
      }
      else
      {
        this.mTurnSpentTime = 0.0f;
        this.mToNextTurn = false;
        this.Enemy.mToNextTurn = false;
        this.StartCoroutine("execEndTurn");
      }
    }
    if ((double) this.mTurnSpentTime <= 60.0)
      return;
    this.mTurnSpentTime = 0.0f;
    Debug.LogWarning((object) "NGDuelUnit this turn timed out");
    if (!this.Enemy.mPlayerUI.isHpDamaged)
    {
      this.Enemy.mPlayerUI.Damaged(this.mThisTurn.damage, new int?(this.mThisTurn.defenderDrainDamage));
      this.StartCoroutine(this.Enemy.playDamage(this.mThisTurn.damage, this.mThisTurn.dispDamage, this.mThisTurn.defenderDrainDamage, this.mThisTurn.defenderDispDrainDamage, this.Enemy.mDefenseDuelSkills, 1f, this.mThisTurn.isDieDefender(), this.mThisTurn.isCritical, isHit: this.mThisTurn.isHit));
    }
    this.StartCoroutine("execEndTurn");
  }

  public void setDefenderSkills(BL.Skill[] skills) => this.resolveDuelSkills(skills);

  private void resolveDuelSkills(BL.Skill[] skills)
  {
    this.mDispDuelSkills = new List<BL.Skill>();
    this.mDefenseDuelSkills = new List<BL.Skill>();
    this.mInvokeDuelSkill = (BL.Skill) null;
    if (skills.Length == 0)
      return;
    foreach (BL.Skill skill in skills)
    {
      BattleskillGenre? genre1_1 = skill.genre1;
      if ((genre1_1.GetValueOrDefault() != BattleskillGenre.attack ? 0 : (genre1_1.HasValue ? 1 : 0)) != 0)
      {
        this.mInvokeDuelSkill = skill;
        this.mDispDuelSkills.Add(skill);
      }
      else
      {
        BattleskillGenre? genre1_2 = skill.genre1;
        if ((genre1_2.GetValueOrDefault() != BattleskillGenre.defense ? 0 : (genre1_2.HasValue ? 1 : 0)) != 0)
          this.mDefenseDuelSkills.Add(skill);
        else
          this.mDispDuelSkills.Add(skill);
      }
      if (this.mDispDuelSkills.Count != 0)
        this.mPlayerUI.skillInvoke(this.mDispDuelSkills.ToArray());
    }
  }

  [DebuggerHidden]
  public IEnumerator startAttack(BL.DuelTurn turn, System.Action cb = null, int turn_count = 0, bool is_renzoku = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CstartAttack\u003Ec__Iterator7F0()
    {
      turn = turn,
      is_renzoku = is_renzoku,
      turn_count = turn_count,
      \u003C\u0024\u003Eturn = turn,
      \u003C\u0024\u003Eis_renzoku = is_renzoku,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  private void InitTurn(bool is_renzoku)
  {
    this.mIsSuisei = false;
    this.mIsLastAttack = false;
    this.mRemoteSuiseiCameraFlag = false;
    this.mTurnSpentTime = 0.0f;
    this.mToNextTurn = false;
    this.mPlayerUI.isHpDamaged = false;
    this.mNowPlayKoyu = false;
    this.mIsDodging = false;
    this.mAttackVoicePlaying = false;
    this.mFirstAttackDone = false;
    this.mSuiseiCount = 0;
    if (Object.op_Inequality((Object) null, (Object) this.Enemy))
    {
      this.Enemy.mToNextTurn = false;
    }
    else
    {
      this.mEnemyUnit = this.mDuelManager.enemyUnit;
      if (Object.op_Equality((Object) null, (Object) this.mEnemyUnit))
        Debug.LogError((object) ("NGDuelUnit cannot get EnemyUnit(My Unit Id = " + (object) this.mMyUnitData.unitId + ")"));
    }
    if (Object.op_Inequality((Object) null, (Object) this.mDuelCI))
      ((Component) this.mDuelCI).gameObject.SetActive(false);
    if (!Object.op_Inequality((Object) null, (Object) this.mBullet))
      return;
    this.mBullet.SetActive(false);
  }

  private bool isShotMadan
  {
    get
    {
      if (this.mThisTurn == null)
        return false;
      BL.MagicBullet magicBullet = !this.mThisTurn.isAtackker ? this.manager.mDuelResult.defenseAttackStatus.magicBullet : this.manager.mDuelResult.attackAttackStatus.magicBullet;
      if (this.mThisTurn.attackStatus != null && this.mThisTurn.attackStatus.magicBullet == null)
        magicBullet = this.mThisTurn.attackStatus.magicBullet;
      return magicBullet != null;
    }
  }

  [DebuggerHidden]
  private IEnumerator execNormalAttack(int turn_count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecNormalAttack\u003Ec__Iterator7F1()
    {
      turn_count = turn_count,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execNormalRemoteAttack(int turn_count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecNormalRemoteAttack\u003Ec__Iterator7F2()
    {
      turn_count = turn_count,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execCritical(int turn_count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecCritical\u003Ec__Iterator7F3()
    {
      turn_count = turn_count,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execCriticalRemote(int turn_count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecCriticalRemote\u003Ec__Iterator7F4()
    {
      turn_count = turn_count,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator execKoyuSkill(BL.Skill ids)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecKoyuSkill\u003Ec__Iterator7F5()
    {
      ids = ids,
      \u003C\u0024\u003Eids = ids,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execSuisei(int turn_count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecSuisei\u003Ec__Iterator7F6()
    {
      turn_count = turn_count,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execSuiseiRemote(int turn_count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecSuiseiRemote\u003Ec__Iterator7F7()
    {
      turn_count = turn_count,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execSkillAttack(int turn_count, BL.Skill skill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecSkillAttack\u003Ec__Iterator7F8()
    {
      skill = skill,
      turn_count = turn_count,
      \u003C\u0024\u003Eskill = skill,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execSkillRemoteAttack(int turn_count, BL.Skill skill)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecSkillRemoteAttack\u003Ec__Iterator7F9()
    {
      skill = skill,
      turn_count = turn_count,
      \u003C\u0024\u003Eskill = skill,
      \u003C\u0024\u003Eturn_count = turn_count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execEndTurn()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecEndTurn\u003Ec__Iterator7FA()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void AtAttack1()
  {
    this.currentClipStatus = "attack1";
    this.currentStatus = NGDuelUnit.Status.ST_READY_A1;
    if (this.mFirstAttackDone)
    {
      this.attackForward(this.mDuelTime.attack1ForwardSpeed, this.mDuelTime.attack1ForwardDistance, this.mDuelTime.attack1ForwardEaseType, this.mDuelTime.attack1MoveStartTime);
    }
    else
    {
      if (this.mIsPlayer)
      {
        if ((double) this.mMyReach < 9.0)
          this.mDuelManager.WarpCameraToPrincess();
      }
      else if ((double) this.mMyReach < 9.0)
        this.mDuelManager.WarpCameraToEnemy();
      this.mFirstAttackDone = true;
    }
  }

  public void AtAttack2()
  {
    this.currentClipStatus = "attack2";
    this.currentStatus = NGDuelUnit.Status.ST_READY_A2;
    if (this.mFirstAttackDone)
    {
      this.attackForward(this.mDuelTime.attack2ForwardSpeed, this.mDuelTime.attack2ForwardDistance, this.mDuelTime.attack2ForwardEaseType, this.mDuelTime.attack2MoveStartTime);
    }
    else
    {
      if (this.mIsPlayer)
      {
        if ((double) this.mMyReach < 9.0)
          this.mDuelManager.WarpCameraToPrincess();
      }
      else if ((double) this.mMyReach < 9.0)
        this.mDuelManager.WarpCameraToEnemy();
      this.mFirstAttackDone = true;
    }
    if ((double) this.mMyReach >= 9.0)
      return;
    this.StartCoroutine(this.attackSubEffect());
  }

  public void AtAttackS()
  {
    this.currentClipStatus = "attackS";
    this.currentStatus = NGDuelUnit.Status.ST_READY_AS;
    if (this.mFirstAttackDone)
    {
      this.attackForward(this.mDuelTime.attackSForwardSpeed, this.mDuelTime.attackSForwardDistance, this.mDuelTime.attackSForwardEaseType, this.mDuelTime.attackSMoveStartTime);
    }
    else
    {
      if (this.mIsPlayer)
      {
        if ((double) this.mMyReach < 9.0)
          this.mDuelManager.WarpCameraToPrincess();
      }
      else if ((double) this.mMyReach < 9.0)
        this.mDuelManager.WarpCameraToEnemy();
      this.mFirstAttackDone = true;
    }
    if ((double) this.mMyReach >= 9.0)
      return;
    this.StartCoroutine(this.attackSubEffect());
  }

  [DebuggerHidden]
  private IEnumerator delayLastAttackOn(float time)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CdelayLastAttackOn\u003Ec__Iterator7FB()
    {
      time = time,
      \u003C\u0024\u003Etime = time,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator execAttackSubEffect(float attackTimeLength, float attackDelay)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CexecAttackSubEffect\u003Ec__Iterator7FC()
    {
      attackDelay = attackDelay,
      attackTimeLength = attackTimeLength,
      \u003C\u0024\u003EattackDelay = attackDelay,
      \u003C\u0024\u003EattackTimeLength = attackTimeLength,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator shootReadyEffect(float wait = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CshootReadyEffect\u003Ec__Iterator7FD()
    {
      wait = wait,
      \u003C\u0024\u003Ewait = wait,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator attackSubEffect(float wait = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CattackSubEffect\u003Ec__Iterator7FE()
    {
      wait = wait,
      \u003C\u0024\u003Ewait = wait,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator missileWeaponAttackReadyEffect(float wait)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CmissileWeaponAttackReadyEffect\u003Ec__Iterator7FF()
    {
      wait = wait,
      \u003C\u0024\u003Ewait = wait,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator missileWeaponAttackSubEffect(float wait)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CmissileWeaponAttackSubEffect\u003Ec__Iterator800()
    {
      wait = wait,
      \u003C\u0024\u003Ewait = wait,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator madanWeaponAttackSubEffect(float wait)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CmadanWeaponAttackSubEffect\u003Ec__Iterator801()
    {
      wait = wait,
      \u003C\u0024\u003Ewait = wait,
      \u003C\u003Ef__this = this
    };
  }

  public string GetMissileHitEffect()
  {
    return Object.op_Inequality((Object) this.mMissileWeapon, (Object) null) ? this.mMissileWeapon.damageEffect : string.Empty;
  }

  [DebuggerHidden]
  protected IEnumerator arrowAttackSubEffect(float wait)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CarrowAttackSubEffect\u003Ec__Iterator802()
    {
      wait = wait,
      \u003C\u0024\u003Ewait = wait,
      \u003C\u003Ef__this = this
    };
  }

  private void attackForward(float speed, float distance, string easeType, float delay)
  {
    if ((double) distance == 0.0 || (double) this.mMyReach >= 9.0)
      return;
    Hashtable args = new Hashtable();
    GameObject target = this.selectTarget();
    float num = target.transform.position.x + distance * this.mDirToEnemy;
    args.Add((object) "x", (object) num);
    args.Add((object) nameof (speed), (object) speed);
    args.Add((object) nameof (delay), (object) delay);
    args.Add((object) "easetype", (object) easeType);
    iTween.MoveTo(target, args);
  }

  protected float moveToAttack(GameObject target)
  {
    switch (this.mMoveType)
    {
      case DuelMoveTypeEnum.ground:
        return this.groundToAttack(target);
      case DuelMoveTypeEnum.fly:
        return this.flyToAttack(target);
      case DuelMoveTypeEnum.giant:
        return this.giantToAttack(target);
      default:
        return this.groundToAttack(target);
    }
  }

  protected float groundToAttack(GameObject target)
  {
    float num1 = 1f;
    Hashtable args = new Hashtable();
    float num2 = this.backward(((Component) this.Enemy).gameObject.transform.position.x, num1 + this.mMyReach);
    args.Add((object) "x", (object) num2);
    float num3 = (Mathf.Abs(((Component) this.Enemy).gameObject.transform.position.x - ((Component) this).gameObject.transform.position.x) - this.mMyReach) / this.mDuelTime.runSpeed;
    args.Add((object) "time", (object) num3);
    args.Add((object) "delay", (object) 0.1f);
    args.Add((object) "easetype", (object) this.mDuelTime.runEaseType);
    this.DuelUnitLog(string.Format("DuelUnit run ready {0} to {1}", (object) target.transform.position.x, (object) num2));
    if ((double) this.mMyReach < 9.0)
    {
      iTween.MoveTo(target, args);
      this.setTrigToAnimator("to_run");
    }
    return num3 - this.mDuelTime.attackBeginOffsetTime;
  }

  private void endVehicleCriticalMove() => this.currentStatus = NGDuelUnit.Status.ST_NONE;

  private Transform[] createRunPath(string path)
  {
    GameObject gameObject1 = GameObject.Find(path);
    if (Object.op_Equality((Object) null, (Object) gameObject1))
      return new Transform[0];
    List<GameObject> source = new List<GameObject>();
    foreach (Transform child in gameObject1.transform.GetChildren())
      source.Add(((Component) child).gameObject);
    List<Transform> transformList = new List<Transform>();
    foreach (GameObject gameObject2 in (IEnumerable<GameObject>) source.OrderBy<GameObject, string>((Func<GameObject, string>) (x => ((Object) x).name)))
    {
      if (gameObject2.activeInHierarchy)
        transformList.Add(gameObject2.transform);
    }
    return transformList.ToArray();
  }

  protected float flyToAttack(GameObject target)
  {
    Hashtable args = new Hashtable();
    float num = (Mathf.Abs(((Component) this.Enemy).gameObject.transform.position.x - target.transform.position.x) - this.mMyReach) / this.mDuelTime.runSpeed;
    args.Add((object) "time", (object) num);
    args.Add((object) "delay", (object) 0.1f);
    args.Add((object) "path", (object) this.createFlyPath());
    args.Add((object) "easetype", (object) this.mDuelTime.runEaseType);
    if ((double) this.mMyReach < 9.0)
    {
      iTween.MoveTo(target, args);
      this.setTrigToAnimator("to_run");
    }
    return num - this.mDuelTime.attackBeginOffsetTime;
  }

  protected Transform[] createFlyPath()
  {
    Transform[] flyPath = new Transform[3];
    GameObject gameObject = GameObject.Find("path_fly_attack_mine");
    if (!this.mIsPlayer)
      gameObject = GameObject.Find("path_fly_attack_enemy");
    gameObject.transform.position = new Vector3(this.Enemy.selectTarget().transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    flyPath[0] = gameObject.transform.GetChildInFind("path_1");
    flyPath[1] = gameObject.transform.GetChildInFind("path_2");
    flyPath[2] = gameObject.transform.GetChildInFind("path_3");
    return flyPath;
  }

  protected float giantToAttack(GameObject target)
  {
    Hashtable args = new Hashtable();
    float num = (Mathf.Abs(((Component) this.Enemy).gameObject.transform.position.x - target.transform.position.x) - this.mMyReach) / this.mDuelTime.runSpeed;
    args.Add((object) "time", (object) num);
    args.Add((object) "delay", (object) 0.1f);
    args.Add((object) "path", (object) this.createGiantPath());
    args.Add((object) "easetype", (object) this.mDuelTime.runEaseType);
    if ((double) this.mMyReach < 9.0)
    {
      iTween.MoveTo(target, args);
      this.setTrigToAnimator("to_run");
    }
    return num - this.mDuelTime.attackBeginOffsetTime;
  }

  protected Transform[] createGiantPath()
  {
    Transform[] giantPath = new Transform[3];
    GameObject gameObject = GameObject.Find("path_large_attack_enemy");
    if (!this.mIsPlayer)
      gameObject = GameObject.Find("path_large_attack_enemy");
    gameObject.transform.position = new Vector3(this.Enemy.selectTarget().transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    giantPath[0] = gameObject.transform.GetChildInFind("path_1");
    giantPath[1] = gameObject.transform.GetChildInFind("path_2");
    giantPath[2] = gameObject.transform.GetChildInFind("path_3");
    return giantPath;
  }

  public void damaged(bool force_lastattack = false)
  {
    if (force_lastattack)
      this.Enemy.mIsLastAttack = true;
    int damage = this.mEnemyUnit.mThisTurn.damage;
    int dispDamage = this.mEnemyUnit.mThisTurn.dispDamage;
    int defenderDrainDamage = this.mEnemyUnit.mThisTurn.defenderDrainDamage;
    int defenderDispDrainDamage = this.mEnemyUnit.mThisTurn.defenderDispDrainDamage;
    float knockBackDistance = this.Enemy.mDuelTime.attack1ForwardKnockBack;
    if ((double) this.Enemy.mMyReach >= 9.0)
      knockBackDistance = 0.0f;
    else if (this.Enemy.currentClipStatus == "attack2")
      knockBackDistance = this.Enemy.mDuelTime.attack2ForwardKnockBack;
    else if (this.Enemy.currentClipStatus == "attackS")
      knockBackDistance = this.Enemy.mDuelTime.attackSForwardKnockBack;
    bool is_die = !this.mEnemyUnit.thisTurn.isAtackker ? this.mEnemyUnit.thisTurn.isDieAttacker() : this.mEnemyUnit.thisTurn.isDieDefender();
    if (this.mEnemyUnit.mInvokeDuelSkill == null)
      this.StartCoroutine(this.playDamage(damage, dispDamage, defenderDrainDamage, defenderDispDrainDamage, this.mDefenseDuelSkills, this.mEnemyUnit.thisTurn.attackStatus.elementAttackRate, is_die, this.mEnemyUnit.mThisTurn.isCritical, knockBackDistance: knockBackDistance, isHit: this.mEnemyUnit.mThisTurn.isHit));
    else if (!this.mEnemyUnit.mIsSuisei)
    {
      this.StartCoroutine(this.playDamage(damage, dispDamage, defenderDrainDamage, defenderDispDrainDamage, this.mDefenseDuelSkills, this.mEnemyUnit.thisTurn.attackStatus.elementAttackRate, is_die, this.mEnemyUnit.mThisTurn.isCritical, knockBackDistance: knockBackDistance, isHit: this.mEnemyUnit.mThisTurn.isHit));
    }
    else
    {
      if (this.mEnemyUnit.mSuiseiCount >= this.mEnemyUnit.mThisTurn.suiseiResults.Count)
        return;
      BL.SuiseiResult suiseiResult = this.mEnemyUnit.mThisTurn.suiseiResults[this.mEnemyUnit.mSuiseiCount];
      ++this.mEnemyUnit.mSuiseiCount;
      this.Enemy.mIsLastAttack = this.mEnemyUnit.mThisTurn.suiseiResults.Count == this.mEnemyUnit.mSuiseiCount;
      this.StartCoroutine(this.playDamage(suiseiResult.damage, suiseiResult.dispDamage, suiseiResult.defenderDrainDamage, suiseiResult.defenderDispDrainDamage, new List<BL.Skill>((IEnumerable<BL.Skill>) suiseiResult.invokeDefenderDuelSkills), this.mEnemyUnit.thisTurn.attackStatus.elementAttackRate, is_die, suiseiResult.isCritical, knockBackDistance: knockBackDistance, isHit: suiseiResult.isHit, is_random: true));
    }
  }

  [DebuggerHidden]
  private IEnumerator playDamage(
    int damage,
    int dispDamage,
    int heal,
    int dispHeal,
    List<BL.Skill> defenderSkills,
    float elementAttackRate,
    bool is_die,
    bool is_critical = false,
    float delay = 0.0f,
    float knockBackDistance = 0.0f,
    bool isHit = false,
    bool isDamageDisp = true,
    bool is_random = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CplayDamage\u003Ec__Iterator803()
    {
      delay = delay,
      damage = damage,
      is_random = is_random,
      isHit = isHit,
      isDamageDisp = isDamageDisp,
      defenderSkills = defenderSkills,
      dispDamage = dispDamage,
      elementAttackRate = elementAttackRate,
      heal = heal,
      dispHeal = dispHeal,
      is_critical = is_critical,
      knockBackDistance = knockBackDistance,
      is_die = is_die,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Edamage = damage,
      \u003C\u0024\u003Eis_random = is_random,
      \u003C\u0024\u003EisHit = isHit,
      \u003C\u0024\u003EisDamageDisp = isDamageDisp,
      \u003C\u0024\u003EdefenderSkills = defenderSkills,
      \u003C\u0024\u003EdispDamage = dispDamage,
      \u003C\u0024\u003EelementAttackRate = elementAttackRate,
      \u003C\u0024\u003Eheal = heal,
      \u003C\u0024\u003EdispHeal = dispHeal,
      \u003C\u0024\u003Eis_critical = is_critical,
      \u003C\u0024\u003EknockBackDistance = knockBackDistance,
      \u003C\u0024\u003Eis_die = is_die,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator damageKnockBack(float distance = 0.5f, float speed = 5f, string easeType = "EaseInQuad", float delay = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CdamageKnockBack\u003Ec__Iterator804()
    {
      delay = delay,
      distance = distance,
      speed = speed,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Edistance = distance,
      \u003C\u0024\u003Espeed = speed,
      \u003C\u003Ef__this = this
    };
  }

  private void playGuardMotion(
    int damage,
    int dispDamage,
    bool isDamageDisp,
    Vector3 additional_pos,
    float elementAttackRate,
    int heal,
    int dispHeal)
  {
    this.setTrigToAnimator("to_guard");
    this.currentStatus = NGDuelUnit.Status.ST_GURAD;
    if ((double) this.Enemy.mDuelTime.attack1ForwardKnockBack != 0.0)
      this.StartCoroutine(this.damageKnockBack(this.Enemy.mDuelTime.attack1ForwardKnockBack, 2f, "easeOutQuad", 0.2f));
    if (isDamageDisp)
    {
      this.showDamageEffect(damage, dispDamage, additional_pos, elementAttackRate, heal, dispHeal);
      Debug.Log((object) "[NGDuelUnit] playGuardMotion last attack.");
    }
    else
      Debug.Log((object) "[NGDuelUnit] playGuardMotion but not last attack.");
    if (Object.op_Inequality((Object) null, (Object) this.mShieldObject))
    {
      this.mShieldObject.SetActive(true);
      this.StartCoroutine(this.shieldOff());
    }
    this.DuelUnitLog("action changes to gurad ");
  }

  [DebuggerHidden]
  private IEnumerator playDodgeMotion()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CplayDodgeMotion\u003Ec__Iterator805()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator waitTillDodgeEnd()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CwaitTillDodgeEnd\u003Ec__Iterator806()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void setDuelShadow()
  {
    if (Object.op_Equality((Object) this.manager.mShadow, (Object) null))
      return;
    Transform parent = this.mBipTransform;
    if (Object.op_Equality((Object) null, (Object) parent))
      parent = ((Component) this).gameObject.transform;
    this.mEffectShadow = this.manager.mShadow.Clone(parent);
    this.mEffectShadow.transform.localScale = new Vector3(this.mMyUnitData.unit.duel_shadow_scale_x, 1f, this.mMyUnitData.unit.duel_shadow_scale_z);
  }

  private void setDuelSupport()
  {
    if (Object.op_Equality((Object) this.manager.mDuelSupport, (Object) null))
      return;
    this.mEffectDuelSupport = this.manager.mDuelSupport.Clone(((Component) this).gameObject.transform);
    this.manager.addDestoryList(this.mEffectDuelSupport);
    if (!Object.op_Equality((Object) null, (Object) this.mEffectDuelSupport))
      return;
    Debug.LogError((object) "[NGDuelUnit] loadDuelSupport cannot load DuelSupport");
  }

  public void hideDuelSupport()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.mEffectDuelSupport))
      return;
    this.mEffectDuelSupport.SetActive(false);
  }

  public void showDuelSupport()
  {
    if (this.mIsDamageWait)
    {
      this.setTrigToAnimator("to_wait");
      this.mIsDamageWait = false;
    }
    this.Enemy.enemyCancelDamagewait();
    if (Object.op_Equality((Object) null, (Object) this.mEffectDuelSupport))
    {
      Debug.LogError((object) "[NGDuelUnit] showDuelSupport efDuelSupport is null");
    }
    else
    {
      DuelSupport component = this.mEffectDuelSupport.GetComponent<DuelSupport>();
      if (!Object.op_Inequality((Object) null, (Object) component) || this.mSupport == null)
        return;
      if (!this.mIsPlayer)
        this.mEffectDuelSupport.transform.localScale = new Vector3(2f, 2f, 1f);
      component.setNumbers(this.mSupport.hit + this.mSupportHitIncr, this.mSupport.evasion + this.mSupportEvasionIncr, this.mSupport.critical + this.mSupportCriticalIncr, this.mSupport.critical_evasion + this.mSupportCriticalEvasionIncr);
    }
  }

  [DebuggerHidden]
  private IEnumerator loadCutinPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadCutinPrefab\u003Ec__Iterator807()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void playSkillCutin()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.mDuelCI))
      return;
    ((Component) this.mDuelCI).gameObject.SetActive(true);
    this.mDuelCI.PlaySkillCutin();
  }

  public void playSkillCutin(int topUnitId, int centerUnitId)
  {
    if (!Object.op_Inequality((Object) null, (Object) this.mDuelCI))
      return;
    this.SetTexture(topUnitId, DuelCutin.CUTINPOS.TOP);
    this.SetTexture(centerUnitId, DuelCutin.CUTINPOS.CENTER);
    ((Component) this.mDuelCI).gameObject.SetActive(true);
    this.mDuelCI.PlaySkillCutin(DuelCutin.PlayMode.SECOND_PERSON);
  }

  public void playSkillCutin(int topUnitId, int centerUnitId, int bottomUnitId)
  {
    if (!Object.op_Inequality((Object) null, (Object) this.mDuelCI))
      return;
    this.SetTexture(topUnitId, DuelCutin.CUTINPOS.TOP);
    this.SetTexture(centerUnitId, DuelCutin.CUTINPOS.CENTER);
    this.SetTexture(bottomUnitId, DuelCutin.CUTINPOS.BOTTOM);
    ((Component) this.mDuelCI).gameObject.SetActive(true);
    this.mDuelCI.PlaySkillCutin(DuelCutin.PlayMode.THIRD_PERSON);
  }

  private void SetTexture(int unitId, DuelCutin.CUTINPOS pos)
  {
    Texture tex;
    if (this.manager.duelCutin.TryGetValue(unitId, out tex))
    {
      this.mDuelCI.SetCutinTexture(tex, pos);
    }
    else
    {
      Debug.LogWarning((object) ("CutinTexture的获取失败　UnitID:" + (object) unitId));
      this.StartCoroutine(this.mDuelCI.LoadAndSetTexture(unitId, pos));
    }
  }

  public void playCriticalCutin()
  {
    ((Component) this.mDuelCI).gameObject.SetActive(true);
    this.mDuelCI.PlayCriticalCutin();
  }

  public void adjustInitPosition() => this.adjustPosition(this.mInitPos);

  public void adjustPosition(Transform pos)
  {
    this.selectTarget().transform.position = pos.position;
    this.selectTarget().transform.rotation = pos.rotation;
  }

  private void adjustInitPos()
  {
    if (Object.op_Equality((Object) null, (Object) this.mInitPos))
    {
      Debug.LogError((object) "[NGDuelUnit] at adjustInitPos Init Position is NULL.");
    }
    else
    {
      float x = ((Component) this.mInitPos).transform.position.x;
      float num = 1f;
      if ((double) x < 0.0)
        num = -1f;
      ((Component) this.mInitPos).transform.position = new Vector3((Mathf.Abs(x) + this.mDuelTime.characterInitOffset) * num, ((Component) this.mInitPos).transform.position.y, ((Component) this.mInitPos).transform.position.z);
      this.adjustPosition(this.mInitPos);
    }
  }

  [DebuggerHidden]
  private IEnumerator bowSuiseiLastCameraWork()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CbowSuiseiLastCameraWork\u003Ec__Iterator808()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator loadArmor(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadArmor\u003Ec__Iterator809()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  private void equipArmor()
  {
    if (Object.op_Equality((Object) this.mEquip, (Object) null))
      return;
    this.mEquip.transform.position = Vector3.zero;
    this.mEquip.Clone(((Component) this).gameObject.transform.GetChildInFind("equippoint_a"));
  }

  [DebuggerHidden]
  protected IEnumerator loadHelm(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadHelm\u003Ec__Iterator80A()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  private void equipHelm()
  {
    if (Object.op_Equality((Object) this.mHelm, (Object) null))
      return;
    this.mHelm.transform.position = Vector3.zero;
    this.mHelm.Clone(((Component) this).gameObject.transform.GetChildInFind("equippoint_b"));
  }

  [DebuggerHidden]
  private IEnumerator shieldOff(float duration = 2f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CshieldOff\u003Ec__Iterator80B()
    {
      duration = duration,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator loadWinAnimator()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadWinAnimator\u003Ec__Iterator80C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ResetTriggers()
  {
    this.mCharacterAnimator.ResetTrigger("to_run");
    if (Object.op_Inequality((Object) null, (Object) this.mVehicleAnimator))
      this.mVehicleAnimator.ResetTrigger("to_run");
    this.mCharacterAnimator.ResetTrigger("to_wait");
    if (!Object.op_Inequality((Object) null, (Object) this.mVehicleAnimator))
      return;
    this.mVehicleAnimator.ResetTrigger("to_wait");
  }

  [DebuggerHidden]
  private IEnumerator loadSkillEffect(string effectName)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadSkillEffect\u003Ec__Iterator80D()
    {
      effectName = effectName,
      \u003C\u0024\u003EeffectName = effectName,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator defenceMoveToOrigPos()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CdefenceMoveToOrigPos\u003Ec__Iterator80E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void completeMoveToOrigPos() => this.mToNextTurn = true;

  [DebuggerHidden]
  private IEnumerator ChangeCameraCenterDelay(float delay = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CChangeCameraCenterDelay\u003Ec__Iterator80F()
    {
      delay = delay,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u003Ef__this = this
    };
  }

  private void WarpCameraToRemotePos(bool isDamageSide = true)
  {
    if (isDamageSide)
    {
      if (this.mMyUnitData.playerUnit.is_enemy)
        this.mDuelManager.WarpCameraToEnemyAsRemote(((Component) this).gameObject.transform, 0.0f);
      else
        this.mDuelManager.WarpCameraToPrincessAsRemote(((Component) this).gameObject.transform, 0.0f);
    }
    else if (!this.mMyUnitData.playerUnit.is_enemy)
      this.mDuelManager.WarpCameraToEnemyAsRemote(((Component) this.Enemy).gameObject.transform, 0.0f);
    else
      this.mDuelManager.WarpCameraToPrincessAsRemote(((Component) this.Enemy).gameObject.transform, 0.0f);
    this.StartCoroutine(this.ChangeCameraCenterDelay(1f));
  }

  private void dispDamageEffect(int damage, int dispDamage, Vector3 additional_pos)
  {
    if (Object.op_Equality((Object) this.manager.mDamagePrefab, (Object) null))
      return;
    GameObject gameObject = this.manager.mDamagePrefab.Clone(this.mRoot3D.transform);
    gameObject.transform.localPosition = this.mMyModel.transform.position;
    this.mRemoveObjects.Add(gameObject);
    DamageNumber component = gameObject.GetComponent<DamageNumber>();
    component.setDamage(dispDamage);
    Transform transform = this.mBipTransform;
    if (Object.op_Equality((Object) null, (Object) transform))
      transform = ((Component) this).gameObject.transform;
    Vector3 vector3 = Vector3.op_Addition(transform.position, additional_pos);
    ((Component) component).transform.position = new Vector3(vector3.x, vector3.y + 1.5f, vector3.z);
  }

  private void dispDamageEffectBiAttack(int damage, int dispDamage)
  {
    if (Object.op_Equality((Object) this.manager.mDamagePrefab, (Object) null))
      return;
    GameObject gameObject = this.manager.mDamagePrefab.Clone(this.mRoot3D.transform);
    gameObject.transform.localPosition = this.mMyModel.transform.position;
    this.mRemoveObjects.Add(gameObject);
    DamageNumber component = gameObject.GetComponent<DamageNumber>();
    component.setDamage(dispDamage);
    Transform transform = this.mBipTransform;
    if (Object.op_Equality((Object) null, (Object) transform))
      transform = ((Component) this).gameObject.transform;
    Vector3 position = transform.position;
    ((Component) component).transform.position = new Vector3(position.x, position.y + 1.5f, position.z);
  }

  private void showDamageEffect(
    int damage,
    int dispDamage,
    Vector3 additional_pos,
    float elementAttackRate,
    int heal,
    int dispHeal)
  {
    this.mPlayerUI.Damaged(damage, new int?(heal));
    this.dispDamageEffect(damage, dispDamage, additional_pos);
    this.StartCoroutine(this.showSelfHealNumber(dispHeal, additional_pos));
    if ((double) elementAttackRate > 1.0)
      this.StartCoroutine(this.dispWeakEffect(additional_pos));
    if ((double) elementAttackRate >= 1.0)
      return;
    this.StartCoroutine(this.dispResistEffect(additional_pos));
  }

  [DebuggerHidden]
  private IEnumerator dispWeakEffect(Vector3 additional_pos)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CdispWeakEffect\u003Ec__Iterator810()
    {
      additional_pos = additional_pos,
      \u003C\u0024\u003Eadditional_pos = additional_pos,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator dispResistEffect(Vector3 additional_pos)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CdispResistEffect\u003Ec__Iterator811()
    {
      additional_pos = additional_pos,
      \u003C\u0024\u003Eadditional_pos = additional_pos,
      \u003C\u003Ef__this = this
    };
  }

  protected void setTrigToAnimator(string trigname)
  {
    if (Object.op_Inequality((Object) this.mCharacterAnimator, (Object) null))
      this.mCharacterAnimator.SetTrigger(trigname);
    if (!Object.op_Inequality((Object) this.mVehicleAnimator, (Object) null))
      return;
    this.mVehicleAnimator.SetTrigger(trigname);
  }

  private string getUnitVehicleWeaponName()
  {
    string vehicleWeaponName = "sword";
    if (this.mMyUnitData.unit.kind_GearKind == 2)
      vehicleWeaponName = "ax";
    else if (this.mMyUnitData.unit.kind_GearKind == 3)
      vehicleWeaponName = "spear";
    return vehicleWeaponName;
  }

  [DebuggerHidden]
  private IEnumerator createVehicle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CcreateVehicle\u003Ec__Iterator812()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createEquip()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CcreateEquip\u003Ec__Iterator813()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createWeapon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CcreateWeapon\u003Ec__Iterator814()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createShield()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CcreateShield\u003Ec__Iterator815()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void DuelUnitLog(string log)
  {
    Debug.Log((object) string.Format("[DuelUnit] {0}", (object) log));
  }

  private float backward(float current, float distance)
  {
    return this.mIsPlayer ? current + distance : current - distance;
  }

  public GameObject selectTarget()
  {
    GameObject gameObject = ((Component) this).gameObject;
    if (Object.op_Inequality((Object) this.mGoVehicle, (Object) null))
      gameObject = this.mGoVehicle;
    return gameObject;
  }

  public void enemyCancelDamagewait()
  {
    if (!this.mIsDamageWait)
      return;
    this.setTrigToAnimator("to_wait");
    this.mIsDamageWait = false;
  }

  public bool isThisTurnHit()
  {
    if (!this.mThisTurn.isHit)
      return false;
    return this.mThisTurn.damage != 0 || true;
  }

  public int damageOfThisTurn() => this.mThisTurn.damage;

  public void playWinPose() => this.setTrigToAnimator("to_win");

  public void playRunPose()
  {
    double attack = (double) this.moveToAttack(this.selectTarget());
  }

  public void playAttackSWait() => this.setTrigToAnimator("to_attackswait");

  [DebuggerHidden]
  private IEnumerator playCriticalEffect(Vector3 additional_pos)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CplayCriticalEffect\u003Ec__Iterator816()
    {
      additional_pos = additional_pos,
      \u003C\u0024\u003Eadditional_pos = additional_pos,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator playCriticalFlash()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CplayCriticalFlash\u003Ec__Iterator817()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void playCriticalFlash_CallStartCoroutine()
  {
    this.StartCoroutine(this.playCriticalFlash());
  }

  [DebuggerHidden]
  private IEnumerator playMissEffect(Vector3 additional_pos)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CplayMissEffect\u003Ec__Iterator818()
    {
      additional_pos = additional_pos,
      \u003C\u0024\u003Eadditional_pos = additional_pos,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator playSikkokuHeal()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CplaySikkokuHeal\u003Ec__Iterator819()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void onDrainFlyEnd()
  {
    this.mDrainBullet.SetActive(false);
    this.StartCoroutine(this.healByMadan(2f));
  }

  [DebuggerHidden]
  public IEnumerator healByMadan(float scale = 1f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003ChealByMadan\u003Ec__Iterator81A()
    {
      scale = scale,
      \u003C\u0024\u003Escale = scale,
      \u003C\u003Ef__this = this
    };
  }

  public void showHealNumber_CallStartCoroutine(float scale = 1f)
  {
    this.StartCoroutine(this.showHealNumber(scale));
  }

  [DebuggerHidden]
  public IEnumerator showHealNumber(float scale = 1f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CshowHealNumber\u003Ec__Iterator81B()
    {
      scale = scale,
      \u003C\u0024\u003Escale = scale,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator showSelfHealNumber(int dispHealNum, Vector3 additional_pos)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CshowSelfHealNumber\u003Ec__Iterator81C()
    {
      dispHealNum = dispHealNum,
      additional_pos = additional_pos,
      \u003C\u0024\u003EdispHealNum = dispHealNum,
      \u003C\u0024\u003Eadditional_pos = additional_pos,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator loadMissileWeaponPrefab(int range)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadMissileWeaponPrefab\u003Ec__Iterator81D()
    {
      range = range,
      \u003C\u0024\u003Erange = range,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator loadMissileWeaponPrefab(string missileName)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadMissileWeaponPrefab\u003Ec__Iterator81E()
    {
      missileName = missileName,
      \u003C\u0024\u003EmissileName = missileName,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator loadmMissileWeaponReadyEffectPrefab(string readyEffectPrefabName)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadmMissileWeaponReadyEffectPrefab\u003Ec__Iterator81F()
    {
      readyEffectPrefabName = readyEffectPrefabName,
      \u003C\u0024\u003EreadyEffectPrefabName = readyEffectPrefabName,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator loadmMissileWeaponElementEffectPrefab(string elementEffectPrefabName)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadmMissileWeaponElementEffectPrefab\u003Ec__Iterator820()
    {
      elementEffectPrefabName = elementEffectPrefabName,
      \u003C\u0024\u003EelementEffectPrefabName = elementEffectPrefabName,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator loadMadanPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadMadanPrefab\u003Ec__Iterator821()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadDefaultAnimatorController(BL.Unit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGDuelUnit.\u003CloadDefaultAnimatorController\u003Ec__Iterator822()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public void warpToKoyuPosAsEnemy()
  {
    if (this.Enemy.mInvokeDuelSkill == null || !this.Enemy.mInvokeDuelSkill.skill.haveKoyuDuelEffect)
      return;
    Vector3 getEnemyPosition = this.Enemy.mInvokeDuelSkill.skill.duel_effect.getEnemyPosition;
    this.selectTarget().transform.position = getEnemyPosition;
    if (!this.mIsPlayer)
      return;
    this.selectTarget().transform.localRotation = Quaternion.Euler(0.0f, 90f, 0.0f);
  }

  public void shootSomethingReady() => this.StartCoroutine(this.shootReadyEffect());

  public void shootSomething() => this.StartCoroutine(this.attackSubEffect());

  public void shootSomethingLastAttack()
  {
    this.mIsLastAttack = true;
    this.StartCoroutine(this.attackSubEffect());
  }

  public void playBackstepFromClip() => this.currentStatus = NGDuelUnit.Status.ST_READY_BS;

  public bool isThisTurnCritical() => this.mThisTurn.isCritical;

  public void SetWinMode() => this.currentStatus = NGDuelUnit.Status.ST_WIN;

  public void SetDodgeMode() => this.currentStatus = NGDuelUnit.Status.ST_READY_DODGE;

  public void SetActiveEquipeWeapon(bool active)
  {
    if (!Object.op_Inequality((Object) this.mWeaponObject, (Object) null) || this.mWeaponObject.activeSelf == active)
      return;
    this.mWeaponObject.SetActive(active);
  }

  public enum Status
  {
    ST_WAIT,
    ST_READY_A1,
    ST_ATTACK1,
    ST_READY_A2,
    ST_ATTACK2,
    ST_READY_THROW,
    ST_THROW,
    ST_READY_AS,
    ST_ATTACKS,
    ST_ATTACKS_WAIT,
    ST_READY_BS,
    ST_BACKSTEP,
    ST_DAMAGE,
    ST_DAMAGE_WAIT,
    ST_DEATH,
    ST_ESCAPE,
    ST_GURAD,
    ST_READY_RUN,
    ST_RUN,
    ST_READY_CRIT_CAM,
    ST_CRIT_CAM,
    ST_READY_RUN_AFTER_ATTACK,
    ST_RUN_AFTER_ATTACK,
    ST_SUPPORT,
    ST_READY_KAIHOU,
    ST_KAIHOU,
    ST_READY_DODGE,
    ST_DODGE,
    ST_WIN,
    ST_NONE,
  }
}
