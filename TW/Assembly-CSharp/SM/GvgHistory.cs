// Decompiled with JetBrains decompiler
// Type: SM.GvgHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class GvgHistory : KeyCompare
  {
    public int _status;
    public int? opponent_defense_star;
    public string target_guild_id;
    public DateTime? created_at;
    public int? defense_star;
    public string gvg_uuid;
    public int? opponent_attack_star;
    public int? target_guild_emblem_id;
    public string target_guild_name;
    public int? attack_star;
    public string guild_id;
    public GvgPlayerHistory[] player_histories;

    public GvgHistory()
    {
    }

    public GvgHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._status = (int) (long) json[nameof (status)];
      int? nullable1;
      if (json[nameof (opponent_defense_star)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (opponent_defense_star)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.opponent_defense_star = nullable1;
      this.target_guild_id = json[nameof (target_guild_id)] != null ? (string) json[nameof (target_guild_id)] : (string) null;
      this.created_at = json[nameof (created_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (created_at)])) : new DateTime?();
      int? nullable3;
      if (json[nameof (defense_star)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (defense_star)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.defense_star = nullable3;
      this.gvg_uuid = json[nameof (gvg_uuid)] != null ? (string) json[nameof (gvg_uuid)] : (string) null;
      int? nullable5;
      if (json[nameof (opponent_attack_star)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (opponent_attack_star)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.opponent_attack_star = nullable5;
      int? nullable7;
      if (json[nameof (target_guild_emblem_id)] == null)
      {
        nullable7 = new int?();
      }
      else
      {
        long? nullable8 = (long?) json[nameof (target_guild_emblem_id)];
        nullable7 = !nullable8.HasValue ? new int?() : new int?((int) nullable8.Value);
      }
      this.target_guild_emblem_id = nullable7;
      this.target_guild_name = json[nameof (target_guild_name)] != null ? (string) json[nameof (target_guild_name)] : (string) null;
      int? nullable9;
      if (json[nameof (attack_star)] == null)
      {
        nullable9 = new int?();
      }
      else
      {
        long? nullable10 = (long?) json[nameof (attack_star)];
        nullable9 = !nullable10.HasValue ? new int?() : new int?((int) nullable10.Value);
      }
      this.attack_star = nullable9;
      this.guild_id = json[nameof (guild_id)] != null ? (string) json[nameof (guild_id)] : (string) null;
      List<GvgPlayerHistory> gvgPlayerHistoryList = new List<GvgPlayerHistory>();
      foreach (object json1 in (List<object>) json[nameof (player_histories)])
        gvgPlayerHistoryList.Add(json1 != null ? new GvgPlayerHistory((Dictionary<string, object>) json1) : (GvgPlayerHistory) null);
      this.player_histories = gvgPlayerHistoryList.ToArray();
    }

    public GvgBattleStatus status
    {
      get
      {
        if (!Enum.IsDefined(typeof (GvgBattleStatus), (object) this._status))
          Debug.LogError((object) ("Key not Found: MasterDataTable.GvgBattleStatus[" + (object) this._status + "]"));
        return (GvgBattleStatus) this._status;
      }
    }
  }
}
