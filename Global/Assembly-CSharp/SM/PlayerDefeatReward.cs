// Decompiled with JetBrains decompiler
// Type: SM.PlayerDefeatReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
