// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRankIncr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearRankIncr
  {
    public int ID;
    public int level;
    public int power;
    public int physical_defense;
    public int magic_defense;

    public static GearRankIncr FromRank(int rank)
    {
      return ((IEnumerable<GearRankIncr>) MasterData.GearRankIncrList).Single<GearRankIncr>((Func<GearRankIncr, bool>) (x => x.level == rank));
    }

    public static GearRankIncr Parse(MasterDataReader reader)
    {
      return new GearRankIncr()
      {
        ID = reader.ReadInt(),
        level = reader.ReadInt(),
        power = reader.ReadInt(),
        physical_defense = reader.ReadInt(),
        magic_defense = reader.ReadInt()
      };
    }
  }
}
