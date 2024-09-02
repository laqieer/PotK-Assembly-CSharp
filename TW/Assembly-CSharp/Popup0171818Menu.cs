// Decompiled with JetBrains decompiler
// Type: Popup0171818Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;

#nullable disable
public class Popup0171818Menu : BattleBackButtonMenuBase
{
  public void IbtnYes()
  {
    Singleton<NGBattleManager>.GetInstance().SetAutoBattleBtnChanged();
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

  public void IbtnNo()
  {
    Singleton<NGBattleManager>.GetInstance().SetAutoBattleBtnChanged();
    this.battleManager.popupDismiss();
  }
}
