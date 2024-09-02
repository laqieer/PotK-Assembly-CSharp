// Decompiled with JetBrains decompiler
// Type: Purchase0162Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Purchase0162Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtNumberCharge;
  [SerializeField]
  protected UILabel TxtNumberFree;
  [SerializeField]
  protected UILabel TxtNumberCommon;
  [SerializeField]
  protected UIScrollView uiScroll;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public void InitPurchase(Player player)
  {
    this.TxtNumberCharge.SetTextLocalize(player.paid_coin);
    this.TxtNumberFree.SetTextLocalize(player.free_coin);
    this.TxtNumberCommon.SetTextLocalize(player.common_coin);
    this.uiScroll.ResetPosition();
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
