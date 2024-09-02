// Decompiled with JetBrains decompiler
// Type: AssetBundleLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

#nullable disable
internal class AssetBundleLoader : IResourceLoader
{
  private static HashSet<string> loading = new HashSet<string>();
  private MonoBehaviour mono;

  public AssetBundleLoader(MonoBehaviour mono) => this.mono = mono;

  [DebuggerHidden]
  private IEnumerator InternalLoad(string path, string assetBundleName, Promise<Object> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new AssetBundleLoader.\u003CInternalLoad\u003Ec__Iterator949()
    {
      assetBundleName = assetBundleName,
      path = path,
      promise = promise,
      \u003C\u0024\u003EassetBundleName = assetBundleName,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Epromise = promise
    };
  }

  [DebuggerHidden]
  private IEnumerator Load_(string path, string assetBundleName, Promise<Object> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new AssetBundleLoader.\u003CLoad_\u003Ec__Iterator94A()
    {
      path = path,
      assetBundleName = assetBundleName,
      promise = promise,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003EassetBundleName = assetBundleName,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }

  public Future<Object> Load(string path, ref ResourceInfo.Resource context)
  {
    string assetBundleName = context._value._asset_bundle;
    return new Future<Object>((Func<Promise<Object>, IEnumerator>) (promise => this.Load_(path, assetBundleName, promise)));
  }

  public Object LoadImmediatelyForSmallObject(string path, ref ResourceInfo.Resource context)
  {
    string assetBundle1 = context._value._asset_bundle;
    string path1 = DLC.ResourceDirectory + assetBundle1;
    if (!CachedFile.Exists(path1))
      return (Object) null;
    AssetBundle assetBundle2 = AssetBundle.LoadFromMemory(File.ReadAllBytes(path1));
    if (Object.op_Equality((Object) assetBundle2, (Object) null))
      return (Object) null;
    Object @object = assetBundle2.LoadAsset(path);
    if (Object.op_Equality(@object, (Object) null))
      Debug.LogError((object) string.Format("File not found: {0} in {1}", (object) path, (object) assetBundle1));
    assetBundle2.Unload(false);
    return @object;
  }

  private class LoadingLock : IDisposable
  {
    private HashSet<string> loading;
    private string path;

    public LoadingLock(HashSet<string> loading, string path)
    {
      loading.Add(path);
      this.loading = loading;
      this.path = path;
    }

    public void Dispose() => this.loading.Remove(this.path);
  }
}
