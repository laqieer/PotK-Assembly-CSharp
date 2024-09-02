// Decompiled with JetBrains decompiler
// Type: SM.PlayerHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerHelper : KeyCompare
  {
    public bool is_friend;
    public int level;
    public string target_player_id;
    public DateTime target_player_last_signed_in_at;
    public PlayerUnit leader_unit;
    public string target_player_name;
    public int current_emblem_id;
    public int leader_unit_id;
    public int equip_gear_id;
    public int leader_unit_level;

    public PlayerHelper()
    {
    }

    public PlayerHelper(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.is_friend = (bool) json[nameof (is_friend)];
      this.level = (int) (long) json[nameof (level)];
      this.target_player_id = (string) json[nameof (target_player_id)];
      this.target_player_last_signed_in_at = DateTime.Parse((string) json[nameof (target_player_last_signed_in_at)]);
      this.leader_unit = json[nameof (leader_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (leader_unit)]) : (PlayerUnit) null;
      this.target_player_name = (string) json[nameof (target_player_name)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.leader_unit_id = (int) (long) json[nameof (leader_unit_id)];
      this.equip_gear_id = (int) (long) json[nameof (equip_gear_id)];
      this.leader_unit_level = (int) (long) json[nameof (leader_unit_level)];
    }

    public GearGear equip_gear_from_cache => MasterData.GearGear[this.equip_gear_id];

    public UnitUnit leader_unit_from_cache => MasterData.UnitUnit[this.leader_unit_id];

    public bool enableLeaderSkill() => this.is_friend;
  }
}
