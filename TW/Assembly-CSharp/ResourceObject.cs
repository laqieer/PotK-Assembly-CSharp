// Decompiled with JetBrains decompiler
// Type: ResourceObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
public class ResourceObject
{
  private string path;

  public ResourceObject(string path) => this.path = path;

  public Future<T> Load<T>() where T : Object
  {
    return Singleton<ResourceManager>.GetInstance().Load<T>(this.path);
  }

  public Future<T> Load<T>(Action<T> callback) where T : Object
  {
    return Singleton<ResourceManager>.GetInstance().Load<T>(this.path, callback);
  }
}
