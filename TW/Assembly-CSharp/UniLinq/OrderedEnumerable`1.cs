﻿// Decompiled with JetBrains decompiler
// Type: UniLinq.OrderedEnumerable`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace UniLinq
{
  internal abstract class OrderedEnumerable<TElement> : 
    IEnumerable,
    IEnumerable<TElement>,
    IOrderedEnumerable<TElement>
  {
    private IEnumerable<TElement> source;

    protected OrderedEnumerable(IEnumerable<TElement> source) => this.source = source;

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public virtual IEnumerator<TElement> GetEnumerator() => this.Sort(this.source).GetEnumerator();

    public abstract SortContext<TElement> CreateContext(SortContext<TElement> current);

    protected abstract IEnumerable<TElement> Sort(IEnumerable<TElement> source);

    public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(
      Func<TElement, TKey> selector,
      IComparer<TKey> comparer,
      bool descending)
    {
      return (IOrderedEnumerable<TElement>) new OrderedSequence<TElement, TKey>(this, this.source, selector, comparer, !descending ? SortDirection.Ascending : SortDirection.Descending);
    }
  }
}
