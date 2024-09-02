// Decompiled with JetBrains decompiler
// Type: Unit00412Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00412Menu : UnitMenuBase
{
  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(Player player, PlayerUnit[] playerUnits, bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00412Menu.\u003CInit\u003Ec__Iterator29B()
    {
      playerUnits = playerUnits,
      isEquip = isEquip,
      player = player,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00412Menu.\u003CCreateUnitIcon\u003Ec__Iterator29C()
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
    this.CreateUnitIconAction(info_index, unit_index);
  }

  protected virtual void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase unitIcon = this.allUnitIcons[unit_index];
    if (unitIcon.PlayerUnit == (PlayerUnit) null)
      Debug.LogError((object) "unit0412 CreateUnitIconAction PlayerUnit == null");
    unitIcon.onClick = (Action<UnitIconBase>) (ui =>
    {
      this.lastReferenceUnitID = unitIcon.PlayerUnit.id;
      this.lastReferenceUnitIndex = this.GetUnitInfoDisplayIndex(unitIcon.PlayerUnit);
      Unit0044Scene.changeScene(true, unitIcon.PlayerUnit, 1);
    });
  }
}
