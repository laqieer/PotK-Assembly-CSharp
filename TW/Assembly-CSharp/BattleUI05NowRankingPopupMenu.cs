// Decompiled with JetBrains decompiler
// Type: BattleUI05NowRankingPopupMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05NowRankingPopupMenu : ResultMenuBase
{
  [SerializeField]
  private GameObject dir_RankingEvent;
  [SerializeField]
  private GameObject dir_StageTitle;
  private QuestScoreBattleFinishContext campaign;
  private GameObject nowRankPopupPrefab;

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05NowRankingPopupMenu.\u003CInit\u003Ec__Iterator970()
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
    return (IEnumerator) new BattleUI05NowRankingPopupMenu.\u003CLoadResources\u003Ec__Iterator971()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05NowRankingPopupMenu.\u003CRun\u003Ec__Iterator972()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05NowRankingPopupMenu.\u003COnFinish\u003Ec__Iterator973()
    {
      \u003C\u003Ef__this = this
    };
  }
}
