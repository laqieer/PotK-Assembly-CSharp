// Decompiled with JetBrains decompiler
// Type: SM.PvPRankingPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PvPRankingPlayer : KeyCompare
  {
    public int ranking;
    public int total_win;
    public string name;
    public int current_class_id;
    public string player_id;
    public int current_emblem_id;
    public int leader_unit_id;
    public int ranking_pt;
    public int leader_unit_level;

    public PvPRankingPlayer()
    {
    }

    public PvPRankingPlayer(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.ranking = (int) (long) json[nameof (ranking)];
      this.total_win = (int) (long) json[nameof (total_win)];
      this.name = (string) json[nameof (name)];
      this.current_class_id = (int) (long) json[nameof (current_class_id)];
      this.player_id = (string) json[nameof (player_id)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.leader_unit_id = (int) (long) json[nameof (leader_unit_id)];
      this.ranking_pt = (int) (long) json[nameof (ranking_pt)];
      this.leader_unit_level = (int) (long) json[nameof (leader_unit_level)];
    }
  }
}
