﻿// Decompiled with JetBrains decompiler
// Type: BattleUI05ScoreRewardPopupMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05ScoreRewardPopupMenu : ResultMenuBase
{
  private GameObject rewardPopupPrefab;
  private int currentCnt;
  private QuestScoreBattleFinishContext campaign;

  [DebuggerHidden]
  public override IEnumerator Init(BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CInit\u003Ec__Iterator778()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CLoadResources\u003Ec__Iterator779()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CRun\u003Ec__Iterator77A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI05ScoreRewardPopupMenu.\u003COnFinish\u003Ec__Iterator77B finishCIterator77B = new BattleUI05ScoreRewardPopupMenu.\u003COnFinish\u003Ec__Iterator77B();
    return (IEnumerator) finishCIterator77B;
  }
}
