// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionRewardMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private int[] guildRewardIds;
  private bool isGuild;

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionRewardMenu.\u003CLoadResources\u003Ec__Iterator984()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(WebAPI.Response.EventTop eventTopInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionRewardMenu.\u003CInit\u003Ec__Iterator985()
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
    return (IEnumerator) new BattleUI05PunitiveExpeditionRewardMenu.\u003CInit\u003Ec__Iterator986()
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
    return (IEnumerator) new BattleUI05PunitiveExpeditionRewardMenu.\u003CRun\u003Ec__Iterator987()
    {
      \u003C\u003Ef__this = this
    };
  }
}
