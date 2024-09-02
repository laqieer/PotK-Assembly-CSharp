// Decompiled with JetBrains decompiler
// Type: TopScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TopScene : MonoBehaviour
{
  private const string toNextScene = "startup000_6";
  private const float csWaitTime = 1f;
  [SerializeField]
  private UIRoot uiRoot;
  [SerializeField]
  private GameObject popupPanel;
  [SerializeField]
  private GameObject menu;
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
  private Startup0008Data userPolicyData;
  [SerializeField]
  private UniWebViewController m_webview;
  [SerializeField]
  private FGGIDConnectInitializer m_FggIdConnect;
  [SerializeField]
  private Startup0008TopPageMenu userPolicy;
  [SerializeField]
  private Startup00016Menu privacy;
  [SerializeField]
  private Startup00017Menu data_load;
  [SerializeField]
  private Transfer01281Menu data_load_warning;
  [SerializeField]
  private UILabel txtApplicationVersion;
  [SerializeField]
  private UILabel txtScreenSize;
  [SerializeField]
  private string bgmName;
  [SerializeField]
  private GameObject loadingBG;
  [SerializeField]
  public UILabel txtLuaDownloadTips;
  public bool BackKeyValid = true;
  private bool m_bFinishDownLua;
  private bool m_bStartPressed;
  [SerializeField]
  private TopBackGroundAnimation backGroundAnim;
  [SerializeField]
  private TopPressBtnAnimation btnAnim;
  [SerializeField]
  private UILabel txtUserID;
  [SerializeField]
  private UILabel txtVersion;
  private GameObject nowPopup;
  private bool enablePressStartBtn = true;
  private bool isIntoTouch = true;
  public TopScene.PopupCondition pCond;

  public bool EnablePressStartBtn
  {
    set => this.enablePressStartBtn = value;
    get => this.enablePressStartBtn;
  }

  private void startWaitBack()
  {
    this.BackKeyValid = false;
    this.StartCoroutine(this.waitTimeValid());
  }

  [DebuggerHidden]
  private IEnumerator waitTimeValid()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopScene.\u003CwaitTimeValid\u003Ec__Iterator18A()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (Input.GetKeyUp((KeyCode) 27) && this.BackKeyValid)
    {
      this.startWaitBack();
      this.TransPopupCondition();
    }
    if (this.m_bFinishDownLua || DenaLib.Singleton<GameLogic>.Instance.GameState != EGameState.ERunGame)
      return;
    Singleton<LuaHotFixMgr>.GetInstance().RefreshUsingLua();
    this.m_bFinishDownLua = true;
    this.ShowVersion();
    if (!this.m_bStartPressed)
      return;
    this.txtLuaDownloadTips.text = "更新文件下载完成.";
    this.OnTouchStart();
  }

  private void ShowVersion()
  {
    if (GameConfig.IsChanelPackage)
      this.txtVersion.text = "Ver " + GameConfig.getClientVer + "_C_" + DenaLib.Singleton<GameLogic>.Instance.strLuaVersion;
    else
      this.txtVersion.text = "Ver " + GameConfig.getClientVer + "_" + DenaLib.Singleton<GameLogic>.Instance.strLuaVersion;
  }

  private void TestLuaBtnClick()
  {
    GameObject go = GameObject.Find("ibtn_sight3");
    if (!Object.op_Implicit((Object) go))
      return;
    go.AddComponent<UIEventListener>();
    UIButton component = go.GetComponent<UIButton>();
    if (!Object.op_Implicit((Object) component))
      return;
    component.onClick.Clear();
    UIEventListener.Get(go).onClick = new UIEventListener.VoidDelegate(this.BtnClickSight1);
  }

  private void BtnClickSight1(GameObject button)
  {
    Debug.LogError((object) ("BtnSight1 Clicked." + ((Object) button).name));
    this.ibtnBackEnd();
  }

  private void TransPopupCondition()
  {
    switch (this.pCond)
    {
      case TopScene.PopupCondition.NONE:
        this.ibtnBackQuit();
        break;
      case TopScene.PopupCondition.DATA_LOAD:
        this.DataLoadOff();
        break;
      case TopScene.PopupCondition.DATA_LOAD_WARNING:
        this.DataLoadWarningOff();
        break;
      case TopScene.PopupCondition.DATA_LOAD_SUCCESS:
        this.SuccessOff();
        break;
      case TopScene.PopupCondition.CLEAR_CACHE:
        this.popupDelete();
        break;
      case TopScene.PopupCondition.CLEAR_CACHE_WARNING:
        this.popupDelete();
        break;
      case TopScene.PopupCondition.GAME_END:
        this.popupDelete();
        break;
      case TopScene.PopupCondition.WEBVIEW:
        this.CloseWebView();
        break;
    }
  }

  public void ibtnBackEnd()
  {
    this.pCond = TopScene.PopupCondition.GAME_END;
    Consts instance = Consts.GetInstance();
    if (GameConfig.IsChanelPackage)
      this.Quit();
    else
      this.nowPopup = ((Component) ModalWindow.ShowYesNo(instance.gamequit_title, instance.gameexit_text, new System.Action(this.Quit), (System.Action) (() =>
      {
        this.pCond = TopScene.PopupCondition.NONE;
        this.nowPopup = (GameObject) null;
      }))).gameObject;
  }

  public void ibtnBackQuit()
  {
    this.pCond = TopScene.PopupCondition.GAME_END;
    Consts instance = Consts.GetInstance();
    if (GameConfig.IsChanelPackage)
      this.Quit();
    else
      this.nowPopup = ((Component) ModalWindow.ShowYesNo(instance.gamequit_title, instance.gameexit_text, new System.Action(this.Quit), (System.Action) (() =>
      {
        this.pCond = TopScene.PopupCondition.NONE;
        this.nowPopup = (GameObject) null;
      }))).gameObject;
  }

  private void popupDelete()
  {
    Object.DestroyObject((Object) this.nowPopup);
    this.pCond = TopScene.PopupCondition.NONE;
  }

  private void logout() => SDK.instance.LogOut(false);

  private void Quit()
  {
    Singleton<NGSoundManager>.GetInstance().StopBgm();
    SDK.instance.Quit();
  }

  private void Exit() => SDK.instance.Exit();

  public void SuccessOff()
  {
    this.Success.gameObject.SetActive(false);
    this.BackCollider.gameObject.SetActive(false);
    StartScript.Restart();
  }

  public void DataLoadOn() => this.ibtnBackEnd();

  public void IbtnPopupNext()
  {
    ((Component) this.data_load_warning).gameObject.SetActive(false);
    ((Component) this.data_load).gameObject.SetActive(true);
    this.data_load.InitDataCode();
    this.BackCollider.gameObject.SetActive(true);
    this.pCond = TopScene.PopupCondition.DATA_LOAD;
  }

  public void DataLoadWarningOff()
  {
    ((Component) this.data_load_warning).gameObject.SetActive(false);
    this.BackCollider.gameObject.SetActive(false);
    this.pCond = TopScene.PopupCondition.NONE;
  }

  public void IbtnPopupDecide()
  {
    this.data_load.MigrateAPI();
    ((Component) this.data_load).gameObject.SetActive(false);
    this.pCond = TopScene.PopupCondition.DATA_LOAD;
  }

  public void DataLoadOff()
  {
    ((Component) this.data_load).gameObject.SetActive(false);
    this.BackCollider.gameObject.SetActive(false);
    if (this.CodeError.activeSelf || this.InputBlock.activeSelf || this.SameTerminal.activeSelf)
      this.pCond = TopScene.PopupCondition.LOCK;
    else if (this.Success.activeSelf)
    {
      this.pCond = TopScene.PopupCondition.DATA_LOAD_SUCCESS;
      this.SuccessOff();
    }
    else
      this.pCond = TopScene.PopupCondition.NONE;
  }

  public void DeleteCacheOn()
  {
    Consts instance = Consts.GetInstance();
    if (Persist.battleEnvironment.Exists || Persist.pvpSuspend.Exists)
    {
      ModalWindow.ShowYesNo(instance.cache_clear_warning_title, instance.cache_clear_warning_body, (System.Action) (() =>
      {
        this.pCond = TopScene.PopupCondition.NONE;
        Persist.cacheInfo.Data.hasDeleted = true;
        Persist.cacheInfo.Flush();
        this.StartCoroutine(this.startClearCacheWithAutoSleep());
      }), (System.Action) (() => this.pCond = TopScene.PopupCondition.NONE));
      this.pCond = TopScene.PopupCondition.CLEAR_CACHE_WARNING;
    }
    else
    {
      ModalWindow modalWindow = ModalWindow.ShowYesNo(instance.clear_cache_title, instance.clear_cache_text, (System.Action) (() => this.StartCoroutine(this.startClearCacheWithAutoSleep())), (System.Action) (() => this.pCond = TopScene.PopupCondition.NONE));
      modalWindow.SetHeight(600);
      this.nowPopup = ((Component) modalWindow).gameObject;
      this.pCond = TopScene.PopupCondition.CLEAR_CACHE;
    }
  }

  [DebuggerHidden]
  private IEnumerator startClearCacheWithAutoSleep()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopScene.\u003CstartClearCacheWithAutoSleep\u003Ec__Iterator18B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator startClearCache()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopScene.\u003CstartClearCache\u003Ec__Iterator18C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OpenWebView()
  {
    if (Object.op_Equality((Object) this.m_webview, (Object) null))
      return;
    this.m_webview.Navigate();
    this.pCond = TopScene.PopupCondition.WEBVIEW;
  }

  public void CloseWebView()
  {
    if (Object.op_Equality((Object) this.m_webview, (Object) null))
      return;
    this.m_webview.Hide();
    this.pCond = TopScene.PopupCondition.NONE;
  }

  public void CodeErrorOff()
  {
    this.BackCollider.SetActive(false);
    this.CodeError.SetActive(false);
    this.pCond = TopScene.PopupCondition.NONE;
  }

  public void InputBlockOff()
  {
    this.InputBlock.SetActive(false);
    this.BackCollider.SetActive(false);
    this.pCond = TopScene.PopupCondition.NONE;
  }

  public void SameTerminalOff()
  {
    this.SameTerminal.SetActive(false);
    this.BackCollider.SetActive(false);
    this.pCond = TopScene.PopupCondition.NONE;
  }

  public void SceneChangeOPMovie()
  {
    if (!this.isIntoTouch)
      ;
  }

  private void Awake() => ModalWindow.setupRootPanel(this.uiRoot);

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopScene.\u003CStart\u003Ec__Iterator18D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OnTouchStart()
  {
    if (!this.EnablePressStartBtn)
      return;
    this.isIntoTouch = false;
    if (DenaLib.Singleton<GameLogic>.Instance.m_GameState == EGameState.ERunGame)
    {
      this.BackCollider.SetActive(true);
      this.pCond = TopScene.PopupCondition.LOCK;
      this.StartCoroutine(this.UserPolicy());
    }
    else
    {
      this.PressStart.SetActive(false);
      this.txtLuaDownloadTips.text = "正在下载更新文件（1KB）请稍等片刻.";
      this.m_bStartPressed = true;
    }
  }

  private void changeNextScene()
  {
    this.pCond = TopScene.PopupCondition.LOCK;
    this.StartCoroutine(this.changeNextSceneLoop());
  }

  [DebuggerHidden]
  private IEnumerator changeNextSceneLoop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopScene.\u003CchangeNextSceneLoop\u003Ec__Iterator18E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void finish()
  {
    if (!Object.op_Inequality((Object) this.loadingBG, (Object) null))
      return;
    this.loadingBG.SetActive(false);
  }

  [DebuggerHidden]
  public IEnumerator UserPolicy()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TopScene.\u003CUserPolicy\u003Ec__Iterator18F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetTextPolicy()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TopScene.\u003CSetTextPolicy\u003Ec__Iterator190 policyCIterator190 = new TopScene.\u003CSetTextPolicy\u003Ec__Iterator190();
    return (IEnumerator) policyCIterator190;
  }

  public GameObject agreementSource { get; set; }

  public enum PopupCondition
  {
    NONE,
    USER_POLICY,
    USER_POLICY_DISSENT,
    PLIVACY,
    DATA_LOAD,
    DATA_LOAD_WARNING,
    DATA_LOAD_SUCCESS,
    CLEAR_CACHE,
    CLEAR_CACHE_WARNING,
    GAME_END,
    LOCK,
    WEBVIEW,
  }
}
