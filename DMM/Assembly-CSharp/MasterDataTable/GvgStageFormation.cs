﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GvgStageFormation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GvgStageFormation
  {
    public int ID;
    public int stage_BattleStage;
    public int formation_x;
    public int formation_y;
    public int player_order;
    public float initial_direction;

    public static GvgStageFormation Parse(MasterDataReader reader) => new GvgStageFormation()
    {
      ID = reader.ReadInt(),
      stage_BattleStage = reader.ReadInt(),
      formation_x = reader.ReadInt(),
      formation_y = reader.ReadInt(),
      player_order = reader.ReadInt(),
      initial_direction = reader.ReadFloat()
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
