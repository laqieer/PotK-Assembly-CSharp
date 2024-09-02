// Decompiled with JetBrains decompiler
// Type: BattleUI02Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class BattleUI02Scene : BattleSceneBase
{
  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI02Scene.\u003ConInitSceneAsync\u003Ec__Iterator73D()
    {
      \u003C\u003Ef__this = this
    };
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
    BattleUI02Scene.\u003ConDestroySceneAsync\u003Ec__Iterator73E asyncCIterator73E = new BattleUI02Scene.\u003ConDestroySceneAsync\u003Ec__Iterator73E();
    return (IEnumerator) asyncCIterator73E;
  }
}
