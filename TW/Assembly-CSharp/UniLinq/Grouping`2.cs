// Decompiled with JetBrains decompiler
// Type: UniLinq.Grouping`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace UniLinq
{
  internal class Grouping<K, T> : IEnumerable, IEnumerable<T>, IGrouping<K, T>
  {
    private K key;
    private IEnumerable<T> group;

    public Grouping(K key, IEnumerable<T> group)
    {
      this.group = group;
      this.key = key;
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.group.GetEnumerator();

    public K Key
    {
      get => this.key;
      set => this.key = value;
    }

    public IEnumerator<T> GetEnumerator() => this.group.GetEnumerator();
  }
}
