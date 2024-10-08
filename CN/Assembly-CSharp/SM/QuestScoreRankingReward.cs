﻿// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreRankingReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreRankingReward : KeyCompare
  {
    public int reward_quantity;
    public int reward_type_id;
    public int ranking_group_id;
    public int rank_upper;
    public int rank_lower;
    public int id;
    public int reward_id;

    public QuestScoreRankingReward()
    {
    }

    public QuestScoreRankingReward(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      this.ranking_group_id = (int) (long) json[nameof (ranking_group_id)];
      this.rank_upper = (int) (long) json[nameof (rank_upper)];
      this.rank_lower = (int) (long) json[nameof (rank_lower)];
      this.id = (int) (long) json[nameof (id)];
      this.reward_id = (int) (long) json[nameof (reward_id)];
    }
  }
}
