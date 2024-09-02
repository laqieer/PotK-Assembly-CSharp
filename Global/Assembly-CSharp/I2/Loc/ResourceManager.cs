// Decompiled with JetBrains decompiler
// Type: I2.Loc.ResourceManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace I2.Loc
{
  public class ResourceManager : MonoBehaviour
  {
    private static ResourceManager mInstance;
    public Object[] Assets;
    private Dictionary<string, Object> mResourcesCache = new Dictionary<string, Object>();
    private bool mCleaningScheduled;

    public static ResourceManager pInstance
    {
      get
      {
        bool flag = Object.op_Equality((Object) ResourceManager.mInstance, (Object) null);
        if (Object.op_Equality((Object) ResourceManager.mInstance, (Object) null))
          ResourceManager.mInstance = (ResourceManager) Object.FindObjectOfType(typeof (ResourceManager));
        if (Object.op_Equality((Object) ResourceManager.mInstance, (Object) null))
        {
          GameObject gameObject = new GameObject("I2ResourceManager", new Type[1]
          {
            typeof (ResourceManager)
          });
          ((Object) gameObject).hideFlags = (HideFlags) (((Object) gameObject).hideFlags | 61);
          ResourceManager.mInstance = gameObject.GetComponent<ResourceManager>();
        }
        if (flag && Application.isPlaying)
          Object.DontDestroyOnLoad((Object) ((Component) ResourceManager.mInstance).gameObject);
        return ResourceManager.mInstance;
      }
    }

    public void OnLevelWasLoaded() => LocalizationManager.UpdateSources();

    public T GetAsset<T>(string Name) where T : Object
    {
      T asset = this.FindAsset(Name) as T;
      return Object.op_Inequality((Object) asset, (Object) null) ? asset : this.LoadFromResources<T>(Name);
    }

    private Object FindAsset(string Name)
    {
      if (this.Assets != null)
      {
        int index = 0;
        for (int length = this.Assets.Length; index < length; ++index)
        {
          if (Object.op_Inequality(this.Assets[index], (Object) null) && this.Assets[index].name == Name)
            return this.Assets[index];
        }
      }
      return (Object) null;
    }

    public bool HasAsset(Object Obj)
    {
      return this.Assets != null && Array.IndexOf<Object>(this.Assets, Obj) >= 0;
    }

    public T LoadFromResources<T>(string Path) where T : Object
    {
      if (string.IsNullOrEmpty(Path))
        return (T) null;
      Object @object;
      if (this.mResourcesCache.TryGetValue(Path, out @object) && Object.op_Inequality(@object, (Object) null))
        return @object as T;
      T obj = (T) null;
      if (Path.EndsWith("]", StringComparison.OrdinalIgnoreCase))
      {
        int length1 = Path.LastIndexOf("[", StringComparison.OrdinalIgnoreCase);
        int length2 = Path.Length - length1 - 2;
        string str = Path.Substring(length1 + 1, length2);
        Path = Path.Substring(0, length1);
        T[] objArray = Resources.LoadAll<T>(Path);
        int index = 0;
        for (int length3 = objArray.Length; index < length3; ++index)
        {
          if (objArray[index].name.Equals(str))
          {
            obj = objArray[index];
            break;
          }
        }
      }
      else
        obj = Resources.Load<T>(Path);
      this.mResourcesCache[Path] = (Object) obj;
      if (!this.mCleaningScheduled)
      {
        this.Invoke("CleanResourceCache", 0.1f);
        this.mCleaningScheduled = true;
      }
      return obj;
    }

    public void CleanResourceCache()
    {
      this.mResourcesCache.Clear();
      Resources.UnloadUnusedAssets();
      this.CancelInvoke();
      this.mCleaningScheduled = false;
    }
  }
}
