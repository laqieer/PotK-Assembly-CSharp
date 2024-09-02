// Decompiled with JetBrains decompiler
// Type: Battle01StopAutoBattleButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Battle01StopAutoBattleButton.\u003CStart_Original\u003Ec__Iterator71C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable || this.env.core.phaseState.state != BL.Phase.player && this.env.core.phaseState.state != BL.Phase.enemy && this.env.core.phaseState.state != BL.Phase.neutral)
      return;
    this.env.core.isAutoBattle.value = false;
  }
}
