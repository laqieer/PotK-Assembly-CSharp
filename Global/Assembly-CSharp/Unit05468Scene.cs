// Decompiled with JetBrains decompiler
// Type: Unit05468Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit05468Scene : NGSceneBase
{
  [SerializeField]
  private Unit05468Menu menu;
  private bool isInit = true;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_6_8", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Unit05468Scene.\u003ConInitSceneAsync\u003Ec__Iterator632 asyncCIterator632 = new Unit05468Scene.\u003ConInitSceneAsync\u003Ec__Iterator632();
    return (IEnumerator) asyncCIterator632;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05468Scene.\u003ConStartSceneAsync\u003Ec__Iterator633()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
  }

  public override void onEndScene()
  {
  }
}
