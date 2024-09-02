// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionResultMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05PunitiveExpeditionResultMenu : ResultMenuBase
{
  [SerializeField]
  private GameObject HuntingEvent;
  private List<ResultMenuBase> sequences;
  private GameObject PunitiveExpeditionRewardMenuPrefab;
  private GameObject HuntingEventPrefab;
  private bool isInitialized;

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionResultMenu.\u003CLoadResources\u003Ec__Iterator980()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(WebAPI.Response.EventTop eventTopInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionResultMenu.\u003CInit\u003Ec__Iterator981()
    {
      eventTopInfo = eventTopInfo,
      \u003C\u0024\u003EeventTopInfo = eventTopInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionResultMenu.\u003CInit\u003Ec__Iterator982()
    {
      result = result,
      info = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionResultMenu.\u003CRun\u003Ec__Iterator983()
    {
      \u003C\u003Ef__this = this
    };
  }
}
