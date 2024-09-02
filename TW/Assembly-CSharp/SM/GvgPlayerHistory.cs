// Decompiled with JetBrains decompiler
// Type: SM.GvgPlayerHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GvgPlayerHistory : KeyCompare
  {
    public string player_name;
    public int? leader_unit_level;
    public int? leader_unit_unit_type_id;
    public int? role;
    public int? attack_count;
    public int? defense_count;
    public int? leader_unit_unit_id;
    public string player_id;
    public int? defense_star;
    public int? attack_star;
    public int? player_emblem_id;
    public string gvg_uuid;
    public int? contribution;
    public string guild_id;
    public int? leader_unit_id;

    public GvgPlayerHistory()
    {
    }

    public GvgPlayerHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_name = json[nameof (player_name)] != null ? (string) json[nameof (player_name)] : (string) null;
      int? nullable1;
      if (json[nameof (leader_unit_level)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (leader_unit_level)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.leader_unit_level = nullable1;
      int? nullable3;
      if (json[nameof (leader_unit_unit_type_id)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (leader_unit_unit_type_id)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.leader_unit_unit_type_id = nullable3;
      int? nullable5;
      if (json[nameof (role)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (role)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.role = nullable5;
      int? nullable7;
      if (json[nameof (attack_count)] == null)
      {
        nullable7 = new int?();
      }
      else
      {
        long? nullable8 = (long?) json[nameof (attack_count)];
        nullable7 = !nullable8.HasValue ? new int?() : new int?((int) nullable8.Value);
      }
      this.attack_count = nullable7;
      int? nullable9;
      if (json[nameof (defense_count)] == null)
      {
        nullable9 = new int?();
      }
      else
      {
        long? nullable10 = (long?) json[nameof (defense_count)];
        nullable9 = !nullable10.HasValue ? new int?() : new int?((int) nullable10.Value);
      }
      this.defense_count = nullable9;
      int? nullable11;
      if (json[nameof (leader_unit_unit_id)] == null)
      {
        nullable11 = new int?();
      }
      else
      {
        long? nullable12 = (long?) json[nameof (leader_unit_unit_id)];
        nullable11 = !nullable12.HasValue ? new int?() : new int?((int) nullable12.Value);
      }
      this.leader_unit_unit_id = nullable11;
      this.player_id = json[nameof (player_id)] != null ? (string) json[nameof (player_id)] : (string) null;
      int? nullable13;
      if (json[nameof (defense_star)] == null)
      {
        nullable13 = new int?();
      }
      else
      {
        long? nullable14 = (long?) json[nameof (defense_star)];
        nullable13 = !nullable14.HasValue ? new int?() : new int?((int) nullable14.Value);
      }
      this.defense_star = nullable13;
      int? nullable15;
      if (json[nameof (attack_star)] == null)
      {
        nullable15 = new int?();
      }
      else
      {
        long? nullable16 = (long?) json[nameof (attack_star)];
        nullable15 = !nullable16.HasValue ? new int?() : new int?((int) nullable16.Value);
      }
      this.attack_star = nullable15;
      int? nullable17;
      if (json[nameof (player_emblem_id)] == null)
      {
        nullable17 = new int?();
      }
      else
      {
        long? nullable18 = (long?) json[nameof (player_emblem_id)];
        nullable17 = !nullable18.HasValue ? new int?() : new int?((int) nullable18.Value);
      }
      this.player_emblem_id = nullable17;
      this.gvg_uuid = json[nameof (gvg_uuid)] != null ? (string) json[nameof (gvg_uuid)] : (string) null;
      int? nullable19;
      if (json[nameof (contribution)] == null)
      {
        nullable19 = new int?();
      }
      else
      {
        long? nullable20 = (long?) json[nameof (contribution)];
        nullable19 = !nullable20.HasValue ? new int?() : new int?((int) nullable20.Value);
      }
      this.contribution = nullable19;
      this.guild_id = json[nameof (guild_id)] != null ? (string) json[nameof (guild_id)] : (string) null;
      int? nullable21;
      if (json[nameof (leader_unit_id)] == null)
      {
        nullable21 = new int?();
      }
      else
      {
        long? nullable22 = (long?) json[nameof (leader_unit_id)];
        nullable21 = !nullable22.HasValue ? new int?() : new int?((int) nullable22.Value);
      }
      this.leader_unit_id = nullable21;
    }
  }
}
