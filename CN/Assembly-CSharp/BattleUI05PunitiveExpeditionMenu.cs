// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05PunitiveExpeditionMenu : ResultMenuBase
{
  [SerializeField]
  private GameObject baseObject;
  [SerializeField]
  private UILabel txtHuntingPointTitle;
  [SerializeField]
  private GameObject dirHuntingPointTitle;
  [SerializeField]
  private GameObject dirHuntingTotalPointTitle;
  [SerializeField]
  private NGxScroll scrollContiner;
  [SerializeField]
  private GameObject dirStageTotalHuntingPt;
  [SerializeField]
  private UILabel txtStageTotalHuntingPt;
  [SerializeField]
  private GameObject dirBase;
  [SerializeField]
  private GameObject dirPlayerTotalHuntingPt;
  [SerializeField]
  private UILabel txtPlayerTotalHuntingPt;
  [SerializeField]
  private GameObject dirTotalHunting;
  [SerializeField]
  private UILabel txtTotalHuntingForAllPt;
  [SerializeField]
  private GameObject dirGuildHunting;
  [SerializeField]
  private UILabel txtGuildHuntingForAllPt;
  [SerializeField]
  private GameObject dirContribution;
  [SerializeField]
  private UILabel txtContribution;
  private GameObject DirHuntingTargetPT;
  private BattleUI05PunitiveExpeditionMenu.AnimState state;
  private bool animatiFinish;
  private System.Action tapCallback;
  private bool toNext;
  private bool isGuild;

  public void onTapToNext() => this.toNext = true;

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionMenu.\u003CLoadResources\u003Ec__Iterator8AB()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void InitTargetPoint(EventBattleFinish eventInfo)
  {
    EventBattleFinishDestroy_enemys[] destroyEnemys = eventInfo.destroy_enemys;
    int bonusScore = 0;
    this.scrollContiner.Clear();
    this.scrollContiner.Reset();
    for (int index = 0; index < destroyEnemys.Length; ++index)
    {
      GameObject gameObject = this.DirHuntingTargetPT.Clone();
      gameObject.GetComponent<BattleUI05PunitiveExpeditionTargetScroll>().Init(destroyEnemys[index]);
      this.scrollContiner.Add(gameObject);
      bonusScore += destroyEnemys[index].bonus_point;
    }
    if (bonusScore > 0)
    {
      GameObject gameObject = this.DirHuntingTargetPT.Clone();
      gameObject.GetComponent<BattleUI05PunitiveExpeditionTargetScroll>().Init(bonusScore);
      this.scrollContiner.Add(gameObject);
    }
    this.scrollContiner.ResolvePosition();
  }

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result, int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionMenu.\u003CInit\u003Ec__Iterator8AC()
    {
      result = result,
      index = index,
      \u003C\u0024\u003Eresult = result,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  public void ChangeState()
  {
    if (this.state == BattleUI05PunitiveExpeditionMenu.AnimState.End)
      return;
    if (this.state == BattleUI05PunitiveExpeditionMenu.AnimState.NowScore)
    {
      this.state = BattleUI05PunitiveExpeditionMenu.AnimState.TotalScore;
      Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1011");
      Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.4f);
    }
    else if (this.state == BattleUI05PunitiveExpeditionMenu.AnimState.TotalScore)
      this.state = BattleUI05PunitiveExpeditionMenu.AnimState.End;
    this.PlayAnimation();
  }

  private void DispNowScore()
  {
    this.dirBase.SetActive(true);
    this.dirHuntingPointTitle.SetActive(true);
  }

  private void DispTotalScore()
  {
    this.dirHuntingTotalPointTitle.SetActive(true);
    this.dirPlayerTotalHuntingPt.SetActive(true);
  }

  private void PlayAnimation()
  {
    if (this.state == BattleUI05PunitiveExpeditionMenu.AnimState.NowScoreInit || this.state == BattleUI05PunitiveExpeditionMenu.AnimState.NowScore)
    {
      if (this.state == BattleUI05PunitiveExpeditionMenu.AnimState.NowScoreInit)
      {
        Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1011");
        Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.5f);
        Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.7f);
        this.state = BattleUI05PunitiveExpeditionMenu.AnimState.NowScore;
      }
      this.DispNowScore();
    }
    else if (this.state == BattleUI05PunitiveExpeditionMenu.AnimState.TotalScore)
    {
      this.DispTotalScore();
    }
    else
    {
      if (this.state != BattleUI05PunitiveExpeditionMenu.AnimState.End)
        return;
      this.animatiFinish = true;
    }
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionMenu.\u003CRun\u003Ec__Iterator8AD()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator WaitForTapping()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05PunitiveExpeditionMenu.\u003CWaitForTapping\u003Ec__Iterator8AE()
    {
      \u003C\u003Ef__this = this
    };
  }

  private enum AnimState
  {
    NowScoreInit,
    NowScore,
    TotalScore,
    End,
  }
}
