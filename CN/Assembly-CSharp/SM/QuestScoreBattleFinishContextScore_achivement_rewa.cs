// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreBattleFinishContextScore_achivement_rewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreBattleFinishContextScore_achivement_rewards : KeyCompare
  {
    public QuestScoreAchivementRewardReceived[] rewards;
    public int score;

    public QuestScoreBattleFinishContextScore_achivement_rewards()
    {
    }

    public QuestScoreBattleFinishContextScore_achivement_rewards(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<QuestScoreAchivementRewardReceived> achivementRewardReceivedList = new List<QuestScoreAchivementRewardReceived>();
      foreach (object json1 in (List<object>) json[nameof (rewards)])
        achivementRewardReceivedList.Add(json1 != null ? new QuestScoreAchivementRewardReceived((Dictionary<string, object>) json1) : (QuestScoreAchivementRewardReceived) null);
      this.rewards = achivementRewardReceivedList.ToArray();
      this.score = (int) (long) json[nameof (score)];
    }
  }
}
