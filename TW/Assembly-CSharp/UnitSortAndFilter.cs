// Decompiled with JetBrains decompiler
// Type: UnitSortAndFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class UnitSortAndFilter : SortAndFilter
{
  private readonly string[] SortLabelStr = new string[22]
  {
    Consts.GetInstance().SORT_POPUP_LABEL_NONE,
    Consts.GetInstance().SORT_POPUP_LABEL_BRANCHOFANARMY,
    Consts.GetInstance().SORT_POPUP_LABEL_ATTRIBUTE,
    Consts.GetInstance().SORT_POPUP_LABEL_LEVEL,
    Consts.GetInstance().SORT_POPUP_LABEL_RARITY,
    Consts.GetInstance().SORT_POPUP_LABEL_COST,
    Consts.GetInstance().SORT_POPUP_LABEL_FIGHTINGPOWER,
    Consts.GetInstance().SORT_POPUP_LABEL_PHYSICALATTACK,
    Consts.GetInstance().SORT_POPUP_LABEL_MAGICATTACK,
    Consts.GetInstance().SORT_POPUP_LABEL_DEFENCE,
    Consts.GetInstance().SORT_POPUP_LABEL_MAGICDEFENCE,
    Consts.GetInstance().SORT_POPUP_LABEL_HIT,
    Consts.GetInstance().SORT_POPUP_LABEL_CRITICAL,
    Consts.GetInstance().SORT_POPUP_LABEL_AVOID,
    Consts.GetInstance().SORT_POPUP_LABEL_SPEED,
    Consts.GetInstance().SORT_POPUP_LABEL_DEXTERITY,
    Consts.GetInstance().SORT_POPUP_LABEL_LUCK,
    Consts.GetInstance().SORT_POPUP_LABEL_WEAPONPROFICIENCY,
    Consts.GetInstance().SORT_POPUP_LABEL_ARMORPROFICIENCY,
    Consts.GetInstance().SORT_POPUP_LABEL_GETORDER,
    Consts.GetInstance().SORT_POPUP_LABEL_HP,
    Consts.GetInstance().SORT_POPUP_LABEL_UNITID
  };
  private SortAndFilter.SORT_TYPE_ORDER_BUY orderBuySort;
  [SerializeField]
  private GameObject[] ListObject;
  [SerializeField]
  private UnitSortAndFilterButton[] OrderBtn;
  [SerializeField]
  private UnitSortAndFilterTabButton[] ListBtns;
  [SerializeField]
  private UnitSortAndFilterButton[] SortBtns;
  [SerializeField]
  private UnitSortAndFilterButton[] FilterBtns;
  [SerializeField]
  private NGxScroll groupScrollView;
  [SerializeField]
  private GameObject[] DisplayList;
  private readonly float[] ListPositionY = new float[3]
  {
    -48f,
    -118f,
    -188f
  };
  private bool isNormalUnitOnly;
  private UnitSortAndFilter.ModeTypes modeType;
  private UnitSortAndFilter.SORT_TYPES sortCategory = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy;
  private bool[] filter = new bool[38];
  private UnitGroupHead groupType = UnitGroupHead.group_all;
  private int groupID = 1;
  private Persist<Persist.UnitSortAndFilterInfo> persist;
  private Action<SortInfo> SortActionExt;

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
    switch (mode)
    {
      case UnitSortAndFilter.ModeTypes.Sort:
        this.ListBtns[0].SpriteColorGray(true);
        this.ListBtns[0].TextColorGray(true);
        this.ListBtns[1].SpriteColorGray(false);
        this.ListBtns[1].TextColorGray(false);
        this.ListBtns[2].SpriteColorGray(false);
        this.ListBtns[2].TextColorGray(false);
        break;
      case UnitSortAndFilter.ModeTypes.Filter:
        this.ListBtns[0].SpriteColorGray(false);
        this.ListBtns[0].TextColorGray(false);
        this.ListBtns[1].SpriteColorGray(true);
        this.ListBtns[1].TextColorGray(true);
        this.ListBtns[2].SpriteColorGray(false);
        this.ListBtns[2].TextColorGray(false);
        break;
      case UnitSortAndFilter.ModeTypes.Group:
        this.ListBtns[0].SpriteColorGray(false);
        this.ListBtns[0].TextColorGray(false);
        this.ListBtns[1].SpriteColorGray(false);
        this.ListBtns[1].TextColorGray(false);
        this.ListBtns[2].SpriteColorGray(true);
        this.ListBtns[2].TextColorGray(true);
        break;
    }
    this.SetSortTabLabel();
    this.SetFilterTabLabel();
    this.SetGroupTabLabel();
  }

  private GameObject CreateGroupBtn(
    GameObject prefab,
    UnitSortAndFilter menu,
    UnitGroupHead type,
    int id,
    string title,
    string spriteName)
  {
    GameObject groupBtn = Object.Instantiate<GameObject>(prefab);
    groupBtn.GetComponent<UnitSortAndFilterGroupButton>().Init(menu, type, id, title, spriteName);
    return groupBtn;
  }

  [DebuggerHidden]
  private IEnumerator CreateGroupList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitSortAndFilter.\u003CCreateGroupList\u003Ec__IteratorBBF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    Action<SortInfo> SortAction,
    Persist<Persist.UnitSortAndFilterInfo> persistData,
    bool normalUnitOnly = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitSortAndFilter.\u003CInitialize\u003Ec__IteratorBC0()
    {
      normalUnitOnly = normalUnitOnly,
      persistData = persistData,
      SortAction = SortAction,
      \u003C\u0024\u003EnormalUnitOnly = normalUnitOnly,
      \u003C\u0024\u003EpersistData = persistData,
      \u003C\u0024\u003ESortAction = SortAction,
      \u003C\u003Ef__this = this
    };
  }

  private void SetSortTabLabel()
  {
    this.ListBtns[0].SetText(this.SortLabelStr[(int) this.sortCategory]);
    if (this.modeType == UnitSortAndFilter.ModeTypes.Sort)
      this.ListBtns[0].SetTextColor(new Color(1f, 1f, 0.0f));
    else
      this.ListBtns[0].SetTextColor(new Color(0.5f, 0.5f, 0.0f));
  }

  private void SetFilterTabLabel()
  {
    bool flag = false;
    for (int index = 0; index < 38; ++index)
    {
      if ((!this.isNormalUnitOnly || index != 27 && index != 26 && index != 28) && !this.filter[index])
      {
        flag = true;
        break;
      }
    }
    this.ListBtns[1].SetText(!flag ? Consts.GetInstance().SORT_POPUP_LABEL_FILTER_OFF : Consts.GetInstance().SORT_POPUP_LABEL_FILTER_ON);
    if (this.modeType == UnitSortAndFilter.ModeTypes.Filter)
    {
      if (flag)
        this.ListBtns[1].SetTextColor(new Color(1f, 1f, 0.0f));
      else
        this.ListBtns[1].SetTextColor(new Color(1f, 1f, 1f));
    }
    else if (flag)
      this.ListBtns[1].SetTextColor(new Color(0.5f, 0.5f, 0.0f));
    else
      this.ListBtns[1].SetTextColor(new Color(0.5f, 0.5f, 0.5f));
  }

  private void SetGroupTabLabel()
  {
    string title = Consts.GetInstance().SORT_POPUP_LABEL_GROUP_ALL_TAB;
    if (this.groupType != UnitGroupHead.group_all)
    {
      switch (this.groupType)
      {
        case UnitGroupHead.group_large:
          UnitGroupLargeCategory groupLargeCategory = ((IEnumerable<UnitGroupLargeCategory>) MasterData.UnitGroupLargeCategoryList).FirstOrDefault<UnitGroupLargeCategory>((Func<UnitGroupLargeCategory, bool>) (x => x.ID == this.groupID));
          if (groupLargeCategory != null)
          {
            title = groupLargeCategory.short_label_name;
            break;
          }
          break;
        case UnitGroupHead.group_small:
          UnitGroupSmallCategory groupSmallCategory = ((IEnumerable<UnitGroupSmallCategory>) MasterData.UnitGroupSmallCategoryList).FirstOrDefault<UnitGroupSmallCategory>((Func<UnitGroupSmallCategory, bool>) (x => x.ID == this.groupID));
          if (groupSmallCategory != null)
          {
            title = groupSmallCategory.short_label_name;
            break;
          }
          break;
        case UnitGroupHead.group_clothing:
          UnitGroupClothingCategory clothingCategory = ((IEnumerable<UnitGroupClothingCategory>) MasterData.UnitGroupClothingCategoryList).FirstOrDefault<UnitGroupClothingCategory>((Func<UnitGroupClothingCategory, bool>) (x => x.ID == this.groupID));
          if (clothingCategory != null)
          {
            title = clothingCategory.short_label_name;
            break;
          }
          break;
        case UnitGroupHead.group_generation:
          UnitGroupGenerationCategory generationCategory = ((IEnumerable<UnitGroupGenerationCategory>) MasterData.UnitGroupGenerationCategoryList).FirstOrDefault<UnitGroupGenerationCategory>((Func<UnitGroupGenerationCategory, bool>) (x => x.ID == this.groupID));
          if (generationCategory != null)
          {
            title = generationCategory.short_label_name;
            break;
          }
          break;
      }
    }
    this.ListBtns[2].SetText(title);
    if (this.modeType == UnitSortAndFilter.ModeTypes.Group)
    {
      if (this.groupType == UnitGroupHead.group_all)
        this.ListBtns[2].SetTextColor(new Color(1f, 1f, 1f));
      else
        this.ListBtns[2].SetTextColor(new Color(1f, 1f, 0.0f));
    }
    else if (this.groupType == UnitGroupHead.group_all)
      this.ListBtns[2].SetTextColor(new Color(0.5f, 0.5f, 0.5f));
    else
      this.ListBtns[2].SetTextColor(new Color(0.5f, 0.5f, 0.0f));
  }

  public void SetValueWindow()
  {
    this.SetSortTabLabel();
    this.SetFilterTabLabel();
    this.SetGroupTabLabel();
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
    foreach (GameObject gridChild in this.groupScrollView.GridChildren())
    {
      UnitSortAndFilterGroupButton component = gridChild.GetComponent<UnitSortAndFilterGroupButton>();
      component.SpriteColorGray(false);
      component.TextColorGray(false);
      if (this.groupID == component.GroupID && this.groupType == component.GroupType)
      {
        component.SpriteColorGray(true);
        component.TextColorGray(true);
      }
    }
  }

  public void IbtnSortBtn() => this.SetListTypeBtn(UnitSortAndFilter.ModeTypes.Sort);

  public void IbtnFilterBtn() => this.SetListTypeBtn(UnitSortAndFilter.ModeTypes.Filter);

  public void IbtnGroupBtn() => this.SetListTypeBtn(UnitSortAndFilter.ModeTypes.Group);

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
      this.SortActionExt(new SortInfo(this.sortCategory, this.orderBuySort, this.filter, this.groupType, this.groupID));
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

  public void SetGroupInfo(UnitGroupHead gType, int gID)
  {
    this.groupID = gID;
    this.groupType = gType;
    this.SetValueWindow();
  }

  public override void SaveData()
  {
    this.persist.Data.order = this.orderBuySort;
    this.persist.Data.sortType = this.sortCategory;
    this.persist.Data.modeType = this.modeType;
    this.persist.Data.groupType = this.groupType;
    this.persist.Data.groupID = this.groupID;
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
    Group,
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
