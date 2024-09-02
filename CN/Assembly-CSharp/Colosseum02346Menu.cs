﻿// Decompiled with JetBrains decompiler
// Type: Colosseum02346Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum02346Menu : ResultMenuBase
{
  [SerializeField]
  private GameObject DirRankupEffect;
  [SerializeField]
  private GameObject DirBottomMessage;
  [SerializeField]
  private GameObject DirTitleExp;
  [SerializeField]
  private GameObject DirRankPoint;
  [SerializeField]
  private GameObject DirRankStatus;
  [SerializeField]
  private GameObject RankExpGauge;
  [SerializeField]
  private GameObject NextBattleEffect;
  [SerializeField]
  protected UILabel TxtGetPoint;
  [SerializeField]
  protected UILabel TxtLose;
  [SerializeField]
  protected UILabel TxtRankname;
  [SerializeField]
  protected UILabel TxtRankPoint;
  [SerializeField]
  protected UILabel TxtRemain;
  [SerializeField]
  protected UILabel TxtToNextRank;
  [SerializeField]
  protected UILabel TxtToNextRankPoint;
  [SerializeField]
  protected UILabel TxtWin;
  [SerializeField]
  protected UILabel TxtRemainNum;
  [SerializeField]
  protected UILabel TxtAttentionNum;
  [SerializeField]
  private GameObject[] Campaing;
  private ColosseumUtility.Info info;
  private ResultMenuBase.Param result;
  private GameObject RankBattleResultEffectPrefab;
  private GameObject NextBattleEffectPrefab;
  private GameObject TotalWinRewardPrefab;
  private GameObject NewEmblemRewardPrefab;
  private GameObject RankUpRewardPrefab;
  private GameObject NewRankNamePrefab;
  private GameObject CampaingPrefab1;
  private GameObject CampaingPrefab2;
  private GameObject CampaingPrefab3;
  private GameObject UnitPrefab;
  private GameObject GearPrefab;
  private GameObject UniquePrefab;
  private bool activeNextBattleEffect;
  private bool activeRankBattleEffect;
  private bool activeRankBattlePopupEffect;
  private int nextBattleType;
  private int rankChangeType;
  private int nowBattleType;

  [DebuggerHidden]
  public override IEnumerator Init(
    ColosseumUtility.Info info,
    ResultMenuBase.Param param,
    Gladiator gladiator)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Menu.\u003CInit\u003Ec__Iterator5C2()
    {
      info = info,
      param = param,
      gladiator = gladiator,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003Egladiator = gladiator,
      \u003C\u003Ef__this = this
    };
  }

  public void EndNextBattleEffect() => this.activeNextBattleEffect = false;

  public void EndRankBattleEffect() => this.activeRankBattleEffect = false;

  public void EndRankBattlePopupEffect() => this.activeRankBattlePopupEffect = false;

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Menu.\u003CRun\u003Ec__Iterator5C3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Colosseum02346Menu.\u003COnFinish\u003Ec__Iterator5C4 finishCIterator5C4 = new Colosseum02346Menu.\u003COnFinish\u003Ec__Iterator5C4();
    return (IEnumerator) finishCIterator5C4;
  }

  [DebuggerHidden]
  private IEnumerator InitObjects()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Menu.\u003CInitObjects\u003Ec__Iterator5C5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowRankUp()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Menu.\u003CShowRankUp\u003Ec__Iterator5C6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowRankInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Menu.\u003CShowRankInfo\u003Ec__Iterator5C7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowRankPoint()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Menu.\u003CShowRankPoint\u003Ec__Iterator5C8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowTitleEXP()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Menu.\u003CShowTitleEXP\u003Ec__Iterator5C9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowBottomMessage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Menu.\u003CShowBottomMessage\u003Ec__Iterator5CA()
    {
      \u003C\u003Ef__this = this
    };
  }

  private delegate IEnumerator Runner();
}
