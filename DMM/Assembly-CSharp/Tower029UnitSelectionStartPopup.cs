﻿// Decompiled with JetBrains decompiler
// Type: Tower029UnitSelectionStartPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Tower029UnitSelectionStartPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel lblPopupTitle;
  [SerializeField]
  private UILabel lblPopupDesc;
  private System.Action<TowerUtil.UnitSelectionMode, TowerUtil.SequenceType> actionUnitSelection;
  private System.Action cancel;
  private TowerUtil.SequenceType sequenceType;

  public void Initialize(
    System.Action<TowerUtil.UnitSelectionMode, TowerUtil.SequenceType> action,
    System.Action cancel,
    TowerUtil.SequenceType sequenceType = TowerUtil.SequenceType.Start)
  {
    if ((UnityEngine.Object) this.GetComponent<UIWidget>() != (UnityEngine.Object) null)
      this.GetComponent<UIWidget>().alpha = 0.0f;
    this.actionUnitSelection = action;
    this.cancel = cancel;
    this.sequenceType = sequenceType;
    this.lblPopupTitle.SetTextLocalize(Consts.GetInstance().POPUP_TOWER_SELECTION_POPUP_TITLE);
    this.lblPopupDesc.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_TOWER_SELECTION_POPUP_DESC, (IDictionary) new Hashtable()
    {
      {
        (object) "num",
        (object) TowerUtil.MaxUnitNum
      }
    }));
  }

  public void onAutoButton() => this.actionUnitSelection(TowerUtil.UnitSelectionMode.Auto, this.sequenceType);

  public void onManualButton() => this.actionUnitSelection(TowerUtil.UnitSelectionMode.Manual, this.sequenceType);

  public override void onBackButton()
  {
    if (this.cancel != null)
      this.cancel();
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
