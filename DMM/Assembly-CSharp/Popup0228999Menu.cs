﻿// Decompiled with JetBrains decompiler
// Type: Popup0228999Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

public class Popup0228999Menu : BackButtonMonoBehaiviour
{
  public void IbtnYes() => this.StartCoroutine(PopupUtility.BuyKiseki());

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().dismiss();

  public override void onBackButton() => this.IbtnNo();
}
