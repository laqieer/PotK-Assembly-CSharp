// Decompiled with JetBrains decompiler
// Type: ResourceDownloader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public static class ResourceDownloader
{
  private static ResourceDownloader.WWWEx jsonWWW;
  private static DLC assetBundle;
  private static DLC streamingAssets;
  private static string error;
  private static bool completed = false;
  private static int jsonProgress = 1;
  private static int num = 1024;
  private static int jsonSize = 10 * ResourceDownloader.num * ResourceDownloader.num;
  private static int maxDownload = 560;
  private static int _firstSize = -1;
  private static int nowDownloadSize = 0;
  private static string nowDownloadName = string.Empty;
  public static bool IsCheckingFiles = false;
  private static bool isDownloadJson = false;
  private static bool isFirst = false;

  [DebuggerHidden]
  private static IEnumerator DownloadJson(
    string url,
    string dlcVersion,
    MonoBehaviour mono,
    Promise<string> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceDownloader.\u003CDownloadJson\u003Ec__IteratorBC8()
    {
      url = url,
      mono = mono,
      promise = promise,
      dlcVersion = dlcVersion,
      \u003C\u0024\u003Eurl = url,
      \u003C\u0024\u003Emono = mono,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u0024\u003EdlcVersion = dlcVersion
    };
  }

  private static ResourceDownloader.ProgressInfo downlJson()
  {
    if (!ResourceDownloader.isDownloadJson)
      return (ResourceDownloader.ProgressInfo) null;
    int num1;
    switch (ResourceDownloader.jsonProgress)
    {
      case 1:
        num1 = ResourceDownloader.jsonWWW == null ? 0 : (int) ((double) (5 * ResourceDownloader.num * ResourceDownloader.num) * (double) ResourceDownloader.jsonWWW.progress);
        break;
      case 2:
        num1 = 5 * ResourceDownloader.num * ResourceDownloader.num;
        break;
      case 3:
        num1 = ResourceDownloader.jsonSize;
        break;
      case 4:
        num1 = 7 * ResourceDownloader.num * ResourceDownloader.num;
        break;
      default:
        num1 = 0;
        break;
    }
    int num2 = ResourceDownloader.maxDownload * ResourceDownloader.num * ResourceDownloader.num;
    return new ResourceDownloader.ProgressInfo()
    {
      Numerator = (long) num1,
      Denominator = (long) num2
    };
  }

  private static ResourceDownloader.ProgressInfo isNotFirst()
  {
    if (ResourceDownloader._firstSize < 0)
      ResourceDownloader._firstSize = Singleton<ResourceManager>.GetInstance().getFirstDownloadSize();
    int firstSize = ResourceDownloader._firstSize;
    long num1 = ResourceDownloader.assetBundle.GetDownloadSize() + ResourceDownloader.streamingAssets.GetDownloadSize();
    long num2 = ResourceDownloader.assetBundle.GetDownloadedSize() + ResourceDownloader.streamingAssets.GetDownloadedSize() + (long) ResourceDownloader.getJsonSizp();
    long num3 = (long) firstSize - num1;
    if (num3 < 0L)
      num3 = 0L;
    return new ResourceDownloader.ProgressInfo()
    {
      Numerator = num3 + ResourceDownloader.assetBundle.GetDownloadedSize() + ResourceDownloader.streamingAssets.GetDownloadedSize() + (long) ResourceDownloader.getJsonSizp(),
      Denominator = (long) (firstSize + ResourceDownloader.getJsonSizp())
    };
  }

  private static int getJsonSizp()
  {
    return ResourceDownloader.isDownloadJson ? ResourceDownloader.jsonSize : 0;
  }

  public static ResourceDownloader.ProgressInfo Progress
  {
    get
    {
      if (ResourceDownloader.assetBundle == null || ResourceDownloader.streamingAssets == null)
        return ResourceDownloader.downlJson();
      if (!ResourceDownloader.isFirst && !ResourceManager.ResDownlCompleted)
        return ResourceDownloader.isNotFirst();
      return new ResourceDownloader.ProgressInfo()
      {
        Numerator = ResourceDownloader.assetBundle.GetDownloadedSize() + ResourceDownloader.streamingAssets.GetDownloadedSize() + (long) ResourceDownloader.getJsonSizp(),
        Denominator = ResourceDownloader.assetBundle.GetDownloadSize() + ResourceDownloader.streamingAssets.GetDownloadSize() + (long) ResourceDownloader.getJsonSizp()
      };
    }
  }

  public static int nowDataDownloadSize
  {
    get => ResourceDownloader.nowDownloadSize;
    set => ResourceDownloader.nowDownloadSize = value;
  }

  public static string nowDataDownloadName
  {
    get => ResourceDownloader.nowDownloadName;
    set => ResourceDownloader.nowDownloadName = value;
  }

  public static bool Completed => ResourceDownloader.error != null || ResourceDownloader.completed;

  public static string Error => ResourceDownloader.error;

  public static void Restart() => ResourceDownloader.error = (string) null;

  [DebuggerHidden]
  private static IEnumerator InternalStart(MonoBehaviour mono, string urlBase, string dlcVersion)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceDownloader.\u003CInternalStart\u003Ec__IteratorBC9()
    {
      dlcVersion = dlcVersion,
      mono = mono,
      \u003C\u0024\u003EdlcVersion = dlcVersion,
      \u003C\u0024\u003Emono = mono
    };
  }

  private static void sendDownloadFinish()
  {
    Dictionary<string, object> firstDownInfo = Singleton<ResourceManager>.GetInstance().getFirstDownInfo();
    int num = 11;
    if (firstDownInfo.ContainsKey("didx"))
      firstDownInfo["didx"] = (object) num;
    else
      firstDownInfo.Add("didx", (object) num);
    Singleton<ResourceManager>.GetInstance().saveFirstDownInfo(firstDownInfo);
    int times = 0;
    try
    {
      times = !firstDownInfo.ContainsKey("dtimes") ? 0 : Convert.ToInt32(firstDownInfo["dtimes"]);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ex.ToString());
    }
    UserEvent.SendDownloadEvent((MonoBehaviour) Singleton<ResourceManager>.GetInstance(), 10, times);
  }

  public static Coroutine Start(MonoBehaviour mono, string urlBase, string dlcVersion)
  {
    ResourceDownloader.completed = false;
    return mono.StartCoroutine(ResourceDownloader.InternalStart(mono, urlBase, dlcVersion));
  }

  [DebuggerHidden]
  public static IEnumerator CleanCache(Action<int, int> progress)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceDownloader.\u003CCleanCache\u003Ec__IteratorBCA()
    {
      progress = progress,
      \u003C\u0024\u003Eprogress = progress
    };
  }

  private class WWWEx : IDisposable
  {
    private WWW _www;
    private int preProgress;
    private float _preTime;
    private bool _succeeded;
    private string _error;
    private string mUrl;
    private IEnumerator coroutine;

    public WWWEx(string url) => this.mUrl = url;

    [DebuggerHidden]
    public IEnumerator Start(MonoBehaviour mono)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new ResourceDownloader.WWWEx.\u003CStart\u003Ec__IteratorBCB()
      {
        mono = mono,
        \u003C\u0024\u003Emono = mono,
        \u003C\u003Ef__this = this
      };
    }

    public bool succeeded => this._succeeded;

    public string error => this._error;

    public WWW www => this._www;

    public float progress => this._www != null ? this._www.progress : 0.0f;

    public bool isTimeout()
    {
      double num = (double) this.updateTime();
      bool flag = false;
      if (this.preProgress > 0)
        flag = (double) Time.time - (double) this._preTime > 10.0;
      if (flag)
        this._error = this.mUrl + "time out may be net lost.";
      return flag;
    }

    [DebuggerHidden]
    private IEnumerator Wait()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new ResourceDownloader.WWWEx.\u003CWait\u003Ec__IteratorBCC()
      {
        \u003C\u003Ef__this = this
      };
    }

    public void Dispose()
    {
    }

    private float updateTime()
    {
      if (this._www != null)
      {
        float progress = this._www.progress;
        int num = (int) ((double) progress * 1000000.0);
        if (num != this.preProgress || (double) progress <= 0.0 || (double) progress >= 1.0)
        {
          this.preProgress = num;
          this._preTime = Time.time;
        }
      }
      else
        this._preTime = Time.time;
      return this._preTime;
    }
  }

  public class ProgressInfo
  {
    public long Numerator;
    public long Denominator;
  }

  public enum JSON_DOWN
  {
    JSON_DOWN_START = 1,
    JSON_DOWN_SUCC = 2,
    JSON_PARSE_SUCC = 3,
    JSON_WRITE_DATA_SUCC = 4,
  }
}
