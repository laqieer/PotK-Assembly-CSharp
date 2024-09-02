// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreRankingPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreRankingPlayer : KeyCompare
  {
    public string name;
    public int rank;
    public int score;
    public string player_id;
    public int current_emblem_id;
    public int leader_unit_id;
    public int leader_unit_level;

    public QuestScoreRankingPlayer()
    {
    }

    public QuestScoreRankingPlayer(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.name = (string) json[nameof (name)];
      this.rank = (int) (long) json[nameof (rank)];
      this.score = (int) (long) json[nameof (score)];
      this.player_id = (string) json[nameof (player_id)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.leader_unit_id = (int) (long) json[nameof (leader_unit_id)];
      this.leader_unit_level = (int) (long) json[nameof (leader_unit_level)];
    }
  }
}
