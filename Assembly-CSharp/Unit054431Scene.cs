// Decompiled with JetBrains decompiler
// Type: Unit054431Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;

public class Unit054431Scene : NGSceneBase
{
  public Unit054431Menu menu;
  private UnitMenuBase currentMenu;
  private bool isInit = true;

  public static void ChangeScene(bool stack, Unit004431Menu.Param sendParam) => Singleton<NGSceneManager>.GetInstance().changeScene("unit054_4_3_1", (stack ? 1 : 0) != 0, (object) Unit00468Scene.Mode.Unit004431, (object) sendParam);

  public IEnumerator onStartSceneAsync(
    Unit00468Scene.Mode mode,
    Unit004431Menu.Param sendParam)
  {
    Unit054431Scene unit054431Scene = this;
    Player player = SMManager.Get<Player>();
    PlayerUnit[] playerUnits1 = SMManager.Get<PlayerUnit[]>();
    IEnumerator e;
    if (!unit054431Scene.isInit)
    {
      // ISSUE: reference to a compiler-generated method
      PlayerUnit[] playerUnits2 = unit054431Scene.menu.sendParam.gearKindId == 7 || unit054431Scene.menu.sendParam.gearKindId == 10 ? ((IEnumerable<PlayerUnit>) playerUnits1).Where<PlayerUnit>((Func<PlayerUnit, bool>) (v => v.unit.IsNormalUnit)).ToArray<PlayerUnit>() : ((IEnumerable<PlayerUnit>) playerUnits1).Where<PlayerUnit>(new Func<PlayerUnit, bool>(unit054431Scene.\u003ConStartSceneAsync\u003Eb__4_1)).ToArray<PlayerUnit>();
      e = unit054431Scene.menu.UpdateInfoAndScroll(playerUnits2);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else
    {
      e = unit054431Scene.menu.Init(player, playerUnits1, sendParam, true);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      unit054431Scene.isInit = false;
    }
  }
}
