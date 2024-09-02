// Decompiled with JetBrains decompiler
// Type: Popup004131Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class Popup004131Menu : BackButtonMenuBase
{
  private Unit00499Menu menu;

  public void Init(Unit00499Menu menu) => this.menu = menu;

  public void IbtnYes()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.StartCoroutine(this.menu.Transmigration());
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
