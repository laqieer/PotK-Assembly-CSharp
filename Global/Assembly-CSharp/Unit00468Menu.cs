// Decompiled with JetBrains decompiler
// Type: Unit00468Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00468Menu : UnitSelectMenuBase
{
  [SerializeField]
  private UIButton ibtnYes;
  [SerializeField]
  protected GameObject[] linkCharactersBac;
  [SerializeField]
  protected GameObject[] linkCharacters;
  [SerializeField]
  protected UILabel txtCostValue;
  protected Promise<int?[]> playerUnitIds;
  protected int deck_type_id;
  protected int deck_number;
  protected int totalCost;
  protected int maxCost;
  protected string IconObjName = "Icon";

  protected void BaseSort(
    UnitSortAndFilter.SORT_TYPES type = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy,
    SortAndFilter.SORT_TYPE_ORDER_BUY order = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING,
    bool[] filterFlg = null)
  {
    base.Sort(type, order, filterFlg);
  }

  protected override void Sort(
    UnitSortAndFilter.SORT_TYPES type = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy,
    SortAndFilter.SORT_TYPE_ORDER_BUY order = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING,
    bool[] filterFlg = null)
  {
    this.BaseSort(type, order, filterFlg);
    this.UpdateInfomation();
    this.UpdateSelectIcon();
  }

  protected virtual void updateTxtCostValue(int cost = 0)
  {
    this.totalCost = cost;
    this.txtCostValue.SetTextLocalize(this.totalCost.ToString() + "/" + (object) this.maxCost);
    this.ibtnYes.isEnabled = this.totalCost > 0;
  }

  public virtual void InitializeAllUnitInfosExtend(PlayerDeck playerDeck)
  {
    bool updateIndex = this.selectedUnitIcons.Count<UnitIconInfo>() == 0;
    UnitIconInfo[] array = this.selectedUnitIcons.ToArray();
    this.selectedUnitIcons.Clear();
    foreach (UnitIconInfo allUnitInfo in this.allUnitInfos)
    {
      UnitIconInfo info = allUnitInfo;
      if (updateIndex)
      {
        info.select = -1;
        info.for_battle = false;
        info.gray = false;
        int? nullable = ((IEnumerable<PlayerUnit>) playerDeck.player_units).FirstIndexOrNull<PlayerUnit>((Func<PlayerUnit, bool>) (a => a != (PlayerUnit) null && a.id == info.playerUnit.id));
        if (nullable.HasValue)
        {
          info.gray = true;
          info.select = nullable.Value;
          info.for_battle = true;
          this.selectedUnitIcons.Add(info);
        }
      }
      else
      {
        info.select = -1;
        info.for_battle = false;
        info.gray = false;
        if (((IEnumerable<PlayerUnit>) playerDeck.player_units).FirstIndexOrNull<PlayerUnit>((Func<PlayerUnit, bool>) (a => a != (PlayerUnit) null && a.id == info.playerUnit.id)).HasValue)
          info.for_battle = true;
        UnitIconInfo unitIconInfo = ((IEnumerable<UnitIconInfo>) array).FirstOrDefault<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => x.playerUnit.id == info.playerUnit.id));
        if (unitIconInfo != null)
        {
          info.gray = true;
          info.select = unitIconInfo.select;
          this.selectedUnitIcons.Add(info);
        }
      }
    }
    this.ReflectionSelectUnit();
    this.CreateSelectUnitList(updateIndex);
    this.updateTxtCostValue(this.GetUsedCost());
  }

  protected void CreateSelectUnitList(bool updateIndex = true)
  {
    this.selectedUnitIcons.Clear();
    this.selectedUnitIcons = this.allUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => x.select >= 0)).OrderBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (x => x.select)).ToList<UnitIconInfo>();
    this.selectedUnitIcons.ForEachIndex<UnitIconInfo>((Action<UnitIconInfo, int>) ((u, n) =>
    {
      if (updateIndex)
        u.select = n;
      this.UnitInfoUpdate(u, true, u.select);
    }));
  }

  private UnitIcon CreateUnitObject(GameObject parent)
  {
    UnitIcon component = (Object.Instantiate((Object) this.unitPrefab, new Vector3(10000f, 0.0f, 0.0f), new Quaternion()) as GameObject).GetComponent<UnitIcon>();
    GameObject gameObject = ((Component) component).gameObject;
    ((Object) gameObject).name = this.IconObjName;
    gameObject.SetActive(true);
    parent.transform.Clear();
    gameObject.transform.parent = parent.transform;
    gameObject.transform.localPosition = Vector3.zero;
    UIWidget componentInChildren = parent.GetComponentInChildren<UIWidget>();
    gameObject.GetComponentInChildren<UnitIcon>().SetSize(componentInChildren.width, componentInChildren.height);
    return component;
  }

  [DebuggerHidden]
  private IEnumerator CreateBottomInformationObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Menu.\u003CCreateBottomInformationObject\u003Ec__Iterator2A5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetSelectUnit(UnitIconInfo info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Menu.\u003CSetSelectUnit\u003Ec__Iterator2A6()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator DisplaySelectUnit()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Menu.\u003CDisplaySelectUnit\u003Ec__Iterator2A7()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetWidgetAlpha(bool canDisp, GameObject obj)
  {
    UIWidget component = obj.GetComponent<UIWidget>();
    if (Object.op_Inequality((Object) component, (Object) null))
      component.alpha = !canDisp ? 0.0f : 1f;
    else
      obj.SetActive(canDisp);
  }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerDeck playerDeck,
    PlayerUnit[] playerUnits,
    Promise<int?[]> player_unit_ids,
    int max_cost,
    bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Menu.\u003CInit\u003Ec__Iterator2A8()
    {
      playerDeck = playerDeck,
      max_cost = max_cost,
      player_unit_ids = player_unit_ids,
      playerUnits = playerUnits,
      isEquip = isEquip,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003Emax_cost = max_cost,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual int GetUsedCost()
  {
    int cost = 0;
    this.selectedUnitIcons.ForEach((Action<UnitIconInfo>) (x => cost += x.playerUnit.unit.cost));
    return cost;
  }

  public override void UpdateInfomation()
  {
    this.StartCoroutine(this.DisplaySelectUnit());
    this.updateTxtCostValue(this.GetUsedCost());
  }

  [DebuggerHidden]
  protected virtual IEnumerator DeckEditAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Menu.\u003CDeckEditAsync\u003Ec__Iterator2A9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator DeckEditApi(int deckTypeID, int deckNumber, int[] playerUnitIds)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468Menu.\u003CDeckEditApi\u003Ec__Iterator2AA()
    {
      deckTypeID = deckTypeID,
      deckNumber = deckNumber,
      playerUnitIds = playerUnitIds,
      \u003C\u0024\u003EdeckTypeID = deckTypeID,
      \u003C\u0024\u003EdeckNumber = deckNumber,
      \u003C\u0024\u003EplayerUnitIds = playerUnitIds
    };
  }

  public override void IbtnYes()
  {
    if (this.IsPush)
      return;
    this.StartCoroutine(this.DeckEditAsync());
  }

  public override void IbtnBack()
  {
    if (this.playerUnitIds != null && !this.playerUnitIds.HasResult)
      this.playerUnitIds.Result = (int?[]) null;
    base.IbtnBack();
  }

  private void IconGraySetting(UnitIconBase unitIcon, UnitIconInfo info)
  {
    if (this.selectedUnitIcons.Count<UnitIconInfo>() >= this.SelectMax)
      unitIcon.Gray = !info.gray;
    else if (this.totalCost >= this.maxCost)
      unitIcon.Gray = !info.gray;
    else if (info.select >= 0)
      unitIcon.Gray = info.gray;
    else if (info.playerUnit.unit.cost <= this.maxCost - this.totalCost)
      unitIcon.Gray = info.gray;
    else
      unitIcon.Gray = !info.gray;
  }

  protected override void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase allUnitIcon = this.allUnitIcons[unit_index];
    UnitIconInfo displayUnitInfo = this.displayUnitInfos[info_index];
    if (displayUnitInfo.removeButton)
    {
      displayUnitInfo.gray = false;
      allUnitIcon.Gray = false;
    }
    else
    {
      displayUnitInfo.gray = false;
      if (displayUnitInfo.select >= 0)
      {
        displayUnitInfo.gray = true;
        if (this.iconSelMode == UnitSelectMenuBase.IconSelMode.Number)
          displayUnitInfo.icon.Select(displayUnitInfo.select);
        else
          displayUnitInfo.icon.SelectByCheckIcon();
      }
      allUnitIcon.onClick = (Action<UnitIconBase>) (ui => this.Select(ui));
      if (displayUnitInfo.button_enable)
      {
        ((Behaviour) allUnitIcon.button).enabled = true;
      }
      else
      {
        ((Behaviour) allUnitIcon.button).enabled = false;
        displayUnitInfo.gray = true;
      }
      if (this.selectedUnitIcons.Count >= this.SelectMax)
        allUnitIcon.Gray = !displayUnitInfo.gray;
      else
        this.IconGraySetting(allUnitIcon, displayUnitInfo);
    }
  }

  public override void UpdateSelectIcon()
  {
    this.selectedUnitIcons.ForEachIndex<UnitIconInfo>((Action<UnitIconInfo, int>) ((u, n) =>
    {
      UnitIconInfo unitInfoDisplay = this.GetUnitInfoDisplay(u.playerUnit);
      if (unitInfoDisplay == null || !Object.op_Inequality((Object) unitInfoDisplay.icon, (Object) null))
        return;
      unitInfoDisplay.gray = true;
      if (this.iconSelMode == UnitSelectMenuBase.IconSelMode.Number)
        unitInfoDisplay.icon.Select(unitInfoDisplay.select);
      else
        unitInfoDisplay.icon.SelectByCheckIcon();
    }));
    foreach (UnitIconInfo displayUnitInfo in this.displayUnitInfos)
    {
      if (Object.op_Inequality((Object) displayUnitInfo.icon, (Object) null))
        this.IconGraySetting(displayUnitInfo.icon, displayUnitInfo);
    }
  }

  protected override void Select(UnitIconBase unitIcon)
  {
    if (unitIcon.Selected)
    {
      this.Deselect(unitIcon);
      this.UpdateInfomation();
      this.UpdateSelectIcon();
    }
    else
    {
      if (this.selectedUnitIcons.Count >= this.SelectMax || unitIcon.Unit.cost > this.maxCost - this.totalCost)
        return;
      if (this.iconSelMode == UnitSelectMenuBase.IconSelMode.Number)
      {
        if (this.isSelectNumPack)
          unitIcon.Select(this.selectedUnitIcons.Count);
        else
          unitIcon.Select(this.GetMinSelectIndex());
      }
      else
        unitIcon.SelectByCheckIcon();
      UnitIconInfo unitInfoAll = this.GetUnitInfoAll(unitIcon.PlayerUnit);
      if (unitInfoAll != null)
      {
        this.UnitInfoUpdate(unitInfoAll, true, unitIcon.SelIndex);
        this.selectedUnitIcons.Add(unitInfoAll);
      }
      UnitIconInfo unitInfoDisplay = this.GetUnitInfoDisplay(unitIcon.PlayerUnit);
      if (unitInfoDisplay != null)
        this.UnitInfoUpdate(unitInfoDisplay, true, unitIcon.SelIndex);
      this.UpdateInfomation();
      this.UpdateSelectIcon();
    }
  }

  protected override void CreateUnitIconCache(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    base.CreateUnitIconCache(info_index, unit_index);
    this.CreateUnitIconAction(info_index, unit_index);
  }
}
