// Decompiled with JetBrains decompiler
// Type: Friend00820Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00820Scene : NGSceneBase
{
  [SerializeField]
  private Friend00820Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00820Scene.\u003ConStartSceneAsync\u003Ec__Iterator43B()
    {
      \u003C\u003Ef__this = this
    };
  }
}
