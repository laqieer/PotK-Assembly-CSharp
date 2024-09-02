// Decompiled with JetBrains decompiler
// Type: Bugu0551Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0551Scene : NGSceneBase
{
  [SerializeField]
  private Bugu0551Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu055_1", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0551Scene.\u003ConInitSceneAsync\u003Ec__Iterator84B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0551Scene.\u003ConStartSceneAsync\u003Ec__Iterator84C()
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
