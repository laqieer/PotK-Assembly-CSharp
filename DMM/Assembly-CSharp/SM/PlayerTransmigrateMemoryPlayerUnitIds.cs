// Decompiled with JetBrains decompiler
// Type: SM.PlayerTransmigrateMemoryPlayerUnitIds
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;

namespace SM
{
  [Serializable]
  public class PlayerTransmigrateMemoryPlayerUnitIds : KeyCompare
  {
    public int?[] transmigrate_memory_player_unit_ids;

    public PlayerTransmigrateMemoryPlayerUnitIds()
    {
    }

    public PlayerTransmigrateMemoryPlayerUnitIds(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.transmigrate_memory_player_unit_ids = ((IEnumerable<object>) json[nameof (transmigrate_memory_player_unit_ids)]).Select<object, int?>((Func<object, int?>) (s =>
      {
        long? nullable = (long?) s;
        return !nullable.HasValue ? new int?() : new int?((int) nullable.GetValueOrDefault());
      })).ToArray<int?>();
    }

    public static PlayerTransmigrateMemoryPlayerUnitIds Current => SMManager.Get<PlayerTransmigrateMemoryPlayerUnitIds>();

    public void AddMemoryData(PlayerUnit playerUnit)
    {
      PlayerUnitTransMigrateMemoryListTransmigrate_memory[] transmigrateMemoryArray = PlayerUnitTransMigrateMemoryList.Current != null ? PlayerUnitTransMigrateMemoryList.Current.transmigrate_memory : new PlayerUnitTransMigrateMemoryListTransmigrate_memory[0];
      int? nullable = ((IEnumerable<PlayerUnitTransMigrateMemoryListTransmigrate_memory>) transmigrateMemoryArray).FirstIndexOrNull<PlayerUnitTransMigrateMemoryListTransmigrate_memory>((Func<PlayerUnitTransMigrateMemoryListTransmigrate_memory, bool>) (x => x.player_unit_id == playerUnit.id));
      if (!nullable.HasValue)
        return;
      playerUnit.SetMemoryData(transmigrateMemoryArray[nullable.Value]);
    }

    public List<PlayerUnit> PlayerUnits()
    {
      PlayerUnit[] playerUnitArray = SMManager.Get<PlayerUnit[]>();
      List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
      PlayerUnitTransMigrateMemoryListTransmigrate_memory[] transmigrateMemoryArray = PlayerUnitTransMigrateMemoryList.Current != null ? PlayerUnitTransMigrateMemoryList.Current.transmigrate_memory : new PlayerUnitTransMigrateMemoryListTransmigrate_memory[0];
      for (int index = 0; index < this.transmigrate_memory_player_unit_ids.Length; ++index)
      {
        int? x = this.transmigrate_memory_player_unit_ids[index];
        int? nullable1 = ((IEnumerable<PlayerUnit>) playerUnitArray).FirstIndexOrNull<PlayerUnit>((Func<PlayerUnit, bool>) (y =>
        {
          int id = y.id;
          int? nullable = x;
          int valueOrDefault = nullable.GetValueOrDefault();
          return id == valueOrDefault & nullable.HasValue;
        }));
        int? nullable3 = ((IEnumerable<PlayerUnitTransMigrateMemoryListTransmigrate_memory>) transmigrateMemoryArray).FirstIndexOrNull<PlayerUnitTransMigrateMemoryListTransmigrate_memory>((Func<PlayerUnitTransMigrateMemoryListTransmigrate_memory, bool>) (y =>
        {
          int playerUnitId = y.player_unit_id;
          int? nullable = x;
          int valueOrDefault = nullable.GetValueOrDefault();
          return playerUnitId == valueOrDefault & nullable.HasValue;
        }));
        if (nullable1.HasValue && nullable3.HasValue)
        {
          playerUnitArray[nullable1.Value].SetMemoryData(transmigrateMemoryArray[nullable3.Value]);
          playerUnitList.Add(playerUnitArray[nullable1.Value]);
        }
        else
          playerUnitList.Add((PlayerUnit) null);
      }
      return playerUnitList;
    }
  }
}
