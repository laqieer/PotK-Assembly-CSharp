// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SupplySupply
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SupplySupply
  {
    public int ID;
    private string _name;
    private string _description;
    private string _flavor;
    public int rarity_GearRarity;
    public int max_count;
    public int battle_stack_limit;
    public int sell_price;
    public int skill_BattleskillSkill;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("supply_SupplySupply_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string description
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._description;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("supply_SupplySupply_description_" + (object) this.ID, out Translation) ? Translation : this._description;
      }
      set => this._description = value;
    }

    public string flavor
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._flavor;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("supply_SupplySupply_flavor_" + (object) this.ID, out Translation) ? Translation : this._flavor;
      }
      set => this._flavor = value;
    }

    public static SupplySupply Parse(MasterDataReader reader)
    {
      return new SupplySupply()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        flavor = reader.ReadString(true),
        rarity_GearRarity = reader.ReadInt(),
        max_count = reader.ReadInt(),
        battle_stack_limit = reader.ReadInt(),
        sell_price = reader.ReadInt(),
        skill_BattleskillSkill = reader.ReadInt()
      };
    }

    public GearRarity rarity
    {
      get
      {
        GearRarity rarity;
        if (!MasterData.GearRarity.TryGetValue(this.rarity_GearRarity, out rarity))
          Debug.LogError((object) ("Key not Found: MasterData.GearRarity[" + (object) this.rarity_GearRarity + "]"));
        return rarity;
      }
    }

    public BattleskillSkill skill
    {
      get
      {
        BattleskillSkill skill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill, out skill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill + "]"));
        return skill;
      }
    }

    public Future<Sprite> LoadSpriteThumbnail()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Supplies/{0}/2D/item_thum", (object) this.ID));
    }

    public Future<Sprite> LoadSpriteBasic()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Supplies/{0}/2D/item_basic", (object) this.ID));
    }
  }
}
