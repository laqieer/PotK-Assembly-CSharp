// Decompiled with JetBrains decompiler
// Type: Friend0086Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend0086Scene : NGSceneBase
{
  [SerializeField]
  private Friend0086Menu menu;
  [SerializeField]
  private GameObject Dir008_2;
  [SerializeField]
  private GameObject Dir008_6;
  private Friend0086Scene.Mode debugMode;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Scene.\u003ConStartSceneAsync\u003Ec__Iterator44D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerFriend friend, Friend0086Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend0086Scene.\u003ConStartSceneAsync\u003Ec__Iterator44E()
    {
      mode = mode,
      friend = friend,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u003Ef__this = this
    };
  }

  public enum Mode
  {
    Accept,
    Friend,
  }
}
