// Decompiled with JetBrains decompiler
// Type: CalcItemCost
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public class CalcItemCost
{
  public static int GetSellCost(List<InventoryItem> items)
  {
    int cost = 0;
    items.ForEach((Action<InventoryItem>) (item => cost += item.GetSellPrice()));
    return cost;
  }

  public static int GetCompositeCost(List<InventoryItem> items)
  {
    int totalItemLevel = 0;
    int totalItemRarity = 0;
    int useGears = 0;
    items.ForEach((Action<InventoryItem>) (item =>
    {
      if (item.Item.gear == null)
        return;
      totalItemLevel += item.Item.gear.compose_level;
      totalItemRarity += item.Item.gear.rarity.index;
      ++useGears;
    }));
    if (useGears < 1)
      useGears = 1;
    int index = totalItemRarity / useGears - 1;
    if (index < 0)
      index = 0;
    NGGameDataManager.Boost boostInfo = Singleton<NGGameDataManager>.GetInstance().BoostInfo;
    return (int) ((boostInfo != null ? boostInfo.DiscountGearCombine : 1.0M) * (Decimal) totalItemLevel * 50M * (Decimal) GearRarity.ComposeRatio(index));
  }

  public static float GetNormalDrillingCost(List<InventoryItem> items)
  {
    return items == null || items.Count<InventoryItem>() == 0 ? 0.0f : (float) ((double) items.Sum<InventoryItem>((Func<InventoryItem, int>) (x => x.Item.gear.compose_level)) * 50.0 * ((double) items.Sum<InventoryItem>((Func<InventoryItem, float>) (x => x.Item.gear.rarity.compose_ratio)) / (double) items.Count));
  }

  public static int GetSpecialDrillingCost(GameCore.ItemInfo targetGear, List<InventoryItem> items)
  {
    int specialDrillingCost1 = 0;
    if (items == null || items.Count<InventoryItem>() == 0)
      return specialDrillingCost1;
    GearSpecialDrillingCost specialDrillingCost2 = (GearSpecialDrillingCost) null;
    foreach (GearSpecialDrillingCost specialDrillingCost3 in (IEnumerable<GearSpecialDrillingCost>) ((IEnumerable<GearSpecialDrillingCost>) MasterData.GearSpecialDrillingCostList).OrderBy<GearSpecialDrillingCost, int>((Func<GearSpecialDrillingCost, int>) (x => x.rarity != null ? 0 : 1)))
    {
      if (specialDrillingCost3.level == targetGear.gearLevel && (specialDrillingCost3.rarity == null || specialDrillingCost3.rarity != null && specialDrillingCost3.rarity.index == targetGear.gear.rarity.index))
      {
        specialDrillingCost2 = specialDrillingCost3;
        break;
      }
    }
    return specialDrillingCost2 == null ? ((IEnumerable<GearSpecialDrillingCost>) MasterData.GearSpecialDrillingCostList).OrderByDescending<GearSpecialDrillingCost, int>((Func<GearSpecialDrillingCost, int>) (x => x.price)).First<GearSpecialDrillingCost>().price : specialDrillingCost2.price;
  }

  public static int GetBuildupCost(List<GameCore.ItemInfo> items)
  {
    int buildupCost = 0;
    foreach (GameCore.ItemInfo itemInfo in items)
    {
      GearKindEnum kind = itemInfo.gear.kind.Enum;
      int rank = itemInfo.gearLevel;
      buildupCost += ((IEnumerable<GearBuildup>) MasterData.GearBuildupList).Where<GearBuildup>((Func<GearBuildup, bool>) (x => x.kind.Enum == kind && x.rank == rank)).First<GearBuildup>().amount;
    }
    return buildupCost;
  }
}
