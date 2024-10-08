﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearDrilling
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearDrilling
  {
    public int ID;
    public int rank;
    public int rare_1;
    public int rare_2;
    public int rare_3;
    public int rare_4;
    public int rare_5;
    public int rare_6;

    public static int GetGearDrilling(int rank, int rarity)
    {
      GearDrilling gearDrilling = ((IEnumerable<GearDrilling>) MasterData.GearDrillingList).FirstOrDefault<GearDrilling>((Func<GearDrilling, bool>) (x => x.rank == rank));
      if (gearDrilling == null)
        return 0;
      switch (rarity)
      {
        case 1:
          return gearDrilling.rare_1;
        case 2:
          return gearDrilling.rare_2;
        case 3:
          return gearDrilling.rare_3;
        case 4:
          return gearDrilling.rare_4;
        case 5:
          return gearDrilling.rare_5;
        default:
          return gearDrilling.rare_6;
      }
    }

    public static GearDrilling Parse(MasterDataReader reader)
    {
      return new GearDrilling()
      {
        ID = reader.ReadInt(),
        rank = reader.ReadInt(),
        rare_1 = reader.ReadInt(),
        rare_2 = reader.ReadInt(),
        rare_3 = reader.ReadInt(),
        rare_4 = reader.ReadInt(),
        rare_5 = reader.ReadInt(),
        rare_6 = reader.ReadInt()
      };
    }
  }
}
