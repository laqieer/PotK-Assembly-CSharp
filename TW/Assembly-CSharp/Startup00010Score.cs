﻿// Decompiled with JetBrains decompiler
// Type: Startup00010Score
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
