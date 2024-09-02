// Decompiled with JetBrains decompiler
// Type: Bugu0551Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Bugu0551Scene.\u003ConInitSceneAsync\u003Ec__Iterator784()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0551Scene.\u003ConStartSceneAsync\u003Ec__Iterator785()
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
