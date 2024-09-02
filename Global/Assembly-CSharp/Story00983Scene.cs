// Decompiled with JetBrains decompiler
// Type: Story00983Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00983Scene : NGSceneBase
{
  [SerializeField]
  private Story00983Menu menu;
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int ID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00983Scene.\u003ConStartSceneAsync\u003Ec__Iterator494()
    {
      ID = ID,
      \u003C\u0024\u003EID = ID,
      \u003C\u003Ef__this = this
    };
  }
}
