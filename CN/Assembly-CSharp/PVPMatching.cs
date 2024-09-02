// Decompiled with JetBrains decompiler
// Type: PVPMatching
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using Net;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class PVPMatching : MonoBehaviour
{
  [SerializeField]
  private int timeoutMilliseconds = 95000;
  [SerializeField]
  private string matchingHost = "punk-mp-matching1.develop3.gu3.jp";
  [SerializeField]
  private int matchingPort = 11126;
  private bool _ignoreVersion;
  private PVPManager _pvpManager;
  private MatchingPeer peer;

  public bool ignoreVersion
  {
    get => this._ignoreVersion;
    set => this._ignoreVersion = value;
  }

  public bool IsCancel { private get; set; }

  private PVPManager pvpManager
  {
    get
    {
      if (Object.op_Equality((Object) this._pvpManager, (Object) null))
        this._pvpManager = Singleton<PVPManager>.GetInstance();
      return this._pvpManager;
    }
  }

  public void setMatchingServer(string host, int port)
  {
    this.matchingHost = host;
    this.matchingPort = port;
  }

  public void getMatchingServer(out string host, out int port)
  {
    host = this.matchingHost;
    port = this.matchingPort;
  }

  public void closePeer()
  {
    if (this.peer == null)
      return;
    this.peer.Close();
    this.peer = (MatchingPeer) null;
  }

  public void cleanupDestroy()
  {
    this.closePeer();
    Object.Destroy((Object) this);
  }

  public Future<MatchingPeer.MatchedConfirmation> matchingPVP(
    string roomkey = "",
    MatchingDebugInfo debugInfo = null)
  {
    Debug.LogWarning((object) (" === matchingPVP " + this.matchingHost + " " + (object) this.matchingPort));
    return new Future<MatchingPeer.MatchedConfirmation>((Func<Promise<MatchingPeer.MatchedConfirmation>, IEnumerator>) (promise => this._matching(promise, roomkey, debugInfo)));
  }

  public Future<MatchingPeer.Matched> matchingReady(bool enable)
  {
    Debug.LogWarning((object) (" === matchingReady " + (object) enable));
    return new Future<MatchingPeer.Matched>((Func<Promise<MatchingPeer.Matched>, IEnumerator>) (promise => this._ready(promise, enable)));
  }

  [DebuggerHidden]
  private IEnumerator _matching(
    Promise<MatchingPeer.MatchedConfirmation> promise,
    string roomkey,
    MatchingDebugInfo debugInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPMatching.\u003C_matching\u003Ec__Iterator9F2()
    {
      promise = promise,
      roomkey = roomkey,
      debugInfo = debugInfo,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u0024\u003Eroomkey = roomkey,
      \u003C\u0024\u003EdebugInfo = debugInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator _ready(Promise<MatchingPeer.Matched> promise, bool enable)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PVPMatching.\u003C_ready\u003Ec__Iterator9F3()
    {
      enable = enable,
      promise = promise,
      \u003C\u0024\u003Eenable = enable,
      \u003C\u0024\u003Epromise = promise,
      \u003C\u003Ef__this = this
    };
  }
}
