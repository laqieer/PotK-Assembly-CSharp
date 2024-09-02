// Decompiled with JetBrains decompiler
// Type: Quest0022MissionCompleteList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0022MissionCompleteList : Quest0022MissionList
{
  private GameObject prefabEffectComp;
  private string rewardMessage;

  [DebuggerHidden]
  public IEnumerator SetParameter(
    QuestStoryMission mission,
    string rewardTitle,
    bool clearFlag,
    bool battleFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionCompleteList.\u003CSetParameter\u003Ec__Iterator25C()
    {
      mission = mission,
      rewardTitle = rewardTitle,
      clearFlag = clearFlag,
      battleFlag = battleFlag,
      \u003C\u0024\u003Emission = mission,
      \u003C\u0024\u003ErewardTitle = rewardTitle,
      \u003C\u0024\u003EclearFlag = clearFlag,
      \u003C\u0024\u003EbattleFlag = battleFlag,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetParameter(
    QuestExtraMission mission,
    string rewardTitle,
    bool clearFlag,
    bool battleFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionCompleteList.\u003CSetParameter\u003Ec__Iterator25D()
    {
      mission = mission,
      rewardTitle = rewardTitle,
      clearFlag = clearFlag,
      battleFlag = battleFlag,
      \u003C\u0024\u003Emission = mission,
      \u003C\u0024\u003ErewardTitle = rewardTitle,
      \u003C\u0024\u003EclearFlag = clearFlag,
      \u003C\u0024\u003EbattleFlag = battleFlag,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetParameter(
    string missionName,
    string rewardTitle,
    bool clearFlag,
    MasterDataTable.CommonRewardType rewardType,
    int rewardId,
    int quantity,
    bool battleFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionCompleteList.\u003CSetParameter\u003Ec__Iterator25E()
    {
      missionName = missionName,
      clearFlag = clearFlag,
      rewardType = rewardType,
      rewardId = rewardId,
      quantity = quantity,
      battleFlag = battleFlag,
      rewardTitle = rewardTitle,
      \u003C\u0024\u003EmissionName = missionName,
      \u003C\u0024\u003EclearFlag = clearFlag,
      \u003C\u0024\u003ErewardType = rewardType,
      \u003C\u0024\u003ErewardId = rewardId,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003EbattleFlag = battleFlag,
      \u003C\u0024\u003ErewardTitle = rewardTitle,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CompletedPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionCompleteList.\u003CCompletedPopup\u003Ec__Iterator25F()
    {
      \u003C\u003Ef__this = this
    };
  }
}
