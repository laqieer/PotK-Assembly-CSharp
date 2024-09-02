// Decompiled with JetBrains decompiler
// Type: CommonRoot
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
public class CommonRoot : Singleton<CommonRoot>
{
  public const int TIPS_LOADING = 0;
  public const int SIMPLE_LOADING = 1;
  public const int NONDISP_LOADING = 2;
  public CommonRoot.HeaderType headerType;
  public CommonRoot.FooterType footerType;
  [SerializeField]
  private GameObject[] headerObjects;
  [SerializeField]
  private CommonFooterBase[] footerObjects;
  public string startScene;
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
  private GameObject cloudAnimPrefab;
  private GameObject cloudAnim;
  public GuildChatManager guildChatManager;
  [SerializeField]
  private GameObject guildBadge;
  [SerializeField]
  private GameObject guildBadgeLabel;
  [SerializeField]
  private GameObject footerGachaButtonNewIcon;
  public int loadingMode;
  private string loadingTipsPrefabPath = "Prefabs/TipsLoadingPrefab";
  private GameObject loadingTipsPrefab;
  private string loadingSimplePrefabPath = "Prefabs/LoadingSimplePrefab";
  private GameObject loadingSimplePrefab;
  private string downloadGaugePrefab_path = "Prefabs/DownloadGauge";
  private GameObject downloadGaugePrefab;
  private GameObject curLoadingPrefab;
  private bool mIsTouchBlockAutoClose;
  private float mAutoCloseTimer;
  private bool mIsTouchBlock;
  private GameObject loadingObject;
  private bool mIsWebRunning;
  private bool mIsLoading;
  private bool mIsShowModalWindow;
  private bool isLoadingPrefabRes;

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
        ((IEnumerable<GameObject>) this.headerObjects).ToggleOnce((int) this.headerType);
      else
        ((IEnumerable<GameObject>) this.headerObjects).ToggleOnce(-1);
    }
  }

  public bool isActiveFooter
  {
    get => this.footerObjects[(int) this.footerType].isActive;
    set
    {
      if (value)
        ((IEnumerable<CommonFooterBase>) this.footerObjects).Select<CommonFooterBase, GameObject>((Func<CommonFooterBase, GameObject>) (x => ((Component) x).gameObject)).ToggleOnce((int) this.footerType);
      else
        ((IEnumerable<CommonFooterBase>) this.footerObjects).Select<CommonFooterBase, GameObject>((Func<CommonFooterBase, GameObject>) (x => ((Component) x).gameObject)).ToggleOnce(-1);
    }
  }

  public bool isActiveBlackBGPanel
  {
    get => this.blackBgTweenParts.isActive;
    set => this.blackBgTweenParts.isActive = value;
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRoot.\u003CStart\u003Ec__IteratorA5D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public int setBlackBGPanelDepth(int depth)
  {
    int depth1 = this.blackBgPanel.depth;
    this.blackBgPanel.depth = depth;
    return depth1;
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

  [DebuggerHidden]
  private IEnumerator closeTouchBlockAutoClose()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRoot.\u003CcloseTouchBlockAutoClose\u003Ec__IteratorA5E()
    {
      \u003C\u003Ef__this = this
    };
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
    }
  }

  public bool isShowModalWindow
  {
    get => this.mIsShowModalWindow;
    set => this.mIsShowModalWindow = value;
  }

  public bool isInputBlock
  {
    get => this.mIsTouchBlock || this.mIsWebRunning || this.mIsLoading || this.mIsShowModalWindow;
  }

  private void resetLoadingPrefab()
  {
    bool flag1 = this.mIsWebRunning || this.mIsLoading;
    bool flag2 = false;
    if (flag1)
    {
      if (Object.op_Equality((Object) this.loadingObject, (Object) null))
      {
        GameObject self;
        if (this.loadingMode == 1)
          self = this.loadingSimplePrefab;
        else if (this.loadingMode == 2)
        {
          self = (GameObject) null;
        }
        else
        {
          self = this.loadingTipsPrefab;
          flag2 = true;
        }
        if (Object.op_Inequality((Object) self, (Object) null))
        {
          this.loadingObject = self.Clone(((Component) this).transform);
          UIPanel component = this.loadingObject.GetComponent<UIPanel>();
          if (Object.op_Inequality((Object) component, (Object) null))
            component.SetAnchor(((Component) this).transform);
        }
        this.curLoadingPrefab = self;
      }
    }
    else if (Object.op_Inequality((Object) this.loadingObject, (Object) null))
    {
      Object.Destroy((Object) this.loadingObject);
      this.loadingObject = (GameObject) null;
      this.curLoadingPrefab = (GameObject) null;
    }
    if (!flag2)
      return;
    if (this.mIsLoading && !this.mIsWebRunning)
      this.setTipsTxt(this.loadingObject, true);
    if (!this.mIsWebRunning)
      return;
    this.setTipsTxt(this.loadingObject);
  }

  public void setTipsTxt(GameObject obj, bool isShow = false)
  {
    if (!Object.op_Inequality((Object) obj, (Object) null))
      return;
    CommonTips component = obj.GetComponent<CommonTips>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.setTipsTxtIsShow(isShow);
  }

  public DownloadGauge viewDownloadGauge()
  {
    if (Object.op_Equality((Object) this.loadingObject, (Object) null))
      return (DownloadGauge) null;
    if (Object.op_Inequality((Object) this.curLoadingPrefab, (Object) null) && Object.op_Inequality((Object) this.curLoadingPrefab, (Object) this.loadingTipsPrefab))
    {
      this.isLoading = false;
      this.loadingMode = 0;
      this.isLoading = true;
    }
    if (Object.op_Equality((Object) this.loadingObject, (Object) null))
      return (DownloadGauge) null;
    Transform childInFind = this.loadingObject.transform.GetChildInFind("Bottom");
    DownloadGauge downloadGauge = ((Component) childInFind).GetComponentInChildren<DownloadGauge>() ?? this.downloadGaugePrefab.CloneAndGetComponent<DownloadGauge>(childInFind);
    ((Component) downloadGauge).transform.localPosition = new Vector3(0.0f, -410f, 0.0f);
    this.setTipsTxt(this.loadingObject);
    return downloadGauge;
  }

  public void resetTouchBlockActive()
  {
    bool flag = !Singleton<PopupManager>.GetInstance().isOpenNoFinish && (this.mIsTouchBlock || this.mIsWebRunning || this.mIsLoading);
    if (Object.op_Inequality((Object) this.loadingObject, (Object) null))
      this.loadingObject.SetActive(flag);
    this.touchBlock.SetActive(flag);
  }

  public bool isViewFps
  {
    get => Object.op_Inequality((Object) this.fpsParts, (Object) null) && this.fpsParts.isActive;
    set
    {
      if (Object.op_Equality((Object) this.fpsParts, (Object) null))
        return;
      DebugFps instance = Singleton<DebugFps>.GetInstance();
      if (!Object.op_Inequality((Object) instance, (Object) null))
        return;
      this.fpsParts.isActive = value;
      ((Behaviour) instance).enabled = value;
    }
  }

  public void UpdateFooterGachaButton()
  {
    DateTime? gachaLatestStartTime = Singleton<NGGameDataManager>.GetInstance().gachaLatestStartTime;
    DateTime rootLastAccessTime = Persist.lastAccessTime.Data.gachaRootLastAccessTime;
    this.footerGachaButtonNewIcon.SetActive(gachaLatestStartTime.HasValue && gachaLatestStartTime.Value > rootLastAccessTime);
  }

  protected override void Initialize()
  {
    this.SetGuildFooterBadge(false);
    this.downloadGaugePrefab = Resources.Load(this.downloadGaugePrefab_path) as GameObject;
    ((IEnumerable<GameObject>) this.headerObjects).ToggleOnce(-1);
    ((IEnumerable<CommonFooterBase>) this.footerObjects).ForEach<CommonFooterBase>((Action<CommonFooterBase>) (x => ((Component) x).gameObject.SetActive(false)));
    ModalWindow.setupRootPanel(((Component) this).GetComponent<UIRoot>());
    this.StartCoroutine(this.bootSequenceLoop());
  }

  [DebuggerHidden]
  private IEnumerator bootSequenceLoop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRoot.\u003CbootSequenceLoop\u003Ec__IteratorA5F()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void InitLoadPrefabRes()
  {
    if (this.isLoadingPrefabRes || Object.op_Inequality((Object) this.loadingTipsPrefab, (Object) null))
      return;
    this.isLoadingPrefabRes = true;
    Future<object> f2 = Future.WhenAllThen<GameObject, object>(Singleton<ResourceManager>.GetInstance().Load<GameObject>(this.loadingTipsPrefabPath), (Func<GameObject, object>) (p =>
    {
      this.loadingTipsPrefab = p;
      this.isLoadingPrefabRes = false;
      return (object) null;
    }));
    Future.WhenAllThen<GameObject, object>(Singleton<ResourceManager>.GetInstance().Load<GameObject>(this.loadingSimplePrefabPath), (Func<GameObject, object>) (p =>
    {
      this.loadingSimplePrefab = p;
      this.loadingSimplePrefab.SetActive(true);
      f2.RunOn<object>((MonoBehaviour) this);
      return (object) null;
    })).RunOn<object>((MonoBehaviour) this);
  }

  public void ShowLoadingTips(bool bShow)
  {
    if (Object.op_Equality((Object) this.loadingTipsPrefab, (Object) null))
      return;
    if (bShow)
    {
      this.loadingMode = 0;
      this.isLoading = true;
    }
    else
      this.isLoading = false;
  }

  public CommonColosseumHeader GetColosseumHeaderComponent()
  {
    return this.headerObjects[1].GetComponent<CommonColosseumHeader>();
  }

  public void DisableColosseumHeaderBtn()
  {
    CommonColosseumHeader colosseumHeaderComponent = this.GetColosseumHeaderComponent();
    if (!Object.op_Inequality((Object) colosseumHeaderComponent, (Object) null))
      return;
    colosseumHeaderComponent.DisableBtn();
  }

  public CommonEarthHeader GetEarthHeaderComponent()
  {
    return this.headerObjects[2].GetComponent<CommonEarthHeader>();
  }

  public void EnableEarthHeader()
  {
    this.headerType = CommonRoot.HeaderType.Earth;
    this.isActiveHeader = true;
  }

  public void SetFooterEnable(bool enable) => this.footerDisableObject.SetActive(!enable);

  [DebuggerHidden]
  private IEnumerator loadDefaultBackground()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRoot.\u003CloadDefaultBackground\u003Ec__IteratorA60()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadCloudAnim()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRoot.\u003CloadCloudAnim\u003Ec__IteratorA61()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void DisableCloudAnim() => Object.Destroy((Object) this.cloudAnim);

  [DebuggerHidden]
  public IEnumerator StartCloudAnim(string startName, string endName, System.Action waitAction)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRoot.\u003CStartCloudAnim\u003Ec__IteratorA62()
    {
      startName = startName,
      endName = endName,
      waitAction = waitAction,
      \u003C\u0024\u003EstartName = startName,
      \u003C\u0024\u003EendName = endName,
      \u003C\u0024\u003EwaitAction = waitAction,
      \u003C\u003Ef__this = this
    };
  }

  public void StartCloudAnimEnd(System.Action reelAnmAction)
  {
    this.cloudAnim.GetComponent<MypageCloudAnim>().End(reelAnmAction);
  }

  public void StartBGTween(int groupID)
  {
    ((IEnumerable<UITweener>) ((Component) this.bgRoot).GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      if (x.tweenGroup != groupID)
        return;
      ((Component) x).gameObject.SetActive(true);
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  public void setBackground(GameObject prefab)
  {
    if (Object.op_Equality((Object) prefab, (Object) null))
    {
      if (Object.op_Equality((Object) this.defaultBackgroudPrefab, (Object) null))
        this.StartCoroutine(this.loadDefaultBackground());
      else
        this.bgRoot.setBackground(this.defaultBackgroudPrefab);
    }
    else
    {
      this.defaultBackgroudPrefab = (GameObject) null;
      this.bgRoot.setBackground(prefab);
    }
  }

  public void releaseBackground() => this.bgRoot.releaseBackground();

  public bool ComparisonBackground(GameObject prefab) => this.bgRoot.ComparisonBackground(prefab);

  public bool hasBackground() => this.bgRoot.hasBackground();

  public T getBackgroundComponent<T>() where T : Component
  {
    return Object.op_Inequality((Object) this.bgRoot.Current, (Object) null) ? this.bgRoot.Current.GetComponent<T>() : (T) null;
  }

  public Camera getCamera() => this.uiCamera;

  public void SetGuildFooterBadge(bool badge, bool label = false)
  {
    if (Singleton<NGGameDataManager>.GetInstance().IsEarth)
      return;
    this.guildBadge.SetActive(badge);
    this.guildBadgeLabel.SetActive(label);
  }

  public bool GuildFooterBadgeVisible()
  {
    if (Singleton<NGGameDataManager>.GetInstance().IsEarth)
      return false;
    return this.guildBadge.activeSelf || this.guildBadgeLabel.activeSelf;
  }

  public void DisableGuildFooterBadge()
  {
    if (Singleton<NGGameDataManager>.GetInstance().IsEarth)
      return;
    if (!Persist.guildSetting.Exists)
    {
      this.SetGuildFooterBadge(false);
    }
    else
    {
      if (GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.startHuntingEvent) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.receiveHuntingReward) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newMember) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newGift))
        return;
      this.SetGuildFooterBadge(false);
    }
  }

  public enum HeaderType
  {
    Normal,
    Colosseum,
    Earth,
    Keep,
  }

  public enum FooterType
  {
    Normal,
    Earth,
    Keep,
  }
}
