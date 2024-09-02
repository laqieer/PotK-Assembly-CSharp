// Decompiled with JetBrains decompiler
// Type: Unit00499Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00499Scene : NGSceneBase
{
  public Unit00499Menu menu;

  public static void changeScene(bool stack, PlayerUnit playerUnit, Unit00499Scene.Mode mode)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_9_9", (stack ? 1 : 0) != 0, (object) playerUnit, (object) mode);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Scene.\u003ConStartSceneAsync\u003Ec__Iterator2FD()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit playerUnit, Unit00499Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Scene.\u003ConStartSceneAsync\u003Ec__Iterator2FE()
    {
      mode = mode,
      playerUnit = playerUnit,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene() => this.menu.EndTweensMaterialQuestInfo(true);

  public enum Mode
  {
    Evolution,
    EarthEvolution,
    Transmigration,
  }
}
