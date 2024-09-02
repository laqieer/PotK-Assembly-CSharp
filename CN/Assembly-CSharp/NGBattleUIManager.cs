// Decompiled with JetBrains decompiler
// Type: NGBattleUIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new NGBattleUIManager.\u003Cinitialize\u003Ec__Iterator9D8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator cleanup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleUIManager.\u003Ccleanup\u003Ec__Iterator9D9()
    {
      \u003C\u003Ef__this = this
    };
  }
}
