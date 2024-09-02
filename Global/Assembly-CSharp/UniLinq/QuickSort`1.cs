// Decompiled with JetBrains decompiler
// Type: UniLinq.QuickSort`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace UniLinq
{
  internal class QuickSort<TElement>
  {
    private TElement[] elements;
    private int[] indexes;
    private SortContext<TElement> context;

    private QuickSort(IEnumerable<TElement> source, SortContext<TElement> context)
    {
      List<TElement> elementList = new List<TElement>();
      foreach (TElement element in source)
        elementList.Add(element);
      this.elements = elementList.ToArray();
      this.indexes = QuickSort<TElement>.CreateIndexes(this.elements.Length);
      this.context = context;
    }

    private static int[] CreateIndexes(int length)
    {
      int[] indexes = new int[length];
      for (int index = 0; index < length; ++index)
        indexes[index] = index;
      return indexes;
    }

    private void PerformSort()
    {
      if (this.elements.Length <= 1)
        return;
      this.context.Initialize(this.elements);
      Array.Sort<int>(this.indexes, (IComparer<int>) this.context);
    }

    [DebuggerHidden]
    public static IEnumerable<TElement> Sort(
      IEnumerable<TElement> source,
      SortContext<TElement> context)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      QuickSort<TElement>.\u003CSort\u003Ec__Iterator10C sortCIterator10C = new QuickSort<TElement>.\u003CSort\u003Ec__Iterator10C()
      {
        source = source,
        context = context,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Econtext = context
      };
      // ISSUE: reference to a compiler-generated field
      sortCIterator10C.\u0024PC = -2;
      return (IEnumerable<TElement>) sortCIterator10C;
    }
  }
}
