// Decompiled with JetBrains decompiler
// Type: BattleUI05ClearBonusLimitedMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05ClearBonusLimitedMenu : ResultMenuBase
{
  private List<BattleStageClear> Rewards;
  private GameObject bonus;

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusLimitedMenu.\u003CInit\u003Ec__Iterator964()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusLimitedMenu.\u003CRun\u003Ec__Iterator965()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateBonusObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusLimitedMenu.\u003CCreateBonusObject\u003Ec__Iterator966()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetColorBackground()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusLimitedMenu.\u003CSetColorBackground\u003Ec__Iterator967()
    {
      \u003C\u003Ef__this = this
    };
  }
}
