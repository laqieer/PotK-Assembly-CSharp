// Decompiled with JetBrains decompiler
// Type: BattleUI05ScoreRewardPopupMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CInit\u003Ec__Iterator8DD()
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
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CLoadResources\u003Ec__Iterator8DE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CRun\u003Ec__Iterator8DF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI05ScoreRewardPopupMenu.\u003COnFinish\u003Ec__Iterator8E0 finishCIterator8E0 = new BattleUI05ScoreRewardPopupMenu.\u003COnFinish\u003Ec__Iterator8E0();
    return (IEnumerator) finishCIterator8E0;
  }
}
