// Decompiled with JetBrains decompiler
// Type: Quest0022MissionComplete
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0022MissionComplete : MonoBehaviour
{
  [SerializeField]
  private UILabel MissionAchievementCount;
  [SerializeField]
  private GameObject MissionAchievementComplete;
  [SerializeField]
  private UILabel MissionAchievementAll;
  [SerializeField]
  private UniqueIconsSetStory MissionCompleteItem;
  private QuestStoryMissionReward rewardItemData;
  private GameObject itemDetailPopupF;

  [DebuggerHidden]
  public IEnumerator missionCompleteRate(QuestConverterData quest, int M)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionComplete.\u003CmissionCompleteRate\u003Ec__Iterator257()
    {
      quest = quest,
      M = M,
      \u003C\u0024\u003Equest = quest,
      \u003C\u0024\u003EM = M,
      \u003C\u003Ef__this = this
    };
  }

  public void onDetail() => this.StartCoroutine(this.setDetailPopup());

  [DebuggerHidden]
  private IEnumerator setDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionComplete.\u003CsetDetailPopup\u003Ec__Iterator258()
    {
      \u003C\u003Ef__this = this
    };
  }
}
