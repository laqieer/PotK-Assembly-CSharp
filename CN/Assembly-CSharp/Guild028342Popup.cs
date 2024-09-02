// Decompiled with JetBrains decompiler
// Type: Guild028342Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild028342Popup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel popupDesc;

  public void Initialize()
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_RESIGN_CONFIRM_TITLE));
    this.popupDesc.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_MENU_RESIGN_DESC3));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().closeAll();

  [DebuggerHidden]
  private IEnumerator LeaveFromGuild()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Guild028342Popup.\u003CLeaveFromGuild\u003Ec__Iterator6D8 guildCIterator6D8 = new Guild028342Popup.\u003CLeaveFromGuild\u003Ec__Iterator6D8();
    return (IEnumerator) guildCIterator6D8;
  }

  public void onYesButton() => this.StartCoroutine(this.LeaveFromGuild());
}
