// Decompiled with JetBrains decompiler
// Type: SocketIOConnection
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using HTTP;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class SocketIOConnection : MonoBehaviour
{
  public string url;
  public bool reconnect;
  public string sid;
  public float heartbeatTimeout;
  public float closingTimeout;
  public string[] transports;
  private Dictionary<string, SocketIOConnection.EventHandler> handlers = new Dictionary<string, SocketIOConnection.EventHandler>();
  private WebSocket socket;
  private int msgUid;

  public bool Ready => this.socket != null;

  private void OnApplicationQuit()
  {
    this.socket.Close(WebSocket.CloseEventCode.CloseEventCodeGoingAway, "Bye.");
  }

  public void On(string eventName, SocketIOConnection.EventHandler fn)
  {
    this.handlers[eventName] = fn;
  }

  public int Send(SocketIOMessage msg)
  {
    msg.id = new int?(this.msgUid++);
    if (this.socket == null)
    {
      Debug.LogError((object) "Socket.IO is not initialised yet!");
      return -1;
    }
    this.socket.Send(msg.ToString());
    return msg.id.Value;
  }

  public int Send(object payload)
  {
    return this.Send(new SocketIOMessage()
    {
      type = SocketIOMessage.FrameType.JSONMESSAGE,
      data = JsonSerializer.Encode(payload)
    });
  }

  public int Emit(string eventName, params object[] args)
  {
    return this.Send(new SocketIOMessage()
    {
      type = SocketIOMessage.FrameType.EVENT,
      data = JsonSerializer.Encode((object) new Hashtable()
      {
        [(object) "name"] = (object) eventName,
        [(object) nameof (args)] = (object) args
      })
    });
  }

  private void Start()
  {
    Application.runInBackground = true;
    if (!this.url.EndsWith("/"))
      this.url += "/";
    this.Dispatch("connecting", (SocketIOMessage) null);
    this.StartCoroutine(this.EstablishConnection((System.Action) (() => this.Dispatch("connect", (SocketIOMessage) null)), (System.Action) (() => this.Dispatch("connect_failed", (SocketIOMessage) null))));
  }

  private void Reconnect()
  {
    this.Dispatch("reconnecting", (SocketIOMessage) null);
    this.StartCoroutine(this.EstablishConnection((System.Action) (() => this.Dispatch("reconnect", (SocketIOMessage) null)), (System.Action) (() => this.Dispatch("reconnect_failed", (SocketIOMessage) null))));
  }

  [DebuggerHidden]
  private IEnumerator EstablishConnection(System.Action success, System.Action failed)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new SocketIOConnection.\u003CEstablishConnection\u003Ec__Iterator10()
    {
      success = success,
      failed = failed,
      \u003C\u0024\u003Esuccess = success,
      \u003C\u0024\u003Efailed = failed,
      \u003C\u003Ef__this = this
    };
  }

  private void Dispatch(string eventName, SocketIOMessage msg)
  {
    SocketIOConnection.EventHandler eventHandler = (SocketIOConnection.EventHandler) null;
    if (!this.handlers.TryGetValue(eventName, out eventHandler))
      return;
    eventHandler(this, msg);
  }

  private void HandleSocketOnTextMessageRecv(string message)
  {
    SocketIOMessage msg = SocketIOMessage.FromString(message);
    msg.socket = this;
    switch (msg.type)
    {
      case SocketIOMessage.FrameType.DISCONNECT:
        this.StopCoroutine("Hearbeat");
        this.Dispatch("disconnect", (SocketIOMessage) null);
        if (!this.reconnect)
          break;
        this.Reconnect();
        break;
      case SocketIOMessage.FrameType.CONNECT:
        if (msg.endPoint != null)
          break;
        this.StartCoroutine("Heartbeat");
        break;
      case SocketIOMessage.FrameType.MESSAGE:
        this.Dispatch(nameof (message), msg);
        break;
      case SocketIOMessage.FrameType.JSONMESSAGE:
        this.Dispatch("json_message", msg);
        break;
      case SocketIOMessage.FrameType.EVENT:
        this.Dispatch(msg.eventName, msg);
        break;
      case SocketIOMessage.FrameType.ERROR:
        this.Dispatch("error", msg);
        break;
    }
  }

  [DebuggerHidden]
  private IEnumerator Heartbeat()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new SocketIOConnection.\u003CHeartbeat\u003Ec__Iterator11()
    {
      \u003C\u003Ef__this = this
    };
  }

  public delegate void EventHandler(SocketIOConnection socket, SocketIOMessage msg);
}
