// Decompiled with JetBrains decompiler
// Type: Shop0071PopupUnitItemPlus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class Shop0071PopupUnitItemPlus : BackButtonMenuBase
{
  private Shop0071Menu menu_;

  public void initialize(Shop0071Menu menu) => this.menu_ = menu;

  public void onClickUnitPlus()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
    this.menu_.popupUnitPlus();
  }

  public void onClickItemPlus()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
    this.menu_.popupItemPlus();
  }

  public override void onBackButton() => this.onClickClose();

  public void onClickClose()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
