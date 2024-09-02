// Decompiled with JetBrains decompiler
// Type: Guild0282Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Guild0282Scene : NGSceneBase
{
  [SerializeField]
  private Guild0282Menu guild0282menu;

  public static void ChangeScene()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", Singleton<NGSceneManager>.GetInstance().sceneName != "guild028_2");
  }

  public static void ChangeSceneOrMemberFocus(GuildMembership member, Guild0282Menu menu)
  {
    bool isStack = Singleton<NGSceneManager>.GetInstance().sceneName != "guild028_2";
    if (member == null)
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", isStack);
    else if (!((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).Any<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == member.player.player_id)))
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", isStack);
    else if (Object.op_Equality((Object) menu, (Object) null) && Object.op_Equality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>(), (Object) null))
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", (isStack ? 1 : 0) != 0, (object) member);
    else if (!menu.MyGuildUI.memberBaseList.Any<Guild0282MemberBase>((Func<Guild0282MemberBase, bool>) (x => x.Member.player.player_id == member.player.player_id)))
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", (isStack ? 1 : 0) != 0, (object) member);
    else if (Singleton<NGSceneManager>.GetInstance().sceneName != "guild028_2")
    {
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", (isStack ? 1 : 0) != 0, (object) member);
    }
    else
    {
      menu.MemberBaseUpdate();
      menu.JumpMember(member);
    }
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Scene.\u003ConStartSceneAsync\u003Ec__Iterator6D4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GuildMembership member)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Scene.\u003ConStartSceneAsync\u003Ec__Iterator6D5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    this.guild0282menu.Initialize();
    this.guild0282menu.InitializeJump();
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }

  public void onStartScene(GuildMembership member)
  {
    this.guild0282menu.Initialize(member);
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }

  public override void onEndScene() => this.guild0282menu.onEndScene();

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Scene.\u003ConEndSceneAsync\u003Ec__Iterator6D6()
    {
      \u003C\u003Ef__this = this
    };
  }
}
