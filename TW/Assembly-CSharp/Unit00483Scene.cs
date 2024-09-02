// Decompiled with JetBrains decompiler
// Type: Unit00483Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00483Scene : NGSceneBase
{
  public Unit00483Menu menu;

  public static void changeScene(
    bool stack,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_3", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) materialPlayerUnits);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00483Scene.\u003ConStartSceneAsync\u003Ec__Iterator380()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit basePlayerUnit, PlayerUnit[] materialPlayerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00483Scene.\u003ConStartSceneAsync\u003Ec__Iterator381()
    {
      basePlayerUnit = basePlayerUnit,
      materialPlayerUnits = materialPlayerUnits,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EmaterialPlayerUnits = materialPlayerUnits,
      \u003C\u003Ef__this = this
    };
  }
}
