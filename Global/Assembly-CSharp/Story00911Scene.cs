// Decompiled with JetBrains decompiler
// Type: Story00911Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00911Scene : NGSceneBase
{
  [SerializeField]
  private Story00911Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00911Scene.\u003ConStartSceneAsync\u003Ec__Iterator464()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int id, int id2)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00911Scene.\u003ConStartSceneAsync\u003Ec__Iterator465()
    {
      id = id,
      id2 = id2,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u003Ef__this = this
    };
  }
}
