// Decompiled with JetBrains decompiler
// Type: Popup0171818Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;

#nullable disable
public class Popup0171818Menu : BattleBackButtonMenuBase
{
  public void IbtnYes()
  {
    if (this.env.core.phaseState.state == BL.Phase.player)
    {
      if (this.env.core.isAutoBattle.value)
        this.battleManager.getController<BattleAIController>().stopAIAction();
      foreach (BL.Unit unit in this.env.core.playerUnits.value)
        this.env.core.getUnitPosition(unit).completeActionUnit(this.env.core, true);
    }
    this.battleManager.popupCloseAll();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo() => this.battleManager.popupDismiss();
}
