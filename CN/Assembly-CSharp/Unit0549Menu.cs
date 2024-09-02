// Decompiled with JetBrains decompiler
// Type: Unit0549Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit0549Menu : Unit00411Menu
{
  [DebuggerHidden]
  public IEnumerator Init(PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0549Menu.\u003CInit\u003Ec__Iterator77B()
    {
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  protected override void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase unitIcon = this.allUnitIcons[unit_index];
    unitIcon.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
    ((UnitIcon) unitIcon).SetEarthButtonDetalEvent(this.allUnitInfos[info_index].playerUnit, this.getUnits());
    if (unitIcon.Unit.IsMaterialUnit)
      unitIcon.onClick = (Action<UnitIconBase>) (ui => this.ChangeEvolutionScene(unitIcon.PlayerUnit));
    else
      unitIcon.onClick = (Action<UnitIconBase>) (ui => this.ChangeEvolutionScene(unitIcon.PlayerUnit));
  }

  private void ChangeEvolutionScene(PlayerUnit selectUnit)
  {
    Unit05499Scene.ChangeScene(true, selectUnit);
  }
}
