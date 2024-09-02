// Decompiled with JetBrains decompiler
// Type: Unit00422Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00422Scene : NGSceneBase
{
  public Unit00422Menu menu;

  public static void changeScene(bool stack, PlayerUnit playerUnit)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2_2", (stack ? 1 : 0) != 0, (object) playerUnit);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit playerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00422Scene.\u003ConStartSceneAsync\u003Ec__Iterator2FE()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }
}
