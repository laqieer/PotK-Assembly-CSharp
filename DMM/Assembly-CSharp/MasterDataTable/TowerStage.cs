// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TowerStage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;

namespace MasterDataTable
{
  [Serializable]
  public class TowerStage
  {
    public int ID;
    public int tower_id;
    public int floor;
    public int stage_id;
    public int back_ground_id_TowerCommonBackground;

    public static TowerStage Parse(MasterDataReader reader) => new TowerStage()
    {
      ID = reader.ReadInt(),
      tower_id = reader.ReadInt(),
      floor = reader.ReadInt(),
      stage_id = reader.ReadInt(),
      back_ground_id_TowerCommonBackground = reader.ReadInt()
    };

    public TowerCommonBackground back_ground_id
    {
      get
      {
        TowerCommonBackground commonBackground;
        if (!MasterData.TowerCommonBackground.TryGetValue(this.back_ground_id_TowerCommonBackground, out commonBackground))
          Debug.LogError((object) ("Key not Found: MasterData.TowerCommonBackground[" + (object) this.back_ground_id_TowerCommonBackground + "]"));
        return commonBackground;
      }
    }

    public string GetBackgroundPath() => !string.IsNullOrEmpty(this.back_ground_id.background_name) ? string.Format(Consts.GetInstance().BACKGROUND_BASE_PATH, (object) this.back_ground_id.background_name) : Consts.GetInstance().DEFULAT_BACKGROUND;
  }
}
