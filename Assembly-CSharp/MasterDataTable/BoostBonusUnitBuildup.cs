﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BoostBonusUnitBuildup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BoostBonusUnitBuildup
  {
    public int ID;
    public int period_id_BoostPeriod;
    public float increase_price;

    public static BoostBonusUnitBuildup Parse(MasterDataReader reader) => new BoostBonusUnitBuildup()
    {
      ID = reader.ReadInt(),
      period_id_BoostPeriod = reader.ReadInt(),
      increase_price = reader.ReadFloat()
    };

    public BoostPeriod period_id
    {
      get
      {
        BoostPeriod boostPeriod;
        if (!MasterData.BoostPeriod.TryGetValue(this.period_id_BoostPeriod, out boostPeriod))
          Debug.LogError((object) ("Key not Found: MasterData.BoostPeriod[" + (object) this.period_id_BoostPeriod + "]"));
        return boostPeriod;
      }
    }
  }
}
