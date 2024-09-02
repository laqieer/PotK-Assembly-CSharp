// Decompiled with JetBrains decompiler
// Type: Shop007231Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop007231Menu : BackButtonMenuBase
{
  [SerializeField]
  private Shop007231Scene scene_;
  [SerializeField]
  private UIScrollView scroll_;
  [SerializeField]
  private UIGrid grid_;

  [DebuggerHidden]
  public IEnumerator coInitialize(PlayerUnitTicketSummary[] coupons)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop007231Menu.\u003CcoInitialize\u003Ec__Iterator4CC()
    {
      coupons = coupons,
      \u003C\u0024\u003Ecoupons = coupons,
      \u003C\u003Ef__this = this
    };
  }

  public void onEndMenu()
  {
    foreach (Component child in ((Component) this.grid_).transform.GetChildren())
      Object.Destroy((Object) child.gameObject);
  }

  public void selectedCoupon(PlayerUnitTicketSummary coupon)
  {
    if (this.IsPushAndSet())
      return;
    Shop00723Scene.changeScene(coupon);
  }

  public void onClickedDescription(SM.UnitTicket ticket)
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine("coPopupDescription", (object) ticket);
  }

  [DebuggerHidden]
  private IEnumerator coPopupDescription(SM.UnitTicket ticket)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop007231Menu.\u003CcoPopupDescription\u003Ec__Iterator4CD()
    {
      ticket = ticket,
      \u003C\u0024\u003Eticket = ticket
    };
  }

  public override void onBackButton() => this.OnIbtnBack();

  public void OnIbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
