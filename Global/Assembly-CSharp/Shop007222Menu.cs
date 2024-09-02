// Decompiled with JetBrains decompiler
// Type: Shop007222Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop007222Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtPrice;
  [SerializeField]
  private UILabel txtProductName;
  [SerializeField]
  private GameObject dynHime;
  private Shop00722Menu m_menu;
  private PlayerShopArticle m_article;

  public void Init(PlayerShopArticle article, Shop00722Menu menu)
  {
    this.m_menu = menu;
    this.m_article = article;
    if (article.article.pay_type == CommonPayType.coin)
    {
      this.dynHime.SetActive(true);
      this.txtPrice.SetTextLocalize(Consts.Lookup("SHOP_00721_TXT_PRICE_COIN", (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) article.article.price
        }
      }));
    }
    else if (article.article.pay_type == CommonPayType.currency)
    {
      this.dynHime.SetActive(false);
      this.txtPrice.SetTextLocalize(Consts.Lookup("SHOP_00721_TXT_PRICE", (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) article.article.price
        }
      }));
    }
    else
    {
      this.dynHime.SetActive(false);
      this.txtPrice.SetTextLocalize(Consts.Lookup("SHOP_00721_TXT_PRICE_COIN", (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) article.article.price
        }
      }));
    }
    this.txtProductName.SetTextLocalize(article.article.name);
  }

  public void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss(true);
    if (SMManager.Get<Player>().coin < this.m_article.article.price)
      this.StartCoroutine(PopupUtility._999_3_1(Consts.Lookup("SHOP_99931_TXT_DESCRIPTION"), string.Empty));
    else
      this.StartCoroutine(this.ShopBuy());
  }

  [DebuggerHidden]
  private IEnumerator ShopBuy()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop007222Menu.\u003CShopBuy\u003Ec__Iterator3E2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
