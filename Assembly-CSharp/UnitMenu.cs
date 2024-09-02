// Decompiled with JetBrains decompiler
// Type: UnitMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

public class UnitMenu : BackButtonMenuBase
{
  public UIButton closeButton;
  public UIButton teamEditButton;
  public UIButton bringUpButton;
  public UIButton classChangeButton;
  public UIButton himeListButton;
  public UIButton itemButton;
  public UIButton CompositeButton;
  public UIButton DrillingButton;
  public UIButton RepairButton;
  public UIButton armorListButton;
  public UIButton reiSouButton;
  public UIButton supplyButton;
  public UIButton extraSkillButton;
  public UIButton buguMaterialButton;
  public UIButton himeMaterialButton;
  public UIButton himeTypeButton;
  public GameObject subMenu;
  public TweenAlpha grid;
  public TweenAlpha slc_base;
  public TweenAlpha slc_base_black;
  public TweenRotation arrow;
  private bool isOpen;
  private bool isSubOpen;
  private float labelColor;

  public override void onBackButton() => this.Close();

  private void Start()
  {
    this.closeButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() => this.Close())));
    this.itemButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.isSubOpen = !this.isSubOpen;
      if (this.isSubOpen)
      {
        this.subMenu.SetActive(true);
        this.SetTweenAlpha(this.subMenu.GetComponent<TweenAlpha>(), 0.0f, 1f);
        this.SetTweenPosition(this.subMenu.GetComponent<TweenPosition>(), (Vector3) new Vector2(0.0f, 190f), (Vector3) new Vector2(0.0f, 205f));
        this.SetTweenRotation(this.arrow, Vector3.zero, new Vector3(0.0f, 0.0f, -180f));
        this.SetButtonState(false);
      }
      else
      {
        this.SetTweenAlpha(this.subMenu.GetComponent<TweenAlpha>(), 1f, 0.0f);
        this.SetTweenPosition(this.subMenu.GetComponent<TweenPosition>(), (Vector3) new Vector2(0.0f, 205f), (Vector3) new Vector2(0.0f, 190f));
        this.SetTweenRotation(this.arrow, new Vector3(0.0f, 0.0f, -180f), Vector3.zero);
        this.SetButtonState(true);
      }
    })));
    this.teamEditButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Unit0046Scene)) && (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Unit0046Scene)) || Unit0046Scene.isQuestEdit))
        return;
      this.UnitMenuCommonProcessing();
      Unit0046Scene.changeScene(false);
      Unit0046Scene.isQuestEdit = true;
    })));
    this.bringUpButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Unit004UnitTrainingListScene)))
        return;
      this.UnitMenuCommonProcessing();
      Unit004UnitTrainingListScene.changeScene(false);
    })));
    this.classChangeButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Unit004JobChangeUnitSelectScene)))
        return;
      this.UnitMenuCommonProcessing();
      Unit004JobChangeUnitSelectScene.changeScene(false);
    })));
    this.himeListButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Unit00468Scene)))
        return;
      this.UnitMenuCommonProcessing();
      if ((UnityEngine.Object) Singleton<ExploreSceneManager>.GetInstanceOrNull() != (UnityEngine.Object) null)
        this.StartCoroutine(Singleton<ExploreSceneManager>.GetInstance().PriorityToExploreUpdate((System.Action) (() => Unit00468Scene.changeScene00411(false))));
      else
        Unit00468Scene.changeScene00411(false);
    })));
    this.CompositeButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Bugu00510Scene)))
        return;
      this.UnitMenuCommonProcessing();
      if (Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Bugu005RecipeCompositeMaterialSelectScene) || Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Bugu005ReisouFusionMaterialScene) || (Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Unit00443Scene) || Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Bugu00561Scene)) || (Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Unit0044ReisouScene) || Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Unit00468Scene) || (Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Unit0042Scene) || Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() == typeof (Help0152Scene))))
        Bugu00510Scene.changeSceneRecipeInit();
      else
        Bugu00510Scene.changeSceneRecipe(false);
    })));
    this.DrillingButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Bugu00526Scene)))
        return;
      this.UnitMenuCommonProcessing();
      Bugu00526Scene.ChangeScene(false);
    })));
    this.RepairButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Bugu00524Scene)))
        return;
      this.UnitMenuCommonProcessing();
      Bugu00524Scene.ChangeScene(false);
    })));
    this.armorListButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Bugu0052Scene)))
        return;
      this.UnitMenuCommonProcessing();
      Bugu0052Scene.ChangeScene(false);
    })));
    this.reiSouButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Bugu005ReisouListScene)))
        return;
      this.UnitMenuCommonProcessing();
      Bugu005ReisouListScene.ChangeScene(false);
    })));
    this.supplyButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Bugu005SupplyListScene)))
        return;
      this.UnitMenuCommonProcessing();
      Bugu005SupplyListScene.ChangeScene(false);
    })));
    this.extraSkillButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Unit004ExtraskillListScene)))
        return;
      this.UnitMenuCommonProcessing();
      if ((UnityEngine.Object) Singleton<ExploreSceneManager>.GetInstanceOrNull() != (UnityEngine.Object) null)
        this.StartCoroutine(Singleton<ExploreSceneManager>.GetInstance().PriorityToExploreUpdate((System.Action) (() => Unit004ExtraskillListScene.changeScene(false))));
      else
        Unit004ExtraskillListScene.changeScene(false);
    })));
    this.buguMaterialButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Bugu005MaterialListScene)))
        return;
      this.UnitMenuCommonProcessing();
      Bugu005MaterialListScene.ChangeScene(false);
    })));
    this.himeMaterialButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Unit004UnitMaterialsListScene)))
        return;
      this.UnitMenuCommonProcessing();
      Unit004UnitMaterialsListScene.changeScene(false);
    })));
    this.himeTypeButton.onClick.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      this.Close();
      if (!(Singleton<NGSceneManager>.GetInstance().sceneBase.GetType() != typeof (Unit004ReincarnationTypeTicketSelectionScene)))
        return;
      this.UnitMenuCommonProcessing();
      Unit004ReincarnationTypeTicketSelectionScene.changeScene(false);
    })));
    if (Singleton<TutorialRoot>.GetInstance().IsTutorialFinish())
      return;
    Singleton<TutorialRoot>.GetInstance().CurrentAdvise();
  }

  private void UnitMenuCommonProcessing()
  {
    Singleton<NGGameDataManager>.GetInstance().IsSea = false;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Singleton<NGGameDataManager>.GetInstance().clearScenePopupRecovery();
    if (!Singleton<NGGameDataManager>.GetInstance().isEditCustomDeck)
      return;
    Singleton<NGSceneManager>.GetInstance().quePreSceneChangeAsync.Enqueue(new Func<IEnumerator>(UnitMenu.doFinalizeCustomDeck));
  }

  private static IEnumerator doFinalizeCustomDeck()
  {
    Singleton<CommonRoot>.GetInstance().ShowLoadingLayer(0);
    return Singleton<NGGameDataManager>.GetInstance().doFinalizeEditCustomDeck();
  }

  private void SetTweenAlpha(TweenAlpha alpha, float from, float end)
  {
    alpha.ResetToBeginning();
    alpha.duration = 0.25f;
    alpha.from = from;
    alpha.to = end;
    alpha.onFinished.Clear();
    if (!this.isOpen)
      alpha.onFinished.Add(new EventDelegate((EventDelegate.Callback) (() => this.gameObject.SetActive(false))));
    else if (this.isOpen && !this.isSubOpen)
      alpha.onFinished.Add(new EventDelegate((EventDelegate.Callback) (() => this.subMenu.SetActive(false))));
    alpha.PlayForward();
  }

  private void SetTweenPosition(TweenPosition alpha, Vector3 from, Vector3 end)
  {
    alpha.ResetToBeginning();
    alpha.duration = 0.25f;
    alpha.from = from;
    alpha.to = end;
    alpha.PlayForward();
  }

  private void SetTweenRotation(TweenRotation rotate, Vector3 from, Vector3 end)
  {
    rotate.ResetToBeginning();
    rotate.duration = 0.25f;
    rotate.from = from;
    rotate.to = end;
    rotate.PlayForward();
  }

  private void SetButtonState(bool state)
  {
    this.teamEditButton.isEnabled = state;
    this.SetButtonLabelColor(this.teamEditButton, state);
    this.bringUpButton.isEnabled = state;
    this.SetButtonLabelColor(this.bringUpButton, state);
    this.classChangeButton.isEnabled = state;
    this.SetButtonLabelColor(this.classChangeButton, state);
    this.himeListButton.isEnabled = state;
    this.SetButtonLabelColor(this.himeListButton, state);
    this.CompositeButton.isEnabled = state;
    this.SetButtonLabelColor(this.CompositeButton, state);
    this.DrillingButton.isEnabled = state;
    this.SetButtonLabelColor(this.DrillingButton, state);
    this.RepairButton.isEnabled = state;
    this.SetButtonLabelColor(this.RepairButton, state);
    this.armorListButton.isEnabled = state;
    this.SetButtonLabelColor(this.armorListButton, state);
    this.reiSouButton.isEnabled = state;
    this.SetButtonLabelColor(this.reiSouButton, state);
  }

  private void SetButtonLabelColor(UIButton btn, bool state)
  {
    this.labelColor = state ? 0.5f : 0.2745f;
    foreach (UIWidget componentsInChild in btn.transform.GetComponentsInChildren<UISprite>())
      componentsInChild.color = new Color(this.labelColor, this.labelColor, this.labelColor);
  }

  public void Open()
  {
    this.isOpen = true;
    this.isSubOpen = false;
    this.subMenu.SetActive(false);
    this.SetButtonState(true);
    this.SetTweenAlpha(this.grid, 0.0f, 1f);
    this.SetTweenAlpha(this.slc_base, 0.0f, 1f);
    this.SetTweenAlpha(this.slc_base_black, 0.0f, 0.5f);
  }

  public void Close()
  {
    this.isOpen = false;
    if (this.isSubOpen)
    {
      this.SetTweenAlpha(this.subMenu.GetComponent<TweenAlpha>(), 1f, 0.0f);
      this.SetTweenPosition(this.subMenu.GetComponent<TweenPosition>(), (Vector3) new Vector2(0.0f, 190f), (Vector3) new Vector2(0.0f, 175f));
      this.SetTweenRotation(this.arrow, new Vector3(0.0f, 0.0f, -180f), Vector3.zero);
    }
    this.isSubOpen = false;
    this.SetTweenAlpha(this.grid, 1f, 0.0f);
    this.SetTweenAlpha(this.slc_base, 1f, 0.0f);
    this.SetTweenAlpha(this.slc_base_black, 0.5f, 0.0f);
  }
}
