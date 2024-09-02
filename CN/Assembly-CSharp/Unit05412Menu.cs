// Decompiled with JetBrains decompiler
// Type: Unit05412Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit05412Menu : Unit00412Menu
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
    return (IEnumerator) new Unit05412Menu.\u003CInit\u003Ec__Iterator763()
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
    UnitIconBase allUnitIcon = this.allUnitIcons[unit_index];
    ((UnitIcon) allUnitIcon).SetEarthButtonDetalEvent(this.allUnitInfos[info_index].playerUnit, this.getUnits());
    allUnitIcon.onClick = (Action<UnitIconBase>) (ui => Unit0544Scene.changeScene(true, this.allUnitInfos[info_index].playerUnit, 1));
  }
}
