// Decompiled with JetBrains decompiler
// Type: Guild028115Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild028115Popup : BackButtonMenuBase
{
  private GameObject commonDlgObj;
  private GuildInfoPopup guildPopupInfo;
  private GuildRegistration guildRegistration;
  private GuildDirectory guildDirectory;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UILabel guildTitle;
  [SerializeField]
  private UI2DSprite guildTitleImage;
  [SerializeField]
  private UILabel popupDesc;

  public void Initialize(GuildRegistration guild, GuildInfoPopup popup)
  {
    this.guildDirectory = (GuildDirectory) null;
    this.guildRegistration = guild;
    this.StartCoroutine(this.Initialize(this.guildRegistration.guild_name, popup, this.guildRegistration.appearance));
  }

  public void Initialize(GuildDirectory guild, GuildInfoPopup popup)
  {
    this.guildRegistration = (GuildRegistration) null;
    this.guildDirectory = guild;
    this.StartCoroutine(this.Initialize(this.guildDirectory.guild_name, popup, guild.appearance));
  }

  [DebuggerHidden]
  private IEnumerator Initialize(string name, GuildInfoPopup popup, GuildAppearance appearance)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028115Popup.\u003CInitialize\u003Ec__Iterator6F5()
    {
      popup = popup,
      name = name,
      appearance = appearance,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Eappearance = appearance,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetGuildData(GuildAppearance data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028115Popup.\u003CSetGuildData\u003Ec__Iterator6F6()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onButtonYes() => this.StartCoroutine(this.SendRequest());

  [DebuggerHidden]
  private IEnumerator SendRequest()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028115Popup.\u003CSendRequest\u003Ec__Iterator6F7()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ShowOkPopup(string title, string message, System.Action action)
  {
    GuildOkPopup component = Singleton<PopupManager>.GetInstance().open(this.commonDlgObj).GetComponent<GuildOkPopup>();
    System.Action action1 = action;
    string title1 = title;
    string message1 = message;
    Vector2? size = new Vector2?();
    System.Action ok = action1;
    component.Initialize(title1, message1, size, ok);
  }
}
