// Decompiled with JetBrains decompiler
// Type: UniLinq.ILookup`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace UniLinq
{
  public interface ILookup<TKey, TElement> : IEnumerable, IEnumerable<IGrouping<TKey, TElement>>
  {
    int Count { get; }

    IEnumerable<TElement> this[TKey key] { get; }

    bool Contains(TKey key);
  }
}
