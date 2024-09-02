// Decompiled with JetBrains decompiler
// Type: UnitMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UniLinq;
using UnityEngine;

#nullable disable
public class UnitMenuBase : BackButtonMenuBase
{
  private int iconWidth;
  private int iconHeight;
  private int iconColumnValue;
  private int iconRowValue;
  private int iconScreenValue;
  private int iconMaxValue;
  protected bool isInitialize;
  private float scrool_start_y;
  private UnitMenuBase.IconType iconType;
  protected GameObject unitPrefab;
  protected UnitSortAndFilter.SORT_TYPES sortType;
  protected SortAndFilter.SORT_TYPE_ORDER_BUY orderType;
  protected List<UnitIconBase> allUnitIcons = new List<UnitIconBase>();
  protected List<UnitIconInfo> allUnitInfos = new List<UnitIconInfo>();
  protected List<UnitIconInfo> displayUnitInfos = new List<UnitIconInfo>();
  protected bool isUpdateIcon;
  [SerializeField]
  protected UILabel TxtNumber;
  [SerializeField]
  protected UILabel TxtNumberpossession;
  [SerializeField]
  protected UILabel TxtNumberselect;
  [SerializeField]
  protected UILabel TxtNumberzeny;
  [SerializeField]
  protected UILabel TxtPossessionUnit;
  [SerializeField]
  protected UILabel TxtPossessionUnitSell;
  [SerializeField]
  protected UILabel TxtSort;
  [SerializeField]
  protected NGxScroll2 scroll;
  private System.Action extendFunc;
  protected Persist<Persist.UnitSortAndFilterInfo> persist;
  private bool IsEquip;
  private bool RemoveButton;
  private bool ForBattleCheck;
  private bool PrincessType;
  private bool m_isGroupingUniqueMaterialUnit;
  protected int lastReferenceUnitID = -1;
  protected int lastReferenceUnitIndex = -1;
  public string Title = string.Empty;
  public GameObject BottomViewPossession;
  public bool isBottomViewSell;
  public bool isBottomViewFormation;
  public bool isBottomViewPossesion;
  public PlayerUnit BaseUnit;

  public PlayerUnit baseUnit
  {
    get => this.BaseUnit;
    set => this.BaseUnit = value;
  }

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    this.backScene();
  }

  public override void onBackButton()
  {
    if (!this.isInitialize)
      return;
    this.IbtnBack();
  }

  public virtual void IbtnClearS()
  {
  }

  public virtual void IbtnNo()
  {
  }

  public virtual void IbtnSort()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowSortAndFilterPopup());
  }

  public virtual void IbtnYes()
  {
  }

  public virtual void IbtnYesS()
  {
  }

  public virtual void VScrollBar()
  {
  }

  private bool[] CreateFilterTable()
  {
    bool[] source = new bool[38];
    if (this.persist == null)
      return ((IEnumerable<bool>) source).Select<bool, bool>((Func<bool, bool>) (x => true)).ToArray<bool>();
    for (int index = 0; index < 38; ++index)
    {
      if (index < this.persist.Data.filter.Count)
        source[index] = this.persist.Data.filter[index];
      else
        source.SetValue((object) true, index);
    }
    return source;
  }

  public UnitIconInfo GetUnitInfoAll(PlayerUnit unit)
  {
    int? nullable = this.allUnitInfos.FirstIndexOrNull<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => v.playerUnit != (PlayerUnit) null && v.playerUnit.id == unit.id));
    return !nullable.HasValue ? (UnitIconInfo) null : this.allUnitInfos[nullable.Value];
  }

  public int GetUnitInfoDisplayIndex(PlayerUnit unit)
  {
    int? nullable = this.displayUnitInfos.FirstIndexOrNull<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => v.playerUnit != (PlayerUnit) null && v.playerUnit.id == unit.id));
    return !nullable.HasValue ? -1 : nullable.Value;
  }

  public UnitIconInfo GetUnitInfoDisplay(PlayerUnit unit)
  {
    int? nullable = this.displayUnitInfos.FirstIndexOrNull<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => v.playerUnit != (PlayerUnit) null && v.playerUnit.id == unit.id));
    return !nullable.HasValue ? (UnitIconInfo) null : this.displayUnitInfos[nullable.Value];
  }

  public void ForBattle(Func<UnitIconInfo, PlayerUnit, bool> func)
  {
    foreach (PlayerDeck playerDeck in SMManager.Get<PlayerDeck[]>())
    {
      if (playerDeck != null)
      {
        foreach (PlayerUnit playerUnit in playerDeck.player_units)
        {
          PlayerUnit unit = playerUnit;
          if (!(unit == (PlayerUnit) null))
          {
            UnitIconInfo unitIconInfo = this.allUnitInfos.FirstOrDefault<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => func(x, unit)));
            if (unitIconInfo != null)
              unitIconInfo.for_battle = true;
          }
        }
      }
    }
  }

  [DebuggerHidden]
  public virtual IEnumerator UpdateInfoAndScroll(PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CUpdateInfoAndScroll\u003Ec__Iterator28B()
    {
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  private bool CheckWeaponType(UnitIconInfo info, bool[] filters)
  {
    bool flag = false;
    switch (info.playerUnit.unit.kind.Enum)
    {
      case GearKindEnum.sword:
        flag = filters[1];
        break;
      case GearKindEnum.axe:
        flag = filters[2];
        break;
      case GearKindEnum.spear:
        flag = filters[3];
        break;
      case GearKindEnum.bow:
        flag = filters[4];
        break;
      case GearKindEnum.gun:
        flag = filters[5];
        break;
      case GearKindEnum.staff:
        flag = filters[6];
        break;
    }
    return flag;
  }

  private bool CheckElementType(UnitIconInfo info, bool[] filters)
  {
    bool flag = false;
    switch (info.playerUnit.GetElement())
    {
      case CommonElement.none:
        flag = filters[7];
        break;
      case CommonElement.fire:
        flag = filters[8];
        break;
      case CommonElement.wind:
        flag = filters[10];
        break;
      case CommonElement.thunder:
        flag = filters[11];
        break;
      case CommonElement.ice:
        flag = filters[9];
        break;
      case CommonElement.light:
        flag = filters[12];
        break;
      case CommonElement.dark:
        flag = filters[13];
        break;
    }
    return flag;
  }

  private bool CheckUnitType(UnitIconInfo info, bool[] filters)
  {
    bool flag = false;
    switch (info.playerUnit.unit_type.Enum)
    {
      case UnitTypeEnum.ouki:
        flag = filters[14];
        break;
      case UnitTypeEnum.meiki:
        flag = filters[15];
        break;
      case UnitTypeEnum.kouki:
        flag = filters[16];
        break;
      case UnitTypeEnum.maki:
        flag = filters[17];
        break;
      case UnitTypeEnum.syuki:
        flag = filters[18];
        break;
      case UnitTypeEnum.syouki:
        flag = filters[19];
        break;
    }
    return flag;
  }

  private bool CheckRarity(UnitIconInfo info, bool[] filters)
  {
    bool flag = false;
    switch (info.playerUnit.unit.rarity.index)
    {
      case 0:
        flag = filters[20];
        break;
      case 1:
        flag = filters[21];
        break;
      case 2:
        flag = filters[22];
        break;
      case 3:
        flag = filters[23];
        break;
      case 4:
        flag = filters[24];
        break;
      case 5:
        flag = filters[37];
        break;
    }
    return flag;
  }

  private bool CheckUnit(UnitIconInfo info, bool[] filters)
  {
    bool flag = false;
    if (info.playerUnit.unit.IsNormalUnit)
      flag = filters[25];
    else if (info.playerUnit.unit.IsSinkaUnit)
      flag = filters[26];
    else if (info.playerUnit.unit.IsTougouUnit)
      flag = filters[27];
    else if (info.playerUnit.unit.IsTenseiUnit)
      flag = filters[28];
    return flag;
  }

  private bool CheckLevel(UnitIconInfo info, bool[] filters)
  {
    bool flag1 = false;
    bool flag2 = false;
    if (info.playerUnit.max_level == info.playerUnit.level)
      flag1 = filters[29];
    if (info.playerUnit.max_level > info.playerUnit.level)
      flag2 = filters[30];
    return flag1 || flag2;
  }

  private bool CheckEquipment(UnitIconInfo info, bool[] filters)
  {
    bool flag1 = false;
    bool flag2 = false;
    if (info.playerUnit.equippedGearOrInitial != info.playerUnit.unit.initial_gear)
      flag1 = filters[31];
    if (info.playerUnit.equippedGearOrInitial == info.playerUnit.unit.initial_gear)
      flag2 = filters[32];
    return flag1 || flag2;
  }

  private bool CheckCompose(UnitIconInfo info, bool[] filters)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    if (info.playerUnit.amountIncrementInCompose == 0)
      flag1 = filters[33];
    if (info.playerUnit.amountIncrementInCompose > 0 && !info.playerUnit.isMaxParamInComposeEx)
      flag2 = filters[34];
    if (info.playerUnit.isMaxParamInComposeEx)
      flag3 = filters[35];
    return flag1 || flag2 || flag3;
  }

  private bool CheckFavorite(UnitIconInfo info, bool[] filters)
  {
    bool flag = false;
    if (!info.playerUnit.favorite)
      flag = true;
    else if (filters[36])
      flag = true;
    return flag;
  }

  protected void CreateDisplayUnitInfo(bool[] filters)
  {
    this.displayUnitInfos = this.allUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (x =>
    {
      if (x.removeButton)
        return true;
      return this.CheckWeaponType(x, filters) && this.CheckElementType(x, filters) && this.CheckUnitType(x, filters) && this.CheckRarity(x, filters) && this.CheckUnit(x, filters) && this.CheckLevel(x, filters) && this.CheckEquipment(x, filters) && this.CheckCompose(x, filters) && this.CheckFavorite(x, filters);
    })).ToList<UnitIconInfo>();
  }

  protected virtual void Sort(
    UnitSortAndFilter.SORT_TYPES type = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy,
    SortAndFilter.SORT_TYPE_ORDER_BUY order = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING,
    bool[] filterFlg = null)
  {
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    this.sortType = type;
    this.orderType = order;
    this.CreateDisplayUnitInfo(filterFlg);
    this.SortAndSetIcons(this.sortType, this.orderType);
    for (int index = 0; index < Mathf.Min(this.iconMaxValue, this.displayUnitInfos.Count); ++index)
      this.ResetUnitIcon(index);
    this.StartCoroutine(this.CreateUnitIconRange(Mathf.Min(this.iconMaxValue, this.displayUnitInfos.Count)));
    foreach (UnitIcon unitIcon in this.scroll.GridChildren().Select<GameObject, UnitIcon>((Func<GameObject, UnitIcon>) (x => x.GetComponent<UnitIcon>())))
    {
      if (Object.op_Inequality((Object) unitIcon, (Object) null) && unitIcon.PlayerUnit != (PlayerUnit) null)
        unitIcon.ShowBottomInfo(this.sortType);
    }
  }

  [DebuggerHidden]
  private IEnumerator CreateUnitIconRange(int value)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CCreateUnitIconRange\u003Ec__Iterator28C()
    {
      value = value,
      \u003C\u0024\u003Evalue = value,
      \u003C\u003Ef__this = this
    };
  }

  private void UpdateSortSprite(UnitSortAndFilter.SORT_TYPES type)
  {
    this.TxtSort.text = string.Empty;
    string empty = string.Empty;
    if (!UnitSortAndFilter.UISortString.TryGetValue(type, out empty))
      return;
    this.TxtSort.text = !string.IsNullOrEmpty(empty) ? Consts.Lookup(empty) : string.Empty;
  }

  protected void SortAndSetIcons(
    UnitSortAndFilter.SORT_TYPES type,
    SortAndFilter.SORT_TYPE_ORDER_BUY order)
  {
    bool flag = Object.op_Inequality((Object) this.TxtSort, (Object) null);
    if (flag)
      this.UpdateSortSprite(type);
    if (this.allUnitIcons.Count < 1)
      return;
    if (flag)
      this.displayUnitInfos = this.displayUnitInfos.SortBy(type, order).ToList<UnitIconInfo>();
    this.scroll.Reset();
    this.allUnitIcons.ForEach((Action<UnitIconBase>) (x =>
    {
      ((Component) x).transform.parent = ((Component) this).transform;
      ((Component) x).gameObject.SetActive(false);
    }));
    for (int index = 0; index < Mathf.Min(this.iconMaxValue, this.displayUnitInfos.Count); ++index)
    {
      this.scroll.Add(((Component) this.allUnitIcons[index]).gameObject, this.iconWidth, this.iconHeight);
      ((Component) this.allUnitIcons[index]).gameObject.SetActive(true);
      if (this.allUnitIcons[index].unit != null && this.allUnitIcons[index].unit.IsMaterialUnit)
      {
        this.allUnitIcons[index].SetCounter(this.displayUnitInfos[index].count);
        this.allUnitIcons[index].SetSelectionCounter(this.displayUnitInfos[index].SelectedCount);
      }
    }
    int targetUnitID = Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID;
    if (targetUnitID != -1)
    {
      this.scroll.CreateScrollPoint(this.iconHeight, this.displayUnitInfos.Count);
      int? nullable = this.displayUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => !x.removeButton)).Select<UnitIconInfo, int>((Func<UnitIconInfo, int>) (x => x.playerUnit.id)).FirstIndexOrNull<int>((Func<int, bool>) (x => x == targetUnitID));
      if (nullable.HasValue)
      {
        this.scroll.ResolvePosition(nullable.Value, this.displayUnitInfos.Count<UnitIconInfo>());
      }
      else
      {
        int referenceUnitIndex = Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex;
        if (referenceUnitIndex != -1 && referenceUnitIndex < this.displayUnitInfos.Count)
          this.scroll.ResolvePosition(referenceUnitIndex, this.displayUnitInfos.Count<UnitIconInfo>());
        else
          this.scroll.ResolvePosition(this.displayUnitInfos.Count<UnitIconInfo>() - 1, this.displayUnitInfos.Count<UnitIconInfo>());
      }
    }
    else
    {
      this.scroll.CreateScrollPoint(this.iconHeight, this.displayUnitInfos.Count);
      this.scroll.ResolvePosition();
    }
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
  }

  private void ScrollIconUpdate(int info_index, int unit_index)
  {
    this.ResetUnitIcon(unit_index);
    if (this.iconType == UnitMenuBase.IconType.Normal || this.iconType == UnitMenuBase.IconType.EarthNormal)
    {
      if (this.displayUnitInfos[info_index].removeButton)
        this.CreateUnitIconCache(info_index, unit_index);
      else if (UnitIcon.IsCache(this.displayUnitInfos[info_index].playerUnit.unit))
        this.CreateUnitIconCache(info_index, unit_index);
      else
        this.StartCoroutine(this.CreateUnitIcon(info_index, unit_index));
    }
    else if (UnitIcon.IsCache(this.displayUnitInfos[info_index].playerUnit.unit))
      this.CreateUnitIconCache(info_index, unit_index, this.BaseUnit);
    else
      this.StartCoroutine(this.CreateUnitIcon(info_index, unit_index, this.BaseUnit));
  }

  protected void ScrollUpdate()
  {
    if ((!this.isInitialize || this.displayUnitInfos.Count <= this.iconScreenValue) && !this.isUpdateIcon)
      return;
    int num1 = this.iconHeight * 2;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scrool_start_y;
    float num3 = (float) (Mathf.Max(0, this.displayUnitInfos.Count - this.iconScreenValue - 1) / this.iconColumnValue * this.iconHeight);
    float num4 = (float) (this.iconHeight * this.iconRowValue);
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    while (true)
    {
      do
      {
        bool flag = false;
        int unit_index = 0;
        foreach (GameObject gameObject in this.scroll)
        {
          GameObject unit = gameObject;
          float num5 = unit.transform.localPosition.y + num2;
          if ((double) num5 > (double) num1)
          {
            int? nullable = this.displayUnitInfos.FirstIndexOrNull<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => Object.op_Inequality((Object) v.icon, (Object) null) && Object.op_Equality((Object) ((Component) v.icon).gameObject, (Object) unit)));
            int info_index = !nullable.HasValue ? (this.displayUnitInfos.Count + 4) / 5 * 5 : nullable.Value + this.iconMaxValue;
            if (nullable.HasValue && info_index < (this.displayUnitInfos.Count + 4) / 5 * 5)
            {
              unit.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y - num4, 0.0f);
              if (info_index >= this.displayUnitInfos.Count)
                unit.SetActive(false);
              else
                this.ScrollIconUpdate(info_index, unit_index);
              flag = true;
            }
          }
          else if ((double) num5 < -((double) num4 - (double) num1))
          {
            int num6 = this.iconMaxValue;
            if (!unit.activeSelf)
            {
              unit.SetActive(true);
              num6 = 0;
            }
            int? nullable = this.displayUnitInfos.FirstIndexOrNull<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => Object.op_Inequality((Object) v.icon, (Object) null) && Object.op_Equality((Object) ((Component) v.icon).gameObject, (Object) unit)));
            int info_index = !nullable.HasValue ? -1 : nullable.Value - num6;
            if (nullable.HasValue && info_index >= 0)
            {
              unit.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y + num4, 0.0f);
              this.ScrollIconUpdate(info_index, unit_index);
              flag = true;
            }
          }
          ++unit_index;
        }
        if (!flag)
          goto label_23;
      }
      while (!this.isUpdateIcon);
      this.isUpdateIcon = false;
    }
label_23:;
  }

  protected virtual void ResetUnitIcon(int index)
  {
    if (this.allUnitIcons == null || this.allUnitIcons.Count == 0)
      return;
    UnitIconBase unitIcon = this.allUnitIcons[index];
    if (this.iconType == UnitMenuBase.IconType.Normal || this.iconType == UnitMenuBase.IconType.EarthNormal)
      ((UnitIcon) unitIcon).ResetUnit();
    else
      ((UnitDetailIcon) unitIcon).ResetUnit();
    ((Component) unitIcon).gameObject.SetActive(false);
    this.displayUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (a => Object.op_Equality((Object) a.icon, (Object) unitIcon))).ForEach<UnitIconInfo>((Action<UnitIconInfo>) (b => b.icon = (UnitIconBase) null));
  }

  [DebuggerHidden]
  protected virtual IEnumerator CreateUnitIconBase(GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CCreateUnitIconBase\u003Ec__Iterator28D()
    {
      prefab = prefab,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator CreateUnitIcon(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CCreateUnitIcon\u003Ec__Iterator28E()
    {
      unit_index = unit_index,
      info_index = info_index,
      baseUnit = baseUnit,
      \u003C\u0024\u003Eunit_index = unit_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void CreateUnitIconCache(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    UnitIconBase unitIcon = this.allUnitIcons[unit_index];
    this.displayUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (a => Object.op_Equality((Object) a.icon, (Object) unitIcon))).ForEach<UnitIconInfo>((Action<UnitIconInfo>) (b => b.icon = (UnitIconBase) null));
    this.displayUnitInfos[info_index].icon = unitIcon;
    if (this.iconType == UnitMenuBase.IconType.Normal || this.iconType == UnitMenuBase.IconType.EarthNormal)
    {
      if (this.displayUnitInfos[info_index].removeButton)
        unitIcon.SetRemoveButton();
      else if (this.displayUnitInfos[info_index].playerUnit.unit.IsMaterialUnit)
        ((UnitIcon) unitIcon).SetMaterialUnitCache(this.displayUnitInfos[info_index].playerUnit, false, this.getUnits());
      else
        ((UnitIcon) unitIcon).SetPlayerUnitCache(this.displayUnitInfos[info_index].playerUnit, this.getUnits());
      ((UnitIcon) unitIcon).setBottom(this.displayUnitInfos[info_index].playerUnit);
      this.displayUnitInfos[info_index].icon.SetCounter(this.displayUnitInfos[info_index].count);
      this.displayUnitInfos[info_index].icon.SetSelectionCounter(this.displayUnitInfos[info_index].SelectedCount);
    }
    else if (this.displayUnitInfos[info_index].playerUnit.unit.IsMaterialUnit)
      ((UnitDetailIcon) unitIcon).SetMaterialUnitCache(this.displayUnitInfos[info_index].playerUnit, false, this.getUnits());
    else
      ((UnitDetailIcon) unitIcon).SetPlayerUnitCache(this.displayUnitInfos[info_index].playerUnit, this.getUnits(), baseUnit);
    unitIcon.ForBattle = this.displayUnitInfos[info_index].for_battle;
    unitIcon.Equip = this.displayUnitInfos[info_index].equip;
    if (unitIcon is UnitIcon)
      ((UnitIcon) unitIcon).princessType.DispPrincessType(this.displayUnitInfos[info_index].pricessType);
    else if (unitIcon is UnitDetailIcon)
      unitIcon.UnitIcon.princessType.DispPrincessType(this.displayUnitInfos[info_index].pricessType);
    unitIcon.SelectMarker = this.displayUnitInfos[info_index].selectMarker;
    unitIcon.ShowBottomInfo(this.sortType);
    ((Component) unitIcon).gameObject.SetActive(true);
  }

  [DebuggerHidden]
  private IEnumerator LoadObjectNormal()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CLoadObjectNormal\u003Ec__Iterator28F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadObjectDetail()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CLoadObjectDetail\u003Ec__Iterator290()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator LoadObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CLoadObject\u003Ec__Iterator291()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateUnitIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CCreateUnitIcon\u003Ec__Iterator292()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Initialize()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CInitialize\u003Ec__Iterator293()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void InitializeEnd()
  {
    this.StartCoroutine(this.LoadObject());
    this.scrool_start_y = ((Component) this.scroll.scrollView).transform.localPosition.y;
    this.isInitialize = true;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
  }

  private void CreateAllUnitInfoEx(
    IEnumerable<PlayerUnit> playerUnits,
    bool isEquip,
    bool removeButton,
    bool for_battle_check,
    bool princessType,
    bool bGroupUniqueMaterialUnit)
  {
    this.m_isGroupingUniqueMaterialUnit = bGroupUniqueMaterialUnit;
    if (!bGroupUniqueMaterialUnit)
    {
      this.CreateAllUnitInfo(playerUnits, isEquip, removeButton, for_battle_check, princessType);
    }
    else
    {
      this.allUnitInfos.Clear();
      if (removeButton)
        this.allUnitInfos.Add(new UnitIconInfo()
        {
          removeButton = true,
          gray = false,
          select = -1,
          for_battle = false,
          pricessType = false,
          equip = false
        });
      foreach (PlayerUnit playerUnit in playerUnits.Where<PlayerUnit>((Func<PlayerUnit, bool>) (playerUnit => playerUnit.unit.IsNormalUnit)))
      {
        UnitIconInfo unitIconInfo = new UnitIconInfo();
        unitIconInfo.playerUnit = playerUnit;
        unitIconInfo.gray = false;
        unitIconInfo.select = -1;
        unitIconInfo.for_battle = false;
        unitIconInfo.pricessType = princessType;
        if (unitIconInfo.playerUnit.equippedGear != (PlayerItem) null)
          unitIconInfo.equip = isEquip;
        this.allUnitInfos.Add(unitIconInfo);
      }
      IEnumerable<IGrouping<int, PlayerUnit>> groupings = playerUnits.Where<PlayerUnit>((Func<PlayerUnit, bool>) (playerUnit => !playerUnit.unit.IsNormalUnit)).GroupBy<PlayerUnit, int, PlayerUnit>((Func<PlayerUnit, int>) (playerUnit => playerUnit.unit.ID), (Func<PlayerUnit, PlayerUnit>) (playerUnit => playerUnit)).Select<IGrouping<int, PlayerUnit>, IGrouping<int, PlayerUnit>>((Func<IGrouping<int, PlayerUnit>, IGrouping<int, PlayerUnit>>) (g => g));
      if (Debug.isDebugBuild)
      {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (IGrouping<int, PlayerUnit> source in groupings)
          stringBuilder.AppendLine("Unit ID: " + (object) source.First<PlayerUnit>().unit.ID + ", Count: " + (object) source.Count<PlayerUnit>());
        Debug.Log((object) ("CreateAllUnitInfoEx: " + stringBuilder.ToString()));
      }
      foreach (IGrouping<int, PlayerUnit> source in groupings)
        this.allUnitInfos.Add(new UnitIconInfo()
        {
          playerUnit = source.First<PlayerUnit>(),
          gray = false,
          select = -1,
          for_battle = false,
          equip = false,
          count = source.Count<PlayerUnit>()
        });
      if (for_battle_check)
        this.ForBattle((Func<UnitIconInfo, PlayerUnit, bool>) ((info, unit) => info.playerUnit != (PlayerUnit) null && !info.removeButton && unit.id == info.playerUnit.id));
      if (this.extendFunc == null)
        return;
      this.extendFunc();
    }
  }

  private void CreateAllUnitInfo(
    IEnumerable<PlayerUnit> playerUnits,
    bool isEquip,
    bool removeButton,
    bool for_battle_check,
    bool princessType)
  {
    this.allUnitInfos.Clear();
    if (removeButton)
      this.allUnitInfos.Add(new UnitIconInfo()
      {
        removeButton = true,
        gray = false,
        select = -1,
        for_battle = false,
        pricessType = false,
        equip = false
      });
    foreach (PlayerUnit playerUnit in playerUnits)
    {
      UnitIconInfo unitIconInfo = new UnitIconInfo();
      unitIconInfo.playerUnit = playerUnit;
      unitIconInfo.gray = false;
      unitIconInfo.select = -1;
      unitIconInfo.for_battle = false;
      unitIconInfo.pricessType = princessType;
      if (unitIconInfo.playerUnit.equippedGear != (PlayerItem) null)
        unitIconInfo.equip = isEquip;
      this.allUnitInfos.Add(unitIconInfo);
    }
    if (for_battle_check)
      this.ForBattle((Func<UnitIconInfo, PlayerUnit, bool>) ((info, unit) => info.playerUnit != (PlayerUnit) null && !info.removeButton && unit.id == info.playerUnit.id));
    if (this.extendFunc == null)
      return;
    this.extendFunc();
  }

  protected virtual void InitializeInfo(
    IEnumerable<PlayerUnit> playerUnits,
    Persist<Persist.UnitSortAndFilterInfo> persistData,
    bool isEquip,
    bool removeButton,
    bool for_battle_check,
    bool princessType,
    System.Action createAllUnitInfoExtendFunc = null)
  {
    this.IsEquip = isEquip;
    this.RemoveButton = removeButton;
    this.ForBattleCheck = for_battle_check;
    this.PrincessType = princessType;
    this.extendFunc = createAllUnitInfoExtendFunc;
    this.persist = persistData;
    if (this.persist != null)
    {
      this.sortType = this.persist.Data.sortType;
      this.orderType = this.persist.Data.order;
    }
    else
    {
      this.sortType = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy;
      this.orderType = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING;
    }
    this.CreateAllUnitInfo(playerUnits, this.IsEquip, this.RemoveButton, this.ForBattleCheck, this.PrincessType);
    this.CreateDisplayUnitInfo(this.CreateFilterTable());
  }

  protected virtual void InitializeInfoEx(
    IEnumerable<PlayerUnit> playerUnits,
    Persist<Persist.UnitSortAndFilterInfo> persistData,
    bool isEquip,
    bool removeButton,
    bool for_battle_check,
    bool princessType,
    bool bGroupUniqueMaterialUnit,
    System.Action createAllUnitInfoExtendFunc = null)
  {
    this.IsEquip = isEquip;
    this.RemoveButton = removeButton;
    this.ForBattleCheck = for_battle_check;
    this.PrincessType = princessType;
    this.extendFunc = createAllUnitInfoExtendFunc;
    this.persist = persistData;
    if (this.persist != null)
    {
      this.sortType = this.persist.Data.sortType;
      this.orderType = this.persist.Data.order;
    }
    else
    {
      this.sortType = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy;
      this.orderType = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING;
    }
    this.CreateAllUnitInfoEx(playerUnits, this.IsEquip, this.RemoveButton, this.ForBattleCheck, this.PrincessType, bGroupUniqueMaterialUnit);
    this.CreateDisplayUnitInfo(this.CreateFilterTable());
  }

  public void SetIconType(UnitMenuBase.IconType type)
  {
    switch (type)
    {
      case UnitMenuBase.IconType.Normal:
        this.iconWidth = UnitIcon.Width;
        this.iconHeight = UnitIcon.Height;
        this.iconColumnValue = UnitIcon.ColumnValue;
        this.iconRowValue = UnitIcon.RowValue;
        this.iconScreenValue = UnitIcon.ScreenValue;
        this.iconMaxValue = UnitIcon.MaxValue;
        break;
      case UnitMenuBase.IconType.EarthNormal:
        this.iconWidth = UnitIcon.Width;
        this.iconHeight = UnitIcon.HeightEarth;
        this.iconColumnValue = UnitIcon.ColumnValue;
        this.iconRowValue = UnitIcon.RowValue;
        this.iconScreenValue = UnitIcon.ScreenValue;
        this.iconMaxValue = UnitIcon.MaxValue;
        break;
      default:
        this.iconWidth = UnitDetailIcon.Width;
        this.iconHeight = UnitDetailIcon.Height;
        this.iconColumnValue = UnitDetailIcon.ColumnValue;
        this.iconRowValue = UnitDetailIcon.RowValue;
        this.iconScreenValue = UnitDetailIcon.ScreenValue;
        this.iconMaxValue = UnitDetailIcon.MaxValue;
        break;
    }
    this.iconType = type;
  }

  protected PlayerUnit[] getUnits()
  {
    return this.displayUnitInfos.Select<UnitIconInfo, PlayerUnit>((Func<UnitIconInfo, PlayerUnit>) (x => x.playerUnit)).ToArray<PlayerUnit>();
  }

  [DebuggerHidden]
  protected IEnumerator ShowSortAndFilterPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitMenuBase.\u003CShowSortAndFilterPopup\u003Ec__Iterator294()
    {
      \u003C\u003Ef__this = this
    };
  }

  public enum IconType
  {
    Normal,
    Detail,
    EarthNormal,
  }
}
