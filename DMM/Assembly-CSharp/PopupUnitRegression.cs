// Decompiled with JetBrains decompiler
// Type: PopupUnitRegression
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using UnityEngine;

[AddComponentMenu("Popup/Unit/Regression")]
public class PopupUnitRegression : BackButtonPopupBase
{
  [SerializeField]
  private PopupUnitRegression.Step step_;
  [SerializeField]
  private Transform lnkBefore_;
  [SerializeField]
  private LimitBreakIndicator indicatorBefore_;
  [SerializeField]
  private Transform lnkAfter_;
  [SerializeField]
  private LimitBreakIndicator indicatorAfter_;
  [SerializeField]
  private UILabel txtNum_;
  [SerializeField]
  private UIButton btnRegression_;
  [SerializeField]
  [Tooltip("演出コントロール用")]
  private Animator animator_;
  private GameObject objBefore_;
  private GameObject objAfter_;
  private bool isWait_;
  private bool isSkipped_;
  private PlayerUnit target_;
  private UnitUnit unitRegression_;
  private System.Action actNext_;
  private System.Action actClose_;
  private System.Action actHelp_;
  private System.Action actItem_;
  private System.Action actUnitDetail_;
  private System.Action oneshotOnTweenFinished_;

  public void initailize(
    GameObject prefabIcon,
    PlayerUnit target,
    int regressionId,
    System.Action actNext,
    System.Action actClose = null,
    System.Action actHelp = null,
    System.Action actItem = null,
    System.Action actUnitDetail = null)
  {
    this.setTopObject(this.gameObject);
    if ((UnityEngine.Object) this.lnkBefore_ != (UnityEngine.Object) null)
      this.objBefore_ = prefabIcon.Clone(this.lnkBefore_);
    if ((UnityEngine.Object) this.lnkAfter_ != (UnityEngine.Object) null)
      this.objAfter_ = prefabIcon.Clone(this.lnkAfter_);
    this.GetComponent<UIPanel>().alpha = 0.0f;
    this.isWait_ = true;
    this.isSkipped_ = false;
    this.target_ = target;
    this.unitRegression_ = regressionId != 0 ? MasterData.UnitUnit[regressionId] : (UnitUnit) null;
    if (actClose == null)
      actClose = actNext;
    this.actNext_ = actNext;
    this.actClose_ = actClose;
    this.actHelp_ = actHelp;
    this.actItem_ = actItem;
    this.actUnitDetail_ = actUnitDetail;
    Consts instance = Consts.GetInstance();
    int itemId = instance.ITEM_REGRESSION_ID;
    int regressionQuantity = instance.ITEM_REGRESSION_QUANTITY;
    PlayerMaterialUnit playerMaterialUnit = Array.Find<PlayerMaterialUnit>(SMManager.Get<PlayerMaterialUnit[]>(), (Predicate<PlayerMaterialUnit>) (x => x._unit == itemId));
    int num = playerMaterialUnit != null ? playerMaterialUnit.quantity : 0;
    if ((UnityEngine.Object) this.txtNum_ != (UnityEngine.Object) null)
    {
      this.txtNum_.SetTextLocalize(Consts.Format(instance.unit_004_9_9_possession_text, (IDictionary) new Hashtable()
      {
        {
          (object) "Count",
          (object) num
        }
      }));
      this.txtNum_.color = num >= regressionQuantity ? Color.yellow : Color.red;
    }
    if (!((UnityEngine.Object) this.btnRegression_ != (UnityEngine.Object) null))
      return;
    this.btnRegression_.isEnabled = this.step_ != PopupUnitRegression.Step._Fin ? num >= regressionQuantity : (UnityEngine.Object) this.animator_ == (UnityEngine.Object) null;
  }

  private IEnumerator Start()
  {
    PopupUnitRegression popupUnitRegression = this;
    if ((UnityEngine.Object) popupUnitRegression.objBefore_ != (UnityEngine.Object) null)
    {
      UnitIcon component = popupUnitRegression.objBefore_.GetComponent<UnitIcon>();
      yield return (object) popupUnitRegression.initIcon(component, popupUnitRegression.target_);
    }
    if ((UnityEngine.Object) popupUnitRegression.indicatorBefore_ != (UnityEngine.Object) null)
      popupUnitRegression.indicatorBefore_.set(popupUnitRegression.target_.breakthrough_count, popupUnitRegression.target_.unit.breakthrough_limit);
    if ((UnityEngine.Object) popupUnitRegression.objAfter_ != (UnityEngine.Object) null)
    {
      UnitIcon component = popupUnitRegression.objAfter_.GetComponent<UnitIcon>();
      PlayerUnit byUnitunit = PlayerUnit.create_by_unitunit(popupUnitRegression.unitRegression_, 1);
      byUnitunit._unit_type = popupUnitRegression.target_._unit_type;
      for (int index = 0; index < Hard.MasterDataTable.Data.UnitRegressionUnitTypes.Length; ++index)
      {
        if (Hard.MasterDataTable.Data.UnitRegressionUnitTypes[index].IsMatch(popupUnitRegression.target_))
        {
          byUnitunit._unit_type = (int) Hard.MasterDataTable.Data.UnitRegressionUnitTypes[index].target_type;
          break;
        }
      }
      yield return (object) popupUnitRegression.initIcon(component, byUnitunit);
    }
    if ((UnityEngine.Object) popupUnitRegression.indicatorAfter_ != (UnityEngine.Object) null)
      popupUnitRegression.indicatorAfter_.set(Mathf.Min(popupUnitRegression.target_.unity_value, popupUnitRegression.unitRegression_.breakthrough_limit), popupUnitRegression.unitRegression_.breakthrough_limit);
    if (popupUnitRegression.step_ == PopupUnitRegression.Step._Fin)
      popupUnitRegression.changeIconToAfter(false);
    // ISSUE: reference to a compiler-generated method
    popupUnitRegression.oneshotOnTweenFinished_ = new System.Action(popupUnitRegression.\u003CStart\u003Eb__22_0);
    popupUnitRegression.isWait_ = false;
    Singleton<PopupManager>.GetInstance().startOpenAnime(popupUnitRegression.gameObject);
  }

  private IEnumerator initIcon(UnitIcon icon, PlayerUnit unit)
  {
    yield return (object) icon.SetPlayerUnit(unit, (PlayerUnit[]) null, (PlayerUnit) null, false, false);
    icon.ShowBottomInfos(UnitSortAndFilter.SORT_TYPES.Level);
    icon.setLevelText(unit);
    icon.SetIconBoxCollider(false);
  }

  public void onTweenFinished()
  {
    if (this.oneshotOnTweenFinished_ == null)
      return;
    this.oneshotOnTweenFinished_();
    this.oneshotOnTweenFinished_ = (System.Action) null;
  }

  private IEnumerator doWaitEffect()
  {
    PopupUnitRegression popupUnitRegression = this;
    yield return (object) new WaitForAnimation(popupUnitRegression.animator_);
    if ((UnityEngine.Object) popupUnitRegression.btnRegression_ != (UnityEngine.Object) null)
      popupUnitRegression.btnRegression_.isEnabled = true;
    if (popupUnitRegression.isSkipped_)
    {
      clipEffectPlayer componentInChildren = popupUnitRegression.gameObject.GetComponentInChildren<clipEffectPlayer>();
      NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
      if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && (UnityEngine.Object) instance != (UnityEngine.Object) null && componentInChildren.lastPlaySound != -1)
        instance.StopSe(componentInChildren.lastPlaySound);
    }
    popupUnitRegression.isSkipped_ = true;
    if ((UnityEngine.Object) popupUnitRegression.objBefore_ != (UnityEngine.Object) null && (UnityEngine.Object) popupUnitRegression.objAfter_ != (UnityEngine.Object) null && popupUnitRegression.objBefore_.activeSelf)
      popupUnitRegression.changeIconToAfter(true);
  }

  public override void onBackButton() => this.onClickedClose();

  public void onClickedClose()
  {
    if (this.isWait_)
      return;
    this.actClose_();
  }

  public void onClickedRegression()
  {
    if (this.isWait_)
      return;
    this.actNext_();
  }

  public void onClickedHelp()
  {
    if (this.isWait_ || this.actHelp_ == null)
      return;
    this.actHelp_();
  }

  public void onClickedItemIcon()
  {
    if (this.isWait_ || this.actItem_ == null)
      return;
    this.actItem_();
  }

  public void onClickedUnitDetail()
  {
    if (this.isWait_ || this.target_ == (PlayerUnit) null)
      return;
    this.actUnitDetail_();
    Unit0042Scene.changeSceneEvolutionUnit(true, this.target_, (PlayerUnit[]) null);
  }

  public void onClickedSkip()
  {
    if (this.isWait_ || this.isSkipped_ || (UnityEngine.Object) this.animator_ == (UnityEngine.Object) null)
      return;
    this.isSkipped_ = true;
    this.animator_.speed *= 5f;
  }

  public void changeIconToAfter(bool bToAfter)
  {
    if ((UnityEngine.Object) this.objBefore_ != (UnityEngine.Object) null)
      this.objBefore_.SetActive(!bToAfter);
    if (!((UnityEngine.Object) this.objAfter_ != (UnityEngine.Object) null))
      return;
    this.objAfter_.SetActive(bToAfter);
  }

  public enum Step
  {
    _1st,
    _2nd,
    _Fin,
  }
}
