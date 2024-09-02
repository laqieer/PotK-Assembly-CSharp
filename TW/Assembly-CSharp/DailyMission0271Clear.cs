// Decompiled with JetBrains decompiler
// Type: DailyMission0271Clear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271Clear : BackButtonMonoBehaiviour
{
  private const int FONT_PIXEL_HIGHT = 38;
  [SerializeField]
  private List<GameObject> linkObjects;
  [SerializeField]
  private UISprite slcTxtBox;
  [SerializeField]
  private UILabel txtRwardMessage;
  [SerializeField]
  private GameObject[] objTragerBox;
  [SerializeField]
  private GameObject objHimeishi;
  [SerializeField]
  private GameObject dirEffect;

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  public IEnumerator SetClearBonus(Hashtable[] Rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Clear.\u003CSetClearBonus\u003Ec__Iterator6B3()
    {
      Rewards = Rewards,
      \u003C\u0024\u003ERewards = Rewards,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetClearBonus(BingoRewardGroup[] Rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Clear.\u003CSetClearBonus\u003Ec__Iterator6B4()
    {
      Rewards = Rewards,
      \u003C\u0024\u003ERewards = Rewards,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetClearBonus(DailyMission0272Panel.RewardViewModel[] Rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Clear.\u003CSetClearBonus\u003Ec__Iterator6B5()
    {
      Rewards = Rewards,
      \u003C\u0024\u003ERewards = Rewards,
      \u003C\u003Ef__this = this
    };
  }
}
