// Decompiled with JetBrains decompiler
// Type: ResourceLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using UnityEngine;

internal class ResourceLoader : IResourceLoader
{
  private IEnumerator Load_(string path, Promise<UnityEngine.Object> promise)
  {
    promise.Result = Resources.Load(path);
    yield break;
  }

  public Future<UnityEngine.Object> Load(string path, ref ResourceInfo.Resource context) => new Future<UnityEngine.Object>((Func<Promise<UnityEngine.Object>, IEnumerator>) (promise => this.Load_(path, promise)));

  public Future<UnityEngine.Object> DownloadOrCache(
    string path,
    ref ResourceInfo.Resource context)
  {
    return new Future<UnityEngine.Object>((Func<Promise<UnityEngine.Object>, IEnumerator>) (promise => this.Load_(path, promise)));
  }

  public UnityEngine.Object LoadImmediatelyForSmallObject(
    string path,
    ref ResourceInfo.Resource context)
  {
    return Resources.Load(path);
  }
}
