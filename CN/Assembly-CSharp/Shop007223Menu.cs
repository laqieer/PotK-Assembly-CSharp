// Decompiled with JetBrains decompiler
// Type: Shop007223Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
