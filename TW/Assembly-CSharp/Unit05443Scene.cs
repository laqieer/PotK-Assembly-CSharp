﻿// Decompiled with JetBrains decompiler
// Type: Unit05443Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit05443Scene : NGSceneBase
{
  public Unit05443Menu menu;
  private bool targetGear_favorite;
  private static bool block;

  public static void changeScene(bool stack, ItemInfo choiceGear)
  {
    Unit05443Scene.block = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_4_3", (stack ? 1 : 0) != 0, (object) choiceGear);
  }

  public static void changeSceneLimited(bool stack, ItemInfo choiceGear)
  {
    Unit05443Scene.block = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_4_3", (stack ? 1 : 0) != 0, (object) choiceGear);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ItemInfo choiceGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05443Scene.\u003ConStartSceneAsync\u003Ec__Iterator837()
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
    return (IEnumerator) new Unit05443Scene.\u003ConEndSceneAsync\u003Ec__Iterator838()
    {
      \u003C\u003Ef__this = this
    };
  }
}
