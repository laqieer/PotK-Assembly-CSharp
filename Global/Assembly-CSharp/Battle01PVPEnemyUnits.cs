// Decompiled with JetBrains decompiler
// Type: Battle01PVPEnemyUnits
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    Battle01PVPEnemyUnits.\u003CStart_Battle\u003Ec__Iterator735 battleCIterator735 = new Battle01PVPEnemyUnits.\u003CStart_Battle\u003Ec__Iterator735();
    return (IEnumerator) battleCIterator735;
  }

  [DebuggerHidden]
  public IEnumerator setupUnits(List<BL.Unit> units, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPEnemyUnits.\u003CsetupUnits\u003Ec__Iterator736()
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
    return (IEnumerator) new Battle01PVPEnemyUnits.\u003CcloneUnitThum\u003Ec__Iterator737()
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
