﻿// Decompiled with JetBrains decompiler
// Type: PopupGuildCheckIn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Text;
using UnityEngine;

public class PopupGuildCheckIn : BackButtonMenuBase
{
  [SerializeField]
  private UILabel mRewardsTextLbl;
  [SerializeField]
  private Animator mAnimator;

  public void Initialize(WebAPI.Response.GuildCheckin response)
  {
    StringBuilder stringBuilder = new StringBuilder();
    foreach (PlayerPresent playerPresent in response.player_presents)
    {
      if (stringBuilder.Length > 0)
        stringBuilder.Append("\n");
      string rewardName = CommonRewardType.GetRewardName((MasterDataTable.CommonRewardType) playerPresent.reward_type_id.Value, playerPresent.reward_id.Value, playerPresent.reward_quantity.Value);
      stringBuilder.Append(rewardName + "GET");
    }
    this.mRewardsTextLbl.SetTextLocalize(stringBuilder.ToString());
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.mAnimator.SetTrigger("close");
    this.StartCoroutine(this.WaitForAnimationAndDismiss());
  }

  private IEnumerator WaitForAnimationAndDismiss()
  {
    do
    {
      yield return (object) null;
    }
    while ((double) this.mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0);
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
