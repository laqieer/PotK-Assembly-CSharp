﻿// Decompiled with JetBrains decompiler
// Type: Popup02352Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02352Menu : Popup0235MenuBase
{
  [SerializeField]
  private UI2DSprite icon;
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription1;
  [SerializeField]
  private UILabel TxtDescription2;
  [SerializeField]
  private UILabel TxtNext;

  [DebuggerHidden]
  public override IEnumerator Init(
    ResultMenuBase.CampaignReward reward,
    ResultMenuBase.CampaignNextReward nextReward,
    GameObject gearObject,
    GameObject unitObject,
    GameObject uniqueObject)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02352Menu.\u003CInit\u003Ec__Iterator7E5()
    {
      reward = reward,
      nextReward = nextReward,
      gearObject = gearObject,
      unitObject = unitObject,
      uniqueObject = uniqueObject,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u0024\u003EnextReward = nextReward,
      \u003C\u0024\u003EgearObject = gearObject,
      \u003C\u0024\u003EunitObject = unitObject,
      \u003C\u0024\u003EuniqueObject = uniqueObject,
      \u003C\u003Ef__this = this
    };
  }
}
