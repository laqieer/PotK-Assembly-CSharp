﻿// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreTotalReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreTotalReward : KeyCompare
  {
    public int reward_quantity;
    public int score_needed;
    public int id;
    public int reward_id;
    public int reward_type_id;

    public QuestScoreTotalReward()
    {
    }

    public QuestScoreTotalReward(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.score_needed = (int) (long) json[nameof (score_needed)];
      this.id = (int) (long) json[nameof (id)];
      this.reward_id = (int) (long) json[nameof (reward_id)];
      this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
    }
  }
}
