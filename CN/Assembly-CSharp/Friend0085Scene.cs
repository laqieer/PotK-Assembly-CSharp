// Decompiled with JetBrains decompiler
// Type: Friend0085Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Friend0085Scene.\u003ConInitSceneAsync\u003Ec__Iterator4DA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0085Scene.\u003ConStartSceneAsync\u003Ec__Iterator4DB()
    {
      \u003C\u003Ef__this = this
    };
  }
}
