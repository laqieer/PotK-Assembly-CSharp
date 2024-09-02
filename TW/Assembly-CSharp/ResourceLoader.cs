// Decompiled with JetBrains decompiler
// Type: ResourceLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
internal class ResourceLoader : IResourceLoader
{
  [DebuggerHidden]
  private IEnumerator Load_(string path, Promise<Object> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceLoader.\u003CLoad_\u003Ec__IteratorBCF()
    {
      path = path,
      promise = promise,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Epromise = promise
    };
  }

  public Future<Object> Load(string path, ref ResourceInfo.Resource context)
  {
    return new Future<Object>((Func<Promise<Object>, IEnumerator>) (promise => this.Load_(path, promise)));
  }

  public Object LoadImmediatelyForSmallObject(string path, ref ResourceInfo.Resource context)
  {
    return Resources.Load(path);
  }
}
