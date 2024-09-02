// Decompiled with JetBrains decompiler
// Type: Purchase0162Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  protected UILabel txt_Attention;

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
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
