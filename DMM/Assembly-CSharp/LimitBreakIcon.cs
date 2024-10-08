﻿// Decompiled with JetBrains decompiler
// Type: LimitBreakIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

public class LimitBreakIcon : MonoBehaviour
{
  public List<GameObject> on_list_;

  public void Init(int breakthrough_count, int breakmax_count) => this.on_list_.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((x, n) =>
  {
    if (n >= breakmax_count)
      x.transform.parent.gameObject.SetActive(false);
    x.SetActive(breakthrough_count > n);
  }));
}
