﻿// Decompiled with JetBrains decompiler
// Type: SM.PlayerQuestScoreProgress
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
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
      foreach (object json1 in (List<object>) json[nameof (battle_score_max)])
        questScoreExtraSList.Add(json1 != null ? new PlayerQuestScoreExtraS((Dictionary<string, object>) json1) : (PlayerQuestScoreExtraS) null);
      this.battle_score_max = questScoreExtraSList.ToArray();
      List<QuestScoreRankingRewardReceived> rankingRewardReceivedList = new List<QuestScoreRankingRewardReceived>();
      foreach (object json2 in (List<object>) json[nameof (score_ranking_rewards)])
        rankingRewardReceivedList.Add(json2 != null ? new QuestScoreRankingRewardReceived((Dictionary<string, object>) json2) : (QuestScoreRankingRewardReceived) null);
      this.score_ranking_rewards = rankingRewardReceivedList.ToArray();
    }
  }
}
