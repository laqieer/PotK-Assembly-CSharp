// Decompiled with JetBrains decompiler
// Type: BattleUI05HardModeOpenMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new BattleUI05HardModeOpenMenu.\u003CInit\u003Ec__Iterator8A0()
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
    return (IEnumerator) new BattleUI05HardModeOpenMenu.\u003CRun\u003Ec__Iterator8A1()
    {
      \u003C\u003Ef__this = this
    };
  }
}
