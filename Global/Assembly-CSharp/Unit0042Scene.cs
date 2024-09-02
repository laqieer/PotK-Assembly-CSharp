﻿// Decompiled with JetBrains decompiler
// Type: Unit0042Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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

  public static void changeScene(bool stack, PlayerUnit playerUnit, PlayerUnit[] playerUnits)
  {
    Unit0042Scene.limited = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) string.Empty, (object) playerUnit, (object) playerUnits);
  }

  public static void changeSceneFriendUnit(bool stack, string player_id)
  {
    Unit0042Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) player_id, null, null);
  }

  public static void changeSceneEvolutionUnit(
    bool stack,
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits)
  {
    Unit0042Scene.limited = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2", (stack ? 1 : 0) != 0, (object) string.Empty, (object) playerUnit, (object) playerUnits);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Scene.\u003ConInitSceneAsync\u003Ec__Iterator254()
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
    return (IEnumerator) new Unit0042Scene.\u003ConStartSceneAsync\u003Ec__Iterator255()
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
    return (IEnumerator) new Unit0042Scene.\u003ConEndSceneAsync\u003Ec__Iterator256()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void oneFrameWait() => this.StartCoroutine(this._oneFrameWait());

  [DebuggerHidden]
  protected IEnumerator _oneFrameWait()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0042Scene.\u003C_oneFrameWait\u003Ec__Iterator257()
    {
      \u003C\u003Ef__this = this
    };
  }
}
