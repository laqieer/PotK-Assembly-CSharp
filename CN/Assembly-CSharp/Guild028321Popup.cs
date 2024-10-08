﻿// Decompiled with JetBrains decompiler
// Type: Guild028321Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Guild028321Popup : BackButtonMenuBase
{
  private Guild0283Menu menu;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel popupDesc;
  [SerializeField]
  private UILabel popupDesc2;

  public void Initialize(Guild0283Menu guild0283Menu)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.menu = guild0283Menu;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_DISMISS_TITLE));
    this.popupDesc.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_DISMISS_DESC3));
    this.popupDesc2.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_DISMISS_DESC4));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onYesButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    Singleton<PopupManager>.GetInstance().open(this.menu.GuildBrakeUpConfirmPopup).GetComponent<Guild028322Popup>().Initialize();
  }
}
