// Decompiled with JetBrains decompiler
// Type: Battle01PVPSetupTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Battle01PVPSetupTime.\u003CStart_Battle\u003Ec__Iterator884()
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
