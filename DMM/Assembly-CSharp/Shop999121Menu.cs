﻿// Decompiled with JetBrains decompiler
// Type: Shop999121Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class Shop999121Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription;

  public void SetText()
  {
    string text1 = Consts.Format(Consts.GetInstance().SHOP_999121_TXT_TITLE);
    string text2 = Consts.Format(Consts.GetInstance().SHOP_999121_TXT_DESCRIPTION);
    this.TxtTitle.SetText(text1);
    this.TxtDescription.SetText(text2);
  }

  public virtual void IbtnPopupOk() => Singleton<PopupManager>.GetInstance().closeAll();

  public override void onBackButton() => this.IbtnPopupOk();
}
