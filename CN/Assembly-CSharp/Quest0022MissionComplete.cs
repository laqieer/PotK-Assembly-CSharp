// Decompiled with JetBrains decompiler
// Type: Quest0022MissionComplete
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Quest0022MissionComplete.\u003CmissionCompleteRate\u003Ec__Iterator222()
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
    return (IEnumerator) new Quest0022MissionComplete.\u003CsetDetailPopup\u003Ec__Iterator223()
    {
      \u003C\u003Ef__this = this
    };
  }
}
