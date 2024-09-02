// Decompiled with JetBrains decompiler
// Type: UniLinq.IGrouping`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
