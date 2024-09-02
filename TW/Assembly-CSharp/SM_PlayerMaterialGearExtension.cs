// Decompiled with JetBrains decompiler
// Type: SM_PlayerMaterialGearExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_PlayerMaterialGearExtension
{
  public static PlayerMaterialGear[] AllGears(this PlayerMaterialGear[] self, Player player)
  {
    return ((IEnumerable<PlayerMaterialGear>) self).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (x => x.player_id == player.id && x.entity_type == MasterDataTable.CommonRewardType.material_gear)).ToArray<PlayerMaterialGear>();
  }

  public static PlayerMaterialGear[] AllGearsWithEquip(this PlayerMaterialGear[] self)
  {
    Player player = SMManager.Get<Player>();
    return ((IEnumerable<PlayerMaterialGear>) self).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (pi => pi.gear != null && pi.player_id == player.id)).ToArray<PlayerMaterialGear>();
  }

  public static PlayerMaterialGear[] AllGears(this PlayerMaterialGear[] self)
  {
    return ((IEnumerable<PlayerMaterialGear>) self).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (pi => !pi.ForBattle && pi.gear != null)).ToArray<PlayerMaterialGear>();
  }

  public static PlayerMaterialGear[] AllSupplies(this PlayerMaterialGear[] self)
  {
    return ((IEnumerable<PlayerMaterialGear>) self).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (pi => !pi.ForBattle && pi.supply != null)).ToArray<PlayerMaterialGear>();
  }

  public static PlayerMaterialGear[] AllBattleSupplies(this PlayerMaterialGear[] self)
  {
    return ((IEnumerable<PlayerMaterialGear>) self).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (pi => pi.ForBattle && pi.supply != null)).ToArray<PlayerMaterialGear>();
  }

  public static int AmountHavingTargetItem(this PlayerMaterialGear[] self, int entity_id)
  {
    int ret = 0;
    ((IEnumerable<PlayerMaterialGear>) ((IEnumerable<PlayerMaterialGear>) self).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (pi => pi.gear != null && pi.gear.ID == entity_id)).ToArray<PlayerMaterialGear>()).ForEach<PlayerMaterialGear>((Action<PlayerMaterialGear>) (ar => ret += ar.quantity));
    return ret;
  }
}
