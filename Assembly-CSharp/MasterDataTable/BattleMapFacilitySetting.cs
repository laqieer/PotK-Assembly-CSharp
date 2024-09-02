// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleMapFacilitySetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleMapFacilitySetting
  {
    public int ID;
    public int map_BattleStage;
    public int coordinate_x;
    public int coordinate_y;

    public static BattleMapFacilitySetting Parse(MasterDataReader reader) => new BattleMapFacilitySetting()
    {
      ID = reader.ReadInt(),
      map_BattleStage = reader.ReadInt(),
      coordinate_x = reader.ReadInt(),
      coordinate_y = reader.ReadInt()
    };

    public BattleStage map
    {
      get
      {
        BattleStage battleStage;
        if (!MasterData.BattleStage.TryGetValue(this.map_BattleStage, out battleStage))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStage[" + (object) this.map_BattleStage + "]"));
        return battleStage;
      }
    }
  }
}
