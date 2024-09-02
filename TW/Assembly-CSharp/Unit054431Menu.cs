// Decompiled with JetBrains decompiler
// Type: Unit054431Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public class Unit054431Menu : Unit004431Menu
{
  protected override PlayerItem[] GetAllGears(PlayerItem[] items)
  {
    return ((IEnumerable<PlayerItem>) items).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear != null)).ToArray<PlayerItem>();
  }

  public override IEnumerator Init(
    Player player,
    PlayerUnit[] playerUnits,
    Unit004431Menu.Param sendParam,
    bool isEquip)
  {
    this.isEarthMode = true;
    this.SetIconType(UnitMenuBase.IconType.Normal);
    return base.Init(player, playerUnits, sendParam, isEquip);
  }

  protected override void ChangeDetailScehe(PlayerUnit unit)
  {
    Unit0542Scene.changeSceneEvolutionUnit(true, unit, this.getUnits());
  }
}
