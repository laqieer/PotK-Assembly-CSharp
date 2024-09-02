// Decompiled with JetBrains decompiler
// Type: Net.Peer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using GameCore.Serialization;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace Net
{
  public class Peer
  {
    private const int ERROR_TYPE = 255;
    private UnityTcpClient client;
    private int requestId;

    public Peer()
    {
      this.Serializer = Peer.MakeDefaultSerializer();
      this.client = new UnityTcpClient();
    }

    public static CrossSerializer MakeDefaultSerializer()
    {
      CrossSerializer crossSerializer = BinaryFormatter.MakeSerializer();
      Action<TypeInfo> modifyTypeInfo = (Action<TypeInfo>) null;
      modifyTypeInfo = (Action<TypeInfo>) (ti =>
      {
        if (ti.assembly.name == "GameCore")
          ti.assembly.name = "Assembly-CSharp";
        if (ti.name_space == "System" && ti.name == "Tuple")
          ti.assembly.name = "Assembly-CSharp";
        foreach (TypeInfo typeArgument in ti.type_arguments)
          modifyTypeInfo(typeArgument);
      });
      crossSerializer.TypeBinder = (Func<TypeInfo, Type>) (typeInfo =>
      {
        TypeInfo typeInfo1 = typeInfo.Clone();
        modifyTypeInfo(typeInfo1);
        return typeInfo1.Type;
      });
      return crossSerializer;
    }

    public CrossSerializer Serializer { get; set; }

    public Future<None> Connect(string hostname, int port) => this.client.Connect(hostname, port);

    public bool Connected => this.client.Connected;

    public void Close() => this.client.Close();

    [DebuggerHidden]
    private IEnumerator ReceiveE(
      int timeoutMilliseconds,
      Promise<Tuple<Peer.CommonHeader, byte[]>> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Peer.\u003CReceiveE\u003Ec__IteratorA8D()
      {
        timeoutMilliseconds = timeoutMilliseconds,
        promise = promise,
        \u003C\u0024\u003EtimeoutMilliseconds = timeoutMilliseconds,
        \u003C\u0024\u003Epromise = promise,
        \u003C\u003Ef__this = this
      };
    }

    public Future<Tuple<Peer.CommonHeader, byte[]>> Receive(int timeoutMilliseconds = -1)
    {
      return new Future<Tuple<Peer.CommonHeader, byte[]>>((Func<Promise<Tuple<Peer.CommonHeader, byte[]>>, IEnumerator>) (promise => this.ReceiveE(timeoutMilliseconds, promise)));
    }

    private byte[] MakeBytes(int type, int requestId, object obj)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        ms.Seek(8L, SeekOrigin.Begin);
        this.Serializer.Serialize(obj, (Stream) ms);
        Peer.CommonHeader commonHeader = new Peer.CommonHeader();
        commonHeader.Type = type;
        commonHeader.Length = (int) (ms.Position - 8L);
        commonHeader.RequestId = requestId;
        ms.Position = 0L;
        commonHeader.Write(ms);
        return ms.ToArray();
      }
    }

    [DebuggerHidden]
    private IEnumerator SendResponseE(
      int requestId,
      int type,
      AssocList<string, object> data,
      int timeout,
      Promise<int> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Peer.\u003CSendResponseE\u003Ec__IteratorA8E()
      {
        type = type,
        requestId = requestId,
        data = data,
        timeout = timeout,
        promise = promise,
        \u003C\u0024\u003Etype = type,
        \u003C\u0024\u003ErequestId = requestId,
        \u003C\u0024\u003Edata = data,
        \u003C\u0024\u003Etimeout = timeout,
        \u003C\u0024\u003Epromise = promise,
        \u003C\u003Ef__this = this
      };
    }

    private Future<int> SendResponse(
      int requestId,
      int type,
      AssocList<string, object> data,
      int timeout)
    {
      return new Future<int>((Func<Promise<int>, IEnumerator>) (promise => this.SendResponseE(requestId, type, data, timeout, promise)));
    }

    [DebuggerHidden]
    private IEnumerator SendE(
      int type,
      AssocList<string, object> data,
      int timeout,
      Promise<int> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Peer.\u003CSendE\u003Ec__IteratorA8F()
      {
        type = type,
        data = data,
        timeout = timeout,
        promise = promise,
        \u003C\u0024\u003Etype = type,
        \u003C\u0024\u003Edata = data,
        \u003C\u0024\u003Etimeout = timeout,
        \u003C\u0024\u003Epromise = promise,
        \u003C\u003Ef__this = this
      };
    }

    public Future<int> Send(int type, AssocList<string, object> data, int timeout)
    {
      return new Future<int>((Func<Promise<int>, IEnumerator>) (promise => this.SendE(type, data, timeout, promise)));
    }

    public Future<int> SendError(string message, int timeout)
    {
      return new Future<int>((Func<Promise<int>, IEnumerator>) (promise => this.SendE((int) byte.MaxValue, new AssocList<string, object>()
      {
        [nameof (message)] = (object) message
      }, timeout, promise)));
    }

    public class CommonHeader
    {
      public const int HEADER_BYTES = 8;
      public int Type;
      public int Length;
      public int RequestId;

      [DebuggerHidden]
      public IEnumerator ReadE(UnityTcpClient client, Promise<None> promise)
      {
        // ISSUE: object of a compiler-generated type is created
        return (IEnumerator) new Peer.CommonHeader.\u003CReadE\u003Ec__IteratorA90()
        {
          client = client,
          promise = promise,
          \u003C\u0024\u003Eclient = client,
          \u003C\u0024\u003Epromise = promise,
          \u003C\u003Ef__this = this
        };
      }

      public Future<None> Read(UnityTcpClient client)
      {
        return new Future<None>((Func<Promise<None>, IEnumerator>) (promise => this.ReadE(client, promise)));
      }

      public void Write(MemoryStream ms)
      {
        int num = this.Type << 24 | this.Length;
        ms.Write(BitConverter.GetBytes(num), 0, 4);
        ms.Write(BitConverter.GetBytes(this.RequestId), 0, 4);
      }
    }
  }
}
