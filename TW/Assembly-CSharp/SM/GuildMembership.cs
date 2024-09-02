// Decompiled with JetBrains decompiler
// Type: SM.GuildMembership
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
  public class GuildMembership : KeyCompare
  {
    public int action_point;
    public int total_defense;
    public int total_attack;
    public GuildPlayerInfo player;
    public int own_star;
    public DateTime joined_at;
    public bool is_defense_membership;
    public int _role_name;
    public int _role;
    public int capture_star;
    public bool scouted;
    public bool in_battle;
    public int contribution;
    public bool in_attack;

    public GuildMembership()
    {
    }

    public GuildMembership(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.action_point = (int) (long) json[nameof (action_point)];
      this.total_defense = (int) (long) json[nameof (total_defense)];
      this.total_attack = (int) (long) json[nameof (total_attack)];
      this.player = json[nameof (player)] != null ? new GuildPlayerInfo((Dictionary<string, object>) json[nameof (player)]) : (GuildPlayerInfo) null;
      this.own_star = (int) (long) json[nameof (own_star)];
      this.joined_at = DateTime.Parse((string) json[nameof (joined_at)]);
      this.is_defense_membership = (bool) json[nameof (is_defense_membership)];
      this._role_name = (int) (long) json[nameof (role_name)];
      this._role = (int) (long) json[nameof (role)];
      this.capture_star = (int) (long) json[nameof (capture_star)];
      this.scouted = (bool) json[nameof (scouted)];
      this.in_battle = (bool) json[nameof (in_battle)];
      this.contribution = (int) (long) json[nameof (contribution)];
      this.in_attack = (bool) json[nameof (in_attack)];
    }

    public GuildRoleName role_name
    {
      get
      {
        if (MasterData.GuildRoleName.ContainsKey(this._role_name))
          return MasterData.GuildRoleName[this._role_name];
        Debug.LogError((object) ("Key not Found: MasterData.GuildRoleName[" + (object) this._role_name + "]"));
        return (GuildRoleName) null;
      }
    }

    public GuildRole role
    {
      get
      {
        if (!Enum.IsDefined(typeof (GuildRole), (object) this._role))
          Debug.LogError((object) ("Key not Found: MasterDataTable.GuildRole[" + (object) this._role + "]"));
        return (GuildRole) this._role;
      }
    }
  }
}
