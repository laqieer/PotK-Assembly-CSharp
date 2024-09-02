// Decompiled with JetBrains decompiler
// Type: TutorialStoryPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TutorialStoryPage : TutorialPageBase
{
  [SerializeField]
  private int scriptId;

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialStoryPage.\u003CShow\u003Ec__Iterator664()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator observeStoryEnd()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialStoryPage.\u003CobserveStoryEnd\u003Ec__Iterator665()
    {
      \u003C\u003Ef__this = this
    };
  }
}
