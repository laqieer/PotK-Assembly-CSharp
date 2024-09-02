// Decompiled with JetBrains decompiler
// Type: HTTP.WebSocket
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using UnityEngine;

#nullable disable
namespace HTTP
{
  public class WebSocket
  {
    private const byte FINALBIT = 128;
    private const byte RESERVEDBIT1 = 64;
    private const byte RESERVEDBIT2 = 32;
    private const byte RESERVEDBIT3 = 16;
    private const byte OP_CODE_MASK = 15;
    private const byte MASKBIT = 128;
    private const byte PAYLOAD_LENGTH_MASK = 127;
    private const int MASKING_KEY_WIDTH_IN_BYTES = 4;
    private const int MAX_PAYLOAD_WITHOUT_EXTENDED_LENGTH_FIELD = 125;
    private const int PAYLOAD_WITH_TWO_BYTE_EXTENDED_FIELD = 126;
    private const int PAYLOAD_WITH_EIGHT_BYTE_EXTENDED_FIELD = 127;
    public int niceness = 100;
    public Exception exception;
    public bool isDone;
    public bool connected;
    private Thread outgoingWorkerThread;
    private Thread incomingWorkerThread;
    private HttpConnection connection;
    private List<string> incomingText = new List<string>();
    private List<byte[]> incomingBinary = new List<byte[]>();
    private List<WebSocket.OutgoingMessage> outgoing = new List<WebSocket.OutgoingMessage>();
    private bool hasContinuousFrame;
    private WebSocket.OpCode continuousFrameOpCode;
    private List<byte> continuousFrameData = new List<byte>();
    private bool receivedClosingHandshake;
    private WebSocket.CloseEventCode closeEventCode;
    private string closeEventReason = string.Empty;
    private bool closing;
    private bool connectionBroken;

    public event System.Action OnConnect;

    public event System.Action OnDisconnect;

    public event WebSocket.OnTextMessageHandler OnTextMessageRecv;

    public event WebSocket.OnBinaryMessageHandler OnBinaryMessageRecv;

    private void OnTextMessage(string msg)
    {
      lock (this.incomingText)
        this.incomingText.Add(msg);
    }

    private void OnBinaryMessage(byte[] msg)
    {
      lock (this.incomingBinary)
        this.incomingBinary.Add(msg);
    }

    [DebuggerHidden]
    public IEnumerator Dispatcher()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new WebSocket.\u003CDispatcher\u003Ec__IteratorD()
      {
        \u003C\u003Ef__this = this
      };
    }

    public void Connect(string uri) => this.Connect(new Uri(uri));

    public Coroutine Wait() => UniWeb.Instance.StartCoroutine(this._Wait());

    [DebuggerHidden]
    private IEnumerator _Wait()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new WebSocket.\u003C_Wait\u003Ec__IteratorE()
      {
        \u003C\u003Ef__this = this
      };
    }

    public void Connect(Uri uri) => UniWeb.Instance.StartCoroutine(this._Connect(uri));

    [DebuggerHidden]
    private IEnumerator _Connect(Uri uri)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new WebSocket.\u003C_Connect\u003Ec__IteratorF()
      {
        uri = uri,
        \u003C\u0024\u003Euri = uri,
        \u003C\u003Ef__this = this
      };
    }

    public void Send(string data)
    {
      this.outgoing.Add(new WebSocket.OutgoingMessage(WebSocket.OpCode.OpCodeText, Encoding.ASCII.GetBytes(data)));
    }

    public void Send(byte[] data)
    {
      this.outgoing.Add(new WebSocket.OutgoingMessage(WebSocket.OpCode.OpCodeBinary, data));
    }

    public void Close(WebSocket.CloseEventCode code, string reason)
    {
      this.StartClosingHandshake(code, reason);
    }

    private void OutgoingWorker()
    {
label_0:
      Thread.Sleep(this.niceness);
      lock (this.outgoing)
      {
        while (true)
        {
          if (this.connection.stream.CanWrite)
          {
            if (this.outgoing.Count > 0)
            {
              WebSocket.OutgoingMessage outgoingMessage = this.outgoing[0];
              byte[] buffer = this.BuildFrame(outgoingMessage.opCode, outgoingMessage.data);
              this.connection.stream.Write(buffer, 0, buffer.Length);
              this.outgoing.RemoveAt(0);
            }
            else
              goto label_0;
          }
          else
            goto label_0;
        }
      }
    }

    private void IncomingWorker()
    {
      this.connectionBroken = false;
      List<byte> buffer = new List<byte>();
      while (this.connection.client.Client.Connected)
      {
        int num = this.connection.stream.ReadByte();
        if (num != -1)
        {
          buffer.Add((byte) num);
          this.ProcessBuffer(buffer);
        }
        else
          break;
      }
      this.connectionBroken = true;
    }

    private bool ProcessBuffer(List<byte> buffer) => this.ProcessFrame(buffer);

    private bool ProcessFrame(List<byte> buffer)
    {
      WebSocket.FrameData frame;
      if (this.ParseFrame(buffer, out frame) != WebSocket.ParseFrameResult.FrameOK)
        return false;
      switch (frame.opCode)
      {
        case WebSocket.OpCode.OpCodeContinuation:
          if (!this.hasContinuousFrame)
          {
            Debug.LogWarning((object) "Received unexpected continuation frame.");
            return false;
          }
          this.continuousFrameData.AddRange((IEnumerable<byte>) new WebSocket.SubArray(buffer, frame.payload, frame.payloadLength));
          this.RemoveProcessed(buffer, frame.end);
          if (frame.final)
          {
            this.continuousFrameData = new List<byte>();
            this.hasContinuousFrame = false;
            if (this.continuousFrameOpCode == WebSocket.OpCode.OpCodeText)
            {
              string empty = string.Empty;
              if (this.continuousFrameData.Count > 0)
                empty = Encoding.UTF8.GetString(this.continuousFrameData.ToArray());
              this.OnTextMessage(empty);
              break;
            }
            if (this.continuousFrameOpCode == WebSocket.OpCode.OpCodeBinary)
            {
              this.OnBinaryMessage(this.continuousFrameData.ToArray());
              break;
            }
            break;
          }
          break;
        case WebSocket.OpCode.OpCodeText:
          if (frame.final)
          {
            string empty = string.Empty;
            if (frame.payloadLength > 0)
            {
              byte[] numArray = new byte[frame.payloadLength];
              buffer.CopyTo(frame.payload, numArray, 0, frame.payloadLength);
              empty = Encoding.UTF8.GetString(numArray);
            }
            this.OnTextMessage(empty);
            this.RemoveProcessed(buffer, frame.end);
            break;
          }
          this.hasContinuousFrame = true;
          this.continuousFrameOpCode = WebSocket.OpCode.OpCodeText;
          this.continuousFrameData.AddRange((IEnumerable<byte>) new WebSocket.SubArray(buffer, frame.payload, frame.payloadLength));
          this.RemoveProcessed(buffer, frame.end);
          break;
        case WebSocket.OpCode.OpCodeBinary:
          if (frame.final)
          {
            byte[] numArray = new byte[frame.payloadLength];
            buffer.CopyTo(frame.payload, numArray, 0, frame.payloadLength);
            this.OnBinaryMessage(numArray);
            this.RemoveProcessed(buffer, frame.end);
            break;
          }
          this.hasContinuousFrame = true;
          this.continuousFrameOpCode = WebSocket.OpCode.OpCodeBinary;
          this.continuousFrameData.AddRange((IEnumerable<byte>) new WebSocket.SubArray(buffer, frame.payload, frame.payloadLength));
          this.RemoveProcessed(buffer, frame.end);
          break;
        case WebSocket.OpCode.OpCodeClose:
          this.closeEventCode = frame.payloadLength < 2 ? WebSocket.CloseEventCode.CloseEventCodeNoStatusRcvd : (WebSocket.CloseEventCode) ((int) buffer[frame.payload] << 8 | (int) buffer[frame.payload + 1]);
          if (frame.payloadLength >= 3)
          {
            byte[] numArray = new byte[frame.payloadLength - 2];
            buffer.CopyTo(2, numArray, 0, frame.payloadLength - 2);
            this.closeEventReason = Encoding.UTF8.GetString(numArray);
          }
          else
            this.closeEventReason = string.Empty;
          this.RemoveProcessed(buffer, frame.end);
          this.receivedClosingHandshake = true;
          this.StartClosingHandshake(this.closeEventCode, this.closeEventReason);
          break;
        case WebSocket.OpCode.OpCodePing:
          byte[] numArray1 = new byte[frame.payloadLength];
          buffer.CopyTo(frame.payload, numArray1, 0, frame.payloadLength);
          this.RemoveProcessed(buffer, frame.end);
          lock (this.outgoing)
          {
            this.outgoing.Add(new WebSocket.OutgoingMessage(WebSocket.OpCode.OpCodePong, numArray1));
            break;
          }
        case WebSocket.OpCode.OpCodePong:
          this.RemoveProcessed(buffer, frame.end);
          break;
        default:
          Debug.LogError((object) "SHOULD NOT REACH HERE");
          break;
      }
      return buffer.Count != 0;
    }

    private WebSocket.ParseFrameResult ParseFrame(List<byte> buffer, out WebSocket.FrameData frame)
    {
      frame = (WebSocket.FrameData) null;
      if (buffer.Count < 2)
        return WebSocket.ParseFrameResult.FrameIncomplete;
      int num1 = 0;
      List<byte> byteList1 = buffer;
      int index1 = num1;
      int num2 = index1 + 1;
      byte num3 = byteList1[index1];
      List<byte> byteList2 = buffer;
      int index2 = num2;
      int num4 = index2 + 1;
      byte num5 = byteList2[index2];
      bool flag1 = ((int) num3 & 128) > 0;
      bool flag2 = ((int) num3 & 64) > 0;
      bool flag3 = ((int) num3 & 32) > 0;
      bool flag4 = ((int) num3 & 16) > 0;
      WebSocket.OpCode opCode = (WebSocket.OpCode) ((int) num3 & 15);
      bool flag5 = ((int) num5 & 128) > 0;
      long num6 = (long) ((int) num5 & (int) sbyte.MaxValue);
      if (num6 > 125L)
      {
        int num7 = num6 != 126L ? 8 : 2;
        if (buffer.Count - num4 < num7)
          return WebSocket.ParseFrameResult.FrameIncomplete;
        num6 = 0L;
        for (int index3 = 0; index3 < num7; ++index3)
          num6 = num6 << 8 | (long) buffer[num4++];
      }
      int num8 = !flag5 ? 0 : 4;
      if (num6 > long.MaxValue || num6 + (long) num8 > (long) int.MaxValue)
      {
        Debug.LogError((object) string.Format("WebSocket frame length too large: {0} bytes", (object) num6));
        return WebSocket.ParseFrameResult.FrameError;
      }
      int num9 = (int) num6;
      if (buffer.Count - num4 < num8 + num9)
        return WebSocket.ParseFrameResult.FrameIncomplete;
      if (flag5)
      {
        int num10 = num4;
        int num11 = num4 + 4;
        for (int index4 = 0; index4 < num9; ++index4)
        {
          List<byte> byteList3;
          int index5;
          (byteList3 = buffer)[index5 = num11 + index4] = (byte) ((uint) byteList3[index5] ^ (uint) buffer[num10 + index4 % 4]);
        }
      }
      frame = new WebSocket.FrameData();
      frame.opCode = opCode;
      frame.final = flag1;
      frame.reserved1 = flag2;
      frame.reserved2 = flag3;
      frame.reserved3 = flag4;
      frame.masked = flag5;
      frame.payload = num4 + num8;
      frame.payloadLength = num9;
      frame.end = num4 + num8 + num9;
      return WebSocket.ParseFrameResult.FrameOK;
    }

    private byte[] BuildFrame(WebSocket.OpCode opCode, byte[] data)
    {
      List<byte> buffer = new List<byte>();
      buffer.Add((byte) (128U | (uint) (byte) opCode));
      if (data.Length <= 125)
        buffer.Add((byte) (128 | data.Length & (int) byte.MaxValue));
      else if (data.Length <= (int) ushort.MaxValue)
      {
        buffer.Add((byte) 254);
        buffer.Add((byte) ((data.Length & 65280) >> 8));
        buffer.Add((byte) (data.Length & (int) byte.MaxValue));
      }
      else
      {
        buffer.Add(byte.MaxValue);
        byte[] collection = new byte[8];
        int length = data.Length;
        for (int index = 0; index < 8; ++index)
        {
          collection[7 - index] = (byte) (length & (int) byte.MaxValue);
          length >>= 8;
        }
        buffer.AddRange((IEnumerable<byte>) collection);
      }
      int count1 = buffer.Count;
      buffer.AddRange((IEnumerable<byte>) new byte[4]);
      int count2 = buffer.Count;
      buffer.AddRange((IEnumerable<byte>) data);
      Arc4RandomNumberGenerator.CryptographicallyRandomValues(buffer, count1, 4);
      for (int index1 = 0; index1 < data.Length; ++index1)
      {
        List<byte> byteList;
        int index2;
        (byteList = buffer)[index2 = count2 + index1] = (byte) ((uint) byteList[index2] ^ (uint) buffer[count1 + index1 % 4]);
      }
      return buffer.ToArray();
    }

    private void RemoveProcessed(List<byte> buffer, int length) => buffer.RemoveRange(0, length);

    private void StartClosingHandshake(WebSocket.CloseEventCode code, string reason)
    {
      if (this.closing)
        return;
      List<byte> byteList = new List<byte>();
      if (!this.receivedClosingHandshake)
      {
        byte num1 = (byte) ((uint) code >> 8);
        byte num2 = (byte) code;
        byteList.Add(num1);
        byteList.Add(num2);
        byteList.AddRange((IEnumerable<byte>) Encoding.UTF8.GetBytes(reason));
        this.outgoing.Add(new WebSocket.OutgoingMessage(WebSocket.OpCode.OpCodeClose, byteList.ToArray()));
      }
      this.closing = true;
    }

    private string WebSocketKey() => Convert.ToBase64String(Guid.NewGuid().ToByteArray());

    [Flags]
    public enum OpCode
    {
      OpCodeContinuation = 0,
      OpCodeText = 1,
      OpCodeBinary = 2,
      OpCodeClose = 8,
      OpCodePing = OpCodeClose | OpCodeText, // 0x00000009
      OpCodePong = OpCodeClose | OpCodeBinary, // 0x0000000A
    }

    private enum ParseFrameResult
    {
      FrameIncomplete,
      FrameOK,
      FrameError,
    }

    public enum CloseEventCode
    {
      CloseEventCodeNotSpecified = -1, // 0xFFFFFFFF
      CloseEventCodeNormalClosure = 1000, // 0x000003E8
      CloseEventCodeGoingAway = 1001, // 0x000003E9
      CloseEventCodeProtocolError = 1002, // 0x000003EA
      CloseEventCodeUnsupportedData = 1003, // 0x000003EB
      CloseEventCodeFrameTooLarge = 1004, // 0x000003EC
      CloseEventCodeNoStatusRcvd = 1005, // 0x000003ED
      CloseEventCodeAbnormalClosure = 1006, // 0x000003EE
      CloseEventCodeInvalidUTF8 = 1007, // 0x000003EF
      CloseEventCodeMinimumUserDefined = 3000, // 0x00000BB8
      CloseEventCodeMaximumUserDefined = 4999, // 0x00001387
    }

    private class FrameData
    {
      public WebSocket.OpCode opCode;
      public bool final;
      public bool reserved1;
      public bool reserved2;
      public bool reserved3;
      public bool masked;
      public int payload;
      public int payloadLength;
      public int end;
    }

    private class SubArray : IEnumerable<byte>, IEnumerable
    {
      private List<byte> array;
      private int offset;
      private int length;

      public SubArray(List<byte> array, int offset, int length)
      {
        this.array = array;
        this.offset = offset;
        this.length = length;
      }

      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

      public IEnumerator<byte> GetEnumerator()
      {
        return (IEnumerator<byte>) new WebSocket.SubArrayEnum(this.array, this.offset, this.length);
      }
    }

    private class SubArrayEnum : IDisposable, IEnumerator, IEnumerator<byte>
    {
      private List<byte> array;
      private int offset;
      private int length;
      private int position = -1;

      public SubArrayEnum(List<byte> array, int offset, int length)
      {
        this.array = array;
        this.offset = offset;
        this.length = length;
      }

      object IEnumerator.Current => (object) this.Current;

      public bool MoveNext()
      {
        ++this.position;
        return this.position < this.length;
      }

      public void Reset() => this.position = -1;

      public byte Current
      {
        get
        {
          try
          {
            return this.array[this.offset + this.position];
          }
          catch (IndexOutOfRangeException ex)
          {
            throw new InvalidOperationException();
          }
        }
      }

      public void Dispose()
      {
      }
    }

    public struct OutgoingMessage
    {
      public WebSocket.OpCode opCode;
      public byte[] data;

      public OutgoingMessage(WebSocket.OpCode opCode, byte[] data)
      {
        this.opCode = opCode;
        this.data = data;
      }
    }

    public delegate void OnTextMessageHandler(string message);

    public delegate void OnBinaryMessageHandler(byte[] message);
  }
}
