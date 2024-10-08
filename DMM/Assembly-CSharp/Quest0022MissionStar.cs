﻿// Decompiled with JetBrains decompiler
// Type: Quest0022MissionStar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

public class Quest0022MissionStar : MonoBehaviour
{
  public GameObject[] notClearStar;
  public GameObject[] clearStar;

  public void initStar()
  {
    ((IEnumerable<GameObject>) this.notClearStar).ForEach<GameObject>((System.Action<GameObject>) (x => x.SetActive(true)));
    ((IEnumerable<GameObject>) this.clearStar).ForEach<GameObject>((System.Action<GameObject>) (x => x.SetActive(false)));
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
