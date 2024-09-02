// Decompiled with JetBrains decompiler
// Type: Popup017182Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class Popup017182Menu : BattleBackButtonMenuBase
{
  [SerializeField]
  private UILabel label;

  public void Awake() => this.label.SetTextLocalize(Consts.GetInstance().BATTLE_SUSPEND_POPUP);

  public void IbtnYes()
  {
    this.battleManager.getController<BattleAIController>().stopAIAction();
    this.battleManager.getManager<BattleTimeManager>().setPhaseState(BL.Phase.suspend);
    this.battleManager.popupCloseAll();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo() => this.battleManager.popupDismiss();
}
