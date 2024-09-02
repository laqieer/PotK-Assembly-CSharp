﻿// Decompiled with JetBrains decompiler
// Type: Shop00771Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00771Menu : BackButtonMenuBase
{
  private GameObject linkTarget;
  private GameObject prefab0078;
  [SerializeField]
  private GameObject linkParent;
  [SerializeField]
  private UIButton ibtnY;
  [SerializeField]
  private UIButton ibtnN;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtDescription04;
  [SerializeField]
  private UILabel TxtDescription05;
  public int _itemId;
  public string _itemName;
  public int _purchasedQuantity;
  public int _playerQuantity;
  public int _price;
  public int _holding;
  private Func<IEnumerator> _onPurchased;
  public int holding_next;
  public Sprite[] backSprite;

  public PlayerShopArticle _playerShopArticle { get; set; }

  public List<Shop0074Scroll> _scrolls { get; set; }

  public Player _player { get; set; }

  public void InitData(
    PlayerShopArticle playerShopArticle,
    int itemId,
    string itemName,
    int purchasedQuantity,
    int playerQuantity,
    int price,
    int holding,
    List<Shop0074Scroll> scrolls,
    PlayerShopArticle[] articles,
    Func<IEnumerator> onPurchased)
  {
    this._playerShopArticle = playerShopArticle;
    this._itemId = itemId;
    this._itemName = itemName;
    this._purchasedQuantity = purchasedQuantity;
    this._playerQuantity = playerQuantity;
    this._price = price;
    this._holding = holding;
    this._scrolls = scrolls;
    this._onPurchased = onPurchased;
    this.CalcBalance();
    this.TxtDescription01.SetTextLocalize(this._itemName);
    this.SetTxtDescription02(this._playerShopArticle);
    this.SetTxtDescription03(this._playerShopArticle);
    this.SetTxtDescription04(this._playerShopArticle);
    this.SetTxtDescription05(this._playerShopArticle);
  }

  public void InitObject(GameObject obj)
  {
    this.linkTarget = obj;
    obj.Clone(this.linkParent.transform);
  }

  private void SetTxtDescription02(PlayerShopArticle psa)
  {
    if (psa.article.pay_type == CommonPayType.money)
    {
      string localizeNumberText1 = this._holding.ToLocalizeNumberText();
      string localizeNumberText2 = this.holding_next.ToLocalizeNumberText();
      this.TxtDescription02.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_00771_TXT_DESCRIPTION02_MONEY, (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) localizeNumberText1
        },
        {
          (object) "moneyNext",
          (object) localizeNumberText2
        }
      }));
    }
    else if (psa.article.pay_type == CommonPayType.medal)
    {
      string localizeNumberText3 = this._holding.ToLocalizeNumberText();
      string localizeNumberText4 = this.holding_next.ToLocalizeNumberText();
      this.TxtDescription02.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_00771_TXT_DESCRIPTION02_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) localizeNumberText3
        },
        {
          (object) "medalNext",
          (object) localizeNumberText4
        }
      }));
    }
    else if (psa.article.pay_type == CommonPayType.battle_medal)
    {
      string localizeNumberText5 = this._holding.ToLocalizeNumberText();
      string localizeNumberText6 = this.holding_next.ToLocalizeNumberText();
      this.TxtDescription02.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_00771_TXT_DESCRIPTION02_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) localizeNumberText5
        },
        {
          (object) "medalNext",
          (object) localizeNumberText6
        }
      }));
    }
    else
      Debug.LogWarning((object) "selected pay_type is other than money, medal");
  }

  public void SetTxtDescription03(PlayerShopArticle psa)
  {
    if (psa.article.pay_type == CommonPayType.money)
      this.TxtDescription03.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION03_MONEY, (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) this._price
        }
      }));
    else if (psa.article.pay_type == CommonPayType.medal)
    {
      this.TxtDescription03.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION03_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) this._price
        }
      }));
    }
    else
    {
      if (psa.article.pay_type != CommonPayType.battle_medal)
        return;
      this.TxtDescription03.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION03_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) this._price
        }
      }));
    }
  }

  public void SetTxtDescription04(PlayerShopArticle psa)
  {
    string localizeNumberText = this._purchasedQuantity.ToLocalizeNumberText();
    this.TxtDescription04.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_00771_TXT_DESCRIPTION04, (IDictionary) new Hashtable()
    {
      {
        (object) "quantity",
        (object) localizeNumberText
      }
    }));
  }

  public void SetTxtDescription05(PlayerShopArticle psa)
  {
    if (psa.article.pay_type == CommonPayType.money)
      this.TxtDescription05.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION05_MONEY, (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) (this._purchasedQuantity * this._price).ToLocalizeNumberText()
        }
      }));
    else if (psa.article.pay_type == CommonPayType.medal)
    {
      this.TxtDescription05.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION05_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) (this._purchasedQuantity * this._price).ToLocalizeNumberText()
        }
      }));
    }
    else
    {
      if (psa.article.pay_type != CommonPayType.battle_medal)
        return;
      this.TxtDescription05.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION05_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) (this._purchasedQuantity * this._price).ToLocalizeNumberText()
        }
      }));
    }
  }

  [DebuggerHidden]
  private IEnumerator ShopBuyAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00771Menu.\u003CShopBuyAsync\u003Ec__Iterator4F7()
    {
      \u003C\u003Ef__this = this
    };
  }

  private int CalcBalance()
  {
    return this.holding_next = this._holding - this._purchasedQuantity * this._price;
  }

  [DebuggerHidden]
  private IEnumerator OpenPopup0078()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00771Menu.\u003COpenPopup0078\u003Ec__Iterator4F8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator OpenPopup99971()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop00771Menu.\u003COpenPopup99971\u003Ec__Iterator4F9 popup99971CIterator4F9 = new Shop00771Menu.\u003COpenPopup99971\u003Ec__Iterator4F9();
    return (IEnumerator) popup99971CIterator4F9;
  }

  public void IbtnNo()
  {
    this.PushAfter();
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupYes()
  {
    if (this._holding < this._purchasedQuantity * this._price)
    {
      this.StartCoroutine(this.OpenPopup99971());
    }
    else
    {
      this.PushAfter();
      this.StartCoroutine(this.OpenPopup0078());
      Singleton<PopupManager>.GetInstance().dismiss(true);
      this.StartCoroutine(this.ShopBuyAsync());
    }
  }

  public void PushAfter()
  {
    ((Behaviour) this.ibtnY).enabled = false;
    ((Behaviour) this.ibtnN).enabled = false;
  }
}
