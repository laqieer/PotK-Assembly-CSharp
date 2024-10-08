﻿// Decompiled with JetBrains decompiler
// Type: SM.PlayerHarmonyQuestM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class PlayerHarmonyQuestM : KeyCompare
  {
    public int _quest_m_id;
    public PlayerHarmonyQuestS[] player_quests;
    public bool is_playable;

    public QuestHarmonyM quest_m_id
    {
      get
      {
        if (MasterData.QuestHarmonyM.ContainsKey(this._quest_m_id))
          return MasterData.QuestHarmonyM[this._quest_m_id];
        Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyM[" + (object) this._quest_m_id + "]"));
        return (QuestHarmonyM) null;
      }
    }

    public PlayerHarmonyQuestM()
    {
    }

    public PlayerHarmonyQuestM(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._quest_m_id = (int) (long) json[nameof (quest_m_id)];
      List<PlayerHarmonyQuestS> playerHarmonyQuestSList = new List<PlayerHarmonyQuestS>();
      foreach (object obj in (List<object>) json[nameof (player_quests)])
        playerHarmonyQuestSList.Add(obj == null ? (PlayerHarmonyQuestS) null : new PlayerHarmonyQuestS((Dictionary<string, object>) obj));
      this.player_quests = playerHarmonyQuestSList.ToArray();
      this.is_playable = (bool) json[nameof (is_playable)];
    }
  }
}
