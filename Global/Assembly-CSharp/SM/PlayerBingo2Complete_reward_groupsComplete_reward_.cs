// Decompiled with JetBrains decompiler
// Type: SM.PlayerBingo2Complete_reward_groupsComplete_reward_entities
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
  public class PlayerBingo2Complete_reward_groupsComplete_reward_entities : KeyCompare
  {
    public string url;
    public int _complete_reward_entity;

    public PlayerBingo2Complete_reward_groupsComplete_reward_entities()
    {
    }

    public PlayerBingo2Complete_reward_groupsComplete_reward_entities(
      Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.url = (string) json[nameof (url)];
      this._complete_reward_entity = (int) (long) json[nameof (complete_reward_entity)];
    }

    public Bingo2CompleteRewardEntity complete_reward_entity
    {
      get
      {
        if (!MasterData.Bingo2CompleteRewardEntity.ContainsKey(this._complete_reward_entity))
          Debug.LogError((object) ("Key not Found: MasterData.Bingo2CompleteRewardEntity[" + (object) this._complete_reward_entity + "]"));
        return MasterData.Bingo2CompleteRewardEntity[this._complete_reward_entity];
      }
    }
  }
}
