﻿// Decompiled with JetBrains decompiler
// Type: StartupDownLoad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using DeviceKit;
using GameCore;
using System.Collections;
using UnityEngine;

public class StartupDownLoad : MonoBehaviour
{
  public bool debug1;
  public bool debug2;
  public bool debug3;
  private static StartupDownLoad instance;
  private static string lastestDLCVersion;

  public static ResourceDownloader.ProgressInfo progress { get; private set; }

  public static StartupDownLoad.State state { get; private set; }

  public static bool IsRunning => (UnityEngine.Object) StartupDownLoad.instance != (UnityEngine.Object) null;

  public static bool isNeedDLC => ResourceManager.DLCVersion == null || !ResourceManager.DLCVersion.Equals(StartupDownLoad.lastestDLCVersion);

  public static long progressNum() => StartupDownLoad.progress != null ? StartupDownLoad.progress.Numerator : 0L;

  public static long progressDem() => StartupDownLoad.progress != null ? StartupDownLoad.progress.Denominator : 100L;

  public static void SetLastestVersion(string dlcVersion) => StartupDownLoad.lastestDLCVersion = dlcVersion;

  public static string GetLastestVersion() => StartupDownLoad.lastestDLCVersion;

  public static void StartDownload(bool confirmDLC)
  {
    if ((UnityEngine.Object) StartupDownLoad.instance != (UnityEngine.Object) null || string.IsNullOrEmpty(StartupDownLoad.lastestDLCVersion))
      return;
    StartupDownLoad.instance = GameObject.Find("DontDestroyObject").AddComponent<StartupDownLoad>();
    StartupDownLoad.instance.AssetDownLoadStart(DLC.UrlBase, StartupDownLoad.lastestDLCVersion, confirmDLC);
  }

  private void assetDownLoadStartDebug()
  {
    StartupDownLoad.progress = (ResourceDownloader.ProgressInfo) null;
    StartupDownLoad.state = StartupDownLoad.State.Completed;
    StartupDownLoad.instance = (StartupDownLoad) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) this);
  }

  public void AssetDownLoadStart(string urlBase, string dlcVersion, bool confirmDLC) => this.StartCoroutine(this.AssetDownLoadStartAsync(urlBase, dlcVersion, confirmDLC));

  public IEnumerator AssetDownLoadStartAsync(
    string urlBase,
    string dlcVersion,
    bool confirmDLC)
  {
    StartupDownLoad startupDownLoad = this;
    StartupDownLoad.progress = (ResourceDownloader.ProgressInfo) null;
    StartupDownLoad.state = StartupDownLoad.State.Processing;
    App.SetAutoSleep(false);
    bool bAbort = false;
    IEnumerator e = startupDownLoad.waitDownloadOrError(urlBase, dlcVersion, confirmDLC, (System.Action) (() => bAbort = true));
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    App.SetAutoSleep(true);
    if (bAbort)
    {
      StartupDownLoad.state = StartupDownLoad.State.Abort;
      StartScript.Restart();
    }
    else
      StartupDownLoad.state = StartupDownLoad.State.Completed;
    StartupDownLoad.instance = (StartupDownLoad) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) startupDownLoad);
  }

  private IEnumerator waitDownloadOrError(
    string urlBase,
    string dlcVersion,
    bool confirmDLC,
    System.Action actionAbort)
  {
    StartupDownLoad startupDownLoad = this;
    bool bAbort = false;
    ResourceDownloader.Start((MonoBehaviour) startupDownLoad, urlBase, dlcVersion, confirmDLC, (System.Action) (() =>
    {
      bAbort = true;
      actionAbort();
    }));
    while (true)
    {
      StartupDownLoad.progress = ResourceDownloader.Progress;
      while (!ResourceDownloader.Completed)
      {
        if (bAbort)
        {
          yield break;
        }
        else
        {
          StartupDownLoad.progress = ResourceDownloader.Progress;
          yield return (object) null;
        }
      }
      if (ResourceDownloader.Error != null)
      {
        Debug.LogError((object) ResourceDownloader.Error);
        bool waitClick = true;
        ModalWindow.Show(Consts.GetInstance().dlc_fail_download_title, ResourceDownloader.Error, (System.Action) (() => waitClick = false));
        while (waitClick)
          yield return (object) null;
        ResourceDownloader.Restart();
      }
      else
        break;
    }
  }

  public enum State
  {
    Sleeping,
    Processing,
    Completed,
    Abort,
  }
}
