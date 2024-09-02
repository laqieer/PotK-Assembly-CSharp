// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitDexterity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerUnitDexterity : KeyCompare
  {
    public int compose;
    public bool is_max;
    public int level;
    public int initial;
    public int inheritance;
    public int buildup;
    public int transmigrate;

    public PlayerUnitDexterity()
    {
    }

    public PlayerUnitDexterity(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.compose = (int) (long) json[nameof (compose)];
      this.is_max = (bool) json[nameof (is_max)];
      this.level = (int) (long) json[nameof (level)];
      this.initial = (int) (long) json[nameof (initial)];
      this.inheritance = (int) (long) json[nameof (inheritance)];
      this.buildup = (int) (long) json[nameof (buildup)];
      this.transmigrate = (int) (long) json[nameof (transmigrate)];
    }
  }
}
