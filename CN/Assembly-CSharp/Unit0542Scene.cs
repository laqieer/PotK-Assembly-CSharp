// Decompiled with JetBrains decompiler
// Type: Unit0542Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0542Scene : NGSceneBase
{
  public Unit0042Menu menu;
  protected static bool limited;
  protected bool init;

  public static void changeScene(bool stack, PlayerUnit playerUnit, PlayerUnit[] playerUnits)
  {
    Unit0542Scene.limited = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_2", (stack ? 1 : 0) != 0, (object) string.Empty, (object) playerUnit, (object) playerUnits);
  }

  public static void changeSceneFriendUnit(bool stack, string player_id)
  {
    Unit0542Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_2", (stack ? 1 : 0) != 0, (object) player_id, null, null);
  }

  public static void changeSceneEvolutionUnit(
    bool stack,
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits)
  {
    Unit0542Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_2", (stack ? 1 : 0) != 0, (object) string.Empty, (object) playerUnit, (object) playerUnits);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0542Scene.\u003ConInitSceneAsync\u003Ec__Iterator766()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    string player_id,
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0542Scene.\u003ConStartSceneAsync\u003Ec__Iterator767()
    {
      playerUnit = playerUnit,
      player_id = player_id,
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003Eplayer_id = player_id,
      \u003C\u0024\u003EplayerUnits = playerUnits,
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
    return (IEnumerator) new Unit0542Scene.\u003ConEndSceneAsync\u003Ec__Iterator768()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void oneFrameWait() => this.StartCoroutine(this._oneFrameWait());

  [DebuggerHidden]
  protected IEnumerator _oneFrameWait()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0542Scene.\u003C_oneFrameWait\u003Ec__Iterator769()
    {
      \u003C\u003Ef__this = this
    };
  }
}
