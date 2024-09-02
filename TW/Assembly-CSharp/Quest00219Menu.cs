// Decompiled with JetBrains decompiler
// Type: Quest00219Menu
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
public class Quest00219Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  public UIScrollView scrollview;
  public UIGrid grid;
  public UI2DSprite EventSprite;
  protected DateTime serverTime;

  public bool IncludingKeyGate { get; set; }

  private PlayerExtraQuestS[] ExtraData { get; set; }

  private List<int> Emphasis { get; set; }

  private List<QuestExtraTimetableNotice> Notices { get; set; }

  protected string LoadSpriteEvent(PlayerExtraQuestS quest)
  {
    return Singleton<ResourceManager>.GetInstance().Contains(string.Format("Prefabs/Banners/ExtraQuest/L/{0}/Specialquest_Story", (object) quest.quest_extra_s.quest_l_QuestExtraL)) ? string.Format("Prefabs/Banners/ExtraQuest/L/{0}/Specialquest_Story", (object) quest.quest_extra_s.quest_l_QuestExtraL) : string.Format("Prefabs/Banners/ExtraQuest/L/4/Specialquest_Story");
  }

  [DebuggerHidden]
  public IEnumerator Init(
    Future<GameObject> ListPrefab,
    Future<GameObject> ScrollPrefab,
    PlayerExtraQuestS[] ExtraData,
    int lid,
    int[] Emphasis,
    QuestExtraTimetableNotice[] Notices)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CInit\u003Ec__Iterator233()
    {
      ExtraData = ExtraData,
      Emphasis = Emphasis,
      Notices = Notices,
      lid = lid,
      ScrollPrefab = ScrollPrefab,
      ListPrefab = ListPrefab,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003EEmphasis = Emphasis,
      \u003C\u0024\u003ENotices = Notices,
      \u003C\u0024\u003Elid = lid,
      \u003C\u0024\u003EScrollPrefab = ScrollPrefab,
      \u003C\u0024\u003EListPrefab = ListPrefab,
      \u003C\u003Ef__this = this
    };
  }

  private Quest00217Scroll.Parameter GenerateParam(PlayerExtraQuestS extra)
  {
    Quest00217Scroll.Parameter param = new Quest00217Scroll.Parameter();
    param.isNew = true;
    QuestExtraS[] array = ((IEnumerable<QuestExtraS>) MasterData.QuestExtraSList).Where<QuestExtraS>((Func<QuestExtraS, bool>) (x => x.quest_m_QuestExtraM == extra.quest_extra_s.quest_m_QuestExtraM)).ToArray<QuestExtraS>();
    int clearCnt = 0;
    ((IEnumerable<PlayerExtraQuestS>) this.ExtraData.S(extra.quest_extra_s.quest_l_QuestExtraL, extra.quest_extra_s.quest_m_QuestExtraM)).ForEach<PlayerExtraQuestS>((Action<PlayerExtraQuestS>) (x =>
    {
      if (x.is_clear)
        ++clearCnt;
      if (!x.is_new)
        param.isNew = false;
      if (param.isHighlighting || !this.Emphasis.Any<int>((Func<int, bool>) (i => i == x._quest_extra_s)))
        return;
      param.isHighlighting = true;
    }));
    if (clearCnt == ((IEnumerable<QuestExtraS>) array).Count<QuestExtraS>())
      param.isClear = true;
    return param;
  }

  [DebuggerHidden]
  private IEnumerator PutBannerList(Future<GameObject> prefab, List<PlayerExtraQuestS> list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CPutBannerList\u003Ec__Iterator234()
    {
      prefab = prefab,
      list = list,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Elist = list,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator PutGeneralBtnList(Future<GameObject> prefab, List<PlayerExtraQuestS> list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CPutGeneralBtnList\u003Ec__Iterator235()
    {
      prefab = prefab,
      list = list,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Elist = list,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitQuestGate(
    int idQuestL,
    PlayerExtraQuestS[] questExtra,
    PlayerQuestGate[] questGates)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CInitQuestGate\u003Ec__Iterator236()
    {
      questExtra = questExtra,
      idQuestL = idQuestL,
      questGates = questGates,
      \u003C\u0024\u003EquestExtra = questExtra,
      \u003C\u0024\u003EidQuestL = idQuestL,
      \u003C\u0024\u003EquestGates = questGates,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ScrollInit(PlayerQuestGate[] gates, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CScrollInit\u003Ec__Iterator237()
    {
      prefab = prefab,
      gates = gates,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Egates = gates,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator ScrollInit(Quest00217Scroll.Parameter param, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CScrollInit\u003Ec__Iterator238()
    {
      prefab = prefab,
      param = param,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator ListInit(
    PlayerExtraQuestS extra,
    GameObject prefab,
    bool isClear,
    bool isNew)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CListInit\u003Ec__Iterator239()
    {
      prefab = prefab,
      extra = extra,
      isClear = isClear,
      isNew = isNew,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003EisClear = isClear,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u003Ef__this = this
    };
  }

  protected void ChangeScene00220(
    PlayerExtraQuestS extra,
    GameObject obj,
    bool Guerrilla = false,
    bool rankingEvent = false)
  {
    this.StartCoroutine(this.QuestTimeCompare(extra, obj, Guerrilla, rankingEvent));
  }

  public virtual void Foreground() => Debug.Log((object) "click default event Foreground");

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnEvent() => Debug.Log((object) "click default event IbtnEvent");

  public virtual void VScrollBar() => Debug.Log((object) "click default event VScrollBar");

  [DebuggerHidden]
  public IEnumerator QuestTimeCompare(
    PlayerExtraQuestS StageData,
    GameObject obj,
    bool Guerrilla = false,
    bool rankingEvent = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CQuestTimeCompare\u003Ec__Iterator23A()
    {
      StageData = StageData,
      Guerrilla = Guerrilla,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u0024\u003EGuerrilla = Guerrilla
    };
  }
}
