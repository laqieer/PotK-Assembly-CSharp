// Decompiled with JetBrains decompiler
// Type: Unit00486Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit00486Scene : NGSceneBase
{
  public Unit00486Menu menu;
  protected bool isInit;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00486Scene.\u003ConInitSceneAsync\u003Ec__Iterator389()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static void changeScene(bool stack, PlayerUnit basePlayerUnit, PlayerUnit[] materialUnits)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_8_6", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) materialUnits);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00486Scene.\u003ConStartSceneAsync\u003Ec__Iterator38A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator onStartSceneAsync(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00486Scene.\u003ConStartSceneAsync\u003Ec__Iterator38B()
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
