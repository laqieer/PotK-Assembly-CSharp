﻿// Decompiled with JetBrains decompiler
// Type: UnitIconInfoExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class UnitIconInfoExtension
{
  public static IEnumerable<UnitIconInfo> SortBy(
    this IEnumerable<UnitIconInfo> self,
    UnitSortAndFilter.SORT_TYPES type,
    SortAndFilter.SORT_TYPE_ORDER_BUY order)
  {
    UnitIconInfo unitIconInfo1 = (UnitIconInfo) null;
    List<UnitIconInfo> source = new List<UnitIconInfo>();
    List<UnitIconInfo> unitIconInfoList = new List<UnitIconInfo>();
    foreach (UnitIconInfo unitIconInfo2 in self)
    {
      if (unitIconInfo2.removeButton)
        unitIconInfo1 = unitIconInfo2;
      else
        source.Add(unitIconInfo2);
    }
    switch (type)
    {
      case UnitSortAndFilter.SORT_TYPES.None:
        if (unitIconInfo1 != null)
          unitIconInfoList.Insert(0, unitIconInfo1);
        return (IEnumerable<UnitIconInfo>) unitIconInfoList;
      case UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.kind_GearKind)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.kind_GearKind)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Attribute:
        if (order == SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING)
        {
          unitIconInfoList.AddRange((IEnumerable<UnitIconInfo>) source.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (ui => ui.playerUnit.GetElement() != CommonElement.none && ui.for_battle)).OrderBy<UnitIconInfo, CommonElement>((Func<UnitIconInfo, CommonElement>) (ui => ui.playerUnit.GetElement())).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)));
          unitIconInfoList.AddRange((IEnumerable<UnitIconInfo>) source.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (ui => ui.playerUnit.GetElement() == CommonElement.none && ui.for_battle)).OrderBy<UnitIconInfo, CommonElement>((Func<UnitIconInfo, CommonElement>) (ui => ui.playerUnit.GetElement())).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)));
          unitIconInfoList.AddRange((IEnumerable<UnitIconInfo>) source.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (ui => ui.playerUnit.GetElement() != CommonElement.none && !ui.for_battle)).OrderBy<UnitIconInfo, CommonElement>((Func<UnitIconInfo, CommonElement>) (ui => ui.playerUnit.GetElement())).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)));
          unitIconInfoList.AddRange((IEnumerable<UnitIconInfo>) source.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (ui => ui.playerUnit.GetElement() == CommonElement.none && !ui.for_battle)).OrderBy<UnitIconInfo, CommonElement>((Func<UnitIconInfo, CommonElement>) (ui => ui.playerUnit.GetElement())).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)));
          goto case UnitSortAndFilter.SORT_TYPES.None;
        }
        else
        {
          unitIconInfoList.AddRange((IEnumerable<UnitIconInfo>) source.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (ui => ui.playerUnit.GetElement() != CommonElement.none && ui.for_battle)).OrderByDescending<UnitIconInfo, CommonElement>((Func<UnitIconInfo, CommonElement>) (ui => ui.playerUnit.GetElement())).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)));
          unitIconInfoList.AddRange((IEnumerable<UnitIconInfo>) source.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (ui => ui.playerUnit.GetElement() == CommonElement.none && ui.for_battle)).OrderByDescending<UnitIconInfo, CommonElement>((Func<UnitIconInfo, CommonElement>) (ui => ui.playerUnit.GetElement())).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)));
          unitIconInfoList.AddRange((IEnumerable<UnitIconInfo>) source.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (ui => ui.playerUnit.GetElement() != CommonElement.none && !ui.for_battle)).OrderByDescending<UnitIconInfo, CommonElement>((Func<UnitIconInfo, CommonElement>) (ui => ui.playerUnit.GetElement())).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)));
          unitIconInfoList.AddRange((IEnumerable<UnitIconInfo>) source.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (ui => ui.playerUnit.GetElement() == CommonElement.none && !ui.for_battle)).OrderByDescending<UnitIconInfo, CommonElement>((Func<UnitIconInfo, CommonElement>) (ui => ui.playerUnit.GetElement())).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)));
          goto case UnitSortAndFilter.SORT_TYPES.None;
        }
      case UnitSortAndFilter.SORT_TYPES.Level:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Rarity:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.rarity.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.rarity.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Cost:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.cost)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.cost)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.FightingPower:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.combat)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.combat)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.PhysicalAttack:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.PhysicalAttack)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.PhysicalAttack)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.MagicAttack:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.MagicAttack)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.MagicAttack)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Defence:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.PhysicalDefense)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.PhysicalDefense)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.MagicDefence:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.MagicDefense)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.MagicDefense)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Hit:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Hit)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Hit)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Critical:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Critical)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Critical)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Avoid:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Evasion)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Evasion)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Speed:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Agility)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Agility)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Dexterity:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Dexterity)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Dexterity)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.Luck:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Luck)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Luck)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.WeaponProficiency:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.proficiency.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.proficiency.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.ArmorProficiency:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.shildProficiency().ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.shildProficiency().ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.GetOrder:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, DateTime>((Func<UnitIconInfo, DateTime>) (ui => ui.playerUnit.created_at)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.rarity.ID)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, DateTime>((Func<UnitIconInfo, DateTime>) (ui => ui.playerUnit.created_at)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.rarity.ID)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.HP:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Hp)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>() : source.OrderByDescending<UnitIconInfo, bool>((Func<UnitIconInfo, bool>) (ui => ui.for_battle)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.nonbattleParameter.Hp)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ThenBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.level)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      case UnitSortAndFilter.SORT_TYPES.UnitID:
        unitIconInfoList = order != SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING ? source.OrderByDescending<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ToList<UnitIconInfo>() : source.OrderBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.playerUnit.unit.ID)).ToList<UnitIconInfo>();
        goto case UnitSortAndFilter.SORT_TYPES.None;
      default:
        throw new Exception();
    }
  }
}
