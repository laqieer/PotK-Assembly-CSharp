// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreBattleFinishContext
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreBattleFinishContext : KeyCompare
  {
    public DateTime start_at;
    public DateTime latest_end_at;
    public bool battle_score_max_updated;
    public QuestScoreAcquisition[] score_acquisitions;
    public int battle_score;
    public int rank;
    public DateTime end_at;
    public DateTime final_at;
    public bool is_open;
    public int battle_score_max;
    public bool score_max_updated;
    public QuestScoreBattleFinishContextScore_achivement_rewards[] score_achivement_rewards;
    public int rank_before;
    public int score_max;
    public int score_total;

    public QuestScoreBattleFinishContext()
    {
    }

    public QuestScoreBattleFinishContext(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.start_at = DateTime.Parse((string) json[nameof (start_at)]);
      this.latest_end_at = DateTime.Parse((string) json[nameof (latest_end_at)]);
      this.battle_score_max_updated = (bool) json[nameof (battle_score_max_updated)];
      List<QuestScoreAcquisition> scoreAcquisitionList = new List<QuestScoreAcquisition>();
      foreach (object json1 in (List<object>) json[nameof (score_acquisitions)])
        scoreAcquisitionList.Add(json1 != null ? new QuestScoreAcquisition((Dictionary<string, object>) json1) : (QuestScoreAcquisition) null);
      this.score_acquisitions = scoreAcquisitionList.ToArray();
      this.battle_score = (int) (long) json[nameof (battle_score)];
      this.rank = (int) (long) json[nameof (rank)];
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
      this.final_at = DateTime.Parse((string) json[nameof (final_at)]);
      this.is_open = (bool) json[nameof (is_open)];
      this.battle_score_max = (int) (long) json[nameof (battle_score_max)];
      this.score_max_updated = (bool) json[nameof (score_max_updated)];
      List<QuestScoreBattleFinishContextScore_achivement_rewards> achivementRewardsList = new List<QuestScoreBattleFinishContextScore_achivement_rewards>();
      foreach (object json2 in (List<object>) json[nameof (score_achivement_rewards)])
        achivementRewardsList.Add(json2 != null ? new QuestScoreBattleFinishContextScore_achivement_rewards((Dictionary<string, object>) json2) : (QuestScoreBattleFinishContextScore_achivement_rewards) null);
      this.score_achivement_rewards = achivementRewardsList.ToArray();
      this.rank_before = (int) (long) json[nameof (rank_before)];
      this.score_max = (int) (long) json[nameof (score_max)];
      this.score_total = (int) (long) json[nameof (score_total)];
    }
  }
}
