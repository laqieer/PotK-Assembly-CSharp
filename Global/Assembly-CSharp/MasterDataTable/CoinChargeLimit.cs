// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CoinChargeLimit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
