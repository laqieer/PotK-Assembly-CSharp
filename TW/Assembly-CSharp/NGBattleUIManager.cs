// Decompiled with JetBrains decompiler
// Type: NGBattleUIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class NGBattleUIManager : BattleManagerBase
{
  public BattleUIController controller;
  public BattleStateController stateController;

  [DebuggerHidden]
  public override IEnumerator initialize(GameCore.BattleInfo battleInfo, BE env_ = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleUIManager.\u003Cinitialize\u003Ec__IteratorAB0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator cleanup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleUIManager.\u003Ccleanup\u003Ec__IteratorAB1()
    {
      \u003C\u003Ef__this = this
    };
  }
}
