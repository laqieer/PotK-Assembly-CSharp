// Decompiled with JetBrains decompiler
// Type: SM.FriendDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class FriendDetail : KeyCompare
  {
    public int player_current_emblem_id;
    public string player_name;
    public PlayerUnit[] player_units;
    public int player_level;
    public PlayerItem[] player_items;
    public GuildDirectory guild;
    public string player_comment;

    public FriendDetail()
    {
    }

    public FriendDetail(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_current_emblem_id = (int) (long) json[nameof (player_current_emblem_id)];
      this.player_name = (string) json[nameof (player_name)];
      List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
      foreach (object json1 in (List<object>) json[nameof (player_units)])
        playerUnitList.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
      this.player_units = playerUnitList.ToArray();
      this.player_level = (int) (long) json[nameof (player_level)];
      List<PlayerItem> playerItemList = new List<PlayerItem>();
      foreach (object json2 in (List<object>) json[nameof (player_items)])
        playerItemList.Add(json2 != null ? new PlayerItem((Dictionary<string, object>) json2) : (PlayerItem) null);
      this.player_items = playerItemList.ToArray();
      this.guild = json[nameof (guild)] != null ? new GuildDirectory((Dictionary<string, object>) json[nameof (guild)]) : (GuildDirectory) null;
      this.player_comment = (string) json[nameof (player_comment)];
    }
  }
}
