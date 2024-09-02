// Decompiled with JetBrains decompiler
// Type: SM.MembershipSchema
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
  public class MembershipSchema : KeyCompare
  {
    public PlayershipSchema player;
    public int contribution;
    public int _role;
    public DateTime joined_at;

    public MembershipSchema()
    {
    }

    public MembershipSchema(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player = json[nameof (player)] != null ? new PlayershipSchema((Dictionary<string, object>) json[nameof (player)]) : (PlayershipSchema) null;
      this.contribution = (int) (long) json[nameof (contribution)];
      this._role = (int) (long) json[nameof (role)];
      this.joined_at = DateTime.Parse((string) json[nameof (joined_at)]);
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
