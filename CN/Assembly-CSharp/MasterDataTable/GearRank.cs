// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearRank
  {
    public int ID;
    public int index_GearRarity;
    public int _max_level_GearRankExp;

    public static GearRank Parse(MasterDataReader reader)
    {
      return new GearRank()
      {
        ID = reader.ReadInt(),
        index_GearRarity = reader.ReadInt(),
        _max_level_GearRankExp = reader.ReadInt()
      };
    }

    public GearRarity index
    {
      get
      {
        GearRarity index;
        if (!MasterData.GearRarity.TryGetValue(this.index_GearRarity, out index))
          Debug.LogError((object) ("Key not Found: MasterData.GearRarity[" + (object) this.index_GearRarity + "]"));
        return index;
      }
    }

    public GearRankExp _max_level
    {
      get
      {
        GearRankExp maxLevel;
        if (!MasterData.GearRankExp.TryGetValue(this._max_level_GearRankExp, out maxLevel))
          Debug.LogError((object) ("Key not Found: MasterData.GearRankExp[" + (object) this._max_level_GearRankExp + "]"));
        return maxLevel;
      }
    }
  }
}
