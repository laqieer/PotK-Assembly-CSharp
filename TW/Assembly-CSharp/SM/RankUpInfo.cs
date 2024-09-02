// Decompiled with JetBrains decompiler
// Type: SM.RankUpInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class RankUpInfo : KeyCompare
  {
    public RankUpInfoRank_up_rewards[] rank_up_rewards;
    public int after_rank_pt;
    public int rank_change;
    public int before_rank_pt;

    public RankUpInfo()
    {
    }

    public RankUpInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<RankUpInfoRank_up_rewards> infoRankUpRewardsList = new List<RankUpInfoRank_up_rewards>();
      foreach (object json1 in (List<object>) json[nameof (rank_up_rewards)])
        infoRankUpRewardsList.Add(json1 != null ? new RankUpInfoRank_up_rewards((Dictionary<string, object>) json1) : (RankUpInfoRank_up_rewards) null);
      this.rank_up_rewards = infoRankUpRewardsList.ToArray();
      this.after_rank_pt = (int) (long) json[nameof (after_rank_pt)];
      this.rank_change = (int) (long) json[nameof (rank_change)];
      this.before_rank_pt = (int) (long) json[nameof (before_rank_pt)];
    }
  }
}
