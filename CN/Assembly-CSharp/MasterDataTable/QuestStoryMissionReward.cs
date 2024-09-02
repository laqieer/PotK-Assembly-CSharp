// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryMissionReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryMissionReward
  {
    public int ID;
    public int quest_m_QuestStoryM;
    public int reward_type_CommonRewardType;
    public int reward_id;
    public int quantity;
    public string message;
    public string result_message;

    public static QuestStoryMissionReward Parse(MasterDataReader reader)
    {
      return new QuestStoryMissionReward()
      {
        ID = reader.ReadInt(),
        quest_m_QuestStoryM = reader.ReadInt(),
        reward_type_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        quantity = reader.ReadInt(),
        message = reader.ReadString(true),
        result_message = reader.ReadString(true)
      };
    }

    public QuestStoryM quest_m
    {
      get
      {
        QuestStoryM questM;
        if (!MasterData.QuestStoryM.TryGetValue(this.quest_m_QuestStoryM, out questM))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryM[" + (object) this.quest_m_QuestStoryM + "]"));
        return questM;
      }
    }

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
