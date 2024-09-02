// Decompiled with JetBrains decompiler
// Type: Shop0079Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop0079Menu : BackButtonMenuBase
{
  public GameObject scrollPrefab;
  public NGxScroll ngxScroll;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UILabel TxtExplanation;
  [SerializeField]
  private UILabel TxtItemname;
  [SerializeField]
  private UILabel TxtPopupkisekinum;
  [SerializeField]
  private UILabel TxtPopuptitle;
  [SerializeField]
  private UILabel TxtPrice;
  public static long playerRevision = -1;

  protected override void Update()
  {
    base.Update();
    long num = SMManager.Revision<Player>();
    if (Shop0079Menu.playerRevision != num)
      this.TxtPopupkisekinum.SetTextLocalize(SMManager.Get<Player>().coin);
    Shop0079Menu.playerRevision = num;
    if (!LCMPayItemLst.getInstance.isNeddRefresh())
      return;
    LCMPayItemLst.getInstance.setRefresh(false);
    this.OutsideScrollText();
  }

  private string getProductId(string productid)
  {
    string productId = productid;
    int length = productid.IndexOf(".");
    if (length > 0)
      productId = productid.Substring(0, length);
    return productId;
  }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerShopArticle[] playerShopArticles,
    Player player,
    WebAPI.Response.CoinbonusHistory history)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0079Menu.\u003CInit\u003Ec__Iterator4AF()
    {
      history = history,
      \u003C\u0024\u003Ehistory = history,
      \u003C\u003Ef__this = this
    };
  }

  public void OutsideScrollText()
  {
    Consts instance = Consts.GetInstance();
    string text = instance.KISEKI_DESCRIPTION;
    int lmoney = SDK.instance.getLMoney();
    if (lmoney > 0)
      text = instance.KISEKI_DESCRIPTION + "\n" + instance.KISEKI_LMONEY + lmoney.ToString();
    this.TxtDescription.SetTextLocalize(text);
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    PaymentListener.PopupDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public static void OnPurchaseSucceeded(
    CoinProduct product,
    int beforeCoin,
    int currentCoin,
    int is_discount,
    bool isMonth)
  {
    DDebug.Log(nameof (OnPurchaseSucceeded));
    Singleton<CommonRoot>.GetInstance().StartCoroutine(Shop0079Menu.popupAlert00711(product, beforeCoin, currentCoin, is_discount, isMonth));
  }

  [DebuggerHidden]
  public static IEnumerator popupAlert00711(
    CoinProduct product,
    int beforeCoin,
    int currentCoin,
    int is_discount,
    bool isMonth)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0079Menu.\u003CpopupAlert00711\u003Ec__Iterator4B0()
    {
      product = product,
      beforeCoin = beforeCoin,
      currentCoin = currentCoin,
      is_discount = is_discount,
      isMonth = isMonth,
      \u003C\u0024\u003Eproduct = product,
      \u003C\u0024\u003EbeforeCoin = beforeCoin,
      \u003C\u0024\u003EcurrentCoin = currentCoin,
      \u003C\u0024\u003Eis_discount = is_discount,
      \u003C\u0024\u003EisMonth = isMonth
    };
  }

  public void IbtnFonds() => this.StartCoroutine(PopupUtility._007_19());

  public void IbtnSpecific() => this.StartCoroutine(PopupUtility._007_18());
}
