// Decompiled with JetBrains decompiler
// Type: Quest0025Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0025Menu : NGMenuBase
{
  public BGChange bgchange;
  public Quest0025CircularMotionSet circul;
  private GameObject jog;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private Transform MainPanel;

  public virtual void IbtnStoryL() => Debug.Log((object) "click default event IbtnStoryL");

  [DebuggerHidden]
  public IEnumerator Init(PlayerStoryQuestS[] StoryData, int LNum, bool Hard)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0025Menu.\u003CInit\u003Ec__Iterator2B0()
    {
      StoryData = StoryData,
      LNum = LNum,
      Hard = Hard,
      \u003C\u0024\u003EStoryData = StoryData,
      \u003C\u0024\u003ELNum = LNum,
      \u003C\u0024\u003EHard = Hard,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator BGchanger(int Lid)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0025Menu.\u003CBGchanger\u003Ec__Iterator2B1()
    {
      Lid = Lid,
      \u003C\u0024\u003ELid = Lid,
      \u003C\u003Ef__this = this
    };
  }
}
