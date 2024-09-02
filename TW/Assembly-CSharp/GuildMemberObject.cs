// Decompiled with JetBrains decompiler
// Type: GuildMemberObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildMemberObject
{
  private GameObject guildMemberListPopup;
  private GameObject guildMemberInfoPopup;
  private GameObject guildMemberListPrefab;
  private GameObject guildPositionManagementPopup;
  private GameObject guildPositionManagementPopupYesNo;
  private GameObject guildPositionManagementPopupOk;

  public GameObject GuildMemberListPopup => this.guildMemberListPopup;

  public GameObject GuildMemberInfoPopup => this.guildMemberInfoPopup;

  public GameObject GuildMemberListPrefab => this.guildMemberListPrefab;

  public GameObject GuildPositionManagementPopup => this.guildPositionManagementPopup;

  public GameObject GuildPositionManagementPopupYesNo => this.guildPositionManagementPopupYesNo;

  public GameObject GuildPositionManagementPopupOk => this.guildPositionManagementPopupOk;

  [DebuggerHidden]
  public IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberObject.\u003CResourceLoad\u003Ec__Iterator76D()
    {
      \u003C\u003Ef__this = this
    };
  }
}
