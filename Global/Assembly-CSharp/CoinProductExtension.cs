// Decompiled with JetBrains decompiler
// Type: CoinProductExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
