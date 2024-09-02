// Decompiled with JetBrains decompiler
// Type: DenaLib.UpdateManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class UpdateManager
  {
    protected string m_ResourceDir = string.Empty;
    protected string m_LocalResourceDir = string.Empty;
    protected List<string> m_DownLoadUrl = new List<string>();
    protected HttpDownload m_HttpDownload = new HttpDownload();
    protected EUpdateState m_UpdateState;
    protected EUpdateResult m_UpdateResult;

    public event UpdateManager.DownloadFinishEvent OnDownloadFinish;

    public virtual void AddRemoteServer(string url)
    {
      if (this.m_DownLoadUrl.Count <= 0)
      {
        this.m_DownLoadUrl.Add(url);
      }
      else
      {
        bool flag = false;
        for (int index = 0; index < this.m_DownLoadUrl.Count; ++index)
        {
          if (this.m_DownLoadUrl[index] == url)
            flag = true;
        }
        if (flag)
          return;
        this.m_DownLoadUrl.Add(url);
      }
    }

    public virtual void CheckUpdate()
    {
    }

    public virtual void Update() => this.m_HttpDownload.Update();

    public virtual void PostUpdate()
    {
      if (this.m_UpdateState != EUpdateState.EUpdateFinish)
        return;
      this.m_UpdateState = EUpdateState.EIdle;
      if (this.OnDownloadFinish == null)
        return;
      this.OnDownloadFinish(this.m_UpdateResult == EUpdateResult.EFinish);
    }

    public virtual float GetUpdateProgress() => 0.0f;

    public virtual void Reset()
    {
    }

    public bool DownLoadFile(
      string remote,
      string local,
      bool newFile,
      DownloadParam dp,
      HttpDownload.OnDownloadFinish downFinishCb)
    {
      if (dp.tryCount < this.m_DownLoadUrl.Count)
      {
        this.m_HttpDownload.Download(this.m_DownLoadUrl[dp.tryCount] + remote, local, newFile, dp.size, (object) dp, downFinishCb);
        return true;
      }
      Debug.LogError((object) "Download Lua Failed! no server or try too times");
      return false;
    }

    public delegate void NetworkCheck();

    public delegate void DownloadFinishEvent(bool success);
  }
}
