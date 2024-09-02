// Decompiled with JetBrains decompiler
// Type: CoinProductExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class CoinProductExtension
{
  public static CoinProduct GetActiveProductData(this CoinProduct[] self, string id)
  {
    return ((IEnumerable<CoinProduct>) self).Where<CoinProduct>((Func<CoinProduct, bool>) (x => x.platform == "android")).Where<CoinProduct>((Func<CoinProduct, bool>) (x => x.product_id == id)).FirstOrDefault<CoinProduct>();
  }
}
