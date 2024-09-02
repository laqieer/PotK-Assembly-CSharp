// Decompiled with JetBrains decompiler
// Type: BattleMainScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    BattleMainScene.\u003ConInitSceneAsync\u003Ec__Iterator9A2 asyncCIterator9A2 = new BattleMainScene.\u003ConInitSceneAsync\u003Ec__Iterator9A2();
    return (IEnumerator) asyncCIterator9A2;
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
    BattleMainScene.\u003ConDestroySceneAsync\u003Ec__Iterator9A3 asyncCIterator9A3 = new BattleMainScene.\u003ConDestroySceneAsync\u003Ec__Iterator9A3();
    return (IEnumerator) asyncCIterator9A3;
  }
}
