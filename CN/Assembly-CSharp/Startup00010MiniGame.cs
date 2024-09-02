// Decompiled with JetBrains decompiler
// Type: Startup00010MiniGame
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Startup00010MiniGame : MonoBehaviour
{
  [SerializeField]
  private float wait_move_time = 2f;
  [SerializeField]
  private iTween.EaseType wait_move_type = iTween.EaseType.linear;
  [SerializeField]
  private float target_move_time = 0.2f;
  [SerializeField]
  private iTween.EaseType target_move_type = iTween.EaseType.linear;
  [SerializeField]
  private float boss_wait_move_time = 2f;
  [SerializeField]
  private iTween.EaseType boss_wait_move_type = iTween.EaseType.linear;
  [SerializeField]
  private float boss_target_move_time = 0.2f;
  [SerializeField]
  private iTween.EaseType boss_target_move_type = iTween.EaseType.linear;
  [SerializeField]
  private UITexture renderTargetTexture;
  [SerializeField]
  private Camera sceneCamera;
  [SerializeField]
  private Camera miniGameCamera;
  [SerializeField]
  private Camera effectGameCamera;
  [SerializeField]
  public Startup00010Player player;
  [SerializeField]
  private GameObject enemyPrefab;
  [SerializeField]
  private GameObject bossPrefab;
  [SerializeField]
  private List<Transform> respawnPoint;
  [SerializeField]
  private List<Startup00010Enemy> enemyList;
  [SerializeField]
  private Transform targetPoint;
  [SerializeField]
  private Transform targetPointBoss;
  [SerializeField]
  private List<Transform> waitPoint;
  [SerializeField]
  private Transform waitPointBoss;
  [SerializeField]
  private Startup00010Enemy targetEnemy;
  public int score;
  public float time;
  [SerializeField]
  private Startup00010ScoreDraw scoreDraw;
  [SerializeField]
  private Startup00010ScoreDraw scoreCutinDraw;
  [SerializeField]
  private Startup00010TweenpositionControll scoreCutinTween;
  [SerializeField]
  private Startup00010TweenpositionControll textChange;
  [SerializeField]
  private List<ParticleSystem> cutinParticleList;
  [SerializeField]
  private List<Startup00010ManaStone> manaStoneList;
  public int bossTiming = 100;
  public int bonusTiming = 777;
  public Startup00010DownloadContents dlc;
  [SerializeField]
  private UILabel dlc_gauge;
  [SerializeField]
  private UILabel dlc_down_size;
  [SerializeField]
  private NGTweenGaugeScale slc_dlc_gauge;
  [SerializeField]
  private UIRoot uiRoot;
  [SerializeField]
  private int getStoneValue;
  [SerializeField]
  private bool bossFlag;
  [SerializeField]
  private GameObject damage_effect;
  [SerializeField]
  private List<GameObject> damage_effect_list;
  [SerializeField]
  private GameObject button_on;
  [SerializeField]
  private GameObject button_off;
  [SerializeField]
  private string bgmName;
  [SerializeField]
  private UIWidget secretManaStone;
  [SerializeField]
  private GameObject secretManaStoneEffect;
  public bool secretMonster;
  public List<GameObject> GameObjList;
  private int downloadIndex = -1;
  private int downloadTimes = -1;

  private void OnPress(bool isDown)
  {
    if (isDown)
    {
      this.button_on.SetActive(true);
      this.button_off.SetActive(false);
      if (Object.op_Inequality((Object) Singleton<NGSoundManager>.GetInstance(), (Object) null))
        Singleton<NGSoundManager>.GetInstance().playSE("SE_0512");
      this.killEnemy();
      this.player.Attack();
    }
    else
    {
      this.button_on.SetActive(false);
      this.button_off.SetActive(true);
    }
  }

  protected virtual void OnEnable() => UICamera.fallThrough = ((Component) this).gameObject;

  protected virtual void OnDisable() => UICamera.fallThrough = (GameObject) null;

  private void Initialize()
  {
    EventTracker.BeaconTutorial("Download", 0);
    this.secretMonster = false;
  }

  private void Awake() => ModalWindow.setupRootPanel(this.uiRoot);

  private void Start()
  {
    this.GameObjList.ForEach((Action<GameObject>) (x => x.SetActive(true)));
    this.Initialize();
    this.score = 0;
    if (!Persist.tutorial.Data.IsFinishTutorial())
      this.score = Mathf.Max(this.score, Persist.tutorial.Data.MiniGameScore);
    for (int index = 0; index < this.score / 100; ++index)
    {
      if (index > 4)
      {
        this.textChange.Play();
        break;
      }
      this.manaStoneList[index].Get();
    }
    if (this.score >= 777)
    {
      ((Component) this.textChange).gameObject.SetActive(false);
      float num = (float) this.score - 500f;
      if ((double) num < 0.0)
        num = 0.0f;
      this.secretManaStone.alpha = num / 277f;
      this.manaStoneList[5].Get();
    }
    this.scoreDraw.Draw(this.score);
    if (Object.op_Equality((Object) this.miniGameCamera.targetTexture, (Object) null))
    {
      this.miniGameCamera.targetTexture = new RenderTexture(1024, 1024, 24);
      this.effectGameCamera.targetTexture = this.miniGameCamera.targetTexture;
      this.miniGameCamera.targetTexture.enableRandomWrite = false;
      this.renderTargetTexture.mainTexture = (Texture) this.miniGameCamera.targetTexture;
      ((Behaviour) this.miniGameCamera).enabled = true;
      ((Behaviour) this.effectGameCamera).enabled = true;
    }
    if (this.bgmName == null && !(string.Empty != this.bgmName) || !Object.op_Inequality((Object) Singleton<NGSoundManager>.GetInstance(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playBGMWithCrossFade(this.bgmName, 1f);
  }

  public void AddScore(string enemyName)
  {
    if (enemyName != "Boss" && (this.score % this.bossTiming == this.bossTiming - 1 || this.score == this.bonusTiming - 1))
      return;
    ++this.score;
    this.scoreDraw.Draw(this.score);
    if (this.score % this.bossTiming == this.bossTiming - 1)
    {
      this.secretMonster = false;
      this.bossFlag = true;
    }
    if (this.bonusTiming - 1 == this.score)
    {
      this.secretMonster = true;
      this.bossFlag = true;
    }
    if (this.score == this.bonusTiming - 1)
    {
      this.secretManaStoneEffect.SetActive(true);
      this.bossFlag = true;
    }
    if (this.score % this.bossTiming == 0 && this.score > 0)
    {
      this.StartCoroutine(this.ScoreCutin(this.score));
      if (this.score == 500)
        this.textChange.Play();
    }
    if (this.score == this.bonusTiming)
      this.StartCoroutine(this.BonusScoreCutin(this.score));
    float num = (float) this.score - 500f;
    if ((double) num < 0.0)
      num = 0.0f;
    this.secretManaStone.alpha = num / 277f;
  }

  [DebuggerHidden]
  public IEnumerator BonusScoreCutin(int score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010MiniGame.\u003CBonusScoreCutin\u003Ec__Iterator163()
    {
      score = score,
      \u003C\u0024\u003Escore = score,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ScoreCutin(int score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010MiniGame.\u003CScoreCutin\u003Ec__Iterator164()
    {
      score = score,
      \u003C\u0024\u003Escore = score,
      \u003C\u003Ef__this = this
    };
  }

  public void Attack() => this.player.Attack();

  private void TargetMove(
    Transform target,
    GameObject move_obj,
    Startup00010MiniGame.MOVE_TYPE type)
  {
    iTween.Stop(move_obj);
    Hashtable args = new Hashtable();
    args.Add((object) "x", (object) target.position.x);
    args.Add((object) "y", (object) target.position.y);
    args.Add((object) "z", (object) target.position.z);
    switch (type)
    {
      case Startup00010MiniGame.MOVE_TYPE.WAIT_MOVE:
        args.Add((object) "time", (object) this.wait_move_time);
        args.Add((object) "easetype", (object) this.wait_move_type);
        args.Add((object) "onupdate", (object) "LockAt");
        args.Add((object) "onupdateparams", (object) move_obj.transform);
        args.Add((object) "onupdatetarget", (object) ((Component) this).gameObject);
        break;
      case Startup00010MiniGame.MOVE_TYPE.TARGET_MOVE:
        args.Add((object) "time", (object) this.target_move_time);
        args.Add((object) "easetype", (object) this.target_move_type);
        args.Add((object) "onupdate", (object) "LockAt");
        args.Add((object) "onupdateparams", (object) move_obj.transform);
        args.Add((object) "onupdatetarget", (object) ((Component) this).gameObject);
        break;
      case Startup00010MiniGame.MOVE_TYPE.BOSS_WAIT_MOVE:
        args.Add((object) "time", (object) this.boss_wait_move_time);
        args.Add((object) "easetype", (object) this.boss_wait_move_type);
        break;
      case Startup00010MiniGame.MOVE_TYPE.BOSS_TARGET_MOVE:
        args.Add((object) "time", (object) this.boss_target_move_time);
        args.Add((object) "easetype", (object) this.boss_target_move_type);
        args.Add((object) "oncomplete", (object) "BossPop");
        args.Add((object) "oncompletetarget", (object) ((Component) this).gameObject);
        break;
    }
    args.Add((object) "delay", (object) 0.01f);
    iTween.MoveTo(move_obj, args);
    move_obj.GetComponent<iTween>().SetPhysics(false);
  }

  private void LockAt(Transform trans) => trans.LookAt(((Component) this.player).transform);

  private void killEnemy()
  {
    if (!Object.op_Inequality((Object) Singleton<NGSoundManager>.GetInstance(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0511", delay: 0.1f);
  }

  private void Update()
  {
    this.time += Time.deltaTime;
    float max = 100f;
    float num1 = 0.0f;
    if (StartupDownLoad.progress != null)
    {
      max = (float) StartupDownLoad.progress.Denominator;
      num1 = (float) StartupDownLoad.progress.Numerator;
    }
    float n = Mathf.Min(num1, max);
    float num2 = (float) ((double) n / (double) max * 100.0);
    if (this.downloadIndex < 0)
    {
      this.downloadIndex = 0;
      Dictionary<string, object> firstDownInfo = Singleton<ResourceManager>.GetInstance().getFirstDownInfo();
      if (firstDownInfo != null)
      {
        try
        {
          this.downloadIndex = !firstDownInfo.ContainsKey("didx") ? 0 : Convert.ToInt32(firstDownInfo["didx"]);
        }
        catch (Exception ex)
        {
          Debug.LogError((object) ex.ToString());
        }
      }
    }
    if (this.downloadTimes < 0)
    {
      this.downloadTimes = 0;
      Dictionary<string, object> firstDownInfo = Singleton<ResourceManager>.GetInstance().getFirstDownInfo();
      try
      {
        this.downloadTimes = !firstDownInfo.ContainsKey("dtimes") ? 0 : Convert.ToInt32(firstDownInfo["dtimes"]);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ex.ToString());
      }
      ++this.downloadTimes;
      if (firstDownInfo.ContainsKey("dtimes"))
        firstDownInfo["dtimes"] = (object) this.downloadTimes;
      else
        firstDownInfo.Add("dtimes", (object) this.downloadTimes);
      Singleton<ResourceManager>.GetInstance().saveFirstDownInfo(firstDownInfo);
    }
    int num3 = (int) (((double) num2 - 4.0) / 10.0);
    if (this.downloadIndex == 0 || num3 >= this.downloadIndex)
    {
      UserEvent.SendDownloadEvent((MonoBehaviour) this, this.downloadIndex, this.downloadTimes);
      ++this.downloadIndex;
      Dictionary<string, object> firstDownInfo = Singleton<ResourceManager>.GetInstance().getFirstDownInfo();
      if (firstDownInfo.ContainsKey("didx"))
        firstDownInfo["didx"] = (object) this.downloadIndex;
      else
        firstDownInfo.Add("didx", (object) this.downloadIndex);
      Singleton<ResourceManager>.GetInstance().saveFirstDownInfo(firstDownInfo);
    }
    if (ResourceDownloader.IsCheckingFiles)
      this.dlc_down_size.SetText(Consts.GetInstance().checking_files);
    else if (ResourceDownloader.nowDataDownloadSize != 0 && !ResourceDownloader.nowDataDownloadName.Equals(string.Empty))
    {
      int num4 = ResourceDownloader.nowDataDownloadSize / 1024 / 1024;
      if (num4 < 1)
      {
        int num5 = ResourceDownloader.nowDataDownloadSize / 1024;
        if (num5 < 1)
          this.dlc_down_size.SetText(string.Format(Consts.GetInstance().downloade + ":{0} {1} B", (object) ResourceDownloader.nowDataDownloadName, (object) ResourceDownloader.nowDataDownloadSize));
        else
          this.dlc_down_size.SetText(string.Format(Consts.GetInstance().downloade + ":{0} {1} KB", (object) ResourceDownloader.nowDataDownloadName, (object) num5));
      }
      else
        this.dlc_down_size.SetText(string.Format(Consts.GetInstance().downloade + ":{0} {1} MB", (object) ResourceDownloader.nowDataDownloadName, (object) num4));
    }
    this.dlc_gauge.SetTextLocalize(string.Format("{0:F} ％", (object) num2));
    this.slc_dlc_gauge.setValue((int) n, (int) max, false);
    if (StartupDownLoad.nowDownloadSize == 0 || StartupDownLoad.nowDownloadName.Equals(string.Empty) || StartupDownLoad.nowDownloadSize / 1024 / 1024 >= 1 || StartupDownLoad.nowDownloadSize / 1024 >= 1)
      ;
    this.SetWaitPoint();
    this.SetEnemy();
  }

  public GameObject SetDamageEffect()
  {
    List<GameObject> list = this.damage_effect_list.Where<GameObject>((Func<GameObject, bool>) (x => !x.activeSelf)).ToList<GameObject>();
    GameObject gameObject;
    if (list.Count == 0)
    {
      gameObject = this.damage_effect_list.First<GameObject>().Clone(this.damage_effect.transform);
      this.damage_effect_list.Add(gameObject);
    }
    else
      gameObject = list.First<GameObject>();
    return gameObject;
  }

  public void BossLost()
  {
    this.enemyList.Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => ((Object) x).name == "Enemy")).Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => ((Object) ((Component) x).transform.parent).name == "WaitPoint")).ToList<Startup00010Enemy>().ForEach((Action<Startup00010Enemy>) (obj =>
    {
      obj.Init();
      ((Component) obj).transform.position = NC.RandomChoice<Transform>(this.respawnPoint).position;
      this.TargetMove(((Component) ((Component) obj).transform.parent).transform, ((Component) obj).gameObject, Startup00010MiniGame.MOVE_TYPE.WAIT_MOVE);
    }));
  }

  public void BossPop()
  {
    Resources.UnloadUnusedAssets();
    this.enemyList.Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => ((Object) x).name == "Enemy")).Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => ((Object) ((Component) x).transform.parent).name == "WaitPoint")).ToList<Startup00010Enemy>().ForEach((Action<Startup00010Enemy>) (x => x.Blow()));
  }

  public void SetWaitPoint()
  {
    string targetName = "Enemy";
    GameObject self = this.enemyPrefab;
    Startup00010MiniGame.MOVE_TYPE type = Startup00010MiniGame.MOVE_TYPE.WAIT_MOVE;
    List<Transform> list1 = this.waitPoint.Where<Transform>((Func<Transform, bool>) (x => x.childCount == 0)).ToList<Transform>();
    if (this.waitPointBoss.childCount == 0)
    {
      targetName = "Boss";
      self = this.bossPrefab;
      list1.Clear();
      list1.Add(this.waitPointBoss);
      type = Startup00010MiniGame.MOVE_TYPE.BOSS_WAIT_MOVE;
    }
    List<Startup00010Enemy> list2 = this.enemyList.Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => !((Component) x).gameObject.activeSelf)).Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => ((Object) x).name == targetName)).ToList<Startup00010Enemy>();
    for (int index = 0; index < list1.Count; ++index)
    {
      Transform parent = NC.RandomChoice<Transform>(this.respawnPoint);
      Startup00010Enemy component;
      if (list2.Count <= index)
      {
        component = self.Clone(parent).GetComponent<Startup00010Enemy>();
        this.enemyList.Add(component);
        ((Object) component).name = targetName;
      }
      else
      {
        component = list2[index];
        ((Component) component).transform.position = parent.position;
        ((Component) component).gameObject.SetActive(true);
      }
      component.Init();
      this.TargetMove(list1[index], ((Component) component).gameObject, type);
      ((Component) component).transform.parent = list1[index];
    }
  }

  public void SetEnemy()
  {
    bool flag = false;
    if (this.targetPoint.childCount > 0)
    {
      flag = true;
      if (Object.op_Equality((Object) ((Component) this.targetPoint.GetChild(0)).GetComponent<iTween>(), (Object) null) && Vector3.op_Inequality(((Component) this.targetPoint.GetChild(0)).transform.localPosition, Vector3.zero))
      {
        this.targetEnemy = ((Component) this.targetPoint.GetChild(0)).GetComponent<Startup00010Enemy>();
        if (((Object) this.targetPoint.GetChild(0)).name == "Boss")
          this.TargetMove(this.targetPointBoss, ((Component) this.targetEnemy).gameObject, Startup00010MiniGame.MOVE_TYPE.BOSS_TARGET_MOVE);
        else
          this.TargetMove(this.targetPoint, ((Component) this.targetEnemy).gameObject, Startup00010MiniGame.MOVE_TYPE.TARGET_MOVE);
      }
    }
    if (flag)
      return;
    string name_object = "Enemy";
    string name_object_boss = "WaitPoint";
    Transform target = this.targetPoint;
    Startup00010MiniGame.MOVE_TYPE type = Startup00010MiniGame.MOVE_TYPE.TARGET_MOVE;
    if (this.bossFlag)
    {
      name_object = "Boss";
      name_object_boss = "WaitPointBoss";
      target = this.targetPointBoss;
      type = Startup00010MiniGame.MOVE_TYPE.BOSS_TARGET_MOVE;
    }
    List<Startup00010Enemy> list = this.enemyList.Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => ((Component) x).gameObject.activeSelf)).Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => x.WaitCheck())).Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => ((Object) x).name == name_object)).Where<Startup00010Enemy>((Func<Startup00010Enemy, bool>) (x => ((Object) ((Component) x).transform.parent).name == name_object_boss)).ToList<Startup00010Enemy>();
    if (list.Count <= 0)
      return;
    this.targetEnemy = NC.RandomChoice<Startup00010Enemy>(list.ToList<Startup00010Enemy>());
    this.TargetMove(target, ((Component) this.targetEnemy).gameObject, type);
    ((Component) this.targetEnemy).transform.parent = this.targetPoint;
    if (!this.bossFlag)
      return;
    if (this.secretMonster)
      this.targetEnemy.SecretSet();
    this.bossFlag = false;
  }

  private enum MOVE_TYPE
  {
    WAIT_MOVE,
    TARGET_MOVE,
    BOSS_WAIT_MOVE,
    BOSS_TARGET_MOVE,
  }
}
