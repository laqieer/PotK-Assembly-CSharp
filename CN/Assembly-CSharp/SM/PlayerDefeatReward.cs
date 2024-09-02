// Decompiled with JetBrains decompiler
// Type: SM.PlayerDefeatReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
