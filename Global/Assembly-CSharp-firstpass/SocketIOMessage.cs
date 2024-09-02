// Decompiled with JetBrains decompiler
// Type: SocketIOMessage
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using HTTP;
using System.Collections;

#nullable disable
public class SocketIOMessage
{
  public SocketIOConnection socket;
  public SocketIOMessage.FrameType type;
  public int? id;
  public bool isUser;
  public string endPoint;
  public string data;
  public string eventName;
  public object[] args;

  public static SocketIOMessage FromString(string msg)
  {
    SocketIOMessage socketIoMessage = new SocketIOMessage();
    int result1 = 0;
    if (int.TryParse(SocketIOMessage.NextPart(msg, out msg), out result1))
      socketIoMessage.type = (SocketIOMessage.FrameType) result1;
    string s = SocketIOMessage.NextPart(msg, out msg);
    if (s == null)
    {
      socketIoMessage.id = new int?();
      socketIoMessage.isUser = false;
    }
    else
    {
      if (s.EndsWith("+"))
      {
        socketIoMessage.isUser = true;
        s = s.Substring(0, s.Length - 1);
      }
      int result2;
      if (int.TryParse(s, out result2))
        socketIoMessage.id = new int?(result2);
    }
    socketIoMessage.endPoint = SocketIOMessage.NextPart(msg, out msg);
    if (msg.Length > 0)
      socketIoMessage.data = msg.Substring(1);
    if (socketIoMessage.type == SocketIOMessage.FrameType.EVENT)
    {
      Hashtable hashtable = JsonSerializer.Decode(socketIoMessage.data) as Hashtable;
      socketIoMessage.eventName = hashtable[(object) "name"] as string;
      socketIoMessage.args = ((ArrayList) hashtable[(object) "args"]).ToArray();
    }
    return socketIoMessage;
  }

  private static string NextPart(string parts, out string remainder)
  {
    if (parts[0] == ':')
    {
      remainder = parts.Substring(1);
      return (string) null;
    }
    int num = parts.IndexOf(':');
    string str = parts.Substring(0, num);
    remainder = parts.Substring(num);
    return str;
  }

  public override string ToString()
  {
    return string.Format("{0}:{1}:{2}:{3}", (object) (int) this.type, !this.isUser ? (object) this.id.ToString() : (object) (this.id.ToString() + "+"), (object) this.endPoint, (object) this.data);
  }

  public enum FrameType
  {
    DISCONNECT,
    CONNECT,
    HEARTBEAT,
    MESSAGE,
    JSONMESSAGE,
    EVENT,
    ACK,
    ERROR,
    NOOP,
  }
}
