// Decompiled with JetBrains decompiler
// Type: SM.DeliveryBroadcastSignalStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class DeliveryBroadcastSignalStatus : KeyCompare
  {
    public string[] errors;
    public int? _last_guild_event;
    public float percent;
    public DateTime last_completed_at;
    public bool running;
    public DateTime last_sent_at;

    public DeliveryBroadcastSignalStatus()
    {
    }

    public DeliveryBroadcastSignalStatus(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.errors = ((IEnumerable<object>) json[nameof (errors)]).Select<object, string>((Func<object, string>) (s => (string) s)).ToArray<string>();
      this._last_guild_event = json[nameof (last_guild_event)] != null ? new int?((int) (long) json[nameof (last_guild_event)]) : new int?();
      this.percent = (float) (double) json[nameof (percent)];
      this.last_completed_at = DateTime.Parse((string) json[nameof (last_completed_at)]);
      this.running = (bool) json[nameof (running)];
      this.last_sent_at = DateTime.Parse((string) json[nameof (last_sent_at)]);
    }

    public GuildEventType? last_guild_event
    {
      get
      {
        if (!this._last_guild_event.HasValue)
          return new GuildEventType?();
        if (!Enum.IsDefined(typeof (GuildEventType), (object) this._last_guild_event))
          Debug.LogError((object) ("Key not Found: MasterDataTable.GuildEventType[" + (object) this._last_guild_event + "]"));
        return new GuildEventType?((GuildEventType) this._last_guild_event.Value);
      }
    }
  }
}
