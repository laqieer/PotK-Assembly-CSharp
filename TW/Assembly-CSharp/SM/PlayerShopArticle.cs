// Decompiled with JetBrains decompiler
// Type: SM.PlayerShopArticle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerShopArticle : KeyCompare
  {
    public int _article;
    public DateTime? recharge_at;
    public int? limit;
    public string banner_url;
    public DateTime? end_at;

    public PlayerShopArticle()
    {
    }

    public PlayerShopArticle(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._article = (int) (long) json[nameof (article)];
      this.recharge_at = json[nameof (recharge_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (recharge_at)])) : new DateTime?();
      int? nullable1;
      if (json[nameof (limit)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (limit)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.limit = nullable1;
      this.banner_url = (string) json[nameof (banner_url)];
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
    }

    public ShopArticle article
    {
      get
      {
        if (MasterData.ShopArticle.ContainsKey(this._article))
          return MasterData.ShopArticle[this._article];
        Debug.LogError((object) ("Key not Found: MasterData.ShopArticle[" + (object) this._article + "]"));
        return (ShopArticle) null;
      }
    }
  }
}
