// Decompiled with JetBrains decompiler
// Type: Popup002HuntingNextRewardReceiveMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup002HuntingNextRewardReceiveMenu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject slcTouchToNext;
  [SerializeField]
  private UILabel txt_CharaEXP;
  [SerializeField]
  private NGxScrollMasonry scroll;
  private System.Action tapCallback;
  private List<PunitiveExpeditionEventReward> earchRewardList;
  private List<PunitiveExpeditionEventReward> totalRewardList;

  [DebuggerHidden]
  public IEnumerator Init(
    int periodID,
    int allPlayerPoint,
    int playerPoint,
    int guildPoint,
    bool isGuild)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002HuntingNextRewardReceiveMenu.\u003CInit\u003Ec__Iterator925()
    {
      periodID = periodID,
      playerPoint = playerPoint,
      allPlayerPoint = allPlayerPoint,
      guildPoint = guildPoint,
      isGuild = isGuild,
      \u003C\u0024\u003EperiodID = periodID,
      \u003C\u0024\u003EplayerPoint = playerPoint,
      \u003C\u0024\u003EallPlayerPoint = allPlayerPoint,
      \u003C\u0024\u003EguildPoint = guildPoint,
      \u003C\u0024\u003EisGuild = isGuild,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002HuntingNextRewardReceiveMenu.\u003CStartScroll\u003Ec__Iterator926()
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
