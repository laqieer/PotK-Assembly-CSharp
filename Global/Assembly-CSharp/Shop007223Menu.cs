// Decompiled with JetBrains decompiler
// Type: Shop007223Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Shop007223Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtProductName;
  private Shop00722Menu menu0722;

  public void Init(PlayerShopArticle article, Shop00722Menu menu)
  {
    this.menu0722 = menu;
    this.txtProductName.SetTextLocalize(article.article.name);
  }

  public virtual void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    this.menu0722.UpdateInfo();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnPopupYes();
}
