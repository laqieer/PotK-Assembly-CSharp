// Decompiled with JetBrains decompiler
// Type: GuildBankDonateListParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using UnityEngine;

public class GuildBankDonateListParts : MonoBehaviour
{
  [SerializeField]
  private UIButton btnDonate;
  [SerializeField]
  private UILabel exchangeRate;
  [SerializeField]
  private UILabel possession;
  [SerializeField]
  private UISprite iconZeny;
  [SerializeField]
  private UISprite iconMedal;
  [SerializeField]
  private UISprite iconMana;
  [SerializeField]
  private GameObject campaignObj;
  [SerializeField]
  private UILabel campaignLabel;
  [SerializeField]
  private UILabel title;
  private GuildMoneyRate moneyRate;
  private System.Action<GuildMoneyRate> actionDonate;
  private bool active;

  private void LoadIcon()
  {
    this.iconZeny.gameObject.SetActive(false);
    this.iconMedal.gameObject.SetActive(false);
    this.iconMana.gameObject.SetActive(false);
    switch (this.moneyRate.token_type)
    {
      case GuildMoneyToken.money:
        this.iconZeny.gameObject.SetActive(true);
        break;
      case GuildMoneyToken.friend_point:
        this.iconMana.gameObject.SetActive(true);
        break;
      case GuildMoneyToken.medal:
        this.iconMedal.gameObject.SetActive(true);
        break;
    }
  }

  public IEnumerator Initialize(
    bool active,
    GuildMoneyRate rate,
    int scale,
    System.Action<GuildMoneyRate> onDonate = null)
  {
    this.active = active;
    this.moneyRate = rate;
    this.actionDonate = onDonate;
    this.LoadIcon();
    this.SetAppearance(scale);
    yield break;
  }

  public void SetAppearance(int scale)
  {
    string str1 = string.Empty;
    string str2 = string.Empty;
    long num = 0;
    switch (this.moneyRate.token_type)
    {
      case GuildMoneyToken.money:
        str1 = Consts.GetInstance().GUILD_BANK_DONATE_TYPE_ZENY;
        str2 = Consts.GetInstance().GUILD_BANK_DONATE_UNIT_ZENY;
        num = Player.Current.money;
        break;
      case GuildMoneyToken.friend_point:
        str1 = Consts.GetInstance().GUILD_BANK_DONATE_TYPE_MANA;
        str2 = Consts.GetInstance().GUILD_BANK_DONATE_UNIT_MANA;
        num = (long) Player.Current.friend_point;
        break;
      case GuildMoneyToken.medal:
        str1 = Consts.GetInstance().GUILD_BANK_DONATE_TYPE_MEDAL;
        str2 = Consts.GetInstance().GUILD_BANK_DONATE_UNIT_MEDAL;
        num = (long) Player.Current.battle_medal;
        break;
    }
    this.title.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_BANK_DONATE_LIST_TITLE, (IDictionary) new Hashtable()
    {
      {
        (object) "type",
        (object) str1
      }
    }));
    this.exchangeRate.SetTextLocalize(Consts.Format(this.moneyRate.campaign_flag ? Consts.GetInstance().GUILD_BANK_EXCHANGE_RATE_CAMPAIGN : Consts.GetInstance().GUILD_BANK_EXCHANGE_RATE, (IDictionary) new Hashtable()
    {
      {
        (object) "num",
        (object) (this.moneyRate.ask_token * scale)
      },
      {
        (object) "unit",
        (object) str2
      },
      {
        (object) "money",
        (object) (this.moneyRate.guild_money * scale)
      }
    }));
    bool flag = num >= (long) (this.moneyRate.ask_token * scale);
    this.possession.SetTextLocalize(Consts.Format(flag ? Consts.GetInstance().GUILD_BANK_POSSESSION : Consts.GetInstance().GUILD_BANK_POSSESSION_SHORTAGE, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) num
      },
      {
        (object) "unit",
        (object) str2
      }
    }));
    this.campaignObj.SetActive(this.moneyRate.campaign_flag);
    this.btnDonate.isEnabled = flag && this.active;
  }

  public void onDonateButton()
  {
    if (this.actionDonate == null)
      return;
    this.actionDonate(this.moneyRate);
  }
}
