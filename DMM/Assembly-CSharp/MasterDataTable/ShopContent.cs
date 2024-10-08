﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ShopContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class ShopContent
  {
    public int ID;
    public int article_ShopArticle;
    public int entity_type_CommonRewardType;
    public int entity_id;
    public int quantity;
    public bool upper_limit_check;
    public int upper_limit_count;

    public static ShopContent Parse(MasterDataReader reader) => new ShopContent()
    {
      ID = reader.ReadInt(),
      article_ShopArticle = reader.ReadInt(),
      entity_type_CommonRewardType = reader.ReadInt(),
      entity_id = reader.ReadInt(),
      quantity = reader.ReadInt(),
      upper_limit_check = reader.ReadBool(),
      upper_limit_count = reader.ReadInt()
    };

    public ShopArticle article
    {
      get
      {
        ShopArticle shopArticle;
        if (!MasterData.ShopArticle.TryGetValue(this.article_ShopArticle, out shopArticle))
          Debug.LogError((object) ("Key not Found: MasterData.ShopArticle[" + (object) this.article_ShopArticle + "]"));
        return shopArticle;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
