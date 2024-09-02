// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BoostBonusUnitTransmigrate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BoostBonusUnitTransmigrate
  {
    public int ID;
    public int period_id_BoostPeriod;
    public float increase_price;

    public static BoostBonusUnitTransmigrate Parse(MasterDataReader reader)
    {
      return new BoostBonusUnitTransmigrate()
      {
        ID = reader.ReadInt(),
        period_id_BoostPeriod = reader.ReadInt(),
        increase_price = reader.ReadFloat()
      };
    }

    public BoostPeriod period_id
    {
      get
      {
        BoostPeriod periodId;
        if (!MasterData.BoostPeriod.TryGetValue(this.period_id_BoostPeriod, out periodId))
          Debug.LogError((object) ("Key not Found: MasterData.BoostPeriod[" + (object) this.period_id_BoostPeriod + "]"));
        return periodId;
      }
    }
  }
}
