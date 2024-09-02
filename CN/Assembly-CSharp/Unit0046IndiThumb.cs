// Decompiled with JetBrains decompiler
// Type: Unit0046IndiThumb
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Unit0046IndiThumb.\u003CSetThumb\u003Ec__Iterator2E1()
    {
      pUnit = pUnit,
      \u003C\u0024\u003EpUnit = pUnit,
      \u003C\u003Ef__this = this
    };
  }
}
