// Decompiled with JetBrains decompiler
// Type: SM.PlayerMaterialGear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerMaterialGear : KeyCompare
  {
    public bool isEarthMode;
    public string player_id;
    public int gear_id;
    public int id;
    public int quantity;

    public PlayerMaterialGear()
    {
    }

    public PlayerMaterialGear(Dictionary<string, object> json)
    {
      this._hasKey = true;
      this.player_id = (string) json[nameof (player_id)];
      this.gear_id = (int) (long) json[nameof (gear_id)];
      this._key = (object) (this.id = (int) (long) json[nameof (id)]);
      this.quantity = (int) (long) json[nameof (quantity)];
    }

    public override bool Equals(object rhs) => this.Equals(rhs as PlayerMaterialGear);

    public override int GetHashCode() => 0;

    public bool Equals(PlayerMaterialGear rhs)
    {
      if (object.ReferenceEquals((object) rhs, (object) null))
        return false;
      if (object.ReferenceEquals((object) this, (object) rhs))
        return true;
      return (object) this.GetType() == (object) rhs.GetType() && this.id == rhs.id && this.entity_type == rhs.entity_type && this.player_id == rhs.player_id;
    }

    public bool ForBattle => false;

    public string name => this.gear.name;

    public MasterDataTable.CommonRewardType entity_type => MasterDataTable.CommonRewardType.gear;

    public GearGear gear => MasterData.GearGear[this.gear_id];

    public SupplySupply supply => (SupplySupply) null;

    public int hp_incremental => 0;

    public int strength_incremental => this.gear.strength_incremental;

    public int vitality_incremental => this.gear.vitality_incremental;

    public int intelligence_incremental => this.gear.intelligence_incremental;

    public int mind_incremental => this.gear.mind_incremental;

    public int agility_incremental => this.gear.agility_incremental;

    public int dexterity_incremental => this.gear.dexterity_incremental;

    public int lucky_incremental => this.gear.lucky_incremental;

    public GearGearSkill[] skills => (GearGearSkill[]) null;

    public static PlayerMaterialGear CreateForKey(int id)
    {
      PlayerMaterialGear forKey = new PlayerMaterialGear();
      forKey._hasKey = true;
      forKey._key = (object) (forKey.id = id);
      return forKey;
    }

    public bool isWeapon() => !this.isSupply() && !this.isCompse() && !this.isExchangable();

    public bool isSupply() => this.entity_type == MasterDataTable.CommonRewardType.supply;

    public bool isCompse()
    {
      return !this.isSupply() && (this.gear.kind.Enum == GearKindEnum.smith && this.gear.compose_kind.kind.Enum != GearKindEnum.smith || this.gear.kind.Enum == GearKindEnum.drilling || this.gear.kind.Enum == GearKindEnum.special_drilling);
    }

    public bool isDilling() => !this.isSupply() && this.gear.kind.Enum == GearKindEnum.drilling;

    public bool isSpecialDilling()
    {
      return !this.isSupply() && this.gear.kind.Enum == GearKindEnum.special_drilling;
    }

    public bool isExchangable()
    {
      return this.gear != null && !this.isSupply() && this.gear.kind.Enum == GearKindEnum.smith && this.gear.compose_kind.kind.Enum == GearKindEnum.smith;
    }

    public CommonElement GetElement()
    {
      CommonElement element = CommonElement.none;
      IEnumerable<GearGearSkill> source = ((IEnumerable<GearGearSkill>) this.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element))));
      if (source.Count<GearGearSkill>() > 0)
        element = source.First<GearGearSkill>().skill.element;
      return element;
    }

    public static bool operator ==(PlayerMaterialGear lhs, PlayerMaterialGear rhs)
    {
      return object.ReferenceEquals((object) lhs, (object) null) ? object.ReferenceEquals((object) rhs, (object) null) : lhs.Equals(rhs);
    }

    public static bool operator !=(PlayerMaterialGear lhs, PlayerMaterialGear rhs) => !(lhs == rhs);
  }
}
