// Decompiled with JetBrains decompiler
// Type: Guild028401Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild028401Popup : BackButtonMenuBase
{
  private Guild02811Menu menu;
  [SerializeField]
  private GuildSetting setting;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UILabel atmosphere;
  [SerializeField]
  private UILabel approval;
  [SerializeField]
  private UILabel autoApproval;

  public void Initialize(Guild02811Menu guild02811menu, GuildSetting data)
  {
    this.menu = guild02811menu;
    this.setting = data;
    this.guildName.SetTextLocalize(this.setting.guildName);
    this.atmosphere.SetTextLocalize(this.setting.atmosphere);
    this.approval.SetTextLocalize(this.setting.approval);
    this.autoApproval.SetTextLocalize(this.setting.autoApproval);
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onButtonDecision()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.BuildGuild());
  }

  [DebuggerHidden]
  private IEnumerator BuildGuild()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028401Popup.\u003CBuildGuild\u003Ec__Iterator6A1()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ErrorCallback(WebAPI.Response.UserError error)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    if (error.Code.Equals("GLD011"))
    {
      Singleton<PopupManager>.GetInstance().open(this.menu.GuildNgWordPopup).GetComponent<Guild028NgWordPopup>().Initialize((System.Action) (() => this.menu.BuildGuildPopupOpen(this.setting)));
    }
    else
    {
      Singleton<CommonRoot>.GetInstance().isLoading = true;
      WebAPI.DefaultUserErrorCallback(error);
      Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
    }
  }
}
