// Decompiled with JetBrains decompiler
// Type: Popup002261Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Popup002261Menu : MonoBehaviour
{
  [SerializeField]
  private UILabel txtTotalPoint;
  [SerializeField]
  private UILabel txtRanking;
  [SerializeField]
  private NGxScrollMasonry Scroll;
  [SerializeField]
  private UIWidget afterResult;
  [SerializeField]
  private GameObject effectParent;
  [SerializeField]
  private UIWidget Top;
  [SerializeField]
  private UIWidget Bottom;
  private QuestScoreCampaignProgress campaignProgress;
  private PlayerQuestScoreProgress playerInfo;
  private WebAPI.Response.QuestscoreRewardRewards[] m_rewards;
  private PlayerEmblem[] emblems;
  private bool isEffect;
  private Quest00226Menu menu;
  private System.Action closeAct;

  public IEnumerator Init(
    QuestScoreCampaignProgress scoreCampaignProgress,
    WebAPI.Response.QuestscoreRewardRewards[] rewards,
    Quest00226Menu menu,
    System.Action act)
  {
    Popup002261Menu popup002261Menu = this;
    popup002261Menu.closeAct = act;
    popup002261Menu.afterResult.alpha = 0.0f;
    popup002261Menu.menu = menu;
    popup002261Menu.isEffect = true;
    popup002261Menu.campaignProgress = scoreCampaignProgress;
    popup002261Menu.playerInfo = scoreCampaignProgress.player;
    popup002261Menu.m_rewards = rewards;
    Future<GameObject> rankingCalculatedF = Res.Prefabs.ranking.ranking_calculated.Load<GameObject>();
    IEnumerator e = rankingCalculatedF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    rankingCalculatedF.Result.Clone(popup002261Menu.effectParent.transform).GetComponentInChildren<PopupPvpClassEffect>().Init(new System.Action(popup002261Menu.EffectEndProvide), new System.Action(popup002261Menu.EffectEndEnable));
  }

  public void EffectEndProvide()
  {
    this.isEffect = false;
    this.StartCoroutine(this.EffectEnd());
  }

  public void EffectEndEnable() => this.isEffect = true;

  private IEnumerator EffectEnd()
  {
    while (!this.isEffect)
      yield return (object) null;
    this.effectParent.SetActive(false);
    IEnumerator e = this.StartResult();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private IEnumerator StartResult()
  {
    this.SetTop();
    this.SetBottom();
    this.SetScroll();
    this.DisplayResult();
    IEnumerator e = this.StartScroll();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    yield return (object) null;
    this.Scroll.ResolvePosition();
    this.afterResult.alpha = 1f;
  }

  private void DisplayResult()
  {
    this.txtTotalPoint.SetTextLocalize(this.playerInfo.score_total);
    this.txtRanking.SetTextLocalize(this.playerInfo.rank);
  }

  private IEnumerator StartScroll()
  {
    Popup002261Menu popup002261Menu = this;
    popup002261Menu.Scroll.Reset();
    popup002261Menu.Scroll.Scroll.gameObject.SetActive(false);
    Future<GameObject> boxPrefabF = Res.Prefabs.versus026_12.slc_Reward_Box.Load<GameObject>();
    IEnumerator e = boxPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject boxPrefab = boxPrefabF.Result;
    Future<GameObject> marginPrefabF = Res.Prefabs.versus026_12.dir_Between_Reward.Load<GameObject>();
    e = marginPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject marginPrefab = marginPrefabF.Result;
    if (popup002261Menu.m_rewards != null)
    {
      IEnumerable<IGrouping<int, WebAPI.Response.QuestscoreRewardRewards>> source1 = ((IEnumerable<WebAPI.Response.QuestscoreRewardRewards>) popup002261Menu.m_rewards).GroupBy<WebAPI.Response.QuestscoreRewardRewards, int>((Func<WebAPI.Response.QuestscoreRewardRewards, int>) (x => x.ranking_group_id));
      // ISSUE: reference to a compiler-generated method
      List<KeyValuePair<int, QuestExtraScoreRankingReward>> sameCampaignData = MasterData.QuestExtraScoreRankingReward.Where<KeyValuePair<int, QuestExtraScoreRankingReward>>(new Func<KeyValuePair<int, QuestExtraScoreRankingReward>, bool>(popup002261Menu.\u003CStartScroll\u003Eb__20_1)).ToList<KeyValuePair<int, QuestExtraScoreRankingReward>>();
      foreach (IGrouping<int, WebAPI.Response.QuestscoreRewardRewards> source2 in (IEnumerable<IGrouping<int, WebAPI.Response.QuestscoreRewardRewards>>) source1.OrderBy<IGrouping<int, WebAPI.Response.QuestscoreRewardRewards>, int>((Func<IGrouping<int, WebAPI.Response.QuestscoreRewardRewards>, int>) (x => sameCampaignData.FirstOrDefault<KeyValuePair<int, QuestExtraScoreRankingReward>>((Func<KeyValuePair<int, QuestExtraScoreRankingReward>, bool>) (y => y.Value.group_id == x.ToList<WebAPI.Response.QuestscoreRewardRewards>()[0].ranking_group_id)).Value.alignment)))
      {
        GameObject gameObject = boxPrefab.Clone();
        popup002261Menu.Scroll.Add(gameObject);
        e = gameObject.GetComponent<Versus02612ScrollRewardBox>().Init(source2.ToList<WebAPI.Response.QuestscoreRewardRewards>(), popup002261Menu.campaignProgress.id);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        popup002261Menu.Scroll.Add(marginPrefab.Clone());
      }
    }
    popup002261Menu.Scroll.Scroll.gameObject.SetActive(true);
    popup002261Menu.Scroll.ResolvePosition();
  }

  private void SetTop()
  {
    this.SetAnchor(this.Top.topAnchor, this.menu.GetEffectParent, 1f, 0);
    this.SetAnchor(this.Top.bottomAnchor, this.menu.GetEffectParent, 1f, -960);
    this.SetAnchor(this.Top.leftAnchor, this.menu.GetEffectParent, 0.0f, 0);
    this.SetAnchor(this.Top.rightAnchor, this.menu.GetEffectParent, 1f, 0);
    this.Top.ResetAnchors();
    this.Top.UpdateAnchors();
    ((IEnumerable<UIWidget>) this.Top.GetComponentsInChildren<UIWidget>()).ForEach<UIWidget>((System.Action<UIWidget>) (x =>
    {
      x.ResetAnchors();
      x.UpdateAnchors();
    }));
  }

  private void SetBottom()
  {
    this.SetAnchor(this.Bottom.topAnchor, this.menu.GetEffectParent, 0.0f, 960);
    this.SetAnchor(this.Bottom.bottomAnchor, this.menu.GetEffectParent, 0.0f, 0);
    this.SetAnchor(this.Bottom.leftAnchor, this.menu.GetEffectParent, 0.0f, 0);
    this.SetAnchor(this.Bottom.rightAnchor, this.menu.GetEffectParent, 1f, 0);
    this.Bottom.ResetAnchors();
    this.Bottom.UpdateAnchors();
    ((IEnumerable<UIWidget>) this.Top.GetComponentsInChildren<UIWidget>()).ForEach<UIWidget>((System.Action<UIWidget>) (x =>
    {
      x.ResetAnchors();
      x.UpdateAnchors();
    }));
  }

  private void SetScroll()
  {
    UIWidget component = this.Scroll.GetComponent<UIWidget>();
    this.SetAnchor(component.topAnchor, this.menu.GetEffectParent, 1f, -287);
    this.SetAnchor(component.bottomAnchor, this.menu.GetEffectParent, 0.0f, (int) sbyte.MaxValue);
    this.SetAnchor(component.leftAnchor, this.menu.GetEffectParent, 0.0f, 5);
    this.SetAnchor(component.rightAnchor, this.menu.GetEffectParent, 1f, -5);
    component.ResetAnchors();
    component.UpdateAnchors();
  }

  private void SetAnchor(UIRect.AnchorPoint ap, Transform parent, float relative, int absolute)
  {
    ap.target = parent;
    ap.relative = relative;
    ap.absolute = absolute;
  }

  public void IbtnTouch()
  {
    if (this.closeAct == null)
      return;
    this.closeAct();
  }
}
