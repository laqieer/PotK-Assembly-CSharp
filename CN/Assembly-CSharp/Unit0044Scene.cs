// Decompiled with JetBrains decompiler
// Type: Unit0044Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit0044Scene : NGSceneBase
{
  public Unit0044Menu menu;
  public UIPanel scrollPanel;
  public UIWidget scrollBarWidget;
  private bool isInit = true;

  public static void changeScene(bool stack, PlayerUnit basePlayerUnit, int changeGearIndex)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_4", (stack ? 1 : 0) != 0, (object) basePlayerUnit, (object) changeGearIndex);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Scene.\u003ConStartSceneAsync\u003Ec__Iterator2CF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnit basePlayerUnit, int changeGearIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Scene.\u003ConStartSceneAsync\u003Ec__Iterator2D0()
    {
      basePlayerUnit = basePlayerUnit,
      changeGearIndex = changeGearIndex,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EchangeGearIndex = changeGearIndex,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene()
  {
    Persist.sortOrder.Flush();
    UnitIcon.ClearCache();
  }
}
