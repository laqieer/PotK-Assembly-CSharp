// Decompiled with JetBrains decompiler
// Type: GuildStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
[Serializable]
public class GuildStatus
{
  [SerializeField]
  private UI2DSprite guildTitleImage;
  private Future<Sprite> futureGuildTitleImage;
  public UISprite start_1;
  public UISprite start_10;
  public UILabel guildRank;
  public UILabel guildCurrentMember;
  public UILabel guildMaxMember;
  public UILabel guildName;
  public NGTweenGaugeScale starGauge;
  public NGTweenGaugeFillAmount starGaugeFillAmount;

  [DebuggerHidden]
  public IEnumerator ResourceLoad(GuildRegistration data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildStatus.\u003CResourceLoad\u003Ec__Iterator76E()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public void SetStatus(GuildRegistration data)
  {
    if (Object.op_Inequality((Object) this.guildTitleImage, (Object) null))
      this.guildTitleImage.sprite2D = this.futureGuildTitleImage.Result;
    if (Object.op_Inequality((Object) this.guildRank, (Object) null))
      this.guildRank.SetTextLocalize(data.appearance.level.ToString());
    if (Object.op_Inequality((Object) this.guildCurrentMember, (Object) null))
      this.guildCurrentMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_CURRENT_MEMBER, (IDictionary) new Hashtable()
      {
        {
          (object) "currentMember",
          (object) data.appearance.membership_num
        }
      }));
    if (Object.op_Inequality((Object) this.guildMaxMember, (Object) null))
      this.guildMaxMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_MAX_MEMBER, (IDictionary) new Hashtable()
      {
        {
          (object) "maxMember",
          (object) data.appearance.membership_capacity
        }
      }));
    if (Object.op_Inequality((Object) this.guildName, (Object) null))
      this.guildName.SetTextLocalize(data.guild_name);
    int caputureStar = 0;
    ((IEnumerable<GuildMembership>) data.memberships).ForEach<GuildMembership>((Action<GuildMembership>) (x => caputureStar += x.capture_star));
    int maxStar = 0;
    int keepStar = 0;
    ((IEnumerable<GuildMembership>) data.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.is_defense_membership)).ForEach<GuildMembership>((Action<GuildMembership>) (x => maxStar += 3));
    ((IEnumerable<GuildMembership>) data.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.is_defense_membership)).ForEach<GuildMembership>((Action<GuildMembership>) (x => keepStar += x.own_star));
    if (Object.op_Inequality((Object) this.starGauge, (Object) null))
      this.starGauge.setValue(keepStar, maxStar);
    if (Object.op_Inequality((Object) this.starGaugeFillAmount, (Object) null))
      this.starGaugeFillAmount.setValue(keepStar, maxStar, true);
    if (Object.op_Inequality((Object) this.start_1, (Object) null))
      this.start_1.SetSprite(string.Format("slc_SetupTime{0}.png__GUI__battleUI__battleUI_prefab", (object) (caputureStar % 10)));
    if (!Object.op_Inequality((Object) this.start_10, (Object) null))
      return;
    this.start_10.SetSprite(string.Format("slc_SetupTime{0}.png__GUI__battleUI__battleUI_prefab", (object) (caputureStar / 10)));
  }

  public void UpdateStatus(GuildRegistration data)
  {
    if (data == null)
      return;
    if (Object.op_Inequality((Object) this.guildTitleImage, (Object) null) && (Object.op_Equality((Object) this.guildTitleImage.sprite2D, (Object) null) || ((Object) this.guildTitleImage.sprite2D).name != ((Object) this.futureGuildTitleImage.Result).name))
      this.guildTitleImage.sprite2D = this.futureGuildTitleImage.Result;
    if (Object.op_Inequality((Object) this.guildRank, (Object) null))
      this.guildRank.SetTextLocalize(data.appearance.level.ToString());
    if (Object.op_Inequality((Object) this.guildCurrentMember, (Object) null))
      this.guildCurrentMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_CURRENT_MEMBER, (IDictionary) new Hashtable()
      {
        {
          (object) "currentMember",
          (object) data.appearance.membership_num
        }
      }));
    if (Object.op_Inequality((Object) this.guildMaxMember, (Object) null))
      this.guildMaxMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_MAX_MEMBER, (IDictionary) new Hashtable()
      {
        {
          (object) "maxMember",
          (object) data.appearance.membership_capacity
        }
      }));
    if (Object.op_Inequality((Object) this.guildName, (Object) null))
      this.guildName.SetTextLocalize(data.guild_name);
    int caputureStar = 0;
    ((IEnumerable<GuildMembership>) data.memberships).ForEach<GuildMembership>((Action<GuildMembership>) (x => caputureStar += x.capture_star));
    int maxStar = 0;
    int keepStar = 0;
    ((IEnumerable<GuildMembership>) data.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.is_defense_membership)).ForEach<GuildMembership>((Action<GuildMembership>) (x => maxStar += 3));
    ((IEnumerable<GuildMembership>) data.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.is_defense_membership)).ForEach<GuildMembership>((Action<GuildMembership>) (x => keepStar += x.own_star));
    if (Object.op_Inequality((Object) this.starGauge, (Object) null))
      this.starGauge.setValue(keepStar, maxStar, duration: 1f);
    if (Object.op_Inequality((Object) this.starGaugeFillAmount, (Object) null))
      this.starGaugeFillAmount.setValue(keepStar, maxStar, true, duration: 1f);
    if (Object.op_Inequality((Object) this.start_1, (Object) null))
      this.start_1.SetSprite(string.Format("slc_SetupTime{0}.png__GUI__battleUI__battleUI_prefab", (object) (caputureStar % 10)));
    if (!Object.op_Inequality((Object) this.start_10, (Object) null))
      return;
    this.start_10.SetSprite(string.Format("slc_SetupTime{0}.png__GUI__battleUI__battleUI_prefab", (object) (caputureStar / 10)));
  }
}
