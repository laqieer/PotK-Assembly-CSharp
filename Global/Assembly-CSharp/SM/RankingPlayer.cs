// Decompiled with JetBrains decompiler
// Type: SM.RankingPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class RankingPlayer : KeyCompare
  {
    public int ranking;
    public string name;
    public int max_rank_pt;
    public int rank_pt;
    public int lose;
    public string player_id;
    public int current_emblem_id;
    public int leader_unit_id;
    public int win;
    public int leader_unit_level;

    public RankingPlayer()
    {
    }

    public RankingPlayer(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.ranking = (int) (long) json[nameof (ranking)];
      this.name = (string) json[nameof (name)];
      this.max_rank_pt = (int) (long) json[nameof (max_rank_pt)];
      this.rank_pt = (int) (long) json[nameof (rank_pt)];
      this.lose = (int) (long) json[nameof (lose)];
      this.player_id = (string) json[nameof (player_id)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.leader_unit_id = (int) (long) json[nameof (leader_unit_id)];
      this.win = (int) (long) json[nameof (win)];
      this.leader_unit_level = (int) (long) json[nameof (leader_unit_level)];
    }
  }
}
