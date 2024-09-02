// Decompiled with JetBrains decompiler
// Type: UniLinq.SortContext`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
