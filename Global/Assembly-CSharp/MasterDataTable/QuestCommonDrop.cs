﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCommonDrop
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestCommonDrop
  {
    public int ID;
    public int quest_type_CommonQuestType;
    public int quest_s_id;
    public int priority;
    public int entity_type_CommonRewardType;
    public int entity_id;
    public int quantity;

    public static QuestCommonDrop Parse(MasterDataReader reader)
    {
      return new QuestCommonDrop()
      {
        ID = reader.ReadInt(),
        quest_type_CommonQuestType = reader.ReadInt(),
        quest_s_id = reader.ReadInt(),
        priority = reader.ReadInt(),
        entity_type_CommonRewardType = reader.ReadInt(),
        entity_id = reader.ReadInt(),
        quantity = reader.ReadInt()
      };
    }

    public CommonQuestType quest_type => (CommonQuestType) this.quest_type_CommonQuestType;

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
