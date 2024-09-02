// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ShopContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
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

    public static ShopContent Parse(MasterDataReader reader)
    {
      return new ShopContent()
      {
        ID = reader.ReadInt(),
        article_ShopArticle = reader.ReadInt(),
        entity_type_CommonRewardType = reader.ReadInt(),
        entity_id = reader.ReadInt(),
        quantity = reader.ReadInt(),
        upper_limit_check = reader.ReadBool(),
        upper_limit_count = reader.ReadInt()
      };
    }

    public ShopArticle article
    {
      get
      {
        ShopArticle article;
        if (!MasterData.ShopArticle.TryGetValue(this.article_ShopArticle, out article))
          Debug.LogError((object) ("Key not Found: MasterData.ShopArticle[" + (object) this.article_ShopArticle + "]"));
        return article;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
