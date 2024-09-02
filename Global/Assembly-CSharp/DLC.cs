// Decompiled with JetBrains decompiler
// Type: DLC
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using Ionic.Zlib;
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
  private Dictionary<string, DLC.Data> dataDic = new Dictionary<string, DLC.Data>();
  private string error;
  private DLC.Consumer[] consumers = new DLC.Consumer[0];

  public DLC(ResourceInfo resourceInfo, string[] paths, bool fileCheckDisable = false)
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
                Exists = !fileCheckDisable && CachedFile.Exists(DLC.ResourceDirectory + assetBundle),
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
                Exists = !fileCheckDisable && CachedFile.Exists(DLC.ResourceDirectory + fileName),
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

  public static string ResourceDirectory => Application.persistentDataPath + "/cache/";

  public static string UrlBase => ServerSelector.DlcUrl;

  public int GetDownloadedSize(bool includesExistFile = false)
  {
    return (!includesExistFile ? 0 : this.GetDownloadSize(true) - this.GetDownloadSize()) + ((IEnumerable<DLC.Consumer>) this.consumers).Sum<DLC.Consumer>((Func<DLC.Consumer, int>) (x => x.Downloaded));
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
    return (IEnumerator) new DLC.\u003CStart\u003Ec__Iterator93F()
    {
      mono = mono,
      \u003C\u0024\u003Emono = mono,
      \u003C\u003Ef__this = this
    };
  }

  private class WWWFile : IDisposable
  {
    private const int BUFFER_SIZE = 1048576;
    private string path;
    private bool succeeded;
    private string error;
    private int contentLength;
    private bool zipped;
    private Thread thread;
    protected static byte[] EOL = new byte[2]
    {
      (byte) 13,
      (byte) 10
    };

    public WWWFile(string url, string path)
    {
      DLC.WWWFile wwwFile = this;
      this.path = path;
      this.thread = new Thread((ThreadStart) (() =>
      {
        try
        {
          Uri uri = new Uri(url);
          TcpClient tcpClient = new TcpClient();
          tcpClient.Connect(uri.Host, uri.Port);
          NetworkStream stream = tcpClient.GetStream();
          SslStream sslStream = new SslStream((Stream) stream, false, new RemoteCertificateValidationCallback(DLC.WWWFile.ValidateServerCertificate));
          sslStream.AuthenticateAsClient(uri.Host);
          stream.WriteTimeout = 10000;
          stream.ReadTimeout = 10000;
          wwwFile.WriteHeaderTo((Stream) sslStream, uri);
          wwwFile.ReadFromStream((Stream) sslStream);
          using (FileStream fileStream = File.Create(path + ".tmp"))
          {
            if (wwwFile.zipped)
            {
              using (GZipStream gzipStream = new GZipStream((Stream) sslStream, (CompressionMode) 1))
              {
                byte[] array = new byte[1024];
                int count = -1;
                while (count != 0)
                {
                  count = gzipStream.Read(array, 0, array.Length);
                  fileStream.Write(array, 0, count);
                }
              }
            }
            else
            {
              int contentLength = wwwFile.contentLength;
              byte[] numArray = new byte[contentLength >= 1048576 ? 1048576 : contentLength];
              int num;
              for (; contentLength > 0; contentLength -= num)
              {
                num = 0;
                while (num < 1048576 && num < contentLength)
                  num += sslStream.Read(numArray, num, Math.Min(numArray.Length - num, contentLength));
                fileStream.Write(numArray, 0, num);
              }
            }
          }
          File.Move(path + ".tmp", path);
          wwwFile.succeeded = true;
        }
        catch (Exception ex)
        {
          wwwFile.error = "error occured: {0}".F((object) ex);
        }
      }));
      this.thread.IsBackground = true;
      this.thread.Start();
    }

    public bool Succeeded => this.succeeded;

    public string Error => this.error;

    public bool Zipped => this.zipped;

    private void WriteHeaderTo(Stream socket, Uri uri)
    {
      BinaryWriter binaryWriter = new BinaryWriter(socket);
      binaryWriter.Write(Encoding.ASCII.GetBytes("GET " + uri.PathAndQuery + " HTTP/1.1"));
      binaryWriter.Write(DLC.WWWFile.EOL);
      binaryWriter.Write(Encoding.ASCII.GetBytes("Accept: */*"));
      binaryWriter.Write(DLC.WWWFile.EOL);
      string str = uri.Host;
      if (uri.Port != 80 && uri.Port != 443)
        str = str + ":" + uri.Port.ToString();
      binaryWriter.Write(Encoding.ASCII.GetBytes("Host: " + str));
      binaryWriter.Write(DLC.WWWFile.EOL);
      binaryWriter.Write(Encoding.ASCII.GetBytes("Accept-Encoding: gzip"));
      binaryWriter.Write(DLC.WWWFile.EOL);
      binaryWriter.Write(DLC.WWWFile.EOL);
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
          if ((int) num2 != (int) DLC.WWWFile.EOL[1])
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
        string[] strArray = this.ReadKeyValue(inputStream);
        if (strArray != null)
        {
          switch (strArray[0].ToLower())
          {
            case "content-length":
              this.contentLength = int.Parse(strArray[1]);
              continue;
            case "content-encoding":
              this.zipped = string.Compare(strArray[1], "gzip", true) == 0;
              continue;
            default:
              continue;
          }
        }
        else
          break;
      }
    }

    private void ReadFromStream(Stream inputStream)
    {
      string[] strArray = inputStream != null ? this.ReadLine(inputStream).Split(' ') : throw new IOException("Cannot read from server, server probably dropped the connection.");
      int result = -1;
      if (strArray.Length <= 0 || !int.TryParse(strArray[1], out result))
        throw new IOException("Bad Status Code, server probably dropped the connection.");
      int num = result;
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
    public IEnumerator Wait()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DLC.WWWFile.\u003CWait\u003Ec__Iterator940()
      {
        \u003C\u003Ef__this = this
      };
    }

    public void Dispose()
    {
      if (this.succeeded)
        return;
      try
      {
        File.Delete(this.path);
      }
      catch (Exception ex)
      {
      }
    }
  }

  private class Data
  {
    public string Path;
    public string Name;
    public bool Exists;
    public bool AssetBundle;
    public int DownloadSize;
    public int StoreSize;
    public bool Uncompress;
    public bool Completed;
    public bool Downloading;

    public string Url
    {
      get => this.AssetBundle ? DLC.UrlBase + "ab/" + this.Name : DLC.UrlBase + "sa/" + this.Name;
    }

    public string StorePath => DLC.ResourceDirectory + this.Name;
  }

  private class Consumer : IDisposable
  {
    private bool interrupted;
    private Dictionary<string, DLC.Data> dataDic;
    private int maxDownloadSize;
    private string error;
    private int downloaded;
    private int stored;

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

    private DLC.Data GetNext()
    {
      int num = 0;
      foreach (KeyValuePair<string, DLC.Data> keyValuePair in this.dataDic)
      {
        if (!keyValuePair.Value.Completed && keyValuePair.Value.Downloading)
          num += keyValuePair.Value.DownloadSize;
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

    public int Downloaded => this.downloaded;

    public int Stored => this.stored;

    public bool Completed => this.dataDic.Count == 0;

    public void Restart() => this.error = (string) null;

    [DebuggerHidden]
    private IEnumerator Run_()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DLC.Consumer.\u003CRun_\u003Ec__Iterator941()
      {
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator Run()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DLC.Consumer.\u003CRun\u003Ec__Iterator942()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
