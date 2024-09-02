// Decompiled with JetBrains decompiler
// Type: ResourceManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using MiniJSON;
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
  public static bool IsInited = false;
  private Dictionary<ResourceInfo.INFO_PATH_TYPE, IResourceLoader> loaderDic;
  public string resourceVersion;
  private ResourceInfo resourceInfo;
  private Dictionary<string, object> pathsExpand = new Dictionary<string, object>();
  private static string pathsExpandIdentifier = "crc";
  private bool resCompleted;
  private static ResourceManager.FILE_IS_EXISTS resDownlLocal = ResourceManager.FILE_IS_EXISTS.FILE_NO;
  private Dictionary<string, object> mFirstDownInfo;
  private SimpleCache<string, Object> cache;
  private static Regex abUnit = new Regex("^Units/[0-9]+/.*$");
  private static Regex saUnit = new Regex("^AssetBundle/Resources/Units/[0-9]+/.*$");
  private static Regex saUnitExclude = new Regex("^AssetBundle/Resources/Units/[0-9]+/2D/c_thum$");
  private static Regex voice = new Regex("^(android|ios)/VO_[0-9]+_awb$");
  private static Regex voiceExclude = new Regex("^(android|ios)/VO_99[0-9][0-9]_awb$");
  private static Regex abBattleMap = new Regex("^BattleMaps/[0-9]+/.*$");
  private static Regex gears = new Regex("Gears/[0-9]*/3D/prefab$");
  private static Regex eventImages = new Regex("^AssetBundle/Resources/EventImages/.*$");
  private static Regex duelAnimators = new Regex("Animators/duel/.*$");
  private static Regex duelWinAnimators = new Regex("Animators/duel_win/.*$");
  private static Regex animations = new Regex("Animations/.*/.*$");
  private AssocList<int, string[]> unitToPaths;
  private AssocList<int, string[]> mapToPaths;
  private string[] baseUnits = new string[20]
  {
    "/100111/",
    "/100221/",
    "/200411/",
    "/300111/",
    "/400131/",
    "/500211/",
    "/400511/",
    "/500511/",
    "/600211/",
    "/10001/",
    "/20001/",
    "/30001/",
    "/40001/",
    "/50001/",
    "/60001/",
    "VO_5005_awb",
    "VO_6002_awb",
    "VO_4005_awb",
    "VO_1014_awb",
    "VO_3001_awb"
  };
  private string[] baseUnitAnim = new string[8]
  {
    "Animators/duel/Anim_unit_01_senpei_sword",
    "Animators/duel/Anim_unit_01_senpei_ax",
    "Animators/duel/Anim_unit_01_senpei_spear",
    "Animators/duel/Anim_unit_12_yumihei_bow",
    "Animators/duel/Anim_unit_16_sogekihei_gun",
    "Animators/duel/Anim_unit_23_souryo",
    "Animators/duel_win/win_03_youki_sogekihei",
    "Animators/duel_win/win_05_kawaii_yumihei"
  };

  protected override void Initialize()
  {
    this.loaderDic = new Dictionary<ResourceInfo.INFO_PATH_TYPE, IResourceLoader>()
    {
      {
        ResourceInfo.INFO_PATH_TYPE.RESOURCE,
        (IResourceLoader) new ResourceLoader()
      },
      {
        ResourceInfo.INFO_PATH_TYPE.STREAMING,
        (IResourceLoader) new StreamingAssetsLoader()
      },
      {
        ResourceInfo.INFO_PATH_TYPE.ASSET_BUNDLE,
        (IResourceLoader) new AssetBundleLoader((MonoBehaviour) this)
      }
    };
    Caching.maximumAvailableDiskSpace = 157286400L;
    ResourceManager.IsInited = true;
  }

  [DebuggerHidden]
  public IEnumerator CleanupCache()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CCleanupCache\u003Ec__IteratorBD2()
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
    string path1 = DLC.ResourceDirectory("df") + "paths.json";
    string path2 = StorageUtil.persistentDataPath + "/dlcversion.dat";
    try
    {
      using (FileStream fileStream = File.OpenRead(path1))
        this.resourceInfo = ResourceInfo.Deserialize((Stream) fileStream);
      this.resourceVersion = File.ReadAllText(path2, Encoding.UTF8);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ex.ToString());
      this.resourceInfo = (ResourceInfo) null;
      this.resourceVersion = (string) null;
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
    return (IEnumerator) new ResourceManager.\u003CDownloadIfNotExists\u003Ec__IteratorBD3()
    {
      path = path,
      \u003C\u0024\u003Epath = path,
      \u003C\u003Ef__this = this
    };
  }

  public void addFileNotDelete(HashSet<string> hs)
  {
    hs.Add("paths.json");
    hs.Add("resDownlComplete.bat");
    hs.Add("pathsFirstDownldSize.bat");
  }

  private static string downlResCompletedPath
  {
    get => DLC.ResourceDirectory("df") + "/resDownlComplete.bat";
  }

  public static string pathsFirstDownldSize
  {
    get => DLC.ResourceDirectory("df") + "pathsFirstDownldSize.bat";
  }

  public void saveFirstDownInfo(Dictionary<string, object> info)
  {
    try
    {
      string contents = Json.Serialize((object) info);
      if (contents == null)
        return;
      File.WriteAllText(ResourceManager.pathsFirstDownldSize, contents, Encoding.UTF8);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ex.ToString());
    }
  }

  public static bool isDownlLoacl()
  {
    if (ResourceManager.resDownlLocal == ResourceManager.FILE_IS_EXISTS.FILE_NO)
      ResourceManager.resDownlLocal = File.Exists(ResourceManager.downlResCompletedPath) ? ResourceManager.FILE_IS_EXISTS.FILE_EXISTS : ResourceManager.FILE_IS_EXISTS.FILE_NOT_EXISTS;
    return ResourceManager.resDownlLocal == ResourceManager.FILE_IS_EXISTS.FILE_NOT_EXISTS;
  }

  public int getFirstDownloadSize()
  {
    Dictionary<string, object> firstDownInfo = this.getFirstDownInfo();
    try
    {
      return !firstDownInfo.ContainsKey("presize") ? 0 : Convert.ToInt32(firstDownInfo["presize"]);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ex.ToString());
    }
    return 0;
  }

  public void saveFirstDownloadSize(long size)
  {
    Dictionary<string, object> firstDownInfo = this.getFirstDownInfo();
    if (firstDownInfo.ContainsKey("presize"))
      firstDownInfo["presize"] = (object) size;
    else
      firstDownInfo.Add("presize", (object) size);
    this.saveFirstDownInfo(firstDownInfo);
  }

  public Dictionary<string, object> getFirstDownInfo()
  {
    if (this.mFirstDownInfo != null)
      return this.mFirstDownInfo;
    Dictionary<string, object> dictionary = (Dictionary<string, object>) null;
    try
    {
      if (File.Exists(ResourceManager.pathsFirstDownldSize))
        dictionary = Json.Deserialize(File.ReadAllText(ResourceManager.pathsFirstDownldSize, Encoding.UTF8)) as Dictionary<string, object>;
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ex.ToString());
    }
    if (dictionary == null)
      dictionary = new Dictionary<string, object>();
    this.mFirstDownInfo = dictionary;
    return this.mFirstDownInfo;
  }

  public bool Initialized => this.resourceInfo != null;

  [DebuggerHidden]
  public IEnumerator InitResourceInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CInitResourceInfo\u003Ec__IteratorBD4()
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

  public static bool ResDownlCompleted
  {
    get
    {
      ResourceManager instance = Singleton<ResourceManager>.GetInstance();
      return !Object.op_Equality((Object) instance, (Object) null) && instance.resCompleted;
    }
  }

  public void resDownlCompleted(bool completed)
  {
    if (File.Exists(ResourceManager.downlResCompletedPath))
      return;
    File.Create(ResourceManager.downlResCompletedPath);
    ResourceManager.resDownlLocal = ResourceManager.FILE_IS_EXISTS.FILE_EXISTS;
  }

  [DebuggerHidden]
  public IEnumerator SaveResourceInfo(byte[] buf, string dlcVersion)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CSaveResourceInfo\u003Ec__IteratorBD5()
    {
      buf = buf,
      dlcVersion = dlcVersion,
      \u003C\u0024\u003Ebuf = buf,
      \u003C\u0024\u003EdlcVersion = dlcVersion
    };
  }

  public ResourceInfo ResourceInfo => this.resourceInfo;

  public bool IsExpandExists(string key) => this.pathsExpand.ContainsKey(key);

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
    return (IEnumerator) new ResourceManager.\u003CSetStep\u003Ec__IteratorBD6()
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
    return (IEnumerator) new ResourceManager.\u003CSetSteps\u003Ec__IteratorBD7()
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
    return (IEnumerator) new ResourceManager.\u003CInternalLoad\u003Ec__IteratorBD8()
    {
      path = path,
      promise = promise,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }

  public bool Contains(string path)
  {
    return !string.IsNullOrEmpty(this.resourceInfo.SearchResourceInfo(path)._key);
  }

  public Future<T> LoadOrNull<T>(string path) where T : Object
  {
    return !Singleton<ResourceManager>.GetInstance().Contains(path) ? Future.Single<T>((T) null) : Singleton<ResourceManager>.GetInstance().Load<T>(path);
  }

  public Future<T> Load<T>(string path) where T : Object
  {
    return (object) typeof (T) != (object) typeof (Sprite) ? this.Cache.Get(path).Then<T>((Func<Object, T>) (obj => (T) obj)) : this.Cache.Get(path).Then<T>((Func<Object, T>) (obj =>
    {
      SpriteMeshType spriteMeshType = (SpriteMeshType) 0;
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

  public Future<T> Load<T>(string path, Action<T> callback) where T : Object
  {
    Future<T> future = this.Load<T>(path);
    future.RunOn<T>((MonoBehaviour) this, callback);
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
    ResourceInfo.Resource context = this.resourceInfo.SearchResourceInfo(path);
    if (!string.IsNullOrEmpty(context._key))
      return (T) this.loaderDic[context._value.path_type].LoadImmediatelyForSmallObject(path, ref context);
    Debug.LogError((object) "File not found: {0}".F((object) path));
    return (T) null;
  }

  [DebuggerHidden]
  public IEnumerator LoadResource(GameObject gameObject)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceManager.\u003CLoadResource\u003Ec__IteratorBD9()
    {
      gameObject = gameObject,
      \u003C\u0024\u003EgameObject = gameObject
    };
  }

  public string ResolveStreamingAssetsPath(string path)
  {
    ResourceInfo.Resource resource = this.resourceInfo != null ? this.resourceInfo.SearchResourceInfo(path) : throw new InvalidOperationException("resourceInfo is null");
    if (string.IsNullOrEmpty(resource._key))
      throw new ArgumentException(string.Format("resourceInfo.ContainsKey({0}) is false", (object) path));
    return DLC.ResourceFullPath(resource._value._file_name);
  }

  public string ResolveStreamingAssetsPathForMovie(string path)
  {
    string sourceFileName = this.ResolveStreamingAssetsPath(path);
    ResourceInfo.Resource resource = this.resourceInfo.SearchResourceInfo(path);
    if (string.IsNullOrEmpty(resource._key))
    {
      Debug.LogError((object) string.Format("resourceInfo.ContainsKey({0}) is false", (object) path));
      return string.Empty;
    }
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

  public bool isBaseUnits(string path)
  {
    foreach (string baseUnit in this.baseUnits)
    {
      if (path.Contains(baseUnit))
        return true;
    }
    foreach (string str in this.baseUnitAnim)
    {
      if (path.Equals(str))
        return true;
    }
    return false;
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

  public enum FILE_IS_EXISTS
  {
    FILE_NO = 1,
    FILE_EXISTS = 2,
    FILE_NOT_EXISTS = 3,
  }
}
