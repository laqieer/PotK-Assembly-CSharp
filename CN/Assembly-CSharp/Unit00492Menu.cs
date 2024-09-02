// Decompiled with JetBrains decompiler
// Type: Unit00492Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00492Menu : UnitMenuBase
{
  private Unit00492Menu.Param param_;

  [DebuggerHidden]
  public IEnumerator coInitialize(Unit00492Menu.Param param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00492Menu.\u003CcoInitialize\u003Ec__Iterator325()
    {
      param = param,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator coUpdateUnits(PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00492Menu.\u003CcoUpdateUnits\u003Ec__Iterator326()
    {
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  private void onSelectUnitIcon(UnitIconBase icon)
  {
    if (this.IsPush)
      return;
    if (icon.PlayerUnit != (PlayerUnit) null)
    {
      this.IsPush = true;
      this.lastReferenceUnitID = icon.PlayerUnit.id;
      this.lastReferenceUnitIndex = this.GetUnitInfoDisplayIndex(icon.PlayerUnit);
      this.param_.onResult_(icon.PlayerUnit);
      this.backScene();
    }
    else
      Debug.LogWarning((object) "PlayerUnit Null : Unit00492Menu");
  }

  [DebuggerHidden]
  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00492Menu.\u003CCreateUnitIcon\u003Ec__Iterator327()
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
    this.setupIconCustom(this.allUnitIcons[unit_index]);
  }

  private void setupIconCustom(UnitIconBase icon)
  {
    if (icon.PlayerUnit == (PlayerUnit) null)
    {
      icon.button.isEnabled = false;
    }
    else
    {
      PlayerUnit playerUnit = icon.PlayerUnit;
      if (!playerUnit.favorite && !playerUnit.CheckForBattle() && !this.isSelected(playerUnit))
      {
        icon.Gray = false;
        icon.onClick = (Action<UnitIconBase>) (ui => this.onSelectUnitIcon(ui));
      }
      else if (this.param_.baseUnit_ != (PlayerUnit) null && this.param_.baseUnit_.id == playerUnit.id)
      {
        icon.SelectByCheckIcon(false);
        icon.onClick = (Action<UnitIconBase>) (ui => this.onSelectUnitIcon(ui));
      }
      else
      {
        if (this.isSelected(playerUnit))
          icon.SelectByCheckIcon();
        else
          icon.Gray = true;
        icon.onClick = (Action<UnitIconBase>) (ui => { });
      }
    }
  }

  private bool isSelected(PlayerUnit unit)
  {
    return this.param_.baseUnit_ != (PlayerUnit) null && this.param_.baseUnit_.id == unit.id || ((IEnumerable<PlayerUnit>) this.param_.selectedUnits_).Any<PlayerUnit>((Func<PlayerUnit, bool>) (pu => pu.id == unit.id));
  }

  public class Param
  {
    public PlayerUnit baseUnit_;
    public PlayerUnit[] selectedUnits_;
    public PlayerUnit[] units_;
    public Unit00492Menu.Param.EventUpdateUnit onUpdate_;
    public Unit00492Menu.Param.EventResult onResult_;

    public delegate void EventResult(PlayerUnit selected);

    public delegate void EventUpdateUnit(PlayerUnit unit);
  }
}
