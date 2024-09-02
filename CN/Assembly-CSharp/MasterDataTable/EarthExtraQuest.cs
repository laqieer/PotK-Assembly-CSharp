// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthExtraQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EarthExtraQuest
  {
    public int ID;
    public string name;
    public int order;
    public int stage_BattleStage;
    public string background_name;
    public int? script;
    public int use_key_num;
    public int clear_limit;
    public int? start_id;
    public int? end_id;

    public static EarthExtraQuest Parse(MasterDataReader reader)
    {
      return new EarthExtraQuest()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        order = reader.ReadInt(),
        stage_BattleStage = reader.ReadInt(),
        background_name = reader.ReadString(true),
        script = reader.ReadIntOrNull(),
        use_key_num = reader.ReadInt(),
        clear_limit = reader.ReadInt(),
        start_id = reader.ReadIntOrNull(),
        end_id = reader.ReadIntOrNull()
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
