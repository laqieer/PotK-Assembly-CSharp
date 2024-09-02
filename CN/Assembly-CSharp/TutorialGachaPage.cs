// Decompiled with JetBrains decompiler
// Type: TutorialGachaPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    TutorialGachaPage.\u003CShow\u003Ec__Iterator7A5 showCIterator7A5 = new TutorialGachaPage.\u003CShow\u003Ec__Iterator7A5();
    return (IEnumerator) showCIterator7A5;
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
    return (IEnumerator) new TutorialGachaPage.\u003Cfinish\u003Ec__Iterator7A6()
    {
      \u003C\u003Ef__this = this
    };
  }
}
