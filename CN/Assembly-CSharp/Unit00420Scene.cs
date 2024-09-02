// Decompiled with JetBrains decompiler
// Type: Unit00420Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00420Scene : NGSceneBase
{
  [SerializeField]
  private Unit00420Menu menu;

  public static void changeScene(
    bool stack,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_20", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) materialPlayerUnits);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit basePlayerUnit, PlayerUnit[] materialPlayerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00420Scene.\u003ConStartSceneAsync\u003Ec__Iterator2BE()
    {
      basePlayerUnit = basePlayerUnit,
      materialPlayerUnits = materialPlayerUnits,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EmaterialPlayerUnits = materialPlayerUnits,
      \u003C\u003Ef__this = this
    };
  }
}
