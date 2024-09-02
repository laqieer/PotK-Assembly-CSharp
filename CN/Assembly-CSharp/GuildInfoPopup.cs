// Decompiled with JetBrains decompiler
// Type: GuildInfoPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildInfoPopup
{
  public GameObject guildInfoPopup;
  public GameObject guildSendRequestPopup;
  public GameObject guildSendRequestResultPopup;
  public GameObject guildCancelRequestPopup;
  public GameObject guildCancelRequestResultPopup;
  public GameObject guildStatementPopup;
  public GameObject guildNgWordPopup;
  public GameObject guildFriendListPopup;
  public GameObject guildFriendListParts;
  private System.Action sendRequestCallback;
  private System.Action cancelRequestCallback;

  [DebuggerHidden]
  public IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildInfoPopup.\u003CResourceLoad\u003Ec__Iterator6A3()
    {
      \u003C\u003Ef__this = this
    };
  }

  public System.Action SendRequestCallback => this.sendRequestCallback;

  public System.Action CancelRequeestCallback => this.cancelRequestCallback;

  public void SetSendRequestCallback(System.Action action) => this.sendRequestCallback = action;

  public void SetCancelRequestCallback(System.Action action) => this.cancelRequestCallback = action;
}
