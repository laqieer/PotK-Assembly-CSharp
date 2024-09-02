// Decompiled with JetBrains decompiler
// Type: SM.RankingGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class RankingGroup : KeyCompare
  {
    public DateTime? finish_time;
    public DateTime? start_time;
    public PvPRankingPlayer my_ranking;
    public int period_id;
    public DateTime? reward_receivable_period;
    public PvPRankingPlayer[] group_ranking;

    public RankingGroup()
    {
    }

    public RankingGroup(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.finish_time = json[nameof (finish_time)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (finish_time)])) : new DateTime?();
      this.start_time = json[nameof (start_time)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_time)])) : new DateTime?();
      this.my_ranking = json[nameof (my_ranking)] != null ? new PvPRankingPlayer((Dictionary<string, object>) json[nameof (my_ranking)]) : (PvPRankingPlayer) null;
      this.period_id = (int) (long) json[nameof (period_id)];
      this.reward_receivable_period = json[nameof (reward_receivable_period)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (reward_receivable_period)])) : new DateTime?();
      List<PvPRankingPlayer> pvPrankingPlayerList = new List<PvPRankingPlayer>();
      foreach (object json1 in (List<object>) json[nameof (group_ranking)])
        pvPrankingPlayerList.Add(json1 != null ? new PvPRankingPlayer((Dictionary<string, object>) json1) : (PvPRankingPlayer) null);
      this.group_ranking = pvPrankingPlayerList.ToArray();
    }
  }
}
