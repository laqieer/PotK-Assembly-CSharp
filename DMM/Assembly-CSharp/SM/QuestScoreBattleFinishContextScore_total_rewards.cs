﻿// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreBattleFinishContextScore_total_rewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
      foreach (object obj in (List<object>) json[nameof (rewards)])
        totalRewardReceivedList.Add(obj == null ? (QuestScoreTotalRewardReceived) null : new QuestScoreTotalRewardReceived((Dictionary<string, object>) obj));
      this.rewards = totalRewardReceivedList.ToArray();
      this.score = (int) (long) json[nameof (score)];
    }
  }
}
