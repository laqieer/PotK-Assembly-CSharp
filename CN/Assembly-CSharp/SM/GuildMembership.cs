// Decompiled with JetBrains decompiler
// Type: SM.GuildMembership
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    public GuildPlayerInfo player;
    public int contribution;
    public int _role;
    public DateTime joined_at;
    public int _role_name;

    public GuildMembership()
    {
    }

    public GuildMembership(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player = json[nameof (player)] != null ? new GuildPlayerInfo((Dictionary<string, object>) json[nameof (player)]) : (GuildPlayerInfo) null;
      this.contribution = (int) (long) json[nameof (contribution)];
      this._role = (int) (long) json[nameof (role)];
      this.joined_at = DateTime.Parse((string) json[nameof (joined_at)]);
      this._role_name = (int) (long) json[nameof (role_name)];
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
  }
}
