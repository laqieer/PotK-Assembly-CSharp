// Decompiled with JetBrains decompiler
// Type: GuildBankDonateResultPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

#nullable disable
public class GuildBankDonateResultPopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel desc;
  [SerializeField]
  private UILabel lblZeny;
  [SerializeField]
  private UILabel valZeny;
  [SerializeField]
  private UILabel lblExp;
  [SerializeField]
  private UILabel valExp;
  [SerializeField]
  private UILabel lblContribution;
  [SerializeField]
  private UILabel valContribution;
  private System.Action onCloseAction;

  public void Initialize(GuildBankDonationInfo info, System.Action action = null)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.onCloseAction = action;
    this.title.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BANK_DONATE_RESULT_TITLE);
    string str1 = string.Empty;
    string str2 = string.Empty;
    switch (info.donateType)
    {
      case GuildMoneyToken.money:
        str1 = string.Empty;
        str2 = Consts.GetInstance().GUILD_BANK_DONATE_UNIT_ZENY;
        break;
      case GuildMoneyToken.friend_point:
        str1 = Consts.GetInstance().GUILD_BANK_DONATE_TYPE_MANA;
        str2 = Consts.GetInstance().GUILD_BANK_DONATE_UNIT_MANA;
        break;
      case GuildMoneyToken.medal:
        str1 = Consts.GetInstance().GUILD_BANK_DONATE_TYPE_MEDAL;
        str2 = Consts.GetInstance().GUILD_BANK_DONATE_UNIT_MEDAL;
        break;
    }
    this.desc.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BANK_DONATE_RESULT_DESC, (IDictionary) new Hashtable()
    {
      {
        (object) "type",
        (object) str1
      },
      {
        (object) "num",
        (object) info.quantity
      },
      {
        (object) "unit",
        (object) str2
      }
    }));
    this.lblZeny.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BANK_LABEL_ZENY);
    this.valZeny.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BANK_VALUE_ZENY, (IDictionary) new Hashtable()
    {
      {
        (object) "before",
        (object) info.zeny_before
      },
      {
        (object) "after",
        (object) info.zeny_result
      }
    }));
    this.lblExp.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BANK_LABEL_EXP);
    this.valExp.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BANK_VALUE_EXP, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) info.exp
      }
    }));
    this.lblContribution.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BANK_LABEL_CONTRIBUTION);
    this.valContribution.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_BANK_VALUE_CONTRIBUTION, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) info.contribution
      }
    }));
  }

  public override void onBackButton()
  {
    if (this.onCloseAction != null)
      this.onCloseAction();
    Singleton<PopupManager>.GetInstance().dismiss(true);
  }
}
