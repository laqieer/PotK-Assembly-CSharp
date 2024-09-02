// Decompiled with JetBrains decompiler
// Type: Popup02353Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02353Menu : Popup0235MenuBase
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription;

  [DebuggerHidden]
  public override IEnumerator Init(
    ResultMenuBase.CampaignReward reward,
    ResultMenuBase.CampaignNextReward nextReward,
    GameObject gearObject,
    GameObject unitObject,
    GameObject uniqueObject)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02353Menu.\u003CInit\u003Ec__IteratorA2A()
    {
      nextReward = nextReward,
      \u003C\u0024\u003EnextReward = nextReward,
      \u003C\u003Ef__this = this
    };
  }
}
