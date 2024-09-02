// Decompiled with JetBrains decompiler
// Type: TopSceneEN
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TopSceneEN : EffectController
{
  private const string toNextScene = "startup000_6";
  [SerializeField]
  private UIRoot uiRoot;
  [SerializeField]
  private GameObject menu;
  [SerializeField]
  public string bgmName;
  [SerializeField]
  private GameObject CodeError;
  [SerializeField]
  private GameObject InputBlock;
  [SerializeField]
  private GameObject SameTerminal;
  [SerializeField]
  private GameObject Success;
  [SerializeField]
  private GameObject BackCollider;
  [SerializeField]
  private GameObject PressStart;
  [SerializeField]
  private GameObject PGSSignInButton;
  [SerializeField]
  private Startup0008Data userPolicyData;
  [SerializeField]
  private Startup0008TopPageMenu userPolicy;
  [SerializeField]
  private Startup00016Menu privacy;
  [SerializeField]
  private GameObject refund;
  [SerializeField]
  private Startup00017Menu data_load;
  [SerializeField]
  private Transfer01281Menu data_load_warning;
  [SerializeField]
  private Transfer01281Menu dataLoadFacebookWarning;
  [SerializeField]
  private GameObject DirFacebookLogin;
  [SerializeField]
  private GameObject dataInheriting;
  private bool isOpenedFacebookPopup;
  [SerializeField]
  private UILabel txtApplicationVersion;
  [SerializeField]
  private UILabel txtScreenSize;
  [SerializeField]
  private UILabel txtBundleVersion;
  [SerializeField]
  private static string dlc_version;
  [SerializeField]
  private TopBackGroundAnimation backGroundAnim;
  [SerializeField]
  private TopPressBtnAnimation btnAnim;
  private GameObject nowPopup;
  private Consts c;
  private bool enablePressStartBtn;
  private bool isIntoTouch = true;
  private TopSceneEN.PopupCondition pCond;

  public static string DLCVersion
  {
    get => TopSceneEN.dlc_version;
    set => TopSceneEN.dlc_version = value;
  }

  public bool EnablePressStartBtn
  {
    set => this.enablePressStartBtn = value;
    get => this.enablePressStartBtn;
  }

  private void Awake()
  {
    this.c = Consts.GetInstance();
    ModalWindow.setupRootPanel(this.uiRoot);
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopSceneEN.\u003CStart\u003Ec__Iterator151()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (!Input.GetKeyUp((KeyCode) 27))
      return;
    this.TransPopupCondition();
  }

  private void TransPopupCondition()
  {
    switch (this.pCond)
    {
      case TopSceneEN.PopupCondition.NONE:
        this.ibtnBackEnd();
        break;
      case TopSceneEN.PopupCondition.USER_POLICY:
        this.UserPolicyDissent();
        break;
      case TopSceneEN.PopupCondition.PRIVACY:
        this.PrivacyOff();
        break;
      case TopSceneEN.PopupCondition.FACEBOOK:
        this.CloseFacebookPopup();
        break;
      case TopSceneEN.PopupCondition.DATA_LOAD:
        this.DataLoadOff();
        break;
      case TopSceneEN.PopupCondition.DATA_LOAD_WARNING:
        this.DataLoadWarningOff();
        break;
      case TopSceneEN.PopupCondition.DATA_LOAD_SUCCESS:
        this.SuccessOff();
        break;
      case TopSceneEN.PopupCondition.CLEAR_CACHE:
        this.popupDelete();
        break;
      case TopSceneEN.PopupCondition.CLEAR_CACHE_WARNING:
        this.popupDelete();
        break;
      case TopSceneEN.PopupCondition.GAME_END:
        this.popupDelete();
        break;
    }
  }

  [DebuggerHidden]
  private IEnumerator StartLocalize()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopSceneEN.\u003CStartLocalize\u003Ec__Iterator152()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void NextStateForStartGame(bool disagree = false)
  {
    if (!Persist.userPolicy.Data.GetUserPolicy() && !disagree)
      return;
    if (!Persist.userPolicy.Data.GetUserPolicy() && disagree)
      this.UserPolicyOn();
    else if (Persist.auth.Data.DeviceID == string.Empty && !this.isOpenedFacebookPopup)
    {
      this.isOpenedFacebookPopup = true;
      this.FacebookOn();
    }
    else
      this.StartGame();
  }

  private void ibtnBackEnd()
  {
    this.pCond = TopSceneEN.PopupCondition.GAME_END;
    this.nowPopup = ((Component) ModalWindow.ShowYesNo(Consts.Lookup("gamequit_title"), Consts.Lookup("gamequit_text"), new System.Action(this.Quit), (System.Action) (() =>
    {
      this.pCond = TopSceneEN.PopupCondition.NONE;
      this.nowPopup = (GameObject) null;
    }))).gameObject;
  }

  private void popupDelete()
  {
    if (Object.op_Inequality((Object) this.nowPopup, (Object) null))
      Object.DestroyObject((Object) this.nowPopup);
    this.pCond = TopSceneEN.PopupCondition.NONE;
  }

  private void Quit()
  {
    Singleton<NGSoundManager>.GetInstance().StopBgm();
    Application.Quit();
  }

  public void SuccessOff()
  {
    this.Success.gameObject.SetActive(false);
    this.BackCollider.gameObject.SetActive(false);
    StartScript.Restart();
  }

  public void DataLoadOn()
  {
    bool fbLoginStatus = Persist.auth.Data.FBLoginStatus;
    ((Component) this.dataLoadFacebookWarning).gameObject.SetActive(fbLoginStatus);
    ((Component) this.data_load_warning).gameObject.SetActive(!fbLoginStatus);
    this.BackCollider.gameObject.SetActive(true);
    this.pCond = TopSceneEN.PopupCondition.DATA_LOAD_WARNING;
  }

  public void IbtnPopupNext()
  {
    ((Component) this.data_load_warning).gameObject.SetActive(false);
    ((Component) this.data_load).gameObject.SetActive(true);
    this.data_load.InitDataCode();
    this.BackCollider.gameObject.SetActive(true);
    this.pCond = TopSceneEN.PopupCondition.DATA_LOAD;
  }

  public void DataLoadWarningOff()
  {
    ((Component) this.data_load_warning).gameObject.SetActive(false);
    ((Component) this.dataLoadFacebookWarning).gameObject.SetActive(false);
    this.BackCollider.gameObject.SetActive(false);
    this.pCond = TopSceneEN.PopupCondition.NONE;
  }

  public void IbtnPopupDecide()
  {
    this.data_load.MigrateAPI();
    ((Component) this.data_load).gameObject.SetActive(false);
    this.pCond = TopSceneEN.PopupCondition.DATA_LOAD;
  }

  public void DataLoadOff()
  {
    ((Component) this.data_load).gameObject.SetActive(false);
    this.BackCollider.gameObject.SetActive(false);
    if (this.CodeError.activeSelf || this.InputBlock.activeSelf || this.SameTerminal.activeSelf)
    {
      this.pCond = TopSceneEN.PopupCondition.NONE;
      this.CodeError.gameObject.SetActive(false);
      this.InputBlock.gameObject.SetActive(false);
      this.SameTerminal.gameObject.SetActive(false);
    }
    else if (this.Success.activeSelf)
    {
      this.pCond = TopSceneEN.PopupCondition.DATA_LOAD_SUCCESS;
      this.SuccessOff();
    }
    else
      this.pCond = TopSceneEN.PopupCondition.NONE;
  }

  public void DeleteCacheOn()
  {
    if (Persist.battleEnvironment.Exists || Persist.pvpSuspend.Exists)
    {
      ModalWindow.ShowYesNo(Consts.Lookup("cache_clear_warning_title"), Consts.Lookup("cache_clear_warning_body"), (System.Action) (() =>
      {
        this.pCond = TopSceneEN.PopupCondition.NONE;
        Persist.cacheInfo.Data.hasDeleted = true;
        Persist.cacheInfo.Flush();
        this.StartCoroutine(this.startClearCacheWithAutoSleep());
      }), (System.Action) (() => this.pCond = TopSceneEN.PopupCondition.NONE));
      this.pCond = TopSceneEN.PopupCondition.CLEAR_CACHE_WARNING;
    }
    else
    {
      ModalWindow modalWindow = ModalWindow.ShowYesNo(Consts.Lookup("clear_cache_title"), Consts.Lookup("clear_cache_text"), (System.Action) (() => this.StartCoroutine(this.startClearCacheWithAutoSleep())), (System.Action) (() => this.pCond = TopSceneEN.PopupCondition.NONE));
      modalWindow.SetHeight(600);
      this.nowPopup = ((Component) modalWindow).gameObject;
      this.pCond = TopSceneEN.PopupCondition.CLEAR_CACHE;
    }
  }

  [DebuggerHidden]
  private IEnumerator startClearCacheWithAutoSleep()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopSceneEN.\u003CstartClearCacheWithAutoSleep\u003Ec__Iterator153()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator startClearCache()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopSceneEN.\u003CstartClearCache\u003Ec__Iterator154()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void PrivacyOn()
  {
    ((Component) this.privacy).gameObject.SetActive(true);
    this.BackCollider.gameObject.SetActive(true);
    this.pCond = TopSceneEN.PopupCondition.PRIVACY;
  }

  public void PrivacyOff()
  {
    ((Component) this.privacy).gameObject.SetActive(false);
    this.BackCollider.gameObject.SetActive(false);
    this.pCond = TopSceneEN.PopupCondition.NONE;
  }

  public void RefundOn()
  {
    this.refund.gameObject.SetActive(true);
    this.BackCollider.gameObject.SetActive(true);
  }

  public void RefundOff()
  {
    this.refund.gameObject.SetActive(false);
    this.BackCollider.gameObject.SetActive(false);
  }

  public void UserPolicyOn()
  {
    ((Component) this.userPolicy).gameObject.SetActive(true);
    this.StartCoroutine(this.userPolicy.ScrollValue());
    this.BackCollider.gameObject.SetActive(true);
    this.pCond = TopSceneEN.PopupCondition.USER_POLICY;
  }

  public void UserPolicyAgree()
  {
    ((Component) this.userPolicy).gameObject.SetActive(false);
    Persist.userPolicy.Data.SetUserPolicy();
    Persist.userPolicy.Flush();
    MetapsAnalyticsScript.TrackEvent("tutorial2", "01_Agree");
    Appsflyer.TrackSimpleEvent("tutorial-01_Agree", "01_Agree");
    this.NextStateForStartGame();
  }

  public void UserPolicyDissent()
  {
    this.pCond = TopSceneEN.PopupCondition.USER_POLICY_CAUTION;
    ((Component) this.userPolicy).gameObject.SetActive(false);
    this.nowPopup = ((Component) ModalWindow.Show(this.userPolicyData.titleDissent, this.userPolicyData.dissent, (System.Action) (() =>
    {
      this.pCond = TopSceneEN.PopupCondition.USER_POLICY;
      this.NextStateForStartGame(true);
    }))).gameObject;
  }

  public void CodeErrorOff()
  {
    this.BackCollider.SetActive(false);
    this.CodeError.SetActive(false);
    this.pCond = TopSceneEN.PopupCondition.NONE;
  }

  public void InputBlockOff()
  {
    this.InputBlock.SetActive(false);
    this.BackCollider.SetActive(false);
    this.pCond = TopSceneEN.PopupCondition.NONE;
  }

  public void SameTerminalOff()
  {
    this.SameTerminal.SetActive(false);
    this.BackCollider.SetActive(false);
    this.pCond = TopSceneEN.PopupCondition.NONE;
  }

  public void SignInPGS()
  {
    Singleton<SocialManager>.GetInstance().Auth((System.Action<bool>) (success => this.PGSSignInButton.SetActive(!success)));
  }

  public void FacebookOn()
  {
    this.pCond = TopSceneEN.PopupCondition.FACEBOOK;
    this.BackCollider.gameObject.SetActive(true);
    if (Object.op_Equality((Object) this.DirFacebookLogin, (Object) null))
    {
      this.pCond = TopSceneEN.PopupCondition.NONE;
      this.BackCollider.gameObject.SetActive(false);
    }
    else
    {
      this.DirFacebookLogin.GetComponent<FacebookLogin>().Init();
      this.DirFacebookLogin.SetActive(true);
      ((IEnumerable<UITweener>) NGTween.findTweeners(this.DirFacebookLogin, true)).ForEach<UITweener>((System.Action<UITweener>) (x => x.PlayForward()));
    }
  }

  public void CloseFacebookPopup() => this.StartCoroutine(this.FacebookCloseEffect());

  [DebuggerHidden]
  private IEnumerator FacebookCloseEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopSceneEN.\u003CFacebookCloseEffect\u003Ec__Iterator155()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void StartGame()
  {
    this.isIntoTouch = false;
    this.PressStart.SetActive(true);
    if (Persist.auth.Exists)
      Appsflyer.SetCustomerID(Persist.auth.Data.DeviceID);
    else
      Debug.LogWarning((object) "Persist.auth not available at Appsflyer setup time");
  }

  public void OnTouchStart()
  {
    if (!this.enablePressStartBtn)
      return;
    this.BackCollider.SetActive(true);
    this.isIntoTouch = false;
    this.pCond = TopSceneEN.PopupCondition.LOCK;
    this.StartCoroutine(this.UserPolicy());
  }

  private void changeNextScene()
  {
    this.pCond = TopSceneEN.PopupCondition.LOCK;
    this.StartCoroutine(this.changeNextSceneLoop());
  }

  [DebuggerHidden]
  private IEnumerator changeNextSceneLoop()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TopSceneEN.\u003CchangeNextSceneLoop\u003Ec__Iterator156 loopCIterator156 = new TopSceneEN.\u003CchangeNextSceneLoop\u003Ec__Iterator156();
    return (IEnumerator) loopCIterator156;
  }

  [DebuggerHidden]
  public IEnumerator UserPolicy()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopSceneEN.\u003CUserPolicy\u003Ec__Iterator157()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetTextPolicy()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopSceneEN.\u003CSetTextPolicy\u003Ec__Iterator158()
    {
      \u003C\u003Ef__this = this
    };
  }

  public GameObject agreementSource { get; set; }

  private enum PopupCondition
  {
    NONE,
    USER_POLICY,
    USER_POLICY_CAUTION,
    PRIVACY,
    FACEBOOK,
    DATA_LOAD,
    DATA_LOAD_WARNING,
    DATA_LOAD_SUCCESS,
    CLEAR_CACHE,
    CLEAR_CACHE_WARNING,
    GAME_END,
    LOCK,
  }
}
