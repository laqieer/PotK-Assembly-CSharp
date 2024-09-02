// Decompiled with JetBrains decompiler
// Type: SM.GvgDeck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class GvgDeck : KeyCompare
  {
    public int member_limit;
    public int?[] player_unit_ids;
    public int cost_limit;
    public PlayerItem[] player_gears;
    public PlayerUnit[] player_units;

    public GvgDeck()
    {
    }

    public GvgDeck(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.member_limit = (int) (long) json[nameof (member_limit)];
      this.player_unit_ids = ((IEnumerable<object>) json[nameof (player_unit_ids)]).Select<object, int?>((Func<object, int?>) (s =>
      {
        long? nullable = (long?) s;
        return nullable.HasValue ? new int?((int) nullable.Value) : new int?();
      })).ToArray<int?>();
      this.cost_limit = (int) (long) json[nameof (cost_limit)];
      List<PlayerItem> playerItemList = new List<PlayerItem>();
      foreach (object json1 in (List<object>) json[nameof (player_gears)])
        playerItemList.Add(json1 != null ? new PlayerItem((Dictionary<string, object>) json1) : (PlayerItem) null);
      this.player_gears = playerItemList.ToArray();
      List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
      foreach (object json2 in (List<object>) json[nameof (player_units)])
        playerUnitList.Add(json2 != null ? new PlayerUnit((Dictionary<string, object>) json2) : (PlayerUnit) null);
      this.player_units = playerUnitList.ToArray();
    }
  }
}
