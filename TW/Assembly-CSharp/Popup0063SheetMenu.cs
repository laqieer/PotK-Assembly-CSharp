// Decompiled with JetBrains decompiler
// Type: Popup0063SheetMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup0063SheetMenu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject SkipBtn;
  [SerializeField]
  private UIButton[] BackBtn;
  [SerializeField]
  private UIButton ResetBtn;
  [SerializeField]
  private UIButton StepupBtn;
  [SerializeField]
  private UILabel Description;
  [SerializeField]
  private GameObject[] SheetPanels;
  [SerializeField]
  private GameObject[] Sheet;
  private Gacha0063DirSheetCachaPanel[] panelObject;
  private System.Action onCallback;
  private bool IsResultEffect;
  private bool ShowDetail;
  private bool ShowResetDialog;
  private bool FinishResetDialog;
  public int activePanel;
  private GachaG007PlayerSheet SheetData;
  private GameObject popupObject;
  private GameObject SpecialPrefab;
  private GameObject NormalPrefab;
  private Gacha0063KisekiExtention KisekiExtention;
  private int EffectSkipCnt;
  private int EffectMax;
  private int EffectNowIndex;
  private int EffectIndex;

  public void SetBackBtnEnable(bool enable)
  {
    foreach (UIButton uiButton in this.BackBtn)
      uiButton.isEnabled = enable;
    this.BackBtnEnable = enable;
  }

  [DebuggerHidden]
  public IEnumerator Init(
    Gacha0063KisekiExtention kisekiExtention,
    GachaG007PlayerPanel[] panels,
    GachaG007PlayerSheet sheetData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CInit\u003Ec__IteratorA02()
    {
      kisekiExtention = kisekiExtention,
      panels = panels,
      sheetData = sheetData,
      \u003C\u0024\u003EkisekiExtention = kisekiExtention,
      \u003C\u0024\u003Epanels = panels,
      \u003C\u0024\u003EsheetData = sheetData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    GachaG007PlayerPanel[] panels,
    GachaG007PlayerSheet sheetData,
    int hitPosition = 0,
    bool isResultEffect = false,
    GameObject effectPrefab = null,
    GameObject hitEffectPrefab = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CInit\u003Ec__IteratorA03()
    {
      sheetData = sheetData,
      isResultEffect = isResultEffect,
      panels = panels,
      effectPrefab = effectPrefab,
      hitEffectPrefab = hitEffectPrefab,
      \u003C\u0024\u003EsheetData = sheetData,
      \u003C\u0024\u003EisResultEffect = isResultEffect,
      \u003C\u0024\u003Epanels = panels,
      \u003C\u0024\u003EeffectPrefab = effectPrefab,
      \u003C\u0024\u003EhitEffectPrefab = hitEffectPrefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartSelEffect(GachaG007PlayerPanel[] panels, int hitPanelIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CStartSelEffect\u003Ec__IteratorA04()
    {
      panels = panels,
      hitPanelIndex = hitPanelIndex,
      \u003C\u0024\u003Epanels = panels,
      \u003C\u0024\u003EhitPanelIndex = hitPanelIndex,
      \u003C\u003Ef__this = this
    };
  }

  private void SelEffect(int idx, float correct) => this.panelObject[idx].SelEffect(correct);

  public void HitEffect(int idx)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_0545");
    this.panelObject[idx].HitEffect();
  }

  public void IbtnNo()
  {
    if (this.ShowResetDialog)
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (this.onCallback == null)
      return;
    this.onCallback();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator ShowSheetResetPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CShowSheetResetPopup\u003Ec__IteratorA05()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnReset()
  {
    if (this.ShowResetDialog)
      return;
    this.StartCoroutine(this.ShowSheetResetPopup());
  }

  public void IbtnStepUp()
  {
    if (this.ShowResetDialog)
      return;
    this.StartCoroutine(this.ShowSheetResetPopup());
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  [DebuggerHidden]
  public IEnumerator ShowDetaiPopup(MasterDataTable.CommonRewardType type, int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CShowDetaiPopup\u003Ec__IteratorA06()
    {
      type = type,
      id = id,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator GetItemEffect(GachaG007PlayerPanel playerPanel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CGetItemEffect\u003Ec__IteratorA07()
    {
      playerPanel = playerPanel,
      \u003C\u0024\u003EplayerPanel = playerPanel,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SheetCompleteEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CSheetCompleteEffect\u003Ec__IteratorA08()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SheetResetPopup(GachaG007PlayerSheet result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CSheetResetPopup\u003Ec__IteratorA09()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public virtual GameObject CreateTouchObject(EventDelegate.Callback callback, Transform parent = null)
  {
    Resolution currentResolution = Screen.currentResolution;
    GameObject touchObject = new GameObject("touch object");
    touchObject.transform.parent = parent ?? ((Component) this).transform;
    UIWidget uiWidget = touchObject.AddComponent<UIWidget>();
    uiWidget.depth = 1000;
    uiWidget.width = ((Resolution) ref currentResolution).height;
    uiWidget.height = ((Resolution) ref currentResolution).width;
    BoxCollider boxCollider = touchObject.AddComponent<BoxCollider>();
    ((Collider) boxCollider).isTrigger = true;
    boxCollider.size = new Vector3()
    {
      x = (float) ((Resolution) ref currentResolution).height,
      y = (float) ((Resolution) ref currentResolution).width,
      z = 1f
    };
    UIButton uiButton = touchObject.AddComponent<UIButton>();
    uiButton.tweenTarget = (GameObject) null;
    EventDelegate.Add(uiButton.onClick, callback);
    return touchObject;
  }

  [DebuggerHidden]
  private IEnumerator SheetReset()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CSheetReset\u003Ec__IteratorA0A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateSheetPanel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0063SheetMenu.\u003CUpdateSheetPanel\u003Ec__IteratorA0B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void PopupNoBtnAction()
  {
    this.FinishResetDialog = true;
    this.ShowResetDialog = false;
    if (this.SheetData.button_type == 3)
      this.StepupBtn.isEnabled = this.SheetData.can_push_button;
    else if (this.SheetData.button_type == 2)
      this.ResetBtn.isEnabled = this.SheetData.can_push_button;
    if (!this.IsResultEffect)
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (this.onCallback == null)
      return;
    this.onCallback();
  }

  public void EffectSkipBtn()
  {
    if (this.EffectIndex >= this.EffectSkipCnt)
      return;
    this.EffectNowIndex = this.EffectMax - this.EffectSkipCnt;
    this.EffectIndex = this.EffectSkipCnt;
    this.SkipBtn.SetActive(false);
  }
}
