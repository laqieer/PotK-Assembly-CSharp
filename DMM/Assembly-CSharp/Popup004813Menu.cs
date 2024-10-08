﻿// Decompiled with JetBrains decompiler
// Type: Popup004813Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Popup004813Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel txtDescription1;
  private System.Action callback;

  public void SetText(int medal) => this.txtDescription1.SetText(Consts.Format(Consts.GetInstance().POPUP_004813_DESCRIPT_TEXT, (IDictionary) new Hashtable()
  {
    {
      (object) "Count",
      (object) medal.ToLocalizeNumberText()
    }
  }));

  public void SetIbtnOKCallback(System.Action callback) => this.callback = callback;

  public virtual void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    if (this.callback != null)
      this.callback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnPopupOk();
}
