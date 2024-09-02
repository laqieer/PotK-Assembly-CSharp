// Decompiled with JetBrains decompiler
// Type: GameCore.ColosseumInitialData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;

#nullable disable
namespace GameCore
{
  public class ColosseumInitialData
  {
    public string transaction_id;
    public PlayerUnit[] player_unit_list;
    public PlayerItem[] player_gear_list;
    public PlayerUnit[] opponent_unit_list;
    public PlayerItem[] opponent_gear_list;
    public Bonus[] bonusList;
    public DateTime now;

    public ColosseumInitialData()
    {
      this.transaction_id = "dummiy_date";
      this.player_unit_list = SMManager.Get<PlayerDeck[]>()[0].player_units;
      this.player_gear_list = SMManager.Get<PlayerItem[]>();
      this.opponent_unit_list = SMManager.Get<PlayerDeck[]>()[0].player_units;
      this.opponent_gear_list = SMManager.Get<PlayerItem[]>();
      this.bonusList = (Bonus[]) null;
      this.now = DateTime.Now;
    }

    public ColosseumInitialData(WebAPI.Response.ColosseumStart response, int bonusTypeID)
    {
      this.transaction_id = response.arena_transaction_id;
      this.player_unit_list = response.colosseum_player_units;
      this.player_gear_list = response.colosseum_player_items;
      this.opponent_unit_list = response.colosseum_target_player_units;
      this.opponent_gear_list = response.colosseum_target_player_items;
      this.bonusList = response.bonus;
      this.now = response.now;
    }

    public ColosseumInitialData(WebAPI.Response.ColosseumTutorialStart response, int bonusTypeID)
    {
      this.transaction_id = response.arena_transaction_id;
      this.player_unit_list = response.colosseum_player_units;
      this.player_gear_list = response.colosseum_player_items;
      this.opponent_unit_list = response.colosseum_target_player_units;
      this.opponent_gear_list = response.colosseum_target_player_items;
      this.bonusList = response.bonus;
      this.now = response.now;
    }

    public ColosseumInitialData(WebAPI.Response.ColosseumResume response, int bonusTypeID)
    {
      this.transaction_id = response.arena_transaction_id;
      this.player_unit_list = response.colosseum_player_units;
      this.player_gear_list = response.colosseum_player_items;
      this.opponent_unit_list = response.colosseum_target_player_units;
      this.opponent_gear_list = response.colosseum_target_player_items;
      this.bonusList = response.bonus;
      this.now = response.now;
    }

    public ColosseumInitialData(WebAPI.Response.ColosseumTutorialResume response, int bonusTypeID)
    {
      this.transaction_id = response.arena_transaction_id;
      this.player_unit_list = response.colosseum_player_units;
      this.player_gear_list = response.colosseum_player_items;
      this.opponent_unit_list = response.colosseum_target_player_units;
      this.opponent_gear_list = response.colosseum_target_player_items;
      this.bonusList = response.bonus;
      this.now = response.now;
    }
  }
}
