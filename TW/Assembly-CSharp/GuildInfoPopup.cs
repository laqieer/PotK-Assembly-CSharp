// Decompiled with JetBrains decompiler
// Type: GuildInfoPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private System.Action requestMaintenanceCallback;
  private System.Action requestAlreadyGuildCallback;

  [DebuggerHidden]
  public IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildInfoPopup.\u003CResourceLoad\u003Ec__Iterator6FE()
    {
      \u003C\u003Ef__this = this
    };
  }

  public System.Action SendRequestCallback => this.sendRequestCallback;

  public System.Action CancelRequeestCallback => this.cancelRequestCallback;

  public void SetSendRequestCallback(System.Action action) => this.sendRequestCallback = action;

  public void SetCancelRequestCallback(System.Action action) => this.cancelRequestCallback = action;

  public System.Action RequestMaintenanceCallback => this.requestMaintenanceCallback;

  public void SetRequestMaintenanceCallback(System.Action action)
  {
    this.requestMaintenanceCallback = action;
  }

  public System.Action RequestAlreadyGuildCallback => this.requestAlreadyGuildCallback;

  public void SetRequestAlreadyGuildCallback(System.Action action)
  {
    this.requestAlreadyGuildCallback = action;
  }
}
