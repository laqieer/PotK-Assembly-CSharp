// Decompiled with JetBrains decompiler
// Type: Quest00226Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00226Menu : Quest00219Menu
{
  [SerializeField]
  private UILabel txtEventTotalPt;
  [SerializeField]
  private UILabel txtEventRank;
  [SerializeField]
  private UILabel txtEventPeriod;
  [SerializeField]
  private GameObject objEffectParent;
  [SerializeField]
  private GameObject dir_EventButton;
  [SerializeField]
  private GameObject dir_EventButton_without_ranking;
  protected QuestScoreCampaignProgress questScoreCampaignProgress;

  public Transform GetEffectParent => this.objEffectParent.transform;

  [DebuggerHidden]
  public IEnumerator Init(
    bool AlreadyReceived,
    PlayerExtraQuestS[] ExtraData,
    WebAPI.Response.QuestscoreRewardRewards[] rewards,
    int lid,
    QuestScoreCampaignProgress qscp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Menu.\u003CInit\u003Ec__Iterator202()
    {
      qscp = qscp,
      AlreadyReceived = AlreadyReceived,
      ExtraData = ExtraData,
      rewards = rewards,
      lid = lid,
      \u003C\u0024\u003Eqscp = qscp,
      \u003C\u0024\u003EAlreadyReceived = AlreadyReceived,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003Erewards = rewards,
      \u003C\u0024\u003Elid = lid,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    Future<GameObject> ListPrefab,
    Future<GameObject> ScrollPrefab,
    bool AlreadyReceived,
    PlayerExtraQuestS[] ExtraData,
    WebAPI.Response.QuestscoreRewardRewards[] rewards,
    int lid)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Menu.\u003CInit\u003Ec__Iterator203()
    {
      ExtraData = ExtraData,
      lid = lid,
      ListPrefab = ListPrefab,
      ScrollPrefab = ScrollPrefab,
      AlreadyReceived = AlreadyReceived,
      rewards = rewards,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003Elid = lid,
      \u003C\u0024\u003EListPrefab = ListPrefab,
      \u003C\u0024\u003EScrollPrefab = ScrollPrefab,
      \u003C\u0024\u003EAlreadyReceived = AlreadyReceived,
      \u003C\u0024\u003Erewards = rewards,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ScrollInit(
    PlayerExtraQuestS extra,
    GameObject prefab,
    bool isClear,
    bool isNew,
    Quest00217Scroll.SeekType seekType,
    int score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Menu.\u003CScrollInit\u003Ec__Iterator204()
    {
      extra = extra,
      prefab = prefab,
      isClear = isClear,
      isNew = isNew,
      score = score,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003EisClear = isClear,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003Escore = score,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ListInit(
    PlayerExtraQuestS extra,
    GameObject prefab,
    bool isClear,
    bool isNew,
    int score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Menu.\u003CListInit\u003Ec__Iterator205()
    {
      extra = extra,
      prefab = prefab,
      isClear = isClear,
      isNew = isNew,
      score = score,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003EisClear = isClear,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003Escore = score,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CellInit(
    PlayerExtraQuestS extra,
    GameObject prefab,
    bool isClear,
    bool isNew,
    int score)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Menu.\u003CCellInit\u003Ec__Iterator206()
    {
      prefab = prefab,
      extra = extra,
      isClear = isClear,
      isNew = isNew,
      score = score,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003EisClear = isClear,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003Escore = score,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnRewardCheck()
  {
    Quest00227Scene.ChangeScene(this.questScoreCampaignProgress, true);
  }

  public void IbtnRanking()
  {
    Quest00229Scene.ChangeScene(this.questScoreCampaignProgress.id, true);
  }

  public void IbtnHowToPlay() => Quest00228Scene.ChangeScene(this.questScoreCampaignProgress, true);
}
