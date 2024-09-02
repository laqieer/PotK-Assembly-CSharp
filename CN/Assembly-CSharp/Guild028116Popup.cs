// Decompiled with JetBrains decompiler
// Type: Guild028116Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild028116Popup : BackButtonMenuBase
{
  private GuildInfoPopup guildPopupInfo;
  private GuildRegistration guildRegistration;
  private GuildDirectory guildDirectory;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel popupDesc;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UILabel guildTitle;
  [SerializeField]
  private UI2DSprite guildTitleImage;

  public void Initialize(GuildRegistration guild, GuildInfoPopup popup)
  {
    this.guildDirectory = (GuildDirectory) null;
    this.guildRegistration = guild;
    this.Initialize(this.guildRegistration.guild_name, popup);
    this.StartCoroutine(this.SetGuildData(guild.appearance));
  }

  public void Initialize(GuildDirectory guild, GuildInfoPopup popup)
  {
    this.guildRegistration = (GuildRegistration) null;
    this.guildDirectory = guild;
    this.Initialize(this.guildDirectory.guild_name, popup);
    this.StartCoroutine(this.SetGuildData(guild.appearance));
  }

  private void Initialize(string name, GuildInfoPopup popup)
  {
    this.guildPopupInfo = popup;
    this.guildName.SetTextLocalize(name);
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_6_TITLE));
    this.popupDesc.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_6_DESC));
  }

  [DebuggerHidden]
  private IEnumerator SetGuildData(GuildAppearance data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028116Popup.\u003CSetGuildData\u003Ec__Iterator69D()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onButtonYes() => this.StartCoroutine(this.SendCancelRequest());

  [DebuggerHidden]
  private IEnumerator SendCancelRequest()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028116Popup.\u003CSendCancelRequest\u003Ec__Iterator69E()
    {
      \u003C\u003Ef__this = this
    };
  }
}
