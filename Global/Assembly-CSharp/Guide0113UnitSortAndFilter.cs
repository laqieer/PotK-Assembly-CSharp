﻿// Decompiled with JetBrains decompiler
// Type: Guide0113UnitSortAndFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Guide0113UnitSortAndFilter : GuideSortAndFilter
{
  public List<GuideSortAndFilterButton> dir_fil1 = new List<GuideSortAndFilterButton>();
  public List<GuideSortAndFilterButton> dir_fil2 = new List<GuideSortAndFilterButton>();
  public List<GuideSortAndFilterButton> dir_sort = new List<GuideSortAndFilterButton>();
  public List<GuideSortAndFilterButton> dir_sort_on = new List<GuideSortAndFilterButton>();
  public List<GearKindEnum> gearKindEnumList = new List<GearKindEnum>();
  public List<int> unitFamilyOrNullList = new List<int>();

  public override void Initialize(System.Action SortAction)
  {
    base.Initialize(SortAction);
    try
    {
      this.gearKindEnumList = new List<GearKindEnum>((IEnumerable<GearKindEnum>) Persist.guidEnemySortAndFilter.Data.gearKindEnumList);
    }
    catch (Exception ex)
    {
      Persist.guidGearSortAndFilter.Delete();
      this.gearKindEnumList = new List<GearKindEnum>((IEnumerable<GearKindEnum>) Persist.guidEnemySortAndFilter.Data.gearKindEnumList);
    }
    try
    {
      this.unitFamilyOrNullList = new List<int>((IEnumerable<int>) Persist.guidEnemySortAndFilter.Data.unitFamilyOrNullList);
    }
    catch (Exception ex)
    {
      Persist.guidGearSortAndFilter.Delete();
      this.unitFamilyOrNullList = new List<int>((IEnumerable<int>) Persist.guidEnemySortAndFilter.Data.unitFamilyOrNullList);
    }
    try
    {
      this.sortType = Persist.guidEnemySortAndFilter.Data.sortType;
    }
    catch (Exception ex)
    {
      Persist.guidGearSortAndFilter.Delete();
      this.sortType = Persist.guidEnemySortAndFilter.Data.sortType;
    }
    try
    {
      this.orderBuySort = Persist.guidEnemySortAndFilter.Data.orderBuySort;
    }
    catch (Exception ex)
    {
      Persist.guidGearSortAndFilter.Delete();
      this.orderBuySort = Persist.guidEnemySortAndFilter.Data.orderBuySort;
    }
    this.SetValueWindow();
  }

  public void SetValueWindow()
  {
    foreach (Guide0113UnitSortAndFilterButton button in this.dir_fil1)
      this.GrayCheck<GearKindEnum>(this.gearKindEnumList, button.gearKindEnum, (SortAndFilterButton) button);
    foreach (Guide0113UnitSortAndFilterButton button in this.dir_fil2)
      this.GrayCheck<int>(this.unitFamilyOrNullList, button.unitFamilyOrNull.GetFamily(), (SortAndFilterButton) button);
    this.IbtnSortType(this.sortType);
    this.IbtnOrderBuySort(this.orderBuySort);
  }

  public void IbtnSortType(GuideSortAndFilter.GUIDE_SORT_TYPE sort)
  {
    this.sortType = sort;
    foreach (Component component in this.dir_sort)
      component.gameObject.SetActive(true);
    foreach (Component component in this.dir_sort_on)
      component.gameObject.SetActive(false);
    ((Component) this.dir_sort_on[(int) this.sortType]).gameObject.SetActive(true);
  }

  public override void IbtnClear()
  {
    this.gearKindEnumList.Clear();
    this.unitFamilyOrNullList.Clear();
    this.SetValueWindow();
  }

  public override void IbtnDicision()
  {
    this.SaveData();
    if (this.sortAction != null)
      this.sortAction();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void SaveData()
  {
    Persist.guidEnemySortAndFilter.Data.gearKindEnumList = this.gearKindEnumList;
    Persist.guidEnemySortAndFilter.Data.unitFamilyOrNullList = this.unitFamilyOrNullList;
    Persist.guidEnemySortAndFilter.Data.sortType = this.sortType;
    Persist.guidEnemySortAndFilter.Data.orderBuySort = this.orderBuySort;
    Persist.guidEnemySortAndFilter.Flush();
  }

  public enum GUIDE_UNIT_SORT_FILTER_CATEGORY
  {
    GEAR,
    SUICIDE,
    SORT1,
    SORT2,
  }
}
