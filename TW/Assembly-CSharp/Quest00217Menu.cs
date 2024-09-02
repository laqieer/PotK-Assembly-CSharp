// Decompiled with JetBrains decompiler
// Type: Quest00217Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00217Menu : BackButtonMenuBase
{
  private const int CATEGORY_METALKEY = 1;
  [SerializeField]
  protected UILabel TxtTitle;
  public UIScrollView scrollview;
  public Quest00217Grid grid;
  public GameObject topDragScroll_;
  private DateTime serverTime;
  private PlayerQuestGate[] keyQuestsGate;
  private Dictionary<int, Quest00217GridCategory> categories = new Dictionary<int, Quest00217GridCategory>();
  private List<UIDragScrollView> pauseDragScrollViews_;
  private Dictionary<int, Description> dicHuntingDescriptions_ = new Dictionary<int, Description>();
  private Dictionary<int, QuestScoreCampaignProgress> dicScoreCampaigns_ = new Dictionary<int, QuestScoreCampaignProgress>();

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerExtraQuestS[] ExtraData,
    int[] Categories,
    int[] Emphasis,
    QuestExtraTimetableNotice[] Notices)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CInit\u003Ec__Iterator20B()
    {
      ExtraData = ExtraData,
      Categories = Categories,
      Emphasis = Emphasis,
      Notices = Notices,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003ECategories = Categories,
      \u003C\u0024\u003EEmphasis = Emphasis,
      \u003C\u0024\u003ENotices = Notices,
      \u003C\u003Ef__this = this
    };
  }

  private void createScrollItemsCategory(PlayerExtraQuestS[] extraData, int[] sortedCategory)
  {
    foreach (QuestExtraCategory questExtraCategory in ((IEnumerable<int>) sortedCategory).Select<int, QuestExtraCategory>((Func<int, QuestExtraCategory>) (i => this.getQuestCategory(i))).ToList<QuestExtraCategory>())
      this.categories.Add(questExtraCategory.ID, this.grid.createCategory(questExtraCategory.ID, questExtraCategory.name));
  }

  private QuestExtraCategory getQuestCategory(int id)
  {
    QuestExtraCategory questCategory = (QuestExtraCategory) null;
    if (MasterData.QuestExtraCategory.TryGetValue(id, out questCategory))
      return questCategory;
    return new QuestExtraCategory()
    {
      ID = id,
      name = string.Format("Category:{0}", (object) id)
    };
  }

  private void cleanEmptyCategory()
  {
    Quest00217GridCategory[] array = this.categories.Values.ToArray<Quest00217GridCategory>();
    for (int index = 0; index < array.Length; ++index)
    {
      if (array[index].items.Count == 0)
      {
        this.categories.Remove(array[index].ID);
        this.grid.deleteCategory(array[index]);
      }
    }
  }

  private List<PlayerExtraQuestS> ChoiceAndSet_BannerToBeDesplayed(PlayerExtraQuestS[] ExtraData)
  {
    PlayerExtraQuestS[] array = ((IEnumerable<PlayerExtraQuestS>) ExtraData).Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x => x.extra_quest_area == 1 || x.extra_quest_area == 3)).ToArray<PlayerExtraQuestS>();
    PlayerExtraQuestS[] collection1 = array.L();
    PlayerExtraQuestS[] collection2 = array.M();
    List<PlayerExtraQuestS> beDesplayed = new List<PlayerExtraQuestS>();
    beDesplayed.AddRange((IEnumerable<PlayerExtraQuestS>) collection1);
    beDesplayed.AddRange((IEnumerable<PlayerExtraQuestS>) collection2);
    return beDesplayed;
  }

  [DebuggerHidden]
  private IEnumerator InitLoopScrolls(
    PlayerExtraQuestS extraData,
    PlayerExtraQuestS[] ExtraData,
    GameObject prefab,
    int[] Emphasis,
    QuestExtraTimetableNotice[] Notices)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CInitLoopScrolls\u003Ec__Iterator20C()
    {
      Notices = Notices,
      Emphasis = Emphasis,
      extraData = extraData,
      ExtraData = ExtraData,
      prefab = prefab,
      \u003C\u0024\u003ENotices = Notices,
      \u003C\u0024\u003EEmphasis = Emphasis,
      \u003C\u0024\u003EextraData = extraData,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator UpdateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CUpdateTime\u003Ec__Iterator20D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator ScrollInit(Quest00217Scroll.Parameter param, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CScrollInit\u003Ec__Iterator20E()
    {
      prefab = prefab,
      param = param,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  private void checkChangeDescriptionScoreCampaing(Quest00217Scroll cntl, int id)
  {
    if (!this.dicScoreCampaigns_.Any<KeyValuePair<int, QuestScoreCampaignProgress>>())
      this.dicScoreCampaigns_ = ((IEnumerable<QuestScoreCampaignProgress>) SMManager.Get<QuestScoreCampaignProgress[]>()).ToList<QuestScoreCampaignProgress>().Distinct<QuestScoreCampaignProgress>((IEqualityComparer<QuestScoreCampaignProgress>) new LambdaEqualityComparer<QuestScoreCampaignProgress>((Func<QuestScoreCampaignProgress, QuestScoreCampaignProgress, bool>) ((a, b) => a.quest_extra_l == b.quest_extra_l))).ToDictionary<QuestScoreCampaignProgress, int>((Func<QuestScoreCampaignProgress, int>) (x => x.quest_extra_l));
    QuestScoreCampaignProgress qscp = (QuestScoreCampaignProgress) null;
    if (this.dicScoreCampaigns_.TryGetValue(id, out qscp))
    {
      if (this.IsPushAndSet())
        return;
      this.pauseDragScrollView();
      Quest00228Scene.ChangeScene(qscp, true);
    }
    else
      cntl.setEffectNoDescription();
  }

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnEvent()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  private IEnumerator Create_Transitionbutton(string name, int categoryId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CCreate_Transitionbutton\u003Ec__Iterator20F()
    {
      name = name,
      categoryId = categoryId,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003EcategoryId = categoryId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreatePunitiveExpeditionEventButton(EventInfo info, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CCreatePunitiveExpeditionEventButton\u003Ec__Iterator210()
    {
      info = info,
      prefab = prefab,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator coInitScrcollHunting(EventInfo info, GameObject go)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CcoInitScrcollHunting\u003Ec__Iterator211()
    {
      info = info,
      go = go,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Ego = go,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator coChangeHuntinDescription(Quest00217ScrollHunting cntl, EventInfo info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CcoChangeHuntinDescription\u003Ec__Iterator212()
    {
      info = info,
      cntl = cntl,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Ecntl = cntl,
      \u003C\u003Ef__this = this
    };
  }

  private void OnDisable() => this.resumeDragScrollView();

  private string GetTitle() => Consts.GetInstance().QUEST_00217_NORMAL_TITLE;

  private void pauseDragScrollView()
  {
    this.resumeDragScrollView();
    this.pauseDragScrollViews_ = new List<UIDragScrollView>();
    foreach (UIDragScrollView componentsInChild in this.topDragScroll_.GetComponentsInChildren<UIDragScrollView>())
    {
      if (((Behaviour) componentsInChild).enabled)
      {
        this.pauseDragScrollViews_.Add(componentsInChild);
        ((Behaviour) componentsInChild).enabled = false;
      }
    }
  }

  private void resumeDragScrollView()
  {
    if (this.pauseDragScrollViews_ == null || !this.pauseDragScrollViews_.Any<UIDragScrollView>())
      return;
    foreach (Behaviour pauseDragScrollView in this.pauseDragScrollViews_)
      pauseDragScrollView.enabled = true;
    this.pauseDragScrollViews_.Clear();
  }
}
