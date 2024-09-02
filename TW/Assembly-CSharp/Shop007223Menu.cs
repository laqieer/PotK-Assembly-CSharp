// Decompiled with JetBrains decompiler
// Type: Shop007223Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Shop007223Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtProductName;
  [SerializeField]
  private UILabel txtOverlimitTxt;
  private Shop00722Menu menu0722;
  private bool giveMessage;

  public void Init(PlayerShopArticle article, Shop00722Menu menu, bool giveMessage)
  {
    this.menu0722 = menu;
    this.giveMessage = giveMessage;
    this.txtProductName.SetTextLocalize(article.article.name);
    ((Component) this.txtOverlimitTxt).gameObject.SetActive(giveMessage);
  }

  public virtual void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.menu0722.UpdateInfo();
  }

  public override void onBackButton() => this.IbtnPopupYes();
}
