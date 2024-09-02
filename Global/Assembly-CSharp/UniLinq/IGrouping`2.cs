// Decompiled with JetBrains decompiler
// Type: UniLinq.IGrouping`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace UniLinq
{
  public interface IGrouping<TKey, TElement> : IEnumerable, IEnumerable<TElement>
  {
    TKey Key { get; }
  }
}
