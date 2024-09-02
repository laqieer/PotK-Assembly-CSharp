// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreBattleFinishContextScore_achivement_rewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
      foreach (object obj in (List<object>) json[nameof (rewards)])
        achivementRewardReceivedList.Add(obj == null ? (QuestScoreAchivementRewardReceived) null : new QuestScoreAchivementRewardReceived((Dictionary<string, object>) obj));
      this.rewards = achivementRewardReceivedList.ToArray();
      this.score = (int) (long) json[nameof (score)];
    }
  }
}
