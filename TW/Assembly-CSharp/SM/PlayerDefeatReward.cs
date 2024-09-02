// Decompiled with JetBrains decompiler
// Type: SM.PlayerDefeatReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerDefeatReward : KeyCompare
  {
    public int defeat_reward_id;

    public PlayerDefeatReward()
    {
    }

    public PlayerDefeatReward(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.defeat_reward_id = (int) (long) json[nameof (defeat_reward_id)];
    }
  }
}
