// Decompiled with JetBrains decompiler
// Type: Shop00720Prefabs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00720Prefabs
{
  private GameObject dirSlotReward;
  private GameObject dirSlotList;
  private GameObject dirSlotPattern;
  private GameObject dirList;

  public GameObject DirSlotReward => this.dirSlotReward;

  public GameObject DirSlotList => this.dirSlotList;

  public GameObject DirSlotPattern => this.dirSlotPattern;

  public GameObject DirList => this.dirList;

  [DebuggerHidden]
  public IEnumerator GetPrefabs()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Prefabs.\u003CGetPrefabs\u003Ec__Iterator3D2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
