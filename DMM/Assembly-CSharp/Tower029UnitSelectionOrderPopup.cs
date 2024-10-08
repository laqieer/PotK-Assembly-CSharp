﻿// Decompiled with JetBrains decompiler
// Type: Tower029UnitSelectionOrderPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class Tower029UnitSelectionOrderPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel lblTitle;
  [SerializeField]
  private UILabel lblOrder;
  [SerializeField]
  private UIPopupList orderList;
  private int selectedIndex;
  private System.Action<TowerUtil.UnitSelectionOrder> actionUnitSelection;

  public void onSelectionChange() => this.selectedIndex = this.orderList.items.IndexOf(UIPopupList.current.value);

  public void Initialize(System.Action<TowerUtil.UnitSelectionOrder> action)
  {
    if ((UnityEngine.Object) this.GetComponent<UIWidget>() != (UnityEngine.Object) null)
      this.GetComponent<UIWidget>().alpha = 0.0f;
    this.actionUnitSelection = action;
    this.lblTitle.SetTextLocalize(Consts.GetInstance().POPUP_TOWER_UNIT_SELECTION_ORDER_TITLE);
    this.orderList.items.Clear();
    this.orderList.items.Add(Consts.GetInstance().POPUP_TOWER_UNIT_SELECTION_ORDER_LEVEL);
    this.orderList.items.Add(Consts.GetInstance().POPUP_TOWER_UNIT_SELECTION_ORDER_ATTRIBUTE);
    this.orderList.items.Add(Consts.GetInstance().POPUP_TOWER_UNIT_SELECTION_ORDER_WEAPON);
    this.orderList.items.Add(Consts.GetInstance().POPUP_TOWER_UNIT_SELECTION_ORDER_FAVORITE);
    this.orderList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.orderList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => this.onSelectionChange())));
    this.orderList.value = Consts.GetInstance().POPUP_TOWER_UNIT_SELECTION_ORDER_LEVEL;
  }

  public void onOKButton()
  {
    if (this.actionUnitSelection != null)
      this.actionUnitSelection((TowerUtil.UnitSelectionOrder) this.selectedIndex);
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();
}
