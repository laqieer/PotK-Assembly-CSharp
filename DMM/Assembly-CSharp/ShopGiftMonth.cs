﻿// Decompiled with JetBrains decompiler
// Type: ShopGiftMonth
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using Gsc.Purchase;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class ShopGiftMonth : MonoBehaviour
{
  [SerializeField]
  private UIWidget pageUiWidget;
  [SerializeField]
  private UIScrollView scroll;
  [SerializeField]
  private UILabel periodLabel;
  [Header("ページ切り替え矢印")]
  [SerializeField]
  private GameObject leftArrow;
  [SerializeField]
  private GameObject rightArrow;
  [Header("デイリー特典")]
  [SerializeField]
  private UIGrid dailyGrid;
  [SerializeField]
  [Tooltip("背景")]
  private UISprite dailyBackground;
  [SerializeField]
  private GameObject kisekiInfo;
  [SerializeField]
  private UILabel kisekiInfoLabel;
  [Header("確定特典")]
  [SerializeField]
  private GameObject reachingItemBase;
  [SerializeField]
  private UIGrid reachingGrid;
  [SerializeField]
  private UISprite reachingBackground;
  private int defaultReachingBackgroundHeight;
  [Header("ギフト特典")]
  [SerializeField]
  private UIWidget benefits;
  [SerializeField]
  private int benefitsAnchorMargin = -12;
  [SerializeField]
  private UIGrid benefitsGrid;
  [SerializeField]
  private UILabel benefitDropUp;
  [SerializeField]
  private UILabel benefitZenyUp;
  [SerializeField]
  private UILabel benefitExpUp;
  [Space(10f)]
  [SerializeField]
  private GameObject receiveRestDay;
  [SerializeField]
  private UILabel receiveRestDayText;
  [SerializeField]
  private UIButton receiveButton;
  [SerializeField]
  private UILabel receiveButtonLabel;
  [SerializeField]
  private UIButton priceButton;
  [SerializeField]
  private UILabel priceLabel;
  [Header("ページ切り替え用隠し横スクロール")]
  [SerializeField]
  private UIScrollView hidingHScroll;
  [SerializeField]
  private NGFullWidthGrid hidingHGrid;
  [SerializeField]
  private UICenterOnChild hidingCenterOnChild;
  private WebAPI.Response.CoinbonusHistory coinbonusHistory;
  private MonthlyPackInfo packInfo;
  private string productId;
  private MonthlyPackInfo[] packInfos;
  private bool isLockPack = true;
  private int currentIndex;
  private bool disabledUpdate = true;
  private Dictionary<GameObject, int> objToIndex;
  private GameObject objHScrollCenter;
  private DateTime now;
  private Vector3 receiveButtonDefaultPos;
  private Vector3 priceButtonDefaultPos;
  private bool bOnEnable;

  private void OnEnable()
  {
    if (!this.bOnEnable)
      this.bOnEnable = true;
    else
      this.StartCoroutine(this.ArrowRetryActive());
  }

  private IEnumerator ArrowRetryActive()
  {
    if (this.leftArrow.activeSelf)
    {
      this.leftArrow.SetActive(false);
      yield return (object) null;
      this.leftArrow.SetActive(true);
    }
    if (this.rightArrow.activeSelf)
    {
      this.rightArrow.SetActive(false);
      yield return (object) null;
      this.rightArrow.SetActive(true);
    }
  }

  public IEnumerator Init(WebAPI.Response.CoinbonusHistory coinbonusHistory)
  {
    this.pageUiWidget.alpha = 0.0f;
    this.disabledUpdate = true;
    this.isLockPack = true;
    this.receiveButtonDefaultPos = this.receiveButton.transform.localPosition;
    this.priceButtonDefaultPos = this.priceButton.transform.localPosition;
    IEnumerator e = ServerTime.WaitSync();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.now = ServerTime.NowAppTime();
    this.coinbonusHistory = coinbonusHistory;
    this.packInfos = ((IEnumerable<MonthlyPackInfo>) coinbonusHistory.monthly_packs).ToArray<MonthlyPackInfo>();
    this.reachingItemBase.SetActive(false);
    this.defaultReachingBackgroundHeight = this.reachingBackground.height;
    if (this.packInfos.Length >= 2)
    {
      this.leftArrow.gameObject.SetActive(false);
      this.rightArrow.gameObject.SetActive(true);
    }
    else
    {
      this.leftArrow.gameObject.SetActive(false);
      this.rightArrow.gameObject.SetActive(false);
    }
    this.setPackInfo(0, true);
    yield return (object) this.ShowPage();
    yield return (object) this.resetHidingHScroll();
    this.pageUiWidget.alpha = 1f;
    this.isLockPack = false;
  }

  private bool setPackInfo(int index, bool bInit = false)
  {
    if (!bInit && this.currentIndex == index)
      return false;
    this.currentIndex = index;
    this.packInfo = this.packInfos[this.currentIndex];
    this.productId = Array.Find<CoinGroup>(this.coinbonusHistory.coin_groups, (Predicate<CoinGroup>) (x => x.id == this.packInfo.pack.coin_group_id)).GetProductId();
    return true;
  }

  private IEnumerator resetHidingHScroll()
  {
    ShopGiftMonth shopGiftMonth = this;
    shopGiftMonth.disabledUpdate = true;
    shopGiftMonth.hidingHGrid.transform.Clear();
    shopGiftMonth.objToIndex = (Dictionary<GameObject, int>) null;
    shopGiftMonth.objHScrollCenter = (GameObject) null;
    if (shopGiftMonth.packInfos.Length > 1)
    {
      shopGiftMonth.objToIndex = new Dictionary<GameObject, int>(shopGiftMonth.packInfos.Length);
      shopGiftMonth.hidingHScroll.gameObject.SetActive(true);
      yield return (object) null;
      GameObject self = new GameObject("dummy");
      self.layer = shopGiftMonth.hidingHGrid.gameObject.layer;
      UIWidget uiWidget = self.AddComponent<UIWidget>();
      UIPanel inParents = NGUITools.FindInParents<UIPanel>(shopGiftMonth.hidingHScroll.gameObject);
      uiWidget.pivot = UIWidget.Pivot.Top;
      uiWidget.width = (int) inParents.width;
      uiWidget.height = (int) inParents.height;
      self.transform.localPosition = Vector3.zero;
      for (int index = 0; index < shopGiftMonth.packInfos.Length; ++index)
      {
        GameObject key = self.Clone(shopGiftMonth.hidingHGrid.transform);
        shopGiftMonth.objToIndex.Add(key, index);
        if (index == 0)
          shopGiftMonth.objHScrollCenter = key;
      }
      // ISSUE: reference to a compiler-generated method
      shopGiftMonth.hidingHGrid.onReposition = new UIGrid.OnReposition(shopGiftMonth.\u003CresetHidingHScroll\u003Eb__45_0);
      shopGiftMonth.hidingHGrid.Reposition();
      UnityEngine.Object.Destroy((UnityEngine.Object) self);
      shopGiftMonth.disabledUpdate = false;
    }
    else
      shopGiftMonth.hidingHScroll.gameObject.SetActive(false);
  }

  private void LateUpdate()
  {
    if (this.disabledUpdate)
      return;
    this.checkUpdatePage();
  }

  private void checkUpdatePage()
  {
    if (this.hidingHScroll.isDragging)
      return;
    GameObject centeredObject = this.hidingCenterOnChild.centeredObject;
    if ((UnityEngine.Object) this.objHScrollCenter == (UnityEngine.Object) centeredObject)
      return;
    int index;
    if (!this.isLockPack && (UnityEngine.Object) centeredObject != (UnityEngine.Object) null && this.objToIndex.TryGetValue(centeredObject, out index))
    {
      if (index > this.currentIndex + 1)
        index = this.currentIndex + 1;
      else if (index < this.currentIndex - 1)
        index = this.currentIndex - 1;
      this.changePage(index);
      this.objHScrollCenter = centeredObject;
      this.hidingCenterOnChild.CenterOn(this.objHScrollCenter.transform);
    }
    else
    {
      if (!((UnityEngine.Object) this.objHScrollCenter != (UnityEngine.Object) null))
        return;
      this.hidingCenterOnChild.CenterOn(this.objHScrollCenter.transform);
    }
  }

  private IEnumerator ShowPage(System.Action onFinished = null)
  {
    ShopGiftMonth shopGiftMonth = this;
    Future<GameObject> prefab = new ResourceObject("Prefabs/common/dir_Reward_IconOnly_Item").Load<GameObject>();
    IEnumerator e = prefab.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject withLoupeIcon = prefab.Result;
    DateTime dateTime1 = shopGiftMonth.packInfo.pack.start_at.Value;
    DateTime dateTime2 = shopGiftMonth.packInfo.pack.end_at.Value;
    shopGiftMonth.periodLabel.text = dateTime1.ToString("yyyy/MM/dd") + "～" + dateTime2.ToString("yyyy/MM/dd");
    shopGiftMonth.dailyGrid.transform.Clear();
    MonthlyPackReward[] monthlyPackRewardArray = shopGiftMonth.packInfo.rewards;
    int index;
    for (index = 0; index < monthlyPackRewardArray.Length; ++index)
    {
      MonthlyPackReward monthlyPackReward = monthlyPackRewardArray[index];
      e = withLoupeIcon.Clone(shopGiftMonth.dailyGrid.transform).GetComponent<ItemIconDetail>().Init((MasterDataTable.CommonRewardType) monthlyPackReward.reward_type_id, monthlyPackReward.reward_id, monthlyPackReward.reward_quantity);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    monthlyPackRewardArray = (MonthlyPackReward[]) null;
    shopGiftMonth.dailyGrid.Reposition();
    GameObject gameObject1 = (GameObject) null;
    shopGiftMonth.reachingGrid.transform.Clear();
    GameObject gameObject2 = shopGiftMonth.reachingGrid.transform.parent.gameObject;
    if (shopGiftMonth.packInfo.extra_rewards.Length != 0)
    {
      gameObject2.SetActive(true);
      MonthlyPackExtraReward[] monthlyPackExtraRewardArray = shopGiftMonth.packInfo.extra_rewards;
      for (index = 0; index < monthlyPackExtraRewardArray.Length; ++index)
      {
        MonthlyPackExtraReward reward = monthlyPackExtraRewardArray[index];
        GameObject scrollItem = shopGiftMonth.reachingItemBase.Clone(shopGiftMonth.reachingGrid.transform);
        scrollItem.SetActive(true);
        yield return (object) scrollItem.GetComponent<ShopGiftMonthReachingItem>().Init(withLoupeIcon, reward);
        gameObject1 = scrollItem;
        scrollItem = (GameObject) null;
      }
      monthlyPackExtraRewardArray = (MonthlyPackExtraReward[]) null;
      shopGiftMonth.reachingBackground.height = shopGiftMonth.defaultReachingBackgroundHeight + (int) ((double) shopGiftMonth.reachingGrid.cellHeight * (double) (shopGiftMonth.packInfo.extra_rewards.Length - 1) + 10.0);
      shopGiftMonth.reachingGrid.Reposition();
    }
    else
      gameObject2.SetActive(false);
    shopGiftMonth.benefits.leftAnchor.target = shopGiftMonth.benefits.rightAnchor.target = (Transform) null;
    shopGiftMonth.benefits.bottomAnchor.target = shopGiftMonth.benefits.topAnchor.target = (UnityEngine.Object) gameObject1 != (UnityEngine.Object) null ? (shopGiftMonth.benefits.topAnchor.target = shopGiftMonth.reachingBackground.transform) : (shopGiftMonth.benefits.topAnchor.target = shopGiftMonth.dailyBackground.transform);
    shopGiftMonth.benefits.bottomAnchor.Set(0.0f, 0.0f);
    shopGiftMonth.benefits.topAnchor.Set(0.0f, (float) shopGiftMonth.benefitsAnchorMargin);
    shopGiftMonth.benefits.ResetAnchors();
    shopGiftMonth.benefits.UpdateAnchors();
    if (shopGiftMonth.packInfo.pack.drop_item_rate_text == "")
      shopGiftMonth.benefitDropUp.gameObject.SetActive(false);
    else
      shopGiftMonth.benefitDropUp.text = shopGiftMonth.packInfo.pack.drop_item_rate_text;
    if (shopGiftMonth.packInfo.pack.money_rate_text == "")
      shopGiftMonth.benefitZenyUp.gameObject.SetActive(false);
    else
      shopGiftMonth.benefitZenyUp.text = shopGiftMonth.packInfo.pack.money_rate_text;
    if (shopGiftMonth.packInfo.pack.player_exp_rate_text == "")
      shopGiftMonth.benefitExpUp.gameObject.SetActive(false);
    else
      shopGiftMonth.benefitExpUp.text = shopGiftMonth.packInfo.pack.player_exp_rate_text;
    shopGiftMonth.benefitsGrid.Reposition();
    if (!shopGiftMonth.packInfo.player_pack.rest_receive_day.HasValue)
    {
      shopGiftMonth.receiveRestDay.SetActive(false);
    }
    else
    {
      shopGiftMonth.receiveRestDay.SetActive(true);
      int? restReceiveDay = shopGiftMonth.packInfo.player_pack.rest_receive_day;
      int num = 0;
      if (restReceiveDay.GetValueOrDefault() > num & restReceiveDay.HasValue)
      {
        shopGiftMonth.receiveRestDayText.text = string.Format("残り{0}日", (object) shopGiftMonth.packInfo.player_pack.rest_receive_day);
      }
      else
      {
        TimeSpan timeSpan = new DateTime(shopGiftMonth.now.Year, shopGiftMonth.now.Month, shopGiftMonth.now.Day, 23, 59, 59) - shopGiftMonth.now;
        shopGiftMonth.receiveRestDayText.text = timeSpan.Hours <= 0 ? string.Format("残り{0}分", (object) timeSpan.Minutes) : string.Format("残り{0}時間", (object) timeSpan.Hours);
      }
    }
    if (shopGiftMonth.packInfo.player_pack.is_purchasable)
    {
      shopGiftMonth.priceButton.gameObject.SetActive(true);
      // ISSUE: reference to a compiler-generated method
      string localizedPrice = ((IEnumerable<ProductInfo>) PurchaseFlow.ProductList).First<ProductInfo>(new Func<ProductInfo, bool>(shopGiftMonth.\u003CShowPage\u003Eb__48_0)).LocalizedPrice;
      shopGiftMonth.priceLabel.SetTextLocalize(localizedPrice.Replace("\\", "￥"));
    }
    else
      shopGiftMonth.priceButton.gameObject.SetActive(false);
    if (!shopGiftMonth.packInfo.player_pack.rest_receive_day.HasValue)
    {
      shopGiftMonth.receiveButton.gameObject.SetActive(false);
      shopGiftMonth.kisekiInfo.SetActive(true);
      CoinProduct activeProductData = MasterData.CoinProductList.GetActiveProductData(shopGiftMonth.productId);
      shopGiftMonth.kisekiInfoLabel.text = string.Format("購入時、有償石{0}個と特典付与", (object) activeProductData.additional_paid_coin);
    }
    else
    {
      shopGiftMonth.receiveButton.gameObject.SetActive(true);
      shopGiftMonth.kisekiInfo.SetActive(false);
      if (shopGiftMonth.packInfo.player_pack.is_received)
      {
        shopGiftMonth.receiveButtonLabel.text = "受取済";
        shopGiftMonth.receiveButton.isEnabled = false;
      }
      else
      {
        shopGiftMonth.receiveButtonLabel.text = "受取";
        shopGiftMonth.receiveButton.isEnabled = true;
      }
    }
    shopGiftMonth.priceButton.transform.localPosition = shopGiftMonth.priceButtonDefaultPos;
    shopGiftMonth.receiveButton.transform.localPosition = shopGiftMonth.receiveButtonDefaultPos;
    if (!shopGiftMonth.priceButton.gameObject.activeSelf || !shopGiftMonth.receiveButton.gameObject.activeSelf)
    {
      if (shopGiftMonth.priceButton.gameObject.activeSelf)
      {
        Transform transform = shopGiftMonth.priceButton.gameObject.transform;
        transform.localPosition = new Vector3(0.0f, transform.localPosition.y, transform.localPosition.z);
      }
      if (shopGiftMonth.receiveButton.gameObject.activeSelf)
      {
        Transform transform = shopGiftMonth.receiveButton.gameObject.transform;
        transform.localPosition = new Vector3(0.0f, transform.localPosition.y, transform.localPosition.z);
      }
    }
    shopGiftMonth.scroll.ResetPosition();
    if (shopGiftMonth.packInfos.Length > 1)
    {
      foreach (IGrouping<GameObject, UIDragScrollView> source in ((IEnumerable<UIDragScrollView>) shopGiftMonth.scroll.GetComponentsInChildren<UIDragScrollView>()).Where<UIDragScrollView>((Func<UIDragScrollView, bool>) (x => x.enabled)).GroupBy<UIDragScrollView, GameObject>((Func<UIDragScrollView, GameObject>) (y => y.gameObject)))
      {
        // ISSUE: reference to a compiler-generated method
        if (!source.Any<UIDragScrollView>(new Func<UIDragScrollView, bool>(shopGiftMonth.\u003CShowPage\u003Eb__48_3)))
          source.First<UIDragScrollView>().gameObject.AddComponent<UIDragScrollView>().scrollView = shopGiftMonth.hidingHScroll;
      }
    }
    System.Action action = onFinished;
    if (action != null)
      action();
  }

  public void OnDetailButton() => Singleton<NGSceneManager>.GetInstance().StartCoroutine(this.ShowOnDetailButton());

  private IEnumerator ShowOnDetailButton()
  {
    Future<GameObject> detailPopupf = Res.Prefabs.popup.popup_006_3_1__anim_popup01.Load<GameObject>();
    IEnumerator e = detailPopupf.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = Singleton<PopupManager>.GetInstance().open(detailPopupf.Result).GetComponent<Popup00631Menu>().InitGachaDetail("月パック", this.packInfo.descriptions);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void OrLeftArrow()
  {
    if (this.isLockPack || this.disabledUpdate)
      return;
    this.movePage(-1);
  }

  public void OrRightArrow()
  {
    if (this.isLockPack || this.disabledUpdate)
      return;
    this.movePage(1);
  }

  private void movePage(int dir)
  {
    int index = this.currentIndex + dir;
    if (index < 0)
      index = 0;
    else if (index >= this.packInfos.Length)
      index = this.packInfos.Length - 1;
    if (!this.changePage(index))
      return;
    this.setHScrollCenter(index);
    SpringPanel component = this.hidingHScroll.GetComponent<SpringPanel>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null) || !component.enabled)
      return;
    this.hidingHScroll.transform.localPosition = component.target;
    component.enabled = false;
  }

  private bool changePage(int index)
  {
    if (!this.setPackInfo(index))
      return false;
    CommonRoot touchMask = Singleton<CommonRoot>.GetInstance();
    touchMask.ShowLoadingLayer(2, true);
    this.disabledUpdate = true;
    EventDelegate.Set(TweenAlpha.Begin(this.scroll.gameObject, 0.1f, 0.0f).onFinished, (EventDelegate.Callback) (() => this.StartCoroutine(this.ShowPage((System.Action) (() =>
    {
      this.setHScrollCenter(index);
      EventDelegate.Set(TweenAlpha.Begin(this.scroll.gameObject, 0.1f, 1f).onFinished, (EventDelegate.Callback) (() =>
      {
        this.disabledUpdate = false;
        touchMask.HideLoadingLayer();
        UnityEngine.Object.Destroy((UnityEngine.Object) this.scroll.GetComponent<TweenAlpha>());
      }));
    })))));
    this.leftArrow.SetActive(this.currentIndex > 0);
    this.rightArrow.SetActive(this.currentIndex < this.packInfos.Length - 1);
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1005");
    return true;
  }

  private void fadeOut()
  {
  }

  private void setHScrollCenter(int index)
  {
    if (this.objToIndex == null)
      return;
    this.objHScrollCenter = this.objToIndex.First<KeyValuePair<GameObject, int>>((Func<KeyValuePair<GameObject, int>, bool>) (x => x.Value == index)).Key;
    if (!((UnityEngine.Object) this.hidingCenterOnChild.centeredObject != (UnityEngine.Object) this.objHScrollCenter))
      return;
    this.hidingCenterOnChild.CenterOn(this.objHScrollCenter.transform);
  }

  public void OnBuy()
  {
    if (this.isLockPack)
      return;
    this.isLockPack = true;
    this.StartCoroutine(this.DoBuy());
  }

  private IEnumerator DoBuy()
  {
    ShopGiftMonth shopGiftMonth = this;
    Future<WebAPI.Response.CoinbonusPackVerifyCheck> handler = WebAPI.CoinbonusPackVerifyCheck(4, shopGiftMonth.packInfo.pack.id, 0);
    IEnumerator e = handler.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    shopGiftMonth.isLockPack = false;
    if (handler.Result != null && PurchaseFlow.Instance.Purchase(shopGiftMonth.productId))
      shopGiftMonth.StartCoroutine(PurchaseBehaviorLoadingLayer.Enable());
  }

  public void OrReceive() => this.StartCoroutine(this.DoReceive());

  private IEnumerator DoReceive()
  {
    PurchaseBehavior.PopupDismiss(true);
    CoinProduct activeProductData = MasterData.CoinProductList.GetActiveProductData(this.productId);
    yield return (object) Singleton<NGSceneManager>.GetInstance().StartCoroutine(Shop0079Menu.OnReciveSucceeded(activeProductData.type, this.packInfo.pack.id));
  }
}
