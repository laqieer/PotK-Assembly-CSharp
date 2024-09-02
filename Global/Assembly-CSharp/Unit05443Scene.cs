// Decompiled with JetBrains decompiler
// Type: Unit05443Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit05443Scene : NGSceneBase
{
  public Unit05443Menu menu;
  private bool targetGear_favorite;
  private static bool block;

  public static void changeScene(bool stack, PlayerItem choiceGear)
  {
    Unit05443Scene.block = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_4_3", (stack ? 1 : 0) != 0, (object) choiceGear);
  }

  public static void changeSceneLimited(bool stack, PlayerItem choiceGear)
  {
    Unit05443Scene.block = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_4_3", (stack ? 1 : 0) != 0, (object) choiceGear);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerItem choiceGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05443Scene.\u003ConStartSceneAsync\u003Ec__Iterator629()
    {
      choiceGear = choiceGear,
      \u003C\u0024\u003EchoiceGear = choiceGear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05443Scene.\u003ConEndSceneAsync\u003Ec__Iterator62A()
    {
      \u003C\u003Ef__this = this
    };
  }
}
