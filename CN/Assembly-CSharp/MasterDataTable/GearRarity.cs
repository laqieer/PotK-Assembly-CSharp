// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRarity
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
  public class GearRarity
  {
    public int ID;
    public string name;
    public int index;
    public float compose_ratio;

    public static float ComposeRatio(int index)
    {
      return ((IEnumerable<GearRarity>) MasterData.GearRarityList).Single<GearRarity>((Func<GearRarity, bool>) (x => x.index == index)).compose_ratio;
    }

    public static GearRarity Parse(MasterDataReader reader)
    {
      return new GearRarity()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        index = reader.ReadInt(),
        compose_ratio = reader.ReadFloat()
      };
    }
  }
}
