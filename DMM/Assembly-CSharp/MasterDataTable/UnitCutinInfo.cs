// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitCutinInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitCutinInfo
  {
    public int ID;
    public int same_character_id;
    public int group_small_category_id;
    public string prefab_name;
    public int? reference_image_UnitReferenceImage;

    public static UnitCutinInfo Parse(MasterDataReader reader) => new UnitCutinInfo()
    {
      ID = reader.ReadInt(),
      same_character_id = reader.ReadInt(),
      group_small_category_id = reader.ReadInt(),
      prefab_name = reader.ReadString(true),
      reference_image_UnitReferenceImage = reader.ReadIntOrNull()
    };

    public UnitReferenceImage reference_image
    {
      get
      {
        if (!this.reference_image_UnitReferenceImage.HasValue)
          return (UnitReferenceImage) null;
        UnitReferenceImage unitReferenceImage;
        if (!MasterData.UnitReferenceImage.TryGetValue(this.reference_image_UnitReferenceImage.Value, out unitReferenceImage))
          Debug.LogError((object) ("Key not Found: MasterData.UnitReferenceImage[" + (object) this.reference_image_UnitReferenceImage.Value + "]"));
        return unitReferenceImage;
      }
    }

    public static UnitCutinInfo find(UnitUnit unit)
    {
      int sameCharacter = unit.same_character_id;
      UnitCutinInfo unitCutinInfo = Array.Find<UnitCutinInfo>(MasterData.UnitCutinInfoList, (Predicate<UnitCutinInfo>) (x => x.same_character_id == sameCharacter));
      if (unitCutinInfo != null)
        return unitCutinInfo;
      int smallCategory = unit.SmallCategoryId;
      return Array.Find<UnitCutinInfo>(MasterData.UnitCutinInfoList, (Predicate<UnitCutinInfo>) (x => x.group_small_category_id == smallCategory));
    }
  }
}
