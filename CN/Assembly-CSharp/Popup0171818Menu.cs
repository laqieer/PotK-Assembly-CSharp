// Decompiled with JetBrains decompiler
// Type: Popup0171818Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
