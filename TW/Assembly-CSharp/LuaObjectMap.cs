// Decompiled with JetBrains decompiler
// Type: LuaObjectMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class LuaObjectMap
{
  private List<object> list;
  private Queue<int> pool;

  public LuaObjectMap()
  {
    this.list = new List<object>(1024);
    this.pool = new Queue<int>(1024);
  }

  public object this[int i] => this.list[i];

  public int Add(object obj)
  {
    int index;
    if (this.pool.Count > 0)
    {
      index = this.pool.Dequeue();
      this.list[index] = obj;
    }
    else
    {
      this.list.Add(obj);
      index = this.list.Count - 1;
    }
    return index;
  }

  public bool TryGetValue(int index, out object obj)
  {
    if (index >= 0 && index < this.list.Count)
    {
      obj = this.list[index];
      return obj != null;
    }
    obj = (object) null;
    return false;
  }

  public object Remove(int index)
  {
    if (index < 0 || index >= this.list.Count)
      return (object) null;
    object obj = this.list[index];
    if (obj != null)
      this.pool.Enqueue(index);
    this.list[index] = (object) null;
    return obj;
  }
}
