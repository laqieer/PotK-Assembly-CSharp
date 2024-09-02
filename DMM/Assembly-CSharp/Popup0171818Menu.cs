// Decompiled with JetBrains decompiler
// Type: Popup0171818Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;

public class Popup0171818Menu : BattleBackButtonMenuBase
{
  public void IbtnYes()
  {
    if (this.env.core.phaseState.state == BL.Phase.player)
    {
      if (this.env.core.isAutoBattle.value)
        this.battleManager.getController<BattleAIController>().stopAIAction();
      foreach (BL.Unit unit in this.env.core.playerUnits.value)
      {
        if (!unit.IsCharm)
        {
          this.env.core.setSomeAction();
          this.env.core.getUnitPosition(unit).completeActionUnit(this.env.core, true);
        }
      }
    }
    this.battleManager.popupCloseAll();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo() => this.battleManager.popupDismiss();
}
