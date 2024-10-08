﻿// Decompiled with JetBrains decompiler
// Type: GameCore.EnumerableWrapper`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace GameCore
{
  public class EnumerableWrapper<T> : IEnumerable<T>, IEnumerable
  {
    private IEnumerable<T> e;

    public EnumerableWrapper(IEnumerable<T> e) => this.e = e;

    public IEnumerator<T> GetEnumerator()
    {
      if (this.e is T[] array)
      {
        for (int i = 0; i < array.Length; ++i)
          yield return array[i];
      }
      else
      {
        foreach (T obj in this.e)
          yield return obj;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
  }
}
