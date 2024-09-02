// Decompiled with JetBrains decompiler
// Type: Quest00217Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  private DateTime serverTime;
  private PlayerQuestGate[] keyQuestsGate;
  private Dictionary<int, Quest00217GridCategory> categories = new Dictionary<int, Quest00217GridCategory>();
  [SerializeField]
  private UI2DSprite testSprite;

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerExtraQuestS[] ExtraData,
    int[] Categories,
    int[] Emphasis,
    WebAPI.Response.QuestProgressExtraNotice[] Notices)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CInit\u003Ec__Iterator1DE()
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
    IEnumerable<PlayerExtraQuestS> extraDatas,
    PlayerExtraQuestS[] ExtraData,
    GameObject prefab,
    int[] Emphasis,
    WebAPI.Response.QuestProgressExtraNotice[] Notices)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CInitLoopScrolls\u003Ec__Iterator1DF()
    {
      Notices = Notices,
      Emphasis = Emphasis,
      extraDatas = extraDatas,
      ExtraData = ExtraData,
      prefab = prefab,
      \u003C\u0024\u003ENotices = Notices,
      \u003C\u0024\u003EEmphasis = Emphasis,
      \u003C\u0024\u003EextraDatas = extraDatas,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator UpdateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CUpdateTime\u003Ec__Iterator1E0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator ScrollInit(Quest00217Scroll.Parameter param, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CScrollInit\u003Ec__Iterator1E1()
    {
      prefab = prefab,
      param = param,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
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
    return (IEnumerator) new Quest00217Menu.\u003CCreate_Transitionbutton\u003Ec__Iterator1E2()
    {
      name = name,
      categoryId = categoryId,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003EcategoryId = categoryId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreatePunitiveExpeditionEventButton(EventInfo[] infos, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CCreatePunitiveExpeditionEventButton\u003Ec__Iterator1E3()
    {
      infos = infos,
      prefab = prefab,
      \u003C\u0024\u003Einfos = infos,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  private string GetTitle() => Consts.GetInstance().QUEST_00217_NORMAL_TITLE;
}
