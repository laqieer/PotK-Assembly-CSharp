// Decompiled with JetBrains decompiler
// Type: Shop00722Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00722Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll scroll;
  [SerializeField]
  private GameObject dynProductBanner;
  [SerializeField]
  private UILabel txtProductDescription;
  [SerializeField]
  private UIButton ibtnPopupBuy;
  [SerializeField]
  private GameObject slcItemFull;
  [SerializeField]
  public UIButton ibtn_Fonds;
  [SerializeField]
  public UIButton ibtn_Specific;
  private int m_shopID;
  private PlayerShopArticle m_article;
  private GameObject detailPopup;
  private Shop00721SpecialShopProduction bannerObject;

  public void UpdateInfo() => this.StartCoroutine(this.UpdateArticleInfo());

  [DebuggerHidden]
  public IEnumerator UpdateArticleInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00722Menu.\u003CUpdateArticleInfo\u003Ec__Iterator4AF()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetBtnActive(PlayerShopArticle article, DateTime serverTime)
  {
    this.ibtnPopupBuy.isEnabled = true;
    this.slcItemFull.SetActive(false);
    if (article.recharge_at.HasValue && serverTime < article.recharge_at.Value)
    {
      this.ibtnPopupBuy.isEnabled = false;
    }
    else
    {
      if (article.limit.HasValue)
      {
        int? limit = article.limit;
        if ((!limit.HasValue ? 0 : (limit.Value < 0 ? 1 : 0)) != 0)
        {
          this.ibtnPopupBuy.isEnabled = false;
          return;
        }
      }
      if (!article.article.limit.HasValue && !article.article.daily_limit.HasValue || (!article.article.limit.HasValue || article.limit.Value > 0) && (!article.article.daily_limit.HasValue || article.limit.Value > 0))
        return;
      this.ibtnPopupBuy.isEnabled = false;
    }
  }

  [DebuggerHidden]
  public IEnumerator Init(
    int shopID,
    PlayerShopArticle article,
    GameObject product,
    DateTime serverTime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00722Menu.\u003CInit\u003Ec__Iterator4B0()
    {
      shopID = shopID,
      article = article,
      product = product,
      serverTime = serverTime,
      \u003C\u0024\u003EshopID = shopID,
      \u003C\u0024\u003Earticle = article,
      \u003C\u0024\u003Eproduct = product,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u003Ef__this = this
    };
  }

  public void IconBtnAction(ShopContent content)
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowDetailPopup(content));
  }

  [DebuggerHidden]
  private IEnumerator ShowDetailPopup(ShopContent content)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00722Menu.\u003CShowDetailPopup\u003Ec__Iterator4B1()
    {
      content = content,
      \u003C\u0024\u003Econtent = content,
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update() => base.Update();

  public virtual void Foreground()
  {
  }

  public void IbtnBuy() => this.StartCoroutine(this.popupAlert007222());

  public void IbtnFonds()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility._007_19());
  }

  public void IbtnSpecific()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility._007_18());
  }

  [DebuggerHidden]
  private IEnumerator popupAlert007222()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00722Menu.\u003CpopupAlert007222\u003Ec__Iterator4B2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void VScrollBar()
  {
  }

  public void BackScene() => this.backScene();
}
