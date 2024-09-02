// Decompiled with JetBrains decompiler
// Type: Shop00711Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00711Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription01;
  [SerializeField]
  protected UILabel TxtDescription02;
  [SerializeField]
  protected UILabel TxtDescription03;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  private UI2DSprite linkItem;
  public int quantity;
  private string itemName;
  private int itemQuantity;

  public PlayerShopArticle shop { get; set; }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerShopArticle psa,
    int purchasedStoneQuentityBefore,
    Sprite spr,
    string nm,
    int qua)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00711Menu.\u003CInit\u003Ec__Iterator3C7()
    {
      spr = spr,
      \u003C\u0024\u003Espr = spr,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(CoinProduct product, int before, int after)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00711Menu.\u003CInit\u003Ec__Iterator3C8()
    {
      before = before,
      after = after,
      product = product,
      \u003C\u0024\u003Ebefore = before,
      \u003C\u0024\u003Eafter = after,
      \u003C\u0024\u003Eproduct = product,
      \u003C\u003Ef__this = this
    };
  }

  public void SetSprite(Sprite spr) => this.linkItem.sprite2D = spr;

  public void SetText(int befereCoin, int afterCoin)
  {
    this.TxtDescription03.SetTextLocalize(Consts.Lookup("SHPT_0711_MENU_BUY_KISEKI", (IDictionary) new Hashtable()
    {
      {
        (object) "before",
        (object) befereCoin
      },
      {
        (object) "after",
        (object) afterCoin
      }
    }));
  }

  public virtual void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    PaymentListener.PopupDismiss();
  }

  public override void onBackButton() => this.IbtnPopupOk();
}
