// Decompiled with JetBrains decompiler
// Type: SM.PlayerQuestScoreProgress
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

namespace SM
{
  [Serializable]
  public class PlayerQuestScoreProgress : KeyCompare
  {
    public int[] score_achivement_reward_cleared;
    public int score_total;
    public int rank;
    public PlayerQuestScoreExtraS[] battle_score_max;
    public QuestScoreRankingRewardReceived[] score_ranking_rewards;

    public PlayerQuestScoreProgress()
    {
    }

    public PlayerQuestScoreProgress(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.score_achivement_reward_cleared = ((IEnumerable<object>) json[nameof (score_achivement_reward_cleared)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.score_total = (int) (long) json[nameof (score_total)];
      this.rank = (int) (long) json[nameof (rank)];
      List<PlayerQuestScoreExtraS> questScoreExtraSList = new List<PlayerQuestScoreExtraS>();
      foreach (object obj in (List<object>) json[nameof (battle_score_max)])
        questScoreExtraSList.Add(obj == null ? (PlayerQuestScoreExtraS) null : new PlayerQuestScoreExtraS((Dictionary<string, object>) obj));
      this.battle_score_max = questScoreExtraSList.ToArray();
      List<QuestScoreRankingRewardReceived> rankingRewardReceivedList = new List<QuestScoreRankingRewardReceived>();
      foreach (object obj in (List<object>) json[nameof (score_ranking_rewards)])
        rankingRewardReceivedList.Add(obj == null ? (QuestScoreRankingRewardReceived) null : new QuestScoreRankingRewardReceived((Dictionary<string, object>) obj));
      this.score_ranking_rewards = rankingRewardReceivedList.ToArray();
    }
  }
}
