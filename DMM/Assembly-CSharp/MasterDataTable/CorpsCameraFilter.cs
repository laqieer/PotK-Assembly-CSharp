// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CorpsCameraFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CorpsCameraFilter
  {
    public int ID;
    public int stage_id_BattleStage;
    public string filter_resource_name;

    public static CorpsCameraFilter Parse(MasterDataReader reader) => new CorpsCameraFilter()
    {
      ID = reader.ReadInt(),
      stage_id_BattleStage = reader.ReadInt(),
      filter_resource_name = reader.ReadString(true)
    };

    public BattleStage stage_id
    {
      get
      {
        BattleStage battleStage;
        if (!MasterData.BattleStage.TryGetValue(this.stage_id_BattleStage, out battleStage))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStage[" + (object) this.stage_id_BattleStage + "]"));
        return battleStage;
      }
    }
  }
}
