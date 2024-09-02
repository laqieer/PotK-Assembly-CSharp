// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestSeaMissionReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestSeaMissionReward
  {
    public int ID;
    public int quest_m_QuestSeaM;
    public int reward_type_CommonRewardType;
    public int reward_id;
    public int quantity;
    public string message;
    public string result_message;

    public static QuestSeaMissionReward Parse(MasterDataReader reader) => new QuestSeaMissionReward()
    {
      ID = reader.ReadInt(),
      quest_m_QuestSeaM = reader.ReadInt(),
      reward_type_CommonRewardType = reader.ReadInt(),
      reward_id = reader.ReadInt(),
      quantity = reader.ReadInt(),
      message = reader.ReadString(true),
      result_message = reader.ReadString(true)
    };

    public QuestSeaM quest_m
    {
      get
      {
        QuestSeaM questSeaM;
        if (!MasterData.QuestSeaM.TryGetValue(this.quest_m_QuestSeaM, out questSeaM))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaM[" + (object) this.quest_m_QuestSeaM + "]"));
        return questSeaM;
      }
    }

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
