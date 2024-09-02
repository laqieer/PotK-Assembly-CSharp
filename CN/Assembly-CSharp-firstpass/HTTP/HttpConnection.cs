// Decompiled with JetBrains decompiler
// Type: HTTP.HttpConnection
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.IO;
using System.Net.Sockets;

#nullable disable
namespace HTTP
{
  public class HttpConnection : IDisposable
  {
    public static string proxyURI;
    public static string cachedHost;
    private static TcpClient cachedClient;
    public string host;
    public int port;
    public TcpClient client;
    public Stream stream;

    public void Connect()
    {
      if (HttpConnection.cachedHost == this.host)
      {
        if (HttpConnection.cachedClient == null)
        {
          HttpConnection.cachedClient = new TcpClient();
          HttpConnection.cachedClient.Connect(this.host, this.port);
        }
        this.client = HttpConnection.cachedClient;
      }
      else
      {
        this.client = new TcpClient();
        if (!string.IsNullOrEmpty(HttpConnection.proxyURI))
        {
          string[] strArray = HttpConnection.proxyURI.Split(':');
          this.host = strArray[0];
          this.port = int.Parse(strArray[1]);
        }
        this.client.Connect(this.host, this.port);
      }
    }

    public void Dispose()
    {
      if (HttpConnection.cachedHost == this.host)
        return;
      this.stream.Dispose();
      this.client.Close();
      this.client.Client.Close();
    }

    public static void DisposeCache()
    {
      if (HttpConnection.cachedClient == null)
        return;
      HttpConnection.cachedClient.Close();
      if (HttpConnection.cachedClient.Client != null)
        HttpConnection.cachedClient.Client.Close();
      HttpConnection.cachedClient = (TcpClient) null;
    }
  }
}
