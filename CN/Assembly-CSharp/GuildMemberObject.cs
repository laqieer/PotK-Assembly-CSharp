// Decompiled with JetBrains decompiler
// Type: GuildMemberObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new GuildMemberObject.\u003CResourceLoad\u003Ec__Iterator6CC()
    {
      \u003C\u003Ef__this = this
    };
  }
}
