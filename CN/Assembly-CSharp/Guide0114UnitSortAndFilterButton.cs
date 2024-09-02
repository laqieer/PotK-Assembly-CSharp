// Decompiled with JetBrains decompiler
// Type: Guide0114UnitSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class Guide0114UnitSortAndFilterButton : GuideSortAndFilterButton
{
  public Guide0114UnitSortAndFilter menu;
  public Guide0114UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY categoryID;
  public GuideSortAndFilter.GUIDE_GEAR_CATEGORY_TYPE gearCategory;

  public override void PressButton()
  {
    switch (this.categoryID)
    {
      case Guide0114UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.GEAR:
        this.menu.IbtnFilter<GearKindEnum>(this.menu.GearKindEnumList, this.gearKindEnum, (SortAndFilterButton) this);
        break;
      case Guide0114UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.CATEGORY:
        this.menu.IbtnFilter<GuideSortAndFilter.GUIDE_GEAR_CATEGORY_TYPE>(this.menu.GearCategoryList, this.gearCategory, (SortAndFilterButton) this);
        break;
      case Guide0114UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.SORT1:
        this.menu.IbtnSortType(this.sort1);
        break;
      case Guide0114UnitSortAndFilter.GUIDE_UNIT_SORT_FILTER_CATEGORY.SORT2:
        this.menu.IbtnOrderBuySort(this.orderBuySort);
        break;
    }
  }
}
