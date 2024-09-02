// Decompiled with JetBrains decompiler
// Type: SingletonBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
