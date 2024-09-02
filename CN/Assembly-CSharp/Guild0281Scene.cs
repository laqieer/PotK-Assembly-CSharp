// Decompiled with JetBrains decompiler
// Type: Guild0281Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
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
    return (IEnumerator) new Guild0281Scene.\u003ConStartSceneAsync\u003Ec__Iterator693()
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
        this.guild0281Menu.PlayTweens(Guild0281Menu.OTHER_TO_GUILDTOP);
        this.guild0281Menu.InitializeGuildTop();
        break;
      case Guild0281Menu.SceneType.HQTop:
        this.guild0281Menu.PlayTweens(Guild0281Menu.OTHER_TO_HQTOP);
        this.guild0281Menu.InitializeHQTop();
        break;
    }
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
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
    return (IEnumerator) new Guild0281Scene.\u003ConEndSceneAsync\u003Ec__Iterator694()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onDestroySceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Scene.\u003ConDestroySceneAsync\u003Ec__Iterator695()
    {
      \u003C\u003Ef__this = this
    };
  }
}
