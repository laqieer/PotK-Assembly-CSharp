// Decompiled with JetBrains decompiler
// Type: Unit054431Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
