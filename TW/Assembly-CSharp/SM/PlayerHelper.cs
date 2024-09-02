// Decompiled with JetBrains decompiler
// Type: SM.PlayerHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerHelper : KeyCompare
  {
    public int? leader_skill_id;
    public bool is_friend;
    public int level;
    public string target_player_id;
    public DateTime target_player_last_signed_in_at;
    public PlayerUnit leader_unit;
    public string target_player_name;
    public bool is_guild_member;
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
      int? nullable1;
      if (json[nameof (leader_skill_id)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (leader_skill_id)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.leader_skill_id = nullable1;
      this.is_friend = (bool) json[nameof (is_friend)];
      this.level = (int) (long) json[nameof (level)];
      this.target_player_id = (string) json[nameof (target_player_id)];
      this.target_player_last_signed_in_at = DateTime.Parse((string) json[nameof (target_player_last_signed_in_at)]);
      this.leader_unit = json[nameof (leader_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (leader_unit)]) : (PlayerUnit) null;
      this.target_player_name = (string) json[nameof (target_player_name)];
      this.is_guild_member = (bool) json[nameof (is_guild_member)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.leader_unit_id = (int) (long) json[nameof (leader_unit_id)];
      this.equip_gear_id = (int) (long) json[nameof (equip_gear_id)];
      this.leader_unit_level = (int) (long) json[nameof (leader_unit_level)];
    }

    public GearGear equip_gear_from_cache => MasterData.GearGear[this.equip_gear_id];

    public UnitUnit leader_unit_from_cache => MasterData.UnitUnit[this.leader_unit_id];

    public BattleskillSkill leader_skill_from_cache
    {
      get
      {
        return this.leader_skill_id.HasValue ? MasterData.BattleskillSkill[this.leader_skill_id.Value] : (BattleskillSkill) null;
      }
    }

    public bool enableLeaderSkill() => this.is_friend || this.is_guild_member;
  }
}
