// Decompiled with JetBrains decompiler
// Type: SM.PlayerValue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerValue : KeyCompare
  {
    public int buy_fund_cnt;
    public int first_buy_coins;

    public PlayerValue()
    {
    }

    public PlayerValue(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.buy_fund_cnt = (int) (long) json[nameof (buy_fund_cnt)];
      this.first_buy_coins = (int) (long) json[nameof (first_buy_coins)];
    }
  }
}
