// Decompiled with JetBrains decompiler
// Type: Shop0574Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Earth;
using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop0574Scroll : MonoBehaviour
{
  [SerializeField]
  private GameObject slcSoldout;
  [SerializeField]
  private GameObject slcZenyShortage;
  [SerializeField]
  private GameObject ibtnBuy;
  [SerializeField]
  private UILabel txtQuantity20;
  [SerializeField]
  private UILabel txtPrice22;
  [SerializeField]
  private UILabel txtOwn20;
  [SerializeField]
  private UILabel txtItemName28;
  [SerializeField]
  private UILabel txtIntroduction22;
  [SerializeField]
  private GameObject linkNoBottom;
  [SerializeField]
  private GameObject linkNormal;
  private GameObject DirThum;
  private Action<EarthShopArticle, GameObject> btnAction;
  private Action<EarthShopArticle> openDetailAction;
  private EarthShopArticle shopArticle;
  private GameObject detailPopupF;

  [DebuggerHidden]
  private IEnumerator SetThumbnail(EarthShopContent content)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0574Scroll.\u003CSetThumbnail\u003Ec__Iterator85B()
    {
      content = content,
      \u003C\u0024\u003Econtent = content,
      \u003C\u003Ef__this = this
    };
  }

  private void SetLimit(EarthShopArticle article)
  {
    int num1 = 0;
    int num2 = 0;
    this.shopArticle = article;
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    if (Object.op_Inequality((Object) instanceOrNull, (Object) null))
    {
      num1 = instanceOrNull.GetProperty(MasterDataTable.CommonRewardType.money);
      num2 = instanceOrNull.GetShopPurchaseCount(this.shopArticle.ID);
    }
    this.slcZenyShortage.SetActive(false);
    this.slcSoldout.SetActive(false);
    this.ibtnBuy.SetActive(false);
    if (article.limit.HasValue && article.limit.Value - num2 <= 0)
    {
      this.slcZenyShortage.SetActive(false);
      this.slcSoldout.SetActive(true);
      this.ibtnBuy.SetActive(false);
    }
    else if (num1 < article.price)
    {
      this.slcZenyShortage.SetActive(true);
      this.slcSoldout.SetActive(false);
      this.ibtnBuy.SetActive(false);
    }
    else
    {
      this.slcZenyShortage.SetActive(false);
      this.slcSoldout.SetActive(false);
      this.ibtnBuy.SetActive(true);
    }
    if (article.limit.HasValue)
    {
      ((Component) this.txtQuantity20).gameObject.SetActive(true);
      this.txtQuantity20.SetTextLocalize(string.Format(Consts.GetInstance().SHOP_0074_SCROLL_ARTICLE_LIMIT_VALUE, (object) (article.limit.Value - num2)));
    }
    else
      ((Component) this.txtQuantity20).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  public IEnumerator Init(
    EarthShopArticle article,
    Action<EarthShopArticle, GameObject> action,
    Action<EarthShopArticle> detailAction)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0574Scroll.\u003CInit\u003Ec__Iterator85C()
    {
      action = action,
      detailAction = detailAction,
      article = article,
      \u003C\u0024\u003Eaction = action,
      \u003C\u0024\u003EdetailAction = detailAction,
      \u003C\u0024\u003Earticle = article,
      \u003C\u003Ef__this = this
    };
  }

  public void buyBtnAction()
  {
    if (this.btnAction == null)
      return;
    this.btnAction(this.shopArticle, this.DirThum);
  }

  public void onDetail()
  {
    if (Singleton<PopupManager>.GetInstance().isOpen || this.openDetailAction == null)
      return;
    this.openDetailAction(this.shopArticle);
  }
}
