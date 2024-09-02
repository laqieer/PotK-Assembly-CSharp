// Decompiled with JetBrains decompiler
// Type: Tower029UnitSelectionRecoveryPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Tower029UnitSelectionRecoveryPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel lblPopupTitle;
  [SerializeField]
  private UILabel lblPopupDesc;
  private System.Action<TowerUtil.UnitSelectionMode, TowerUtil.SequenceType> actionUnitSelection;
  private TowerProgress progress;
  private TowerUtil.SequenceType sequenceType;
  [SerializeField]
  private List<SupplyItem> SupplyItems = new List<SupplyItem>();
  [SerializeField]
  private List<SupplyItem> SaveDeck = new List<SupplyItem>();

  public void Initialize(
    TowerProgress progress,
    System.Action<TowerUtil.UnitSelectionMode, TowerUtil.SequenceType> action,
    TowerUtil.SequenceType sequenceType)
  {
    if ((UnityEngine.Object) this.GetComponent<UIWidget>() != (UnityEngine.Object) null)
      this.GetComponent<UIWidget>().alpha = 0.0f;
    this.actionUnitSelection = action;
    this.sequenceType = sequenceType;
    this.progress = progress;
    this.lblPopupTitle.SetTextLocalize(Consts.GetInstance().POPUP_TOWER_UNIT_RECOVERY_SELECTION_TITLE);
    this.lblPopupDesc.SetTextLocalize(Consts.GetInstance().POPUP_TOWER_UNIT_RECOVERY_SELECTION_DESC);
  }

  public void onAutoButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.actionUnitSelection == null)
      return;
    this.actionUnitSelection(TowerUtil.UnitSelectionMode.Auto, this.sequenceType);
  }

  public void onManualButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.actionUnitSelection == null)
      return;
    this.actionUnitSelection(TowerUtil.UnitSelectionMode.Manual, this.sequenceType);
  }

  public void onOkButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.SupplyItems = ((IEnumerable<SupplyItem>) SupplyItem.Merge(((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>().AllSupplies()).ToList<PlayerItem>().ToArray(), ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>().AllTowerSupplies()).ToArray<PlayerItem>())).ToList<SupplyItem>();
    this.SaveDeck = this.SupplyItems.Copy();
    Quest00210aScene.ChangeScene(true, new Quest00210Menu.Param()
    {
      SupplyItems = this.SupplyItems,
      SaveDeck = this.SaveDeck,
      removeButton = false,
      limitedOnly = true,
      mode = Quest00210Scene.Mode.Tower
    }, ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Where<PlayerUnit>((Func<PlayerUnit, bool>) (u => u.tower_is_entry)).Select<PlayerUnit, int>((Func<PlayerUnit, int>) (u => u.id)).ToArray<int>(), this.progress, this.sequenceType);
  }

  public override void onBackButton()
  {
  }
}
