// Decompiled with JetBrains decompiler
// Type: DenaLib.HttpDownload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class HttpDownload
  {
    public const int BUFFER_SIZE = 1024;
    public const int Timeout = 3000;
    private Queue<HttpDownload.DownLoadContext> m_DownLoadContextQueue = new Queue<HttpDownload.DownLoadContext>();
    private HttpDownload.DownLoadContext m_CurrentDownLoadContext;

    public HttpDownload() => HttpDownload.DownLoadContext.Init();

    public void Download(
      string url,
      string fileName,
      bool newFile,
      long size,
      object param,
      HttpDownload.OnDownloadFinish downloadFinishCb)
    {
      HttpDownload.DownLoadContext downLoadContext = new HttpDownload.DownLoadContext();
      downLoadContext.FileName = fileName;
      downLoadContext.Url = url;
      downLoadContext.Param = param;
      downLoadContext.TotalNew = newFile;
      downLoadContext.DownloadFinishCb = downloadFinishCb;
      downLoadContext.FileSize = size;
      if (this.m_CurrentDownLoadContext == null)
      {
        this.m_CurrentDownLoadContext = downLoadContext;
        this.m_CurrentDownLoadContext.Start();
      }
      else
        this.m_DownLoadContextQueue.Enqueue(downLoadContext);
    }

    public void Update()
    {
      if (this.m_CurrentDownLoadContext != null)
      {
        this.m_CurrentDownLoadContext.elapsedTime += Time.deltaTime;
        if (!this.m_CurrentDownLoadContext.DownLoading)
        {
          if (this.m_CurrentDownLoadContext.Error && this.m_CurrentDownLoadContext.TryCount < HttpDownload.DownLoadContext.MaxTryCount)
          {
            this.m_CurrentDownLoadContext.Start();
          }
          else
          {
            if (this.m_CurrentDownLoadContext.DownloadFinishCb != null)
              this.m_CurrentDownLoadContext.DownloadFinishCb(this.m_CurrentDownLoadContext.FileName, this.m_CurrentDownLoadContext.Message, this.m_CurrentDownLoadContext.Error, this.m_CurrentDownLoadContext.Param);
            this.m_CurrentDownLoadContext = (HttpDownload.DownLoadContext) null;
          }
        }
        else if ((double) this.m_CurrentDownLoadContext.elapsedTime > (double) this.m_CurrentDownLoadContext.waitTime)
          this.m_CurrentDownLoadContext.StopDownLoadLua();
      }
      if (this.m_CurrentDownLoadContext != null || this.m_DownLoadContextQueue.Count <= 0)
        return;
      this.m_CurrentDownLoadContext = this.m_DownLoadContextQueue.Dequeue();
      this.m_CurrentDownLoadContext.Start();
    }

    public long GetCurrentDownloadSize()
    {
      return this.m_CurrentDownLoadContext != null ? this.m_CurrentDownLoadContext.FileDownloadSize : 0L;
    }

    public class DownLoadContext
    {
      public string FileName = string.Empty;
      public string Url = string.Empty;
      public byte[] BufferRead = new byte[1024];
      public FileStream FS;
      public HttpWebRequest WebRequest;
      public HttpWebResponse WebResponse;
      public Stream ResponseStream;
      public string Message = string.Empty;
      public HttpDownload.OnDownloadFinish DownloadFinishCb;
      public object Param;
      public bool DownLoading;
      public bool Error;
      public int TryCount;
      public bool TotalNew;
      public static int MaxTryCount = 1;
      public static AsyncCallback ResponseCb;
      public static AsyncCallback ReadCb;
      public static WaitOrTimerCallback TimeOutCb;
      public long FileSize;
      public long FileDownloadSize;
      public Coroutine coroutineDownLua;
      public float elapsedTime;
      public float waitTime = 20f;
      private static WWW jsonWWW;

      public static void Init()
      {
        if (HttpDownload.DownLoadContext.ResponseCb == null)
          HttpDownload.DownLoadContext.ResponseCb = new AsyncCallback(HttpDownload.DownLoadContext.ResponseCallback);
        if (HttpDownload.DownLoadContext.TimeOutCb == null)
          HttpDownload.DownLoadContext.TimeOutCb = new WaitOrTimerCallback(HttpDownload.DownLoadContext.TimeoutCallback);
        if (HttpDownload.DownLoadContext.ReadCb != null)
          return;
        HttpDownload.DownLoadContext.ReadCb = new AsyncCallback(HttpDownload.DownLoadContext.ReadCallback);
      }

      public void Start()
      {
        try
        {
          if (HttpDownload.DownLoadContext.ResponseCb != null)
          {
            if (this.CheckContinueDownloadFile())
            {
              ++this.TryCount;
              this.coroutineDownLua = global::Singleton<ResourceManager>.GetInstance().StartCoroutine(this.DownloadLua());
              this.DownLoading = true;
              return;
            }
            this.Error = false;
            this.DownLoading = false;
            return;
          }
        }
        catch (Exception ex)
        {
          this.Message = ex.Message;
        }
        this.Error = true;
        this.DownLoading = false;
      }

      public void StopDownLoadLua()
      {
        MonoBehaviour instance = (MonoBehaviour) global::Singleton<ResourceManager>.GetInstance();
        this.DownLoading = false;
        instance.StopCoroutine(this.coroutineDownLua);
        HttpDownload.DownLoadContext.jsonWWW.Dispose();
        Debug.LogError((object) "StopDownLoadLua!");
      }

      [DebuggerHidden]
      public IEnumerator DownloadLua()
      {
        // ISSUE: object of a compiler-generated type is created
        return (IEnumerator) new HttpDownload.DownLoadContext.\u003CDownloadLua\u003Ec__Iterator0()
        {
          \u003C\u003Ef__this = this
        };
      }

      public void Clean()
      {
        if (this.WebRequest != null)
          this.WebRequest.Abort();
        if (this.ResponseStream != null)
          this.ResponseStream.Close();
        if (this.FS == null)
          return;
        this.FS.Close();
      }

      private bool CheckContinueDownloadFile()
      {
        string fileName = this.FileName;
        if (System.IO.File.Exists(fileName))
        {
          if (this.TotalNew)
          {
            System.IO.File.Delete(fileName);
          }
          else
          {
            this.FileDownloadSize = new FileInfo(fileName).Length;
            return this.FileDownloadSize < this.FileSize;
          }
        }
        return true;
      }

      private static void ResponseCallback(IAsyncResult asyncResult)
      {
        if (asyncResult == null || !(asyncResult.AsyncState is HttpDownload.DownLoadContext))
          return;
        HttpDownload.DownLoadContext asyncState = asyncResult.AsyncState as HttpDownload.DownLoadContext;
        try
        {
          HttpWebRequest webRequest = asyncState.WebRequest;
          asyncState.WebResponse = (HttpWebResponse) webRequest.EndGetResponse(asyncResult);
          Stream responseStream = asyncState.WebResponse.GetResponseStream();
          asyncState.ResponseStream = responseStream;
          string path = asyncState.FileName + ".tmp";
          if (asyncState.FS != null)
            asyncState.FS.Close();
          asyncState.FS = System.IO.File.Open(path, FileMode.OpenOrCreate);
          if (asyncState.FS.Length > 0L)
            asyncState.FS.Seek(asyncState.FS.Length, SeekOrigin.Begin);
          responseStream.BeginRead(asyncState.BufferRead, 0, 1024, HttpDownload.DownLoadContext.ReadCb, (object) asyncState);
          return;
        }
        catch (WebException ex)
        {
          asyncState.Message = ex.Message;
        }
        catch (Exception ex)
        {
          asyncState.Message = ex.Message;
        }
        asyncState.Clean();
        asyncState.Error = true;
        asyncState.DownLoading = false;
      }

      private static void ReadCallback(IAsyncResult asyncResult)
      {
        if (asyncResult == null || !(asyncResult.AsyncState is HttpDownload.DownLoadContext))
          return;
        HttpDownload.DownLoadContext asyncState = asyncResult.AsyncState as HttpDownload.DownLoadContext;
        try
        {
          Stream responseStream = asyncState.ResponseStream;
          int count = responseStream.EndRead(asyncResult);
          if (count > 0 && asyncState.FS != null)
          {
            asyncState.FS.Write(asyncState.BufferRead, 0, count);
            asyncState.FileDownloadSize += (long) count;
            responseStream.BeginRead(asyncState.BufferRead, 0, 1024, HttpDownload.DownLoadContext.ReadCb, (object) asyncState);
            return;
          }
          asyncState.Clean();
          string str = asyncState.FileName + ".tmp";
          System.IO.File.Copy(str, asyncState.FileName, true);
          System.IO.File.Delete(str);
        }
        catch (WebException ex)
        {
          asyncState.Message = ex.Message;
          asyncState.Clean();
          asyncState.Error = true;
        }
        catch (Exception ex)
        {
          asyncState.Message = ex.Message;
          asyncState.Clean();
          asyncState.Error = true;
        }
        asyncState.DownLoading = false;
      }

      private static void TimeoutCallback(object state, bool timeout)
      {
        if (!timeout || !(state is HttpDownload.DownLoadContext downLoadContext))
          return;
        downLoadContext.Clean();
        downLoadContext.Error = true;
        downLoadContext.Message = nameof (timeout);
        downLoadContext.DownLoading = false;
      }
    }

    public delegate void OnDownloadFinish(
      string filename,
      string message,
      bool error,
      object param);
  }
}
