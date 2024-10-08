﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static QuestStoryMission Parse(MasterDataReader reader) => new QuestStoryMission()
    {
      ID = reader.ReadInt(),
      quest_s_QuestStoryS = reader.ReadInt(),
      priority = reader.ReadInt(),
      name = reader.ReadString(true),
      entity_type_CommonRewardType = reader.ReadInt(),
      entity_id = reader.ReadInt(),
      quantity = reader.ReadInt()
    };

    public QuestStoryS quest_s
    {
      get
      {
        QuestStoryS questStoryS;
        if (!MasterData.QuestStoryS.TryGetValue(this.quest_s_QuestStoryS, out questStoryS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryS[" + (object) this.quest_s_QuestStoryS + "]"));
        return questStoryS;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
