// Decompiled with JetBrains decompiler
// Type: Shop0079Menu
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
  private long playerRevision = -1;

  protected override void Update()
  {
    base.Update();
    long num = SMManager.Revision<Player>();
    if (this.playerRevision != num)
      this.TxtPopupkisekinum.SetTextLocalize(SMManager.Get<Player>().coin - PaymentListener.UsedCoinInBattle);
    this.playerRevision = num;
  }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerShopArticle[] playerShopArticles,
    Player player,
    WebAPI.Response.CoinbonusHistory history)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0079Menu.\u003CInit\u003Ec__Iterator415()
    {
      history = history,
      \u003C\u0024\u003Ehistory = history,
      \u003C\u003Ef__this = this
    };
  }

  public void OutsideScrollText()
  {
    this.TxtDescription.SetTextLocalize(Consts.Lookup("KISEKI_DESCRIPTION"));
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    PaymentListener.PopupDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public static void OnPurchaseSucceeded(CoinProduct product, int currentCoin, int addCoin)
  {
    Singleton<CommonRoot>.GetInstance().StartCoroutine(Shop0079Menu.popupAlert00711(product, currentCoin, addCoin));
  }

  [DebuggerHidden]
  public static IEnumerator popupAlert00711(CoinProduct product, int currentCoin, int addCoin)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0079Menu.\u003CpopupAlert00711\u003Ec__Iterator416()
    {
      product = product,
      currentCoin = currentCoin,
      addCoin = addCoin,
      \u003C\u0024\u003Eproduct = product,
      \u003C\u0024\u003EcurrentCoin = currentCoin,
      \u003C\u0024\u003EaddCoin = addCoin
    };
  }

  public void IbtnFonds() => this.StartCoroutine(PopupUtility._007_19());

  public void IbtnSpecific() => this.StartCoroutine(PopupUtility._007_18());
}
