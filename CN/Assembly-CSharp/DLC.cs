// Decompiled with JetBrains decompiler
// Type: DLC
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using UniLinq;
using UnityEngine;

#nullable disable
public class DLC
{
  private const int CONSUMER_COUNT = 5;
  public const string RES_TYPE_AB = "ab";
  public const string RES_TYPE_SA = "sa";
  public const string RES_TYPE_DEF = "df";
  private Dictionary<string, DLC.Data> dataDic = new Dictionary<string, DLC.Data>();
  private string error;
  private DLC.Consumer[] consumers = new DLC.Consumer[0];
  private IEnumerator coroutine;

  public DLC(ResourceInfo resourceInfo, string[] paths, bool fileCheckDisable = false, bool fromLocal = false)
  {
    using (new ScopeTimer("DLC.ctor"))
    {
      foreach (string str in new HashSet<string>((IEnumerable<string>) paths).ToArray<string>())
      {
        int n = ResourceInfo.SearchResourceInfo(str, resourceInfo);
        if (n >= 0)
        {
          ResourceInfo.Resource resource = resourceInfo[n];
          switch ((ResourceInfo.INFO_PATH_TYPE) resource._value._path_type)
          {
            case ResourceInfo.INFO_PATH_TYPE.ASSET_BUNDLE:
              string assetBundle = resource._value._asset_bundle;
              this.dataDic[str] = new DLC.Data()
              {
                Path = str,
                Name = assetBundle,
                isLocal = fromLocal,
                Exists = !fileCheckDisable && CachedFile.Exists(DLC.ResourceFullPath(assetBundle)),
                AssetBundle = true,
                DownloadSize = (int) resource._value._download_size,
                StoreSize = (int) resource._value._store_size,
                Uncompress = false
              };
              continue;
            case ResourceInfo.INFO_PATH_TYPE.STREAMING:
              string fileName = resource._value._file_name;
              this.dataDic[str] = new DLC.Data()
              {
                Path = str,
                Name = fileName,
                isLocal = fromLocal,
                Exists = !fileCheckDisable && CachedFile.Exists(DLC.ResourceFullPath(fileName)),
                AssetBundle = false,
                DownloadSize = (int) resource._value._download_size,
                StoreSize = (int) resource._value._store_size,
                Uncompress = false
              };
              continue;
            default:
              continue;
          }
        }
      }
    }
  }

  public static string ResourceDirectory(string type)
  {
    switch (type)
    {
      case "ab":
        return Application.persistentDataPath + "/cache/ab/";
      case "sa":
        return Application.persistentDataPath + "/cache/sa/";
      default:
        return Application.persistentDataPath + "/cache/";
    }
  }

  public static string ResourceFullPath(string fileName)
  {
    if (fileName.EndsWith(".unity3d"))
      return DLC.ResourceDirectory("ab") + fileName;
    return !fileName.Contains(".") ? DLC.ResourceDirectory("sa") + fileName : DLC.ResourceDirectory("df") + fileName;
  }

  public static string ResourceTempDirectory => Application.temporaryCachePath + "/";

  public static bool isFolderName(string s) => s == "ab" || s == "sa" || s == "cache";

  public static string UrlBase => ServerSelector.DlcUrl;

  public int GetDownloadedSize(bool includesExistFile = false)
  {
    return (!includesExistFile ? 0 : this.GetDownloadSize(true) - this.GetDownloadSize()) + ((IEnumerable<DLC.Consumer>) this.consumers).Sum<DLC.Consumer>((Func<DLC.Consumer, int>) (x => x.Downloaded)) + this.GetDownloadingLoadedSize();
  }

  public int GetDownloadingLoadedSize()
  {
    return ((IEnumerable<DLC.Consumer>) this.consumers).Sum<DLC.Consumer>((Func<DLC.Consumer, int>) (x => x.DownlodingLoadedSize()));
  }

  public bool DownloadRequired => this.GetDownloadSize() != 0;

  public int GetDownloadSize(bool includesExistFile = false)
  {
    return this.dataDic.Where<KeyValuePair<string, DLC.Data>>((Func<KeyValuePair<string, DLC.Data>, bool>) (x => includesExistFile || !x.Value.Exists)).Sum<KeyValuePair<string, DLC.Data>>((Func<KeyValuePair<string, DLC.Data>, int>) (x => x.Value.DownloadSize));
  }

  public int GetStoredSize(bool includesExistFile = false)
  {
    return (!includesExistFile ? 0 : this.GetStoreSize(true) - this.GetStoreSize()) + ((IEnumerable<DLC.Consumer>) this.consumers).Sum<DLC.Consumer>((Func<DLC.Consumer, int>) (x => x.Stored));
  }

  public int GetStoreSize(bool includesExistFile = false)
  {
    return this.dataDic.Where<KeyValuePair<string, DLC.Data>>((Func<KeyValuePair<string, DLC.Data>, bool>) (x => includesExistFile || !x.Value.Exists)).Sum<KeyValuePair<string, DLC.Data>>((Func<KeyValuePair<string, DLC.Data>, int>) (x => x.Value.StoreSize));
  }

  public string Error => this.error;

  public long GetRequireSize() => (long) ((double) this.GetStoreSize() * 1.2);

  [DebuggerHidden]
  public IEnumerator Start(MonoBehaviour mono)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DLC.\u003CStart\u003Ec__IteratorADC()
    {
      mono = mono,
      \u003C\u0024\u003Emono = mono,
      \u003C\u003Ef__this = this
    };
  }

  private abstract class WWWFile : IDisposable
  {
    protected string tmPath;
    protected string dsPath;
    protected bool succeeded;
    protected string error;
    protected string mUrl;
    protected int downloadSize;

    public bool Succeeded => this.succeeded;

    public string Error => this.error;

    public abstract void Dispose();

    public abstract int getDownloadingDownloadedSize();

    public abstract IEnumerator Wait();
  }

  private class WWWWrapper : DLC.WWWFile
  {
    private WWW www;
    private byte[] mBytes;
    private bool _isSetDone;
    public bool isForceDispose;

    public WWWWrapper(string url, string path, int downloadSize)
    {
      this.dsPath = path;
      this.mUrl = url;
      this.downloadSize = downloadSize;
      this.www = new WWW(url);
      this.isForceDispose = false;
    }

    [DebuggerHidden]
    public override IEnumerator Wait()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DLC.WWWWrapper.\u003CWait\u003Ec__IteratorADD()
      {
        \u003C\u003Ef__this = this
      };
    }

    public void forceDispose() => this.isForceDispose = true;

    public bool isDone() => this.www != null && this.www.isDone;

    public float progress() => this.www != null ? this.www.progress : 0.0f;

    public override void Dispose()
    {
      if (this.www == null)
        return;
      this.www.Dispose();
      this.www = (WWW) null;
    }

    public override int getDownloadingDownloadedSize()
    {
      return (int) ((double) this.progress() * (double) this.downloadSize);
    }
  }

  private class WWWStreamFile : DLC.WWWFile
  {
    private const int BUFFER_SIZE = 1048576;
    private int contentLength;
    private Thread thread;
    protected static byte[] EOL = new byte[2]
    {
      (byte) 13,
      (byte) 10
    };
    private int downloadingDownloadedSize;

    public WWWStreamFile(string url, string ds_path, string temp_path, int size)
    {
      DLC.WWWStreamFile wwwStreamFile = this;
      this.tmPath = temp_path;
      this.dsPath = ds_path;
      this.downloadSize = size;
      this.downloadingDownloadedSize = 0;
      this.thread = new Thread((ThreadStart) (() =>
      {
        try
        {
          try
          {
            if (File.Exists(wwwStreamFile.tmPath))
              File.Delete(wwwStreamFile.tmPath);
          }
          catch (Exception ex)
          {
          }
          try
          {
            if (File.Exists(wwwStreamFile.tmPath))
              File.Delete(wwwStreamFile.tmPath);
          }
          catch (Exception ex)
          {
          }
          try
          {
            if (File.Exists(wwwStreamFile.dsPath))
              File.Delete(wwwStreamFile.dsPath);
          }
          catch (Exception ex)
          {
          }
          try
          {
            if (File.Exists(wwwStreamFile.dsPath))
              File.Delete(wwwStreamFile.dsPath);
          }
          catch (Exception ex)
          {
          }
          Uri uri = new Uri(url);
          using (TcpClient tcpClient = new TcpClient())
          {
            tcpClient.Connect(uri.Host, uri.Port);
            NetworkStream stream1 = tcpClient.GetStream();
            stream1.WriteTimeout = 10000;
            stream1.ReadTimeout = 10000;
            Stream stream2 = (Stream) stream1;
            if (uri.Scheme.ToLower() == "https")
            {
              SslStream sslStream = new SslStream((Stream) stream1, false, new RemoteCertificateValidationCallback(DLC.WWWStreamFile.ValidateServerCertificate));
              sslStream.AuthenticateAsClient(uri.Host);
              stream2 = (Stream) sslStream;
            }
            using (Stream stream3 = stream2)
            {
              wwwStreamFile.WriteHeaderTo(stream3, uri);
              wwwStreamFile.ReadFromStream(stream3);
              using (FileStream fileStream = File.Create(wwwStreamFile.tmPath))
              {
                int contentLength = wwwStreamFile.contentLength;
                wwwStreamFile.downloadingDownloadedSize = 0;
                byte[] numArray = new byte[contentLength >= 1048576 ? 1048576 : contentLength];
                int num1;
                for (; contentLength > 0; contentLength -= num1)
                {
                  num1 = 0;
                  while (num1 < 1048576 && num1 < contentLength)
                  {
                    int num2 = stream3.Read(numArray, num1, Math.Min(numArray.Length - num1, contentLength));
                    num1 += num2;
                    wwwStreamFile.downloadingDownloadedSize += num2;
                  }
                  fileStream.Write(numArray, 0, num1);
                }
              }
            }
            File.Move(wwwStreamFile.tmPath, wwwStreamFile.dsPath);
            wwwStreamFile.succeeded = true;
          }
        }
        catch (Exception ex)
        {
          wwwStreamFile.error = "error occured: {0}".F((object) ex);
        }
      }));
      this.thread.IsBackground = true;
      this.thread.Start();
    }

    private void WriteHeaderTo(Stream socket, Uri uri)
    {
      BinaryWriter binaryWriter = new BinaryWriter(socket);
      binaryWriter.Write(Encoding.ASCII.GetBytes("GET " + uri.PathAndQuery + " HTTP/1.0"));
      binaryWriter.Write(DLC.WWWStreamFile.EOL);
      binaryWriter.Write(Encoding.ASCII.GetBytes("Accept: */*"));
      binaryWriter.Write(DLC.WWWStreamFile.EOL);
      string str = uri.Host;
      if (uri.Port != 80 && uri.Port != 443)
        str = str + ":" + uri.Port.ToString();
      binaryWriter.Write(Encoding.ASCII.GetBytes("Host: " + str));
      binaryWriter.Write(DLC.WWWStreamFile.EOL);
      binaryWriter.Write(DLC.WWWStreamFile.EOL);
    }

    private string ReadLine(Stream stream)
    {
      List<byte> byteList = new List<byte>();
      while (true)
      {
        int num1;
        try
        {
          num1 = stream.ReadByte();
        }
        catch (IOException ex)
        {
          throw new IOException("Terminated Stream");
        }
        if (num1 != -1)
        {
          byte num2 = (byte) num1;
          if ((int) num2 != (int) DLC.WWWStreamFile.EOL[1])
            byteList.Add(num2);
          else
            goto label_8;
        }
        else
          break;
      }
      throw new IOException("Unterminated Stream");
label_8:
      return Encoding.ASCII.GetString(byteList.ToArray()).Trim();
    }

    private string[] ReadKeyValue(Stream stream)
    {
      string str = this.ReadLine(stream);
      if (str == string.Empty)
        return (string[]) null;
      int length = str.IndexOf(':');
      if (length == -1)
        return (string[]) null;
      return new string[2]
      {
        str.Substring(0, length).Trim(),
        str.Substring(length + 1).Trim()
      };
    }

    private void CollectHeaders(Stream inputStream)
    {
      while (true)
      {
        string[] strArray;
        do
        {
          strArray = this.ReadKeyValue(inputStream);
          if (strArray == null)
            goto label_3;
        }
        while (!(strArray[0].ToLower() == "content-length"));
        this.contentLength = int.Parse(strArray[1]);
      }
label_3:;
    }

    private void ReadFromStream(Stream inputStream)
    {
      string[] strArray = inputStream != null ? this.ReadLine(inputStream).Split(' ') : throw new IOException("Cannot read from server, server probably dropped the connection.");
      int result = -1;
      if (strArray.Length <= 0 || !int.TryParse(strArray[1], out result))
        throw new IOException("Bad Status Code, server probably dropped the connection.");
      int num = result;
      string.Join(" ", strArray, 2, strArray.Length - 2);
      if (num / 100 != 2)
        throw new IOException("bad status: {0}".F((object) num));
      this.CollectHeaders(inputStream);
    }

    private static bool ValidateServerCertificate(
      object sender,
      X509Certificate certificate,
      X509Chain chain,
      SslPolicyErrors sslPolicyErrors)
    {
      return true;
    }

    [DebuggerHidden]
    public override IEnumerator Wait()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DLC.WWWStreamFile.\u003CWait\u003Ec__IteratorADE()
      {
        \u003C\u003Ef__this = this
      };
    }

    public override void Dispose()
    {
      if (this.succeeded)
        return;
      try
      {
        File.Delete(this.tmPath);
        File.Delete(this.dsPath);
      }
      catch (Exception ex)
      {
      }
    }

    public override int getDownloadingDownloadedSize() => this.downloadingDownloadedSize;
  }

  private class Data
  {
    public string Path;
    public string Name;
    public bool Exists;
    public bool AssetBundle;
    public DLC.WWWFile wwwF;
    private int preProgress;
    private float _preTime;
    public string Ext;
    public bool isLocal;
    public int DownloadSize;
    public int StoreSize;
    public bool Uncompress;
    public bool Completed;
    public bool Downloading;

    public string Url
    {
      get => this.AssetBundle ? DLC.UrlBase + "ab/" + this.Name : DLC.UrlBase + "sa/" + this.Name;
    }

    public string StorePath => DLC.ResourceFullPath(this.Name);

    public string StoreTempPath => DLC.ResourceTempDirectory + this.Name + ".tmp";

    public void Dispose()
    {
      if (this.wwwF == null)
        return;
      this.wwwF.Dispose();
    }

    public int downloadingLoadedSize()
    {
      int num = 0;
      if (this.wwwF != null && !this.Completed && this.Downloading)
        num = this.wwwF.getDownloadingDownloadedSize();
      return num;
    }

    public void reset2Download()
    {
      this.wwwF = (DLC.WWWFile) null;
      this.Downloading = false;
      this.preProgress = 0;
      this._preTime = 0.0f;
    }

    public float updateTime()
    {
      if (this.wwwF != null)
      {
        int downloadingDownloadedSize = this.wwwF.getDownloadingDownloadedSize();
        if (downloadingDownloadedSize != this.preProgress || downloadingDownloadedSize <= 0)
        {
          this.preProgress = downloadingDownloadedSize;
          this._preTime = Time.time;
        }
      }
      else
      {
        this.preProgress = 0;
        this._preTime = Time.time;
      }
      return this._preTime;
    }

    public bool isTimeout() => false;
  }

  private class Consumer : IDisposable
  {
    public static List<string> testList = new List<string>();
    private bool interrupted;
    private Dictionary<string, DLC.Data> dataDic;
    private int maxDownloadSize;
    private int toNullCount;
    private string error;
    private int downloaded;
    private int downloadingLoadedSize;
    private int stored;
    public DLC.Data loadingData;
    public IEnumerator coroutine;

    public Consumer(Dictionary<string, DLC.Data> dataDic)
    {
      this.dataDic = dataDic;
      this.maxDownloadSize = !this.dataDic.Any<KeyValuePair<string, DLC.Data>>() ? 0 : this.dataDic.Select<KeyValuePair<string, DLC.Data>, int>((Func<KeyValuePair<string, DLC.Data>, int>) (x => x.Value.DownloadSize)).Max();
      if (this.maxDownloadSize >= 5242880)
        return;
      this.maxDownloadSize = 5242880;
    }

    public void Dispose()
    {
      this.loadingData = (DLC.Data) null;
      this.coroutine = (IEnumerator) null;
    }

    private void RemoveCompletedData()
    {
      List<string> stringList = new List<string>();
      foreach (KeyValuePair<string, DLC.Data> keyValuePair in this.dataDic)
      {
        if (keyValuePair.Value.Completed)
          stringList.Add(keyValuePair.Key);
      }
      foreach (string key in stringList)
        this.dataDic.Remove(key);
    }

    private void resetDieData()
    {
      Debug.LogWarning((object) nameof (resetDieData));
      List<DLC.Data> dataList = new List<DLC.Data>();
      foreach (KeyValuePair<string, DLC.Data> keyValuePair in this.dataDic)
      {
        if (!keyValuePair.Value.Completed && keyValuePair.Value.Downloading)
        {
          if (keyValuePair.Value.isTimeout())
            dataList.Add(keyValuePair.Value);
          foreach (DLC.Data data in dataList)
            data.reset2Download();
        }
      }
    }

    private DLC.Data GetNext()
    {
      int num = 0;
      this.downloadingLoadedSize = 0;
      foreach (KeyValuePair<string, DLC.Data> keyValuePair in this.dataDic)
      {
        if (!keyValuePair.Value.Completed && keyValuePair.Value.Downloading)
        {
          num += keyValuePair.Value.DownloadSize;
          this.downloadingLoadedSize += keyValuePair.Value.downloadingLoadedSize();
        }
      }
      if (num >= this.maxDownloadSize)
        return (DLC.Data) null;
      foreach (KeyValuePair<string, DLC.Data> keyValuePair in this.dataDic)
      {
        if (!keyValuePair.Value.Completed && !keyValuePair.Value.Downloading)
          return keyValuePair.Value;
      }
      return (DLC.Data) null;
    }

    public string Error => this.error;

    public int Downloaded
    {
      get => this.downloaded;
      set => this.downloaded = value;
    }

    public int DownlodingLoadedSize()
    {
      return this.loadingData != null && this.loadingData.Downloading && !this.loadingData.Completed ? this.loadingData.downloadingLoadedSize() : 0;
    }

    public int Stored => this.stored;

    public bool Completed => this.dataDic.Count == 0;

    public void Restart() => this.error = (string) null;

    private DLC.WWWFile createWWFile(DLC.Data data)
    {
      return data.isLocal ? (DLC.WWWFile) new DLC.WWWWrapper(data.Url, data.StorePath, data.DownloadSize) : (DLC.WWWFile) new DLC.WWWStreamFile(data.Url, data.StorePath, data.StoreTempPath, data.DownloadSize);
    }

    [DebuggerHidden]
    private IEnumerator Run_()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DLC.Consumer.\u003CRun_\u003Ec__IteratorADF()
      {
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator Run()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DLC.Consumer.\u003CRun\u003Ec__IteratorAE0()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
