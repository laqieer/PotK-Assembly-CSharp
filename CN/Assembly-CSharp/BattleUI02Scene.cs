// Decompiled with JetBrains decompiler
// Type: BattleUI02Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class BattleUI02Scene : BattleSceneBase
{
  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI02Scene.\u003ConInitSceneAsync\u003Ec__Iterator887()
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
    BattleUI02Scene.\u003ConDestroySceneAsync\u003Ec__Iterator888 asyncCIterator888 = new BattleUI02Scene.\u003ConDestroySceneAsync\u003Ec__Iterator888();
    return (IEnumerator) asyncCIterator888;
  }
}
