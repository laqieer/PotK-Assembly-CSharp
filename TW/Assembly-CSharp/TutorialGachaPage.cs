// Decompiled with JetBrains decompiler
// Type: TutorialGachaPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TutorialGachaPage : TutorialPageBase
{
  private const int REWARD_TYPE_UNIT = 1;

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TutorialGachaPage.\u003CShow\u003Ec__Iterator870 showCIterator870 = new TutorialGachaPage.\u003CShow\u003Ec__Iterator870();
    return (IEnumerator) showCIterator870;
  }

  public void OnGachaFinish()
  {
    UserEvent.SendEvent((MonoBehaviour) Singleton<TutorialRoot>.GetInstance(), "Frist_Gacha_end");
    this.StartCoroutine(this.finish());
  }

  [DebuggerHidden]
  private IEnumerator finish()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialGachaPage.\u003Cfinish\u003Ec__Iterator871()
    {
      \u003C\u003Ef__this = this
    };
  }
}
