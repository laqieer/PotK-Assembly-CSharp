// Decompiled with JetBrains decompiler
// Type: DirAddStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new DirAddStatus.\u003CInit\u003Ec__Iterator26C()
    {
      list = list,
      \u003C\u0024\u003Elist = list,
      \u003C\u003Ef__this = this
    };
  }
}
