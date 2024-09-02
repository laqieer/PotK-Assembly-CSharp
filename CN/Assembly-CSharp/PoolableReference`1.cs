// Decompiled with JetBrains decompiler
// Type: PoolableReference`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PoolableReference<T> where T : Component
{
  private PoolableObject _pooledObj;
  private int _initialUsageCount;
  private T _objComponent;

  public PoolableReference() => this.Reset();

  public PoolableReference(T componentOfPoolableObject)
  {
    this.Set(componentOfPoolableObject, false);
  }

  public PoolableReference(PoolableReference<T> poolableReference)
  {
    this._objComponent = poolableReference._objComponent;
    this._pooledObj = poolableReference._pooledObj;
    this._initialUsageCount = poolableReference._initialUsageCount;
  }

  public void Reset()
  {
    this._pooledObj = (PoolableObject) null;
    this._objComponent = (T) null;
    this._initialUsageCount = 0;
  }

  public T Get()
  {
    if (!Object.op_Implicit((Object) (object) this._objComponent))
      return (T) null;
    if (!Object.op_Implicit((Object) this._pooledObj) || this._pooledObj._usageCount == this._initialUsageCount && !this._pooledObj._isAvailableForPooling)
      return this._objComponent;
    this._objComponent = (T) null;
    this._pooledObj = (PoolableObject) null;
    return (T) null;
  }

  public void Set(T componentOfPoolableObject) => this.Set(componentOfPoolableObject, false);

  public void Set(T componentOfPoolableObject, bool allowNonePoolable)
  {
    if (!Object.op_Implicit((Object) (object) componentOfPoolableObject))
    {
      this.Reset();
    }
    else
    {
      this._objComponent = componentOfPoolableObject;
      this._pooledObj = this._objComponent.GetComponent<PoolableObject>();
      if (!Object.op_Implicit((Object) this._pooledObj))
      {
        if (allowNonePoolable)
          this._initialUsageCount = 0;
        else
          Debug.LogError((object) "Object for PoolableReference must be poolable");
      }
      else
        this._initialUsageCount = this._pooledObj._usageCount;
    }
  }
}
