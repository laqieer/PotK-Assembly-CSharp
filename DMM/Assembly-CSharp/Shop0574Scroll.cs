// Decompiled with JetBrains decompiler
// Type: Shop0574Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Earth;
using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

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
  private System.Action<EarthShopArticle, GameObject> btnAction;
  private System.Action<EarthShopArticle> openDetailAction;
  private EarthShopArticle shopArticle;
  private GameObject detailPopupF;

  private IEnumerator SetThumbnail(EarthShopContent content)
  {
    this.DirThum = this.linkNoBottom;
    bool visibleBottom = false;
    switch (content.entity_type)
    {
      case MasterDataTable.CommonRewardType.unit:
      case MasterDataTable.CommonRewardType.material_unit:
        visibleBottom = true;
        this.DirThum = this.linkNormal;
        break;
      case MasterDataTable.CommonRewardType.gear:
      case MasterDataTable.CommonRewardType.material_gear:
      case MasterDataTable.CommonRewardType.gear_body:
        visibleBottom = true;
        this.DirThum = this.linkNormal;
        break;
      case MasterDataTable.CommonRewardType.gacha_ticket:
        yield break;
      case MasterDataTable.CommonRewardType.season_ticket:
        yield break;
    }
    IEnumerator e = this.DirThum.GetOrAddComponent<CreateIconObject>().CreateThumbnail(content.entity_type, content.entity_id, visibleBottom: visibleBottom);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private void SetLimit(EarthShopArticle article)
  {
    long num1 = 0;
    int num2 = 0;
    this.shopArticle = article;
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    if ((UnityEngine.Object) instanceOrNull != (UnityEngine.Object) null)
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
    else if (num1 < (long) article.price)
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
      this.txtQuantity20.gameObject.SetActive(true);
      this.txtQuantity20.SetTextLocalize(string.Format(Consts.GetInstance().SHOP_0074_SCROLL_ARTICLE_LIMIT_VALUE, (object) (article.limit.Value - num2)));
    }
    else
      this.txtQuantity20.gameObject.SetActive(false);
  }

  public IEnumerator Init(
    EarthShopArticle article,
    System.Action<EarthShopArticle, GameObject> action,
    System.Action<EarthShopArticle> detailAction)
  {
    this.btnAction = action;
    this.openDetailAction = detailAction;
    this.txtItemName28.SetTextLocalize(article.name);
    this.txtIntroduction22.SetTextLocalize(article.description);
    this.txtPrice22.SetTextLocalize(article.price);
    this.txtOwn20.SetTextLocalize(article.ShopContents.GetPossessionNum());
    this.SetLimit(article);
    IEnumerator e = this.SetThumbnail(article.ShopContents);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
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
