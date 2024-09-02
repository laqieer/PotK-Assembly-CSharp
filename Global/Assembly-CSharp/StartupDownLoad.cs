// Decompiled with JetBrains decompiler
// Type: StartupDownLoad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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

  public static ResourceDownloader.ProgressInfo progress { get; private set; }

  public static StartupDownLoad.State state { get; private set; }

  public static bool IsRunning
  {
    get => Object.op_Inequality((Object) StartupDownLoad.instance, (Object) null);
  }

  public static int progressNum()
  {
    return StartupDownLoad.progress == null ? 0 : StartupDownLoad.progress.Numerator;
  }

  public static int progressDem()
  {
    return StartupDownLoad.progress == null ? 100 : StartupDownLoad.progress.Denominator;
  }

  public static void StartDownload(string dlcVersion)
  {
    if (Object.op_Inequality((Object) StartupDownLoad.instance, (Object) null))
      return;
    StartupDownLoad.instance = GameObject.Find("DontDestroyObject").AddComponent<StartupDownLoad>();
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
    return (IEnumerator) new StartupDownLoad.\u003CAssetDownLoadStartAsync\u003Ec__Iterator89B()
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
    return (IEnumerator) new StartupDownLoad.\u003CwaitDownloadOrError\u003Ec__Iterator89C()
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
