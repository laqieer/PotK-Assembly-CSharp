// Decompiled with JetBrains decompiler
// Type: NGBattleAIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using AI.Logic;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class NGBattleAIManager : BattleManagerBase
{
  public AILogicBase ai;

  [DebuggerHidden]
  public override IEnumerator initialize(GameCore.BattleInfo battleInfo, BE env_ = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleAIManager.\u003Cinitialize\u003Ec__IteratorAA6()
    {
      env_ = env_,
      \u003C\u0024\u003Eenv_ = env_,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator cleanup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleAIManager.\u003Ccleanup\u003Ec__IteratorAA7()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void clearCache()
  {
    if (!(this.ai is LispAILogic ai))
      return;
    ai.clearCache();
  }
}
