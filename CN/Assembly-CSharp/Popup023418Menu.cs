// Decompiled with JetBrains decompiler
// Type: Popup023418Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup023418Menu : NGMenuBase
{
  protected System.Action onCallback;
  [SerializeField]
  private UILabel TxtDescription1;
  [SerializeField]
  private UILabel TxtDescription2;
  [SerializeField]
  private GameObject link_Icon;

  protected string GetRewardTypeText(MasterDataTable.CommonRewardType type)
  {
    string rewardTypeText = string.Empty;
    if (type != MasterDataTable.CommonRewardType.money && type != MasterDataTable.CommonRewardType.peculiar && type != MasterDataTable.CommonRewardType.player_exp && type != MasterDataTable.CommonRewardType.unit_exp && type != MasterDataTable.CommonRewardType.gear_experience_point && type != MasterDataTable.CommonRewardType.gear_training_point && type != MasterDataTable.CommonRewardType.coin && type != MasterDataTable.CommonRewardType.recover && type != MasterDataTable.CommonRewardType.max_unit && type != MasterDataTable.CommonRewardType.max_item && type != MasterDataTable.CommonRewardType.medal && type != MasterDataTable.CommonRewardType.friend_point && type != MasterDataTable.CommonRewardType.deck && type == MasterDataTable.CommonRewardType.battle_medal)
      rewardTypeText = Consts.GetInstance().UNIQUE_ICON_BATTLE_MEDAL;
    return rewardTypeText;
  }

  protected string GetRewardTypeUnitText(MasterDataTable.CommonRewardType type)
  {
    string rewardTypeUnitText = string.Empty;
    if (type != MasterDataTable.CommonRewardType.money && type != MasterDataTable.CommonRewardType.peculiar && type != MasterDataTable.CommonRewardType.player_exp && type != MasterDataTable.CommonRewardType.unit_exp && type != MasterDataTable.CommonRewardType.gear_experience_point && type != MasterDataTable.CommonRewardType.gear_training_point && type != MasterDataTable.CommonRewardType.coin && type != MasterDataTable.CommonRewardType.recover && type != MasterDataTable.CommonRewardType.max_unit && type != MasterDataTable.CommonRewardType.max_item && type != MasterDataTable.CommonRewardType.medal && type != MasterDataTable.CommonRewardType.friend_point && type != MasterDataTable.CommonRewardType.deck && type == MasterDataTable.CommonRewardType.battle_medal)
      rewardTypeUnitText = Consts.GetInstance().UNIQUE_ICON_MEDAL_COUNT;
    return rewardTypeUnitText;
  }

  [DebuggerHidden]
  public IEnumerator Init(ResultMenuBase.BonusReward reward, int totalWin)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup023418Menu.\u003CInit\u003Ec__Iterator949()
    {
      reward = reward,
      totalWin = totalWin,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u0024\u003EtotalWin = totalWin,
      \u003C\u003Ef__this = this
    };
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  public virtual void IbtnOK()
  {
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
