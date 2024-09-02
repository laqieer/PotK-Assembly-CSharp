// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitGroup
  {
    public int ID;
    public int unit_id;
    public int group_large_category_id_UnitGroupLargeCategory;
    public int group_small_category_id_UnitGroupSmallCategory;
    public int group_clothing_category_id_UnitGroupClothingCategory;
    public int group_clothing_category_id_2_UnitGroupClothingCategory;
    public int group_generation_category_id_UnitGroupGenerationCategory;

    public static UnitGroup Parse(MasterDataReader reader) => new UnitGroup()
    {
      ID = reader.ReadInt(),
      unit_id = reader.ReadInt(),
      group_large_category_id_UnitGroupLargeCategory = reader.ReadInt(),
      group_small_category_id_UnitGroupSmallCategory = reader.ReadInt(),
      group_clothing_category_id_UnitGroupClothingCategory = reader.ReadInt(),
      group_clothing_category_id_2_UnitGroupClothingCategory = reader.ReadInt(),
      group_generation_category_id_UnitGroupGenerationCategory = reader.ReadInt()
    };

    public UnitGroupLargeCategory group_large_category_id
    {
      get
      {
        UnitGroupLargeCategory groupLargeCategory;
        if (!MasterData.UnitGroupLargeCategory.TryGetValue(this.group_large_category_id_UnitGroupLargeCategory, out groupLargeCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupLargeCategory[" + (object) this.group_large_category_id_UnitGroupLargeCategory + "]"));
        return groupLargeCategory;
      }
    }

    public UnitGroupSmallCategory group_small_category_id
    {
      get
      {
        UnitGroupSmallCategory groupSmallCategory;
        if (!MasterData.UnitGroupSmallCategory.TryGetValue(this.group_small_category_id_UnitGroupSmallCategory, out groupSmallCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupSmallCategory[" + (object) this.group_small_category_id_UnitGroupSmallCategory + "]"));
        return groupSmallCategory;
      }
    }

    public UnitGroupClothingCategory group_clothing_category_id
    {
      get
      {
        UnitGroupClothingCategory clothingCategory;
        if (!MasterData.UnitGroupClothingCategory.TryGetValue(this.group_clothing_category_id_UnitGroupClothingCategory, out clothingCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupClothingCategory[" + (object) this.group_clothing_category_id_UnitGroupClothingCategory + "]"));
        return clothingCategory;
      }
    }

    public UnitGroupClothingCategory group_clothing_category_id_2
    {
      get
      {
        UnitGroupClothingCategory clothingCategory;
        if (!MasterData.UnitGroupClothingCategory.TryGetValue(this.group_clothing_category_id_2_UnitGroupClothingCategory, out clothingCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupClothingCategory[" + (object) this.group_clothing_category_id_2_UnitGroupClothingCategory + "]"));
        return clothingCategory;
      }
    }

    public UnitGroupGenerationCategory group_generation_category_id
    {
      get
      {
        UnitGroupGenerationCategory generationCategory;
        if (!MasterData.UnitGroupGenerationCategory.TryGetValue(this.group_generation_category_id_UnitGroupGenerationCategory, out generationCategory))
          Debug.LogError((object) ("Key not Found: MasterData.UnitGroupGenerationCategory[" + (object) this.group_generation_category_id_UnitGroupGenerationCategory + "]"));
        return generationCategory;
      }
    }
  }
}
