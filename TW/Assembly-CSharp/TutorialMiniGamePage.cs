// Decompiled with JetBrains decompiler
// Type: TutorialMiniGamePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new TutorialMiniGamePage.\u003CShow\u003Ec__Iterator873()
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
