﻿// Decompiled with JetBrains decompiler
// Type: Guild028NgWordPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class Guild028NgWordPopup : BackButtonMenuBase
{
  private System.Action callback;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDesc;

  public void Initialize(System.Action ok = null)
  {
    if ((UnityEngine.Object) this.GetComponent<UIWidget>() != (UnityEngine.Object) null)
      this.GetComponent<UIWidget>().alpha = 0.0f;
    this.txtTitle.SetTextLocalize(Consts.GetInstance().GUILD_COMMON_NG_WORD_TITLE);
    this.txtDesc.SetTextLocalize(Consts.GetInstance().GUILD_COMMON_NG_WORD);
    this.callback = ok;
  }

  public override void onBackButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.callback == null)
      return;
    this.callback();
  }
}
