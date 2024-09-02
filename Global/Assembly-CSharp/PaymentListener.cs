// Decompiled with JetBrains decompiler
// Type: PaymentListener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using gu3.gacct;
using gu3.Payment;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class PaymentListener : Singleton<PaymentListener>, IPaymentListener, IGacctListener
{
  private const int verifyRetryMax = 5;
  private static string purchasingProductId;
  private static int verifyRetryCount;
  private bool hasError;
  private static string _apiPath;
  private int retryCnt;

  public static Dictionary<string, Product> Products { get; private set; }

  public static bool IsBattle { get; set; }

  public static int UsedCoinInBattle
  {
    get
    {
      if (PaymentListener.IsBattle)
      {
        NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
        if (Object.op_Inequality((Object) instance, (Object) null) && instance.environment != null)
          return instance.environment.core.continueCount;
      }
      return 0;
    }
  }

  public static Action<int, int> buyCallback { get; set; }

  public static string ApiPath
  {
    get
    {
      if (PaymentListener._apiPath == null)
        PaymentListener._apiPath = WebRequest.BaseURL + "api/v2//charge/";
      return PaymentListener._apiPath;
    }
  }

  [DebuggerHidden]
  public static IEnumerator OpenItemList(bool isBattle)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PaymentListener.\u003COpenItemList\u003Ec__Iterator885()
    {
      isBattle = isBattle,
      \u003C\u0024\u003EisBattle = isBattle
    };
  }

  public static GameObject PopupOpen(GameObject prefab)
  {
    return PaymentListener.IsBattle ? Singleton<NGBattleManager>.GetInstance().popupOpen(prefab) : Singleton<PopupManager>.GetInstance().open(prefab);
  }

  public static void PopupDismiss()
  {
    if (PaymentListener.IsBattle)
      Singleton<NGBattleManager>.GetInstance().popupDismiss();
    else
      Singleton<PopupManager>.GetInstance().dismiss();
  }

  public static void RequestPurchase(string productId)
  {
    PaymentListener.verifyRetryCount = 0;
    PaymentListener.purchasingProductId = productId;
    Singleton<PaymentListener>.GetInstance().StartCoroutine(Singleton<PaymentListener>.GetInstance()._RequestPurchase(productId));
  }

  [DebuggerHidden]
  private IEnumerator _RequestPurchase(string productId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PaymentListener.\u003C_RequestPurchase\u003Ec__Iterator886()
    {
      productId = productId,
      \u003C\u0024\u003EproductId = productId,
      \u003C\u003Ef__this = this
    };
  }

  protected override void Initialize()
  {
    PaymentListener.Products = new Dictionary<string, Product>();
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PaymentListener.\u003CStart\u003Ec__Iterator887()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OnSetupSucceeded(string message)
  {
    PaymentKit.RequestProductDetails(((IEnumerable<CoinProduct>) MasterData.CoinProductList).Where<CoinProduct>((Func<CoinProduct, bool>) (x => x.platform == "android")).Select<CoinProduct, string>((Func<CoinProduct, string>) (x => x.product_id)).ToArray<string>());
  }

  public void OnSetupFailed(string message)
  {
    if (Application.bundleIdentifier != "jp.co.gu3.punkww" || this.retryCnt >= 3)
      return;
    Debug.LogError((object) "**** PaymentKit: cannot be initialization.");
    this.StartCoroutine(this.Start());
    ++this.retryCnt;
  }

  public void OnUpdateProductDetails(ProductContainer container)
  {
    PaymentListener.Products.Clear();
    foreach (Product content in ((Allocator<MetaProduct, Product>) container).Contents)
      PaymentListener.Products[content.id] = content;
  }

  public void OnQueryInventoryFailed(string message) => this.OnSetupSucceeded(message);

  public void OnPurchaseSucceeded(PurchaseContainer purchases)
  {
    Client.SendVerify(PaymentListener.ApiPath, WebQueue.AuthToken, purchases, PaymentListener.Products.Values.ToArray<Product>());
  }

  public void OnPurchaseCanceled(string message) => PurchaseLoadingLayer.Disable();

  public void OnPurchaseFailed(string message) => PurchaseLoadingLayer.Disable();

  public void OnPurchaseAlreadyOwned(string message)
  {
    this.hasError = true;
    PaymentListener.ShowPopupWithMessage(Consts.Lookup("PAYMENT_PURCHASE_ERROR_TITLE"), Consts.Lookup("PAYMENT_PURCHASE_ERROR_ALREADY_OWNED"), (System.Action) (() => this.SetRetryPayment(0.0f)));
  }

  public void OnPurchaseDeferred(string productId)
  {
    this.hasError = true;
    PaymentListener.ShowPopupWithMessage(Consts.Lookup("PAYMENT_PURCHASE_ERROR_TITLE"), Consts.Lookup("PAYMENT_PURCHASE_ERROR_DEFERRED"), (System.Action) (() => PurchaseLoadingLayer.Disable()));
  }

  public void OnPurchaseFinished(bool isSuccess)
  {
    if (isSuccess || this.hasError)
      return;
    PurchaseLoadingLayer.Disable();
  }

  public static void SendAge(int year, int month, int day)
  {
    Client.SendAge(PaymentListener.ApiPath, WebQueue.AuthToken, year, month, day);
  }

  public void OnAgeResponse(AgeResponse response)
  {
    if (((Allocator<MetaAge, Age>) response).Meta.error.isError)
    {
      PurchaseLoadingLayer.Disable();
      PaymentListener.ShowPopupWithMessage(Consts.Lookup("RESPONSE_ERROR_01"), Consts.Lookup("RESPONSE_ERROR_02"), (System.Action) (() => PurchaseLoadingLayer.Disable()));
    }
    else
    {
      Product product = PaymentListener.Products[PaymentListener.purchasingProductId];
      Client.SendChargeLimit(PaymentListener.ApiPath, WebQueue.AuthToken, product.currency, new double[1]
      {
        product.price
      });
    }
  }

  public void OnChargeLimitResponse(ChargeLimitResponse response)
  {
    if (((Allocator<MetaChargeLimit, ChargeLimit>) response).Meta.error.isError && ((Allocator<MetaChargeLimit, ChargeLimit>) response).Meta.error.reasons == "AGE000")
      this.StartCoroutine(this.ShowApprovePurchase());
    else if (((Allocator<MetaChargeLimit, ChargeLimit>) response).Meta.error.isError)
    {
      PurchaseLoadingLayer.Disable();
      PaymentListener.ShowPopupWithMessage(Consts.Lookup("RESPONSE_ERROR_01"), Consts.Lookup("RESPONSE_ERROR_02"), (System.Action) (() => PurchaseLoadingLayer.Disable()));
    }
    else
    {
      bool flag = false;
      foreach (ChargeLimit content in ((Allocator<MetaChargeLimit, ChargeLimit>) response).Contents)
      {
        if (content.active)
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        PaymentListener.ShowPopupWithMessage(Consts.Lookup("PAYMENT_LISTENER_ON_CHARGE_LIMIT_RESPONSE"), Consts.Lookup("SHOP_999101_SET_TEXT"), (System.Action) (() => PurchaseLoadingLayer.Disable()));
      else
        PaymentKit.StartPayment(PaymentListener.purchasingProductId);
    }
  }

  public void OnVerifyResponse(VerifyResponse response)
  {
    if (((Allocator<MetaVerify, Verify>) response).Meta.error.isError)
    {
      if (PaymentListener.verifyRetryCount++ < 5)
        PaymentKit.ResumePayment();
      else
        PaymentListener.ShowPopupWithMessage(Consts.Lookup("RESPONSE_ERROR_03"), Consts.Lookup("RESPONSE_ERROR_04"), (System.Action) (() => this.SetRetryPayment(0.0f)));
    }
    else
    {
      PurchaseLoadingLayer.Disable();
      int currentPaidCoin = ((Allocator<MetaVerify, Verify>) response).Meta.CurrentPaidCoin;
      int currentFreeCoin = ((Allocator<MetaVerify, Verify>) response).Meta.CurrentFreeCoin;
      int additionalPaidCoin = ((Allocator<MetaVerify, Verify>) response).Meta.AdditionalPaidCoin;
      int additionalFreeCoin = ((Allocator<MetaVerify, Verify>) response).Meta.AdditionalFreeCoin;
      Player data = SMManager.Get<Player>();
      if (data != null)
      {
        data.free_coin = currentFreeCoin;
        data.paid_coin = currentPaidCoin;
        SMManager.Change<Player>(data);
      }
      int currentCoin = currentPaidCoin + currentFreeCoin - PaymentListener.UsedCoinInBattle;
      int num = additionalPaidCoin + additionalFreeCoin;
      Dictionary<string, CoinProduct> dictionary = ((IEnumerable<CoinProduct>) MasterData.CoinProductList).Where<CoinProduct>((Func<CoinProduct, bool>) (x => x.platform == "android")).ToDictionary<CoinProduct, string>((Func<CoinProduct, string>) (x => x.product_id));
      foreach (Verify content in ((Allocator<MetaVerify, Verify>) response).Contents)
      {
        int addCoin = 0;
        CoinProduct product;
        if (dictionary.TryGetValue(content.productId, out product))
          addCoin = product.additional_free_coin + product.additional_paid_coin;
        Shop0079Menu.OnPurchaseSucceeded(product, currentCoin, addCoin);
        currentCoin -= addCoin;
        EventTracker.SendPayment(content.productId);
      }
      if (PaymentListener.IsBattle && PaymentListener.buyCallback != null)
        PaymentListener.buyCallback(currentCoin, num);
      this.StartCoroutine("SendCoinbonusPresent");
      Product product1 = PaymentListener.Products[PaymentListener.purchasingProductId];
      MetapsAnalyticsScript.TrackPurchase(product1.id, product1.price, product1.currency);
      Appsflyer.TrackPurchase(product1.id, product1.price, product1.currency);
    }
  }

  public void OnPurchaseCreditLimit(string message)
  {
    PurchaseLoadingLayer.Disable();
    PaymentListener.ShowPopupWithMessage(Consts.Lookup("PAYMENT_LISTENER_ON_CHARGE_LIMIT_RESPONSE"), message, (System.Action) (() => PurchaseLoadingLayer.Disable()));
  }

  [DebuggerHidden]
  private IEnumerator SendCoinbonusPresent()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PaymentListener.\u003CSendCoinbonusPresent\u003Ec__Iterator888 presentCIterator888 = new PaymentListener.\u003CSendCoinbonusPresent\u003Ec__Iterator888();
    return (IEnumerator) presentCIterator888;
  }

  private void OnApplicationPause(bool pauseState)
  {
    if (pauseState)
      return;
    this.SetRetryPayment(0.0f);
  }

  public void SetRetryPayment(float wait = 300f)
  {
    this.StopCoroutine("_SetRetryPayment");
    this.StartCoroutine("_SetRetryPayment", (object) wait);
  }

  [DebuggerHidden]
  private IEnumerator _SetRetryPayment(float wait)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PaymentListener.\u003C_SetRetryPayment\u003Ec__Iterator889()
    {
      wait = wait,
      \u003C\u0024\u003Ewait = wait
    };
  }

  public static void ShowPopupWithMessage(string title, string message, System.Action callback = null)
  {
    PopupCommon component = PaymentListener.PopupOpen(PopupCommon.LoadPrefab()).GetComponent<PopupCommon>();
    component.Init(title, message);
    component.OK.onClick.Clear();
    EventDelegate.Add(component.OK.onClick, (EventDelegate.Callback) (() => PaymentListener.PopupDismiss()));
    if (callback == null)
      return;
    EventDelegate.Add(component.OK.onClick, (EventDelegate.Callback) (() => callback()));
  }

  [DebuggerHidden]
  private IEnumerator ShowInputBirthday()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PaymentListener.\u003CShowInputBirthday\u003Ec__Iterator88A birthdayCIterator88A = new PaymentListener.\u003CShowInputBirthday\u003Ec__Iterator88A();
    return (IEnumerator) birthdayCIterator88A;
  }

  public static void ShowInputBirthday(bool isYes)
  {
    if (isYes)
      Singleton<PaymentListener>.GetInstance().StartCoroutine(Singleton<PaymentListener>.GetInstance().ShowInputBirthday());
    else
      PurchaseLoadingLayer.Disable();
  }

  [DebuggerHidden]
  private IEnumerator ShowApprovePurchase()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PaymentListener.\u003CShowApprovePurchase\u003Ec__Iterator88B purchaseCIterator88B = new PaymentListener.\u003CShowApprovePurchase\u003Ec__Iterator88B();
    return (IEnumerator) purchaseCIterator88B;
  }
}
