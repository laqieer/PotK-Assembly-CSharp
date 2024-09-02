// Decompiled with JetBrains decompiler
// Type: BattleUI05HardModeOpenMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
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
  public override IEnumerator Init(BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05HardModeOpenMenu.\u003CInit\u003Ec__Iterator756()
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
    return (IEnumerator) new BattleUI05HardModeOpenMenu.\u003CRun\u003Ec__Iterator757()
    {
      \u003C\u003Ef__this = this
    };
  }
}
