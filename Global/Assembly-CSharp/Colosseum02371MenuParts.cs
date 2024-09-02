// Decompiled with JetBrains decompiler
// Type: Colosseum02371MenuParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Colosseum02371MenuParts : MonoBehaviour
{
  [SerializeField]
  protected GameObject[] DirObject;
  private int index;

  public GameObject GetTextDir() => this.DirObject[this.index];

  public void Init(RankingPlayer data)
  {
    if (data != null)
    {
      this.index = data.ranking - 1 >= 3 ? 3 : data.ranking - 1;
      ((IEnumerable<GameObject>) this.DirObject).ToggleOnce(this.index);
    }
    else
      ((IEnumerable<GameObject>) this.DirObject).ToggleOnce(4);
  }
}
