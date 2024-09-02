// Decompiled with JetBrains decompiler
// Type: SM.EventBattleFinish
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class EventBattleFinish : KeyCompare
  {
    public string period_name;
    public int current_sum_point;
    public int all_player_point;
    public EventBattleFinishDestroy_enemys[] destroy_enemys;
    public bool is_quest_target;
    public bool is_bonus_term;
    public int guild_point;
    public int period_id;
    public int contribution;
    public int[] get_reward_ids;
    public int player_point;
    public int period_type;

    public EventBattleFinish()
    {
    }

    public EventBattleFinish(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.period_name = (string) json[nameof (period_name)];
      this.current_sum_point = (int) (long) json[nameof (current_sum_point)];
      this.all_player_point = (int) (long) json[nameof (all_player_point)];
      List<EventBattleFinishDestroy_enemys> finishDestroyEnemysList = new List<EventBattleFinishDestroy_enemys>();
      foreach (object json1 in (List<object>) json[nameof (destroy_enemys)])
        finishDestroyEnemysList.Add(json1 != null ? new EventBattleFinishDestroy_enemys((Dictionary<string, object>) json1) : (EventBattleFinishDestroy_enemys) null);
      this.destroy_enemys = finishDestroyEnemysList.ToArray();
      this.is_quest_target = (bool) json[nameof (is_quest_target)];
      this.is_bonus_term = (bool) json[nameof (is_bonus_term)];
      this.guild_point = (int) (long) json[nameof (guild_point)];
      this.period_id = (int) (long) json[nameof (period_id)];
      this.contribution = (int) (long) json[nameof (contribution)];
      this.get_reward_ids = ((IEnumerable<object>) json[nameof (get_reward_ids)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.player_point = (int) (long) json[nameof (player_point)];
      this.period_type = (int) (long) json[nameof (period_type)];
    }
  }
}
