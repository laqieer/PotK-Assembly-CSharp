// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryMission
  {
    public int ID;
    public int quest_s_QuestStoryS;
    public int priority;
    public string name;
    public int entity_type_CommonRewardType;
    public int entity_id;
    public int quantity;

    public static QuestStoryMission Parse(MasterDataReader reader)
    {
      return new QuestStoryMission()
      {
        ID = reader.ReadInt(),
        quest_s_QuestStoryS = reader.ReadInt(),
        priority = reader.ReadInt(),
        name = reader.ReadString(true),
        entity_type_CommonRewardType = reader.ReadInt(),
        entity_id = reader.ReadInt(),
        quantity = reader.ReadInt()
      };
    }

    public QuestStoryS quest_s
    {
      get
      {
        QuestStoryS questS;
        if (!MasterData.QuestStoryS.TryGetValue(this.quest_s_QuestStoryS, out questS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryS[" + (object) this.quest_s_QuestStoryS + "]"));
        return questS;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
