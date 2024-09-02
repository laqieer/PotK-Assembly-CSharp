// Decompiled with JetBrains decompiler
// Type: PLitJson.OrderedDictionaryEnumerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace PLitJson
{
  internal class OrderedDictionaryEnumerator : IEnumerator, IDictionaryEnumerator
  {
    private IEnumerator<KeyValuePair<string, JsonData>> list_enumerator;

    public OrderedDictionaryEnumerator(
      IEnumerator<KeyValuePair<string, JsonData>> enumerator)
    {
      this.list_enumerator = enumerator;
    }

    public object Current => (object) this.Entry;

    public DictionaryEntry Entry
    {
      get
      {
        KeyValuePair<string, JsonData> current = this.list_enumerator.Current;
        return new DictionaryEntry((object) current.Key, (object) current.Value);
      }
    }

    public object Key => (object) this.list_enumerator.Current.Key;

    public object Value => (object) this.list_enumerator.Current.Value;

    public bool MoveNext() => this.list_enumerator.MoveNext();

    public void Reset() => this.list_enumerator.Reset();
  }
}
