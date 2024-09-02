// Decompiled with JetBrains decompiler
// Type: Popup017192Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

public class Popup017192Menu : NGBattleMenuBase
{
  public void IbtnYes()
  {
    this.env.core.isAutoBattle.value = false;
    this.battleManager.popupDismiss();
  }

  public void IbtnNo() => this.battleManager.popupDismiss();
}
