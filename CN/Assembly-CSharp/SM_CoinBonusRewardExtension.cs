// Decompiled with JetBrains decompiler
// Type: SM_CoinBonusRewardExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_CoinBonusRewardExtension
{
  public static IEnumerable<CoinBonusReward> GetActiveList(this CoinBonusReward[] self, string id)
  {
    return ((IEnumerable<CoinBonusReward>) self).Where<CoinBonusReward>((Func<CoinBonusReward, bool>) (x => x.coin_product_id.platform == "android")).Where<CoinBonusReward>((Func<CoinBonusReward, bool>) (x => x.coin_product_id.product_id == id));
  }
}
