// Decompiled with JetBrains decompiler
// Type: LRUList`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class LRUList<TKey, TValue>
{
  private const int DEFAULT_CAPACITY = 255;
  private int _capacity;
  private IDictionary<TKey, TValue> _dictionary;
  private LinkedList<TKey> _linkedList;

  public LRUList()
    : this((int) byte.MaxValue)
  {
  }

  public LRUList(int capacity)
  {
    this._capacity = capacity <= 0 ? (int) byte.MaxValue : capacity;
    this._dictionary = (IDictionary<TKey, TValue>) new Dictionary<TKey, TValue>();
    this._linkedList = new LinkedList<TKey>();
  }

  public void Set(TKey key, TValue value)
  {
    this._dictionary[key] = value;
    this._linkedList.Remove(key);
    this._linkedList.AddFirst(key);
    if (this._linkedList.Count <= this._capacity)
      return;
    this._dictionary.Remove(this._linkedList.Last.Value);
    this._linkedList.RemoveLast();
  }

  public bool TryGet(TKey key, out TValue value)
  {
    try
    {
      bool flag = this._dictionary.TryGetValue(key, out value);
      if (flag)
      {
        this._linkedList.Remove(key);
        this._linkedList.AddFirst(key);
      }
      return flag;
    }
    catch
    {
      throw;
    }
    finally
    {
    }
  }

  public bool ContainsKey(TKey key)
  {
    try
    {
      return this._dictionary.ContainsKey(key);
    }
    finally
    {
    }
  }

  public int Count => this._dictionary.Count;

  public int Capacity
  {
    get => this._capacity;
    set
    {
      if (value <= 0)
        return;
      if (this._capacity == value)
        return;
      try
      {
        this._capacity = value;
        while (this._linkedList.Count > this._capacity)
          this._linkedList.RemoveLast();
      }
      finally
      {
      }
    }
  }

  public ICollection<TKey> Keys => this._dictionary.Keys;

  public ICollection<TValue> Values => this._dictionary.Values;
}
