// Decompiled with JetBrains decompiler
// Type: Guild0282GuildBaseMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0282GuildBaseMenu : GuildMapObject
{
  private GuildMemberObject guildMemberObj;
  private Guild0282Menu menu;
  [SerializeField]
  private bool isEnemy;
  private GuildRegistration guild;
  private GuildInfoPopup guildInfoPopup;
  private GameObject guildBattleRecordPopup;
  private GameObject guildBattleMemberScorePopup;

  public void Initialize(
    GuildRegistration guildData,
    GuildInfoPopup guildInfoData,
    GuildMemberObject memberObj,
    Guild0282Menu menu)
  {
    this.guild = guildData;
    this.guildInfoPopup = guildInfoData;
    this.guildMemberObj = memberObj;
    this.menu = menu;
  }

  public override void onBackButton()
  {
  }

  public void onButtonBattleLog()
  {
    Debug.Log((object) "OpenBattleLog");
    this.StartCoroutine(this.ShowBattleRecord());
  }

  public void onButtonGuildTop()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.menu.BackScene();
  }

  public void onButtonMemberList()
  {
    Debug.Log((object) "OpemMemberList");
    this.StartCoroutine(this.ShowMemberList());
  }

  public void onButtonGuildAbout()
  {
    this.menu.isClosePopupByBackBtn = false;
    Singleton<PopupManager>.GetInstance().open(this.guildInfoPopup.guildInfoPopup).GetComponent<Guild028114Popup>().Initialize(this.guildInfoPopup, this.guild, this.isEnemy);
    Debug.Log((object) "OpemGuildAbout");
  }

  [DebuggerHidden]
  private IEnumerator ShowMemberList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282GuildBaseMenu.\u003CShowMemberList\u003Ec__Iterator760()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowBattleRecord()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282GuildBaseMenu.\u003CShowBattleRecord\u003Ec__Iterator761()
    {
      \u003C\u003Ef__this = this
    };
  }
}
