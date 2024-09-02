// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreCampaignProgressScore_achivement_rewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreCampaignProgressScore_achivement_rewards : KeyCompare
  {
    public QuestScoreAchivementReward[] rewards;
    public int quest_extra_m;

    public QuestScoreCampaignProgressScore_achivement_rewards()
    {
    }

    public QuestScoreCampaignProgressScore_achivement_rewards(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<QuestScoreAchivementReward> achivementRewardList = new List<QuestScoreAchivementReward>();
      foreach (object json1 in (List<object>) json[nameof (rewards)])
        achivementRewardList.Add(json1 != null ? new QuestScoreAchivementReward((Dictionary<string, object>) json1) : (QuestScoreAchivementReward) null);
      this.rewards = achivementRewardList.ToArray();
      this.quest_extra_m = (int) (long) json[nameof (quest_extra_m)];
    }
  }
}
