// Decompiled with JetBrains decompiler
// Type: Net.UnityTcpClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;
using System.Net.Sockets;

#nullable disable
namespace Net
{
  public class UnityTcpClient
  {
    private TcpClient client;
    private string hostname;
    private int port;

    public UnityTcpClient()
    {
      this.client = new TcpClient();
      this.ConnectTimeout = -1;
      this.ReceiveTimeout = -1;
      this.SendTimeout = -1;
    }

    public void Close() => this.client.Close();

    public bool Connected => this.client.Connected;

    public int ConnectTimeout { get; set; }

    public int ReceiveTimeout { get; set; }

    public int SendTimeout { get; set; }

    private NetworkStream GetStreamByWorker()
    {
      lock (this)
        return this.client.GetStream();
    }

    [DebuggerHidden]
    private IEnumerator RunWithTimeout<T>(
      T result,
      int timeout,
      Promise<T> promise,
      Action<object, T> action,
      Action timeoutAction = null)
      where T : class
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UnityTcpClient.\u003CRunWithTimeout\u003Ec__IteratorA97<T>()
      {
        timeout = timeout,
        action = action,
        result = result,
        timeoutAction = timeoutAction,
        promise = promise,
        \u003C\u0024\u003Etimeout = timeout,
        \u003C\u0024\u003Eaction = action,
        \u003C\u0024\u003Eresult = result,
        \u003C\u0024\u003EtimeoutAction = timeoutAction,
        \u003C\u0024\u003Epromise = promise
      };
    }

    public Future<None> Connect(string hostname, int port)
    {
      return new Future<None>((Func<Promise<None>, IEnumerator>) (promise => this.ConnectE(hostname, port, promise)));
    }

    private IEnumerator ConnectE(string hostname, int port, Promise<None> promise)
    {
      return this.RunWithTimeout<None>(None.Value, this.ConnectTimeout, promise, (Action<object, None>) ((sync, result) => this.client.Connect(hostname, port)), (Action) (() => this.client.Close()));
    }

    public Future<UnityTcpClient.ReadResult> Read(int bytes)
    {
      return new Future<UnityTcpClient.ReadResult>((Func<Promise<UnityTcpClient.ReadResult>, IEnumerator>) (promise => this.ReadE(bytes, promise)));
    }

    private IEnumerator ReadE(int bytes, Promise<UnityTcpClient.ReadResult> promise)
    {
      return this.RunWithTimeout<UnityTcpClient.ReadResult>(new UnityTcpClient.ReadResult(), this.ReceiveTimeout, promise, (Action<object, UnityTcpClient.ReadResult>) ((sync, result) =>
      {
        byte[] buffer = new byte[bytes];
        NetworkStream streamByWorker = this.GetStreamByWorker();
        int offset = 0;
        while (offset != bytes)
          offset += streamByWorker.Read(buffer, offset, bytes - offset);
        lock (sync)
          result.Buffer = buffer;
      }));
    }

    public Future<None> Write(byte[] buf)
    {
      return new Future<None>((Func<Promise<None>, IEnumerator>) (promise => this.WriteE(buf, promise)));
    }

    private IEnumerator WriteE(byte[] buf, Promise<None> promise)
    {
      return this.RunWithTimeout<None>(None.Value, this.SendTimeout, promise, (Action<object, None>) ((sync, result) => this.GetStreamByWorker().Write(buf, 0, buf.Length)));
    }

    public class ReadResult
    {
      public byte[] Buffer;
    }
  }
}
