// Decompiled with JetBrains decompiler
// Type: BattleSceneBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class BattleSceneBase : NGSceneBase
{
  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleSceneBase.\u003ConInitSceneAsync\u003Ec__Iterator72B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onSceneInitialized() => Singleton<NGBattleManager>.GetInstance();

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleSceneBase.\u003ConEndSceneAsync\u003Ec__Iterator72C()
    {
      \u003C\u003Ef__this = this
    };
  }
}
