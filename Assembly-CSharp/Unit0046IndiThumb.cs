﻿// Decompiled with JetBrains decompiler
// Type: Unit0046IndiThumb
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;
using UnityEngine;

public class Unit0046IndiThumb : MonoBehaviour
{
  public Transform parent;
  public GameObject prefab;

  public IEnumerator SetThumb(PlayerUnit pUnit)
  {
    this.parent.Clear();
    this.prefab.Clone(this.parent).GetComponent<UnitIconBottomBase>().Set(pUnit);
    yield break;
  }
}
