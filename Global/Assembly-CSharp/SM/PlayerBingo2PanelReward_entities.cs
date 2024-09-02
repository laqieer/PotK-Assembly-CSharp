// Decompiled with JetBrains decompiler
// Type: SM.PlayerBingo2PanelReward_entities
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
  public class PlayerBingo2PanelReward_entities : KeyCompare
  {
    public int _reward_entity;

    public PlayerBingo2PanelReward_entities()
    {
    }

    public PlayerBingo2PanelReward_entities(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._reward_entity = (int) (long) json[nameof (reward_entity)];
    }

    public Bingo2RewardEntity reward_entity
    {
      get
      {
        if (!MasterData.Bingo2RewardEntity.ContainsKey(this._reward_entity))
          Debug.LogError((object) ("Key not Found: MasterData.Bingo2RewardEntity[" + (object) this._reward_entity + "]"));
        return MasterData.Bingo2RewardEntity[this._reward_entity];
      }
    }
  }
}
