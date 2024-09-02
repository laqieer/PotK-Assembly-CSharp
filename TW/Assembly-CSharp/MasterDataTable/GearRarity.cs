// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
