// Decompiled with JetBrains decompiler
// Type: TutorialMoviePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TutorialMoviePage : TutorialPageBase
{
  [SerializeField]
  private string iosMoviePath;
  [SerializeField]
  private string androidMoviePath;

  private string moviePath() => this.androidMoviePath;

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialMoviePage.\u003CShow\u003Ec__Iterator663()
    {
      \u003C\u003Ef__this = this
    };
  }
}
