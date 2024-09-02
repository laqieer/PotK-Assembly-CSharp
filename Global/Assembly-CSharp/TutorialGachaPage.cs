// Decompiled with JetBrains decompiler
// Type: TutorialGachaPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class TutorialGachaPage : TutorialPageBase
{
  private const int REWARD_TYPE_UNIT = 1;

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TutorialGachaPage.\u003CShow\u003Ec__Iterator65F showCIterator65F = new TutorialGachaPage.\u003CShow\u003Ec__Iterator65F();
    return (IEnumerator) showCIterator65F;
  }

  public void OnGachaFinish() => this.StartCoroutine(this.finish());

  [DebuggerHidden]
  private IEnumerator finish()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialGachaPage.\u003Cfinish\u003Ec__Iterator660()
    {
      \u003C\u003Ef__this = this
    };
  }
}
