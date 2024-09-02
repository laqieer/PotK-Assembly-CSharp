// Decompiled with JetBrains decompiler
// Type: Tower029SupplyConfirmPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class Tower029SupplyConfirmPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel lblTitle;
  [SerializeField]
  private UILabel lblDesc;
  private System.Action actionYesButton;
  private bool isPush;

  public void Initialize(System.Action action)
  {
    if ((UnityEngine.Object) this.GetComponent<UIWidget>() != (UnityEngine.Object) null)
      this.GetComponent<UIWidget>().alpha = 0.0f;
    this.actionYesButton = action;
    this.lblTitle.SetTextLocalize(Consts.GetInstance().POPUP_TOWER_SUPPLY_CONFIRM_TITLE);
    this.lblDesc.SetTextLocalize(Consts.GetInstance().POPUP_TOWER_SUPPLY_CONFIRM_DESC);
  }

  public void onYesButton()
  {
    if (this.isPush)
      return;
    this.isPush = true;
    if (this.actionYesButton == null)
      return;
    this.actionYesButton();
  }

  public override void onBackButton()
  {
    if (this.isPush)
      return;
    this.isPush = true;
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
