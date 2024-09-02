// Decompiled with JetBrains decompiler
// Type: SM.PlayerQuestScoreExtraS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerQuestScoreExtraS : KeyCompare
  {
    public int quest_extra_s;
    public int score_max;

    public PlayerQuestScoreExtraS()
    {
    }

    public PlayerQuestScoreExtraS(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.quest_extra_s = (int) (long) json[nameof (quest_extra_s)];
      this.score_max = (int) (long) json[nameof (score_max)];
    }
  }
}
