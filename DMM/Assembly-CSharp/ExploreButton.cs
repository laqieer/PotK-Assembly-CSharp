﻿// Decompiled with JetBrains decompiler
// Type: ExploreButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ExploreButton : MypageEventButton
{
  [SerializeField]
  private UIButton ExploreBtn;

  public override bool IsActive()
  {
    if (!Singleton<TutorialRoot>.GetInstance().IsTutorialFinish())
      return false;
    ExploreDataManager instance = Singleton<ExploreDataManager>.GetInstance();
    return instance.IsNotRegisteredDeck() ? !(instance.LastSyncTime > ServerTime.NowAppTimeAddDelta()) : !instance.IsRankingAcceptanceFinish;
  }

  public override bool IsBadge()
  {
    ExploreDataManager instance = Singleton<ExploreDataManager>.GetInstance();
    return !instance.IsNotRegisteredDeck() && instance.NeedShowBadge;
  }

  public override void SetActive(bool value)
  {
    this.ExploreBtn.isEnabled = value;
    this.SetBadgeActive(false);
  }
}
