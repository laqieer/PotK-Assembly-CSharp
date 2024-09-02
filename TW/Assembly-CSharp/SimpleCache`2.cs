// Decompiled with JetBrains decompiler
// Type: SimpleCache`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class SimpleCache<Key, Value> where Value : Object
{
  private Dictionary<Key, WeakReference> cacheDic = new Dictionary<Key, WeakReference>();
  private Func<Key, Promise<Value>, IEnumerator> loader;

  public SimpleCache(
    Func<Key, Promise<Value>, IEnumerator> loader,
    Func<Value, long> getSize,
    long maxSize,
    Action<Key, Value> unload = null)
  {
    this.loader = loader;
  }

  private Value GetTarget(Key key)
  {
    return !this.cacheDic.ContainsKey(key) ? (Value) null : this.cacheDic[key].Target as Value;
  }

  [DebuggerHidden]
  private IEnumerator Run(Key key, Promise<Value> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new SimpleCache<Key, Value>.\u003CRun\u003Ec__IteratorBDA()
    {
      key = key,
      promise = promise,
      \u003C\u0024\u003Ekey = key,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }

  public void SetValue(Key key, Value value)
  {
    if (!this.cacheDic.ContainsKey(key))
      this.cacheDic.Add(key, new WeakReference((object) value));
    else
      this.cacheDic[key].Target = (object) value;
  }

  public Value TryGet(Key key) => this.GetTarget(key);

  public Future<Value> Get(Key key)
  {
    Value target = this.GetTarget(key);
    return Object.op_Equality((Object) target, (Object) null) ? new Future<Value>((Func<Promise<Value>, IEnumerator>) (promise => this.Run(key, promise))) : Future.Single<Value>(target);
  }

  public void Clear()
  {
    HashSet<Key> source = new HashSet<Key>((IEnumerable<Key>) this.cacheDic.Keys);
    Dictionary<Key, WeakReference> dictionary = new Dictionary<Key, WeakReference>();
    foreach (KeyValuePair<Key, WeakReference> keyValuePair in this.cacheDic)
    {
      if (keyValuePair.Value.Target != null)
        dictionary.Add(keyValuePair.Key, keyValuePair.Value);
    }
    this.cacheDic = dictionary;
    source.ExceptWith((IEnumerable<Key>) this.cacheDic.Keys);
    if (source.Count == 0)
      return;
    Debug.Log((object) ("Removed keys are:\n" + source.Select<Key, string>((Func<Key, string>) (x => x.ToString())).Join("\n")));
  }

  private class Wrap
  {
    public Value value;

    public Wrap(Value value) => this.value = value;
  }
}
