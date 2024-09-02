﻿// Decompiled with JetBrains decompiler
// Type: Quest99961Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class Quest99961Menu : NGMenuBase
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

  public virtual void SetText(int have_bugu, int max_have_bugu, Player player_data)
  {
    this.player_data_ = player_data;
    this.TxtPopupdescripton01.SetText("[ff0000]" + Consts.Lookup("QUEST_99961_MENU_SET_TEXT_01"));
    this.TxtPopupdescripton02.SetText(Consts.Lookup("QUEST_99961_MENU_SET_TEXT_02"));
    this.TxtPopupdescripton03.SetText(Consts.Lookup("GACHA_0065MENU_DESCRIPTION02") + "：[ff0000]" + have_bugu.ToString().ToConverter() + "[-]/[ff0000]" + max_have_bugu.ToString().ToConverter() + "[-]");
    this.TxtTitle.SetText(Consts.Lookup("QUEST_99961_MENU_SET_TEXT_03"));
  }

  public virtual void IbtnPopupSell()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Bugu0052Scene.changeSceneSell(true);
  }

  public virtual void IbtnPopupIntegrate()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Bugu0053Scene.changeScene(true);
  }

  public virtual void IbtnPopupExtend()
  {
    this.player_data_ = SMManager.Get<Player>();
    if (this.player_data_.CheckLimitMaxItem())
      this.StartCoroutine(PopupUtility._999_12_1());
    else
      this.StartCoroutine(PopupUtility._007_16(0.0f));
  }
}
