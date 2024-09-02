// Decompiled with JetBrains decompiler
// Type: BattleUI05ScoreRewardPopupMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CInit\u003Ec__Iterator9AA()
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
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CLoadResources\u003Ec__Iterator9AB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopupMenu.\u003CRun\u003Ec__Iterator9AC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI05ScoreRewardPopupMenu.\u003COnFinish\u003Ec__Iterator9AD finishCIterator9Ad = new BattleUI05ScoreRewardPopupMenu.\u003COnFinish\u003Ec__Iterator9AD();
    return (IEnumerator) finishCIterator9Ad;
  }
}
