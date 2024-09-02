// Decompiled with JetBrains decompiler
// Type: CommonRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  public int loadingMode;
  private string loadingTipsPrefabPath = "Prefabs/TipsLoadingPrefab";
  private GameObject loadingTipsPrefab;
  private string loadingSimplePrefabPath = "Prefabs/LoadingSimplePrefab";
  private GameObject loadingSimplePrefab;
  private string downloadGaugePrefab_path = "Prefabs/DownloadGauge";
  private GameObject downloadGaugePrefab;
  private bool mIsTouchBlockAutoClose;
  private float mAutoCloseTimer;
  private bool mIsTouchBlock;
  private GameObject loadingObject;
  private bool mIsWebRunnig;
  private bool mIsLoading;
  private bool mIsShowModalWindow;

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
    return (IEnumerator) new CommonRoot.\u003CcloseTouchBlockAutoClose\u003Ec__Iterator8CC()
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

  public bool isWebRunnig
  {
    get => this.mIsWebRunnig;
    set
    {
      if (this.mIsWebRunnig != value)
      {
        this.mIsWebRunnig = value;
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
    get => this.mIsTouchBlock || this.mIsWebRunnig || this.mIsLoading || this.mIsShowModalWindow;
  }

  private void resetLoadingPrefab()
  {
    if (this.mIsWebRunnig || this.mIsLoading)
    {
      if (!Object.op_Equality((Object) this.loadingObject, (Object) null))
        return;
      GameObject self = this.loadingMode != 1 ? (this.loadingMode != 2 ? this.loadingTipsPrefab : (GameObject) null) : this.loadingSimplePrefab;
      if (!Object.op_Inequality((Object) self, (Object) null))
        return;
      this.loadingObject = self.Clone(((Component) this).transform);
      UIPanel component = this.loadingObject.GetComponent<UIPanel>();
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      component.SetAnchor(((Component) this).transform);
    }
    else
    {
      if (!Object.op_Inequality((Object) this.loadingObject, (Object) null))
        return;
      Object.Destroy((Object) this.loadingObject);
      this.loadingObject = (GameObject) null;
    }
  }

  public DownloadGauge viewDownloadGauge()
  {
    if (Object.op_Equality((Object) this.loadingObject, (Object) null))
      return (DownloadGauge) null;
    Transform childInFind = this.loadingObject.transform.GetChildInFind("Bottom");
    DownloadGauge downloadGauge = ((Component) childInFind).GetComponentInChildren<DownloadGauge>() ?? this.downloadGaugePrefab.CloneAndGetComponent<DownloadGauge>(childInFind);
    ((Component) downloadGauge).transform.localPosition = new Vector3(0.0f, -410f, 0.0f);
    return downloadGauge;
  }

  public void resetTouchBlockActive()
  {
    bool flag = !Singleton<PopupManager>.GetInstance().isOpenNoFinish && (this.mIsTouchBlock || this.mIsWebRunnig || this.mIsLoading);
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

  protected override void Initialize()
  {
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
    return (IEnumerator) new CommonRoot.\u003CbootSequenceLoop\u003Ec__Iterator8CD()
    {
      \u003C\u003Ef__this = this
    };
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
    return (IEnumerator) new CommonRoot.\u003CloadDefaultBackground\u003Ec__Iterator8CE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadCloudAnim()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRoot.\u003CloadCloudAnim\u003Ec__Iterator8CF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void DisableCloudAnim() => Object.Destroy((Object) this.cloudAnim);

  [DebuggerHidden]
  public IEnumerator StartCloudAnim(string startName, string endName, System.Action waitAction)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRoot.\u003CStartCloudAnim\u003Ec__Iterator8D0()
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
