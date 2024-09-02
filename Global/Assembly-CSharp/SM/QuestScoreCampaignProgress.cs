// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreCampaignProgress
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreCampaignProgress : KeyCompare
  {
    public DateTime start_at;
    public QuestScoreCampaignDescriptionBlock description;
    public DateTime latest_end_at;
    public bool score_ranking_disabled;
    public DateTime end_at;
    public DateTime final_at;
    public PlayerQuestScoreProgress player;
    public int quest_extra_l;
    public bool is_open;
    public QuestScoreCampaignProgressScore_achivement_rewards[] score_achivement_rewards;
    public QuestScoreRankingReward[] score_ranking_rewards;
    public int id;

    public QuestScoreCampaignProgress()
    {
    }

    public QuestScoreCampaignProgress(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.start_at = DateTime.Parse((string) json[nameof (start_at)]);
      this.description = json[nameof (description)] != null ? new QuestScoreCampaignDescriptionBlock((Dictionary<string, object>) json[nameof (description)]) : (QuestScoreCampaignDescriptionBlock) null;
      this.latest_end_at = DateTime.Parse((string) json[nameof (latest_end_at)]);
      this.score_ranking_disabled = (bool) json[nameof (score_ranking_disabled)];
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
      this.final_at = DateTime.Parse((string) json[nameof (final_at)]);
      this.player = json[nameof (player)] != null ? new PlayerQuestScoreProgress((Dictionary<string, object>) json[nameof (player)]) : (PlayerQuestScoreProgress) null;
      this.quest_extra_l = (int) (long) json[nameof (quest_extra_l)];
      this.is_open = (bool) json[nameof (is_open)];
      List<QuestScoreCampaignProgressScore_achivement_rewards> achivementRewardsList = new List<QuestScoreCampaignProgressScore_achivement_rewards>();
      foreach (object json1 in (List<object>) json[nameof (score_achivement_rewards)])
        achivementRewardsList.Add(json1 != null ? new QuestScoreCampaignProgressScore_achivement_rewards((Dictionary<string, object>) json1) : (QuestScoreCampaignProgressScore_achivement_rewards) null);
      this.score_achivement_rewards = achivementRewardsList.ToArray();
      List<QuestScoreRankingReward> scoreRankingRewardList = new List<QuestScoreRankingReward>();
      foreach (object json2 in (List<object>) json[nameof (score_ranking_rewards)])
        scoreRankingRewardList.Add(json2 != null ? new QuestScoreRankingReward((Dictionary<string, object>) json2) : (QuestScoreRankingReward) null);
      this.score_ranking_rewards = scoreRankingRewardList.ToArray();
      this.id = (int) (long) json[nameof (id)];
    }

    public int GetQuestSScore(int sid)
    {
      int questSscore = 0;
      if (this.player.battle_score_max == null || this.player.battle_score_max.Length == 0)
        return 0;
      PlayerQuestScoreExtraS questScoreExtraS = ((IEnumerable<PlayerQuestScoreExtraS>) this.player.battle_score_max).FirstOrDefault<PlayerQuestScoreExtraS>((Func<PlayerQuestScoreExtraS, bool>) (x => x.quest_extra_s == sid));
      if (questScoreExtraS != null)
        questSscore = questScoreExtraS.score_max;
      return questSscore;
    }

    public int GetQuestMScoreFromSID(int sid)
    {
      int score = 0;
      PlayerExtraQuestS[] source = SMManager.Get<PlayerExtraQuestS[]>();
      if (source == null || this.player.battle_score_max.Length == 0)
        return 0;
      PlayerExtraQuestS playerExtraQuestS = ((IEnumerable<PlayerExtraQuestS>) source).FirstOrDefault<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x => x._quest_extra_s == sid));
      if (playerExtraQuestS != null)
      {
        int questM = playerExtraQuestS.quest_extra_s.quest_m_QuestExtraM;
        MasterData.QuestExtraS.Where<KeyValuePair<int, QuestExtraS>>((Func<KeyValuePair<int, QuestExtraS>, bool>) (x => x.Value.quest_m_QuestExtraM == questM)).ForEach<KeyValuePair<int, QuestExtraS>>((Action<KeyValuePair<int, QuestExtraS>>) (x => score += this.GetQuestSScore(x.Value.ID)));
      }
      return score;
    }

    public int GetQuestMScoreFromMID(int mid)
    {
      int score = 0;
      MasterData.QuestExtraS.Where<KeyValuePair<int, QuestExtraS>>((Func<KeyValuePair<int, QuestExtraS>, bool>) (x => x.Value.quest_m_QuestExtraM == mid)).ForEach<KeyValuePair<int, QuestExtraS>>((Action<KeyValuePair<int, QuestExtraS>>) (x => score += this.GetQuestSScore(x.Value.ID)));
      return score;
    }
  }
}
