// Decompiled with JetBrains decompiler
// Type: Quest0022MissionDescriptions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0022MissionDescriptions : MonoBehaviour
{
  public List<Quest0022MissionDescription> Descriptions;

  public Quest0022MissionDescription ActiveDescriptionObject { get; private set; }

  public QuestStoryMission[] missionDataS { get; set; }

  public QuestExtraMission[] missionDataE { get; set; }

  public PlayerMissionHistory[] hists { get; set; }

  public Quest0022MissionDescription GetDescription(int index)
  {
    Quest0022MissionDescription obj = this.ReferDescription(index);
    this.Descriptions.ForEach((Action<Quest0022MissionDescription>) (x => ((Component) x).gameObject.SetActive(Object.op_Equality((Object) x, (Object) obj))));
    return obj;
  }

  public Quest0022MissionDescription ReferDescription(int index)
  {
    string findkey = index.ToString();
    return this.Descriptions.Find((Predicate<Quest0022MissionDescription>) (x => ((Object) ((Component) x).gameObject).name.Contains(findkey)));
  }

  [DebuggerHidden]
  public IEnumerator InitMissionDescription(int MissionCount, int StageID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionDescriptions.\u003CInitMissionDescription\u003Ec__Iterator23F()
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

  public void StartTweenClick(bool order, EventDelegate.Callback callback = null)
  {
    foreach (UITweener component in ((Component) this).GetComponents<UITweener>())
    {
      if (component.tweenGroup == 2)
      {
        if (callback != null)
        {
          component.AddOnFinished(callback);
          callback = (EventDelegate.Callback) null;
        }
        component.Play(order);
      }
    }
  }
}
