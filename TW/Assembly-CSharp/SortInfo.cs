// Decompiled with JetBrains decompiler
// Type: SortInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class SortInfo
{
  public UnitSortAndFilter.SORT_TYPES sortType = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy;
  public SortAndFilter.SORT_TYPE_ORDER_BUY orderType;
  public bool[] filters;
  public UnitGroupHead groupType = UnitGroupHead.group_all;
  public int groupID = 1;

  public SortInfo(
    UnitSortAndFilter.SORT_TYPES sType,
    SortAndFilter.SORT_TYPE_ORDER_BUY oType,
    bool[] filter,
    UnitGroupHead gType,
    int gID)
  {
    this.sortType = sType;
    this.orderType = oType;
    this.filters = filter;
    this.groupType = gType;
    this.groupID = gID;
  }
}
