﻿// Decompiled with JetBrains decompiler
// Type: Unit00487Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00487Scene : NGSceneBase
{
  public Unit00487Menu menu487;
  protected bool isInit;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00487Scene.\u003ConInitSceneAsync\u003Ec__Iterator2E0()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static void changeScene(bool stack, PlayerUnit basePlayerUnit, PlayerUnit[] materialUnits)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_7", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) materialUnits);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00487Scene.\u003ConStartSceneAsync\u003Ec__Iterator2E1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit basePlayerUnit, PlayerUnit[] materialUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00487Scene.\u003ConStartSceneAsync\u003Ec__Iterator2E2()
    {
      basePlayerUnit = basePlayerUnit,
      materialUnits = materialUnits,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EmaterialUnits = materialUnits,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene()
  {
    Persist.sortOrder.Flush();
    UnitDetailIcon.ClearCache();
  }
}
