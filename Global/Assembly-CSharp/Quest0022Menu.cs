﻿// Decompiled with JetBrains decompiler
// Type: Quest0022Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
public class Quest0022Menu : QuestStageMenuBase
{
  private const int DEBUG_BONUS_CATEGORY = 2;
  [SerializeField]
  private GameObject Top;
  private Quest0022Bonus bonus;
  private int bonusCategory;
  private float timer = 1f;
  private DateTime? timeBonusTarget;
  private GameObject bonusTimeContainer;
  [SerializeField]
  private bool isDebugBonusTime;
  private DateTime DEBUG_BONU_TIME = new DateTime(2015, 4, 10, 0, 9, 0);

  protected override void Update()
  {
    if (!this.SceneStart || this.hscrollButtons == null)
      return;
    base.Update();
    this.UpdateButton();
    if (this.bonusCategory == 0)
      return;
    this.timer -= Time.deltaTime;
    if ((double) this.timer > 0.0)
      return;
    this.StartCoroutine(this.UpdateTimeBonus());
    this.timer = 1f;
  }

  [DebuggerHidden]
  private IEnumerator UpdateTimeBonus()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022Menu.\u003CUpdateTimeBonus\u003Ec__Iterator1E3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    PlayerStoryQuestS[] StoryData,
    int L,
    int M,
    bool hard,
    bool bgCreate)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022Menu.\u003CInitialize\u003Ec__Iterator1E4()
    {
      StoryData = StoryData,
      L = L,
      M = M,
      hard = hard,
      bgCreate = bgCreate,
      \u003C\u0024\u003EStoryData = StoryData,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EM = M,
      \u003C\u0024\u003Ehard = hard,
      \u003C\u0024\u003EbgCreate = bgCreate,
      \u003C\u003Ef__this = this
    };
  }

  protected override void SetTextLimitation(int s_id)
  {
    AssocList<int, QuestStoryLimitation> questStoryLimitation = MasterData.QuestStoryLimitation;
    QuestStoryLimitationLabel[] limitationLabelList = MasterData.QuestStoryLimitationLabelList;
    KeyValuePair<int, QuestStoryLimitation>[] array = questStoryLimitation.Where<KeyValuePair<int, QuestStoryLimitation>>((Func<KeyValuePair<int, QuestStoryLimitation>, bool>) (n => n.Value.quest_s_id_QuestStoryS == s_id)).ToArray<KeyValuePair<int, QuestStoryLimitation>>();
    if (((IEnumerable<KeyValuePair<int, QuestStoryLimitation>>) array).Count<KeyValuePair<int, QuestStoryLimitation>>() == 0)
    {
      this.EntryInfoScript.IsDisplay = false;
    }
    else
    {
      int target_id = ((IEnumerable<KeyValuePair<int, QuestStoryLimitation>>) array).First<KeyValuePair<int, QuestStoryLimitation>>().Value.ID;
      string str = string.Join(",", ((IEnumerable<QuestStoryLimitationLabel>) limitationLabelList).Where<QuestStoryLimitationLabel>((Func<QuestStoryLimitationLabel, bool>) (n => n.ID == target_id)).Select<QuestStoryLimitationLabel, string>((Func<QuestStoryLimitationLabel, string>) (x => x.label)).ToArray<string>());
      if (this.hardmode)
        this.EntryInfoScript.TextHurd = str;
      else
        this.EntryInfoScript.TextNormal = str;
      this.EntryInfoScript.Normal = !this.hardmode;
      this.EntryInfoScript.Hurd = this.hardmode;
    }
  }

  public override void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    ((Behaviour) this.btnBack).enabled = false;
    this.tweenSettingDefault();
    ((Component) this).GetComponent<BGChange>().M_BGAnimation(10, Hard: this.hardmode);
    Quest00240723Scene.ChangeScene0024(false, this.PassData);
  }

  private void OnDisable() => Object.Destroy((Object) this.bonusTimeContainer);
}
