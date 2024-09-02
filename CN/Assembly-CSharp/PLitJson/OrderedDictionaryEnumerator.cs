// Decompiled with JetBrains decompiler
// Type: PLitJson.OrderedDictionaryEnumerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
