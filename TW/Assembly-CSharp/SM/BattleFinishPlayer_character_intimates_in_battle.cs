﻿// Decompiled with JetBrains decompiler
// Type: SM.BattleFinishPlayer_character_intimates_in_battle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class BattleFinishPlayer_character_intimates_in_battle : KeyCompare
  {
    public int target_character_id;
    public int character_id;
    public int before_total_exp;
    public int after_total_exp;
    public int after_level;
    public int before_level;

    public BattleFinishPlayer_character_intimates_in_battle()
    {
    }

    public BattleFinishPlayer_character_intimates_in_battle(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.target_character_id = (int) (long) json[nameof (target_character_id)];
      this.character_id = (int) (long) json[nameof (character_id)];
      this.before_total_exp = (int) (long) json[nameof (before_total_exp)];
      this.after_total_exp = (int) (long) json[nameof (after_total_exp)];
      this.after_level = (int) (long) json[nameof (after_level)];
      this.before_level = (int) (long) json[nameof (before_level)];
    }
  }
}
