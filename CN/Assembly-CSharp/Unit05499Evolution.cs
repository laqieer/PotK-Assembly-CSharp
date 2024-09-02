// Decompiled with JetBrains decompiler
// Type: Unit05499Evolution
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Unit05499Evolution.\u003CCreateIndicator\u003Ec__Iterator77E()
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
