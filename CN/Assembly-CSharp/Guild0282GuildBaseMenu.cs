// Decompiled with JetBrains decompiler
// Type: Guild0282GuildBaseMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

  public void onButtonBattleLog() => Debug.Log((object) "OpenBattleLog");

  public void onButtonGuildTop()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.backScene();
  }

  public void onButtonMemberList()
  {
    Debug.Log((object) "OpemMemberList");
    this.StartCoroutine(this.ShowMemberList());
  }

  public void onButtonGuildAbout()
  {
    Singleton<PopupManager>.GetInstance().open(this.guildInfoPopup.guildInfoPopup).GetComponent<Guild028114Popup>().Initialize(this.guildInfoPopup);
    Debug.Log((object) "OpemGuildAbout");
  }

  [DebuggerHidden]
  private IEnumerator ShowMemberList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282GuildBaseMenu.\u003CShowMemberList\u003Ec__Iterator6C5()
    {
      \u003C\u003Ef__this = this
    };
  }
}
