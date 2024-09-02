// Decompiled with JetBrains decompiler
// Type: TutorialMiniGamePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class TutorialMiniGamePage : TutorialPageBase
{
  private const int playingSeconds = 10;

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialMiniGamePage.\u003CShow\u003Ec__Iterator7A8()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void finishCallback(int score)
  {
    Persist.tutorial.Data.MiniGameScore = score;
    this.NextPage();
  }
}
