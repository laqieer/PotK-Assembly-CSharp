// Decompiled with JetBrains decompiler
// Type: BattleMainScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class BattleMainScene : BattleSceneBase
{
  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleMainScene.\u003ConInitSceneAsync\u003Ec__IteratorA77 asyncCIteratorA77 = new BattleMainScene.\u003ConInitSceneAsync\u003Ec__IteratorA77();
    return (IEnumerator) asyncCIteratorA77;
  }

  public void onStartScene()
  {
    Singleton<CommonRoot>.GetInstance().isActiveBackground3DCamera = false;
  }

  public override void onEndScene()
  {
    Singleton<CommonRoot>.GetInstance().isActiveBackground3DCamera = true;
  }

  [DebuggerHidden]
  public override IEnumerator onDestroySceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleMainScene.\u003ConDestroySceneAsync\u003Ec__IteratorA78 asyncCIteratorA78 = new BattleMainScene.\u003ConDestroySceneAsync\u003Ec__IteratorA78();
    return (IEnumerator) asyncCIteratorA78;
  }
}
