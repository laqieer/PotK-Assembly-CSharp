﻿// Decompiled with JetBrains decompiler
// Type: TutorialStoryPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new TutorialStoryPage.\u003CShow\u003Ec__Iterator875()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator observeStoryEnd()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialStoryPage.\u003CobserveStoryEnd\u003Ec__Iterator876()
    {
      \u003C\u003Ef__this = this
    };
  }
}
