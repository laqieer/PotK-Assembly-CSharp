// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitGearProficiency
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerUnitGearProficiency : KeyCompare
  {
    public int total_exp;
    public int exp_next;
    public int gear_kind_id;
    public int exp;
    public int level;

    public PlayerUnitGearProficiency()
    {
    }

    public PlayerUnitGearProficiency(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.total_exp = (int) (long) json[nameof (total_exp)];
      this.exp_next = (int) (long) json[nameof (exp_next)];
      this.gear_kind_id = (int) (long) json[nameof (gear_kind_id)];
      this.exp = (int) (long) json[nameof (exp)];
      this.level = (int) (long) json[nameof (level)];
    }
  }
}
