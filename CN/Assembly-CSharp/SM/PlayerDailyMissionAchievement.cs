// Decompiled with JetBrains decompiler
// Type: SM.PlayerDailyMissionAchievement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerDailyMissionAchievement : KeyCompare
  {
    public int count;
    public int limit_count;
    public DailyMissionReward[] rewards;
    public string target_date;
    public int max_count;
    public int mission_id;
    public int received_count;

    public PlayerDailyMissionAchievement()
    {
    }

    public PlayerDailyMissionAchievement(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.count = (int) (long) json[nameof (count)];
      this.limit_count = (int) (long) json[nameof (limit_count)];
      List<DailyMissionReward> dailyMissionRewardList = new List<DailyMissionReward>();
      foreach (object json1 in (List<object>) json[nameof (rewards)])
        dailyMissionRewardList.Add(json1 != null ? new DailyMissionReward((Dictionary<string, object>) json1) : (DailyMissionReward) null);
      this.rewards = dailyMissionRewardList.ToArray();
      this.target_date = (string) json[nameof (target_date)];
      this.max_count = (int) (long) json[nameof (max_count)];
      this.mission_id = (int) (long) json[nameof (mission_id)];
      this.received_count = (int) (long) json[nameof (received_count)];
    }
  }
}
