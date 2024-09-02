// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SupplySupply
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;

namespace MasterDataTable
{
  [Serializable]
  public class SupplySupply
  {
    public int ID;
    public string name;
    public string description;
    public string flavor;
    public int rarity_GearRarity;
    public int max_count;
    public int battle_stack_limit;
    public int sell_price;
    public int skill_BattleskillSkill;

    public static SupplySupply Parse(MasterDataReader reader) => new SupplySupply()
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

    public GearRarity rarity
    {
      get
      {
        GearRarity gearRarity;
        if (!MasterData.GearRarity.TryGetValue(this.rarity_GearRarity, out gearRarity))
          Debug.LogError((object) ("Key not Found: MasterData.GearRarity[" + (object) this.rarity_GearRarity + "]"));
        return gearRarity;
      }
    }

    public BattleskillSkill skill
    {
      get
      {
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill + "]"));
        return battleskillSkill;
      }
    }

    public List<string> ResourcePaths() => new List<string>()
    {
      string.Format("AssetBundle/Resources/Supplies/{0}/2D/item_thum", (object) this.ID),
      string.Format("AssetBundle/Resources/Supplies/{0}/2D/item_basic", (object) this.ID)
    };

    public Future<UnityEngine.Sprite> LoadSpriteThumbnail() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("AssetBundle/Resources/Supplies/{0}/2D/item_thum", (object) this.ID));

    public Future<UnityEngine.Sprite> LoadSpriteBasic() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("AssetBundle/Resources/Supplies/{0}/2D/item_basic", (object) this.ID));
  }
}
