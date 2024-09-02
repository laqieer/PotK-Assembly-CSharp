// Decompiled with JetBrains decompiler
// Type: SingletonBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class SingletonBase : MonoBehaviour
{
  protected abstract void Initialize();

  protected virtual void Finlaize()
  {
  }

  protected abstract void clearInstance();

  public void forceDestroy()
  {
    this.clearInstance();
    this.Finlaize();
  }
}
