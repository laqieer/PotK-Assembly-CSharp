// Decompiled with JetBrains decompiler
// Type: ItemSortAndFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class ItemSortAndFilter : SortAndFilter
{
  [SerializeField]
  protected ItemSortAndFilter.FILTER_TYPES[] ForceEnableFilterType;
  [SerializeField]
  private ItemSortAndFilterButton[] OrderBtn;
  [SerializeField]
  private ItemSortAndFilterButton[] FilterBtns;
  [SerializeField]
  private ItemSortAndFilterButton[] SortBtns;
  [SerializeField]
  private ItemSortAndFilterButton[] ListBtns;
  [SerializeField]
  private GameObject[] ListObject;
  private Bugu005ItemListMenuBase menuBase;
  private ItemSortAndFilter.ModeTypes modeType;

  public void Initialize(Bugu005ItemListMenuBase menu, bool setUI = false)
  {
    this.menuBase = menu;
    Persist<Persist.ItemSortAndFilterInfo> persist = this.menuBase.GetPersist();
    if (persist != null)
    {
      try
      {
        this.menuBase.SortCategory = persist.Data.sortType;
        if (!((IEnumerable<ItemSortAndFilterButton>) this.SortBtns).Any<ItemSortAndFilterButton>((Func<ItemSortAndFilterButton, bool>) (x => x.SortType == this.menuBase.SortCategory)))
          this.menuBase.SortCategory = this.SortBtns[0].SortType;
        this.menuBase.OrderBuySort = persist.Data.order;
        bool flag = this.FilterBtns == null || this.FilterBtns.Length == 0;
        for (int index = 0; index < 27; ++index)
          this.menuBase.Filter.SetValue((object) flag, index);
        if (this.ForceEnableFilterType != null && this.ForceEnableFilterType.Length > 0)
        {
          foreach (int index in this.ForceEnableFilterType)
            this.menuBase.Filter.SetValue((object) true, index);
        }
        foreach (ItemSortAndFilterButton filterBtn in this.FilterBtns)
          this.menuBase.Filter.SetValue((object) persist.Data.filter[(int) filterBtn.FilterType], (int) filterBtn.FilterType);
      }
      catch
      {
        persist.Delete();
        this.menuBase.SortCategory = this.SortBtns[0].SortType;
        this.menuBase.OrderBuySort = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING;
        foreach (ItemSortAndFilterButton filterBtn in this.FilterBtns)
          this.menuBase.Filter.SetValue((object) true, (int) filterBtn.FilterType);
      }
    }
    else
    {
      this.menuBase.SortCategory = ItemSortAndFilter.SORT_TYPES.BranchOfWeapon;
      this.menuBase.OrderBuySort = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING;
      for (int index = 0; index < 27; ++index)
        this.menuBase.Filter.SetValue((object) true, index);
    }
    if (!setUI)
      return;
    this.SetOrderTypeBtn();
    ItemSortAndFilterButton sortAndFilterButton1 = ((IEnumerable<ItemSortAndFilterButton>) this.FilterBtns).FirstOrDefault<ItemSortAndFilterButton>((Func<ItemSortAndFilterButton, bool>) (x => x.FilterType == ItemSortAndFilter.FILTER_TYPES.ElementLight));
    ItemSortAndFilterButton sortAndFilterButton2 = ((IEnumerable<ItemSortAndFilterButton>) this.FilterBtns).FirstOrDefault<ItemSortAndFilterButton>((Func<ItemSortAndFilterButton, bool>) (x => x.FilterType == ItemSortAndFilter.FILTER_TYPES.ElementDark));
    if (Object.op_Inequality((Object) sortAndFilterButton1, (Object) null) && Object.op_Inequality((Object) sortAndFilterButton2, (Object) null))
    {
      ((Component) sortAndFilterButton1).gameObject.SetActive(false);
      ((Component) sortAndFilterButton2).gameObject.SetActive(false);
      if (Player.Current.IsEnableDarkAndHoly())
      {
        ((Component) sortAndFilterButton1).gameObject.SetActive(true);
        ((Component) sortAndFilterButton2).gameObject.SetActive(true);
      }
    }
    this.SetValueWindow();
    this.SetListTypeBtn(persist.Data.modeType);
  }

  private void SetOrderTypeBtn()
  {
    if (this.menuBase.OrderBuySort == SortAndFilter.SORT_TYPE_ORDER_BUY.DESCENDING)
    {
      this.OrderBtn[1].SpriteColorGray(true);
      this.OrderBtn[1].TextColorGray(true);
      this.OrderBtn[0].SpriteColorGray(false);
      this.OrderBtn[0].TextColorGray(false);
    }
    else
    {
      this.OrderBtn[1].SpriteColorGray(false);
      this.OrderBtn[1].TextColorGray(false);
      this.OrderBtn[0].SpriteColorGray(true);
      this.OrderBtn[0].TextColorGray(true);
    }
  }

  public void SetValueWindow()
  {
    foreach (ItemSortAndFilterButton sortBtn in this.SortBtns)
    {
      sortBtn.SpriteColorGray(false);
      sortBtn.TextColorGray(false);
      if (sortBtn.SortType == this.menuBase.SortCategory)
      {
        sortBtn.SpriteColorGray(true);
        sortBtn.TextColorGray(true);
      }
    }
    foreach (ItemSortAndFilterButton filterBtn in this.FilterBtns)
    {
      if (!Object.op_Equality((Object) filterBtn, (Object) null))
      {
        filterBtn.SpriteColorGray(false);
        filterBtn.TextColorGray(false);
        if (this.menuBase.Filter[(int) filterBtn.FilterType])
        {
          filterBtn.SpriteColorGray(true);
          filterBtn.TextColorGray(true);
        }
      }
    }
  }

  private void SetListTypeBtn(ItemSortAndFilter.ModeTypes mode)
  {
    if (Object.op_Inequality((Object) this.ListBtns[0], (Object) null) && Object.op_Inequality((Object) this.ListBtns[1], (Object) null))
    {
      this.modeType = mode;
      ((IEnumerable<GameObject>) this.ListObject).ToggleOnceEx((int) this.modeType);
      if (mode == ItemSortAndFilter.ModeTypes.Sort)
      {
        this.ListBtns[0].SpriteColorGray(true);
        this.ListBtns[0].TextColorGray(true);
        this.ListBtns[1].SpriteColorGray(false);
        this.ListBtns[1].TextColorGray(false);
      }
      else
      {
        this.ListBtns[0].SpriteColorGray(false);
        this.ListBtns[0].TextColorGray(false);
        this.ListBtns[1].SpriteColorGray(true);
        this.ListBtns[1].TextColorGray(true);
      }
    }
    else
    {
      this.modeType = ItemSortAndFilter.ModeTypes.Sort;
      ((IEnumerable<GameObject>) this.ListObject).ToggleOnceEx((int) this.modeType);
    }
  }

  public void SetSortCategory(ItemSortAndFilter.SORT_TYPES type)
  {
    this.menuBase.SortCategory = type;
    this.SetValueWindow();
  }

  public void SetFilterType(ItemSortAndFilter.FILTER_TYPES type, bool flg)
  {
    this.menuBase.Filter[(int) type] = flg;
    this.SetValueWindow();
  }

  public void IbtnSortBtn() => this.SetListTypeBtn(ItemSortAndFilter.ModeTypes.Sort);

  public void IbtnFilterBtn() => this.SetListTypeBtn(ItemSortAndFilter.ModeTypes.Filter);

  public override void IbtnDicision()
  {
    this.SaveData();
    if (Object.op_Inequality((Object) this.menuBase, (Object) null))
      this.menuBase.Sort(this.menuBase.SortCategory, this.menuBase.OrderBuySort);
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void IbtnOrder()
  {
    this.menuBase.OrderBuySort = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING;
    this.SetOrderTypeBtn();
  }

  public override void IbtnOrderDec()
  {
    this.menuBase.OrderBuySort = SortAndFilter.SORT_TYPE_ORDER_BUY.DESCENDING;
    this.SetOrderTypeBtn();
  }

  public override void SaveData()
  {
    Persist<Persist.ItemSortAndFilterInfo> persist = this.menuBase.GetPersist();
    if (persist == null)
      return;
    persist.Data.order = this.menuBase.OrderBuySort;
    persist.Data.sortType = this.menuBase.SortCategory;
    persist.Data.modeType = this.modeType;
    for (int index = 0; index < 27; ++index)
    {
      if (index < persist.Data.filter.Count)
        persist.Data.filter[index] = this.menuBase.Filter[index];
      else
        persist.Data.filter.Add(this.menuBase.Filter[index]);
    }
    persist.Flush();
  }

  public override void IbtnAllSelect()
  {
    for (int index = 0; index < this.FilterBtns.Length; ++index)
      this.menuBase.Filter[(int) this.FilterBtns[index].FilterType] = true;
    if (this.ForceEnableFilterType != null && this.ForceEnableFilterType.Length > 0)
    {
      foreach (int index in this.ForceEnableFilterType)
        this.menuBase.Filter[index] = true;
    }
    this.SetValueWindow();
  }

  public override void IbtnClear()
  {
    for (int index = 0; index < 27; ++index)
      this.menuBase.Filter[index] = false;
    this.SetValueWindow();
  }

  public static UISprite SortSpriteLabel(ItemSortAndFilter.SORT_TYPES type, UISprite SortSprite)
  {
    string str = ItemSortAndFilter.SetSortLabelSpriteName(type);
    if (!string.IsNullOrEmpty(str))
    {
      string name = string.Format("slc_button_text_{0}_22pt.png__GUI__button_text__button_text_prefab", (object) str);
      UISpriteData sprite = SortSprite.atlas.GetSprite(name);
      if (sprite == null)
        return SortSprite;
      SortSprite.spriteName = name;
      ((Component) SortSprite).GetComponent<UIWidget>().SetDimensions(sprite.width, sprite.height);
    }
    return SortSprite;
  }

  private static string SetSortLabelSpriteName(ItemSortAndFilter.SORT_TYPES type)
  {
    string str = string.Empty;
    switch (type)
    {
      case ItemSortAndFilter.SORT_TYPES.BranchOfWeapon:
        str = "weapontype";
        break;
      case ItemSortAndFilter.SORT_TYPES.Attribute:
        str = "element";
        break;
      case ItemSortAndFilter.SORT_TYPES.Rarity:
        str = "sort_rare";
        break;
      case ItemSortAndFilter.SORT_TYPES.Rank:
        str = "rank";
        break;
      case ItemSortAndFilter.SORT_TYPES.RankMax:
        str = "maximumrank";
        break;
      case ItemSortAndFilter.SORT_TYPES.GetOrder:
        str = "sort_obtaining";
        break;
      case ItemSortAndFilter.SORT_TYPES.Category:
        str = "sort_categoly";
        break;
    }
    return str;
  }

  public enum ModeTypes
  {
    Sort,
    Filter,
  }

  public enum SORT_TYPES
  {
    None,
    BranchOfWeapon,
    Attribute,
    Rarity,
    Rank,
    RankMax,
    Favorite,
    GetOrder,
    Category,
  }

  public enum FILTER_TYPES
  {
    None,
    WeaponSword,
    WeaponAxe,
    WeaponSpear,
    WeaponBow,
    WeaponGun,
    WeaponStaff,
    WeaponShield,
    WeaponAccessories,
    WeaponSmith,
    ElementNone,
    ElementFire,
    ElementWind,
    ElementThunder,
    ElementIce,
    ElementLight,
    ElementDark,
    Rare1,
    Rare2,
    Rare3,
    Rare4,
    Rare5,
    Rare6,
    Money,
    Weapon,
    Favorite,
    Alchemist,
    Max,
  }
}
