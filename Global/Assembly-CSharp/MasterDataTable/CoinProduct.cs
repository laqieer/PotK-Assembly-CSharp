// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CoinProduct
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
  public class CoinProduct
  {
    public int ID;
    public string product_id;
    public string platform;
    private string _name;
    public string description;
    public int additional_paid_coin;
    public int additional_free_coin;
    public bool apple_serial_campaign;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("coin_CoinProduct_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

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
        additional_free_coin = reader.ReadInt(),
        apple_serial_campaign = reader.ReadBool()
      };
    }

    public static Future<Sprite> LoadSpriteThumbnail(bool isBounsActice)
    {
      return isBounsActice ? ResourceManager.Load<Sprite>("Icons/Item_Thumbnail_Kiseki_Bonus") : ResourceManager.Load<Sprite>("Icons/Item_Thumbnail_Kiseki");
    }
  }
}
