// Decompiled with JetBrains decompiler
// Type: Mypage00117Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Mypage00117Scene : NGSceneBase
{
  [SerializeField]
  private Mypage00117Menu menu;
  private Startup0008Data data;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00117Scene.\u003ConStartSceneAsync\u003Ec__Iterator15C()
    {
      \u003C\u003Ef__this = this
    };
  }
}
