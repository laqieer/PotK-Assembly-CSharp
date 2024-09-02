// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestSeaMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestSeaMission
  {
    public int ID;
    public int quest_s_QuestSeaS;
    public int priority;
    public string name;
    public int entity_type_CommonRewardType;
    public int entity_id;
    public int quantity;

    public static QuestSeaMission Parse(MasterDataReader reader) => new QuestSeaMission()
    {
      ID = reader.ReadInt(),
      quest_s_QuestSeaS = reader.ReadInt(),
      priority = reader.ReadInt(),
      name = reader.ReadString(true),
      entity_type_CommonRewardType = reader.ReadInt(),
      entity_id = reader.ReadInt(),
      quantity = reader.ReadInt()
    };

    public QuestSeaS quest_s
    {
      get
      {
        QuestSeaS questSeaS;
        if (!MasterData.QuestSeaS.TryGetValue(this.quest_s_QuestSeaS, out questSeaS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaS[" + (object) this.quest_s_QuestSeaS + "]"));
        return questSeaS;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
