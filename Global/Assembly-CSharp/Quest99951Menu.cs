﻿// Decompiled with JetBrains decompiler
// Type: Quest99951Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class Quest99951Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtPopupdescripton01;
  [SerializeField]
  protected UILabel TxtPopupdescripton02;
  [SerializeField]
  protected UILabel TxtPopupdescripton03;
  [SerializeField]
  protected UILabel TxtTitle;
  protected Player player_data_;

  public virtual void SetText(int have_unit, int max_have_unit, Player player_data)
  {
    this.TxtPopupdescripton03.SetTextLocalize(Consts.Lookup("GACHA_0065MENU_DESCRIPTION02") + "：[ff0000]" + have_unit.ToLocalizeNumberText() + "[-]/[ff0000]" + max_have_unit.ToLocalizeNumberText() + "[-]");
  }

  public void IbtnPopupCom()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    Unit00468Scene.changeScene0048(true);
  }

  public void IbtnPopupDisjoint()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    Unit00468Scene.changeScene00410(true);
  }

  public void IbtnPopupExtend()
  {
    this.player_data_ = SMManager.Get<Player>();
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (this.player_data_.CheckLimitMaxUnit())
      this.StartCoroutine(PopupUtility._999_11_1());
    else
      this.StartCoroutine(PopupUtility._007_14(0.0f));
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
