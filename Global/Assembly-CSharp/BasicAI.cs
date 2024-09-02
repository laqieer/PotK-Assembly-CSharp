// Decompiled with JetBrains decompiler
// Type: BasicAI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using AI.Logic;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class BasicAI : BattleMonoBehaviour
{
  private LispAILogic ai = new LispAILogic();

  public AILogicBase aiLogic => (AILogicBase) this.ai;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BasicAI.\u003CStart_Battle\u003Ec__Iterator82C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadScript()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BasicAI.\u003CloadScript\u003Ec__Iterator82D()
    {
      \u003C\u003Ef__this = this
    };
  }
}
