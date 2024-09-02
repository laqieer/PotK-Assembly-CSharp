// Decompiled with JetBrains decompiler
// Type: BattleUI05ClearBonusMenu
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
public class BattleUI05ClearBonusMenu : ResultMenuBase
{
  private List<BattleStageClear> Rewards;
  private GameObject bonus;
  [SerializeField]
  public GameObject touch2NextNoFun;
  public Touch2NextAuto touchScript;

  private void Awake()
  {
    if (Object.op_Implicit((Object) this.touch2NextNoFun))
      this.touch2NextNoFun.SetActive(false);
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusMenu.\u003CInit\u003Ec__Iterator968()
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
    return (IEnumerator) new BattleUI05ClearBonusMenu.\u003CRun\u003Ec__Iterator969()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateBonusObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusMenu.\u003CCreateBonusObject\u003Ec__Iterator96A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetColorBackground()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusMenu.\u003CSetColorBackground\u003Ec__Iterator96B()
    {
      \u003C\u003Ef__this = this
    };
  }
}
