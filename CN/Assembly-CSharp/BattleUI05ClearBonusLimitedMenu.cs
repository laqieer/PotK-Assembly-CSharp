// Decompiled with JetBrains decompiler
// Type: BattleUI05ClearBonusLimitedMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new BattleUI05ClearBonusLimitedMenu.\u003CInit\u003Ec__Iterator897()
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
    return (IEnumerator) new BattleUI05ClearBonusLimitedMenu.\u003CRun\u003Ec__Iterator898()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateBonusObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusLimitedMenu.\u003CCreateBonusObject\u003Ec__Iterator899()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetColorBackground()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusLimitedMenu.\u003CSetColorBackground\u003Ec__Iterator89A()
    {
      \u003C\u003Ef__this = this
    };
  }
}
