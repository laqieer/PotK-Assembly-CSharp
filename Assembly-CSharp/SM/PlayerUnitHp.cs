// Decompiled with JetBrains decompiler
// Type: SM.PlayerUnitHp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace SM
{
  [Serializable]
  public class PlayerUnitHp : KeyCompare
  {
    [SerializeField]
    private int overkillers_value_;
    public int level_up_max_status;
    public int compose;
    public bool is_max;
    public int level;
    public int x_level;
    public int initial;
    public int inheritance;
    public int buildup;
    public int transmigrate;

    public int overkillersValue => this.overkillers_value_;

    public void resetOverkillersValue(int value = 0) => this.overkillers_value_ = value;

    public PlayerUnitHp()
    {
    }

    public PlayerUnitHp(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.level_up_max_status = (int) (long) json[nameof (level_up_max_status)];
      this.compose = (int) (long) json[nameof (compose)];
      this.is_max = (bool) json[nameof (is_max)];
      this.level = (int) (long) json[nameof (level)];
      this.x_level = (int) (long) json[nameof (x_level)];
      this.initial = (int) (long) json[nameof (initial)];
      this.inheritance = (int) (long) json[nameof (inheritance)];
      this.buildup = (int) (long) json[nameof (buildup)];
      this.transmigrate = (int) (long) json[nameof (transmigrate)];
    }

    public bool isMax(int add = 0) => this.is_max || this.compose + this.level + this.transmigrate + add >= this.level_up_max_status;

    public int buildupMaxCnt(PlayerUnit unit)
    {
      int a = unit.buildup_limit - (unit.buildup_count - this.buildup);
      if (a > unit.unit.buildup_limit_release_id.hp_limit_release_cnt)
        a = unit.unit.buildup_limit_release_id.hp_limit_release_cnt;
      if (a > this.level_up_max_status - this.level)
        a = this.level_up_max_status - this.level;
      return Mathf.Max(a, 0);
    }

    public int possibleBuildupCnt(PlayerUnit unit)
    {
      int a = unit.buildup_limit - (unit.buildup_count - this.buildup);
      if (a > unit.unit.buildup_limit_release_id.hp_limit_release_cnt)
        a = unit.unit.buildup_limit_release_id.hp_limit_release_cnt;
      if (a > unit.unit.buildup_limit_release_id.hp_limit_release_cnt - this.buildup)
        a = unit.unit.buildup_limit_release_id.hp_limit_release_cnt - this.buildup;
      if (a > this.level_up_max_status - this.level)
        a = this.level_up_max_status - this.level;
      return Mathf.Max(a, 0);
    }
  }
}
