﻿// Decompiled with JetBrains decompiler
// Type: SM.PlayerExtraQuestS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerExtraQuestS : KeyCompare
  {
    public int daily_limit_strictly;
    public int _quest_extra_s;
    public int consumed_ap;
    public int[] clear_rewards;
    public DateTime? time_locked_at;
    public bool is_new;
    public int extra_quest_area;
    public int? remain_battle_count;
    public string seek_index;
    public bool is_story_type_quest;
    public bool enable_autobattle;
    public int daily_limit;
    public DateTime today_day_end_at;
    public bool is_clear;
    public int max_battle_count_limit;

    public PlayerExtraQuestS()
    {
    }

    public PlayerExtraQuestS(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.daily_limit_strictly = (int) (long) json[nameof (daily_limit_strictly)];
      this._quest_extra_s = (int) (long) json[nameof (quest_extra_s)];
      this.consumed_ap = (int) (long) json[nameof (consumed_ap)];
      this.clear_rewards = ((IEnumerable<object>) json[nameof (clear_rewards)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.time_locked_at = json[nameof (time_locked_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (time_locked_at)])) : new DateTime?();
      this.is_new = (bool) json[nameof (is_new)];
      this.extra_quest_area = (int) (long) json[nameof (extra_quest_area)];
      int? nullable1;
      if (json[nameof (remain_battle_count)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (remain_battle_count)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.remain_battle_count = nullable1;
      this.seek_index = (string) json[nameof (seek_index)];
      this.is_story_type_quest = (bool) json[nameof (is_story_type_quest)];
      this.enable_autobattle = (bool) json[nameof (enable_autobattle)];
      this.daily_limit = (int) (long) json[nameof (daily_limit)];
      this.today_day_end_at = DateTime.Parse((string) json[nameof (today_day_end_at)]);
      this.is_clear = (bool) json[nameof (is_clear)];
      this.max_battle_count_limit = (int) (long) json[nameof (max_battle_count_limit)];
    }

    public QuestExtraS quest_extra_s
    {
      get
      {
        if (MasterData.QuestExtraS.ContainsKey(this._quest_extra_s))
          return MasterData.QuestExtraS[this._quest_extra_s];
        Debug.LogError((object) ("Key not Found: MasterData.QuestExtraS[" + (object) this._quest_extra_s + "]"));
        return (QuestExtraS) null;
      }
    }

    public PlayerExtraQuestS.SeekType seek_type
    {
      get
      {
        if (this.seek_index == "m" || this.seek_index == "M")
          return PlayerExtraQuestS.SeekType.M;
        return this.seek_index == "l" || this.seek_index == "L" ? PlayerExtraQuestS.SeekType.L : PlayerExtraQuestS.SeekType.None;
      }
    }

    public QuestExtraCategory top_category
    {
      get
      {
        QuestExtraCategory topCategory = (QuestExtraCategory) null;
        if (this.seek_type == PlayerExtraQuestS.SeekType.L)
        {
          QuestExtraL questExtraL;
          if (MasterData.QuestExtraL.TryGetValue(this.quest_extra_s.quest_l_QuestExtraL, out questExtraL))
            topCategory = questExtraL.category;
        }
        else
        {
          QuestExtraM questExtraM;
          if (MasterData.QuestExtraM.TryGetValue(this.quest_extra_s.quest_m_QuestExtraM, out questExtraM))
            topCategory = questExtraM.category;
        }
        return topCategory;
      }
    }

    public enum SeekType
    {
      None,
      M,
      L,
    }
  }
}
