// Decompiled with JetBrains decompiler
// Type: SM.PlayerFriend
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerFriend : KeyCompare
  {
    public string sent_player_id;
    public int?[] gear_ids;
    public DateTime? applied_at;
    public int level;
    public string target_player_id;
    public DateTime target_player_last_signed_in_at;
    public PlayerUnit leader_unit;
    public bool application;
    public bool is_favorite;
    public int current_emblem_id;
    public string target_player_name;

    public PlayerFriend()
    {
    }

    public PlayerFriend(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.sent_player_id = (string) json[nameof (sent_player_id)];
      this.gear_ids = ((IEnumerable<object>) json[nameof (gear_ids)]).Select<object, int?>((Func<object, int?>) (s =>
      {
        long? nullable = (long?) s;
        return nullable.HasValue ? new int?((int) nullable.Value) : new int?();
      })).ToArray<int?>();
      this.applied_at = json[nameof (applied_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (applied_at)])) : new DateTime?();
      this.level = (int) (long) json[nameof (level)];
      this.target_player_id = (string) json[nameof (target_player_id)];
      this.target_player_last_signed_in_at = DateTime.Parse((string) json[nameof (target_player_last_signed_in_at)]);
      this.leader_unit = json[nameof (leader_unit)] != null ? new PlayerUnit((Dictionary<string, object>) json[nameof (leader_unit)]) : (PlayerUnit) null;
      this.application = (bool) json[nameof (application)];
      this.is_favorite = (bool) json[nameof (is_favorite)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.target_player_name = (string) json[nameof (target_player_name)];
    }
  }
}
