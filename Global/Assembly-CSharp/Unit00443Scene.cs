﻿// Decompiled with JetBrains decompiler
// Type: Unit00443Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00443Scene : NGSceneBase
{
  public Unit00443Menu menu;
  private bool targetGear_favorite;
  private static bool block;

  public static void changeScene(bool stack, PlayerItem choiceGear)
  {
    Unit00443Scene.block = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_4_3", (stack ? 1 : 0) != 0, (object) choiceGear);
  }

  public static void changeSceneLimited(bool stack, PlayerItem choiceGear)
  {
    Unit00443Scene.block = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_4_3", (stack ? 1 : 0) != 0, (object) choiceGear);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerItem choiceGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00443Scene.\u003ConStartSceneAsync\u003Ec__Iterator272()
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
    return (IEnumerator) new Unit00443Scene.\u003ConEndSceneAsync\u003Ec__Iterator273()
    {
      \u003C\u003Ef__this = this
    };
  }
}
