// Decompiled with JetBrains decompiler
// Type: Unit0544Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;

#nullable disable
public class Unit0544Menu : Unit0044Menu
{
  public override IEnumerator InitPlayerGears(
    Player player,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] playerUnits,
    List<InventoryItem> playerGears,
    int index)
  {
    this.isEarthMode = true;
    return base.InitPlayerGears(player, basePlayerUnit, playerUnits, playerGears, index);
  }

  protected override void ChangeDetailScene(PlayerItem gear)
  {
    Unit05443Scene.changeSceneLimited(true, gear);
  }

  protected override void SetPosessionText(int value, int max)
  {
    this.TxtNumberpossession.SetTextLocalize(string.Format("{0}", (object) value));
  }
}
