// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CoinProduct
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
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

    public static CoinProduct Parse(MasterDataReader reader)
    {
      return new CoinProduct()
      {
        ID = reader.ReadInt(),
        product_id = reader.ReadString(true),
        platform = reader.ReadString(true),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        additional_paid_coin = reader.ReadInt(),
        additional_free_coin = reader.ReadInt()
      };
    }

    public static Future<Sprite> LoadSpriteThumbnail(int isBounsActice)
    {
      if (isBounsActice == 1)
        return Singleton<ResourceManager>.GetInstance().Load<Sprite>("Icons/Item_Thumbnail_Kiseki_Bonus");
      return isBounsActice == -1 ? Singleton<ResourceManager>.GetInstance().Load<Sprite>("Icons/Item_Thumbnail_Kiseki_Month") : Singleton<ResourceManager>.GetInstance().Load<Sprite>("Icons/Item_Thumbnail_Kiseki");
    }
  }
}
