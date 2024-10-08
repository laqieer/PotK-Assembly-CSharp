﻿// Decompiled with JetBrains decompiler
// Type: SM.GuildEventBase
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
  public class GuildEventBase : KeyCompare
  {
    public string guild_id;
    public DateTime? created_at;
    public int _base_type;
    public int _event_type;
    public int rank;

    public GuildEventBase()
    {
    }

    public GuildEventBase(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.guild_id = (string) json[nameof (guild_id)];
      this.created_at = json[nameof (created_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (created_at)])) : new DateTime?();
      this._base_type = (int) (long) json[nameof (base_type)];
      this._event_type = (int) (long) json[nameof (event_type)];
      this.rank = (int) (long) json[nameof (rank)];
    }

    public GuildBaseType base_type
    {
      get
      {
        if (!Enum.IsDefined(typeof (GuildBaseType), (object) this._base_type))
          Debug.LogError((object) ("Key not Found: MasterDataTable.GuildBaseType[" + (object) this._base_type + "]"));
        return (GuildBaseType) this._base_type;
      }
    }

    public GuildEventType event_type
    {
      get
      {
        if (!Enum.IsDefined(typeof (GuildEventType), (object) this._event_type))
          Debug.LogError((object) ("Key not Found: MasterDataTable.GuildEventType[" + (object) this._event_type + "]"));
        return (GuildEventType) this._event_type;
      }
    }
  }
}
