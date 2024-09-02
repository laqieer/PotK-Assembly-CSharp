﻿// Decompiled with JetBrains decompiler
// Type: ResourceManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UniLinq;
using UnityEngine;

#nullable disable
public class ResourceManager : Singleton<ResourceManager>
{
  private Dictionary<string, IResourceLoader> loaderDic;
  private string resourceVersion;
  private ResourceInfo resourceInfo;
  private SimpleCache<string, Object> cache;
  private static Regex abUnit = new Regex("^Units/[0-9]+/.*$");
  private static Regex saUnit = new Regex("^AssetBundle/Resources/Units/[0-9]+/.*$");
  private static Regex saUnitExclude = new Regex("^AssetBundle/Resources/Units/[0-9]+/2D/c_thum$");
  private static Regex voice = new Regex("^(android|ios)/VO_[0-9]+_awb$");
  private static Regex voiceExclude = new Regex("^(android|ios)/VO_99[0-9][0-9]_awb$");
  private static Regex abBattleMap = new Regex("^BattleMaps/[0-9]+/.*$");
  private static Regex duelAnimators = new Regex("Animators/duel/.*$");
  private static Regex duelWinAnimators = new Regex("Animators/duel_win/.*$");
  private AssocList<int, string[]> unitToPaths;
  private AssocList<int, string[]> mapToPaths;

  protected override void Initialize()
  {
    this.loaderDic = new Dictionary<string, IResourceLoader>()
    {
      {
        "Resource",
        (IResourceLoader) new ResourceLoader()
      },
      {
        "StreamingAssets",
        (IResourceLoader) new StreamingAssetsLoader()
      },
      {
        "AssetBundle",
        (IResourceLoader) new AssetBundleLoader((MonoBehaviour) this)
      }
    };
  }

  [DebuggerHidden]
  public IEnumerator CleanupCache()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CCleanupCache\u003Ec__Iterator94B()
    {
      \u003C\u003Ef__this = this
    };
  }

  private string[] GetHashedFilenameListFromFileSystem(string path)
  {
    string[] files = Directory.GetFiles(path);
    for (int index = 0; index < files.Length; ++index)
      files[index] = Path.GetFileName(files[index]);
    return files;
  }

  private string[] GetHashedFilenameListFromDatabase()
  {
    List<string> stringList = new List<string>();
    foreach (ResourceInfo.Resource resource in this.resourceInfo)
    {
      switch (resource._value.path_type)
      {
        case ResourceInfo.INFO_PATH_TYPE.ASSET_BUNDLE:
          if (!string.IsNullOrEmpty(resource._value._asset_bundle))
          {
            stringList.Add(resource._value._asset_bundle);
            continue;
          }
          continue;
        case ResourceInfo.INFO_PATH_TYPE.STREAMING:
          if (!string.IsNullOrEmpty(resource._value._file_name))
          {
            stringList.Add(resource._value._file_name);
            continue;
          }
          continue;
        default:
          continue;
      }
    }
    return stringList.ToArray();
  }

  public string ResolveAssetPath(string hashedFilename)
  {
    foreach (ResourceInfo.Resource resource in this.resourceInfo)
    {
      if (!string.IsNullOrEmpty(resource._value._asset_bundle) && resource._value._asset_bundle.Equals(hashedFilename) || !string.IsNullOrEmpty(resource._value._file_name) && resource._value._file_name.Equals(hashedFilename))
        return resource._key;
    }
    return string.Empty;
  }

  public void InitResourceInfoSync()
  {
    string path1 = DLC.ResourceDirectory + "paths.json";
    string path2 = Application.persistentDataPath + "/dlcversion.dat";
    try
    {
      using (FileStream fileStream = File.OpenRead(path1))
        this.resourceInfo = ResourceInfo.Deserialize((Stream) fileStream);
      this.resourceVersion = File.ReadAllText(path2, Encoding.UTF8);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ex.ToString());
    }
  }

  private bool ContainsInAssetDatabase(string hashedFilename)
  {
    foreach (ResourceInfo.Resource resource in this.resourceInfo)
    {
      if (!string.IsNullOrEmpty(resource._value._asset_bundle) && resource._value._asset_bundle.Equals(hashedFilename) || !string.IsNullOrEmpty(resource._value._file_name) && resource._value._file_name.Equals(hashedFilename))
        return true;
    }
    return false;
  }

  [DebuggerHidden]
  public IEnumerator DownloadIfNotExists(string path)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CDownloadIfNotExists\u003Ec__Iterator94C()
    {
      path = path,
      \u003C\u0024\u003Epath = path,
      \u003C\u003Ef__this = this
    };
  }

  public bool Initialized => this.resourceInfo != null;

  [DebuggerHidden]
  public IEnumerator InitResourceInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CInitResourceInfo\u003Ec__Iterator94D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static string DLCVersion
  {
    get
    {
      ResourceManager instance = Singleton<ResourceManager>.GetInstance();
      return Object.op_Equality((Object) instance, (Object) null) ? string.Empty : instance.resourceVersion;
    }
  }

  [DebuggerHidden]
  public IEnumerator SaveResourceInfo(byte[] buf, string dlcVersion)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CSaveResourceInfo\u003Ec__Iterator94E()
    {
      buf = buf,
      dlcVersion = dlcVersion,
      \u003C\u0024\u003Ebuf = buf,
      \u003C\u0024\u003EdlcVersion = dlcVersion
    };
  }

  public ResourceInfo ResourceInfo => this.resourceInfo;

  private SimpleCache<string, Object> Cache
  {
    get
    {
      if (this.cache == null)
        this.cache = new SimpleCache<string, Object>((Func<string, Promise<Object>, IEnumerator>) ((key, promise) => this.InternalLoad(key, promise)), (Func<Object, long>) (_ => 1L), 10L);
      return this.cache;
    }
  }

  [DebuggerHidden]
  private IEnumerator SetStep(Object res, ResourceInfo.Step step)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CSetStep\u003Ec__Iterator94F()
    {
      res = res,
      step = step,
      \u003C\u0024\u003Eres = res,
      \u003C\u0024\u003Estep = step,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetSteps(string path, Object obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CSetSteps\u003Ec__Iterator950()
    {
      path = path,
      obj = obj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Eobj = obj,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InternalLoad(string path, Promise<Object> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CInternalLoad\u003Ec__Iterator951()
    {
      path = path,
      promise = promise,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }

  public bool Contains(string path) => this.resourceInfo.SearchResourceInfo(path) >= 0;

  public static Future<T> LoadOrNull<T>(string path) where T : Object
  {
    return !Singleton<ResourceManager>.GetInstance().Contains(path) ? Future.Single<T>((T) null) : ResourceManager.Load<T>(path);
  }

  public static Future<T> Load<T>(string path) where T : Object
  {
    return (object) typeof (T) != (object) typeof (Sprite) ? Singleton<ResourceManager>.GetInstance().Cache.Get(path).Then<T>((Func<Object, T>) (obj => (T) obj)) : Singleton<ResourceManager>.GetInstance().Cache.Get(path).Then<T>((Func<Object, T>) (obj =>
    {
      SpriteMeshType spriteMeshType = !path.EndsWith("/unit_large") && !path.EndsWith("/unit_full") && !path.EndsWith("/unit_pickup") && !path.EndsWith("/c_thum") && !path.EndsWith("/c_400x400") && !path.EndsWith("/battle_cutin") && !path.EndsWith("/item_basic") && !path.EndsWith("/item_thum") && !path.EndsWith("/key_basic") && !path.EndsWith("/key_thum") && !path.EndsWith("/weapon_basic") && !path.EndsWith("/weapon_thum") ? (SpriteMeshType) 1 : (SpriteMeshType) 0;
      uint num1 = 1;
      uint num2 = 100;
      if (Object.op_Equality(obj, (Object) null))
        obj = (Object) Resources.Load<Texture2D>("Sprites/1x1_alpha0");
      Texture2D texture2D = (Texture2D) obj;
      Sprite sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, (float) ((Texture) texture2D).width, (float) ((Texture) texture2D).height), new Vector2(0.5f, 0.5f), (float) num1, num2, spriteMeshType);
      ((Object) sprite).name = ((Object) texture2D).name;
      return (object) sprite as T;
    }));
  }

  public static Future<T> Load<T>(string path, Action<T> callback) where T : Object
  {
    Future<T> future = ResourceManager.Load<T>(path);
    future.RunOn<T>((MonoBehaviour) Singleton<ResourceManager>.GetInstance(), callback);
    return future;
  }

  public void ClearCache() => this.Cache.Clear();

  public void ClearPathCache()
  {
    this.unitToPaths = (AssocList<int, string[]>) null;
    this.mapToPaths = (AssocList<int, string[]>) null;
  }

  public T LoadImmediatelyForSmallObject<T>(string path) where T : Object
  {
    if (this.resourceInfo == null)
      return (T) null;
    Object @object = this.Cache.TryGet(path);
    if (Object.op_Inequality(@object, (Object) null))
      return (T) @object;
    int n = this.resourceInfo.SearchResourceInfo(path);
    if (n < 0)
    {
      Debug.LogError((object) "File not found: {0}".F((object) path));
      return (T) null;
    }
    ResourceInfo.Resource context = this.resourceInfo[n];
    return (T) this.loaderDic[this.resourceInfo[n]._value.GetPathTypeName()].LoadImmediatelyForSmallObject(path, ref context);
  }

  [DebuggerHidden]
  public IEnumerator LoadResource(GameObject gameObject)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CLoadResource\u003Ec__Iterator952()
    {
      gameObject = gameObject,
      \u003C\u0024\u003EgameObject = gameObject
    };
  }

  public string ResolveStreamingAssetsPath(string path)
  {
    int n = this.resourceInfo != null ? this.resourceInfo.SearchResourceInfo(path) : throw new InvalidOperationException("resourceInfo is null");
    if (n < 0)
      throw new ArgumentException(string.Format("resourceInfo.ContainsKey({0}) is false", (object) path));
    return DLC.ResourceDirectory + this.resourceInfo[n]._value._file_name;
  }

  public string ResolveStreamingAssetsPathForMovie(string path)
  {
    string sourceFileName = this.ResolveStreamingAssetsPath(path);
    int n = this.resourceInfo.SearchResourceInfo(path);
    if (n < 0)
    {
      Debug.LogError((object) string.Format("resourceInfo.ContainsKey({0}) is false", (object) path));
      return string.Empty;
    }
    ResourceInfo.Resource resource = this.resourceInfo[n];
    string str = sourceFileName + resource._value._ext;
    if (File.Exists(str))
      return str;
    try
    {
      File.Copy(sourceFileName, str);
    }
    catch (Exception ex)
    {
      return sourceFileName;
    }
    return str;
  }

  public static bool IsInitialDLCTarget(string path)
  {
    return !ResourceManager.abUnit.IsMatch(path) && (!ResourceManager.saUnit.IsMatch(path) || ResourceManager.saUnitExclude.IsMatch(path)) && (!ResourceManager.voice.IsMatch(path) || ResourceManager.voiceExclude.IsMatch(path)) && !ResourceManager.duelAnimators.IsMatch(path) && !ResourceManager.duelWinAnimators.IsMatch(path) && !ResourceManager.abBattleMap.IsMatch(path);
  }

  private void InitPaths()
  {
    using (new ScopeTimer("ResourceManager.InitPaths"))
    {
      Regex regex1 = new Regex("^Units/(?<id>[0-9]+)/.*$");
      Regex regex2 = new Regex("^AssetBundle/Resources/Units/(?<id>[0-9]+)/.*$");
      Regex regex3 = new Regex("^(android|ios)/VO_(?<id>[0-9]+)_awb$");
      AssocList<int, List<string>> assocList1 = new AssocList<int, List<string>>();
      AssocList<int, List<string>> assocList2 = new AssocList<int, List<string>>();
      Action<AssocList<int, List<string>>, int, string> action = (Action<AssocList<int, List<string>>, int, string>) ((dic, n, str) =>
      {
        if (!dic.ContainsKey(n))
          dic.Add(n, new List<string>());
        dic[n].Add(string.Intern(str));
      });
      foreach (ResourceInfo.Resource resource in this.resourceInfo)
      {
        Match match1 = regex1.Match(resource._key);
        if (match1.Success)
        {
          int num = int.Parse(match1.Groups["id"].Value);
          action(assocList1, num, resource._key);
        }
        else
        {
          Match match2 = regex2.Match(resource._key);
          if (match2.Success)
          {
            int num = int.Parse(match2.Groups["id"].Value);
            action(assocList1, num, resource._key);
          }
          else
          {
            Match match3 = regex3.Match(resource._key);
            if (match3.Success)
            {
              int num = int.Parse(match3.Groups["id"].Value);
              action(assocList2, num, resource._key);
            }
          }
        }
      }
      this.unitToPaths = new AssocList<int, string[]>();
      foreach (UnitUnit unitUnit in MasterData.UnitUnitList)
      {
        List<string> list = (!assocList1.ContainsKey(unitUnit.resource_reference_unit_id.ID) ? (IEnumerable<string>) new List<string>() : (IEnumerable<string>) assocList1[unitUnit.resource_reference_unit_id.ID]).Concat<string>(!assocList2.ContainsKey(unitUnit.character.ID) ? (IEnumerable<string>) new List<string>() : (IEnumerable<string>) assocList2[unitUnit.character.ID]).Concat<string>(!assocList2.ContainsKey(unitUnit.same_character_id) ? (IEnumerable<string>) new List<string>() : (IEnumerable<string>) assocList2[unitUnit.same_character_id]).ToList<string>();
        if (!string.IsNullOrEmpty(unitUnit.DuelAnimatorPath))
          list.Add(unitUnit.DuelAnimatorPath);
        if (!string.IsNullOrEmpty(unitUnit.WinAnimatorPath))
          list.Add(unitUnit.WinAnimatorPath);
        this.unitToPaths[unitUnit.ID] = list.ToArray();
      }
      Regex regex4 = new Regex("^BattleMaps/(?<id>[0-9]+)/.*$");
      AssocList<int, List<string>> assocList3 = new AssocList<int, List<string>>();
      foreach (ResourceInfo.Resource resource in this.resourceInfo)
      {
        Match match = regex4.Match(resource._key);
        if (match.Success)
        {
          int num = int.Parse(match.Groups["id"].Value);
          action(assocList3, num, resource._key);
        }
      }
      this.mapToPaths = new AssocList<int, string[]>();
      foreach (KeyValuePair<int, List<string>> keyValuePair in assocList3)
        this.mapToPaths[keyValuePair.Key] = keyValuePair.Value.ToArray();
    }
  }

  public string[] PathsFromUnit(UnitUnit unit)
  {
    if (this.unitToPaths != null && this.unitToPaths.ContainsKey(unit.ID))
      return this.unitToPaths[unit.ID];
    this.InitPaths();
    return this.unitToPaths.ContainsKey(unit.ID) ? this.unitToPaths[unit.ID] : new string[0];
  }

  public string[] PathsFromBattleMap(BattleMap map)
  {
    if (this.mapToPaths != null && this.mapToPaths.ContainsKey(map.ID))
      return this.mapToPaths[map.ID];
    this.InitPaths();
    return this.mapToPaths.ContainsKey(map.ID) ? this.mapToPaths[map.ID] : new string[0];
  }

  public DLC CreateDLC(string[] paths) => new DLC(this.resourceInfo, paths);
}
