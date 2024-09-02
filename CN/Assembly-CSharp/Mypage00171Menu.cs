// Decompiled with JetBrains decompiler
// Type: Mypage00171Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Mypage00171Menu : BackButtonMenuBase
{
  public NGxScroll scroll;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UILabel TxtPopuptitle;

  private PlayerPresent CreatePresentData(PlayerPresent[] presents, int rewardTypeID)
  {
    PlayerPresent present = new PlayerPresent();
    present.reward_type_id = new int?(rewardTypeID);
    present.reward_quantity = new int?(0);
    ((IEnumerable<PlayerPresent>) presents).Where<PlayerPresent>((Func<PlayerPresent, bool>) (x =>
    {
      int? rewardTypeId = x.reward_type_id;
      return rewardTypeId.GetValueOrDefault() == rewardTypeID && rewardTypeId.HasValue;
    })).ForEach<PlayerPresent>((Action<PlayerPresent>) (x =>
    {
      PlayerPresent playerPresent = present;
      int? rewardQuantity1 = playerPresent.reward_quantity;
      int? nullable;
      if (rewardQuantity1.HasValue)
      {
        int? rewardQuantity2 = x.reward_quantity;
        if (rewardQuantity2.HasValue)
        {
          nullable = new int?(rewardQuantity1.Value + rewardQuantity2.Value);
          goto label_4;
        }
      }
      nullable = new int?();
label_4:
      playerPresent.reward_quantity = nullable;
    }));
    int? rewardQuantity = present.reward_quantity;
    return (rewardQuantity.GetValueOrDefault() != 0 ? 0 : (rewardQuantity.HasValue ? 1 : 0)) != 0 ? (PlayerPresent) null : present;
  }

  private PlayerPresent[] CreatePresentDataByGroup(PlayerPresent[] presents, int rewardTypeID)
  {
    List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
    foreach (IGrouping<int, PlayerPresent> self in ((IEnumerable<PlayerPresent>) presents).Where<PlayerPresent>((Func<PlayerPresent, bool>) (x =>
    {
      int? rewardTypeId = x.reward_type_id;
      return rewardTypeId.GetValueOrDefault() == rewardTypeID && rewardTypeId.HasValue;
    })).GroupBy<PlayerPresent, int>((Func<PlayerPresent, int>) (x => x.reward_id.Value)).ToArray<IGrouping<int, PlayerPresent>>())
    {
      PlayerPresent present = new PlayerPresent();
      present.reward_type_id = new int?(rewardTypeID);
      present.reward_quantity = new int?(0);
      self.ForEach<PlayerPresent>((Action<PlayerPresent>) (x =>
      {
        PlayerPresent playerPresent = present;
        int? rewardQuantity1 = playerPresent.reward_quantity;
        int? nullable;
        if (rewardQuantity1.HasValue)
        {
          int? rewardQuantity2 = x.reward_quantity;
          if (rewardQuantity2.HasValue)
          {
            nullable = new int?(rewardQuantity1.Value + rewardQuantity2.Value);
            goto label_4;
          }
        }
        nullable = new int?();
label_4:
        playerPresent.reward_quantity = nullable;
        present.reward_id = x.reward_id;
      }));
      int? rewardQuantity = present.reward_quantity;
      if ((rewardQuantity.GetValueOrDefault() != 0 ? 1 : (!rewardQuantity.HasValue ? 1 : 0)) != 0)
        playerPresentList.Add(present);
    }
    return playerPresentList.Count == 0 ? (PlayerPresent[]) null : playerPresentList.ToArray();
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerPresent[] presents)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00171Menu.\u003CInit\u003Ec__Iterator1A2()
    {
      presents = presents,
      \u003C\u0024\u003Epresents = presents,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
