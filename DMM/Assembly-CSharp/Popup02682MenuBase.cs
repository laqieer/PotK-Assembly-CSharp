﻿// Decompiled with JetBrains decompiler
// Type: Popup02682MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;

public class Popup02682MenuBase : BackButtonMonoBehaiviour
{
  protected System.Action onCallback;
  private bool isPush;

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  public virtual IEnumerator Init(
    Versus0268Menu.PvpParam.CampaignReward reward,
    Versus0268Menu.PvpParam.CampaignNextReward nextReward)
  {
    yield break;
  }

  public void IbtnOK()
  {
    if (this.isPush)
      return;
    this.isPush = true;
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOK();
}
