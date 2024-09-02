// Decompiled with JetBrains decompiler
// Type: Guild028341Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Guild028341Popup : BackButtonMenuBase
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
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_RESIGN_TITLE));
    this.popupDesc.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_RESIGN_DESC1));
    this.popupDesc2.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_RESIGN_DESC2));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onYesButton()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    Singleton<PopupManager>.GetInstance().open(this.menu.GuildResignConfirmPopup).GetComponent<Guild028342Popup>().Initialize(this.menu);
  }
}
