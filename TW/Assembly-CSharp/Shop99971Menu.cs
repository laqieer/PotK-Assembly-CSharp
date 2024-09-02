// Decompiled with JetBrains decompiler
// Type: Shop99971Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using UnityEngine;

#nullable disable
public class Shop99971Menu : NGMenuBase
{
  [SerializeField]
  private UILabel TxtTitleMoney;
  [SerializeField]
  private UILabel TxtTitleMedal;
  [SerializeField]
  private UILabel TxtDescriptionMoney;
  [SerializeField]
  private UILabel TxtDescriptionMedal;

  public void SetText(CommonPayType payType)
  {
    if (payType == CommonPayType.money)
    {
      string text1 = Consts.Format(Consts.GetInstance().SHOP_99971_TXT_TITLE_MONEY);
      string text2 = Consts.Format(Consts.GetInstance().SHOP_99971_TXT_DESCRIPTION_MONEY);
      this.TxtTitleMoney.SetText(text1);
      this.TxtDescriptionMoney.SetText(text2);
    }
    else
    {
      if (payType != CommonPayType.medal)
        return;
      string text3 = Consts.Format(Consts.GetInstance().SHOP_99971_TXT_TITLE_MEDAL);
      string text4 = Consts.Format(Consts.GetInstance().SHOP_99971_TXT_DESCRIPTION_MEDAL);
      this.TxtTitleMoney.SetText(text3);
      this.TxtDescriptionMedal.SetText(text4);
    }
  }

  public void SetText(ShopArticle shop_article) => this.SetText(shop_article.pay_type);

  public virtual void IbtnPopupOk() => Singleton<PopupManager>.GetInstance().closeAll();
}
