﻿// Decompiled with JetBrains decompiler
// Type: Popup0063SheetMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

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
  private bool isSkip;
  private int EffectSkipCnt;
  private int EffectMax;
  private int EffectNowIndex;
  private int EffectIndex;

  public void SetBackBtnEnable(bool enable)
  {
    foreach (UIButtonColor uiButtonColor in this.BackBtn)
      uiButtonColor.isEnabled = enable;
    this.BackBtnEnable = enable;
  }

  public IEnumerator Init(
    Gacha0063KisekiExtention kisekiExtention,
    GachaG007PlayerPanel[] panels,
    GachaG007PlayerSheet sheetData)
  {
    this.KisekiExtention = kisekiExtention;
    IEnumerator e = this.Init(panels, sheetData);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator Init(
    GachaG007PlayerPanel[] panels,
    GachaG007PlayerSheet sheetData,
    int hitPosition = 0,
    bool isResultEffect = false,
    GameObject effectPrefab = null,
    GameObject hitEffectPrefab = null)
  {
    Popup0063SheetMenu parent = this;
    parent.SheetData = sheetData;
    parent.IsResultEffect = isResultEffect;
    Future<GameObject> normalPrefabF;
    IEnumerator e;
    if ((UnityEngine.Object) parent.NormalPrefab == (UnityEngine.Object) null)
    {
      normalPrefabF = Res.Prefabs.gacha006_3.dir_SheetGacha_Panel.Load<GameObject>();
      e = normalPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      parent.NormalPrefab = normalPrefabF.Result;
      normalPrefabF = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) parent.SpecialPrefab == (UnityEngine.Object) null)
    {
      normalPrefabF = Res.Prefabs.gacha006_3.dir_SheetGacha_Special_Panel.Load<GameObject>();
      e = normalPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      parent.SpecialPrefab = normalPrefabF.Result;
      normalPrefabF = (Future<GameObject>) null;
    }
    int len = panels.Length > parent.SheetPanels.Length ? parent.SheetPanels.Length : panels.Length;
    parent.panelObject = new Gacha0063DirSheetCachaPanel[len];
    for (int i = 0; i < len; ++i)
    {
      parent.panelObject[i] = (Gacha0063DirSheetCachaPanel) null;
      parent.panelObject[i] = !panels[i].highlight ? parent.NormalPrefab.Clone(parent.SheetPanels[i].transform).GetComponent<Gacha0063DirSheetCachaPanel>() : parent.SpecialPrefab.Clone(parent.SheetPanels[i].transform).GetComponent<Gacha0063DirSheetCachaPanel>();
      if ((UnityEngine.Object) parent.panelObject[i] != (UnityEngine.Object) null)
      {
        e = parent.panelObject[i].Init(parent, panels[i], isResultEffect, effectPrefab, hitEffectPrefab);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        if (!panels[i].is_opened)
          ++parent.activePanel;
      }
    }
    parent.ResetBtn.gameObject.SetActive(false);
    parent.StepupBtn.gameObject.SetActive(false);
    parent.Description.gameObject.SetActive(false);
    parent.SkipBtn.SetActive(false);
    if (parent.IsResultEffect)
    {
      ((IEnumerable<GameObject>) parent.Sheet).ToggleOnce(0);
      parent.SetBackBtnEnable(false);
    }
    else if (parent.SheetData.button_type == 2)
    {
      ((IEnumerable<GameObject>) parent.Sheet).ToggleOnce(1);
      parent.ResetBtn.gameObject.SetActive(true);
      if (!parent.SheetData.can_push_button)
      {
        parent.ResetBtn.isEnabled = false;
        parent.Description.gameObject.SetActive(true);
      }
    }
    else if (parent.SheetData.button_type == 3)
    {
      ((IEnumerable<GameObject>) parent.Sheet).ToggleOnce(1);
      parent.StepupBtn.gameObject.SetActive(true);
      if (!parent.SheetData.can_push_button)
      {
        parent.StepupBtn.isEnabled = false;
        parent.Description.gameObject.SetActive(true);
      }
    }
    else
      ((IEnumerable<GameObject>) parent.Sheet).ToggleOnce(0);
  }

  public IEnumerator StartSelEffect(GachaG007PlayerPanel[] panels, int hitPanelIndex)
  {
    this.SkipBtn.SetActive(true);
    this.isSkip = false;
    UnityEngine.Random.Range(0, 2);
    GachaG007PlayerPanel[] effArray = true ? ((IEnumerable<GachaG007PlayerPanel>) panels).Where<GachaG007PlayerPanel>((Func<GachaG007PlayerPanel, bool>) (x => !x.is_opened && x.reward_type_id.HasValue)).OrderBy<GachaG007PlayerPanel, int>((Func<GachaG007PlayerPanel, int>) (x => x.position)).ToArray<GachaG007PlayerPanel>() : ((IEnumerable<GachaG007PlayerPanel>) panels).Where<GachaG007PlayerPanel>((Func<GachaG007PlayerPanel, bool>) (x => !x.is_opened && x.reward_type_id.HasValue)).OrderByDescending<GachaG007PlayerPanel, int>((Func<GachaG007PlayerPanel, int>) (x => x.position)).ToArray<GachaG007PlayerPanel>();
    this.EffectMax = UnityEngine.Random.Range(3 * ((IEnumerable<GachaG007PlayerPanel>) effArray).Count<GachaG007PlayerPanel>(), 5 * ((IEnumerable<GachaG007PlayerPanel>) effArray).Count<GachaG007PlayerPanel>() + 1);
    int hitIndex = Array.IndexOf<int>(((IEnumerable<GachaG007PlayerPanel>) effArray).Select<GachaG007PlayerPanel, int>((Func<GachaG007PlayerPanel, int>) (x => x.position)).ToArray<int>(), hitPanelIndex);
    int rate = this.EffectMax / 3;
    int first = rate;
    int second = first + rate;
    this.EffectNowIndex = this.EffectMax;
    this.EffectSkipCnt = second + 1;
    this.EffectIndex = 0;
    if (((IEnumerable<GachaG007PlayerPanel>) effArray).Count<GachaG007PlayerPanel>() == 1)
    {
      this.SkipBtn.SetActive(false);
    }
    else
    {
      NGSoundManager sm = Singleton<NGSoundManager>.GetInstance();
      float baseSpeed = 0.15f;
      while (this.EffectNowIndex != hitIndex)
      {
        int index = Mathf.Abs(this.EffectNowIndex % ((IEnumerable<GachaG007PlayerPanel>) effArray).Count<GachaG007PlayerPanel>());
        this.SelEffect(effArray[index].position - 1, 0.0f);
        float seconds = this.EffectIndex >= first ? (this.EffectIndex >= second ? baseSpeed + (float) (rate - (second - this.EffectIndex)) / (float) rate * 0.25f : baseSpeed + (float) (rate - (second - this.EffectIndex)) / (float) rate * 0.25f) : baseSpeed;
        if ((UnityEngine.Object) sm != (UnityEngine.Object) null)
          sm.playSE("SE_0544");
        yield return (object) new WaitForSeconds(seconds);
        if (!this.isSkip)
        {
          --this.EffectNowIndex;
          ++this.EffectIndex;
        }
        else
          break;
      }
      this.SkipBtn.SetActive(false);
    }
  }

  private void SelEffect(int idx, float correct) => this.panelObject[idx].SelEffect(correct);

  public void HitEffect(int idx)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if ((UnityEngine.Object) instance != (UnityEngine.Object) null)
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

  private IEnumerator ShowSheetResetPopup()
  {
    IEnumerator e = this.SheetResetPopup(this.SheetData);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
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

  public IEnumerator ShowDetaiPopup(MasterDataTable.CommonRewardType type, int id)
  {
    Popup0063SheetMenu popup0063SheetMenu = this;
    if (!popup0063SheetMenu.ShowDetail)
    {
      popup0063SheetMenu.SetBackBtnEnable(false);
      popup0063SheetMenu.ShowDetail = true;
      Resolution windowSize = Screen.currentResolution;
      Future<UnityEngine.Sprite> textureLoader = Res.Prefabs.BackGround.black.Load<UnityEngine.Sprite>();
      IEnumerator e = textureLoader.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject colorLayer = new GameObject("Color Layer")
      {
        transform = {
          parent = popup0063SheetMenu.gameObject.transform
        },
        layer = popup0063SheetMenu.gameObject.layer
      };
      colorLayer.transform.localScale = new Vector3(1f, 1f, 1f);
      UIPanel uiPanel = colorLayer.AddComponent<UIPanel>();
      UI2DSprite ui2Dsprite = colorLayer.AddComponent<UI2DSprite>();
      uiPanel.depth = 300;
      ui2Dsprite.sprite2D = textureLoader.Result;
      ui2Dsprite.alpha = 0.75f;
      ui2Dsprite.height = windowSize.height;
      ui2Dsprite.width = windowSize.width;
      bool isFinished = false;
      GameObject popup = popup0063SheetMenu.popupObject.Clone(colorLayer.transform);
      popup.SetActive(false);
      e = popup.GetComponent<Shop00742Menu>().Init(type, id, (System.Action) (() => isFinished = true));
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      popup.SetActive(true);
      while (!isFinished)
        yield return (object) null;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) colorLayer);
      popup0063SheetMenu.ShowDetail = false;
      popup0063SheetMenu.SetBackBtnEnable(true);
    }
  }

  public IEnumerator GetItemEffect(GachaG007PlayerPanel playerPanel)
  {
    Popup0063SheetMenu popup0063SheetMenu = this;
    if (playerPanel != null)
    {
      Resolution windowSize = Screen.currentResolution;
      Future<UnityEngine.Sprite> textureLoader = Res.Prefabs.BackGround.black.Load<UnityEngine.Sprite>();
      IEnumerator e = textureLoader.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject colorLayer = new GameObject("Color Layer")
      {
        transform = {
          parent = popup0063SheetMenu.gameObject.transform
        },
        layer = popup0063SheetMenu.gameObject.layer
      };
      colorLayer.transform.localScale = new Vector3(1f, 1f, 1f);
      UIPanel uiPanel = colorLayer.AddComponent<UIPanel>();
      UI2DSprite ui2Dsprite = colorLayer.AddComponent<UI2DSprite>();
      uiPanel.depth = 300;
      ui2Dsprite.sprite2D = textureLoader.Result;
      ui2Dsprite.alpha = 0.75f;
      ui2Dsprite.height = windowSize.height;
      ui2Dsprite.width = windowSize.width;
      Future<GameObject> loader = Res.Prefabs.gacha006_3.SheetGacha_eff_main.Load<GameObject>();
      e = loader.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject bonus = loader.Result.Clone(colorLayer.transform);
      bool isFinished = false;
      e = bonus.GetComponent<SheetGachaGetBonus>().Init(playerPanel, (System.Action) (() => this.CreateTouchObject((EventDelegate.Callback) (() => isFinished = true), bonus.transform.parent)));
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      while (!isFinished)
        yield return (object) null;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) colorLayer);
    }
  }

  public IEnumerator SheetCompleteEffect()
  {
    Popup0063SheetMenu popup0063SheetMenu = this;
    Resolution currentResolution = Screen.currentResolution;
    GameObject colorLayer = new GameObject("Color Layer")
    {
      transform = {
        parent = popup0063SheetMenu.gameObject.transform
      },
      layer = popup0063SheetMenu.gameObject.layer
    };
    colorLayer.transform.localScale = new Vector3(1f, 1f, 1f);
    UIPanel uiPanel = colorLayer.AddComponent<UIPanel>();
    UI2DSprite ui2Dsprite = colorLayer.AddComponent<UI2DSprite>();
    uiPanel.depth = 300;
    ui2Dsprite.height = currentResolution.height;
    ui2Dsprite.width = currentResolution.width;
    Future<GameObject> loader = Res.Prefabs.gacha006_3.SheetGacha_complete_eff_main.Load<GameObject>();
    IEnumerator e = loader.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject bonus = loader.Result.Clone(colorLayer.transform);
    bool isFinished = false;
    bonus.GetComponent<SheetGachaComplete>().Init((System.Action) (() => this.CreateTouchObject((EventDelegate.Callback) (() => isFinished = true), bonus.transform.parent)));
    while (!isFinished)
      yield return (object) null;
    UnityEngine.Object.DestroyObject((UnityEngine.Object) colorLayer);
  }

  public IEnumerator SheetResetPopup(GachaG007PlayerSheet result)
  {
    Popup0063SheetMenu popup0063SheetMenu = this;
    if (result != null && result.can_push_button)
    {
      Resolution windowSize = Screen.currentResolution;
      Future<UnityEngine.Sprite> textureLoader = Res.Prefabs.BackGround.black.Load<UnityEngine.Sprite>();
      IEnumerator e = textureLoader.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject colorLayer = new GameObject("Color Layer")
      {
        transform = {
          parent = popup0063SheetMenu.gameObject.transform
        },
        layer = popup0063SheetMenu.gameObject.layer
      };
      colorLayer.transform.localScale = new Vector3(1f, 1f, 1f);
      UIPanel uiPanel = colorLayer.AddComponent<UIPanel>();
      UI2DSprite ui2Dsprite = colorLayer.AddComponent<UI2DSprite>();
      uiPanel.depth = 300;
      ui2Dsprite.sprite2D = textureLoader.Result;
      ui2Dsprite.alpha = 0.75f;
      ui2Dsprite.height = windowSize.height;
      ui2Dsprite.width = windowSize.width;
      Future<GameObject> loader = (Future<GameObject>) null;
      if (result.button_type == 2)
      {
        popup0063SheetMenu.ResetBtn.isEnabled = false;
        loader = Res.Prefabs.popup.popup_006_3_3__anim_popup01.Load<GameObject>();
      }
      else if (result.button_type == 3)
      {
        popup0063SheetMenu.StepupBtn.isEnabled = false;
        loader = Res.Prefabs.popup.popup_006_3_4__anim_popup01.Load<GameObject>();
      }
      e = loader.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject gameObject = loader.Result.Clone(colorLayer.transform);
      popup0063SheetMenu.FinishResetDialog = false;
      popup0063SheetMenu.ShowResetDialog = true;
      e = gameObject.GetComponent<Popup00633SheetResetMenu>().Init(new Func<IEnumerator>(popup0063SheetMenu.SheetReset), new System.Action(popup0063SheetMenu.PopupNoBtnAction));
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      while (!popup0063SheetMenu.FinishResetDialog)
        yield return (object) null;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) colorLayer);
    }
  }

  public virtual GameObject CreateTouchObject(
    EventDelegate.Callback callback,
    Transform parent = null)
  {
    Resolution currentResolution = Screen.currentResolution;
    GameObject gameObject = new GameObject("touch object");
    gameObject.transform.parent = parent ?? this.transform;
    UIWidget uiWidget = gameObject.AddComponent<UIWidget>();
    uiWidget.depth = 1000;
    uiWidget.width = currentResolution.height;
    uiWidget.height = currentResolution.width;
    BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
    boxCollider.isTrigger = true;
    boxCollider.size = new Vector3()
    {
      x = (float) currentResolution.height,
      y = (float) currentResolution.width,
      z = 1f
    };
    UIButton uiButton = gameObject.AddComponent<UIButton>();
    uiButton.tweenTarget = (GameObject) null;
    EventDelegate.Add(uiButton.onClick, callback);
    return gameObject;
  }

  private IEnumerator SheetReset()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<CommonRoot>.GetInstance().loadingMode = 1;
    Future<WebAPI.Response.GachaG007PanelPanelReset> result = WebAPI.GachaG007PanelPanelReset(this.SheetData.sheet_series_id, (System.Action<WebAPI.Response.UserError>) (error =>
    {
      WebAPI.DefaultUserErrorCallback(error);
      Singleton<CommonRoot>.GetInstance().loadingMode = 0;
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      MypageScene.ChangeSceneOnError();
    }));
    IEnumerator e = result.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (result.Result != null)
    {
      if (!this.IsResultEffect)
      {
        e = this.UpdateSheetPanel();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        if ((UnityEngine.Object) this.KisekiExtention != (UnityEngine.Object) null)
          this.KisekiExtention.UpdateSheetInfo();
      }
      this.PopupNoBtnAction();
      Singleton<CommonRoot>.GetInstance().loadingMode = 0;
      Singleton<CommonRoot>.GetInstance().isLoading = false;
    }
  }

  private IEnumerator UpdateSheetPanel()
  {
    Popup0063SheetMenu parent = this;
    parent.SheetData = SMManager.Get<GachaG007PlayerSheet[]>()[0];
    GachaG007PlayerPanel[] panels = ((IEnumerable<GachaG007PlayerPanel>) parent.SheetData.player_panels).OrderBy<GachaG007PlayerPanel, int>((Func<GachaG007PlayerPanel, int>) (x => x.position)).ToArray<GachaG007PlayerPanel>();
    foreach (Component component in parent.panelObject)
      UnityEngine.Object.Destroy((UnityEngine.Object) component.gameObject);
    int len = panels.Length > parent.SheetPanels.Length ? parent.SheetPanels.Length : panels.Length;
    parent.panelObject = new Gacha0063DirSheetCachaPanel[len];
    for (int i = 0; i < len; ++i)
    {
      parent.panelObject[i] = (Gacha0063DirSheetCachaPanel) null;
      parent.panelObject[i] = !panels[i].highlight ? parent.NormalPrefab.Clone(parent.SheetPanels[i].transform).GetComponent<Gacha0063DirSheetCachaPanel>() : parent.SpecialPrefab.Clone(parent.SheetPanels[i].transform).GetComponent<Gacha0063DirSheetCachaPanel>();
      if ((UnityEngine.Object) parent.panelObject[i] != (UnityEngine.Object) null)
      {
        IEnumerator e = parent.panelObject[i].Init(parent, panels[i]);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        if (!panels[i].is_opened)
          ++parent.activePanel;
      }
    }
    parent.ResetBtn.gameObject.SetActive(false);
    parent.StepupBtn.gameObject.SetActive(false);
    parent.Description.gameObject.SetActive(false);
    if (parent.IsResultEffect)
      parent.SetBackBtnEnable(false);
    else if (parent.SheetData.button_type == 2)
    {
      parent.ResetBtn.gameObject.SetActive(true);
      if (!parent.SheetData.can_push_button)
      {
        parent.ResetBtn.isEnabled = false;
        parent.Description.gameObject.SetActive(true);
      }
    }
    else if (parent.SheetData.button_type == 3)
    {
      parent.StepupBtn.gameObject.SetActive(true);
      if (!parent.SheetData.can_push_button)
      {
        parent.StepupBtn.isEnabled = false;
        parent.Description.gameObject.SetActive(true);
      }
    }
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
    this.isSkip = true;
    this.SkipBtn.SetActive(false);
  }
}
