﻿// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionRewardMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05PunitiveExpeditionRewardMenu : ResultMenuBase
{
  private GameObject rewardReceivePopup;
  [SerializeField]
  private GameObject hantingEvent;
  private bool toNext;
  private int allPlayerPoint;
  private int playerPoint;
  private int[] rewardIds;
  private bool isGuild;

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionRewardMenu.\u003CLoadResources\u003Ec__Iterator8B7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(WebAPI.Response.EventTop eventTopInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionRewardMenu.\u003CInit\u003Ec__Iterator8B8()
    {
      eventTopInfo = eventTopInfo,
      \u003C\u0024\u003EeventTopInfo = eventTopInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result, int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionRewardMenu.\u003CInit\u003Ec__Iterator8B9()
    {
      result = result,
      index = index,
      \u003C\u0024\u003Eresult = result,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionRewardMenu.\u003CRun\u003Ec__Iterator8BA()
    {
      \u003C\u003Ef__this = this
    };
  }
}
