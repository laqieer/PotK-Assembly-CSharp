﻿// Decompiled with JetBrains decompiler
// Type: Shop0574ConfirmPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class Shop0574ConfirmPopup : BackButtonMenuBase
{
  private readonly int INPUT_MIN = 1;
  private readonly int INPUT_MAX = 99;
  [SerializeField]
  private UIInput InputUI;
  [SerializeField]
  private GameObject DirThum;
  [SerializeField]
  private UILabel InpDescription;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtDescription05;
  [SerializeField]
  private UILabel TxtDescription06;
  [SerializeField]
  private UIButton IbtnPopupYes;
  [SerializeField]
  private UIButton IbtnPopupNo;
  [SerializeField]
  private UIButton IbtnPopupPlus;
  [SerializeField]
  private UIButton IbtnPopupMinus;
  private EarthShopArticle shopArticle;
  private GameObject mfinalConfirmPopup;
  private Action<EarthShopArticle, GameObject, int> EndAction;
  private int possesiveMoney;
  private int quantity;
  private int price;
  private int purchaseCount;

  private int GetTotalPrice() => this.quantity * this.price;

  private void SetTotlaPrice()
  {
    int totalPrice = this.GetTotalPrice();
    if (this.possesiveMoney < totalPrice)
      this.TxtDescription05.SetTextLocalize(Consts.Lookup("SHOP_0076_TXT_DESCRIPTION05_MONEY_OVER", (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) totalPrice.ToLocalizeNumberText()
        }
      }));
    else
      this.TxtDescription05.SetTextLocalize(Consts.Lookup("SHOP_007X_TXT_DESCRIPTION05_MONEY", (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) totalPrice.ToLocalizeNumberText()
        }
      }));
  }

  public void Init(
    EarthShopArticle article,
    GameObject thum,
    GameObject finalConfirmPopup,
    Action<EarthShopArticle, GameObject, int> endAction)
  {
    this.shopArticle = article;
    this.purchaseCount = 0;
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    if (Object.op_Inequality((Object) instanceOrNull, (Object) null))
    {
      this.possesiveMoney = instanceOrNull.GetProperty(MasterDataTable.CommonRewardType.money);
      this.purchaseCount = instanceOrNull.GetShopPurchaseCount(this.shopArticle.ID);
    }
    this.EndAction = endAction;
    this.mfinalConfirmPopup = finalConfirmPopup;
    this.quantity = 1;
    this.price = article.price;
    thum.Clone(this.DirThum.transform);
    this.InpDescription.SetTextLocalize(this.quantity);
    this.TxtDescription01.SetText(article.name);
    this.TxtDescription03.SetTextLocalize(Consts.Lookup("SHOP_007X_TXT_DESCRIPTION03_MONEY", (IDictionary) new Hashtable()
    {
      {
        (object) "money",
        (object) article.price
      }
    }));
    this.TxtDescription06.SetTextLocalize(Consts.Lookup("SHOP_0076_TXT_DESCRIPTION06_MONEY", (IDictionary) new Hashtable()
    {
      {
        (object) "money",
        (object) this.possesiveMoney
      }
    }));
    this.SetTotlaPrice();
  }

  public void onChangeInputQuantity() => this.onChangeInputQuantity(true);

  public void onChangeInputQuantity(bool isInit = true)
  {
    if (isInit)
    {
      int result;
      this.quantity = !int.TryParse(this.InputUI.value, out result) || result == 0 ? this.INPUT_MIN : result;
    }
    if (this.shopArticle.limit.HasValue)
    {
      if (this.quantity < this.shopArticle.limit.Value - this.purchaseCount)
      {
        this.IbtnPopupPlus.isEnabled = true;
      }
      else
      {
        this.quantity = this.shopArticle.limit.Value - this.purchaseCount;
        this.IbtnPopupPlus.isEnabled = false;
      }
    }
    else
      this.IbtnPopupPlus.isEnabled = this.quantity < this.INPUT_MAX;
    this.IbtnPopupMinus.isEnabled = this.quantity > this.INPUT_MIN;
    this.IbtnPopupYes.isEnabled = this.GetTotalPrice() <= this.possesiveMoney;
    this.SetTotlaPrice();
    this.InpDescription.SetTextLocalize(this.quantity);
  }

  private void OpenFinalConfirmPopup()
  {
    GameObject prefab = this.mfinalConfirmPopup.Clone();
    prefab.GetComponent<Shop0574FinalConfirmPopup>().Init(this.shopArticle, this.DirThum, this.quantity, this.EndAction);
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
  }

  public void IbtnMinus()
  {
    if (this.quantity > 1)
      --this.quantity;
    this.onChangeInputQuantity(false);
  }

  public void IbtnPlus()
  {
    bool flag = !this.shopArticle.limit.HasValue || this.quantity < this.shopArticle.limit.Value - this.purchaseCount;
    if (this.quantity < this.INPUT_MAX && flag)
      ++this.quantity;
    this.onChangeInputQuantity(false);
  }

  public void IbtnYes()
  {
    if (this.quantity == 0 || this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss(true);
    if (this.GetTotalPrice() > this.possesiveMoney)
      this.StartCoroutine(PopupUtility._999_7_1(CommonPayType.money));
    else
      this.OpenFinalConfirmPopup();
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
