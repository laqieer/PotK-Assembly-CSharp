﻿// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreAchivementReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreAchivementReward : KeyCompare
  {
    public int reward_quantity;
    public int score_needed;
    public int id;
    public int reward_id;
    public int reward_type_id;

    public QuestScoreAchivementReward()
    {
    }

    public QuestScoreAchivementReward(Dictionary<string, object> json)
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
