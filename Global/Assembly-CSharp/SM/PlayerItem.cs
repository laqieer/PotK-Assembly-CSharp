// Decompiled with JetBrains decompiler
// Type: SM.PlayerItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerItem : KeyCompare
  {
    private const string nameFormat = "{0}+{1}";
    public const int DEFAULT_LIMIT = 5;
    public bool isEarthMode;
    public int gear_accessory_remaining_amount;
    public int entity_id;
    public PlayerGearBuildupParam gear_buildup_param;
    public bool for_battle;
    public int box_type_id;
    public int _entity_type;
    public int gear_level;
    public bool favorite;
    public int gear_exp_next;
    public bool is_new;
    public bool broken;
    public string player_id;
    public int gear_level_unlimit;
    public int gear_level_limit_max;
    public int gear_total_exp;
    public int gear_exp;
    public int id;
    public int gear_level_limit;
    public int quantity;

    public PlayerItem()
    {
    }

    public PlayerItem(Dictionary<string, object> json)
    {
      this._hasKey = true;
      this.gear_accessory_remaining_amount = (int) (long) json[nameof (gear_accessory_remaining_amount)];
      this.entity_id = (int) (long) json[nameof (entity_id)];
      this.gear_buildup_param = json[nameof (gear_buildup_param)] != null ? new PlayerGearBuildupParam((Dictionary<string, object>) json[nameof (gear_buildup_param)]) : (PlayerGearBuildupParam) null;
      this.for_battle = (bool) json[nameof (for_battle)];
      this.box_type_id = (int) (long) json[nameof (box_type_id)];
      this._entity_type = (int) (long) json[nameof (_entity_type)];
      this.gear_level = (int) (long) json[nameof (gear_level)];
      this.favorite = (bool) json[nameof (favorite)];
      this.gear_exp_next = (int) (long) json[nameof (gear_exp_next)];
      this.is_new = (bool) json[nameof (is_new)];
      this.broken = (bool) json[nameof (broken)];
      this.player_id = (string) json[nameof (player_id)];
      this.gear_level_unlimit = (int) (long) json[nameof (gear_level_unlimit)];
      this.gear_level_limit_max = (int) (long) json[nameof (gear_level_limit_max)];
      this.gear_total_exp = (int) (long) json[nameof (gear_total_exp)];
      this.gear_exp = (int) (long) json[nameof (gear_exp)];
      this._key = (object) (this.id = (int) (long) json[nameof (id)]);
      this.gear_level_limit = (int) (long) json[nameof (gear_level_limit)];
      this.quantity = (int) (long) json[nameof (quantity)];
    }

    public override bool Equals(object rhs) => this.Equals(rhs as PlayerItem);

    public override int GetHashCode() => 0;

    public bool Equals(PlayerItem rhs)
    {
      if (object.ReferenceEquals((object) rhs, (object) null))
        return false;
      if (object.ReferenceEquals((object) this, (object) rhs))
        return true;
      return (object) this.GetType() == (object) rhs.GetType() && this.id == rhs.id && this.entity_type == rhs.entity_type && this.player_id == rhs.player_id;
    }

    public bool ForBattle
    {
      get
      {
        if (this.entity_type == MasterDataTable.CommonRewardType.gear)
        {
          PlayerUnit[] source = SMManager.Get<PlayerUnit[]>();
          return source != null && ((IEnumerable<PlayerUnit>) source).Any<PlayerUnit>((Func<PlayerUnit, bool>) (x => ((IEnumerable<int?>) x.equip_gear_ids).Contains<int?>(new int?(this.id))));
        }
        return this.entity_type == MasterDataTable.CommonRewardType.supply && this.box_type_id == 2;
      }
    }

    public string name
    {
      get
      {
        if (this.gear == null)
          return this.supply.name;
        if (this.gear_level_unlimit <= 0)
          return this.gear.name;
        return "{0}+{1}".F((object) this.gear.name, (object) this.gear_level_unlimit);
      }
    }

    public MasterDataTable.CommonRewardType entity_type => (MasterDataTable.CommonRewardType) this._entity_type;

    public GearGear gear
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? MasterData.GearGear[this.entity_id] : (GearGear) null;
      }
    }

    public SupplySupply supply
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.supply ? MasterData.SupplySupply[this.entity_id] : (SupplySupply) null;
      }
    }

    public int hp_incremental
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? this.gear.hp_incremental + this.gear_buildup_param.hp_add : 0;
      }
    }

    public int strength_incremental
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? this.gear.strength_incremental + this.gear_buildup_param.strength_add : 0;
      }
    }

    public int vitality_incremental
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? this.gear.vitality_incremental + this.gear_buildup_param.vitality_add : 0;
      }
    }

    public int intelligence_incremental
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? this.gear.intelligence_incremental + this.gear_buildup_param.intelligence_add : 0;
      }
    }

    public int mind_incremental
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? this.gear.mind_incremental + this.gear_buildup_param.mind_add : 0;
      }
    }

    public int agility_incremental
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? this.gear.agility_incremental + this.gear_buildup_param.agility_add : 0;
      }
    }

    public int dexterity_incremental
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? this.gear.dexterity_incremental + this.gear_buildup_param.dexterity_add : 0;
      }
    }

    public int lucky_incremental
    {
      get
      {
        return this.entity_type == MasterDataTable.CommonRewardType.gear ? this.gear.lucky_incremental + this.gear_buildup_param.lucky_add : 0;
      }
    }

    public GearGearSkill[] skills
    {
      get
      {
        List<GearGearSkill> source1 = new List<GearGearSkill>();
        if (this.entity_type == MasterDataTable.CommonRewardType.gear)
        {
          List<GearGearSkill> list = ((IEnumerable<GearGearSkill>) MasterData.GearGearSkillList).Where<GearGearSkill>((Func<GearGearSkill, bool>) (x => x.gear.ID == this.entity_id && x.isReleased(this))).ToList<GearGearSkill>();
          if (list.Count > 0)
          {
            foreach (IGrouping<int, GearGearSkill> source2 in list.GroupBy<GearGearSkill, int>((Func<GearGearSkill, int>) (x => x.skill_group)))
              source1.Add(source2.OrderByDescending<GearGearSkill, int>((Func<GearGearSkill, int>) (x => x.release_rank)).First<GearGearSkill>());
          }
        }
        return source1.OrderBy<GearGearSkill, int>((Func<GearGearSkill, int>) (x => x.skill_group)).ToArray<GearGearSkill>();
      }
    }

    public static PlayerItem CreateForKey(int id)
    {
      PlayerItem forKey = new PlayerItem();
      forKey._hasKey = true;
      forKey._key = (object) (forKey.id = id);
      return forKey;
    }

    public bool isExchangable()
    {
      return this.gear.kind.Enum == GearKindEnum.smith && this.gear.compose_kind.kind.Enum == GearKindEnum.smith;
    }

    public CommonElement GetElement()
    {
      CommonElement element = CommonElement.none;
      IEnumerable<GearGearSkill> source = ((IEnumerable<GearGearSkill>) this.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element))));
      if (source.Count<GearGearSkill>() > 0)
        element = source.First<GearGearSkill>().skill.element;
      return element;
    }

    public static bool operator ==(PlayerItem lhs, PlayerItem rhs)
    {
      return object.ReferenceEquals((object) lhs, (object) null) ? object.ReferenceEquals((object) rhs, (object) null) : lhs.Equals(rhs);
    }

    public static bool operator !=(PlayerItem lhs, PlayerItem rhs) => !(lhs == rhs);
  }
}
