// Decompiled with JetBrains decompiler
// Type: Popup002HuntingRewardReceiveMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  public IEnumerator Init(int allPlayerPoint, int playerPoint, int[] getRewardIds, bool isGuild)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002HuntingRewardReceiveMenu.\u003CInit\u003Ec__Iterator927()
    {
      isGuild = isGuild,
      allPlayerPoint = allPlayerPoint,
      playerPoint = playerPoint,
      getRewardIds = getRewardIds,
      \u003C\u0024\u003EisGuild = isGuild,
      \u003C\u0024\u003EallPlayerPoint = allPlayerPoint,
      \u003C\u0024\u003EplayerPoint = playerPoint,
      \u003C\u0024\u003EgetRewardIds = getRewardIds,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002HuntingRewardReceiveMenu.\u003CStartScroll\u003Ec__Iterator928()
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
