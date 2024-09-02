// Decompiled with JetBrains decompiler
// Type: SM.PlayerCoinBonusHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerCoinBonusHistory : KeyCompare
  {
    public int coinbonus_reward_id;
    public int id;

    public PlayerCoinBonusHistory()
    {
    }

    public PlayerCoinBonusHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.coinbonus_reward_id = (int) (long) json[nameof (coinbonus_reward_id)];
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
