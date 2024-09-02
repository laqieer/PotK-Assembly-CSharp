// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCharacterMReleaseCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestCharacterMReleaseCondition
  {
    public int ID;
    public int quest_m_QuestCharacterM;
    public string required_condition;
    public int? required_quest_type;
    public int? required_quest_s_id;

    public static QuestCharacterMReleaseCondition Parse(MasterDataReader reader)
    {
      return new QuestCharacterMReleaseCondition()
      {
        ID = reader.ReadInt(),
        quest_m_QuestCharacterM = reader.ReadInt(),
        required_condition = reader.ReadStringOrNull(true),
        required_quest_type = reader.ReadIntOrNull(),
        required_quest_s_id = reader.ReadIntOrNull()
      };
    }

    public QuestCharacterM quest_m
    {
      get
      {
        QuestCharacterM questM;
        if (!MasterData.QuestCharacterM.TryGetValue(this.quest_m_QuestCharacterM, out questM))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterM[" + (object) this.quest_m_QuestCharacterM + "]"));
        return questM;
      }
    }
  }
}
