// Decompiled with JetBrains decompiler
// Type: StartupDownLoad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class StartupDownLoad : MonoBehaviour
{
  public bool debug1;
  public bool debug2;
  public bool debug3;
  private static StartupDownLoad instance;
  private static string lastestDLCVersion;
  public static bool isFriestDownload;

  public static ResourceDownloader.ProgressInfo progress { get; private set; }

  public static StartupDownLoad.State state { get; private set; }

  public static bool IsRunning
  {
    get => Object.op_Inequality((Object) StartupDownLoad.instance, (Object) null);
  }

  public static bool isNeedDLC
  {
    get
    {
      return ResourceManager.DLCVersion == null || !ResourceManager.DLCVersion.Equals(StartupDownLoad.lastestDLCVersion);
    }
  }

  public static long progressNum()
  {
    if (StartupDownLoad.progress == null)
      return 0;
    return StartupDownLoad.progress.Numerator > StartupDownLoad.progress.Denominator ? StartupDownLoad.progress.Denominator : StartupDownLoad.progress.Numerator;
  }

  public static long progressDem()
  {
    return StartupDownLoad.progress == null ? 100L : StartupDownLoad.progress.Denominator;
  }

  public static int nowDownloadSize => ResourceDownloader.nowDataDownloadSize;

  public static string nowDownloadName => ResourceDownloader.nowDataDownloadName;

  public static void SetLastestVersion(string dlcVersion)
  {
    StartupDownLoad.lastestDLCVersion = dlcVersion;
  }

  public static void StartDownload()
  {
    if (Object.op_Inequality((Object) StartupDownLoad.instance, (Object) null) || string.IsNullOrEmpty(StartupDownLoad.lastestDLCVersion))
      return;
    StartupDownLoad.instance = GameObject.Find("DontDestroyObject").AddComponent<StartupDownLoad>();
    string dlcVersion = GameConfig.dlc_version;
    if (StartupDownLoad.lastestDLCVersion != null && StartupDownLoad.lastestDLCVersion != string.Empty && StartupDownLoad.lastestDLCVersion.Length > 8)
      dlcVersion = StartupDownLoad.lastestDLCVersion;
    StartupDownLoad.instance.AssetDownLoadStart(DLC.UrlBase, dlcVersion);
  }

  private void assetDownLoadStartDebug()
  {
    StartupDownLoad.progress = (ResourceDownloader.ProgressInfo) null;
    StartupDownLoad.state = StartupDownLoad.State.Completed;
    StartupDownLoad.instance = (StartupDownLoad) null;
    Object.Destroy((Object) this);
  }

  public void AssetDownLoadStart(string urlBase, string dlcVersion)
  {
    this.StartCoroutine(this.AssetDownLoadStartAsync(urlBase, dlcVersion));
  }

  [DebuggerHidden]
  public IEnumerator AssetDownLoadStartAsync(string urlBase, string dlcVersion)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StartupDownLoad.\u003CAssetDownLoadStartAsync\u003Ec__IteratorAF1()
    {
      urlBase = urlBase,
      dlcVersion = dlcVersion,
      \u003C\u0024\u003EurlBase = urlBase,
      \u003C\u0024\u003EdlcVersion = dlcVersion,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator waitDownloadOrError(string urlBase, string dlcVersion)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StartupDownLoad.\u003CwaitDownloadOrError\u003Ec__IteratorAF2()
    {
      urlBase = urlBase,
      dlcVersion = dlcVersion,
      \u003C\u0024\u003EurlBase = urlBase,
      \u003C\u0024\u003EdlcVersion = dlcVersion,
      \u003C\u003Ef__this = this
    };
  }

  public enum State
  {
    Sleeping,
    Processing,
    Completed,
  }
}
