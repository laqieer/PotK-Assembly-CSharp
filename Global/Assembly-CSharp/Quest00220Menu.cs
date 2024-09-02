// Decompiled with JetBrains decompiler
// Type: Quest00220Menu
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
public class Quest00220Menu : QuestStageMenuBase
{
  private bool isKeyQuest;

  protected override void Update()
  {
    if (!this.SceneStart || this.hscrollButtons == null)
      return;
    base.Update();
    this.UpdateButton();
  }

  [DebuggerHidden]
  public IEnumerator Initialize(PlayerExtraQuestS[] ExtraData, int L, int M, bool isKeyQuest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00220Menu.\u003CInitialize\u003Ec__Iterator1FE()
    {
      isKeyQuest = isKeyQuest,
      ExtraData = ExtraData,
      L = L,
      M = M,
      \u003C\u0024\u003EisKeyQuest = isKeyQuest,
      \u003C\u0024\u003EExtraData = ExtraData,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EM = M,
      \u003C\u003Ef__this = this
    };
  }

  protected override void SetTextLimitation(int s_id)
  {
    AssocList<int, QuestExtraLimitation> questExtraLimitation = MasterData.QuestExtraLimitation;
    QuestExtraLimitationLabel[] limitationLabelList = MasterData.QuestExtraLimitationLabelList;
    KeyValuePair<int, QuestExtraLimitation>[] array = questExtraLimitation.Where<KeyValuePair<int, QuestExtraLimitation>>((Func<KeyValuePair<int, QuestExtraLimitation>, bool>) (n => n.Value.quest_s_id_QuestExtraS == s_id)).ToArray<KeyValuePair<int, QuestExtraLimitation>>();
    if (((IEnumerable<KeyValuePair<int, QuestExtraLimitation>>) array).Count<KeyValuePair<int, QuestExtraLimitation>>() == 0)
    {
      this.EntryInfoScript.IsDisplay = false;
    }
    else
    {
      int target_id = ((IEnumerable<KeyValuePair<int, QuestExtraLimitation>>) array).First<KeyValuePair<int, QuestExtraLimitation>>().Value.ID;
      this.EntryInfoScript.TextNormal = ((IEnumerable<QuestExtraLimitationLabel>) limitationLabelList).Where<QuestExtraLimitationLabel>((Func<QuestExtraLimitationLabel, bool>) (n => n.ID == target_id)).First<QuestExtraLimitationLabel>().label;
      this.EntryInfoScript.Normal = true;
      this.EntryInfoScript.Hurd = false;
    }
  }

  public override void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    ((Behaviour) this.btnBack).enabled = false;
    this.tweenSettingDefault();
    if (this.isKeyQuest)
      Quest002171Scene.ChangeScene(false);
    else if (this.StageDataS[0].seek_index == "L" || this.StageDataS[0].seek_index == "l")
    {
      QuestScoreCampaignProgress[] source = SMManager.Get<QuestScoreCampaignProgress[]>();
      if (source != null)
      {
        if (((IEnumerable<QuestScoreCampaignProgress>) source).FirstOrDefault<QuestScoreCampaignProgress>((Func<QuestScoreCampaignProgress, bool>) (x => x.quest_extra_l == this.StageDataS[0].id_L)) != null)
          Quest00226Scene.ChangeScene(this.StageDataS[0].id_S, false);
        else
          Quest00219Scene.ChangeScene(this.StageDataS[0].id_S, false);
      }
      else
        Quest00219Scene.ChangeScene(this.StageDataS[0].id_S, false);
    }
    else
    {
      if (!(this.StageDataS[0].seek_index == "M") && !(this.StageDataS[0].seek_index == "m"))
        return;
      Quest00217Scene.ChangeScene(false);
    }
  }
}
