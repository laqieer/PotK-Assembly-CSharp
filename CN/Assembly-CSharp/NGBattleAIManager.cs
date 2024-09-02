// Decompiled with JetBrains decompiler
// Type: NGBattleAIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new NGBattleAIManager.\u003Cinitialize\u003Ec__Iterator9CE()
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
    return (IEnumerator) new NGBattleAIManager.\u003Ccleanup\u003Ec__Iterator9CF()
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
