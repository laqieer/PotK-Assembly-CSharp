// Decompiled with JetBrains decompiler
// Type: Unit00481Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00481Menu : Unit0048Menu
{
  [DebuggerHidden]
  public override IEnumerator Init(Player player, PlayerUnit[] playerUnits, bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00481Menu.\u003CInit\u003Ec__Iterator2B8()
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
}
