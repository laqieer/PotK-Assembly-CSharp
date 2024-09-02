// Decompiled with JetBrains decompiler
// Type: ResourceObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
