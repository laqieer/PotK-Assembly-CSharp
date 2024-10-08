﻿// Decompiled with JetBrains decompiler
// Type: SpriteNumberSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SpriteNumberSelect : MonoBehaviour
{
  private GameObject[] numbers = new GameObject[10];

  private void Awake() => this.initialize();

  private void initialize()
  {
    if (!Object.op_Equality((Object) this.numbers[0], (Object) null))
      return;
    foreach (Transform transform in ((Component) this).transform)
    {
      for (int index = 0; index < this.numbers.Length; ++index)
      {
        if (((Object) transform).name.EndsWith(string.Format("{0}", (object) index)))
        {
          this.numbers[index] = ((Component) transform).gameObject;
          break;
        }
      }
    }
  }

  public void setNumber(int n)
  {
    this.initialize();
    for (int index = 0; index < this.numbers.Length; ++index)
    {
      if (Object.op_Inequality((Object) this.numbers[index], (Object) null))
        this.numbers[index].SetActive(n == index);
    }
  }
}
