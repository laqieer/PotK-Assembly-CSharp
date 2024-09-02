// Decompiled with JetBrains decompiler
// Type: Popup02353Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Popup02353Menu.\u003CInit\u003Ec__Iterator7E6()
    {
      nextReward = nextReward,
      \u003C\u0024\u003EnextReward = nextReward,
      \u003C\u003Ef__this = this
    };
  }
}
