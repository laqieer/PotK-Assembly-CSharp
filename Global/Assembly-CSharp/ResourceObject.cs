// Decompiled with JetBrains decompiler
// Type: ResourceObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
public class ResourceObject
{
  private string path;

  public ResourceObject(string path) => this.path = path;

  public Future<T> Load<T>() where T : Object => ResourceManager.Load<T>(this.path);

  public Future<T> Load<T>(Action<T> callback) where T : Object
  {
    return ResourceManager.Load<T>(this.path, callback);
  }
}
