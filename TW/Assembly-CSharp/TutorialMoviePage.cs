// Decompiled with JetBrains decompiler
// Type: TutorialMoviePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  [SerializeField]
  private string windowsMoviePath;

  private string moviePath() => this.androidMoviePath;

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialMoviePage.\u003CShow\u003Ec__Iterator874()
    {
      \u003C\u003Ef__this = this
    };
  }
}
