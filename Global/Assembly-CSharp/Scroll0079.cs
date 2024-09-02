// Decompiled with JetBrains decompiler
// Type: Scroll0079
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using gu3.Payment;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
public class Scroll0079 : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtExplanation;
  [SerializeField]
  protected UILabel TxtItemname;
  [SerializeField]
  protected UILabel TxtPrice;
  [SerializeField]
  protected UILabel TxtPopupkisekinum;
  [SerializeField]
  private UI2DSprite linkItem;
  public Shop0079Menu menu;
  private Sprite sendSprite;
  private string sendName;
  private int sendQuantity;
  private CoinProduct _coinProduct;
  private Product _product;
  public int purchasedStoneQuentity;

  public Player player { get; set; }

  [DebuggerHidden]
  public IEnumerator Init(
    Product productDetail,
    bool is_coinbonus_active,
    CoinBonusReward coinbonusReward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Scroll0079.\u003CInit\u003Ec__Iterator412()
    {
      productDetail = productDetail,
      is_coinbonus_active = is_coinbonus_active,
      coinbonusReward = coinbonusReward,
      \u003C\u0024\u003EproductDetail = productDetail,
      \u003C\u0024\u003Eis_coinbonus_active = is_coinbonus_active,
      \u003C\u0024\u003EcoinbonusReward = coinbonusReward,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetSprite(CoinProduct cp, bool is_coinbonus_active)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Scroll0079.\u003CSetSprite\u003Ec__Iterator413()
    {
      cp = cp,
      is_coinbonus_active = is_coinbonus_active,
      \u003C\u0024\u003Ecp = cp,
      \u003C\u0024\u003Eis_coinbonus_active = is_coinbonus_active,
      \u003C\u003Ef__this = this
    };
  }

  private string ExtractNumber(string str) => Regex.Replace(str, "[^\\d]", string.Empty);

  private void SetText(Product pd, bool is_coinbonus_active, CoinBonusReward coinbonusReward)
  {
    if (is_coinbonus_active)
      this.TxtItemname.SetTextLocalize(pd.localizedTitle.ToConverter() + "[ff0000]" + coinbonusReward.client_coin_shop_title.ToConverter());
    else
      this.TxtItemname.SetTextLocalize(pd.localizedTitle);
    this.TxtExplanation.SetTextLocalize(pd.localizedDescription);
    CoinProduct activeProductData = MasterData.CoinProductList.GetActiveProductData(pd.id);
    this.TxtPopupkisekinum.SetTextLocalize(Consts.Lookup("SHOP_0079_TXT_POPUP_KISEKINUM", (IDictionary) new Hashtable()
    {
      {
        (object) "kisekiNum",
        (object) (activeProductData.additional_free_coin + activeProductData.additional_paid_coin)
      }
    }));
    this.TxtPrice.SetTextLocalize(pd.localizedPrice.ToString());
  }

  [DebuggerHidden]
  private IEnumerator openPopup999101()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Scroll0079.\u003CopenPopup999101\u003Ec__Iterator414 popup999101CIterator414 = new Scroll0079.\u003CopenPopup999101\u003Ec__Iterator414();
    return (IEnumerator) popup999101CIterator414;
  }

  public void onBuy()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    PaymentListener.RequestPurchase(this._product.id);
  }
}
