// Decompiled with JetBrains decompiler
// Type: CommonRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using AppSetup;
using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class CommonRoot : Singleton<CommonRoot>
{
  public CommonRoot.HeaderType headerType;
  public CommonRoot.FooterType footerType;
  [SerializeField]
  private GameObject[] headerObjects;
  [SerializeField]
  private CommonFooterBase[] footerObjects;
  [SerializeField]
  private string startScene_;
  [SerializeField]
  private GameObject defaultBackgroudPrefab;
  [SerializeField]
  private NGTweenParts fpsParts;
  [SerializeField]
  private GameObject background3DCamera;
  [SerializeField]
  private GameObject uiMask3D;
  [SerializeField]
  private Camera uiCamera;
  [SerializeField]
  private CommonBackground bgRoot;
  [SerializeField]
  private UIPanel blackBgPanel;
  [SerializeField]
  private NGTweenParts blackBgTweenParts;
  [SerializeField]
  private GameObject touchBlock;
  [SerializeField]
  private GameObject footerDisableObject;
  [SerializeField]
  private GameObject touchBlockAutoClose;
  [SerializeField]
  private GameObject cloudAnimObject;
  public GameObject unitMenuParent;
  [SerializeField]
  private GameObject loadTmpObj;
  private GameObject cloudAnimPrefab;
  private GameObject cloudAnim;
  public GuildChatManager guildChatManager;
  [SerializeField]
  private GameObject guildBadgeLabelEntry;
  [SerializeField]
  private GameObject guildBadgeLabelPrepare;
  [SerializeField]
  private GameObject guildBadgeLabelBattle;
  [SerializeField]
  private GameObject guildBadgeLabelMatch;
  [SerializeField]
  private GameObject headerStoneBikkuriIcon;
  [SerializeField]
  private GameObject footerGachaButtonNewIcon;
  [SerializeField]
  private GameObject footerLimitedShopButtonNewIcon;
  [SerializeField]
  private GameObject footerNewbiePacksIcon;
  [SerializeField]
  private GameObject footerBikkuriIcon;
  [SerializeField]
  private Animator fadeAnime;
  public const int TIPS_LOADING = 0;
  public const int SIMPLE_LOADING = 1;
  public const int NONDISP_LOADING = 2;
  public const int BLACK_LOADING = 3;
  public const int TEXT_TIPS_LOADING = 4;
  public int loadingMode = 4;
  private string loadingTipsPrefabPath = "Prefabs/common/Loading/TipsLoadingPrefab";
  private GameObject loadingTipsPrefab;
  private string loadingSimplePrefabPath = "Prefabs/common/Loading/LoadingSimplePrefab";
  private GameObject loadingSimplePrefab;
  private string downloadGaugePrefab_path = "Prefabs/common/Loading/DownloadGauge";
  private GameObject downloadGaugePrefab;
  private string loadingTextTipsPrefabPath = "Prefabs/common/Loading/TipsLoadingPrefab_text";
  private GameObject loadingTextTipsPrefab;
  public DailyMissionController DailyMissionController;
  public DisplayTouchEffectController TouchEffectController;
  private bool _isSeaGlobalMenuOpen;
  private bool mIsTouchBlockAutoClose;
  private float mAutoCloseTimer;
  private bool mIsTouchBlock;
  private GameObject loadingObject;
  private bool mIsWebRunning;
  private bool mIsLoading;
  private bool isForceLoadingPanel;
  private bool mIsShowModalWindow;

  public string startScene => this.startScene_;

  public object[] startSceneArgs { get; private set; } = new object[0];

  public void setStartScene(string name, object[] args = null)
  {
    this.startScene_ = name;
    if (args != null && args.Length != 0)
    {
      this.startSceneArgs = args;
    }
    else
    {
      if (this.startSceneArgs.Length == 0)
        return;
      this.startSceneArgs = new object[0];
    }
  }

  public GameObject LoadTmpObj => this.loadTmpObj;

  public bool IsBootSetuped { get; private set; }

  public bool isActiveBackground3DCamera
  {
    get => this.background3DCamera.gameObject.activeSelf;
    set
    {
      if (this.background3DCamera.gameObject.activeSelf == value)
        return;
      this.background3DCamera.gameObject.SetActive(value);
    }
  }

  public bool isActive3DUIMask
  {
    get => this.uiMask3D.gameObject.activeSelf;
    set
    {
      if (this.uiMask3D.gameObject.activeSelf == value)
        return;
      this.uiMask3D.gameObject.SetActive(value);
    }
  }

  public bool isActiveBackground
  {
    get => this.bgRoot.isActive;
    set => this.bgRoot.isActive = value;
  }

  public bool isActiveHeader
  {
    get => this.headerObjects[(int) this.headerType].activeSelf;
    set
    {
      if (value)
        ((IEnumerable<GameObject>) this.headerObjects).ToggleOnceEx((int) this.headerType);
      else
        ((IEnumerable<GameObject>) this.headerObjects).ToggleOnceEx(-1);
    }
  }

  public bool isActiveFooter
  {
    get => this.footerObjects[(int) this.footerType].isActive;
    set
    {
      if (value)
        ((IEnumerable<CommonFooterBase>) this.footerObjects).Select<CommonFooterBase, GameObject>((Func<CommonFooterBase, GameObject>) (x => x.gameObject)).ToggleOnce((int) this.footerType);
      else
        ((IEnumerable<CommonFooterBase>) this.footerObjects).Select<CommonFooterBase, GameObject>((Func<CommonFooterBase, GameObject>) (x => x.gameObject)).ToggleOnce(-1);
    }
  }

  public bool isActiveHomeMenu => this.footerType == CommonRoot.FooterType.Normal && this.footerObjects[0].GetComponent<CommonFooter>().IsActiveMyPageMenuPopup;

  public bool isSeaGlobalMenuOpen
  {
    get => this._isSeaGlobalMenuOpen;
    set => this._isSeaGlobalMenuOpen = value;
  }

  public bool isActiveBlackBGPanel
  {
    get => this.blackBgTweenParts.isActive;
    set => this.blackBgTweenParts.isActive = value;
  }

  public void forceActiveBlackBGPanel(bool enable)
  {
    this.blackBgTweenParts.resetActive(enable);
    this.blackBgTweenParts.GetComponentInChildren<UIWidget>().alpha = enable ? 1f : 0.0f;
  }

  public int setBlackBGPanelDepth(int depth)
  {
    int depth1 = this.blackBgPanel.depth;
    this.blackBgPanel.depth = depth;
    return depth1;
  }

  public int getBlackBGPanelDepth() => this.blackBgPanel.depth;

  public CommonFooter GetHeavenCommonFooter() => this.footerType == CommonRoot.FooterType.Normal ? this.footerObjects[0].GetComponent<CommonFooter>() : (CommonFooter) null;

  public void ActiveBaseHomeMenu(bool active)
  {
    if (this.footerType != CommonRoot.FooterType.Normal)
      return;
    this.footerObjects[0].GetComponent<CommonFooter>().ActiveHomeFooter(active);
  }

  public void setDisableFooterColor(bool isActive)
  {
    if (isActive)
      this.footerObjects[(int) this.footerType].setDisableColor();
    else
      this.footerObjects[(int) this.footerType].resetDisableColor();
  }

  public bool isTouchBlockAutoClose
  {
    get => this.mIsTouchBlockAutoClose;
    set
    {
      if (value)
      {
        this.mAutoCloseTimer = 0.05f;
        if (!this.mIsTouchBlockAutoClose)
          this.openTouchBlockAutoClose();
        this.mIsTouchBlockAutoClose = true;
      }
      else
      {
        if ((double) this.mAutoCloseTimer >= 0.0)
          return;
        this.mIsTouchBlockAutoClose = false;
      }
    }
  }

  private void openTouchBlockAutoClose()
  {
    this.touchBlockAutoClose.SetActive(true);
    this.StartCoroutine(this.closeTouchBlockAutoClose());
  }

  private IEnumerator closeTouchBlockAutoClose()
  {
    do
    {
      this.mAutoCloseTimer -= Time.deltaTime;
      yield return (object) null;
    }
    while ((double) this.mAutoCloseTimer >= 0.0);
    this.touchBlockAutoClose.SetActive(false);
    this.isTouchBlockAutoClose = false;
  }

  public bool isTouchBlock
  {
    get => this.mIsTouchBlock;
    set
    {
      if (this.mIsTouchBlock != value)
        this.mIsTouchBlock = value;
      this.resetTouchBlockActive();
    }
  }

  public bool isWebRunning
  {
    get => this.isWebRunning;
    set
    {
      if (this.mIsWebRunning != value)
      {
        this.mIsWebRunning = value;
        this.resetLoadingPrefab();
      }
      this.resetTouchBlockActive();
    }
  }

  public bool isLoading
  {
    get => this.mIsLoading;
    set
    {
      if (this.mIsLoading != value)
      {
        this.mIsLoading = value;
        this.resetLoadingPrefab();
      }
      this.resetTouchBlockActive();
      if (this.mIsLoading)
      {
        AppSetupFPS.SetMaxFPS(60);
        Application.backgroundLoadingPriority = ThreadPriority.High;
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
          return;
        QualitySettings.asyncUploadTimeSlice = 33;
      }
      else
      {
        AppSetupFPS.SetDefault();
        Application.backgroundLoadingPriority = ThreadPriority.Normal;
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
          return;
        QualitySettings.asyncUploadTimeSlice = 10;
      }
    }
  }

  public void ShowLoadingLayer(int mode, bool isForceLoadingPanel = false)
  {
    this.loadingMode = mode;
    this.isForceLoadingPanel = isForceLoadingPanel;
    this.isLoading = true;
  }

  public void HideLoadingLayer()
  {
    this.isLoading = false;
    this.isForceLoadingPanel = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }

  public bool isShowModalWindow
  {
    get => this.mIsShowModalWindow;
    set => this.mIsShowModalWindow = value;
  }

  public bool isInputBlock => this.mIsTouchBlock || this.mIsWebRunning || this.mIsLoading || this.mIsShowModalWindow;

  public bool getCloudAnimEnabled() => !((UnityEngine.Object) this.cloudAnim == (UnityEngine.Object) null) && this.cloudAnim.GetComponent<MypageCloudAnim>().getReelTweenActionEnabled();

  private void resetLoadingPrefab()
  {
    if ((this.mIsWebRunning ? 1 : (this.mIsLoading ? 1 : 0)) != 0)
    {
      if ((UnityEngine.Object) this.loadingObject == (UnityEngine.Object) null)
      {
        GameObject self;
        switch (this.loadingMode)
        {
          case 0:
          case 3:
            self = this.loadingTipsPrefab;
            break;
          case 1:
            self = this.loadingSimplePrefab;
            break;
          case 2:
            self = (GameObject) null;
            break;
          case 4:
            self = this.loadingTextTipsPrefab;
            break;
          default:
            self = (GameObject) null;
            break;
        }
        if ((UnityEngine.Object) self != (UnityEngine.Object) null)
        {
          this.loadingObject = self.Clone(this.transform);
          if (this.loadingMode == 3 || this.loadingMode == 0 && (UnityEngine.Object) this.cloudAnim != (UnityEngine.Object) null && this.cloudAnim.activeInHierarchy)
            this.loadingObject.GetComponent<CommonTips>().SetBlackGround();
          UIPanel component = this.loadingObject.GetComponent<UIPanel>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
            component.SetAnchor(this.transform);
        }
      }
      if (!((UnityEngine.Object) Singleton<NGMessageUI>.GetInstance() != (UnityEngine.Object) null))
        return;
      Singleton<NGMessageUI>.GetInstance().TurnOff();
    }
    else
    {
      if (!((UnityEngine.Object) this.loadingObject != (UnityEngine.Object) null))
        return;
      this.isForceLoadingPanel = false;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.loadingObject);
      this.loadingObject = (GameObject) null;
    }
  }

  public DownloadGauge viewDownloadGauge()
  {
    if ((UnityEngine.Object) this.loadingObject == (UnityEngine.Object) null)
      return (DownloadGauge) null;
    Transform childInFind = this.loadingObject.transform.GetChildInFind("Bottom");
    DownloadGauge downloadGauge = childInFind.GetComponentInChildren<DownloadGauge>(true);
    if ((UnityEngine.Object) downloadGauge == (UnityEngine.Object) null)
    {
      downloadGauge = this.downloadGaugePrefab.CloneAndGetComponent<DownloadGauge>(childInFind.transform);
      downloadGauge.transform.localPosition = new Vector3(0.0f, -410f, 0.0f);
    }
    downloadGauge.gameObject.SetActive(true);
    return downloadGauge;
  }

  public void resetTouchBlockActive()
  {
    bool flag = (!Singleton<PopupManager>.GetInstance().isOpenNoFinish ? 1 : (this.isForceLoadingPanel ? 1 : 0)) != 0 && (this.mIsTouchBlock || this.mIsWebRunning || this.mIsLoading);
    if ((UnityEngine.Object) this.loadingObject != (UnityEngine.Object) null)
      this.loadingObject.SetActive(flag);
    this.touchBlock.SetActive(flag);
  }

  public bool isViewFps
  {
    get => (UnityEngine.Object) this.fpsParts != (UnityEngine.Object) null && this.fpsParts.isActive;
    set
    {
      if ((UnityEngine.Object) this.fpsParts == (UnityEngine.Object) null)
        return;
      DebugFps instance = Singleton<DebugFps>.GetInstance();
      if (!((UnityEngine.Object) instance != (UnityEngine.Object) null))
        return;
      this.fpsParts.isActive = value;
      instance.enabled = value;
    }
  }

  public void UpdateFooterGachaButton()
  {
    DateTime? gachaLatestStartTime = Singleton<NGGameDataManager>.GetInstance().gachaLatestStartTime;
    DateTime rootLastAccessTime = Persist.lastAccessTime.Data.gachaRootLastAccessTime;
    GameObject gachaButtonNewIcon = this.footerGachaButtonNewIcon;
    DateTime? nullable = gachaLatestStartTime;
    DateTime dateTime = rootLastAccessTime;
    int num = nullable.HasValue ? (nullable.GetValueOrDefault() > dateTime ? 1 : 0) : 0;
    gachaButtonNewIcon.SetActive(num != 0);
  }

  public IEnumerator UpdateFooterLimitedShopButton()
  {
    if (Singleton<NGGameDataManager>.GetInstance().receivableGift)
      this.footerLimitedShopButtonNewIcon.SetActive(false);
    else if (Singleton<NGGameDataManager>.GetInstance().newbiePacks)
    {
      this.footerLimitedShopButtonNewIcon.SetActive(false);
    }
    else
    {
      IEnumerator e = ServerTime.WaitSync();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.footerLimitedShopButtonNewIcon.SetActive(ShopCommon.IsNewLimitedShop(ServerTime.NowAppTime()));
    }
  }

  public void SetFooterExploreButtonEnable(bool enable) => this.GetHeavenCommonFooter().enableExploreButton(enable);

  public void UpdateHeaderBikkuriIcon()
  {
    if (Singleton<NGGameDataManager>.GetInstance().receivableGift)
      this.headerStoneBikkuriIcon.SetActive(true);
    else
      this.headerStoneBikkuriIcon.SetActive(false);
  }

  public void UpdateFooterNewbiePacksIcon()
  {
    if (Singleton<NGGameDataManager>.GetInstance().newbiePacks)
    {
      this.footerNewbiePacksIcon.SetActive(true);
      this.footerLimitedShopButtonNewIcon.SetActive(false);
      this.footerBikkuriIcon.SetActive(false);
    }
    else
      this.footerNewbiePacksIcon.SetActive(false);
  }

  public void UpdateFooterBikkuriIcon()
  {
    if (Singleton<NGGameDataManager>.GetInstance().receivableGift)
    {
      this.footerBikkuriIcon.SetActive(true);
      this.footerNewbiePacksIcon.SetActive(false);
      this.footerLimitedShopButtonNewIcon.SetActive(false);
    }
    else
      this.footerBikkuriIcon.SetActive(false);
  }

  public IEnumerator UpdateAllButtonBadges()
  {
    IEnumerator e = this.UpdateFooterLimitedShopButton();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.UpdateFooterGachaButton();
    this.UpdateHeaderBikkuriIcon();
    this.UpdateFooterBikkuriIcon();
    this.UpdateFooterNewbiePacksIcon();
  }

  protected override void Initialize()
  {
    StatusBarHelper.SetVisibilityForIPhoneX(true);
    if (IOSUtil.IsDeviceGenerationiPhoneX)
      SafeAreaBandRoot.ShowSafeAreaBand();
    ((IEnumerable<GameObject>) this.headerObjects).ToggleOnceEx(-1);
    ((IEnumerable<CommonFooterBase>) this.footerObjects).ForEach<CommonFooterBase>((System.Action<CommonFooterBase>) (x => x.gameObject.SetActive(false)));
    ModalWindow.setupRootPanel(this.GetComponent<UIRoot>());
    this.StartCoroutine(this.bootSequenceLoop());
    Transform transform1 = this.transform.Find("FrontPanel/LeftMask");
    if ((UnityEngine.Object) transform1 != (UnityEngine.Object) null)
      transform1.GetComponent<UI2DSprite>().updateAnchors = UIRect.AnchorUpdate.OnUpdate;
    Transform transform2 = this.transform.Find("FrontPanel/RightMask");
    if (!((UnityEngine.Object) transform2 != (UnityEngine.Object) null))
      return;
    transform2.GetComponent<UI2DSprite>().updateAnchors = UIRect.AnchorUpdate.OnUpdate;
  }

  private IEnumerator bootSequenceLoop()
  {
    CommonRoot commonRoot = this;
    IEnumerator e = Singleton<ResourceManager>.GetInstance().LoadResource(commonRoot.gameObject);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    SceneManager.LoadScene("tutorial", LoadSceneMode.Additive);
    while ((UnityEngine.Object) Singleton<TutorialRoot>.GetInstanceOrNull() == (UnityEngine.Object) null)
      yield return (object) null;
    while (Singleton<TutorialRoot>.GetInstance().IsInitilizing)
      yield return (object) null;
    Future<object> f2 = Future.WhenAllThen<GameObject, object>(Singleton<ResourceManager>.GetInstance().Load<GameObject>(commonRoot.loadingTipsPrefabPath), (Func<GameObject, object>) (p =>
    {
      this.loadingTipsPrefab = p;
      this.isLoading = true;
      this.IsBootSetuped = true;
      if (!PerformanceConfig.GetInstance().IsTuningTitleToHome)
        Singleton<NGGameDataManager>.GetInstance().bootFirstScene(this.startScene);
      return (object) null;
    }));
    Future<object> f4 = Future.WhenAllThen<GameObject, object>(Singleton<ResourceManager>.GetInstance().Load<GameObject>(commonRoot.loadingSimplePrefabPath), (Func<GameObject, object>) (p =>
    {
      this.loadingSimplePrefab = p;
      f2.RunOn<object>((MonoBehaviour) this);
      return (object) null;
    }));
    Future<object> f6 = Future.WhenAllThen<GameObject, object>(Singleton<ResourceManager>.GetInstance().Load<GameObject>(commonRoot.loadingTextTipsPrefabPath), (Func<GameObject, object>) (p =>
    {
      this.loadingTextTipsPrefab = p;
      f4.RunOn<object>((MonoBehaviour) this);
      return (object) null;
    }));
    Future.WhenAllThen<GameObject, object>(Singleton<ResourceManager>.GetInstance().Load<GameObject>(commonRoot.downloadGaugePrefab_path), (Func<GameObject, object>) (p =>
    {
      this.downloadGaugePrefab = p;
      f6.RunOn<object>((MonoBehaviour) this);
      return (object) null;
    })).RunOn<object>((MonoBehaviour) commonRoot);
    Singleton<CommonRoot>.GetInstance().StartCoroutine(Singleton<CommonRoot>.GetInstance().LoadCommonResources());
  }

  private IEnumerator LoadCommonResources()
  {
    IEnumerator e = Singleton<NGGameDataManager>.GetInstance().LoadResideResources();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = Singleton<NGGameDataManager>.GetInstance().LoadOtherBattleAtlas();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public CommonHeader GetNormalHeaderComponent() => this.headerObjects[0].GetComponent<CommonHeader>();

  public CommonColosseumHeader GetColosseumHeaderComponent() => this.headerObjects[1].GetComponent<CommonColosseumHeader>();

  public void DisableColosseumHeaderBtn()
  {
    CommonColosseumHeader colosseumHeaderComponent = this.GetColosseumHeaderComponent();
    if (!((UnityEngine.Object) colosseumHeaderComponent != (UnityEngine.Object) null))
      return;
    colosseumHeaderComponent.DisableBtn();
  }

  public CommonEarthHeader GetEarthHeaderComponent() => this.headerObjects[2].GetComponent<CommonEarthHeader>();

  public void EnableEarthHeader()
  {
    this.headerType = CommonRoot.HeaderType.Earth;
    this.isActiveHeader = true;
  }

  public void SetFooterEnable(bool enable)
  {
    this.footerDisableObject.SetActive(!enable);
    if (enable)
      return;
    foreach (CommonFooterBase footerObject in this.footerObjects)
    {
      CommonFooter commonFooter = footerObject as CommonFooter;
      if ((UnityEngine.Object) commonFooter != (UnityEngine.Object) null)
        commonFooter.CloseSubMenu();
    }
  }

  public bool GetFooterEnable() => !this.footerDisableObject.activeSelf;

  public CommonTowerHeader GetTowerHeaderComponent() => this.headerObjects[4].GetComponent<CommonTowerHeader>();

  public CommonCorpsHeader GetCorpsHeader() => this.headerObjects[7].GetComponent<CommonCorpsHeader>();

  public CommonSeaHeader GetSeaHeaderComponent() => this.headerObjects[5].GetComponent<CommonSeaHeader>();

  private IEnumerator loadDefaultBackground()
  {
    Future<GameObject> prefabF = Res.Prefabs.BackGround.DefaultBackground.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject result = prefabF.Result;
    this.bgRoot.setBackground(result);
    this.defaultBackgroudPrefab = result;
  }

  private IEnumerator loadCloudAnim()
  {
    if ((UnityEngine.Object) this.cloudAnimPrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> prefabF = Res.Prefabs.mypage.CloudAnimator.Load<GameObject>();
      IEnumerator e = prefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.cloudAnimPrefab = prefabF.Result;
      prefabF = (Future<GameObject>) null;
    }
    this.cloudAnim = UnityEngine.Object.Instantiate<GameObject>(this.cloudAnimPrefab);
    this.cloudAnim.SetParent(this.cloudAnimObject.gameObject);
  }

  public void DisableCloudAnim()
  {
    UnityEngine.Object.Destroy((UnityEngine.Object) this.cloudAnim);
    this.cloudAnim = (GameObject) null;
  }

  public IEnumerator StartCloudAnim(string startName, string endName, System.Action waitAction)
  {
    IEnumerator e = this.loadCloudAnim();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) this.cloudAnim != (UnityEngine.Object) null)
    {
      this.cloudAnim.GetComponent<MypageCloudAnim>().Init(startName, endName, waitAction);
      this.cloudAnim.GetComponent<MypageCloudAnim>().Start();
    }
  }

  public void StartCloudAnimEnd(System.Action reelAnmAction) => this.cloudAnim.GetComponent<MypageCloudAnim>().End(reelAnmAction);

  public void StartBGTween(int groupID) => ((IEnumerable<UITweener>) this.bgRoot.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((System.Action<UITweener>) (x =>
  {
    if (x.tweenGroup != groupID)
      return;
    x.gameObject.SetActive(true);
    x.ResetToBeginning();
    x.PlayForward();
  }));

  public void setBackground(GameObject prefab)
  {
    if ((UnityEngine.Object) prefab == (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.defaultBackgroudPrefab == (UnityEngine.Object) null)
        this.StartCoroutine(this.loadDefaultBackground());
      else
        this.bgRoot.setBackground(this.defaultBackgroudPrefab);
    }
    else
      this.bgRoot.setBackground(prefab);
  }

  public IEnumerator setBackgroundAsync(GameObject prefab)
  {
    if ((UnityEngine.Object) prefab == (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.defaultBackgroudPrefab == (UnityEngine.Object) null)
      {
        IEnumerator e = this.loadDefaultBackground();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      else
        this.bgRoot.setBackground(this.defaultBackgroudPrefab);
    }
    else
      this.bgRoot.setBackground(prefab);
  }

  public void releaseBackground() => this.bgRoot.releaseBackground();

  public bool ComparisonBackground(GameObject prefab) => this.bgRoot.ComparisonBackground(prefab);

  public bool hasBackground() => this.bgRoot.hasBackground();

  public CommonBackground getCommonBackground() => this.bgRoot;

  public T getBackgroundComponent<T>() where T : Component => !((UnityEngine.Object) this.bgRoot.Current != (UnityEngine.Object) null) ? default (T) : this.bgRoot.Current.GetComponent<T>();

  public Camera getCamera() => this.uiCamera;

  public void SetGuildFooterBadgeLabel(GuildUtil.GuildBadgeLabelType labelType)
  {
    if (Singleton<NGGameDataManager>.GetInstance().IsEarth)
      return;
    this.guildBadgeLabelEntry.SetActive(false);
    this.guildBadgeLabelPrepare.SetActive(false);
    this.guildBadgeLabelBattle.SetActive(false);
    this.guildBadgeLabelMatch.SetActive(false);
    if (labelType == GuildUtil.GuildBadgeLabelType.none)
      return;
    this.guildBadgeLabelEntry.SetActive(labelType == GuildUtil.GuildBadgeLabelType.entry);
    this.guildBadgeLabelPrepare.SetActive(labelType == GuildUtil.GuildBadgeLabelType.prepare);
    this.guildBadgeLabelBattle.SetActive(labelType == GuildUtil.GuildBadgeLabelType.battle);
    this.guildBadgeLabelMatch.SetActive(labelType == GuildUtil.GuildBadgeLabelType.matching);
  }

  public void WhiteFadeIn() => this.fadeAnime.Play("White_FadeIn");

  public void WhiteFadeOut() => this.fadeAnime.Play("White_FadeOut");

  public enum HeaderType
  {
    Normal,
    Colosseum,
    Earth,
    Keep,
    Tower,
    Sea,
    NormalOrSea,
    Corps,
  }

  public enum FooterType
  {
    Normal,
    Earth,
    Keep,
  }
}
