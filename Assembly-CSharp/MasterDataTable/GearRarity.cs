// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

namespace MasterDataTable
{
  [Serializable]
  public class GearRarity
  {
    public int ID;
    public string name;
    public int index;
    public float compose_ratio;
    public int combine_reisou_jewel;

    public static float ComposeRatio(int index) => ((IEnumerable<GearRarity>) MasterData.GearRarityList).Single<GearRarity>((Func<GearRarity, bool>) (x => x.index == index)).compose_ratio;

    public static GearRarity Parse(MasterDataReader reader) => new GearRarity()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      index = reader.ReadInt(),
      compose_ratio = reader.ReadFloat(),
      combine_reisou_jewel = reader.ReadInt()
    };
  }
}
