// Decompiled with JetBrains decompiler
// Type: Guild0281Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0281Scene : NGSceneBase
{
  private bool changeScene;
  [SerializeField]
  private Guild0281Menu guild0281Menu;
  private static Guild0281Menu menu;
  private bool? restartGvg;

  public static void ChangeSceneBattleResultBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guild028_1", false, (object) false, (object) Guild0281Menu.SceneType.GuildTop);
  }

  public static void ChangeSceneGuildTop(bool establishOrJoinGuild = false, Guild0281Menu menu = null)
  {
    if (establishOrJoinGuild && Persist.guildSetting.Exists)
    {
      Persist.guildSetting.Data.reset();
      Persist.guildSetting.Flush();
    }
    if (Object.op_Equality((Object) menu, (Object) null))
    {
      if (Object.op_Inequality((Object) Guild0281Scene.menu, (Object) null))
      {
        Guild0281Scene.menu.EndAnimation();
        Guild0281Scene.menu.sceneType = Guild0281Menu.SceneType.NONE;
      }
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_1", true, (object) establishOrJoinGuild, (object) Guild0281Menu.SceneType.GuildTop);
    }
    else
    {
      menu.PlayTweens(Guild0281Menu.HQTOP_TO_GUILDTOP);
      menu.InitializeGuildTop();
    }
  }

  public static void ChangeSceneHQTop(bool establishOrJoinGuild = false, Guild0281Menu menu = null)
  {
    if (!PlayerAffiliation.Current.guild.appearance.GuildHQOpen())
      Guild0281Scene.ChangeSceneGuildTop();
    else if (Object.op_Equality((Object) menu, (Object) null))
    {
      if (Object.op_Inequality((Object) Guild0281Scene.menu, (Object) null))
      {
        Guild0281Scene.menu.EndAnimation();
        Guild0281Scene.menu.sceneType = Guild0281Menu.SceneType.NONE;
      }
      Singleton<NGSceneManager>.GetInstance().changeScene("guild028_1", true, (object) establishOrJoinGuild, (object) Guild0281Menu.SceneType.HQTop);
    }
    else
    {
      menu.PlayTweens(Guild0281Menu.GUILDTOP_TO_HQTOP);
      menu.InitializeHQTop();
    }
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool establishOrJoinGuild, Guild0281Menu.SceneType type)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Scene.\u003ConStartSceneAsync\u003Ec__Iterator6EA()
    {
      type = type,
      establishOrJoinGuild = establishOrJoinGuild,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003EestablishOrJoinGuild = establishOrJoinGuild,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(bool establishOrJoinGuild, Guild0281Menu.SceneType type)
  {
    if (this.guild0281Menu.sceneType != Guild0281Menu.SceneType.NONE)
      type = this.guild0281Menu.sceneType;
    if (this.changeScene)
      return;
    switch (type)
    {
      case Guild0281Menu.SceneType.GuildTop:
        this.guild0281Menu.PlayTweens(Guild0281Menu.OTHER_TO_GUILDTOP, new EventDelegate.Callback(((NGSceneBase) this).onTweenFinished));
        this.guild0281Menu.InitializeGuildTop();
        this.guild0281Menu.checkOpenBattleEntryPopup();
        break;
      case Guild0281Menu.SceneType.HQTop:
        this.guild0281Menu.PlayTweens(Guild0281Menu.OTHER_TO_HQTOP, new EventDelegate.Callback(((NGSceneBase) this).onTweenFinished));
        this.guild0281Menu.InitializeHQTop();
        break;
    }
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    if (this.guild0281Menu.GVGResult == null)
      return;
    this.StartCoroutine(this.guild0281Menu.GuildBattleResult());
  }

  public override void onEndScene()
  {
    if (this.changeScene)
      return;
    this.guild0281Menu.onEndScene();
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Scene.\u003ConEndSceneAsync\u003Ec__Iterator6EB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onDestroySceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Scene.\u003ConDestroySceneAsync\u003Ec__Iterator6EC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator whetherResumeGvg()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Scene.\u003CwhetherResumeGvg\u003Ec__Iterator6ED()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ResumeGvg()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Guild0281Scene.\u003CResumeGvg\u003Ec__Iterator6EE resumeGvgCIterator6Ee = new Guild0281Scene.\u003CResumeGvg\u003Ec__Iterator6EE();
    return (IEnumerator) resumeGvgCIterator6Ee;
  }

  [DebuggerHidden]
  private IEnumerator getGvgBattleIDFromServer(Action<string> action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Scene.\u003CgetGvgBattleIDFromServer\u003Ec__Iterator6EF()
    {
      action = action,
      \u003C\u0024\u003Eaction = action
    };
  }

  [DebuggerHidden]
  private IEnumerator forceCloseGvg(System.Action action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Scene.\u003CforceCloseGvg\u003Ec__Iterator6F0()
    {
      action = action,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }
}
