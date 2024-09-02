// Decompiled with JetBrains decompiler
// Type: UnitSortAndFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UnitSortAndFilter : SortAndFilter
{
  public static readonly Dictionary<UnitSortAndFilter.SORT_TYPES, string> UISortString = new Dictionary<UnitSortAndFilter.SORT_TYPES, string>()
  {
    {
      UnitSortAndFilter.SORT_TYPES.None,
      string.Empty
    },
    {
      UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy,
      "UI_SORT_TYPE_WEAPON_TYPE"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Attribute,
      "UI_SORT_TYPE_ELEMENT"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Level,
      "UI_SORT_TYPE_LEVEL"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Rarity,
      "UI_SORT_TYPE_RARITY"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Cost,
      "UI_SORT_TYPE_COST"
    },
    {
      UnitSortAndFilter.SORT_TYPES.FightingPower,
      "UI_SORT_TYPE_POWER"
    },
    {
      UnitSortAndFilter.SORT_TYPES.PhysicalAttack,
      "UI_SORT_TYPE_PHYSICAL_ATTACK"
    },
    {
      UnitSortAndFilter.SORT_TYPES.MagicAttack,
      "UI_SORT_TYPE_MAGICAL_ATTACK"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Defence,
      "UI_SORT_TYPE_PHYSICAL_DEFENCE"
    },
    {
      UnitSortAndFilter.SORT_TYPES.MagicDefence,
      "UI_SORT_TYPE_MAGICAL_DEFENCE"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Hit,
      "UI_SORT_TYPE_ACCURACY"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Critical,
      "UI_SORT_TYPE_CRITICAL"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Avoid,
      "UI_SORT_TYPE_EVASION"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Speed,
      "UI_SORT_TYPE_SPEED"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Dexterity,
      "UI_SORT_TYPE_AGILITY"
    },
    {
      UnitSortAndFilter.SORT_TYPES.Luck,
      "UI_SORT_TYPE_LUCK"
    },
    {
      UnitSortAndFilter.SORT_TYPES.WeaponProficiency,
      "UI_SORT_TYPE_WEAPON_PROFICIENCY"
    },
    {
      UnitSortAndFilter.SORT_TYPES.ArmorProficiency,
      "UI_SORT_TYPE_SHIELD_PROFICIENCY"
    },
    {
      UnitSortAndFilter.SORT_TYPES.GetOrder,
      "UI_SORT_TYPE_ACQUIRED"
    },
    {
      UnitSortAndFilter.SORT_TYPES.HP,
      "UI_SORT_TYPE_HP"
    }
  };
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
    Persist<Persist.UnitSortAndFilterInfo> persistData)
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
