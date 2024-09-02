// Decompiled with JetBrains decompiler
// Type: DenaLib.HotUpdate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace DenaLib
{
  public class HotUpdate : UpdateManager
  {
    private int m_MainVersion;
    private string m_PackageDir = string.Empty;
    private string m_LocalPackageDir = string.Empty;
    private string m_LocalLuaDir = string.Empty;
    private UpdateMetaFile m_RemoteMetaFile = new UpdateMetaFile();
    private int m_UpdateIndex = -1;
    private UpdateMetaFile m_LocalMetaFile = new UpdateMetaFile();
    private HttpDownload.OnDownloadFinish m_UpdateMetaDownFinishCb;
    private HttpDownload.OnDownloadFinish m_PackageDownFinishCb;
    private float m_Progress;
    private float m_CurrentProgress;

    public HotUpdate()
    {
      this.m_UpdateMetaDownFinishCb = new HttpDownload.OnDownloadFinish(this.OnUpdateMetaDownFinish);
      this.m_PackageDownFinishCb = new HttpDownload.OnDownloadFinish(this.OnPackageDownFinish);
    }

    public static void UnPackage(string packagefile, string dir)
    {
      FileInfo fileInfo = new FileInfo(packagefile);
      if (!fileInfo.Exists)
        return;
      try
      {
        List<UpdateInfo> updateInfoList = new List<UpdateInfo>();
        FileStream input1 = new FileStream(fileInfo.FullName, FileMode.Open);
        BinaryReader br = new BinaryReader((Stream) input1);
        int num = br.ReadInt32();
        for (int index = 0; index < num; ++index)
        {
          UpdateInfo updateInfo = new UpdateInfo();
          updateInfo.Load(br);
          updateInfoList.Add(updateInfo);
        }
        string path1 = fileInfo.FullName + ".unpak";
        if (File.Exists(path1))
          File.Delete(path1);
        FileStream output = new FileStream(path1, FileMode.CreateNew);
        Singleton<Utlity>.Instance.DecompressFileLZMA(input1, output);
        output.Close();
        FileStream input2 = new FileStream(path1, FileMode.Open);
        BinaryReader binaryReader = new BinaryReader((Stream) input2);
        for (int index = 0; index < updateInfoList.Count; ++index)
        {
          UpdateInfo updateInfo = updateInfoList[index];
          string str1 = dir + updateInfo.relativePath;
          Singleton<Utlity>.Instance.CreateDir(dir, updateInfo.relativePath);
          string path2 = str1.Replace("\\", "/");
          if (updateInfo.updateType == 0 && updateInfo.length > 0L)
          {
            byte[] numArray = new byte[updateInfo.length];
            binaryReader.Read(numArray, 0, (int) updateInfo.length);
            if (File.Exists(path2))
              File.Delete(path2);
            using (FileStream fileStream = new FileStream(path2, FileMode.CreateNew))
              fileStream.Write(numArray, 0, (int) updateInfo.length);
            string str2 = Singleton<Utlity>.Instance.CalcFileMD5(numArray);
            if (str2 != updateInfo.md5)
              Debuger.LogWarning((object) string.Format("{0} md5 unmatched:orignal {1} new {2}", (object) updateInfo.name, (object) updateInfo.md5, (object) str2));
          }
          else if (updateInfo.updateType == 1)
          {
            string path3 = dir + updateInfo.name;
            if (File.Exists(path3))
              File.Delete(path3);
          }
        }
        input2.Close();
        if (!File.Exists(path1))
          return;
        File.Delete(path1);
      }
      catch (Exception ex)
      {
        Debuger.LogWarning((object) ex.Message);
      }
    }

    public void SetVersion(int mainVersion)
    {
      this.m_MainVersion = mainVersion;
      this.m_ResourceDir = PathManager.HotUpdateDataDir;
      this.m_PackageDir = PathManager.HotUpdatePackageDir;
      this.m_LocalResourceDir = PathManager.UpdateBaseDir + this.m_ResourceDir;
      this.m_LocalPackageDir = PathManager.UpdateBaseDir + this.m_PackageDir;
      this.m_LocalLuaDir = this.m_LocalResourceDir + "/Lua";
      try
      {
        if (!Directory.Exists(PathManager.UpdateBaseDir + PathManager.HotUpdateDir))
          Directory.CreateDirectory(PathManager.UpdateBaseDir + PathManager.HotUpdateDir);
        if (!Directory.Exists(this.m_LocalResourceDir))
          Directory.CreateDirectory(this.m_LocalResourceDir);
        if (Directory.Exists(this.m_LocalPackageDir))
          return;
        Directory.CreateDirectory(this.m_LocalPackageDir);
      }
      catch (Exception ex)
      {
        this.m_UpdateResult = EUpdateResult.EMetaError;
        Singleton<Utlity>.Instance.LogMsg(EMessageCode.EInitHotUpdateDirFail, ex.Message);
      }
    }

    public string GetLuaDir() => this.m_LocalLuaDir;

    public override void CheckUpdate()
    {
      base.CheckUpdate();
      this.m_LocalMetaFile.Load(this.m_LocalPackageDir + UpdateMetaFile.LocMetaFileName);
      this.m_UpdateIndex = -1;
      this.m_UpdateState = EUpdateState.EChecking;
      this.m_UpdateResult = EUpdateResult.EUnkow;
      this.m_Progress = 0.0f;
      this.m_CurrentProgress = 0.0f;
      this.DownloadMeta(new DownloadParam()
      {
        tryCount = 0,
        md5 = string.Empty
      });
    }

    public override void Update()
    {
      base.Update();
      if (this.m_UpdateState != EUpdateState.EUpdating)
        return;
      if (this.m_RemoteMetaFile.TotalSize > 0L)
        this.m_Progress = (float) (this.m_LocalMetaFile.TotalSize + this.m_HttpDownload.GetCurrentDownloadSize()) / (float) this.m_RemoteMetaFile.TotalSize;
      if ((double) this.m_Progress > 1.0)
        this.m_Progress = 1f;
      if ((double) this.m_CurrentProgress >= (double) this.m_Progress)
        return;
      this.m_CurrentProgress += 0.1f;
      if ((double) this.m_CurrentProgress <= 1.0)
        return;
      this.m_CurrentProgress = 1f;
    }

    public override void PostUpdate()
    {
      if (this.m_UpdateState == EUpdateState.EUpdateFinish)
      {
        if ((double) this.m_CurrentProgress < (double) this.m_Progress)
        {
          this.m_CurrentProgress += 0.1f;
          if ((double) this.m_CurrentProgress > 1.0)
            this.m_CurrentProgress = 1f;
        }
        else
        {
          this.m_CurrentProgress = 1f;
          base.PostUpdate();
        }
      }
      if (this.m_UpdateResult != EUpdateResult.EMetaError && this.m_UpdateResult != EUpdateResult.EPackageError)
        return;
      this.m_UpdateState = EUpdateState.EUpdateFinish;
    }

    public override void Reset()
    {
      try
      {
        if (!Directory.Exists(this.m_LocalResourceDir))
          return;
        Directory.Delete(this.m_LocalResourceDir, true);
      }
      catch (Exception ex)
      {
        Debuger.LogWarning((object) ex.Message);
      }
    }

    private void DownloadMeta(DownloadParam dp)
    {
      string str = DateTime.Now.ToString("yyyyMMddhhmmss");
      if (this.DownLoadFile(this.m_PackageDir + UpdateMetaFile.MetaFileName + "?ver=" + str, this.m_LocalPackageDir + UpdateMetaFile.MetaFileName, true, dp, this.m_UpdateMetaDownFinishCb))
        return;
      this.m_UpdateResult = EUpdateResult.EMetaError;
    }

    private void DownloadPackage()
    {
      ++this.m_UpdateIndex;
      for (; this.m_RemoteMetaFile.PackageList.Count > 0 && this.m_UpdateIndex < this.m_RemoteMetaFile.PackageList.Count; ++this.m_UpdateIndex)
      {
        UpdatePackageInfo package = this.m_RemoteMetaFile.PackageList[this.m_UpdateIndex];
        if (!this.m_LocalMetaFile.FindPackage(package))
        {
          this.DownloadPackage(new DownloadParam()
          {
            tryCount = 0,
            name = package.name,
            md5 = package.md5,
            size = package.size
          });
          break;
        }
      }
      if (this.m_RemoteMetaFile.PackageList.Count != 0 && this.m_UpdateIndex < this.m_RemoteMetaFile.PackageList.Count)
        return;
      this.m_UpdateState = EUpdateState.EUpdateFinish;
      this.m_UpdateResult = EUpdateResult.EFinish;
    }

    private void DownloadPackage(DownloadParam dp)
    {
      string str1 = DateTime.Now.ToString("yyyyMMddhhmmss");
      string str2 = "/" + dp.name + ".data";
      if (this.DownLoadFile(this.m_PackageDir + str2 + "?ver=" + str1, this.m_LocalPackageDir + str2, true, dp, this.m_PackageDownFinishCb))
        return;
      this.m_UpdateResult = EUpdateResult.EPackageError;
    }

    private void OnUpdateMetaDownFinish(string filename, string message, bool error, object param)
    {
      if (error)
      {
        Debuger.Log((object) ("download error:" + (object) error));
        if (!(param is DownloadParam dp))
          return;
        ++dp.tryCount;
        this.DownloadMeta(dp);
      }
      else if (File.Exists(filename))
      {
        this.m_RemoteMetaFile.Load(filename);
        this.m_UpdateState = EUpdateState.EUpdating;
        this.DownloadPackage();
      }
      else
      {
        this.m_UpdateState = EUpdateState.EUpdateFinish;
        this.m_UpdateResult = EUpdateResult.EPackageError;
      }
    }

    private void OnPackageDownFinish(string filename, string message, bool error, object param)
    {
      if (!(param is DownloadParam dp))
        return;
      if (error)
      {
        Debuger.Log((object) ("download error:" + (object) error));
        ++dp.tryCount;
        this.DownloadPackage(dp);
      }
      else if (File.Exists(filename))
      {
        HotUpdate.UnPackage(filename, this.m_LocalResourceDir);
        if (this.m_UpdateIndex < this.m_RemoteMetaFile.PackageList.Count)
          this.m_LocalMetaFile.UpdatePackage(this.m_RemoteMetaFile.PackageList[this.m_UpdateIndex]);
        this.m_LocalMetaFile.Save(this.m_LocalPackageDir + UpdateMetaFile.LocMetaFileName);
        this.m_LocalMetaFile.TotalSize += dp.size;
        this.DownloadPackage();
      }
      else
      {
        this.m_UpdateState = EUpdateState.EUpdateFinish;
        this.m_UpdateResult = EUpdateResult.EPackageError;
      }
    }

    public override float GetUpdateProgress() => this.m_CurrentProgress;
  }
}
