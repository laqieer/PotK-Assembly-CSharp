// Decompiled with JetBrains decompiler
// Type: Shop0074Scroll
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
using UniLinq;
using UnityEngine;

#nullable disable
public class Shop0074Scroll : MonoBehaviour
{
  public GameObject soldout;
  public GameObject shortage;
  public GameObject buy;
  public UILabel quantityLabel;
  public GameObject timerBase;
  public UILabel timerLabel;
  public UILabel priceLabel;
  public UILabel ownLabel;
  public UILabel titleLabel;
  public UILabel descriptionLabel;
  public UI2DSprite articleSprite;
  [SerializeField]
  private GameObject linkNoBottom;
  [SerializeField]
  private GameObject linkNormal;
  [SerializeField]
  private BoxCollider ibtnDetailCollider;
  public List<Shop0074Scroll> _scrolls;
  public int _playerItemQuantity;
  public int _playerUnitQuantity;
  private PlayerQuestKey key;
  private PlayerSeasonTicket sTicket;
  private PlayerGachaTicket gTicket;
  private int gachaTicke_quantity;
  private int _quantity;
  private GameObject detailPopupF;
  private DateTime serverTime;
  private GameObject linkTarget;
  public int _shopID;
  private Func<IEnumerator> _onPurchased;
  private NGMenuBase menu;
  [SerializeField]
  private GameObject[] medalIconObject;
  public Sprite[] backSprite;

  public ShopContent[] ShopContents { get; set; }

  public PlayerShopArticle _playerShopArticle { get; set; }

  public ShopArticle _shopArticle { get; set; }

  public PlayerItem[] _allItems { get; set; }

  public PlayerUnit[] _allUnits { get; set; }

  public PlayerMaterialUnit[] _allMaterialUnits { get; set; }

  public Modified<Shop[]> shopModify { get; set; }

  public PlayerShopArticle[] _articles { get; set; }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerShopArticle playerShopArticle,
    int holding,
    int playerItemQuantity,
    int playerUnitQuantity,
    PlayerItem[] allItems,
    PlayerUnit[] allUnits,
    int shopId,
    List<Shop0074Scroll> scrolls,
    ShopArticle shopArticle,
    PlayerShopArticle[] articles,
    GameObject popup,
    Shop0074Scroll.IconType iconType,
    PlayerQuestKey key,
    NGMenuBase menu,
    Func<IEnumerator> onPurchased)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0074Scroll.\u003CInit\u003Ec__Iterator484()
    {
      menu = menu,
      playerShopArticle = playerShopArticle,
      shopArticle = shopArticle,
      playerItemQuantity = playerItemQuantity,
      playerUnitQuantity = playerUnitQuantity,
      allItems = allItems,
      allUnits = allUnits,
      scrolls = scrolls,
      articles = articles,
      shopId = shopId,
      onPurchased = onPurchased,
      key = key,
      popup = popup,
      holding = holding,
      iconType = iconType,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EplayerShopArticle = playerShopArticle,
      \u003C\u0024\u003EshopArticle = shopArticle,
      \u003C\u0024\u003EplayerItemQuantity = playerItemQuantity,
      \u003C\u0024\u003EplayerUnitQuantity = playerUnitQuantity,
      \u003C\u0024\u003EallItems = allItems,
      \u003C\u0024\u003EallUnits = allUnits,
      \u003C\u0024\u003Escrolls = scrolls,
      \u003C\u0024\u003Earticles = articles,
      \u003C\u0024\u003EshopId = shopId,
      \u003C\u0024\u003EonPurchased = onPurchased,
      \u003C\u0024\u003Ekey = key,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u0024\u003Eholding = holding,
      \u003C\u0024\u003EiconType = iconType,
      \u003C\u003Ef__this = this
    };
  }

  public void ArticleLimitValue(
    ShopArticle shopArticle,
    PlayerShopArticle playerArticle,
    int holding)
  {
    if (shopArticle.limit.HasValue && playerArticle.limit.Value <= 0 || shopArticle.daily_limit.HasValue && playerArticle.limit.Value <= 0)
    {
      this.soldout.SetActive(true);
      this.buy.SetActive(false);
    }
    else if (holding < shopArticle.price)
    {
      this.shortage.SetActive(true);
      this.buy.SetActive(false);
    }
    else
    {
      this.shortage.SetActive(false);
      this.soldout.SetActive(false);
      this.buy.SetActive(true);
    }
    if (this._shopArticle.end_at.HasValue)
      ((MonoBehaviour) this.menu).StartCoroutine(this.UpdateServerTime());
    if (this._shopArticle.limit.HasValue || this._shopArticle.daily_limit.HasValue)
    {
      ((Component) this.quantityLabel).gameObject.SetActive(true);
      this.quantityLabel.SetTextLocalize(string.Format(Consts.GetInstance().SHOP_0074_SCROLL_ARTICLE_LIMIT_VALUE, (object) this._playerShopArticle.limit.Value));
    }
    else
      ((Component) this.quantityLabel).gameObject.SetActive(false);
    this.priceLabel.SetTextLocalize(this._shopArticle.price.ToString());
  }

  public void Init00771(WebAPI.Response.ShopBuy result)
  {
    this._allItems = SMManager.Get<PlayerItem[]>();
    this._allUnits = SMManager.Get<PlayerUnit[]>();
    Shop[] source = SMManager.Get<Shop[]>();
    SMManager.UpdateList<PlayerBattleMedal>(result.after.battle_medals);
    // ISSUE: object of a compiler-generated type is created
    foreach (\u003C\u003E__AnonType4<Shop, int> anonType4 in ((IEnumerable<Shop>) source).Select<Shop, \u003C\u003E__AnonType4<Shop, int>>((Func<Shop, int, \u003C\u003E__AnonType4<Shop, int>>) ((value, index) => new \u003C\u003E__AnonType4<Shop, int>(value, index))))
    {
      foreach (PlayerShopArticle playerShopArticle1 in (IEnumerable<PlayerShopArticle>) ((IEnumerable<PlayerShopArticle>) anonType4.value.articles).OrderBy<PlayerShopArticle, int>((Func<PlayerShopArticle, int>) (x => x.article.view_order)))
      {
        PlayerShopArticle playerShopArticle = playerShopArticle1;
        if (playerShopArticle.article.ID == this._playerShopArticle.article.ID)
        {
          this._playerShopArticle = playerShopArticle;
          this._shopArticle = playerShopArticle.article;
          this._playerItemQuantity = this._allItems.AmountHavingTargetItem(playerShopArticle.article.ShopContents[0].entity_id, playerShopArticle.article.ShopContents[0].entity_type);
          this._playerUnitQuantity = 0;
          if (MasterData.UnitUnit.ContainsKey(playerShopArticle.article.ShopContents[0].entity_id))
          {
            if (MasterData.UnitUnit[playerShopArticle.article.ShopContents[0].entity_id].IsMaterialUnit)
            {
              PlayerMaterialUnit playerMaterialUnit = ((IEnumerable<PlayerMaterialUnit>) this._allMaterialUnits).FirstOrDefault<PlayerMaterialUnit>((Func<PlayerMaterialUnit, bool>) (x => x._unit == playerShopArticle.article.ShopContents[0].entity_id));
              if (playerMaterialUnit != null)
                this._playerUnitQuantity = playerMaterialUnit.quantity;
            }
            else
              this._playerUnitQuantity = this._allUnits.AmountHavingTargetUnit(playerShopArticle.article.ShopContents[0].entity_id, playerShopArticle.article.ShopContents[0].entity_type);
          }
          int holding = 0;
          if (this._shopArticle.pay_type == CommonPayType.money)
            holding = result.after.money;
          else if (this._shopArticle.pay_type == CommonPayType.medal)
            holding = result.after.medal;
          else if (this._shopArticle.pay_type == CommonPayType.battle_medal)
            holding = result.after.battle_medal;
          this.ArticleLimitValue(this._shopArticle, this._playerShopArticle, holding);
          break;
        }
      }
    }
    if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.unit || this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.material_unit)
    {
      int num = 0;
      if (MasterData.UnitUnit.ContainsKey(this._shopArticle.ShopContents[0].entity_id))
      {
        if (MasterData.UnitUnit[this._shopArticle.ShopContents[0].entity_id].IsMaterialUnit)
        {
          PlayerMaterialUnit playerMaterialUnit = ((IEnumerable<PlayerMaterialUnit>) this._allMaterialUnits).FirstOrDefault<PlayerMaterialUnit>((Func<PlayerMaterialUnit, bool>) (x => x._unit == this._shopArticle.ShopContents[0].entity_id));
          if (playerMaterialUnit != null)
            num = playerMaterialUnit.quantity;
        }
        else
          num = this._allUnits.AmountHavingTargetUnit(this._shopArticle.ShopContents[0].entity_id, this._shopArticle.ShopContents[0].entity_type);
      }
      this.ownLabel.SetTextLocalize(num.ToString());
    }
    else if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.supply || this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.gear)
      this.ownLabel.SetTextLocalize(this._allItems.AmountHavingTargetItem(this._shopArticle.ShopContents[0].entity_id, this._shopArticle.ShopContents[0].entity_type).ToString());
    else if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.quest_key)
    {
      this.key = ((IEnumerable<PlayerQuestKey>) result.player_quest_keys).Where<PlayerQuestKey>((Func<PlayerQuestKey, bool>) (x => x.quest_key_id == this._shopArticle.ShopContents[0].entity_id)).First<PlayerQuestKey>();
      this.ownLabel.SetTextLocalize(this.key != null ? this.key.quantity : 0);
    }
    else if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.season_ticket)
    {
      this.sTicket = result.player_season_tickets[0];
      this.ownLabel.SetTextLocalize(this.sTicket.quantity);
    }
    else if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.gacha_ticket)
    {
      PlayerGachaTicket[] gachaTickets = result.player.gacha_tickets;
      int num = 0;
      foreach (PlayerGachaTicket playerGachaTicket in gachaTickets)
      {
        if (playerGachaTicket.ticket_id == this._shopArticle.ShopContents[0].entity_id)
        {
          num = playerGachaTicket.quantity;
          break;
        }
      }
      this.ownLabel.SetTextLocalize(num.ToString());
    }
    else
      Debug.LogWarning((object) "获得未预期的CommonRewardType");
  }

  [DebuggerHidden]
  private IEnumerator openPopup0076()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0074Scroll.\u003CopenPopup0076\u003Ec__Iterator485()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool AddForStack()
  {
    foreach (PlayerItem allItem in this._allItems)
    {
      if (allItem.entity_id == this._shopArticle.ShopContents[0].entity_id && !allItem.ForBattle && allItem.quantity < 99)
        return true;
    }
    return false;
  }

  private void ButtonAction()
  {
    Player player = SMManager.Get<Player>();
    if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.supply)
    {
      int num = !this.AddForStack() ? 1 : 0;
      if (((IEnumerable<PlayerItem>) this._allItems).ToList<PlayerItem>().Count + num > player.max_items && !this.AddForStack())
        this.StartCoroutine(PopupUtility._999_6_1(true));
      else
        this.StartCoroutine(this.openPopup0076());
    }
    else if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.gear)
    {
      if (player.CheckMaxItem())
        this.StartCoroutine(PopupUtility._999_6_1(true));
      else
        this.StartCoroutine(this.openPopup0076());
    }
    else if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.unit || this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.material_unit)
    {
      if (player.CheckMaxUnit())
        this.StartCoroutine(PopupUtility._999_5_1(true));
      else
        this.StartCoroutine(this.openPopup0076());
    }
    else if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.quest_key)
    {
      if (this.key.max_quantity <= (this.key != null ? this.key.quantity : 0))
        this.StartCoroutine(PopupUtility._999_15(MasterData.QuestkeyQuestkey[this.key.quest_key_id].name));
      else
        this.StartCoroutine(this.openPopup0076());
    }
    else if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.season_ticket)
    {
      if (this.sTicket.max_quantity <= this.sTicket.quantity)
        this.StartCoroutine(PopupUtility._999_15(MasterData.SeasonTicketSeasonTicket[this.sTicket.season_ticket_id].name));
      else
        this.StartCoroutine(this.openPopup0076());
    }
    else
      this.StartCoroutine(this.openPopup0076());
  }

  public void onBuy()
  {
    if (this.menu.IsPushAndSet())
      return;
    this.ButtonAction();
  }

  public void onChange()
  {
    if (this.menu.IsPushAndSet())
      return;
    this.ButtonAction();
  }

  public void onDetail()
  {
    if (this._shopArticle.ShopContents[0].entity_type == MasterDataTable.CommonRewardType.gacha_ticket || this.menu.IsPushAndSet())
      return;
    this.StartCoroutine(this.setDetailPopup());
  }

  [DebuggerHidden]
  private IEnumerator setDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0074Scroll.\u003CsetDetailPopup\u003Ec__Iterator486()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateServerTime()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0074Scroll.\u003CUpdateServerTime\u003Ec__Iterator487()
    {
      \u003C\u003Ef__this = this
    };
  }

  public enum IconType
  {
    RareMedal,
    BattleMedal,
    None,
  }
}
