// Decompiled with JetBrains decompiler
// Type: Scroll0079
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Bode;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
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
  public int purchasedStoneQuentity;
  private int sdkItemindex;
  private string itemDesc = string.Empty;
  private string itemReward = string.Empty;
  private int rewardCount;
  private int nowReward;
  private bool isMonth;
  private bool needRefresh;

  public Player player { get; set; }

  [DebuggerHidden]
  public IEnumerator Init(
    CoinProduct data,
    WebAPI.Response.CoinbonusHistory history,
    int pSDKIndex,
    string price)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Scroll0079.\u003CInit\u003Ec__Iterator4FB()
    {
      data = data,
      pSDKIndex = pSDKIndex,
      price = price,
      history = history,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EpSDKIndex = pSDKIndex,
      \u003C\u0024\u003Eprice = price,
      \u003C\u0024\u003Ehistory = history,
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (!this.needRefresh)
      return;
    this.needRefresh = false;
    this.TxtItemname.SetText(this._coinProduct.name);
    this.StartCoroutine(this.updateSprite());
  }

  private void initIsMonth()
  {
    if (this._coinProduct.ID.ToString().Substring(1, 1) == "2")
      this.isMonth = true;
    else
      this.isMonth = false;
  }

  [DebuggerHidden]
  public IEnumerator SetSprite(int is_coinbonus_active)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Scroll0079.\u003CSetSprite\u003Ec__Iterator4FC()
    {
      is_coinbonus_active = is_coinbonus_active,
      \u003C\u0024\u003Eis_coinbonus_active = is_coinbonus_active,
      \u003C\u003Ef__this = this
    };
  }

  private int isReward(WebAPI.Response.CoinbonusHistory history)
  {
    int num1 = 0;
    CoinBonus[] coinBonuses = history.coin_bonuses;
    foreach (CoinBonusReward coinBonusReward in history.coin_bonus_rewards)
    {
      if (coinBonusReward._coin_product_id == this._coinProduct.ID)
      {
        for (int index = 0; index < coinBonuses.Length; ++index)
        {
          CoinBonus coinBonus = coinBonuses[index];
          if (coinBonus.id == coinBonusReward.coin_bonus_id)
          {
            DateTime? startAt = coinBonus.start_at;
            if ((!startAt.HasValue ? 0 : (startAt.Value <= DateTime.Now ? 1 : 0)) != 0)
            {
              DateTime? endAt = coinBonus.end_at;
              if ((!endAt.HasValue ? 0 : (endAt.Value >= DateTime.Now ? 1 : 0)) != 0)
              {
                int num2 = coinBonus.purchase_limit;
                if (num2 > 1)
                  num2 = 1;
                this.rewardCount = num2;
                this.nowReward = this.getRewardCount(history.player_coin_bonus_history, coinBonusReward.id);
                if (this.rewardCount > this.nowReward)
                {
                  this.itemReward = coinBonusReward.client_coin_shop_title;
                  num1 = 1;
                }
              }
            }
          }
        }
      }
    }
    return num1;
  }

  private int getRewardCount(PlayerCoinBonusHistory[] coinHistory, int rewardId)
  {
    int rewardCount = 0;
    for (int index = 0; index < coinHistory.Length; ++index)
    {
      if (coinHistory[index].coinbonus_reward_id == rewardId)
        ++rewardCount;
    }
    return rewardCount;
  }

  [DebuggerHidden]
  private IEnumerator openPopup999101()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Scroll0079.\u003CopenPopup999101\u003Ec__Iterator4FD popup999101CIterator4Fd = new Scroll0079.\u003CopenPopup999101\u003Ec__Iterator4FD();
    return (IEnumerator) popup999101CIterator4Fd;
  }

  public void onPayFinishEvent(int beforeCoin, int coin, int is_discount)
  {
    DDebug.Log(nameof (onPayFinishEvent));
    if (this.nowReward > 0 || this.rewardCount <= 0)
      is_discount = 0;
    Shop0079Menu.OnPurchaseSucceeded(this._coinProduct, beforeCoin, coin, is_discount, this.isMonth);
    if (this.rewardCount <= 0 || is_discount != 1)
      return;
    this.needRefresh = true;
  }

  [DebuggerHidden]
  private IEnumerator updateSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Scroll0079.\u003CupdateSprite\u003Ec__Iterator4FE()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onBuy()
  {
    SDK.instance.setPayFinishAct(new Action<int, int, int>(this.onPayFinishEvent));
    SDK.instance.buyItem(this.sdkItemindex);
  }
}
