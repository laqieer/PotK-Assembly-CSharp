// Decompiled with JetBrains decompiler
// Type: Battle01StopAutoBattleButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01StopAutoBattleButton : NGBattleMenuBase
{
  private GameObject popupPrefab;

  [DebuggerHidden]
  protected override IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01StopAutoBattleButton.\u003CStart_Original\u003Ec__Iterator92E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable || this.env.core.phaseState.state != BL.Phase.player && this.env.core.phaseState.state != BL.Phase.enemy && this.env.core.phaseState.state != BL.Phase.neutral)
      return;
    this.battleManager.popupOpen(this.popupPrefab);
  }
}
