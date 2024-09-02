// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreBattleFinishContextScore_total_rewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreBattleFinishContextScore_total_rewards : KeyCompare
  {
    public QuestScoreTotalRewardReceived[] rewards;
    public int score;

    public QuestScoreBattleFinishContextScore_total_rewards()
    {
    }

    public QuestScoreBattleFinishContextScore_total_rewards(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<QuestScoreTotalRewardReceived> totalRewardReceivedList = new List<QuestScoreTotalRewardReceived>();
      foreach (object json1 in (List<object>) json[nameof (rewards)])
        totalRewardReceivedList.Add(json1 != null ? new QuestScoreTotalRewardReceived((Dictionary<string, object>) json1) : (QuestScoreTotalRewardReceived) null);
      this.rewards = totalRewardReceivedList.ToArray();
      this.score = (int) (long) json[nameof (score)];
    }
  }
}
