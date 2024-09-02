// Decompiled with JetBrains decompiler
// Type: Popup002HuntingRewardReceiveMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Popup002HuntingRewardReceiveMenu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject slcTouchToNext;
  [SerializeField]
  private UILabel txt_CharaEXP;
  [SerializeField]
  private GameObject dir_GuildHuntingPt;
  [SerializeField]
  private UILabel txt_GuildHuntingPt;
  [SerializeField]
  private GameObject dir_AllPlayerTotalHuntingPt;
  [SerializeField]
  private UILabel txt_AllPlayerTotalHuntingPt;
  [SerializeField]
  private UILabel txt_PlayerTotalHuntingPt;
  [SerializeField]
  private UILabel txt_PlayerTotalHunting;
  [SerializeField]
  private UILabel txt_CharaEXP_26;
  [SerializeField]
  private NGxScrollMasonry scroll;
  private System.Action tapCallback;
  private IEnumerable<IGrouping<Tuple<EventPointType, int>, PunitiveExpeditionEventReward>> rewardListGroup;

  [DebuggerHidden]
  public IEnumerator Init(
    int allPlayerPoint,
    int playerPoint,
    int[] getRewardIds,
    int[] getGuildRewardIds,
    bool isGuild)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002HuntingRewardReceiveMenu.\u003CInit\u003Ec__Iterator9FA()
    {
      isGuild = isGuild,
      allPlayerPoint = allPlayerPoint,
      playerPoint = playerPoint,
      getRewardIds = getRewardIds,
      getGuildRewardIds = getGuildRewardIds,
      \u003C\u0024\u003EisGuild = isGuild,
      \u003C\u0024\u003EallPlayerPoint = allPlayerPoint,
      \u003C\u0024\u003EplayerPoint = playerPoint,
      \u003C\u0024\u003EgetRewardIds = getRewardIds,
      \u003C\u0024\u003EgetGuildRewardIds = getGuildRewardIds,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002HuntingRewardReceiveMenu.\u003CStartScroll\u003Ec__Iterator9FB()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ResetScrollPosition()
  {
    this.scroll.Scroll.verticalScrollBar.value = 0.0f;
    this.scroll.ResolvePosition();
  }

  public void SetTapCallBack(System.Action callback) => this.tapCallback = callback;

  public void onTapToNext()
  {
    if (this.tapCallback == null)
      return;
    this.tapCallback();
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().onDismiss();
}
