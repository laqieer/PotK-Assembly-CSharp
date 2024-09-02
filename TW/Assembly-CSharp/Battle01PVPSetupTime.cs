// Decompiled with JetBrains decompiler
// Type: Battle01PVPSetupTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PVPSetupTime : BattleMonoBehaviour
{
  [SerializeField]
  private SpriteNumber setupTime;
  private BL.BattleModified<BL.StructValue<int>> timeLimitModified;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPSetupTime.\u003CStart_Battle\u003Ec__Iterator951()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    if (this.battleManager.gameEngine == null || !this.timeLimitModified.isChangedOnce())
      return;
    this.setupTime.setNumber(this.timeLimitModified.value.value);
  }
}
