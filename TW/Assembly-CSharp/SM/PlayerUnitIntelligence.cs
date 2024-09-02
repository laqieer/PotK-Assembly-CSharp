// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitIntelligence
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerUnitIntelligence : KeyCompare
  {
    public int level_up_max_status;
    public int compose;
    public bool is_max;
    public int level;
    public int initial;
    public int inheritance;
    public int buildup;
    public int transmigrate;

    public PlayerUnitIntelligence()
    {
    }

    public PlayerUnitIntelligence(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.level_up_max_status = (int) (long) json[nameof (level_up_max_status)];
      this.compose = (int) (long) json[nameof (compose)];
      this.is_max = (bool) json[nameof (is_max)];
      this.level = (int) (long) json[nameof (level)];
      this.initial = (int) (long) json[nameof (initial)];
      this.inheritance = (int) (long) json[nameof (inheritance)];
      this.buildup = (int) (long) json[nameof (buildup)];
      this.transmigrate = (int) (long) json[nameof (transmigrate)];
    }

    public bool isMax(int add = 0)
    {
      return this.is_max || this.compose + this.level + this.transmigrate + add >= this.level_up_max_status;
    }
  }
}
