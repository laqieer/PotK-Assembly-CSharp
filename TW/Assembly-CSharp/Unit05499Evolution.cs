// Decompiled with JetBrains decompiler
// Type: Unit05499Evolution
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit05499Evolution : Unit00499Evolution
{
  [DebuggerHidden]
  protected override IEnumerator CreateIndicator(
    int evolutionPatternId,
    PlayerUnit[] playerUnits,
    PlayerMaterialUnit[] playerMaterialUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05499Evolution.\u003CCreateIndicator\u003Ec__Iterator845()
    {
      evolutionPatternId = evolutionPatternId,
      playerUnits = playerUnits,
      playerMaterialUnits = playerMaterialUnits,
      \u003C\u0024\u003EevolutionPatternId = evolutionPatternId,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EplayerMaterialUnits = playerMaterialUnits,
      \u003C\u003Ef__this = this
    };
  }
}
