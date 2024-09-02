// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTicketUnitSample
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitTicketUnitSample
  {
    public int ID;
    public int ticketID;
    public int unitUnit_UnitUnit;

    public static UnitTicketUnitSample Parse(MasterDataReader reader)
    {
      return new UnitTicketUnitSample()
      {
        ID = reader.ReadInt(),
        ticketID = reader.ReadInt(),
        unitUnit_UnitUnit = reader.ReadInt()
      };
    }

    public UnitUnit unitUnit
    {
      get
      {
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unitUnit_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unitUnit_UnitUnit + "]"));
        return unitUnit;
      }
    }
  }
}
