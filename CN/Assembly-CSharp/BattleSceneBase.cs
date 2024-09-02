// Decompiled with JetBrains decompiler
// Type: BattleSceneBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class BattleSceneBase : NGSceneBase
{
  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleSceneBase.\u003ConInitSceneAsync\u003Ec__Iterator875()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onSceneInitialized() => Singleton<NGBattleManager>.GetInstance();

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleSceneBase.\u003ConEndSceneAsync\u003Ec__Iterator876()
    {
      \u003C\u003Ef__this = this
    };
  }
}
