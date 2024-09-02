// Decompiled with JetBrains decompiler
// Type: Mypage00117Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Mypage00117Scene.\u003ConStartSceneAsync\u003Ec__Iterator1C0()
    {
      \u003C\u003Ef__this = this
    };
  }
}
