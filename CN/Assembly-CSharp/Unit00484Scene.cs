// Decompiled with JetBrains decompiler
// Type: Unit00484Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00484Scene : Unit00483Scene
{
  public Unit00484Menu menu484;

  public static void changeScene(
    bool stack,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits,
    Unit00468Scene.Mode mode)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_4", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) materialPlayerUnits, (object) mode);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits,
    Unit00468Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00484Scene.\u003ConStartSceneAsync\u003Ec__Iterator344()
    {
      basePlayerUnit = basePlayerUnit,
      materialPlayerUnits = materialPlayerUnits,
      mode = mode,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EmaterialPlayerUnits = materialPlayerUnits,
      \u003C\u0024\u003Emode = mode,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits,
    Unit00468Scene.Mode mode)
  {
    if (mode == Unit00468Scene.Mode.Unit0048)
    {
      Singleton<TutorialRoot>.GetInstance().ShowAdvice("unit004_8_3");
    }
    else
    {
      if (mode != Unit00468Scene.Mode.Unit00481)
        return;
      Singleton<TutorialRoot>.GetInstance().ShowAdvice("unit004_8_4_reinforce");
    }
  }
}
