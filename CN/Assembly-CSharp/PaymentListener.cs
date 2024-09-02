// Decompiled with JetBrains decompiler
// Type: PaymentListener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class PaymentListener : Singleton<PaymentListener>
{
  private const int verifyRetryMax = 5;
  private static string purchasingProductId;
  private static int verifyRetryCount;
  private bool hasError;
  private bool isSendVerify;
  private static string _apiPath;
  private int retryCnt;

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
    return (IEnumerator) new PaymentListener.\u003COpenItemList\u003Ec__IteratorA00()
    {
      isBattle = isBattle,
      \u003C\u0024\u003EisBattle = isBattle
    };
  }

  public static GameObject PopupOpen(GameObject prefab)
  {
    Debug.Log((object) ("*** PaymentListener PopupOpen: " + (object) prefab + " ****"));
    return PaymentListener.IsBattle ? Singleton<NGBattleManager>.GetInstance().popupOpen(prefab) : Singleton<PopupManager>.GetInstance().open(prefab);
  }

  public static void PopupDismiss()
  {
    Debug.Log((object) "*** PaymentListener PopupDismiss ***");
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
    return (IEnumerator) new PaymentListener.\u003C_RequestPurchase\u003Ec__IteratorA01()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Initialize()
  {
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PaymentListener.\u003CStart\u003Ec__IteratorA02 startCIteratorA02 = new PaymentListener.\u003CStart\u003Ec__IteratorA02();
    return (IEnumerator) startCIteratorA02;
  }

  public void OnSetupSucceeded(string message)
  {
    ((IEnumerable<CoinProduct>) MasterData.CoinProductList).Where<CoinProduct>((Func<CoinProduct, bool>) (x => x.platform == "android")).Select<CoinProduct, string>((Func<CoinProduct, string>) (x => x.product_id)).ToArray<string>();
  }

  public void OnSetupFailed(string message)
  {
    if (Application.bundleIdentifier != "jp.co.gu3.punk" || this.retryCnt >= 3)
      return;
    Debug.LogError((object) "**** PaymentKit: cannot be initialization.");
    this.StartCoroutine(this.Start());
    ++this.retryCnt;
  }

  public void OnQueryInventoryFailed(string message) => this.OnSetupSucceeded(message);

  public void OnPurchaseCanceled(string message) => PurchaseLoadingLayer.Disable();

  public void OnPurchaseFailed(string message) => PurchaseLoadingLayer.Disable();

  public void OnPurchaseAlreadyOwned(string message)
  {
    this.hasError = true;
    PaymentListener.ShowPopupWithMessage(Consts.GetInstance().RESPONSE_ERROR_03_TITLE, Consts.GetInstance().RESPONSE_ERROR_05, (System.Action) (() => this.SetRetryPayment(0.0f)));
  }

  public void OnPurchaseDeferred(string productId)
  {
    this.hasError = true;
    PaymentListener.ShowPopupWithMessage(Consts.GetInstance().RESPONSE_ERROR_03_TITLE, Consts.GetInstance().RESPONSE_ERROR_06, (System.Action) (() => PurchaseLoadingLayer.Disable()));
  }

  public void OnPurchaseFinished(bool isSuccess)
  {
    if (isSuccess || this.hasError)
      return;
    PurchaseLoadingLayer.Disable();
  }

  public static void SendAge(int year, int month, int day)
  {
  }

  public void OnPurchaseCreditLimit(string message)
  {
    PurchaseLoadingLayer.Disable();
    PaymentListener.ShowPopupWithMessage(Consts.GetInstance().PAYMENT_LISTENER_ON_CHARGE_LIMIT_RESPONSE, message, (System.Action) (() => PurchaseLoadingLayer.Disable()));
  }

  [DebuggerHidden]
  public static IEnumerator SendCoinbonusPresent()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PaymentListener.\u003CSendCoinbonusPresent\u003Ec__IteratorA03 presentCIteratorA03 = new PaymentListener.\u003CSendCoinbonusPresent\u003Ec__IteratorA03();
    return (IEnumerator) presentCIteratorA03;
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
    return (IEnumerator) new PaymentListener.\u003C_SetRetryPayment\u003Ec__IteratorA04()
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
    PaymentListener.\u003CShowInputBirthday\u003Ec__IteratorA05 birthdayCIteratorA05 = new PaymentListener.\u003CShowInputBirthday\u003Ec__IteratorA05();
    return (IEnumerator) birthdayCIteratorA05;
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
    PaymentListener.\u003CShowApprovePurchase\u003Ec__IteratorA06 purchaseCIteratorA06 = new PaymentListener.\u003CShowApprovePurchase\u003Ec__IteratorA06();
    return (IEnumerator) purchaseCIteratorA06;
  }
}
