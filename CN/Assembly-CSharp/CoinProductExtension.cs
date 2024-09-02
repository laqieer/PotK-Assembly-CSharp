// Decompiled with JetBrains decompiler
// Type: CoinProductExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
