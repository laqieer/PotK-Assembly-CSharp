// Decompiled with JetBrains decompiler
// Type: SM.RankUpInfoRank_up_rewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class RankUpInfoRank_up_rewards : KeyCompare
  {
    public int reward_quantity;
    public int reward_type_id;
    public int reward_id;

    public RankUpInfoRank_up_rewards()
    {
    }

    public RankUpInfoRank_up_rewards(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      this.reward_id = (int) (long) json[nameof (reward_id)];
    }
  }
}
