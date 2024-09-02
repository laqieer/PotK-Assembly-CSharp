// Decompiled with JetBrains decompiler
// Type: SM.PlayerBingo2Selected_reward_group
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
  public class PlayerBingo2Selected_reward_group : KeyCompare
  {
    public PlayerBingo2Selected_reward_groupComplete_reward_entities[] complete_reward_entities;
    public int _complete_reward_group;

    public PlayerBingo2Selected_reward_group()
    {
    }

    public PlayerBingo2Selected_reward_group(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<PlayerBingo2Selected_reward_groupComplete_reward_entities> completeRewardEntitiesList = new List<PlayerBingo2Selected_reward_groupComplete_reward_entities>();
      foreach (object json1 in (List<object>) json[nameof (complete_reward_entities)])
        completeRewardEntitiesList.Add(json1 != null ? new PlayerBingo2Selected_reward_groupComplete_reward_entities((Dictionary<string, object>) json1) : (PlayerBingo2Selected_reward_groupComplete_reward_entities) null);
      this.complete_reward_entities = completeRewardEntitiesList.ToArray();
      this._complete_reward_group = (int) (long) json[nameof (complete_reward_group)];
    }

    public Bingo2CompleteRewardGroup complete_reward_group
    {
      get
      {
        if (!MasterData.Bingo2CompleteRewardGroup.ContainsKey(this._complete_reward_group))
          Debug.LogError((object) ("Key not Found: MasterData.Bingo2CompleteRewardGroup[" + (object) this._complete_reward_group + "]"));
        return MasterData.Bingo2CompleteRewardGroup[this._complete_reward_group];
      }
    }
  }
}
