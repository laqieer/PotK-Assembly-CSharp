// Decompiled with JetBrains decompiler
// Type: BattleUI05NowRankingPopupMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
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
  public override IEnumerator Init(BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05NowRankingPopupMenu.\u003CInit\u003Ec__Iterator759()
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
    return (IEnumerator) new BattleUI05NowRankingPopupMenu.\u003CLoadResources\u003Ec__Iterator75A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05NowRankingPopupMenu.\u003CRun\u003Ec__Iterator75B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05NowRankingPopupMenu.\u003COnFinish\u003Ec__Iterator75C()
    {
      \u003C\u003Ef__this = this
    };
  }
}
