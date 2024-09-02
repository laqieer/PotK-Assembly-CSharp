// Decompiled with JetBrains decompiler
// Type: Unit004682Menu
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
public class Unit004682Menu : Unit00468Menu
{
  private const int FIRST_DECK = 0;
  private const int LAST_MEMBER = 1;
  private int changeNumber;

  protected override void Sort(
    UnitSortAndFilter.SORT_TYPES type = UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy,
    SortAndFilter.SORT_TYPE_ORDER_BUY order = SortAndFilter.SORT_TYPE_ORDER_BUY.ASCENDING,
    bool[] filterFlg = null)
  {
    this.BaseSort(type, order, filterFlg);
  }

  protected override int GetUsedCost()
  {
    int cost = 0;
    this.selectedUnitIcons.ForEach((Action<UnitIconInfo>) (x => cost += x.playerUnit.unit.cost));
    UnitIconInfo unitIconInfo = this.selectedUnitIcons.FirstOrDefault<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => x.select == this.changeNumber));
    if (unitIconInfo != null)
      cost -= unitIconInfo.playerUnit.unit.cost;
    return cost;
  }

  protected override void updateTxtCostValue(int cost = 0) => this.totalCost = cost;

  public override void UpdateInfomation()
  {
  }

  public override void InitializeAllUnitInfosExtend(PlayerDeck playerDeck)
  {
    this.selectedUnitIcons.Clear();
    foreach (UnitIconInfo allUnitInfo in this.allUnitInfos)
    {
      UnitIconInfo info = allUnitInfo;
      info.select = -1;
      info.for_battle = false;
      if (!info.removeButton)
      {
        int? nullable = ((IEnumerable<PlayerUnit>) playerDeck.player_units).FirstIndexOrNull<PlayerUnit>((Func<PlayerUnit, bool>) (a => a != (PlayerUnit) null && a.id == info.playerUnit.id));
        if (nullable.HasValue)
        {
          info.select = nullable.Value;
          info.for_battle = true;
          this.selectedUnitIcons.Add(info);
        }
      }
    }
    this.ReflectionSelectUnit();
    this.CreateSelectUnitList(true);
    this.updateTxtCostValue(this.GetUsedCost());
  }

  private bool GetRemoveBtnFlg(PlayerDeck playerDeck, int number)
  {
    bool removeBtnFlg = false;
    if (playerDeck.player_unit_ids[number].HasValue)
    {
      removeBtnFlg = true;
      int num = 0;
      foreach (PlayerUnit playerUnit in playerDeck.player_units)
      {
        if (playerUnit != (PlayerUnit) null)
          ++num;
      }
      if (playerDeck.deck_number == 0 && num <= 1)
        removeBtnFlg = false;
    }
    return removeBtnFlg;
  }

  [DebuggerHidden]
  public IEnumerator Init(
    Player player,
    PlayerDeck playerDeck,
    PlayerUnit[] playerUnits,
    Promise<int?[]> player_unit_ids,
    int max_cost,
    int number,
    bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004682Menu.\u003CInit\u003Ec__Iterator2AB()
    {
      player_unit_ids = player_unit_ids,
      number = number,
      playerDeck = playerDeck,
      max_cost = max_cost,
      playerUnits = playerUnits,
      isEquip = isEquip,
      player = player,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u0024\u003Enumber = number,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003Emax_cost = max_cost,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u003Ef__this = this
    };
  }

  private void DeckRemove(UnitIconBase ui)
  {
    ModelUnits.Instance.DestroyModelUnits();
    int? nullable = this.allUnitInfos.FirstIndexOrNull<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => v.playerUnit != (PlayerUnit) null && v.select == this.changeNumber));
    if (!nullable.HasValue)
      return;
    UnitIconInfo allUnitInfo = this.allUnitInfos[nullable.Value];
    if (allUnitInfo != null && !allUnitInfo.removeButton)
      allUnitInfo.select = -1;
    this.CreateSelectUnitList(true);
    this.StartCoroutine(this.DeckEditAsync());
  }

  private void DeckEdit(UnitIconBase ui)
  {
    ModelUnits.Instance.DestroyModelUnits();
    int? nullable = this.allUnitInfos.FirstIndexOrNull<UnitIconInfo>((Func<UnitIconInfo, bool>) (v => v.playerUnit != (PlayerUnit) null && v.select == this.changeNumber));
    if (nullable.HasValue)
    {
      UnitIconInfo allUnitInfo = this.allUnitInfos[nullable.Value];
      if (allUnitInfo != null && !allUnitInfo.removeButton)
        allUnitInfo.select = -1;
    }
    UnitIconInfo unitInfoAll = this.GetUnitInfoAll(ui.PlayerUnit);
    if (unitInfoAll != null && !unitInfoAll.removeButton)
      unitInfoAll.select = this.changeNumber;
    this.CreateSelectUnitList(true);
    this.StartCoroutine(this.DeckEditAsync());
  }

  [DebuggerHidden]
  protected override IEnumerator DeckEditAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004682Menu.\u003CDeckEditAsync\u003Ec__Iterator2AC()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase allUnitIcon = this.allUnitIcons[unit_index];
    UnitIconInfo displayUnitInfo = this.displayUnitInfos[info_index];
    if (displayUnitInfo.removeButton)
    {
      allUnitIcon.onClick = (Action<UnitIconBase>) (ui => this.DeckRemove(ui));
      allUnitIcon.Gray = false;
      ((Behaviour) allUnitIcon.button).enabled = true;
    }
    else
    {
      allUnitIcon.onClick = (Action<UnitIconBase>) (ui => this.DeckEdit(ui));
      if (allUnitIcon.Unit.cost > this.maxCost - this.totalCost || displayUnitInfo.select != -1 && displayUnitInfo.select != this.changeNumber)
      {
        displayUnitInfo.gray = true;
        allUnitIcon.Gray = true;
        ((Behaviour) allUnitIcon.button).enabled = false;
      }
      else
      {
        displayUnitInfo.gray = false;
        allUnitIcon.Gray = false;
        ((Behaviour) allUnitIcon.button).enabled = true;
      }
      allUnitIcon.numberBase.SetActive(false);
    }
  }
}
