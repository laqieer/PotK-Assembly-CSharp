﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleMapLandform
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleMapLandform
  {
    public int ID;
    public int map_BattleMap;
    public int coordinate_x;
    public int coordinate_y;
    public int landform_BattleLandform;

    public static BattleMapLandform Parse(MasterDataReader reader)
    {
      return new BattleMapLandform()
      {
        ID = reader.ReadInt(),
        map_BattleMap = reader.ReadInt(),
        coordinate_x = reader.ReadInt(),
        coordinate_y = reader.ReadInt(),
        landform_BattleLandform = reader.ReadInt()
      };
    }

    public BattleMap map
    {
      get
      {
        BattleMap map;
        if (!MasterData.BattleMap.TryGetValue(this.map_BattleMap, out map))
          Debug.LogError((object) ("Key not Found: MasterData.BattleMap[" + (object) this.map_BattleMap + "]"));
        return map;
      }
    }

    public BattleLandform landform
    {
      get
      {
        BattleLandform landform;
        if (!MasterData.BattleLandform.TryGetValue(this.landform_BattleLandform, out landform))
          Debug.LogError((object) ("Key not Found: MasterData.BattleLandform[" + (object) this.landform_BattleLandform + "]"));
        return landform;
      }
    }
  }
}
