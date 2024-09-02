// Decompiled with JetBrains decompiler
// Type: Popup02351Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02351Menu : Popup0235MenuBase
{
  [SerializeField]
  private UI2DSprite icon;
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription1;
  [SerializeField]
  private UILabel TxtDescription2;

  [DebuggerHidden]
  public override IEnumerator Init(
    ResultMenuBase.CampaignReward reward,
    ResultMenuBase.CampaignNextReward nextReward,
    GameObject gearObject,
    GameObject unitObject,
    GameObject uniqueObject)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02351Menu.\u003CInit\u003Ec__Iterator953()
    {
      reward = reward,
      gearObject = gearObject,
      unitObject = unitObject,
      uniqueObject = uniqueObject,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u0024\u003EgearObject = gearObject,
      \u003C\u0024\u003EunitObject = unitObject,
      \u003C\u0024\u003EuniqueObject = uniqueObject,
      \u003C\u003Ef__this = this
    };
  }
}
