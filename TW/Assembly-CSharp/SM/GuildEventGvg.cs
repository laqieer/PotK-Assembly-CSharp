// Decompiled with JetBrains decompiler
// Type: SM.GuildEventGvg
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
  public class GuildEventGvg : KeyCompare
  {
    public DateTime? created_at;
    public string guild_id;
    public GuildRegistration guild;
    public int _event_type;
    public GuildRegistration opponent;

    public GuildEventGvg()
    {
    }

    public GuildEventGvg(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.created_at = json[nameof (created_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (created_at)])) : new DateTime?();
      this.guild_id = (string) json[nameof (guild_id)];
      this.guild = json[nameof (guild)] != null ? new GuildRegistration((Dictionary<string, object>) json[nameof (guild)]) : (GuildRegistration) null;
      this._event_type = (int) (long) json[nameof (event_type)];
      this.opponent = json[nameof (opponent)] != null ? new GuildRegistration((Dictionary<string, object>) json[nameof (opponent)]) : (GuildRegistration) null;
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
