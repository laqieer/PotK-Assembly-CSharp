﻿// Decompiled with JetBrains decompiler
// Type: Popup0228999Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class Popup0228999Menu : BackButtonMonoBehaiviour
{
  public void IbtnYes() => this.StartCoroutine(PopupUtility.BuyKiseki());

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().dismiss();

  public override void onBackButton() => this.IbtnNo();
}
