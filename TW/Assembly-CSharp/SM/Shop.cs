﻿// Decompiled with JetBrains decompiler
// Type: SM.Shop
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class Shop : KeyCompare
  {
    public PlayerShopArticle[] articles;
    public int id;
    public string name;

    public Shop()
    {
    }

    public Shop(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<PlayerShopArticle> playerShopArticleList = new List<PlayerShopArticle>();
      foreach (object json1 in (List<object>) json[nameof (articles)])
        playerShopArticleList.Add(json1 != null ? new PlayerShopArticle((Dictionary<string, object>) json1) : (PlayerShopArticle) null);
      this.articles = playerShopArticleList.ToArray();
      this.id = (int) (long) json[nameof (id)];
      this.name = (string) json[nameof (name)];
    }
  }
}
