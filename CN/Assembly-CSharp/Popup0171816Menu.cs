// Decompiled with JetBrains decompiler
// Type: Popup0171816Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
