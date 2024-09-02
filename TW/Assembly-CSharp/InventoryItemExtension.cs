// Decompiled with JetBrains decompiler
// Type: InventoryItemExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class InventoryItemExtension
{
  public static InventoryItem FindByItem(this List<InventoryItem> invItem, GameCore.ItemInfo findItem)
  {
    return invItem.FirstOrDefault<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item != null && x.Item.itemID == findItem.itemID));
  }

  public static InventoryItem FindByItemIndex(this List<InventoryItem> invItem, GameCore.ItemInfo findItem)
  {
    return invItem.FirstOrDefault<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item != null && x.Item.itemID == findItem.itemID && x.Item.sameItemIdx == findItem.sameItemIdx));
  }

  public static List<int> ToGearId(this List<InventoryItem> xs)
  {
    List<int> gearId = new List<int>();
    foreach (InventoryItem inventoryItem in xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemType == GameCore.ItemInfo.ItemType.Gear)))
      gearId.Add(inventoryItem.Item.itemID);
    return gearId;
  }

  public static List<int> ToMaterialId(this List<InventoryItem> xs)
  {
    IEnumerable<InventoryItem> inventoryItems = xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemType == GameCore.ItemInfo.ItemType.Compse || x.Item.itemType == GameCore.ItemInfo.ItemType.Exchangable));
    List<int> materialId = new List<int>();
    foreach (InventoryItem inventoryItem in inventoryItems)
      materialId.Add(inventoryItem.Item.itemID);
    return materialId;
  }

  public static List<int> ToNotSupplyID(this List<InventoryItem> xs)
  {
    List<int> notSupplyId = new List<int>();
    foreach (InventoryItem inventoryItem in xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemType == GameCore.ItemInfo.ItemType.Gear)))
      notSupplyId.Add(inventoryItem.Item.itemID);
    PlayerItem[] source = SMManager.Get<PlayerItem[]>();
    IEnumerable<InventoryItem> inventoryItems = xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemType == GameCore.ItemInfo.ItemType.Compse || x.Item.itemType == GameCore.ItemInfo.ItemType.Exchangable));
    foreach (InventoryItem inventoryItem in inventoryItems)
    {
      InventoryItem s = inventoryItem;
      List<PlayerItem> list = ((IEnumerable<PlayerItem>) source).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear != null && x.gear.ID == s.Item.masterID)).ToList<PlayerItem>();
      for (int index = 0; index < s.selectCount; ++index)
        notSupplyId.Add(list[index].id);
    }
    return notSupplyId;
  }

  public static List<int> ToEntityIdBySupply(this List<InventoryItem> xs)
  {
    IEnumerable<InventoryItem> inventoryItems = xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemType == GameCore.ItemInfo.ItemType.Supply));
    List<int> entityIdBySupply = new List<int>();
    foreach (InventoryItem inventoryItem in inventoryItems)
      entityIdBySupply.Add(inventoryItem.Item.masterID);
    return entityIdBySupply;
  }

  public static List<int> ToSelectQuantityBySupply(this List<InventoryItem> xs)
  {
    IEnumerable<InventoryItem> inventoryItems = xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemType == GameCore.ItemInfo.ItemType.Supply));
    List<int> quantityBySupply = new List<int>();
    foreach (InventoryItem inventoryItem in inventoryItems)
      quantityBySupply.Add(inventoryItem.selectCount);
    return quantityBySupply;
  }

  public static List<int> ToEntityIdByMaterial(this List<InventoryItem> xs)
  {
    IEnumerable<InventoryItem> inventoryItems = xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemType == GameCore.ItemInfo.ItemType.Compse || x.Item.itemType == GameCore.ItemInfo.ItemType.Exchangable));
    List<int> entityIdByMaterial = new List<int>();
    foreach (InventoryItem inventoryItem in inventoryItems)
      entityIdByMaterial.Add(inventoryItem.Item.masterID);
    return entityIdByMaterial;
  }

  public static List<int> ToSelectQuantityByMaterial(this List<InventoryItem> xs)
  {
    IEnumerable<InventoryItem> inventoryItems = xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.itemType == GameCore.ItemInfo.ItemType.Compse || x.Item.itemType == GameCore.ItemInfo.ItemType.Exchangable));
    List<int> quantityByMaterial = new List<int>();
    foreach (InventoryItem inventoryItem in inventoryItems)
      quantityByMaterial.Add(inventoryItem.selectCount);
    return quantityByMaterial;
  }

  private static int GetSortRank(GameCore.ItemInfo item)
  {
    return !item.gear.kind.isEquip || item.gear.disappearance_type_GearDisappearanceType != 0 ? item.gear.kind_GearKind : 0;
  }

  public static IEnumerable<InventoryItem> SortBy(
    this IEnumerable<InventoryItem> self,
    ItemSortAndFilter.SORT_TYPES sortType,
    SortAndFilter.SORT_TYPE_ORDER_BUY order)
  {
    InventoryItem inventoryItem1 = (InventoryItem) null;
    List<InventoryItem> source = new List<InventoryItem>();
    List<InventoryItem> inventoryItemList1 = new List<InventoryItem>();
    foreach (InventoryItem inventoryItem2 in self)
    {
      if (inventoryItem2.removeButton)
        inventoryItem1 = inventoryItem2;
      else
        source.Add(inventoryItem2);
    }
    List<InventoryItem> inventoryItemList2;
    switch (sortType)
    {
      case ItemSortAndFilter.SORT_TYPES.BranchOfWeapon:
        inventoryItemList2 = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<InventoryItem, GameCore.ItemInfo.ItemType>((Func<InventoryItem, GameCore.ItemInfo.ItemType>) (x => x.Item.itemType)).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.resource_reference_gear_id_GearGear)).ToList<InventoryItem>() : source.OrderBy<InventoryItem, GameCore.ItemInfo.ItemType>((Func<InventoryItem, GameCore.ItemInfo.ItemType>) (x => x.Item.itemType)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.resource_reference_gear_id_GearGear)).ToList<InventoryItem>();
        break;
      case ItemSortAndFilter.SORT_TYPES.Attribute:
        inventoryItemList2 = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.isWeapon ? (int) x.Item.gear.GetElement() : int.MaxValue)).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>() : source.OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.isWeapon ? (int) x.Item.gear.GetElement() : int.MaxValue)).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>();
        break;
      case ItemSortAndFilter.SORT_TYPES.Rarity:
        inventoryItemList2 = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? 0 : x.Item.gear.rarity.index)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>() : source.OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? 0 : x.Item.gear.rarity.index)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>();
        break;
      case ItemSortAndFilter.SORT_TYPES.Rank:
        inventoryItemList2 = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? int.MaxValue : InventoryItemExtension.GetSortRank(x.Item))).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gearLevel + x.Item.gearLevelUnLimit)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>() : source.OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? int.MaxValue : InventoryItemExtension.GetSortRank(x.Item))).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gearLevel + x.Item.gearLevelUnLimit)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>();
        break;
      case ItemSortAndFilter.SORT_TYPES.RankMax:
        inventoryItemList2 = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? int.MaxValue : InventoryItemExtension.GetSortRank(x.Item))).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gearLevelLimit)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>() : source.OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? int.MaxValue : InventoryItemExtension.GetSortRank(x.Item))).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gearLevelLimit)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>();
        break;
      case ItemSortAndFilter.SORT_TYPES.Favorite:
        inventoryItemList2 = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderBy<InventoryItem, bool>((Func<InventoryItem, bool>) (x => x.Item.favorite)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? int.MaxValue : x.Item.gear.kind_GearKind)).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? 0 : x.Item.gear.rarity.index)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.resource_reference_gear_id_GearGear)).ToList<InventoryItem>() : source.OrderByDescending<InventoryItem, bool>((Func<InventoryItem, bool>) (x => x.Item.favorite)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? int.MaxValue : x.Item.gear.kind_GearKind)).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? 0 : x.Item.gear.rarity.index)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.resource_reference_gear_id_GearGear)).ToList<InventoryItem>();
        break;
      case ItemSortAndFilter.SORT_TYPES.GetOrder:
        inventoryItemList2 = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.itemID)).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>() : source.OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.itemID)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>();
        break;
      case ItemSortAndFilter.SORT_TYPES.Category:
        inventoryItemList2 = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x =>
        {
          if (x.Item.isWeapon)
            return 0;
          if (x.Item.isCompse)
            return 1;
          return x.Item.isDrilling ? 2 : 3;
        })).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.resource_reference_gear_id_GearGear)).ToList<InventoryItem>() : source.OrderBy<InventoryItem, int>((Func<InventoryItem, int>) (x =>
        {
          if (x.Item.isWeapon)
            return 0;
          if (x.Item.isCompse)
            return 1;
          return x.Item.isDrilling ? 2 : 3;
        })).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.resource_reference_gear_id_GearGear)).ToList<InventoryItem>();
        break;
      default:
        throw new Exception();
    }
    if (inventoryItem1 != null)
      inventoryItemList2.Insert(0, inventoryItem1);
    return (IEnumerable<InventoryItem>) inventoryItemList2;
  }

  public static IEnumerable<InventoryItem> FilterBy(
    this IEnumerable<InventoryItem> self,
    bool[] filters)
  {
    InventoryItem inventoryItem1 = (InventoryItem) null;
    List<InventoryItem> source = new List<InventoryItem>();
    List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    foreach (InventoryItem inventoryItem2 in self)
    {
      if (inventoryItem2.removeButton)
        inventoryItem1 = inventoryItem2;
      else
        source.Add(inventoryItem2);
    }
    List<InventoryItem> list = source.Where<InventoryItem>((Func<InventoryItem, bool>) (x => InventoryItemExtension.CheckWeaponType(x, filters) && InventoryItemExtension.CheckRarity(x, filters) && InventoryItemExtension.CheckGear(x, filters) && InventoryItemExtension.CheckWeaponElement(x, filters) && InventoryItemExtension.CheckFavorite(x, filters))).ToList<InventoryItem>();
    if (inventoryItem1 != null)
      list.Insert(0, inventoryItem1);
    return (IEnumerable<InventoryItem>) list;
  }

  private static bool CheckFavorite(InventoryItem item, bool[] filters)
  {
    bool flag = true;
    return item.Item.favorite ? filters[25] : flag;
  }

  private static bool CheckWeaponType(InventoryItem item, bool[] filters)
  {
    bool flag = false;
    if (item.Item.gear == null)
      return true;
    switch (item.Item.gear.kind.Enum)
    {
      case GearKindEnum.sword:
        flag = filters[1];
        break;
      case GearKindEnum.axe:
        flag = filters[2];
        break;
      case GearKindEnum.spear:
        flag = filters[3];
        break;
      case GearKindEnum.bow:
        flag = filters[4];
        break;
      case GearKindEnum.gun:
        flag = filters[5];
        break;
      case GearKindEnum.staff:
        flag = filters[6];
        break;
      case GearKindEnum.shield:
        flag = filters[7];
        break;
      case GearKindEnum.smith:
        flag = InventoryItemExtension.CheckMoney(item, filters);
        break;
      case GearKindEnum.accessories:
        flag = filters[8];
        break;
      case GearKindEnum.drilling:
      case GearKindEnum.special_drilling:
        flag = filters[26];
        break;
    }
    return flag;
  }

  private static bool CheckMoney(InventoryItem item, bool[] filters)
  {
    return !item.Item.isExchangable ? filters[9] : filters[23];
  }

  private static bool CheckWeaponElement(InventoryItem item, bool[] filters)
  {
    bool flag = false;
    if (item.Item.gear == null)
      return true;
    switch (item.Item.gear.GetElement())
    {
      case CommonElement.none:
        flag = filters[10];
        break;
      case CommonElement.fire:
        flag = filters[11];
        break;
      case CommonElement.wind:
        flag = filters[12];
        break;
      case CommonElement.thunder:
        flag = filters[13];
        break;
      case CommonElement.ice:
        flag = filters[14];
        break;
      case CommonElement.light:
        flag = filters[15];
        break;
      case CommonElement.dark:
        flag = filters[16];
        break;
    }
    return flag;
  }

  private static bool CheckRarity(InventoryItem item, bool[] filters)
  {
    bool flag = false;
    if (item.Item.gear == null)
      return true;
    switch (item.Item.gear.rarity.index)
    {
      case 1:
        flag = filters[17];
        break;
      case 2:
        flag = filters[18];
        break;
      case 3:
        flag = filters[19];
        break;
      case 4:
        flag = filters[20];
        break;
      case 5:
        flag = filters[21];
        break;
      case 6:
        flag = filters[22];
        break;
    }
    return flag;
  }

  private static bool CheckGear(InventoryItem item, bool[] filters)
  {
    bool flag = false;
    if (filters[24] || item.Item.gear == null)
      return true;
    if (!item.Item.gear.kind.isEquip)
      flag = true;
    return flag;
  }
}
