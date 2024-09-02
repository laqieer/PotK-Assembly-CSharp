// Decompiled with JetBrains decompiler
// Type: Guild0282Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
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

  public static void ChangeSceneBattleFinish(string targetPlayerID, int captureStar)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", true, (object) targetPlayerID, (object) captureStar);
  }

  public static void ChangeSceneOrMemberFocus(GuildMembership member, Guild0282Menu menu)
  {
    bool isStack = Singleton<NGSceneManager>.GetInstance().sceneName != "guild028_2";
    if (member == null)
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", isStack);
    else if (!((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).Any<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == member.player.player_id)) && (!Object.op_Inequality((Object) menu, (Object) null) || menu.EnGuildUI == null || !menu.EnGuildUI.memberBaseList.Any<Guild0282MemberBase>((Func<Guild0282MemberBase, bool>) (x => x.Member.player.player_id == member.player.player_id))))
    {
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", isStack);
    }
    else
    {
      if (Object.op_Equality((Object) menu, (Object) null))
      {
        menu = ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>();
        if (Object.op_Equality((Object) menu, (Object) null))
        {
          Singleton<NGSceneManager>.GetInstance().changeScene("guild028_2", (isStack ? 1 : 0) != 0, (object) member);
          return;
        }
      }
      if (!menu.MyGuildUI.memberBaseList.Any<Guild0282MemberBase>((Func<Guild0282MemberBase, bool>) (x => x.Member.player.player_id == member.player.player_id)) && menu.EnGuildUI != null && !menu.EnGuildUI.memberBaseList.Any<Guild0282MemberBase>((Func<Guild0282MemberBase, bool>) (x => x.Member.player.player_id == member.player.player_id)))
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
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Scene.\u003ConStartSceneAsync\u003Ec__Iterator784()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GuildMembership member)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Scene.\u003ConStartSceneAsync\u003Ec__Iterator785()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(string targetPlayerID, int captureStar)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Scene.\u003ConStartSceneAsync\u003Ec__Iterator786()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    this.guild0282menu.Initialize();
    this.guild0282menu.InitializeJump();
    if (GuildUtil.gvgPopupState != GuildUtil.GvGPopupState.None && this.guild0282menu.actionForGvgPopup != null)
      this.guild0282menu.actionForGvgPopup();
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }

  public void onStartScene(GuildMembership member)
  {
    if (GuildUtil.gvgPopupState != GuildUtil.GvGPopupState.None && this.guild0282menu.actionForGvgPopup != null)
    {
      this.onStartScene();
    }
    else
    {
      this.guild0282menu.Initialize(member);
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    }
  }

  public void onStartScene(string targetPlayerID, int captureStar)
  {
    if (GuildUtil.gvgPopupState != GuildUtil.GvGPopupState.None && this.guild0282menu.actionForGvgPopup != null)
    {
      this.onStartScene();
    }
    else
    {
      int? nullable = ((IEnumerable<GuildMembership>) this.guild0282menu.EnGuild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == targetPlayerID));
      if (nullable.HasValue && GuildUtil.isBattleOrPreparing(PlayerAffiliation.Current.guild.gvg_status))
        this.guild0282menu.InitializeGBResult(this.guild0282menu.EnGuild.memberships[nullable.Value], captureStar);
      else
        this.guild0282menu.Initialize();
    }
  }

  public override void onEndScene() => this.guild0282menu.onEndScene();

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Scene.\u003ConEndSceneAsync\u003Ec__Iterator787()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override IEnumerator onDestroySceneAsync()
  {
    GuildUtil.gvgPopupState = GuildUtil.GvGPopupState.None;
    GuildUtil.gvgDeckAttack = (GvgDeck) null;
    GuildUtil.gvgDeckDefense = (GvgDeck) null;
    GuildUtil.gvgFriendDefense = (GvgReinforcement) null;
    return base.onDestroySceneAsync();
  }
}
