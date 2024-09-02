// Decompiled with JetBrains decompiler
// Type: AlgorithmUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public static class AlgorithmUtil
{
  public static int GetLevenShteinDistance(string a, string b)
  {
    int[,] numArray = new int[a.Length + 1, b.Length + 1];
    for (int index = 0; index < a.Length + 1; ++index)
      numArray[index, 0] = index;
    for (int index = 0; index < b.Length + 1; ++index)
      numArray[0, index] = index;
    for (int index1 = 1; index1 < a.Length + 1; ++index1)
    {
      for (int index2 = 1; index2 < b.Length + 1; ++index2)
      {
        int num = (int) a[index1 - 1] != (int) b[index2 - 1] ? 1 : 0;
        numArray[index1, index2] = Mathf.Min(new int[3]
        {
          numArray[index1 - 1, index2] + index1,
          numArray[index1, index2 - 1] + 1,
          numArray[index1 - 1, index2 - 1] + num
        });
      }
    }
    return numArray[a.Length, b.Length];
  }

  public static void diffList<T>(List<T> l1, List<T> l2, List<T> diff)
  {
    List<T> objList1;
    List<T> objList2;
    if (l1.Count < l2.Count)
    {
      objList1 = l2;
      objList2 = l1;
    }
    else
    {
      objList1 = l1;
      objList2 = l2;
    }
    foreach (T obj in objList1)
    {
      if (!objList2.Contains(obj))
        diff.Add(obj);
    }
  }

  public static IEnumerable<IEnumerable<T>> Permutation<T>(IEnumerable<T> xs) where T : IComparable
  {
    return AlgorithmUtil._permutation<T>((IEnumerable<T>) new List<T>(), xs);
  }

  [DebuggerHidden]
  private static IEnumerable<IEnumerable<T>> _permutation<T>(IEnumerable<T> xs, IEnumerable<T> ys) where T : IComparable
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AlgorithmUtil.\u003C_permutation\u003Ec__IteratorBEE<T> permutationCIteratorBee = new AlgorithmUtil.\u003C_permutation\u003Ec__IteratorBEE<T>()
    {
      ys = ys,
      xs = xs,
      \u003C\u0024\u003Eys = ys,
      \u003C\u0024\u003Exs = xs
    };
    // ISSUE: reference to a compiler-generated field
    permutationCIteratorBee.\u0024PC = -2;
    return (IEnumerable<IEnumerable<T>>) permutationCIteratorBee;
  }
}
