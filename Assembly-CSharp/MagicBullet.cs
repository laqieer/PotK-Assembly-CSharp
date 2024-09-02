// Decompiled with JetBrains decompiler
// Type: MagicBullet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
  private const string prefabPath = "BattleEffects/duel/";
  public string strMuzzlePF;
  public string strBulletPF;
  public string strExplosePF;
  public string strDrainBulletPF;
  public string strDrainExplosePF;
  public Vector3? startOffset;
  public Quaternion startAngle;
  public bool isFollowPosition;
  public bool isFollowBone;
  public float shootDelay;
  public float initSpeed;
  public float accelSpeed;
  public float deaccelSpeed;
  public Vector3? bulletOffset;
  public float bulletDisappearDelay;
  public Transform damagePoint;
  private Transform healPoint;
  public bool isGrounder;
  public bool isGrounderHit;
  public bool isDrain;
  public float damageDelay;
  public Vector3? exploseOffset;
  private NGDuelUnit mEnemy;
  private NGDuelUnit mMine;
  private bool isHit;
  private bool isCritical;
  public iTween.EaseType easetype = iTween.EaseType.linear;
  private Hashtable buh = new Hashtable();
  private Vector3 dp1;
  private Linear mLinearX;
  private GameObject bullet;
  private GameObject mzl;
  private GameObject chakudan;
  private GameObject drainBullet;
  private GameObject drainChakudan;
  private Transform mMuzzlePos;
  private IEnumerator mFunc;
  private float internalTime;
  private bool mbFire;
  private MagicBullet.MBStatus status;

  private void Start() => this.internalTime = 0.0f;

  public IEnumerator preloadPrefabs()
  {
    List<Future<GameObject>> futures = new List<Future<GameObject>>();
    if (!string.IsNullOrEmpty(this.strMuzzlePF))
      futures.Add(this.loadMuzzle());
    if (!string.IsNullOrEmpty(this.strBulletPF))
      futures.Add(this.loadBullet());
    if (!string.IsNullOrEmpty(this.strDrainBulletPF))
      futures.Add(this.loadDrainBullet());
    if (!string.IsNullOrEmpty(this.strExplosePF))
      futures.Add(this.loadChakudan());
    if (!string.IsNullOrEmpty(this.strDrainExplosePF))
      futures.Add(this.loadDrainChakudan());
    futures.Add(this.loadPreLeak("ef509_wand_magic"));
    if (futures.Count > 0)
    {
      IEnumerator e = futures.Sequence<GameObject>().Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  private GameObject setPreloadPrefabs(GameObject obj)
  {
    Singleton<NGDuelDataManager>.GetInstance().AddPreloadDuelEffect(obj);
    return obj;
  }

  private Future<GameObject> loadMuzzle() => new ResourceObject("BattleEffects/duel/" + this.strMuzzlePF).Load<GameObject>().Then<GameObject>((Func<GameObject, GameObject>) (f =>
  {
    Singleton<NGDuelDataManager>.GetInstance().AddPreloadDuelEffect(f);
    return f;
  }));

  private Future<GameObject> loadBullet() => new ResourceObject("BattleEffects/duel/" + this.strBulletPF).Load<GameObject>().Then<GameObject>((Func<GameObject, GameObject>) (f =>
  {
    Singleton<NGDuelDataManager>.GetInstance().AddPreloadDuelEffect(f);
    return f;
  }));

  private Future<GameObject> loadDrainBullet() => new ResourceObject("BattleEffects/duel/" + this.strDrainBulletPF).Load<GameObject>().Then<GameObject>((Func<GameObject, GameObject>) (f =>
  {
    Singleton<NGDuelDataManager>.GetInstance().AddPreloadDuelEffect(f);
    return f;
  }));

  private Future<GameObject> loadChakudan() => new ResourceObject("BattleEffects/duel/" + this.strExplosePF).Load<GameObject>().Then<GameObject>((Func<GameObject, GameObject>) (f =>
  {
    Singleton<NGDuelDataManager>.GetInstance().AddPreloadDuelEffect(f);
    return f;
  }));

  private Future<GameObject> loadDrainChakudan() => new ResourceObject("BattleEffects/duel/" + this.strDrainExplosePF).Load<GameObject>().Then<GameObject>((Func<GameObject, GameObject>) (f =>
  {
    Singleton<NGDuelDataManager>.GetInstance().AddPreloadDuelEffect(f);
    return f;
  }));

  private Future<GameObject> loadPreLeak(string name) => new ResourceObject("BattleEffects/duel/" + name).Load<GameObject>().Then<GameObject>((Func<GameObject, GameObject>) (f =>
  {
    Singleton<NGDuelDataManager>.GetInstance().AddPreloadDuelEffect(f);
    return f;
  }));

  private void Update()
  {
    this.internalTime += Time.deltaTime;
    switch (this.status)
    {
      case MagicBullet.MBStatus.ST_INIT:
        this.gameObject.transform.position = this.mMuzzlePos.position;
        this.status = MagicBullet.MBStatus.ST_READY;
        break;
      case MagicBullet.MBStatus.ST_PREPARE:
        this.status = MagicBullet.MBStatus.ST_READY;
        break;
      case MagicBullet.MBStatus.ST_READY:
        if (!this.mbFire)
          break;
        this.status = MagicBullet.MBStatus.ST_FIRE;
        break;
      case MagicBullet.MBStatus.ST_FIRE:
        Transform parent = this.transform;
        if (this.strBulletPF.Contains("bless"))
          parent = this.mMuzzlePos;
        this.mzl = Singleton<NGDuelDataManager>.GetInstance().GetPreloadDuelEffect(this.strMuzzlePF, parent);
        this.mzl.SetActive(true);
        if (this.startOffset.HasValue)
          this.mzl.transform.localPosition = this.startOffset.Value;
        this.status = MagicBullet.MBStatus.ST_BULLET;
        break;
      case MagicBullet.MBStatus.ST_BULLET:
        if ((double) this.shootDelay > (double) this.internalTime)
          break;
        this.bullet = Singleton<NGDuelDataManager>.GetInstance().GetPreloadDuelEffect(this.strBulletPF, this.transform);
        this.bullet.SetActive(true);
        this.bullet.transform.LookAt(this.damagePoint);
        if (this.bulletOffset.HasValue)
          this.bullet.transform.localPosition = this.bulletOffset.Value;
        this.dp1 = this.damagePoint.position;
        if (this.isGrounder)
        {
          this.dp1 = new Vector3(this.dp1.x, 0.0f, this.dp1.z);
          this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
        }
        this.buh.Clear();
        this.buh.Add((object) "position", (object) this.dp1);
        this.buh.Add((object) "looktarget", (object) this.damagePoint);
        this.buh.Add((object) "speed", (object) this.initSpeed);
        this.buh.Add((object) "oncomplete", (object) "onFlyEnd");
        this.buh.Add((object) "easetype", (object) this.easetype);
        this.buh.Add((object) "oncompletetarget", (object) this.gameObject);
        iTween.MoveTo(this.bullet, this.buh);
        this.gameObject.transform.LookAt(this.damagePoint);
        if (this.bulletOffset.HasValue)
          this.gameObject.transform.localPosition = this.bulletOffset.Value;
        this.internalTime = 0.0f;
        this.status = MagicBullet.MBStatus.ST_FLYING;
        break;
      case MagicBullet.MBStatus.ST_EXPLOSE:
        if (!this.isHit)
        {
          this.internalTime = 0.0f;
          float x = this.gameObject.transform.position.x;
          float num = x;
          float e = (double) x >= 0.0 ? num - 10f : num + 10f;
          this.mLinearX = new Linear(x, e, Mathf.Abs(x - e) / this.initSpeed);
          this.bulletDisappearDelay += 0.5f;
          this.mEnemy.damaged();
          this.status = MagicBullet.MBStatus.ST_ENDWAIT;
          break;
        }
        this.mLinearX = (Linear) null;
        if ((double) this.damageDelay > (double) this.internalTime)
          break;
        this.mEnemy.damaged();
        if (this.isHit)
        {
          if (this.isCritical && this.mMine.mIsLastAttack)
            this.mEnemy.playCriticalFlash_CallStartCoroutine();
          this.chakudan = Singleton<NGDuelDataManager>.GetInstance().GetPreloadDuelEffect(this.strExplosePF, this.transform);
          if ((UnityEngine.Object) this.chakudan == (UnityEngine.Object) null)
            this.chakudan = this.bullet;
          else
            this.chakudan.SetActive(true);
          Vector3 vector3 = this.damagePoint.position;
          if (this.isGrounderHit)
          {
            vector3 = new Vector3(this.damagePoint.position.x, 0.0f, this.damagePoint.position.z);
            this.chakudan.transform.rotation = Quaternion.identity;
          }
          this.chakudan.transform.position = vector3;
          if (this.exploseOffset.HasValue)
            this.chakudan.transform.localPosition = this.exploseOffset.Value;
        }
        if (!this.isDrain || !this.isHit)
        {
          this.status = MagicBullet.MBStatus.ST_ENDWAIT;
          break;
        }
        this.status = MagicBullet.MBStatus.ST_DRAIN_BULLET;
        break;
      case MagicBullet.MBStatus.ST_DRAIN_BULLET:
        if ((UnityEngine.Object) null == (UnityEngine.Object) this.healPoint)
          this.healPoint = this.transform;
        this.drainBullet = Singleton<NGDuelDataManager>.GetInstance().GetPreloadDuelEffect(this.strDrainBulletPF, this.transform);
        this.drainBullet.SetActive(true);
        this.drainBullet.transform.localPosition = this.bullet.transform.localPosition;
        this.drainBullet.transform.LookAt(this.healPoint);
        if (this.bulletOffset.HasValue)
          this.drainBullet.transform.localPosition = this.bulletOffset.Value;
        this.dp1 = this.healPoint.position;
        if (this.isGrounder)
        {
          this.dp1 = new Vector3(this.dp1.x, 0.0f, this.dp1.z);
          this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
        }
        this.buh.Clear();
        this.buh.Add((object) "position", (object) this.dp1);
        this.buh.Add((object) "looktarget", (object) this.healPoint);
        this.buh.Add((object) "speed", (object) this.initSpeed);
        this.buh.Add((object) "oncomplete", (object) "onDrainFlyEnd");
        this.buh.Add((object) "easetype", (object) this.easetype);
        this.buh.Add((object) "oncompletetarget", (object) this.gameObject);
        iTween.MoveTo(this.drainBullet, this.buh);
        this.status = MagicBullet.MBStatus.ST_FLYING;
        break;
      case MagicBullet.MBStatus.ST_DRAIN_HEAL:
        this.drainBullet.SetActive(false);
        this.drainChakudan = Singleton<NGDuelDataManager>.GetInstance().GetPreloadDuelEffect(this.strDrainExplosePF, this.mMine.gameObject.transform);
        this.drainChakudan.SetActive(true);
        this.drainChakudan.transform.LookAt(this.damagePoint);
        Vector3 vector3_1 = this.healPoint.position;
        if (this.isGrounderHit)
          vector3_1 = new Vector3(this.healPoint.position.x, 0.0f, this.healPoint.position.z);
        this.drainChakudan.transform.position = vector3_1;
        if (this.exploseOffset.HasValue)
          this.drainChakudan.transform.localPosition = this.exploseOffset.Value;
        this.mMine.showHealNumber_CallStartCoroutine();
        this.status = MagicBullet.MBStatus.ST_ENDWAIT;
        break;
      case MagicBullet.MBStatus.ST_ENDWAIT:
        if ((double) this.internalTime > (double) this.bulletDisappearDelay && this.isHit)
          this.bullet.SetActive(false);
        if (this.isHit)
        {
          ParticleSystem component = this.chakudan.GetComponent<ParticleSystem>();
          if ((UnityEngine.Object) component == (UnityEngine.Object) null || component.isStopped)
          {
            this.bullet.SetActive(false);
            this.status = MagicBullet.MBStatus.ST_END;
          }
        }
        if (this.mLinearX == null)
          break;
        this.mLinearX.Update(Time.deltaTime);
        if (this.mLinearX.isEnd)
        {
          this.gameObject.SetActive(false);
          this.status = MagicBullet.MBStatus.ST_END;
          break;
        }
        Vector3 position = this.gameObject.transform.position;
        position.x = this.mLinearX.value;
        this.gameObject.transform.position = position;
        break;
      case MagicBullet.MBStatus.ST_END:
        UnityEngine.Object.Destroy((UnityEngine.Object) this.mzl);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.chakudan);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.bullet);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
        break;
    }
  }

  public void Initialize()
  {
  }

  public void Fire(
    NGDuelUnit target,
    NGDuelUnit healtarget,
    Transform muzzle,
    bool is_hit = true,
    bool is_critical = false,
    bool is_drain = false)
  {
    this.isHit = is_hit;
    this.isCritical = is_critical;
    this.mMuzzlePos = muzzle;
    this.isDrain = is_drain;
    if ((UnityEngine.Object) null != (UnityEngine.Object) this.mzl)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.mzl);
    if ((UnityEngine.Object) null != (UnityEngine.Object) this.chakudan)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.chakudan);
    if ((UnityEngine.Object) null != (UnityEngine.Object) this.bullet)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.bullet);
    this.damagePoint = target.mBipTransform;
    this.mEnemy = target;
    if ((UnityEngine.Object) null != (UnityEngine.Object) healtarget)
    {
      this.healPoint = healtarget.mBipTransform;
      this.mMine = healtarget;
    }
    this.gameObject.transform.position = this.mMuzzlePos.position;
    this.status = MagicBullet.MBStatus.ST_READY;
    this.mbFire = true;
    this.internalTime = 0.0f;
  }

  private void onFlyEnd() => this.status = MagicBullet.MBStatus.ST_EXPLOSE;

  private void onDrainFlyEnd() => this.status = MagicBullet.MBStatus.ST_DRAIN_HEAL;

  private enum MBStatus
  {
    ST_NONE,
    ST_INIT,
    ST_PREPARE,
    ST_READY,
    ST_FIRE,
    ST_BULLET,
    ST_FLYING,
    ST_FLYEND,
    ST_EXPLOSE,
    ST_DRAIN_BULLET,
    ST_DRAIN_HEAL,
    ST_ENDWAIT,
    ST_END,
  }
}
