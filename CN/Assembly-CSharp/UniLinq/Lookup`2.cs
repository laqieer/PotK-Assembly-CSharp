// Decompiled with JetBrains decompiler
// Type: UniLinq.Lookup`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace UniLinq
{
  public class Lookup<TKey, TElement> : 
    IEnumerable,
    IEnumerable<IGrouping<TKey, TElement>>,
    ILookup<TKey, TElement>
  {
    private IGrouping<TKey, TElement> nullGrouping;
    private Dictionary<TKey, IGrouping<TKey, TElement>> groups;

    internal Lookup(Dictionary<TKey, List<TElement>> lookup, IEnumerable<TElement> nullKeyElements)
    {
      this.groups = new Dictionary<TKey, IGrouping<TKey, TElement>>(lookup.Comparer);
      foreach (KeyValuePair<TKey, List<TElement>> keyValuePair in lookup)
        this.groups.Add(keyValuePair.Key, (IGrouping<TKey, TElement>) new Grouping<TKey, TElement>(keyValuePair.Key, (IEnumerable<TElement>) keyValuePair.Value));
      if (nullKeyElements == null)
        return;
      this.nullGrouping = (IGrouping<TKey, TElement>) new Grouping<TKey, TElement>(default (TKey), nullKeyElements);
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public int Count => this.nullGrouping == null ? this.groups.Count : this.groups.Count + 1;

    public IEnumerable<TElement> this[TKey key]
    {
      get
      {
        if ((object) key == null && this.nullGrouping != null)
          return (IEnumerable<TElement>) this.nullGrouping;
        IGrouping<TKey, TElement> grouping;
        return (object) key != null && this.groups.TryGetValue(key, out grouping) ? (IEnumerable<TElement>) grouping : (IEnumerable<TElement>) new TElement[0];
      }
    }

    [DebuggerHidden]
    public IEnumerable<TResult> ApplyResultSelector<TResult>(
      Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Lookup<TKey, TElement>.\u003CApplyResultSelector\u003Ec__Iterator14E<TResult> selectorCIterator14E = new Lookup<TKey, TElement>.\u003CApplyResultSelector\u003Ec__Iterator14E<TResult>()
      {
        resultSelector = resultSelector,
        \u003C\u0024\u003EresultSelector = resultSelector,
        \u003C\u003Ef__this = this
      };
      // ISSUE: reference to a compiler-generated field
      selectorCIterator14E.\u0024PC = -2;
      return (IEnumerable<TResult>) selectorCIterator14E;
    }

    public bool Contains(TKey key)
    {
      return (object) key != null ? this.groups.ContainsKey(key) : this.nullGrouping != null;
    }

    [DebuggerHidden]
    public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator<IGrouping<TKey, TElement>>) new Lookup<TKey, TElement>.\u003CGetEnumerator\u003Ec__Iterator14F()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
