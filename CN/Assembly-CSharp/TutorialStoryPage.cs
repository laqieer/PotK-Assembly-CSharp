// Decompiled with JetBrains decompiler
// Type: TutorialStoryPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new TutorialStoryPage.\u003CShow\u003Ec__Iterator7AA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator observeStoryEnd()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialStoryPage.\u003CobserveStoryEnd\u003Ec__Iterator7AB()
    {
      \u003C\u003Ef__this = this
    };
  }
}
