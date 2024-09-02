// Decompiled with JetBrains decompiler
// Type: HTTP.Request
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using UnityEngine;

#nullable disable
namespace HTTP
{
  public class Request : BaseHTTP
  {
    public bool isDone;
    public Exception exception;
    public int maximumRedirects = 8;
    public bool acceptGzip = true;
    public bool useCache;
    public readonly Headers headers = new Headers();
    public bool enableCookies = true;
    public float timeout;
    private byte[] bytes;
    private string method;
    private string protocol = "HTTP/1.1";
    private static Dictionary<string, string> etags = new Dictionary<string, string>();
    private Action<Request> OnDone;

    public Request(string method, string uri)
    {
      this.method = method;
      this.uri = new Uri(uri);
    }

    public Request(string method, string uri, bool useCache)
    {
      this.method = method;
      this.uri = new Uri(uri);
      this.useCache = useCache;
    }

    public Request(string uri, WWWForm form)
    {
      this.method = "POST";
      this.uri = new Uri(uri);
      this.bytes = form.data;
      foreach (string key in form.headers.Keys)
        this.headers.Set(key, form.headers[key]);
    }

    public Request(string method, string uri, byte[] bytes)
    {
      this.method = method;
      this.uri = new Uri(uri);
      this.bytes = bytes;
    }

    public Response response { get; private set; }

    public Uri uri { get; private set; }

    public HttpConnection upgradedConnection { get; private set; }

    public float Progress => this.response == null ? 0.0f : this.response.progress;

    public string Text
    {
      set => this.bytes = value != null ? Encoding.UTF8.GetBytes(value) : (byte[]) null;
    }

    public Coroutine Send(Action<Request> OnDone)
    {
      this.OnDone = OnDone;
      return this.Send();
    }

    public Coroutine Send()
    {
      this.BeginSending();
      return UniWeb.Instance.StartCoroutine(this._Wait());
    }

    private static bool ValidateServerCertificate(
      object sender,
      X509Certificate certificate,
      X509Chain chain,
      SslPolicyErrors sslPolicyErrors)
    {
      return true;
    }

    private HttpConnection CreateConnection(string host, int port, bool useSsl)
    {
      HttpConnection connection = new HttpConnection()
      {
        host = host,
        port = port
      };
      connection.Connect();
      if (useSsl)
      {
        connection.stream = (Stream) new SslStream((Stream) connection.client.GetStream(), false, new RemoteCertificateValidationCallback(Request.ValidateServerCertificate));
        (connection.stream as SslStream).AuthenticateAsClient(this.uri.Host);
      }
      else
        connection.stream = (Stream) connection.client.GetStream();
      return connection;
    }

    [DebuggerHidden]
    private IEnumerator Timeout()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Request.\u003CTimeout\u003Ec__IteratorB()
      {
        \u003C\u003Ef__this = this
      };
    }

    private void AddHeadersToRequest()
    {
      if (this.useCache)
      {
        string empty = string.Empty;
        if (Request.etags.TryGetValue(this.uri.AbsoluteUri, out empty))
          this.headers.Set("If-None-Match", empty);
      }
      string str = this.uri.Host;
      if (this.uri.Port != 80 && this.uri.Port != 443)
        str = str + ":" + this.uri.Port.ToString();
      this.headers.Set("Host", str);
      if (!this.acceptGzip)
        return;
      this.headers.Set("Accept-Encoding", "gzip");
    }

    private void BeginSending()
    {
      if ((double) this.timeout > 0.0)
        UniWeb.Instance.StartCoroutine(this.Timeout());
      this.isDone = false;
      ThreadPool.QueueUserWorkItem((WaitCallback) (t =>
      {
        try
        {
          int num = 0;
          HttpConnection httpConnection = (HttpConnection) null;
          while (num < this.maximumRedirects)
          {
            this.AddHeadersToRequest();
            httpConnection = this.CreateConnection(this.uri.Host, this.uri.Port, this.uri.Scheme.ToLower() == "https");
            this.WriteToStream(httpConnection.stream);
            this.response = new Response(this);
            this.response.ReadFromStream(httpConnection.stream);
            int status = this.response.status;
            switch (status)
            {
              case 301:
              case 302:
                this.method = "GET";
                this.uri = new Uri(this.response.headers.Get("Location"));
                ++num;
                continue;
              case 304:
                goto label_7;
              case 307:
                this.uri = new Uri(this.response.headers.Get("Location"));
                ++num;
                continue;
              default:
                if (status == 101)
                {
                  this.upgradedConnection = httpConnection;
                  goto label_7;
                }
                else
                  goto label_7;
            }
          }
label_7:
          if (this.upgradedConnection == null)
            httpConnection.Dispose();
          if (this.useCache)
          {
            if (this.response != null)
            {
              string str = this.response.headers.Get("etag");
              if (str.Length > 0)
                Request.etags[this.uri.AbsoluteUri] = str;
            }
          }
        }
        catch (Exception ex)
        {
          this.exception = ex;
          this.response = (Response) null;
        }
        this.isDone = true;
      }));
    }

    private void WriteToStream(Stream outputStream)
    {
      BinaryWriter stream = new BinaryWriter(outputStream);
      bool flag = false;
      stream.Write(Encoding.ASCII.GetBytes(this.method.ToUpper() + " " + this.uri.PathAndQuery + " " + this.protocol));
      stream.Write(BaseHTTP.EOL);
      if (this.uri.UserInfo != null && this.uri.UserInfo != string.Empty && !this.headers.Contains("Authorization"))
        this.headers.Set("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(this.uri.UserInfo)));
      if (!this.headers.Contains("Accept"))
        this.headers.Add("Accept", "*/*");
      if (this.bytes != null && this.bytes.Length > 0)
      {
        this.headers.Set("Content-Length", this.bytes.Length.ToString());
        flag = true;
      }
      else
        this.headers.Pop("Content-Length");
      this.headers.Write(stream);
      stream.Write(BaseHTTP.EOL);
      if (!flag)
        return;
      stream.Write(this.bytes);
    }

    [DebuggerHidden]
    private IEnumerator _Wait()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Request.\u003C_Wait\u003Ec__IteratorC()
      {
        \u003C\u003Ef__this = this
      };
    }

    private static void AOTStrippingReferences()
    {
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
    }
  }
}
