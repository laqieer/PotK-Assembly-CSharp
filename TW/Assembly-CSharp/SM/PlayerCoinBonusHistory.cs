// Decompiled with JetBrains decompiler
// Type: SM.PlayerCoinBonusHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerCoinBonusHistory : KeyCompare
  {
    public int coinbonus_id;
    public int coinbonus_reward_id;
    public int id;

    public PlayerCoinBonusHistory()
    {
    }

    public PlayerCoinBonusHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.coinbonus_id = (int) (long) json[nameof (coinbonus_id)];
      this.coinbonus_reward_id = (int) (long) json[nameof (coinbonus_reward_id)];
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
