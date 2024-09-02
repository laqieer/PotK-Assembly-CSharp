// Decompiled with JetBrains decompiler
// Type: SM.PlayerDeck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerDeck : KeyCompare
  {
    public int member_limit;
    public int deck_type_id;
    public int?[] player_unit_ids;
    public int cost_limit;
    public int deck_number;

    public PlayerDeck()
    {
    }

    public PlayerDeck(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.member_limit = (int) (long) json[nameof (member_limit)];
      this.deck_type_id = (int) (long) json[nameof (deck_type_id)];
      this.player_unit_ids = ((IEnumerable<object>) json[nameof (player_unit_ids)]).Select<object, int?>((Func<object, int?>) (s =>
      {
        long? nullable = (long?) s;
        return nullable.HasValue ? new int?((int) nullable.Value) : new int?();
      })).ToArray<int?>();
      this.cost_limit = (int) (long) json[nameof (cost_limit)];
      this.deck_number = (int) (long) json[nameof (deck_number)];
    }

    public PlayerUnit[] player_units
    {
      get
      {
        Dictionary<int, PlayerUnit> dic = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).ToDictionary<PlayerUnit, int>((Func<PlayerUnit, int>) (unit => unit.id));
        return ((IEnumerable<int?>) this.player_unit_ids).Select<int?, PlayerUnit>((Func<int?, PlayerUnit>) (id => !id.HasValue ? (PlayerUnit) null : dic[id.Value])).ToArray<PlayerUnit>();
      }
    }

    public int total_combat
    {
      get
      {
        return ((IEnumerable<PlayerUnit>) this.player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (unit => unit != (PlayerUnit) null)).Sum<PlayerUnit>((Func<PlayerUnit, int>) (unit => Judgement.NonBattleParameter.FromPlayerUnit(unit).Combat));
      }
    }

    public int cost
    {
      get
      {
        return ((IEnumerable<PlayerUnit>) this.player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (unit => unit != (PlayerUnit) null)).Sum<PlayerUnit>((Func<PlayerUnit, int>) (unit => unit.unit.cost));
      }
    }
  }
}
