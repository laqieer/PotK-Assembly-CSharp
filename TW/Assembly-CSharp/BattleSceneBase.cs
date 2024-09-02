// Decompiled with JetBrains decompiler
// Type: BattleSceneBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class BattleSceneBase : NGSceneBase
{
  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleSceneBase.\u003ConInitSceneAsync\u003Ec__Iterator941()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onSceneInitialized() => Singleton<NGBattleManager>.GetInstance();

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleSceneBase.\u003ConEndSceneAsync\u003Ec__Iterator942()
    {
      \u003C\u003Ef__this = this
    };
  }
}
