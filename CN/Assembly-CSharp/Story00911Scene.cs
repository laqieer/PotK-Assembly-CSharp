// Decompiled with JetBrains decompiler
// Type: Story00911Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Story00911Scene.\u003ConStartSceneAsync\u003Ec__Iterator507()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int id, int id2)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00911Scene.\u003ConStartSceneAsync\u003Ec__Iterator508()
    {
      id = id,
      id2 = id2,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u003Ef__this = this
    };
  }
}
