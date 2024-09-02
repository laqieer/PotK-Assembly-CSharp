// Decompiled with JetBrains decompiler
// Type: LimitBreakIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LimitBreakIcon : MonoBehaviour
{
  public List<GameObject> on_list_;

  public void Init(int breakthrough_count, int breakmax_count)
  {
    this.on_list_.ForEachIndex<GameObject>((Action<GameObject, int>) ((x, n) =>
    {
      if (n >= breakmax_count)
        ((Component) x.transform.parent).gameObject.SetActive(false);
      x.SetActive(breakthrough_count > n);
    }));
  }
}
