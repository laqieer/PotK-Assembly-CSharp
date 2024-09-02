// Decompiled with JetBrains decompiler
// Type: SM.PlayerCharacterQuestM
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
  public class PlayerCharacterQuestM : KeyCompare
  {
    public int _quest_m_id;
    public PlayerCharacterQuestS[] player_quests;
    public bool is_playable;
    public int _unit_id;

    public PlayerCharacterQuestM()
    {
    }

    public PlayerCharacterQuestM(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._quest_m_id = (int) (long) json[nameof (quest_m_id)];
      List<PlayerCharacterQuestS> playerCharacterQuestSList = new List<PlayerCharacterQuestS>();
      foreach (object json1 in (List<object>) json[nameof (player_quests)])
        playerCharacterQuestSList.Add(json1 != null ? new PlayerCharacterQuestS((Dictionary<string, object>) json1) : (PlayerCharacterQuestS) null);
      this.player_quests = playerCharacterQuestSList.ToArray();
      this.is_playable = (bool) json[nameof (is_playable)];
      this._unit_id = (int) (long) json[nameof (unit_id)];
    }

    public QuestCharacterM quest_m_id
    {
      get
      {
        if (!MasterData.QuestCharacterM.ContainsKey(this._quest_m_id))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterM[" + (object) this._quest_m_id + "]"));
        return MasterData.QuestCharacterM[this._quest_m_id];
      }
    }

    public UnitUnit unit_id
    {
      get
      {
        if (!MasterData.UnitUnit.ContainsKey(this._unit_id))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this._unit_id + "]"));
        return MasterData.UnitUnit[this._unit_id];
      }
    }
  }
}
