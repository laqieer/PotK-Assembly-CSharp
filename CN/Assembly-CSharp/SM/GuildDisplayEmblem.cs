﻿// Decompiled with JetBrains decompiler
// Type: SM.GuildDisplayEmblem
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
  public class GuildDisplayEmblem : KeyCompare
  {
    public bool is_enabled;
    public DateTime? created_at;
    public int _unit;
    public bool in_use;

    public GuildDisplayEmblem()
    {
    }

    public GuildDisplayEmblem(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.is_enabled = (bool) json[nameof (is_enabled)];
      this.created_at = json[nameof (created_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (created_at)])) : new DateTime?();
      this._unit = (int) (long) json[nameof (unit)];
      this.in_use = (bool) json[nameof (in_use)];
    }

    public GuildEmblemUnit unit
    {
      get
      {
        if (MasterData.GuildEmblemUnit.ContainsKey(this._unit))
          return MasterData.GuildEmblemUnit[this._unit];
        Debug.LogError((object) ("Key not Found: MasterData.GuildEmblemUnit[" + (object) this._unit + "]"));
        return (GuildEmblemUnit) null;
      }
    }
  }
}
