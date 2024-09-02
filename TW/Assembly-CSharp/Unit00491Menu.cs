﻿// Decompiled with JetBrains decompiler
// Type: Unit00491Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00491Menu : UnitMenuBase
{
  private bool IsToucn = true;
  private Unit00491Menu.Mode mode;
  private int unitCount;

  public void EnableTouch() => this.Invoke("Touch", 1f);

  private void Touch() => this.IsToucn = true;

  public bool IsInit()
  {
    return ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Count<PlayerUnit>() != this.unitCount;
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  public IEnumerator Init(
    Player player,
    PlayerUnit[] playerUnits,
    PlayerMaterialUnit[] playerMaterialUnits,
    bool isEquip,
    Unit00491Menu.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00491Menu.\u003CInit\u003Ec__Iterator363()
    {
      mode = mode,
      playerUnits = playerUnits,
      playerMaterialUnits = playerMaterialUnits,
      isEquip = isEquip,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EplayerMaterialUnits = playerMaterialUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator UpdateInfoAndScroll(
    PlayerUnit[] playerUnits,
    PlayerMaterialUnit[] materialUnits = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00491Menu.\u003CUpdateInfoAndScroll\u003Ec__Iterator364()
    {
      playerUnits = playerUnits,
      materialUnits = materialUnits,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EmaterialUnits = materialUnits,
      \u003C\u003Ef__this = this
    };
  }

  private void SelectUnitIcon(UnitIconBase unitIcon)
  {
    if (!this.IsToucn)
      return;
    if (unitIcon.PlayerUnit != (PlayerUnit) null)
    {
      this.lastReferenceUnitID = unitIcon.PlayerUnit.id;
      this.lastReferenceUnitIndex = this.GetUnitInfoDisplayIndex(unitIcon.PlayerUnit);
      if (this.mode == Unit00491Menu.Mode.Evolution)
        Unit00499Scene.changeScene(true, unitIcon.PlayerUnit, Unit00499Scene.Mode.Evolution);
      else
        Unit00499Scene.changeScene(true, unitIcon.PlayerUnit, Unit00499Scene.Mode.Transmigration);
    }
    else
      Debug.LogWarning((object) "PlayerUnit Null : Unit00491Menu");
    this.IsToucn = false;
  }

  [DebuggerHidden]
  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00491Menu.\u003CCreateUnitIcon\u003Ec__Iterator365()
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
    base.CreateUnitIconCache(info_index, unit_index);
    this.allUnitIcons[unit_index].onClick = (Action<UnitIconBase>) (ui => this.SelectUnitIcon(ui));
  }

  public enum Mode
  {
    Evolution,
    Trans,
  }
}
