// Decompiled with JetBrains decompiler
// Type: SM.GuildHq
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
  public class GuildHq : KeyCompare
  {
    public int guild_level_cap;
    public bool is_enabled;
    public int next_price;
    public string base_name;
    public int max_rank;
    public int rank;
    public int[] _bonuses;
    public int _base_type;

    public GuildHq()
    {
    }

    public GuildHq(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.guild_level_cap = (int) (long) json[nameof (guild_level_cap)];
      this.is_enabled = (bool) json[nameof (is_enabled)];
      this.next_price = (int) (long) json[nameof (next_price)];
      this.base_name = (string) json[nameof (base_name)];
      this.max_rank = (int) (long) json[nameof (max_rank)];
      this.rank = (int) (long) json[nameof (rank)];
      this._bonuses = ((IEnumerable<object>) json[nameof (bonuses)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this._base_type = (int) (long) json[nameof (base_type)];
    }

    public GuildBaseBonus[] bonuses
    {
      get
      {
        return ((IEnumerable<int>) this._bonuses).Select<int, GuildBaseBonus>((Func<int, GuildBaseBonus>) (x => MasterData.GuildBaseBonus[x])).ToArray<GuildBaseBonus>();
      }
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
  }
}
