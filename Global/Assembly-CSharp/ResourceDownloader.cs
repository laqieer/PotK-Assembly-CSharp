// Decompiled with JetBrains decompiler
// Type: ResourceDownloader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;

#nullable disable
public static class ResourceDownloader
{
  private static DLC assetBundle;
  private static DLC streamingAssets;
  private static string error;
  public static string errorDLC;
  private static bool completed;

  [DebuggerHidden]
  private static IEnumerator DownloadJson(string url, string dlcVersion, Promise<string> promise)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceDownloader.\u003CDownloadJson\u003Ec__Iterator943()
    {
      url = url,
      promise = promise,
      dlcVersion = dlcVersion,
      \u003C\u0024\u003Eurl = url,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u0024\u003EdlcVersion = dlcVersion
    };
  }

  public static ResourceDownloader.ProgressInfo Progress
  {
    get
    {
      if (ResourceDownloader.assetBundle == null || ResourceDownloader.streamingAssets == null)
        return (ResourceDownloader.ProgressInfo) null;
      return new ResourceDownloader.ProgressInfo()
      {
        Numerator = ResourceDownloader.assetBundle.GetDownloadedSize() + ResourceDownloader.streamingAssets.GetDownloadedSize(),
        Denominator = ResourceDownloader.assetBundle.GetDownloadSize() + ResourceDownloader.streamingAssets.GetDownloadSize()
      };
    }
  }

  public static bool Completed => ResourceDownloader.error != null || ResourceDownloader.completed;

  public static string Error => ResourceDownloader.error;

  public static void Restart()
  {
    ResourceDownloader.error = (string) null;
    ResourceDownloader.errorDLC = (string) null;
  }

  private static string[] GetEntries(string dirName)
  {
    string[] files = Directory.GetFiles(dirName);
    string[] entries = new string[files.Length];
    for (int index = 0; index < files.Length; ++index)
      entries[index] = Path.GetFileName(files[index]);
    return entries;
  }

  [DebuggerHidden]
  private static IEnumerator InternalStart(MonoBehaviour mono, string urlBase, string dlcVersion)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ResourceDownloader.\u003CInternalStart\u003Ec__Iterator944()
    {
      dlcVersion = dlcVersion,
      urlBase = urlBase,
      mono = mono,
      \u003C\u0024\u003EdlcVersion = dlcVersion,
      \u003C\u0024\u003EurlBase = urlBase,
      \u003C\u0024\u003Emono = mono
    };
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
    return (IEnumerator) new ResourceDownloader.\u003CCleanCache\u003Ec__Iterator945()
    {
      progress = progress,
      \u003C\u0024\u003Eprogress = progress
    };
  }

  public class ProgressInfo
  {
    public int Numerator;
    public int Denominator;
  }
}
