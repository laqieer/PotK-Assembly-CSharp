// Decompiled with JetBrains decompiler
// Type: Versus02614Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02614Scene : NGSceneBase
{
  [SerializeField]
  private Versus02614Menu menu;

  public static void ChangeScene(
    bool stack,
    WebAPI.Response.PvpBoot pvpInfo,
    RankingGroup[] ranking_data)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_14", (stack ? 1 : 0) != 0, (object) pvpInfo, (object) ranking_data);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614Scene.\u003ConInitSceneAsync\u003Ec__Iterator592()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(WebAPI.Response.PvpBoot pvpInfo, RankingGroup[] ranking_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614Scene.\u003ConStartSceneAsync\u003Ec__Iterator593()
    {
      pvpInfo = pvpInfo,
      ranking_data = ranking_data,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u0024\u003Eranking_data = ranking_data,
      \u003C\u003Ef__this = this
    };
  }

  public RankingGroup[] SettingDebug()
  {
    List<PvPRankingPlayer> pvPrankingPlayerList = new List<PvPRankingPlayer>();
    PvPRankingPlayer pvPrankingPlayer1 = new PvPRankingPlayer()
    {
      ranking = 10000,
      ranking_pt = 40,
      current_emblem_id = Player.Current.current_emblem_id,
      leader_unit_id = 401123,
      leader_unit_level = 100,
      total_win = 10,
      player_id = Player.Current.short_id,
      name = Player.Current.name,
      current_class_id = 5
    };
    PvPRankingPlayer pvPrankingPlayer2 = new PvPRankingPlayer()
    {
      ranking = 0,
      ranking_pt = 40,
      current_emblem_id = Player.Current.current_emblem_id,
      leader_unit_id = 401123,
      leader_unit_level = 100,
      total_win = 10,
      player_id = Player.Current.short_id,
      name = Player.Current.name,
      current_class_id = 5
    };
    for (int number = 1; number < 31; ++number)
    {
      PvPRankingPlayer pvPrankingPlayer3 = new PvPRankingPlayer()
      {
        ranking = number,
        ranking_pt = 1000000 - number * 2,
        current_emblem_id = number,
        leader_unit_id = 100111 + number % 6 * 100000,
        leader_unit_level = number % 100,
        total_win = number * 100,
        player_id = (number * 100).ToLocalizeNumberText(),
        name = number.ToLocalizeNumberText() + "あああああ",
        current_class_id = number % 9 + 1
      };
      pvPrankingPlayerList.Add(pvPrankingPlayer3);
    }
    return new RankingGroup[3]
    {
      new RankingGroup()
      {
        group_ranking = pvPrankingPlayerList.ToArray(),
        my_ranking = pvPrankingPlayer2,
        start_time = new DateTime?(new DateTime(2015, 10, 12)),
        finish_time = new DateTime?(new DateTime(2015, 10, 16)),
        reward_receivable_period = new DateTime?(new DateTime(2015, 10, 16)),
        period_id = 1
      },
      new RankingGroup()
      {
        group_ranking = pvPrankingPlayerList.ToArray(),
        my_ranking = pvPrankingPlayer2,
        start_time = new DateTime?(new DateTime(2015, 10, 12)),
        finish_time = new DateTime?(new DateTime(2015, 10, 16)),
        reward_receivable_period = new DateTime?(new DateTime(2015, 10, 16)),
        period_id = 1
      },
      new RankingGroup()
      {
        group_ranking = pvPrankingPlayerList.ToArray(),
        my_ranking = pvPrankingPlayer1,
        start_time = new DateTime?(new DateTime(2015, 9, 29)),
        finish_time = new DateTime?(new DateTime(2015, 10, 2)),
        reward_receivable_period = new DateTime?(new DateTime(2015, 10, 2)),
        period_id = 1
      }
    };
  }
}
