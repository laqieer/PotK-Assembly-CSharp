// Decompiled with JetBrains decompiler
// Type: Story0091Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0091Scene : NGSceneBase
{
  public Story0091Menu menu;
  [SerializeField]
  private NGxScroll ScrollContainer;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0091Scene.\u003ConStartSceneAsync\u003Ec__Iterator45A()
    {
      \u003C\u003Ef__this = this
    };
  }
}
