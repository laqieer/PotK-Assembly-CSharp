// Decompiled with JetBrains decompiler
// Type: GuideSortAndFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class GuideSortAndFilter : SortAndFilter
{
  public GuideSortAndFilter.GUIDE_SORT_TYPE sortType = GuideSortAndFilter.GUIDE_SORT_TYPE.NUMBER;
  public GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE orderBuySort = GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE.BACK;
  public List<SortAndFilterButton> dir_orderBuySort = new List<SortAndFilterButton>();

  public void IbtnOrderBuySort(GuideSortAndFilter.GUIDE_ORDER_BUY_SORT_TYPE sort)
  {
    this.orderBuySort = sort;
    foreach (Component component in this.dir_orderBuySort)
      component.gameObject.SetActive(true);
    ((Component) this.dir_orderBuySort[(int) this.orderBuySort]).gameObject.SetActive(false);
  }

  public enum GUIDE_CATEGORY_TYPE
  {
    HIME,
    SINKA,
    TOUGOU,
    TENSEI,
  }

  public enum GUIDE_GEAR_CATEGORY_TYPE
  {
    GEAR,
    TOUGOU,
    OTHER,
  }

  public enum GUIDE_SORT_TYPE
  {
    NEW,
    RARE,
    NUMBER,
  }

  public enum GUIDE_ORDER_BUY_SORT_TYPE
  {
    FORWARD,
    BACK,
  }
}
