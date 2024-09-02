// Decompiled with JetBrains decompiler
// Type: DailyMission0271MissonReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271MissonReward : MonoBehaviour
{
  [SerializeField]
  private UILabel rewardName;
  [SerializeField]
  private CreateIconObject rewardThum;

  [DebuggerHidden]
  public IEnumerator Init(MasterDataTable.CommonRewardType type, int id, int quantity)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271MissonReward.\u003CInit\u003Ec__Iterator6C5()
    {
      type = type,
      id = id,
      quantity = quantity,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u003Ef__this = this
    };
  }
}
