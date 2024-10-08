﻿// Decompiled with JetBrains decompiler
// Type: Quest00214PopupReleaseCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Quest00214PopupReleaseCondition : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtDescription;

  public void Init(string message) => this.TxtDescription.SetText(message);

  public void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOk();
}
