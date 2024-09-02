// Decompiled with JetBrains decompiler
// Type: Popup026823Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup026823Menu : Popup02682MenuBase
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription;

  [DebuggerHidden]
  public override IEnumerator Init(
    Versus0268Menu.PvpParam.CampaignReward reward,
    Versus0268Menu.PvpParam.CampaignNextReward nextReward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup026823Menu.\u003CInit\u003Ec__Iterator7F3()
    {
      nextReward = nextReward,
      \u003C\u0024\u003EnextReward = nextReward,
      \u003C\u003Ef__this = this
    };
  }
}
