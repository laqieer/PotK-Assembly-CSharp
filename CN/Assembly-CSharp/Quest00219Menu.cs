// Decompiled with JetBrains decompiler
// Type: Quest00219Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
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

  public string LoadSpriteEvent(PlayerExtraQuestS quest)
  {
    return Singleton<ResourceManager>.GetInstance().Contains(string.Format("Prefabs/Banners/ExtraQuest/L/{0}/Specialquest_Story", (object) quest.quest_extra_s.quest_l_QuestExtraL)) ? string.Format("Prefabs/Banners/ExtraQuest/L/{0}/Specialquest_Story", (object) quest.quest_extra_s.quest_l_QuestExtraL) : string.Format("Prefabs/Banners/ExtraQuest/L/4/Specialquest_Story");
  }

  protected void ShowExplanationMessage(QuestExtraL extra)
  {
    if (Persist.explanation.Data.IsOpen(extra.ID) || extra.description == null)
      return;
    Singleton<TutorialRoot>.GetInstance().showEventQuestExplanation(extra.description.description, extra.ID);
  }

  [DebuggerHidden]
  public IEnumerator Init(
    Future<GameObject> ListPrefab,
    Future<GameObject> ScrollPrefab,
    PlayerExtraQuestS[] ExtraData,
    int lid,
    int[] Emphasis,
    WebAPI.Response.QuestProgressExtraNotice[] Notices)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CInit\u003Ec__Iterator201()
    {
      ExtraData = ExtraData,
      lid = lid,
      ListPrefab = ListPrefab,
      ScrollPrefab = ScrollPrefab,
      Emphasis = Emphasis,
      Notices = Notices,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003Elid = lid,
      \u003C\u0024\u003EListPrefab = ListPrefab,
      \u003C\u0024\u003EScrollPrefab = ScrollPrefab,
      \u003C\u0024\u003EEmphasis = Emphasis,
      \u003C\u0024\u003ENotices = Notices,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator ScrollInit(Quest00217Scroll.Parameter param, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CScrollInit\u003Ec__Iterator202()
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
    return (IEnumerator) new Quest00219Menu.\u003CListInit\u003Ec__Iterator203()
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
    return (IEnumerator) new Quest00219Menu.\u003CQuestTimeCompare\u003Ec__Iterator204()
    {
      StageData = StageData,
      Guerrilla = Guerrilla,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u0024\u003EGuerrilla = Guerrilla
    };
  }
}
