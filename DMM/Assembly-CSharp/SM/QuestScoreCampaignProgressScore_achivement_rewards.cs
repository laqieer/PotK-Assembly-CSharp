﻿// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreCampaignProgressScore_achivement_rewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
      foreach (object obj in (List<object>) json[nameof (rewards)])
        achivementRewardList.Add(obj == null ? (QuestScoreAchivementReward) null : new QuestScoreAchivementReward((Dictionary<string, object>) obj));
      this.rewards = achivementRewardList.ToArray();
      this.quest_extra_m = (int) (long) json[nameof (quest_extra_m)];
    }
  }
}
