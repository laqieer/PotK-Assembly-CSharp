// Decompiled with JetBrains decompiler
// Type: Guild028OptionEditConfirmPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Guild028OptionEditConfirmPopup : BackButtonMenuBase
{
  private Guild0283Menu guildMenu;
  private int approval_policy_id;
  private int atmosphere_id;
  private int auto_approval_id;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel guildNameLabel;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UILabel approvalPolicyLabel;
  [SerializeField]
  private UILabel approvalPolicy;
  [SerializeField]
  private UILabel atmosphereLabel;
  [SerializeField]
  private UILabel atmosphere;
  [SerializeField]
  private UILabel autoApprovalLabel;
  [SerializeField]
  private UILabel autoApproval;

  public void Initialize(
    Guild0283Menu menu,
    int approval_policy,
    int atmosphere,
    int auto_approval,
    string guild_name)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.guildMenu = menu;
    this.approval_policy_id = approval_policy;
    this.atmosphere_id = atmosphere;
    this.auto_approval_id = auto_approval;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_TITLE2));
    this.guildNameLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_GUILD_NAME));
    this.atmosphereLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_ATMOSPHERE));
    this.approvalPolicyLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_REQUIREMENT));
    this.autoApprovalLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_APPROVAL));
    this.guildName.SetTextLocalize(guild_name);
    this.atmosphere.SetTextLocalize(((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).Where<GuildAtmosphere>((Func<GuildAtmosphere, bool>) (x => x.ID == atmosphere)).First<GuildAtmosphere>().name);
    this.approvalPolicy.SetTextLocalize(((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).Where<GuildApprovalPolicy>((Func<GuildApprovalPolicy, bool>) (x => x.ID == approval_policy)).First<GuildApprovalPolicy>().name);
    this.autoApproval.SetTextLocalize(((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).Where<GuildAutoApproval>((Func<GuildAutoApproval, bool>) (x => x.ID == auto_approval)).First<GuildAutoApproval>().name);
  }

  private void ErrorCallback(WebAPI.Response.UserError error)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    if (error.Code.Equals("GLD011"))
      Singleton<PopupManager>.GetInstance().open(this.guildMenu.GuildNgWordPopup).GetComponent<Guild028NgWordPopup>().Initialize((System.Action) (() => { }));
    else if (error.Code.Equals("GLD014"))
    {
      WebAPI.DefaultUserErrorCallback(error);
      Singleton<CommonRoot>.GetInstance().isLoading = true;
      Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
    }
    else
      WebAPI.DefaultUserErrorCallback(error);
  }

  [DebuggerHidden]
  private IEnumerator SendGuildSetting()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028OptionEditConfirmPopup.\u003CSendGuildSetting\u003Ec__Iterator6D9()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onYesButton() => this.StartCoroutine(this.SendGuildSetting());
}
