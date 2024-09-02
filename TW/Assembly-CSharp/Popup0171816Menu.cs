// Decompiled with JetBrains decompiler
// Type: Popup0171816Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
public class Popup0171816Menu : BattleBackButtonMenuBase
{
  public void IbtnYes()
  {
    this.env.core.isAutoBattle.value = true;
    Singleton<NGBattleManager>.GetInstance().SetAutoBattleBtnChanged();
    this.battleManager.popupCloseAll();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo()
  {
    Singleton<NGBattleManager>.GetInstance().SetAutoBattleBtnChanged();
    this.battleManager.popupDismiss();
  }
}
