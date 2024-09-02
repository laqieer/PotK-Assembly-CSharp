// Decompiled with JetBrains decompiler
// Type: SM.PlayerGearReisouSchema
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class PlayerGearReisouSchema : KeyCompare
  {
    public int chaos_gear_level;
    public int gear_level;
    public int gear_id;
    public int id;
    public int holy_gear_level;

    public PlayerItem getReisouItemForSchema() => this.getReisouItemForSchema(this);

    public PlayerItem getReisouItemForSchema(PlayerGearReisouSchema schema)
    {
      PlayerItem playerItem = new PlayerItem();
      playerItem.entity_id = schema.gear_id;
      playerItem._entity_type = 3;
      playerItem.for_battle = true;
      playerItem.gear_level = schema.gear_level;
      playerItem.gear_level_limit = 99;
      playerItem.favorite = false;
      playerItem.gear_exp_next = 1;
      playerItem.is_new = false;
      playerItem.broken = false;
      playerItem.id = schema.id;
      playerItem.quantity = 1;
      if (playerItem.gear.isMythologyReisou())
      {
        playerItem.ReisouHolyLv = schema.holy_gear_level;
        playerItem.ReisouChaosLv = schema.chaos_gear_level;
        playerItem.SetPlayerMythologyGearStatusCache(new PlayerMythologyGearStatus()
        {
          holy_gear_level = schema.holy_gear_level,
          chaos_gear_level = schema.chaos_gear_level
        });
      }
      else
      {
        playerItem.ReisouHolyLv = 0;
        playerItem.ReisouChaosLv = 0;
      }
      return playerItem;
    }

    public PlayerGearReisouSchema()
    {
    }

    public PlayerGearReisouSchema(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.chaos_gear_level = (int) (long) json[nameof (chaos_gear_level)];
      this.gear_level = (int) (long) json[nameof (gear_level)];
      this.gear_id = (int) (long) json[nameof (gear_id)];
      this.id = (int) (long) json[nameof (id)];
      this.holy_gear_level = (int) (long) json[nameof (holy_gear_level)];
    }
  }
}
