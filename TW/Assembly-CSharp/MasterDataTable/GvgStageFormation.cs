// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GvgStageFormation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
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

    public static GvgStageFormation Parse(MasterDataReader reader)
    {
      return new GvgStageFormation()
      {
        ID = reader.ReadInt(),
        stage_BattleStage = reader.ReadInt(),
        formation_x = reader.ReadInt(),
        formation_y = reader.ReadInt(),
        player_order = reader.ReadInt(),
        initial_direction = reader.ReadFloat()
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
