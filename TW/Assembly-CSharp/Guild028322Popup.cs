// Decompiled with JetBrains decompiler
// Type: Guild028322Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild028322Popup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel popupDesc;
  private Guild0283Menu menu;

  public void Initialize(Guild0283Menu menu)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.menu = menu;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_DISMISS_CONFIRM_TITLE));
    this.popupDesc.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_DISMISS_DESC5));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().closeAll();

  [DebuggerHidden]
  private IEnumerator DismissGuild()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028322Popup.\u003CDismissGuild\u003Ec__Iterator78E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onYesButton() => this.StartCoroutine(this.DismissGuild());
}
