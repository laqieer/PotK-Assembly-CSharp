// Decompiled with JetBrains decompiler
// Type: NGGameDataManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using gu3;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGGameDataManager : Singleton<NGGameDataManager>
{
  private Modified<Player> player;
  private Modified<PlayerUnit[]> unit;
  private Modified<NGGameDataManager.TimeCounter> timeCounter;
  private DateTime oldTime;
  private bool started;
  public int defaultTargetFrameRate = 30;
  public WebAPI.Response.HomeStartUp homeStartUp;
  public DateTime lastInfoTime;
  public DateTime lastGachaTime;
  public DateTime lastSlotTime;
  public bool infoThrough;
  public bool isCallHomeUpdateAllData = true;
  public Dictionary<string, Texture2D> webImageCache;
  private GameObject[] otherBattleAtlas;
  public int lastReferenceUnitID = -1;
  public int lastReferenceUnitIndex = -1;
  public int[] clearedExtraQuestSIds;
  private bool isColosseum;
  private bool isEarth;
  public NGGameDataManager.TimeCounter timeInstance;
  private bool mRefreshHomeHome;
  [SerializeField]
  private int webApiUpdateIntervalSeconds = 1800;
  private DateTime updatedTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  private bool mIsUpdating;

  public bool IsColosseum
  {
    get => this.isColosseum;
    set => this.isColosseum = value;
  }

  public bool IsEarth
  {
    get => this.isEarth;
    set => this.isEarth = value;
  }

  [DebuggerHidden]
  public IEnumerator LoadOtherBattleAtlas()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGGameDataManager.\u003CLoadOtherBattleAtlas\u003Ec__Iterator8DB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator UnLoadOtherBattleAtlas()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGGameDataManager.\u003CUnLoadOtherBattleAtlas\u003Ec__Iterator8DC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator GetWebImage(string url, UI2DSprite sprite)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGGameDataManager.\u003CGetWebImage\u003Ec__Iterator8DD()
    {
      url = url,
      sprite = sprite,
      \u003C\u0024\u003Eurl = url,
      \u003C\u0024\u003Esprite = sprite,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadWebImage(string url)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGGameDataManager.\u003CLoadWebImage\u003Ec__Iterator8DE()
    {
      url = url,
      \u003C\u0024\u003Eurl = url
    };
  }

  public bool isInitialized => this.player != null && this.unit != null && this.started;

  protected override void Initialize()
  {
    Application.targetFrameRate = this.defaultTargetFrameRate;
    this.player = SMManager.Observe<Player>();
    this.unit = SMManager.Observe<PlayerUnit[]>();
    this.timeCounter = SMManager.Observe<NGGameDataManager.TimeCounter>();
    this.oldTime = DateTime.Now;
    this.webImageCache = new Dictionary<string, Texture2D>();
    Consts.Update(MasterData.ConstsConstsList);
    Sentry.Start((MonoBehaviour) this);
  }

  private void Start()
  {
    this.timeInstance.Init(this.player);
    SMManager.Change<NGGameDataManager.TimeCounter>(this.timeInstance);
    this.started = true;
  }

  private void Update()
  {
    if (!this.isInitialized)
      return;
    DateTime now = DateTime.Now;
    float totalSeconds = (float) (now - this.oldTime).TotalSeconds;
    this.oldTime = now;
    if (!this.timeCounter.Value.AddDeltaTime(totalSeconds))
      return;
    this.timeCounter.NotifyChanged();
  }

  private void OnApplicationPause(bool pause)
  {
    if (!this.isInitialized)
      return;
    if (pause)
    {
      if (Persist.notification.Data.Ap)
      {
        int seconds = Mathf.FloorToInt(this.timeInstance.ApFullRecoverySeconds);
        if (seconds > 0)
          LocalNotification.ScheduleWithTimeInterval(new LocalNotification.Notification()
          {
            category = "AP_RECOVERY",
            message = Consts.Lookup("AP_RECOVER_PUSHNOTIFICATION_TEXT")
          }, seconds);
      }
      if (!Persist.notification.Data.Bp)
        return;
      int seconds1 = Mathf.FloorToInt(this.timeInstance.BpFullRecoverySeconds);
      if (seconds1 <= 0)
        return;
      LocalNotification.ScheduleWithTimeInterval(new LocalNotification.Notification()
      {
        category = "BP_RECOVERY",
        message = Consts.Lookup("BP_RECOVER_PUSHNOTIFICATION_TEXT")
      }, seconds1);
    }
    else
    {
      LocalNotification.CancelNotificationsWithCategory("AP_RECOVERY");
      LocalNotification.CancelNotificationsWithCategory("BP_RECOVERY");
    }
  }

  public bool refreshHomeHome
  {
    set => this.mRefreshHomeHome = value;
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsyncProxyImpl(
    Promise<NGGameDataManager.StartSceneProxyResult> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGGameDataManager.\u003CStartSceneAsyncProxyImpl\u003Ec__Iterator8DF()
    {
      promise = promise,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }

  public void StartSceneAsyncProxy(
    Action<NGGameDataManager.StartSceneProxyResult> callback = null)
  {
    new Future<NGGameDataManager.StartSceneProxyResult>(new Func<Promise<NGGameDataManager.StartSceneProxyResult>, IEnumerator>(this.StartSceneAsyncProxyImpl)).RunOn<NGGameDataManager.StartSceneProxyResult>((MonoBehaviour) this, callback);
  }

  public bool InfoOrLoginBonusJump()
  {
    bool flag = false;
    if (!this.infoThrough)
    {
      this.infoThrough = true;
      try
      {
        foreach (OfficialInformationArticle informationArticle in ((IEnumerable<OfficialInformationArticle>) this.homeStartUp.articles).Where<OfficialInformationArticle>((Func<OfficialInformationArticle, bool>) (x => !Persist.infoUnRead.Data.GetUnRead(x.id))))
        {
          if (this.lastInfoTime < informationArticle.published_at)
          {
            Singleton<NGSceneManager>.GetInstance().changeScene("startup000_12", false, (object) informationArticle);
            flag = true;
            break;
          }
        }
      }
      catch
      {
        Persist.infoUnRead.Delete();
      }
    }
    if (!flag)
    {
      foreach (PlayerLoginBonus playerLoginbonuse in this.homeStartUp.player_loginbonuses)
      {
        if (playerLoginbonuse.loginbonus.draw_type != LoginbonusDrawType.popup)
        {
          Singleton<NGSceneManager>.GetInstance().changeScene("startup000_14");
          flag = true;
          break;
        }
      }
    }
    return flag;
  }

  public void bootFirstScene(string scene)
  {
    bool playerIsCreate = WebAPI.LastPlayerBoot.player_is_create;
    if (playerIsCreate && !Singleton<TutorialRoot>.GetInstance().IsTutorialFinish())
      Singleton<TutorialRoot>.GetInstance().EndTutorial();
    if (!playerIsCreate)
      WebAPI.TutorialTutorialResume().RunOn<WebAPI.Response.TutorialTutorialResume>((MonoBehaviour) this, (Action<WebAPI.Response.TutorialTutorialResume>) (_ => Singleton<TutorialRoot>.GetInstance().StartTutorial()));
    else if (WebAPI.LastPlayerBoot.player_during_battle)
    {
      Singleton<NGSoundManager>.GetInstance().CheckInitialize(true);
      if (this.isCallHomeUpdateAllData)
        WebAPI.HomeUpdateAllData().RunOn<WebAPI.Response.HomeUpdateAllData>((MonoBehaviour) this, (Action<WebAPI.Response.HomeUpdateAllData>) (_ => WebAPI.HomeStartUp().RunOn<WebAPI.Response.HomeStartUp>((MonoBehaviour) this, (Action<WebAPI.Response.HomeStartUp>) (__ => Singleton<NGBattleManager>.GetInstance().startBattle((BattleInfo) null)))));
      else
        WebAPI.HomeStartUp().RunOn<WebAPI.Response.HomeStartUp>((MonoBehaviour) this, (Action<WebAPI.Response.HomeStartUp>) (_ => Singleton<NGBattleManager>.GetInstance().startBattle((BattleInfo) null)));
    }
    else if (WebAPI.LastPlayerBoot.player_during_pvp)
    {
      Singleton<NGSoundManager>.GetInstance().CheckInitialize(true);
      if (this.isCallHomeUpdateAllData)
        WebAPI.HomeUpdateAllData().RunOn<WebAPI.Response.HomeUpdateAllData>((MonoBehaviour) this, (Action<WebAPI.Response.HomeUpdateAllData>) (_ => WebAPI.HomeStartUp().RunOn<WebAPI.Response.HomeStartUp>((MonoBehaviour) this, (Action<WebAPI.Response.HomeStartUp>) (__ =>
        {
          this.isCallHomeUpdateAllData = false;
          Singleton<NGBattleManager>.GetInstance().startBattle(new BattleInfo()
          {
            pvp = true,
            pvp_restart = true,
            port = WebAPI.LastPlayerBoot.game_server_port,
            host = WebAPI.LastPlayerBoot.game_server_host,
            battleToken = WebAPI.LastPlayerBoot.pvp_token
          });
        }))));
      else
        WebAPI.HomeStartUp().RunOn<WebAPI.Response.HomeStartUp>((MonoBehaviour) this, (Action<WebAPI.Response.HomeStartUp>) (_ =>
        {
          this.isCallHomeUpdateAllData = false;
          Singleton<NGBattleManager>.GetInstance().startBattle(new BattleInfo()
          {
            pvp = true,
            pvp_restart = true,
            port = WebAPI.LastPlayerBoot.game_server_port,
            host = WebAPI.LastPlayerBoot.game_server_host,
            battleToken = WebAPI.LastPlayerBoot.pvp_token
          });
        }));
    }
    else if (WebAPI.LastPlayerBoot.player_during_pvp_result)
    {
      if (this.isCallHomeUpdateAllData)
        WebAPI.HomeUpdateAllData().RunOn<WebAPI.Response.HomeUpdateAllData>((MonoBehaviour) this, (Action<WebAPI.Response.HomeUpdateAllData>) (_ =>
        {
          this.isCallHomeUpdateAllData = false;
          WebAPI.HomeStartUp().RunOn<WebAPI.Response.HomeStartUp>((MonoBehaviour) this, (Action<WebAPI.Response.HomeStartUp>) (__ => Singleton<NGSceneManager>.GetInstance().changeScene("versus026_8")));
        }));
      else
        WebAPI.HomeStartUp().RunOn<WebAPI.Response.HomeStartUp>((MonoBehaviour) this, (Action<WebAPI.Response.HomeStartUp>) (_ => Singleton<NGSceneManager>.GetInstance().changeScene("versus026_8")));
    }
    else
      Singleton<NGGameDataManager>.GetInstance().StartSceneAsyncProxy((Action<NGGameDataManager.StartSceneProxyResult>) (data =>
      {
        if (scene == "mypage")
          MypageScene.ChangeScene(false);
        else
          Singleton<NGSceneManager>.GetInstance().changeScene(scene);
      }));
  }

  [Serializable]
  public class TimeCounter
  {
    private Modified<Player> player;
    private float apElapsedSeconds;
    private int ap_full_remain;
    private float bpElapsedSeconds;
    private int bp_full_remain;

    public float ApRecoverySecondsPerPoint
    {
      get
      {
        return this.player.Value == null || this.player.Value.ap >= this.player.Value.ap_max ? 0.0f : (float) this.player.Value.ap_auto_healing_sec - this.apElapsedSeconds;
      }
    }

    public float ApFullRecoverySeconds
    {
      get
      {
        return this.player.Value == null ? 0.0f : (float) ((this.player.Value.ap_max - this.player.Value.ap) * this.player.Value.ap_auto_healing_sec) - this.apElapsedSeconds;
      }
    }

    public float BpRecoverySecondsPerPoint
    {
      get
      {
        return this.player.Value == null || this.player.Value.bp >= this.player.Value.bp_max ? 0.0f : (float) this.player.Value.bp_auto_healing_sec - this.bpElapsedSeconds;
      }
    }

    public float BpFullRecoverySeconds
    {
      get
      {
        return this.player.Value == null ? 0.0f : (float) ((this.player.Value.bp_max - this.player.Value.bp) * this.player.Value.bp_auto_healing_sec) - this.bpElapsedSeconds;
      }
    }

    public void Init(Modified<Player> p) => this.player = p;

    private bool ApDeltaTime(bool isChanged, float delta)
    {
      if (this.player.Value.ap >= this.player.Value.ap_max)
      {
        this.apElapsedSeconds = 0.0f;
        this.ap_full_remain = 0;
        return isChanged;
      }
      if (isChanged && this.ap_full_remain != this.player.Value.ap_full_remain)
      {
        this.ap_full_remain = this.player.Value.ap_full_remain;
        this.apElapsedSeconds = (float) (this.player.Value.ap_auto_healing_sec - this.player.Value.ap_full_remain % this.player.Value.ap_auto_healing_sec);
      }
      else
        isChanged = (int) this.apElapsedSeconds < (int) (this.apElapsedSeconds += delta);
      return isChanged;
    }

    private bool BpDeltaTime(bool isChanged, float delta)
    {
      if (this.player.Value.bp >= this.player.Value.bp_max)
      {
        this.bpElapsedSeconds = 0.0f;
        this.bp_full_remain = 0;
        return isChanged;
      }
      if (isChanged && this.bp_full_remain != this.player.Value.bp_full_remain)
      {
        this.bp_full_remain = this.player.Value.bp_full_remain;
        this.bpElapsedSeconds = (float) (this.player.Value.bp_auto_healing_sec - this.player.Value.bp_full_remain % this.player.Value.bp_auto_healing_sec);
      }
      else
        isChanged = (int) this.bpElapsedSeconds < (int) (this.bpElapsedSeconds += delta);
      return isChanged;
    }

    private bool ApRecoveryPoint()
    {
      int num = (int) ((double) this.apElapsedSeconds / (double) this.player.Value.ap_auto_healing_sec);
      if (num <= 0)
        return false;
      this.player.Value.ap += num;
      this.apElapsedSeconds -= (float) (num * this.player.Value.ap_auto_healing_sec);
      if (this.player.Value.ap >= this.player.Value.ap_max)
      {
        this.player.Value.ap = this.player.Value.ap_max;
        this.apElapsedSeconds = 0.0f;
      }
      return true;
    }

    private bool BpRecoveryPoint()
    {
      int num = (int) ((double) this.bpElapsedSeconds / (double) this.player.Value.bp_auto_healing_sec);
      if (num <= 0)
        return false;
      this.player.Value.bp += num;
      this.bpElapsedSeconds -= (float) (num * this.player.Value.bp_auto_healing_sec);
      if (this.player.Value.bp >= this.player.Value.bp_max)
      {
        this.player.Value.bp = this.player.Value.bp_max;
        this.bpElapsedSeconds = 0.0f;
      }
      return true;
    }

    public bool AddDeltaTime(float delta)
    {
      if (this.player.Value == null)
        return false;
      bool isChanged = this.ApDeltaTime(this.player.IsChangedOnce(), delta);
      bool flag = isChanged | this.BpDeltaTime(isChanged, delta);
      if (this.ApRecoveryPoint() || this.BpRecoveryPoint())
      {
        this.player.NotifyChanged();
        this.player.IsChangedOnce();
      }
      return flag;
    }
  }

  public class StartSceneProxyResult
  {
    public bool IsBreak;
  }
}
