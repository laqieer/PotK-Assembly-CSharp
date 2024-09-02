// Decompiled with JetBrains decompiler
// Type: Unit05411Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit05411Menu : Unit00411Menu
{
  [SerializeField]
  private UILabel TxtUnitCount;

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  public override IEnumerator Init(Player player, PlayerUnit[] playerUnits, bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05411Menu.\u003CInit\u003Ec__Iterator61A()
    {
      playerUnits = playerUnits,
      isEquip = isEquip,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u003Ef__this = this
    };
  }

  protected override void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase unitIcon = this.allUnitIcons[unit_index];
    unitIcon.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
    ((UnitIcon) unitIcon).SetEarthButtonDetalEvent(this.allUnitInfos[info_index].playerUnit, this.getUnits());
    unitIcon.onClick = (Action<UnitIconBase>) (ui => Unit0542Scene.changeScene(true, unitIcon.PlayerUnit, this.getUnits()));
  }
}
