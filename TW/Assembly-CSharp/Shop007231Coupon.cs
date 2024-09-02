// Decompiled with JetBrains decompiler
// Type: Shop007231Coupon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop007231Coupon : MonoBehaviour
{
  [SerializeField]
  private UILabel txtTitle_;
  [SerializeField]
  private GameObject linkThum_;
  [SerializeField]
  private UILabel txtLimitDate_;
  [SerializeField]
  private UILabel txtNeed_;
  [SerializeField]
  private UILabel txtProgress_;
  [SerializeField]
  private UILabel txtProgressRed_;
  [SerializeField]
  private UIButton btnToShop_;
  private Shop007231Menu menu_;
  private PlayerUnitTicketSummary coupon_;

  [DebuggerHidden]
  public IEnumerator coInitialize(Shop007231Menu menu, PlayerUnitTicketSummary coupon)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop007231Coupon.\u003CcoInitialize\u003Ec__Iterator4CA()
    {
      coupon = coupon,
      menu = menu,
      \u003C\u0024\u003Ecoupon = coupon,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  public void onClickedSelect() => this.menu_.selectedCoupon(this.coupon_);

  public void onClickedDescription() => this.menu_.onClickedDescription(this.coupon_.unit_ticket);
}
