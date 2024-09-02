// Decompiled with JetBrains decompiler
// Type: GameCore.ItemInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  public class ItemInfo
  {
    public ItemInfo.ItemType itemType;
    public string name;
    public int itemID;
    public int masterID;
    public bool broken;
    public int gearLevel;
    public int gearLevelLimit;
    public int gearLevelUnLimit;
    public int gearExp;
    public int gearExpNext;
    public PlayerGearBuildupParam gearBuildupParam;
    public int gearAccessoryRemainingAmount;
    public int quantity;
    public bool ForBattle;
    public bool favorite;
    public bool isNew;
    public int sameItemIdx;

    public ItemInfo(ItemInfo.ItemType type, int sameIdx = 0)
    {
      this.itemID = 0;
      this.masterID = 0;
      this.broken = false;
      this.gearLevel = 1;
      this.gearLevelLimit = 0;
      this.gearLevelUnLimit = 0;
      this.gearExp = 0;
      this.gearExpNext = 0;
      this.gearBuildupParam = (PlayerGearBuildupParam) null;
      this.gearAccessoryRemainingAmount = 0;
      this.quantity = 1;
      this.ForBattle = false;
      this.favorite = false;
      this.isNew = false;
      this.itemType = type;
      this.sameItemIdx = sameIdx;
    }

    public ItemInfo(PlayerItem item) => this.Set(item);

    public ItemInfo(PlayerMaterialGear item, int sameIndex = 0)
    {
      this.Set(item);
      this.sameItemIdx = sameIndex;
    }

    public void Set(PlayerItem item)
    {
      this.itemID = item.id;
      this.broken = item.broken;
      this.gearLevel = item.gear_level;
      this.gearLevelLimit = item.gear_level_limit;
      this.gearLevelUnLimit = item.gear_level_unlimit;
      this.gearExp = item.gear_exp;
      this.gearExpNext = item.gear_exp_next;
      this.gearBuildupParam = (PlayerGearBuildupParam) null;
      this.gearAccessoryRemainingAmount = item.gear_accessory_remaining_amount;
      this.name = item.name;
      this.quantity = item.quantity >= 1 ? item.quantity : 1;
      this.ForBattle = item.ForBattle;
      this.favorite = item.favorite;
      this.isNew = item.is_new;
      if (item.isSupply())
      {
        this.itemType = ItemInfo.ItemType.Supply;
        this.masterID = item.supply.ID;
        this.quantity = item.quantity;
      }
      else
      {
        this.masterID = item.gear.ID;
        this.gearBuildupParam = (PlayerGearBuildupParam) null;
        if (item.isWeapon())
        {
          this.itemType = ItemInfo.ItemType.Gear;
          this.gearBuildupParam = item.gear_buildup_param;
        }
        else if (item.isCompse())
        {
          this.itemType = ItemInfo.ItemType.Compse;
        }
        else
        {
          if (!item.isExchangable())
            return;
          this.itemType = ItemInfo.ItemType.Exchangable;
        }
      }
    }

    public void Set(PlayerMaterialGear item)
    {
      this.itemID = item.id;
      this.masterID = item.gear_id;
      this.broken = false;
      this.gearLevel = 1;
      this.gearLevelLimit = 0;
      this.gearLevelUnLimit = 0;
      this.gearExp = 0;
      this.gearExpNext = 0;
      this.gearBuildupParam = (PlayerGearBuildupParam) null;
      this.gearAccessoryRemainingAmount = 0;
      this.name = item.name;
      this.quantity = item.quantity;
      this.ForBattle = false;
      this.favorite = false;
      this.isNew = false;
      if (item.isCompse())
      {
        this.itemType = ItemInfo.ItemType.Compse;
      }
      else
      {
        if (!item.isExchangable())
          return;
        this.itemType = ItemInfo.ItemType.Exchangable;
      }
    }

    public GearGear gear
    {
      get
      {
        return this.itemType == ItemInfo.ItemType.Supply ? (GearGear) null : MasterData.GearGear[this.masterID];
      }
    }

    public SupplySupply supply
    {
      get
      {
        return this.itemType != ItemInfo.ItemType.Supply ? (SupplySupply) null : MasterData.SupplySupply[this.masterID];
      }
    }

    public bool isWeapon => this.itemType == ItemInfo.ItemType.Gear;

    public bool isSupply => this.itemType == ItemInfo.ItemType.Supply;

    public bool isExchangable => this.itemType == ItemInfo.ItemType.Exchangable;

    public bool isCompse => this.itemType == ItemInfo.ItemType.Compse;

    public bool isDrilling
    {
      get
      {
        if (this.gear == null)
          return false;
        return this.gear.kind.Enum == GearKindEnum.drilling || this.gear.kind.Enum == GearKindEnum.special_drilling;
      }
    }

    public string Name() => this.name;

    public string Description()
    {
      return this.itemType == ItemInfo.ItemType.Supply ? this.supply.description : string.Empty;
    }

    public int SellPrice()
    {
      return this.itemType == ItemInfo.ItemType.Supply ? this.supply.sell_price : this.gear.sell_price;
    }

    public int RepairPrice()
    {
      int num = 0;
      if (this.itemType == ItemInfo.ItemType.Gear)
        num = this.gear.repair_price * (this.gearLevel + 1);
      return num;
    }

    public CommonElement GetElement()
    {
      CommonElement element = CommonElement.none;
      PlayerItem playerItem = ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).FirstOrDefault<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == this.itemID));
      if (playerItem != (PlayerItem) null)
      {
        IEnumerable<GearGearSkill> source = ((IEnumerable<GearGearSkill>) playerItem.skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (x => ((IEnumerable<BattleskillEffect>) x.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element))));
        if (source.Count<GearGearSkill>() > 0)
          element = source.First<GearGearSkill>().skill.element;
      }
      return element;
    }

    public GearGearSkill[] skills
    {
      get
      {
        List<GearGearSkill> source1 = new List<GearGearSkill>();
        if (this.isWeapon)
        {
          List<GearGearSkill> list = ((IEnumerable<GearGearSkill>) MasterData.GearGearSkillList).Where<GearGearSkill>((Func<GearGearSkill, bool>) (x => x.gear.ID == this.masterID && x.isReleased(this))).ToList<GearGearSkill>();
          if (list.Count > 0)
          {
            foreach (IGrouping<int, GearGearSkill> source2 in list.GroupBy<GearGearSkill, int>((Func<GearGearSkill, int>) (x => x.skill_group)))
              source1.Add(source2.OrderByDescending<GearGearSkill, int>((Func<GearGearSkill, int>) (x => x.release_rank)).First<GearGearSkill>());
          }
        }
        return source1.OrderBy<GearGearSkill, int>((Func<GearGearSkill, int>) (x => x.skill_group)).ToArray<GearGearSkill>();
      }
    }

    public int hp_incremental
    {
      get
      {
        return this.isWeapon && this.gearBuildupParam != null ? this.gear.hp_incremental + this.gearBuildupParam.hp_add : 0;
      }
    }

    public int strength_incremental
    {
      get
      {
        return this.isWeapon && this.gearBuildupParam != null ? this.gear.strength_incremental + this.gearBuildupParam.strength_add : 0;
      }
    }

    public int vitality_incremental
    {
      get
      {
        return this.isWeapon && this.gearBuildupParam != null ? this.gear.vitality_incremental + this.gearBuildupParam.vitality_add : 0;
      }
    }

    public int intelligence_incremental
    {
      get
      {
        return this.isWeapon && this.gearBuildupParam != null ? this.gear.intelligence_incremental + this.gearBuildupParam.intelligence_add : 0;
      }
    }

    public int mind_incremental
    {
      get
      {
        return this.isWeapon && this.gearBuildupParam != null ? this.gear.mind_incremental + this.gearBuildupParam.mind_add : 0;
      }
    }

    public int agility_incremental
    {
      get
      {
        return this.isWeapon && this.gearBuildupParam != null ? this.gear.agility_incremental + this.gearBuildupParam.agility_add : 0;
      }
    }

    public int dexterity_incremental
    {
      get
      {
        return this.isWeapon && this.gearBuildupParam != null ? this.gear.dexterity_incremental + this.gearBuildupParam.dexterity_add : 0;
      }
    }

    public int lucky_incremental
    {
      get
      {
        return this.isWeapon && this.gearBuildupParam != null ? this.gear.lucky_incremental + this.gearBuildupParam.lucky_add : 0;
      }
    }

    public Future<Sprite> LoadSpriteThumbnail()
    {
      return this.itemType == ItemInfo.ItemType.Supply ? this.supply.LoadSpriteThumbnail() : this.gear.LoadSpriteThumbnail();
    }

    public enum ItemType
    {
      Gear,
      Compse,
      Exchangable,
      Supply,
    }
  }
}
