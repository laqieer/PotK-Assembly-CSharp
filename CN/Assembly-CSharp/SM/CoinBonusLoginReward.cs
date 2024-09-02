﻿// Decompiled with JetBrains decompiler
// Type: SM.CoinBonusLoginReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class CoinBonusLoginReward : KeyCompare
  {
    public int coin_bonus_id;
    public string client_coin_shop_title;
    public int id;
    public int _coin_product_id;

    public CoinBonusLoginReward()
    {
    }

    public CoinBonusLoginReward(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.coin_bonus_id = (int) (long) json[nameof (coin_bonus_id)];
      this.client_coin_shop_title = (string) json[nameof (client_coin_shop_title)];
      this.id = (int) (long) json[nameof (id)];
      this._coin_product_id = (int) (long) json[nameof (coin_product_id)];
    }

    public CoinProduct coin_product_id
    {
      get
      {
        if (MasterData.CoinProduct.ContainsKey(this._coin_product_id))
          return MasterData.CoinProduct[this._coin_product_id];
        Debug.LogError((object) ("Key not Found: MasterData.CoinProduct[" + (object) this._coin_product_id + "]"));
        return (CoinProduct) null;
      }
    }
  }
}
