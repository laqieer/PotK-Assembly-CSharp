// Decompiled with JetBrains decompiler
// Type: Quest0022MissionDescriptions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest0022MissionDescriptions : MonoBehaviour
{
  public List<Quest0022MissionDescription> Descriptions;
  private Quest0022MissionDescription ActiveDescriptionObject;

  public QuestStoryMission[] missionDataS { get; set; }

  public QuestExtraMission[] missionDataE { get; set; }

  public PlayerMissionHistory[] hists { get; set; }

  public Quest0022MissionDescription GetDescription(int index)
  {
    Quest0022MissionDescription obj = this.Descriptions.Where<Quest0022MissionDescription>((Func<Quest0022MissionDescription, bool>) (x => ((Object) ((Component) x).gameObject).name.Contains(index.ToString()))).First<Quest0022MissionDescription>();
    this.Descriptions.ForEach((Action<Quest0022MissionDescription>) (x => ((Component) x).gameObject.SetActive(Object.op_Equality((Object) x, (Object) obj))));
    return obj;
  }

  [DebuggerHidden]
  public IEnumerator InitMissionDescription(int MissionCount, int StageID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionDescriptions.\u003CInitMissionDescription\u003Ec__Iterator1CC()
    {
      MissionCount = MissionCount,
      StageID = StageID,
      \u003C\u0024\u003EMissionCount = MissionCount,
      \u003C\u0024\u003EStageID = StageID,
      \u003C\u003Ef__this = this
    };
  }

  public void StartTween(bool order)
  {
    foreach (UITweener component in ((Component) this).GetComponents<UITweener>())
    {
      if (component.tweenGroup == 1)
        component.Play(order);
    }
  }

  public void StartTweenClick(bool order)
  {
    foreach (UITweener component in ((Component) this).GetComponents<UITweener>())
    {
      if (component.tweenGroup == 2)
        component.Play(order);
    }
  }
}
