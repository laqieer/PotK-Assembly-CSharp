﻿// Decompiled with JetBrains decompiler
// Type: Unit054431Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit054431Scene : NGSceneBase
{
  public Unit054431Menu menu;
  private UnitMenuBase currentMenu;
  private bool isInit = true;

  public static void ChangeScene(bool stack, Unit004431Menu.Param sendParam)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_4_3_1", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit004431, (object) sendParam);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Unit00468Scene.Mode mode, Unit004431Menu.Param sendParam)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit054431Scene.\u003ConStartSceneAsync\u003Ec__Iterator62B()
    {
      sendParam = sendParam,
      \u003C\u0024\u003EsendParam = sendParam,
      \u003C\u003Ef__this = this
    };
  }
}
