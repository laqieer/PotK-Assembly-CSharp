// Decompiled with JetBrains decompiler
// Type: Guild028OptionEditPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Guild028OptionEditPopup : BackButtonMenuBase
{
  private Guild0283Menu guildMenu;
  private GuildRegistration guildSetting;
  private string prevRequirementPulldownValue;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel guildNameLabel;
  [SerializeField]
  private UIInput guildNameInput;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UILabel atmosphereLabel;
  [SerializeField]
  private UILabel atmosphere;
  [SerializeField]
  private UILabel conditionLabel;
  [SerializeField]
  private UILabel condition;
  [SerializeField]
  private UILabel approvalLabel;
  [SerializeField]
  private UILabel approval;
  [SerializeField]
  private UIPopupList atmospherePulldown;
  [SerializeField]
  private UIPopupList conditionPulldown;
  [SerializeField]
  private UIPopupList approvalPulldown;
  [SerializeField]
  private SpreadColorButton decideButton;

  public void Initialize(Guild0283Menu menu)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.guildMenu = menu;
    this.guildSetting = PlayerAffiliation.Current.guild;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_TITLE));
    this.guildNameLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_GUILD_NAME));
    this.atmosphereLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_ATMOSPHERE));
    this.conditionLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_REQUIREMENT));
    this.approvalLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_OPTION_EDIT_APPROVAL));
    this.atmospherePulldown.items.Clear();
    this.conditionPulldown.items.Clear();
    this.approvalPulldown.items.Clear();
    this.atmospherePulldown.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.conditionPulldown.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.approvalPulldown.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    ((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).ForEach<GuildAtmosphere>((Action<GuildAtmosphere>) (x => this.atmospherePulldown.items.Add(x.name)));
    ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).ForEach<GuildApprovalPolicy>((Action<GuildApprovalPolicy>) (x => this.conditionPulldown.items.Add(x.name)));
    ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).ForEach<GuildAutoApproval>((Action<GuildAutoApproval>) (x => this.approvalPulldown.items.Add(x.name)));
    int? nullable = ((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).FirstIndexOrNull<GuildAtmosphere>((Func<GuildAtmosphere, bool>) (x => x.ID == this.guildSetting.atmosphere.ID));
    if (nullable.HasValue)
    {
      this.atmosphere.SetTextLocalize(MasterData.GuildAtmosphereList[nullable.Value].name);
      this.atmospherePulldown.value = this.atmosphere.text;
    }
    nullable = ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).FirstIndexOrNull<GuildApprovalPolicy>((Func<GuildApprovalPolicy, bool>) (x => x.ID == this.guildSetting.approval_policy.ID));
    if (nullable.HasValue)
    {
      this.condition.SetTextLocalize(MasterData.GuildApprovalPolicyList[nullable.Value].name);
      this.conditionPulldown.value = this.condition.text;
    }
    nullable = ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).FirstIndexOrNull<GuildAutoApproval>((Func<GuildAutoApproval, bool>) (x => x.ID == this.guildSetting.auto_approval.ID));
    if (nullable.HasValue)
    {
      this.approval.SetTextLocalize(MasterData.GuildAutoApprovalList[nullable.Value].name);
      this.approvalPulldown.value = this.approval.text;
    }
    this.guildName.text = this.guildSetting.guild_name;
    this.guildNameInput.value = this.guildName.text;
    this.guildNameInput.onValidate = new UIInput.OnValidate(this.onValidateGuildName);
  }

  public void SetPulldownEventCallback()
  {
    if (this.conditionPulldown.onChange == null)
      this.conditionPulldown.onChange = new List<EventDelegate>();
    this.conditionPulldown.onChange.Add(new EventDelegate(new EventDelegate.Callback(this.onRequirementPulldownValueChanged)));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onChangeGuildName()
  {
    this.guildName.SetTextLocalize(this.guildNameInput.value);
    this.decideButton.isEnabled = !this.guildNameInput.value.isEmptyOrWhitespace();
  }

  public char onValidateGuildName(string text, int charIndex, char addedChar)
  {
    bool flag = char.IsControl(addedChar) || addedChar >= '\uE000' && addedChar <= '\uF8FF';
    Debug.Log((object) (((int) addedChar).ToString() + ":" + (object) flag));
    return flag ? char.MinValue : addedChar;
  }

  public void onDecideButton()
  {
    int approval_policy = -1;
    int atmosphere = -1;
    int auto_approval = -1;
    int? nullable = ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).FirstIndexOrNull<GuildApprovalPolicy>((Func<GuildApprovalPolicy, bool>) (x => x.name == this.condition.text));
    if (nullable.HasValue)
      approval_policy = MasterData.GuildApprovalPolicyList[nullable.Value].ID;
    nullable = ((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).FirstIndexOrNull<GuildAtmosphere>((Func<GuildAtmosphere, bool>) (x => x.name == this.atmosphere.text));
    if (nullable.HasValue)
      atmosphere = MasterData.GuildAtmosphereList[nullable.Value].ID;
    nullable = ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).FirstIndexOrNull<GuildAutoApproval>((Func<GuildAutoApproval, bool>) (x => x.name == this.approval.text));
    if (nullable.HasValue)
      auto_approval = MasterData.GuildAutoApprovalList[nullable.Value].ID;
    if (approval_policy < 0 || atmosphere < 0 || auto_approval < 0)
      return;
    GameObject prefab = this.guildMenu.GuildSettingConfirmPopup.Clone();
    Guild028OptionEditConfirmPopup component = prefab.GetComponent<Guild028OptionEditConfirmPopup>();
    prefab.SetActive(false);
    component.Initialize(this.guildMenu, approval_policy, atmosphere, auto_approval, this.guildName.text);
    prefab.SetActive(true);
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
  }

  public void onRequirementPulldownValueChanged()
  {
    if (this.prevRequirementPulldownValue != null && this.prevRequirementPulldownValue.Equals(this.conditionPulldown.value))
      return;
    this.prevRequirementPulldownValue = this.conditionPulldown.value;
    int? nullable1 = ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).FirstIndexOrNull<GuildApprovalPolicy>((Func<GuildApprovalPolicy, bool>) (x => x.name == this.conditionPulldown.value));
    if (!nullable1.HasValue || !MasterData.GuildApprovalPolicyList[nullable1.Value].default_manual)
      return;
    int? nullable2 = ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).FirstIndexOrNull<GuildAutoApproval>((Func<GuildAutoApproval, bool>) (x => !x.auto_approval));
    if (!nullable2.HasValue)
      return;
    this.approval.SetTextLocalize(MasterData.GuildAutoApprovalList[nullable2.Value].name);
    this.approvalPulldown.value = this.approval.text;
  }
}
