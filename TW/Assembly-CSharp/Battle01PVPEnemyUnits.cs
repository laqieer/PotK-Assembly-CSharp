// Decompiled with JetBrains decompiler
// Type: Battle01PVPEnemyUnits
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PVPEnemyUnits : NGBattleMenuBase
{
  [SerializeField]
  private GameObject[] nodes;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Battle01PVPEnemyUnits.\u003CStart_Battle\u003Ec__Iterator94C battleCIterator94C = new Battle01PVPEnemyUnits.\u003CStart_Battle\u003Ec__Iterator94C();
    return (IEnumerator) battleCIterator94C;
  }

  [DebuggerHidden]
  public IEnumerator setupUnits(List<BL.Unit> units, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPEnemyUnits.\u003CsetupUnits\u003Ec__Iterator94D()
    {
      units = units,
      prefab = prefab,
      \u003C\u0024\u003Eunits = units,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator cloneUnitThum(BL.Unit unit, GameObject prefab, Transform parent)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPEnemyUnits.\u003CcloneUnitThum\u003Ec__Iterator94E()
    {
      prefab = prefab,
      parent = parent,
      unit = unit,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Eunit = unit
    };
  }
}
