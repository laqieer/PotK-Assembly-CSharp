// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStagePlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
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

    public static BattleStagePlayer Parse(MasterDataReader reader)
    {
      return new BattleStagePlayer()
      {
        ID = reader.ReadInt(),
        stage_BattleStage = reader.ReadInt(),
        initial_coordinate_x = reader.ReadInt(),
        initial_coordinate_y = reader.ReadInt(),
        initial_direction = reader.ReadFloat(),
        deck_position = reader.ReadInt()
      };
    }

    public BattleStage stage
    {
      get
      {
        BattleStage stage;
        if (!MasterData.BattleStage.TryGetValue(this.stage_BattleStage, out stage))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStage[" + (object) this.stage_BattleStage + "]"));
        return stage;
      }
    }
  }
}
