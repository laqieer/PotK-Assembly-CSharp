// Decompiled with JetBrains decompiler
// Type: InventoryItemExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public static class InventoryItemExtension
{
  public static InventoryItem FindByItem(this List<InventoryItem> xs, PlayerItem item)
  {
    foreach (InventoryItem byItem in xs)
    {
      if (byItem.Item == item)
        return byItem;
    }
    Debug.LogError((object) ("NOT FOUND ID:" + (object) item.id));
    return (InventoryItem) null;
  }

  public static void Check(this List<InventoryItem> xs)
  {
    foreach (InventoryItem inventoryItem in xs)
      Debug.LogWarning((object) ("------SelectFlag[" + (object) inventoryItem.select + "]--------ID:" + (object) inventoryItem.Item.id + "--------Index:" + (object) inventoryItem.index + "--------slCount:" + (object) inventoryItem.selectCount));
  }

  public static List<InventoryItem> Copy(this List<InventoryItem> xs)
  {
    Debug.LogWarning((object) nameof (Copy));
    return xs.Select<InventoryItem, InventoryItem>((Func<InventoryItem, InventoryItem>) (x => x.Copy())).ToList<InventoryItem>();
  }

  public static void RestoreSelectData(this List<InventoryItem> xs, List<InventoryItem> itemList)
  {
    foreach (InventoryItem inventoryItem1 in itemList)
    {
      foreach (InventoryItem inventoryItem2 in xs)
      {
        if (inventoryItem2.Item == inventoryItem1.Item)
          inventoryItem2.select = inventoryItem1.select;
      }
    }
  }

  public static List<PlayerItem> ToPlayerItemList(this List<InventoryItem> xs)
  {
    List<PlayerItem> playerItemList = new List<PlayerItem>();
    foreach (InventoryItem inventoryItem in xs)
      playerItemList.Add(inventoryItem.Item);
    return playerItemList;
  }

  public static void GrayReverseComposite(this List<InventoryItem> xs)
  {
    foreach (InventoryItem inventoryItem in xs)
    {
      if (!inventoryItem.Item.favorite && !inventoryItem.Item.ForBattle && !inventoryItem.Item.broken)
        inventoryItem.Gray = !inventoryItem.Gray;
    }
  }

  public static void GrayReverseDrilling(
    this List<InventoryItem> xs,
    Func<PlayerItem, bool> checkFunk)
  {
    foreach (InventoryItem inventoryItem in xs)
    {
      if (!inventoryItem.Item.favorite && !inventoryItem.Item.ForBattle && !inventoryItem.Item.broken && checkFunk(inventoryItem.Item))
        inventoryItem.Gray = !inventoryItem.Gray;
    }
  }

  public static void GrayReverseSell(this List<InventoryItem> xs)
  {
    foreach (InventoryItem inventoryItem in xs)
    {
      if (!inventoryItem.Item.favorite && !inventoryItem.Item.ForBattle)
        inventoryItem.Gray = !inventoryItem.Gray;
    }
  }

  public static void GrayReverseAll(this List<InventoryItem> xs)
  {
    foreach (InventoryItem inventoryItem in xs)
      inventoryItem.Gray = !inventoryItem.Gray;
  }

  public static List<int> ToGearId(this List<InventoryItem> xs)
  {
    List<int> gearId = new List<int>();
    foreach (InventoryItem inventoryItem in xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item._entity_type == 3)))
    {
      if (inventoryItem.selectIDS == null || inventoryItem.selectIDS.Length == 0)
        gearId.Add(inventoryItem.Item.id);
      else
        gearId.AddRange(((IEnumerable<int>) inventoryItem.selectIDS).Take<int>(inventoryItem.selectCount));
    }
    return gearId;
  }

  public static List<int> ToEntityIdBySupply(this List<InventoryItem> xs)
  {
    IEnumerable<InventoryItem> inventoryItems = xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item._entity_type == 2));
    List<int> entityIdBySupply = new List<int>();
    foreach (InventoryItem inventoryItem in inventoryItems)
      entityIdBySupply.Add(inventoryItem.Item.entity_id);
    return entityIdBySupply;
  }

  public static List<int> ToSelectQuantity(this List<InventoryItem> xs)
  {
    IEnumerable<InventoryItem> inventoryItems = xs.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item._entity_type == 2));
    List<int> selectQuantity = new List<int>();
    foreach (InventoryItem inventoryItem in inventoryItems)
      selectQuantity.Add(inventoryItem.selectCount);
    return selectQuantity;
  }

  public static List<InventoryItem> InventoryUpdate(
    this List<InventoryItem> xs,
    PlayerItem[] result)
  {
    List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    foreach (InventoryItem inventoryItem in xs)
    {
      InventoryItem s = inventoryItem;
      PlayerItem playerItem = ((IEnumerable<PlayerItem>) result).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x == s.Item)).FirstOrDefault<PlayerItem>();
      if (playerItem != (PlayerItem) null)
        inventoryItemList.Add(new InventoryItem(playerItem)
        {
          select = false,
          selectCount = 0,
          Gray = playerItem.favorite || playerItem.ForBattle,
          index = 0
        });
    }
    return inventoryItemList;
  }

  public static void PlayerItemUpdate(this List<InventoryItem> xs, List<InventoryItem> newItems)
  {
    foreach (InventoryItem inventoryItem1 in xs)
    {
      InventoryItem s = inventoryItem1;
      InventoryItem inventoryItem2 = newItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item == s.Item)).FirstOrDefault<InventoryItem>();
      if (inventoryItem2 != null)
        s.Item = inventoryItem2.Item;
    }
  }

  public static IEnumerable<InventoryItem> SortBy(
    this IEnumerable<InventoryItem> self,
    ItemIcon.Sort sortLabel)
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
    List<InventoryItem> list;
    switch (sortLabel)
    {
      case ItemIcon.Sort.RARITY:
        list = source.OrderByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? 0 : x.Item.gear.rarity.index)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>();
        break;
      case ItemIcon.Sort.GETORDER:
        list = source.OrderByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.id)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.ID)).ToList<InventoryItem>();
        break;
      case ItemIcon.Sort.CATEGORY:
        list = source.OrderByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item._entity_type)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.resource_reference_gear_id_GearGear)).ToList<InventoryItem>();
        break;
      case ItemIcon.Sort.FAVORITE:
        list = source.OrderByDescending<InventoryItem, bool>((Func<InventoryItem, bool>) (x => x.Item.favorite)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? 999 : x.Item.gear.kind_GearKind)).ThenByDescending<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? 0 : x.Item.gear.rarity.index)).ThenBy<InventoryItem, int>((Func<InventoryItem, int>) (x => x.Item.gear == null ? x.Item.supply.ID : x.Item.gear.resource_reference_gear_id_GearGear)).ToList<InventoryItem>();
        break;
      default:
        throw new Exception();
    }
    if (inventoryItem1 != null)
      list.Insert(0, inventoryItem1);
    return (IEnumerable<InventoryItem>) list;
  }
}
