// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionResultMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new BattleUI05PunitiveExpeditionResultMenu.\u003CLoadResources\u003Ec__Iterator8B3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(WebAPI.Response.EventTop eventTopInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionResultMenu.\u003CInit\u003Ec__Iterator8B4()
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
    return (IEnumerator) new BattleUI05PunitiveExpeditionResultMenu.\u003CInit\u003Ec__Iterator8B5()
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
    return (IEnumerator) new BattleUI05PunitiveExpeditionResultMenu.\u003CRun\u003Ec__Iterator8B6()
    {
      \u003C\u003Ef__this = this
    };
  }
}
