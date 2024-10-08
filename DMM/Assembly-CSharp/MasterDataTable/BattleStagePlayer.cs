﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStagePlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleStagePlayer
  {
    public int ID;
    public int stage_BattleStage;
    public int initial_coordinate_x;
    public int initial_coordinate_y;
    public float initial_direction;
    public int deck_position;

    public static BattleStagePlayer Parse(MasterDataReader reader) => new BattleStagePlayer()
    {
      ID = reader.ReadInt(),
      stage_BattleStage = reader.ReadInt(),
      initial_coordinate_x = reader.ReadInt(),
      initial_coordinate_y = reader.ReadInt(),
      initial_direction = reader.ReadFloat(),
      deck_position = reader.ReadInt()
    };

    public BattleStage stage
    {
      get
      {
        BattleStage battleStage;
        if (!MasterData.BattleStage.TryGetValue(this.stage_BattleStage, out battleStage))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStage[" + (object) this.stage_BattleStage + "]"));
        return battleStage;
      }
    }
  }
}
