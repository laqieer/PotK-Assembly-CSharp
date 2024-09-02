// Decompiled with JetBrains decompiler
// Type: SM.GuildInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class GuildInfo : KeyCompare
  {
    public int _atmosphere;
    public int _auto_approval;
    public int money;
    public GuildHq[] hqs;
    public GuildAppearance appearance;
    public string guild_name;
    public GuildMembership[] memberships;
    public GuildLevelBonus level_bonus;
    public int _approval_policy;
    public string private_message;
    public string guild_id;
    public GuildApplicant[] applicants;

    public GuildInfo()
    {
    }

    public GuildInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._atmosphere = (int) (long) json[nameof (atmosphere)];
      this._auto_approval = (int) (long) json[nameof (auto_approval)];
      this.money = (int) (long) json[nameof (money)];
      List<GuildHq> guildHqList = new List<GuildHq>();
      foreach (object json1 in (List<object>) json[nameof (hqs)])
        guildHqList.Add(json1 != null ? new GuildHq((Dictionary<string, object>) json1) : (GuildHq) null);
      this.hqs = guildHqList.ToArray();
      this.appearance = json[nameof (appearance)] != null ? new GuildAppearance((Dictionary<string, object>) json[nameof (appearance)]) : (GuildAppearance) null;
      this.guild_name = (string) json[nameof (guild_name)];
      List<GuildMembership> guildMembershipList = new List<GuildMembership>();
      foreach (object json2 in (List<object>) json[nameof (memberships)])
        guildMembershipList.Add(json2 != null ? new GuildMembership((Dictionary<string, object>) json2) : (GuildMembership) null);
      this.memberships = guildMembershipList.ToArray();
      this.level_bonus = json[nameof (level_bonus)] != null ? new GuildLevelBonus((Dictionary<string, object>) json[nameof (level_bonus)]) : (GuildLevelBonus) null;
      this._approval_policy = (int) (long) json[nameof (approval_policy)];
      this.private_message = (string) json[nameof (private_message)];
      this.guild_id = (string) json[nameof (guild_id)];
      List<GuildApplicant> guildApplicantList = new List<GuildApplicant>();
      foreach (object json3 in (List<object>) json[nameof (applicants)])
        guildApplicantList.Add(json3 != null ? new GuildApplicant((Dictionary<string, object>) json3) : (GuildApplicant) null);
      this.applicants = guildApplicantList.ToArray();
    }

    public GuildAtmosphere atmosphere
    {
      get
      {
        if (MasterData.GuildAtmosphere.ContainsKey(this._atmosphere))
          return MasterData.GuildAtmosphere[this._atmosphere];
        Debug.LogError((object) ("Key not Found: MasterData.GuildAtmosphere[" + (object) this._atmosphere + "]"));
        return (GuildAtmosphere) null;
      }
    }

    public GuildAutoApproval auto_approval
    {
      get
      {
        if (MasterData.GuildAutoApproval.ContainsKey(this._auto_approval))
          return MasterData.GuildAutoApproval[this._auto_approval];
        Debug.LogError((object) ("Key not Found: MasterData.GuildAutoApproval[" + (object) this._auto_approval + "]"));
        return (GuildAutoApproval) null;
      }
    }

    public GuildApprovalPolicy approval_policy
    {
      get
      {
        if (MasterData.GuildApprovalPolicy.ContainsKey(this._approval_policy))
          return MasterData.GuildApprovalPolicy[this._approval_policy];
        Debug.LogError((object) ("Key not Found: MasterData.GuildApprovalPolicy[" + (object) this._approval_policy + "]"));
        return (GuildApprovalPolicy) null;
      }
    }
  }
}
