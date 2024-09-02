// Decompiled with JetBrains decompiler
// Type: SM.PlayerHarmonyQuestS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerHarmonyQuestS : KeyCompare
  {
    public int max_battle_count_limit;
    public bool is_new;
    public int? remain_battle_count;
    public bool enable_autobattle;
    public int _quest_harmony_s;
    public bool is_clear;
    public int consumed_ap;

    public PlayerHarmonyQuestS()
    {
    }

    public PlayerHarmonyQuestS(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.max_battle_count_limit = (int) (long) json[nameof (max_battle_count_limit)];
      this.is_new = (bool) json[nameof (is_new)];
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
      this.enable_autobattle = (bool) json[nameof (enable_autobattle)];
      this._quest_harmony_s = (int) (long) json[nameof (quest_harmony_s)];
      this.is_clear = (bool) json[nameof (is_clear)];
      this.consumed_ap = (int) (long) json[nameof (consumed_ap)];
    }

    public QuestHarmonyS quest_harmony_s
    {
      get
      {
        if (!MasterData.QuestHarmonyS.ContainsKey(this._quest_harmony_s))
          Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyS[" + (object) this._quest_harmony_s + "]"));
        return MasterData.QuestHarmonyS[this._quest_harmony_s];
      }
    }
  }
}
