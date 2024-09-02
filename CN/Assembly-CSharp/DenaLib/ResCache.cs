// Decompiled with JetBrains decompiler
// Type: DenaLib.ResCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class ResCache
  {
    public static readonly float GCTime = 10f;
    public int Key = -1;
    public Object ResObj;
    public EResType ResType;
    public bool IsLoading = true;
    public bool AutoGC;
    public float LifeTime = ResCache.GCTime;
    public Queue<OnLoadFinished> DelayLoadQueue = new Queue<OnLoadFinished>();
    public ResourceRequest ResourceLoad;
    public AssetBundleRequest AssetBundleLoad;
    public AssetBundle AssetBundleCache;

    public bool Clear()
    {
      if (this.IsLoading)
        return false;
      if (Object.op_Inequality(this.ResObj, (Object) null))
      {
        Object.Destroy(this.ResObj);
        this.ResObj = (Object) null;
      }
      this.ResourceLoad = (ResourceRequest) null;
      this.AssetBundleLoad = (AssetBundleRequest) null;
      this.Key = -1;
      this.ResType = EResType.EResPrefab;
      this.IsLoading = true;
      this.AutoGC = false;
      this.LifeTime = ResCache.GCTime;
      return true;
    }

    public bool Process(float time)
    {
      if (!this.IsLoading)
      {
        for (int index = 3; this.DelayLoadQueue.Count > 0 && index > 0; --index)
          this.DelayLoadQueue.Dequeue()(this.ResObj);
        if (this.DelayLoadQueue.Count == 0 && this.AutoGC)
        {
          this.LifeTime -= time;
          if ((double) this.LifeTime <= 0.0 && Object.op_Inequality(this.ResObj, (Object) null))
          {
            this.ResObj = (Object) null;
            this.Key = -1;
            return true;
          }
        }
      }
      return false;
    }
  }
}
