// Decompiled with JetBrains decompiler
// Type: UniLinq.IOrderedEnumerable`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace UniLinq
{
  public interface IOrderedEnumerable<TElement> : IEnumerable, IEnumerable<TElement>
  {
    IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(
      Func<TElement, TKey> keySelector,
      IComparer<TKey> comparer,
      bool descending);
  }
}
