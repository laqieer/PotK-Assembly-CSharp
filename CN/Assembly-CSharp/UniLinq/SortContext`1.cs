// Decompiled with JetBrains decompiler
// Type: UniLinq.SortContext`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace UniLinq
{
  internal abstract class SortContext<TElement> : IComparer<int>
  {
    protected SortDirection direction;
    protected SortContext<TElement> child_context;

    protected SortContext(SortDirection direction, SortContext<TElement> child_context)
    {
      this.direction = direction;
      this.child_context = child_context;
    }

    public abstract void Initialize(TElement[] elements);

    public abstract int Compare(int first_index, int second_index);
  }
}
