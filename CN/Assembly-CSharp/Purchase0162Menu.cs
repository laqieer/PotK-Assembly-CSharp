﻿// Decompiled with JetBrains decompiler
// Type: Purchase0162Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
