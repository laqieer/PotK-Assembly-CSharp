// Decompiled with JetBrains decompiler
// Type: NGBattleUIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class NGBattleUIManager : BattleManagerBase
{
  public BattleUIController controller;
  public BattleStateController stateController;

  [DebuggerHidden]
  public override IEnumerator initialize(BattleInfo battleInfo, BE env_ = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleUIManager.\u003Cinitialize\u003Ec__Iterator85D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator cleanup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleUIManager.\u003Ccleanup\u003Ec__Iterator85E()
    {
      \u003C\u003Ef__this = this
    };
  }
}
