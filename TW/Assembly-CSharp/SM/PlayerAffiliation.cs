// Decompiled with JetBrains decompiler
// Type: SM.PlayerAffiliation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerAffiliation : KeyCompare
  {
    public int _status;
    public DateTime? applied_at;
    public GuildRegistration guild;
    public DateTime? joined_at;
    public int? _role_name;
    public int? _role;
    public int[] stamp_groups;
    public string guild_id;
    public DateTime? leaved_at;

    public PlayerAffiliation()
    {
    }

    public PlayerAffiliation(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._status = (int) (long) json[nameof (status)];
      this.applied_at = json[nameof (applied_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (applied_at)])) : new DateTime?();
      this.guild = json[nameof (guild)] != null ? new GuildRegistration((Dictionary<string, object>) json[nameof (guild)]) : (GuildRegistration) null;
      this.joined_at = json[nameof (joined_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (joined_at)])) : new DateTime?();
      this._role_name = json[nameof (role_name)] != null ? new int?((int) (long) json[nameof (role_name)]) : new int?();
      this._role = json[nameof (role)] != null ? new int?((int) (long) json[nameof (role)]) : new int?();
      this.stamp_groups = ((IEnumerable<object>) json[nameof (stamp_groups)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.guild_id = json[nameof (guild_id)] != null ? (string) json[nameof (guild_id)] : (string) null;
      this.leaved_at = json[nameof (leaved_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (leaved_at)])) : new DateTime?();
    }

    public bool onGvgOperation
    {
      get
      {
        return this.guild.gvg_status == GvgStatus.matching || this.guild.gvg_status == GvgStatus.preparing || this.guild.gvg_status == GvgStatus.fighting || this.guild.gvg_status == GvgStatus.aggregating || this.guild.gvg_status == GvgStatus.finished;
      }
    }

    public PlayerAffiliation Clone() => (PlayerAffiliation) this.MemberwiseClone();

    public static PlayerAffiliation Current => SMManager.Get<PlayerAffiliation>();

    public GuildPlayerInfo Player
    {
      get
      {
        return ((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).Single<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == SM.Player.Current.id)).player;
      }
    }

    public bool isGuildMember()
    {
      return this.status != GuildMembershipStatus.not_exist && this.status != GuildMembershipStatus.applicant && this.status != GuildMembershipStatus.withdraw;
    }

    public GuildMembershipStatus status
    {
      get
      {
        if (!Enum.IsDefined(typeof (GuildMembershipStatus), (object) this._status))
          Debug.LogError((object) ("Key not Found: MasterDataTable.GuildMembershipStatus[" + (object) this._status + "]"));
        return (GuildMembershipStatus) this._status;
      }
    }

    public GuildRoleName role_name
    {
      get
      {
        if (!this._role_name.HasValue)
          return (GuildRoleName) null;
        if (MasterData.GuildRoleName.ContainsKey(this._role_name.Value))
          return MasterData.GuildRoleName[this._role_name.Value];
        Debug.LogError((object) ("Key not Found: MasterData.GuildRoleName[" + (object) this._role_name + "]"));
        return (GuildRoleName) null;
      }
    }

    public GuildRole? role
    {
      get
      {
        if (!this._role.HasValue)
          return new GuildRole?();
        if (!Enum.IsDefined(typeof (GuildRole), (object) this._role))
          Debug.LogError((object) ("Key not Found: MasterDataTable.GuildRole[" + (object) this._role + "]"));
        return new GuildRole?((GuildRole) this._role.Value);
      }
    }
  }
}
