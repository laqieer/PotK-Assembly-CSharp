﻿// Decompiled with JetBrains decompiler
// Type: Battle01PVPSetupTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private PVPManager _pvpManager;

  private PVPManager pvpManager
  {
    get
    {
      if (Object.op_Equality((Object) this._pvpManager, (Object) null))
        this._pvpManager = Singleton<PVPManager>.GetInstanceOrNull();
      return this._pvpManager;
    }
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPSetupTime.\u003CStart_Battle\u003Ec__Iterator73A()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    if (Object.op_Equality((Object) this.pvpManager, (Object) null) || !this.timeLimitModified.isChangedOnce())
      return;
    this.setupTime.setNumber(this.timeLimitModified.value.value);
  }
}
