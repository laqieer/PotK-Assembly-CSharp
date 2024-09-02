// Decompiled with JetBrains decompiler
// Type: BattleUI55Continue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI55Continue : ResultMenuBase
{
  public bool isReset;
  private bool isShowResetPopup;
  private GameObject popup1;
  private GameObject popup2;

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55Continue.\u003CInit\u003Ec__Iterator9B2()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55Continue.\u003CRun\u003Ec__Iterator9B3()
    {
      \u003C\u003Ef__this = this
    };
  }
}
