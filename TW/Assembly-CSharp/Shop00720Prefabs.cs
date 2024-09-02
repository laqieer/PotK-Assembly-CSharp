// Decompiled with JetBrains decompiler
// Type: Shop00720Prefabs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Shop00720Prefabs.\u003CGetPrefabs\u003Ec__Iterator49E()
    {
      \u003C\u003Ef__this = this
    };
  }
}
