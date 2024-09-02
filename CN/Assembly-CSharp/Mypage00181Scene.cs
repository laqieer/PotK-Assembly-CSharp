// Decompiled with JetBrains decompiler
// Type: Mypage00181Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Mypage00181Scene : NGSceneBase
{
  [SerializeField]
  private Mypage00181Menu menu;

  public Mypage00181Menu Menu
  {
    get => this.menu;
    set => this.menu = value;
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00181Scene.\u003ConInitSceneAsync\u003Ec__Iterator1AA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00181Scene.\u003ConStartSceneAsync\u003Ec__Iterator1AB()
    {
      \u003C\u003Ef__this = this
    };
  }
}
