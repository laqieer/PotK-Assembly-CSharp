// Decompiled with JetBrains decompiler
// Type: Shop99971Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
      string text1 = Consts.Lookup("SHOP_99971_TXT_TITLE_MONEY");
      string text2 = Consts.Lookup("SHOP_99971_TXT_DESCRIPTION_MONEY");
      this.TxtTitleMoney.SetText(text1);
      this.TxtDescriptionMoney.SetText(text2);
    }
    else
    {
      if (payType != CommonPayType.medal)
        return;
      string text3 = Consts.Lookup("SHOP_99971_TXT_TITLE_MEDAL");
      string text4 = Consts.Lookup("SHOP_99971_TXT_DESCRIPTION_MEDAL");
      this.TxtTitleMoney.SetText(text3);
      this.TxtDescriptionMedal.SetText(text4);
    }
  }

  public void SetText(ShopArticle shop_article) => this.SetText(shop_article.pay_type);

  public virtual void IbtnPopupOk() => Singleton<PopupManager>.GetInstance().closeAll();
}
