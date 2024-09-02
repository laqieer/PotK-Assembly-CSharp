// Decompiled with JetBrains decompiler
// Type: MypageMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class MypageMenu : BackButtonMenuBase
{
  [SerializeField]
  private const float MoviePlayTime = 1.5f;
  public static int LeaderID;
  [HideInInspector]
  public NGSoundManager sm;
  [HideInInspector]
  public UIButton[] button;
  [HideInInspector]
  public GameObject CharaAnimObj;
  [HideInInspector]
  public UI2DSprite[] CharaSprites;
  [HideInInspector]
  public UILabel[] CharaName;
  [HideInInspector]
  public Animator CharaAnimator;
  [HideInInspector]
  public bool CharaAnimation;
  [HideInInspector]
  public int ButtonCount;
  [HideInInspector]
  public int ButtonTweenFinishedCount;
  [SerializeField]
  private BannersProc BannerParent;
  [SerializeField]
  private GameObject InfoNew;
  [SerializeField]
  private GameObject MissionNew;
  [SerializeField]
  private GameObject MissionButton;
  [SerializeField]
  private GameObject PresentNew;
  [SerializeField]
  private GameObject BingoNew;
  [SerializeField]
  private GameObject BingoButton;
  [SerializeField]
  public GameObject slc_Circle_Base;
  [SerializeField]
  public GameObject dir_Select;
  [SerializeField]
  public GameObject dir_Roulette;
  [SerializeField]
  protected MypageSlidePanelDragged Story_Container;
  [SerializeField]
  private MypageSlidePanelDragged Character_Container;
  [SerializeField]
  private MypageSlidePanelDragged Event_Container;
  [SerializeField]
  private MypageSlidePanelDragged Colosseum_Container;
  [SerializeField]
  private MypageSlidePanelDragged Multi_Container;
  [SerializeField]
  private GameObject OpenEffectObject;
  private string tweenName = string.Empty;
  private static readonly int INFO_READ_JUDGE_NUM = 3;
  public static readonly int START_TWEENGROUP = 22;
  public static readonly int END_TWEENGROUP = 33;
  public static readonly int START_TWEENGROUP_TOP = 50;
  public static readonly int END_TWEENGROUP_TOP = 51;
  public static readonly int START_TWEEN_GROUP_JOGDIAL = 122;
  public static readonly int END_TWEEN_GROUP_JOGDIAL = 133;
  public static readonly int HEAVEN_OUT_BG_TWEENGROUP = 151;
  public static readonly int HEAVEN_IN_BG_TWEENGROUP = 152;
  public static readonly int EARTH_OUT_BG_TWEENGROUP = 153;
  public static readonly int EARTH_IN_BG_TWEENGROUP = 150;
  private GameObject LoginPopup;
  public Transform CharaAnimTrans;
  public GameObject NotTouch;
  public CircularMotionPositionSet CirculButton;
  public UIPanel MainPanel;

  public float CharaMovieTime => 1.5f;

  public bool LoginPopupActive() => !Object.op_Equality((Object) this.LoginPopup, (Object) null);

  [DebuggerHidden]
  public virtual IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CInitSceneAsync\u003Ec__Iterator5EA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator StartSceneAsync(bool isCloudAnim)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CStartSceneAsync\u003Ec__Iterator5EB()
    {
      isCloudAnim = isCloudAnim,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.backPopoup());
  }

  [DebuggerHidden]
  private IEnumerator backPopoup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    MypageMenu.\u003CbackPopoup\u003Ec__Iterator5EC popoupCIterator5Ec = new MypageMenu.\u003CbackPopoup\u003Ec__Iterator5EC();
    return (IEnumerator) popoupCIterator5Ec;
  }

  protected void TweenInit()
  {
    this.NotTouch.SetActive(true);
    ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.onFinished.Clear();
      ((Behaviour) x).enabled = false;
    }));
  }

  [DebuggerHidden]
  protected virtual IEnumerator InitOne()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CInitOne\u003Ec__Iterator5ED()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void JogDialSetting()
  {
    if (SMManager.Get<Player>().IsColosseum() && !Persist.colosseumOpen.Data.isOpen)
    {
      if (Object.op_Inequality((Object) this.Colosseum_Container, (Object) null))
      {
        this.Colosseum_Container.SetPreparation();
        this.CirculButton.Init(this.Colosseum_Container);
      }
      else
        this.CirculButton.Init(this.Story_Container);
    }
    else
    {
      if (Object.op_Inequality((Object) this.Colosseum_Container, (Object) null) && SMManager.Get<Player>().GetFeatureColosseum() && !SMManager.Get<Player>().GetReleaseColosseum())
        this.Colosseum_Container.SetPreparation();
      this.CirculButton.Init(this.Story_Container);
    }
  }

  [DebuggerHidden]
  protected virtual IEnumerator CharcterAnimationSetting(bool isCloudAnim, int tweenID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CCharcterAnimationSetting\u003Ec__Iterator5EE()
    {
      isCloudAnim = isCloudAnim,
      tweenID = tweenID,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u0024\u003EtweenID = tweenID,
      \u003C\u003Ef__this = this
    };
  }

  private void PresentIconSetting()
  {
    if (Object.op_Equality((Object) this.PresentNew, (Object) null))
      return;
    PlayerPresent[] source = SMManager.Get<PlayerPresent[]>();
    this.PresentNew.SetActive(source != null && ((IEnumerable<PlayerPresent>) source).Any<PlayerPresent>((Func<PlayerPresent, bool>) (p => !p.received_at.HasValue)));
  }

  private void MissionIconSetting()
  {
    if (Object.op_Equality((Object) this.MissionNew, (Object) null) || Object.op_Equality((Object) this.MissionButton, (Object) null))
      return;
    Player player = SMManager.Get<Player>();
    if (!player.IsMission())
      this.MissionButton.SetActive(false);
    else if (player.is_bingo_end)
      this.MissionNew.SetActive(player.is_open_mission);
    else
      this.MissionNew.SetActive(player.is_open_bingo);
  }

  private void BingoIconSetting()
  {
    Player player = SMManager.Get<Player>();
    this.BingoButton.SetActive(player.is_open_bingo2);
    this.BingoNew.SetActive(player.has_new_bingo2);
  }

  private void InfoIconSetting()
  {
    if (Object.op_Equality((Object) this.InfoNew, (Object) null))
      return;
    OfficialInformationArticle[] source = SMManager.Get<OfficialInformationArticle[]>();
    if (source != null)
      this.InfoNew.SetActive(this.GetInfoAlreadyRead(((IEnumerable<OfficialInformationArticle>) source).OrderBy<OfficialInformationArticle, int>((Func<OfficialInformationArticle, int>) (x => x.priority)).ToArray<OfficialInformationArticle>()));
    else
      this.InfoNew.SetActive(false);
  }

  private bool GetInfoAlreadyRead(OfficialInformationArticle[] info)
  {
    int num1 = info.Length;
    if (num1 <= 0)
      return false;
    if (num1 >= MypageMenu.INFO_READ_JUDGE_NUM)
      num1 = MypageMenu.INFO_READ_JUDGE_NUM;
    int num2 = 0;
    for (int index = 0; index < num1; ++index)
    {
      if (Persist.infoUnRead.Data.GetUnRead(info[index].id))
        ++num2;
    }
    return num1 != num2;
  }

  public void ResetTweenDelay()
  {
    ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      if (x.tweenGroup != MypageMenu.START_TWEENGROUP || (double) x.delay < (double) this.CharaMovieTime)
        return;
      x.delay -= this.CharaMovieTime;
    }));
  }

  protected float SetCharacterAnimControllerWithGetAddDelayTime(bool LeaderChange, int id)
  {
    float addDelayTime;
    if (LeaderChange)
    {
      this.tweenName = "Play";
      addDelayTime = 1.5f;
    }
    else
    {
      this.tweenName = "Fade";
      addDelayTime = 0.0f;
    }
    this.CharaAnimation = true;
    MypageMenu.LeaderID = id;
    return addDelayTime;
  }

  protected void AddStartTweenDelay(float addTime, int groupID)
  {
    List<MypageSlidePanelDragged> buttons = this.CirculButton.GetTargets;
    ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      if (x.tweenGroup != groupID)
        return;
      x.delay += addTime;
      EventDelegate.Add(x.onFinished, (EventDelegate.Callback) (() => x.delay -= addTime));
      foreach (Component component in buttons)
      {
        if (Object.op_Equality((Object) component.transform, (Object) ((Component) x).gameObject.transform))
        {
          EventDelegate.Add(x.onFinished, (EventDelegate.Callback) (() => this.ButtonTweenFinished()));
          break;
        }
      }
    }));
    this.ButtonCount = buttons.Count;
  }

  public void StartLoginPopup()
  {
    this.MainPanel.alpha = 0.0f;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public void FinishLoginPopup()
  {
    this.MainPanel.alpha = 1f;
    this.CharaAnimProc();
    this.PlayTween(MypageMenu.START_TWEENGROUP);
    this.ShowTutorialAdvice();
  }

  public void LoginBonusPopupStart(List<PlayerLoginBonus> loginBonus, System.Action callback)
  {
    if (loginBonus.Count <= 0)
    {
      callback();
    }
    else
    {
      PlayerLoginBonus loginBonu = loginBonus[0];
      loginBonus.RemoveAt(0);
      GameObject gameObject = Singleton<PopupManager>.GetInstance().open(this.LoginPopup);
      gameObject.GetComponent<Startup000144Menu>().InitScene(loginBonu);
      EventDelegate.Set(gameObject.GetComponent<Startup000144Menu>().ibtn_ok.onClick, (EventDelegate.Callback) (() =>
      {
        Singleton<PopupManager>.GetInstance().onDismiss();
        if (loginBonus.Count <= 0)
          callback();
        else
          this.LoginBonusPopupStart(loginBonus, callback);
      }));
    }
  }

  public void LevelUpPopupStart(List<LevelRewardSchemaMixin> levelupBonus, System.Action callback)
  {
    if (levelupBonus.Count <= 0)
    {
      callback();
    }
    else
    {
      LevelRewardSchemaMixin levelupBonu = levelupBonus[0];
      levelupBonus.RemoveAt(0);
      ModalWindow.Show(levelupBonu.reward_title, levelupBonu.reward_message, (System.Action) (() =>
      {
        if (levelupBonus.Count<LevelRewardSchemaMixin>() > 0)
        {
          Singleton<NGGameDataManager>.GetInstance().homeStartUp.player_achieve_level_rewards = (LevelRewardSchemaMixin[]) null;
          callback();
        }
        else
          this.LevelUpPopupStart(levelupBonus, callback);
      }));
    }
  }

  public void DeviceRewardPopupStart(System.Action callback)
  {
    if (Singleton<NGGameDataManager>.GetInstance().homeStartUp.device_rewards == null)
    {
      callback();
    }
    else
    {
      DeviceReward deviceReward = ((IEnumerable<DeviceReward>) Singleton<NGGameDataManager>.GetInstance().homeStartUp.device_rewards).FirstOrDefault<DeviceReward>();
      if (deviceReward == null)
      {
        callback();
      }
      else
      {
        List<DeviceReward> device_rewards = ((IEnumerable<DeviceReward>) Singleton<NGGameDataManager>.GetInstance().homeStartUp.device_rewards).ToList<DeviceReward>();
        device_rewards.RemoveAt(0);
        Singleton<NGGameDataManager>.GetInstance().homeStartUp.device_rewards = device_rewards.ToArray();
        GameObject prefab = PopupCommon.LoadPrefab();
        PopupCommon component = Singleton<PopupManager>.GetInstance().open(prefab).GetComponent<PopupCommon>();
        component.Init(deviceReward.display_title, deviceReward.display_message);
        EventDelegate.Set(component.OK.onClick, (EventDelegate.Callback) (() =>
        {
          Singleton<PopupManager>.GetInstance().onDismiss();
          if (device_rewards.Count > 0)
            this.DeviceRewardPopupStart(callback);
          else
            callback();
        }));
      }
    }
  }

  public void ShowTutorialAdvice()
  {
    if (Persist.tutorial.Data.Hints.ContainsKey("home_dailymission"))
      return;
    if (Persist.tutorial.Data.Hints.ContainsKey("dailymission027_1"))
    {
      Persist.tutorial.Data.Hints["home_dailymission"] = true;
      Persist.tutorial.Flush();
    }
    else
      Singleton<TutorialRoot>.GetInstance().ForceShowAdvice("mypage_dailymission", (System.Action) (() =>
      {
        Persist.tutorial.Data.Hints["home_dailymission"] = true;
        Persist.tutorial.Flush();
        DailyMission0271Scene.ChangeScene0271(false);
      }));
  }

  public void SetJogDialActive(bool active)
  {
    this.slc_Circle_Base.SetActive(active);
    this.dir_Roulette.SetActive(active);
    this.dir_Select.SetActive(active);
  }

  public void PlayTween(int groupID)
  {
    ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      if (x.tweenGroup != groupID)
        return;
      ((Component) x).gameObject.SetActive(true);
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  public void ButtonTweenFinished()
  {
    ++this.ButtonTweenFinishedCount;
    if (this.ButtonCount != this.ButtonTweenFinishedCount)
      return;
    if (SMManager.Get<Player>().IsColosseum() && !Persist.colosseumOpen.Data.isOpen)
      this.StartCoroutine(this.OpenColosseum());
    else
      this.AllCircleTweenFinished();
  }

  [DebuggerHidden]
  private IEnumerator OpenColosseum()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003COpenColosseum\u003Ec__Iterator5EF()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OpenColosseumEnd(MypageSlidePanelOpen obj)
  {
    this.Colosseum_Container.EnableEffect();
    Object.DestroyObject((Object) ((Component) obj).gameObject);
    this.AllCircleTweenFinished();
  }

  [DebuggerHidden]
  public virtual IEnumerator CloudAnimationStart()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CCloudAnimationStart\u003Ec__Iterator5F0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ChangeEarth()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    MypageMenu.\u003CChangeEarth\u003Ec__Iterator5F1 earthCIterator5F1 = new MypageMenu.\u003CChangeEarth\u003Ec__Iterator5F1();
    return (IEnumerator) earthCIterator5F1;
  }

  protected virtual void AllCircleTweenFinished()
  {
    this.NotTouch.SetActive(false);
    this.sm = Singleton<NGSoundManager>.GetInstance();
    this.CharaStartVoice();
    this.CirculButton.condition = CircularMotionPositionSet.CirculCondition.START;
    if (!Object.op_Inequality((Object) this.BannerParent, (Object) null))
      return;
    this.BannerParent.StartLoadBannerAll();
  }

  private void CharaStartVoice()
  {
    CharaVoiceCueEnum.CueID[] cueIdArray = new CharaVoiceCueEnum.CueID[6]
    {
      CharaVoiceCueEnum.CueID.MYPAGE_TIMESIGNAL_0_3,
      CharaVoiceCueEnum.CueID.MYPAGE_TIMESIGNAL_4_7,
      CharaVoiceCueEnum.CueID.MYPAGE_TIMESIGNAL_8_11,
      CharaVoiceCueEnum.CueID.MYPAGE_TIMESIGNAL_12_15,
      CharaVoiceCueEnum.CueID.MYPAGE_TIMESIGNAL_16_19,
      CharaVoiceCueEnum.CueID.MYPAGE_TIMESIGNAL_20_23
    };
    if (!MasterData.UnitUnit.ContainsKey(MypageMenu.LeaderID))
      return;
    this.sm.playVoiceByID(MasterData.UnitUnit[MypageMenu.LeaderID].unitVoicePattern.file_name, (int) cueIdArray[DateTime.Now.Hour / 4]);
  }

  private void CharaTouchVoice()
  {
    if (Object.op_Equality((Object) this.sm, (Object) null))
      this.sm = Singleton<NGSoundManager>.GetInstance();
    this.sm.stopVoice();
    int index = Random.Range(0, 3);
    CharaVoiceCueEnum.CueID[] cueIdArray = new CharaVoiceCueEnum.CueID[3]
    {
      CharaVoiceCueEnum.CueID.MYPAGE_TOUCH_NORMAL,
      CharaVoiceCueEnum.CueID.MYPAGE_TOUCH_EMOTIONS,
      CharaVoiceCueEnum.CueID.MYPAGE_TOUCH_SERVICE
    };
    if (!MasterData.UnitUnit.ContainsKey(MypageMenu.LeaderID))
      return;
    this.sm.playVoiceByID(MasterData.UnitUnit[MypageMenu.LeaderID].unitVoicePattern.file_name, (int) cueIdArray[index]);
  }

  public void CharaAnimProc()
  {
    if (!this.CharaAnimation)
      return;
    this.CharaAnimObj.SetActive(true);
    this.CharaAnimator.SetBool(this.tweenName, true);
  }

  public void CharaAnimInit()
  {
    if (Object.op_Equality((Object) this.CharaAnimObj, (Object) null))
      return;
    this.CharaAnimObj.SetActive(false);
    this.CharaAnimator.Play(string.Empty, 0, 1f);
  }

  [DebuggerHidden]
  protected IEnumerator CreateCharcterAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CCreateCharcterAnimation\u003Ec__Iterator5F2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator CreateJogDial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CCreateJogDial\u003Ec__Iterator5F3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateLoginPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CCreateLoginPopup\u003Ec__Iterator5F4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void StopBannerScroll()
  {
    if (!Object.op_Inequality((Object) this.BannerParent, (Object) null))
      return;
    this.BannerParent.StopScroll();
  }
}
