// Decompiled with JetBrains decompiler
// Type: DirAddStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DirAddStatus : MonoBehaviour
{
  [SerializeField]
  private GameObject[] AddStatus;

  [DebuggerHidden]
  public IEnumerator Init(List<IncrementalInfo> list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DirAddStatus.\u003CInit\u003Ec__Iterator313()
    {
      list = list,
      \u003C\u0024\u003Elist = list,
      \u003C\u003Ef__this = this
    };
  }
}
