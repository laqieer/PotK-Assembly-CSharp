﻿// Decompiled with JetBrains decompiler
// Type: SM.PlayerHarmonyQuestM
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
  public class PlayerHarmonyQuestM : KeyCompare
  {
    public int _quest_m_id;
    public PlayerHarmonyQuestS[] player_quests;
    public bool is_playable;

    public PlayerHarmonyQuestM()
    {
    }

    public PlayerHarmonyQuestM(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._quest_m_id = (int) (long) json[nameof (quest_m_id)];
      List<PlayerHarmonyQuestS> playerHarmonyQuestSList = new List<PlayerHarmonyQuestS>();
      foreach (object json1 in (List<object>) json[nameof (player_quests)])
        playerHarmonyQuestSList.Add(json1 != null ? new PlayerHarmonyQuestS((Dictionary<string, object>) json1) : (PlayerHarmonyQuestS) null);
      this.player_quests = playerHarmonyQuestSList.ToArray();
      this.is_playable = (bool) json[nameof (is_playable)];
    }

    public QuestHarmonyM quest_m_id
    {
      get
      {
        if (!MasterData.QuestHarmonyM.ContainsKey(this._quest_m_id))
          Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyM[" + (object) this._quest_m_id + "]"));
        return MasterData.QuestHarmonyM[this._quest_m_id];
      }
    }
  }
}
