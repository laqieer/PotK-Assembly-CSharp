// Decompiled with JetBrains decompiler
// Type: Popup023417Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class Popup023417Menu : BackButtonMenuBase
{
  public virtual void IbtnBack() => Singleton<PopupManager>.GetInstance().onDismiss();

  public virtual void IbtnTeamSetting()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Unit0046Scene.changeScene(true);
  }

  public void IbtnNo() => this.IbtnBack();

  public override void onBackButton() => this.IbtnNo();
}
