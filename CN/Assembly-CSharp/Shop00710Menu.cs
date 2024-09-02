// Decompiled with JetBrains decompiler
// Type: Shop00710Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00710Menu : BackButtonMenuBase
{
  [SerializeField]
  private UI2DSprite linkItem;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtPopuptitle;
  public string itemTitle;
  public string itemQuantity;
  public int itemPrice;
  public int purchasedStoneQuentity;
  private Sprite sendSprite;
  private string sendName;

  public Player player { get; set; }

  public PlayerShopArticle shopArticle { get; set; }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerShopArticle psa,
    int purchasedStoneQuentity,
    Sprite spr,
    string title,
    string kisekiNum)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00710Menu.\u003CInit\u003Ec__Iterator44A()
    {
      spr = spr,
      title = title,
      kisekiNum = kisekiNum,
      \u003C\u0024\u003Espr = spr,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003EkisekiNum = kisekiNum,
      \u003C\u003Ef__this = this
    };
  }

  public void SetSprite(Sprite item) => this.linkItem.sprite2D = item;

  public void SetText(string title, string kisekiNum)
  {
    Consts instance = Consts.GetInstance();
    this.itemTitle = title;
    this.itemQuantity = kisekiNum;
    this.TxtDescription01.SetTextLocalize(this.itemTitle + kisekiNum + Consts.GetInstance().SHOP_00710_MENU);
    this.TxtDescription02.SetText(instance.SHOP_00710_TXT_DESCRIPTION02);
    this.TxtDescription03.SetTextLocalize(string.Empty);
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
