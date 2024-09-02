// Decompiled with JetBrains decompiler
// Type: Unit0046IndiThumb
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0046IndiThumb : MonoBehaviour
{
  public Transform parent;
  public GameObject prefab;

  [DebuggerHidden]
  public IEnumerator SetThumb(PlayerUnit pUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046IndiThumb.\u003CSetThumb\u003Ec__Iterator31F()
    {
      pUnit = pUnit,
      \u003C\u0024\u003EpUnit = pUnit,
      \u003C\u003Ef__this = this
    };
  }
}
