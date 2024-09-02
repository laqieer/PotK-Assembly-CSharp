// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthShopContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using SM;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EarthShopContent
  {
    public int ID;
    public int article_EarthShopArticle;
    public int entity_type_CommonRewardType;
    public int entity_id;
    public int quantity;
    public bool upper_limit_check;
    public int upper_limit_count;

    public static EarthShopContent Parse(MasterDataReader reader)
    {
      return new EarthShopContent()
      {
        ID = reader.ReadInt(),
        article_EarthShopArticle = reader.ReadInt(),
        entity_type_CommonRewardType = reader.ReadInt(),
        entity_id = reader.ReadInt(),
        quantity = reader.ReadInt(),
        upper_limit_check = reader.ReadBool(),
        upper_limit_count = reader.ReadInt()
      };
    }

    public EarthShopArticle article
    {
      get
      {
        EarthShopArticle article;
        if (!MasterData.EarthShopArticle.TryGetValue(this.article_EarthShopArticle, out article))
          Debug.LogError((object) ("Key not Found: MasterData.EarthShopArticle[" + (object) this.article_EarthShopArticle + "]"));
        return article;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;

    public int GetPossessionNum()
    {
      int possessionNum = 0;
      switch (this.entity_type)
      {
        case CommonRewardType.unit:
          possessionNum = Singleton<EarthDataManager>.GetInstance().GetPlayerUnits().AmountHavingTargetUnit(this.entity_id, this.entity_type);
          break;
        case CommonRewardType.supply:
        case CommonRewardType.gear:
          possessionNum = SMManager.Get<PlayerItem[]>().AmountHavingTargetItem(this.entity_id, this.entity_type);
          break;
      }
      return possessionNum;
    }
  }
}
