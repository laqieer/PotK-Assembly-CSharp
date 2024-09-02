// Decompiled with JetBrains decompiler
// Type: SM.GuildEvent
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
  public class GuildEvent : KeyCompare
  {
    public DateTime? created_at;
    public string guild_id;
    public int _event_type;

    public GuildEvent()
    {
    }

    public GuildEvent(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.created_at = json[nameof (created_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (created_at)])) : new DateTime?();
      this.guild_id = (string) json[nameof (guild_id)];
      this._event_type = (int) (long) json[nameof (event_type)];
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
