﻿// Decompiled with JetBrains decompiler
// Type: Unit05422Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit05422Scene : NGSceneBase
{
  public Unit05422Menu menu;

  public static void changeScene(bool stack, PlayerUnit playerUnit)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_2_2", (stack ? 1 : 0) != 0, (object) playerUnit);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit playerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05422Scene.\u003ConStartSceneAsync\u003Ec__Iterator76A()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }
}
