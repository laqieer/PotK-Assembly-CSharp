// Decompiled with JetBrains decompiler
// Type: Bugu0051Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0051Scene : NGSceneBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  public Bugu0051Menu menu;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_1", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0051Scene.\u003ConInitSceneAsync\u003Ec__Iterator300()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
  }
}
