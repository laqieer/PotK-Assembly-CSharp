﻿// Decompiled with JetBrains decompiler
// Type: Startup00010Score
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Startup00010Score : MonoBehaviour
{
  public List<GameObject> score_sprite_list;

  public void SetActive(int number)
  {
    this.score_sprite_list.ForEachIndex<GameObject>((Action<GameObject, int>) ((x, n) => x.SetActive(n == number)));
  }
}
