﻿// Decompiled with JetBrains decompiler
// Type: Guide0113UnitSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class Guide0113UnitSortAndFilterButton : GuideSortAndFilterButton
{
  public Guide0113UnitSortAndFilter menu;
  public Guide0113UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY categoryID;
  public UnitFamilyOrNull unitFamilyOrNull;

  public override void PressButton()
  {
    switch (this.categoryID)
    {
      case Guide0113UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.GEAR:
        this.menu.IbtnFilter<GearKindEnum>(this.menu.gearKindEnumList, this.gearKindEnum, (SortAndFilterButton) this);
        break;
      case Guide0113UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.SUICIDE:
        this.menu.IbtnFilter<int>(this.menu.unitFamilyOrNullList, this.unitFamilyOrNull.GetFamily(), (SortAndFilterButton) this);
        break;
      case Guide0113UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.SORT1:
        this.menu.IbtnSortType(this.sort1);
        break;
      case Guide0113UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.SORT2:
        this.menu.IbtnOrderBuySort(this.orderBuySort);
        break;
    }
  }
}
