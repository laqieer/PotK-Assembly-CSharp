﻿// Decompiled with JetBrains decompiler
// Type: SM.ColosseumEnd
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class ColosseumEnd : KeyCompare
  {
    public PlayerItem[] after_player_gears;
    public PlayerUnit[] after_player_units;
    public int remaining_times;
    public ColosseumEndUnlock_messages[] unlock_messages;
    public UnlockQuest[] unlock_quests;
    public int[] disappeared_player_gears;
    public PlayerEmblem[] new_emblems;
    public PlayerUnit[] before_player_units;
    public int limit_times;
    public PlayerItem[] before_player_gears;

    public ColosseumEnd()
    {
    }

    public ColosseumEnd(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<PlayerItem> playerItemList1 = new List<PlayerItem>();
      foreach (object json1 in (List<object>) json[nameof (after_player_gears)])
        playerItemList1.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
      this.after_player_gears = playerItemList1.ToArray();
      List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
      foreach (object json2 in (List<object>) json[nameof (after_player_units)])
        playerUnitList1.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
      this.after_player_units = playerUnitList1.ToArray();
      this.remaining_times = (int) (long) json[nameof (remaining_times)];
      List<ColosseumEndUnlock_messages> endUnlockMessagesList = new List<ColosseumEndUnlock_messages>();
      foreach (object json3 in (List<object>) json[nameof (unlock_messages)])
        endUnlockMessagesList.Add(json3 != null ? new ColosseumEndUnlock_messages((Dictionary<string, object>) json3) : (ColosseumEndUnlock_messages) null);
      this.unlock_messages = endUnlockMessagesList.ToArray();
      List<UnlockQuest> unlockQuestList = new List<UnlockQuest>();
      foreach (object json4 in (List<object>) json[nameof (unlock_quests)])
        unlockQuestList.Add(json4 != null ? new UnlockQuest((Dictionary<string, object>) json4) : (UnlockQuest) null);
      this.unlock_quests = unlockQuestList.ToArray();
      this.disappeared_player_gears = ((IEnumerable<object>) json[nameof (disappeared_player_gears)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      List<PlayerEmblem> playerEmblemList = new List<PlayerEmblem>();
      foreach (object json5 in (List<object>) json[nameof (new_emblems)])
        playerEmblemList.Add(json5 != null ? new PlayerEmblem((Dictionary<string, object>) json5) : (PlayerEmblem) null);
      this.new_emblems = playerEmblemList.ToArray();
      List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
      foreach (object json6 in (List<object>) json[nameof (before_player_units)])
        playerUnitList2.Add(json6 != null ? new PlayerUnit((Dictionary<string, object>) json6) : (PlayerUnit) null);
      this.before_player_units = playerUnitList2.ToArray();
      this.limit_times = (int) (long) json[nameof (limit_times)];
      List<PlayerItem> playerItemList2 = new List<PlayerItem>();
      foreach (object json7 in (List<object>) json[nameof (before_player_gears)])
        playerItemList2.Add(json7 != null ? new PlayerItem((Dictionary<string, object>) json7) : (PlayerItem) null);
      this.before_player_gears = playerItemList2.ToArray();
    }
  }
}
