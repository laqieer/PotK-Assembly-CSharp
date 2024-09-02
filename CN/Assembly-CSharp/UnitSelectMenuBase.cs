// Decompiled with JetBrains decompiler
// Type: UnitSelectMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class UnitSelectMenuBase : UnitMenuBase
{
  [SerializeField]
  protected UnitSelectMenuBase.IconSelMode iconSelMode;
  [SerializeField]
  private int SELECT_MAX = 10;
  protected List<UnitIconInfo> selectedUnitIcons = new List<UnitIconInfo>();
  [SerializeField]
  protected bool isSelectNumPack = true;

  public int SelectMax
  {
    set => this.SELECT_MAX = value;
    get => this.SELECT_MAX;
  }

  public override void IbtnClearS()
  {
    if (this.IsPush)
      return;
    foreach (UnitIconBase allUnitIcon in this.allUnitIcons)
    {
      this.Deselect(allUnitIcon);
      if (((Behaviour) allUnitIcon.button).enabled)
        allUnitIcon.Gray = false;
    }
    this.allUnitInfos.ForEach((Action<UnitIconInfo>) (v => v.select = -1));
    this.displayUnitInfos.ForEach((Action<UnitIconInfo>) (v => v.select = -1));
    this.selectedUnitIcons.Clear();
    this.UpdateInfomation();
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public virtual void UpdateInfomation()
  {
  }

  protected void UnitInfoUpdate(UnitIconInfo info, bool enable, int cnt)
  {
    info.gray = enable;
    info.select = cnt;
  }

  public virtual void UpdateSelectIcon()
  {
    foreach (UnitIconInfo displayUnitInfo in this.displayUnitInfos)
    {
      if (Object.op_Inequality((Object) displayUnitInfo.icon, (Object) null) && ((Behaviour) displayUnitInfo.icon.button).enabled)
        displayUnitInfo.icon.Gray = this.selectedUnitIcons.Count < this.SelectMax ? displayUnitInfo.select != -1 || displayUnitInfo.gray : !displayUnitInfo.gray;
    }
    this.selectedUnitIcons.ForEachIndex<UnitIconInfo>((Action<UnitIconInfo, int>) ((u, n) =>
    {
      UnitIconInfo unitInfoDisplay = this.GetUnitInfoDisplay(u.playerUnit);
      if (unitInfoDisplay == null || !Object.op_Inequality((Object) unitInfoDisplay.icon, (Object) null))
        return;
      if (this.iconSelMode == UnitSelectMenuBase.IconSelMode.Number)
        unitInfoDisplay.icon.Select(unitInfoDisplay.select);
      else if (unitInfoDisplay.icon.unit.IsNormalUnit)
        unitInfoDisplay.icon.SelectByCheckIcon();
      else
        unitInfoDisplay.icon.HideCheckIcon();
    }));
    this.UpdateInfomation();
  }

  protected void ReflectionSelectUnit()
  {
    this.selectedUnitIcons = this.selectedUnitIcons.OrderBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (v => v.select)).ToList<UnitIconInfo>();
    this.selectedUnitIcons.ForEach((Action<UnitIconInfo>) (u =>
    {
      UnitIconInfo unitInfoAll = this.GetUnitInfoAll(u.playerUnit);
      if (unitInfoAll == null)
        return;
      unitInfoAll.SelectedCount = u.SelectedCount;
      unitInfoAll.select = u.select;
    }));
    this.selectedUnitIcons.Clear();
  }

  protected void ConsiderFavoriteUnit()
  {
    this.allUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => !v.playerUnit.favorite && v.select == -1)).ForEach<UnitIconInfo>((Action<UnitIconInfo>) (v =>
    {
      v.gray = false;
      v.button_enable = true;
    }));
  }

  protected void IgnoreFavoriteUnit()
  {
    this.allUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => v.playerUnit.favorite)).ForEach<UnitIconInfo>((Action<UnitIconInfo>) (v =>
    {
      v.select = -1;
      v.gray = true;
      v.button_enable = false;
    }));
  }

  protected void IgnoreDeckUnit(PlayerDeck[] playerDeck)
  {
    foreach (PlayerDeck playerDeck1 in playerDeck)
    {
      if (playerDeck1 != null)
      {
        foreach (PlayerUnit playerUnit in playerDeck1.player_units)
        {
          PlayerUnit unit = playerUnit;
          if (!(unit == (PlayerUnit) null))
          {
            UnitIconInfo unitIconInfo = this.allUnitInfos.FirstOrDefault<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => x.playerUnit != (PlayerUnit) null && !x.removeButton && unit.id == x.playerUnit.id));
            if (unitIconInfo != null)
            {
              unitIconInfo.select = -1;
              unitIconInfo.gray = true;
              unitIconInfo.button_enable = false;
            }
          }
        }
      }
    }
  }

  protected void CreateSelectUnitList()
  {
    this.selectedUnitIcons.Clear();
    this.selectedUnitIcons = this.allUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => x.select >= 0)).OrderBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (x => x.select)).ToList<UnitIconInfo>();
    this.selectedUnitIcons.ForEachIndex<UnitIconInfo>((Action<UnitIconInfo, int>) ((u, n) =>
    {
      u.select = n;
      this.UnitInfoUpdate(u, true, n);
    }));
  }

  public virtual void InitializeAllUnitInfosExtend(PlayerDeck[] playerDeck)
  {
    this.ReflectionSelectUnit();
    this.ConsiderFavoriteUnit();
    this.IgnoreFavoriteUnit();
    this.IgnoreDeckUnit(playerDeck);
    this.CreateSelectUnitList();
  }

  protected virtual void Deselect(UnitIconBase unitIcon)
  {
    if (!unitIcon.Selected)
      return;
    if (this.iconSelMode == UnitSelectMenuBase.IconSelMode.Number)
      unitIcon.Deselect();
    else
      unitIcon.DeselectByCheckIcon();
    UnitIconInfo unitInfoAll1 = this.GetUnitInfoAll(unitIcon.PlayerUnit);
    if (unitInfoAll1 != null)
    {
      this.UnitInfoUpdate(unitInfoAll1, false, -1);
      this.selectedUnitIcons.Remove(unitInfoAll1);
    }
    UnitIconInfo unitInfoDisplay1 = this.GetUnitInfoDisplay(unitIcon.PlayerUnit);
    if (unitInfoDisplay1 != null)
      this.UnitInfoUpdate(unitInfoDisplay1, false, -1);
    if (!this.isSelectNumPack)
      return;
    this.selectedUnitIcons = this.selectedUnitIcons.OrderBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (v => v.select)).ToList<UnitIconInfo>();
    this.selectedUnitIcons.ForEachIndex<UnitIconInfo>((Action<UnitIconInfo, int>) ((u, n) =>
    {
      UnitIconInfo unitInfoAll2 = this.GetUnitInfoAll(u.playerUnit);
      if (unitInfoAll2 != null)
      {
        unitInfoAll2.select = n;
        this.UnitInfoUpdate(unitInfoAll2, true, n);
      }
      UnitIconInfo unitInfoDisplay2 = this.GetUnitInfoDisplay(u.playerUnit);
      if (unitInfoDisplay2 == null)
        return;
      unitInfoDisplay2.select = n;
    }));
  }

  protected int GetMinSelectIndex(int min = 0)
  {
    this.selectedUnitIcons.OrderBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (x => x.select)).ForEach<UnitIconInfo>((Action<UnitIconInfo>) (x =>
    {
      if (min < x.select)
        return;
      min = x.select + 1;
    }));
    if (min > this.SelectMax)
      min = this.SelectMax;
    return min;
  }

  protected virtual void Select(UnitIconBase unitIcon)
  {
    if (unitIcon.Selected)
    {
      this.Deselect(unitIcon);
      this.UpdateSelectIcon();
    }
    else if (this.selectedUnitIcons.Count < this.SelectMax)
    {
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
      if (this.selectedUnitIcons.Count >= this.SelectMax)
      {
        foreach (UnitIconInfo allUnitInfo in this.allUnitInfos)
        {
          if (Object.op_Inequality((Object) allUnitInfo.icon, (Object) null) && ((Behaviour) allUnitInfo.icon.button).enabled)
            allUnitInfo.icon.Gray = !allUnitInfo.gray;
        }
      }
    }
    this.UpdateInfomation();
  }

  protected override void ResetUnitIcon(int index)
  {
    base.ResetUnitIcon(index);
    this.Deselect(this.allUnitIcons[index]);
  }

  [DebuggerHidden]
  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitSelectMenuBase.\u003CCreateUnitIcon\u003Ec__Iterator2FC()
    {
      info_index = info_index,
      unit_index = unit_index,
      baseUnit = baseUnit,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u0024\u003Eunit_index = unit_index,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u003Ef__this = this
    };
  }

  protected override void CreateUnitIconCache(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    base.CreateUnitIconCache(info_index, unit_index, baseUnit);
    this.CreateUnitIconAction(info_index, unit_index);
  }

  protected virtual void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase allUnitIcon = this.allUnitIcons[unit_index];
    UnitIconInfo displayUnitInfo = this.displayUnitInfos[info_index];
    displayUnitInfo.gray = false;
    if (displayUnitInfo.select >= 0)
    {
      if (this.iconSelMode == UnitSelectMenuBase.IconSelMode.Number)
        displayUnitInfo.icon.Select(displayUnitInfo.select);
      else if (displayUnitInfo.icon.unit.IsNormalUnit)
        displayUnitInfo.icon.SelectByCheckIcon();
      else
        displayUnitInfo.icon.HideCheckIcon();
      displayUnitInfo.gray = true;
    }
    allUnitIcon.SetCounter(displayUnitInfo.count);
    allUnitIcon.SetSelectionCounter(displayUnitInfo.SelectedCount);
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
    if (this.selectedUnitIcons.Count >= this.SelectMax && displayUnitInfo.button_enable)
      allUnitIcon.Gray = !displayUnitInfo.gray;
    else
      allUnitIcon.Gray = displayUnitInfo.gray;
  }

  protected enum IconSelMode
  {
    Number,
    Check,
  }
}
