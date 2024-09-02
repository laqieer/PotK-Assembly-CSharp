// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CoinProduct
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using Gsc.Purchase;
using System;

namespace MasterDataTable
{
  [Serializable]
  public class CoinProduct
  {
    public int ID;
    public string product_id;
    public string platform;
    public string name;
    public string description;
    public int additional_paid_coin;
    public int additional_free_coin;
    public int type;
    public int? product_detail_group_no;

    public static CoinProduct Parse(MasterDataReader reader) => new CoinProduct()
    {
      ID = reader.ReadInt(),
      product_id = reader.ReadString(true),
      platform = reader.ReadString(true),
      name = reader.ReadString(true),
      description = reader.ReadString(true),
      additional_paid_coin = reader.ReadInt(),
      additional_free_coin = reader.ReadInt(),
      type = reader.ReadInt(),
      product_detail_group_no = reader.ReadIntOrNull()
    };

    public static Future<UnityEngine.Sprite> LoadSpriteThumbnail(
      ProductInfo productInfo,
      bool isBounsActice)
    {
      return isBounsActice ? Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("Icons/Item_Thumbnail_Kiseki_Bonus") : Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("Icons/Item_Thumbnail_Kiseki");
    }

    public static Future<UnityEngine.Sprite> LoadSpriteThumbnail(
      bool isBounsActice,
      string packIconResourceName)
    {
      if (!string.IsNullOrEmpty(packIconResourceName))
        return Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("Shop/" + packIconResourceName);
      return isBounsActice ? Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("Icons/Item_Thumbnail_Kiseki_Bonus") : Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("Icons/Item_Thumbnail_Kiseki");
    }
  }
}
