// Decompiled with JetBrains decompiler
// Type: Popup017182Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Popup017182Menu : BattleBackButtonMenuBase
{
  [SerializeField]
  private UILabel label;

  public void Awake() => this.label.SetTextLocalize(Consts.Lookup("BATTLE_SUSPEND_POPUP"));

  public void IbtnYes()
  {
    this.battleManager.getController<BattleAIController>().stopAIAction();
    this.battleManager.getManager<BattleTimeManager>().setPhaseState(BL.Phase.suspend);
    this.battleManager.popupCloseAll();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo() => this.battleManager.popupDismiss();
}
