// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpStageFormation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PvpStageFormation
  {
    public int ID;
    public int stage_BattleStage;
    public int formation_x;
    public int formation_y;
    public int player_order;
    public float initial_direction;

    public static PvpStageFormation Parse(MasterDataReader reader)
    {
      return new PvpStageFormation()
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
