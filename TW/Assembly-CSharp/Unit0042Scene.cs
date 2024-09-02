// Decompiled with JetBrains decompiler
// Type: Unit0042Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0042Scene : NGSceneBase
{
  public Unit0042Menu menu;
  protected static bool limited;
  protected bool init;
  private static bool isGuest;

  public static void changeScene(bool stack, PlayerUnit playerUnit, PlayerUnit[] playerUnits)
  {
    Unit0042Scene.isGuest = false;
    Unit0042Scene.limited = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) string.Empty, (object) playerUnit, (object) playerUnits);
  }

  public static void changeSceneGuestUnit(
    bool stack,
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits)
  {
    Unit0042Scene.isGuest = true;
    Unit0042Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) string.Empty, (object) playerUnit, (object) playerUnits);
  }

  public static void changeSceneFriendUnit(bool stack, string player_id)
  {
    Unit0042Scene.isGuest = false;
    Unit0042Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) player_id, null, null);
  }

  public static void changeSceneFriendUnit(bool stack, string player_id, PlayerUnit playerUnit)
  {
    Unit0042Scene.isGuest = false;
    Unit0042Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) player_id, (object) playerUnit, null);
  }

  public static void changeSceneEvolutionUnit(
    bool stack,
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits)
  {
    Unit0042Scene.isGuest = false;
    Unit0042Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) string.Empty, (object) playerUnit, (object) playerUnits);
  }

  public static void changeSceneGvgUnit(bool stack, PlayerUnit unit, PlayerUnit[] playerUnits)
  {
    Unit0042Scene.isGuest = false;
    Unit0042Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) unit, (object) playerUnits);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Scene.\u003ConInitSceneAsync\u003Ec__Iterator2EE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator onStartSceneAsync(
    string player_id,
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Scene.\u003ConStartSceneAsync\u003Ec__Iterator2EF()
    {
      player_id = player_id,
      playerUnit = playerUnit,
      playerUnits = playerUnits,
      \u003C\u0024\u003Eplayer_id = player_id,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator onStartSceneAsync(PlayerUnit unit, PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Scene.\u003ConStartSceneAsync\u003Ec__Iterator2F0()
    {
      playerUnits = playerUnits,
      unit = unit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene()
  {
    if (this.tweens == null)
      return;
    foreach (Behaviour tween in this.tweens)
      tween.enabled = false;
    this.tweenTimeoutTime = 10f;
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Scene.\u003ConEndSceneAsync\u003Ec__Iterator2F1()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void oneFrameWait() => this.StartCoroutine(this._oneFrameWait());

  [DebuggerHidden]
  protected IEnumerator _oneFrameWait()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Scene.\u003C_oneFrameWait\u003Ec__Iterator2F2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
