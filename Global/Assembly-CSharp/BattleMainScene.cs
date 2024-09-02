// Decompiled with JetBrains decompiler
// Type: BattleMainScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    BattleMainScene.\u003ConInitSceneAsync\u003Ec__Iterator833 asyncCIterator833 = new BattleMainScene.\u003ConInitSceneAsync\u003Ec__Iterator833();
    return (IEnumerator) asyncCIterator833;
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
    BattleMainScene.\u003ConDestroySceneAsync\u003Ec__Iterator834 asyncCIterator834 = new BattleMainScene.\u003ConDestroySceneAsync\u003Ec__Iterator834();
    return (IEnumerator) asyncCIterator834;
  }
}
