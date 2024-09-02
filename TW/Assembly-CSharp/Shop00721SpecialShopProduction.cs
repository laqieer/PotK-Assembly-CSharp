// Decompiled with JetBrains decompiler
// Type: Shop00721SpecialShopProduction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00721SpecialShopProduction : MonoBehaviour
{
  [SerializeField]
  private GameObject soldout;
  [SerializeField]
  private GameObject slcHime;
  [SerializeField]
  private FloatButton BtnFormation;
  [SerializeField]
  private UI2DSprite BtnSprite;
  [SerializeField]
  private UILabel txtTime;
  [SerializeField]
  private UILabel txtProductNum;
  [SerializeField]
  private UILabel txtPrice;
  private Shop00721Menu m_menu;
  private int m_shopID;
  private int m_idx;
  private PlayerShopArticle m_article;

  public FloatButton Btn => this.BtnFormation;

  public void Disable()
  {
    if (!Object.op_Inequality((Object) this.BtnFormation, (Object) null))
      return;
    this.BtnFormation.isEnabled = false;
  }

  public void Enable()
  {
    if (!Object.op_Inequality((Object) this.BtnFormation, (Object) null))
      return;
    this.BtnFormation.isEnabled = true;
  }

  private void SetTimeString(DateTime serverTime, DateTime? endTime)
  {
    if (!endTime.HasValue)
    {
      ((Component) this.txtTime).gameObject.SetActive(false);
      this.txtTime.SetTextLocalize(string.Empty);
    }
    else
    {
      ((Component) this.txtTime).gameObject.SetActive(true);
      TimeSpan self = endTime.Value - serverTime;
      this.txtTime.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_0074_SCROLL_UPDATE_SERVER_TIME, (IDictionary) new Hashtable()
      {
        {
          (object) "time",
          (object) self.DisplayString()
        }
      }));
    }
  }

  private void SetRechargeTime(DateTime serverTime, PlayerShopArticle article)
  {
    TimeSpan timeSpan = article.recharge_at.Value - serverTime;
    int num1 = timeSpan.Hours >= 0 ? timeSpan.Hours : 0;
    int num2 = timeSpan.Minutes >= 0 ? timeSpan.Minutes : 0;
    int seconds = timeSpan.Seconds >= 0 ? timeSpan.Seconds : 0;
    if (num1 == 0 && num2 == 0 && seconds > 0)
    {
      num1 = 0;
      num2 = 1;
    }
    ((Component) this.txtProductNum).gameObject.SetActive(true);
    string str = string.Format(Consts.GetInstance().SHOP_00721_SPECIAL_SHOP_PRODUCTION_UPDATE_SERVER_TIME2, (object) num1, (object) num2);
    this.txtProductNum.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_00721_SPECIAL_SHOP_PRODUCTION_UPDATE_SERVER_TIME, (IDictionary) new Hashtable()
    {
      {
        (object) "time",
        (object) str
      }
    }));
  }

  private void SetLimitsStat(DateTime serverTime, PlayerShopArticle article)
  {
    this.BtnFormation.isEnabled = true;
    this.soldout.SetActive(false);
    ((Component) this.txtProductNum).gameObject.SetActive(false);
    if (article.article.limit.HasValue || article.article.daily_limit.HasValue)
    {
      if (article.article.limit.HasValue && article.limit.Value <= 0 || article.article.daily_limit.HasValue && article.limit.Value <= 0)
        this.soldout.SetActive(true);
      else if (article.recharge_at.HasValue && serverTime < article.recharge_at.Value)
      {
        this.SetRechargeTime(serverTime, article);
      }
      else
      {
        ((Component) this.txtProductNum).gameObject.SetActive(true);
        if (article.article.unit == string.Empty)
          this.txtProductNum.SetTextLocalize(string.Format(Consts.GetInstance().SHOP_0074_SCROLL_ARTICLE_LIMIT_VALUE, (object) article.limit.Value));
        else
          this.txtProductNum.SetTextLocalize(Consts.Format(Consts.GetInstance().SHOP_0074_SCROLL_ARTICLE_LIMIT_VALUE_EXT, (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) article.limit.Value
            },
            {
              (object) "unit",
              (object) article.article.unit
            }
          }));
      }
    }
    else
    {
      if (!article.recharge_at.HasValue || !(serverTime < article.recharge_at.Value))
        return;
      this.SetRechargeTime(serverTime, article);
    }
  }

  [DebuggerHidden]
  public IEnumerator Init(
    DateTime serverTime,
    int shopID,
    PlayerShopArticle article,
    Shop00721Menu menu,
    int idx)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00721SpecialShopProduction.\u003CInit\u003Ec__Iterator4AD()
    {
      idx = idx,
      menu = menu,
      shopID = shopID,
      article = article,
      serverTime = serverTime,
      \u003C\u0024\u003Eidx = idx,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EshopID = shopID,
      \u003C\u0024\u003Earticle = article,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnProduct()
  {
    if (Object.op_Inequality((Object) this.m_menu, (Object) null))
      this.m_menu.CurrentShopIDX = this.m_idx;
    Shop00722Scene.changeScene(true, this.m_shopID, this.m_article, ((Component) this).gameObject);
  }
}
