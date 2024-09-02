// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CoinChargeLimit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class CoinChargeLimit
  {
    public int ID;
    public int age_limit;
    public string currency;
    public float charge_limit_per_month;

    public static CoinChargeLimit Parse(MasterDataReader reader)
    {
      return new CoinChargeLimit()
      {
        ID = reader.ReadInt(),
        age_limit = reader.ReadInt(),
        currency = reader.ReadString(true),
        charge_limit_per_month = reader.ReadFloat()
      };
    }
  }
}
