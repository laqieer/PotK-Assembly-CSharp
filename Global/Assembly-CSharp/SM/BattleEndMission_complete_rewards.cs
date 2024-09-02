// Decompiled with JetBrains decompiler
// Type: SM.BattleEndMission_complete_rewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class BattleEndMission_complete_rewards : KeyCompare
  {
    public int reward_quantity;
    public string message;
    public int reward_type_id;
    public int reward_id;

    public BattleEndMission_complete_rewards()
    {
    }

    public BattleEndMission_complete_rewards(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.reward_quantity = (int) (long) json[nameof (reward_quantity)];
      this.message = (string) json[nameof (message)];
      this.reward_type_id = (int) (long) json[nameof (reward_type_id)];
      this.reward_id = (int) (long) json[nameof (reward_id)];
    }
  }
}
