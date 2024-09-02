// Decompiled with JetBrains decompiler
// Type: Friend0085Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Friend0085Scene.\u003ConInitSceneAsync\u003Ec__Iterator529()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0085Scene.\u003ConStartSceneAsync\u003Ec__Iterator52A()
    {
      \u003C\u003Ef__this = this
    };
  }
}
