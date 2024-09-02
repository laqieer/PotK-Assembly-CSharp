// Decompiled with JetBrains decompiler
// Type: SM.Gladiator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class Gladiator : KeyCompare
  {
    public string name;
    public int player_level;
    public int rank_pt;
    public int total_power;
    public int matching_type;
    public string player_id;
    public int current_emblem_id;
    public int leader_unit_id;
    public int leader_unit_level;

    public Gladiator()
    {
    }

    public Gladiator(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.name = (string) json[nameof (name)];
      this.player_level = (int) (long) json[nameof (player_level)];
      this.rank_pt = (int) (long) json[nameof (rank_pt)];
      this.total_power = (int) (long) json[nameof (total_power)];
      this.matching_type = (int) (long) json[nameof (matching_type)];
      this.player_id = (string) json[nameof (player_id)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.leader_unit_id = (int) (long) json[nameof (leader_unit_id)];
      this.leader_unit_level = (int) (long) json[nameof (leader_unit_level)];
    }
  }
}
