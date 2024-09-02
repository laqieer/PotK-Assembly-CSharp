// Decompiled with JetBrains decompiler
// Type: Unit05468Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Unit05468Scene.\u003ConInitSceneAsync\u003Ec__Iterator779 asyncCIterator779 = new Unit05468Scene.\u003ConInitSceneAsync\u003Ec__Iterator779();
    return (IEnumerator) asyncCIterator779;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05468Scene.\u003ConStartSceneAsync\u003Ec__Iterator77A()
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
