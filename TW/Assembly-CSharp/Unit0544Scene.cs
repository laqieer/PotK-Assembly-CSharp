// Decompiled with JetBrains decompiler
// Type: Unit0544Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit0544Scene : NGSceneBase
{
  public Unit0544Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Unit0544Scene.\u003ConInitSceneAsync\u003Ec__Iterator834 asyncCIterator834 = new Unit0544Scene.\u003ConInitSceneAsync\u003Ec__Iterator834();
    return (IEnumerator) asyncCIterator834;
  }

  public static void ChangeScene(bool stack, PlayerUnit basePlayerUnit, int changeGearIndex)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_4", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) changeGearIndex);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit basePlayerUnit, int changeGearIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0544Scene.\u003ConStartSceneAsync\u003Ec__Iterator835()
    {
      basePlayerUnit = basePlayerUnit,
      changeGearIndex = changeGearIndex,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EchangeGearIndex = changeGearIndex,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void onStartScene(PlayerUnit basePlayerUnit, int changeGearIndex)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isActiveHeader = true;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = true;
  }

  public override void onEndScene()
  {
    Persist.sortOrder.Flush();
    this.menu.onEndScene();
    ItemIcon.ClearCache();
  }
}
