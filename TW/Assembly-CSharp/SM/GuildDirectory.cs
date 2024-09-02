// Decompiled with JetBrains decompiler
// Type: SM.GuildDirectory
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
  public class GuildDirectory : KeyCompare
  {
    public int _atmosphere;
    public DateTime? entried_at;
    public int _auto_approval;
    public bool in_gvg;
    public GuildAppearance appearance;
    public string guild_name;
    public int _approval_policy;
    public string guild_id;

    public GuildDirectory()
    {
    }

    public GuildDirectory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._atmosphere = (int) (long) json[nameof (atmosphere)];
      this.entried_at = json[nameof (entried_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (entried_at)])) : new DateTime?();
      this._auto_approval = (int) (long) json[nameof (auto_approval)];
      this.in_gvg = (bool) json[nameof (in_gvg)];
      this.appearance = json[nameof (appearance)] != null ? new GuildAppearance((Dictionary<string, object>) json[nameof (appearance)]) : (GuildAppearance) null;
      this.guild_name = (string) json[nameof (guild_name)];
      this._approval_policy = (int) (long) json[nameof (approval_policy)];
      this.guild_id = (string) json[nameof (guild_id)];
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
