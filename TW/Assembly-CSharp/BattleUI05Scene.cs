// Decompiled with JetBrains decompiler
// Type: BattleUI05Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleUI05Scene : NGSceneBase
{
  [SerializeField]
  private GameObject touchToNext;
  private List<ResultMenuBase> sequences;
  private bool isInitialized;
  private bool isStarted;
  private bool toNextSequence;
  private static DateTime serverTime;
  private GameObject PunitiveExpeditionRewardMenuPrefab;
  private GameObject PunitiveExpeditionNextRewardMenuPrefab;

  public override void onEndScene() => this.sequences.Clear();

  public override List<string> createResourceLoadList()
  {
    PlayerUnit[] source = SMManager.Get<PlayerUnit[]>();
    ResourceManager rm = Singleton<ResourceManager>.GetInstance();
    return ((IEnumerable<PlayerUnit>) source).SelectMany<PlayerUnit, string>((Func<PlayerUnit, IEnumerable<string>>) (x => (IEnumerable<string>) rm.PathsFromUnit(x.unit))).ToList<string>();
  }

  public void IbtnTouchToNext() => this.toNextSequence = true;

  public static void ChangeScene(
    GameCore.BattleInfo info,
    bool isWin,
    WebAPI.Response.BattleStoryFinish result)
  {
    BattleUI05Scene.ChangeScene(info, isWin, result.battle_finish);
  }

  public static void ChangeScene(
    GameCore.BattleInfo info,
    bool isWin,
    WebAPI.Response.BattleWaveFinish result)
  {
    BattleUI05Scene.ChangeScene(info, isWin, result.battle_finish);
  }

  public static void ChangeScene(GameCore.BattleInfo info, bool isWin, BattleEnd result)
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    instance.clearStack();
    instance.destroyCurrentScene();
    instance.destroyLoadedScenes();
    if (isWin)
      instance.changeScene("battleUI_05", false, (object) info, (object) isWin, (object) result);
    else
      BattleUI05Scene.ReturnQuestScene(info, isWin, result);
  }

  public static void ReturnQuestScene(GameCore.BattleInfo info, bool isWin, BattleEnd result)
  {
    switch (info.quest_type)
    {
      case CommonQuestType.Story:
        QuestStoryS questStoryS = ((IEnumerable<UnlockQuest>) result.unlock_quests).Where<UnlockQuest>((Func<UnlockQuest, bool>) (x => x.quest_type == 1)).Select<UnlockQuest, QuestStoryS>((Func<UnlockQuest, QuestStoryS>) (x => MasterData.QuestStoryS[x.quest_s_id])).FirstOrDefault<QuestStoryS>() ?? MasterData.QuestStoryS[info.quest_s_id];
        int clearCount = !isWin ? 0 : info.quest_loop_count + 1;
        Quest0022Scene.ChangeScene0022(false, questStoryS.quest_l.ID, questStoryS.quest_m.ID, info.quest_s_id, clearCount, result.player_review);
        break;
      case CommonQuestType.Character:
        Quest00214Scene.ChangeScene(false, MasterData.QuestCharacterS[info.quest_s_id].unit.ID);
        break;
      case CommonQuestType.Extra:
        QuestExtraS nextQuest = ((IEnumerable<UnlockQuest>) result.unlock_quests).Where<UnlockQuest>((Func<UnlockQuest, bool>) (x => x.quest_type == 3)).Select<UnlockQuest, QuestExtraS>((Func<UnlockQuest, QuestExtraS>) (x => MasterData.QuestExtraS[x.quest_s_id])).FirstOrDefault<QuestExtraS>() ?? MasterData.QuestExtraS[info.quest_s_id];
        if (result.score_campaigns.Length > 0)
        {
          BattleUI05Scene.ReturnRankingQuestScene(result.score_campaigns[0], nextQuest);
          break;
        }
        PlayerExtraQuestS[] resultExtraData = SMManager.Get<PlayerExtraQuestS[]>().S(nextQuest.quest_l_QuestExtraL, nextQuest.quest_m_QuestExtraM);
        bool flag = false;
        if (resultExtraData != null)
        {
          PlayerExtraQuestS playerExtraQuestS = ((IEnumerable<PlayerExtraQuestS>) resultExtraData).FirstOrDefault<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x => x.quest_extra_s.ID == nextQuest.ID));
          if (playerExtraQuestS != null && playerExtraQuestS.remain_battle_count.HasValue && playerExtraQuestS.remain_battle_count.Value - 1 <= 0)
            flag = true;
        }
        if (nextQuest.extra_quest_area == CommonExtraQuestArea.key)
        {
          PlayerQuestGate[] source = SMManager.Get<PlayerQuestGate[]>();
          PlayerQuestGate playerQuestGate = ((IEnumerable<PlayerQuestGate>) source).FirstOrDefault<PlayerQuestGate>((Func<PlayerQuestGate, bool>) (x => ((IEnumerable<int>) x.quest_ids).Any<int>((Func<int, bool>) (y => ((IEnumerable<PlayerExtraQuestS>) resultExtraData).Any<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (z => z._quest_extra_s == y))))));
          if (!flag && resultExtraData != null && resultExtraData.Length > 0)
          {
            DateTime? endAt = playerQuestGate.end_at;
            if ((!endAt.HasValue ? 0 : (ServerTime.NowAppTime() > endAt.Value ? 1 : 0)) == 0 && playerQuestGate.in_progress)
            {
              Quest00220Scene.ChangeScene00220(false, nextQuest.quest_l_QuestExtraL, nextQuest.quest_m_QuestExtraM, isKeyQuest: true);
              break;
            }
          }
          PlayerExtraQuestS[] self = SMManager.Get<PlayerExtraQuestS[]>();
          IEnumerable<int> idGateS = ((IEnumerable<PlayerQuestGate>) source).SelectMany<PlayerQuestGate, int>((Func<PlayerQuestGate, IEnumerable<int>>) (s => (IEnumerable<int>) s.quest_ids));
          if (((IEnumerable<PlayerExtraQuestS>) self.M(nextQuest.quest_l_QuestExtraL)).All<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x => idGateS.Contains<int>(x._quest_extra_s))))
          {
            Quest002171Scene.ChangeScene(false);
            break;
          }
          if (nextQuest.seek_index.ToUpper() == "L")
          {
            Quest00219Scene.ChangeScene(nextQuest.ID, false);
            break;
          }
          Quest00217Scene.ChangeScene(false);
          break;
        }
        if (flag || resultExtraData == null || resultExtraData.Length <= 0 || ServerTime.NowAppTime() > resultExtraData[0].today_day_end_at)
        {
          Quest00217Scene.ChangeScene(false);
          break;
        }
        Quest00220Scene.ChangeScene00220(false, nextQuest.quest_l_QuestExtraL, nextQuest.quest_m_QuestExtraM);
        break;
      case CommonQuestType.Harmony:
        Quest00214Scene.ChangeScene(false, info.quest_s_id, true);
        break;
      default:
        MypageScene.ChangeScene(false);
        break;
    }
  }

  private static void ReturnRankingQuestScene(
    QuestScoreBattleFinishContext campaign,
    QuestExtraS nextQuest)
  {
    switch (CampaignQuest.GetEvetnTerm(campaign, BattleUI05Scene.serverTime))
    {
      case CampaignQuest.RankingEventTerm.normal:
        Quest00220Scene.ChangeScene00220(false, nextQuest.quest_l_QuestExtraL, nextQuest.quest_m_QuestExtraM);
        break;
      case CampaignQuest.RankingEventTerm.receive:
        Quest00217Scene.ChangeScene(false);
        break;
      case CampaignQuest.RankingEventTerm.aggregate:
        Quest00217Scene.ChangeScene(false);
        break;
    }
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GameCore.BattleInfo info, bool isWin, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05Scene.\u003ConStartSceneAsync\u003Ec__Iterator9A2()
    {
      info = info,
      result = result,
      isWin = isWin,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u0024\u003EisWin = isWin,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator setBackGround(GameCore.BattleInfo info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05Scene.\u003CsetBackGround\u003Ec__Iterator9A3()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(GameCore.BattleInfo info, bool isWin, BattleEnd result)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus(info, isWin, result));
  }

  private string setPathStory(GameCore.BattleInfo info)
  {
    switch (info.quest_type)
    {
      case CommonQuestType.Story:
        return this.setStoryPath(info.storyQuest.quest_story_s);
      case CommonQuestType.Character:
        return this.setCharaPath(MasterData.QuestCharacterS[info.quest_s_id]);
      case CommonQuestType.Extra:
        return this.setExtraPath(info.extraQuest.quest_extra_s);
      case CommonQuestType.Harmony:
        return this.setHarmonyPath(MasterData.QuestHarmonyS[info.quest_s_id]);
      default:
        return string.Empty;
    }
  }

  private string setStoryPath(QuestStoryS quest) => quest.GetBackgroundPath();

  private string setExtraPath(QuestExtraS quest) => quest.GetBackgroundPath();

  private string setCharaPath(QuestCharacterS quest) => quest.GetBackgroundPath();

  private string setHarmonyPath(QuestHarmonyS quest) => quest.GetBackgroundPath();

  [DebuggerHidden]
  private IEnumerator InitMenus(GameCore.BattleInfo info, bool isWin, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05Scene.\u003CInitMenus\u003Ec__Iterator9A4()
    {
      info = info,
      result = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RunMenus(GameCore.BattleInfo info, bool isWin, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05Scene.\u003CRunMenus\u003Ec__Iterator9A5()
    {
      info = info,
      isWin = isWin,
      result = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003EisWin = isWin,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }
}
