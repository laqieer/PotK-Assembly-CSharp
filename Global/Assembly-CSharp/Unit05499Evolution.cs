// Decompiled with JetBrains decompiler
// Type: Unit05499Evolution
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit05499Evolution : Unit00499Evolution
{
  [DebuggerHidden]
  protected override IEnumerator CreateIndicator(int evolutionPatturnId, PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05499Evolution.\u003CCreateIndicator\u003Ec__Iterator637()
    {
      evolutionPatturnId = evolutionPatturnId,
      playerUnits = playerUnits,
      \u003C\u0024\u003EevolutionPatturnId = evolutionPatturnId,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }
}
