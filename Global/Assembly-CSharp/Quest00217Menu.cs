// Decompiled with JetBrains decompiler
// Type: Quest00217Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
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
  [SerializeField]
  protected UILabel TxtTitle;
  public UIScrollView scrollview;
  public UIGrid grid;
  private DateTime serverTime;
  private PlayerQuestGate[] keyQuestsGate;

  [DebuggerHidden]
  public IEnumerator Init(PlayerExtraQuestS[] ExtraData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CInit\u003Ec__Iterator1A2()
    {
      ExtraData = ExtraData,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u003Ef__this = this
    };
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
    GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CInitLoopScrolls\u003Ec__Iterator1A3()
    {
      extraDatas = extraDatas,
      ExtraData = ExtraData,
      prefab = prefab,
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
    return (IEnumerator) new Quest00217Menu.\u003CUpdateTime\u003Ec__Iterator1A4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ScrollInit(
    PlayerExtraQuestS extra,
    GameObject prefab,
    bool isClear,
    bool isNew)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CScrollInit\u003Ec__Iterator1A5()
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
  private IEnumerator Create_Transitionbutton(string name)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Menu.\u003CCreate_Transitionbutton\u003Ec__Iterator1A6()
    {
      name = name,
      \u003C\u0024\u003Ename = name,
      \u003C\u003Ef__this = this
    };
  }

  private string GetTitle() => Consts.Lookup("QUEST_00217_NORMAL_TITLE");
}
