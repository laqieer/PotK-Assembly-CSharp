// Decompiled with JetBrains decompiler
// Type: Guild02811FriendScrollBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild02811FriendScrollBar : FriendScrollBar
{
  private GuildDirectory guild;

  public GuildDirectory Guild
  {
    get => this.guild;
    set => this.guild = value;
  }

  public Guild02811Menu Menu { get; set; }

  public void onButtonGuildAbout()
  {
    GameObject prefab = this.Menu.GuildPopup.guildInfoPopup.Clone();
    prefab.SetActive(false);
    prefab.GetComponent<Guild028114Popup>().Initialize(this.Guild, this.Menu.GuildPopup);
    prefab.SetActive(true);
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
  }

  [DebuggerHidden]
  public override IEnumerator SetUnitIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811FriendScrollBar.\u003CSetUnitIcon\u003Ec__Iterator6FD()
    {
      \u003C\u003Ef__this = this
    };
  }
}
