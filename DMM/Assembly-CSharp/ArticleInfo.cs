﻿// Decompiled with JetBrains decompiler
// Type: ArticleInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;

public class ArticleInfo
{
  public Shop0074Scroll scroll;

  public PlayerShopArticle article { get; set; }

  public Shop shop { get; set; }

  public ShopArticleListMenu menu { get; set; }

  public Func<IEnumerator> onPurchased { get; set; }

  public System.Action<long> onPurchasedHolding { get; set; }

  public ArticleInfo TempCopy()
  {
    ArticleInfo articleInfo = (ArticleInfo) this.MemberwiseClone();
    articleInfo.scroll = (Shop0074Scroll) null;
    return articleInfo;
  }
}
