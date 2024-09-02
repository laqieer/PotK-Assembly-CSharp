// Decompiled with JetBrains decompiler
// Type: UniLinq.ILookup`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

namespace UniLinq
{
  public interface ILookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>, IEnumerable
  {
    int Count { get; }

    IEnumerable<TElement> this[TKey key] { get; }

    bool Contains(TKey key);
  }
}
