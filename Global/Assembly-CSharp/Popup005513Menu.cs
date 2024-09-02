// Decompiled with JetBrains decompiler
// Type: Popup005513Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class Popup005513Menu : BackButtonMonoBehaiviour
{
  private System.Action action;

  public void SetYesAction(System.Action action) => this.action = action;

  public void IbtnYes()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.action();
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
