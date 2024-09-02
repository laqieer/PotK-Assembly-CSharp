// Decompiled with JetBrains decompiler
// Type: SM.PlayerSupply
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerSupply : KeyCompare
  {
    public int gear_accessory_remaining_amount;
    public int entity_id;
    public PlayerGearBuildupParam gear_buildup_param;
    public bool for_battle;
    public int box_type_id;
    public int _entity_type;
    public int gear_level;
    public bool favorite;
    public int gear_exp_next;
    public bool is_new;
    public bool broken;
    public string player_id;
    public int gear_level_unlimit;
    public int gear_level_limit_max;
    public int gear_total_exp;
    public int gear_exp;
    public int id;
    public int gear_level_limit;
    public int quantity;

    public PlayerSupply()
    {
    }

    public PlayerSupply(Dictionary<string, object> json)
    {
      this._hasKey = true;
      this.gear_accessory_remaining_amount = (int) (long) json[nameof (gear_accessory_remaining_amount)];
      this.entity_id = (int) (long) json[nameof (entity_id)];
      this.gear_buildup_param = json[nameof (gear_buildup_param)] != null ? new PlayerGearBuildupParam((Dictionary<string, object>) json[nameof (gear_buildup_param)]) : (PlayerGearBuildupParam) null;
      this.for_battle = (bool) json[nameof (for_battle)];
      this.box_type_id = (int) (long) json[nameof (box_type_id)];
      this._entity_type = (int) (long) json[nameof (_entity_type)];
      this.gear_level = (int) (long) json[nameof (gear_level)];
      this.favorite = (bool) json[nameof (favorite)];
      this.gear_exp_next = (int) (long) json[nameof (gear_exp_next)];
      this.is_new = (bool) json[nameof (is_new)];
      this.broken = (bool) json[nameof (broken)];
      this.player_id = (string) json[nameof (player_id)];
      this.gear_level_unlimit = (int) (long) json[nameof (gear_level_unlimit)];
      this.gear_level_limit_max = (int) (long) json[nameof (gear_level_limit_max)];
      this.gear_total_exp = (int) (long) json[nameof (gear_total_exp)];
      this.gear_exp = (int) (long) json[nameof (gear_exp)];
      this._key = (object) (this.id = (int) (long) json[nameof (id)]);
      this.gear_level_limit = (int) (long) json[nameof (gear_level_limit)];
      this.quantity = (int) (long) json[nameof (quantity)];
    }
  }
}
