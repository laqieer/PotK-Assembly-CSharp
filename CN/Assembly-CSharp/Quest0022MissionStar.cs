// Decompiled with JetBrains decompiler
// Type: Quest0022MissionStar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Quest0022MissionStar : MonoBehaviour
{
  public GameObject[] notClearStar;
  public GameObject[] clearStar;

  public void initStar()
  {
    ((IEnumerable<GameObject>) this.notClearStar).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(true)));
    ((IEnumerable<GameObject>) this.clearStar).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
  }

  public void setStar(List<bool> clearList)
  {
    this.initStar();
    for (int index = 0; index < this.clearStar.Length; ++index)
    {
      this.clearStar[index].SetActive(clearList[index]);
      this.notClearStar[index].SetActive(!clearList[index]);
    }
  }
}
