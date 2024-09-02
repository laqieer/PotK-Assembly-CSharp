// Decompiled with JetBrains decompiler
// Type: BattleUI05HardModeOpenMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05HardModeOpenMenu : ResultMenuBase
{
  private GameObject popupObject;
  private string title;
  private string message;

  public bool ToNext { set; get; }

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05HardModeOpenMenu.\u003CInit\u003Ec__Iterator96D()
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
    return (IEnumerator) new BattleUI05HardModeOpenMenu.\u003CRun\u003Ec__Iterator96E()
    {
      \u003C\u003Ef__this = this
    };
  }
}
