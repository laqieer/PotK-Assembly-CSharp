// Decompiled with JetBrains decompiler
// Type: Unit00468GvgMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
public class Unit00468GvgMenu : Unit00468Menu
{
  private GuildUtil.GvGPopupState state;

  private void InitializeAllUnitInfosExtend(GvgDeck gvgDeck)
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
        int? nullable = ((IEnumerable<PlayerUnit>) gvgDeck.player_units).FirstIndexOrNull<PlayerUnit>((Func<PlayerUnit, bool>) (a => a != (PlayerUnit) null && a.id == info.playerUnit.id));
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
        if (((IEnumerable<PlayerUnit>) gvgDeck.player_units).FirstIndexOrNull<PlayerUnit>((Func<PlayerUnit, bool>) (a => a != (PlayerUnit) null && a.id == info.playerUnit.id)).HasValue)
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

  [DebuggerHidden]
  public IEnumerator Init(
    GvgDeck gvgDeck,
    PlayerUnit[] playerUnits,
    Promise<int?[]> player_unit_ids,
    int max_cost,
    bool isEquip,
    GuildUtil.GvGPopupState state)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468GvgMenu.\u003CInit\u003Ec__Iterator354()
    {
      max_cost = max_cost,
      player_unit_ids = player_unit_ids,
      playerUnits = playerUnits,
      isEquip = isEquip,
      gvgDeck = gvgDeck,
      state = state,
      \u003C\u0024\u003Emax_cost = max_cost,
      \u003C\u0024\u003Eplayer_unit_ids = player_unit_ids,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003EgvgDeck = gvgDeck,
      \u003C\u0024\u003Estate = state,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator DeckEditAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00468GvgMenu.\u003CDeckEditAsync\u003Ec__Iterator355()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void IbtnYes()
  {
    if (this.IsPush)
      return;
    this.StartCoroutine(this.DeckEditAsync());
  }
}
