// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.IntArrayEqualityComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace GameCore.Serialization
{
  internal class IntArrayEqualityComparer : IEqualityComparer<int[]>
  {
    bool IEqualityComparer<int[]>.System\u002ECollections\u002EGeneric\u002EIEqualityComparer\u003Cint\u005B\u005D\u003E\u002EEquals(
      int[] x,
      int[] y)
    {
      if (x == null && y == null)
        return true;
      return x != null && y != null && ((IEnumerable<int>) x).SequenceEqual<int>((IEnumerable<int>) y);
    }

    int IEqualityComparer<int[]>.System\u002ECollections\u002EGeneric\u002EIEqualityComparer\u003Cint\u005B\u005D\u003E\u002EGetHashCode(
      int[] x)
    {
      int a = x.Length;
      int num = Math.Min(x.Length, 10);
      for (int index = 0; index < num; ++index)
        a = a.Combine(x[index]);
      return a;
    }
  }
}
