// Decompiled with JetBrains decompiler
// Type: Quest00219Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
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

  [DebuggerHidden]
  public IEnumerator Init(
    Future<GameObject> ListPrefab,
    Future<GameObject> ScrollPrefab,
    PlayerExtraQuestS[] ExtraData,
    int lid)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CInit\u003Ec__Iterator1C4()
    {
      ExtraData = ExtraData,
      lid = lid,
      ListPrefab = ListPrefab,
      ScrollPrefab = ScrollPrefab,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003Elid = lid,
      \u003C\u0024\u003EListPrefab = ListPrefab,
      \u003C\u0024\u003EScrollPrefab = ScrollPrefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator ScrollInit(
    PlayerExtraQuestS extra,
    GameObject prefab,
    bool isClear,
    bool isNew,
    Quest00217Scroll.SeekType seekType)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CScrollInit\u003Ec__Iterator1C5()
    {
      prefab = prefab,
      extra = extra,
      isClear = isClear,
      isNew = isNew,
      seekType = seekType,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003EisClear = isClear,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003EseekType = seekType,
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
    return (IEnumerator) new Quest00219Menu.\u003CListInit\u003Ec__Iterator1C6()
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
  public IEnumerator QuestTimeCompare(
    PlayerExtraQuestS StageData,
    GameObject obj,
    bool Guerrilla = false,
    bool rankingEvent = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Menu.\u003CQuestTimeCompare\u003Ec__Iterator1C7()
    {
      StageData = StageData,
      Guerrilla = Guerrilla,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u0024\u003EGuerrilla = Guerrilla
    };
  }
}
