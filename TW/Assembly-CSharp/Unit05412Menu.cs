// Decompiled with JetBrains decompiler
// Type: Unit05412Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  public override IEnumerator Init(
    Player player,
    PlayerUnit[] playerUnits,
    bool isEquip,
    bool forBattle = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05412Menu.\u003CInit\u003Ec__Iterator82A()
    {
      playerUnits = playerUnits,
      isEquip = isEquip,
      forBattle = forBattle,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003EforBattle = forBattle,
      \u003C\u003Ef__this = this
    };
  }

  protected override void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase allUnitIcon = this.allUnitIcons[unit_index];
    ((UnitIcon) allUnitIcon).SetEarthButtonDetalEvent(this.allUnitInfos[info_index].playerUnit, this.getUnits());
    allUnitIcon.onClick = (Action<UnitIconBase>) (ui => Unit0544Scene.ChangeScene(true, this.allUnitInfos[info_index].playerUnit, 1));
  }
}
