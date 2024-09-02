// Decompiled with JetBrains decompiler
// Type: UniLinq.SortContext`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
