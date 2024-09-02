// Decompiled with JetBrains decompiler
// Type: Battle01StopAutoBattleButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Battle01StopAutoBattleButton.\u003CStart_Original\u003Ec__Iterator863()
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
