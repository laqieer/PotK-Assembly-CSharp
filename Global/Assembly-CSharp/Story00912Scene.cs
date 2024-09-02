// Decompiled with JetBrains decompiler
// Type: Story00912Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00912Scene : NGSceneBase
{
  [SerializeField]
  private Story00912Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00912Scene.\u003ConStartSceneAsync\u003Ec__Iterator46B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int id, int id2, int id3, int questSId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00912Scene.\u003ConStartSceneAsync\u003Ec__Iterator46C()
    {
      id = id,
      id2 = id2,
      id3 = id3,
      questSId = questSId,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u0024\u003Eid3 = id3,
      \u003C\u0024\u003EquestSId = questSId,
      \u003C\u003Ef__this = this
    };
  }
}
