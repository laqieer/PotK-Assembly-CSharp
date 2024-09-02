// Decompiled with JetBrains decompiler
// Type: Shop0076Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop0076Menu : BackButtonMenuBase
{
  private const int INPUT_MIN = 1;
  private const int INPUT_MAX = 99;
  [SerializeField]
  private GameObject linkParent;
  [SerializeField]
  private UILabel InpQuantity;
  [SerializeField]
  private UIInput InpUI;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtDescription04;
  [SerializeField]
  private UILabel TxtDescription05;
  [SerializeField]
  private UILabel TxtDescription06;
  [SerializeField]
  private UILabel TxtPopuptitle;
  private GameObject linkTarget;
  private string itemName;
  private int itemId;
  private int price;
  private int holding;
  private int quantity;
  public UIButton btnMinus;
  public UIButton btnPlus;
  public UIButton btnYes;
  private bool initData;
  public int _playerQuantity;
  public List<Shop0074Scroll> _scrolls;
  private int stackQuantity;
  private Func<IEnumerator> _onPurchased;
  public Sprite[] backSprite;

  public PlayerShopArticle _playerShopArticle { get; set; }

  public ShopArticle _shopArticle { get; set; }

  public Player _player { get; set; }

  public PlayerItem[] _allItems { get; set; }

  public PlayerUnit[] _allUnits { get; set; }

  public PlayerShopArticle[] _articles { get; set; }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerShopArticle playerShopArticle,
    ShopArticle shopArticle,
    Player player,
    int playerQuantity,
    PlayerItem[] allItems,
    PlayerUnit[] allUnits,
    List<Shop0074Scroll> scrolls,
    PlayerShopArticle[] articles,
    Func<IEnumerator> onPurchased)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0076Menu.\u003CInit\u003Ec__Iterator4A3()
    {
      player = player,
      playerShopArticle = playerShopArticle,
      shopArticle = shopArticle,
      playerQuantity = playerQuantity,
      allItems = allItems,
      allUnits = allUnits,
      scrolls = scrolls,
      articles = articles,
      onPurchased = onPurchased,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u0024\u003EplayerShopArticle = playerShopArticle,
      \u003C\u0024\u003EshopArticle = shopArticle,
      \u003C\u0024\u003EplayerQuantity = playerQuantity,
      \u003C\u0024\u003EallItems = allItems,
      \u003C\u0024\u003EallUnits = allUnits,
      \u003C\u0024\u003Escrolls = scrolls,
      \u003C\u0024\u003Earticles = articles,
      \u003C\u0024\u003EonPurchased = onPurchased,
      \u003C\u003Ef__this = this
    };
  }

  private void HoldingTypeCheck(ShopArticle sa, Player p)
  {
    if (sa.pay_type == CommonPayType.money)
      this.holding = p.money;
    else if (sa.pay_type == CommonPayType.medal)
    {
      this.holding = p.medal;
    }
    else
    {
      if (sa.pay_type != CommonPayType.battle_medal)
        return;
      this.holding = p.battle_medal;
    }
  }

  public void SetTxtDescription03(ShopArticle sa)
  {
    if (sa.pay_type == CommonPayType.money)
      this.TxtDescription03.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION03_MONEY, (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) this.price
        }
      }));
    else if (sa.pay_type == CommonPayType.medal)
    {
      this.TxtDescription03.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION03_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) this.price
        }
      }));
    }
    else
    {
      if (sa.pay_type != CommonPayType.battle_medal)
        return;
      this.TxtDescription03.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION03_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) this.price
        }
      }));
    }
  }

  public void SetTxtDescription05(ShopArticle sa)
  {
    if (sa.pay_type == CommonPayType.money)
    {
      string text;
      if (this.holding < this.quantity * this.price)
        text = Consts.Format(Consts.GetInstance().SHOP_0076_TXT_DESCRIPTION05_MONEY_OVER, (IDictionary) new Hashtable()
        {
          {
            (object) "money",
            (object) (this.quantity * this.price).ToLocalizeNumberText()
          }
        });
      else
        text = Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION05_MONEY, (IDictionary) new Hashtable()
        {
          {
            (object) "money",
            (object) (this.quantity * this.price).ToLocalizeNumberText()
          }
        });
      this.TxtDescription05.SetTextLocalize(text);
    }
    else if (sa.pay_type == CommonPayType.medal)
    {
      string text;
      if (this.holding < this.quantity * this.price)
        text = Consts.Format(Consts.GetInstance().SHOP_0076_TXT_DESCRIPTION05_MEDAL_OVER, (IDictionary) new Hashtable()
        {
          {
            (object) "medal",
            (object) (this.quantity * this.price).ToLocalizeNumberText()
          }
        });
      else
        text = Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION05_MEDAL, (IDictionary) new Hashtable()
        {
          {
            (object) "medal",
            (object) (this.quantity * this.price).ToLocalizeNumberText()
          }
        });
      this.TxtDescription05.SetTextLocalize(text);
    }
    else
    {
      if (sa.pay_type != CommonPayType.battle_medal)
        return;
      string text;
      if (this.holding < this.quantity * this.price)
        text = Consts.Format(Consts.GetInstance().SHOP_0076_TXT_DESCRIPTION05_MEDAL_OVER, (IDictionary) new Hashtable()
        {
          {
            (object) "medal",
            (object) (this.quantity * this.price).ToLocalizeNumberText()
          }
        });
      else
        text = Consts.Format(Consts.GetInstance().SHOP_007X_TXT_DESCRIPTION05_MEDAL, (IDictionary) new Hashtable()
        {
          {
            (object) "medal",
            (object) (this.quantity * this.price).ToLocalizeNumberText()
          }
        });
      this.TxtDescription05.SetTextLocalize(text);
    }
  }

  public void SetTxtDescription06(ShopArticle sa)
  {
    if (sa.pay_type == CommonPayType.money)
      this.TxtDescription06.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_0076_TXT_DESCRIPTION06_MONEY, (IDictionary) new Hashtable()
      {
        {
          (object) "money",
          (object) this.holding
        }
      }));
    else if (sa.pay_type == CommonPayType.medal)
      this.TxtDescription06.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_0076_TXT_DESCRIPTION06_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) this.holding
        }
      }));
    else if (sa.pay_type == CommonPayType.battle_medal)
      this.TxtDescription06.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_0076_TXT_DESCRIPTION06_MEDAL, (IDictionary) new Hashtable()
      {
        {
          (object) "medal",
          (object) this.holding
        }
      }));
    else
      Debug.LogWarning((object) "selected pay_type is ohter than money, medal");
  }

  public void SetLongPress()
  {
    ((Component) this.btnPlus).GetComponent<LongPressButton>().onLongPressLoop = (Func<IEnumerator>) (() => this.LongPressedCountPlus());
    ((Component) this.btnMinus).GetComponent<LongPressButton>().onLongPressLoop = (Func<IEnumerator>) (() => this.LongPressedCountMinus());
  }

  public void InitObject(GameObject obj)
  {
    this.linkTarget = obj;
    obj.Clone(this.linkParent.transform);
  }

  public void setKeyboardTypeNumber() => this.InpUI.keyboardType = UIInput.KeyboardType.NumberPad;

  private void setInput(UILabel label, string input) => label.SetTextLocalize(input);

  public void setTxt(string input) => this.setInput(this.InpQuantity, input);

  public void onChangeInputQuantity() => this.onChangeInputQuantity(true);

  public void onChangeInputQuantity(bool isInit = true)
  {
    if (isInit)
    {
      this.setTxt(this.InpUI.value);
      int result;
      this.quantity = !int.TryParse(this.InpUI.value, out result) || result == 0 ? 1 : result;
    }
    bool hasValue1 = this._shopArticle.daily_limit.HasValue;
    bool hasValue2 = this._shopArticle.limit.HasValue;
    if (hasValue1 || hasValue2)
    {
      if (hasValue1 && hasValue2)
        this.btnPlus.isEnabled = this.quantity < this._shopArticle.daily_limit.Value && this.quantity < this._shopArticle.limit.Value;
      else if (hasValue1)
      {
        if (this.quantity < this._shopArticle.daily_limit.Value)
        {
          this.btnPlus.isEnabled = true;
        }
        else
        {
          this.quantity = this._shopArticle.daily_limit.Value;
          this.btnPlus.isEnabled = false;
        }
      }
      else if (hasValue2)
      {
        if (this.quantity < this._shopArticle.limit.Value)
        {
          this.btnPlus.isEnabled = true;
        }
        else
        {
          this.quantity = this._playerShopArticle.limit.Value;
          this.btnPlus.isEnabled = false;
        }
      }
    }
    else
      this.btnPlus.isEnabled = this.quantity < 99;
    this.InpQuantity.SetTextLocalize(this.quantity.ToString());
    this.btnMinus.isEnabled = this.quantity > 1;
    if (this.quantity * this.price > this.holding)
    {
      this.InpQuantity.SetTextLocalize(this.quantity.ToString());
      this.btnYes.isEnabled = false;
    }
    else
      this.btnYes.isEnabled = true;
    this.SetTxtDescription05(this._shopArticle);
    this.InpQuantity.SetTextLocalize(this.quantity);
  }

  [DebuggerHidden]
  private IEnumerator OpenPopup00771()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0076Menu.\u003COpenPopup00771\u003Ec__Iterator4A4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LongPressedCountPlus()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0076Menu.\u003CLongPressedCountPlus\u003Ec__Iterator4A5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LongPressedCountMinus()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0076Menu.\u003CLongPressedCountMinus\u003Ec__Iterator4A6()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnMinus()
  {
    if (this.quantity > 1)
      --this.quantity;
    this.onChangeInputQuantity(false);
  }

  public void IbtnPlus()
  {
    bool flag = !this._playerShopArticle.limit.HasValue || this.quantity < this._playerShopArticle.limit.Value;
    if (this.quantity < 99 && flag)
      ++this.quantity;
    this.onChangeInputQuantity(false);
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupYes()
  {
    if (this.quantity == 0 || this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss(true);
    if (this.quantity * this.price > this.holding)
      this.StartCoroutine(PopupUtility._999_7_1(this._shopArticle));
    else
      this.StartCoroutine(this.OpenPopup00771());
  }

  protected override void Update()
  {
    if (!this.initData)
      this.StartCoroutine(this.Init(this._playerShopArticle, this._shopArticle, this._player, this._playerQuantity, this._allItems, this._allUnits, this._scrolls, this._articles, this._onPurchased));
    base.Update();
  }
}
