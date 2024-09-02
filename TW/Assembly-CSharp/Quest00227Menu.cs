// Decompiled with JetBrains decompiler
// Type: Quest00227Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00227Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txt_title;
  [SerializeField]
  private NGxScroll scroll;
  private GameObject QuestBar;
  private GameObject RankingBar;

  [DebuggerHidden]
  public IEnumerator Initialize(QuestScoreCampaignProgress qscp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00227Menu.\u003CInitialize\u003Ec__Iterator280()
    {
      qscp = qscp,
      \u003C\u0024\u003Eqscp = qscp,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00227Menu.\u003CLoadResources\u003Ec__Iterator281()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void AddBarObject(QuestScoreCampaignProgress progress)
  {
    this.scroll.Clear();
    if (progress.total_reward_exists)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.QuestBar);
      this.InitBarObject(gameObject, Quest00227Menu.BarType.TotalScore, progress);
      this.scroll.Add(gameObject);
    }
    QuestScoreCampaignProgressScore_achivement_rewards[] achivementRewards = progress.score_achivement_rewards;
    for (int index = 0; index < achivementRewards.Length; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.QuestBar);
      this.InitBarObject(gameObject, Quest00227Menu.BarType.Quest, progress, index);
      this.scroll.Add(gameObject);
    }
    if (!progress.score_ranking_disabled)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.RankingBar);
      this.InitBarObject(gameObject, Quest00227Menu.BarType.Ranking, progress);
      this.scroll.Add(gameObject);
    }
    this.scroll.ResolvePosition();
  }

  private void InitBarObject(
    GameObject obj,
    Quest00227Menu.BarType type,
    QuestScoreCampaignProgress progress,
    int index = 0)
  {
    int rank = 0;
    UIButton componentInChildren1 = obj.GetComponentInChildren<UIButton>();
    UILabel componentInChildren2 = obj.GetComponentInChildren<UILabel>();
    switch (type)
    {
      case Quest00227Menu.BarType.Quest:
        QuestScoreCampaignProgressScore_achivement_rewards achivementReward = progress.score_achivement_rewards[index];
        QuestExtraM m;
        if (!MasterData.QuestExtraM.TryGetValue(achivementReward.quest_extra_m, out m))
          break;
        rank = progress.GetQuestMScoreFromMID(m.ID);
        EventDelegate.Add(componentInChildren1.onClick, (EventDelegate.Callback) (() => Quest002272Scene.ChangeScene(true, achivementReward, progress.player.score_achivement_reward_cleared, m.name, rank)));
        componentInChildren2.SetTextLocalize(m.name);
        break;
      case Quest00227Menu.BarType.Ranking:
        rank = progress.player.rank;
        EventDelegate.Add(componentInChildren1.onClick, (EventDelegate.Callback) (() => Quest002271Scene.ChangeScene(true, progress, Consts.GetInstance().QUEST_00227_RANKING_BARNAME, rank)));
        componentInChildren2.SetTextLocalize(Consts.GetInstance().QUEST_00227_RANKING_BARNAME);
        break;
      case Quest00227Menu.BarType.TotalScore:
        EventDelegate.Add(componentInChildren1.onClick, (EventDelegate.Callback) (() => Quest002272Scene.ChangeScene(true, progress.score_total_rewards, Consts.GetInstance().QUEST_00227_TOTALSCORE_BARNAME, progress.player.score_total)));
        componentInChildren2.SetTextLocalize(Consts.GetInstance().QUEST_00227_TOTALSCORE_BARNAME);
        break;
    }
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  private enum BarType
  {
    Quest,
    Ranking,
    TotalScore,
  }
}
