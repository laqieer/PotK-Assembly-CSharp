﻿// Decompiled with JetBrains decompiler
// Type: Guide0112UnitSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;

public class Guide0112UnitSortAndFilterButton : GuideSortAndFilterButton
{
  public Guide0112UnitSortAndFilter menu;
  public Guide0112UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY categoryID;
  public GuideSortAndFilter.GUIDE_CATEGORY_TYPE unitCategory;
  public UnitFamilyOrNull unitFamilyOrNull;

  public override void PressButton()
  {
    switch (this.categoryID)
    {
      case Guide0112UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.GEAR:
        this.menu.IbtnFilter<GearKindEnum>(this.menu.gearKindEnumList, this.gearKindEnum, (SortAndFilterButton) this);
        break;
      case Guide0112UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.SUICIDE:
        this.menu.IbtnFilter<int>(this.menu.unitFamilyOrNullList, this.unitFamilyOrNull.GetFamily(), (SortAndFilterButton) this);
        break;
      case Guide0112UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.CATEGORY:
        this.menu.IbtnFilter<GuideSortAndFilter.GUIDE_CATEGORY_TYPE>(this.menu.unitCategoryList, this.unitCategory, (SortAndFilterButton) this);
        break;
      case Guide0112UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.SORT1:
        this.menu.IbtnSortType(this.sort1);
        break;
      case Guide0112UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.SORT2:
        this.menu.IbtnOrderBuySort(this.orderBuySort);
        break;
    }
  }
}
