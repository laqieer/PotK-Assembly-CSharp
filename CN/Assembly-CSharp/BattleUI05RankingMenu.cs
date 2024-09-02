// Decompiled with JetBrains decompiler
// Type: BattleUI05RankingMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05RankingMenu : ResultMenuBase
{
  [SerializeField]
  private GameObject dir_RankingEvent;
  [SerializeField]
  private GameObject dir_StageTitle;
  [SerializeField]
  private UILabel txt_GetPoint;
  [SerializeField]
  private UILabel txt_TotalScoreTitle;
  [SerializeField]
  private UILabel txt_TotalScore;
  [SerializeField]
  private UILabel txt_StageHishScore;
  [SerializeField]
  private GameObject[] obj_PtBreakDown;
  [SerializeField]
  private GameObject obj_NowHighScore;
  [SerializeField]
  private GameObject obj_TotalHighScore;
  [SerializeField]
  private GameObject obj_TotalScoreTitle;
  [SerializeField]
  private GameObject obj_TotalScore;
  [SerializeField]
  private GameObject obj_ToNext;
  [SerializeField]
  private GameObject baseObj;
  private GameObject breakDownPrefab;
  private GameObject highScorePrefab;
  private bool onFinish;
  private BattleUI05RankingMenu.AnimState state;
  private QuestScoreBattleFinishContext campaign;

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RankingMenu.\u003CInit\u003Ec__Iterator8C0()
    {
      result = result,
      info = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  private void InitStagePoint(QuestScoreAcquisition[] scores)
  {
    for (int index = 0; index < scores.Length; ++index)
      this.breakDownPrefab.Clone(this.obj_PtBreakDown[index].transform).GetComponent<BattleUI05BreakDown>().SetPoint(scores[index].description, scores[index].score);
  }

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RankingMenu.\u003CLoadResources\u003Ec__Iterator8C1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RankingMenu.\u003CRun\u003Ec__Iterator8C2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void PlayAnimation()
  {
    if (this.state == BattleUI05RankingMenu.AnimState.NowScoreInit || this.state == BattleUI05RankingMenu.AnimState.NowScore)
    {
      if (this.state == BattleUI05RankingMenu.AnimState.NowScoreInit)
      {
        Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1011");
        Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.5f);
        Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.7f);
        this.state = BattleUI05RankingMenu.AnimState.NowScore;
      }
      this.DispNowScore();
    }
    if (this.state == BattleUI05RankingMenu.AnimState.StageScoreUpdate)
      this.DispNowScoreUpdate();
    else if (this.state == BattleUI05RankingMenu.AnimState.TotalScore)
      this.DispTotalScore();
    else if (this.state == BattleUI05RankingMenu.AnimState.TotalScoreUpdate)
    {
      this.DispTotalScoreUpdate();
    }
    else
    {
      if (this.state != BattleUI05RankingMenu.AnimState.End)
        return;
      this.onFinish = true;
    }
  }

  public void ChangeState()
  {
    if (this.state == BattleUI05RankingMenu.AnimState.End)
      return;
    if (this.state == BattleUI05RankingMenu.AnimState.NowScore)
    {
      this.state = !this.campaign.battle_score_max_updated ? BattleUI05RankingMenu.AnimState.TotalScore : BattleUI05RankingMenu.AnimState.StageScoreUpdate;
      if (this.state == BattleUI05RankingMenu.AnimState.TotalScore)
      {
        Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1011");
        Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.4f);
      }
    }
    else if (this.state == BattleUI05RankingMenu.AnimState.StageScoreUpdate)
    {
      this.state = BattleUI05RankingMenu.AnimState.TotalScore;
      Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1011");
      Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.4f);
    }
    else if (this.state == BattleUI05RankingMenu.AnimState.TotalScore)
      this.state = !this.campaign.score_max_updated ? BattleUI05RankingMenu.AnimState.End : BattleUI05RankingMenu.AnimState.TotalScoreUpdate;
    else if (this.state == BattleUI05RankingMenu.AnimState.TotalScoreUpdate)
      this.state = BattleUI05RankingMenu.AnimState.End;
    this.PlayAnimation();
  }

  public void DispNowScore()
  {
    this.dir_RankingEvent.SetActive(true);
    this.baseObj.SetActive(true);
    this.dir_StageTitle.SetActive(true);
  }

  private void DispNowScoreUpdate()
  {
    this.CreateHighScore(this.obj_NowHighScore.transform, new System.Action(this.ChangeState));
  }

  private void DispTotalScore()
  {
    this.obj_TotalScoreTitle.SetActive(true);
    this.obj_TotalScore.SetActive(true);
  }

  private void DispTotalScoreUpdate()
  {
    this.CreateHighScore(this.obj_TotalHighScore.transform, new System.Action(this.ChangeState));
  }

  private void CreateHighScore(Transform parent, System.Action callback)
  {
    UITweener componentInChildren = this.highScorePrefab.Clone(parent).GetComponentInChildren<UITweener>();
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1024", delay: 0.2f);
    if (Object.op_Equality((Object) componentInChildren, (Object) null))
      callback();
    else
      componentInChildren.SetOnFinished(new EventDelegate((EventDelegate.Callback) (() => callback())));
  }

  [DebuggerHidden]
  private IEnumerator WaitForTapping()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05RankingMenu.\u003CWaitForTapping\u003Ec__Iterator8C3()
    {
      \u003C\u003Ef__this = this
    };
  }

  private enum AnimState
  {
    NowScoreInit,
    NowScore,
    StageScoreUpdate,
    TotalScore,
    TotalScoreUpdate,
    End,
  }
}
