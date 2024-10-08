﻿// Decompiled with JetBrains decompiler
// Type: DailyMission0271CompRewardPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using UnityEngine;

public class DailyMission0271CompRewardPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UIButton YesButton;
  [SerializeField]
  private UIButton NgButton;
  [SerializeField]
  private CreateIconObject RewardThumb;
  [SerializeField]
  private UILabel rewardName;
  private System.Action yesCallback;
  private System.Action noCallback;

  public IEnumerator Init(BingoRewardGroup completeReward, System.Action yes = null, System.Action no = null)
  {
    this.rewardName.SetTextLocalize(CommonRewardType.GetRewardName(completeReward.reward_type_id, completeReward.reward_id, completeReward.reward_quantity));
    IEnumerator e = this.RewardThumb.CreateThumbnail(completeReward.reward_type_id, completeReward.reward_id, completeReward.reward_quantity);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.yesCallback = yes;
    this.noCallback = no;
  }

  public void IbtnNo()
  {
    if (this.noCallback != null)
      this.noCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnYes()
  {
    if (this.yesCallback != null)
      this.yesCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
