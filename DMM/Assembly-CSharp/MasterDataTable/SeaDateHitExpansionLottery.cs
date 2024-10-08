﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SeaDateHitExpansionLottery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class SeaDateHitExpansionLottery
  {
    public int ID;
    public int? same_character_id_UnitUnit;
    public int? character_id;
    public int time_zone_id_SeaHomeTimeZone;
    public int date_spot_id_SeaDateDateSpot;

    public static SeaDateHitExpansionLottery Parse(MasterDataReader reader) => new SeaDateHitExpansionLottery()
    {
      ID = reader.ReadInt(),
      same_character_id_UnitUnit = reader.ReadIntOrNull(),
      character_id = reader.ReadIntOrNull(),
      time_zone_id_SeaHomeTimeZone = reader.ReadInt(),
      date_spot_id_SeaDateDateSpot = reader.ReadInt()
    };

    public UnitUnit same_character_id
    {
      get
      {
        if (!this.same_character_id_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.same_character_id_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.same_character_id_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public SeaHomeTimeZone time_zone_id
    {
      get
      {
        SeaHomeTimeZone seaHomeTimeZone;
        if (!MasterData.SeaHomeTimeZone.TryGetValue(this.time_zone_id_SeaHomeTimeZone, out seaHomeTimeZone))
          Debug.LogError((object) ("Key not Found: MasterData.SeaHomeTimeZone[" + (object) this.time_zone_id_SeaHomeTimeZone + "]"));
        return seaHomeTimeZone;
      }
    }

    public SeaDateDateSpot date_spot_id
    {
      get
      {
        SeaDateDateSpot seaDateDateSpot;
        if (!MasterData.SeaDateDateSpot.TryGetValue(this.date_spot_id_SeaDateDateSpot, out seaDateDateSpot))
          Debug.LogError((object) ("Key not Found: MasterData.SeaDateDateSpot[" + (object) this.date_spot_id_SeaDateDateSpot + "]"));
        return seaDateDateSpot;
      }
    }
  }
}
