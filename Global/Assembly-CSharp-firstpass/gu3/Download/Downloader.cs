// Decompiled with JetBrains decompiler
// Type: gu3.Download.Downloader
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using AOT;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace gu3.Download
{
  public class Downloader
  {
    private const string LIB_NAME = "Downloader";

    [DllImport("Downloader")]
    private static extern void Downloader_init(
      IntPtr finishDownloading,
      IntPtr writeData,
      IntPtr finishAllDownloading);

    [DllImport("Downloader")]
    private static extern void Downloader_start();

    [DllImport("Downloader")]
    private static extern void Downloader_addQueue(string from, string to, IntPtr handler);

    public static void Init()
    {
      Downloader.Downloader_init(Marshal.GetFunctionPointerForDelegate((Delegate) new Downloader.FinishDownloading(Downloader.didFinishDownloading)), Marshal.GetFunctionPointerForDelegate((Delegate) new Downloader.WriteData(Downloader.didWriteData)), Marshal.GetFunctionPointerForDelegate((Delegate) new Downloader.FinishAllDownloading(Downloader.didFinishAllDownloading)));
      AndroidJavaClass androidJavaClass1 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
      AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass1).GetStatic<AndroidJavaObject>("currentActivity");
      AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("jp.co.gu3.download.Downloader");
      ((AndroidJavaObject) androidJavaClass2).CallStatic("setContext", new object[1]
      {
        (object) androidJavaObject
      });
      ((AndroidJavaObject) androidJavaClass1).Dispose();
      androidJavaObject.Dispose();
      ((AndroidJavaObject) androidJavaClass2).Dispose();
    }

    public static void AddQueue(string from, string to, IDownloadHandler handler)
    {
      Downloader.Downloader_addQueue(from, to, Handle.ToIntPtr(handler));
    }

    public static void Start() => Downloader.Downloader_start();

    [MonoPInvokeCallback(typeof (Downloader.FinishDownloading))]
    public static void didFinishDownloading(IntPtr pHandler, string path, string location)
    {
      IDownloadHandler handler = Handle.FromIntPtr(pHandler);
      handler.didFinishDownloading(path, location);
      Handle.Remove(handler);
    }

    [MonoPInvokeCallback(typeof (Downloader.WriteData))]
    public static void didWriteData(
      IntPtr pHandler,
      string path,
      long receiveBytes,
      long totalBytes)
    {
      Handle.FromIntPtr(pHandler).didWriteData(path, receiveBytes, totalBytes);
    }

    [MonoPInvokeCallback(typeof (Downloader.FinishAllDownloading))]
    public static void didFinishAllDownloading()
    {
    }

    public delegate void FinishDownloading(IntPtr handler, string path, string location);

    public delegate void WriteData(
      IntPtr handler,
      string path,
      long receiveBytes,
      long totalBytes);

    public delegate void FinishAllDownloading();
  }
}
