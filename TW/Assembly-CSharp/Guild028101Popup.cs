// Decompiled with JetBrains decompiler
// Type: Guild028101Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Guild028101Popup : BackButtonMenuBase
{
  private Guild02811Menu menu;
  private GuildSetting setting;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UIInput guildNameInput;
  [SerializeField]
  private UILabel atmosphere;
  [SerializeField]
  private UIPopupList atmosphereList;
  [SerializeField]
  private UILabel approval;
  [SerializeField]
  private UIPopupList approvalList;
  [SerializeField]
  private UILabel autoApproval;
  [SerializeField]
  private UIPopupList autoApprovalList;
  [SerializeField]
  private UILabel availability;
  [SerializeField]
  private UIPopupList availabilityList;

  public void Initialize(Guild02811Menu guild02811menu, GuildSetting guildsetting)
  {
    this.menu = guild02811menu;
    this.setting = guildsetting;
    this.guildNameInput.onValidate = new UIInput.OnValidate(this.onValidate);
    this.guildName.SetTextLocalize(this.setting.guildName);
    this.guildNameInput.value = this.setting.guildName;
    this.guildNameInput.defaultText = string.Empty;
    this.atmosphere.SetTextLocalize(this.setting.atmosphere);
    this.approval.SetTextLocalize(this.setting.approval);
    this.autoApproval.SetTextLocalize(this.setting.autoApproval);
    this.availability.SetTextLocalize(this.setting.availability);
    this.atmosphereList.items.Clear();
    this.atmosphereList.items.Add(Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL);
    ((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).ForEach<GuildAtmosphere>((Action<GuildAtmosphere>) (x => this.atmosphereList.items.Add(x.name)));
    this.atmosphereList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.atmosphereList.value = this.setting.atmosphere;
    this.approvalList.items.Clear();
    this.approvalList.items.Add(Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL);
    ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).ForEach<GuildApprovalPolicy>((Action<GuildApprovalPolicy>) (x => this.approvalList.items.Add(x.name)));
    this.approvalList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.approvalList.value = this.setting.approval;
    this.autoApprovalList.items.Clear();
    this.autoApprovalList.items.Add(Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL);
    ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).ForEach<GuildAutoApproval>((Action<GuildAutoApproval>) (x => this.autoApprovalList.items.Add(x.name)));
    this.autoApprovalList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.autoApprovalList.value = this.setting.autoApproval;
    this.availabilityList.items.Clear();
    this.availabilityList.items.Add(Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL);
    ((IEnumerable<GuildAvailability>) MasterData.GuildAvailabilityList).ForEach<GuildAvailability>((Action<GuildAvailability>) (x => this.availabilityList.items.Add(x.name)));
    this.availabilityList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.availabilityList.value = this.setting.availability;
  }

  private char onValidate(string text, int charIndex, char addedChar)
  {
    bool flag = char.IsControl(addedChar) || addedChar >= '\uE000' && addedChar <= '\uF8FF';
    Debug.Log((object) (((int) addedChar).ToString() + ":" + (object) flag));
    return flag ? char.MinValue : addedChar;
  }

  public void onChangeInput()
  {
    if (this.IsPush)
      return;
    this.guildName.SetTextLocalize(this.guildNameInput.value);
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onButtonSerch()
  {
    this.menu.Setting(new GuildSetting()
    {
      guildName = this.guildName.text,
      atmosphere = this.atmosphere.text,
      approval = this.approval.text,
      autoApproval = this.autoApproval.text,
      availability = this.availability.text
    });
    Singleton<PopupManager>.GetInstance().dismiss();
    this.StartCoroutine(this.menu.SearchGuild(new System.Action(this.menu.DrawGuildList)));
  }

  public void onButtonBest()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.StartCoroutine(this.menu.SearchBestGuild(new System.Action(this.menu.DrawGuildList)));
  }

  public void onButtonFriend()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.StartCoroutine(this.menu.FriendList());
  }
}
