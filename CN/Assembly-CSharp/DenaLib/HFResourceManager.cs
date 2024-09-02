// Decompiled with JetBrains decompiler
// Type: DenaLib.HFResourceManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class HFResourceManager
  {
    public static readonly int MaxPrefabCount = 9;
    private Dictionary<int, ResCache> m_ResObjList;
    private ResCacheGroup[] m_ResCacheGroup;
    private List<ResCache> m_ResCacheRecy;
    private bool m_Start;

    public HFResourceManager() => this.Init();

    public void Init()
    {
      this.m_ResObjList = new Dictionary<int, ResCache>();
      this.m_ResCacheGroup = new ResCacheGroup[6];
      for (int index = 0; index < 6; ++index)
        this.m_ResCacheGroup[index] = new ResCacheGroup();
      this.m_ResCacheRecy = new List<ResCache>();
      this.m_Start = true;
    }

    public void UnloadUnusedAssets()
    {
      for (int index1 = 0; index1 < 6; ++index1)
      {
        ResCacheGroup resCacheGroup = this.m_ResCacheGroup[index1];
        for (int index2 = resCacheGroup.ResCacheList.Count - 1; index2 >= 0; --index2)
        {
          ResCache resCache = resCacheGroup.ResCacheList[index2];
          int key = resCache.Key;
          if (resCache.Clear())
          {
            this.m_ResObjList.Remove(key);
            resCacheGroup.ResCacheList.RemoveAt(index2);
            this.m_ResCacheRecy.Add(resCache);
          }
        }
      }
      Resources.UnloadUnusedAssets();
      GC.Collect();
    }

    public void Update()
    {
      for (int index1 = 0; index1 < 6; ++index1)
      {
        ResCacheGroup resCacheGroup = this.m_ResCacheGroup[index1];
        for (int index2 = resCacheGroup.ResCacheList.Count - 1; index2 >= 0; --index2)
        {
          ResCache resCache = resCacheGroup.ResCacheList[index2];
          int key = resCache.Key;
          if (resCache.IsLoading)
          {
            if (resCache.AssetBundleLoad != null)
            {
              if (((AsyncOperation) resCache.AssetBundleLoad).isDone)
              {
                resCache.IsLoading = false;
                resCache.ResObj = resCache.AssetBundleLoad.asset;
                if (Object.op_Inequality((Object) resCache.AssetBundleCache, (Object) null))
                  resCache.AssetBundleCache.Unload(false);
              }
            }
            else if (resCache.ResourceLoad != null)
            {
              if (((AsyncOperation) resCache.ResourceLoad).isDone)
              {
                resCache.IsLoading = false;
                resCache.ResObj = resCache.ResourceLoad.asset;
              }
            }
            else
              resCache.IsLoading = false;
          }
          if (resCache.Process(Time.deltaTime))
          {
            this.m_ResObjList.Remove(key);
            resCacheGroup.ResCacheList.RemoveAt(index2);
            this.m_ResCacheRecy.Add(resCache);
          }
        }
      }
    }

    public EResLoadState Load(
      string resName,
      EResType resType,
      bool autoGC,
      out Object instance,
      OnLoadFinished loadFinishCb)
    {
      EResLoadState eresLoadState = EResLoadState.ELoadFail;
      Object @object = (Object) null;
      instance = (Object) null;
      ResCache resCache = (ResCache) null;
      int hashCode = resName.GetHashCode();
      if (!this.m_ResObjList.TryGetValue(hashCode, out resCache))
      {
        string path = string.Empty;
        if (PathManager.GetResourcePath(resName, out path) == EResLocation.EResLocal)
        {
          @object = Resources.Load(resName, this.ConvertResType(resType));
        }
        else
        {
          AssetBundle assetBundle = AssetBundle.LoadFromFile(path);
          if (Object.op_Inequality((Object) assetBundle, (Object) null))
          {
            @object = assetBundle.mainAsset;
            assetBundle.Unload(false);
          }
        }
        if (Object.op_Inequality(@object, (Object) null))
        {
          if (this.m_ResCacheRecy.Count > 0)
          {
            resCache = this.m_ResCacheRecy[this.m_ResCacheRecy.Count - 1];
            this.m_ResCacheRecy.RemoveAt(this.m_ResCacheRecy.Count - 1);
          }
          else
            resCache = new ResCache();
          resCache.Key = hashCode;
          resCache.ResObj = @object;
          resCache.ResType = resType;
          resCache.IsLoading = false;
          resCache.AutoGC = autoGC;
          resCache.LifeTime = ResCache.GCTime;
          this.AddResourceCache(resCache);
        }
        else
          eresLoadState = EResLoadState.ELoadFail;
      }
      if (resCache != null)
      {
        if (resCache.IsLoading)
        {
          if (loadFinishCb != null)
            resCache.DelayLoadQueue.Enqueue(loadFinishCb);
          eresLoadState = EResLoadState.ELoading;
        }
        else
        {
          instance = @object;
          eresLoadState = EResLoadState.ELoadSuccess;
        }
      }
      return eresLoadState;
    }

    public EResLoadState LoadAsync(
      string resName,
      EResType resType,
      bool autoGC,
      out Object instance,
      OnLoadFinished loadFinishCb)
    {
      EResLoadState eresLoadState = EResLoadState.ELoadFail;
      Object @object = (Object) null;
      instance = (Object) null;
      ResCache resCache1 = (ResCache) null;
      int hashCode = resName.GetHashCode();
      if (!this.m_ResObjList.TryGetValue(hashCode, out resCache1))
      {
        ResCache resCache2;
        if (this.m_ResCacheRecy.Count > 0)
        {
          resCache2 = this.m_ResCacheRecy[this.m_ResCacheRecy.Count - 1];
          this.m_ResCacheRecy.RemoveAt(this.m_ResCacheRecy.Count - 1);
        }
        else
          resCache2 = new ResCache();
        resCache2.Key = hashCode;
        resCache2.ResObj = (Object) null;
        resCache2.ResType = resType;
        resCache2.IsLoading = true;
        resCache2.AutoGC = autoGC;
        resCache2.LifeTime = ResCache.GCTime;
        this.AddResourceCache(resCache2);
        string path = string.Empty;
        if (PathManager.GetResourcePath(resName, out path) == EResLocation.EResLocal)
        {
          eresLoadState = EResLoadState.ELoading;
          resCache2.DelayLoadQueue.Enqueue(loadFinishCb);
          resCache2.ResourceLoad = Resources.LoadAsync(resName, this.ConvertResType(resType));
        }
        else
        {
          AssetBundle assetBundle = AssetBundle.LoadFromFile(path);
          if (Object.op_Inequality((Object) assetBundle, (Object) null))
          {
            eresLoadState = EResLoadState.ELoading;
            resCache2.DelayLoadQueue.Enqueue(loadFinishCb);
            resCache2.AssetBundleCache = assetBundle;
            resCache2.AssetBundleLoad = assetBundle.LoadAssetAsync(resName, this.ConvertResType(resType));
          }
        }
      }
      else if (resCache1.IsLoading)
      {
        if (loadFinishCb != null)
          resCache1.DelayLoadQueue.Enqueue(loadFinishCb);
        eresLoadState = EResLoadState.ELoading;
      }
      else
      {
        instance = @object;
        eresLoadState = EResLoadState.ELoadSuccess;
      }
      return eresLoadState;
    }

    public Object DoInstantiate(EResType kType, Object obj)
    {
      if (Object.op_Equality(obj, (Object) null))
        return (Object) null;
      return kType == EResType.EResAudio || kType == EResType.EResAtlas || kType == EResType.EResTexture ? obj : Object.Instantiate(obj);
    }

    private Type ConvertResType(EResType resType)
    {
      Type type = (Type) null;
      switch (resType)
      {
        case EResType.EResPrefab:
        case EResType.EResData:
        case EResType.EResAtlas:
          type = typeof (GameObject);
          break;
        case EResType.EResAudio:
          type = typeof (AudioClip);
          break;
        case EResType.EResText:
          type = typeof (TextAsset);
          break;
        case EResType.EResTexture:
          type = typeof (Texture);
          break;
      }
      return type;
    }

    private void AddResourceCache(ResCache resCache)
    {
      this.m_ResObjList.Add(resCache.Key, resCache);
      ResCacheGroup resCacheGroup = this.m_ResCacheGroup[(int) resCache.ResType];
      resCacheGroup.ResCacheList.Add(resCache);
      if (resCacheGroup.ResCacheList.Count <= ResCacheGroup.MaxCount)
        return;
      Debuger.LogWarning((object) string.Format("too many resource type:{0},count:{1}", (object) resCache.ResType, (object) resCacheGroup.ResCacheList.Count));
    }
  }
}
