// Decompiled with JetBrains decompiler
// Type: ResourceLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new ResourceLoader.\u003CLoad_\u003Ec__IteratorAE8()
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
