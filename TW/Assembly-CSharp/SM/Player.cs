// Decompiled with JetBrains decompiler
// Type: SM.Player
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class Player : KeyCompare
  {
    public string comment;
    public int bp_full_remain;
    public int mp_max;
    public int money;
    public int ap_max;
    public int ap_auto_healing_sec;
    public int ap_full_remain;
    public int max_friends;
    public int ap;
    public int battle_medal;
    public int max_units;
    public int friend_point;
    public int continuation_date;
    public int max_items_cap;
    public int next_panel_mission_id;
    public bool is_bingo_end;
    public int max_cost;
    public string id;
    public int common_coin;
    public DateTime mp_full_recovery_at;
    public bool is_open_activity;
    public int? game_over_count;
    public bool is_open_bingo;
    public int mp;
    public int ap_overflow;
    public int friends_count;
    public bool is_open_mission;
    public int bp_max;
    public int bp;
    public int medal;
    public int exp_next;
    public string name;
    public string extension;
    public int level;
    public int free_coin;
    public int max_items;
    public int total_exp;
    public PlayerGachaTicket[] gacha_tickets;
    public int max_friends_cap;
    public string short_id;
    public int max_units_cap;
    public int exp;
    public int current_emblem_id;
    public int bp_auto_healing_sec;
    public int paid_coin;
    public PlayerClear_daily_mission_ids clear_daily_mission_ids;

    public Player()
    {
    }

    public Player(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.comment = (string) json[nameof (comment)];
      this.bp_full_remain = (int) (long) json[nameof (bp_full_remain)];
      this.mp_max = (int) (long) json[nameof (mp_max)];
      this.money = (int) (long) json[nameof (money)];
      this.ap_max = (int) (long) json[nameof (ap_max)];
      this.ap_auto_healing_sec = (int) (long) json[nameof (ap_auto_healing_sec)];
      this.ap_full_remain = (int) (long) json[nameof (ap_full_remain)];
      this.max_friends = (int) (long) json[nameof (max_friends)];
      this.ap = (int) (long) json[nameof (ap)];
      this.battle_medal = (int) (long) json[nameof (battle_medal)];
      this.max_units = (int) (long) json[nameof (max_units)];
      this.friend_point = (int) (long) json[nameof (friend_point)];
      this.continuation_date = (int) (long) json[nameof (continuation_date)];
      this.max_items_cap = (int) (long) json[nameof (max_items_cap)];
      this.next_panel_mission_id = (int) (long) json[nameof (next_panel_mission_id)];
      this.is_bingo_end = (bool) json[nameof (is_bingo_end)];
      this.max_cost = (int) (long) json[nameof (max_cost)];
      this.id = (string) json[nameof (id)];
      this.common_coin = (int) (long) json[nameof (common_coin)];
      this.mp_full_recovery_at = DateTime.Parse((string) json[nameof (mp_full_recovery_at)]);
      this.is_open_activity = (bool) json[nameof (is_open_activity)];
      int? nullable1;
      if (json[nameof (game_over_count)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (game_over_count)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.game_over_count = nullable1;
      this.is_open_bingo = (bool) json[nameof (is_open_bingo)];
      this.mp = (int) (long) json[nameof (mp)];
      this.ap_overflow = (int) (long) json[nameof (ap_overflow)];
      this.friends_count = (int) (long) json[nameof (friends_count)];
      this.is_open_mission = (bool) json[nameof (is_open_mission)];
      this.bp_max = (int) (long) json[nameof (bp_max)];
      this.bp = (int) (long) json[nameof (bp)];
      this.medal = (int) (long) json[nameof (medal)];
      this.exp_next = (int) (long) json[nameof (exp_next)];
      this.name = (string) json[nameof (name)];
      this.extension = (string) json[nameof (extension)];
      this.level = (int) (long) json[nameof (level)];
      this.free_coin = (int) (long) json[nameof (free_coin)];
      this.max_items = (int) (long) json[nameof (max_items)];
      this.total_exp = (int) (long) json[nameof (total_exp)];
      List<PlayerGachaTicket> playerGachaTicketList = new List<PlayerGachaTicket>();
      foreach (object json1 in (List<object>) json[nameof (gacha_tickets)])
        playerGachaTicketList.Add(json1 != null ? new PlayerGachaTicket((Dictionary<string, object>) json1) : (PlayerGachaTicket) null);
      this.gacha_tickets = playerGachaTicketList.ToArray();
      this.max_friends_cap = (int) (long) json[nameof (max_friends_cap)];
      this.short_id = (string) json[nameof (short_id)];
      this.max_units_cap = (int) (long) json[nameof (max_units_cap)];
      this.exp = (int) (long) json[nameof (exp)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.bp_auto_healing_sec = (int) (long) json[nameof (bp_auto_healing_sec)];
      this.paid_coin = (int) (long) json[nameof (paid_coin)];
      this.clear_daily_mission_ids = json[nameof (clear_daily_mission_ids)] != null ? new PlayerClear_daily_mission_ids((Dictionary<string, object>) json[nameof (clear_daily_mission_ids)]) : (PlayerClear_daily_mission_ids) null;
    }

    public Player Clone() => (Player) this.MemberwiseClone();

    public static Player Current => SMManager.Get<Player>();

    public int coin => this.free_coin + this.paid_coin + this.common_coin;

    public bool CheckZeny(int useZeny) => this.money >= useZeny;

    public bool CheckLimitMaxItem() => this.max_items >= this.max_items_cap;

    public bool ExpandLimitItem(int num)
    {
      if (this.CheckLimitMaxItem())
        return false;
      this.max_items += num;
      return true;
    }

    public bool CheckMaxItem(int num) => num >= this.max_items;

    public bool CheckMaxItem()
    {
      return this.CheckMaxItem(((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.entity_type == MasterDataTable.CommonRewardType.gear)).ToArray<PlayerItem>().Length);
    }

    public bool CheckLimitMaxUnit() => this.max_units >= this.max_units_cap;

    public bool CheckMaxUnit(int num) => num >= this.max_units;

    public bool CheckMaxUnit() => this.CheckMaxUnit(SMManager.Get<PlayerUnit[]>().Length);

    public bool CheckCapMaxUnit(int num) => num >= this.max_units_cap;

    public bool CheckCapMaxUnit() => this.CheckCapMaxUnit(SMManager.Get<PlayerUnit[]>().Length);

    public bool CheckKiseki(int num) => this.coin >= num;

    public bool CheckFrendPoint(int num) => this.friend_point >= num;

    public bool CheckApFull() => this.ap >= this.ap_max;

    public bool CheckAp(int num) => this.ap >= num;

    private bool ContainsExtension(string str)
    {
      bool res = false;
      ((IEnumerable<string>) this.extension.Split(':')).ForEach<string>((Action<string>) (x =>
      {
        if (!(x == str))
          return;
        res = true;
      }));
      return res;
    }

    public bool GetFeatureColosseum() => this.ContainsExtension("colosseum");

    public bool GetReleaseColosseum() => this.ContainsExtension("colosseum_unlock");

    public bool GetReleaseSlot() => this.ContainsExtension("is_open_slot");

    public bool GetFeatureColosseumRanking() => this.ContainsExtension("colosseum_ranking");

    public bool IsColosseum() => this.GetFeatureColosseum() && this.GetReleaseColosseum();

    public bool IsPvp() => this.ContainsExtension("pvp");

    public bool IsClassMatch() => this.ContainsExtension("class_match");

    public bool IsClassMatchRanking() => this.ContainsExtension("class_ranking");

    public bool IsClassMatchShowRanking() => this.ContainsExtension("class_show_ranking");

    public bool IsMission() => this.ContainsExtension("dailymission");

    public bool IsSkipDuel() => this.ContainsExtension("battle_skip_ani");

    public bool IsCombiQuest() => this.ContainsExtension("combi_quest");

    public bool IsGearRecipe() => this.ContainsExtension("gear_recipe");

    public bool IsGearBuildup() => this.ContainsExtension("gear_buildup");

    public bool IsEnableDarkAndHoly() => this.ContainsExtension("enable_light_darkness");

    public bool IsUniteReinfoce() => this.ContainsExtension("unit_buildup");

    public bool IsGearDrilling() => this.ContainsExtension("gear_drilling");

    public bool IsGuildOpen() => this.ContainsExtension("guild");

    public bool IsGuildMatingOpen() => this.ContainsExtension("gvg");
  }
}
