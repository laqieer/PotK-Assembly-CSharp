// Decompiled with JetBrains decompiler
// Type: UnitSortAndFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UnitSortAndFilter : SortAndFilter
{
  private SortAndFilter.SORT_TYPE_ORDER_BUY orderBuySort;
  [SerializeField]
  private GameObject[] ListObject;
  [SerializeField]
  private UnitSortAndFilterButton[] OrderBtn;
  [SerializeField]
  private UnitSortAndFilterButton[] ListBtns;
  [SerializeField]
  private UnitSortAndFilterButton[] SortBtns;
  [SerializeField]
  private UnitSortAndFilterButton[] FilterBtns;
  [SerializeField]
  private GameObject[] DisplayList;
  private readonly float[] ListPositionY = new float[3]
  {
    -48f,
    -118f,
    -188f
  };
  private UnitSortAndFilter.ModeTypes modeType;
  private UnitSortAndFilter.SORT_TYPES sortCategory = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy;
  private bool[] filter = new bool[38];
  private Persist<Persist.UnitSortAndFilterInfo> persist;
  private Action<UnitSortAndFilter.SORT_TYPES, SortAndFilter.SORT_TYPE_ORDER_BUY, bool[]> SortActionExt;

  private void SetOrderTypeBtn()
  {
    if (this.orderBuySort == SortAndFilter.SORT_TYPE_ORDER_BUY.DESCENDING)
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

  private void SetListTypeBtn(UnitSortAndFilter.ModeTypes mode)
  {
    this.modeType = mode;
    ((IEnumerable<GameObject>) this.ListObject).ToggleOnce((int) mode);
    if (mode == UnitSortAndFilter.ModeTypes.Sort)
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

  public void Initialize(
    Action<UnitSortAndFilter.SORT_TYPES, SortAndFilter.SORT_TYPE_ORDER_BUY, bool[]> SortAction,
    Persist<Persist.UnitSortAndFilterInfo> persistData,
    bool normalUnitOnly = false)
  {
    this.persist = persistData;
    this.sortCategory = this.persist.Data.sortType;
    this.orderBuySort = this.persist.Data.order;
    this.SetOrderTypeBtn();
    ((Component) this.FilterBtns[11]).gameObject.SetActive(false);
    ((Component) this.FilterBtns[12]).gameObject.SetActive(false);
    if (Player.Current.IsEnableDarkAndHoly())
    {
      ((Component) this.FilterBtns[11]).gameObject.SetActive(true);
      ((Component) this.FilterBtns[12]).gameObject.SetActive(true);
    }
    if (normalUnitOnly)
    {
      if (this.persist.Data.filter.Count >= 25)
        this.persist.Data.filter[25] = true;
      if (this.persist.Data.filter.Count >= 27)
        this.persist.Data.filter[27] = false;
      if (this.persist.Data.filter.Count >= 26)
        this.persist.Data.filter[26] = false;
      if (this.persist.Data.filter.Count >= 28)
        this.persist.Data.filter[28] = false;
    }
    for (int index = 0; index < 38; ++index)
    {
      if (index < this.persist.Data.filter.Count)
        this.filter[index] = this.persist.Data.filter[index];
      else
        this.filter.SetValue((object) true, index);
    }
    this.SortActionExt = SortAction;
    this.SetValueWindow();
    this.SetListTypeBtn(this.persist.Data.modeType);
    if (normalUnitOnly)
    {
      for (int index = 0; index < this.DisplayList.Length; ++index)
      {
        if (index == 0)
        {
          this.DisplayList[index].SetActive(false);
        }
        else
        {
          this.DisplayList[index].SetActive(true);
          Vector3 localPosition = this.DisplayList[index].transform.localPosition;
          localPosition.y = this.ListPositionY[index - 1];
          this.DisplayList[index].transform.localPosition = localPosition;
        }
      }
    }
    else
    {
      for (int index = 0; index < this.DisplayList.Length; ++index)
      {
        this.DisplayList[index].SetActive(true);
        Vector3 localPosition = this.DisplayList[index].transform.localPosition;
        localPosition.y = this.ListPositionY[index];
        this.DisplayList[index].transform.localPosition = localPosition;
      }
    }
  }

  public void SetValueWindow()
  {
    foreach (UnitSortAndFilterButton sortBtn in this.SortBtns)
    {
      sortBtn.SpriteColorGray(false);
      sortBtn.TextColorGray(false);
      if (sortBtn.SortType == this.sortCategory)
      {
        sortBtn.SpriteColorGray(true);
        sortBtn.TextColorGray(true);
      }
    }
    foreach (UnitSortAndFilterButton filterBtn in this.FilterBtns)
    {
      filterBtn.SpriteColorGray(false);
      filterBtn.TextColorGray(false);
      if (this.filter[(int) filterBtn.FilterType])
      {
        filterBtn.SpriteColorGray(true);
        filterBtn.TextColorGray(true);
      }
    }
  }

  public void IbtnSortBtn() => this.SetListTypeBtn(UnitSortAndFilter.ModeTypes.Sort);

  public void IbtnFilterBtn() => this.SetListTypeBtn(UnitSortAndFilter.ModeTypes.Filter);

  public override void IbtnAllSelect()
  {
    for (int index = 0; index < 38; ++index)
      this.filter[index] = true;
    this.SetValueWindow();
  }

  public override void IbtnClear()
  {
    for (int index = 0; index < 38; ++index)
      this.filter[index] = false;
    this.SetValueWindow();
  }

  public override void IbtnDicision()
  {
    this.SaveData();
    if (this.SortActionExt != null)
      this.SortActionExt(this.sortCategory, this.orderBuySort, this.filter);
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void IbtnOrder()
  {
    this.orderBuySort = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING;
    this.SetOrderTypeBtn();
  }

  public override void IbtnOrderDec()
  {
    this.orderBuySort = SortAndFilter.SORT_TYPE_ORDER_BUY.DESCENDING;
    this.SetOrderTypeBtn();
  }

  public void SetSortCategory(UnitSortAndFilter.SORT_TYPES type)
  {
    this.sortCategory = type;
    this.SetValueWindow();
  }

  public void SetFilterType(UnitSortAndFilter.FILTER_TYPES type, bool flg)
  {
    this.filter[(int) type] = flg;
    this.SetValueWindow();
  }

  public override void SaveData()
  {
    this.persist.Data.order = this.orderBuySort;
    this.persist.Data.sortType = this.sortCategory;
    this.persist.Data.modeType = this.modeType;
    for (int index = 0; index < 38; ++index)
    {
      if (index < this.persist.Data.filter.Count)
        this.persist.Data.filter[index] = this.filter[index];
      else
        this.persist.Data.filter.Add(this.filter[index]);
    }
    this.persist.Flush();
  }

  public enum ModeTypes
  {
    Sort,
    Filter,
  }

  public enum SORT_TYPES
  {
    None,
    BranchOfAnArmy,
    Attribute,
    Level,
    Rarity,
    Cost,
    FightingPower,
    PhysicalAttack,
    MagicAttack,
    Defence,
    MagicDefence,
    Hit,
    Critical,
    Avoid,
    Speed,
    Dexterity,
    Luck,
    WeaponProficiency,
    ArmorProficiency,
    GetOrder,
    HP,
    UnitID,
  }

  public enum FILTER_TYPES
  {
    None,
    WeaponSword,
    WeaponAxe,
    WeaponSpear,
    WeaponBow,
    WeaponGun,
    WeaponRod,
    ElementNone,
    ElementFire,
    ElementIce,
    ElementWind,
    ElementThunder,
    ElementLight,
    ElementDark,
    UnitTypeOuki,
    UnitTypeMeiki,
    UnitTypeKouki,
    UnitTypeMaki,
    UnitTypeSyuki,
    UnitTypeSyouki,
    Rare1,
    Rare2,
    Rare3,
    Rare4,
    Rare5,
    Unit,
    EvolutionUnit,
    ComposeUnit,
    TransmigrationUnit,
    LevelMax,
    OtherLevelMax,
    Equipment,
    NonEquipment,
    NonCompose,
    Compose,
    ComposeComplete,
    Favoritea,
    Rare6,
    Max,
  }

  public enum FILTER_BTN_INDEX
  {
    WeaponSword,
    WeaponAxe,
    WeaponSpear,
    WeaponBow,
    WeaponGun,
    WeaponRod,
    ElementNone,
    ElementFire,
    ElementIce,
    ElementWind,
    ElementThunder,
    ElementLight,
    ElementDark,
    UnitTypeOuki,
    UnitTypeMeiki,
    UnitTypeKouki,
    UnitTypeMaki,
    UnitTypeSyuki,
    UnitTypeSyouki,
    Rare1,
    Rare2,
    Rare3,
    Rare4,
    Rare5,
    Unit,
    EvolutionUnit,
    ComposeUnit,
    TransmigrationUnit,
    LevelMax,
    OtherLevelMax,
    Equipment,
    NonEquipment,
    NonCompose,
    Compose,
    ComposeComplete,
    Favoritea,
    Rare6,
  }
}
