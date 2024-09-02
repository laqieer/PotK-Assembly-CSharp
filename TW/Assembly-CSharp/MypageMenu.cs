// Decompiled with JetBrains decompiler
// Type: MypageMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private GameObject FriendBadge;
  [SerializeField]
  private GameObject InfoNew;
  [SerializeField]
  private GameObject PresentNew;
  [SerializeField]
  private GameObject PanelMissionBtn;
  [SerializeField]
  private GameObject PanelMissionClear;
  [SerializeField]
  private MypagePanelMissionInfo NextPanelMission;
  [SerializeField]
  private GameObject DirPanelMissionBtn;
  [SerializeField]
  private GameObject DirPanelMissionEffect;
  [SerializeField]
  private GameObject ActivityNew;
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
  protected MypageSlidePanelDragged Event_Container;
  [SerializeField]
  private MypageSlidePanelDragged Colosseum_Container;
  [SerializeField]
  private MypageSlidePanelDragged Multi_Container;
  [SerializeField]
  private GameObject OpenEffectObject;
  protected static List<int> playTouchVoiceList = new List<int>();
  protected int nextPlayIndex;
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
  private int LoginBonusCloseCounter;
  private int LevelUpBonusCloseCounter;
  private int LevelUpBonusCount;
  private GameObject LoginPopup;
  public Transform CharaAnimTrans;
  public GameObject NotTouch;
  public CircularMotionPositionSet CirculButton;
  public UIPanel MainPanel;
  public MypageMissionClearInfo MissionClearInfo;

  public float CharaMovieTime => 1.5f;

  public bool isAnimePlaying
  {
    get
    {
      if (!Object.op_Inequality((Object) this.CharaAnimator, (Object) null) || !this.CharaAnimation)
        return false;
      AnimatorStateInfo animatorStateInfo = this.CharaAnimator.GetCurrentAnimatorStateInfo(0);
      return (double) ((AnimatorStateInfo) ref animatorStateInfo).normalizedTime < 1.0;
    }
  }

  public bool LoginPopupActive() => !Object.op_Equality((Object) this.LoginPopup, (Object) null);

  [DebuggerHidden]
  public virtual IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CInitSceneAsync\u003Ec__Iterator7EA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator StartSceneAsync(bool isCloudAnim, bool isReservedEventScript)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CStartSceneAsync\u003Ec__Iterator7EB()
    {
      isCloudAnim = isCloudAnim,
      isReservedEventScript = isReservedEventScript,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u0024\u003EisReservedEventScript = isReservedEventScript,
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
    MypageMenu.\u003CbackPopoup\u003Ec__Iterator7EC popoupCIterator7Ec = new MypageMenu.\u003CbackPopoup\u003Ec__Iterator7EC();
    return (IEnumerator) popoupCIterator7Ec;
  }

  protected void TweenInit()
  {
    this.NotTouch.SetActive(true);
    ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>(true)).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.onFinished.Clear();
      ((Behaviour) x).enabled = false;
    }));
  }

  [DebuggerHidden]
  protected virtual IEnumerator InitOne()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CInitOne\u003Ec__Iterator7ED()
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
    return (IEnumerator) new MypageMenu.\u003CCharcterAnimationSetting\u003Ec__Iterator7EE()
    {
      isCloudAnim = isCloudAnim,
      tweenID = tweenID,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u0024\u003EtweenID = tweenID,
      \u003C\u003Ef__this = this
    };
  }

  private void ActivityIconSetting()
  {
    if (SMManager.Get<Player>().is_open_activity)
      this.ActivityNew.SetActive(true);
    else
      this.ActivityNew.SetActive(false);
  }

  private void PresentIconSetting()
  {
    if (Object.op_Equality((Object) this.PresentNew, (Object) null))
      return;
    PlayerPresent[] source = SMManager.Get<PlayerPresent[]>();
    this.PresentNew.SetActive(source != null && ((IEnumerable<PlayerPresent>) source).Any<PlayerPresent>((Func<PlayerPresent, bool>) (p => !p.received_at.HasValue)));
  }

  private void InfoIconSetting()
  {
    if (Object.op_Equality((Object) this.InfoNew, (Object) null))
      return;
    this.InfoNew.SetActive(((IEnumerable<OfficialInformationArticle>) SMManager.Get<OfficialInformationArticle[]>()).Where<OfficialInformationArticle>((Func<OfficialInformationArticle, bool>) (w => !Persist.infoUnRead.Data.GetUnRead(w.id))).Any<OfficialInformationArticle>((Func<OfficialInformationArticle, bool>) (a => !a.IsPast)));
  }

  [DebuggerHidden]
  private IEnumerator PanelMissionIconSetting()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CPanelMissionIconSetting\u003Ec__Iterator7EF()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void FriendBadgeSetting()
  {
    if (Object.op_Equality((Object) this.FriendBadge, (Object) null))
      return;
    this.FriendBadge.SetActive(Singleton<NGGameDataManager>.GetInstance().ReceivedFriendRequestCount > 0);
  }

  public void ResetTweenDelay()
  {
    ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>(true)).ForEach<UITweener>((Action<UITweener>) (x =>
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
    ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>(true)).ForEach<UITweener>((Action<UITweener>) (x =>
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

  public void LoginPopupStart(PlayerLoginBonus loginBonus, int loginBonusCount)
  {
    this.LoginBonusCloseCounter = 0;
    this.MainPanel.alpha = 0.0f;
    GameObject gameObject = Singleton<PopupManager>.GetInstance().open(this.LoginPopup);
    gameObject.GetComponent<Startup000144Menu>().InitScene(loginBonus);
    EventDelegate.Set(gameObject.GetComponent<Startup000144Menu>().ibtn_ok.onClick, (EventDelegate.Callback) (() =>
    {
      Singleton<PopupManager>.GetInstance().onDismiss();
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      ++this.LoginBonusCloseCounter;
      if (loginBonusCount > this.LoginBonusCloseCounter)
        return;
      LevelRewardSchemaMixin[] playerLevelRewards = Singleton<NGGameDataManager>.GetInstance().playerLevelRewards;
      if (playerLevelRewards != null && playerLevelRewards.Length > 0)
      {
        this.LevelUpPopupInit(playerLevelRewards);
        this.LevelUpPopupStart(playerLevelRewards);
      }
      else
      {
        this.MainPanel.alpha = 1f;
        this.CharaAnimProc();
        this.PlayTween(MypageMenu.START_TWEENGROUP);
      }
    }));
  }

  public void LevelUpPopupInit(LevelRewardSchemaMixin[] levelupBonus)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    this.LevelUpBonusCount = levelupBonus.Length;
    this.LevelUpBonusCloseCounter = 0;
    this.MainPanel.alpha = 0.0f;
  }

  public void LevelUpPopupStart(LevelRewardSchemaMixin[] levelupBonus)
  {
    ModalWindow.Show(levelupBonus[this.LevelUpBonusCloseCounter].reward_title, levelupBonus[this.LevelUpBonusCloseCounter].reward_message, (System.Action) (() =>
    {
      ++this.LevelUpBonusCloseCounter;
      if (this.LevelUpBonusCount <= this.LevelUpBonusCloseCounter)
      {
        Singleton<NGGameDataManager>.GetInstance().playerLevelRewards = (LevelRewardSchemaMixin[]) null;
        this.MainPanel.alpha = 1f;
        this.CharaAnimProc();
        this.PlayTween(MypageMenu.START_TWEENGROUP);
      }
      else
        this.LevelUpPopupStart(levelupBonus);
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
    return (IEnumerator) new MypageMenu.\u003COpenColosseum\u003Ec__Iterator7F0()
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
    return (IEnumerator) new MypageMenu.\u003CCloudAnimationStart\u003Ec__Iterator7F1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ChangeEarth()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    MypageMenu.\u003CChangeEarth\u003Ec__Iterator7F2 earthCIterator7F2 = new MypageMenu.\u003CChangeEarth\u003Ec__Iterator7F2();
    return (IEnumerator) earthCIterator7F2;
  }

  protected virtual void AllCircleTweenFinished()
  {
    this.NotTouch.SetActive(false);
    this.CharaStartVoice();
    if (Object.op_Inequality((Object) this.MissionClearInfo, (Object) null))
      this.MissionClearInfo.startDisplay();
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

  protected void CharaTouchVoice()
  {
    if (Object.op_Equality((Object) this.sm, (Object) null))
      this.sm = Singleton<NGSoundManager>.GetInstance();
    this.sm.stopVoice();
    if (!MasterData.UnitUnit.ContainsKey(MypageMenu.LeaderID))
      return;
    if (Random.Range(0, 1000) < 500 && this.sm.ExistsCueID(MasterData.UnitUnit[MypageMenu.LeaderID].unitVoicePattern.file_name, 90))
    {
      this.sm.playVoiceByID(MasterData.UnitUnit[MypageMenu.LeaderID].unitVoicePattern.file_name, 90);
    }
    else
    {
      if (MypageMenu.playTouchVoiceList.Count <= 0)
        return;
      this.sm.playVoiceByID(MasterData.UnitUnit[MypageMenu.LeaderID].unitVoicePattern.file_name, MypageMenu.playTouchVoiceList[this.nextPlayIndex]);
      this.nextPlayIndex = (this.nextPlayIndex + 1) % MypageMenu.playTouchVoiceList.Count;
      if (this.nextPlayIndex != 0)
        return;
      MypageMenu.playTouchVoiceList = MypageMenu.playTouchVoiceList.Shuffle<int>().ToList<int>();
    }
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
    return (IEnumerator) new MypageMenu.\u003CCreateCharcterAnimation\u003Ec__Iterator7F3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator CreateJogDial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CCreateJogDial\u003Ec__Iterator7F4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateLoginPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CCreateLoginPopup\u003Ec__Iterator7F5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void StopBannerScroll()
  {
    if (!Object.op_Inequality((Object) this.BannerParent, (Object) null))
      return;
    this.BannerParent.StopEffect();
    this.BannerParent.StopScroll();
  }

  [DebuggerHidden]
  private IEnumerator CreateMissionClearInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CCreateMissionClearInfo\u003Ec__Iterator7F6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator MissionClearInfoSetting()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageMenu.\u003CMissionClearInfoSetting\u003Ec__Iterator7F7()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void StopMissionClearInfo()
  {
    if (!Object.op_Inequality((Object) this.MissionClearInfo, (Object) null))
      return;
    this.MissionClearInfo.clearAll();
  }

  public void HidePanelMission()
  {
    ((Component) this.NextPanelMission).gameObject.SetActive(false);
    this.PanelMissionBtn.gameObject.SetActive(false);
    this.DirPanelMissionBtn.SetActive(false);
    this.DirPanelMissionEffect.SetActive(false);
  }
}
