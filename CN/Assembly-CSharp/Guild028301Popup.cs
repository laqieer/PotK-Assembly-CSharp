// Decompiled with JetBrains decompiler
// Type: Guild028301Popup
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
public class Guild028301Popup : BackButtonMenuBase
{
  private Guild02811Menu menu;
  [SerializeField]
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
  private SpreadColorButton OKButton;

  public void Initialize(Guild02811Menu guild02811menu)
  {
    this.menu = guild02811menu;
    ((Component) this.guildName).GetComponent<UIInput>().onValidate = new UIInput.OnValidate(this.onValidate);
    this.OKButton.isEnabled = false;
    this.atmosphereList.items.Clear();
    this.approvalList.items.Clear();
    this.autoApprovalList.items.Clear();
    this.atmosphereList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.approvalList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.autoApprovalList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1002"))));
    this.approvalList.onChange.Add(new EventDelegate((EventDelegate.Callback) (() =>
    {
      int? nullable1 = ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).FirstIndexOrNull<GuildApprovalPolicy>((Func<GuildApprovalPolicy, bool>) (x => x.name == this.approval.text));
      if (!nullable1.HasValue || !MasterData.GuildApprovalPolicyList[nullable1.Value].default_manual)
        return;
      int? nullable2 = ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).FirstIndexOrNull<GuildAutoApproval>((Func<GuildAutoApproval, bool>) (x => !x.auto_approval));
      if (!nullable2.HasValue)
        return;
      this.autoApprovalList.value = MasterData.GuildAutoApprovalList[nullable2.Value].name;
      this.autoApproval.SetTextLocalize(MasterData.GuildAutoApprovalList[nullable2.Value].name);
    })));
    ((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).ForEach<GuildAtmosphere>((Action<GuildAtmosphere>) (x => this.atmosphereList.items.Add(x.name)));
    ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).ForEach<GuildApprovalPolicy>((Action<GuildApprovalPolicy>) (x => this.approvalList.items.Add(x.name)));
    ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).ForEach<GuildAutoApproval>((Action<GuildAutoApproval>) (x => this.autoApprovalList.items.Add(x.name)));
    this.guildName.SetTextLocalize(string.Empty);
    this.atmosphere.SetTextLocalize(((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).First<GuildAtmosphere>().name);
    this.atmosphereList.value = ((IEnumerable<GuildAtmosphere>) MasterData.GuildAtmosphereList).First<GuildAtmosphere>().name;
    this.approval.SetTextLocalize(((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).First<GuildApprovalPolicy>().name);
    this.approvalList.value = ((IEnumerable<GuildApprovalPolicy>) MasterData.GuildApprovalPolicyList).First<GuildApprovalPolicy>().name;
    this.autoApproval.SetTextLocalize(((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).First<GuildAutoApproval>().name);
    this.autoApprovalList.value = ((IEnumerable<GuildAutoApproval>) MasterData.GuildAutoApprovalList).First<GuildAutoApproval>().name;
  }

  [DebuggerHidden]
  public IEnumerator Initialize(Guild02811Menu guild02811menu, GuildSetting setting)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028301Popup.\u003CInitialize\u003Ec__Iterator6A0()
    {
      guild02811menu = guild02811menu,
      setting = setting,
      \u003C\u0024\u003Eguild02811menu = guild02811menu,
      \u003C\u0024\u003Esetting = setting,
      \u003C\u003Ef__this = this
    };
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
    this.guildName.SetTextLocalize(((Component) this.guildName).GetComponent<UIInput>().value);
    this.OKButton.isEnabled = !this.guildName.text.isEmptyOrWhitespace();
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onButtonDecision()
  {
    Singleton<PopupManager>.GetInstance().open(this.menu.BuildSettingCheckPopup).GetComponent<Guild028401Popup>().Initialize(this.menu, new GuildSetting()
    {
      guildName = this.guildName.text,
      atmosphere = this.atmosphere.text,
      approval = this.approval.text,
      autoApproval = this.autoApproval.text
    });
  }
}
