// Decompiled with JetBrains decompiler
// Type: Friend0085Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend0085Scene : NGSceneBase
{
  [SerializeField]
  private Friend0085Menu menu;
  private PlayerFriend[] recivedFriend;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0085Scene.\u003ConInitSceneAsync\u003Ec__Iterator43F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0085Scene.\u003ConStartSceneAsync\u003Ec__Iterator440()
    {
      \u003C\u003Ef__this = this
    };
  }
}
