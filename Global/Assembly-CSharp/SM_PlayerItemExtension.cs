// Decompiled with JetBrains decompiler
// Type: SM_PlayerItemExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_PlayerItemExtension
{
  public static PlayerItem[] AllGears(this PlayerItem[] self, Player player)
  {
    return ((IEnumerable<PlayerItem>) self).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.player_id == player.id && x.entity_type == MasterDataTable.CommonRewardType.gear)).ToArray<PlayerItem>();
  }

  public static PlayerItem[] AllGearsWithEquip(this PlayerItem[] self)
  {
    Player player = SMManager.Get<Player>();
    return ((IEnumerable<PlayerItem>) self).Where<PlayerItem>((Func<PlayerItem, bool>) (pi => pi.gear != null && pi.player_id == player.id)).ToArray<PlayerItem>();
  }

  public static PlayerItem[] AllGears(this PlayerItem[] self)
  {
    return ((IEnumerable<PlayerItem>) self).Where<PlayerItem>((Func<PlayerItem, bool>) (pi => !pi.ForBattle && pi.gear != null)).ToArray<PlayerItem>();
  }

  public static PlayerItem[] AllSupplies(this PlayerItem[] self)
  {
    return ((IEnumerable<PlayerItem>) self).Where<PlayerItem>((Func<PlayerItem, bool>) (pi => !pi.ForBattle && pi.supply != null)).ToArray<PlayerItem>();
  }

  public static PlayerItem[] AllBattleSupplies(this PlayerItem[] self)
  {
    return ((IEnumerable<PlayerItem>) self).Where<PlayerItem>((Func<PlayerItem, bool>) (pi => pi.ForBattle && pi.supply != null)).ToArray<PlayerItem>();
  }

  public static int AmountHavingTargetItem(
    this PlayerItem[] self,
    int entity_id,
    MasterDataTable.CommonRewardType entity_type)
  {
    int ret = 0;
    if (entity_type == MasterDataTable.CommonRewardType.gear)
      ((IEnumerable<PlayerItem>) ((IEnumerable<PlayerItem>) self).Where<PlayerItem>((Func<PlayerItem, bool>) (pi => pi.gear != null && pi.gear.ID == entity_id)).ToArray<PlayerItem>()).ForEach<PlayerItem>((Action<PlayerItem>) (ar => ret += ar.quantity));
    if (entity_type == MasterDataTable.CommonRewardType.supply)
      ((IEnumerable<PlayerItem>) ((IEnumerable<PlayerItem>) self).Where<PlayerItem>((Func<PlayerItem, bool>) (pi => pi.supply != null && pi.supply.ID == entity_id)).ToArray<PlayerItem>()).ForEach<PlayerItem>((Action<PlayerItem>) (ar => ret += ar.quantity));
    return ret;
  }
}
