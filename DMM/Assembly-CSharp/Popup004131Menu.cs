﻿// Decompiled with JetBrains decompiler
// Type: Popup004131Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class Popup004131Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txt_Description1_left;
  private System.Action<bool> eventEnd_;

  public void Init(Unit00499Menu menu, bool isRecord = false) => this.Init((System.Action<bool>) (bYes =>
  {
    if (!bYes)
      return;
    this.StartCoroutine(menu.Transmigration(isRecord));
  }), isRecord);

  public void Init(System.Action<bool> onEnd, bool isRecord = false)
  {
    this.eventEnd_ = onEnd;
    if (isRecord)
      this.txt_Description1_left.SetTextLocalize(Consts.GetInstance().MEMORY_LOAD_DESCRIPTION);
    else
      this.txt_Description1_left.SetTextLocalize(Consts.GetInstance().TRANSMIGRATE_DESCRIPTION);
  }

  public void IbtnYes()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.eventEnd_(true);
  }

  public void IbtnNo()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.eventEnd_(false);
  }

  public override void onBackButton() => this.IbtnNo();
}
