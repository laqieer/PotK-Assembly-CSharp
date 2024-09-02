// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearRank
  {
    public int ID;
    public int index_GearRarity;
    public int _max_level_GearRankExp;

    public static GearRank Parse(MasterDataReader reader) => new GearRank()
    {
      ID = reader.ReadInt(),
      index_GearRarity = reader.ReadInt(),
      _max_level_GearRankExp = reader.ReadInt()
    };

    public GearRarity index
    {
      get
      {
        GearRarity gearRarity;
        if (!MasterData.GearRarity.TryGetValue(this.index_GearRarity, out gearRarity))
          Debug.LogError((object) ("Key not Found: MasterData.GearRarity[" + (object) this.index_GearRarity + "]"));
        return gearRarity;
      }
    }

    public GearRankExp _max_level
    {
      get
      {
        GearRankExp gearRankExp;
        if (!MasterData.GearRankExp.TryGetValue(this._max_level_GearRankExp, out gearRankExp))
          Debug.LogError((object) ("Key not Found: MasterData.GearRankExp[" + (object) this._max_level_GearRankExp + "]"));
        return gearRankExp;
      }
    }
  }
}
